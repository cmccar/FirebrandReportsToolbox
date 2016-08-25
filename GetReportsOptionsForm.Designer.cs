namespace FirebrandReportsToolbox
{
    partial class GetReportsOptionsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GetReportsOptionsForm));
            this.getReportsOptionsTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.masterSpreadsheetStartRowLabel = new System.Windows.Forms.Label();
            this.getReportsButton = new System.Windows.Forms.Button();
            this.endDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.masterSpreadsheetEndRowLabel = new System.Windows.Forms.Label();
            this.startDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.getReportsOptionsTableLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // getReportsOptionsTableLayoutPanel
            // 
            this.getReportsOptionsTableLayoutPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.getReportsOptionsTableLayoutPanel.ColumnCount = 1;
            this.getReportsOptionsTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.getReportsOptionsTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.getReportsOptionsTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.getReportsOptionsTableLayoutPanel.Controls.Add(this.masterSpreadsheetStartRowLabel, 0, 0);
            this.getReportsOptionsTableLayoutPanel.Controls.Add(this.getReportsButton, 0, 4);
            this.getReportsOptionsTableLayoutPanel.Controls.Add(this.endDateTimePicker, 0, 3);
            this.getReportsOptionsTableLayoutPanel.Controls.Add(this.masterSpreadsheetEndRowLabel, 0, 2);
            this.getReportsOptionsTableLayoutPanel.Controls.Add(this.startDateTimePicker, 0, 1);
            this.getReportsOptionsTableLayoutPanel.Location = new System.Drawing.Point(12, 15);
            this.getReportsOptionsTableLayoutPanel.Name = "getReportsOptionsTableLayoutPanel";
            this.getReportsOptionsTableLayoutPanel.RowCount = 5;
            this.getReportsOptionsTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.getReportsOptionsTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.getReportsOptionsTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.getReportsOptionsTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.getReportsOptionsTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.getReportsOptionsTableLayoutPanel.Size = new System.Drawing.Size(360, 200);
            this.getReportsOptionsTableLayoutPanel.TabIndex = 23;
            // 
            // masterSpreadsheetStartRowLabel
            // 
            this.masterSpreadsheetStartRowLabel.AutoSize = true;
            this.masterSpreadsheetStartRowLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.masterSpreadsheetStartRowLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.masterSpreadsheetStartRowLabel.Location = new System.Drawing.Point(3, 0);
            this.masterSpreadsheetStartRowLabel.Name = "masterSpreadsheetStartRowLabel";
            this.masterSpreadsheetStartRowLabel.Size = new System.Drawing.Size(354, 40);
            this.masterSpreadsheetStartRowLabel.TabIndex = 14;
            this.masterSpreadsheetStartRowLabel.Text = "Start time (based on when report submitted)";
            this.masterSpreadsheetStartRowLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // getReportsButton
            // 
            this.getReportsButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.getReportsButton.Location = new System.Drawing.Point(3, 163);
            this.getReportsButton.Name = "getReportsButton";
            this.getReportsButton.Size = new System.Drawing.Size(354, 34);
            this.getReportsButton.TabIndex = 38;
            this.getReportsButton.Text = "Get Reports";
            this.getReportsButton.UseVisualStyleBackColor = true;
            this.getReportsButton.Click += new System.EventHandler(this.getReportsButton_Click);
            // 
            // endDateTimePicker
            // 
            this.endDateTimePicker.Dock = System.Windows.Forms.DockStyle.Fill;
            this.endDateTimePicker.Location = new System.Drawing.Point(3, 123);
            this.endDateTimePicker.MaxDate = new System.DateTime(2026, 1, 1, 0, 0, 0, 0);
            this.endDateTimePicker.MinDate = new System.DateTime(2014, 1, 1, 0, 0, 0, 0);
            this.endDateTimePicker.Name = "endDateTimePicker";
            this.endDateTimePicker.Size = new System.Drawing.Size(354, 20);
            this.endDateTimePicker.TabIndex = 42;
            this.endDateTimePicker.Value = new System.DateTime(2016, 8, 20, 13, 44, 0, 0);
            // 
            // masterSpreadsheetEndRowLabel
            // 
            this.masterSpreadsheetEndRowLabel.AutoSize = true;
            this.masterSpreadsheetEndRowLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.masterSpreadsheetEndRowLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.masterSpreadsheetEndRowLabel.Location = new System.Drawing.Point(3, 80);
            this.masterSpreadsheetEndRowLabel.Name = "masterSpreadsheetEndRowLabel";
            this.masterSpreadsheetEndRowLabel.Size = new System.Drawing.Size(354, 40);
            this.masterSpreadsheetEndRowLabel.TabIndex = 34;
            this.masterSpreadsheetEndRowLabel.Text = "End time (based on when report submitted)";
            this.masterSpreadsheetEndRowLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // startDateTimePicker
            // 
            this.startDateTimePicker.Cursor = System.Windows.Forms.Cursors.Default;
            this.startDateTimePicker.Dock = System.Windows.Forms.DockStyle.Fill;
            this.startDateTimePicker.Location = new System.Drawing.Point(3, 43);
            this.startDateTimePicker.MaxDate = new System.DateTime(2026, 1, 1, 0, 0, 0, 0);
            this.startDateTimePicker.MinDate = new System.DateTime(2014, 1, 1, 0, 0, 0, 0);
            this.startDateTimePicker.Name = "startDateTimePicker";
            this.startDateTimePicker.Size = new System.Drawing.Size(354, 20);
            this.startDateTimePicker.TabIndex = 41;
            // 
            // GetReportsOptionsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 231);
            this.Controls.Add(this.getReportsOptionsTableLayoutPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "GetReportsOptionsForm";
            this.Text = "Get Reports Options";
            this.getReportsOptionsTableLayoutPanel.ResumeLayout(false);
            this.getReportsOptionsTableLayoutPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel getReportsOptionsTableLayoutPanel;
        private System.Windows.Forms.Label masterSpreadsheetStartRowLabel;
        private System.Windows.Forms.Label masterSpreadsheetEndRowLabel;
        private System.Windows.Forms.Button getReportsButton;
        private System.Windows.Forms.DateTimePicker endDateTimePicker;
        private System.Windows.Forms.DateTimePicker startDateTimePicker;
    }
}