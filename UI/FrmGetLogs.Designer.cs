namespace Eco
{
    partial class FrmGetLogs
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
            this.txtFRomDate = new System.Windows.Forms.MaskedTextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblFromDate = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtToDate = new System.Windows.Forms.MaskedTextBox();
            this.BtnGet = new DevExpress.XtraEditors.SimpleButton();
            this.cmbbxSelectEncoder = new System.Windows.Forms.ComboBox();
            this.lbl = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtFRomDate
            // 
            this.txtFRomDate.Location = new System.Drawing.Point(286, 26);
            this.txtFRomDate.Mask = "0000/00/00";
            this.txtFRomDate.Name = "txtFRomDate";
            this.txtFRomDate.Size = new System.Drawing.Size(88, 20);
            this.txtFRomDate.TabIndex = 0;
            this.txtFRomDate.ValidatingType = typeof(System.DateTime);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cmbbxSelectEncoder);
            this.groupBox1.Controls.Add(this.lbl);
            this.groupBox1.Controls.Add(this.BtnGet);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtToDate);
            this.groupBox1.Controls.Add(this.lblFromDate);
            this.groupBox1.Controls.Add(this.txtFRomDate);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(438, 131);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "دریافت لاگها از دستگاه";
            // 
            // lblFromDate
            // 
            this.lblFromDate.AutoSize = true;
            this.lblFromDate.Location = new System.Drawing.Point(380, 29);
            this.lblFromDate.Name = "lblFromDate";
            this.lblFromDate.Size = new System.Drawing.Size(46, 13);
            this.lblFromDate.TabIndex = 1;
            this.lblFromDate.Text = "از تاریخ:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(204, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "تا تاریخ:";
            // 
            // txtToDate
            // 
            this.txtToDate.Location = new System.Drawing.Point(109, 26);
            this.txtToDate.Mask = "0000/00/00";
            this.txtToDate.Name = "txtToDate";
            this.txtToDate.Size = new System.Drawing.Size(89, 20);
            this.txtToDate.TabIndex = 2;
            this.txtToDate.ValidatingType = typeof(System.DateTime);
            // 
            // BtnGet
            // 
            this.BtnGet.Location = new System.Drawing.Point(12, 96);
            this.BtnGet.Name = "BtnGet";
            this.BtnGet.Size = new System.Drawing.Size(69, 23);
            this.BtnGet.TabIndex = 23;
            this.BtnGet.Text = "دریافت";
            this.BtnGet.Click += new System.EventHandler(this.BtnGet_Click);
            // 
            // cmbbxSelectEncoder
            // 
            this.cmbbxSelectEncoder.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbbxSelectEncoder.FormattingEnabled = true;
            this.cmbbxSelectEncoder.Location = new System.Drawing.Point(189, 58);
            this.cmbbxSelectEncoder.Name = "cmbbxSelectEncoder";
            this.cmbbxSelectEncoder.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cmbbxSelectEncoder.Size = new System.Drawing.Size(185, 21);
            this.cmbbxSelectEncoder.TabIndex = 25;
            // 
            // lbl
            // 
            this.lbl.AutoSize = true;
            this.lbl.Location = new System.Drawing.Point(380, 63);
            this.lbl.Name = "lbl";
            this.lbl.Size = new System.Drawing.Size(45, 13);
            this.lbl.TabIndex = 26;
            this.lbl.Text = "دستگاه:";
            // 
            // FrmGetLogs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(438, 131);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FrmGetLogs";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "دریافت لاگ از دستگاه";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.MaskedTextBox txtFRomDate;
        private System.Windows.Forms.GroupBox groupBox1;
        private DevExpress.XtraEditors.SimpleButton BtnGet;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.MaskedTextBox txtToDate;
        private System.Windows.Forms.Label lblFromDate;
        private System.Windows.Forms.ComboBox cmbbxSelectEncoder;
        private System.Windows.Forms.Label lbl;
    }
}