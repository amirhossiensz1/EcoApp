namespace Eco
{
    partial class FrmAccessGroup
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
            this.GrpAccessGroup = new DevExpress.XtraEditors.GroupControl();
            this.lblVerify = new System.Windows.Forms.Label();
            this.VerfiCombo = new System.Windows.Forms.ComboBox();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.btnSave = new DevExpress.XtraEditors.SimpleButton();
            this.grpAddAcsGroup = new System.Windows.Forms.GroupBox();
            this.grpAcsAreaList = new System.Windows.Forms.GroupBox();
            this.chkListAcsArea = new DevExpress.XtraEditors.CheckedListBoxControl();
            this.txtAcsGroupName = new System.Windows.Forms.TextBox();
            this.lblAcsGroupName = new System.Windows.Forms.Label();
            this.grpAcsGroupList = new System.Windows.Forms.GroupBox();
            this.UnCheckAll = new System.Windows.Forms.CheckBox();
            this.chkListAcsGroup = new DevExpress.XtraEditors.CheckedListBoxControl();
            ((System.ComponentModel.ISupportInitialize)(this.GrpAccessGroup)).BeginInit();
            this.GrpAccessGroup.SuspendLayout();
            this.grpAddAcsGroup.SuspendLayout();
            this.grpAcsAreaList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkListAcsArea)).BeginInit();
            this.grpAcsGroupList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkListAcsGroup)).BeginInit();
            this.SuspendLayout();
            // 
            // GrpAccessGroup
            // 
            this.GrpAccessGroup.Controls.Add(this.lblVerify);
            this.GrpAccessGroup.Controls.Add(this.VerfiCombo);
            this.GrpAccessGroup.Controls.Add(this.btnCancel);
            this.GrpAccessGroup.Controls.Add(this.btnSave);
            this.GrpAccessGroup.Controls.Add(this.grpAddAcsGroup);
            this.GrpAccessGroup.Controls.Add(this.grpAcsGroupList);
            this.GrpAccessGroup.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GrpAccessGroup.Location = new System.Drawing.Point(0, 0);
            this.GrpAccessGroup.Name = "GrpAccessGroup";
            this.GrpAccessGroup.Size = new System.Drawing.Size(513, 513);
            this.GrpAccessGroup.TabIndex = 0;
            this.GrpAccessGroup.Text = "گروه دسترسی";
            // 
            // lblVerify
            // 
            this.lblVerify.AutoSize = true;
            this.lblVerify.Font = new System.Drawing.Font("Tahoma", 9F);
            this.lblVerify.Location = new System.Drawing.Point(412, 476);
            this.lblVerify.Name = "lblVerify";
            this.lblVerify.Size = new System.Drawing.Size(92, 14);
            this.lblVerify.TabIndex = 5;
            this.lblVerify.Text = "حالت شناسایی:";
            // 
            // VerfiCombo
            // 
            this.VerfiCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.VerfiCombo.FormattingEnabled = true;
            this.VerfiCombo.Location = new System.Drawing.Point(190, 473);
            this.VerfiCombo.Name = "VerfiCombo";
            this.VerfiCombo.Size = new System.Drawing.Size(213, 21);
            this.VerfiCombo.TabIndex = 4;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(93, 470);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 25);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "لغو";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(12, 469);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 25);
            this.btnSave.TabIndex = 2;
            this.btnSave.Text = "ثبت";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // grpAddAcsGroup
            // 
            this.grpAddAcsGroup.Controls.Add(this.grpAcsAreaList);
            this.grpAddAcsGroup.Controls.Add(this.txtAcsGroupName);
            this.grpAddAcsGroup.Controls.Add(this.lblAcsGroupName);
            this.grpAddAcsGroup.Location = new System.Drawing.Point(5, 24);
            this.grpAddAcsGroup.Name = "grpAddAcsGroup";
            this.grpAddAcsGroup.Size = new System.Drawing.Size(267, 433);
            this.grpAddAcsGroup.TabIndex = 1;
            this.grpAddAcsGroup.TabStop = false;
            // 
            // grpAcsAreaList
            // 
            this.grpAcsAreaList.Controls.Add(this.chkListAcsArea);
            this.grpAcsAreaList.Location = new System.Drawing.Point(0, 55);
            this.grpAcsAreaList.Name = "grpAcsAreaList";
            this.grpAcsAreaList.Size = new System.Drawing.Size(261, 480);
            this.grpAcsAreaList.TabIndex = 2;
            this.grpAcsAreaList.TabStop = false;
            this.grpAcsAreaList.Text = "مناطق دسترسی";
            // 
            // chkListAcsArea
            // 
            this.chkListAcsArea.CheckOnClick = true;
            this.chkListAcsArea.DisplayMember = "Name";
            this.chkListAcsArea.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkListAcsArea.Location = new System.Drawing.Point(3, 17);
            this.chkListAcsArea.Name = "chkListAcsArea";
            this.chkListAcsArea.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this.chkListAcsArea.Size = new System.Drawing.Size(255, 460);
            this.chkListAcsArea.TabIndex = 1;
            this.chkListAcsArea.ValueMember = "ID";
            // 
            // txtAcsGroupName
            // 
            this.txtAcsGroupName.Location = new System.Drawing.Point(7, 17);
            this.txtAcsGroupName.Name = "txtAcsGroupName";
            this.txtAcsGroupName.Size = new System.Drawing.Size(152, 21);
            this.txtAcsGroupName.TabIndex = 1;
            // 
            // lblAcsGroupName
            // 
            this.lblAcsGroupName.AutoSize = true;
            this.lblAcsGroupName.Location = new System.Drawing.Point(169, 20);
            this.lblAcsGroupName.Name = "lblAcsGroupName";
            this.lblAcsGroupName.Size = new System.Drawing.Size(97, 13);
            this.lblAcsGroupName.TabIndex = 0;
            this.lblAcsGroupName.Text = "نام گروه دسترسی:";
            // 
            // grpAcsGroupList
            // 
            this.grpAcsGroupList.Controls.Add(this.UnCheckAll);
            this.grpAcsGroupList.Controls.Add(this.chkListAcsGroup);
            this.grpAcsGroupList.Location = new System.Drawing.Point(278, 24);
            this.grpAcsGroupList.Name = "grpAcsGroupList";
            this.grpAcsGroupList.Size = new System.Drawing.Size(230, 433);
            this.grpAcsGroupList.TabIndex = 0;
            this.grpAcsGroupList.TabStop = false;
            this.grpAcsGroupList.Text = "لیست گروه دسترسی";
            // 
            // UnCheckAll
            // 
            this.UnCheckAll.AutoSize = true;
            this.UnCheckAll.Checked = true;
            this.UnCheckAll.CheckState = System.Windows.Forms.CheckState.Checked;
            this.UnCheckAll.Location = new System.Drawing.Point(121, 19);
            this.UnCheckAll.Name = "UnCheckAll";
            this.UnCheckAll.Size = new System.Drawing.Size(102, 17);
            this.UnCheckAll.TabIndex = 3;
            this.UnCheckAll.Text = "عدم انتخاب همه";
            this.UnCheckAll.UseVisualStyleBackColor = true;
            this.UnCheckAll.CheckedChanged += new System.EventHandler(this.UnCheckAll_CheckedChanged);
            // 
            // chkListAcsGroup
            // 
            this.chkListAcsGroup.CheckOnClick = true;
            this.chkListAcsGroup.DisplayMember = "NameID";
            this.chkListAcsGroup.HorizontalScrollbar = true;
            this.chkListAcsGroup.Location = new System.Drawing.Point(6, 44);
            this.chkListAcsGroup.MultiColumn = true;
            this.chkListAcsGroup.Name = "chkListAcsGroup";
            this.chkListAcsGroup.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this.chkListAcsGroup.Size = new System.Drawing.Size(217, 389);
            this.chkListAcsGroup.TabIndex = 0;
            this.chkListAcsGroup.ValueMember = "ID";
            this.chkListAcsGroup.ItemCheck += new DevExpress.XtraEditors.Controls.ItemCheckEventHandler(this.chkListAcsGroup_ItemCheck);
            this.chkListAcsGroup.MouseClick += new System.Windows.Forms.MouseEventHandler(this.chkListAcsGroup_MouseClick);
            // 
            // FrmAccessGroup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(513, 513);
            this.Controls.Add(this.GrpAccessGroup);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmAccessGroup";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmAccessGroup";
            this.Load += new System.EventHandler(this.FrmAccessGroup_Load);
            ((System.ComponentModel.ISupportInitialize)(this.GrpAccessGroup)).EndInit();
            this.GrpAccessGroup.ResumeLayout(false);
            this.GrpAccessGroup.PerformLayout();
            this.grpAddAcsGroup.ResumeLayout(false);
            this.grpAddAcsGroup.PerformLayout();
            this.grpAcsAreaList.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chkListAcsArea)).EndInit();
            this.grpAcsGroupList.ResumeLayout(false);
            this.grpAcsGroupList.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkListAcsGroup)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl GrpAccessGroup;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private DevExpress.XtraEditors.SimpleButton btnSave;
        private System.Windows.Forms.GroupBox grpAddAcsGroup;
        private System.Windows.Forms.GroupBox grpAcsAreaList;
        private DevExpress.XtraEditors.CheckedListBoxControl chkListAcsArea;
        private System.Windows.Forms.TextBox txtAcsGroupName;
        private System.Windows.Forms.Label lblAcsGroupName;
        private System.Windows.Forms.GroupBox grpAcsGroupList;
        private DevExpress.XtraEditors.CheckedListBoxControl chkListAcsGroup;
        private System.Windows.Forms.CheckBox UnCheckAll;
        private System.Windows.Forms.Label lblVerify;
        private System.Windows.Forms.ComboBox VerfiCombo;
    }
}