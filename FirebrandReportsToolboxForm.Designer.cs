namespace FirebrandReportsToolbox
{
    partial class FirebrandReportsToolboxForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Brands");
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FirebrandReportsToolboxForm));
            this.eventsListView = new System.Windows.Forms.ListView();
            this.timeColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.localTimecolumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.eventMessageColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.leftTreeViewContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.getReportsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rightSideDataGridView = new System.Windows.Forms.DataGridView();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportTableToExcelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.changeGoogleAccountToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.leftTreeView = new System.Windows.Forms.TreeView();
            this.mainTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.leftTreeViewContextMenuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rightSideDataGridView)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.mainTableLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // eventsListView
            // 
            this.eventsListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.timeColumnHeader,
            this.localTimecolumnHeader,
            this.eventMessageColumnHeader});
            this.mainTableLayoutPanel.SetColumnSpan(this.eventsListView, 2);
            this.eventsListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.eventsListView.FullRowSelect = true;
            this.eventsListView.Location = new System.Drawing.Point(3, 404);
            this.eventsListView.Name = "eventsListView";
            this.eventsListView.Size = new System.Drawing.Size(1201, 210);
            this.eventsListView.TabIndex = 3;
            this.eventsListView.UseCompatibleStateImageBehavior = false;
            this.eventsListView.View = System.Windows.Forms.View.Details;
            // 
            // timeColumnHeader
            // 
            this.timeColumnHeader.Text = "Event Time";
            this.timeColumnHeader.Width = 134;
            // 
            // localTimecolumnHeader
            // 
            this.localTimecolumnHeader.Text = "Event Local Time";
            this.localTimecolumnHeader.Width = 123;
            // 
            // eventMessageColumnHeader
            // 
            this.eventMessageColumnHeader.Text = "Event Message";
            this.eventMessageColumnHeader.Width = 625;
            // 
            // leftTreeViewContextMenuStrip
            // 
            this.leftTreeViewContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.getReportsToolStripMenuItem});
            this.leftTreeViewContextMenuStrip.Name = "leftTreeViewContextMenuStrip";
            this.leftTreeViewContextMenuStrip.Size = new System.Drawing.Size(133, 26);
            // 
            // getReportsToolStripMenuItem
            // 
            this.getReportsToolStripMenuItem.Name = "getReportsToolStripMenuItem";
            this.getReportsToolStripMenuItem.Size = new System.Drawing.Size(132, 22);
            this.getReportsToolStripMenuItem.Text = "Get reports";
            this.getReportsToolStripMenuItem.Click += new System.EventHandler(this.getReportsToolStripMenuItem_Click);
            // 
            // rightSideDataGridView
            // 
            this.rightSideDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.rightSideDataGridView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.rightSideDataGridView.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.rightSideDataGridView.DefaultCellStyle = dataGridViewCellStyle1;
            this.rightSideDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rightSideDataGridView.Location = new System.Drawing.Point(304, 3);
            this.rightSideDataGridView.Name = "rightSideDataGridView";
            this.rightSideDataGridView.Size = new System.Drawing.Size(900, 395);
            this.rightSideDataGridView.TabIndex = 5;
            this.rightSideDataGridView.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.rightSideDataGridView_CellPainting);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.optionsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1207, 24);
            this.menuStrip1.TabIndex = 6;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exportTableToExcelToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // exportTableToExcelToolStripMenuItem
            // 
            this.exportTableToExcelToolStripMenuItem.Name = "exportTableToExcelToolStripMenuItem";
            this.exportTableToExcelToolStripMenuItem.Size = new System.Drawing.Size(179, 22);
            this.exportTableToExcelToolStripMenuItem.Text = "Export table to Excel";
            this.exportTableToExcelToolStripMenuItem.Click += new System.EventHandler(this.exportTableToExcelToolStripMenuItem_Click);
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.changeGoogleAccountToolStripMenuItem});
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.optionsToolStripMenuItem.Text = "Options";
            // 
            // changeGoogleAccountToolStripMenuItem
            // 
            this.changeGoogleAccountToolStripMenuItem.Name = "changeGoogleAccountToolStripMenuItem";
            this.changeGoogleAccountToolStripMenuItem.Size = new System.Drawing.Size(202, 22);
            this.changeGoogleAccountToolStripMenuItem.Text = "Change Google account";
            this.changeGoogleAccountToolStripMenuItem.Click += new System.EventHandler(this.changeGoogleAccountToolStripMenuItem_Click);
            // 
            // leftTreeView
            // 
            this.leftTreeView.BackColor = System.Drawing.Color.Black;
            this.leftTreeView.ContextMenuStrip = this.leftTreeViewContextMenuStrip;
            this.leftTreeView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.leftTreeView.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.leftTreeView.ForeColor = System.Drawing.Color.White;
            this.leftTreeView.Location = new System.Drawing.Point(3, 3);
            this.leftTreeView.Name = "leftTreeView";
            treeNode1.Name = "rootNode";
            treeNode1.Tag = "root";
            treeNode1.Text = "Brands";
            this.leftTreeView.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode1});
            this.leftTreeView.Size = new System.Drawing.Size(295, 395);
            this.leftTreeView.TabIndex = 4;
            this.leftTreeView.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.leftTreeView_NodeMouseClick);
            this.leftTreeView.MouseDown += new System.Windows.Forms.MouseEventHandler(this.leftTreeView_MouseDown);
            // 
            // mainTableLayoutPanel
            // 
            this.mainTableLayoutPanel.ColumnCount = 2;
            this.mainTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.mainTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 75F));
            this.mainTableLayoutPanel.Controls.Add(this.rightSideDataGridView, 1, 0);
            this.mainTableLayoutPanel.Controls.Add(this.leftTreeView, 0, 0);
            this.mainTableLayoutPanel.Controls.Add(this.eventsListView, 0, 1);
            this.mainTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainTableLayoutPanel.Location = new System.Drawing.Point(0, 24);
            this.mainTableLayoutPanel.Name = "mainTableLayoutPanel";
            this.mainTableLayoutPanel.RowCount = 2;
            this.mainTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 65F));
            this.mainTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 35F));
            this.mainTableLayoutPanel.Size = new System.Drawing.Size(1207, 617);
            this.mainTableLayoutPanel.TabIndex = 7;
            // 
            // FirebrandReportsToolboxForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1207, 641);
            this.Controls.Add(this.mainTableLayoutPanel);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FirebrandReportsToolboxForm";
            this.Text = "Firebrand Reports Toolbox";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FirebrandReportsToolbox_FormClosed);
            this.Load += new System.EventHandler(this.FirebrandReportsToolboxForm_Load);
            this.ResizeEnd += new System.EventHandler(this.FirebrandReportsToolbox_ResizeEnd);
            this.leftTreeViewContextMenuStrip.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.rightSideDataGridView)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.mainTableLayoutPanel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ListView eventsListView;
        private System.Windows.Forms.ColumnHeader timeColumnHeader;
        private System.Windows.Forms.ColumnHeader localTimecolumnHeader;
        private System.Windows.Forms.ColumnHeader eventMessageColumnHeader;
        private System.Windows.Forms.ContextMenuStrip leftTreeViewContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem getReportsToolStripMenuItem;
        private System.Windows.Forms.DataGridView rightSideDataGridView;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem changeGoogleAccountToolStripMenuItem;
        private System.Windows.Forms.TableLayoutPanel mainTableLayoutPanel;
        private System.Windows.Forms.TreeView leftTreeView;
        private System.Windows.Forms.ToolStripMenuItem exportTableToExcelToolStripMenuItem;
    }
}

