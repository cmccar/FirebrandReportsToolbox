using Google.GData.Spreadsheets;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FirebrandReportsToolbox
{
    public enum EventType
    {
        Information,
        Warning,
        Error
    }
    public static class Utility
    {
        public static int GetRandomUnusedPort()
        {
            var listener = new System.Net.Sockets.TcpListener(IPAddress.Loopback, 0);
            listener.Start();
            var port = ((IPEndPoint)listener.LocalEndpoint).Port;
            listener.Stop();
            return port;
        }

        public static IEnumerable<T> GetEnumValues<T>()
        {
            return Enum.GetValues(typeof(T)).Cast<T>();
        }

        public static string GetDescription(this Enum value)
        {
            Type type = value.GetType();
            string name = Enum.GetName(type, value);
            if (name != null)
            {
                FieldInfo field = type.GetField(name);
                if (field != null)
                {
                    DescriptionAttribute attr =
                           Attribute.GetCustomAttribute(field,
                             typeof(DescriptionAttribute)) as DescriptionAttribute;
                    if (attr != null)
                    {
                        return attr.Description;
                    }
                }
            }
            return null;
        }

        public static string ColumnToLetter(uint column)
        {
            uint temp;
            string letter = string.Empty;
            while (column > 0)
            {
                temp = (column - 1) % 26;
                letter = (char)(temp + 65) + letter;
                column = (column - temp - 1) / 26;
            }
            return letter;
        }

        public static int LetterToColumn(string letter)
        {
            int column = 0;
            for (var i = 0; i < letter.Length; i++)
            {
                column += ((int)letter[i] - 64) * (int)Math.Pow(26, letter.Length - i - 1);
            }
            return column - 1;
        }

        public static bool SaveAsExcelWorkbook(BrandName _brand, string _filePath, DataTable _table)
        {
            Microsoft.Office.Interop.Excel.Application excel;
            Microsoft.Office.Interop.Excel.Workbook workBook;
            Microsoft.Office.Interop.Excel.Worksheet workSheet;
            Microsoft.Office.Interop.Excel.Range cellRange;

            try
            {
                excel = new Microsoft.Office.Interop.Excel.Application();
                excel.Visible = false;
                excel.DisplayAlerts = false;
                workBook = excel.Workbooks.Add(Type.Missing);


                workSheet = (Microsoft.Office.Interop.Excel.Worksheet)workBook.ActiveSheet;
                workSheet.Name = "ReportsWorksheet";

                workSheet.Range[workSheet.Cells[1, 1], workSheet.Cells[1, 8]].Merge();
                workSheet.Cells[1, 1] = Utility.GetDescription(_brand) + " Reports";
                workSheet.Cells.Font.Size = 15;


                int rowcount = 2;

                foreach (DataRow datarow in _table.Rows)
                {
                    rowcount += 1;
                    for (int i = 1; i <= _table.Columns.Count; i++)
                    {

                        if (rowcount == 3)
                        {
                            workSheet.Cells[2, i] = _table.Columns[i - 1].ColumnName;
                            workSheet.Cells.Font.Color = System.Drawing.Color.Black;

                        }

                        workSheet.Cells[rowcount, i] = datarow[i - 1].ToString();

                        if (rowcount > 3)
                        {
                            if (i == _table.Columns.Count)
                            {
                                if (rowcount % 2 == 0)
                                {
                                    cellRange = workSheet.Range[workSheet.Cells[rowcount, 1], workSheet.Cells[rowcount, _table.Columns.Count]];
                                }

                            }
                        }

                    }

                }

                cellRange = workSheet.Range[workSheet.Cells[1, 1], workSheet.Cells[rowcount, _table.Columns.Count]];
                cellRange.EntireColumn.AutoFit();
                Microsoft.Office.Interop.Excel.Borders border = cellRange.Borders;
                border.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                border.Weight = 2d;

                cellRange = workSheet.Range[workSheet.Cells[1, 1], workSheet.Cells[2, _table.Columns.Count]];
                workBook.SaveAs(_filePath);
                workBook.Close();
                excel.Quit();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
            finally
            {
                workSheet = null;
                cellRange = null;
                workBook = null;
            }
        }

        public static System.Data.DataTable ExportToDataTable(CellFeed _cellFeed)
        {
            System.Data.DataTable table = new System.Data.DataTable();

            int i = 0, j = 0;
            string cellAddr = string.Empty;
            string oldCellAddr = string.Empty;
            DataRow row = null;
            foreach (CellEntry ce in _cellFeed.Entries)
            {
                if (!string.IsNullOrEmpty(cellAddr))
                    oldCellAddr = cellAddr;

                cellAddr = ce.Title.Text;

                if (string.IsNullOrEmpty(oldCellAddr))
                    oldCellAddr = cellAddr;

                Regex rg = new Regex("\\d+");
                Match rowNum = rg.Match(cellAddr);
                Match oldRowNum = rg.Match(oldCellAddr);

                if (rowNum.ToString() != oldRowNum.ToString())
                {
                    if (j > 1)
                        table.Rows.Add(row);
                    row = table.NewRow();
                    j++;
                    i = 0;
                }

                if (j == 0)
                    table.Columns.Add(ce.InputValue, typeof(string));
                else
                    row[i] = ce.InputValue;

                i++;
            }
            if (row != null) table.Rows.Add(row);
            return table;

        }

        public static List<List<string>> CellFeedTo2DList(CellFeed _cellFeed)
        {
            List<List<string>> nestedList = new List<List<string>>();

            int i = 0;
            string cellAddr = string.Empty;
            string oldCellAddr = string.Empty;
            List<string> row = new List<string>();
            foreach (CellEntry ce in _cellFeed.Entries)
            {
                if (!string.IsNullOrEmpty(cellAddr))
                    oldCellAddr = cellAddr;

                cellAddr = ce.Title.Text;

                if (string.IsNullOrEmpty(oldCellAddr))
                    oldCellAddr = cellAddr;

                Regex rg = new Regex("\\d+");
                Match rowNum = rg.Match(cellAddr);
                Match oldRowNum = rg.Match(oldCellAddr);

                if (rowNum.ToString() != oldRowNum.ToString())
                {
                    nestedList.Add(row);
                    row = new List<string>();
                    i = 0;
                }

                row.Add(ce.Value);

                i++;
            }
            if (row != null) nestedList.Add(row);
            return nestedList;
        }

        public static List<List<string>> Combine2DLists(List<List<string>> _list1, List<List<string>> _list2)
        {
            List<List<string>> combined2DList = new List<List<string>>();

            for(int i = 0; i < _list1.Count; i++)
            {
                List<string> combinedList = new List<string>();
                combinedList.AddRange(_list1[i]);
                combinedList.AddRange(_list2[i]);
                combined2DList.Add(combinedList);
            }

            return combined2DList;
        }

        public static DataTable NestedListToDataTable(this List<List<object>> _list)
        {
            DataTable tmp = new DataTable();
            for (int i = 0; i < _list.Count; i++)
            {
                if (i == 0)
                {
                    foreach(string s in _list[i])
                    {
                        tmp.Columns.Add(s);
                    }
                }
                else
                {
                    tmp.Rows.Add(_list[i].ToArray());
                }
            }
            return tmp;
        }

    }
}
