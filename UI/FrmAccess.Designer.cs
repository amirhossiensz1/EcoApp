using Application = System.Windows.Forms.Application;

namespace UI
{
    partial class FrmAccess
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmAccess));
            this.fingerLink = new DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit();
            this.gridAccess = new DevExpress.XtraGrid.GridControl();
            this.grdAccess = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.Id = new DevExpress.XtraGrid.Columns.GridColumn();
            this.FirstNameCol = new DevExpress.XtraGrid.Columns.GridColumn();
            this.LastNameCol = new DevExpress.XtraGrid.Columns.GridColumn();
            this.PersonalNumCol = new DevExpress.XtraGrid.Columns.GridColumn();
            this.FingerCol = new DevExpress.XtraGrid.Columns.GridColumn();
            this.PicCol = new DevExpress.XtraGrid.Columns.GridColumn();
            this.DbCol = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnSend = new DevExpress.XtraEditors.SimpleButton();
            this.GrpBoxAccess = new System.Windows.Forms.GroupBox();
            this.SendProgress = new DevExpress.XtraEditors.ProgressBarControl();
            this.figerLinks = new DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit();
            ((System.ComponentModel.ISupportInitialize)(this.fingerLink)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridAccess)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdAccess)).BeginInit();
            this.GrpBoxAccess.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SendProgress.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.figerLinks)).BeginInit();
            this.SuspendLayout();
            // 
            // fingerLink
            // 
            this.fingerLink.AccessibleDescription = "";
            this.fingerLink.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.fingerLink.Caption = "جزئیات";
            this.fingerLink.EditFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.fingerLink.Name = "fingerLink";
            this.fingerLink.NullText = "جزئیات";
            // 
            // gridAccess
            // 
            this.gridAccess.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridAccess.Location = new System.Drawing.Point(3, 16);
            this.gridAccess.MainView = this.grdAccess;
            this.gridAccess.Name = "gridAccess";
            this.gridAccess.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.figerLinks});
            this.gridAccess.Size = new System.Drawing.Size(551, 406);
            this.gridAccess.TabIndex = 0;
            this.gridAccess.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grdAccess});
            // 
            // grdAccess
            // 
            this.grdAccess.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.grdAccess.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grdAccess.Appearance.HeaderPanel.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grdAccess.Appearance.Row.Options.UseTextOptions = true;
            this.grdAccess.Appearance.Row.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grdAccess.Appearance.Row.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grdAccess.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.Id,
            this.FirstNameCol,
            this.LastNameCol,
            this.PersonalNumCol,
            this.FingerCol,
            this.PicCol,
            this.DbCol});
            this.grdAccess.GridControl = this.gridAccess;
            this.grdAccess.Name = "grdAccess";
            this.grdAccess.OptionsFind.AlwaysVisible = true;
            this.grdAccess.OptionsFind.FindDelay = 100;
            this.grdAccess.OptionsFind.FindNullPrompt = "جست و جو ...";
            this.grdAccess.OptionsFind.ShowClearButton = false;
            this.grdAccess.OptionsFind.ShowCloseButton = false;
            this.grdAccess.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect;
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
            this.Id.Width = 58;
            // 
            // FirstNameCol
            // 
            this.FirstNameCol.Caption = "نام";
            this.FirstNameCol.FieldName = "EmpFname";
            this.FirstNameCol.Name = "FirstNameCol";
            this.FirstNameCol.OptionsColumn.AllowEdit = false;
            this.FirstNameCol.OptionsColumn.AllowSize = false;
            this.FirstNameCol.Visible = true;
            this.FirstNameCol.VisibleIndex = 1;
            this.FirstNameCol.Width = 81;
            // 
            // LastNameCol
            // 
            this.LastNameCol.Caption = "نام خانوادگی";
            this.LastNameCol.FieldName = "EmpLname";
            this.LastNameCol.Name = "LastNameCol";
            this.LastNameCol.OptionsColumn.AllowEdit = false;
            this.LastNameCol.OptionsColumn.AllowSize = false;
            this.LastNameCol.Visible = true;
            this.LastNameCol.VisibleIndex = 2;
            this.LastNameCol.Width = 106;
            // 
            // PersonalNumCol
            // 
            this.PersonalNumCol.Caption = "شماره کارمندی";
            this.PersonalNumCol.FieldName = "PersonalNum";
            this.PersonalNumCol.Name = "PersonalNumCol";
            this.PersonalNumCol.OptionsColumn.AllowEdit = false;
            this.PersonalNumCol.OptionsColumn.AllowSize = false;
            this.PersonalNumCol.Visible = true;
            this.PersonalNumCol.VisibleIndex = 3;
            this.PersonalNumCol.Width = 95;
            // 
            // FingerCol
            // 
            this.FingerCol.Caption = "اثر انگشت";
            this.FingerCol.ColumnEdit = this.figerLinks;
            this.FingerCol.Name = "FingerCol";
            this.FingerCol.OptionsColumn.AllowSize = false;
            this.FingerCol.Visible = true;
            this.FingerCol.VisibleIndex = 4;
            this.FingerCol.Width = 66;
            // 
            // PicCol
            // 
            this.PicCol.Caption = "عکس";
            this.PicCol.FieldName = "Picture";
            this.PicCol.Name = "PicCol";
            this.PicCol.OptionsColumn.AllowSize = false;
            this.PicCol.Visible = true;
            this.PicCol.VisibleIndex = 5;
            this.PicCol.Width = 59;
            // 
            // DbCol
            // 
            this.DbCol.Caption = "اطلاعات پایه";
            this.DbCol.FieldName = "Db";
            this.DbCol.Name = "DbCol";
            this.DbCol.OptionsColumn.AllowSize = false;
            this.DbCol.Visible = true;
            this.DbCol.VisibleIndex = 6;
            this.DbCol.Width = 68;
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(483, 438);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(75, 23);
            this.btnSend.TabIndex = 2;
            this.btnSend.Text = "درج در دستگاه";
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // GrpBoxAccess
            // 
            this.GrpBoxAccess.Controls.Add(this.gridAccess);
            this.GrpBoxAccess.Location = new System.Drawing.Point(1, 7);
            this.GrpBoxAccess.Name = "GrpBoxAccess";
            this.GrpBoxAccess.Size = new System.Drawing.Size(557, 425);
            this.GrpBoxAccess.TabIndex = 3;
            this.GrpBoxAccess.TabStop = false;
            // 
            // SendProgress
            // 
            this.SendProgress.Location = new System.Drawing.Point(4, 438);
            this.SendProgress.Name = "SendProgress";
            this.SendProgress.Properties.ReadOnly = true;
            this.SendProgress.Size = new System.Drawing.Size(473, 23);
            this.SendProgress.TabIndex = 4;
            // 
            // figerLinks
            // 
            this.figerLinks.AutoHeight = false;
            this.figerLinks.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.figerLinks.Caption = "جزئیات";
            this.figerLinks.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.figerLinks.Name = "figerLinks";
            this.figerLinks.NullText = "جزئیات";
            this.figerLinks.Click += new System.EventHandler(this.figerLinks_Click);
            // 
            // FrmAccess
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(560, 471);
            this.Controls.Add(this.SendProgress);
            this.Controls.Add(this.GrpBoxAccess);
            this.Controls.Add(this.btnSend);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmAccess";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "دسترسی اشخاص";
            this.Load += new System.EventHandler(this.FrmEmpInDevice_Load);
            ((System.ComponentModel.ISupportInitialize)(this.fingerLink)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridAccess)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdAccess)).EndInit();
            this.GrpBoxAccess.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.SendProgress.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.figerLinks)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridAccess;
        private DevExpress.XtraGrid.Views.Grid.GridView grdAccess;
        private DevExpress.XtraGrid.Columns.GridColumn FirstNameCol;
        private DevExpress.XtraGrid.Columns.GridColumn LastNameCol;
        private DevExpress.XtraGrid.Columns.GridColumn FingerCol;
        private DevExpress.XtraGrid.Columns.GridColumn PicCol;
        private DevExpress.XtraGrid.Columns.GridColumn DbCol;
        private DevExpress.XtraEditors.SimpleButton btnSend;
        private System.Windows.Forms.GroupBox GrpBoxAccess;
        private DevExpress.XtraGrid.Columns.GridColumn Id;
        private DevExpress.XtraEditors.ProgressBarControl SendProgress;
        private DevExpress.XtraGrid.Columns.GridColumn PersonalNumCol;
        private DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit fingerLink;
        private DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit figerLinks;
    }
}