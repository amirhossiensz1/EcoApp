namespace Eco
{
    partial class FrmOrganization
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
            this.GrpOrganization = new DevExpress.XtraEditors.GroupControl();
            this.BtnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.TreeOrganization = new Telerik.WinControls.UI.RadTreeView();
            ((System.ComponentModel.ISupportInitialize)(this.GrpOrganization)).BeginInit();
            this.GrpOrganization.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TreeOrganization)).BeginInit();
            this.SuspendLayout();
            // 
            // GrpOrganization
            // 
            this.GrpOrganization.Controls.Add(this.BtnCancel);
            this.GrpOrganization.Controls.Add(this.TreeOrganization);
            this.GrpOrganization.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GrpOrganization.Location = new System.Drawing.Point(0, 0);
            this.GrpOrganization.Name = "GrpOrganization";
            this.GrpOrganization.Size = new System.Drawing.Size(408, 569);
            this.GrpOrganization.TabIndex = 0;
            this.GrpOrganization.Text = "چارت سازمانی";
            // 
            // BtnCancel
            // 
            this.BtnCancel.Location = new System.Drawing.Point(5, 538);
            this.BtnCancel.Name = "BtnCancel";
            this.BtnCancel.Size = new System.Drawing.Size(56, 26);
            this.BtnCancel.TabIndex = 1;
            this.BtnCancel.Text = "لغو";
            this.BtnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // TreeOrganization
            // 
            this.TreeOrganization.AllowAdd = true;
            this.TreeOrganization.AllowDefaultContextMenu = true;
            this.TreeOrganization.AllowDragDrop = true;
            this.TreeOrganization.AllowEdit = true;
            this.TreeOrganization.AllowRemove = true;
            this.TreeOrganization.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(236)))), ((int)(((byte)(239)))));
            this.TreeOrganization.ChildMember = "ID";
            this.TreeOrganization.Cursor = System.Windows.Forms.Cursors.Default;
            this.TreeOrganization.DisplayMember = "name";
            this.TreeOrganization.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.TreeOrganization.ForeColor = System.Drawing.Color.Black;
            this.TreeOrganization.ItemHeight = 50;
            this.TreeOrganization.LineColor = System.Drawing.Color.Green;
            this.TreeOrganization.LineStyle = Telerik.WinControls.UI.TreeLineStyle.Solid;
            this.TreeOrganization.Location = new System.Drawing.Point(2, 20);
            this.TreeOrganization.Name = "TreeOrganization";
            this.TreeOrganization.ParentMember = "OrganizationID";
            this.TreeOrganization.PathSeparator = "";
            this.TreeOrganization.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.TreeOrganization.ShowLines = true;
            this.TreeOrganization.Size = new System.Drawing.Size(403, 512);
            this.TreeOrganization.SpacingBetweenNodes = 1;
            this.TreeOrganization.TabIndex = 0;
            this.TreeOrganization.ToggleMode = Telerik.WinControls.UI.ToggleMode.SingleClick;
            this.TreeOrganization.ValueMember = "⁯ID";
            this.TreeOrganization.Edited += new Telerik.WinControls.UI.TreeNodeEditedEventHandler(this.TreeOrganization_Edited);
            this.TreeOrganization.CreateNodeElement += new Telerik.WinControls.UI.CreateTreeNodeElementEventHandler(this.TreeOrganization_CreateNodeElement);
            this.TreeOrganization.ContextMenuOpening += new Telerik.WinControls.UI.TreeViewContextMenuOpeningEventHandler(this.TreeOrganization_ContextMenuOpening);
            this.TreeOrganization.NodeRemoving += new Telerik.WinControls.UI.RadTreeView.RadTreeViewCancelEventHandler(this.TreeOrganization_NodeRemoving);
            this.TreeOrganization.NodeAdded += new Telerik.WinControls.UI.RadTreeView.RadTreeViewEventHandler(this.TreeOrganization_NodeAdded);
            this.TreeOrganization.DragDrop += new System.Windows.Forms.DragEventHandler(this.TreeOrganization_DragDrop);
            ((Telerik.WinControls.UI.RadTreeViewElement)(this.TreeOrganization.GetChildAt(0))).ShowExpandCollapse = true;
            ((Telerik.WinControls.UI.RadTreeViewElement)(this.TreeOrganization.GetChildAt(0))).ItemHeight = 50;
            ((Telerik.WinControls.UI.RadTreeViewElement)(this.TreeOrganization.GetChildAt(0))).ShowLines = true;
            ((Telerik.WinControls.UI.RadTreeViewElement)(this.TreeOrganization.GetChildAt(0))).ShowRootLines = true;
            ((Telerik.WinControls.UI.RadTreeViewElement)(this.TreeOrganization.GetChildAt(0))).LineColor = System.Drawing.Color.Green;
            ((Telerik.WinControls.UI.RadTreeViewElement)(this.TreeOrganization.GetChildAt(0))).LineStyle = Telerik.WinControls.UI.TreeLineStyle.Solid;
            ((Telerik.WinControls.UI.RadTreeViewElement)(this.TreeOrganization.GetChildAt(0))).TreeIndent = 20;
            ((Telerik.WinControls.UI.RadTreeViewElement)(this.TreeOrganization.GetChildAt(0))).FullRowSelect = true;
            ((Telerik.WinControls.UI.RadTreeViewElement)(this.TreeOrganization.GetChildAt(0))).NodeSpacing = 1;
            ((Telerik.WinControls.UI.RadTreeViewElement)(this.TreeOrganization.GetChildAt(0))).BorderColor = System.Drawing.SystemColors.ControlDark;
            ((Telerik.WinControls.UI.RadTreeViewElement)(this.TreeOrganization.GetChildAt(0))).BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(236)))), ((int)(((byte)(239)))));
            ((Telerik.WinControls.UI.RadTreeViewElement)(this.TreeOrganization.GetChildAt(0))).AutoSizeMode = Telerik.WinControls.RadAutoSizeMode.Auto;
            ((Telerik.WinControls.UI.RadTreeViewVirtualizedContainer)(this.TreeOrganization.GetChildAt(0).GetChildAt(0))).ShouldPaint = false;
            // 
            // FrmOrganization
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(408, 569);
            this.Controls.Add(this.GrpOrganization);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmOrganization";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmOrganization";
            this.Load += new System.EventHandler(this.FrmOrganization_Load);
            ((System.ComponentModel.ISupportInitialize)(this.GrpOrganization)).EndInit();
            this.GrpOrganization.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.TreeOrganization)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl GrpOrganization;
        private Telerik.WinControls.UI.RadTreeView TreeOrganization;
        private DevExpress.XtraEditors.SimpleButton BtnCancel;
    }
}