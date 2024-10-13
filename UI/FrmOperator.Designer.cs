namespace UI
{
    partial class FrmEditOperator
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmEditOperator));
            this.GrpOperator = new System.Windows.Forms.GroupBox();
            this.GridOperator = new DevExpress.XtraGrid.GridControl();
            this.grdOperator = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.NameCol = new DevExpress.XtraGrid.Columns.GridColumn();
            this.LnameCol = new DevExpress.XtraGrid.Columns.GridColumn();
            this.UserNameCol = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grpEdit = new System.Windows.Forms.GroupBox();
            this.txtRePass = new DevExpress.XtraEditors.TextEdit();
            this.txtPass = new DevExpress.XtraEditors.TextEdit();
            this.txtUserName = new DevExpress.XtraEditors.TextEdit();
            this.txtLName = new DevExpress.XtraEditors.TextEdit();
            this.txtName = new DevExpress.XtraEditors.TextEdit();
            this.lblRePass = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblUsername = new System.Windows.Forms.Label();
            this.lblLName = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.BtnSave = new DevExpress.XtraEditors.SimpleButton();
            this.BtnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.GrpOperator.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GridOperator)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdOperator)).BeginInit();
            this.grpEdit.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtRePass.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPass.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUserName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtName.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // GrpOperator
            // 
            this.GrpOperator.Controls.Add(this.GridOperator);
            this.GrpOperator.Location = new System.Drawing.Point(2, 2);
            this.GrpOperator.Name = "GrpOperator";
            this.GrpOperator.Size = new System.Drawing.Size(381, 278);
            this.GrpOperator.TabIndex = 0;
            this.GrpOperator.TabStop = false;
            this.GrpOperator.Text = "کاربران سیستم";
            // 
            // GridOperator
            // 
            this.GridOperator.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GridOperator.Location = new System.Drawing.Point(3, 18);
            this.GridOperator.MainView = this.grdOperator;
            this.GridOperator.Name = "GridOperator";
            this.GridOperator.Size = new System.Drawing.Size(375, 257);
            this.GridOperator.TabIndex = 0;
            this.GridOperator.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grdOperator});
            // 
            // grdOperator
            // 
            this.grdOperator.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.grdOperator.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grdOperator.Appearance.HeaderPanel.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grdOperator.Appearance.Row.Options.UseTextOptions = true;
            this.grdOperator.Appearance.Row.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grdOperator.Appearance.Row.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grdOperator.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.NameCol,
            this.LnameCol,
            this.UserNameCol});
            this.grdOperator.GridControl = this.GridOperator;
            this.grdOperator.Name = "grdOperator";
            this.grdOperator.OptionsBehavior.Editable = false;
            this.grdOperator.OptionsFind.AlwaysVisible = true;
            this.grdOperator.OptionsFind.FindDelay = 100;
            this.grdOperator.OptionsFind.FindNullPrompt = "مورد جست و جو را در این قسمت بنویسید ...";
            this.grdOperator.OptionsFind.ShowClearButton = false;
            this.grdOperator.OptionsFind.ShowCloseButton = false;
            this.grdOperator.RowClick += new DevExpress.XtraGrid.Views.Grid.RowClickEventHandler(this.grdOperator_RowClick);
            // 
            // NameCol
            // 
            this.NameCol.Caption = "نام";
            this.NameCol.FieldName = "Name";
            this.NameCol.Name = "NameCol";
            this.NameCol.OptionsColumn.AllowSize = false;
            this.NameCol.Visible = true;
            this.NameCol.VisibleIndex = 0;
            // 
            // LnameCol
            // 
            this.LnameCol.Caption = "نام خانوادگی";
            this.LnameCol.FieldName = "Lname";
            this.LnameCol.Name = "LnameCol";
            this.LnameCol.OptionsColumn.AllowSize = false;
            this.LnameCol.Visible = true;
            this.LnameCol.VisibleIndex = 1;
            // 
            // UserNameCol
            // 
            this.UserNameCol.Caption = "نام کاربری";
            this.UserNameCol.FieldName = "UserName";
            this.UserNameCol.Name = "UserNameCol";
            this.UserNameCol.OptionsColumn.AllowSize = false;
            this.UserNameCol.Visible = true;
            this.UserNameCol.VisibleIndex = 2;
            // 
            // grpEdit
            // 
            this.grpEdit.Controls.Add(this.txtRePass);
            this.grpEdit.Controls.Add(this.txtPass);
            this.grpEdit.Controls.Add(this.txtUserName);
            this.grpEdit.Controls.Add(this.txtLName);
            this.grpEdit.Controls.Add(this.txtName);
            this.grpEdit.Controls.Add(this.lblRePass);
            this.grpEdit.Controls.Add(this.label1);
            this.grpEdit.Controls.Add(this.lblUsername);
            this.grpEdit.Controls.Add(this.lblLName);
            this.grpEdit.Controls.Add(this.lblName);
            this.grpEdit.Location = new System.Drawing.Point(389, 2);
            this.grpEdit.Name = "grpEdit";
            this.grpEdit.Size = new System.Drawing.Size(291, 278);
            this.grpEdit.TabIndex = 1;
            this.grpEdit.TabStop = false;
            this.grpEdit.Text = "ویرایش کاربران";
            // 
            // txtRePass
            // 
            this.txtRePass.Location = new System.Drawing.Point(75, 204);
            this.txtRePass.Name = "txtRePass";
            this.txtRePass.Properties.UseSystemPasswordChar = true;
            this.txtRePass.Size = new System.Drawing.Size(100, 20);
            this.txtRePass.TabIndex = 10;
            // 
            // txtPass
            // 
            this.txtPass.Location = new System.Drawing.Point(75, 160);
            this.txtPass.Name = "txtPass";
            this.txtPass.Properties.PasswordChar = '*';
            this.txtPass.Properties.UseSystemPasswordChar = true;
            this.txtPass.Size = new System.Drawing.Size(100, 20);
            this.txtPass.TabIndex = 9;
            // 
            // txtUserName
            // 
            this.txtUserName.Location = new System.Drawing.Point(75, 116);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(100, 20);
            this.txtUserName.TabIndex = 8;
            // 
            // txtLName
            // 
            this.txtLName.Location = new System.Drawing.Point(75, 76);
            this.txtLName.Name = "txtLName";
            this.txtLName.Size = new System.Drawing.Size(100, 20);
            this.txtLName.TabIndex = 7;
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(75, 29);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(100, 20);
            this.txtName.TabIndex = 6;
            // 
            // lblRePass
            // 
            this.lblRePass.AutoSize = true;
            this.lblRePass.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblRePass.Location = new System.Drawing.Point(207, 206);
            this.lblRePass.Name = "lblRePass";
            this.lblRePass.Size = new System.Drawing.Size(75, 14);
            this.lblRePass.TabIndex = 4;
            this.lblRePass.Text = "تکرار رمز عبور:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label1.Location = new System.Drawing.Point(231, 162);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 14);
            this.label1.TabIndex = 3;
            this.label1.Text = "رمز عبور:";
            // 
            // lblUsername
            // 
            this.lblUsername.AutoSize = true;
            this.lblUsername.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblUsername.Location = new System.Drawing.Point(221, 118);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(61, 14);
            this.lblUsername.TabIndex = 2;
            this.lblUsername.Text = "نام کاربری:";
            // 
            // lblLName
            // 
            this.lblLName.AutoSize = true;
            this.lblLName.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblLName.Location = new System.Drawing.Point(207, 78);
            this.lblLName.Name = "lblLName";
            this.lblLName.Size = new System.Drawing.Size(76, 14);
            this.lblLName.TabIndex = 1;
            this.lblLName.Text = "نام خانوادگی:";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblName.Location = new System.Drawing.Point(254, 31);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(25, 14);
            this.lblName.TabIndex = 0;
            this.lblName.Text = "نام:";
            // 
            // BtnSave
            // 
            this.BtnSave.Location = new System.Drawing.Point(595, 300);
            this.BtnSave.Name = "BtnSave";
            this.BtnSave.Size = new System.Drawing.Size(75, 23);
            this.BtnSave.TabIndex = 2;
            this.BtnSave.Text = "ذخیره";
            this.BtnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // BtnCancel
            // 
            this.BtnCancel.AllowDrop = true;
            this.BtnCancel.Location = new System.Drawing.Point(505, 300);
            this.BtnCancel.Name = "BtnCancel";
            this.BtnCancel.Size = new System.Drawing.Size(75, 23);
            this.BtnCancel.TabIndex = 3;
            this.BtnCancel.Text = "لغو";
            this.BtnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // FrmEditOperator
            // 
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(683, 341);
            this.Controls.Add(this.BtnCancel);
            this.Controls.Add(this.BtnSave);
            this.Controls.Add(this.grpEdit);
            this.Controls.Add(this.GrpOperator);
            this.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmEditOperator";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ویرایش کاربر";
            this.Load += new System.EventHandler(this.FrmEditOperator_Load);
            this.GrpOperator.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.GridOperator)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdOperator)).EndInit();
            this.grpEdit.ResumeLayout(false);
            this.grpEdit.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtRePass.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPass.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUserName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtName.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox GrpOperator;
        private System.Windows.Forms.GroupBox grpEdit;
        private DevExpress.XtraEditors.SimpleButton BtnSave;
        private DevExpress.XtraEditors.SimpleButton BtnCancel;
        private DevExpress.XtraEditors.TextEdit txtRePass;
        private DevExpress.XtraEditors.TextEdit txtPass;
        private DevExpress.XtraEditors.TextEdit txtUserName;
        private DevExpress.XtraEditors.TextEdit txtLName;
        private DevExpress.XtraEditors.TextEdit txtName;
        private System.Windows.Forms.Label lblRePass;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.Label lblLName;
        private System.Windows.Forms.Label lblName;
        private DevExpress.XtraGrid.GridControl GridOperator;
        private DevExpress.XtraGrid.Views.Grid.GridView grdOperator;
        private DevExpress.XtraGrid.Columns.GridColumn NameCol;
        private DevExpress.XtraGrid.Columns.GridColumn LnameCol;
        private DevExpress.XtraGrid.Columns.GridColumn UserNameCol;
    }
}