namespace UI
{
    partial class FrmAddGuest
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmAddGuest));
            this.GrpDefineGuest = new DevExpress.XtraEditors.GroupControl();
            this.cmbEncoder = new System.Windows.Forms.ComboBox();
            this.lblSelectedEncoder = new System.Windows.Forms.Label();
            this.grpGroups = new System.Windows.Forms.GroupBox();
            this.BtnRecieve = new DevExpress.XtraEditors.SimpleButton();
            this.CounterTo = new System.Windows.Forms.NumericUpDown();
            this.CounterFrom = new System.Windows.Forms.NumericUpDown();
            this.BtnGroupStart = new DevExpress.XtraEditors.SimpleButton();
            this.lblTo = new System.Windows.Forms.Label();
            this.lblFrom = new System.Windows.Forms.Label();
            this.gridViewGuest = new DevExpress.XtraGrid.GridControl();
            this.grdviewGuest = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.NameCol = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CardNumber = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Progressbar = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ProgressBarCard = new DevExpress.XtraEditors.Repository.RepositoryItemProgressBar();
            this.CardProgressBar = new DevExpress.XtraEditors.Repository.RepositoryItemProgressBar();
            this.lblTypeEncode = new System.Windows.Forms.Label();
            this.cmbSelectType = new System.Windows.Forms.ComboBox();
            this.GrpIndivitual = new System.Windows.Forms.GroupBox();
            this.btnGet = new DevExpress.XtraEditors.SimpleButton();
            this.CounterCardNumber = new System.Windows.Forms.NumericUpDown();
            this.BtnIndivitualStart = new DevExpress.XtraEditors.SimpleButton();
            this.lblCardNumber = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.GrpDefineGuest)).BeginInit();
            this.GrpDefineGuest.SuspendLayout();
            this.grpGroups.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CounterTo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CounterFrom)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewGuest)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdviewGuest)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ProgressBarCard)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CardProgressBar)).BeginInit();
            this.GrpIndivitual.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CounterCardNumber)).BeginInit();
            this.SuspendLayout();
            // 
            // GrpDefineGuest
            // 
            this.GrpDefineGuest.Controls.Add(this.cmbEncoder);
            this.GrpDefineGuest.Controls.Add(this.lblSelectedEncoder);
            this.GrpDefineGuest.Controls.Add(this.gridViewGuest);
            this.GrpDefineGuest.Controls.Add(this.lblTypeEncode);
            this.GrpDefineGuest.Controls.Add(this.cmbSelectType);
            this.GrpDefineGuest.Controls.Add(this.GrpIndivitual);
            this.GrpDefineGuest.Controls.Add(this.grpGroups);
            this.GrpDefineGuest.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GrpDefineGuest.Location = new System.Drawing.Point(0, 0);
            this.GrpDefineGuest.Name = "GrpDefineGuest";
            this.GrpDefineGuest.Size = new System.Drawing.Size(457, 346);
            this.GrpDefineGuest.TabIndex = 0;
            this.GrpDefineGuest.Text = "تعریف کارت مهمان";
            // 
            // cmbEncoder
            // 
            this.cmbEncoder.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEncoder.FormattingEnabled = true;
            this.cmbEncoder.Location = new System.Drawing.Point(11, 32);
            this.cmbEncoder.Name = "cmbEncoder";
            this.cmbEncoder.Size = new System.Drawing.Size(121, 21);
            this.cmbEncoder.TabIndex = 5;
            // 
            // lblSelectedEncoder
            // 
            this.lblSelectedEncoder.AutoSize = true;
            this.lblSelectedEncoder.Location = new System.Drawing.Point(138, 35);
            this.lblSelectedEncoder.Name = "lblSelectedEncoder";
            this.lblSelectedEncoder.Size = new System.Drawing.Size(65, 13);
            this.lblSelectedEncoder.TabIndex = 4;
            this.lblSelectedEncoder.Text = "اتنخاب انکدر:";
            // 
            // grpGroups
            // 
            this.grpGroups.Controls.Add(this.BtnRecieve);
            this.grpGroups.Controls.Add(this.CounterTo);
            this.grpGroups.Controls.Add(this.CounterFrom);
            this.grpGroups.Controls.Add(this.BtnGroupStart);
            this.grpGroups.Controls.Add(this.lblTo);
            this.grpGroups.Controls.Add(this.lblFrom);
            this.grpGroups.Location = new System.Drawing.Point(5, 58);
            this.grpGroups.Name = "grpGroups";
            this.grpGroups.Size = new System.Drawing.Size(449, 80);
            this.grpGroups.TabIndex = 2;
            this.grpGroups.TabStop = false;
            this.grpGroups.Text = "گروهی";
            // 
            // BtnRecieve
            // 
            this.BtnRecieve.Location = new System.Drawing.Point(72, 31);
            this.BtnRecieve.Name = "BtnRecieve";
            this.BtnRecieve.Size = new System.Drawing.Size(59, 23);
            this.BtnRecieve.TabIndex = 7;
            this.BtnRecieve.Text = "دریافت";
            this.BtnRecieve.Click += new System.EventHandler(this.BtnRecieve_Click);
            // 
            // CounterTo
            // 
            this.CounterTo.Location = new System.Drawing.Point(148, 33);
            this.CounterTo.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.CounterTo.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.CounterTo.Name = "CounterTo";
            this.CounterTo.Size = new System.Drawing.Size(120, 21);
            this.CounterTo.TabIndex = 6;
            this.CounterTo.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // CounterFrom
            // 
            this.CounterFrom.Location = new System.Drawing.Point(294, 33);
            this.CounterFrom.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.CounterFrom.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.CounterFrom.Name = "CounterFrom";
            this.CounterFrom.Size = new System.Drawing.Size(120, 21);
            this.CounterFrom.TabIndex = 5;
            this.CounterFrom.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // BtnGroupStart
            // 
            this.BtnGroupStart.Location = new System.Drawing.Point(7, 30);
            this.BtnGroupStart.Name = "BtnGroupStart";
            this.BtnGroupStart.Size = new System.Drawing.Size(59, 23);
            this.BtnGroupStart.TabIndex = 4;
            this.BtnGroupStart.Text = "شروع";
            this.BtnGroupStart.Click += new System.EventHandler(this.BtnGroupStart_Click);
            // 
            // lblTo
            // 
            this.lblTo.AutoSize = true;
            this.lblTo.Location = new System.Drawing.Point(274, 35);
            this.lblTo.Name = "lblTo";
            this.lblTo.Size = new System.Drawing.Size(17, 13);
            this.lblTo.TabIndex = 3;
            this.lblTo.Text = "تا:";
            // 
            // lblFrom
            // 
            this.lblFrom.AutoSize = true;
            this.lblFrom.Location = new System.Drawing.Point(417, 35);
            this.lblFrom.Name = "lblFrom";
            this.lblFrom.Size = new System.Drawing.Size(18, 13);
            this.lblFrom.TabIndex = 2;
            this.lblFrom.Text = "از:";
            // 
            // gridViewGuest
            // 
            this.gridViewGuest.Location = new System.Drawing.Point(1, 144);
            this.gridViewGuest.MainView = this.grdviewGuest;
            this.gridViewGuest.Name = "gridViewGuest";
            this.gridViewGuest.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.CardProgressBar,
            this.ProgressBarCard});
            this.gridViewGuest.Size = new System.Drawing.Size(453, 201);
            this.gridViewGuest.TabIndex = 3;
            this.gridViewGuest.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grdviewGuest});
            // 
            // grdviewGuest
            // 
            this.grdviewGuest.AppearancePrint.Row.Options.UseTextOptions = true;
            this.grdviewGuest.AppearancePrint.Row.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grdviewGuest.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.NameCol,
            this.CardNumber,
            this.Progressbar});
            this.grdviewGuest.GridControl = this.gridViewGuest;
            this.grdviewGuest.Name = "grdviewGuest";
            this.grdviewGuest.OptionsBehavior.Editable = false;
            this.grdviewGuest.OptionsBehavior.ReadOnly = true;
            // 
            // NameCol
            // 
            this.NameCol.Caption = "نام";
            this.NameCol.FieldName = "Name";
            this.NameCol.Name = "NameCol";
            this.NameCol.OptionsColumn.AllowEdit = false;
            this.NameCol.OptionsColumn.AllowSize = false;
            this.NameCol.Visible = true;
            this.NameCol.VisibleIndex = 0;
            this.NameCol.Width = 113;
            // 
            // CardNumber
            // 
            this.CardNumber.Caption = "شماره کارت";
            this.CardNumber.FieldName = "CardNumberStr";
            this.CardNumber.Name = "CardNumber";
            this.CardNumber.Visible = true;
            this.CardNumber.VisibleIndex = 1;
            this.CardNumber.Width = 151;
            // 
            // Progressbar
            // 
            this.Progressbar.Caption = "در صد پیشرفت";
            this.Progressbar.ColumnEdit = this.ProgressBarCard;
            this.Progressbar.FieldName = "ID";
            this.Progressbar.Name = "Progressbar";
            this.Progressbar.Visible = true;
            this.Progressbar.VisibleIndex = 2;
            this.Progressbar.Width = 292;
            // 
            // ProgressBarCard
            // 
            this.ProgressBarCard.FlowAnimationEnabled = true;
            this.ProgressBarCard.Name = "ProgressBarCard";
            this.ProgressBarCard.ProgressViewStyle = DevExpress.XtraEditors.Controls.ProgressViewStyle.Solid;
            this.ProgressBarCard.ReadOnly = true;
            // 
            // CardProgressBar
            // 
            this.CardProgressBar.Name = "CardProgressBar";
            // 
            // lblTypeEncode
            // 
            this.lblTypeEncode.AutoSize = true;
            this.lblTypeEncode.Location = new System.Drawing.Point(360, 35);
            this.lblTypeEncode.Name = "lblTypeEncode";
            this.lblTypeEncode.Size = new System.Drawing.Size(94, 13);
            this.lblTypeEncode.TabIndex = 1;
            this.lblTypeEncode.Text = "نحوه کد کردن کارت:";
            this.lblTypeEncode.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cmbSelectType
            // 
            this.cmbSelectType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSelectType.FormattingEnabled = true;
            this.cmbSelectType.Location = new System.Drawing.Point(233, 32);
            this.cmbSelectType.Name = "cmbSelectType";
            this.cmbSelectType.Size = new System.Drawing.Size(121, 21);
            this.cmbSelectType.TabIndex = 0;
            this.cmbSelectType.SelectionChangeCommitted += new System.EventHandler(this.cmbSelectType_SelectionChangeCommitted);
            // 
            // GrpIndivitual
            // 
            this.GrpIndivitual.Controls.Add(this.btnGet);
            this.GrpIndivitual.Controls.Add(this.CounterCardNumber);
            this.GrpIndivitual.Controls.Add(this.BtnIndivitualStart);
            this.GrpIndivitual.Controls.Add(this.lblCardNumber);
            this.GrpIndivitual.Location = new System.Drawing.Point(5, 59);
            this.GrpIndivitual.Name = "GrpIndivitual";
            this.GrpIndivitual.Size = new System.Drawing.Size(449, 79);
            this.GrpIndivitual.TabIndex = 0;
            this.GrpIndivitual.TabStop = false;
            this.GrpIndivitual.Text = "انتخابی";
            this.GrpIndivitual.Visible = false;
            // 
            // btnGet
            // 
            this.btnGet.Location = new System.Drawing.Point(98, 30);
            this.btnGet.Name = "btnGet";
            this.btnGet.Size = new System.Drawing.Size(84, 23);
            this.btnGet.TabIndex = 8;
            this.btnGet.Text = "دریافت";
            this.btnGet.Visible = false;
            this.btnGet.Click += new System.EventHandler(this.BtnGet_Click);
            // 
            // CounterCardNumber
            // 
            this.CounterCardNumber.Location = new System.Drawing.Point(247, 33);
            this.CounterCardNumber.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.CounterCardNumber.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.CounterCardNumber.Name = "CounterCardNumber";
            this.CounterCardNumber.Size = new System.Drawing.Size(120, 21);
            this.CounterCardNumber.TabIndex = 7;
            this.CounterCardNumber.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // BtnIndivitualStart
            // 
            this.BtnIndivitualStart.Location = new System.Drawing.Point(8, 30);
            this.BtnIndivitualStart.Name = "BtnIndivitualStart";
            this.BtnIndivitualStart.Size = new System.Drawing.Size(84, 23);
            this.BtnIndivitualStart.TabIndex = 5;
            this.BtnIndivitualStart.Text = "شروع";
            this.BtnIndivitualStart.Click += new System.EventHandler(this.BtnIndivitualStart_Click);
            // 
            // lblCardNumber
            // 
            this.lblCardNumber.AutoSize = true;
            this.lblCardNumber.Location = new System.Drawing.Point(373, 37);
            this.lblCardNumber.Name = "lblCardNumber";
            this.lblCardNumber.Size = new System.Drawing.Size(65, 13);
            this.lblCardNumber.TabIndex = 4;
            this.lblCardNumber.Text = "شماره کارت:";
            // 
            // FrmAddGuest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.Silver;
            this.ClientSize = new System.Drawing.Size(457, 346);
            this.Controls.Add(this.GrpDefineGuest);
            this.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmAddGuest";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = " تعریف کارت مهمان";
            ((System.ComponentModel.ISupportInitialize)(this.GrpDefineGuest)).EndInit();
            this.GrpDefineGuest.ResumeLayout(false);
            this.GrpDefineGuest.PerformLayout();
            this.grpGroups.ResumeLayout(false);
            this.grpGroups.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CounterTo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CounterFrom)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewGuest)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdviewGuest)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ProgressBarCard)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CardProgressBar)).EndInit();
            this.GrpIndivitual.ResumeLayout(false);
            this.GrpIndivitual.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CounterCardNumber)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl GrpDefineGuest;
        private System.Windows.Forms.Label lblTypeEncode;
        private System.Windows.Forms.ComboBox cmbSelectType;
        private DevExpress.XtraGrid.GridControl gridViewGuest;
        private DevExpress.XtraGrid.Views.Grid.GridView grdviewGuest;
        private System.Windows.Forms.GroupBox grpGroups;
        private System.Windows.Forms.GroupBox GrpIndivitual;
        private System.Windows.Forms.Label lblTo;
        private System.Windows.Forms.Label lblFrom;
        private DevExpress.XtraEditors.SimpleButton BtnIndivitualStart;
        private System.Windows.Forms.Label lblCardNumber;
        private DevExpress.XtraEditors.SimpleButton BtnGroupStart;
        private System.Windows.Forms.NumericUpDown CounterCardNumber;
        private System.Windows.Forms.NumericUpDown CounterTo;
        private System.Windows.Forms.NumericUpDown CounterFrom;
        private System.Windows.Forms.ComboBox cmbEncoder;
        private System.Windows.Forms.Label lblSelectedEncoder;
        private DevExpress.XtraGrid.Columns.GridColumn NameCol;
        private DevExpress.XtraGrid.Columns.GridColumn CardNumber;
        private DevExpress.XtraGrid.Columns.GridColumn Progressbar;
        private DevExpress.XtraEditors.Repository.RepositoryItemProgressBar CardProgressBar;
        private DevExpress.XtraEditors.Repository.RepositoryItemProgressBar ProgressBarCard;
        private DevExpress.XtraEditors.SimpleButton btnGet;
        private DevExpress.XtraEditors.SimpleButton BtnRecieve;
    }
}