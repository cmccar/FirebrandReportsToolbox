using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
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

            if (!Directory.Exists(Properties.Settings.Default.ReportsDirectory))
            {
                if (!Directory.Exists(Properties.Settings.Default.ReportsDirectory))
                    Directory.CreateDirectory(Properties.Settings.Default.ReportsDirectory);
            }

            var brands = Utility.GetEnumValues<BrandName>();
            TreeNode rootNode = GetLeftTreeViewNode("rootNode");
            foreach (BrandName brand in brands)
            {
                if (brand == BrandName.Runa)
                {
                    TreeNode node = new TreeNode(Utility.GetDescription(brand));
                    node.Tag = Utility.GetDescription(brand);
                    rootNode.Nodes.Add(node);
                }
            }
        }

        private void FirebrandReportsToolboxForm_Load(object sender, EventArgs e)
        {
            GRef = this;
            GoogleApiDriver.Configure();
        }

        #region Menu Click Events

        private void fileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            exportTableToExcelToolStripMenuItem.Enabled = IsDataTableLoaded;
        }

        private void exportTableToExcelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Thread exportToExcelThread = new Thread(() => {
                try
                {
                    string fileName = Utility.GetDescription(LastBrandReportsGeneratedFor) + "Reports_" + LastStartTime.ToString("MM.dd.yy") + "-" + LastEndTime.ToString("MM.dd.yy") + ".xlsx";
                    SaveFileDialog saveFileDialog = new SaveFileDialog();
                    saveFileDialog.DefaultExt = ".xlsx";
                    saveFileDialog.InitialDirectory = Properties.Settings.Default.ReportsDirectory;
                    saveFileDialog.FileName = fileName;
                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        if (!saveFileDialog.FileName.EndsWith(".xlsx"))
                        {
                            NewEvent(EventType.Error, "Please select a file with a .xlsx extension.");
                            return;
                        }

                        if (Utility.SaveAsExcelWorkbook(LastBrandReportsGeneratedFor, saveFileDialog.FileName, LastReportsDataTable))
                        {
                            string filePath = Path.GetDirectoryName(saveFileDialog.FileName);
                            NewEvent(EventType.Information, "Succesfully created " + Utility.GetDescription(LastBrandReportsGeneratedFor) + " reports Excel spreadsheet at " + fileName);
                            Properties.Settings.Default.ReportsDirectory = filePath;
                        }
                        else
                        {
                            NewEvent(EventType.Information, "Error creating " + Utility.GetDescription(LastBrandReportsGeneratedFor) + " reports Excel spreadsheet.");
                        }
                    }
                }
                catch (Exception ex)
                {
                    NewEvent(EventType.Information, "Error creating " + Utility.GetDescription(LastBrandReportsGeneratedFor) + " reports Excel spreadsheet: " + ex.Message);
                }
            });
            exportToExcelThread.SetApartmentState(ApartmentState.STA);
            exportToExcelThread.Start();
        }

        private void changeGoogleAccountToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //GoogleApiDriver.ConfigureOAuth2(true);
        }

        private void getReportsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            object tag = GetLastSelectedItemsTag();
            if (tag == null)
                return;
            BrandName brand = (BrandName)Enum.Parse(typeof(BrandName), tag.ToString());
            GetReportsOptionsForm getReportsOptionsForm = new GetReportsOptionsForm(brand);
            getReportsOptionsForm.ShowDialog();
        }

        #endregion // Menu Click Events

        public static BrandName LastBrandReportsGeneratedFor;
        public static DateTime LastStartTime = new DateTime();
        public static DateTime LastEndTime = new DateTime();
        public static DataTable LastReportsDataTable = new DataTable();
        public static bool IsDataTableLoaded = false;
        public void ParseLoadedReports(BrandName _brand, DateTime _startTime, DateTime _endTime, DataTable _reportsDataTable)
        {
            BeginInvoke((MethodInvoker)delegate
            {
                LastBrandReportsGeneratedFor = _brand;
                LastStartTime = _startTime;
                LastEndTime = _endTime;
                LastReportsDataTable = _reportsDataTable;

                // Reset data grid view
                rightSideDataGridView.Columns.Clear();
                rightSideDataGridView.Rows.Clear();

                // Add columns to datagrid view
                for (int i = 0; i < _reportsDataTable.Columns.Count; i++)
                {
                    DataColumn dc = _reportsDataTable.Columns[i];
                    rightSideDataGridView.Columns.Add(dc.ColumnName, dc.ColumnName);
                }

                // Add rows to datagrid view
                for (int i = 0; i < _reportsDataTable.Rows.Count; i++)
                {
                    DataRow dr = _reportsDataTable.Rows[i];
                    string firstItem = dr[0].ToString();
                    if (string.IsNullOrEmpty(firstItem))
                        continue;
                    rightSideDataGridView.Rows.Add(dr.ItemArray);
                }

                IsDataTableLoaded = true;
            });
        }

        #region UI Helper Functions

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
                FilterEvents();
            });
        }

        /// <summary>
        /// Filters the events list view based on the currently checked filters
        /// </summary>
        private void FilterEvents()
        {
            eventsListView.Items.Clear();
            eventsListView.Items.AddRange(eventsListViewItems.Where(i => filterEventTypes.Contains((EventType)i.Tag)).ToArray());
            this.ResizeEventsColumnHeaders();
        }

        #endregion //Events

        #region Click Events

        private ICloneable lastItemSelected;
        // List<TreeNode> dynamicallyAddedToTreeNodes;
        private void leftTreeView_MouseDown(object sender, MouseEventArgs e)
        {
            if (leftTreeView.HitTest(e.Location).Node == null)
            {
                LeftSideAfterSelectLogic(null);
            }
            else
            {
                lastItemSelected = leftTreeView.HitTest(e.Location).Node;
                LeftSideAfterSelectLogic(GetLastSelectedItemsTag());
            }
        }

        private void leftTreeView_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            leftTreeView.SelectedNode = e.Node;
        }

        /// <summary>
        /// Performs the left side after select logic
        /// </summary>
        /// <param name="tagSelected">The tag selected</param>
        public void LeftSideAfterSelectLogic(object tagSelected)
        {
            try
            {
                if (tagSelected != null)
                {
                    switch (tagSelected.ToString())
                    {
                        case "root":
                            DisplayCorrectContextMenuItems(null);
                            break;

                        // Brands are default
                        default:
                            DisplayCorrectContextMenuItems(new List<ContextMenuOption> { ContextMenuOption.GetReports });
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                NewEvent(EventType.Error, "Error: " + ex.Message);
            }
        }

        #endregion //Click Events


        #region Menu Options

        /// <summary>
        /// Enum order must match item order in designer for visibility toggle to work
        /// </summary>
        private enum ContextMenuOption
        {
            GetReports
        }

        /// <summary>
        /// Displays only the context menu options listed in the argument 
        /// </summary>
        /// <param name="_contextMenuOptionsToDisplay">The context menu options to display</param>
        private void DisplayCorrectContextMenuItems(List<ContextMenuOption> _contextMenuOptionsToDisplay)
        {
            foreach (ToolStripItem item in leftTreeViewContextMenuStrip.Items)
            {
                item.Visible = false;
            }

            // If null, keep all items hidden
            if (_contextMenuOptionsToDisplay != null)
            {
                foreach (ContextMenuOption contextMenuOption in _contextMenuOptionsToDisplay)
                {
                    leftTreeViewContextMenuStrip.Items[(int)contextMenuOption].Visible = true;
                }
            }
        }

        #endregion //Menu Options

        /// <summary>
        /// Reloads the dynamic aspects of the UI in a thread safe way
        /// </summary>
        public void ReloadUI()
        {
            BeginInvoke((MethodInvoker)delegate
            {
                FirebrandReportsToolboxForm_Load(null, null);
            });
        }

        /// <summary>
        /// Returns the text of either the last tree node or last list view item selected
        /// </summary>
        /// <returns>The text of either the last tree node or last list view item selected</returns>
        private string GetLastSelectedItemsText()
        {
            if (lastItemSelected != null)
            {
                if (lastItemSelected.GetType() == typeof(TreeNode))
                {
                    TreeNode lastSelectedTreeNode = (TreeNode)lastItemSelected;
                    if (lastSelectedTreeNode.Text != null)
                        return lastSelectedTreeNode.Text;
                }
                else if (lastItemSelected.GetType() == typeof(ListViewItem))
                {
                    ListViewItem listItemView = (ListViewItem)lastItemSelected;
                    if (listItemView.Text != null)
                        return listItemView.Text;
                }
            }
            return string.Empty;
        }

        /// <summary>
        /// Returns the name of either the last tree node or last list view item selected
        /// </summary>
        /// <returns>The name of either the last tree node or last list view item selected</returns>
        private string GetLastSelectedItemsName()
        {
            if (lastItemSelected != null)
            {
                if (lastItemSelected.GetType() == typeof(TreeNode))
                {
                    TreeNode lastSelectedTreeNode = (TreeNode)lastItemSelected;
                    if (lastSelectedTreeNode.Name != null)
                        return lastSelectedTreeNode.Name;
                }
                else if (lastItemSelected.GetType() == typeof(ListViewItem))
                {
                    ListViewItem listItemView = (ListViewItem)lastItemSelected;
                    if (listItemView.Name != null)
                        return listItemView.Name;
                }
            }
            return string.Empty;
        }

        /// <summary>
        /// Returns the tag of either the last tree node or last list view item selected
        /// </summary>
        /// <returns>The tag of either the last tree node or last list view item selected</returns>
        private object GetLastSelectedItemsTag()
        {
            if (lastItemSelected != null)
            {
                if (lastItemSelected.GetType() == typeof(TreeNode))
                {
                    TreeNode lastSelectedTreeNode = (TreeNode)lastItemSelected;
                    if (lastSelectedTreeNode.Tag != null)
                        return lastSelectedTreeNode.Tag;
                }
                else if (lastItemSelected.GetType() == typeof(ListViewItem))
                {
                    ListViewItem listItemView = (ListViewItem)lastItemSelected;
                    if (listItemView.Tag != null)
                        return listItemView.Tag;
                }
            }
            return null;
        }

        /// <summary>
        /// Returns the tree node object with the given name from the left side
        /// </summary>
        /// <param name="treeNodeName">The name of the tree node</param>
        /// <returns>TreeNode with given name</returns>
        private TreeNode GetLeftTreeViewNode(string treeNodeName)
        {
            TreeNode[] treeNodes = leftTreeView.Nodes.Find(treeNodeName, true);
            if (treeNodes.Length > 0)
                return treeNodes[0];
            else
                return null;
        }

        /// <summary>
        /// Deletes the tree node object with the given name from the left side
        /// </summary>
        /// <param name="treeNodeName">Name of the tree node</param>
        private void DeleteLeftTreeViewNode(string treeNodeName)
        {
            TreeNode treeNode = GetLeftTreeViewNode(treeNodeName);
            if (treeNode != null)
                treeNode.Remove();
        }

        /// <summary>
        /// Returns the list view item object with the given name from the right side
        /// </summary>
        /// <param name="listViewItemName">The name of the list view item</param>
        /// <returns>ListViewItem with the given name</returns>
        private ListViewItem GetRightListViewItem(string listViewItemName)
        {
            ListViewItem[] listViewItems = null;// rightListView.Items.Find(listViewItemName, true);
            if (listViewItems.Length > 0)
                return listViewItems[0];
            else
                return null;
        }

        /// <summary>
        /// Deletes the list view item object with the given name from the right side
        /// </summary>
        /// <param name="listViewItemName">Name of the list view item</param>
        private void DeleteRightListViewItem(string listViewItemName)
        {
            ListViewItem listViewItem = GetRightListViewItem(listViewItemName);
            if (listViewItem != null)
                listViewItem.Remove();
        }

        private void ResetRightListView()
        {
            //rightListView.Columns.Clear();
            //rightListView.Items.Clear();
        }

        /// <summary>
        /// Clears all of the populated nodes in the tree view
        /// </summary>
        private void ClearAllPopulatedNodes()
        {
            /*foreach (TreeNode treeNode in dynamicallyAddedToTreeNodes)
            {
                if (treeNode != null)
                    treeNode.Nodes.Clear();
            }*/
        }

        public static void ColorListViewHeader(ref ListView list, Color backColor, Color foreColor)
        {
            list.OwnerDraw = true;
            list.DrawColumnHeader +=
                new DrawListViewColumnHeaderEventHandler
                (
                    (sender, e) => HeaderDraw(sender, e, backColor, foreColor)
                );
            list.DrawItem += new DrawListViewItemEventHandler(BodyDraw);
        }
        private static void HeaderDraw(object sender, DrawListViewColumnHeaderEventArgs e, Color backColor, Color foreColor)
        {
            e.Graphics.FillRectangle(new SolidBrush(backColor), e.Bounds);
            e.Graphics.DrawString(e.Header.Text, e.Font, new SolidBrush(foreColor), e.Bounds);
        }
        private static void BodyDraw(object sender, DrawListViewItemEventArgs e)
        {
            e.DrawDefault = true;
        }

        private void FirebrandReportsToolbox_FormClosed(object sender, FormClosedEventArgs e)
        {
            //exit the application
            Environment.Exit(0);
        }


        private void FirebrandReportsToolbox_ResizeEnd(object sender, EventArgs e)
        {
            this.ResizeEventsColumnHeaders();
        }

        /// <summary>
        /// Resizes the event list view's column headers to either fit 
        /// content or to fit the column header width - if items are empty.
        /// </summary>
        private void ResizeEventsColumnHeaders()
        {
            if (eventsListView.Items.Count > 0)
            {
                for (int i = 0; i < this.eventsListView.Columns.Count - 1; i++)
                {
                    this.eventsListView.AutoResizeColumn(i, ColumnHeaderAutoResizeStyle.ColumnContent);
                }
            }
            else
            {
                for (int i = 0; i < this.eventsListView.Columns.Count - 1; i++)
                {
                    this.eventsListView.AutoResizeColumn(i, ColumnHeaderAutoResizeStyle.HeaderSize);
                }
            }

            this.eventsListView.Columns[this.eventsListView.Columns.Count - 1].Width = -2;
        }

        #endregion //Helper Functions
    }
}
