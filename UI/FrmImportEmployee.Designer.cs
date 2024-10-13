namespace UI
{
    partial class FrmImportEmployee
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmImportEmployee));
            this.txtPath = new System.Windows.Forms.TextBox();
            this.grpImportBasicData = new DevExpress.XtraEditors.GroupControl();
            this.progressBarImportInfo = new DevExpress.XtraEditors.ProgressBarControl();
            this.btnBrows = new DevExpress.XtraEditors.SimpleButton();
            this.DbPicture = new System.Windows.Forms.PictureBox();
            this.btnSend = new System.Windows.Forms.Button();
            this.ExcelPicture = new System.Windows.Forms.PictureBox();
            this.ExcelFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.ImportDataTab = new DevExpress.XtraTab.XtraTabControl();
            this.PictureTab = new DevExpress.XtraTab.XtraTabPage();
            this.grpImportPicture = new DevExpress.XtraEditors.GroupControl();
            this.BtnSendPic = new DevExpress.XtraEditors.SimpleButton();
            this.progressBarPic = new DevExpress.XtraEditors.ProgressBarControl();
            this.grpNameType = new System.Windows.Forms.GroupBox();
            this.radioPersonalNum = new System.Windows.Forms.RadioButton();
            this.radioNationalCode = new System.Windows.Forms.RadioButton();
            this.grpImportPic = new System.Windows.Forms.GroupBox();
            this.radioJpeg = new System.Windows.Forms.RadioButton();
            this.radioGif = new System.Windows.Forms.RadioButton();
            this.txtPicPath = new System.Windows.Forms.TextBox();
            this.PicBrows = new DevExpress.XtraEditors.SimpleButton();
            this.BasicTab = new DevExpress.XtraTab.XtraTabPage();
            this.PicfolderBrowser = new System.Windows.Forms.FolderBrowserDialog();
            ((System.ComponentModel.ISupportInitialize)(this.grpImportBasicData)).BeginInit();
            this.grpImportBasicData.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.progressBarImportInfo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DbPicture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ExcelPicture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ImportDataTab)).BeginInit();
            this.ImportDataTab.SuspendLayout();
            this.PictureTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grpImportPicture)).BeginInit();
            this.grpImportPicture.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.progressBarPic.Properties)).BeginInit();
            this.grpNameType.SuspendLayout();
            this.grpImportPic.SuspendLayout();
            this.BasicTab.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtPath
            // 
            this.txtPath.Location = new System.Drawing.Point(12, 41);
            this.txtPath.Name = "txtPath";
            this.txtPath.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtPath.Size = new System.Drawing.Size(278, 21);
            this.txtPath.TabIndex = 3;
            // 
            // grpImportBasicData
            // 
            this.grpImportBasicData.Controls.Add(this.progressBarImportInfo);
            this.grpImportBasicData.Controls.Add(this.btnBrows);
            this.grpImportBasicData.Controls.Add(this.DbPicture);
            this.grpImportBasicData.Controls.Add(this.txtPath);
            this.grpImportBasicData.Controls.Add(this.btnSend);
            this.grpImportBasicData.Controls.Add(this.ExcelPicture);
            this.grpImportBasicData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpImportBasicData.Location = new System.Drawing.Point(0, 0);
            this.grpImportBasicData.Name = "grpImportBasicData";
            this.grpImportBasicData.Size = new System.Drawing.Size(382, 260);
            this.grpImportBasicData.TabIndex = 4;
            this.grpImportBasicData.Text = "ارسال اطلاعات پایه";
            // 
            // progressBarImportInfo
            // 
            this.progressBarImportInfo.Location = new System.Drawing.Point(12, 215);
            this.progressBarImportInfo.Name = "progressBarImportInfo";
            this.progressBarImportInfo.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.progressBarImportInfo.Size = new System.Drawing.Size(359, 18);
            this.progressBarImportInfo.TabIndex = 6;
            // 
            // btnBrows
            // 
            this.btnBrows.Location = new System.Drawing.Point(296, 39);
            this.btnBrows.Name = "btnBrows";
            this.btnBrows.Size = new System.Drawing.Size(75, 23);
            this.btnBrows.TabIndex = 5;
            this.btnBrows.Text = "انتخاب فایل";
            this.btnBrows.Click += new System.EventHandler(this.btnBrows_Click_1);
            // 
            // DbPicture
            // 
            this.DbPicture.Image = ((System.Drawing.Image)(resources.GetObject("DbPicture.Image")));
            this.DbPicture.Location = new System.Drawing.Point(243, 110);
            this.DbPicture.Name = "DbPicture";
            this.DbPicture.Size = new System.Drawing.Size(47, 50);
            this.DbPicture.TabIndex = 4;
            this.DbPicture.TabStop = false;
            // 
            // btnSend
            // 
            this.btnSend.Image = ((System.Drawing.Image)(resources.GetObject("btnSend.Image")));
            this.btnSend.Location = new System.Drawing.Point(155, 122);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(58, 29);
            this.btnSend.TabIndex = 1;
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // ExcelPicture
            // 
            this.ExcelPicture.Image = ((System.Drawing.Image)(resources.GetObject("ExcelPicture.Image")));
            this.ExcelPicture.Location = new System.Drawing.Point(72, 110);
            this.ExcelPicture.Name = "ExcelPicture";
            this.ExcelPicture.Size = new System.Drawing.Size(55, 50);
            this.ExcelPicture.TabIndex = 0;
            this.ExcelPicture.TabStop = false;
            // 
            // ExcelFileDialog
            // 
            this.ExcelFileDialog.ShowHelp = true;
            // 
            // ImportDataTab
            // 
            this.ImportDataTab.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ImportDataTab.Location = new System.Drawing.Point(0, 0);
            this.ImportDataTab.MultiLine = DevExpress.Utils.DefaultBoolean.False;
            this.ImportDataTab.Name = "ImportDataTab";
            this.ImportDataTab.PageImagePosition = DevExpress.XtraTab.TabPageImagePosition.Center;
            this.ImportDataTab.RightToLeftLayout = DevExpress.Utils.DefaultBoolean.True;
            this.ImportDataTab.SelectedTabPage = this.PictureTab;
            this.ImportDataTab.ShowTabHeader = DevExpress.Utils.DefaultBoolean.True;
            this.ImportDataTab.Size = new System.Drawing.Size(388, 288);
            this.ImportDataTab.TabIndex = 5;
            this.ImportDataTab.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.BasicTab,
            this.PictureTab});
            // 
            // PictureTab
            // 
            this.PictureTab.Controls.Add(this.grpImportPicture);
            this.PictureTab.Name = "PictureTab";
            this.PictureTab.Size = new System.Drawing.Size(382, 260);
            this.PictureTab.Text = "تصویر";
            // 
            // grpImportPicture
            // 
            this.grpImportPicture.Controls.Add(this.BtnSendPic);
            this.grpImportPicture.Controls.Add(this.progressBarPic);
            this.grpImportPicture.Controls.Add(this.grpNameType);
            this.grpImportPicture.Controls.Add(this.grpImportPic);
            this.grpImportPicture.Controls.Add(this.txtPicPath);
            this.grpImportPicture.Controls.Add(this.PicBrows);
            this.grpImportPicture.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpImportPicture.Location = new System.Drawing.Point(0, 0);
            this.grpImportPicture.Name = "grpImportPicture";
            this.grpImportPicture.Size = new System.Drawing.Size(382, 260);
            this.grpImportPicture.TabIndex = 0;
            this.grpImportPicture.Text = "ارسال تصاویر ";
            // 
            // BtnSendPic
            // 
            this.BtnSendPic.Location = new System.Drawing.Point(13, 225);
            this.BtnSendPic.Name = "BtnSendPic";
            this.BtnSendPic.Size = new System.Drawing.Size(75, 23);
            this.BtnSendPic.TabIndex = 11;
            this.BtnSendPic.Text = "ارسال عکس ";
            this.BtnSendPic.Click += new System.EventHandler(this.BtnSendPic_Click);
            // 
            // progressBarPic
            // 
            this.progressBarPic.Location = new System.Drawing.Point(9, 192);
            this.progressBarPic.Name = "progressBarPic";
            this.progressBarPic.Properties.EndColor = System.Drawing.SystemColors.HighlightText;
            this.progressBarPic.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.progressBarPic.Size = new System.Drawing.Size(355, 18);
            this.progressBarPic.TabIndex = 10;
            // 
            // grpNameType
            // 
            this.grpNameType.Controls.Add(this.radioPersonalNum);
            this.grpNameType.Controls.Add(this.radioNationalCode);
            this.grpNameType.Location = new System.Drawing.Point(189, 68);
            this.grpNameType.Name = "grpNameType";
            this.grpNameType.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.grpNameType.Size = new System.Drawing.Size(141, 106);
            this.grpNameType.TabIndex = 9;
            this.grpNameType.TabStop = false;
            this.grpNameType.Text = "انتخاب نوع نام فایل";
            // 
            // radioPersonalNum
            // 
            this.radioPersonalNum.AutoSize = true;
            this.radioPersonalNum.Location = new System.Drawing.Point(35, 63);
            this.radioPersonalNum.Name = "radioPersonalNum";
            this.radioPersonalNum.Size = new System.Drawing.Size(96, 17);
            this.radioPersonalNum.TabIndex = 2;
            this.radioPersonalNum.TabStop = true;
            this.radioPersonalNum.Text = "شماره پرسنلی";
            this.radioPersonalNum.UseVisualStyleBackColor = true;
            // 
            // radioNationalCode
            // 
            this.radioNationalCode.AutoSize = true;
            this.radioNationalCode.Location = new System.Drawing.Point(69, 28);
            this.radioNationalCode.Name = "radioNationalCode";
            this.radioNationalCode.Size = new System.Drawing.Size(60, 17);
            this.radioNationalCode.TabIndex = 1;
            this.radioNationalCode.TabStop = true;
            this.radioNationalCode.Text = "کد ملی";
            this.radioNationalCode.UseVisualStyleBackColor = true;
            // 
            // grpImportPic
            // 
            this.grpImportPic.Controls.Add(this.radioJpeg);
            this.grpImportPic.Controls.Add(this.radioGif);
            this.grpImportPic.Location = new System.Drawing.Point(45, 68);
            this.grpImportPic.Name = "grpImportPic";
            this.grpImportPic.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.grpImportPic.Size = new System.Drawing.Size(138, 106);
            this.grpImportPic.TabIndex = 8;
            this.grpImportPic.TabStop = false;
            this.grpImportPic.Text = "انتخاب نوع تصاویر";
            // 
            // radioJpeg
            // 
            this.radioJpeg.AutoSize = true;
            this.radioJpeg.Location = new System.Drawing.Point(16, 63);
            this.radioJpeg.Name = "radioJpeg";
            this.radioJpeg.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.radioJpeg.Size = new System.Drawing.Size(48, 17);
            this.radioJpeg.TabIndex = 1;
            this.radioJpeg.TabStop = true;
            this.radioJpeg.Text = "Jpeg";
            this.radioJpeg.UseVisualStyleBackColor = true;
            // 
            // radioGif
            // 
            this.radioGif.AutoSize = true;
            this.radioGif.Location = new System.Drawing.Point(16, 28);
            this.radioGif.Name = "radioGif";
            this.radioGif.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.radioGif.Size = new System.Drawing.Size(38, 17);
            this.radioGif.TabIndex = 0;
            this.radioGif.TabStop = true;
            this.radioGif.Text = "Gif";
            this.radioGif.UseVisualStyleBackColor = true;
            // 
            // txtPicPath
            // 
            this.txtPicPath.Location = new System.Drawing.Point(9, 41);
            this.txtPicPath.MaxLength = 50;
            this.txtPicPath.Name = "txtPicPath";
            this.txtPicPath.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtPicPath.Size = new System.Drawing.Size(274, 21);
            this.txtPicPath.TabIndex = 7;
            // 
            // PicBrows
            // 
            this.PicBrows.Location = new System.Drawing.Point(289, 39);
            this.PicBrows.Name = "PicBrows";
            this.PicBrows.Size = new System.Drawing.Size(75, 23);
            this.PicBrows.TabIndex = 6;
            this.PicBrows.Text = "انتخاب فایل";
            this.PicBrows.Click += new System.EventHandler(this.PicBrows_Click);
            // 
            // BasicTab
            // 
            this.BasicTab.Controls.Add(this.grpImportBasicData);
            this.BasicTab.Name = "BasicTab";
            this.BasicTab.PageVisible = false;
            this.BasicTab.Size = new System.Drawing.Size(382, 260);
            this.BasicTab.Text = "اطلاعات پایه";
            // 
            // FrmImportEmployee
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(388, 288);
            this.Controls.Add(this.ImportDataTab);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmImportEmployee";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ارسال اطلاعات کارمندان";
            this.Load += new System.EventHandler(this.FrmImportEmployee_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grpImportBasicData)).EndInit();
            this.grpImportBasicData.ResumeLayout(false);
            this.grpImportBasicData.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.progressBarImportInfo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DbPicture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ExcelPicture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ImportDataTab)).EndInit();
            this.ImportDataTab.ResumeLayout(false);
            this.PictureTab.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grpImportPicture)).EndInit();
            this.grpImportPicture.ResumeLayout(false);
            this.grpImportPicture.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.progressBarPic.Properties)).EndInit();
            this.grpNameType.ResumeLayout(false);
            this.grpNameType.PerformLayout();
            this.grpImportPic.ResumeLayout(false);
            this.grpImportPic.PerformLayout();
            this.BasicTab.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox ExcelPicture;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.TextBox txtPath;
        private DevExpress.XtraEditors.GroupControl grpImportBasicData;
        private System.Windows.Forms.OpenFileDialog ExcelFileDialog;
        private System.Windows.Forms.PictureBox DbPicture;
        private DevExpress.XtraTab.XtraTabControl ImportDataTab;
        private DevExpress.XtraTab.XtraTabPage PictureTab;
        private DevExpress.XtraTab.XtraTabPage BasicTab;
        private DevExpress.XtraEditors.GroupControl grpImportPicture;
        private DevExpress.XtraEditors.SimpleButton btnBrows;
        private DevExpress.XtraEditors.SimpleButton BtnSendPic;
        private DevExpress.XtraEditors.ProgressBarControl progressBarPic;
        private System.Windows.Forms.GroupBox grpNameType;
        private System.Windows.Forms.RadioButton radioPersonalNum;
        private System.Windows.Forms.RadioButton radioNationalCode;
        private System.Windows.Forms.GroupBox grpImportPic;
        private System.Windows.Forms.RadioButton radioJpeg;
        private System.Windows.Forms.RadioButton radioGif;
        private System.Windows.Forms.TextBox txtPicPath;
        private DevExpress.XtraEditors.SimpleButton PicBrows;
        private System.Windows.Forms.FolderBrowserDialog PicfolderBrowser;
        private DevExpress.XtraEditors.ProgressBarControl progressBarImportInfo;
    }
}