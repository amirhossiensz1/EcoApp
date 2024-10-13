namespace Eco
{
    partial class FrmDayType
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
            this.components = new System.ComponentModel.Container();
            DevExpress.XtraScheduler.TimeRuler timeRuler1 = new DevExpress.XtraScheduler.TimeRuler();
            DevExpress.XtraScheduler.TimeRuler timeRuler2 = new DevExpress.XtraScheduler.TimeRuler();
            DevExpress.XtraScheduler.TimeScaleYear timeScaleYear1 = new DevExpress.XtraScheduler.TimeScaleYear();
            DevExpress.XtraScheduler.TimeScaleQuarter timeScaleQuarter1 = new DevExpress.XtraScheduler.TimeScaleQuarter();
            DevExpress.XtraScheduler.TimeScaleMonth timeScaleMonth1 = new DevExpress.XtraScheduler.TimeScaleMonth();
            DevExpress.XtraScheduler.TimeScaleWeek timeScaleWeek1 = new DevExpress.XtraScheduler.TimeScaleWeek();
            DevExpress.XtraScheduler.TimeScaleDay timeScaleDay1 = new DevExpress.XtraScheduler.TimeScaleDay();
            DevExpress.XtraScheduler.TimeScaleHour timeScaleHour1 = new DevExpress.XtraScheduler.TimeScaleHour();
            DevExpress.XtraScheduler.TimeScale15Minutes timeScale15Minutes1 = new DevExpress.XtraScheduler.TimeScale15Minutes();
            DevExpress.XtraScheduler.TimeRuler timeRuler3 = new DevExpress.XtraScheduler.TimeRuler();
            this.schedulerStorage = new DevExpress.XtraScheduler.SchedulerStorage(this.components);
            this.trackBarRange1 = new Telerik.WinControls.UI.TrackBarRange();
            this.trackBarRange2 = new Telerik.WinControls.UI.TrackBarRange();
            this.trackBarRange3 = new Telerik.WinControls.UI.TrackBarRange();
            this.trackBarRange4 = new Telerik.WinControls.UI.TrackBarRange();
            this.trackBarRange5 = new Telerik.WinControls.UI.TrackBarRange();
            this.trackBarRange6 = new Telerik.WinControls.UI.TrackBarRange();
            this.a = new Telerik.WinControls.UI.TrackBarRange();
            this.b = new Telerik.WinControls.UI.TrackBarRange();
            this.trackBarRange7 = new Telerik.WinControls.UI.TrackBarRange();
            this.trackBarRange8 = new Telerik.WinControls.UI.TrackBarRange();
            this.trackBarRange9 = new Telerik.WinControls.UI.TrackBarRange();
            this.trackBarRange10 = new Telerik.WinControls.UI.TrackBarRange();
            this.trackBarRange11 = new Telerik.WinControls.UI.TrackBarRange();
            this.trackBarRange12 = new Telerik.WinControls.UI.TrackBarRange();
            this.grpControl = new DevExpress.XtraEditors.GroupControl();
            this.label2 = new System.Windows.Forms.Label();
            this.comboDayType = new System.Windows.Forms.ComboBox();
            this.BtnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.BtnSave = new DevExpress.XtraEditors.SimpleButton();
            this.lblDayTypeName = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.TimeLine = new DevExpress.XtraScheduler.SchedulerControl();
            ((System.ComponentModel.ISupportInitialize)(this.schedulerStorage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpControl)).BeginInit();
            this.grpControl.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TimeLine)).BeginInit();
            this.SuspendLayout();
            // 
            // a
            // 
            this.a.Text = "a";
            // 
            // b
            // 
            this.b.Text = "b";
            // 
            // grpControl
            // 
            this.grpControl.Controls.Add(this.label2);
            this.grpControl.Controls.Add(this.comboDayType);
            this.grpControl.Controls.Add(this.BtnCancel);
            this.grpControl.Controls.Add(this.BtnSave);
            this.grpControl.Controls.Add(this.lblDayTypeName);
            this.grpControl.Controls.Add(this.txtName);
            this.grpControl.Controls.Add(this.groupBox1);
            this.grpControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpControl.Location = new System.Drawing.Point(0, 0);
            this.grpControl.Name = "grpControl";
            this.grpControl.Size = new System.Drawing.Size(972, 248);
            this.grpControl.TabIndex = 0;
            this.grpControl.Text = "نوع روز";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(848, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(112, 18);
            this.label2.TabIndex = 14;
            this.label2.Text = "نوع روزهای ثبت شده :";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label2.UseCompatibleTextRendering = true;
            // 
            // comboDayType
            // 
            this.comboDayType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboDayType.FormattingEnabled = true;
            this.comboDayType.Location = new System.Drawing.Point(691, 29);
            this.comboDayType.Name = "comboDayType";
            this.comboDayType.Size = new System.Drawing.Size(151, 21);
            this.comboDayType.TabIndex = 13;
            this.comboDayType.SelectionChangeCommitted += new System.EventHandler(this.comboDayType_SelectionChangeCommitted);
            // 
            // BtnCancel
            // 
            this.BtnCancel.Location = new System.Drawing.Point(74, 211);
            this.BtnCancel.Name = "BtnCancel";
            this.BtnCancel.Size = new System.Drawing.Size(56, 28);
            this.BtnCancel.TabIndex = 12;
            this.BtnCancel.Text = "لغو";
            this.BtnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // BtnSave
            // 
            this.BtnSave.Location = new System.Drawing.Point(12, 211);
            this.BtnSave.Name = "BtnSave";
            this.BtnSave.Size = new System.Drawing.Size(56, 28);
            this.BtnSave.TabIndex = 11;
            this.BtnSave.Text = "ذخیره";
            this.BtnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // lblDayTypeName
            // 
            this.lblDayTypeName.AutoSize = true;
            this.lblDayTypeName.Location = new System.Drawing.Point(539, 34);
            this.lblDayTypeName.Name = "lblDayTypeName";
            this.lblDayTypeName.Size = new System.Drawing.Size(58, 13);
            this.lblDayTypeName.TabIndex = 10;
            this.lblDayTypeName.Text = "نام نوع روز:";
            this.lblDayTypeName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(382, 32);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(151, 21);
            this.txtName.TabIndex = 9;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.TimeLine);
            this.groupBox1.Location = new System.Drawing.Point(5, 56);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.groupBox1.Size = new System.Drawing.Size(962, 149);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            // 
            // TimeLine
            // 
            this.TimeLine.ActiveViewType = DevExpress.XtraScheduler.SchedulerViewType.Timeline;
            this.TimeLine.Appearance.Selection.BackColor = System.Drawing.Color.Lime;
            this.TimeLine.Appearance.Selection.BackColor2 = System.Drawing.Color.Lime;
            this.TimeLine.Appearance.Selection.ForeColor = System.Drawing.Color.DarkGreen;
            this.TimeLine.Appearance.Selection.Options.UseBackColor = true;
            this.TimeLine.Appearance.Selection.Options.UseForeColor = true;
            this.TimeLine.BackColor = System.Drawing.Color.Ivory;
            this.TimeLine.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TimeLine.LimitInterval.Duration = System.TimeSpan.Parse("1.00:00:00");
            this.TimeLine.LimitInterval.Start = new System.DateTime(2020, 3, 2, 0, 0, 0, 0);
            this.TimeLine.Location = new System.Drawing.Point(3, 17);
            this.TimeLine.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.UltraFlat;
            this.TimeLine.Name = "TimeLine";
            this.TimeLine.OptionsBehavior.RecurrentAppointmentDeleteAction = DevExpress.XtraScheduler.RecurrentAppointmentAction.Cancel;
            this.TimeLine.OptionsBehavior.RecurrentAppointmentEditAction = DevExpress.XtraScheduler.RecurrentAppointmentAction.Cancel;
            this.TimeLine.OptionsBehavior.ShowCurrentTime = DevExpress.XtraScheduler.CurrentTimeVisibility.Always;
            this.TimeLine.OptionsBehavior.ShowRemindersForm = false;
            this.TimeLine.OptionsCustomization.AllowAppointmentConflicts = DevExpress.XtraScheduler.AppointmentConflictsMode.Forbidden;
            this.TimeLine.OptionsCustomization.AllowAppointmentCopy = DevExpress.XtraScheduler.UsedAppointmentType.None;
            this.TimeLine.OptionsCustomization.AllowAppointmentCreate = DevExpress.XtraScheduler.UsedAppointmentType.None;
            this.TimeLine.OptionsCustomization.AllowAppointmentDrag = DevExpress.XtraScheduler.UsedAppointmentType.None;
            this.TimeLine.OptionsCustomization.AllowAppointmentDragBetweenResources = DevExpress.XtraScheduler.UsedAppointmentType.None;
            this.TimeLine.OptionsCustomization.AllowAppointmentEdit = DevExpress.XtraScheduler.UsedAppointmentType.None;
            this.TimeLine.OptionsCustomization.AllowAppointmentMultiSelect = false;
            this.TimeLine.OptionsCustomization.AllowDisplayAppointmentDependencyForm = DevExpress.XtraScheduler.AllowDisplayAppointmentDependencyForm.Never;
            this.TimeLine.OptionsCustomization.AllowDisplayAppointmentForm = DevExpress.XtraScheduler.AllowDisplayAppointmentForm.Never;
            this.TimeLine.OptionsCustomization.AllowInplaceEditor = DevExpress.XtraScheduler.UsedAppointmentType.None;
            this.TimeLine.OptionsRangeControl.AllowChangeActiveView = false;
            this.TimeLine.OptionsRangeControl.AutoAdjustMode = false;
            this.TimeLine.OptionsRangeControl.DataDisplayType = DevExpress.XtraScheduler.RangeControlDataDisplayType.Thumbnail;
            this.TimeLine.OptionsRangeControl.MaxSelectedIntervalCount = 1;
            this.TimeLine.OptionsRangeControl.RangeMaximum = new System.DateTime(2020, 2, 23, 0, 0, 0, 0);
            this.TimeLine.OptionsRangeControl.RangeMinimum = new System.DateTime(2020, 2, 23, 0, 0, 0, 0);
            this.TimeLine.OptionsView.FirstDayOfWeek = DevExpress.XtraScheduler.FirstDayOfWeek.Saturday;
            this.TimeLine.OptionsView.HideSelection = true;
            this.TimeLine.OptionsView.NavigationButtons.NextCaption = "";
            this.TimeLine.OptionsView.NavigationButtons.PrevCaption = "";
            this.TimeLine.OptionsView.NavigationButtons.Visibility = DevExpress.XtraScheduler.NavigationButtonVisibility.Never;
            this.TimeLine.OptionsView.ResourceHeaders.ImageInterpolationMode = System.Drawing.Drawing2D.InterpolationMode.Invalid;
            this.TimeLine.OptionsView.ToolTipVisibility = DevExpress.XtraScheduler.ToolTipVisibility.Never;
            this.TimeLine.ResourceNavigator.Buttons.EnabledAutoRepeat = false;
            this.TimeLine.ResourceNavigator.Buttons.Last.Enabled = false;
            this.TimeLine.ResourceNavigator.Buttons.Last.Visible = false;
            this.TimeLine.ResourceNavigator.Buttons.Next.Enabled = false;
            this.TimeLine.ResourceNavigator.Buttons.Next.Visible = false;
            this.TimeLine.ResourceNavigator.Buttons.NextPage.Enabled = false;
            this.TimeLine.ResourceNavigator.Buttons.NextPage.Visible = false;
            this.TimeLine.ResourceNavigator.Buttons.Prev.Enabled = false;
            this.TimeLine.ResourceNavigator.Buttons.Prev.Visible = false;
            this.TimeLine.ResourceNavigator.Buttons.PrevPage.Enabled = false;
            this.TimeLine.ResourceNavigator.Buttons.PrevPage.Visible = false;
            this.TimeLine.Size = new System.Drawing.Size(956, 129);
            this.TimeLine.Start = new System.DateTime(2020, 3, 2, 0, 0, 0, 0);
            this.TimeLine.Storage = this.schedulerStorage;
            this.TimeLine.TabIndex = 7;
            this.TimeLine.Text = "schedulerControl";
            this.TimeLine.Views.DayView.AllDayAreaScrollBarVisible = true;
            this.TimeLine.Views.DayView.Appearance.AllDayArea.BackColor = System.Drawing.Color.White;
            this.TimeLine.Views.DayView.Appearance.AllDayArea.Options.UseBackColor = true;
            this.TimeLine.Views.DayView.Appearance.TimeRulerNowLine.Options.UseTextOptions = true;
            this.TimeLine.Views.DayView.Appearance.TimeRulerNowLine.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.TimeLine.Views.DayView.Appearance.TimeRulerNowLine.TextOptions.WordWrap = DevExpress.Utils.WordWrap.NoWrap;
            this.TimeLine.Views.DayView.AppointmentDisplayOptions.ContinueArrowDisplayType = DevExpress.XtraScheduler.AppointmentContinueArrowDisplayType.Never;
            this.TimeLine.Views.DayView.AppointmentDisplayOptions.EndTimeVisibility = DevExpress.XtraScheduler.AppointmentTimeVisibility.Never;
            this.TimeLine.Views.DayView.AppointmentDisplayOptions.ShowRecurrence = false;
            this.TimeLine.Views.DayView.AppointmentDisplayOptions.ShowReminder = false;
            this.TimeLine.Views.DayView.AppointmentDisplayOptions.ShowShadows = false;
            this.TimeLine.Views.DayView.AppointmentDisplayOptions.SnapToCellsMode = DevExpress.XtraScheduler.AppointmentSnapToCellsMode.Never;
            this.TimeLine.Views.DayView.AppointmentDisplayOptions.StartTimeVisibility = DevExpress.XtraScheduler.AppointmentTimeVisibility.Always;
            this.TimeLine.Views.DayView.AppointmentDisplayOptions.StatusDisplayType = DevExpress.XtraScheduler.AppointmentStatusDisplayType.Never;
            this.TimeLine.Views.DayView.AppointmentDisplayOptions.TimeDisplayType = DevExpress.XtraScheduler.AppointmentTimeDisplayType.Text;
            this.TimeLine.Views.DayView.GroupSeparatorWidth = 1;
            this.TimeLine.Views.DayView.NavigationButtonVisibility = DevExpress.XtraScheduler.NavigationButtonVisibility.Never;
            this.TimeLine.Views.DayView.ShowAllAppointmentsAtTimeCells = true;
            this.TimeLine.Views.DayView.ShowAllDayArea = false;
            this.TimeLine.Views.DayView.ShowDayHeaders = false;
            this.TimeLine.Views.DayView.ShowWorkTimeOnly = true;
            this.TimeLine.Views.DayView.StatusLineWidth = 1;
            timeRuler1.AlwaysShowTopRowTime = true;
            timeRuler1.ShowCurrentTime = DevExpress.XtraScheduler.CurrentTimeVisibility.Always;
            timeRuler1.ShowMinutes = true;
            this.TimeLine.Views.DayView.TimeRulers.Add(timeRuler1);
            this.TimeLine.Views.DayView.VisibleTime = new DevExpress.XtraScheduler.TimeOfDayInterval(System.TimeSpan.Parse("00:00:00"), System.TimeSpan.Parse("24.00:00:00"));
            this.TimeLine.Views.DayView.VisibleTimeSnapMode = true;
            this.TimeLine.Views.DayView.WorkTime = new DevExpress.XtraScheduler.WorkTimeInterval(System.TimeSpan.Parse("00:00:00"), System.TimeSpan.Parse("23:59:59"));
            this.TimeLine.Views.FullWeekView.TimeRulers.Add(timeRuler2);
            this.TimeLine.Views.GanttView.AppointmentDisplayOptions.StatusDisplayType = DevExpress.XtraScheduler.AppointmentStatusDisplayType.Time;
            this.TimeLine.Views.GanttView.Enabled = false;
            this.TimeLine.Views.MonthView.Enabled = false;
            this.TimeLine.Views.TimelineView.AppointmentDisplayOptions.AppointmentHeight = 80;
            this.TimeLine.Views.TimelineView.AppointmentDisplayOptions.AppointmentInterspacing = 0;
            this.TimeLine.Views.TimelineView.AppointmentDisplayOptions.ContinueArrowDisplayType = DevExpress.XtraScheduler.AppointmentContinueArrowDisplayType.Never;
            this.TimeLine.Views.TimelineView.AppointmentDisplayOptions.ShowRecurrence = false;
            this.TimeLine.Views.TimelineView.AppointmentDisplayOptions.ShowReminder = false;
            this.TimeLine.Views.TimelineView.AppointmentDisplayOptions.StatusDisplayType = DevExpress.XtraScheduler.AppointmentStatusDisplayType.Time;
            this.TimeLine.Views.TimelineView.AppointmentDisplayOptions.TimeDisplayType = DevExpress.XtraScheduler.AppointmentTimeDisplayType.Clock;
            this.TimeLine.Views.TimelineView.CellsAutoHeightOptions.Enabled = true;
            this.TimeLine.Views.TimelineView.EnableInfiniteScrolling = false;
            this.TimeLine.Views.TimelineView.GroupSeparatorWidth = 4;
            this.TimeLine.Views.TimelineView.NavigationButtonVisibility = DevExpress.XtraScheduler.NavigationButtonVisibility.Never;
            this.TimeLine.Views.TimelineView.OptionsSelectionBehavior.UpdateSelectionDurationAction = DevExpress.XtraScheduler.UpdateSelectionDurationAction.Adjust;
            timeScaleYear1.Enabled = false;
            timeScaleYear1.Visible = false;
            timeScaleQuarter1.Enabled = false;
            timeScaleQuarter1.Visible = false;
            timeScaleMonth1.Enabled = false;
            timeScaleMonth1.Visible = false;
            timeScaleWeek1.Enabled = false;
            timeScaleWeek1.Visible = false;
            timeScaleDay1.Enabled = false;
            timeScaleDay1.Visible = false;
            timeScaleHour1.Enabled = false;
            timeScaleHour1.Visible = false;
            this.TimeLine.Views.TimelineView.Scales.Add(timeScaleYear1);
            this.TimeLine.Views.TimelineView.Scales.Add(timeScaleQuarter1);
            this.TimeLine.Views.TimelineView.Scales.Add(timeScaleMonth1);
            this.TimeLine.Views.TimelineView.Scales.Add(timeScaleWeek1);
            this.TimeLine.Views.TimelineView.Scales.Add(timeScaleDay1);
            this.TimeLine.Views.TimelineView.Scales.Add(timeScaleHour1);
            this.TimeLine.Views.TimelineView.Scales.Add(timeScale15Minutes1);
            this.TimeLine.Views.TimelineView.SelectionBar.Visible = false;
            this.TimeLine.Views.TimelineView.ShowMoreButtons = false;
            this.TimeLine.Views.TimelineView.ShowResourceHeaders = false;
            this.TimeLine.Views.WeekView.Enabled = false;
            this.TimeLine.Views.WorkWeekView.Enabled = false;
            this.TimeLine.Views.WorkWeekView.TimeRulers.Add(timeRuler3);
            this.TimeLine.PopupMenuShowing += new DevExpress.XtraScheduler.PopupMenuShowingEventHandler(this.schedulerControl1_PopupMenuShowing);
            this.TimeLine.MouseClick += new System.Windows.Forms.MouseEventHandler(this.TimeLine_MouseClick);
            // 
            // FrmDayType
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(972, 248);
            this.Controls.Add(this.grpControl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.Name = "FrmDayType";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "]";
            this.Load += new System.EventHandler(this.FrmDayType_Load);
            ((System.ComponentModel.ISupportInitialize)(this.schedulerStorage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpControl)).EndInit();
            this.grpControl.ResumeLayout(false);
            this.grpControl.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.TimeLine)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.UI.TrackBarRange trackBarRange1;
        private Telerik.WinControls.UI.TrackBarRange trackBarRange2;
        private Telerik.WinControls.UI.TrackBarRange trackBarRange3;
        private Telerik.WinControls.UI.TrackBarRange trackBarRange4;
        private Telerik.WinControls.UI.TrackBarRange trackBarRange5;
        private Telerik.WinControls.UI.TrackBarRange trackBarRange6;
        public Telerik.WinControls.UI.TrackBarRange a;
        public Telerik.WinControls.UI.TrackBarRange b;
        private Telerik.WinControls.UI.TrackBarRange trackBarRange7;
        private Telerik.WinControls.UI.TrackBarRange trackBarRange8;
        private Telerik.WinControls.UI.TrackBarRange trackBarRange9;
        private Telerik.WinControls.UI.TrackBarRange trackBarRange10;
        private Telerik.WinControls.UI.TrackBarRange trackBarRange11;
        private Telerik.WinControls.UI.TrackBarRange trackBarRange12;
        private DevExpress.XtraEditors.GroupControl grpControl;
        private DevExpress.XtraScheduler.SchedulerControl TimeLine;
        private DevExpress.XtraScheduler.SchedulerStorage schedulerStorage;
        private System.Windows.Forms.Label lblDayTypeName;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.GroupBox groupBox1;
        private DevExpress.XtraEditors.SimpleButton BtnCancel;
        private DevExpress.XtraEditors.SimpleButton BtnSave;
        private System.Windows.Forms.ComboBox comboDayType;
        private System.Windows.Forms.Label label2;
    }
}