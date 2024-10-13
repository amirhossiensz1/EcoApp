namespace UI
{
    partial class FrmFingersInDevice
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
            this.grpFingers = new DevExpress.XtraEditors.GroupControl();
            this.BtnReceiveAll = new DevExpress.XtraEditors.SimpleButton();
            this.lblStatus = new System.Windows.Forms.Label();
            this.BtnDeleteAll = new DevExpress.XtraEditors.SimpleButton();
            this.BtnSendAll = new DevExpress.XtraEditors.SimpleButton();
            this.LeftHand = new System.Windows.Forms.PictureBox();
            this.RightHand = new System.Windows.Forms.PictureBox();
            this.progressPanel = new DevExpress.XtraWaitForm.ProgressPanel();
            ((System.ComponentModel.ISupportInitialize)(this.grpFingers)).BeginInit();
            this.grpFingers.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LeftHand)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RightHand)).BeginInit();
            this.SuspendLayout();
            // 
            // grpFingers
            // 
            this.grpFingers.Controls.Add(this.progressPanel);
            this.grpFingers.Controls.Add(this.BtnReceiveAll);
            this.grpFingers.Controls.Add(this.lblStatus);
            this.grpFingers.Controls.Add(this.BtnDeleteAll);
            this.grpFingers.Controls.Add(this.BtnSendAll);
            this.grpFingers.Controls.Add(this.LeftHand);
            this.grpFingers.Controls.Add(this.RightHand);
            this.grpFingers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpFingers.Location = new System.Drawing.Point(0, 0);
            this.grpFingers.Name = "grpFingers";
            this.grpFingers.Size = new System.Drawing.Size(499, 424);
            this.grpFingers.TabIndex = 0;
            this.grpFingers.Text = "اثر انگشتهای موجود در دستگاه";
            // 
            // BtnReceiveAll
            // 
            this.BtnReceiveAll.Location = new System.Drawing.Point(244, 372);
            this.BtnReceiveAll.Name = "BtnReceiveAll";
            this.BtnReceiveAll.Size = new System.Drawing.Size(111, 31);
            this.BtnReceiveAll.TabIndex = 8;
            this.BtnReceiveAll.Text = "دریافت از دستگاه ";
            this.BtnReceiveAll.Click += new System.EventHandler(this.BtnReceiveAll_Click);
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(219, 409);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(0, 13);
            this.lblStatus.TabIndex = 7;
            // 
            // BtnDeleteAll
            // 
            this.BtnDeleteAll.Location = new System.Drawing.Point(129, 372);
            this.BtnDeleteAll.Name = "BtnDeleteAll";
            this.BtnDeleteAll.Size = new System.Drawing.Size(109, 31);
            this.BtnDeleteAll.TabIndex = 6;
            this.BtnDeleteAll.Text = "حذف همه از دستگاه";
            this.BtnDeleteAll.Click += new System.EventHandler(this.BtnDeleteAll_Click);
            // 
            // BtnSendAll
            // 
            this.BtnSendAll.Location = new System.Drawing.Point(12, 372);
            this.BtnSendAll.Name = "BtnSendAll";
            this.BtnSendAll.Size = new System.Drawing.Size(111, 31);
            this.BtnSendAll.TabIndex = 4;
            this.BtnSendAll.Text = "ارسال همه به دستگاه ";
            this.BtnSendAll.Click += new System.EventHandler(this.BtnSendAll_Click);
            // 
            // LeftHand
            // 
            this.LeftHand.Image = global::Eco.Properties.Resources.hand3;
            this.LeftHand.Location = new System.Drawing.Point(12, 23);
            this.LeftHand.Name = "LeftHand";
            this.LeftHand.Size = new System.Drawing.Size(226, 343);
            this.LeftHand.TabIndex = 3;
            this.LeftHand.TabStop = false;
            // 
            // RightHand
            // 
            this.RightHand.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.RightHand.ErrorImage = null;
            this.RightHand.Image = global::Eco.Properties.Resources.hand2;
            this.RightHand.InitialImage = null;
            this.RightHand.Location = new System.Drawing.Point(244, 21);
            this.RightHand.Name = "RightHand";
            this.RightHand.Size = new System.Drawing.Size(232, 345);
            this.RightHand.TabIndex = 2;
            this.RightHand.TabStop = false;
            // 
            // progressPanel
            // 
            this.progressPanel.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.progressPanel.Appearance.Options.UseBackColor = true;
            this.progressPanel.AppearanceCaption.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.progressPanel.AppearanceCaption.Options.UseFont = true;
            this.progressPanel.AppearanceDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.progressPanel.AppearanceDescription.Options.UseFont = true;
            this.progressPanel.Caption = "لطفا صبر کنید .....";
            this.progressPanel.Description = "در حال دریافت ....";
            this.progressPanel.Location = new System.Drawing.Point(167, 160);
            this.progressPanel.Name = "progressPanel";
            this.progressPanel.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.progressPanel.Size = new System.Drawing.Size(142, 66);
            this.progressPanel.TabIndex = 9;
            this.progressPanel.Text = "لطفا صبر کنید ....";
            this.progressPanel.Visible = false;
            // 
            // FrmFingersInDevice
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(499, 424);
            this.Controls.Add(this.grpFingers);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmFingersInDevice";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "نمایش اثر انگشتهای موجود در دستگاه";
            this.Load += new System.EventHandler(this.FrmFingersInDevice_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grpFingers)).EndInit();
            this.grpFingers.ResumeLayout(false);
            this.grpFingers.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LeftHand)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RightHand)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl grpFingers;
        private System.Windows.Forms.PictureBox RightHand;
        private System.Windows.Forms.PictureBox LeftHand;
        private DevExpress.XtraEditors.SimpleButton BtnSendAll;
        private DevExpress.XtraEditors.SimpleButton BtnDeleteAll;
        private System.Windows.Forms.Label lblStatus;
        private DevExpress.XtraEditors.SimpleButton BtnReceiveAll;
        private DevExpress.XtraWaitForm.ProgressPanel progressPanel;

    }
}