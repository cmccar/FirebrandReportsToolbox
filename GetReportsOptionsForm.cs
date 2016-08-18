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

namespace FirebrandReportsToolbox
{
    public partial class GetReportsOptionsForm : Form
    {
        public DataTable Reports;
        public BrandName Brand;
        public DateTime StartTime;
        public DateTime EndTime;

        public GetReportsOptionsForm(BrandName _brand)
        {
            InitializeComponent();
            Brand = _brand;
            AcceptButton = getReportsButton;
        }

        private void getReportsButton_Click(object sender, EventArgs e)
        {
            if (startDateTimePicker.Value > endDateTimePicker.Value)
            {
                MessageBox.Show("Please enter a start time that is earlier than the end time entered.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            ReportsDriver.GetReports(startDateTimePicker.Value, endDateTimePicker.Value, Brand, ParseLoadedReports);
        }

        public void ParseLoadedReports(DateTime _startTime, DateTime _endTime, DataTable _reportsDataTable)
        {
            BeginInvoke((MethodInvoker)delegate
            {
                Reports = _reportsDataTable;
                StartTime = _startTime;
                EndTime = _endTime;
                DialogResult = DialogResult.OK;
                Close();
            });
        }
    }
}
