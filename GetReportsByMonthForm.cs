using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FirebrandReportsToolbox.DataClasses;

namespace FirebrandReportsToolbox
{
    public partial class GetReportsByMonthForm : Form
    {
        private DataTable reports;
        public DataTable Reports { get { return reports; } }

        private BrandName brandName;
        public BrandName BrandName { get { return brandName; } }

        private Month selectedMonth;
        public Month SelectedMonth { get { return selectedMonth; } }

        public GetReportsByMonthForm(BrandName _brandName)
        {
            InitializeComponent();

            brandName = _brandName;
            AcceptButton = getReportsButton;

            string[] monthNames = System.Globalization.CultureInfo.CurrentCulture.DateTimeFormat.MonthNames;

            for (int i = 1; i <= monthNames.Length; i++)
            {
                // Last index is null
                if (string.IsNullOrEmpty(monthNames[i]))
                    break;
                Month month = FileSystemDriver.GRef.BrandsMonthsDic[brandName].MonthNumsToMonth[i];
                monthsComboBox.Items.Add(new ComboBoxMonthItem(month.Name, month));
            }

            int monthNum = DateTime.Now.Month;
            monthsComboBox.SelectedIndex = monthNum - 1;
        }

        private void getReportsButton_Click(object sender, EventArgs e)
        {
            ReportsDriver.GetReports(brandName, selectedMonth, FirebrandReportsToolboxForm.GRef.ParseLoadedReports);
            DialogResult = DialogResult.OK;
            Close();
        }

        private void monthsComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedMonth = ((ComboBoxMonthItem)monthsComboBox.SelectedItem).Value;
        }

        private class ComboBoxMonthItem
        {
            public string Name;
            public Month Value;
            public ComboBoxMonthItem(string name, Month value)
            {
                Name = name;
                Value = value;
            }
            public override string ToString()
            {
                // Generates the text shown in the combo box
                return Name;
            }
        }
    }
}
