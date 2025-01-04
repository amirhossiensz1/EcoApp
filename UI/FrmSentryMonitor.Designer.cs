namespace Eco
{
    partial class FrmSentryMonitor
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
            this.grdViewTrafic = new DevExpress.XtraGrid.GridControl();
            this.grdTrafic = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.Id = new DevExpress.XtraGrid.Columns.GridColumn();
            this.GrdEmpFname = new DevExpress.XtraGrid.Columns.GridColumn();
            this.GrdEmpLname = new DevExpress.XtraGrid.Columns.GridColumn();
            this.GrdDevice = new DevExpress.XtraGrid.Columns.GridColumn();
            this.GrdAccessTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.GrdDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.GrdAccessType = new DevExpress.XtraGrid.Columns.GridColumn();
            this.GrdSuccessPass = new DevExpress.XtraGrid.Columns.GridColumn();
            this.GrdReqType = new DevExpress.XtraGrid.Columns.GridColumn();
            this.GrdPictureCol = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            ((System.ComponentModel.ISupportInitialize)(this.grdViewTrafic)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdTrafic)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // grdViewTrafic
            // 
            this.grdViewTrafic.Cursor = System.Windows.Forms.Cursors.Default;
            this.grdViewTrafic.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdViewTrafic.Location = new System.Drawing.Point(0, 0);
            this.grdViewTrafic.MainView = this.grdTrafic;
            this.grdViewTrafic.Name = "grdViewTrafic";
            this.grdViewTrafic.Size = new System.Drawing.Size(902, 554);
            this.grdViewTrafic.TabIndex = 0;
            this.grdViewTrafic.UseEmbeddedNavigator = true;
            this.grdViewTrafic.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grdTrafic,
            this.gridView1});
            // 
            // grdTrafic
            // 
            this.grdTrafic.Appearance.EvenRow.BackColor = System.Drawing.Color.Honeydew;
            this.grdTrafic.Appearance.EvenRow.Options.UseBackColor = true;
            this.grdTrafic.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.grdTrafic.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grdTrafic.Appearance.HeaderPanel.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grdTrafic.Appearance.HeaderPanel.TextOptions.WordWrap = DevExpress.Utils.WordWrap.NoWrap;
            this.grdTrafic.Appearance.OddRow.BackColor = System.Drawing.Color.SeaShell;
            this.grdTrafic.Appearance.OddRow.ForeColor = System.Drawing.Color.Black;
            this.grdTrafic.Appearance.OddRow.Options.UseBackColor = true;
            this.grdTrafic.Appearance.OddRow.Options.UseForeColor = true;
            this.grdTrafic.Appearance.Row.Options.UseTextOptions = true;
            this.grdTrafic.Appearance.Row.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grdTrafic.Appearance.Row.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grdTrafic.Appearance.SelectedRow.BackColor = System.Drawing.Color.Silver;
            this.grdTrafic.Appearance.SelectedRow.Options.UseBackColor = true;
            this.grdTrafic.Appearance.TopNewRow.BackColor = System.Drawing.Color.Lime;
            this.grdTrafic.Appearance.TopNewRow.Options.UseBackColor = true;
            this.grdTrafic.Appearance.ViewCaption.Options.UseTextOptions = true;
            this.grdTrafic.Appearance.ViewCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grdTrafic.Appearance.ViewCaption.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grdTrafic.AppearancePrint.EvenRow.BackColor = System.Drawing.Color.LightGray;
            this.grdTrafic.AppearancePrint.EvenRow.BackColor2 = System.Drawing.Color.White;
            this.grdTrafic.AppearancePrint.EvenRow.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.grdTrafic.AppearancePrint.EvenRow.Options.UseBackColor = true;
            this.grdTrafic.AppearancePrint.EvenRow.Options.UseForeColor = true;
            this.grdTrafic.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.Id,
            this.GrdEmpFname,
            this.GrdEmpLname,
            this.GrdDevice,
            this.GrdAccessTime,
            this.GrdDate,
            this.GrdAccessType,
            this.GrdSuccessPass,
            this.GrdReqType,
            this.GrdPictureCol});
            this.grdTrafic.GridControl = this.grdViewTrafic;
            this.grdTrafic.Name = "grdTrafic";
            this.grdTrafic.NewItemRowText = "top";
            this.grdTrafic.OptionsBehavior.Editable = false;
            this.grdTrafic.OptionsCustomization.AllowRowSizing = true;
            this.grdTrafic.OptionsDetail.AllowExpandEmptyDetails = true;
            this.grdTrafic.OptionsDetail.AllowOnlyOneMasterRowExpanded = true;
            this.grdTrafic.OptionsFind.AlwaysVisible = true;
            this.grdTrafic.OptionsFind.FindMode = DevExpress.XtraEditors.FindMode.Always;
            this.grdTrafic.OptionsFind.FindNullPrompt = "کلمه مورد نظر را وارد کنید ....";
            this.grdTrafic.OptionsFind.ShowClearButton = false;
            this.grdTrafic.OptionsPrint.PrintDetails = true;
            this.grdTrafic.OptionsPrint.PrintFooter = false;
            this.grdTrafic.OptionsPrint.PrintGroupFooter = false;
            this.grdTrafic.OptionsPrint.PrintPreview = true;
            this.grdTrafic.OptionsView.AllowHtmlDrawHeaders = true;
            this.grdTrafic.OptionsView.EnableAppearanceEvenRow = true;
            this.grdTrafic.OptionsView.EnableAppearanceOddRow = true;
            this.grdTrafic.OptionsView.GroupFooterShowMode = DevExpress.XtraGrid.Views.Grid.GroupFooterShowMode.Hidden;
            this.grdTrafic.OptionsView.ShowGroupedColumns = true;
            this.grdTrafic.OptionsView.ShowPreviewRowLines = DevExpress.Utils.DefaultBoolean.True;
            this.grdTrafic.RowHeight = 100;
            this.grdTrafic.RowSeparatorHeight = 2;
            this.grdTrafic.ViewCaptionHeight = 100;
            // 
            // Id
            // 
            this.Id.Caption = "کد کاربری";
            this.Id.FieldName = "Id";
            this.Id.Name = "Id";
            this.Id.OptionsColumn.AllowEdit = false;
            this.Id.OptionsColumn.AllowSize = false;
            this.Id.OptionsColumn.ReadOnly = true;
            this.Id.Visible = true;
            this.Id.VisibleIndex = 0;
            this.Id.Width = 40;
            // 
            // GrdEmpFname
            // 
            this.GrdEmpFname.Caption = "نام کارمند";
            this.GrdEmpFname.FieldName = "EmpFname";
            this.GrdEmpFname.Name = "GrdEmpFname";
            this.GrdEmpFname.OptionsColumn.AllowEdit = false;
            this.GrdEmpFname.OptionsColumn.AllowSize = false;
            this.GrdEmpFname.OptionsColumn.ReadOnly = true;
            this.GrdEmpFname.Visible = true;
            this.GrdEmpFname.VisibleIndex = 1;
            // 
            // GrdEmpLname
            // 
            this.GrdEmpLname.Caption = "نام خانوادگی";
            this.GrdEmpLname.FieldName = "EmpLname";
            this.GrdEmpLname.Name = "GrdEmpLname";
            this.GrdEmpLname.OptionsColumn.AllowEdit = false;
            this.GrdEmpLname.OptionsColumn.AllowSize = false;
            this.GrdEmpLname.OptionsColumn.ReadOnly = true;
            this.GrdEmpLname.Visible = true;
            this.GrdEmpLname.VisibleIndex = 2;
            // 
            // GrdDevice
            // 
            this.GrdDevice.Caption = "دستگاه";
            this.GrdDevice.FieldName = "DeviceName";
            this.GrdDevice.Name = "GrdDevice";
            this.GrdDevice.OptionsColumn.AllowSize = false;
            this.GrdDevice.Visible = true;
            this.GrdDevice.VisibleIndex = 3;
            // 
            // GrdAccessTime
            // 
            this.GrdAccessTime.Caption = "زمان تردد";
            this.GrdAccessTime.FieldName = "Time";
            this.GrdAccessTime.Name = "GrdAccessTime";
            this.GrdAccessTime.OptionsColumn.AllowSize = false;
            this.GrdAccessTime.Visible = true;
            this.GrdAccessTime.VisibleIndex = 4;
            // 
            // GrdDate
            // 
            this.GrdDate.Caption = "تاریخ";
            this.GrdDate.FieldName = "Date";
            this.GrdDate.Name = "GrdDate";
            this.GrdDate.OptionsColumn.AllowSize = false;
            this.GrdDate.Visible = true;
            this.GrdDate.VisibleIndex = 5;
            // 
            // GrdAccessType
            // 
            this.GrdAccessType.Caption = "نوع تردد";
            this.GrdAccessType.FieldName = "Type";
            this.GrdAccessType.Name = "GrdAccessType";
            this.GrdAccessType.OptionsColumn.AllowSize = false;
            this.GrdAccessType.OptionsColumn.ReadOnly = true;
            this.GrdAccessType.Visible = true;
            this.GrdAccessType.VisibleIndex = 6;
            // 
            // GrdSuccessPass
            // 
            this.GrdSuccessPass.Caption = "صحت عبور";
            this.GrdSuccessPass.FieldName = "SuccessPass";
            this.GrdSuccessPass.Name = "GrdSuccessPass";
            this.GrdSuccessPass.OptionsColumn.AllowSize = false;
            this.GrdSuccessPass.OptionsColumn.ReadOnly = true;
            this.GrdSuccessPass.Visible = true;
            this.GrdSuccessPass.VisibleIndex = 7;
            // 
            // GrdReqType
            // 
            this.GrdReqType.AppearanceCell.Options.UseImage = true;
            this.GrdReqType.AppearanceCell.Options.UseTextOptions = true;
            this.GrdReqType.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.GrdReqType.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.GrdReqType.Caption = "نحوه تردد";
            this.GrdReqType.FieldName = "ReqType";
            this.GrdReqType.Name = "GrdReqType";
            this.GrdReqType.OptionsColumn.AllowSize = false;
            this.GrdReqType.OptionsColumn.ReadOnly = true;
            this.GrdReqType.Visible = true;
            this.GrdReqType.VisibleIndex = 8;
            // 
            // GrdPictureCol
            // 
            this.GrdPictureCol.Caption = "تصویر";
            this.GrdPictureCol.FieldName = "Image";
            this.GrdPictureCol.Name = "GrdPictureCol";
            this.GrdPictureCol.OptionsColumn.AllowEdit = false;
            this.GrdPictureCol.OptionsColumn.AllowSize = false;
            this.GrdPictureCol.OptionsColumn.ReadOnly = true;
            this.GrdPictureCol.UnboundType = DevExpress.Data.UnboundColumnType.Object;
            this.GrdPictureCol.Visible = true;
            this.GrdPictureCol.VisibleIndex = 9;
            // 
            // gridView1
            // 
            this.gridView1.GridControl = this.grdViewTrafic;
            this.gridView1.Name = "gridView1";
            // 
            // FrmSentryMonitor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(902, 554);
            this.Controls.Add(this.grdViewTrafic);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "FrmSentryMonitor";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmSentryMonitor_FormClosing);
            this.Load += new System.EventHandler(this.FrmSentryMonitor_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdViewTrafic)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdTrafic)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl grdViewTrafic;
        private DevExpress.XtraGrid.Views.Grid.GridView grdTrafic;
        private DevExpress.XtraGrid.Columns.GridColumn Id;
        private DevExpress.XtraGrid.Columns.GridColumn GrdEmpFname;
        private DevExpress.XtraGrid.Columns.GridColumn GrdEmpLname;
        private DevExpress.XtraGrid.Columns.GridColumn GrdDevice;
        private DevExpress.XtraGrid.Columns.GridColumn GrdAccessTime;
        private DevExpress.XtraGrid.Columns.GridColumn GrdDate;
        private DevExpress.XtraGrid.Columns.GridColumn GrdAccessType;
        private DevExpress.XtraGrid.Columns.GridColumn GrdPictureCol;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn GrdSuccessPass;
        private DevExpress.XtraGrid.Columns.GridColumn GrdReqType;

    }
}