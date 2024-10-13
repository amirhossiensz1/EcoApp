namespace Eco
{
    partial class FrmAccessTypeMenu
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
            this.AccessTypeMenu = new DevExpress.XtraEditors.GroupControl();
            this.btnRemove = new DevExpress.XtraEditors.SimpleButton();
            this.BtnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.btnOk = new DevExpress.XtraEditors.SimpleButton();
            this.cmbAccessType = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.AccessTypeMenu)).BeginInit();
            this.AccessTypeMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // AccessTypeMenu
            // 
            this.AccessTypeMenu.Controls.Add(this.btnRemove);
            this.AccessTypeMenu.Controls.Add(this.BtnCancel);
            this.AccessTypeMenu.Controls.Add(this.btnOk);
            this.AccessTypeMenu.Controls.Add(this.cmbAccessType);
            this.AccessTypeMenu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AccessTypeMenu.Location = new System.Drawing.Point(0, 0);
            this.AccessTypeMenu.Name = "AccessTypeMenu";
            this.AccessTypeMenu.Size = new System.Drawing.Size(184, 90);
            this.AccessTypeMenu.TabIndex = 0;
            this.AccessTypeMenu.Text = "نوع تردد";
            // 
            // btnRemove
            // 
            this.btnRemove.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnRemove.Location = new System.Drawing.Point(66, 56);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(48, 22);
            this.btnRemove.TabIndex = 3;
            this.btnRemove.Text = "حذف";
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // BtnCancel
            // 
            this.BtnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.BtnCancel.Location = new System.Drawing.Point(120, 56);
            this.BtnCancel.Name = "BtnCancel";
            this.BtnCancel.Size = new System.Drawing.Size(48, 22);
            this.BtnCancel.TabIndex = 2;
            this.BtnCancel.Text = "لغو";
            this.BtnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // btnOk
            // 
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.Retry;
            this.btnOk.Location = new System.Drawing.Point(12, 56);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(48, 22);
            this.btnOk.TabIndex = 1;
            this.btnOk.Text = "ثبت";
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // cmbAccessType
            // 
            this.cmbAccessType.BackColor = System.Drawing.SystemColors.Window;
            this.cmbAccessType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAccessType.ForeColor = System.Drawing.SystemColors.InfoText;
            this.cmbAccessType.FormattingEnabled = true;
            this.cmbAccessType.Location = new System.Drawing.Point(12, 23);
            this.cmbAccessType.Name = "cmbAccessType";
            this.cmbAccessType.Size = new System.Drawing.Size(156, 21);
            this.cmbAccessType.TabIndex = 0;
            // 
            // FrmAccessTypeMenu
            // 
            this.AcceptButton = this.btnOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.BtnCancel;
            this.ClientSize = new System.Drawing.Size(184, 90);
            this.Controls.Add(this.AccessTypeMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmAccessTypeMenu";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmDayTypeMenu";
            this.Load += new System.EventHandler(this.FrmAccessTypeMenu_Load);
            ((System.ComponentModel.ISupportInitialize)(this.AccessTypeMenu)).EndInit();
            this.AccessTypeMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl AccessTypeMenu;
        private System.Windows.Forms.ComboBox cmbAccessType;
        private DevExpress.XtraEditors.SimpleButton btnOk;
        private DevExpress.XtraEditors.SimpleButton BtnCancel;
        private DevExpress.XtraEditors.SimpleButton btnRemove;

    }
}