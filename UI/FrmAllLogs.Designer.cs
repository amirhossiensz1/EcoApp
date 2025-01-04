namespace UI
{
    partial class FrmAllLogs
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmAllLogs));
            this.grdViewAllLogs = new DevExpress.XtraGrid.GridControl();
            this.girdViewAllLogs = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.Id = new DevExpress.XtraGrid.Columns.GridColumn();
            this.GrdEmpFname = new DevExpress.XtraGrid.Columns.GridColumn();
            this.GrdEmpLname = new DevExpress.XtraGrid.Columns.GridColumn();
            this.GrdPersonalNum = new DevExpress.XtraGrid.Columns.GridColumn();
            this.GrdDevice = new DevExpress.XtraGrid.Columns.GridColumn();
            this.GrdAccessTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.GrdDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.GrdAccessType = new DevExpress.XtraGrid.Columns.GridColumn();
            this.GrdSuccessPass = new DevExpress.XtraGrid.Columns.GridColumn();
            this.GrdReqType = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdpictureCol = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CmbBxType = new System.Windows.Forms.ComboBox();
            this.lblTypeExport = new System.Windows.Forms.Label();
            this.BtnExport = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.grdViewAllLogs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.girdViewAllLogs)).BeginInit();
            this.SuspendLayout();
            // 
            // grdViewAllLogs
            // 
            this.grdViewAllLogs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdViewAllLogs.Location = new System.Drawing.Point(0, 0);
            this.grdViewAllLogs.MainView = this.girdViewAllLogs;
            this.grdViewAllLogs.Name = "grdViewAllLogs";
            this.grdViewAllLogs.Size = new System.Drawing.Size(789, 462);
            this.grdViewAllLogs.TabIndex = 0;
            this.grdViewAllLogs.UseEmbeddedNavigator = true;
            this.grdViewAllLogs.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.girdViewAllLogs});
            this.grdViewAllLogs.Click += new System.EventHandler(this.grdViewAllLogs_Click);
            // 
            // girdViewAllLogs
            // 
            this.girdViewAllLogs.Appearance.EvenRow.BackColor = System.Drawing.Color.SeaShell;
            this.girdViewAllLogs.Appearance.EvenRow.Options.UseBackColor = true;
            this.girdViewAllLogs.Appearance.OddRow.BackColor = System.Drawing.Color.Honeydew;
            this.girdViewAllLogs.Appearance.OddRow.Options.UseBackColor = true;
            this.girdViewAllLogs.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.Id,
            this.GrdEmpFname,
            this.GrdEmpLname,
            this.GrdPersonalNum,
            this.GrdDevice,
            this.GrdAccessTime,
            this.GrdDate,
            this.GrdAccessType,
            this.GrdSuccessPass,
            this.GrdReqType,
            this.grdpictureCol});
            this.girdViewAllLogs.GridControl = this.grdViewAllLogs;
            this.girdViewAllLogs.Name = "girdViewAllLogs";
            this.girdViewAllLogs.OptionsBehavior.AutoSelectAllInEditor = false;
            this.girdViewAllLogs.OptionsBehavior.Editable = false;
            this.girdViewAllLogs.OptionsFilter.InHeaderSearchMode = DevExpress.XtraGrid.Views.Grid.GridInHeaderSearchMode.TextSearch;
            this.girdViewAllLogs.OptionsFind.AlwaysVisible = true;
            this.girdViewAllLogs.OptionsFind.FindNullPrompt = "کلمه مورد نظر را وارد کنید ....";
            this.girdViewAllLogs.OptionsFind.SearchInPreview = true;
            this.girdViewAllLogs.OptionsPrint.PrintDetails = true;
            this.girdViewAllLogs.OptionsPrint.PrintFilterInfo = true;
            this.girdViewAllLogs.OptionsPrint.PrintFooter = false;
            this.girdViewAllLogs.OptionsPrint.PrintGroupFooter = false;
            this.girdViewAllLogs.OptionsPrint.PrintPreview = true;
            this.girdViewAllLogs.OptionsSelection.MultiSelect = true;
            this.girdViewAllLogs.OptionsSelection.ResetSelectionClickOutsideCheckboxSelector = true;
            this.girdViewAllLogs.OptionsSelection.ShowCheckBoxSelectorInPrintExport = DevExpress.Utils.DefaultBoolean.True;
            this.girdViewAllLogs.OptionsView.AnimationType = DevExpress.XtraGrid.Views.Base.GridAnimationType.AnimateAllContent;
            this.girdViewAllLogs.OptionsView.EnableAppearanceEvenRow = true;
            this.girdViewAllLogs.OptionsView.EnableAppearanceOddRow = true;
            this.girdViewAllLogs.OptionsView.GroupFooterShowMode = DevExpress.XtraGrid.Views.Grid.GroupFooterShowMode.Hidden;
            this.girdViewAllLogs.RowHeight = 70;
            this.girdViewAllLogs.RowSeparatorHeight = 2;
            // 
            // Id
            // 
            this.Id.AppearanceCell.Options.UseTextOptions = true;
            this.Id.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.Id.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.Id.AppearanceHeader.Options.UseTextOptions = true;
            this.Id.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.Id.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.Id.Caption = "کد کاربری";
            this.Id.FieldName = "Id";
            this.Id.Name = "Id";
            this.Id.OptionsColumn.AllowEdit = false;
            this.Id.OptionsColumn.AllowSize = false;
            this.Id.OptionsColumn.ReadOnly = true;
            this.Id.Visible = true;
            this.Id.VisibleIndex = 0;
            this.Id.Width = 65;
            // 
            // GrdEmpFname
            // 
            this.GrdEmpFname.AppearanceHeader.Options.UseTextOptions = true;
            this.GrdEmpFname.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.GrdEmpFname.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.GrdEmpFname.Caption = "نام کارمند";
            this.GrdEmpFname.FieldName = "EmpFname";
            this.GrdEmpFname.Name = "GrdEmpFname";
            this.GrdEmpFname.OptionsColumn.AllowEdit = false;
            this.GrdEmpFname.OptionsColumn.AllowSize = false;
            this.GrdEmpFname.OptionsColumn.ReadOnly = true;
            this.GrdEmpFname.Visible = true;
            this.GrdEmpFname.VisibleIndex = 1;
            this.GrdEmpFname.Width = 105;
            // 
            // GrdEmpLname
            // 
            this.GrdEmpLname.AppearanceHeader.Options.UseTextOptions = true;
            this.GrdEmpLname.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.GrdEmpLname.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.GrdEmpLname.Caption = "نام خانوادگی";
            this.GrdEmpLname.FieldName = "EmpLname";
            this.GrdEmpLname.Name = "GrdEmpLname";
            this.GrdEmpLname.OptionsColumn.AllowEdit = false;
            this.GrdEmpLname.OptionsColumn.AllowSize = false;
            this.GrdEmpLname.OptionsColumn.ReadOnly = true;
            this.GrdEmpLname.Visible = true;
            this.GrdEmpLname.VisibleIndex = 2;
            this.GrdEmpLname.Width = 97;
            // 
            // GrdPersonalNum
            // 
            this.GrdPersonalNum.AppearanceCell.Options.UseTextOptions = true;
            this.GrdPersonalNum.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.GrdPersonalNum.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.GrdPersonalNum.AppearanceHeader.Options.UseTextOptions = true;
            this.GrdPersonalNum.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.GrdPersonalNum.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.GrdPersonalNum.Caption = "شماره کارمندی";
            this.GrdPersonalNum.FieldName = "EmpPersonalNum";
            this.GrdPersonalNum.Name = "GrdPersonalNum";
            this.GrdPersonalNum.OptionsColumn.AllowEdit = false;
            this.GrdPersonalNum.OptionsColumn.AllowSize = false;
            this.GrdPersonalNum.OptionsColumn.ReadOnly = true;
            this.GrdPersonalNum.Visible = true;
            this.GrdPersonalNum.VisibleIndex = 3;
            this.GrdPersonalNum.Width = 90;
            // 
            // GrdDevice
            // 
            this.GrdDevice.AppearanceHeader.Options.UseTextOptions = true;
            this.GrdDevice.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.GrdDevice.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.GrdDevice.Caption = "دستگاه";
            this.GrdDevice.FieldName = "DeviceName";
            this.GrdDevice.Name = "GrdDevice";
            this.GrdDevice.OptionsColumn.AllowEdit = false;
            this.GrdDevice.OptionsColumn.AllowSize = false;
            this.GrdDevice.OptionsColumn.ReadOnly = true;
            this.GrdDevice.Visible = true;
            this.GrdDevice.VisibleIndex = 4;
            this.GrdDevice.Width = 183;
            // 
            // GrdAccessTime
            // 
            this.GrdAccessTime.AppearanceHeader.Options.UseTextOptions = true;
            this.GrdAccessTime.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.GrdAccessTime.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.GrdAccessTime.Caption = "ساعت تردد";
            this.GrdAccessTime.FieldName = "Time";
            this.GrdAccessTime.Name = "GrdAccessTime";
            this.GrdAccessTime.OptionsColumn.AllowEdit = false;
            this.GrdAccessTime.OptionsColumn.AllowSize = false;
            this.GrdAccessTime.OptionsColumn.ReadOnly = true;
            this.GrdAccessTime.Visible = true;
            this.GrdAccessTime.VisibleIndex = 5;
            this.GrdAccessTime.Width = 74;
            // 
            // GrdDate
            // 
            this.GrdDate.AppearanceHeader.Options.UseTextOptions = true;
            this.GrdDate.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.GrdDate.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.GrdDate.Caption = "تاریخ تردد";
            this.GrdDate.FieldName = "Date";
            this.GrdDate.Name = "GrdDate";
            this.GrdDate.OptionsColumn.AllowEdit = false;
            this.GrdDate.OptionsColumn.AllowSize = false;
            this.GrdDate.OptionsColumn.ReadOnly = true;
            this.GrdDate.Visible = true;
            this.GrdDate.VisibleIndex = 6;
            this.GrdDate.Width = 77;
            // 
            // GrdAccessType
            // 
            this.GrdAccessType.AppearanceHeader.Options.UseTextOptions = true;
            this.GrdAccessType.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.GrdAccessType.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.GrdAccessType.Caption = "نوع تردد";
            this.GrdAccessType.FieldName = "Type";
            this.GrdAccessType.Name = "GrdAccessType";
            this.GrdAccessType.OptionsColumn.AllowEdit = false;
            this.GrdAccessType.OptionsColumn.AllowSize = false;
            this.GrdAccessType.OptionsColumn.ReadOnly = true;
            this.GrdAccessType.Visible = true;
            this.GrdAccessType.VisibleIndex = 7;
            this.GrdAccessType.Width = 73;
            // 
            // GrdSuccessPass
            // 
            this.GrdSuccessPass.AppearanceHeader.Options.UseTextOptions = true;
            this.GrdSuccessPass.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.GrdSuccessPass.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.GrdSuccessPass.Caption = "صحت عبور";
            this.GrdSuccessPass.FieldName = "SuccessPass";
            this.GrdSuccessPass.Name = "GrdSuccessPass";
            this.GrdSuccessPass.OptionsColumn.AllowEdit = false;
            this.GrdSuccessPass.OptionsColumn.AllowSize = false;
            this.GrdSuccessPass.OptionsColumn.ReadOnly = true;
            this.GrdSuccessPass.Visible = true;
            this.GrdSuccessPass.VisibleIndex = 8;
            this.GrdSuccessPass.Width = 76;
            // 
            // GrdReqType
            // 
            this.GrdReqType.Caption = "نحوه تردد";
            this.GrdReqType.FieldName = "ReqType";
            this.GrdReqType.Name = "GrdReqType";
            this.GrdReqType.OptionsColumn.AllowEdit = false;
            this.GrdReqType.OptionsColumn.AllowSize = false;
            this.GrdReqType.OptionsColumn.ReadOnly = true;
            this.GrdReqType.Visible = true;
            this.GrdReqType.VisibleIndex = 9;
            this.GrdReqType.Width = 90;
            // 
            // grdpictureCol
            // 
            this.grdpictureCol.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grdpictureCol.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grdpictureCol.Caption = "تصویر";
            this.grdpictureCol.FieldName = "Image";
            this.grdpictureCol.Name = "grdpictureCol";
            this.grdpictureCol.OptionsColumn.AllowEdit = false;
            this.grdpictureCol.OptionsColumn.AllowSize = false;
            this.grdpictureCol.OptionsColumn.ReadOnly = true;
            this.grdpictureCol.Width = 83;
            // 
            // CmbBxType
            // 
            this.CmbBxType.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.CmbBxType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbBxType.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.CmbBxType.FormattingEnabled = true;
            this.CmbBxType.Location = new System.Drawing.Point(604, 12);
            this.CmbBxType.Name = "CmbBxType";
            this.CmbBxType.Size = new System.Drawing.Size(121, 24);
            this.CmbBxType.TabIndex = 16;
            this.CmbBxType.SelectedIndexChanged += new System.EventHandler(this.CmbBxType_SelectedIndexChanged);
            // 
            // lblTypeExport
            // 
            this.lblTypeExport.AutoSize = true;
            this.lblTypeExport.BackColor = System.Drawing.SystemColors.ControlLight;
            this.lblTypeExport.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblTypeExport.Location = new System.Drawing.Point(483, 15);
            this.lblTypeExport.Name = "lblTypeExport";
            this.lblTypeExport.Size = new System.Drawing.Size(115, 16);
            this.lblTypeExport.TabIndex = 15;
            this.lblTypeExport.Text = "انتخاب نوع خروجی:";
            this.lblTypeExport.Click += new System.EventHandler(this.lblTypeExport_Click);
            // 
            // BtnExport
            // 
            this.BtnExport.Location = new System.Drawing.Point(731, 12);
            this.BtnExport.Name = "BtnExport";
            this.BtnExport.Size = new System.Drawing.Size(52, 23);
            this.BtnExport.TabIndex = 13;
            this.BtnExport.Text = "خروجی ";
            this.BtnExport.Click += new System.EventHandler(this.BtnExport_Click);
            // 
            // FrmAllLogs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(789, 462);
            this.Controls.Add(this.CmbBxType);
            this.Controls.Add(this.lblTypeExport);
            this.Controls.Add(this.BtnExport);
            this.Controls.Add(this.grdViewAllLogs);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmAllLogs";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "گزارش کلیه تردد ها";
            this.Load += new System.EventHandler(this.FrmAllLogs_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdViewAllLogs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.girdViewAllLogs)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraGrid.GridControl grdViewAllLogs;
        private DevExpress.XtraGrid.Views.Grid.GridView girdViewAllLogs;
        private DevExpress.XtraGrid.Columns.GridColumn GrdEmpFname;
        private DevExpress.XtraGrid.Columns.GridColumn GrdEmpLname;
        private DevExpress.XtraGrid.Columns.GridColumn GrdDevice;
        private DevExpress.XtraGrid.Columns.GridColumn GrdAccessTime;
        private DevExpress.XtraGrid.Columns.GridColumn GrdDate;
        private DevExpress.XtraGrid.Columns.GridColumn GrdAccessType;
        private DevExpress.XtraGrid.Columns.GridColumn grdpictureCol;
        private System.Windows.Forms.ComboBox CmbBxType;
        private System.Windows.Forms.Label lblTypeExport;
        private DevExpress.XtraEditors.SimpleButton BtnExport;
        private DevExpress.XtraGrid.Columns.GridColumn GrdPersonalNum;
        private DevExpress.XtraGrid.Columns.GridColumn Id;
        private DevExpress.XtraGrid.Columns.GridColumn GrdSuccessPass;
        private DevExpress.XtraGrid.Columns.GridColumn GrdReqType;
    }
}