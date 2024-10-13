namespace Eco
{
    partial class FrmAccessArea
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
            this.grpAccessArea = new DevExpress.XtraEditors.GroupControl();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.btnSave = new DevExpress.XtraEditors.SimpleButton();
            this.groupAddAccessArea = new System.Windows.Forms.GroupBox();
            this.cmbSchGroup = new System.Windows.Forms.ComboBox();
            this.grpDeviceList = new System.Windows.Forms.GroupBox();
            this.chkListDevices = new DevExpress.XtraEditors.CheckedListBoxControl();
            this.txtName = new System.Windows.Forms.TextBox();
            this.lblSchGroup = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.groupAccessAreaList = new System.Windows.Forms.GroupBox();
            this.UnCheckAll = new System.Windows.Forms.CheckBox();
            this.chkListAcsArea = new DevExpress.XtraEditors.CheckedListBoxControl();
            ((System.ComponentModel.ISupportInitialize)(this.grpAccessArea)).BeginInit();
            this.grpAccessArea.SuspendLayout();
            this.groupAddAccessArea.SuspendLayout();
            this.grpDeviceList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkListDevices)).BeginInit();
            this.groupAccessAreaList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkListAcsArea)).BeginInit();
            this.SuspendLayout();
            // 
            // grpAccessArea
            // 
            this.grpAccessArea.Controls.Add(this.btnCancel);
            this.grpAccessArea.Controls.Add(this.btnSave);
            this.grpAccessArea.Controls.Add(this.groupAddAccessArea);
            this.grpAccessArea.Controls.Add(this.groupAccessAreaList);
            this.grpAccessArea.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpAccessArea.Location = new System.Drawing.Point(0, 0);
            this.grpAccessArea.Name = "grpAccessArea";
            this.grpAccessArea.Size = new System.Drawing.Size(505, 538);
            this.grpAccessArea.TabIndex = 0;
            this.grpAccessArea.Text = "ناحیه دسترسی";
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(93, 507);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 26);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "لغو";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(12, 506);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 27);
            this.btnSave.TabIndex = 2;
            this.btnSave.Text = "ثبت";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // groupAddAccessArea
            // 
            this.groupAddAccessArea.Controls.Add(this.cmbSchGroup);
            this.groupAddAccessArea.Controls.Add(this.grpDeviceList);
            this.groupAddAccessArea.Controls.Add(this.txtName);
            this.groupAddAccessArea.Controls.Add(this.lblSchGroup);
            this.groupAddAccessArea.Controls.Add(this.lblName);
            this.groupAddAccessArea.Location = new System.Drawing.Point(5, 23);
            this.groupAddAccessArea.Name = "groupAddAccessArea";
            this.groupAddAccessArea.Size = new System.Drawing.Size(265, 477);
            this.groupAddAccessArea.TabIndex = 1;
            this.groupAddAccessArea.TabStop = false;
            // 
            // cmbSchGroup
            // 
            this.cmbSchGroup.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSchGroup.FormattingEnabled = true;
            this.cmbSchGroup.Location = new System.Drawing.Point(3, 66);
            this.cmbSchGroup.Name = "cmbSchGroup";
            this.cmbSchGroup.Size = new System.Drawing.Size(144, 21);
            this.cmbSchGroup.TabIndex = 6;
            // 
            // grpDeviceList
            // 
            this.grpDeviceList.Controls.Add(this.chkListDevices);
            this.grpDeviceList.Location = new System.Drawing.Point(3, 108);
            this.grpDeviceList.Name = "grpDeviceList";
            this.grpDeviceList.Size = new System.Drawing.Size(256, 366);
            this.grpDeviceList.TabIndex = 5;
            this.grpDeviceList.TabStop = false;
            this.grpDeviceList.Text = "لیست دستگاه ها";
            // 
            // chkListDevices
            // 
            this.chkListDevices.CheckOnClick = true;
            this.chkListDevices.DisplayMember = "DeviceName";
            this.chkListDevices.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkListDevices.Location = new System.Drawing.Point(3, 17);
            this.chkListDevices.Name = "chkListDevices";
            this.chkListDevices.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this.chkListDevices.Size = new System.Drawing.Size(250, 346);
            this.chkListDevices.TabIndex = 0;
            this.chkListDevices.ValueMember = "ID";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(3, 23);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(144, 21);
            this.txtName.TabIndex = 4;
            // 
            // lblSchGroup
            // 
            this.lblSchGroup.AutoSize = true;
            this.lblSchGroup.Location = new System.Drawing.Point(186, 69);
            this.lblSchGroup.Name = "lblSchGroup";
            this.lblSchGroup.Size = new System.Drawing.Size(74, 13);
            this.lblSchGroup.TabIndex = 1;
            this.lblSchGroup.Text = "گروه زمانبندی:";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(153, 26);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(100, 13);
            this.lblName.TabIndex = 0;
            this.lblName.Text = "نام ناحیه دسترسی:";
            // 
            // groupAccessAreaList
            // 
            this.groupAccessAreaList.BackColor = System.Drawing.Color.Transparent;
            this.groupAccessAreaList.Controls.Add(this.UnCheckAll);
            this.groupAccessAreaList.Controls.Add(this.chkListAcsArea);
            this.groupAccessAreaList.Location = new System.Drawing.Point(276, 23);
            this.groupAccessAreaList.Name = "groupAccessAreaList";
            this.groupAccessAreaList.Size = new System.Drawing.Size(223, 477);
            this.groupAccessAreaList.TabIndex = 0;
            this.groupAccessAreaList.TabStop = false;
            this.groupAccessAreaList.Text = "نواحی دسترسی";
            // 
            // UnCheckAll
            // 
            this.UnCheckAll.AutoSize = true;
            this.UnCheckAll.Checked = true;
            this.UnCheckAll.CheckState = System.Windows.Forms.CheckState.Checked;
            this.UnCheckAll.Location = new System.Drawing.Point(118, 18);
            this.UnCheckAll.Name = "UnCheckAll";
            this.UnCheckAll.Size = new System.Drawing.Size(102, 17);
            this.UnCheckAll.TabIndex = 2;
            this.UnCheckAll.Text = "عدم انتخاب همه";
            this.UnCheckAll.UseVisualStyleBackColor = true;
            this.UnCheckAll.CheckedChanged += new System.EventHandler(this.UnCheckAll_CheckedChanged);
            // 
            // chkListAcsArea
            // 
            this.chkListAcsArea.CheckOnClick = true;
            this.chkListAcsArea.DisplayMember = "Name";
            this.chkListAcsArea.Location = new System.Drawing.Point(3, 41);
            this.chkListAcsArea.Name = "chkListAcsArea";
            this.chkListAcsArea.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this.chkListAcsArea.Size = new System.Drawing.Size(217, 433);
            this.chkListAcsArea.TabIndex = 0;
            this.chkListAcsArea.ValueMember = "ID";
            this.chkListAcsArea.ItemCheck += new DevExpress.XtraEditors.Controls.ItemCheckEventHandler(this.chkListAcsArea_ItemCheck);
            this.chkListAcsArea.MouseClick += new System.Windows.Forms.MouseEventHandler(this.chkListAcsArea_MouseClick);
            // 
            // FrmAccessArea
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(505, 538);
            this.Controls.Add(this.grpAccessArea);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmAccessArea";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmAccessArea";
            this.Load += new System.EventHandler(this.FrmAccessArea_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grpAccessArea)).EndInit();
            this.grpAccessArea.ResumeLayout(false);
            this.groupAddAccessArea.ResumeLayout(false);
            this.groupAddAccessArea.PerformLayout();
            this.grpDeviceList.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chkListDevices)).EndInit();
            this.groupAccessAreaList.ResumeLayout(false);
            this.groupAccessAreaList.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkListAcsArea)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl grpAccessArea;
        private System.Windows.Forms.GroupBox groupAddAccessArea;
        private System.Windows.Forms.GroupBox groupAccessAreaList;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private DevExpress.XtraEditors.SimpleButton btnSave;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblSchGroup;
        private System.Windows.Forms.GroupBox grpDeviceList;
        private DevExpress.XtraEditors.CheckedListBoxControl chkListDevices;
        private System.Windows.Forms.TextBox txtName;
        private DevExpress.XtraEditors.CheckedListBoxControl chkListAcsArea;
        private System.Windows.Forms.ComboBox cmbSchGroup;
        private System.Windows.Forms.CheckBox UnCheckAll;
    }
}