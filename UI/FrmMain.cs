using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Reflection;
using System.Threading;
using System.Windows.Forms;
using BLL;
using DevExpress.Utils;
using DevExpress.XtraBars.Docking;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Layout;
using DevExpress.XtraNavBar;
using Eco;
using Model;

namespace UI
{
    public partial class MainFrm : Form
    {
        private readonly FrmAllLogs _frmAllLogs = new FrmAllLogs { TopLevel = false };
        private List<Device> _devices;
        private Thread[] _deviceThreads;
        private PictureBox[] _echoGallery;
        private Thread _pingThread;
        private Thread _trafficLogThread;
        private readonly DeviceBLL deviceBll = new DeviceBLL();
        private bool flag;
        private bool flagBigSize;
        private bool flagRefresh = true;
        private bool flagSmallSize;
        private Thread show;
        private Socket[] sockets;


        /// <summary>`
        ///     this is constractor
        /// </summary>
        public MainFrm()
        {
            InitializeComponent();
            panelOnDvc.AutoScroll = true;
            gridViewEmp.GroupPanelText = @"جهت فیلتر کردن هر ستون ستون مورد نظر را به این قسمت بکشید";
            grdViewDevice.GroupPanelText = @"جهت فیلتر کردن هر ستون ستون مورد نظر را به این قسمت بکشید";
        }


        private void MainFrm_Load(object sender, EventArgs e)
        {
            MainPanel.Dock = DockStyle.Fill;
            panelOnDvc.Dock = DockStyle.Fill;
            panelDevice.Dock = DockStyle.Fill;
            panelEmp.Dock = DockStyle.Fill;
            panelGuest.Dock = DockStyle.Fill;
        }

        private void MainFrm_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                KillDeviceThreads();

                //if (_frmSentryMonitor.MainSocket.Connected)
                //    _frmSentryMonitor.MainSocket.Close();
                //_frmSentryMonitor.Close();
                _pingThread.Abort();
                //this.Close();
                Application.Exit();
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }

        }

        //Created By Amirhossiensz ....

        #region Show Online traffic per day ....

        /// <summary>
        ///     Event for showing Online traffic
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void navBarOnlineTrafic_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            try
            {
                HeighLightText("navBarOnlineTrafic");

                KillDeviceThreads();

                FrmSentryMonitor frmSentryMonitor = new FrmSentryMonitor();
                frmSentryMonitor.ShowDialog();

            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
            }
        }

        #endregion

        private void ClientMenu_Click(object sender, EventArgs e)
        {
            try
            {
                KillDeviceThreads();

                var frmClient = new FrmClient();
                frmClient.ShowDialog();
            }
            catch (Exception)
            {
                throw;
            }
        }


        private void OpertManagerMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                KillDeviceThreads();

                var frmEditOperator = new FrmEditOperator();
                frmEditOperator.ShowDialog();
            }
            catch (Exception)
            {
                throw;
            }
        }

        //Created By Amirhossiensz ....

        #region Show Online Eco.....

        /// <summary>
        ///     Event link for show online ECO
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void navBarOnlinePdp_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            try
            {
                ShowSmalSize();
            }
            catch (Exception)
            {
                throw;
            }
        }


        /// <summary>
        ///     Resize Main Form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainFrm_Resize(object sender, EventArgs e)
        {
            if (panelOnDvc.Visible)
            {
                if (WindowState == FormWindowState.Maximized && flagBigSize)
                    ShowBigSize();
                if (WindowState == FormWindowState.Maximized && flagSmallSize)
                    ShowSmalSize();
                if (Width == 1100 && Height == 610 && flagSmallSize)
                    ShowSmalSize();
                if (Width == 1100 && Height == 610 && flagBigSize)
                    ShowBigSize();
            }
        }


        /// <summary>
        ///     Event for when the menu is collapsed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menu_Collapsed(object sender, DockPanelEventArgs e)
        {
            if (panelOnDvc.Visible)
                ShowBigSize();
        }

        /// <summary>
        ///     Event for when the menu is Expanding
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menu_Expanding(object sender, DockPanelCancelEventArgs e)
        {
            if (panelOnDvc.Visible)
                ShowSmalSize();
        }

        /// <summary>
        ///     HeighLight title when click on it
        /// </summary>
        /// <param name="text"></param>
        private void HeighLightText(string text)
        {
            switch (text)
            {
                case "navBarOnlinePdp":
                    navBarOnlinePdp.Appearance.ForeColor = Color.Blue;
                    navBarOnlineTrafic.Appearance.ForeColor = Color.Black;
                    navBarShowDevice.Appearance.ForeColor = Color.Black;
                    navBarAddDevice.Appearance.ForeColor = Color.Black;
                    navBarAddEmp.Appearance.ForeColor = Color.Black;
                    navBarSendEmp.Appearance.ForeColor = Color.Black;
                    navBarSetting.Appearance.ForeColor = Color.Black;
                    navBarAllLog.Appearance.ForeColor = Color.Black;
                    navBarAllGuest.Appearance.ForeColor = Color.Black;
                    navBarAddGuest.Appearance.ForeColor = Color.Black;
                    navbarChartTraffic.Appearance.ForeColor = Color.Black;
                    break;
                case "navBarOnlineTrafic":
                    navBarOnlinePdp.Appearance.ForeColor = Color.Black;
                    navBarOnlineTrafic.Appearance.ForeColor = Color.Blue;
                    navBarShowDevice.Appearance.ForeColor = Color.Black;
                    navBarAddDevice.Appearance.ForeColor = Color.Black;
                    navBarAddEmp.Appearance.ForeColor = Color.Black;
                    navBarSendEmp.Appearance.ForeColor = Color.Black;
                    navBarSetting.Appearance.ForeColor = Color.Black;
                    navBarAllLog.Appearance.ForeColor = Color.Black;
                    navBarAllGuest.Appearance.ForeColor = Color.Black;
                    navBarAddGuest.Appearance.ForeColor = Color.Black;
                    navbarChartTraffic.Appearance.ForeColor = Color.Black;
                    break;
                case "navBarShowEmp":
                    navBarOnlinePdp.Appearance.ForeColor = Color.Black;
                    navBarOnlineTrafic.Appearance.ForeColor = Color.Black;
                    navBarShowDevice.Appearance.ForeColor = Color.Black;
                    navBarAddDevice.Appearance.ForeColor = Color.Black;
                    navBarAddEmp.Appearance.ForeColor = Color.Black;
                    navBarSendEmp.Appearance.ForeColor = Color.Black;
                    navBarSetting.Appearance.ForeColor = Color.Black;
                    navBarAllLog.Appearance.ForeColor = Color.Black;
                    navBarAllGuest.Appearance.ForeColor = Color.Black;
                    navBarAddGuest.Appearance.ForeColor = Color.Black;
                    navbarChartTraffic.Appearance.ForeColor = Color.Black;
                    break;
                case "navBarShowDevice":
                    navBarOnlinePdp.Appearance.ForeColor = Color.Black;
                    navBarOnlineTrafic.Appearance.ForeColor = Color.Black;
                    navBarShowDevice.Appearance.ForeColor = Color.Blue;
                    navBarAddDevice.Appearance.ForeColor = Color.Black;
                    navBarAddEmp.Appearance.ForeColor = Color.Black;
                    navBarSendEmp.Appearance.ForeColor = Color.Black;
                    navBarSetting.Appearance.ForeColor = Color.Black;
                    navBarAllLog.Appearance.ForeColor = Color.Black;
                    navBarAllGuest.Appearance.ForeColor = Color.Black;
                    navBarAddGuest.Appearance.ForeColor = Color.Black;
                    navbarChartTraffic.Appearance.ForeColor = Color.Black;
                    break;
                case "navBarAddDevice":
                    navBarOnlinePdp.Appearance.ForeColor = Color.Black;
                    navBarOnlineTrafic.Appearance.ForeColor = Color.Black;
                    navBarShowDevice.Appearance.ForeColor = Color.Black;
                    navBarAddDevice.Appearance.ForeColor = Color.Blue;
                    navBarAddEmp.Appearance.ForeColor = Color.Black;
                    navBarSendEmp.Appearance.ForeColor = Color.Black;
                    navBarSetting.Appearance.ForeColor = Color.Black;
                    navBarAllLog.Appearance.ForeColor = Color.Black;
                    navBarAllGuest.Appearance.ForeColor = Color.Black;
                    navBarAddGuest.Appearance.ForeColor = Color.Black;
                    navbarChartTraffic.Appearance.ForeColor = Color.Black;
                    break;
                case "navBarAddEmp":
                    navBarOnlinePdp.Appearance.ForeColor = Color.Black;
                    navBarOnlineTrafic.Appearance.ForeColor = Color.Black;
                    navBarShowDevice.Appearance.ForeColor = Color.Black;
                    navBarAddDevice.Appearance.ForeColor = Color.Black;
                    navBarAddEmp.Appearance.ForeColor = Color.Blue;
                    navBarSendEmp.Appearance.ForeColor = Color.Black;
                    navBarSetting.Appearance.ForeColor = Color.Black;
                    navBarAllLog.Appearance.ForeColor = Color.Black;
                    navBarAllGuest.Appearance.ForeColor = Color.Black;
                    navBarAddGuest.Appearance.ForeColor = Color.Black;
                    navbarChartTraffic.Appearance.ForeColor = Color.Black;
                    break;
                case "navBarSendEmp":
                    navBarOnlinePdp.Appearance.ForeColor = Color.Black;
                    navBarOnlineTrafic.Appearance.ForeColor = Color.Black;
                    navBarShowDevice.Appearance.ForeColor = Color.Black;
                    navBarAddDevice.Appearance.ForeColor = Color.Black;
                    navBarAddEmp.Appearance.ForeColor = Color.Black;
                    navBarSendEmp.Appearance.ForeColor = Color.Blue;
                    navBarSetting.Appearance.ForeColor = Color.Black;
                    navBarAllLog.Appearance.ForeColor = Color.Black;
                    navBarAllGuest.Appearance.ForeColor = Color.Black;
                    navBarAddGuest.Appearance.ForeColor = Color.Black;
                    navbarChartTraffic.Appearance.ForeColor = Color.Black;
                    break;
                case "navBarSetting":
                    navBarOnlinePdp.Appearance.ForeColor = Color.Black;
                    navBarOnlineTrafic.Appearance.ForeColor = Color.Black;
                    navBarShowDevice.Appearance.ForeColor = Color.Black;
                    navBarAddDevice.Appearance.ForeColor = Color.Black;
                    navBarAddEmp.Appearance.ForeColor = Color.Black;
                    navBarSendEmp.Appearance.ForeColor = Color.Black;
                    navBarSetting.Appearance.ForeColor = Color.Blue;
                    navBarAllLog.Appearance.ForeColor = Color.Black;
                    navBarAllGuest.Appearance.ForeColor = Color.Black;
                    navBarAddGuest.Appearance.ForeColor = Color.Black;
                    navbarChartTraffic.Appearance.ForeColor = Color.Black;
                    break;
                case "navBarAllLog":
                    navBarOnlinePdp.Appearance.ForeColor = Color.Black;
                    navBarOnlineTrafic.Appearance.ForeColor = Color.Black;
                    navBarShowDevice.Appearance.ForeColor = Color.Black;
                    navBarAddDevice.Appearance.ForeColor = Color.Black;
                    navBarAddEmp.Appearance.ForeColor = Color.Black;
                    navBarSendEmp.Appearance.ForeColor = Color.Black;
                    navBarSetting.Appearance.ForeColor = Color.Black;
                    navBarAllLog.Appearance.ForeColor = Color.Blue;
                    navBarAllGuest.Appearance.ForeColor = Color.Black;
                    navBarAddGuest.Appearance.ForeColor = Color.Black;
                    navbarChartTraffic.Appearance.ForeColor = Color.Black;
                    break;
                case "navBarAllGuest":
                    navBarOnlinePdp.Appearance.ForeColor = Color.Black;
                    navBarOnlineTrafic.Appearance.ForeColor = Color.Black;
                    navBarShowDevice.Appearance.ForeColor = Color.Black;
                    navBarAddDevice.Appearance.ForeColor = Color.Black;
                    navBarAddEmp.Appearance.ForeColor = Color.Black;
                    navBarSendEmp.Appearance.ForeColor = Color.Black;
                    navBarSetting.Appearance.ForeColor = Color.Black;
                    navBarAllLog.Appearance.ForeColor = Color.Black;
                    navBarAllGuest.Appearance.ForeColor = Color.Blue;
                    navBarAddGuest.Appearance.ForeColor = Color.Black;
                    navbarChartTraffic.Appearance.ForeColor = Color.Black;
                    break;
                case "navBarAddGuest":
                    navBarOnlinePdp.Appearance.ForeColor = Color.Black;
                    navBarOnlineTrafic.Appearance.ForeColor = Color.Black;
                    navBarShowDevice.Appearance.ForeColor = Color.Black;
                    navBarAddDevice.Appearance.ForeColor = Color.Black;
                    navBarAddEmp.Appearance.ForeColor = Color.Black;
                    navBarSendEmp.Appearance.ForeColor = Color.Black;
                    navBarSetting.Appearance.ForeColor = Color.Black;
                    navBarAllLog.Appearance.ForeColor = Color.Black;
                    navBarAllGuest.Appearance.ForeColor = Color.Black;
                    navBarAddGuest.Appearance.ForeColor = Color.Blue;
                    navbarChartTraffic.Appearance.ForeColor = Color.Black;
                    break;
                case "navbarChartTraffic":
                    navBarOnlinePdp.Appearance.ForeColor = Color.Black;
                    navBarOnlineTrafic.Appearance.ForeColor = Color.Black;
                    navBarShowDevice.Appearance.ForeColor = Color.Black;
                    navBarAddDevice.Appearance.ForeColor = Color.Black;
                    navBarAddEmp.Appearance.ForeColor = Color.Black;
                    navBarSendEmp.Appearance.ForeColor = Color.Black;
                    navBarSetting.Appearance.ForeColor = Color.Black;
                    navBarAllLog.Appearance.ForeColor = Color.Black;
                    navBarAllGuest.Appearance.ForeColor = Color.Black;
                    navBarAddGuest.Appearance.ForeColor = Color.Black;
                    navbarChartTraffic.Appearance.ForeColor = Color.Blue;
                    break;
            }
        }

        //Show Big Size.....

        private void ShowBigSize()
        {
            try
            {
                HeighLightText("navBarOnlinePdp");
                flagBigSize = true;
                flagSmallSize = false;
                KillDeviceThreads();

                GrpOnDvc.Controls.Clear();
                var device = new DeviceBLL();
                var show = panelOnDvc;
                show.Visible = true;
                show = panelEmp;
                show.Visible = false;
                show = MainPanel;
                show.Visible = false;
                show = panelDevice;
                show.Visible = false;
                show = panelGuest;
                show.Visible = false;
                _devices = new List<Device>();
                //Size bigsize = new Size(1045, 549);
                var size = new Size(Width - 40, Height - 69);

                //Create UI Of the Online ECO page


                GrpOnDvc.Size = size;


                _devices = device.SelectDevices();

                _echoGallery = new PictureBox[_devices.Count];
                var lblOnDvcName = new Label[_devices.Count];
                var lblIpDvc = new Label[_devices.Count];

                var deviceCounter = 0;


                foreach (var Device in _devices)
                {
                    lblOnDvcName[deviceCounter] = new Label();
                    _echoGallery[deviceCounter] = new PictureBox();
                    lblIpDvc[deviceCounter] = new Label();


                    lblOnDvcName[deviceCounter].Font = new Font("B Nazanin", 12);

                    var imagesDirectory =

                        // ReSharper disable once AssignNullToNotNullAttribute
                        Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "Images");
                    _echoGallery[deviceCounter].Image = Image.FromFile(imagesDirectory + "\\OflineEco.gif");

                    _echoGallery[deviceCounter].Width = 90;
                    _echoGallery[deviceCounter].Height = 90;

                    _echoGallery[deviceCounter].Text = Device.DeviceName;
                    lblOnDvcName[deviceCounter].Text = Device.DeviceName;
                    lblIpDvc[deviceCounter].Text = Device.IP;

                    _echoGallery[deviceCounter].Location = new Point((((deviceCounter) % 6) * 170) + 50,
                        (deviceCounter) / 6 * 150 + 20);
                    lblOnDvcName[deviceCounter].Location = new Point((((deviceCounter) % 6) * 170) + 30,
                        (deviceCounter) / 6 * 150 + 110);
                    lblIpDvc[deviceCounter].Location = new Point((((deviceCounter) % 6) * 170) + 30,
                        (deviceCounter) / 6 * 150 + 140);


                    _echoGallery[deviceCounter].Visible = true;
                    lblOnDvcName[deviceCounter].Visible = true;
                    lblIpDvc[deviceCounter].Visible = true;


                    GrpOnDvc.Controls.Add(lblOnDvcName[deviceCounter]);
                    GrpOnDvc.Controls.Add(lblIpDvc[deviceCounter]);
                    GrpOnDvc.Controls.Add(_echoGallery[deviceCounter]);


                    deviceCounter++;
                }

                if (deviceCounter >= 24)
                {
                    var s = new Size(Width - 40, deviceCounter / 6 * 250);
                    GrpOnDvc.Size = s;
                }

                GrpOnDvc.Refresh();

                var counter = _devices.Count;


                _pingThread = new Thread(() => StartPing(_echoGallery));
                _pingThread.Start();
                //_deviceThreads = new Thread[_devices.Count];

                //for (int i = 0; i < counter; i++)
                //{
                //    int index = i;
                //    _deviceThreads[index] = new Thread(() => StartDvcThread( _devices[index], _echoGallery[index]));

                //    _deviceThreads[index].Start();
                //}               
            }
            catch (ArgumentNullException e2)
            {
                Console.WriteLine(@"ArgumentNullException: {0}", e2);
            }
            catch (SocketException e1)
            {
                Console.WriteLine(@"SocketException: {0}", e1);
            }
        }

        //Show small size.....
        private void ShowSmalSize()
        {
            try
            {
                HeighLightText("navBarOnlinePdp");
                flagSmallSize = true;
                flagBigSize = false;
                KillDeviceThreads();
                GrpOnDvc.Controls.Clear();
                var device = new DeviceBLL();
                var show = panelOnDvc;
                show.Visible = true;
                show = panelEmp;
                show.Visible = false;
                show = MainPanel;
                show.Visible = false;
                show = panelDevice;
                show.Visible = false;
                show = panelGuest;
                show.Visible = false;
                _devices = new List<Device>();
                var samalsize = new Size(Width - 250, Height - 75);
                GrpOnDvc.Size = samalsize;

                _devices = device.SelectDevices();

                _echoGallery = new PictureBox[_devices.Count];
                var lblOnDvcName = new Label[_devices.Count];
                var lblIpDvc = new Label[_devices.Count];

                var deviceCounter = 0;


                foreach (var Device in _devices)
                {
                    lblOnDvcName[deviceCounter] = new Label();
                    _echoGallery[deviceCounter] = new PictureBox();
                    lblIpDvc[deviceCounter] = new Label();


                    lblOnDvcName[deviceCounter].Font = new Font("B Nazanin", 12);

                    var imagesDirectory =

                        // ReSharper disable once AssignNullToNotNullAttribute
                        Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "Images");
                    _echoGallery[deviceCounter].Image = Image.FromFile(imagesDirectory + "\\OflineEco.gif");

                    _echoGallery[deviceCounter].Width = 90;
                    _echoGallery[deviceCounter].Height = 90;

                    _echoGallery[deviceCounter].Text = Device.DeviceName;
                    lblOnDvcName[deviceCounter].Text = Device.DeviceName;
                    lblIpDvc[deviceCounter].Text = Device.IP;

                    _echoGallery[deviceCounter].Location = new Point((((deviceCounter) % 5) * 150) + 50,
                        (deviceCounter) / 5 * 150 + 20);
                    lblOnDvcName[deviceCounter].Location = new Point((((deviceCounter) % 5) * 150) + 30,
                        (deviceCounter) / 5 * 150 + 110);
                    lblIpDvc[deviceCounter].Location = new Point((((deviceCounter) % 5) * 150) + 30,
                        (deviceCounter) / 5 * 150 + 140);


                    _echoGallery[deviceCounter].Visible = true;
                    lblOnDvcName[deviceCounter].Visible = true;
                    lblIpDvc[deviceCounter].Visible = true;


                    GrpOnDvc.Controls.Add(lblOnDvcName[deviceCounter]);
                    GrpOnDvc.Controls.Add(lblIpDvc[deviceCounter]);
                    GrpOnDvc.Controls.Add(_echoGallery[deviceCounter]);

                    deviceCounter++;
                }

                if (deviceCounter >= 15)
                {
                    var s = new Size(Width - 250, deviceCounter / 6 * 200);
                    GrpOnDvc.Size = s;
                }
                GrpOnDvc.Refresh();

                var counter = _devices.Count;


                //_deviceThreads = new Thread[_devices.Count];


                _pingThread = new Thread(() => StartPing(_echoGallery));
                _pingThread.Start();

                //
                //                for (int i = 0; i < counter; i++)
                //                {
                //                    int index = i;
                //                    sockets[index]= new Socket(AddressFamily.InterNetwork,SocketType.Stream, ProtocolType.Tcp);
                //                    SRM.Add(_devices[index].IP,sockets[index]);
                //                }
                //
                //                for (int i = 0; i < 1; i++)
                //                {
                //                    int index = i;
                //                    _deviceThreads[index] = new Thread(() => StartDvcThread(sockets[index], _devices[index], _echoGallery[index]));
                //                    
                //                    _deviceThreads[index].Start();
                //                }

                //for (int i = 0; i < counter; i++)
                //{
                //    int index = i;
                //   // sockets[index] = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                //    _deviceThreads[index] = new Thread(() => StartDvcThread(_devices[index], _echoGallery[index]));

                //    _deviceThreads[index].Start();
                //}
            }
            catch (ArgumentNullException e2)
            {
                Console.WriteLine(@"ArgumentNullException: {0}", e2);
            }
            catch (SocketException e1)
            {
                Console.WriteLine(@"SocketException: {0}", e1);
            }
        }

        private void StartPing(PictureBox[] echoGallery)
        {

            while (_pingThread.IsAlive)
            {
                var i = 0;
                foreach (var device in _devices)
                {
                    var bll = new DeviceBLL();
                    var connect = false;
                    var imagesDirectory =
                        Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "Images");
                    try
                    {
                        connect = bll.Ping(device.IP, device.Port);
                        //    deviceBll.NewPing(sck,device);

                        echoGallery[i].Image =
                            Image.FromFile(connect
                                ? imagesDirectory + "\\OnlineEco.gif"
                                : imagesDirectory + "\\OflineEco.gif");
                    }
                    catch (PingException exception)
                    {
                        Console.WriteLine(exception.Message);
                    }
                    //   connect = deviceBll.Ping(sck,device.IP, device.Port, device.ServerIP);

                    i++;
                }
            }
        }


        /// <summary>
        ///     Method of thread for Show online device
        /// </summary>
        /// <param name="device"></param>
        /// <param name="echoGallery"></param>
        /// <summary>
        ///     This Method Kill Thread of showing online ECO
        /// </summary>
        private void KillDeviceThreads()
        {
            try
            {
                if (_pingThread == null)
                    return;
                if (_pingThread.IsAlive)
                {
                    _pingThread.Abort();
                    _pingThread.Join();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion

        //Created By Amirhossiensz ....

        #region Device Management

        /// <summary>
        ///     This is Event for showing All devices
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <summary>
        ///     This is event for Adding device form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void navBarAddDevice_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            KillDeviceThreads();

            HeighLightText("navBarAddDevice");
            //**************
            var Show = panelDevice;
            Show.Visible = true;
            Show = panelOnDvc;
            Show.Visible = false;
            Show = panelEmp;
            Show.Visible = false;
            Show = MainPanel;
            Show.Visible = false;
            Show = panelGuest;
            Show.Visible = false;

            gridViewDevice.DataSource = deviceBll.SelectDevices();
            //**************

            var frmAddDevice = new FrmAddDevice();
            frmAddDevice.ShowDialog();

            gridViewDevice.DataSource = deviceBll.SelectDevices();
        }


        /// <summary>
        ///     This event for showin Setting form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void navBarSetting_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            KillDeviceThreads();


            //**********************
            HeighLightText("navBarSetting");
            var Show = panelDevice;
            Show.Visible = true;
            Show = panelOnDvc;
            Show.Visible = false;
            Show = panelEmp;
            Show.Visible = false;
            Show = MainPanel;
            Show.Visible = false;
            Show = panelGuest;
            Show.Visible = false;

            // DeviceBLL deviceBll = new DeviceBLL();
            gridViewDevice.DataSource = deviceBll.SelectDevices();


            //**********************

            var frmSetting = new FrmSetting();
            frmSetting.ShowDialog();
        }


        /// <summary>
        ///     This is right Click event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void grdViewDevice_RowClick(object sender, RowClickEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                var rightClickMenu = new ContextMenu();

                rightClickMenu.MenuItems.Add(new MenuItem("حذف"));
                rightClickMenu.MenuItems.Add(new MenuItem("راه اندازی مجدد"));
                //rightClickMenu.MenuItems.Add(new MenuItem("راه انداز ریدر اول"));
                //rightClickMenu.MenuItems.Add(new MenuItem("راه انداز ریدر دوم"));
                rightClickMenu.MenuItems.Add(new MenuItem("گرفتن اطلاعات از دستگاه"));



                //  rightClickMenu.MenuItems.Add(new MenuItem("ویرایش"));
                //    rightClickMenu.MenuItems.Add(new MenuItem(" ویرایش تنظیمات"));
                //    rightClickMenu.MenuItems.Add(new MenuItem(" همزمانی زمان"));
                //   rightClickMenu.MenuItems.Add(new MenuItem("لیست دسترسی ها"));
                
                var point = new Point(e.X, e.Y);

                rightClickMenu.Show(gridViewDevice, point);
                rightClickMenu.MenuItems[0].Click += rightClickDeleteDevice_Click;
                rightClickMenu.MenuItems[1].Click += rightClickResetDevice_Click;
                //rightClickMenu.MenuItems[2].Click += rightClickFo1Device_Click;
                //rightClickMenu.MenuItems[3].Click += rightClickFo2Device_Click;
                rightClickMenu.MenuItems[2].Click += rightClickGetInfofromDevice_Click;
                //   rightClickMenu.MenuItems[1].Click += new EventHandler(this.rightClickEditeDevice_Click);
                //     rightClickMenu.MenuItems[1].Click += new EventHandler(this.rightClickEditeSetting_Click);
                //     rightClickMenu.MenuItems[2].Click += new EventHandler(this.rightClickSyncDevice_Click);
                //    rightClickMenu.MenuItems[3].Click += new EventHandler(this.rigtClickEmployeeInDevice_Click);
            }
        }

        private void rightClickGetInfofromDevice_Click(object sender, EventArgs e)
        {
            try
            {
                var index = grdViewDevice.FocusedRowHandle;
                var id = grdViewDevice.GetRowCellValue(index, "ID");
                var device = deviceBll.SelectOneDevices((int)id);
                var frmGetInfo = new FrmGetInfo(device);
                frmGetInfo.ShowDialog();
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
            }
        }

        private void rightClickFo2Device_Click(object sender, EventArgs e)
        {
            try
            {
                var index = grdViewDevice.FocusedRowHandle;
                var id = grdViewDevice.GetRowCellValue(index, "ID");
                var device = deviceBll.SelectOneDevices((int)id);
                var sendResponse = deviceBll.SendForceOpen2(device).Substring(0, 1);

                if (sendResponse == "1")
                {
                    MessageBox.Show(@"تحریک ریدر 2 ، انجام گردید!", @"پیام", MessageBoxButtons.OK,
                        MessageBoxIcon.Information, MessageBoxDefaultButton.Button1,
                        MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                }


                if (sendResponse == "2")
                {
                    MessageBox.Show(@"دستگاه در شبکه موجود نمی باشد!", @"پیام", MessageBoxButtons.OK,
                        MessageBoxIcon.Information, MessageBoxDefaultButton.Button1,
                        MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                }

                if (sendResponse == "3")
                {
                    MessageBox.Show(@"عملیات با مشکل مواجه شد!", @"هشدار", MessageBoxButtons.OK,
                        MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1,
                        MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                }
                if (sendResponse == "4")
                {
                    MessageBox.Show(@"مشکل ارسال در سرویس دوباره تلاش کنید!", @"هشدار", MessageBoxButtons.OK,
                        MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1,
                        MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                }

                if (sendResponse == "5")
                {
                    MessageBox.Show(@"وضیت سرویس نرم افزار را بررسی کنید!", @"هشدار", MessageBoxButtons.OK,
                        MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1,
                        MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void rightClickFo1Device_Click(object sender, EventArgs e)
        {
            try
            {
                var index = grdViewDevice.FocusedRowHandle;
                var id = grdViewDevice.GetRowCellValue(index, "ID");
                var device = deviceBll.SelectOneDevices((int)id);
                var sendResponse = deviceBll.SendForceOpen1(device).Substring(0, 1);


                if (sendResponse == "1")
                {
                    MessageBox.Show(@"تحریک ریدر 1 ، انجام گردید!", @"پیام", MessageBoxButtons.OK,
                        MessageBoxIcon.Information, MessageBoxDefaultButton.Button1,
                        MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                }


                if (sendResponse == "2")
                {
                    MessageBox.Show(@"دستگاه در شبکه موجود نمی باشد!", @"پیام", MessageBoxButtons.OK,
                        MessageBoxIcon.Information, MessageBoxDefaultButton.Button1,
                        MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                }

                if (sendResponse == "3")
                {
                    MessageBox.Show(@"عملیات با مشکل مواجه شد!", @"هشدار", MessageBoxButtons.OK,
                        MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1,
                        MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                }
                if (sendResponse == "4")
                {
                    MessageBox.Show(@"مشکل ارسال در سرویس دوباره تلاش کنید!", @"هشدار", MessageBoxButtons.OK,
                        MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1,
                        MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                }

                if (sendResponse == "5")
                {
                    MessageBox.Show(@"وضیت سرویس نرم افزار را بررسی کنید!", @"هشدار", MessageBoxButtons.OK,
                        MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1,
                        MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void rightClickResetDevice_Click(object sender, EventArgs e)
        {
            try
            {
                var index = grdViewDevice.FocusedRowHandle;
                var id = grdViewDevice.GetRowCellValue(index, "ID");
                var device = deviceBll.SelectOneDevices((int)id);
                var sendreturn = deviceBll.ResetDevice(device).Substring(0, 1);

                if (sendreturn == "1")
                {
                    MessageBox.Show(@"راه اندازی مجدد ، انجام گردید!", @"پیام", MessageBoxButtons.OK,
                        MessageBoxIcon.Information, MessageBoxDefaultButton.Button1,
                        MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                }


                if (sendreturn == "2")
                {
                    MessageBox.Show(@"دستگاه در شبکه موجود نمی باشد!", @"پیام", MessageBoxButtons.OK,
                        MessageBoxIcon.Information, MessageBoxDefaultButton.Button1,
                        MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                }

                if (sendreturn == "3")
                {
                    MessageBox.Show(@"عملیات با مشکل مواجه شد!", @"هشدار", MessageBoxButtons.OK,
                        MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1,
                        MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                }
                if (sendreturn == "4")
                {
                    MessageBox.Show(@"مشکل ارسال در سرویس دوباره تلاش کنید!", @"هشدار", MessageBoxButtons.OK,
                        MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1,
                        MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                }

                if (sendreturn == "5")
                {
                    MessageBox.Show(@"وضیت سرویس نرم افزار را بررسی کنید!", @"هشدار", MessageBoxButtons.OK,
                        MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1,
                        MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                }
            }
            catch (Exception exception)
            {
                throw;
            }
        }


        private void grdViewDevice_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                var index = grdViewDevice.FocusedRowHandle;
                var id = grdViewDevice.GetRowCellValue(index, "ID");
                var frmAddDevice = new FrmAddDevice(true, deviceBll.SelectOneDevices((int)id))
                {
                    Text = @"ویرایش دستگاه"
                };

                frmAddDevice.ShowDialog();
                gridViewDevice.DataSource = deviceBll.SelectDevices();
            }
            catch (Exception)
            {
                throw;
            }
        }


        private void rightClickSyncDevice_Click(object sender, EventArgs e)
        {
            var index = grdViewDevice.FocusedRowHandle;
            var id = grdViewDevice.GetRowCellValue(index, "ID");
            var device = deviceBll.SelectOneDevices((int)id);
            var sendreturn = deviceBll.SendSync(device);

            if (sendreturn == 1)
            {
                MessageBox.Show(@"همگام سازی انجام گرفت.", @"پیام", MessageBoxButtons.OK,
                    MessageBoxIcon.Information, MessageBoxDefaultButton.Button1,
                    MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
            }
            if (sendreturn == 2)
            {
                MessageBox.Show(@"دستگاه در شبکه موجود نمی باشد.", @"پیام", MessageBoxButtons.OK,
                    MessageBoxIcon.Information, MessageBoxDefaultButton.Button1,
                    MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
            }
            if (sendreturn == 3)
            {
                MessageBox.Show(@"عملیات با مشکل مواجه شد.", @"هشدار", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1,
                    MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
            }
            if (sendreturn == 4)
            {
                MessageBox.Show(@"مشکل ارسال در سرویس دوباره تلاش کنید.", @"هشدار", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1,
                    MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
            }
            if (sendreturn == 5)
            {
                MessageBox.Show(@"وضعیت سرویس نرم افزار را بررسی کنید.", @"هشدار", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1,
                    MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
            }
        }


        /// <summary>
        ///     This event for Edit Setting of per device
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        //private void rightClickEditeSetting_Click(object sender, EventArgs e)
        //{
        //    var index = grdViewDevice.FocusedRowHandle;
        //    var id = grdViewDevice.GetRowCellValue(index, "ID");

        //    var device = deviceBll.SelectOneDevices((int) id);

        //    // if (deviceBll.Ping(device.IP,device.Port,device.ServerIP))
        //    if (deviceBll.Ping(device.IP, device.Port))
        //    {
        //        var frmSetting = new FrmSetting(true, deviceBll.SelectOneDevices((int) id));
        //        frmSetting.ShowDialog();
        //    }
        //    else
        //    {
        //        var result = MessageBox.Show(@"امکان برقرار ارتباط با دستگاه موجود نمی باشد!!!", @"هشدار",
        //            MessageBoxButtons.OK,
        //            MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1,
        //            MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
        //        if (result == DialogResult.OK)
        //        {
        //            //                    var frmSetting = new FrmSetting(false);
        //            //                    frmSetting.ShowDialog();
        //        }
        //    }
        //    gridViewDevice.DataSource = deviceBll.SelectDevices();
        //}

        /// <summary>
        ///     This is Event for Delete Device
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rightClickDeleteDevice_Click(object sender, EventArgs e)
        {
            var settingBll = new SettingBLL();
            var deviceEmpBll = new DeviceEmpBll();

            var index = grdViewDevice.FocusedRowHandle;
            var id = grdViewDevice.GetRowCellValue(index, "ID");

            var result = MessageBox.Show(@"آیا مطمئن به حذف دستگاه مورد نظر  هستید?", @"هشدار",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1,
                MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
            if (result == DialogResult.Yes)
            {
                deviceEmpBll.DeletedevicefromDeviceEmp(id);
                settingBll.DeleteOneSetting(id);
                deviceBll.DeleteOneDevice(id);
            }
            gridViewDevice.DataSource = deviceBll.SelectDevices();
        }


        /// <summary>
        ///     This is Event for showin Access Employees per device
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        //private void rigtClickEmployeeInDevice_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        var index = grdViewDevice.FocusedRowHandle;
        //        var id = grdViewDevice.GetRowCellValue(index, "ID");
        //        var device = deviceBll.SelectOneDevices((int) id);
        //        //if (deviceBll.Ping(device.IP, device.Port, device.ServerIP))
        //        if (deviceBll.Ping(device.IP, device.Port))
        //        {
        //            var frmEmpInDevice = new FrmAccess(device);
        //            // var frmEmpInDevice = new FrmDeviceInfo(device);
        //            frmEmpInDevice.ShowDialog();
        //        }
        //        else
        //        {
        //            var result = MessageBox.Show(@"امکان برقرار ارتباط با دستگاه موجود نمی باشد!!!", @"هشدار",
        //                MessageBoxButtons.OK,
        //                MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1,
        //                MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
        //        }
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //}

        #endregion

        //Created By Amirhossiensz ....

        #region Employee Managment

        /// <summary>
        ///     This method change view to card view
        /// </summary>
        /// <param name="Grid"></param>
        /// <param name="node"></param>
        /// <param name="viewName"></param>
        /// <param name="removeOld"></param>
        private void ChangeView(GridControl Grid, GridLevelNode node, string viewName, bool removeOld)
        {
            var levelNode = node;
            if (levelNode == null) return;
            var view = Grid.CreateView(viewName);
            Grid.ViewCollection.Add(view);
            var lView = new LayoutView(Grid);

            var prev = levelNode.LevelTemplate;
            MemoryStream ms = null;

            if (prev != null)
            {
                ms = new MemoryStream();
                prev.SaveLayoutToStream(ms, OptionsLayoutBase.FullLayout);
            }

            if (node.IsRootLevel)
            {
                prev = Grid.MainView;
                Grid.MainView = view;
            }
            else
            {
                levelNode.LevelTemplate = view;
            }
            if (ms != null)
            {
                lView.DetailAutoHeight = true;
                if (removeOld && prev != null) prev.Dispose();
                ms.Seek(0, SeekOrigin.Begin);
                view.RestoreLayoutFromStream(ms, OptionsLayoutBase.FullLayout);
                ms.Close();
                var mi = view.GetType()
                    .GetMethod("DesignerMakeColumnsVisible",
                        BindingFlags.InvokeMethod | BindingFlags.NonPublic | BindingFlags.Instance);
                if (mi != null) mi.Invoke(view, null);
                if (prev != null) AssignViewProperties(prev, view);
            }
            if (removeOld && prev != null) prev.Dispose();
        }

        private void AssignViewProperties(BaseView prev, BaseView view)
        {
            ColumnView cprev = prev as ColumnView, cview = view as ColumnView;
            var lView = new LayoutView();
            if (cprev != null && cview != null)
            {
                cview.Images = cprev.Images;
            }
        }


        /// <summary>
        ///     This event is for show add employee form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void navBarAddEmp_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            KillDeviceThreads();
            //******************
            HeighLightText("navBarAddEmp");
            var show = panelEmp;
            show.Visible = true;
            show = panelOnDvc;
            show.Visible = false;
            show = MainPanel;
            show.Visible = false;
            show = panelDevice;
            show.Visible = false;
            show = panelGuest;
            show.Visible = false;
            CmbBxType.DataSource = TypeList();

            var employeeBll = new EmployeeBLL();
            grdViewEmp.DataSource = employeeBll.SelectEmployeesList();
            grdViewEmp.Show();
            //******************
            var frmAddEmp = new FrmAddEmployee();
            frmAddEmp.ShowDialog();
            grdViewEmp.DataSource = employeeBll.SelectEmployeesList();
        }


        /// <summary>
        ///     this event is for right click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gridView_RowClick(object sender, RowClickEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                var rightClickMenu = new ContextMenu();

                rightClickMenu.MenuItems.Add(new MenuItem("حذف"));
                rightClickMenu.MenuItems.Add(new MenuItem("ارسال به دستگاه"));
                rightClickMenu.MenuItems.Add(new MenuItem("حذف شخص از دستگاه"));

                var point = new Point(e.X, e.Y);

                rightClickMenu.Show(grdViewEmp, point);
                rightClickMenu.MenuItems[0].Click += rightClickDeleteEmployee_Click;
                rightClickMenu.MenuItems[1].Click += rightClickSendInfo_click;
                rightClickMenu.MenuItems[2].Click += rightClickDeleteInfo_click;
            }
        }

        private void rightClickDeleteInfo_click(object sender, EventArgs e)
        {
            try
            {
                var employeeBll = new EmployeeBLL();
                var cardBll = new CardBLL();
                var fingerBll = new FingerBLL();
                var deviceEmpBll = new DeviceEmpBll();
                DeviceBLL deviceBll = new DeviceBLL();

                var selectedRows = gridViewEmp.GetSelectedRows();
                var result = new object[selectedRows.Length];

                for (var i = 0; i < selectedRows.Length; i++)
                {
                    var rowHandle = selectedRows[i];

                    if (!gridViewEmp.IsGroupRow(rowHandle))
                    {
                        result[i] = gridViewEmp.GetRowCellValue(rowHandle, "ID");
                    }
                    else
                        result[i] = -1; // default value
                }

                var employees = employeeBll.SelectEmployees(result);

                if (employees.Count == 0)
                {
                    MessageBox.Show(@"باید حداقل یک شخص انتخاب شود!!!", @"هشدار", MessageBoxButtons.OK,
                        MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1,
                        MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                }
                if (employees.Count == 1)
                {
                    var dialogResult = MessageBox.Show(@"آیا مطمئن به حذف این شخص از دستگاه هستید!!!", @"هشدار",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1,
                        MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                    if (dialogResult == DialogResult.Yes)
                    {
                        
                        show = new Thread(() => showformDeleteInfo(employees));
                        show.Start();

                    }
                }
                if (employees.Count > 1)
                {
                    var dialogResult = MessageBox.Show(@"آیا مطمئن به حذف این اشخاص هستید!!!", @"هشدار",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1,
                        MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                    if (dialogResult == DialogResult.Yes)
                    {
                        show = new Thread(() => showformDeleteInfo(employees));
                        show.Start();
                    }
                }

            }
            catch (Exception ex)
            {

                throw;
            }
        }

        private void showformDeleteInfo(List<Employee> employees)
        {
            var frmSendInfo = new FrmDeleteInfo(employees);
            frmSendInfo.ShowDialog();
        }


        private void gridViewEmp_DoubleClick(object sender, EventArgs e)
        {
            var employeeBll = new EmployeeBLL();

            var index = gridViewEmp.FocusedRowHandle;
            var id = gridViewEmp.GetRowCellValue(index, "ID");


            //**************
            var frmAddEmployee = new FrmAddEmployee(true, employeeBll.SelectOneEmployees(id)) { Text = @"ویرایش کارمند" };
            frmAddEmployee.ShowDialog();
            grdViewEmp.DataSource = employeeBll.SelectEmployeesList();
        }

        /// <summary>
        ///     This event is for delete employees
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rightClickDeleteEmployee_Click(object sender, EventArgs e)
        {
            var employeeBll = new EmployeeBLL();
            var cardBll = new CardBLL();
            var fingerBll = new FingerBLL();
            var deviceEmpBll = new DeviceEmpBll();


            var selectedRows = gridViewEmp.GetSelectedRows();
            var result = new object[selectedRows.Length];

            for (var i = 0; i < selectedRows.Length; i++)
            {
                var rowHandle = selectedRows[i];

                if (!gridViewEmp.IsGroupRow(rowHandle))
                {
                    result[i] = gridViewEmp.GetRowCellValue(rowHandle, "ID");
                }
                else
                    result[i] = -1; // default value
            }

            var employees = employeeBll.SelectEmployees(result);

            if (employees.Count == 0)
            {
                var index = gridViewEmp.FocusedRowHandle;
                var id = gridViewEmp.GetRowCellValue(index, "ID");

                var dialogResult = MessageBox.Show(@"آیا مطمئن به حذف این شخص مورد نظر  هستید!!!", @"هشدار",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1,
                    MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                if (dialogResult == DialogResult.Yes)
                {
                    
                    fingerBll.Deletefingers((int)id);
                    cardBll.DeleteCards((int)id);
                    employeeBll.DeleteOneEmployee(id);
                }
            }
            if (employees.Count == 1)
            {
                var dialogResult = MessageBox.Show(@"آیا مطمئن به حذف  شخص مورد نظر  هستید!!!", @"هشدار",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1,
                    MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                if (dialogResult == DialogResult.Yes)
                {
                   
                    fingerBll.Deletefingers(employees[0].ID);
                    cardBll.DeleteCards(employees[0].ID);
                    employeeBll.DeleteOneEmployee(employees[0].ID);
                }
            }

            if (employees.Count > 1)
            {
                var dialogResult = MessageBox.Show(@"آیا مطمئن به حذف این اشخاص هستید!!!", @"هشدار",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1,
                    MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                if (dialogResult == DialogResult.Yes)
                {
                    deviceEmpBll.DeleteEmployeesfromDeviceEmp(employees);
                    fingerBll.Deletefingers(employees);
                    cardBll.DeleteCards(employees);
                    employeeBll.DeleteEmployees(employees);
                }
            }


            grdViewEmp.DataSource = employeeBll.SelectEmployeesList();
        }


        /// <summary>
        ///     this event is for show edit employee form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rightClickEditeEmployee_Click(object sender, EventArgs e)
        {
            var employeeBll = new EmployeeBLL();

            var index = gridViewEmp.FocusedRowHandle;
            var id = gridViewEmp.GetRowCellValue(index, "ID");


            //**************
            var frmAddEmployee = new FrmAddEmployee(true, employeeBll.SelectOneEmployees(id)) { Text = @"ویرایش کارمند" };
            frmAddEmployee.ShowDialog();
            grdViewEmp.DataSource = employeeBll.SelectEmployeesList();
        }


        /// <summary>
        ///     this event is for show access form per device and send Info of one employee to Eco
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rightClickSendInfo_click(object sender, EventArgs e)
        {
            var employeeBll = new EmployeeBLL();
            var selectedRows = gridViewEmp.GetSelectedRows();
            var result = new object[selectedRows.Length];

            for (var i = 0; i < selectedRows.Length; i++)
            {
                var rowHandle = selectedRows[i];

                if (!gridViewEmp.IsGroupRow(rowHandle))
                {
                    result[i] = gridViewEmp.GetRowCellValue(rowHandle, "ID");
                }
                else
                    result[i] = -1; // default value
            }

            var employees = employeeBll.SelectEmployees(result);
            if (employees.Count == 0)
                MessageBox.Show(@"باید حداقل یک شخص انتخاب شود!!!", @"هشدار", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1,
                    MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
            if (employees.Count == 1)
            {
                show = new Thread(() => showformSendInfo(employees[0]));
                show.Start();
            }

            if (employees.Count > 1)
            {
                show = new Thread(() => showformSync(employees));
                show.Start();
            }
        }

        private void showformSendInfo(Employee employee)
        {
            var frmSendInfo = new FrmSendInfo(employee);
            frmSendInfo.ShowDialog();
        }

        /// <summary>
        ///     this event is for showing send all employees info to devices
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void navBarSendEmp_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            KillDeviceThreads();
            //
            HeighLightText("navBarSendEmp");
            var Show = panelEmp;
            Show.Visible = true;
            Show = panelOnDvc;
            Show.Visible = false;
            Show = MainPanel;
            Show.Visible = false;
            Show = panelDevice;
            Show.Visible = false;
            Show = panelGuest;
            Show.Visible = false;
            grdViewEmp.Show();


            CmbBxType.DataSource = TypeList();

            var employeeBll = new EmployeeBLL();

            var employees = employeeBll.SelectEmployees();
            //     grdViewEmp.DataSource = employeeBll.SelectEmployees();
            //     grdViewEmp.Show();

            show = new Thread(() => showformSync(employees));
            show.Start();
        }

        private void showformSync(List<Employee> employees)
        {
            var frmSync = new FrmSync(employees);
            frmSync.ShowDialog();
        }


        /// <summary>
        ///     this is enum type of export file
        /// </summary>
        private enum TypeExport
        {
            Pdf = 0,
            Excel,
            Csv
        };


        /// <summary>
        ///     This is return List of types
        /// </summary>
        /// <returns></returns>
        private List<string> TypeList()
        {
            var typeList = new List<string>();

            foreach (var i in Enum.GetValues(typeof(TypeExport)))
            {
                typeList.Add(((TypeExport)i).ToString());
            }
            return typeList;
        }


        /// <summary>
        ///     this is event of print button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnPrint_Click(object sender, EventArgs e)
        {
            gridViewEmp.ShowPrintPreview();
        }


        /// <summary>
        ///     This is method of Export gridview
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnExport_Click(object sender, EventArgs e)
        {
            // ReSharper disable once AssignNullToNotNullAttribute;
            var logDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\Logs";
            if (!Directory.Exists(logDirectory))
            {
                Directory.CreateDirectory(logDirectory);
            }
            if (CmbBxType.SelectedValue.ToString() == TypeExport.Pdf.ToString())
            {
                // ReSharper disable once AssignNullToNotNullAttribute
                var pdfDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) +
                                   "\\Logs\\اطلاعات پرسنلی.pdf";

                grdViewEmp.ExportToPdf(pdfDirectory);
                return;
            }
            if (CmbBxType.SelectedValue.ToString() == TypeExport.Excel.ToString())
            {
                // ReSharper disable once AssignNullToNotNullAttribute
                var xlsDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) +
                                   "\\Logs\\اطلاعات پرسنلی.xlsx";

                grdViewEmp.ExportToXlsx(xlsDirectory);
                return;
            }
            if (CmbBxType.SelectedValue.ToString() == TypeExport.Csv.ToString())
            {
                // ReSharper disable once AssignNullToNotNullAttribute
                var cvsDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) +
                                   "\\Logs\\اطلاعات پرسنلی.csv";

                grdViewEmp.ExportToCsv(cvsDirectory);
            }
        }


        private void EmployeeGroup_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            try
            {
                var frmOrganization = new FrmOrganization();
                KillDeviceThreads();
                frmOrganization.ShowDialog();
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion

        //Created By Amirhossiensz ....

        #region import Employeess and finger to DataBase

        private void ImportEmployeeStripMenuItem_Click(object sender, EventArgs e)
        {
            var frmImportEmployee = new FrmImportEmployee();
            frmImportEmployee.ShowDialog();
        }

        private void ImportFingerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frmImportFinger = new FrmImportFinger();
            frmImportFinger.ShowDialog();
        }

        #endregion

        //log

        #region Log

        private void navBarAllLog_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            KillDeviceThreads();


            HeighLightText("navBarAllLog");

            var Show = panelDevice;

            Show.Visible = false;
            Show = panelOnDvc;
            Show.Visible = false;
            Show = panelEmp;
            Show.Visible = false;
            Show = MainPanel;
            Show.Visible = true;
            Show = panelGuest;
            Show.Visible = false;


            MainPanel.Controls.Clear();
            MainPanel.Controls.Add(_frmAllLogs);
            _frmAllLogs.Dock = DockStyle.Fill;

            Invoke((MethodInvoker)delegate { _frmAllLogs.Visible = true; });

            // var frmAllLogs = new FrmAllLogs();
            // frmAllLogs.ShowDialog();
        }

        private void navbarChartTraffic_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            //KillDeviceThreads();

            //HeighLightText("navbarChartTraffic");


            //var frm = new FrmStatistic();
            //frm.ShowDialog();
        }

        #endregion

        // Show All Guest Card

        #region guest Card

        private void navBarAllGuest_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            var guestbll = new GuestBLL();
            KillDeviceThreads();

            //**********************
            HeighLightText("navBarAllGuest");
            var Show = panelGuest;
            Show.Visible = true;
            Show = panelOnDvc;
            Show.Visible = false;
            Show = panelDevice;
            Show.Visible = false;
            Show = panelEmp;
            Show.Visible = false;
            Show = MainPanel;
            Show.Visible = false;


            gridViewGuest.DataSource = guestbll.SelectGuestCards().ToList();
            gridViewGuest.Show();
        }

        private void navBarAddGuest_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            KillDeviceThreads();
            var guestbll = new GuestBLL();

            HeighLightText("navBarAddGuest");
            var Show = panelGuest;
            Show.Visible = true;
            Show = panelOnDvc;
            Show.Visible = false;
            Show = panelDevice;
            Show.Visible = false;
            Show = panelEmp;
            Show.Visible = false;
            Show = MainPanel;
            Show.Visible = false;


            gridViewGuest.DataSource = guestbll.SelectGuestCards().ToList();
            gridViewGuest.Show();

            var frmAddGuest = new FrmAddGuest();
            frmAddGuest.ShowDialog();


            gridViewGuest.Show();
            gridViewGuest.DataSource = guestbll.SelectGuestCards().ToList();
        }

        #endregion

        //menu expanding

        #region menu expanding

        private void navBarDevices_ItemChanged(object sender, EventArgs e)
        {
            if ((NavBarGroup)sender == navBarDevices && navBarDevices.Expanded)
            {
                HeighLightText("navBarShowDevice");
                KillDeviceThreads();
                var Show = panelDevice;

                Show.Visible = true;
                Show = panelOnDvc;
                Show.Visible = false;
                Show = panelEmp;
                Show.Visible = false;
                Show = MainPanel;
                Show.Visible = false;
                Show = panelGuest;
                Show.Visible = false;


                navBarMonitor.Expanded = false;
                navBarEmployee.Expanded = false;
                navBarLog.Expanded = false;
                navSchaduler.Expanded = false;


                //            deviceBll = new DeviceBLL();
                gridViewDevice.DataSource = deviceBll.SelectDevices();
            }
        }

        private void navBarEmployee_ItemChanged(object sender, EventArgs e)
        {
            try
            {
                if ((NavBarGroup)sender == navBarEmployee && navBarEmployee.Expanded)
                {
                    HeighLightText("navBarShowEmp");
                    KillDeviceThreads();

                    var Show = panelEmp;
                    Show.Visible = true;
                    Show = panelOnDvc;
                    Show.Visible = false;
                    Show = MainPanel;
                    Show.Visible = false;
                    Show = panelDevice;
                    Show.Visible = false;
                    Show = panelGuest;
                    Show.Visible = false;
                    CmbBxType.DataSource = TypeList();


                    navSchaduler.Expanded = false;
                    navBarMonitor.Expanded = false;
                    navBarDevices.Expanded = false;
                    navBarLog.Expanded = false;

                    var employeeBll = new EmployeeBLL();
                    var employeeList = employeeBll.SelectEmployeesList();
                    grdViewEmp.DataSource = employeeList;
                    grdViewEmp.Show();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void navBarMonitor_ItemChanged(object sender, EventArgs e)
        {
            try
            {
                if ((NavBarGroup)sender == navBarMonitor && navBarMonitor.Expanded)
                {
                    ShowSmalSize();

                    navSchaduler.Expanded = false;
                    navBarEmployee.Expanded = false;
                    navBarDevices.Expanded = false;
                    navBarLog.Expanded = false;
                }
            }
            catch (Exception)
            {
                //throw;
            }
        }

        private void navBarLog_ItemChanged(object sender, EventArgs e)
        {
            try
            {
                if ((NavBarGroup)sender == navBarLog && navBarLog.Expanded)
                {
                    var Show = panelDevice;

                    Show.Visible = false;
                    Show = panelOnDvc;
                    Show.Visible = false;
                    Show = panelEmp;
                    Show.Visible = false;
                    Show = MainPanel;
                    Show.Visible = true;
                    Show = panelGuest;
                    Show.Visible = false;

                    MainPanel.Controls.Clear();
                    MainPanel.Controls.Add(_frmAllLogs);
                    _frmAllLogs.Dock = DockStyle.Fill;

                    // Invoke((MethodInvoker)delegate { _frmAllLogs.Visible = true; });
                    _frmAllLogs.Visible = true;
                    _frmAllLogs.FrmAllLogs_Load(sender, e);
                    navSchaduler.Expanded = false;
                    navBarEmployee.Expanded = false;
                    navBarDevices.Expanded = false;
                    navBarMonitor.Expanded = false;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void navSchaduler_ItemChanged(object sender, EventArgs e)
        {
            try
            {
                if ((NavBarGroup)sender == navSchaduler && navSchaduler.Expanded)
                {
                    navBarMonitor.Expanded = false;
                    navBarEmployee.Expanded = false;
                    navBarDevices.Expanded = false;
                    navBarLog.Expanded = false;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion

        //Access Control

        #region accecc control

        private void DayType_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            var frmDayType = new FrmDayType();
            frmDayType.ShowDialog();
        }

        private void SchGroup_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            var frmScheduleGroup = new FrmScheduleGroup();
            frmScheduleGroup.ShowDialog();
        }


        private void Holidays_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            try
            {
                var frmHolidaygroup = new FrmHolidaygroup();
                KillDeviceThreads();

                frmHolidaygroup.ShowDialog();
            }
            catch (Exception ex)
            {
                throw;
            }
        }


        private void AcessGroup_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            try
            {
                var frmAccessGroup = new FrmAccessGroup();
                KillDeviceThreads();
                frmAccessGroup.ShowDialog();
            }
            catch (Exception)
            {
                throw;
            }
        }


        private void AccessArea_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            try
            {
                var frmAccessArea = new FrmAccessArea();
                KillDeviceThreads();
                frmAccessArea.ShowDialog();
            }
            catch (Exception ex)
            {
            }
        }

        #endregion

        private void nvBrCtrlMenu_Click(object sender, EventArgs e)
        {

        }

        private void Menu_Click(object sender, EventArgs e)
        {

        }

        private void مدیریتنقشدردستگاهToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmZkRoleManagment frmZkRoleManagment = new FrmZkRoleManagment();
            frmZkRoleManagment.ShowDialog();
        }

        private void navBarGetLogs_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            FrmGetLogs frmGetLogs = new FrmGetLogs();
            frmGetLogs.ShowDialog();
        }
    }
}