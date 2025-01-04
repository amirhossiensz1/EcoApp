using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using DevExpress.Data;
using DevExpress.LookAndFeel;
using DevExpress.Utils;
using DevExpress.XtraBars.Docking;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraNavBar;
using DevExpress.XtraNavBar.ViewInfo;
using ComboBox = System.Windows.Forms.ComboBox;

namespace UI
{
    partial class MainFrm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            try
            {
                if (disposing && (components != null))
                {
                    components.Dispose();
                }
                base.Dispose(disposing);
            }
            catch (Exception ex)
            {
                
                Console.WriteLine(ex.Message);
            }

        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainFrm));
            this.CheckEdit = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.repositoryItemPictureEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit();
            this.dockManager1 = new DevExpress.XtraBars.Docking.DockManager(this.components);
            this.menu = new DevExpress.XtraBars.Docking.DockPanel();
            this.dockPanel_Container = new DevExpress.XtraBars.Docking.ControlContainer();
            this.nvBrCtrlMenu = new DevExpress.XtraNavBar.NavBarControl();
            this.navBarMonitor = new DevExpress.XtraNavBar.NavBarGroup();
            this.grdViewEmp = new DevExpress.XtraGrid.GridControl();
            this.gridViewEmp = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.GrdopertCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.GrdFName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.GrdLName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.GrdEmpID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.GrdOrganization = new DevExpress.XtraGrid.Columns.GridColumn();
            this.GrdAcsGRoup = new DevExpress.XtraGrid.Columns.GridColumn();
            this.GrdCard = new DevExpress.XtraGrid.Columns.GridColumn();
            this.GrdFinger = new DevExpress.XtraGrid.Columns.GridColumn();
            this.GrdPicture = new DevExpress.XtraGrid.Columns.GridColumn();
            this.navBarOnlinePdp = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarOnlineTrafic = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarDevices = new DevExpress.XtraNavBar.NavBarGroup();
            this.navBarAddDevice = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarSetting = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarFirmWare = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarEmployee = new DevExpress.XtraNavBar.NavBarGroup();
            this.navBarAddEmp = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarSendEmp = new DevExpress.XtraNavBar.NavBarItem();
            this.EmployeeGroup = new DevExpress.XtraNavBar.NavBarItem();
            this.navSchaduler = new DevExpress.XtraNavBar.NavBarGroup();
            this.DayType = new DevExpress.XtraNavBar.NavBarItem();
            this.SchGroup = new DevExpress.XtraNavBar.NavBarItem();
            this.AccessArea = new DevExpress.XtraNavBar.NavBarItem();
            this.AcessGroup = new DevExpress.XtraNavBar.NavBarItem();
            this.Holidays = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarGuest = new DevExpress.XtraNavBar.NavBarGroup();
            this.navBarAllGuest = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarAddGuest = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarLog = new DevExpress.XtraNavBar.NavBarGroup();
            this.navBarAllLog = new DevExpress.XtraNavBar.NavBarItem();
            this.navbarChartTraffic = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarShowDevice = new DevExpress.XtraNavBar.NavBarItem();
            this.panelEmp = new DevExpress.XtraEditors.PanelControl();
            this.CmbBxType = new System.Windows.Forms.ComboBox();
            this.lblTypeExport = new System.Windows.Forms.Label();
            this.BtnPrint = new DevExpress.XtraEditors.SimpleButton();
            this.BtnExport = new DevExpress.XtraEditors.SimpleButton();
            this.GrpOnDvc = new DevExpress.XtraEditors.GroupControl();
            this.panelGuest = new DevExpress.XtraEditors.PanelControl();
            this.gridViewGuest = new DevExpress.XtraGrid.GridControl();
            this.grdViewGuest = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.NameCol = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CardNumber = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panelDevice = new DevExpress.XtraEditors.PanelControl();
            this.gridViewDevice = new DevExpress.XtraGrid.GridControl();
            this.grdViewDevice = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.GrdName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.GrdIP = new DevExpress.XtraGrid.Columns.GridColumn();
            this.GrdPort = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdTftpPort = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.TopMenu = new System.Windows.Forms.MenuStrip();
            this.BasicInfoMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ClientMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.OpertManagerMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.مدیریتنقشدردستگاهToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.اطلاعاتToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ImportEmployeeStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ImportFingerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.backgroundWorker2 = new System.ComponentModel.BackgroundWorker();
            this.panelOnDvc = new DevExpress.XtraEditors.PanelControl();
            this.MainPanel = new DevExpress.XtraEditors.PanelControl();
            this.TrafficMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.OfflineLogMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.OnlineLogToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.NewOpert = new System.Windows.Forms.ToolStripMenuItem();
            this.EditOpert = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.CheckEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemPictureEdit2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dockManager1)).BeginInit();
            this.menu.SuspendLayout();
            this.dockPanel_Container.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nvBrCtrlMenu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdViewEmp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewEmp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelEmp)).BeginInit();
            this.panelEmp.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GrpOnDvc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelGuest)).BeginInit();
            this.panelGuest.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewGuest)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdViewGuest)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelDevice)).BeginInit();
            this.panelDevice.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewDevice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdViewDevice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.TopMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelOnDvc)).BeginInit();
            this.panelOnDvc.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MainPanel)).BeginInit();
            this.SuspendLayout();
            // 
            // CheckEdit
            // 
            this.CheckEdit.AllowGrayed = true;
            this.CheckEdit.AllowHtmlDraw = DevExpress.Utils.DefaultBoolean.False;
            resources.ApplyResources(this.CheckEdit, "CheckEdit");
            this.CheckEdit.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.CheckEdit.Name = "CheckEdit";
            this.CheckEdit.NullStyle = DevExpress.XtraEditors.Controls.StyleIndeterminate.Unchecked;
            this.CheckEdit.Tag = true;
            // 
            // repositoryItemPictureEdit2
            // 
            this.repositoryItemPictureEdit2.Name = "repositoryItemPictureEdit2";
            // 
            // dockManager1
            // 
            this.dockManager1.Form = this;
            this.dockManager1.RootPanels.AddRange(new DevExpress.XtraBars.Docking.DockPanel[] {
            this.menu});
            this.dockManager1.TopZIndexControls.AddRange(new string[] {
            "DevExpress.XtraBars.BarDockControl",
            "DevExpress.XtraBars.StandaloneBarDockControl",
            "System.Windows.Forms.StatusBar",
            "System.Windows.Forms.MenuStrip",
            "System.Windows.Forms.StatusStrip",
            "DevExpress.XtraBars.Ribbon.RibbonStatusBar",
            "DevExpress.XtraBars.Ribbon.RibbonControl",
            "DevExpress.XtraBars.Navigation.OfficeNavigationBar",
            "DevExpress.XtraBars.Navigation.TileNavPane"});
            // 
            // menu
            // 
            this.menu.Appearance.BackColor = System.Drawing.Color.Lavender;
            this.menu.Appearance.BackColor2 = ((System.Drawing.Color)(resources.GetObject("menu.Appearance.BackColor2")));
            this.menu.Appearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.menu.Appearance.Options.UseBackColor = true;
            this.menu.Appearance.Options.UseBorderColor = true;
            resources.ApplyResources(this.menu, "menu");
            this.menu.Controls.Add(this.dockPanel_Container);
            this.menu.Dock = DevExpress.XtraBars.Docking.DockingStyle.Left;
            this.menu.DockVertical = DevExpress.Utils.DefaultBoolean.False;
            this.menu.FloatSize = new System.Drawing.Size(50, 50);
            this.menu.ID = new System.Guid("28637168-bdab-458a-85f8-5be629920cc6");
            this.menu.ImageOptions.AllowGlyphSkinning = DevExpress.Utils.DefaultBoolean.False;
            this.menu.Name = "menu";
            this.menu.Options.AllowDockBottom = false;
            this.menu.Options.AllowDockFill = false;
            this.menu.Options.AllowFloating = false;
            this.menu.Options.ShowCloseButton = false;
            this.menu.OriginalSize = new System.Drawing.Size(227, 553);
            this.menu.TabsScroll = true;
            this.menu.Expanding += new DevExpress.XtraBars.Docking.DockPanelCancelEventHandler(this.menu_Expanding);
            this.menu.Collapsed += new DevExpress.XtraBars.Docking.DockPanelEventHandler(this.menu_Collapsed);
            this.menu.Click += new System.EventHandler(this.Menu_Click);
            // 
            // dockPanel_Container
            // 
            this.dockPanel_Container.Controls.Add(this.nvBrCtrlMenu);
            resources.ApplyResources(this.dockPanel_Container, "dockPanel_Container");
            this.dockPanel_Container.Name = "dockPanel_Container";
            // 
            // nvBrCtrlMenu
            // 
            this.nvBrCtrlMenu.ActiveGroup = this.navBarMonitor;
            resources.ApplyResources(this.nvBrCtrlMenu, "nvBrCtrlMenu");
            this.nvBrCtrlMenu.DragDropFlags = DevExpress.XtraNavBar.NavBarDragDrop.None;
            this.nvBrCtrlMenu.Groups.AddRange(new DevExpress.XtraNavBar.NavBarGroup[] {
            this.navBarMonitor,
            this.navBarDevices,
            this.navBarEmployee,
            this.navSchaduler,
            this.navBarGuest,
            this.navBarLog});
            this.nvBrCtrlMenu.Items.AddRange(new DevExpress.XtraNavBar.NavBarItem[] {
            this.navBarAddDevice,
            this.navBarSetting,
            this.navBarOnlineTrafic,
            this.navBarOnlinePdp,
            this.navBarAddEmp,
            this.navBarSendEmp,
            this.navBarShowDevice,
            this.navBarAllLog,
            this.navBarAllGuest,
            this.navBarAddGuest,
            this.navbarChartTraffic,
            this.DayType,
            this.SchGroup,
            this.AcessGroup,
            this.Holidays,
            this.EmployeeGroup,
            this.navBarFirmWare,
            this.AccessArea});
            this.nvBrCtrlMenu.LookAndFeel.SkinName = "VS2010";
            this.nvBrCtrlMenu.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.UltraFlat;
            this.nvBrCtrlMenu.Name = "nvBrCtrlMenu";
            this.nvBrCtrlMenu.OptionsNavPane.CollapsedNavPaneContentControl = this.dockPanel_Container;
            this.nvBrCtrlMenu.OptionsNavPane.ExpandedWidth = ((int)(resources.GetObject("resource.ExpandedWidth")));
            this.nvBrCtrlMenu.View = new DevExpress.XtraNavBar.ViewInfo.SkinExplorerBarViewInfoRegistrator();
            this.nvBrCtrlMenu.Click += new System.EventHandler(this.nvBrCtrlMenu_Click);
            // 
            // navBarMonitor
            // 
            this.navBarMonitor.Appearance.Font = ((System.Drawing.Font)(resources.GetObject("navBarMonitor.Appearance.Font")));
            this.navBarMonitor.Appearance.Options.UseFont = true;
            this.navBarMonitor.Appearance.Options.UseTextOptions = true;
            this.navBarMonitor.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.navBarMonitor.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            resources.ApplyResources(this.navBarMonitor, "navBarMonitor");
            this.navBarMonitor.CollapsedNavPaneContentControl = this.grdViewEmp;
            this.navBarMonitor.GroupStyle = DevExpress.XtraNavBar.NavBarGroupStyle.SmallIconsText;
            this.navBarMonitor.ItemLinks.AddRange(new DevExpress.XtraNavBar.NavBarItemLink[] {
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarOnlinePdp),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarOnlineTrafic)});
            this.navBarMonitor.Name = "navBarMonitor";
            this.navBarMonitor.ItemChanged += new System.EventHandler(this.navBarMonitor_ItemChanged);
            // 
            // grdViewEmp
            // 
            this.grdViewEmp.Cursor = System.Windows.Forms.Cursors.Default;
            resources.ApplyResources(this.grdViewEmp, "grdViewEmp");
            this.grdViewEmp.MainView = this.gridViewEmp;
            this.grdViewEmp.Name = "grdViewEmp";
            this.grdViewEmp.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.CheckEdit});
            this.grdViewEmp.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewEmp});
            // 
            // gridViewEmp
            // 
            this.gridViewEmp.Appearance.GroupPanel.BackColor = System.Drawing.Color.OldLace;
            this.gridViewEmp.Appearance.GroupPanel.Options.UseBackColor = true;
            this.gridViewEmp.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.gridViewEmp.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridViewEmp.Appearance.HeaderPanel.TextOptions.HotkeyPrefix = DevExpress.Utils.HKeyPrefix.Show;
            this.gridViewEmp.Appearance.HeaderPanel.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gridViewEmp.Appearance.OddRow.BackColor = System.Drawing.Color.Linen;
            this.gridViewEmp.Appearance.OddRow.Options.UseBackColor = true;
            this.gridViewEmp.Appearance.Row.Options.UseTextOptions = true;
            this.gridViewEmp.Appearance.Row.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridViewEmp.Appearance.Row.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gridViewEmp.AppearancePrint.EvenRow.Options.UseTextOptions = true;
            this.gridViewEmp.AppearancePrint.EvenRow.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gridViewEmp.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.GrdopertCode,
            this.GrdFName,
            this.GrdLName,
            this.GrdEmpID,
            this.GrdOrganization,
            this.GrdAcsGRoup,
            this.GrdCard,
            this.GrdFinger,
            this.GrdPicture});
            this.gridViewEmp.DetailHeight = 500;
            this.gridViewEmp.GridControl = this.grdViewEmp;
            this.gridViewEmp.Name = "gridViewEmp";
            this.gridViewEmp.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.True;
            this.gridViewEmp.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.True;
            this.gridViewEmp.OptionsBehavior.AutoSelectAllInEditor = false;
            this.gridViewEmp.OptionsBehavior.Editable = false;
            this.gridViewEmp.OptionsFilter.InHeaderSearchMode = DevExpress.XtraGrid.Views.Grid.GridInHeaderSearchMode.TextFilter;
            this.gridViewEmp.OptionsFind.AlwaysVisible = true;
            this.gridViewEmp.OptionsFind.FindNullPrompt = "کلمه مورد نظر را وارد کنید ....";
            this.gridViewEmp.OptionsFind.ShowClearButton = false;
            this.gridViewEmp.OptionsPrint.EnableAppearanceEvenRow = true;
            this.gridViewEmp.OptionsPrint.PrintFooter = false;
            this.gridViewEmp.OptionsPrint.PrintGroupFooter = false;
            this.gridViewEmp.OptionsPrint.PrintHeader = false;
            this.gridViewEmp.OptionsPrint.PrintHorzLines = false;
            this.gridViewEmp.OptionsPrint.PrintVertLines = false;
            this.gridViewEmp.OptionsSelection.MultiSelect = true;
            this.gridViewEmp.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect;
            this.gridViewEmp.OptionsSelection.ShowCheckBoxSelectorInPrintExport = DevExpress.Utils.DefaultBoolean.False;
            this.gridViewEmp.OptionsView.EnableAppearanceOddRow = true;
            this.gridViewEmp.OptionsView.RowAutoHeight = true;
            this.gridViewEmp.RowHeight = 75;
            this.gridViewEmp.RowClick += new DevExpress.XtraGrid.Views.Grid.RowClickEventHandler(this.gridView_RowClick);
            this.gridViewEmp.DoubleClick += new System.EventHandler(this.gridViewEmp_DoubleClick);
            // 
            // GrdopertCode
            // 
            resources.ApplyResources(this.GrdopertCode, "GrdopertCode");
            this.GrdopertCode.FieldName = "ID";
            this.GrdopertCode.Name = "GrdopertCode";
            this.GrdopertCode.OptionsColumn.AllowEdit = false;
            this.GrdopertCode.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.GrdopertCode.OptionsColumn.AllowSize = false;
            this.GrdopertCode.OptionsColumn.ReadOnly = true;
            // 
            // GrdFName
            // 
            resources.ApplyResources(this.GrdFName, "GrdFName");
            this.GrdFName.FieldName = "EmpFname";
            this.GrdFName.ImageOptions.Alignment = ((System.Drawing.StringAlignment)(resources.GetObject("GrdFName.ImageOptions.Alignment")));
            this.GrdFName.Name = "GrdFName";
            this.GrdFName.OptionsColumn.AllowEdit = false;
            this.GrdFName.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.GrdFName.OptionsColumn.AllowSize = false;
            this.GrdFName.OptionsColumn.ReadOnly = true;
            // 
            // GrdLName
            // 
            resources.ApplyResources(this.GrdLName, "GrdLName");
            this.GrdLName.FieldName = "EmpLname";
            this.GrdLName.Name = "GrdLName";
            this.GrdLName.OptionsColumn.AllowEdit = false;
            this.GrdLName.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.GrdLName.OptionsColumn.AllowSize = false;
            this.GrdLName.OptionsColumn.ReadOnly = true;
            // 
            // GrdEmpID
            // 
            resources.ApplyResources(this.GrdEmpID, "GrdEmpID");
            this.GrdEmpID.FieldName = "PersonalNum";
            this.GrdEmpID.Name = "GrdEmpID";
            this.GrdEmpID.OptionsColumn.AllowEdit = false;
            this.GrdEmpID.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.GrdEmpID.OptionsColumn.AllowSize = false;
            this.GrdEmpID.OptionsColumn.ReadOnly = true;
            // 
            // GrdOrganization
            // 
            resources.ApplyResources(this.GrdOrganization, "GrdOrganization");
            this.GrdOrganization.FieldName = "OrganizationName";
            this.GrdOrganization.Name = "GrdOrganization";
            this.GrdOrganization.OptionsColumn.AllowEdit = false;
            this.GrdOrganization.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.GrdOrganization.OptionsColumn.AllowSize = false;
            this.GrdOrganization.OptionsColumn.ReadOnly = true;
            // 
            // GrdAcsGRoup
            // 
            resources.ApplyResources(this.GrdAcsGRoup, "GrdAcsGRoup");
            this.GrdAcsGRoup.FieldName = "AccessGroupName";
            this.GrdAcsGRoup.Name = "GrdAcsGRoup";
            this.GrdAcsGRoup.OptionsColumn.AllowEdit = false;
            this.GrdAcsGRoup.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.GrdAcsGRoup.OptionsColumn.AllowSize = false;
            this.GrdAcsGRoup.OptionsColumn.ReadOnly = true;
            // 
            // GrdCard
            // 
            resources.ApplyResources(this.GrdCard, "GrdCard");
            this.GrdCard.FieldName = "HasCard";
            this.GrdCard.Name = "GrdCard";
            this.GrdCard.OptionsColumn.AllowEdit = false;
            this.GrdCard.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.GrdCard.OptionsColumn.AllowSize = false;
            this.GrdCard.OptionsColumn.ReadOnly = true;
            // 
            // GrdFinger
            // 
            resources.ApplyResources(this.GrdFinger, "GrdFinger");
            this.GrdFinger.FieldName = "HasFinger";
            this.GrdFinger.Name = "GrdFinger";
            this.GrdFinger.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.GrdFinger.OptionsColumn.AllowSize = false;
            // 
            // GrdPicture
            // 
            resources.ApplyResources(this.GrdPicture, "GrdPicture");
            this.GrdPicture.FieldName = "Image";
            this.GrdPicture.ImageOptions.Alignment = ((System.Drawing.StringAlignment)(resources.GetObject("GrdPicture.ImageOptions.Alignment")));
            this.GrdPicture.Name = "GrdPicture";
            this.GrdPicture.OptionsColumn.AllowSize = false;
            this.GrdPicture.UnboundType = DevExpress.Data.UnboundColumnType.Object;
            // 
            // navBarOnlinePdp
            // 
            resources.ApplyResources(this.navBarOnlinePdp, "navBarOnlinePdp");
            this.navBarOnlinePdp.Name = "navBarOnlinePdp";
            this.navBarOnlinePdp.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navBarOnlinePdp_LinkClicked);
            // 
            // navBarOnlineTrafic
            // 
            this.navBarOnlineTrafic.AppearanceHotTracked.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.navBarOnlineTrafic.AppearancePressed.ForeColor = System.Drawing.Color.Red;
            this.navBarOnlineTrafic.CanDrag = false;
            resources.ApplyResources(this.navBarOnlineTrafic, "navBarOnlineTrafic");
            this.navBarOnlineTrafic.Name = "navBarOnlineTrafic";
            this.navBarOnlineTrafic.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navBarOnlineTrafic_LinkClicked);
            // 
            // navBarDevices
            // 
            this.navBarDevices.Appearance.Font = ((System.Drawing.Font)(resources.GetObject("navBarDevices.Appearance.Font")));
            this.navBarDevices.Appearance.Options.UseFont = true;
            resources.ApplyResources(this.navBarDevices, "navBarDevices");
            this.navBarDevices.GroupStyle = DevExpress.XtraNavBar.NavBarGroupStyle.SmallIconsText;
            this.navBarDevices.ImageOptions.LargeImageSize = new System.Drawing.Size(20, 20);
            this.navBarDevices.ImageOptions.SmallImageSize = new System.Drawing.Size(20, 20);
            this.navBarDevices.ItemLinks.AddRange(new DevExpress.XtraNavBar.NavBarItemLink[] {
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarAddDevice),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarSetting),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarFirmWare)});
            this.navBarDevices.Name = "navBarDevices";
            this.navBarDevices.NavigationPaneVisible = false;
            this.navBarDevices.ShowIcons = DevExpress.Utils.DefaultBoolean.True;
            this.navBarDevices.ItemChanged += new System.EventHandler(this.navBarDevices_ItemChanged);
            // 
            // navBarAddDevice
            // 
            resources.ApplyResources(this.navBarAddDevice, "navBarAddDevice");
            this.navBarAddDevice.Name = "navBarAddDevice";
            this.navBarAddDevice.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navBarAddDevice_LinkClicked);
            // 
            // navBarSetting
            // 
            resources.ApplyResources(this.navBarSetting, "navBarSetting");
            this.navBarSetting.Name = "navBarSetting";
            this.navBarSetting.Visible = false;
            this.navBarSetting.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navBarSetting_LinkClicked);
            // 
            // navBarFirmWare
            // 
            resources.ApplyResources(this.navBarFirmWare, "navBarFirmWare");
            this.navBarFirmWare.Name = "navBarFirmWare";
            this.navBarFirmWare.Visible = false;
            // 
            // navBarEmployee
            // 
            this.navBarEmployee.Appearance.Font = ((System.Drawing.Font)(resources.GetObject("navBarEmployee.Appearance.Font")));
            this.navBarEmployee.Appearance.Options.UseFont = true;
            this.navBarEmployee.AppearancePressed.ForeColor = System.Drawing.Color.Black;
            resources.ApplyResources(this.navBarEmployee, "navBarEmployee");
            this.navBarEmployee.GroupStyle = DevExpress.XtraNavBar.NavBarGroupStyle.SmallIconsText;
            this.navBarEmployee.ItemLinks.AddRange(new DevExpress.XtraNavBar.NavBarItemLink[] {
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarAddEmp),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarSendEmp),
            new DevExpress.XtraNavBar.NavBarItemLink(this.EmployeeGroup)});
            this.navBarEmployee.Name = "navBarEmployee";
            this.navBarEmployee.ItemChanged += new System.EventHandler(this.navBarEmployee_ItemChanged);
            // 
            // navBarAddEmp
            // 
            resources.ApplyResources(this.navBarAddEmp, "navBarAddEmp");
            this.navBarAddEmp.Name = "navBarAddEmp";
            this.navBarAddEmp.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navBarAddEmp_LinkClicked);
            // 
            // navBarSendEmp
            // 
            resources.ApplyResources(this.navBarSendEmp, "navBarSendEmp");
            this.navBarSendEmp.Name = "navBarSendEmp";
            this.navBarSendEmp.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navBarSendEmp_LinkClicked);
            // 
            // EmployeeGroup
            // 
            resources.ApplyResources(this.EmployeeGroup, "EmployeeGroup");
            this.EmployeeGroup.Name = "EmployeeGroup";
            this.EmployeeGroup.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.EmployeeGroup_LinkClicked);
            // 
            // navSchaduler
            // 
            this.navSchaduler.Appearance.Font = ((System.Drawing.Font)(resources.GetObject("navSchaduler.Appearance.Font")));
            this.navSchaduler.Appearance.Options.UseFont = true;
            resources.ApplyResources(this.navSchaduler, "navSchaduler");
            this.navSchaduler.ItemLinks.AddRange(new DevExpress.XtraNavBar.NavBarItemLink[] {
            new DevExpress.XtraNavBar.NavBarItemLink(this.DayType),
            new DevExpress.XtraNavBar.NavBarItemLink(this.SchGroup),
            new DevExpress.XtraNavBar.NavBarItemLink(this.AccessArea),
            new DevExpress.XtraNavBar.NavBarItemLink(this.AcessGroup),
            new DevExpress.XtraNavBar.NavBarItemLink(this.Holidays)});
            this.navSchaduler.Name = "navSchaduler";
            this.navSchaduler.ItemChanged += new System.EventHandler(this.navSchaduler_ItemChanged);
            // 
            // DayType
            // 
            resources.ApplyResources(this.DayType, "DayType");
            this.DayType.Name = "DayType";
            this.DayType.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.DayType_LinkClicked);
            // 
            // SchGroup
            // 
            resources.ApplyResources(this.SchGroup, "SchGroup");
            this.SchGroup.Name = "SchGroup";
            this.SchGroup.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.SchGroup_LinkClicked);
            // 
            // AccessArea
            // 
            resources.ApplyResources(this.AccessArea, "AccessArea");
            this.AccessArea.Name = "AccessArea";
            this.AccessArea.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.AccessArea_LinkClicked);
            // 
            // AcessGroup
            // 
            resources.ApplyResources(this.AcessGroup, "AcessGroup");
            this.AcessGroup.Name = "AcessGroup";
            this.AcessGroup.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.AcessGroup_LinkClicked);
            // 
            // Holidays
            // 
            resources.ApplyResources(this.Holidays, "Holidays");
            this.Holidays.Name = "Holidays";
            this.Holidays.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.Holidays_LinkClicked);
            // 
            // navBarGuest
            // 
            this.navBarGuest.Appearance.Font = ((System.Drawing.Font)(resources.GetObject("navBarGuest.Appearance.Font")));
            this.navBarGuest.Appearance.Options.UseFont = true;
            resources.ApplyResources(this.navBarGuest, "navBarGuest");
            this.navBarGuest.GroupStyle = DevExpress.XtraNavBar.NavBarGroupStyle.SmallIconsText;
            this.navBarGuest.ItemLinks.AddRange(new DevExpress.XtraNavBar.NavBarItemLink[] {
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarAllGuest),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarAddGuest)});
            this.navBarGuest.Name = "navBarGuest";
            // 
            // navBarAllGuest
            // 
            resources.ApplyResources(this.navBarAllGuest, "navBarAllGuest");
            this.navBarAllGuest.Name = "navBarAllGuest";
            this.navBarAllGuest.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navBarAllGuest_LinkClicked);
            // 
            // navBarAddGuest
            // 
            resources.ApplyResources(this.navBarAddGuest, "navBarAddGuest");
            this.navBarAddGuest.Name = "navBarAddGuest";
            this.navBarAddGuest.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navBarAddGuest_LinkClicked);
            // 
            // navBarLog
            // 
            this.navBarLog.Appearance.Font = ((System.Drawing.Font)(resources.GetObject("navBarLog.Appearance.Font")));
            this.navBarLog.Appearance.Options.UseFont = true;
            resources.ApplyResources(this.navBarLog, "navBarLog");
            this.navBarLog.Expanded = true;
            this.navBarLog.GroupStyle = DevExpress.XtraNavBar.NavBarGroupStyle.SmallIconsText;
            this.navBarLog.ItemLinks.AddRange(new DevExpress.XtraNavBar.NavBarItemLink[] {
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarAllLog),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navbarChartTraffic)});
            this.navBarLog.Name = "navBarLog";
            this.navBarLog.ItemChanged += new System.EventHandler(this.navBarLog_ItemChanged);
            // 
            // navBarAllLog
            // 
            resources.ApplyResources(this.navBarAllLog, "navBarAllLog");
            this.navBarAllLog.Name = "navBarAllLog";
            this.navBarAllLog.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navBarAllLog_LinkClicked);
            // 
            // navbarChartTraffic
            // 
            resources.ApplyResources(this.navbarChartTraffic, "navbarChartTraffic");
            this.navbarChartTraffic.Name = "navbarChartTraffic";
            this.navbarChartTraffic.Visible = false;
            this.navbarChartTraffic.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navbarChartTraffic_LinkClicked);
            // 
            // navBarShowDevice
            // 
            resources.ApplyResources(this.navBarShowDevice, "navBarShowDevice");
            this.navBarShowDevice.Name = "navBarShowDevice";
            this.navBarShowDevice.Visible = false;
            // 
            // panelEmp
            // 
            this.panelEmp.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.panelEmp.Controls.Add(this.CmbBxType);
            this.panelEmp.Controls.Add(this.lblTypeExport);
            this.panelEmp.Controls.Add(this.BtnPrint);
            this.panelEmp.Controls.Add(this.BtnExport);
            this.panelEmp.Controls.Add(this.grdViewEmp);
            resources.ApplyResources(this.panelEmp, "panelEmp");
            this.panelEmp.Name = "panelEmp";
            // 
            // CmbBxType
            // 
            this.CmbBxType.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.CmbBxType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            resources.ApplyResources(this.CmbBxType, "CmbBxType");
            this.CmbBxType.FormattingEnabled = true;
            this.CmbBxType.Name = "CmbBxType";
            // 
            // lblTypeExport
            // 
            resources.ApplyResources(this.lblTypeExport, "lblTypeExport");
            this.lblTypeExport.BackColor = System.Drawing.SystemColors.ControlLight;
            this.lblTypeExport.Name = "lblTypeExport";
            // 
            // BtnPrint
            // 
            resources.ApplyResources(this.BtnPrint, "BtnPrint");
            this.BtnPrint.Name = "BtnPrint";
            this.BtnPrint.Click += new System.EventHandler(this.BtnPrint_Click);
            // 
            // BtnExport
            // 
            resources.ApplyResources(this.BtnExport, "BtnExport");
            this.BtnExport.Name = "BtnExport";
            this.BtnExport.Click += new System.EventHandler(this.BtnExport_Click);
            // 
            // GrpOnDvc
            // 
            this.GrpOnDvc.AllowDrop = true;
            this.GrpOnDvc.AllowTouchScroll = true;
            resources.ApplyResources(this.GrpOnDvc, "GrpOnDvc");
            this.GrpOnDvc.CaptionLocation = DevExpress.Utils.Locations.Top;
            this.GrpOnDvc.FireScrollEventOnMouseWheel = true;
            this.GrpOnDvc.InvertTouchScroll = true;
            this.GrpOnDvc.Name = "GrpOnDvc";
            this.GrpOnDvc.ScrollBarSmallChange = 10;
            // 
            // panelGuest
            // 
            this.panelGuest.Controls.Add(this.gridViewGuest);
            resources.ApplyResources(this.panelGuest, "panelGuest");
            this.panelGuest.Name = "panelGuest";
            // 
            // gridViewGuest
            // 
            resources.ApplyResources(this.gridViewGuest, "gridViewGuest");
            this.gridViewGuest.MainView = this.grdViewGuest;
            this.gridViewGuest.Name = "gridViewGuest";
            this.gridViewGuest.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grdViewGuest});
            // 
            // grdViewGuest
            // 
            this.grdViewGuest.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.NameCol,
            this.CardNumber});
            this.grdViewGuest.GridControl = this.gridViewGuest;
            this.grdViewGuest.Name = "grdViewGuest";
            // 
            // NameCol
            // 
            resources.ApplyResources(this.NameCol, "NameCol");
            this.NameCol.FieldName = "Name";
            this.NameCol.Name = "NameCol";
            this.NameCol.OptionsColumn.AllowEdit = false;
            this.NameCol.OptionsColumn.AllowSize = false;
            this.NameCol.OptionsColumn.ShowInExpressionEditor = false;
            // 
            // CardNumber
            // 
            resources.ApplyResources(this.CardNumber, "CardNumber");
            this.CardNumber.FieldName = "CardNumberStr";
            this.CardNumber.Name = "CardNumber";
            this.CardNumber.OptionsColumn.AllowSize = false;
            this.CardNumber.OptionsColumn.ReadOnly = true;
            // 
            // panelDevice
            // 
            this.panelDevice.Controls.Add(this.gridViewDevice);
            resources.ApplyResources(this.panelDevice, "panelDevice");
            this.panelDevice.Name = "panelDevice";
            // 
            // gridViewDevice
            // 
            this.gridViewDevice.Cursor = System.Windows.Forms.Cursors.Default;
            resources.ApplyResources(this.gridViewDevice, "gridViewDevice");
            this.gridViewDevice.MainView = this.grdViewDevice;
            this.gridViewDevice.Name = "gridViewDevice";
            this.gridViewDevice.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grdViewDevice,
            this.gridView1});
            // 
            // grdViewDevice
            // 
            this.grdViewDevice.Appearance.GroupPanel.BorderColor = System.Drawing.Color.White;
            this.grdViewDevice.Appearance.GroupPanel.ForeColor = System.Drawing.Color.DarkGray;
            this.grdViewDevice.Appearance.GroupPanel.Options.UseBorderColor = true;
            this.grdViewDevice.Appearance.GroupPanel.Options.UseFont = true;
            this.grdViewDevice.Appearance.GroupPanel.Options.UseForeColor = true;
            this.grdViewDevice.Appearance.GroupPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grdViewDevice.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.grdViewDevice.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grdViewDevice.Appearance.HeaderPanel.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Top;
            this.grdViewDevice.Appearance.HeaderPanel.TextOptions.WordWrap = DevExpress.Utils.WordWrap.NoWrap;
            this.grdViewDevice.Appearance.Row.Options.UseTextOptions = true;
            this.grdViewDevice.Appearance.Row.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grdViewDevice.Appearance.Row.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grdViewDevice.Appearance.ViewCaption.BorderColor = System.Drawing.Color.Black;
            this.grdViewDevice.Appearance.ViewCaption.ForeColor = System.Drawing.Color.Black;
            this.grdViewDevice.Appearance.ViewCaption.Options.UseBorderColor = true;
            this.grdViewDevice.Appearance.ViewCaption.Options.UseForeColor = true;
            this.grdViewDevice.Appearance.ViewCaption.Options.UseTextOptions = true;
            this.grdViewDevice.Appearance.ViewCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grdViewDevice.Appearance.ViewCaption.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grdViewDevice.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.GrdName,
            this.GrdIP,
            this.GrdPort,
            this.grdTftpPort});
            this.grdViewDevice.GridControl = this.gridViewDevice;
            this.grdViewDevice.Name = "grdViewDevice";
            this.grdViewDevice.OptionsBehavior.AutoSelectAllInEditor = false;
            this.grdViewDevice.OptionsBehavior.Editable = false;
            this.grdViewDevice.OptionsFind.AlwaysVisible = true;
            this.grdViewDevice.OptionsFind.FindMode = DevExpress.XtraEditors.FindMode.Always;
            this.grdViewDevice.OptionsFind.FindNullPrompt = "کلمه مورد نظر را وارد کنید ....";
            this.grdViewDevice.OptionsFind.SearchInPreview = true;
            this.grdViewDevice.OptionsFind.ShowClearButton = false;
            this.grdViewDevice.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.grdViewDevice.RowClick += new DevExpress.XtraGrid.Views.Grid.RowClickEventHandler(this.grdViewDevice_RowClick);
            this.grdViewDevice.DoubleClick += new System.EventHandler(this.grdViewDevice_DoubleClick);
            // 
            // GrdName
            // 
            resources.ApplyResources(this.GrdName, "GrdName");
            this.GrdName.FieldName = "DeviceName";
            this.GrdName.Name = "GrdName";
            this.GrdName.OptionsColumn.AllowSize = false;
            // 
            // GrdIP
            // 
            resources.ApplyResources(this.GrdIP, "GrdIP");
            this.GrdIP.FieldName = "IP";
            this.GrdIP.Name = "GrdIP";
            this.GrdIP.OptionsColumn.AllowSize = false;
            // 
            // GrdPort
            // 
            resources.ApplyResources(this.GrdPort, "GrdPort");
            this.GrdPort.FieldName = "Port";
            this.GrdPort.Name = "GrdPort";
            this.GrdPort.OptionsColumn.AllowSize = false;
            // 
            // grdTftpPort
            // 
            resources.ApplyResources(this.grdTftpPort, "grdTftpPort");
            this.grdTftpPort.FieldName = "UDPPort";
            this.grdTftpPort.Name = "grdTftpPort";
            this.grdTftpPort.OptionsColumn.AllowEdit = false;
            this.grdTftpPort.OptionsColumn.AllowSize = false;
            // 
            // gridView1
            // 
            this.gridView1.GridControl = this.gridViewDevice;
            this.gridView1.Name = "gridView1";
            // 
            // TopMenu
            // 
            resources.ApplyResources(this.TopMenu, "TopMenu");
            this.TopMenu.GripStyle = System.Windows.Forms.ToolStripGripStyle.Visible;
            this.TopMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.BasicInfoMenuItem,
            this.اطلاعاتToolStripMenuItem});
            this.TopMenu.Name = "TopMenu";
            this.TopMenu.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            // 
            // BasicInfoMenuItem
            // 
            this.BasicInfoMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ClientMenu,
            this.OpertManagerMenuItem,
            this.مدیریتنقشدردستگاهToolStripMenuItem});
            this.BasicInfoMenuItem.Name = "BasicInfoMenuItem";
            resources.ApplyResources(this.BasicInfoMenuItem, "BasicInfoMenuItem");
            // 
            // ClientMenu
            // 
            this.ClientMenu.Name = "ClientMenu";
            resources.ApplyResources(this.ClientMenu, "ClientMenu");
            this.ClientMenu.Click += new System.EventHandler(this.ClientMenu_Click);
            // 
            // OpertManagerMenuItem
            // 
            this.OpertManagerMenuItem.Name = "OpertManagerMenuItem";
            resources.ApplyResources(this.OpertManagerMenuItem, "OpertManagerMenuItem");
            this.OpertManagerMenuItem.Click += new System.EventHandler(this.OpertManagerMenuItem_Click);
            // 
            // مدیریتنقشدردستگاهToolStripMenuItem
            // 
            resources.ApplyResources(this.مدیریتنقشدردستگاهToolStripMenuItem, "مدیریتنقشدردستگاهToolStripMenuItem");
            this.مدیریتنقشدردستگاهToolStripMenuItem.Name = "مدیریتنقشدردستگاهToolStripMenuItem";
            this.مدیریتنقشدردستگاهToolStripMenuItem.Click += new System.EventHandler(this.مدیریتنقشدردستگاهToolStripMenuItem_Click);
            // 
            // اطلاعاتToolStripMenuItem
            // 
            this.اطلاعاتToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ImportEmployeeStripMenuItem,
            this.ImportFingerToolStripMenuItem});
            this.اطلاعاتToolStripMenuItem.Name = "اطلاعاتToolStripMenuItem";
            resources.ApplyResources(this.اطلاعاتToolStripMenuItem, "اطلاعاتToolStripMenuItem");
            // 
            // ImportEmployeeStripMenuItem
            // 
            this.ImportEmployeeStripMenuItem.Name = "ImportEmployeeStripMenuItem";
            resources.ApplyResources(this.ImportEmployeeStripMenuItem, "ImportEmployeeStripMenuItem");
            this.ImportEmployeeStripMenuItem.Click += new System.EventHandler(this.ImportEmployeeStripMenuItem_Click);
            // 
            // ImportFingerToolStripMenuItem
            // 
            this.ImportFingerToolStripMenuItem.Name = "ImportFingerToolStripMenuItem";
            resources.ApplyResources(this.ImportFingerToolStripMenuItem, "ImportFingerToolStripMenuItem");
            this.ImportFingerToolStripMenuItem.Click += new System.EventHandler(this.ImportFingerToolStripMenuItem_Click);
            // 
            // panelOnDvc
            // 
            this.panelOnDvc.Controls.Add(this.GrpOnDvc);
            resources.ApplyResources(this.panelOnDvc, "panelOnDvc");
            this.panelOnDvc.Name = "panelOnDvc";
            // 
            // MainPanel
            // 
            resources.ApplyResources(this.MainPanel, "MainPanel");
            this.MainPanel.Name = "MainPanel";
            // 
            // TrafficMenuItem
            // 
            this.TrafficMenuItem.Name = "TrafficMenuItem";
            resources.ApplyResources(this.TrafficMenuItem, "TrafficMenuItem");
            // 
            // OfflineLogMenuItem
            // 
            resources.ApplyResources(this.OfflineLogMenuItem, "OfflineLogMenuItem");
            this.OfflineLogMenuItem.Name = "OfflineLogMenuItem";
            // 
            // OnlineLogToolStripMenuItem
            // 
            resources.ApplyResources(this.OnlineLogToolStripMenuItem, "OnlineLogToolStripMenuItem");
            this.OnlineLogToolStripMenuItem.Name = "OnlineLogToolStripMenuItem";
            // 
            // NewOpert
            // 
            this.NewOpert.Name = "NewOpert";
            resources.ApplyResources(this.NewOpert, "NewOpert");
            // 
            // EditOpert
            // 
            this.EditOpert.Name = "EditOpert";
            resources.ApplyResources(this.EditOpert, "EditOpert");
            // 
            // MainFrm
            // 
            this.AllowDrop = true;
            resources.ApplyResources(this, "$this");
            this.BackColor = System.Drawing.Color.Gray;
            this.Controls.Add(this.MainPanel);
            this.Controls.Add(this.panelOnDvc);
            this.Controls.Add(this.panelDevice);
            this.Controls.Add(this.panelGuest);
            this.Controls.Add(this.panelEmp);
            this.Controls.Add(this.menu);
            this.Controls.Add(this.TopMenu);
            this.MainMenuStrip = this.TopMenu;
            this.Name = "MainFrm";
            this.TransparencyKey = System.Drawing.Color.Gainsboro;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainFrm_FormClosing);
            this.Load += new System.EventHandler(this.MainFrm_Load);
            this.Resize += new System.EventHandler(this.MainFrm_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.CheckEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemPictureEdit2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dockManager1)).EndInit();
            this.menu.ResumeLayout(false);
            this.dockPanel_Container.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nvBrCtrlMenu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdViewEmp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewEmp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelEmp)).EndInit();
            this.panelEmp.ResumeLayout(false);
            this.panelEmp.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GrpOnDvc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelGuest)).EndInit();
            this.panelGuest.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridViewGuest)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdViewGuest)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelDevice)).EndInit();
            this.panelDevice.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridViewDevice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdViewDevice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.TopMenu.ResumeLayout(false);
            this.TopMenu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelOnDvc)).EndInit();
            this.panelOnDvc.ResumeLayout(false);
            this.panelOnDvc.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MainPanel)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DockManager dockManager1;
        private ControlContainer dockPanel_Container;
        private NavBarControl nvBrCtrlMenu;
        private NavBarGroup navBarMonitor;
        private NavBarGroup navBarDevices;
        private NavBarItem navBarAddDevice;
        private NavBarGroup navBarEmployee;
        private NavBarItem navBarSetting;
        internal DockPanel menu;
        private NavBarItem navBarOnlineTrafic;
        private NavBarItem navBarOnlinePdp;
        private NavBarItem navBarAddEmp;
        private NavBarItem navBarSendEmp;
        private PanelControl panelEmp;
        private NavBarItem navBarShowDevice;
        private PanelControl panelDevice;
        private GridControl gridViewDevice;
        private GridView grdViewDevice;
        private GridView gridView1;
        private GridColumn GrdName;
        private GridColumn GrdIP;
        private GridColumn GrdPort;
        private RepositoryItemPictureEdit repositoryItemPictureEdit2;
        private GroupControl GrpOnDvc;
        private BackgroundWorker backgroundWorker1;
        private GridControl grdViewEmp;
        public RepositoryItemCheckEdit CheckEdit;
        private MenuStrip TopMenu;
        private GridView gridViewEmp;
        private GridColumn GrdFName;
        private GridColumn GrdLName;
        private GridColumn GrdEmpID;
        private GridColumn GrdCard;
        private GridColumn GrdFinger;
        private GridColumn GrdPicture;
        private GridColumn grdTftpPort;
        private BackgroundWorker backgroundWorker2;
        private ToolStripMenuItem اطلاعاتToolStripMenuItem;
        private ToolStripMenuItem ImportEmployeeStripMenuItem;
        private ComboBox CmbBxType;
        private Label lblTypeExport;
        private SimpleButton BtnPrint;
        private SimpleButton BtnExport;
        private NavBarGroup navBarLog;
        private NavBarItem navBarAllLog;
        private GridColumn GrdopertCode;
        private NavBarGroup navBarGuest;
        private NavBarItem navBarAllGuest;
        private PanelControl panelGuest;
        private GridControl gridViewGuest;
        private GridView grdViewGuest;
        private GridColumn NameCol;
        private GridColumn CardNumber;
        private NavBarItem navBarAddGuest;
        private PanelControl panelOnDvc;
        private NavBarItem navbarChartTraffic;
        private ToolStripMenuItem ImportFingerToolStripMenuItem;
        private NavBarGroup navSchaduler;
        private NavBarItem DayType;
        private NavBarItem SchGroup;
        private NavBarItem AcessGroup;
        private NavBarItem Holidays;
        private NavBarItem EmployeeGroup;
        private NavBarItem navBarFirmWare;
        private PanelControl MainPanel;
        private ToolStripMenuItem BasicInfoMenuItem;
        private ToolStripMenuItem ClientMenu;
        private ToolStripMenuItem OpertManagerMenuItem;
        private ToolStripMenuItem TrafficMenuItem;
        private ToolStripMenuItem OfflineLogMenuItem;
        private ToolStripMenuItem OnlineLogToolStripMenuItem;
        private ToolStripMenuItem NewOpert;
        private ToolStripMenuItem EditOpert;
        private GridColumn GrdOrganization;
        private NavBarItem AccessArea;
        private GridColumn GrdAcsGRoup;
        private ToolStripMenuItem مدیریتنقشدردستگاهToolStripMenuItem;
    }
}

