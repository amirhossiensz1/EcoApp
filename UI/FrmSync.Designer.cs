namespace UI
{
    partial class FrmSync
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmSync));
            this.repositoryItemCheckEdit4 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.repositoryItemCheckEdit5 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.repositoryItemCheckEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.repositoryItemCheckEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.repositoryItemProgressBar1 = new DevExpress.XtraEditors.Repository.RepositoryItemProgressBar();
            this.gridSendInfo = new DevExpress.XtraGrid.GridControl();
            this.grdSendInfo = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.DeviceCol = new DevExpress.XtraGrid.Columns.GridColumn();
            this.basicInfoCol = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ProgressBarBasicInfo = new DevExpress.XtraEditors.Repository.RepositoryItemProgressBar();
            this.message = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ProgressBarPic = new DevExpress.XtraEditors.Repository.RepositoryItemProgressBar();
            this.ProgressBarFinger = new DevExpress.XtraEditors.Repository.RepositoryItemProgressBar();
            this.PictureEditSending = new DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit();
            this.TestProgressBar = new DevExpress.XtraEditors.Repository.RepositoryItemProgressBar();
            this.repositoryItemRichTextEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemRichTextEdit();
            this.btnSend = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.GrpInfo = new System.Windows.Forms.GroupBox();
            this.chkPalm = new DevExpress.XtraEditors.CheckEdit();
            this.chkFace = new DevExpress.XtraEditors.CheckEdit();
            this.chkBasicInfo = new DevExpress.XtraEditors.CheckEdit();
            this.chkPicture = new DevExpress.XtraEditors.CheckEdit();
            this.chkFinger = new DevExpress.XtraEditors.CheckEdit();
            this.GrpBtns = new System.Windows.Forms.GroupBox();
            this.btnNahad = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemProgressBar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridSendInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdSendInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ProgressBarBasicInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ProgressBarPic)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ProgressBarFinger)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureEditSending)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TestProgressBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemRichTextEdit1)).BeginInit();
            this.GrpInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkPalm.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkFace.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkBasicInfo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkPicture.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkFinger.Properties)).BeginInit();
            this.GrpBtns.SuspendLayout();
            this.SuspendLayout();
            // 
            // repositoryItemCheckEdit4
            // 
            this.repositoryItemCheckEdit4.AutoHeight = false;
            this.repositoryItemCheckEdit4.Name = "repositoryItemCheckEdit4";
            this.repositoryItemCheckEdit4.NullStyle = DevExpress.XtraEditors.Controls.StyleIndeterminate.Inactive;
            // 
            // repositoryItemCheckEdit5
            // 
            this.repositoryItemCheckEdit5.AutoHeight = false;
            this.repositoryItemCheckEdit5.Name = "repositoryItemCheckEdit5";
            // 
            // repositoryItemCheckEdit1
            // 
            this.repositoryItemCheckEdit1.AutoHeight = false;
            this.repositoryItemCheckEdit1.Name = "repositoryItemCheckEdit1";
            // 
            // repositoryItemCheckEdit2
            // 
            this.repositoryItemCheckEdit2.AutoHeight = false;
            this.repositoryItemCheckEdit2.Name = "repositoryItemCheckEdit2";
            // 
            // repositoryItemProgressBar1
            // 
            this.repositoryItemProgressBar1.Name = "repositoryItemProgressBar1";
            // 
            // gridSendInfo
            // 
            this.gridSendInfo.Cursor = System.Windows.Forms.Cursors.Default;
            this.gridSendInfo.Location = new System.Drawing.Point(1, 88);
            this.gridSendInfo.MainView = this.grdSendInfo;
            this.gridSendInfo.Name = "gridSendInfo";
            this.gridSendInfo.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.ProgressBarPic,
            this.ProgressBarFinger,
            this.ProgressBarBasicInfo,
            this.PictureEditSending,
            this.TestProgressBar,
            this.repositoryItemRichTextEdit1});
            this.gridSendInfo.Size = new System.Drawing.Size(697, 348);
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
            this.grdSendInfo.Appearance.Row.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grdSendInfo.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.DeviceCol,
            this.basicInfoCol,
            this.message});
            this.grdSendInfo.GridControl = this.gridSendInfo;
            this.grdSendInfo.Name = "grdSendInfo";
            this.grdSendInfo.OptionsBehavior.AutoSelectAllInEditor = false;
            this.grdSendInfo.OptionsBehavior.Editable = false;
            this.grdSendInfo.OptionsFind.AlwaysVisible = true;
            this.grdSendInfo.OptionsFind.FindDelay = 100;
            this.grdSendInfo.OptionsFind.FindNullPrompt = "جستو جو";
            this.grdSendInfo.OptionsFind.ShowClearButton = false;
            this.grdSendInfo.OptionsFind.ShowCloseButton = false;
            this.grdSendInfo.OptionsImageLoad.AnimationType = DevExpress.Utils.ImageContentAnimationType.Expand;
            this.grdSendInfo.OptionsSelection.MultiSelect = true;
            this.grdSendInfo.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect;
            // 
            // DeviceCol
            // 
            this.DeviceCol.Caption = "دستگاه های موجود";
            this.DeviceCol.FieldName = "DeviceName";
            this.DeviceCol.Name = "DeviceCol";
            this.DeviceCol.OptionsColumn.AllowEdit = false;
            this.DeviceCol.Visible = true;
            this.DeviceCol.VisibleIndex = 1;
            this.DeviceCol.Width = 358;
            // 
            // basicInfoCol
            // 
            this.basicInfoCol.Caption = "وضعیت ارسال";
            this.basicInfoCol.ColumnEdit = this.ProgressBarBasicInfo;
            this.basicInfoCol.FieldName = "Port";
            this.basicInfoCol.Name = "basicInfoCol";
            this.basicInfoCol.Visible = true;
            this.basicInfoCol.VisibleIndex = 2;
            this.basicInfoCol.Width = 141;
            // 
            // ProgressBarBasicInfo
            // 
            this.ProgressBarBasicInfo.EditValueChangedFiringMode = DevExpress.XtraEditors.Controls.EditValueChangedFiringMode.Buffered;
            this.ProgressBarBasicInfo.Name = "ProgressBarBasicInfo";
            this.ProgressBarBasicInfo.ProgressViewStyle = DevExpress.XtraEditors.Controls.ProgressViewStyle.Solid;
            this.ProgressBarBasicInfo.ReadOnly = true;
            this.ProgressBarBasicInfo.ShowTitle = true;
            this.ProgressBarBasicInfo.Step = 1;
            // 
            // message
            // 
            this.message.Caption = "نتیجه ارسال";
            this.message.FieldName = "IP";
            this.message.Name = "message";
            this.message.OptionsColumn.AllowEdit = false;
            this.message.OptionsColumn.AllowSize = false;
            this.message.Tag = "<Null>";
            this.message.Visible = true;
            this.message.VisibleIndex = 3;
            this.message.Width = 102;
            // 
            // ProgressBarPic
            // 
            this.ProgressBarPic.FlowAnimationEnabled = true;
            this.ProgressBarPic.Name = "ProgressBarPic";
            this.ProgressBarPic.ShowTitle = true;
            this.ProgressBarPic.Step = 1;
            // 
            // ProgressBarFinger
            // 
            this.ProgressBarFinger.Name = "ProgressBarFinger";
            this.ProgressBarFinger.ProgressViewStyle = DevExpress.XtraEditors.Controls.ProgressViewStyle.Solid;
            this.ProgressBarFinger.ShowTitle = true;
            this.ProgressBarFinger.Step = 1;
            // 
            // PictureEditSending
            // 
            this.PictureEditSending.AllowDisposeImage = true;
            this.PictureEditSending.Appearance.Image = ((System.Drawing.Image)(resources.GetObject("PictureEditSending.Appearance.Image")));
            this.PictureEditSending.Appearance.Options.UseImage = true;
            this.PictureEditSending.AppearanceReadOnly.Image = ((System.Drawing.Image)(resources.GetObject("PictureEditSending.AppearanceReadOnly.Image")));
            this.PictureEditSending.AppearanceReadOnly.Options.UseImage = true;
            this.PictureEditSending.ContextButtonOptions.AnimationType = DevExpress.Utils.ContextAnimationType.SequenceAnimation;
            this.PictureEditSending.EnableLODImages = true;
            this.PictureEditSending.InitialImage = ((System.Drawing.Image)(resources.GetObject("PictureEditSending.InitialImage")));
            this.PictureEditSending.Name = "PictureEditSending";
            this.PictureEditSending.ReadOnly = true;
            this.PictureEditSending.ShowZoomSubMenu = DevExpress.Utils.DefaultBoolean.False;
            // 
            // TestProgressBar
            // 
            this.TestProgressBar.Name = "TestProgressBar";
            this.TestProgressBar.ShowTitle = true;
            // 
            // repositoryItemRichTextEdit1
            // 
            this.repositoryItemRichTextEdit1.Name = "repositoryItemRichTextEdit1";
            this.repositoryItemRichTextEdit1.ShowCaretInReadOnly = false;
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(6, 19);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(75, 23);
            this.btnSend.TabIndex = 1;
            this.btnSend.Text = "ارسال";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(87, 19);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "لغو";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // GrpInfo
            // 
            this.GrpInfo.Controls.Add(this.chkPalm);
            this.GrpInfo.Controls.Add(this.chkFace);
            this.GrpInfo.Controls.Add(this.chkBasicInfo);
            this.GrpInfo.Controls.Add(this.chkPicture);
            this.GrpInfo.Controls.Add(this.chkFinger);
            this.GrpInfo.Location = new System.Drawing.Point(9, 9);
            this.GrpInfo.Name = "GrpInfo";
            this.GrpInfo.Size = new System.Drawing.Size(677, 70);
            this.GrpInfo.TabIndex = 3;
            this.GrpInfo.TabStop = false;
            this.GrpInfo.Text = "اطلاعات";
            // 
            // chkPalm
            // 
            this.chkPalm.Location = new System.Drawing.Point(87, 29);
            this.chkPalm.Name = "chkPalm";
            this.chkPalm.Properties.Caption = "دست";
            this.chkPalm.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.chkPalm.Size = new System.Drawing.Size(75, 19);
            this.chkPalm.TabIndex = 4;
            // 
            // chkFace
            // 
            this.chkFace.Location = new System.Drawing.Point(210, 29);
            this.chkFace.Name = "chkFace";
            this.chkFace.Properties.Caption = "چهره";
            this.chkFace.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.chkFace.Size = new System.Drawing.Size(75, 19);
            this.chkFace.TabIndex = 3;
            // 
            // chkBasicInfo
            // 
            this.chkBasicInfo.EditValue = true;
            this.chkBasicInfo.Location = new System.Drawing.Point(583, 29);
            this.chkBasicInfo.Name = "chkBasicInfo";
            this.chkBasicInfo.Properties.Caption = "اطلاعات پایه";
            this.chkBasicInfo.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.chkBasicInfo.Size = new System.Drawing.Size(75, 19);
            this.chkBasicInfo.TabIndex = 2;
            // 
            // chkPicture
            // 
            this.chkPicture.Location = new System.Drawing.Point(442, 29);
            this.chkPicture.Name = "chkPicture";
            this.chkPicture.Properties.Caption = "تصویر پروفایل";
            this.chkPicture.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.chkPicture.Size = new System.Drawing.Size(94, 19);
            this.chkPicture.TabIndex = 1;
            // 
            // chkFinger
            // 
            this.chkFinger.Location = new System.Drawing.Point(331, 29);
            this.chkFinger.Name = "chkFinger";
            this.chkFinger.Properties.Caption = "اثر انگشت";
            this.chkFinger.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.chkFinger.Size = new System.Drawing.Size(75, 19);
            this.chkFinger.TabIndex = 0;
            // 
            // GrpBtns
            // 
            this.GrpBtns.Controls.Add(this.btnCancel);
            this.GrpBtns.Controls.Add(this.btnSend);
            this.GrpBtns.Location = new System.Drawing.Point(511, 442);
            this.GrpBtns.Name = "GrpBtns";
            this.GrpBtns.Size = new System.Drawing.Size(175, 58);
            this.GrpBtns.TabIndex = 4;
            this.GrpBtns.TabStop = false;
            // 
            // btnNahad
            // 
            this.btnNahad.Location = new System.Drawing.Point(12, 453);
            this.btnNahad.Name = "btnNahad";
            this.btnNahad.Size = new System.Drawing.Size(77, 38);
            this.btnNahad.TabIndex = 5;
            this.btnNahad.Text = "ارسال TA  ";
            this.btnNahad.UseVisualStyleBackColor = true;
            this.btnNahad.Visible = false;
            this.btnNahad.Click += new System.EventHandler(this.BtnNahad_Click);
            // 
            // FrmSync
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(700, 511);
            this.Controls.Add(this.btnNahad);
            this.Controls.Add(this.GrpBtns);
            this.Controls.Add(this.GrpInfo);
            this.Controls.Add(this.gridSendInfo);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FrmSync";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ارسال اطلاعات  کارمندان";
            this.Load += new System.EventHandler(this.FrmSync_Load);
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemProgressBar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridSendInfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdSendInfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ProgressBarBasicInfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ProgressBarPic)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ProgressBarFinger)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureEditSending)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TestProgressBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemRichTextEdit1)).EndInit();
            this.GrpInfo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chkPalm.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkFace.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkBasicInfo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkPicture.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkFinger.Properties)).EndInit();
            this.GrpBtns.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridSendInfo;
        private DevExpress.XtraGrid.Views.Grid.GridView grdSendInfo;
        private DevExpress.XtraGrid.Columns.GridColumn DeviceCol;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.Button btnCancel;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit4;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit5;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit1;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit2;
        private DevExpress.XtraEditors.Repository.RepositoryItemProgressBar repositoryItemProgressBar1;
        private System.Windows.Forms.GroupBox GrpInfo;
        private DevExpress.XtraEditors.CheckEdit chkBasicInfo;
        private DevExpress.XtraEditors.CheckEdit chkPicture;
        private DevExpress.XtraEditors.CheckEdit chkFinger;
        private System.Windows.Forms.GroupBox GrpBtns;
        private DevExpress.XtraEditors.Repository.RepositoryItemProgressBar ProgressBarPic;
        private DevExpress.XtraEditors.Repository.RepositoryItemProgressBar ProgressBarFinger;
        public DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit PictureEditSending;
        private DevExpress.XtraEditors.Repository.RepositoryItemProgressBar ProgressBarBasicInfo;
        private DevExpress.XtraGrid.Columns.GridColumn basicInfoCol;
        private DevExpress.XtraEditors.Repository.RepositoryItemProgressBar TestProgressBar;
        private DevExpress.XtraGrid.Columns.GridColumn message;
        private DevExpress.XtraEditors.Repository.RepositoryItemRichTextEdit repositoryItemRichTextEdit1;
        private DevExpress.XtraEditors.CheckEdit chkPalm;
        private DevExpress.XtraEditors.CheckEdit chkFace;
        private System.Windows.Forms.Button btnNahad;
    }
}