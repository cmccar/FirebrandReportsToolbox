namespace FirebrandReportsToolbox
{
    partial class GetReportsByMonthForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GetReportsByMonthForm));
            this.getReportsOptionsTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.masterSpreadsheetStartRowLabel = new System.Windows.Forms.Label();
            this.getReportsButton = new System.Windows.Forms.Button();
            this.monthsComboBox = new System.Windows.Forms.ComboBox();
            this.getReportsOptionsTableLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // getReportsOptionsTableLayoutPanel
            // 
            this.getReportsOptionsTableLayoutPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.getReportsOptionsTableLayoutPanel.ColumnCount = 1;
            this.getReportsOptionsTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.getReportsOptionsTableLayoutPanel.Controls.Add(this.masterSpreadsheetStartRowLabel, 0, 0);
            this.getReportsOptionsTableLayoutPanel.Controls.Add(this.getReportsButton, 0, 2);
            this.getReportsOptionsTableLayoutPanel.Controls.Add(this.monthsComboBox, 0, 1);
            this.getReportsOptionsTableLayoutPanel.Location = new System.Drawing.Point(12, 12);
            this.getReportsOptionsTableLayoutPanel.Name = "getReportsOptionsTableLayoutPanel";
            this.getReportsOptionsTableLayoutPanel.RowCount = 3;
            this.getReportsOptionsTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.getReportsOptionsTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.getReportsOptionsTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.getReportsOptionsTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.getReportsOptionsTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.getReportsOptionsTableLayoutPanel.Size = new System.Drawing.Size(359, 140);
            this.getReportsOptionsTableLayoutPanel.TabIndex = 24;
            // 
            // masterSpreadsheetStartRowLabel
            // 
            this.masterSpreadsheetStartRowLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.masterSpreadsheetStartRowLabel.AutoSize = true;
            this.masterSpreadsheetStartRowLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.masterSpreadsheetStartRowLabel.Location = new System.Drawing.Point(3, 13);
            this.masterSpreadsheetStartRowLabel.Margin = new System.Windows.Forms.Padding(3, 13, 3, 13);
            this.masterSpreadsheetStartRowLabel.Name = "masterSpreadsheetStartRowLabel";
            this.masterSpreadsheetStartRowLabel.Size = new System.Drawing.Size(353, 20);
            this.masterSpreadsheetStartRowLabel.TabIndex = 14;
            this.masterSpreadsheetStartRowLabel.Text = "Choose the month to generate reports for";
            this.masterSpreadsheetStartRowLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // getReportsButton
            // 
            this.getReportsButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.getReportsButton.Location = new System.Drawing.Point(3, 105);
            this.getReportsButton.Margin = new System.Windows.Forms.Padding(3, 13, 3, 13);
            this.getReportsButton.Name = "getReportsButton";
            this.getReportsButton.Size = new System.Drawing.Size(353, 22);
            this.getReportsButton.TabIndex = 38;
            this.getReportsButton.Text = "Get Reports";
            this.getReportsButton.UseVisualStyleBackColor = true;
            this.getReportsButton.Click += new System.EventHandler(this.getReportsButton_Click);
            // 
            // monthsComboBox
            // 
            this.monthsComboBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.monthsComboBox.FormattingEnabled = true;
            this.monthsComboBox.Location = new System.Drawing.Point(3, 59);
            this.monthsComboBox.Margin = new System.Windows.Forms.Padding(3, 13, 3, 13);
            this.monthsComboBox.Name = "monthsComboBox";
            this.monthsComboBox.Size = new System.Drawing.Size(353, 21);
            this.monthsComboBox.TabIndex = 39;
            this.monthsComboBox.SelectedIndexChanged += new System.EventHandler(this.monthsComboBox_SelectedIndexChanged);
            // 
            // GetReportsByMonthForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(383, 164);
            this.Controls.Add(this.getReportsOptionsTableLayoutPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "GetReportsByMonthForm";
            this.Text = "Get Reports Options";
            this.getReportsOptionsTableLayoutPanel.ResumeLayout(false);
            this.getReportsOptionsTableLayoutPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel getReportsOptionsTableLayoutPanel;
        private System.Windows.Forms.Label masterSpreadsheetStartRowLabel;
        private System.Windows.Forms.Button getReportsButton;
        private System.Windows.Forms.ComboBox monthsComboBox;
    }
}