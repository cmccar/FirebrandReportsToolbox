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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.eventsListView = new System.Windows.Forms.ListView();
            this.brandsComboBox = new System.Windows.Forms.ComboBox();
            this.brandsLabel = new System.Windows.Forms.Label();
            this.getReportsButton = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 67F));
            this.tableLayoutPanel1.Controls.Add(this.eventsListView, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.brandsComboBox, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.brandsLabel, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.getReportsButton, 1, 2);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 12);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(347, 438);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // eventsListView
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.eventsListView, 2);
            this.eventsListView.Location = new System.Drawing.Point(3, 3);
            this.eventsListView.Name = "eventsListView";
            this.eventsListView.Size = new System.Drawing.Size(341, 213);
            this.eventsListView.TabIndex = 0;
            this.eventsListView.UseCompatibleStateImageBehavior = false;
            // 
            // brandsComboBox
            // 
            this.brandsComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.brandsComboBox.FormattingEnabled = true;
            this.brandsComboBox.Location = new System.Drawing.Point(117, 237);
            this.brandsComboBox.Margin = new System.Windows.Forms.Padding(3, 18, 3, 3);
            this.brandsComboBox.Name = "brandsComboBox";
            this.brandsComboBox.Size = new System.Drawing.Size(227, 21);
            this.brandsComboBox.TabIndex = 1;
            // 
            // brandsLabel
            // 
            this.brandsLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.brandsLabel.AutoSize = true;
            this.brandsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.brandsLabel.Location = new System.Drawing.Point(3, 222);
            this.brandsLabel.Margin = new System.Windows.Forms.Padding(3);
            this.brandsLabel.Name = "brandsLabel";
            this.brandsLabel.Size = new System.Drawing.Size(76, 48);
            this.brandsLabel.TabIndex = 2;
            this.brandsLabel.Text = "Brand Name";
            this.brandsLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // getReportsButton
            // 
            this.getReportsButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.getReportsButton.Location = new System.Drawing.Point(117, 276);
            this.getReportsButton.Name = "getReportsButton";
            this.getReportsButton.Size = new System.Drawing.Size(227, 23);
            this.getReportsButton.TabIndex = 3;
            this.getReportsButton.Text = "Get Reports";
            this.getReportsButton.UseVisualStyleBackColor = true;
            this.getReportsButton.Click += new System.EventHandler(this.getReportsButton_Click);
            // 
            // FirebrandReportsToolboxForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(371, 462);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "FirebrandReportsToolboxForm";
            this.Text = "Firebrand Reports Toolbox";
            this.Load += new System.EventHandler(this.FirebrandReportsToolboxForm_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.ListView eventsListView;
        private System.Windows.Forms.ComboBox brandsComboBox;
        private System.Windows.Forms.Label brandsLabel;
        private System.Windows.Forms.Button getReportsButton;
    }
}

