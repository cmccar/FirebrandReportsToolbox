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
        public delegate void ReportsLoadedDelegate(DateTime startTime, DateTime endTime, DataTable reportsDataTable);
        private static ReportsLoadedDelegate handler;
        // Generate the final reports datatable for the brand, once done call the delegate to return to main form
        public static void GetReports(DateTime _startTime, DateTime _endTime, BrandName _brand, Action<DateTime, DateTime, DataTable> _reportsLoadedMethod)
        {
            handler = new ReportsLoadedDelegate(_reportsLoadedMethod);
            switch (_brand)
            {
                case BrandName.Runa:
                    GetRunaReports(_startTime, _endTime, _brand);
                    break;
            }
        }

        private const string RunaSalesStartCol = "BU"; // Column in master spreadsheet in which Runa sales data begins
        private const string RunaSalesEndCol = "DD"; // Column in master spreadsheet in which Runa sales data ends
        private static void GetRunaReports(DateTime _startTime, DateTime _endTime, BrandName _brand)
        {
            Task.Factory.StartNew(() =>
            {
                FirebrandReportsToolboxForm.GRef.NewEvent(EventType.Information, "Creating " + Utility.GetDescription(_brand) + " reports data table.");

                SpreadsheetQuery query = new SpreadsheetQuery();
                query.Title = "Firebrand Master Reports Sheet";
                SpreadsheetFeed feed = GoogleApiDriver.MasterSpreadsheetService.Query(query);

                if (feed.Entries.Count == 0)
                {
                    MessageBox.Show("No Google spreadsheets found!", "No Spreadsheets", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                SpreadsheetEntry masterReportsSpreadsheet = (SpreadsheetEntry)feed.Entries[0];
                WorksheetFeed wsFeed = masterReportsSpreadsheet.Worksheets;
                // Get the sorted (by ('No' will be above 'Yes' rows) report complete, then by brand name) submissions worksheet
                AtomTextConstruct sortedSubmissionsTitle = new AtomTextConstruct(AtomTextConstructElementType.Title, "SortedSubmissions");
                WorksheetEntry sortedSubmissionsWorksheet = (WorksheetEntry)wsFeed.Entries.First(ws => ws.Title.Text == sortedSubmissionsTitle.Text);

                // Get start and end rows
                Tuple<uint, uint> startAndEndRows = GetStartAndEndRows(sortedSubmissionsWorksheet, _startTime, _endTime, _brand);
                if(startAndEndRows == null)
                {
                    FirebrandReportsToolboxForm.GRef.NewEvent(EventType.Error, "Error getting the start and end rows.");
                    return;
                }
                uint startRow = startAndEndRows.Item1, endRow = startAndEndRows.Item2;

                // Get shared data table
                List<List<string>> sharedNestedList = GetSharedReportData(sortedSubmissionsWorksheet, startRow, endRow);

                uint minCol = Utility.LetterToColumn(RunaSalesStartCol);
                uint maxCol = Utility.LetterToColumn(RunaSalesEndCol);

                // Get sales data table columns first
                CellFeed cellFeed = GoogleApiDriver.GetCellFeed(sortedSubmissionsWorksheet, 1, 1, minCol, maxCol);
                List<List<string>> salesColumns = Utility.CellFeedTo2DList(cellFeed);

                // Get sales data table
                cellFeed = GoogleApiDriver.GetCellFeed(sortedSubmissionsWorksheet, startRow, endRow, minCol, maxCol);
                List<List<string>> salesDataTable = Utility.CellFeedTo2DList(cellFeed);

                // Put together columns and body
                salesDataTable.Insert(0, salesColumns[0]);

                FirebrandReportsToolboxForm.GRef.NewEvent(EventType.Information, "Created " + Utility.GetDescription(_brand) + "'s sales fields data table.");

                // Make final data table
                List<List<string>> finalDataTable = Utility.Combine2DLists(sharedNestedList, salesDataTable);

                DataTable final = Utility.NestedListToDataTable(finalDataTable);
                handler.Invoke(_startTime, _endTime, final);
             
                FirebrandReportsToolboxForm.GRef.NewEvent(EventType.Information, "Successfully created " + Utility.GetDescription(_brand) + "'s final reports data table.");
            });
        }

        #region Shared Fields Data

        private const string SharedFieldsData1StartCol = "D"; // Column in master spreadsheet in which shared fields data 1 begins
        private const string SharedFieldsData1EndCol = "K"; // Column in master spreadsheet in which shared fields data 1 ends
        private const string SharedFieldsData2StartCol = "W"; // Column in master spreadsheet in which shared fields data 2 begins
        private const string SharedFieldsData2EndCol = "BT"; // Column in master spreadsheet in which shared fields data 2 ends
        // Returns a merged nested list of both of the shared fields data for the reports
        private static List<List<string>> GetSharedReportData(WorksheetEntry _worksheetEntry, uint _startRow, uint _endRow)
        {
            uint minCol1 = Utility.LetterToColumn(SharedFieldsData1StartCol);
            uint maxCol1 = Utility.LetterToColumn(SharedFieldsData1EndCol);

            // Get shared data table 1 columns first (first part of report)
            CellFeed cellFeed = GoogleApiDriver.GetCellFeed(_worksheetEntry, 1, 1, minCol1, maxCol1);
            List <List<string>> sharedDateTable1Columns = Utility.CellFeedTo2DList(cellFeed);

            // Get shared data table 1 body
            cellFeed = GoogleApiDriver.GetCellFeed(_worksheetEntry, _startRow, _endRow, minCol1, maxCol1);
            List<List<string>> sharedDateTable1 = Utility.CellFeedTo2DList(cellFeed);

            // Put together columns and body
            sharedDateTable1.Insert(0, sharedDateTable1Columns[0]);

            FirebrandReportsToolboxForm.GRef.NewEvent(EventType.Information, "Created shared fields data table #1.");
         
            uint minCol2 = Utility.LetterToColumn(SharedFieldsData2StartCol);
            uint maxCol2 = Utility.LetterToColumn(SharedFieldsData2EndCol);

            // Get shared data table 2 columns first (second part of report)
            cellFeed = GoogleApiDriver.GetCellFeed(_worksheetEntry, 1, 1, minCol2, maxCol2);
            List<List<string>> sharedDateTable2Columns = Utility.CellFeedTo2DList(cellFeed);

            // Then shared data table 2 body
            cellFeed = GoogleApiDriver.GetCellFeed(_worksheetEntry, _startRow, _endRow, minCol2, maxCol2);
            List<List<string>> sharedDateTable2 = Utility.CellFeedTo2DList(cellFeed);

            // Put together columns and body
            sharedDateTable2.Insert(0, sharedDateTable2Columns[0]);

            FirebrandReportsToolboxForm.GRef.NewEvent(EventType.Information, "Created shared fields data table #2.");

            // Put together final shared data table
            List<List<string>> allSharedDataTable = Utility.Combine2DLists(sharedDateTable1, sharedDateTable2);
           
            return allSharedDataTable;
        }

        #endregion // Shared Fields Data

        private const string SubmissionDateAndBrandStartCol = "A"; // Column in master spreadsheet in which submission date and brand data starts
        private const string SubmissionDateAndBrandEndCol = "B"; // Column in master spreadsheet in which submission date and brand data ends
        private static Tuple<uint, uint> GetStartAndEndRows(WorksheetEntry _sortedSubmissionsWorksheet, DateTime _startTime, DateTime _endTime, BrandName _brand)
        {
            string brandName = Utility.GetDescription(_brand);

            CellFeed cellFeed = GoogleApiDriver.GetCellFeed(_sortedSubmissionsWorksheet, 2, _sortedSubmissionsWorksheet.RowCount.Count, Utility.LetterToColumn(SubmissionDateAndBrandStartCol), Utility.LetterToColumn(SubmissionDateAndBrandEndCol));
            if(cellFeed == null)
            {
                FirebrandReportsToolboxForm.GRef.NewEvent(EventType.Error, "Error retrieving the brand's cell feed's start and end rows.");
                return null;
            }

            List<List<string>> brandAndDemoIdNestedList = Utility.CellFeedTo2DList(cellFeed);


            uint startRow = 0, endRow = 0;
            for (int i = 0; i < brandAndDemoIdNestedList.Count; i++)
            {
                List<string> rowList = brandAndDemoIdNestedList[i];
                DateTime rowSubmissionDate = new DateTime();
                bool dateTimeParseSuccess = false;
                string rowBrandName = null;
                for (int j = 0; j < rowList.Count; j++)
                {
                    if (rowList[j] == null)
                        break;
                    switch (j)
                    {
                        case 0:
                            if (!(dateTimeParseSuccess = DateTime.TryParse(rowList[j], out rowSubmissionDate)))
                            {
                                FirebrandReportsToolboxForm.GRef.NewEvent(EventType.Error, "Error parsing row's submission date, invalid Datetime format.");
                            }
                            break;

                        case 1:
                            rowBrandName = rowList[j];
                            break;
                    }
                }

                if (!dateTimeParseSuccess)
                {
                    // This means the rows are into empty rows, set end row and break
                    if (startRow != 0)
                    {
                        endRow = (uint)i;
                        break;
                    }
                    else
                    {
                        continue;
                    }
                }
                  
                if (rowBrandName == brandName)
                {
                    if (startRow == 0)
                    {
                        if (rowSubmissionDate >= _startTime)
                        {
                            startRow = (uint)i;
                        }
                    }
                    else // Look for endRow now
                    {
                        if (rowSubmissionDate >= _endTime)
                        {
                            endRow = (uint)i;
                            break;
                        }
                    }
                }
                else
                {
                    // This means the rows are into a new brand, set end row now
                    if (startRow != 0)
                    {
                        endRow = (uint)i;
                        break;
                    }
                }
            }

            if (startRow != 0 && endRow != 0)
                return new Tuple<uint, uint>(startRow, endRow);
            else
                return null;
        }
    }
}
