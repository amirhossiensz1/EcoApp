namespace Eco
{
    partial class FrmHolidaygroup
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
            this.Holidaysgroup = new DevExpress.XtraEditors.GroupControl();
            this.BtnAddHolidayGroupList = new DevExpress.XtraEditors.SimpleButton();
            this.HolidayGrpListGrp = new System.Windows.Forms.GroupBox();
            this.UncheckAll = new System.Windows.Forms.CheckBox();
            this.HolidaysGroupList = new DevExpress.XtraEditors.CheckedListBoxControl();
            this.HolidaysList = new System.Windows.Forms.GroupBox();
            this.CheckedAll = new System.Windows.Forms.CheckBox();
            this.HoliDayList = new DevExpress.XtraEditors.CheckedListBoxControl();
            this.btnAddHoliDayList = new DevExpress.XtraEditors.SimpleButton();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.btnSave = new DevExpress.XtraEditors.SimpleButton();
            this.HoliDaysLbl = new System.Windows.Forms.Label();
            this.HolidaysPicker = new Telerik.WinControls.UI.RadDateTimePicker();
            this.txtGroupName = new System.Windows.Forms.TextBox();
            this.lblHoliDayGroup = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.Holidaysgroup)).BeginInit();
            this.Holidaysgroup.SuspendLayout();
            this.HolidayGrpListGrp.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.HolidaysGroupList)).BeginInit();
            this.HolidaysList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.HoliDayList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.HolidaysPicker)).BeginInit();
            this.SuspendLayout();
            // 
            // Holidaysgroup
            // 
            this.Holidaysgroup.Controls.Add(this.BtnAddHolidayGroupList);
            this.Holidaysgroup.Controls.Add(this.HolidayGrpListGrp);
            this.Holidaysgroup.Controls.Add(this.HolidaysList);
            this.Holidaysgroup.Controls.Add(this.btnAddHoliDayList);
            this.Holidaysgroup.Controls.Add(this.btnCancel);
            this.Holidaysgroup.Controls.Add(this.btnSave);
            this.Holidaysgroup.Controls.Add(this.HoliDaysLbl);
            this.Holidaysgroup.Controls.Add(this.HolidaysPicker);
            this.Holidaysgroup.Controls.Add(this.txtGroupName);
            this.Holidaysgroup.Controls.Add(this.lblHoliDayGroup);
            this.Holidaysgroup.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Holidaysgroup.Location = new System.Drawing.Point(0, 0);
            this.Holidaysgroup.Name = "Holidaysgroup";
            this.Holidaysgroup.Size = new System.Drawing.Size(591, 452);
            this.Holidaysgroup.TabIndex = 0;
            this.Holidaysgroup.Text = "گروه تعطیلات";
            // 
            // BtnAddHolidayGroupList
            // 
            this.BtnAddHolidayGroupList.Location = new System.Drawing.Point(12, 37);
            this.BtnAddHolidayGroupList.Name = "BtnAddHolidayGroupList";
            this.BtnAddHolidayGroupList.Size = new System.Drawing.Size(52, 20);
            this.BtnAddHolidayGroupList.TabIndex = 11;
            this.BtnAddHolidayGroupList.Text = "افزودن";
            this.BtnAddHolidayGroupList.Click += new System.EventHandler(this.AddHolidayGroupList_Click);
            // 
            // HolidayGrpListGrp
            // 
            this.HolidayGrpListGrp.Controls.Add(this.UncheckAll);
            this.HolidayGrpListGrp.Controls.Add(this.HolidaysGroupList);
            this.HolidayGrpListGrp.Location = new System.Drawing.Point(5, 65);
            this.HolidayGrpListGrp.Name = "HolidayGrpListGrp";
            this.HolidayGrpListGrp.Size = new System.Drawing.Size(266, 332);
            this.HolidayGrpListGrp.TabIndex = 10;
            this.HolidayGrpListGrp.TabStop = false;
            this.HolidayGrpListGrp.Text = "لیست گروه تعطیلات";
            // 
            // UncheckAll
            // 
            this.UncheckAll.AutoSize = true;
            this.UncheckAll.Location = new System.Drawing.Point(158, 17);
            this.UncheckAll.Name = "UncheckAll";
            this.UncheckAll.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.UncheckAll.Size = new System.Drawing.Size(102, 17);
            this.UncheckAll.TabIndex = 6;
            this.UncheckAll.Text = "عدم انتخاب همه";
            this.UncheckAll.ThreeState = true;
            this.UncheckAll.UseVisualStyleBackColor = true;
            this.UncheckAll.CheckedChanged += new System.EventHandler(this.UncheckAll_CheckedChanged);
            // 
            // HolidaysGroupList
            // 
            this.HolidaysGroupList.CheckOnClick = true;
            this.HolidaysGroupList.DisplayMember = "Name";
            this.HolidaysGroupList.HotTrackSelectMode = DevExpress.XtraEditors.HotTrackSelectMode.SelectItemOnClick;
            this.HolidaysGroupList.Location = new System.Drawing.Point(3, 36);
            this.HolidaysGroupList.MultiColumn = true;
            this.HolidaysGroupList.Name = "HolidaysGroupList";
            this.HolidaysGroupList.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this.HolidaysGroupList.Size = new System.Drawing.Size(260, 293);
            this.HolidaysGroupList.TabIndex = 5;
            this.HolidaysGroupList.ValueMember = "ID";
            this.HolidaysGroupList.ItemCheck += new DevExpress.XtraEditors.Controls.ItemCheckEventHandler(this.HolidaysGroupList_ItemCheck);
            this.HolidaysGroupList.MouseClick += new System.Windows.Forms.MouseEventHandler(this.HolidaysGroupList_MouseClick);
            // 
            // HolidaysList
            // 
            this.HolidaysList.Controls.Add(this.CheckedAll);
            this.HolidaysList.Controls.Add(this.HoliDayList);
            this.HolidaysList.Location = new System.Drawing.Point(274, 65);
            this.HolidaysList.Name = "HolidaysList";
            this.HolidaysList.Size = new System.Drawing.Size(313, 332);
            this.HolidaysList.TabIndex = 9;
            this.HolidaysList.TabStop = false;
            this.HolidaysList.Text = "لیست تعطیلات";
            // 
            // CheckedAll
            // 
            this.CheckedAll.AutoSize = true;
            this.CheckedAll.Location = new System.Drawing.Point(229, 17);
            this.CheckedAll.Name = "CheckedAll";
            this.CheckedAll.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.CheckedAll.Size = new System.Drawing.Size(79, 17);
            this.CheckedAll.TabIndex = 4;
            this.CheckedAll.Text = "انتخاب همه";
            this.CheckedAll.ThreeState = true;
            this.CheckedAll.UseVisualStyleBackColor = true;
            this.CheckedAll.CheckedChanged += new System.EventHandler(this.CheckedAll_CheckedChanged);
            // 
            // HoliDayList
            // 
            this.HoliDayList.CheckOnClick = true;
            this.HoliDayList.DisplayMember = "Date";
            this.HoliDayList.Location = new System.Drawing.Point(3, 36);
            this.HoliDayList.MultiColumn = true;
            this.HoliDayList.Name = "HoliDayList";
            this.HoliDayList.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this.HoliDayList.ShowFocusRect = false;
            this.HoliDayList.Size = new System.Drawing.Size(307, 290);
            this.HoliDayList.TabIndex = 3;
            this.HoliDayList.ValueMember = "ID";
            this.HoliDayList.ItemCheck += new DevExpress.XtraEditors.Controls.ItemCheckEventHandler(this.HoliDayList_ItemCheck);
            this.HoliDayList.MouseClick += new System.Windows.Forms.MouseEventHandler(this.HoliDayList_MouseClick);
            // 
            // btnAddHoliDayList
            // 
            this.btnAddHoliDayList.Location = new System.Drawing.Point(277, 37);
            this.btnAddHoliDayList.Name = "btnAddHoliDayList";
            this.btnAddHoliDayList.Size = new System.Drawing.Size(52, 20);
            this.btnAddHoliDayList.TabIndex = 8;
            this.btnAddHoliDayList.Text = "افزودن ";
            this.btnAddHoliDayList.Click += new System.EventHandler(this.btnAddList_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(93, 412);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 7;
            this.btnCancel.Text = "لغو";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(12, 412);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 6;
            this.btnSave.Text = "تخصیص";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // HoliDaysLbl
            // 
            this.HoliDaysLbl.AutoSize = true;
            this.HoliDaysLbl.Location = new System.Drawing.Point(513, 41);
            this.HoliDaysLbl.Name = "HoliDaysLbl";
            this.HoliDaysLbl.Size = new System.Drawing.Size(64, 13);
            this.HoliDaysLbl.TabIndex = 5;
            this.HoliDaysLbl.Text = "تاریخ تعطیل:";
            // 
            // HolidaysPicker
            // 
            this.HolidaysPicker.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.HolidaysPicker.Location = new System.Drawing.Point(365, 38);
            this.HolidaysPicker.MinDate = new System.DateTime(622, 3, 22, 0, 0, 0, 0);
            this.HolidaysPicker.Name = "HolidaysPicker";
            this.HolidaysPicker.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.HolidaysPicker.Size = new System.Drawing.Size(142, 20);
            this.HolidaysPicker.TabIndex = 4;
            this.HolidaysPicker.TabStop = false;
            this.HolidaysPicker.Text = "Monday, July 20, 2020";
            this.HolidaysPicker.Value = new System.DateTime(2020, 7, 20, 17, 36, 13, 998);
            ((Telerik.WinControls.UI.RadDateTimePickerElement)(this.HolidaysPicker.GetChildAt(0))).CanFocus = false;
            ((Telerik.WinControls.UI.RadDateTimePickerElement)(this.HolidaysPicker.GetChildAt(0))).RightToLeft = true;
            // 
            // txtGroupName
            // 
            this.txtGroupName.Location = new System.Drawing.Point(96, 38);
            this.txtGroupName.Name = "txtGroupName";
            this.txtGroupName.Size = new System.Drawing.Size(119, 21);
            this.txtGroupName.TabIndex = 1;
            // 
            // lblHoliDayGroup
            // 
            this.lblHoliDayGroup.AutoSize = true;
            this.lblHoliDayGroup.Location = new System.Drawing.Point(221, 41);
            this.lblHoliDayGroup.Name = "lblHoliDayGroup";
            this.lblHoliDayGroup.Size = new System.Drawing.Size(50, 13);
            this.lblHoliDayGroup.TabIndex = 0;
            this.lblHoliDayGroup.Text = "نام گروه :";
            // 
            // FrmHolidaygroup
            // 
            this.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.AllowDrop = true;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(591, 452);
            this.Controls.Add(this.Holidaysgroup);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmHolidaygroup";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "گروه تعطیلات";
            this.Load += new System.EventHandler(this.FrmHolidaygroup_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Holidaysgroup)).EndInit();
            this.Holidaysgroup.ResumeLayout(false);
            this.Holidaysgroup.PerformLayout();
            this.HolidayGrpListGrp.ResumeLayout(false);
            this.HolidayGrpListGrp.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.HolidaysGroupList)).EndInit();
            this.HolidaysList.ResumeLayout(false);
            this.HolidaysList.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.HoliDayList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.HolidaysPicker)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl Holidaysgroup;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private DevExpress.XtraEditors.SimpleButton btnSave;
        private System.Windows.Forms.Label HoliDaysLbl;
        private Telerik.WinControls.UI.RadDateTimePicker HolidaysPicker;
        private DevExpress.XtraEditors.CheckedListBoxControl HoliDayList;
        private System.Windows.Forms.TextBox txtGroupName;
        private System.Windows.Forms.Label lblHoliDayGroup;
        private DevExpress.XtraEditors.SimpleButton btnAddHoliDayList;
        private DevExpress.XtraEditors.SimpleButton BtnAddHolidayGroupList;
        private System.Windows.Forms.GroupBox HolidayGrpListGrp;
        private System.Windows.Forms.GroupBox HolidaysList;
        private DevExpress.XtraEditors.CheckedListBoxControl HolidaysGroupList;
        private System.Windows.Forms.CheckBox CheckedAll;
        private System.Windows.Forms.CheckBox UncheckAll;
    }
}