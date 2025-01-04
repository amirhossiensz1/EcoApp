namespace UI
{
    partial class FrmAddEmployee
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmAddEmployee));
            this.gridDeviceInfo = new DevExpress.XtraGrid.GridControl();
            this.GrdInfoInDevices = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.ColID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ColNameDevices = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ColIp = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ColFinger = new DevExpress.XtraGrid.Columns.GridColumn();
            this.FigerLink = new DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit();
            this.ColPic = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ColDB = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ColDeviceID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.chkEditDB = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.btnFingers = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.xtraTab = new DevExpress.XtraTab.XtraTabControl();
            this.TabBasicInfo = new DevExpress.XtraTab.XtraTabPage();
            this.GrpAddEmp = new DevExpress.XtraEditors.GroupControl();
            this.btnSetPrivateAccessGroup = new DevExpress.XtraEditors.SimpleButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rdbAdmin = new System.Windows.Forms.RadioButton();
            this.rdbUser = new System.Windows.Forms.RadioButton();
            this.grpAuthTypeForZk = new System.Windows.Forms.GroupBox();
            this.chkAuth = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.VerfiCombo = new System.Windows.Forms.ComboBox();
            this.DeviceType = new System.Windows.Forms.GroupBox();
            this.rdbtnRaya = new System.Windows.Forms.RadioButton();
            this.rdbtnZk = new System.Windows.Forms.RadioButton();
            this.rdbtnEco = new System.Windows.Forms.RadioButton();
            this.grpMenuAccess = new System.Windows.Forms.GroupBox();
            this.chkDeviceMenu = new System.Windows.Forms.CheckBox();
            this.chkOperatorMenu = new System.Windows.Forms.CheckBox();
            this.chkNetworkMenu = new System.Windows.Forms.CheckBox();
            this.lblDeviceMenu = new System.Windows.Forms.Label();
            this.lblOperatorMenu = new System.Windows.Forms.Label();
            this.LblNetworkMenu = new System.Windows.Forms.Label();
            this.GrpOrganization = new System.Windows.Forms.GroupBox();
            this.TreeOrganization = new Telerik.WinControls.UI.RadTreeView();
            this.GrpPvInfo = new System.Windows.Forms.GroupBox();
            this.chkPrivateAccess = new System.Windows.Forms.CheckBox();
            this.cmbAcsGroup = new System.Windows.Forms.ComboBox();
            this.txtFName = new System.Windows.Forms.TextBox();
            this.lblFName = new System.Windows.Forms.Label();
            this.lblLname = new System.Windows.Forms.Label();
            this.txtRePin = new System.Windows.Forms.TextBox();
            this.lblPin = new System.Windows.Forms.Label();
            this.lblRePin = new System.Windows.Forms.Label();
            this.lblNational = new System.Windows.Forms.Label();
            this.lblEmpIdErr = new System.Windows.Forms.Label();
            this.lblEmpID = new System.Windows.Forms.Label();
            this.lblTel = new System.Windows.Forms.Label();
            this.lblNationalErr = new System.Windows.Forms.Label();
            this.lblPost = new System.Windows.Forms.Label();
            this.txtLName = new System.Windows.Forms.TextBox();
            this.txtNational = new System.Windows.Forms.TextBox();
            this.txtPost = new System.Windows.Forms.TextBox();
            this.txtPin = new System.Windows.Forms.TextBox();
            this.txtTel = new System.Windows.Forms.TextBox();
            this.txtEmpId = new System.Windows.Forms.TextBox();
            this.BtnBrows = new DevExpress.XtraEditors.SimpleButton();
            this.pictureEmployee = new System.Windows.Forms.PictureBox();
            this.grpAuthType = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lbland2 = new System.Windows.Forms.Label();
            this.lblAnd1 = new System.Windows.Forms.Label();
            this.lblAnd = new System.Windows.Forms.Label();
            this.lblIDtype = new System.Windows.Forms.Label();
            this.lblCard = new System.Windows.Forms.Label();
            this.lblPintype = new System.Windows.Forms.Label();
            this.lblFingerType = new System.Windows.Forms.Label();
            this.lbl3 = new System.Windows.Forms.Label();
            this.lbl2 = new System.Windows.Forms.Label();
            this.lbl1 = new System.Windows.Forms.Label();
            this.TabFinger = new DevExpress.XtraTab.XtraTabPage();
            this.GrpctrlEncoder = new DevExpress.XtraEditors.GroupControl();
            this.GrpPalm = new System.Windows.Forms.GroupBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.btnGetPalm = new DevExpress.XtraEditors.SimpleButton();
            this.grpFace = new System.Windows.Forms.GroupBox();
            this.BtnSendFace = new DevExpress.XtraEditors.SimpleButton();
            this.btnGetFace = new DevExpress.XtraEditors.SimpleButton();
            this.PicBox = new System.Windows.Forms.PictureBox();
            this.grpEncoder = new System.Windows.Forms.GroupBox();
            this.cmbbxSelectEncoder = new System.Windows.Forms.ComboBox();
            this.lbl = new System.Windows.Forms.Label();
            this.GrpFinger = new System.Windows.Forms.GroupBox();
            this.waiting = new System.Windows.Forms.PictureBox();
            this.LeftHand = new System.Windows.Forms.PictureBox();
            this.RightHand = new System.Windows.Forms.PictureBox();
            this.grpEcoder = new System.Windows.Forms.GroupBox();
            this.btnConnect = new DevExpress.XtraEditors.SimpleButton();
            this.btnEncode = new DevExpress.XtraEditors.SimpleButton();
            this.btnDeleteCard = new DevExpress.XtraEditors.SimpleButton();
            this.picExistCard = new System.Windows.Forms.PictureBox();
            this.TabInfoDevices = new DevExpress.XtraTab.XtraTabPage();
            this.GrpctrInfoDevices = new DevExpress.XtraEditors.GroupControl();
            this.progressPanel = new DevExpress.XtraWaitForm.ProgressPanel();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.btnCancelEmp = new DevExpress.XtraEditors.SimpleButton();
            this.btnApply = new DevExpress.XtraEditors.SimpleButton();
            this.btnSaveEmp = new DevExpress.XtraEditors.SimpleButton();
            this.btnEdit = new DevExpress.XtraEditors.SimpleButton();
            this.BtnSend = new DevExpress.XtraEditors.SimpleButton();
            this.radThemeManager1 = new Telerik.WinControls.RadThemeManager();
            ((System.ComponentModel.ISupportInitialize)(this.gridDeviceInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrdInfoInDevices)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FigerLink)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkEditDB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnFingers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTab)).BeginInit();
            this.xtraTab.SuspendLayout();
            this.TabBasicInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GrpAddEmp)).BeginInit();
            this.GrpAddEmp.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.grpAuthTypeForZk.SuspendLayout();
            this.DeviceType.SuspendLayout();
            this.grpMenuAccess.SuspendLayout();
            this.GrpOrganization.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TreeOrganization)).BeginInit();
            this.GrpPvInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEmployee)).BeginInit();
            this.grpAuthType.SuspendLayout();
            this.TabFinger.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GrpctrlEncoder)).BeginInit();
            this.GrpctrlEncoder.SuspendLayout();
            this.GrpPalm.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.grpFace.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PicBox)).BeginInit();
            this.grpEncoder.SuspendLayout();
            this.GrpFinger.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.waiting)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LeftHand)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RightHand)).BeginInit();
            this.grpEcoder.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picExistCard)).BeginInit();
            this.TabInfoDevices.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GrpctrInfoDevices)).BeginInit();
            this.GrpctrInfoDevices.SuspendLayout();
            this.SuspendLayout();
            // 
            // gridDeviceInfo
            // 
            this.gridDeviceInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridDeviceInfo.Location = new System.Drawing.Point(2, 23);
            this.gridDeviceInfo.MainView = this.GrdInfoInDevices;
            this.gridDeviceInfo.Name = "gridDeviceInfo";
            this.gridDeviceInfo.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.chkEditDB,
            this.btnFingers,
            this.FigerLink});
            this.gridDeviceInfo.Size = new System.Drawing.Size(761, 613);
            this.gridDeviceInfo.TabIndex = 0;
            this.gridDeviceInfo.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.GrdInfoInDevices});
            // 
            // GrdInfoInDevices
            // 
            this.GrdInfoInDevices.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.ColID,
            this.ColNameDevices,
            this.ColIp,
            this.ColFinger,
            this.ColPic,
            this.ColDB,
            this.ColDeviceID});
            this.GrdInfoInDevices.GridControl = this.gridDeviceInfo;
            this.GrdInfoInDevices.Name = "GrdInfoInDevices";
            this.GrdInfoInDevices.OptionsView.ColumnAutoWidth = false;
            // 
            // ColID
            // 
            this.ColID.Caption = "Id";
            this.ColID.FieldName = "ID";
            this.ColID.Name = "ColID";
            // 
            // ColNameDevices
            // 
            this.ColNameDevices.Caption = "نام دستگاه";
            this.ColNameDevices.FieldName = "DeviceName";
            this.ColNameDevices.Name = "ColNameDevices";
            this.ColNameDevices.OptionsColumn.AllowEdit = false;
            this.ColNameDevices.OptionsColumn.AllowSize = false;
            this.ColNameDevices.OptionsColumn.ImmediateUpdateRowPosition = DevExpress.Utils.DefaultBoolean.False;
            this.ColNameDevices.OptionsColumn.ShowInExpressionEditor = false;
            this.ColNameDevices.Visible = true;
            this.ColNameDevices.VisibleIndex = 0;
            this.ColNameDevices.Width = 312;
            // 
            // ColIp
            // 
            this.ColIp.Caption = "آدرس شبکه";
            this.ColIp.FieldName = "DeviceIp";
            this.ColIp.Name = "ColIp";
            this.ColIp.OptionsColumn.AllowEdit = false;
            this.ColIp.OptionsColumn.AllowSize = false;
            this.ColIp.OptionsColumn.ShowInExpressionEditor = false;
            this.ColIp.Visible = true;
            this.ColIp.VisibleIndex = 1;
            this.ColIp.Width = 218;
            // 
            // ColFinger
            // 
            this.ColFinger.Caption = "اثر انگشت";
            this.ColFinger.ColumnEdit = this.FigerLink;
            this.ColFinger.FieldName = "Finger";
            this.ColFinger.Name = "ColFinger";
            this.ColFinger.OptionsColumn.AllowSize = false;
            this.ColFinger.Visible = true;
            this.ColFinger.VisibleIndex = 2;
            this.ColFinger.Width = 78;
            // 
            // FigerLink
            // 
            this.FigerLink.AutoHeight = false;
            this.FigerLink.Caption = "جزئیات";
            this.FigerLink.Name = "FigerLink";
            this.FigerLink.NullText = "جزئیات";
            this.FigerLink.Click += new System.EventHandler(this.FigerLink_Click);
            // 
            // ColPic
            // 
            this.ColPic.Caption = "عکس";
            this.ColPic.FieldName = "Picture";
            this.ColPic.Name = "ColPic";
            this.ColPic.OptionsColumn.AllowSize = false;
            this.ColPic.Visible = true;
            this.ColPic.VisibleIndex = 3;
            this.ColPic.Width = 57;
            // 
            // ColDB
            // 
            this.ColDB.Caption = "اطلاعات پایه";
            this.ColDB.FieldName = "Db";
            this.ColDB.Name = "ColDB";
            this.ColDB.OptionsColumn.AllowSize = false;
            this.ColDB.Visible = true;
            this.ColDB.VisibleIndex = 4;
            this.ColDB.Width = 80;
            // 
            // ColDeviceID
            // 
            this.ColDeviceID.Caption = "DeviceID";
            this.ColDeviceID.FieldName = "DeviceID";
            this.ColDeviceID.Name = "ColDeviceID";
            // 
            // chkEditDB
            // 
            this.chkEditDB.AutoHeight = false;
            this.chkEditDB.Name = "chkEditDB";
            // 
            // btnFingers
            // 
            this.btnFingers.AutoHeight = false;
            this.btnFingers.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.btnFingers.Name = "btnFingers";
            // 
            // xtraTab
            // 
            this.xtraTab.HeaderOrientation = DevExpress.XtraTab.TabOrientation.Horizontal;
            this.xtraTab.Location = new System.Drawing.Point(6, 2);
            this.xtraTab.LookAndFeel.UseDefaultLookAndFeel = false;
            this.xtraTab.LookAndFeel.UseWindowsXPTheme = true;
            this.xtraTab.Name = "xtraTab";
            this.xtraTab.PageImagePosition = DevExpress.XtraTab.TabPageImagePosition.Center;
            this.xtraTab.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.xtraTab.SelectedTabPage = this.TabBasicInfo;
            this.xtraTab.ShowTabHeader = DevExpress.Utils.DefaultBoolean.True;
            this.xtraTab.Size = new System.Drawing.Size(773, 666);
            this.xtraTab.TabIndex = 0;
            this.xtraTab.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.TabBasicInfo,
            this.TabFinger,
            this.TabInfoDevices});
            this.xtraTab.SelectedPageChanged += new DevExpress.XtraTab.TabPageChangedEventHandler(this.xtraTab_SelectedPageChanged);
            // 
            // TabBasicInfo
            // 
            this.TabBasicInfo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.TabBasicInfo.Controls.Add(this.GrpAddEmp);
            this.TabBasicInfo.Name = "TabBasicInfo";
            this.TabBasicInfo.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.TabBasicInfo.Size = new System.Drawing.Size(765, 638);
            this.TabBasicInfo.Text = "اطلاعات پایه";
            // 
            // GrpAddEmp
            // 
            this.GrpAddEmp.CaptionLocation = DevExpress.Utils.Locations.Top;
            this.GrpAddEmp.Controls.Add(this.btnSetPrivateAccessGroup);
            this.GrpAddEmp.Controls.Add(this.groupBox1);
            this.GrpAddEmp.Controls.Add(this.DeviceType);
            this.GrpAddEmp.Controls.Add(this.grpMenuAccess);
            this.GrpAddEmp.Controls.Add(this.GrpOrganization);
            this.GrpAddEmp.Controls.Add(this.GrpPvInfo);
            this.GrpAddEmp.Controls.Add(this.BtnBrows);
            this.GrpAddEmp.Controls.Add(this.pictureEmployee);
            this.GrpAddEmp.Controls.Add(this.grpAuthTypeForZk);
            this.GrpAddEmp.Controls.Add(this.grpAuthType);
            this.GrpAddEmp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GrpAddEmp.Location = new System.Drawing.Point(0, 0);
            this.GrpAddEmp.Name = "GrpAddEmp";
            this.GrpAddEmp.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.GrpAddEmp.Size = new System.Drawing.Size(765, 638);
            this.GrpAddEmp.TabIndex = 15;
            this.GrpAddEmp.Text = "اضافه کردن کامند";
            // 
            // btnSetPrivateAccessGroup
            // 
            this.btnSetPrivateAccessGroup.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btnSetPrivateAccessGroup.Appearance.Options.UseBackColor = true;
            this.btnSetPrivateAccessGroup.Location = new System.Drawing.Point(582, 407);
            this.btnSetPrivateAccessGroup.Name = "btnSetPrivateAccessGroup";
            this.btnSetPrivateAccessGroup.Size = new System.Drawing.Size(172, 38);
            this.btnSetPrivateAccessGroup.TabIndex = 32;
            this.btnSetPrivateAccessGroup.Text = "تعریف گروه دسترسی اختصاصی";
            this.btnSetPrivateAccessGroup.Click += new System.EventHandler(this.btnSetPrivateAccessGroup_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rdbAdmin);
            this.groupBox1.Controls.Add(this.rdbUser);
            this.groupBox1.Location = new System.Drawing.Point(6, 213);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(117, 75);
            this.groupBox1.TabIndex = 31;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "نقش کاربر";
            // 
            // rdbAdmin
            // 
            this.rdbAdmin.AutoSize = true;
            this.rdbAdmin.Location = new System.Drawing.Point(28, 46);
            this.rdbAdmin.Name = "rdbAdmin";
            this.rdbAdmin.Size = new System.Drawing.Size(72, 17);
            this.rdbAdmin.TabIndex = 1;
            this.rdbAdmin.Text = "مدیر ارشد";
            this.rdbAdmin.UseVisualStyleBackColor = true;
            // 
            // rdbUser
            // 
            this.rdbUser.AutoSize = true;
            this.rdbUser.Checked = true;
            this.rdbUser.Location = new System.Drawing.Point(27, 20);
            this.rdbUser.Name = "rdbUser";
            this.rdbUser.Size = new System.Drawing.Size(73, 17);
            this.rdbUser.TabIndex = 0;
            this.rdbUser.TabStop = true;
            this.rdbUser.Text = "کاربر عادی";
            this.rdbUser.UseVisualStyleBackColor = true;
            // 
            // grpAuthTypeForZk
            // 
            this.grpAuthTypeForZk.Controls.Add(this.chkAuth);
            this.grpAuthTypeForZk.Controls.Add(this.label3);
            this.grpAuthTypeForZk.Controls.Add(this.VerfiCombo);
            this.grpAuthTypeForZk.Location = new System.Drawing.Point(6, 461);
            this.grpAuthTypeForZk.Name = "grpAuthTypeForZk";
            this.grpAuthTypeForZk.Size = new System.Drawing.Size(440, 110);
            this.grpAuthTypeForZk.TabIndex = 24;
            this.grpAuthTypeForZk.TabStop = false;
            this.grpAuthTypeForZk.Text = "نحوه احراز هویت";
            // 
            // chkAuth
            // 
            this.chkAuth.AutoSize = true;
            this.chkAuth.Location = new System.Drawing.Point(267, 62);
            this.chkAuth.Name = "chkAuth";
            this.chkAuth.Size = new System.Drawing.Size(102, 17);
            this.chkAuth.TabIndex = 29;
            this.chkAuth.Text = "اعمال حالت گروه";
            this.chkAuth.UseVisualStyleBackColor = true;
            this.chkAuth.CheckedChanged += new System.EventHandler(this.chkAuth_CheckedChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(256, 28);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(119, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "نحوه احراز هویت شخص:";
            // 
            // VerfiCombo
            // 
            this.VerfiCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.VerfiCombo.FormattingEnabled = true;
            this.VerfiCombo.Location = new System.Drawing.Point(37, 25);
            this.VerfiCombo.Name = "VerfiCombo";
            this.VerfiCombo.Size = new System.Drawing.Size(213, 21);
            this.VerfiCombo.TabIndex = 5;
            // 
            // DeviceType
            // 
            this.DeviceType.Controls.Add(this.rdbtnRaya);
            this.DeviceType.Controls.Add(this.rdbtnZk);
            this.DeviceType.Controls.Add(this.rdbtnEco);
            this.DeviceType.Location = new System.Drawing.Point(6, 407);
            this.DeviceType.Name = "DeviceType";
            this.DeviceType.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.DeviceType.Size = new System.Drawing.Size(437, 48);
            this.DeviceType.TabIndex = 29;
            this.DeviceType.TabStop = false;
            this.DeviceType.Text = "انتخاب نوع دستگاه ";
            // 
            // rdbtnRaya
            // 
            this.rdbtnRaya.AutoSize = true;
            this.rdbtnRaya.Location = new System.Drawing.Point(160, 20);
            this.rdbtnRaya.Name = "rdbtnRaya";
            this.rdbtnRaya.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.rdbtnRaya.Size = new System.Drawing.Size(104, 17);
            this.rdbtnRaya.TabIndex = 2;
            this.rdbtnRaya.TabStop = true;
            this.rdbtnRaya.Text = "دستگاه رایا کنترلر";
            this.rdbtnRaya.UseVisualStyleBackColor = true;
            this.rdbtnRaya.CheckedChanged += new System.EventHandler(this.rdbtnRaya_CheckedChanged);
            // 
            // rdbtnZk
            // 
            this.rdbtnZk.AutoSize = true;
            this.rdbtnZk.Location = new System.Drawing.Point(68, 20);
            this.rdbtnZk.Name = "rdbtnZk";
            this.rdbtnZk.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.rdbtnZk.Size = new System.Drawing.Size(74, 17);
            this.rdbtnZk.TabIndex = 1;
            this.rdbtnZk.TabStop = true;
            this.rdbtnZk.Text = "دستگاه ZK";
            this.rdbtnZk.UseVisualStyleBackColor = true;
            this.rdbtnZk.CheckedChanged += new System.EventHandler(this.rdbtnZk_CheckedChanged);
            // 
            // rdbtnEco
            // 
            this.rdbtnEco.AutoSize = true;
            this.rdbtnEco.Checked = true;
            this.rdbtnEco.Location = new System.Drawing.Point(276, 20);
            this.rdbtnEco.Name = "rdbtnEco";
            this.rdbtnEco.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.rdbtnEco.Size = new System.Drawing.Size(75, 17);
            this.rdbtnEco.TabIndex = 0;
            this.rdbtnEco.TabStop = true;
            this.rdbtnEco.Text = "دستگاه اکو";
            this.rdbtnEco.UseVisualStyleBackColor = true;
            this.rdbtnEco.CheckedChanged += new System.EventHandler(this.rdbtnEco_CheckedChanged);
            // 
            // grpMenuAccess
            // 
            this.grpMenuAccess.Controls.Add(this.chkDeviceMenu);
            this.grpMenuAccess.Controls.Add(this.chkOperatorMenu);
            this.grpMenuAccess.Controls.Add(this.chkNetworkMenu);
            this.grpMenuAccess.Controls.Add(this.lblDeviceMenu);
            this.grpMenuAccess.Controls.Add(this.lblOperatorMenu);
            this.grpMenuAccess.Controls.Add(this.LblNetworkMenu);
            this.grpMenuAccess.Enabled = false;
            this.grpMenuAccess.Location = new System.Drawing.Point(458, 461);
            this.grpMenuAccess.Name = "grpMenuAccess";
            this.grpMenuAccess.Size = new System.Drawing.Size(294, 168);
            this.grpMenuAccess.TabIndex = 26;
            this.grpMenuAccess.TabStop = false;
            this.grpMenuAccess.Text = "سطح دسترسی به تنظیمات دستگاه";
            // 
            // chkDeviceMenu
            // 
            this.chkDeviceMenu.AutoSize = true;
            this.chkDeviceMenu.Location = new System.Drawing.Point(181, 130);
            this.chkDeviceMenu.Name = "chkDeviceMenu";
            this.chkDeviceMenu.Size = new System.Drawing.Size(15, 14);
            this.chkDeviceMenu.TabIndex = 8;
            this.chkDeviceMenu.UseVisualStyleBackColor = true;
            // 
            // chkOperatorMenu
            // 
            this.chkOperatorMenu.AutoSize = true;
            this.chkOperatorMenu.Location = new System.Drawing.Point(181, 81);
            this.chkOperatorMenu.Name = "chkOperatorMenu";
            this.chkOperatorMenu.Size = new System.Drawing.Size(15, 14);
            this.chkOperatorMenu.TabIndex = 7;
            this.chkOperatorMenu.UseVisualStyleBackColor = true;
            // 
            // chkNetworkMenu
            // 
            this.chkNetworkMenu.AutoSize = true;
            this.chkNetworkMenu.Location = new System.Drawing.Point(181, 33);
            this.chkNetworkMenu.Name = "chkNetworkMenu";
            this.chkNetworkMenu.Size = new System.Drawing.Size(15, 14);
            this.chkNetworkMenu.TabIndex = 6;
            this.chkNetworkMenu.UseVisualStyleBackColor = true;
            // 
            // lblDeviceMenu
            // 
            this.lblDeviceMenu.AutoSize = true;
            this.lblDeviceMenu.Location = new System.Drawing.Point(206, 130);
            this.lblDeviceMenu.Name = "lblDeviceMenu";
            this.lblDeviceMenu.Size = new System.Drawing.Size(82, 13);
            this.lblDeviceMenu.TabIndex = 5;
            this.lblDeviceMenu.Text = "تنظیمات دستگاه";
            // 
            // lblOperatorMenu
            // 
            this.lblOperatorMenu.AutoSize = true;
            this.lblOperatorMenu.Location = new System.Drawing.Point(210, 81);
            this.lblOperatorMenu.Name = "lblOperatorMenu";
            this.lblOperatorMenu.Size = new System.Drawing.Size(78, 13);
            this.lblOperatorMenu.TabIndex = 4;
            this.lblOperatorMenu.Text = "تنظیمات کاربری";
            // 
            // LblNetworkMenu
            // 
            this.LblNetworkMenu.AutoSize = true;
            this.LblNetworkMenu.Location = new System.Drawing.Point(213, 33);
            this.LblNetworkMenu.Name = "LblNetworkMenu";
            this.LblNetworkMenu.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.LblNetworkMenu.Size = new System.Drawing.Size(75, 13);
            this.LblNetworkMenu.TabIndex = 3;
            this.LblNetworkMenu.Text = "تنظیمات شبکه";
            // 
            // GrpOrganization
            // 
            this.GrpOrganization.Controls.Add(this.TreeOrganization);
            this.GrpOrganization.Location = new System.Drawing.Point(129, 23);
            this.GrpOrganization.Name = "GrpOrganization";
            this.GrpOrganization.Size = new System.Drawing.Size(317, 377);
            this.GrpOrganization.TabIndex = 28;
            this.GrpOrganization.TabStop = false;
            this.GrpOrganization.Text = "سمت سازمانی";
            // 
            // TreeOrganization
            // 
            this.TreeOrganization.AutoCheckChildNodes = false;
            this.TreeOrganization.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(236)))), ((int)(((byte)(239)))));
            this.TreeOrganization.CheckBoxes = true;
            this.TreeOrganization.ChildMember = "ID";
            this.TreeOrganization.Cursor = System.Windows.Forms.Cursors.Default;
            this.TreeOrganization.DisplayMember = "name";
            this.TreeOrganization.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TreeOrganization.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.TreeOrganization.ForeColor = System.Drawing.Color.Black;
            this.TreeOrganization.Location = new System.Drawing.Point(3, 17);
            this.TreeOrganization.Name = "TreeOrganization";
            this.TreeOrganization.ParentMember = "OrganizationID";
            this.TreeOrganization.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.TreeOrganization.ShowLines = true;
            this.TreeOrganization.Size = new System.Drawing.Size(311, 357);
            this.TreeOrganization.SpacingBetweenNodes = -1;
            this.TreeOrganization.TabIndex = 0;
            this.TreeOrganization.ToggleMode = Telerik.WinControls.UI.ToggleMode.SingleClick;
            this.TreeOrganization.ValueMember = "ID";
            this.TreeOrganization.NodeCheckedChanging += new Telerik.WinControls.UI.RadTreeView.RadTreeViewCancelEventHandler(this.TreeOrganization_NodeCheckedChanging);
            ((Telerik.WinControls.UI.RadTreeViewElement)(this.TreeOrganization.GetChildAt(0))).ShowExpandCollapse = true;
            ((Telerik.WinControls.UI.RadTreeViewElement)(this.TreeOrganization.GetChildAt(0))).ItemHeight = 20;
            ((Telerik.WinControls.UI.RadTreeViewElement)(this.TreeOrganization.GetChildAt(0))).ShowLines = true;
            ((Telerik.WinControls.UI.RadTreeViewElement)(this.TreeOrganization.GetChildAt(0))).ShowRootLines = true;
            ((Telerik.WinControls.UI.RadTreeViewElement)(this.TreeOrganization.GetChildAt(0))).LineColor = System.Drawing.Color.Gray;
            ((Telerik.WinControls.UI.RadTreeViewElement)(this.TreeOrganization.GetChildAt(0))).TreeIndent = 20;
            ((Telerik.WinControls.UI.RadTreeViewElement)(this.TreeOrganization.GetChildAt(0))).FullRowSelect = true;
            ((Telerik.WinControls.UI.RadTreeViewElement)(this.TreeOrganization.GetChildAt(0))).NodeSpacing = -1;
            ((Telerik.WinControls.UI.RadTreeViewElement)(this.TreeOrganization.GetChildAt(0))).AlternatingRowColor = System.Drawing.Color.AliceBlue;
            ((Telerik.WinControls.UI.RadTreeViewElement)(this.TreeOrganization.GetChildAt(0))).BorderColor = System.Drawing.SystemColors.ControlDark;
            ((Telerik.WinControls.UI.RadTreeViewElement)(this.TreeOrganization.GetChildAt(0))).BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(236)))), ((int)(((byte)(239)))));
            // 
            // GrpPvInfo
            // 
            this.GrpPvInfo.Controls.Add(this.chkPrivateAccess);
            this.GrpPvInfo.Controls.Add(this.cmbAcsGroup);
            this.GrpPvInfo.Controls.Add(this.txtFName);
            this.GrpPvInfo.Controls.Add(this.lblFName);
            this.GrpPvInfo.Controls.Add(this.lblLname);
            this.GrpPvInfo.Controls.Add(this.txtRePin);
            this.GrpPvInfo.Controls.Add(this.lblPin);
            this.GrpPvInfo.Controls.Add(this.lblRePin);
            this.GrpPvInfo.Controls.Add(this.lblNational);
            this.GrpPvInfo.Controls.Add(this.lblEmpIdErr);
            this.GrpPvInfo.Controls.Add(this.lblEmpID);
            this.GrpPvInfo.Controls.Add(this.lblTel);
            this.GrpPvInfo.Controls.Add(this.lblNationalErr);
            this.GrpPvInfo.Controls.Add(this.lblPost);
            this.GrpPvInfo.Controls.Add(this.txtLName);
            this.GrpPvInfo.Controls.Add(this.txtNational);
            this.GrpPvInfo.Controls.Add(this.txtPost);
            this.GrpPvInfo.Controls.Add(this.txtPin);
            this.GrpPvInfo.Controls.Add(this.txtTel);
            this.GrpPvInfo.Controls.Add(this.txtEmpId);
            this.GrpPvInfo.Location = new System.Drawing.Point(452, 23);
            this.GrpPvInfo.Name = "GrpPvInfo";
            this.GrpPvInfo.Size = new System.Drawing.Size(308, 377);
            this.GrpPvInfo.TabIndex = 27;
            this.GrpPvInfo.TabStop = false;
            this.GrpPvInfo.Text = "اطلاعات فردی";
            // 
            // chkPrivateAccess
            // 
            this.chkPrivateAccess.AutoSize = true;
            this.chkPrivateAccess.Location = new System.Drawing.Point(157, 340);
            this.chkPrivateAccess.Name = "chkPrivateAccess";
            this.chkPrivateAccess.Size = new System.Drawing.Size(145, 17);
            this.chkPrivateAccess.TabIndex = 28;
            this.chkPrivateAccess.Text = "گروه دسترسی اختصاصی";
            this.chkPrivateAccess.UseVisualStyleBackColor = true;
            this.chkPrivateAccess.CheckedChanged += new System.EventHandler(this.chkPrivateAccess_CheckedChanged);
            // 
            // cmbAcsGroup
            // 
            this.cmbAcsGroup.DisplayMember = "Name";
            this.cmbAcsGroup.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAcsGroup.FormattingEnabled = true;
            this.cmbAcsGroup.Location = new System.Drawing.Point(6, 338);
            this.cmbAcsGroup.Name = "cmbAcsGroup";
            this.cmbAcsGroup.Size = new System.Drawing.Size(145, 21);
            this.cmbAcsGroup.TabIndex = 27;
            this.cmbAcsGroup.ValueMember = "ID";
            // 
            // txtFName
            // 
            this.txtFName.BackColor = System.Drawing.SystemColors.Info;
            this.txtFName.ForeColor = System.Drawing.Color.Maroon;
            this.txtFName.Location = new System.Drawing.Point(7, 35);
            this.txtFName.Margin = new System.Windows.Forms.Padding(4);
            this.txtFName.MaxLength = 15;
            this.txtFName.Name = "txtFName";
            this.txtFName.Size = new System.Drawing.Size(145, 21);
            this.txtFName.TabIndex = 7;
            // 
            // lblFName
            // 
            this.lblFName.AutoSize = true;
            this.lblFName.Location = new System.Drawing.Point(248, 38);
            this.lblFName.Name = "lblFName";
            this.lblFName.Size = new System.Drawing.Size(55, 13);
            this.lblFName.TabIndex = 0;
            this.lblFName.Text = "نام کارمند:";
            // 
            // lblLname
            // 
            this.lblLname.AutoSize = true;
            this.lblLname.Location = new System.Drawing.Point(234, 76);
            this.lblLname.Name = "lblLname";
            this.lblLname.Size = new System.Drawing.Size(69, 13);
            this.lblLname.TabIndex = 1;
            this.lblLname.Text = "نام خانوادگی:";
            // 
            // txtRePin
            // 
            this.txtRePin.BackColor = System.Drawing.SystemColors.Info;
            this.txtRePin.ForeColor = System.Drawing.Color.Maroon;
            this.txtRePin.Location = new System.Drawing.Point(7, 225);
            this.txtRePin.Margin = new System.Windows.Forms.Padding(4);
            this.txtRePin.MaxLength = 10;
            this.txtRePin.Name = "txtRePin";
            this.txtRePin.Size = new System.Drawing.Size(145, 21);
            this.txtRePin.TabIndex = 12;
            this.txtRePin.UseSystemPasswordChar = true;
            // 
            // lblPin
            // 
            this.lblPin.AutoSize = true;
            this.lblPin.Location = new System.Drawing.Point(247, 190);
            this.lblPin.Name = "lblPin";
            this.lblPin.Size = new System.Drawing.Size(56, 13);
            this.lblPin.TabIndex = 2;
            this.lblPin.Text = "کلمه عبور:";
            // 
            // lblRePin
            // 
            this.lblRePin.AutoSize = true;
            this.lblRePin.Location = new System.Drawing.Point(223, 228);
            this.lblRePin.Name = "lblRePin";
            this.lblRePin.Size = new System.Drawing.Size(80, 13);
            this.lblRePin.TabIndex = 25;
            this.lblRePin.Text = "تکرار کلمه عبور:";
            // 
            // lblNational
            // 
            this.lblNational.AutoSize = true;
            this.lblNational.Location = new System.Drawing.Point(257, 152);
            this.lblNational.Name = "lblNational";
            this.lblNational.Size = new System.Drawing.Size(46, 13);
            this.lblNational.TabIndex = 3;
            this.lblNational.Text = "کد ملی:";
            // 
            // lblEmpIdErr
            // 
            this.lblEmpIdErr.AutoSize = true;
            this.lblEmpIdErr.Location = new System.Drawing.Point(276, 252);
            this.lblEmpIdErr.Name = "lblEmpIdErr";
            this.lblEmpIdErr.Size = new System.Drawing.Size(0, 13);
            this.lblEmpIdErr.TabIndex = 24;
            // 
            // lblEmpID
            // 
            this.lblEmpID.AutoSize = true;
            this.lblEmpID.Location = new System.Drawing.Point(221, 114);
            this.lblEmpID.Name = "lblEmpID";
            this.lblEmpID.Size = new System.Drawing.Size(82, 13);
            this.lblEmpID.TabIndex = 4;
            this.lblEmpID.Text = "شماره کارمندی:";
            // 
            // lblTel
            // 
            this.lblTel.AutoSize = true;
            this.lblTel.Location = new System.Drawing.Point(271, 304);
            this.lblTel.Name = "lblTel";
            this.lblTel.Size = new System.Drawing.Size(32, 13);
            this.lblTel.TabIndex = 5;
            this.lblTel.Text = "تلفن:";
            // 
            // lblNationalErr
            // 
            this.lblNationalErr.AutoSize = true;
            this.lblNationalErr.Location = new System.Drawing.Point(276, 137);
            this.lblNationalErr.Name = "lblNationalErr";
            this.lblNationalErr.Size = new System.Drawing.Size(0, 13);
            this.lblNationalErr.TabIndex = 22;
            // 
            // lblPost
            // 
            this.lblPost.AutoSize = true;
            this.lblPost.Location = new System.Drawing.Point(264, 266);
            this.lblPost.Name = "lblPost";
            this.lblPost.Size = new System.Drawing.Size(39, 13);
            this.lblPost.TabIndex = 6;
            this.lblPost.Text = "سمت:";
            // 
            // txtLName
            // 
            this.txtLName.BackColor = System.Drawing.SystemColors.Info;
            this.txtLName.ForeColor = System.Drawing.Color.Maroon;
            this.txtLName.Location = new System.Drawing.Point(7, 73);
            this.txtLName.Margin = new System.Windows.Forms.Padding(4);
            this.txtLName.MaxLength = 15;
            this.txtLName.Name = "txtLName";
            this.txtLName.Size = new System.Drawing.Size(145, 21);
            this.txtLName.TabIndex = 8;
            // 
            // txtNational
            // 
            this.txtNational.BackColor = System.Drawing.SystemColors.Info;
            this.txtNational.ForeColor = System.Drawing.Color.Maroon;
            this.txtNational.Location = new System.Drawing.Point(7, 149);
            this.txtNational.Margin = new System.Windows.Forms.Padding(4);
            this.txtNational.MaxLength = 10;
            this.txtNational.Name = "txtNational";
            this.txtNational.Size = new System.Drawing.Size(145, 21);
            this.txtNational.TabIndex = 9;
            this.txtNational.TextChanged += new System.EventHandler(this.txtNational_TextChanged);
            // 
            // txtPost
            // 
            this.txtPost.Location = new System.Drawing.Point(7, 263);
            this.txtPost.Margin = new System.Windows.Forms.Padding(4);
            this.txtPost.MaxLength = 15;
            this.txtPost.Name = "txtPost";
            this.txtPost.Size = new System.Drawing.Size(145, 21);
            this.txtPost.TabIndex = 14;
            // 
            // txtPin
            // 
            this.txtPin.BackColor = System.Drawing.SystemColors.Info;
            this.txtPin.ForeColor = System.Drawing.Color.Maroon;
            this.txtPin.Location = new System.Drawing.Point(7, 187);
            this.txtPin.Margin = new System.Windows.Forms.Padding(4);
            this.txtPin.MaxLength = 10;
            this.txtPin.Name = "txtPin";
            this.txtPin.Size = new System.Drawing.Size(145, 21);
            this.txtPin.TabIndex = 11;
            this.txtPin.UseSystemPasswordChar = true;
            this.txtPin.TextChanged += new System.EventHandler(this.txtPin_TextChanged);
            // 
            // txtTel
            // 
            this.txtTel.Location = new System.Drawing.Point(7, 301);
            this.txtTel.Margin = new System.Windows.Forms.Padding(4);
            this.txtTel.MaxLength = 11;
            this.txtTel.Name = "txtTel";
            this.txtTel.Size = new System.Drawing.Size(145, 21);
            this.txtTel.TabIndex = 13;
            // 
            // txtEmpId
            // 
            this.txtEmpId.BackColor = System.Drawing.SystemColors.Info;
            this.txtEmpId.ForeColor = System.Drawing.Color.Maroon;
            this.txtEmpId.Location = new System.Drawing.Point(7, 111);
            this.txtEmpId.Margin = new System.Windows.Forms.Padding(4);
            this.txtEmpId.MaxLength = 10;
            this.txtEmpId.Name = "txtEmpId";
            this.txtEmpId.Size = new System.Drawing.Size(145, 21);
            this.txtEmpId.TabIndex = 10;
            this.txtEmpId.TextChanged += new System.EventHandler(this.txtEmpId_TextChanged);
            // 
            // BtnBrows
            // 
            this.BtnBrows.Location = new System.Drawing.Point(31, 183);
            this.BtnBrows.Name = "BtnBrows";
            this.BtnBrows.Size = new System.Drawing.Size(75, 23);
            this.BtnBrows.TabIndex = 15;
            this.BtnBrows.Text = "انتخاب فایل";
            this.BtnBrows.Click += new System.EventHandler(this.BtnBrows_Click);
            // 
            // pictureEmployee
            // 
            this.pictureEmployee.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureEmployee.BackColor = System.Drawing.Color.White;
            this.pictureEmployee.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureEmployee.Image = ((System.Drawing.Image)(resources.GetObject("pictureEmployee.Image")));
            this.pictureEmployee.Location = new System.Drawing.Point(12, 40);
            this.pictureEmployee.Name = "pictureEmployee";
            this.pictureEmployee.Size = new System.Drawing.Size(111, 137);
            this.pictureEmployee.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureEmployee.TabIndex = 20;
            this.pictureEmployee.TabStop = false;
            // 
            // grpAuthType
            // 
            this.grpAuthType.Controls.Add(this.label2);
            this.grpAuthType.Controls.Add(this.label1);
            this.grpAuthType.Controls.Add(this.lbland2);
            this.grpAuthType.Controls.Add(this.lblAnd1);
            this.grpAuthType.Controls.Add(this.lblAnd);
            this.grpAuthType.Controls.Add(this.lblIDtype);
            this.grpAuthType.Controls.Add(this.lblCard);
            this.grpAuthType.Controls.Add(this.lblPintype);
            this.grpAuthType.Controls.Add(this.lblFingerType);
            this.grpAuthType.Controls.Add(this.lbl3);
            this.grpAuthType.Controls.Add(this.lbl2);
            this.grpAuthType.Controls.Add(this.lbl1);
            this.grpAuthType.Location = new System.Drawing.Point(12, 461);
            this.grpAuthType.Name = "grpAuthType";
            this.grpAuthType.Size = new System.Drawing.Size(434, 169);
            this.grpAuthType.TabIndex = 16;
            this.grpAuthType.TabStop = false;
            this.grpAuthType.Text = "نحوه احراز هویت";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(345, 109);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(13, 13);
            this.label2.TabIndex = 23;
            this.label2.Text = "یا";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(344, 76);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(13, 13);
            this.label1.TabIndex = 22;
            this.label1.Text = "یا";
            // 
            // lbland2
            // 
            this.lbland2.AutoSize = true;
            this.lbland2.Location = new System.Drawing.Point(248, 33);
            this.lbland2.Name = "lbland2";
            this.lbland2.Size = new System.Drawing.Size(12, 13);
            this.lbland2.TabIndex = 21;
            this.lbland2.Text = "و";
            // 
            // lblAnd1
            // 
            this.lblAnd1.AutoSize = true;
            this.lblAnd1.Location = new System.Drawing.Point(158, 31);
            this.lblAnd1.Name = "lblAnd1";
            this.lblAnd1.Size = new System.Drawing.Size(12, 13);
            this.lblAnd1.TabIndex = 20;
            this.lblAnd1.Text = "و";
            // 
            // lblAnd
            // 
            this.lblAnd.AutoSize = true;
            this.lblAnd.Location = new System.Drawing.Point(92, 31);
            this.lblAnd.Name = "lblAnd";
            this.lblAnd.Size = new System.Drawing.Size(12, 13);
            this.lblAnd.TabIndex = 19;
            this.lblAnd.Text = "و";
            // 
            // lblIDtype
            // 
            this.lblIDtype.AutoSize = true;
            this.lblIDtype.Location = new System.Drawing.Point(177, 31);
            this.lblIDtype.Name = "lblIDtype";
            this.lblIDtype.Size = new System.Drawing.Size(51, 13);
            this.lblIDtype.TabIndex = 6;
            this.lblIDtype.Text = "کد کاربری";
            // 
            // lblCard
            // 
            this.lblCard.AutoSize = true;
            this.lblCard.Location = new System.Drawing.Point(110, 31);
            this.lblCard.Name = "lblCard";
            this.lblCard.Size = new System.Drawing.Size(28, 13);
            this.lblCard.TabIndex = 5;
            this.lblCard.Text = "کارت";
            // 
            // lblPintype
            // 
            this.lblPintype.AutoSize = true;
            this.lblPintype.Location = new System.Drawing.Point(270, 33);
            this.lblPintype.Name = "lblPintype";
            this.lblPintype.Size = new System.Drawing.Size(52, 13);
            this.lblPintype.TabIndex = 4;
            this.lblPintype.Text = "کلمه عبور";
            // 
            // lblFingerType
            // 
            this.lblFingerType.AutoSize = true;
            this.lblFingerType.Location = new System.Drawing.Point(27, 31);
            this.lblFingerType.Name = "lblFingerType";
            this.lblFingerType.Size = new System.Drawing.Size(55, 13);
            this.lblFingerType.TabIndex = 3;
            this.lblFingerType.Text = "اثر انگشت";
            // 
            // lbl3
            // 
            this.lbl3.AutoSize = true;
            this.lbl3.Location = new System.Drawing.Point(344, 129);
            this.lbl3.Name = "lbl3";
            this.lbl3.Size = new System.Drawing.Size(17, 13);
            this.lbl3.TabIndex = 2;
            this.lbl3.Text = "3:";
            // 
            // lbl2
            // 
            this.lbl2.AutoSize = true;
            this.lbl2.Location = new System.Drawing.Point(344, 93);
            this.lbl2.Name = "lbl2";
            this.lbl2.Size = new System.Drawing.Size(17, 13);
            this.lbl2.TabIndex = 1;
            this.lbl2.Text = "2:";
            // 
            // lbl1
            // 
            this.lbl1.AutoSize = true;
            this.lbl1.Location = new System.Drawing.Point(344, 58);
            this.lbl1.Name = "lbl1";
            this.lbl1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lbl1.Size = new System.Drawing.Size(17, 13);
            this.lbl1.TabIndex = 0;
            this.lbl1.Text = "1:";
            // 
            // TabFinger
            // 
            this.TabFinger.Controls.Add(this.GrpctrlEncoder);
            this.TabFinger.Name = "TabFinger";
            this.TabFinger.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.TabFinger.Size = new System.Drawing.Size(765, 638);
            this.TabFinger.Text = "تخصیص ابزار احراز هویت";
            // 
            // GrpctrlEncoder
            // 
            this.GrpctrlEncoder.Controls.Add(this.GrpPalm);
            this.GrpctrlEncoder.Controls.Add(this.grpFace);
            this.GrpctrlEncoder.Controls.Add(this.grpEncoder);
            this.GrpctrlEncoder.Controls.Add(this.GrpFinger);
            this.GrpctrlEncoder.Controls.Add(this.grpEcoder);
            this.GrpctrlEncoder.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GrpctrlEncoder.Location = new System.Drawing.Point(0, 0);
            this.GrpctrlEncoder.Name = "GrpctrlEncoder";
            this.GrpctrlEncoder.Size = new System.Drawing.Size(765, 638);
            this.GrpctrlEncoder.TabIndex = 0;
            this.GrpctrlEncoder.Text = "تخصیص ابزار احراز هویت";
            // 
            // GrpPalm
            // 
            this.GrpPalm.Controls.Add(this.pictureBox2);
            this.GrpPalm.Controls.Add(this.btnGetPalm);
            this.GrpPalm.Location = new System.Drawing.Point(5, 484);
            this.GrpPalm.Name = "GrpPalm";
            this.GrpPalm.Size = new System.Drawing.Size(379, 149);
            this.GrpPalm.TabIndex = 28;
            this.GrpPalm.TabStop = false;
            this.GrpPalm.Text = "دریافت اطلاعات کف دست";
            // 
            // pictureBox2
            // 
            this.pictureBox2.Location = new System.Drawing.Point(257, 20);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(116, 123);
            this.pictureBox2.TabIndex = 24;
            this.pictureBox2.TabStop = false;
            // 
            // btnGetPalm
            // 
            this.btnGetPalm.Location = new System.Drawing.Point(6, 120);
            this.btnGetPalm.Name = "btnGetPalm";
            this.btnGetPalm.Size = new System.Drawing.Size(75, 23);
            this.btnGetPalm.TabIndex = 24;
            this.btnGetPalm.Text = "دریافت";
            this.btnGetPalm.Click += new System.EventHandler(this.BtnGetPalm_Click);
            // 
            // grpFace
            // 
            this.grpFace.Controls.Add(this.BtnSendFace);
            this.grpFace.Controls.Add(this.btnGetFace);
            this.grpFace.Controls.Add(this.PicBox);
            this.grpFace.Location = new System.Drawing.Point(390, 484);
            this.grpFace.Name = "grpFace";
            this.grpFace.Size = new System.Drawing.Size(369, 149);
            this.grpFace.TabIndex = 27;
            this.grpFace.TabStop = false;
            this.grpFace.Text = "دریافت اطلاعات چهره";
            // 
            // BtnSendFace
            // 
            this.BtnSendFace.Location = new System.Drawing.Point(6, 120);
            this.BtnSendFace.Name = "BtnSendFace";
            this.BtnSendFace.Size = new System.Drawing.Size(75, 23);
            this.BtnSendFace.TabIndex = 24;
            this.BtnSendFace.Text = "ارسال";
            this.BtnSendFace.Click += new System.EventHandler(this.BtnSendFace_Click);
            // 
            // btnGetFace
            // 
            this.btnGetFace.Location = new System.Drawing.Point(87, 120);
            this.btnGetFace.Name = "btnGetFace";
            this.btnGetFace.Size = new System.Drawing.Size(75, 23);
            this.btnGetFace.TabIndex = 23;
            this.btnGetFace.Text = "دریافت";
            this.btnGetFace.Click += new System.EventHandler(this.BtnGetFace_Click);
            // 
            // PicBox
            // 
            this.PicBox.Dock = System.Windows.Forms.DockStyle.Right;
            this.PicBox.Location = new System.Drawing.Point(250, 17);
            this.PicBox.Name = "PicBox";
            this.PicBox.Size = new System.Drawing.Size(116, 129);
            this.PicBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.PicBox.TabIndex = 0;
            this.PicBox.TabStop = false;
            // 
            // grpEncoder
            // 
            this.grpEncoder.Controls.Add(this.cmbbxSelectEncoder);
            this.grpEncoder.Controls.Add(this.lbl);
            this.grpEncoder.Location = new System.Drawing.Point(390, 26);
            this.grpEncoder.Name = "grpEncoder";
            this.grpEncoder.Size = new System.Drawing.Size(371, 86);
            this.grpEncoder.TabIndex = 26;
            this.grpEncoder.TabStop = false;
            this.grpEncoder.Text = "انتخاب دستگاه";
            // 
            // cmbbxSelectEncoder
            // 
            this.cmbbxSelectEncoder.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbbxSelectEncoder.FormattingEnabled = true;
            this.cmbbxSelectEncoder.Location = new System.Drawing.Point(129, 36);
            this.cmbbxSelectEncoder.Name = "cmbbxSelectEncoder";
            this.cmbbxSelectEncoder.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cmbbxSelectEncoder.Size = new System.Drawing.Size(185, 21);
            this.cmbbxSelectEncoder.TabIndex = 1;
            this.cmbbxSelectEncoder.SelectionChangeCommitted += new System.EventHandler(this.cmbbxSelectEncoder_SelectionChangeCommitted);
            // 
            // lbl
            // 
            this.lbl.AutoSize = true;
            this.lbl.Location = new System.Drawing.Point(320, 39);
            this.lbl.Name = "lbl";
            this.lbl.Size = new System.Drawing.Size(41, 13);
            this.lbl.TabIndex = 24;
            this.lbl.Text = "دستگاه";
            // 
            // GrpFinger
            // 
            this.GrpFinger.Controls.Add(this.waiting);
            this.GrpFinger.Controls.Add(this.LeftHand);
            this.GrpFinger.Controls.Add(this.RightHand);
            this.GrpFinger.Location = new System.Drawing.Point(5, 114);
            this.GrpFinger.Name = "GrpFinger";
            this.GrpFinger.Size = new System.Drawing.Size(754, 364);
            this.GrpFinger.TabIndex = 25;
            this.GrpFinger.TabStop = false;
            this.GrpFinger.Text = "تخصیص اثرانگشت";
            // 
            // waiting
            // 
            this.waiting.BackColor = System.Drawing.Color.Transparent;
            this.waiting.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.waiting.Image = ((System.Drawing.Image)(resources.GetObject("waiting.Image")));
            this.waiting.InitialImage = ((System.Drawing.Image)(resources.GetObject("waiting.InitialImage")));
            this.waiting.Location = new System.Drawing.Point(319, 132);
            this.waiting.Name = "waiting";
            this.waiting.Size = new System.Drawing.Size(111, 84);
            this.waiting.TabIndex = 2;
            this.waiting.TabStop = false;
            this.waiting.Visible = false;
            this.waiting.WaitOnLoad = true;
            // 
            // LeftHand
            // 
            this.LeftHand.Image = global::Eco.Properties.Resources.hand3;
            this.LeftHand.Location = new System.Drawing.Point(126, 13);
            this.LeftHand.Name = "LeftHand";
            this.LeftHand.Size = new System.Drawing.Size(232, 345);
            this.LeftHand.TabIndex = 0;
            this.LeftHand.TabStop = false;
            // 
            // RightHand
            // 
            this.RightHand.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.RightHand.ErrorImage = null;
            this.RightHand.Image = global::Eco.Properties.Resources.hand2;
            this.RightHand.InitialImage = null;
            this.RightHand.Location = new System.Drawing.Point(403, 13);
            this.RightHand.Name = "RightHand";
            this.RightHand.Size = new System.Drawing.Size(232, 345);
            this.RightHand.TabIndex = 1;
            this.RightHand.TabStop = false;
            // 
            // grpEcoder
            // 
            this.grpEcoder.Controls.Add(this.btnConnect);
            this.grpEcoder.Controls.Add(this.btnEncode);
            this.grpEcoder.Controls.Add(this.btnDeleteCard);
            this.grpEcoder.Controls.Add(this.picExistCard);
            this.grpEcoder.Location = new System.Drawing.Point(7, 26);
            this.grpEcoder.Name = "grpEcoder";
            this.grpEcoder.Size = new System.Drawing.Size(377, 86);
            this.grpEcoder.TabIndex = 22;
            this.grpEcoder.TabStop = false;
            this.grpEcoder.Text = "تخصیص کارت";
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(288, 36);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(75, 23);
            this.btnConnect.TabIndex = 4;
            this.btnConnect.Text = "اتصال به انکدر";
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // btnEncode
            // 
            this.btnEncode.Enabled = false;
            this.btnEncode.Location = new System.Drawing.Point(207, 36);
            this.btnEncode.Name = "btnEncode";
            this.btnEncode.Size = new System.Drawing.Size(75, 23);
            this.btnEncode.TabIndex = 2;
            this.btnEncode.Text = "شروع";
            this.btnEncode.Click += new System.EventHandler(this.btnEncode_Click);
            // 
            // btnDeleteCard
            // 
            this.btnDeleteCard.Location = new System.Drawing.Point(126, 36);
            this.btnDeleteCard.Name = "btnDeleteCard";
            this.btnDeleteCard.Size = new System.Drawing.Size(75, 23);
            this.btnDeleteCard.TabIndex = 3;
            this.btnDeleteCard.Text = "حذف کارت";
            this.btnDeleteCard.Visible = false;
            this.btnDeleteCard.Click += new System.EventHandler(this.btnDeleteCard_Click);
            // 
            // picExistCard
            // 
            this.picExistCard.Image = global::Eco.Properties.Resources.card;
            this.picExistCard.Location = new System.Drawing.Point(21, 18);
            this.picExistCard.Name = "picExistCard";
            this.picExistCard.Size = new System.Drawing.Size(96, 64);
            this.picExistCard.TabIndex = 2;
            this.picExistCard.TabStop = false;
            this.picExistCard.Visible = false;
            // 
            // TabInfoDevices
            // 
            this.TabInfoDevices.Controls.Add(this.GrpctrInfoDevices);
            this.TabInfoDevices.Name = "TabInfoDevices";
            this.TabInfoDevices.PageVisible = false;
            this.TabInfoDevices.Size = new System.Drawing.Size(765, 638);
            this.TabInfoDevices.Text = "وضعیت اطلاعات در دستگاهها";
            // 
            // GrpctrInfoDevices
            // 
            this.GrpctrInfoDevices.Controls.Add(this.progressPanel);
            this.GrpctrInfoDevices.Controls.Add(this.gridDeviceInfo);
            this.GrpctrInfoDevices.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GrpctrInfoDevices.Location = new System.Drawing.Point(0, 0);
            this.GrpctrInfoDevices.Name = "GrpctrInfoDevices";
            this.GrpctrInfoDevices.Size = new System.Drawing.Size(765, 638);
            this.GrpctrInfoDevices.TabIndex = 0;
            this.GrpctrInfoDevices.Text = "وضعیت اطلاعات شخص در دستگاه";
            // 
            // progressPanel
            // 
            this.progressPanel.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.progressPanel.Appearance.Options.UseBackColor = true;
            this.progressPanel.AppearanceCaption.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.progressPanel.AppearanceCaption.Options.UseFont = true;
            this.progressPanel.AppearanceDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.progressPanel.AppearanceDescription.Options.UseFont = true;
            this.progressPanel.Caption = "لطفا صبر کنید .....";
            this.progressPanel.Description = "در حال ارسال ....";
            this.progressPanel.Location = new System.Drawing.Point(309, 196);
            this.progressPanel.Name = "progressPanel";
            this.progressPanel.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.progressPanel.Size = new System.Drawing.Size(142, 66);
            this.progressPanel.TabIndex = 1;
            this.progressPanel.Text = "لطفا صبر کنید ....";
            // 
            // openFileDialog
            // 
            this.openFileDialog.Title = "انتخاب عکس";
            // 
            // btnCancelEmp
            // 
            this.btnCancelEmp.Location = new System.Drawing.Point(537, 674);
            this.btnCancelEmp.Name = "btnCancelEmp";
            this.btnCancelEmp.Size = new System.Drawing.Size(75, 23);
            this.btnCancelEmp.TabIndex = 21;
            this.btnCancelEmp.Text = "لغو";
            this.btnCancelEmp.Visible = false;
            this.btnCancelEmp.Click += new System.EventHandler(this.btnCancelEmp_Click);
            // 
            // btnApply
            // 
            this.btnApply.Location = new System.Drawing.Point(618, 674);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(75, 23);
            this.btnApply.TabIndex = 17;
            this.btnApply.Text = "ثبت";
            this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
            // 
            // btnSaveEmp
            // 
            this.btnSaveEmp.Location = new System.Drawing.Point(699, 674);
            this.btnSaveEmp.Name = "btnSaveEmp";
            this.btnSaveEmp.Size = new System.Drawing.Size(75, 23);
            this.btnSaveEmp.TabIndex = 16;
            this.btnSaveEmp.Text = "افزودن";
            this.btnSaveEmp.Click += new System.EventHandler(this.btnSaveEmp_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(699, 675);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(75, 23);
            this.btnEdit.TabIndex = 16;
            this.btnEdit.Text = "ثبت";
            this.btnEdit.Visible = false;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // BtnSend
            // 
            this.BtnSend.Location = new System.Drawing.Point(618, 674);
            this.BtnSend.Name = "BtnSend";
            this.BtnSend.Size = new System.Drawing.Size(75, 23);
            this.BtnSend.TabIndex = 22;
            this.BtnSend.Text = "ارسال";
            this.BtnSend.Click += new System.EventHandler(this.BtnSend_Click);
            // 
            // FrmAddEmployee
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(797, 710);
            this.Controls.Add(this.BtnSend);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnSaveEmp);
            this.Controls.Add(this.btnApply);
            this.Controls.Add(this.btnCancelEmp);
            this.Controls.Add(this.xtraTab);
            this.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmAddEmployee";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "اضافه کردن کارمند";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmAddEmployee_FormClosing);
            this.Load += new System.EventHandler(this.FrmAddEmployee_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridDeviceInfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrdInfoInDevices)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FigerLink)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkEditDB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnFingers)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTab)).EndInit();
            this.xtraTab.ResumeLayout(false);
            this.TabBasicInfo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.GrpAddEmp)).EndInit();
            this.GrpAddEmp.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.grpAuthTypeForZk.ResumeLayout(false);
            this.grpAuthTypeForZk.PerformLayout();
            this.DeviceType.ResumeLayout(false);
            this.DeviceType.PerformLayout();
            this.grpMenuAccess.ResumeLayout(false);
            this.grpMenuAccess.PerformLayout();
            this.GrpOrganization.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.TreeOrganization)).EndInit();
            this.GrpPvInfo.ResumeLayout(false);
            this.GrpPvInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEmployee)).EndInit();
            this.grpAuthType.ResumeLayout(false);
            this.grpAuthType.PerformLayout();
            this.TabFinger.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.GrpctrlEncoder)).EndInit();
            this.GrpctrlEncoder.ResumeLayout(false);
            this.GrpPalm.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.grpFace.ResumeLayout(false);
            this.grpFace.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PicBox)).EndInit();
            this.grpEncoder.ResumeLayout(false);
            this.grpEncoder.PerformLayout();
            this.GrpFinger.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.waiting)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LeftHand)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RightHand)).EndInit();
            this.grpEcoder.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picExistCard)).EndInit();
            this.TabInfoDevices.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.GrpctrInfoDevices)).EndInit();
            this.GrpctrInfoDevices.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraTab.XtraTabPage TabBasicInfo;
        private DevExpress.XtraTab.XtraTabPage TabFinger;
        private System.Windows.Forms.Label lblTel;
        private System.Windows.Forms.Label lblEmpID;
        private System.Windows.Forms.Label lblNational;
        private System.Windows.Forms.Label lblPin;
        private System.Windows.Forms.Label lblLname;
        private System.Windows.Forms.Label lblFName;
        private System.Windows.Forms.TextBox txtPost;
        private System.Windows.Forms.TextBox txtTel;
        private System.Windows.Forms.TextBox txtEmpId;
        private System.Windows.Forms.TextBox txtPin;
        private System.Windows.Forms.TextBox txtNational;
        private System.Windows.Forms.TextBox txtLName;
        private System.Windows.Forms.TextBox txtFName;
        private System.Windows.Forms.Label lblPost;
        private DevExpress.XtraEditors.GroupControl GrpAddEmp;
        private DevExpress.XtraEditors.GroupControl GrpctrlEncoder;
        private System.Windows.Forms.GroupBox grpAuthType;
        private System.Windows.Forms.Label lblIDtype;
        private System.Windows.Forms.Label lblCard;
        private System.Windows.Forms.Label lblPintype;
        private System.Windows.Forms.Label lblFingerType;
        private System.Windows.Forms.Label lbl3;
        private System.Windows.Forms.Label lbl2;
        private System.Windows.Forms.Label lbl1;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.PictureBox pictureEmployee;
        public DevExpress.XtraTab.XtraTabControl xtraTab;
        private System.Windows.Forms.Label lblNationalErr;
        private System.Windows.Forms.Label lblEmpIdErr;
        private System.Windows.Forms.PictureBox LeftHand;
        private System.Windows.Forms.Label lbl;
        private System.Windows.Forms.ComboBox cmbbxSelectEncoder;
        private System.Windows.Forms.GroupBox grpEcoder;
        private System.Windows.Forms.PictureBox RightHand;
        private System.Windows.Forms.GroupBox GrpFinger;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbland2;
        private System.Windows.Forms.Label lblAnd1;
        private System.Windows.Forms.Label lblAnd;
        private System.Windows.Forms.PictureBox picExistCard;
        private System.Windows.Forms.TextBox txtRePin;
        private System.Windows.Forms.Label lblRePin;
        private DevExpress.XtraEditors.SimpleButton btnCancelEmp;
        private DevExpress.XtraEditors.SimpleButton btnApply;
        private DevExpress.XtraEditors.SimpleButton btnSaveEmp;
        private DevExpress.XtraEditors.SimpleButton btnEdit;
        private DevExpress.XtraEditors.SimpleButton BtnBrows;
        private DevExpress.XtraEditors.SimpleButton btnEncode;
        private DevExpress.XtraEditors.SimpleButton btnDeleteCard;
        private System.Windows.Forms.GroupBox grpMenuAccess;
        private System.Windows.Forms.CheckBox chkDeviceMenu;
        private System.Windows.Forms.CheckBox chkOperatorMenu;
        private System.Windows.Forms.CheckBox chkNetworkMenu;
        private System.Windows.Forms.Label lblDeviceMenu;
        private System.Windows.Forms.Label lblOperatorMenu;
        private System.Windows.Forms.Label LblNetworkMenu;
        private System.Windows.Forms.PictureBox waiting;
        private System.Windows.Forms.GroupBox grpEncoder;
        private DevExpress.XtraTab.XtraTabPage TabInfoDevices;
        private DevExpress.XtraEditors.GroupControl GrpctrInfoDevices;
        private DevExpress.XtraGrid.GridControl gridDeviceInfo;
        private DevExpress.XtraGrid.Views.Grid.GridView GrdInfoInDevices;
        private DevExpress.XtraGrid.Columns.GridColumn ColID;
        private DevExpress.XtraGrid.Columns.GridColumn ColNameDevices;
        private DevExpress.XtraGrid.Columns.GridColumn ColIp;
        private DevExpress.XtraGrid.Columns.GridColumn ColFinger;
        private DevExpress.XtraGrid.Columns.GridColumn ColPic;
        private DevExpress.XtraGrid.Columns.GridColumn ColDB;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit chkEditDB;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit btnFingers;
        private DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit FigerLink;
        private DevExpress.XtraGrid.Columns.GridColumn ColDeviceID;
        private DevExpress.XtraEditors.SimpleButton BtnSend;
        private DevExpress.XtraWaitForm.ProgressPanel progressPanel;
        private System.Windows.Forms.GroupBox GrpOrganization;
        private Telerik.WinControls.UI.RadTreeView TreeOrganization;
        private System.Windows.Forms.GroupBox GrpPvInfo;
        private DevExpress.XtraEditors.SimpleButton btnConnect;
        private Telerik.WinControls.RadThemeManager radThemeManager1;
        private System.Windows.Forms.ComboBox cmbAcsGroup;
        private System.Windows.Forms.CheckBox chkPrivateAccess;
        private System.Windows.Forms.GroupBox GrpPalm;
        private System.Windows.Forms.GroupBox grpFace;
        private System.Windows.Forms.PictureBox PicBox;
        private System.Windows.Forms.PictureBox pictureBox2;
        private DevExpress.XtraEditors.SimpleButton btnGetPalm;
        private DevExpress.XtraEditors.SimpleButton btnGetFace;
        private DevExpress.XtraEditors.SimpleButton BtnSendFace;
        private System.Windows.Forms.GroupBox DeviceType;
        private System.Windows.Forms.RadioButton rdbtnEco;
        private System.Windows.Forms.RadioButton rdbtnZk;
        private System.Windows.Forms.RadioButton rdbtnRaya;
        private System.Windows.Forms.GroupBox grpAuthTypeForZk;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox VerfiCombo;
        private System.Windows.Forms.CheckBox chkAuth;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rdbAdmin;
        private System.Windows.Forms.RadioButton rdbUser;
        private DevExpress.XtraEditors.SimpleButton btnSetPrivateAccessGroup;
    }
}