using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Google.GData.Client;
using Google.GData.Spreadsheets;
using System.Windows.Forms;
using System.Data;
using System.IO;
using FirebrandReportsToolbox.DataClasses;

namespace FirebrandReportsToolbox
{
    public enum BrandName
    {
        [Description("Brew Dr.")]
        BrewDr,
        [Description("Love Beets")]
        LoveBeets,
        [Description("Nutpods")]
        Nutpods,
        [Description("Peeled Snacks")]
        PeeledSnacks,
        [Description("Runa")]
        Runa
    }

    public static class ReportsDriver
    {
        public delegate void ReportsLoadedDelegate(BrandName _brandName, Month _month, DataTable _reportsDataTable);
        private static ReportsLoadedDelegate handler;
        // Generate the final reports datatable for the brand, once done call the delegate to return to main form
        public static void GetReports(BrandName _brandName, Month _month, Action<BrandName, Month, DataTable> _reportsLoadedMethod)
        {
            handler = new ReportsLoadedDelegate(_reportsLoadedMethod);
            switch (_brandName)
            {
                case BrandName.Runa:
                    GetRunaReports(_brandName, _month);
                    break;
            }
        }

        private const string RunaSalesStartCol = "BT"; // Column in master spreadsheet in which Runa sales data begins
        private const string RunaSalesEndCol = "DC"; // Column in master spreadsheet in which Runa sales data ends
        private static void GetRunaReports(BrandName _brandName, Month _month)
        {
            Task.Factory.StartNew(() =>
            {
                try
                {
                    FirebrandReportsToolboxForm.GRef.NewEvent(EventType.Information, "Creating " + Utility.GetDescription(_brandName) + "'s " + _month.Name + " reports data table.");

                    DataTable runaReportsDataTable = CreateDataTable(_brandName, Utility.LetterToColumn(RunaSalesStartCol), Utility.LetterToColumn(RunaSalesEndCol));
                    handler.Invoke(_brandName, _month, runaReportsDataTable);

                    FirebrandReportsToolboxForm.GRef.NewEvent(EventType.Information,
                        "Successfully created " + Utility.GetDescription(_brandName) + "'s final reports data table. Make any needed edits, when done click \"Export table to excel\" option under the \"File\" menu.");
                }
                catch(Exception ex)
                {
                    FirebrandReportsToolboxForm.GRef.NewEvent(EventType.Error, "Error creating Runa reports data table: " + ex.Message);
                }
            });
        }


        private const string SheetName = "Submissions";
        private const string BrandCol = "B";
        private const string SharedFieldsData1StartCol = "C"; // Column in master spreadsheet in which shared fields data 1 begins
        private const string SharedFieldsData1EndCol = "J"; // Column in master spreadsheet in which shared fields data 1 ends
        private const string SharedFieldsData2StartCol = "V"; // Column in master spreadsheet in which shared fields data 2 begins
        private const string SharedFieldsData2EndCol = "BS"; // Column in master spreadsheet in which shared fields data 2 ends
        private const string SubmissionIdCol = "DE";
        private static DataTable CreateDataTable(BrandName _brand, int _brandSalesStartCol, int _brandSalesEndCol)
        {
            try
            {
                // Get all cells from the sheet
                IList<IList<object>> allCells = GoogleApiDriver.GetSheetValues(SheetName);
                // Determine which rows have reports for the brand argument passed in
                List<int> brandRowNums = new List<int>();
                // Always add 0'th row (column headers)
                brandRowNums.Add(0);
                int brandCol = Utility.LetterToColumn(BrandCol);
                for (int i = 0; i < allCells.Count; i++)
                {
                    // If brand name matches, record row number
                    if (allCells[i][brandCol].ToString() == Enum.GetName(typeof(BrandName), _brand))
                        brandRowNums.Add(i);
                }

                // Create nested list to eventually become final reports data table
                List<List<object>> reportsNestedList = new List<List<object>>();

                int sharedFields1Start = Utility.LetterToColumn(SharedFieldsData1StartCol);
                int sharedFields1End = Utility.LetterToColumn(SharedFieldsData1EndCol);
                int sharedFields2Start = Utility.LetterToColumn(SharedFieldsData2StartCol);
                int sharedFields2End = Utility.LetterToColumn(SharedFieldsData2EndCol);
                int submissionIdCol = Utility.LetterToColumn(SubmissionIdCol);

                // Iterate over all rows for this brand and append each relevant section of the sheet
                foreach (int rowNum in brandRowNums)
                {
                    List<object> rowList = new List<object>();
                    // Add shared fields 1 to this row
                    rowList.AddRange(allCells[rowNum].Skip(sharedFields1Start).Take(sharedFields1End - sharedFields1Start).ToList<object>());
                    // Add shared fields 2 to this row
                    rowList.AddRange(allCells[rowNum].Skip(sharedFields2Start).Take(sharedFields2End - sharedFields2Start).ToList<object>());
                    // Add brand's sales fields to this row
                    rowList.AddRange(allCells[rowNum].Skip(_brandSalesStartCol).Take(_brandSalesEndCol - _brandSalesStartCol).ToList<object>());
                    // Add the report's submission ID to this row
                    rowList.Add(allCells[rowNum][submissionIdCol]);
                    // Add row to the nested list
                    reportsNestedList.Add(rowList);
                }

                return Utility.NestedListToDataTable(reportsNestedList);
            }
            catch(Exception ex)
            {
                throw (ex);
            }
        }

        private static List<string> GetSubmissionNumbers(BrandName _brand, string _month)
        {
            List<string> submissionNumbers = new List<string>();

            string brandName = Enum.GetName(typeof(BrandName), _brand);
            string brandReportsPath = Environment.GetFolderPath(
                   Environment.SpecialFolder.Personal) + brandName + "\\" + _month + "\\";
            if (!Directory.Exists(brandReportsPath))
                Directory.CreateDirectory(brandReportsPath);

            string thisMonthsReportsFileName = brandReportsPath + brandName + "Reports.xlsx";
            if (File.Exists(thisMonthsReportsFileName))
            {
                var book = new LinqToExcel.ExcelQueryFactory(thisMonthsReportsFileName);

                var query =
                    from row in book.Worksheet(0)
                    let item = new
                    {
                        SubmissionId = row["Submission ID"].Cast<string>(),
                    }
                    select item;

                foreach(var row in query)
                {
                    submissionNumbers.Add(row.SubmissionId);
                }

            }
            return submissionNumbers;
        }
    }
}
