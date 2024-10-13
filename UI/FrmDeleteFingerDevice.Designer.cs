namespace UI
{
    partial class FrmDeleteFingerDevice
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
            this.grpDevices = new DevExpress.XtraEditors.GroupControl();
            this.BtnDelete = new DevExpress.XtraEditors.SimpleButton();
            this.grdDevices = new DevExpress.XtraGrid.GridControl();
            this.grdDevice = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.DvcNameCol = new DevExpress.XtraGrid.Columns.GridColumn();
            this.dvcIpCol = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdID = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.grpDevices)).BeginInit();
            this.grpDevices.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdDevices)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdDevice)).BeginInit();
            this.SuspendLayout();
            // 
            // grpDevices
            // 
            this.grpDevices.Controls.Add(this.BtnDelete);
            this.grpDevices.Controls.Add(this.grdDevices);
            this.grpDevices.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpDevices.Location = new System.Drawing.Point(0, 0);
            this.grpDevices.Name = "grpDevices";
            this.grpDevices.Size = new System.Drawing.Size(485, 328);
            this.grpDevices.TabIndex = 0;
            this.grpDevices.Text = "حذف اثر انگشت از دستگاه ها";
            // 
            // BtnDelete
            // 
            this.BtnDelete.Location = new System.Drawing.Point(12, 293);
            this.BtnDelete.Name = "BtnDelete";
            this.BtnDelete.Size = new System.Drawing.Size(75, 23);
            this.BtnDelete.TabIndex = 1;
            this.BtnDelete.Text = "حذف";
            this.BtnDelete.Click += new System.EventHandler(this.BtnDelete_Click);
            // 
            // grdDevices
            // 
            this.grdDevices.Location = new System.Drawing.Point(2, 20);
            this.grdDevices.MainView = this.grdDevice;
            this.grdDevices.Name = "grdDevices";
            this.grdDevices.Size = new System.Drawing.Size(480, 255);
            this.grdDevices.TabIndex = 0;
            this.grdDevices.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grdDevice});
            // 
            // grdDevice
            // 
            this.grdDevice.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.DvcNameCol,
            this.dvcIpCol,
            this.grdID});
            this.grdDevice.GridControl = this.grdDevices;
            this.grdDevice.Name = "grdDevice";
            this.grdDevice.OptionsFind.AlwaysVisible = true;
            this.grdDevice.OptionsFind.FindMode = DevExpress.XtraEditors.FindMode.FindClick;
            this.grdDevice.OptionsSelection.MultiSelect = true;
            this.grdDevice.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect;
            this.grdDevice.OptionsSelection.UseIndicatorForSelection = false;
            // 
            // DvcNameCol
            // 
            this.DvcNameCol.Caption = "نام دستگاه";
            this.DvcNameCol.FieldName = "DeviceName";
            this.DvcNameCol.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.DisplayText;
            this.DvcNameCol.Name = "DvcNameCol";
            this.DvcNameCol.Visible = true;
            this.DvcNameCol.VisibleIndex = 1;
            // 
            // dvcIpCol
            // 
            this.dvcIpCol.Caption = "آدرس شبکه";
            this.dvcIpCol.FieldName = "IP";
            this.dvcIpCol.Name = "dvcIpCol";
            this.dvcIpCol.Visible = true;
            this.dvcIpCol.VisibleIndex = 2;
            // 
            // grdID
            // 
            this.grdID.FieldName = "ID";
            this.grdID.Name = "grdID";
            // 
            // FrmDeleteFingerDevice
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(485, 328);
            this.Controls.Add(this.grpDevices);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmDeleteFingerDevice";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.ShowIcon = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "انتخاب دستگاه";
            this.Load += new System.EventHandler(this.FrmDeleteFingerDevice_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grpDevices)).EndInit();
            this.grpDevices.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdDevices)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdDevice)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl grpDevices;
        private DevExpress.XtraGrid.GridControl grdDevices;
        private DevExpress.XtraGrid.Views.Grid.GridView grdDevice;
        private DevExpress.XtraGrid.Columns.GridColumn DvcNameCol;
        private DevExpress.XtraGrid.Columns.GridColumn dvcIpCol;
        private DevExpress.XtraEditors.SimpleButton BtnDelete;
        private DevExpress.XtraGrid.Columns.GridColumn grdID;

    }
}