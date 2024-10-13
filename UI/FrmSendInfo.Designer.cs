namespace UI
{
    partial class FrmSendInfo
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
            this.gridSendInfo = new DevExpress.XtraGrid.GridControl();
            this.grdSendInfo = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.DeviceCol = new DevExpress.XtraGrid.Columns.GridColumn();
            this.fingerCol = new DevExpress.XtraGrid.Columns.GridColumn();
            this.PicCol = new DevExpress.XtraGrid.Columns.GridColumn();
            this.DbCol = new DevExpress.XtraGrid.Columns.GridColumn();
            this.basicInfoCol = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ProgressBarBasicInfo = new DevExpress.XtraEditors.Repository.RepositoryItemProgressBar();
            this.message = new DevExpress.XtraGrid.Columns.GridColumn();
            this.FingerCheckEdit = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.PicCheckEdit = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.DbCheckEdit = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.CardCheckEdit = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.btnSend = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.labelName = new System.Windows.Forms.Label();
            this.grpInfo = new System.Windows.Forms.GroupBox();
            this.chkBasicDb = new DevExpress.XtraEditors.CheckEdit();
            this.chkPic = new DevExpress.XtraEditors.CheckEdit();
            this.chkFinger = new DevExpress.XtraEditors.CheckEdit();
            this.chkFace = new DevExpress.XtraEditors.CheckEdit();
            this.chkPalm = new DevExpress.XtraEditors.CheckEdit();
            ((System.ComponentModel.ISupportInitialize)(this.gridSendInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdSendInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ProgressBarBasicInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FingerCheckEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PicCheckEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DbCheckEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CardCheckEdit)).BeginInit();
            this.grpInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkBasicDb.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkPic.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkFinger.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkFace.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkPalm.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // gridSendInfo
            // 
            this.gridSendInfo.Cursor = System.Windows.Forms.Cursors.Default;
            this.gridSendInfo.Location = new System.Drawing.Point(2, 75);
            this.gridSendInfo.MainView = this.grdSendInfo;
            this.gridSendInfo.Name = "gridSendInfo";
            this.gridSendInfo.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.FingerCheckEdit,
            this.PicCheckEdit,
            this.DbCheckEdit,
            this.CardCheckEdit,
            this.ProgressBarBasicInfo});
            this.gridSendInfo.Size = new System.Drawing.Size(821, 348);
            this.gridSendInfo.TabIndex = 0;
            this.gridSendInfo.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grdSendInfo});
            // 
            // grdSendInfo
            // 
            this.grdSendInfo.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.grdSendInfo.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grdSendInfo.Appearance.HeaderPanel.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grdSendInfo.Appearance.Row.Options.UseTextOptions = true;
            this.grdSendInfo.Appearance.Row.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grdSendInfo.Appearance.Row.TextOptions.Trimming = DevExpress.Utils.Trimming.None;
            this.grdSendInfo.Appearance.Row.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grdSendInfo.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.DeviceCol,
            this.fingerCol,
            this.PicCol,
            this.DbCol,
            this.basicInfoCol,
            this.message});
            this.grdSendInfo.GridControl = this.gridSendInfo;
            this.grdSendInfo.Name = "grdSendInfo";
            this.grdSendInfo.OptionsFind.AlwaysVisible = true;
            this.grdSendInfo.OptionsFind.ClearFindOnClose = false;
            this.grdSendInfo.OptionsFind.FindDelay = 100;
            this.grdSendInfo.OptionsFind.FindNullPrompt = "جست و جو ...";
            this.grdSendInfo.OptionsFind.ShowCloseButton = false;
            this.grdSendInfo.OptionsFind.ShowFindButton = false;
            this.grdSendInfo.OptionsSelection.MultiSelect = true;
            this.grdSendInfo.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect;
            // 
            // DeviceCol
            // 
            this.DeviceCol.Caption = "دستگاه موجود";
            this.DeviceCol.FieldName = "DeviceName";
            this.DeviceCol.Name = "DeviceCol";
            this.DeviceCol.OptionsColumn.AllowEdit = false;
            this.DeviceCol.OptionsColumn.AllowSize = false;
            this.DeviceCol.Visible = true;
            this.DeviceCol.VisibleIndex = 1;
            this.DeviceCol.Width = 226;
            // 
            // fingerCol
            // 
            this.fingerCol.Caption = "اثر انگشت";
            this.fingerCol.FieldName = "Finger";
            this.fingerCol.Name = "fingerCol";
            this.fingerCol.OptionsColumn.AllowEdit = false;
            this.fingerCol.OptionsColumn.AllowSize = false;
            this.fingerCol.UnboundType = DevExpress.Data.UnboundColumnType.Boolean;
            this.fingerCol.Width = 64;
            // 
            // PicCol
            // 
            this.PicCol.Caption = "عکس";
            this.PicCol.FieldName = "Picture";
            this.PicCol.Name = "PicCol";
            this.PicCol.OptionsColumn.AllowEdit = false;
            this.PicCol.OptionsColumn.AllowSize = false;
            this.PicCol.Width = 64;
            // 
            // DbCol
            // 
            this.DbCol.Caption = "اطلاعات پایه";
            this.DbCol.FieldName = "Db";
            this.DbCol.Name = "DbCol";
            this.DbCol.OptionsColumn.AllowEdit = false;
            this.DbCol.OptionsColumn.AllowSize = false;
            this.DbCol.Visible = true;
            this.DbCol.VisibleIndex = 2;
            this.DbCol.Width = 64;
            // 
            // basicInfoCol
            // 
            this.basicInfoCol.Caption = "وضعیت ارسال";
            this.basicInfoCol.ColumnEdit = this.ProgressBarBasicInfo;
            this.basicInfoCol.FieldName = "Port";
            this.basicInfoCol.Name = "basicInfoCol";
            this.basicInfoCol.Visible = true;
            this.basicInfoCol.VisibleIndex = 3;
            this.basicInfoCol.Width = 119;
            // 
            // ProgressBarBasicInfo
            // 
            this.ProgressBarBasicInfo.Name = "ProgressBarBasicInfo";
            this.ProgressBarBasicInfo.ProgressViewStyle = DevExpress.XtraEditors.Controls.ProgressViewStyle.Solid;
            this.ProgressBarBasicInfo.ShowTitle = true;
            // 
            // message
            // 
            this.message.Caption = "نتیجه ارسال";
            this.message.FieldName = "DeviceIp";
            this.message.Name = "message";
            this.message.OptionsColumn.AllowEdit = false;
            this.message.Visible = true;
            this.message.VisibleIndex = 4;
            this.message.Width = 80;
            // 
            // FingerCheckEdit
            // 
            this.FingerCheckEdit.AutoHeight = false;
            this.FingerCheckEdit.Name = "FingerCheckEdit";
            // 
            // PicCheckEdit
            // 
            this.PicCheckEdit.AutoHeight = false;
            this.PicCheckEdit.Name = "PicCheckEdit";
            // 
            // DbCheckEdit
            // 
            this.DbCheckEdit.AutoHeight = false;
            this.DbCheckEdit.Name = "DbCheckEdit";
            // 
            // CardCheckEdit
            // 
            this.CardCheckEdit.AutoHeight = false;
            this.CardCheckEdit.Name = "CardCheckEdit";
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(740, 429);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(75, 23);
            this.btnSend.TabIndex = 1;
            this.btnSend.Text = "ارسال";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(659, 429);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "لغو";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.Location = new System.Drawing.Point(59, 9);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(0, 13);
            this.labelName.TabIndex = 5;
            // 
            // grpInfo
            // 
            this.grpInfo.Controls.Add(this.chkPalm);
            this.grpInfo.Controls.Add(this.chkFace);
            this.grpInfo.Controls.Add(this.chkBasicDb);
            this.grpInfo.Controls.Add(this.chkPic);
            this.grpInfo.Controls.Add(this.chkFinger);
            this.grpInfo.Location = new System.Drawing.Point(0, 9);
            this.grpInfo.Name = "grpInfo";
            this.grpInfo.Size = new System.Drawing.Size(823, 60);
            this.grpInfo.TabIndex = 6;
            this.grpInfo.TabStop = false;
            this.grpInfo.Text = "اطلاعات";
            // 
            // chkBasicDb
            // 
            this.chkBasicDb.EditValue = true;
            this.chkBasicDb.Location = new System.Drawing.Point(736, 19);
            this.chkBasicDb.Name = "chkBasicDb";
            this.chkBasicDb.Properties.Caption = "اطلاعات پایه";
            this.chkBasicDb.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.chkBasicDb.Size = new System.Drawing.Size(75, 19);
            this.chkBasicDb.TabIndex = 5;
            // 
            // chkPic
            // 
            this.chkPic.Location = new System.Drawing.Point(617, 19);
            this.chkPic.Name = "chkPic";
            this.chkPic.Properties.Caption = "تصویر پروفایل";
            this.chkPic.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.chkPic.Size = new System.Drawing.Size(83, 19);
            this.chkPic.TabIndex = 4;
            // 
            // chkFinger
            // 
            this.chkFinger.Location = new System.Drawing.Point(495, 21);
            this.chkFinger.Name = "chkFinger";
            this.chkFinger.Properties.Caption = "اثر انگشت";
            this.chkFinger.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.chkFinger.Size = new System.Drawing.Size(75, 19);
            this.chkFinger.TabIndex = 3;
            // 
            // chkFace
            // 
            this.chkFace.Location = new System.Drawing.Point(355, 21);
            this.chkFace.Name = "chkFace";
            this.chkFace.Properties.Caption = "چهره";
            this.chkFace.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.chkFace.Size = new System.Drawing.Size(75, 19);
            this.chkFace.TabIndex = 6;
            // 
            // chkPalm
            // 
            this.chkPalm.Location = new System.Drawing.Point(237, 21);
            this.chkPalm.Name = "chkPalm";
            this.chkPalm.Properties.Caption = "دست";
            this.chkPalm.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.chkPalm.Size = new System.Drawing.Size(75, 19);
            this.chkPalm.TabIndex = 7;
            // 
            // FrmSendInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(824, 469);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.grpInfo);
            this.Controls.Add(this.labelName);
            this.Controls.Add(this.gridSendInfo);
            this.MaximizeBox = false;
            this.Name = "FrmSendInfo";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.ShowIcon = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ارسال اطلاعات فرد به دستگاه";
            this.Load += new System.EventHandler(this.FrmSendInfo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridSendInfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdSendInfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ProgressBarBasicInfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FingerCheckEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PicCheckEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DbCheckEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CardCheckEdit)).EndInit();
            this.grpInfo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chkBasicDb.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkPic.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkFinger.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkFace.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkPalm.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridSendInfo;
        private DevExpress.XtraGrid.Views.Grid.GridView grdSendInfo;
        private DevExpress.XtraGrid.Columns.GridColumn DeviceCol;
        private DevExpress.XtraGrid.Columns.GridColumn fingerCol;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit FingerCheckEdit;
        private DevExpress.XtraGrid.Columns.GridColumn PicCol;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit PicCheckEdit;
        private DevExpress.XtraGrid.Columns.GridColumn DbCol;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit DbCheckEdit;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit CardCheckEdit;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.GroupBox grpInfo;
        private DevExpress.XtraEditors.CheckEdit chkBasicDb;
        private DevExpress.XtraEditors.CheckEdit chkPic;
        private DevExpress.XtraEditors.CheckEdit chkFinger;
        private DevExpress.XtraGrid.Columns.GridColumn basicInfoCol;
        private DevExpress.XtraEditors.Repository.RepositoryItemProgressBar ProgressBarBasicInfo;
        private DevExpress.XtraGrid.Columns.GridColumn message;
        private DevExpress.XtraEditors.CheckEdit chkPalm;
        private DevExpress.XtraEditors.CheckEdit chkFace;
    }
}