using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FirebrandReportsToolbox
{
    public partial class FirebrandReportsToolboxForm : Form
    {
        public static FirebrandReportsToolboxForm GRef;

        public FirebrandReportsToolboxForm()
        {
            InitializeComponent();
            // Populate brands combo box
            brandsComboBox.DisplayMember = "Text";
            brandsComboBox.ValueMember = "Value";
            var brands = Utility.GetEnumValues<BrandName>();
            foreach (BrandName brand in brands)
            {
                var brandItem = new ComboBoxItem();
                brandItem.Text = Utility.GetDescription(brand);
                brandItem.Value = brand;
                brandsComboBox.Items.Add(brandItem);
            }
            brandsComboBox.SelectedIndex = 0;
        }

        private void FirebrandReportsToolboxForm_Load(object sender, EventArgs e)
        {
            GRef = this;
            GoogleApiDriver.ConfigureOAuth2();
        }

        private void getReportsButton_Click(object sender, EventArgs e)
        {
            var brandSelected = (ComboBoxItem)brandsComboBox.SelectedItem;
            var reports = ReportsDriver.GetReports((BrandName)brandSelected.Value);
            return;
        }
    }

    public class ComboBoxItem
    {
        public string Text { get; set; }
        public object Value { get; set; }

        public override string ToString()
        {
            return Text;
        }
    }
}
