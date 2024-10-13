namespace Eco
{
    partial class FrmSelectAccessGroup
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
            this.cmbAcsGroup = new System.Windows.Forms.ComboBox();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.btnOk = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.GrpAccessGroup)).BeginInit();
            this.GrpAccessGroup.SuspendLayout();
            this.SuspendLayout();
            // 
            // GrpAccessGroup
            // 
            this.GrpAccessGroup.Controls.Add(this.cmbAcsGroup);
            this.GrpAccessGroup.Controls.Add(this.btnCancel);
            this.GrpAccessGroup.Controls.Add(this.btnOk);
            this.GrpAccessGroup.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GrpAccessGroup.Location = new System.Drawing.Point(0, 0);
            this.GrpAccessGroup.Name = "GrpAccessGroup";
            this.GrpAccessGroup.Size = new System.Drawing.Size(176, 95);
            this.GrpAccessGroup.TabIndex = 0;
            this.GrpAccessGroup.Text = "انتخاب گروه دسترسی";
            // 
            // cmbAcsGroup
            // 
            this.cmbAcsGroup.DisplayMember = "Name";
            this.cmbAcsGroup.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAcsGroup.FormattingEnabled = true;
            this.cmbAcsGroup.Location = new System.Drawing.Point(12, 33);
            this.cmbAcsGroup.Name = "cmbAcsGroup";
            this.cmbAcsGroup.Size = new System.Drawing.Size(152, 21);
            this.cmbAcsGroup.TabIndex = 2;
            this.cmbAcsGroup.ValueMember = "ID";
            this.cmbAcsGroup.SelectionChangeCommitted += new System.EventHandler(this.cmbAcsGroup_SelectionChangeCommitted);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(108, 60);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(56, 23);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "لغو";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(12, 60);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(56, 23);
            this.btnOk.TabIndex = 0;
            this.btnOk.Text = "ثبت";
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // FrmSelectAccessGroup
            // 
            this.AcceptButton = this.btnOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(176, 95);
            this.Controls.Add(this.GrpAccessGroup);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmSelectAccessGroup";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "انتخاب گروه دسترسی";
            this.Load += new System.EventHandler(this.FrmSelectAccessGroup_Load);
            ((System.ComponentModel.ISupportInitialize)(this.GrpAccessGroup)).EndInit();
            this.GrpAccessGroup.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl GrpAccessGroup;
        private System.Windows.Forms.ComboBox cmbAcsGroup;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private DevExpress.XtraEditors.SimpleButton btnOk;
    }
}