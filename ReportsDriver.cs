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
        public static List<object> GetReports(BrandName _brand)
        {
            switch (_brand)
            {
                case BrandName.Runa:
                    return GetRunaReports();
            }
            return null;
        }

        private const string SharedData1StartCol = "A";
        private const string SharedData1EndCol = "I";

        private const string SharedData2StartCol = "V";
        private const string SharedData2EndCol = "BO";
        private static List<List<string>> GetSharedReportData(WorksheetEntry _worksheet)
        {
            // Get shared data table 1 first (first part of report)
            CellQuery cellQuery = new CellQuery(_worksheet.CellFeedLink);
            cellQuery.MinimumRow = 1;
            uint minCol = Utility.LetterToColumn(SharedData1StartCol);
            uint maxCol = Utility.LetterToColumn(SharedData1EndCol);
            cellQuery.MinimumColumn = minCol;
            cellQuery.MaximumColumn = maxCol;
            cellQuery.ReturnEmpty = ReturnEmptyCells.yes;
            CellFeed cellFeed = GoogleApiDriver.MasterSpreadsheetService.Query(cellQuery);
            List<List<string>> sharedDateTable1 = Utility.CellFeedTo2DList(cellFeed);

            FirebrandReportsToolboxForm.GRef.NewEvent(EventType.Information, "Finished getting sharedDataTable1");

            // Then shared data table 2 (second part of report)
            cellQuery = new CellQuery(_worksheet.CellFeedLink);
            cellQuery.MinimumRow = 1;
            minCol = Utility.LetterToColumn(SharedData2StartCol);
            maxCol = Utility.LetterToColumn(SharedData2EndCol);
            cellQuery.MinimumColumn = minCol;
            cellQuery.MaximumColumn = maxCol;
            cellQuery.ReturnEmpty = ReturnEmptyCells.yes;
            cellFeed = GoogleApiDriver.MasterSpreadsheetService.Query(cellQuery);
            List<List<string>> sharedDateTable2 = Utility.CellFeedTo2DList(cellFeed);

            FirebrandReportsToolboxForm.GRef.NewEvent(EventType.Information, "Finished getting sharedDataTable2");

            List<List<string>> allSharedDataTable = Utility.Combine2DLists(sharedDateTable1, sharedDateTable2);

            FirebrandReportsToolboxForm.GRef.NewEvent(EventType.Information, "Finished getting allSharedDataTable");

            return allSharedDataTable;
        }

        private const string RunaSalesStartCol = "BP";
        private const string RunaSalesEndCol = "CY";
        private static List<object> GetRunaReports()
        {
            Task.Factory.StartNew(() =>
            {
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
                WorksheetEntry worksheet = (WorksheetEntry)wsFeed.Entries[0];

                // Get shared data table
                List<List<string>> sharedNestedList = GetSharedReportData(worksheet);

                // Get sales data table
                CellQuery cellQuery = new CellQuery(worksheet.CellFeedLink);
                cellQuery.MinimumRow = 1;
                uint minCol = Utility.LetterToColumn(RunaSalesStartCol);
                uint maxCol = Utility.LetterToColumn(RunaSalesEndCol);
                cellQuery.MinimumColumn = minCol;
                cellQuery.MaximumColumn = maxCol;
                cellQuery.ReturnEmpty = ReturnEmptyCells.yes;
                CellFeed cellFeed = GoogleApiDriver.MasterSpreadsheetService.Query(cellQuery);
                List<List<string>> salesNestedList = Utility.CellFeedTo2DList(cellFeed);

                FirebrandReportsToolboxForm.GRef.NewEvent(EventType.Information, "Finished getting salesNestedList");

                // Make final data table
                List<List<string>> finalDataTable = Utility.Combine2DLists(sharedNestedList, salesNestedList);

                FirebrandReportsToolboxForm.GRef.NewEvent(EventType.Information, "Finished getting finalDataTable");

                Utility.SaveAsExcelWorkbook("RunaSpreadsheet", Utility.NestedListToDataTable(finalDataTable));

                FirebrandReportsToolboxForm.GRef.NewEvent(EventType.Information, "Made excel sheet");


            });
            return null;
        }
    }
}
