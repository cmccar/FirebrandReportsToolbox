namespace FirebrandReportsToolbox
{
    partial class GetAccessCodeForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GetAccessCodeForm));
            this.enterAccessCodeTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.authorizationUrlTextBox = new System.Windows.Forms.TextBox();
            this.descrptionLabel = new System.Windows.Forms.Label();
            this.enterAccessCodeTableLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // enterAccessCodeTableLayoutPanel
            // 
            this.enterAccessCodeTableLayoutPanel.ColumnCount = 1;
            this.enterAccessCodeTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.enterAccessCodeTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.enterAccessCodeTableLayoutPanel.Controls.Add(this.authorizationUrlTextBox, 0, 1);
            this.enterAccessCodeTableLayoutPanel.Controls.Add(this.descrptionLabel, 0, 0);
            this.enterAccessCodeTableLayoutPanel.Location = new System.Drawing.Point(12, 12);
            this.enterAccessCodeTableLayoutPanel.Name = "enterAccessCodeTableLayoutPanel";
            this.enterAccessCodeTableLayoutPanel.RowCount = 2;
            this.enterAccessCodeTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.enterAccessCodeTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.enterAccessCodeTableLayoutPanel.Size = new System.Drawing.Size(390, 112);
            this.enterAccessCodeTableLayoutPanel.TabIndex = 6;
            // 
            // authorizationUrlTextBox
            // 
            this.authorizationUrlTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.authorizationUrlTextBox.Location = new System.Drawing.Point(3, 74);
            this.authorizationUrlTextBox.Margin = new System.Windows.Forms.Padding(3, 18, 3, 3);
            this.authorizationUrlTextBox.Name = "authorizationUrlTextBox";
            this.authorizationUrlTextBox.Size = new System.Drawing.Size(384, 20);
            this.authorizationUrlTextBox.TabIndex = 7;
            // 
            // descrptionLabel
            // 
            this.descrptionLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.descrptionLabel.AutoSize = true;
            this.descrptionLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.descrptionLabel.Location = new System.Drawing.Point(3, 0);
            this.descrptionLabel.Name = "descrptionLabel";
            this.descrptionLabel.Size = new System.Drawing.Size(384, 56);
            this.descrptionLabel.TabIndex = 6;
            this.descrptionLabel.Text = "Enter the authorization URL below into your browser and go to it";
            this.descrptionLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // GetAccessCodeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(414, 136);
            this.Controls.Add(this.enterAccessCodeTableLayoutPanel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "GetAccessCodeForm";
            this.Text = "Get Access Code";
            this.enterAccessCodeTableLayoutPanel.ResumeLayout(false);
            this.enterAccessCodeTableLayoutPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel enterAccessCodeTableLayoutPanel;
        private System.Windows.Forms.Label descrptionLabel;
        private System.Windows.Forms.TextBox authorizationUrlTextBox;
    }
}