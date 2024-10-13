namespace Eco
{
    partial class FrmGetInfo
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
            this.ProgressBarBasicInfo = new DevExpress.XtraEditors.Repository.RepositoryItemProgressBar();
            this.repositoryItemCheckEdit4 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.repositoryItemCheckEdit5 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.repositoryItemCheckEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.repositoryItemCheckEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.repositoryItemProgressBar1 = new DevExpress.XtraEditors.Repository.RepositoryItemProgressBar();
            this.gridGetInfo = new DevExpress.XtraGrid.GridControl();
            this.grdGetInfo = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.FullNameCol = new DevExpress.XtraGrid.Columns.GridColumn();
            this.PersonalNumCol = new DevExpress.XtraGrid.Columns.GridColumn();
            this.basicInfoCol = new DevExpress.XtraGrid.Columns.GridColumn();
            this.message = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnGet = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.GrpInfo = new System.Windows.Forms.GroupBox();
            this.chkPalm = new DevExpress.XtraEditors.CheckEdit();
            this.chkFace = new DevExpress.XtraEditors.CheckEdit();
            this.chkBasicInfo = new DevExpress.XtraEditors.CheckEdit();
            this.chkFinger = new DevExpress.XtraEditors.CheckEdit();
            this.GrpBtns = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.ProgressBarBasicInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemProgressBar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridGetInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdGetInfo)).BeginInit();
            this.GrpInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkPalm.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkFace.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkBasicInfo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkFinger.Properties)).BeginInit();
            this.GrpBtns.SuspendLayout();
            this.SuspendLayout();
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
            // gridGetInfo
            // 
            this.gridGetInfo.Cursor = System.Windows.Forms.Cursors.Default;
            this.gridGetInfo.Location = new System.Drawing.Point(1, 88);
            this.gridGetInfo.MainView = this.grdGetInfo;
            this.gridGetInfo.Name = "gridGetInfo";
            this.gridGetInfo.Size = new System.Drawing.Size(899, 348);
            this.gridGetInfo.TabIndex = 0;
            this.gridGetInfo.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grdGetInfo});
            // 
            // grdGetInfo
            // 
            this.grdGetInfo.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.grdGetInfo.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grdGetInfo.Appearance.HeaderPanel.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grdGetInfo.Appearance.Row.Options.UseTextOptions = true;
            this.grdGetInfo.Appearance.Row.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grdGetInfo.Appearance.Row.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grdGetInfo.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.FullNameCol,
            this.PersonalNumCol,
            this.basicInfoCol,
            this.message});
            this.grdGetInfo.GridControl = this.gridGetInfo;
            this.grdGetInfo.Name = "grdGetInfo";
            this.grdGetInfo.OptionsBehavior.AutoSelectAllInEditor = false;
            this.grdGetInfo.OptionsBehavior.Editable = false;
            this.grdGetInfo.OptionsDetail.SmartDetailHeight = true;
            this.grdGetInfo.OptionsFind.AlwaysVisible = true;
            this.grdGetInfo.OptionsFind.FindDelay = 100;
            this.grdGetInfo.OptionsFind.FindNullPrompt = "جستو جو";
            this.grdGetInfo.OptionsFind.ShowClearButton = false;
            this.grdGetInfo.OptionsFind.ShowCloseButton = false;
            this.grdGetInfo.OptionsImageLoad.AnimationType = DevExpress.Utils.ImageContentAnimationType.Expand;
            this.grdGetInfo.OptionsSelection.MultiSelect = true;
            this.grdGetInfo.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect;
            this.grdGetInfo.OptionsView.RowAutoHeight = true;
            this.grdGetInfo.OptionsView.ShowPreviewRowLines = DevExpress.Utils.DefaultBoolean.True;
            this.grdGetInfo.RowHeight = 35;
            // 
            // FullNameCol
            // 
            this.FullNameCol.Caption = "نام و نام خانوادگی ";
            this.FullNameCol.FieldName = "EmpFullName";
            this.FullNameCol.Name = "FullNameCol";
            this.FullNameCol.OptionsColumn.AllowEdit = false;
            this.FullNameCol.Visible = true;
            this.FullNameCol.VisibleIndex = 1;
            this.FullNameCol.Width = 133;
            // 
            // PersonalNumCol
            // 
            this.PersonalNumCol.Caption = "شماره پرسنلی";
            this.PersonalNumCol.FieldName = "PersonalNum";
            this.PersonalNumCol.Name = "PersonalNumCol";
            this.PersonalNumCol.OptionsColumn.AllowEdit = false;
            this.PersonalNumCol.Visible = true;
            this.PersonalNumCol.VisibleIndex = 2;
            this.PersonalNumCol.Width = 81;
            // 
            // basicInfoCol
            // 
            this.basicInfoCol.Caption = "وضعیت دریافت";
            this.basicInfoCol.ColumnEdit = this.ProgressBarBasicInfo;
            this.basicInfoCol.FieldName = "EmpPinCode";
            this.basicInfoCol.Name = "basicInfoCol";
            this.basicInfoCol.Visible = true;
            this.basicInfoCol.VisibleIndex = 3;
            this.basicInfoCol.Width = 148;
            // 
            // message
            // 
            this.message.Caption = "نتیجه ";
            this.message.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.message.FieldName = "Post";
            this.message.Name = "message";
            this.message.OptionsColumn.AllowEdit = false;
            this.message.Tag = "<Null>";
            this.message.Visible = true;
            this.message.VisibleIndex = 4;
            this.message.Width = 444;
            // 
            // btnGet
            // 
            this.btnGet.Location = new System.Drawing.Point(6, 19);
            this.btnGet.Name = "btnGet";
            this.btnGet.Size = new System.Drawing.Size(75, 23);
            this.btnGet.TabIndex = 1;
            this.btnGet.Text = "دریافت";
            this.btnGet.UseVisualStyleBackColor = true;
            this.btnGet.Click += new System.EventHandler(this.btnGet_Click);
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
            this.GrpInfo.Controls.Add(this.chkFinger);
            this.GrpInfo.Location = new System.Drawing.Point(9, 9);
            this.GrpInfo.Name = "GrpInfo";
            this.GrpInfo.Size = new System.Drawing.Size(891, 70);
            this.GrpInfo.TabIndex = 3;
            this.GrpInfo.TabStop = false;
            this.GrpInfo.Text = "اطلاعات";
            // 
            // chkPalm
            // 
            this.chkPalm.Enabled = false;
            this.chkPalm.Location = new System.Drawing.Point(172, 29);
            this.chkPalm.Name = "chkPalm";
            this.chkPalm.Properties.Caption = "دست";
            this.chkPalm.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.chkPalm.Size = new System.Drawing.Size(75, 19);
            this.chkPalm.TabIndex = 4;
            // 
            // chkFace
            // 
            this.chkFace.Location = new System.Drawing.Point(301, 29);
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
            this.chkBasicInfo.Properties.Caption = "کد کارت";
            this.chkBasicInfo.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.chkBasicInfo.Size = new System.Drawing.Size(75, 19);
            this.chkBasicInfo.TabIndex = 2;
            // 
            // chkFinger
            // 
            this.chkFinger.Location = new System.Drawing.Point(442, 29);
            this.chkFinger.Name = "chkFinger";
            this.chkFinger.Properties.Caption = "اثر انگشت";
            this.chkFinger.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.chkFinger.Size = new System.Drawing.Size(75, 19);
            this.chkFinger.TabIndex = 0;
            // 
            // GrpBtns
            // 
            this.GrpBtns.Controls.Add(this.btnCancel);
            this.GrpBtns.Controls.Add(this.btnGet);
            this.GrpBtns.Location = new System.Drawing.Point(725, 442);
            this.GrpBtns.Name = "GrpBtns";
            this.GrpBtns.Size = new System.Drawing.Size(175, 58);
            this.GrpBtns.TabIndex = 4;
            this.GrpBtns.TabStop = false;
            // 
            // FrmGetInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(905, 511);
            this.Controls.Add(this.GrpBtns);
            this.Controls.Add(this.GrpInfo);
            this.Controls.Add(this.gridGetInfo);
            this.MaximizeBox = false;
            this.Name = "FrmGetInfo";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "دریافت اطلاعات  کارمندان";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmGetInfo_FormClosing);
            this.Load += new System.EventHandler(this.FrmGetInfo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ProgressBarBasicInfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemProgressBar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridGetInfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdGetInfo)).EndInit();
            this.GrpInfo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chkPalm.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkFace.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkBasicInfo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkFinger.Properties)).EndInit();
            this.GrpBtns.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridGetInfo;
        private DevExpress.XtraGrid.Views.Grid.GridView grdGetInfo;
        private DevExpress.XtraGrid.Columns.GridColumn FullNameCol;
        private System.Windows.Forms.Button btnGet;
        private System.Windows.Forms.Button btnCancel;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit4;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit5;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit1;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit2;
        private DevExpress.XtraEditors.Repository.RepositoryItemProgressBar repositoryItemProgressBar1;
        private System.Windows.Forms.GroupBox GrpInfo;
        private DevExpress.XtraEditors.CheckEdit chkBasicInfo;
        private DevExpress.XtraEditors.CheckEdit chkFinger;
        private System.Windows.Forms.GroupBox GrpBtns;
        private DevExpress.XtraGrid.Columns.GridColumn basicInfoCol;
        private DevExpress.XtraGrid.Columns.GridColumn message;
        private DevExpress.XtraEditors.CheckEdit chkPalm;
        private DevExpress.XtraEditors.CheckEdit chkFace;
        private DevExpress.XtraEditors.Repository.RepositoryItemProgressBar ProgressBarBasicInfo;
        private DevExpress.XtraGrid.Columns.GridColumn PersonalNumCol;
    }
}