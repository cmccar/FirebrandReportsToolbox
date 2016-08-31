using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using FirebrandReportsToolbox.DataClasses;


namespace FirebrandReportsToolbox
{
    public class FileSystemDriver
    {
        // Global reference
        private static FileSystemDriver gRef;
        public static FileSystemDriver GRef {  get { return gRef; } }

        // Mapping of brand names to months object, which provides file path information
        private Dictionary<BrandName, Months> brandMonthsDic;
        public Dictionary<BrandName, Months> BrandsMonthsDic { get { return brandMonthsDic; } }

        private string documentsFilePath;
        
        // Constructor
        public FileSystemDriver()
        {
            gRef = this;
            brandMonthsDic = new Dictionary<BrandName, Months>();
            documentsFilePath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            CreateMonthObjects();
        }

        public bool CreateBrandReportsExcel(BrandName _brandName, Month _month, DataTable _dataTable)
        {
            try
            {
                if (!Directory.Exists(_month.FilePath))
                    Directory.CreateDirectory(_month.FilePath);
                string fileName = _month.FilePath + "\\" +Utility.GetDescription(_brandName) + _month.Name + _month.StartTime.ToString("yyyy") + "Reports.xlsx";
                
                if (Utility.SaveAsExcelWorkbook(_brandName, fileName, _dataTable))
                {
                    string filePath = Path.GetDirectoryName(fileName);
                    FirebrandReportsToolboxForm.GRef.NewEvent(EventType.Information,
                        "Succesfully created " + Utility.GetDescription(_brandName) + " reports Excel spreadsheet at " + fileName);
                    Properties.Settings.Default.ReportsDirectory = filePath;
                }
                else
                {
                    FirebrandReportsToolboxForm.GRef.NewEvent(EventType.Information,
                        "Error creating " + Utility.GetDescription(_brandName) + " reports Excel spreadsheet.");
                }
            }
            catch(Exception ex)
            {
                FirebrandReportsToolboxForm.GRef.NewEvent(EventType.Error,
                    "Error creating Excel reports spreadsheet for " + Utility.GetDescription(_brandName) + ": " + ex.Message);
            }
            return false;
        }

        private void CreateMonthObjects()
        {
            string[] monthNames = System.Globalization.CultureInfo.CurrentCulture.DateTimeFormat.MonthNames;
            string year = DateTime.Now.ToString("yyyy");

            for (int i = 1; i <= monthNames.Length; i++)
            {
                // Last index will be empty
                if (string.IsNullOrEmpty(monthNames[i - 1]))
                    break;

                DateTime firstDayOfMonth = new DateTime(DateTime.Now.Year, i, 1);
                DateTime lastDayOfMonth = firstDayOfMonth.AddMonths(1).AddSeconds(-1);

                foreach (BrandName brandName in Enum.GetValues(typeof(BrandName)))
                {
                    if (brandName != BrandName.Runa)
                        continue;
                    if (!brandMonthsDic.ContainsKey(brandName))
                        brandMonthsDic.Add(brandName, new Months());

                    string brandMonthFilePath = Path.Combine(documentsFilePath, Utility.GetDescription(brandName) + "\\" + monthNames[i - 1] + year);
                    switch (brandName)
                    {
                        case BrandName.Runa:
                            brandMonthsDic[brandName].MonthNumsToMonth.Add(i, new Month(monthNames[i - 1], brandMonthFilePath, firstDayOfMonth, lastDayOfMonth));
                            break;
                    }
                }
            }
        }

    }
}
