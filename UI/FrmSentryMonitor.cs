using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using BLL;
using DevExpress.Data;
using DevExpress.Utils;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;
using Model;
using zkemkeeper;

namespace Eco
{
    public partial class FrmSentryMonitor : Form
    {
        private readonly PersianCalendar _perCalendar = new PersianCalendar();
        public static ArrayList WorkerSocketList = ArrayList.Synchronized(new ArrayList());
        private readonly DeviceBLL _deviceBll = new DeviceBLL();

        private readonly TrafficLogBLL _traficLogBll = new TrafficLogBLL();

        public int ClientCount;

        public DataTable DacTable = GetTable();

        public AsyncCallback PfnWorkerCallBack;

        delegate void SetTextCallback();

        private CZKEM _czkem;
        private List<CZKEM> _zkList = new List<CZKEM>();

        List<TrafficEmployee> trafficLog = new List<TrafficEmployee>();

        public Socket MainSocket { get; set; }


        private void LoadGrid()
        {
            // InvokeRequired required compares the thread ID of the
            // calling thread to the thread ID of the creating thread.
            // If these threads are different, it returns true.
            if (this.grdViewTrafic.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(LoadGrid);
                this.Invoke(d, new object[] { });
            }
            else
            {
                grdViewTrafic.DataSource = _traficLogBll.SelectTodayOnlineLog();
            }
        }


        public void CheckReciveCommand(string msgClient, int clientId)
        {
            try
            {
                if (msgClient.Length > 1 && msgClient.Contains("Refresh"))
                {
                    //grdViewTrafic.DataSource = _traficLogBll.SelectTodayOnlineLog();
                    LoadGrid();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public FrmSentryMonitor()
        {
            
            MainSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            InitializeComponent();
        }

        
        private void CreateEventForEachZkDevices()
        {
            try
            {
                foreach (var device in _deviceBll.SelectDevices())
                {

                    if (device.DeviceType.Type != "ZK")
                    {
                        continue;
                    }
                    _czkem = new CZKEM();
                    if (new DeviceBLL().Ping(device.IP, device.Port))
                    {
                        var c = _czkem.Connect_Net(device.IP, (int) device.Port);
                        if (c)
                            _zkList.Add(_czkem);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public void RaiseEvent()
        {
            foreach (var zk in _zkList)
            {
             //   var c = zk.Connect_Net(device.IP, device.Port);
                var res = zk.RegEvent(1, 65535);
                zk.OnAttTransactionEx += (s, i, state, method, year, month, day, hour, minute, second, code) =>
                    CzkemOnOnAttTransactionEx(s, i, state, method, year, month, day, hour, minute, second, code,zk);

            }

        }



        private void CzkemOnOnAttTransactionEx(string enrollnumber, int isinvalid, int attstate, int verifymethod, int year, int month, int day, int hour, int minute, int second, int workcode, CZKEM zk)
        {
            
            EmployeeBLL employeeBll = new EmployeeBLL();
            var emp = employeeBll.SelectOneEmployees(enrollnumber);
            string IpAddress = "";
            zk.GetDeviceIP(1,ref IpAddress);
            string reqtype = verifymethodMode(verifymethod);
            TrafficEmployee traffic = new TrafficEmployee()
            {
                EmpPersonalNum = enrollnumber,
                Access = true,
                Date = GetTodayShamsiDate(year, month, day),
                Time = GetTime(hour, minute, second),
                EmpFname = emp.EmpFname,
                EmpLname = emp.EmpLname,
                Id = emp.ID,
                Image = emp.Image,
                Type = attstate+1,
                SuccessPass = true,
                status = true,
                ReqType = reqtype,
                DeviceName = new DeviceBLL().SelectOneDevices(IpAddress).DeviceName
            };
            Thread.Sleep(2000);
            trafficLog = _traficLogBll.SelectTodayOnlineLog();
           // trafficLog.Add(traffic);
            grdViewTrafic.DataSource = trafficLog;
            grdTrafic.Columns["Time"].SortOrder = ColumnSortOrder.Descending;
            grdViewTrafic.RefreshDataSource();
        }

        private string verifymethodMode(int verifymethod)
        {
            switch (verifymethod)
            {
                case 1:
                    return "Finger";
                case 2://Pin
                    return "Num";
                case 3://Password
                    return "Num1";
                case 4:
                    return "Card";
                case 5:
                    return "Finger/pw";
                case 6:
                    return "Finger/Card";
                case 7:
                    return "pw/Card";
                case 8:
                    return "Pin&Finger";
                case 9:
                    return "Finger&pw";
                case 10:
                    return "Finger&Card";
                case 11:
                    return "pw&Card";
                case 12:
                    return "Finger&Pw&Card";
                case 13:
                    return "Pin&Finger&pw";
                case 14:
                    return "Finger&Card/Pin";
                case 15:
                    return "Face";
                default:
                    return "";
            }
        }

        private string GetTime(int dwHour, int dwMinute, int dwSecond)
        {
            try
            {
                return (dwHour > 9 ? dwHour.ToString() : '0' + dwHour.ToString()) + ":" + (dwMinute > 9 ? dwMinute.ToString() : '0' + dwMinute.ToString()) + ":" + (dwSecond > 9 ? dwSecond.ToString() : '0' + dwSecond.ToString());

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return "";
            }
        }

        private string GetDate(int dwYear, int dwMonth, int dwDay)
        {
            try
            {
                return dwYear + "/" + (dwMonth > 9 ? dwMonth.ToString() : '0' + dwMonth.ToString()) + "/" + (dwDay > 9 ? dwDay.ToString() : '0' + dwDay.ToString());

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return "";
            }
        }

        private string GetDateTime(DateTime time)
        {
            try
            {
                var dateTime = time.Year + "-" + (time.Month > 9 ? time.Month.ToString() : '0' + time.Month.ToString()) + "-" +
                               (time.Day > 9 ? time.Day.ToString() : '0' + time.Day.ToString()) + " "
                               + (time.Hour > 9 ? time.Hour.ToString() : '0' + time.Hour.ToString()) + ":"
                               + (time.Minute > 9 ? time.Minute.ToString() : '0' + time.Minute.ToString()) + ":"
                               + (time.Second > 9 ? time.Second.ToString() : '0' + time.Second.ToString());
                return dateTime;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return "";
            }
        }

        public string GetTodayShamsiDate(int y, int m, int d)
        {
            DateTime date = new DateTime(y, m, d);
            var year = _perCalendar.GetYear(date).ToString(CultureInfo.InvariantCulture);
            var month = _perCalendar.GetMonth(date).ToString(CultureInfo.InvariantCulture);
            var day = _perCalendar.GetDayOfMonth(date).ToString(CultureInfo.InvariantCulture);
            day = (day.Length == 1) ? "0" + day : day;
            month = (month.Length == 1) ? "0" + month : month;
            return ConvertDate((year + month + day));
        }


        private string ConvertDate(string taDate)
        {
            string Date;
            Date = taDate.Substring(0, 4);
            Date += "/";
            Date += taDate.Substring(4, 2);
            Date += "/";
            Date += taDate.Substring(6, 2);

            return Date;
        }

        private void FrmSentryMonitor_Load(object sender, EventArgs e)
        {
            try
            {

                CreateEventForEachZkDevices();
                RaiseEvent();

                grdViewTrafic.DataSource = _traficLogBll.SelectTodayOnlineLog();
                grdTrafic.Columns["Date"].SortOrder = ColumnSortOrder.Descending;
                grdTrafic.Columns["Time"].SortOrder = ColumnSortOrder.Descending;

                SetUiImages();
                
                StartListenPort(_deviceBll.SelectDevices()[0].ServerIP, 8000);

            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
            }
        }

        private void SetUiImages()
        {
            grdTrafic.GroupPanelText = @"جهت فیلتر کردن هر ستون ستون مورد نظر را به این قسمت بکشید";
            // ReSharper disable once AssignNullToNotNullAttribute
            var imagesDirectory = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location),
                "Images");

            var imageCombo = grdViewTrafic.RepositoryItems.Add("ImageComboBoxEdit") as RepositoryItemImageComboBox;

            var acessCombo = grdViewTrafic.RepositoryItems.Add("ImageComboBoxEdit") as RepositoryItemImageComboBox;

            var reqTypeCombo = grdViewTrafic.RepositoryItems.Add("ImageComboBoxEdit") as RepositoryItemImageComboBox;

            reqTypeCombo.GlyphAlignment = HorzAlignment.Center;



            var images = new ImageCollection();
            var imagesReqType = new ImageCollection();
            images.ImageSize = new Size(32, 32);
            imagesReqType.ImageSize = new Size(64, 64);

            images.AddImage(Image.FromFile(imagesDirectory + "\\inputTrue.png"));

            images.AddImage(Image.FromFile(imagesDirectory + "\\outputTrue.png"));

            images.AddImage(Image.FromFile(imagesDirectory + "\\inputFalse.png"));

            images.AddImage(Image.FromFile(imagesDirectory + "\\outputFalse.png"));

            images.AddImage(Image.FromFile(imagesDirectory + "\\check.png"));

            images.AddImage(Image.FromFile(imagesDirectory + "\\multiply.png"));


            imagesReqType.AddImage(Image.FromFile(imagesDirectory + "\\Id.png"));

            imagesReqType.AddImage(Image.FromFile(imagesDirectory + "\\Num.png"));

            imagesReqType.AddImage(Image.FromFile(imagesDirectory + "\\Pbi.png"));

            imagesReqType.AddImage(Image.FromFile(imagesDirectory + "\\Dsi.png"));

            imagesReqType.AddImage(Image.FromFile(imagesDirectory + "\\Card.png"));

            imagesReqType.AddImage(Image.FromFile(imagesDirectory + "\\Num1.png"));

            imagesReqType.AddImage(Image.FromFile(imagesDirectory + "\\Finger.png"));

            imagesReqType.AddImage(Image.FromFile(imagesDirectory + "\\Face.png"));

            imageCombo.LargeImages = images;

            acessCombo.LargeImages = images;

            reqTypeCombo.LargeImages = imagesReqType;

            imageCombo.Items.Add(new ImageComboBoxItem("input", 1, 0));

            imageCombo.Items.Add(new ImageComboBoxItem("output", 2, 1));

            imageCombo.Items.Add(new ImageComboBoxItem("input", 3, 2));

            imageCombo.Items.Add(new ImageComboBoxItem("output", 4, 3));


            acessCombo.Items.Add(new ImageComboBoxItem("check", true, 4));

            acessCombo.Items.Add(new ImageComboBoxItem("multiply", false, 5));



            reqTypeCombo.Items.Add(new ImageComboBoxItem("Id", "Id", 0));

            reqTypeCombo.Items.Add(new ImageComboBoxItem("Num", "Num", 1));

            reqTypeCombo.Items.Add(new ImageComboBoxItem("Pbi", "Pbi", 2));

            reqTypeCombo.Items.Add(new ImageComboBoxItem("Dsi", "Dsi", 3));

            reqTypeCombo.Items.Add(new ImageComboBoxItem("Card", "Card", 4));

            reqTypeCombo.Items.Add(new ImageComboBoxItem("Num1", "Num1", 5));

            reqTypeCombo.Items.Add(new ImageComboBoxItem("Finger", "Finger", 6));

            reqTypeCombo.Items.Add(new ImageComboBoxItem("Face", "Face", 7));



            imageCombo.GlyphAlignment = HorzAlignment.Center;

            grdTrafic.Columns["Type"].ColumnEdit = imageCombo;

            acessCombo.GlyphAlignment = HorzAlignment.Center;

            grdTrafic.Columns["SuccessPass"].ColumnEdit = acessCombo;

            reqTypeCombo.GlyphAlignment = HorzAlignment.Center;

            grdTrafic.Columns["ReqType"].ColumnEdit = reqTypeCombo;
        }


        public bool StartListenPort(string ip, int portServer)
        {
            try
            {
                Thread.Sleep(100);
                var port = portServer;

                var ipLocal = new IPEndPoint(IPAddress.Any, port);
                MainSocket.Bind(ipLocal);
                MainSocket.Listen(4);
                MainSocket.BeginAccept(OnClientConnect, null);
                return true;
            }
            catch (SocketException se)
            {
                var time = DateTime.Now;
                var log = "Method StartListenPort :" + se.Message + ".\t" +
                          Convert.ToString(time, CultureInfo.InvariantCulture) + " \r\n";
                return false;
            }
            catch (Exception se)
            {
                var time = DateTime.Now;
                var log = "Method StartListenPort :" + se.Message + ".\t" +
                          Convert.ToString(time, CultureInfo.InvariantCulture) + " \r\n";
                return false;
            }
        }

        private void UpdateClientList()
        {
            try
            {
                for (var i = 0; i < WorkerSocketList.Count; i++)
                {
                    var clientKey = Convert.ToString(i + 1);
                    var workerSocket = (Socket) WorkerSocketList[i];
                    if (workerSocket != null)
                    {
                        if (workerSocket.Connected)
                        {
                            var ipClient = ((IPEndPoint) (workerSocket.RemoteEndPoint)).Address.ToString();
                            DacTable.Rows.Add(clientKey.ToString(CultureInfo.InvariantCulture), ipClient);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                var time = DateTime.Now;
                var log = "Method UpdateClientList :" + ex.Message + ".\t" +
                          Convert.ToString(time, CultureInfo.InvariantCulture) + " \r\n";
            }
        }

        private static DataTable GetTable()
        {
            var table = new DataTable();
            table.Columns.Add("DacId", typeof (string));
            table.Columns.Add("DacIp", typeof (string));
            return table;
        }

        private void OnClientConnect(IAsyncResult asyn)
        {
            try
            {
                var workerSocket = MainSocket.EndAccept(asyn);

                Interlocked.Increment(ref ClientCount);


                WorkerSocketList.Remove(workerSocket);
                WorkerSocketList.Add(workerSocket);

                UpdateClientList();

                WaitForData(workerSocket, ClientCount);

                MainSocket.BeginAccept(OnClientConnect, null);
            }
            catch (ObjectDisposedException)
            {
                UpdateClientList();
            }
            catch (SocketException ex)
            {

                ResetListenPort();
            }
            catch (Exception ex)
            {
                ResetListenPort();
            }
        }


        private void ResetListenPort()
        {
            try
            {
                UpdateClientList();
                MainSocket.Close(200);
                Thread.Sleep(1000);
                var serverIp = _deviceBll.SelectDevices()[0].ServerIP;
                while (true)
                {
                    if (StartListenPort(serverIp, 8000))
                        break;
                    Thread.Sleep(3000);
                }
            }
            catch (Exception ex)
            {
                var time = DateTime.Now;
                var log = " Method ResetAllCilent : // " + ex.Message + " .\t" +
                          Convert.ToString(time, CultureInfo.InvariantCulture) + " \r\n";
                Thread.Sleep(2000);
            }
        }


        private void WaitForData(Socket soc, int clientNumber)
        {
            try
            {
                if (PfnWorkerCallBack == null)
                {
                    PfnWorkerCallBack = OnDataReceived;
                }
                var theSocPkt = new SocketPacketServer(soc, clientNumber);
                soc.BeginReceive(theSocPkt.DataBuffer, 0, theSocPkt.DataBuffer.Length, SocketFlags.None,
                    PfnWorkerCallBack, theSocPkt);
            }
            catch (SocketException ex)
            {
                if (ex.ErrorCode != 10054)
                {
                    var time = DateTime.Now;
                    var log = "Method WaitForData :" + ex.Message + ".\t" +
                              Convert.ToString(time, CultureInfo.InvariantCulture) + " \r\n";
                }
                UpdateClientList();
            }
            catch (Exception ex)
            {
                var time = DateTime.Now;
                var log = "Method WaitForData :" + ex.Message + ".\t" +
                          Convert.ToString(time, CultureInfo.InvariantCulture) + " \r\n";
                UpdateClientList();
            }
        }


        private void OnDataReceived(IAsyncResult asyn)
        {
            try
            {
                var socketData = (SocketPacketServer) asyn.AsyncState;
                var dacIp = GetClientIp(socketData.ClientNumber);
                if (!string.IsNullOrEmpty(dacIp))
                {
                    try
                    {
                        var iRx = socketData.CurrentSocket.EndReceive(asyn);
                        var chars = new char[iRx + 1];
                        // Extract the characters as a buffer
                        var decoder = Encoding.UTF8.GetDecoder();
                        decoder.GetChars(socketData.DataBuffer, 0, iRx, chars, 0);

                        var szData = new string(chars);

                        if (szData == "\0")
                        {
                            var ex = new SocketException(10054);
                            Console.WriteLine(ex.Message);
                        }

                        ReciveCommand(szData, socketData.ClientNumber);
                        WaitForData(socketData.CurrentSocket, socketData.ClientNumber);
                    }
                    catch (ObjectDisposedException)
                    {
                        Debugger.Log(0, "1", " \nOnDataReceived: Socket has been closed \r\n");
                    }
                    catch (SocketException ex)
                    {
                        if (ex.ErrorCode == 10054)
                        {
                            WorkerSocketList[socketData.ClientNumber - 1] = null;
                        }
                        UpdateClientList();
                    }
                    catch (Exception ex)
                    {
                        var msg = "Client " + dacIp + " : " + ex.Message;
                        var time = DateTime.Now;
                        var log = " Method  OnDataReceived : // " + msg + " .\t" +
                                  Convert.ToString(time, CultureInfo.InvariantCulture) + " \r\n";

                        WorkerSocketList[socketData.ClientNumber - 1] = null;
                        UpdateClientList();
                    }
                }
            }
            catch (Exception ex)
            {
                var time = DateTime.Now;
                var log = " Method  OnDataReceived 3 : // " + ex.Message + " .\t" +
                          Convert.ToString(time, CultureInfo.InvariantCulture) + " \r\n";
            }
        }


        private void ReciveCommand(string msgClient, int clientId)
        {
            try
            {
                if (msgClient.Length < 4)
                    return;

                CheckReciveCommand(msgClient, clientId);
            }
            catch (Exception ex)
            {
                var time = DateTime.Now;
                var log = " Method ReciveCommand : // " + ex.Message + " .\t" +
                          Convert.ToString(time, CultureInfo.InvariantCulture) + " \r\n";
            }
        }

        public string GetClientIp(int clientId)
        {
            try
            {
                var socketList = WorkerSocketList;
                var workerSocket = (Socket) socketList[clientId - 1];
                var dacIp = ((IPEndPoint) (workerSocket.RemoteEndPoint)).Address.ToString();
                return dacIp;
            }
            catch (Exception ex)
            {
                var time = DateTime.Now;
                var log = " Method GetClientIp : // " + ex.Message + " .\t" +
                          Convert.ToString(time, CultureInfo.InvariantCulture) + " \r\n";
                return null;
            }
        }




        private void FrmSentryMonitor_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                _czkem.Disconnect();
                MainSocket.Shutdown(SocketShutdown.Both);
                MainSocket.Disconnect(true);
                MainSocket.Close(200);
                
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);

            }

        }
    }


    public class SocketPacketServer
    {
        public byte[] DataBuffer = new byte[1024];

        public SocketPacketServer(Socket socket, int clientNumberIn)
        {
            CurrentSocket = socket;
            ClientNumber = clientNumberIn;
        }

        public Socket CurrentSocket { get; set; }

        public int ClientNumber { get; set; }
    }
}