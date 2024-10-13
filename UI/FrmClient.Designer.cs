namespace Eco
{
    partial class FrmClient
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
            this.GrpDefineClient = new DevExpress.XtraEditors.GroupControl();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.GridClient = new DevExpress.XtraGrid.GridControl();
            this.grdClient = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.ClientName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ClientIP = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ClientPort = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ServerIP = new DevExpress.XtraGrid.Columns.GridColumn();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.BtnSave = new DevExpress.XtraEditors.SimpleButton();
            this.txtServerIp = new System.Windows.Forms.TextBox();
            this.txtPCIP = new System.Windows.Forms.TextBox();
            this.txtPCName = new System.Windows.Forms.TextBox();
            this.lblServerIp = new System.Windows.Forms.Label();
            this.lblClientIP = new System.Windows.Forms.Label();
            this.lblComputerName = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.GrpDefineClient)).BeginInit();
            this.GrpDefineClient.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GridClient)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdClient)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // GrpDefineClient
            // 
            this.GrpDefineClient.Controls.Add(this.groupBox2);
            this.GrpDefineClient.Controls.Add(this.groupBox1);
            this.GrpDefineClient.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GrpDefineClient.Location = new System.Drawing.Point(0, 0);
            this.GrpDefineClient.Name = "GrpDefineClient";
            this.GrpDefineClient.Size = new System.Drawing.Size(720, 328);
            this.GrpDefineClient.TabIndex = 0;
            this.GrpDefineClient.Text = "تعریف کلاینت";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.GridClient);
            this.groupBox2.Location = new System.Drawing.Point(256, 23);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(459, 302);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "کامپیوتر های متصل به سرور";
            // 
            // GridClient
            // 
            this.GridClient.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GridClient.Location = new System.Drawing.Point(3, 17);
            this.GridClient.MainView = this.grdClient;
            this.GridClient.Name = "GridClient";
            this.GridClient.Size = new System.Drawing.Size(453, 282);
            this.GridClient.TabIndex = 1;
            this.GridClient.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grdClient});
            // 
            // grdClient
            // 
            this.grdClient.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.grdClient.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grdClient.Appearance.HeaderPanel.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grdClient.Appearance.Row.Options.UseTextOptions = true;
            this.grdClient.Appearance.Row.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grdClient.Appearance.Row.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grdClient.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.ClientName,
            this.ClientIP,
            this.ClientPort,
            this.ServerIP});
            this.grdClient.GridControl = this.GridClient;
            this.grdClient.Name = "grdClient";
            this.grdClient.OptionsBehavior.Editable = false;
            this.grdClient.OptionsFind.AlwaysVisible = true;
            this.grdClient.OptionsFind.FindDelay = 100;
            this.grdClient.OptionsFind.FindNullPrompt = "مورد جست و جو را در این قسمت بنویسید ...";
            this.grdClient.OptionsFind.ShowClearButton = false;
            this.grdClient.OptionsFind.ShowCloseButton = false;
            this.grdClient.RowClick += new DevExpress.XtraGrid.Views.Grid.RowClickEventHandler(this.grdClient_RowClick);
            // 
            // ClientName
            // 
            this.ClientName.Caption = "نام کامپیوتر";
            this.ClientName.FieldName = "ClientName";
            this.ClientName.Name = "ClientName";
            this.ClientName.OptionsColumn.AllowSize = false;
            this.ClientName.Visible = true;
            this.ClientName.VisibleIndex = 0;
            // 
            // ClientIP
            // 
            this.ClientIP.Caption = "آدرس شبکه";
            this.ClientIP.FieldName = "ClientIP";
            this.ClientIP.Name = "ClientIP";
            this.ClientIP.OptionsColumn.AllowSize = false;
            this.ClientIP.Visible = true;
            this.ClientIP.VisibleIndex = 1;
            // 
            // ClientPort
            // 
            this.ClientPort.Caption = "پورت کامپیوتر";
            this.ClientPort.FieldName = "ClientPort";
            this.ClientPort.Name = "ClientPort";
            this.ClientPort.OptionsColumn.AllowSize = false;
            this.ClientPort.Visible = true;
            this.ClientPort.VisibleIndex = 2;
            // 
            // ServerIP
            // 
            this.ServerIP.Caption = "آدرس شبکه سرور";
            this.ServerIP.FieldName = "ServerIP";
            this.ServerIP.Name = "ServerIP";
            this.ServerIP.OptionsColumn.AllowSize = false;
            this.ServerIP.OptionsColumn.ReadOnly = true;
            this.ServerIP.Visible = true;
            this.ServerIP.VisibleIndex = 3;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnCancel);
            this.groupBox1.Controls.Add(this.BtnSave);
            this.groupBox1.Controls.Add(this.txtServerIp);
            this.groupBox1.Controls.Add(this.txtPCIP);
            this.groupBox1.Controls.Add(this.txtPCName);
            this.groupBox1.Controls.Add(this.lblServerIp);
            this.groupBox1.Controls.Add(this.lblClientIP);
            this.groupBox1.Controls.Add(this.lblComputerName);
            this.groupBox1.Location = new System.Drawing.Point(3, 23);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(247, 302);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "تعریف کامپیوتر";
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(90, 270);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 9;
            this.btnCancel.Text = "لغو";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // BtnSave
            // 
            this.BtnSave.Location = new System.Drawing.Point(9, 270);
            this.BtnSave.Name = "BtnSave";
            this.BtnSave.Size = new System.Drawing.Size(75, 23);
            this.BtnSave.TabIndex = 8;
            this.BtnSave.Text = "ذخیره";
            this.BtnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // txtServerIp
            // 
            this.txtServerIp.Location = new System.Drawing.Point(6, 164);
            this.txtServerIp.Name = "txtServerIp";
            this.txtServerIp.Size = new System.Drawing.Size(122, 21);
            this.txtServerIp.TabIndex = 7;
            // 
            // txtPCIP
            // 
            this.txtPCIP.Location = new System.Drawing.Point(6, 118);
            this.txtPCIP.Name = "txtPCIP";
            this.txtPCIP.Size = new System.Drawing.Size(122, 21);
            this.txtPCIP.TabIndex = 5;
            // 
            // txtPCName
            // 
            this.txtPCName.Location = new System.Drawing.Point(6, 74);
            this.txtPCName.Name = "txtPCName";
            this.txtPCName.Size = new System.Drawing.Size(122, 21);
            this.txtPCName.TabIndex = 4;
            // 
            // lblServerIp
            // 
            this.lblServerIp.AutoSize = true;
            this.lblServerIp.Location = new System.Drawing.Point(137, 167);
            this.lblServerIp.Name = "lblServerIp";
            this.lblServerIp.Size = new System.Drawing.Size(94, 13);
            this.lblServerIp.TabIndex = 3;
            this.lblServerIp.Text = "آدرس شبکه سرور:";
            // 
            // lblClientIP
            // 
            this.lblClientIP.AutoSize = true;
            this.lblClientIP.Location = new System.Drawing.Point(137, 121);
            this.lblClientIP.Name = "lblClientIP";
            this.lblClientIP.Size = new System.Drawing.Size(104, 13);
            this.lblClientIP.TabIndex = 1;
            this.lblClientIP.Text = "آدرس شبکه کامپیوتر:";
            // 
            // lblComputerName
            // 
            this.lblComputerName.AutoSize = true;
            this.lblComputerName.Location = new System.Drawing.Point(137, 77);
            this.lblComputerName.Name = "lblComputerName";
            this.lblComputerName.Size = new System.Drawing.Size(62, 13);
            this.lblComputerName.TabIndex = 0;
            this.lblComputerName.Text = "نام کامپیوتر:";
            // 
            // FrmClient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(720, 328);
            this.Controls.Add(this.GrpDefineClient);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmClient";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "تعریف کلاینت";
            this.Load += new System.EventHandler(this.FrmClient_Load);
            ((System.ComponentModel.ISupportInitialize)(this.GrpDefineClient)).EndInit();
            this.GrpDefineClient.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.GridClient)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdClient)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl GrpDefineClient;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox1;
        private DevExpress.XtraGrid.GridControl GridClient;
        private DevExpress.XtraGrid.Views.Grid.GridView grdClient;
        private DevExpress.XtraGrid.Columns.GridColumn ClientName;
        private DevExpress.XtraGrid.Columns.GridColumn ClientIP;
        private DevExpress.XtraGrid.Columns.GridColumn ClientPort;
        private DevExpress.XtraGrid.Columns.GridColumn ServerIP;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private DevExpress.XtraEditors.SimpleButton BtnSave;
        private System.Windows.Forms.TextBox txtServerIp;
        private System.Windows.Forms.TextBox txtPCIP;
        private System.Windows.Forms.TextBox txtPCName;
        private System.Windows.Forms.Label lblServerIp;
        private System.Windows.Forms.Label lblClientIP;
        private System.Windows.Forms.Label lblComputerName;
    }
}