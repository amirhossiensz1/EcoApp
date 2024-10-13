namespace UI
{
    partial class FrmAddDevice
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmAddDevice));
            this.lblDeviceName = new System.Windows.Forms.Label();
            this.lblDeviceIP = new System.Windows.Forms.Label();
            this.lblDevicePort = new System.Windows.Forms.Label();
            this.txtBxDeviceName = new System.Windows.Forms.TextBox();
            this.txtBxDevicePort = new System.Windows.Forms.TextBox();
            this.PicEcho = new DevExpress.XtraEditors.PictureEdit();
            this.lblIPAddress = new System.Windows.Forms.Label();
            this.txtBxDeviceIP = new System.Windows.Forms.TextBox();
            this.lblFTPPort = new System.Windows.Forms.Label();
            this.txtBxFtpPort = new System.Windows.Forms.TextBox();
            this.GrpAddDevice = new DevExpress.XtraEditors.GroupControl();
            this.btnEdit = new DevExpress.XtraEditors.SimpleButton();
            this.btnSave = new DevExpress.XtraEditors.SimpleButton();
            this.grpActivation = new System.Windows.Forms.GroupBox();
            this.txtBxActivation = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtwebpass = new System.Windows.Forms.TextBox();
            this.txtwebuser = new System.Windows.Forms.TextBox();
            this.lblRegistration = new System.Windows.Forms.Label();
            this.txtBxRegistrationCode = new System.Windows.Forms.TextBox();
            this.lblActivation = new System.Windows.Forms.Label();
            this.grpBasicInfo = new System.Windows.Forms.GroupBox();
            this.lblType = new System.Windows.Forms.Label();
            this.cmbType = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtBxIpServer = new System.Windows.Forms.TextBox();
            this.txtBxSerial = new System.Windows.Forms.TextBox();
            this.lblSerial = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.PicEcho.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrpAddDevice)).BeginInit();
            this.GrpAddDevice.SuspendLayout();
            this.grpActivation.SuspendLayout();
            this.grpBasicInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblDeviceName
            // 
            this.lblDeviceName.AutoSize = true;
            this.lblDeviceName.Location = new System.Drawing.Point(197, 54);
            this.lblDeviceName.Name = "lblDeviceName";
            this.lblDeviceName.Size = new System.Drawing.Size(64, 13);
            this.lblDeviceName.TabIndex = 0;
            this.lblDeviceName.Text = "نام دستگاه :";
            // 
            // lblDeviceIP
            // 
            this.lblDeviceIP.AutoSize = true;
            this.lblDeviceIP.Location = new System.Drawing.Point(152, 87);
            this.lblDeviceIP.Name = "lblDeviceIP";
            this.lblDeviceIP.Size = new System.Drawing.Size(109, 13);
            this.lblDeviceIP.TabIndex = 1;
            this.lblDeviceIP.Text = "آدرس شبکه دستگاه : ";
            // 
            // lblDevicePort
            // 
            this.lblDevicePort.AutoSize = true;
            this.lblDevicePort.Location = new System.Drawing.Point(167, 159);
            this.lblDevicePort.Name = "lblDevicePort";
            this.lblDevicePort.Size = new System.Drawing.Size(94, 13);
            this.lblDevicePort.TabIndex = 2;
            this.lblDevicePort.Text = "پورت TCP دستگاه :";
            // 
            // txtBxDeviceName
            // 
            this.txtBxDeviceName.Location = new System.Drawing.Point(13, 51);
            this.txtBxDeviceName.MaxLength = 20;
            this.txtBxDeviceName.Name = "txtBxDeviceName";
            this.txtBxDeviceName.Size = new System.Drawing.Size(137, 21);
            this.txtBxDeviceName.TabIndex = 1;
            // 
            // txtBxDevicePort
            // 
            this.txtBxDevicePort.Location = new System.Drawing.Point(13, 156);
            this.txtBxDevicePort.MaxLength = 6;
            this.txtBxDevicePort.Name = "txtBxDevicePort";
            this.txtBxDevicePort.Size = new System.Drawing.Size(137, 21);
            this.txtBxDevicePort.TabIndex = 4;
            // 
            // PicEcho
            // 
            this.PicEcho.Location = new System.Drawing.Point(6, 31);
            this.PicEcho.Name = "PicEcho";
            this.PicEcho.Properties.Appearance.BackColor = System.Drawing.Color.WhiteSmoke;
            this.PicEcho.Properties.Appearance.Options.UseBackColor = true;
            this.PicEcho.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.PicEcho.Properties.ZoomPercent = 120D;
            this.PicEcho.Size = new System.Drawing.Size(102, 96);
            this.PicEcho.TabIndex = 8;
            // 
            // lblIPAddress
            // 
            this.lblIPAddress.AutoSize = true;
            this.lblIPAddress.Location = new System.Drawing.Point(94, 98);
            this.lblIPAddress.Name = "lblIPAddress";
            this.lblIPAddress.Size = new System.Drawing.Size(0, 14);
            this.lblIPAddress.TabIndex = 9;
            // 
            // txtBxDeviceIP
            // 
            this.txtBxDeviceIP.Location = new System.Drawing.Point(13, 86);
            this.txtBxDeviceIP.MaxLength = 16;
            this.txtBxDeviceIP.Name = "txtBxDeviceIP";
            this.txtBxDeviceIP.Size = new System.Drawing.Size(137, 21);
            this.txtBxDeviceIP.TabIndex = 2;
            // 
            // lblFTPPort
            // 
            this.lblFTPPort.AutoSize = true;
            this.lblFTPPort.Location = new System.Drawing.Point(168, 194);
            this.lblFTPPort.Name = "lblFTPPort";
            this.lblFTPPort.Size = new System.Drawing.Size(93, 13);
            this.lblFTPPort.TabIndex = 12;
            this.lblFTPPort.Text = "پورت FTP دستگاه :";
            // 
            // txtBxFtpPort
            // 
            this.txtBxFtpPort.Location = new System.Drawing.Point(13, 191);
            this.txtBxFtpPort.MaxLength = 6;
            this.txtBxFtpPort.Name = "txtBxFtpPort";
            this.txtBxFtpPort.Size = new System.Drawing.Size(137, 21);
            this.txtBxFtpPort.TabIndex = 5;
            // 
            // GrpAddDevice
            // 
            this.GrpAddDevice.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.GrpAddDevice.Controls.Add(this.btnEdit);
            this.GrpAddDevice.Controls.Add(this.btnSave);
            this.GrpAddDevice.Controls.Add(this.grpActivation);
            this.GrpAddDevice.Controls.Add(this.grpBasicInfo);
            this.GrpAddDevice.Controls.Add(this.PicEcho);
            this.GrpAddDevice.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GrpAddDevice.Location = new System.Drawing.Point(0, 0);
            this.GrpAddDevice.Name = "GrpAddDevice";
            this.GrpAddDevice.Size = new System.Drawing.Size(637, 285);
            this.GrpAddDevice.TabIndex = 13;
            this.GrpAddDevice.Text = "اضافه کردن دستگاه";
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(12, 250);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(75, 23);
            this.btnEdit.TabIndex = 24;
            this.btnEdit.Text = "ذخیره";
            this.btnEdit.Visible = false;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(12, 250);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 23;
            this.btnSave.Text = "ذخیره";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click_1);
            // 
            // grpActivation
            // 
            this.grpActivation.Controls.Add(this.txtBxActivation);
            this.grpActivation.Controls.Add(this.label3);
            this.grpActivation.Controls.Add(this.label2);
            this.grpActivation.Controls.Add(this.txtwebpass);
            this.grpActivation.Controls.Add(this.txtwebuser);
            this.grpActivation.Controls.Add(this.lblRegistration);
            this.grpActivation.Controls.Add(this.txtBxRegistrationCode);
            this.grpActivation.Controls.Add(this.lblActivation);
            this.grpActivation.Location = new System.Drawing.Point(112, 22);
            this.grpActivation.Name = "grpActivation";
            this.grpActivation.Size = new System.Drawing.Size(242, 251);
            this.grpActivation.TabIndex = 22;
            this.grpActivation.TabStop = false;
            // 
            // txtBxActivation
            // 
            this.txtBxActivation.Location = new System.Drawing.Point(9, 74);
            this.txtBxActivation.Multiline = true;
            this.txtBxActivation.Name = "txtBxActivation";
            this.txtBxActivation.Size = new System.Drawing.Size(221, 73);
            this.txtBxActivation.TabIndex = 25;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(158, 196);
            this.label3.Name = "label3";
            this.label3.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label3.Size = new System.Drawing.Size(76, 13);
            this.label3.TabIndex = 24;
            this.label3.Text = "کلمه عبور وب :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(162, 164);
            this.label2.Name = "label2";
            this.label2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label2.Size = new System.Drawing.Size(72, 13);
            this.label2.TabIndex = 23;
            this.label2.Text = "کد کاربری وب:";
            // 
            // txtwebpass
            // 
            this.txtwebpass.Location = new System.Drawing.Point(9, 193);
            this.txtwebpass.MaxLength = 8;
            this.txtwebpass.Name = "txtwebpass";
            this.txtwebpass.Size = new System.Drawing.Size(137, 21);
            this.txtwebpass.TabIndex = 22;
            this.txtwebpass.UseSystemPasswordChar = true;
            // 
            // txtwebuser
            // 
            this.txtwebuser.Location = new System.Drawing.Point(9, 161);
            this.txtwebuser.MaxLength = 8;
            this.txtwebuser.Name = "txtwebuser";
            this.txtwebuser.Size = new System.Drawing.Size(137, 21);
            this.txtwebuser.TabIndex = 21;
            // 
            // lblRegistration
            // 
            this.lblRegistration.AutoSize = true;
            this.lblRegistration.Location = new System.Drawing.Point(152, 23);
            this.lblRegistration.Name = "lblRegistration";
            this.lblRegistration.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblRegistration.Size = new System.Drawing.Size(82, 13);
            this.lblRegistration.TabIndex = 19;
            this.lblRegistration.Text = "کد ثبت دستگاه :";
            // 
            // txtBxRegistrationCode
            // 
            this.txtBxRegistrationCode.Location = new System.Drawing.Point(9, 20);
            this.txtBxRegistrationCode.MaxLength = 8;
            this.txtBxRegistrationCode.Name = "txtBxRegistrationCode";
            this.txtBxRegistrationCode.Size = new System.Drawing.Size(137, 21);
            this.txtBxRegistrationCode.TabIndex = 17;
            // 
            // lblActivation
            // 
            this.lblActivation.AutoSize = true;
            this.lblActivation.Location = new System.Drawing.Point(153, 55);
            this.lblActivation.Name = "lblActivation";
            this.lblActivation.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblActivation.Size = new System.Drawing.Size(80, 13);
            this.lblActivation.TabIndex = 20;
            this.lblActivation.Text = "کد فعال سازی :";
            // 
            // grpBasicInfo
            // 
            this.grpBasicInfo.Controls.Add(this.lblType);
            this.grpBasicInfo.Controls.Add(this.cmbType);
            this.grpBasicInfo.Controls.Add(this.label1);
            this.grpBasicInfo.Controls.Add(this.txtBxIpServer);
            this.grpBasicInfo.Controls.Add(this.txtBxDeviceName);
            this.grpBasicInfo.Controls.Add(this.lblDeviceIP);
            this.grpBasicInfo.Controls.Add(this.lblDeviceName);
            this.grpBasicInfo.Controls.Add(this.lblDevicePort);
            this.grpBasicInfo.Controls.Add(this.txtBxDevicePort);
            this.grpBasicInfo.Controls.Add(this.txtBxSerial);
            this.grpBasicInfo.Controls.Add(this.txtBxDeviceIP);
            this.grpBasicInfo.Controls.Add(this.lblSerial);
            this.grpBasicInfo.Controls.Add(this.txtBxFtpPort);
            this.grpBasicInfo.Controls.Add(this.lblFTPPort);
            this.grpBasicInfo.Location = new System.Drawing.Point(360, 23);
            this.grpBasicInfo.Name = "grpBasicInfo";
            this.grpBasicInfo.Size = new System.Drawing.Size(270, 250);
            this.grpBasicInfo.TabIndex = 21;
            this.grpBasicInfo.TabStop = false;
            // 
            // lblType
            // 
            this.lblType.AutoSize = true;
            this.lblType.Location = new System.Drawing.Point(198, 19);
            this.lblType.Name = "lblType";
            this.lblType.Size = new System.Drawing.Size(63, 13);
            this.lblType.TabIndex = 19;
            this.lblType.Text = "نوع دستگاه:";
            // 
            // cmbType
            // 
            this.cmbType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbType.FormattingEnabled = true;
            this.cmbType.Location = new System.Drawing.Point(13, 14);
            this.cmbType.Name = "cmbType";
            this.cmbType.Size = new System.Drawing.Size(137, 21);
            this.cmbType.TabIndex = 18;
            this.cmbType.SelectionChangeCommitted += new System.EventHandler(this.cmbType_SelectionChangeCommitted);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(164, 124);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 13);
            this.label1.TabIndex = 17;
            this.label1.Text = "آدرس شبکه سرور :";
            // 
            // txtBxIpServer
            // 
            this.txtBxIpServer.Location = new System.Drawing.Point(13, 121);
            this.txtBxIpServer.Name = "txtBxIpServer";
            this.txtBxIpServer.Size = new System.Drawing.Size(137, 21);
            this.txtBxIpServer.TabIndex = 3;
            // 
            // txtBxSerial
            // 
            this.txtBxSerial.Location = new System.Drawing.Point(13, 224);
            this.txtBxSerial.MaxLength = 11;
            this.txtBxSerial.Name = "txtBxSerial";
            this.txtBxSerial.Size = new System.Drawing.Size(137, 21);
            this.txtBxSerial.TabIndex = 6;
            // 
            // lblSerial
            // 
            this.lblSerial.AutoSize = true;
            this.lblSerial.Location = new System.Drawing.Point(181, 227);
            this.lblSerial.Name = "lblSerial";
            this.lblSerial.Size = new System.Drawing.Size(80, 13);
            this.lblSerial.TabIndex = 16;
            this.lblSerial.Text = "سریال دستگاه :";
            // 
            // FrmAddDevice
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(637, 285);
            this.Controls.Add(this.GrpAddDevice);
            this.Controls.Add(this.lblIPAddress);
            this.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmAddDevice";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "تعریف دستگاه";
            this.Load += new System.EventHandler(this.FrmAddDevice_Load);
            ((System.ComponentModel.ISupportInitialize)(this.PicEcho.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrpAddDevice)).EndInit();
            this.GrpAddDevice.ResumeLayout(false);
            this.grpActivation.ResumeLayout(false);
            this.grpActivation.PerformLayout();
            this.grpBasicInfo.ResumeLayout(false);
            this.grpBasicInfo.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblDeviceName;
        private System.Windows.Forms.Label lblDeviceIP;
        private System.Windows.Forms.Label lblDevicePort;
        private System.Windows.Forms.TextBox txtBxDeviceName;
        private System.Windows.Forms.TextBox txtBxDevicePort;
        private DevExpress.XtraEditors.PictureEdit PicEcho;
        private System.Windows.Forms.Label lblIPAddress;
        private System.Windows.Forms.TextBox txtBxDeviceIP;
        private System.Windows.Forms.Label lblFTPPort;
        private System.Windows.Forms.TextBox txtBxFtpPort;
        private DevExpress.XtraEditors.GroupControl GrpAddDevice;
        private System.Windows.Forms.TextBox txtBxSerial;
        private System.Windows.Forms.Label lblSerial;
        private System.Windows.Forms.Label lblActivation;
        private System.Windows.Forms.Label lblRegistration;
        private System.Windows.Forms.TextBox txtBxRegistrationCode;
        private System.Windows.Forms.GroupBox grpActivation;
        private System.Windows.Forms.GroupBox grpBasicInfo;
        private DevExpress.XtraEditors.SimpleButton btnSave;
        private DevExpress.XtraEditors.SimpleButton btnEdit;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtBxIpServer;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtwebpass;
        private System.Windows.Forms.TextBox txtwebuser;
        private System.Windows.Forms.TextBox txtBxActivation;
        private System.Windows.Forms.Label lblType;
        private System.Windows.Forms.ComboBox cmbType;
    }
}