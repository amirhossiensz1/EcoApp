namespace Eco
{
    partial class FrmDeleteInfo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmDeleteInfo));
            this.GrpBtns = new System.Windows.Forms.GroupBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSend = new System.Windows.Forms.Button();
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
            this.GrpBtns.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridSendInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdSendInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ProgressBarBasicInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ProgressBarPic)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ProgressBarFinger)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureEditSending)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TestProgressBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemRichTextEdit1)).BeginInit();
            this.SuspendLayout();
            // 
            // GrpBtns
            // 
            this.GrpBtns.Controls.Add(this.btnCancel);
            this.GrpBtns.Controls.Add(this.btnSend);
            this.GrpBtns.Location = new System.Drawing.Point(564, 366);
            this.GrpBtns.Name = "GrpBtns";
            this.GrpBtns.Size = new System.Drawing.Size(175, 58);
            this.GrpBtns.TabIndex = 6;
            this.GrpBtns.TabStop = false;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(87, 19);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "لغو";
            this.btnCancel.UseVisualStyleBackColor = true;
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
            // gridSendInfo
            // 
            this.gridSendInfo.Cursor = System.Windows.Forms.Cursors.Default;
            this.gridSendInfo.Location = new System.Drawing.Point(0, 1);
            this.gridSendInfo.MainView = this.grdSendInfo;
            this.gridSendInfo.Name = "gridSendInfo";
            this.gridSendInfo.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.ProgressBarPic,
            this.ProgressBarFinger,
            this.ProgressBarBasicInfo,
            this.PictureEditSending,
            this.TestProgressBar,
            this.repositoryItemRichTextEdit1});
            this.gridSendInfo.Size = new System.Drawing.Size(750, 359);
            this.gridSendInfo.TabIndex = 5;
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
            // FrmDeleteInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(751, 436);
            this.Controls.Add(this.GrpBtns);
            this.Controls.Add(this.gridSendInfo);
            this.Name = "FrmDeleteInfo";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.TopMost = true;
            this.Load += new System.EventHandler(this.FrmDeleteInfo_Load);
            this.GrpBtns.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridSendInfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdSendInfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ProgressBarBasicInfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ProgressBarPic)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ProgressBarFinger)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureEditSending)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TestProgressBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemRichTextEdit1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox GrpBtns;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSend;
        private DevExpress.XtraGrid.GridControl gridSendInfo;
        private DevExpress.XtraGrid.Views.Grid.GridView grdSendInfo;
        private DevExpress.XtraGrid.Columns.GridColumn DeviceCol;
        private DevExpress.XtraGrid.Columns.GridColumn basicInfoCol;
        private DevExpress.XtraEditors.Repository.RepositoryItemProgressBar ProgressBarBasicInfo;
        private DevExpress.XtraGrid.Columns.GridColumn message;
        private DevExpress.XtraEditors.Repository.RepositoryItemProgressBar ProgressBarPic;
        private DevExpress.XtraEditors.Repository.RepositoryItemProgressBar ProgressBarFinger;
        public DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit PictureEditSending;
        private DevExpress.XtraEditors.Repository.RepositoryItemProgressBar TestProgressBar;
        private DevExpress.XtraEditors.Repository.RepositoryItemRichTextEdit repositoryItemRichTextEdit1;
    }
}