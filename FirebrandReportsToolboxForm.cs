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

        #region Events

        private List<EventType> filterEventTypes = new List<EventType> { EventType.Information, EventType.Warning, EventType.Error };
        private List<ListViewItem> eventsListViewItems = new List<ListViewItem>();

        /// <summary>
        /// Updates the events message box on the bottom of the form
        /// </summary>
        /// <param name="eventType">Type of event</param>
        /// <param name="message">Message to display</param>
        public void NewEvent(EventType eventType, string message)
        {
            BeginInvoke((MethodInvoker)delegate
            {
                if (eventsListViewItems.Count > 999)
                    eventsListViewItems.RemoveAt(eventsListViewItems.Count - 1);
                ListViewItem lvi = new ListViewItem(DateTime.Now.ToUniversalTime().ToString());
                lvi.SubItems.Add(DateTime.Now.ToString());
                lvi.SubItems.Add(message);
                lvi.Tag = eventType;
                switch (eventType)
                {
                    case EventType.Information:
                        lvi.BackColor = Color.Green;
                        lvi.ImageIndex = 0;
                        break;

                    case EventType.Warning:
                        lvi.BackColor = Color.Yellow;
                        lvi.ImageIndex = 1;
                        break;

                    case EventType.Error:
                        lvi.BackColor = Color.Red;
                        lvi.ImageIndex = 2;
                        break;
                }
                eventsListViewItems.Insert(0, lvi);
            });
        }

        #endregion //Events
    }

    public enum EventType
    {
        Information,
        Warning,
        Error
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
