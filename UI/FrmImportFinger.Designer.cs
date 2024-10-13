namespace UI
{
    partial class FrmImportFinger
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmImportFinger));
            this.FingBrows = new DevExpress.XtraEditors.SimpleButton();
            this.txtFingPath = new System.Windows.Forms.TextBox();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.progressBarFings = new DevExpress.XtraEditors.ProgressBarControl();
            this.btnSendFings = new System.Windows.Forms.Button();
            this.fingsfolderBrowser = new System.Windows.Forms.FolderBrowserDialog();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.progressBarFings.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // FingBrows
            // 
            this.FingBrows.Location = new System.Drawing.Point(301, 53);
            this.FingBrows.Name = "FingBrows";
            this.FingBrows.Size = new System.Drawing.Size(75, 23);
            this.FingBrows.TabIndex = 7;
            this.FingBrows.Text = "انتخاب فایل";
            this.FingBrows.Click += new System.EventHandler(this.FingBrows_Click);
            // 
            // txtFingPath
            // 
            this.txtFingPath.Location = new System.Drawing.Point(12, 55);
            this.txtFingPath.MaxLength = 50;
            this.txtFingPath.Name = "txtFingPath";
            this.txtFingPath.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtFingPath.Size = new System.Drawing.Size(274, 21);
            this.txtFingPath.TabIndex = 9;
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.progressBarFings);
            this.groupControl1.Controls.Add(this.btnSendFings);
            this.groupControl1.Controls.Add(this.txtFingPath);
            this.groupControl1.Controls.Add(this.FingBrows);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl1.Location = new System.Drawing.Point(0, 0);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.groupControl1.Size = new System.Drawing.Size(388, 194);
            this.groupControl1.TabIndex = 10;
            this.groupControl1.Text = "انتقال اثر انگشت ها به پایگاه داده";
            // 
            // progressBarFings
            // 
            this.progressBarFings.Location = new System.Drawing.Point(12, 127);
            this.progressBarFings.Name = "progressBarFings";
            this.progressBarFings.Properties.EndColor = System.Drawing.SystemColors.HighlightText;
            this.progressBarFings.Properties.Step = 1;
            this.progressBarFings.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.progressBarFings.Size = new System.Drawing.Size(364, 18);
            this.progressBarFings.TabIndex = 11;
            // 
            // btnSendFings
            // 
            this.btnSendFings.Location = new System.Drawing.Point(12, 151);
            this.btnSendFings.Name = "btnSendFings";
            this.btnSendFings.Size = new System.Drawing.Size(75, 23);
            this.btnSendFings.TabIndex = 10;
            this.btnSendFings.Text = "شروع";
            this.btnSendFings.UseVisualStyleBackColor = true;
            this.btnSendFings.Click += new System.EventHandler(this.btnSendFings_Click);
            // 
            // FrmImportFinger
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(388, 194);
            this.Controls.Add(this.groupControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmImportFinger";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ارسال اثر انگشت ها به پایگاه داده";
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.progressBarFings.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton FingBrows;
        private System.Windows.Forms.TextBox txtFingPath;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private System.Windows.Forms.Button btnSendFings;
        private System.Windows.Forms.FolderBrowserDialog fingsfolderBrowser;
        private DevExpress.XtraEditors.ProgressBarControl progressBarFings;
    }
}