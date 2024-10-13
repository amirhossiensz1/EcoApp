using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using BLL;
using Model;

namespace UI
{
    public partial class FrmFingersInDevice : Form
    {
        private readonly Device _device = new Device();
        private readonly DeviceBLL _deviceBll = new DeviceBLL();
        private readonly FingerBLL _fingerBll = new FingerBLL();
        private readonly List<int> _fingerInDevice = new List<int>();
        private readonly DeviceEmpBll _deviceEmpBll = new DeviceEmpBll();
        private readonly Employee _employee = new Employee();
        private List<Finger> _fingers = new List<Finger>();
        // ReSharper disable once AssignNullToNotNullAttribute
        private readonly string fingsRecord =
            Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location),
                "FingsRecord");


        public FrmFingersInDevice()
        {
            InitializeComponent();
        }

        public FrmFingersInDevice(Device device, Employee employee)
        {
            InitializeComponent();
            _employee = employee;
            _device = device;
        }


        private void FrmFingersInDevice_Load(object sender, EventArgs e)
        {
            try
            {
                _fingers = _fingerBll.SelectFingersEmployee(_employee.ID);

                GetFingsRecordFromDevice();
                AnalyzeFingsRecordFile();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        private void GetFingsRecordFromDevice()
        {
            _fingerInDevice.Clear();
            string returndata;

            var temp = File.Create(fingsRecord + ".txt");
            temp.Close();

            var requestFileName = _deviceBll.CreateRequestFileName(_device, fingsRecord + ".txt", "DB\\FingsRecord.txt");

            var fingsRecords = _deviceBll.GetFile(requestFileName, _device.IP, _device.UDPPort);

            if (fingsRecords == null)
                lblStatus.Text = @"دریافت فایل با مشکل مواجه شد !";
            else
            {
                if (fingsRecords.Length != 0)
                {
                    if (fingsRecords[3] == 13)
                        lblStatus.Text = @"کد فعال سازی وارد شده نا معتبر می باشد!";
                    if (fingsRecords[3] == 12)
                        lblStatus.Text = @"کد فعال سازی وارد شده  با سریال سیستم هم خوانی ندارد!";
                    if (fingsRecords[3] == 11)
                        lblStatus.Text = @"کد کاربری/رمز وب دستگاه با نرم افزار یکسان نیست!";
                    if (fingsRecords[3] == 10)
                        lblStatus.Text = @"زمان دستگاه با سرور یکسان نمی باشد" + Environment.NewLine +
                                         @"لطفا ابتدا زمان را یکسان سازی کنید!";
                }

                returndata = Encoding.ASCII.GetString(fingsRecords);


                if (!Directory.Exists(fingsRecord))
                {
                    Directory.CreateDirectory(fingsRecord);
                }
                File.WriteAllText(fingsRecord + "\\" + "FingsRecord.txt", returndata, Encoding.BigEndianUnicode);

                //AnalyzeFingsRecordFile(fingsRecord);
            }
        }

        private void AnalyzeFingsRecordFile()
        {
            try
            {
                var setButton = false;
                bool flag;
                if (!Directory.Exists(fingsRecord))
                {
                    MessageBox.Show(@"پوشه FingsRecord  موجود نمی باشد", @"خطا", MessageBoxButtons.OK,
                        MessageBoxIcon.Error, MessageBoxDefaultButton.Button1,
                        MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                    return;
                }
                // if fingsRecord  had error return from method

                var fingsRecordfile = Directory.GetFiles(fingsRecord, "FingsRecord.txt");
                int[] a = {0, 0, 0, 0, 0, 0, 0, 0, 0, 0};


                var fileLines = File.ReadLines(fingsRecordfile[0]);

                foreach (var fileLine in fileLines)
                {
                    Application.DoEvents();
                    var end = fileLine.IndexOf(';', 0);
                    var id = fileLine.Substring(2, end - 2);

                    if (id == Convert.ToString(_employee.ID))
                    {
                        var fingNumEnd = fileLine.IndexOf(';', end + 1);
                        var fingsNumSum = Convert.ToInt32(fileLine.Substring(end + 1, fingNumEnd - (end + 1)));
                        double fingNum = 9;
                        setButton = true;

                        var binary = Convert.ToString(fingsNumSum, 2);

                        for (var i = 0; i < binary.Length; i++)
                        {
                            a[i] = Convert.ToInt32(binary[(binary.Length - 1) - i].ToString());
                        }
                        for (var i = binary.Length; i < a.Length; i++)
                        {
                            a[i] = 0;
                        }


                        for (var i = 0; i < a.Length; i++)
                        {
                            flag = false;

                            if (a[i] == 1)
                            {
                                Setfingerprint(i);
                                flag = true;
                            }

                            if (a[i] == 0)
                            {
                                foreach (var finger in _fingers)
                                {
                                    if (finger.FingerNum == i)
                                    {
                                        SetfingerSend(i);
                                        flag = true;
                                        break;
                                    }
                                }
                                if (flag == false)
                                {
                                    SetfingerEmpty(i);
                                }
                            }
                        }
                        return;
                    }
                }

                if (!setButton)
                {
                    for (var i = 0; i < a.Length; i++)
                    {
                        flag = false;

                        if (a[i] == 0)
                        {
                            foreach (var finger in _fingers)
                            {
                                if (finger.FingerNum == i)
                                {
                                    SetfingerSend(i);
                                    flag = true;
                                    break;
                                }
                            }
                            if (flag == false)
                            {
                                SetfingerEmpty(i);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        private void Setfingerprint(int fingerNum)
        {
            //PictureBox fingerPrint = new PictureBox();
            var fingerPrint = new Button();
            fingerPrint.FlatAppearance.BorderSize = 0;
            fingerPrint.FlatStyle = FlatStyle.Flat;
            fingerPrint.BackColor = Color.Transparent;
            fingerPrint.Click += fingerPrint_click;
            var imagesDirectory =
                // ReSharper disable once AssignNullToNotNullAttribute
                Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "Images");

            switch (fingerNum)
            {
                case 0:
                    fingerPrint.TabIndex = 0;
                    fingerPrint.Size = new Size(29, 28);
                    fingerPrint.Location = new Point(188, 69);
                    fingerPrint.Image = Image.FromFile(imagesDirectory + "\\Untitled-6.png");
                    _fingerInDevice.Add(0);
                    break;
                case 1:
                    fingerPrint.TabIndex = 1;
                    fingerPrint.Size = new Size(29, 28);
                    fingerPrint.Location = new Point(149, 31);
                    fingerPrint.Image = Image.FromFile(imagesDirectory + "\\Untitled-6.png");
                    _fingerInDevice.Add(1);
                    break;
                case 2:
                    fingerPrint.TabIndex = 2;
                    fingerPrint.Size = new Size(29, 28);
                    fingerPrint.Location = new Point(96, 2);
                    fingerPrint.Image = Image.FromFile(imagesDirectory + "\\Untitled-6.png");
                    _fingerInDevice.Add(2);
                    break;
                case 3:
                    fingerPrint.TabIndex = 3;
                    fingerPrint.Size = new Size(29, 28);
                    fingerPrint.Location = new Point(43, 31);
                    fingerPrint.Image = Image.FromFile(imagesDirectory + "\\Untitled-6.png");
                    _fingerInDevice.Add(3);
                    break;
                case 4:
                    fingerPrint.TabIndex = 4;
                    fingerPrint.Size = new Size(29, 28);
                    fingerPrint.Location = new Point(4, 69);
                    fingerPrint.Image = Image.FromFile(imagesDirectory + "\\Untitled-6.png");
                    _fingerInDevice.Add(4);
                    break;

                case 5:
                    fingerPrint.TabIndex = 5;
                    fingerPrint.Size = new Size(29, 28);
                    fingerPrint.Location = new Point(185, 69);
                    fingerPrint.Image = Image.FromFile(imagesDirectory + "\\Untitled-6.png");
                    _fingerInDevice.Add(5);
                    break;

                case 6:
                    fingerPrint.TabIndex = 6;
                    fingerPrint.Size = new Size(29, 28);
                    fingerPrint.Location = new Point(146, 31);
                    fingerPrint.Image = Image.FromFile(imagesDirectory + "\\Untitled-6.png");
                    _fingerInDevice.Add(6);
                    break;
                case 7:
                    fingerPrint.TabIndex = 7;
                    fingerPrint.Size = new Size(29, 28);
                    fingerPrint.Location = new Point(93, 2);
                    fingerPrint.Image = Image.FromFile(imagesDirectory + "\\Untitled-6.png");
                    _fingerInDevice.Add(7);
                    break;

                case 8:
                    fingerPrint.TabIndex = 8;
                    fingerPrint.Size = new Size(29, 28);
                    fingerPrint.Location = new Point(40, 31);
                    fingerPrint.Image = Image.FromFile(imagesDirectory + "\\Untitled-6.png");
                    _fingerInDevice.Add(8);
                    break;

                case 9:
                    fingerPrint.TabIndex = 9;
                    fingerPrint.Size = new Size(29, 28);
                    fingerPrint.Location = new Point(1, 69);
                    fingerPrint.Image = Image.FromFile(imagesDirectory + "\\Untitled-6.png");
                    _fingerInDevice.Add(9);
                    break;
            }

            if (fingerNum < 5)
                RightHand.Controls.Add(fingerPrint);
            else
            {
                LeftHand.Controls.Add(fingerPrint);
            }
            fingerPrint.BringToFront();
        }


        private void SetfingerEmpty(int fingerNum)
        {
            //PictureBox fingerPrint = new PictureBox();
            var fingerPrint = new Button();
            fingerPrint.FlatAppearance.BorderSize = 0;
            fingerPrint.FlatStyle = FlatStyle.Flat;
            fingerPrint.BackColor = Color.Transparent;
            //  fingerPrint.Click += new EventHandler(fingerPrint_click);
            var imagesDirectory =
                // ReSharper disable once AssignNullToNotNullAttribute
                Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "Images");

            switch (fingerNum)
            {
                case 0:
                    fingerPrint.TabIndex = 0;
                    fingerPrint.Size = new Size(29, 28);
                    fingerPrint.Location = new Point(188, 69);
                    fingerPrint.Image = Image.FromFile(imagesDirectory + "\\fingEmpty.png");
                    break;
                case 1:
                    fingerPrint.TabIndex = 1;
                    fingerPrint.Size = new Size(29, 28);
                    fingerPrint.Location = new Point(149, 31);
                    fingerPrint.Image = Image.FromFile(imagesDirectory + "\\fingEmpty.png");
                    break;
                case 2:
                    fingerPrint.TabIndex = 2;
                    fingerPrint.Size = new Size(29, 28);
                    fingerPrint.Location = new Point(96, 2);
                    fingerPrint.Image = Image.FromFile(imagesDirectory + "\\fingEmpty.png");
                    break;
                case 3:
                    fingerPrint.TabIndex = 3;
                    fingerPrint.Size = new Size(29, 28);
                    fingerPrint.Location = new Point(43, 31);
                    fingerPrint.Image = Image.FromFile(imagesDirectory + "\\fingEmpty.png");
                    break;
                case 4:
                    fingerPrint.TabIndex = 4;
                    fingerPrint.Size = new Size(29, 28);
                    fingerPrint.Location = new Point(4, 69);
                    fingerPrint.Image = Image.FromFile(imagesDirectory + "\\fingEmpty.png");
                    break;

                case 5:
                    fingerPrint.TabIndex = 5;
                    fingerPrint.Size = new Size(29, 28);
                    fingerPrint.Location = new Point(185, 69);
                    fingerPrint.Image = Image.FromFile(imagesDirectory + "\\fingEmpty.png");
                    break;

                case 6:
                    fingerPrint.TabIndex = 6;
                    fingerPrint.Size = new Size(29, 28);
                    fingerPrint.Location = new Point(146, 31);
                    fingerPrint.Image = Image.FromFile(imagesDirectory + "\\fingEmpty.png");
                    break;
                case 7:
                    fingerPrint.TabIndex = 7;
                    fingerPrint.Size = new Size(29, 28);
                    fingerPrint.Location = new Point(93, 2);
                    fingerPrint.Image = Image.FromFile(imagesDirectory + "\\fingEmpty.png");
                    break;

                case 8:
                    fingerPrint.TabIndex = 8;
                    fingerPrint.Size = new Size(29, 28);
                    fingerPrint.Location = new Point(40, 31);
                    fingerPrint.Image = Image.FromFile(imagesDirectory + "\\fingEmpty.png");
                    break;

                case 9:
                    fingerPrint.TabIndex = 9;
                    fingerPrint.Size = new Size(29, 28);
                    fingerPrint.Location = new Point(1, 69);
                    fingerPrint.Image = Image.FromFile(imagesDirectory + "\\fingEmpty.png");
                    break;
            }

            if (fingerNum < 5)
                RightHand.Controls.Add(fingerPrint);
            else
            {
                LeftHand.Controls.Add(fingerPrint);
            }
            fingerPrint.BringToFront();
        }


        private void SetfingerSend(int fingerNum)
        {
            //PictureBox fingerPrint = new PictureBox();
            var fingerPrint = new Button();
            fingerPrint.FlatAppearance.BorderSize = 0;
            fingerPrint.FlatStyle = FlatStyle.Flat;
            fingerPrint.BackColor = Color.Transparent;
            fingerPrint.Click += fingerSend_click;
            var imagesDirectory =
                // ReSharper disable once AssignNullToNotNullAttribute
                Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "Images");

            switch (fingerNum)
            {
                case 0:
                    fingerPrint.TabIndex = 0;
                    fingerPrint.Size = new Size(29, 28);
                    fingerPrint.Location = new Point(188, 69);
                    fingerPrint.Image = Image.FromFile(imagesDirectory + "\\FingSend.png");
                    break;
                case 1:
                    fingerPrint.TabIndex = 1;
                    fingerPrint.Size = new Size(29, 28);
                    fingerPrint.Location = new Point(149, 31);
                    fingerPrint.Image = Image.FromFile(imagesDirectory + "\\FingSend.png");
                    break;
                case 2:
                    fingerPrint.TabIndex = 2;
                    fingerPrint.Size = new Size(29, 28);
                    fingerPrint.Location = new Point(96, 2);
                    fingerPrint.Image = Image.FromFile(imagesDirectory + "\\FingSend.png");
                    break;
                case 3:
                    fingerPrint.TabIndex = 3;
                    fingerPrint.Size = new Size(29, 28);
                    fingerPrint.Location = new Point(43, 31);
                    fingerPrint.Image = Image.FromFile(imagesDirectory + "\\FingSend.png");
                    break;
                case 4:
                    fingerPrint.TabIndex = 4;
                    fingerPrint.Size = new Size(29, 28);
                    fingerPrint.Location = new Point(4, 69);
                    fingerPrint.Image = Image.FromFile(imagesDirectory + "\\FingSend.png");
                    break;

                case 5:
                    fingerPrint.TabIndex = 5;
                    fingerPrint.Size = new Size(29, 28);
                    fingerPrint.Location = new Point(185, 69);
                    fingerPrint.Image = Image.FromFile(imagesDirectory + "\\FingSend.png");

                    break;

                case 6:
                    fingerPrint.TabIndex = 6;
                    fingerPrint.Size = new Size(29, 28);
                    fingerPrint.Location = new Point(146, 31);
                    fingerPrint.Image = Image.FromFile(imagesDirectory + "\\FingSend.png");
                    break;
                case 7:
                    fingerPrint.TabIndex = 7;
                    fingerPrint.Size = new Size(29, 28);
                    fingerPrint.Location = new Point(93, 2);
                    fingerPrint.Image = Image.FromFile(imagesDirectory + "\\FingSend.png");
                    break;

                case 8:
                    fingerPrint.TabIndex = 8;
                    fingerPrint.Size = new Size(29, 28);
                    fingerPrint.Location = new Point(40, 31);
                    fingerPrint.Image = Image.FromFile(imagesDirectory + "\\FingSend.png");
                    break;

                case 9:
                    fingerPrint.TabIndex = 9;
                    fingerPrint.Size = new Size(29, 28);
                    fingerPrint.Location = new Point(1, 69);
                    fingerPrint.Image = Image.FromFile(imagesDirectory + "\\FingSend.png");
                    break;
            }

            if (fingerNum < 5)
                RightHand.Controls.Add(fingerPrint);
            else
            {
                LeftHand.Controls.Add(fingerPrint);
            }
            fingerPrint.BringToFront();
        }

        private void fingerSend_click(object sender, EventArgs e)
        {
            try
            {
                var fingerPrint = (Button) sender;
                var fingerNum = fingerPrint.TabIndex;
                var finger = new Finger();

                var result = MessageBox.Show(@"آیا مطمئن به ارسال اثر انگشت هستید", @"پیام", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);
                foreach (var fing in _fingers)
                {
                    if (fing.FingerNum == fingerNum)
                        finger = fing;
                }

                if (result == DialogResult.Yes)
                {
                    SendFingerToDevice(finger);
                    GetFingsRecordFromDevice();
                    AnalyzeFingsRecordFile();
                    _deviceEmpBll.SetFingerTrueInAccess(_employee, _device, true);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        private void SendFingerToDevice(Finger finger)
        {
            try
            {
                // ReSharper disable once AssignNullToNotNullAttribute
                var fingsPath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location),
                    "Fings\\" + _device.IP);
                if (!Directory.Exists(fingsPath))
                    Directory.CreateDirectory(fingsPath);


                // ReSharper disable once AssignNullToNotNullAttribute
                var syncPath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location),
                    "Sync");
                if (!Directory.Exists(syncPath))
                    Directory.CreateDirectory(syncPath);


                var finishSync = false;
                var checkFingSend = false;

                var fingerData = finger.Data;

                var header = _fingerBll.GenarateHeader(fingerData, _employee.ID, finger);

                _fingerBll.GenerateFinger(fingsPath, header, fingerData, _employee.ID, finger.FingerNum);

                _fingerBll.GenerateSyncFile(_employee.ID, finger.FingerNum);

                var filePath = Directory.GetFiles(fingsPath, "*.txt");

                foreach (var file in filePath)
                {
                    var index = file.IndexOf(_device.IP, StringComparison.Ordinal);
                    var endIndex = file.IndexOf(".txt", StringComparison.Ordinal);
                    var destination = "Fings\\" +
                                      file.Substring(index + _device.IP.Length + 1,
                                          endIndex - (index + _device.IP.Length + 1)) + ".eft";

                    var requestFileName = _deviceBll.CreateRequestFileName(_device, file, destination);

                    if (_device.UDPPort != null &&
                        _deviceBll.SendTftp(file, requestFileName, _device.IP, (int) _device.UDPPort) == 0)
                        checkFingSend = true;
                }

                var syncdestination = "Sync2.fpt";
                var requestFileNameSync = _deviceBll.CreateRequestFileName(_device, syncPath + "\\Sync.txt",
                    syncdestination);
                if (_device.UDPPort != null &&
                    _deviceBll.SendTftp(syncPath + "\\Sync.txt", requestFileNameSync, _device.IP, (int) _device.UDPPort) ==
                    0)
                    finishSync = true;

                if (finishSync && checkFingSend)
                {
                    MessageBox.Show(@"ارسال شد!!!", @"پیام", MessageBoxButtons.OK,
                        MessageBoxIcon.None, MessageBoxDefaultButton.Button1,
                        MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                    DeleteFiles(fingsPath, syncPath);
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }


        private void DeleteFingerFromDevice(int empId, int fingerNum)
        {
            try
            {
                // ReSharper disable once AssignNullToNotNullAttribute
                var syncPath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location),
                    "Sync");

                if (!Directory.Exists(syncPath))
                    Directory.CreateDirectory(syncPath);


                var flag = -1;
                var devices = _deviceBll.SelectDevices();
                _fingerBll.GenerateSyncFile((-1*empId), fingerNum);
                SendDeleteSync();

                if (Directory.Exists(syncPath))
                    File.Delete(syncPath + "\\Sync.txt");
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
            }
        }

        private int SendDeleteSync()
        {
            var flag = -1;
            var deviceBll = new DeviceBLL();
            // ReSharper disable once AssignNullToNotNullAttribute
            var syncPath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location),
                "Sync");
            var syncdestination = "Sync2.fpt";
            var requestFileName = deviceBll.CreateRequestFileName(_device, syncPath + "\\Sync.txt", syncdestination);
            if (deviceBll.Ping(_device.IP, _device.Port))
                if (_device.UDPPort != null)
                    flag = deviceBll.SendTftp(syncPath + "\\Sync.txt", requestFileName, _device.IP,
                        (int) _device.UDPPort);
            return flag;
        }

        private void fingerPrint_click(object sender, EventArgs e)
        {
            try
            {
                var fingerPrint = (Button) sender;
                var fingerNum = fingerPrint.TabIndex;

                var result = MessageBox.Show(@"آیا مطمئن به حذف اثر انگشت هستید", @"پیام", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    DeleteFingerFromDevice(_employee.ID, fingerNum);
                    GetFingsRecordFromDevice();
                    AnalyzeFingsRecordFile();
                    if (ExistFingerInDevice() == false)
                        _deviceEmpBll.SetFingerTrueInAccess(_employee, _device, false);
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private bool ExistFingerInDevice()
        {
            try
            {
                // ReSharper disable once AssignNullToNotNullAttribute
                var fingsRecord = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location),
                    "FingsRecord");

                var fingsRecordfile = Directory.GetFiles(fingsRecord, "FingsRecord.txt");

                var fileLines = File.ReadLines(fingsRecordfile[0]);

                foreach (var fileLine in fileLines)
                {
                    var end = fileLine.IndexOf(';', 0);
                    var id = fileLine.Substring(2, end - 2);

                    if (id == Convert.ToString(_employee.ID))
                    {
                        var fingNumEnd = fileLine.IndexOf(';', end + 1);
                        var fingsNumSum = Convert.ToInt32(fileLine.Substring(end + 1, fingNumEnd - (end + 1)));

                        if (fingsNumSum == 0)
                            return false;
                        return true;
                    }
                }
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
                throw;
            }
        }

        private void BtnSendAll_Click(object sender, EventArgs e)
        {
            try
            {
                // ReSharper disable once AssignNullToNotNullAttribute
                var fingsPath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location),
                    "Fings\\" + _device.IP);

                if (!Directory.Exists(fingsPath))
                    Directory.CreateDirectory(fingsPath);

                // ReSharper disable once AssignNullToNotNullAttribute
                var syncPath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location),
                    "Sync");
                if (!Directory.Exists(syncPath))
                    Directory.CreateDirectory(syncPath);


                var finishSync = false;
                var checkFingSend = false;


                foreach (var finger in _fingers)
                {
                    var fingerData = finger.Data;

                    var header = _fingerBll.GenarateHeader(fingerData, _employee.ID, finger);

                    _fingerBll.GenerateFinger(fingsPath, header, fingerData, _employee.ID, finger.FingerNum);

                    _fingerBll.GenerateSyncFile(_employee.ID, finger.FingerNum);
                }

                var filePath = Directory.GetFiles(fingsPath, "*.txt");

                foreach (var file in filePath)
                {
                    var index = file.IndexOf(_device.IP, StringComparison.Ordinal);
                    var endIndex = file.IndexOf(".txt", StringComparison.Ordinal);
                    var destination = "Fings\\" +
                                      file.Substring(index + _device.IP.Length + 1,
                                          endIndex - (index + _device.IP.Length + 1)) + ".eft";

                    var requestFileName = _deviceBll.CreateRequestFileName(_device, file, destination);

                    if (_device.UDPPort != null &&
                        _deviceBll.SendTftp(file, requestFileName, _device.IP, (int) _device.UDPPort) == 0)
                        checkFingSend = true;
                }


                var syncdestination = "Sync2.fpt";
                var requestFileNameSync = _deviceBll.CreateRequestFileName(_device, syncPath + "\\Sync.txt",
                    syncdestination);
                if (_device.UDPPort != null &&
                    _deviceBll.SendTftp(syncPath + "\\Sync.txt", requestFileNameSync, _device.IP, (int) _device.UDPPort) ==
                    0)
                    finishSync = true;

                if (finishSync && checkFingSend)
                {
                    MessageBox.Show(@"ارسال شد!!!", @"پیام", MessageBoxButtons.OK,
                        MessageBoxIcon.None, MessageBoxDefaultButton.Button1,
                        MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                    DeleteFiles(fingsPath, syncPath);
                    GetFingsRecordFromDevice();
                    AnalyzeFingsRecordFile();

                    _deviceEmpBll.SetFingerTrueInAccess(_employee, _device, true);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        private void DeleteFiles(string fingsPath, string syncPath)
        {
            try
            {
                if (Directory.Exists(fingsPath))
                {
                    var filePath = Directory.GetFiles(fingsPath, "*.txt");
                    foreach (var file in filePath)
                    {
                        File.Delete(file);
                    }
                }

                if (Directory.Exists(syncPath))
                {
                    var filePath = Directory.GetFiles(syncPath, "*.txt");
                    foreach (var file in filePath)
                    {
                        File.Delete(file);
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }


        private void DeleteFiles(string fingsPath)
        {
            try
            {
                if (Directory.Exists(fingsPath))
                {
                    var filePath = Directory.GetFiles(fingsPath, "*.eft");
                    foreach (var file in filePath)
                    {
                        File.Delete(file);
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void BtnDeleteAll_Click(object sender, EventArgs e)
        {
            try
            {
                var flag = 0;
                var fileName = "\\Sync.txt";
                // ReSharper disable once AssignNullToNotNullAttribute
                var syncPath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location),
                    "Sync");

                if (!Directory.Exists(syncPath))
                    Directory.CreateDirectory(syncPath);


                foreach (var finger in _fingerInDevice)
                {
                    using (var file = new StreamWriter(syncPath + fileName, true))
                    {
                        file.WriteLine((-1*_employee.ID) + finger);
                    }
                }

                var syncdestination = "Sync2.fpt";
                var requestFileName = _deviceBll.CreateRequestFileName(_device, syncPath + "\\Sync.txt", syncdestination);
                if (_deviceBll.Ping(_device.IP, _device.Port))
                    if (_device.UDPPort != null)
                        flag = _deviceBll.SendTftp(syncPath + "\\Sync.txt", requestFileName, _device.IP,
                            (int) _device.UDPPort);

                if (flag == 0)
                {
                    if (Directory.Exists(syncPath))
                        File.Delete(syncPath + "\\Sync.txt");

                    GetFingsRecordFromDevice();
                    AnalyzeFingsRecordFile();

                    _deviceEmpBll.SetFingerTrueInAccess(_employee, _device, false);
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private void BtnReceiveAll_Click(object sender, EventArgs e)
        {
            try
            {
                progressPanel.Visible = true;
                enabledForm(false);
                int[] fingers = {0, 0, 0, 0, 0, 0, 0, 0, 0, 0};
                // ReSharper disable once AssignNullToNotNullAttribute
                var fingRecord = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location),
                    "FingsRecord");
                var fings = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location),
                    "Fings");

                GetFingsRecordFromDevice();

                var empId = AnalyzeForGetfingerFile(fingRecord, ref fingers);

                GetFingersFromDevice(empId, fingers, fings);

                AnalyzeFingsRecordFile();

                var insert = InsertFingerToDataBase(fings);

                if (insert == 1)
                    MessageBox.Show(@"عملیات با موفقیت به پایان رسید", @"پیام", MessageBoxButtons.OK,
                        MessageBoxIcon.Information, MessageBoxDefaultButton.Button1,
                        MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                if (insert == -1)
                    MessageBox.Show(@"پوشه Fingers  موجود نمی باشد", @"خطا", MessageBoxButtons.OK,
                        MessageBoxIcon.Error, MessageBoxDefaultButton.Button1,
                        MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                if (insert == -2)
                    MessageBox.Show(@"عملیات با مشکل مواجه شد", @"خطا", MessageBoxButtons.OK,
                        MessageBoxIcon.Error, MessageBoxDefaultButton.Button1,
                        MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);

                DeleteFiles(fings);
                progressPanel.Visible = false;
                enabledForm(true);
                lblStatus.Text = "";
            }
            catch (Exception)
            {
                lblStatus.Text = "";
                throw;
            }
        }

        private void enabledForm(bool p)
        {
            RightHand.Enabled = p;
            LeftHand.Enabled = p;
            BtnDeleteAll.Enabled = p;
            BtnReceiveAll.Enabled = p;
            BtnSendAll.Enabled = p;
        }

        private int InsertFingerToDataBase(string fings)
        {
            try
            {
                var fileBytes = new byte[924];
                var fingerdata = new byte[860];
                var headerdata = new byte[64];
                var employeeBll = new EmployeeBLL();

                if (!Directory.Exists(fings))
                    return -1;

                var fingsFiles = Directory.GetFiles(fings, "*.eft");

                foreach (var fingerfile in fingsFiles)
                {
                    var startIndex = fingerfile.IndexOf("Fings\\", StringComparison.Ordinal);
                    var endIndex = fingerfile.IndexOf(".eft", StringComparison.Ordinal);
                    var employeeIdFingNum = fingerfile.Substring(startIndex + 6, endIndex - (startIndex + 6));
                    var fingerNum = Convert.ToInt32(employeeIdFingNum.Substring(employeeIdFingNum.Length - 1, 1));
                    var employeeId = Convert.ToInt32(employeeIdFingNum.Substring(0, employeeIdFingNum.Length - 1));
                    fileBytes = File.ReadAllBytes(fingerfile);

                    for (var i = 0; i < 64; i++)
                    {
                        headerdata[i] = fileBytes[i];
                    }

                    for (var i = 64; i < fileBytes.Length; i++)
                    {
                        fingerdata[i - 64] = fileBytes[i];
                    }

                    var md5 = Getmd5FromHeader(headerdata);
                    var enrollTime = GetEnrollTimeFromHeader(headerdata);

                    var newfinger = new Finger
                    {
                        EmpID = employeeId,
                        FingerNum = fingerNum,
                        Data = fingerdata,
                        Md5 = md5,
                        DataLength = fingerdata.Length,
                        EnrollTime = enrollTime,
                        fingerQuality = 95
                    };


                    if (employeeBll.SelectOneEmployees(employeeId) != null)
                    {
                        if (_fingerBll.SelectOneFinger(employeeId))
                        {
                            if (_fingerBll.SelectFingerMd5(employeeId, md5))
                            {
                                //break;
                            }
                            else
                            {
                                var finger = _fingerBll.SelectOneFinger(employeeId, fingerNum);
                                if (finger == null)
                                {
                                    employeeBll.SetHasFinger(employeeId);
                                    _fingerBll.InsertFingerToDb(newfinger);
                                }
                                else
                                {
                                    if (Convert.ToInt64(finger.EnrollTime) < Convert.ToInt64(enrollTime))
                                    {
                                        _fingerBll.Upadate(newfinger);
                                    }
                                }
                            }
                        }
                        else
                        {
                            employeeBll.SetHasFinger(employeeId);
                            _fingerBll.InsertFingerToDb(newfinger);
                        }
                    }
                }

                return 1;
            }
            catch (Exception exception)
            {
                return -2;
            }
        }


        private string GetEnrollTimeFromHeader(byte[] headerdata)
        {
            var enrollTime = new byte[12];
            for (var i = 50; i < 62; i++)
            {
                enrollTime[i - 50] = headerdata[i];
            }
            var aaa = Encoding.UTF8.GetString(enrollTime);
            return aaa;
        }

        private string Getmd5FromHeader(byte[] headerdata)
        {
            var md5 = new byte[16];
            for (var i = 2; i < 18; i++)
            {
                md5[i - 2] = headerdata[i];
            }
            return ConvertByteArrayToString(md5);
        }

        private string ConvertByteArrayToString(byte[] ba)
        {
            var hex = new StringBuilder(ba.Length*2);
            foreach (var b in ba)
                hex.AppendFormat("{0:x2}", b);
            return hex.ToString();
        }

        private void GetFingersFromDevice(int empId, int[] fingers, string fings)
        {
            var temp = File.Create(fings + "\\empty.txt");
            temp.Close();


            for (var i = 0; i < fingers.Length; i++)
            {
                Application.DoEvents();

                if (fingers[i] == 1)
                {
                    var requestFileName = _deviceBll.CreateRequestFileName(_device, fings + " \\empty.txt",
                        "Fings\\" + empId + i + ".eft");

                    var fingerBytes = _deviceBll.GetFile(requestFileName, _device.IP, _device.UDPPort);

                    if (fingerBytes == null)
                    {
                        lblStatus.Text = @"دریافت فایل با مشکل مواجه شد !";
                        return;
                    }
                    if (fingerBytes.Length != 0)
                    {
                        if (fingerBytes[3] == 13)
                        {
                            lblStatus.Text = @"کد فعال سازی وارد شده نا معتبر می باشد!";
                            return;
                        }
                        if (fingerBytes[3] == 12)
                        {
                            lblStatus.Text = @"کد فعال سازی وارد شده  با سریال سیستم هم خوانی ندارد!";
                            return;
                        }

                        if (fingerBytes[3] == 11)
                        {
                            lblStatus.Text = @"کد کاربری/رمز وب دستگاه با نرم افزار یکسان نیست!";
                            return;
                        }

                        if (fingerBytes[3] == 10)
                        {
                            lblStatus.Text = @"زمان دستگاه با سرور یکسان نمی باشد" + Environment.NewLine +
                                             @"لطفا ابتدا زمان را یکسان سازی کنید!";
                            return;
                        }
                    }

                    if (!Directory.Exists(fings))
                    {
                        Directory.CreateDirectory(fings);
                    }
                    File.WriteAllBytes(fings + "\\" + empId + i + ".eft", fingerBytes);
                }
            }
        }


        private int AnalyzeForGetfingerFile(string fingsRecord, ref int[] a)
        {
            try
            {
                var setButton = false;
                bool flag;
                if (!Directory.Exists(fingsRecord))
                {
                    MessageBox.Show(@"پوشه FingsRecord  موجود نمی باشد", @"خطا", MessageBoxButtons.OK,
                        MessageBoxIcon.Error, MessageBoxDefaultButton.Button1,
                        MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                    return -1;
                }
                // if fingsRecord  had error return from method

                var fingsRecordfile = Directory.GetFiles(fingsRecord, "FingsRecord.txt");


                var fileLines = File.ReadLines(fingsRecordfile[0]);

                foreach (var fileLine in fileLines)
                {
                    Application.DoEvents();
                    var end = fileLine.IndexOf(';', 0);
                    var id = fileLine.Substring(2, end - 2);

                    if (id == Convert.ToString(_employee.ID))
                    {
                        var fingNumEnd = fileLine.IndexOf(';', end + 1);
                        var fingsNumSum = Convert.ToInt32(fileLine.Substring(end + 1, fingNumEnd - (end + 1)));
                        double fingNum = 9;
                        setButton = true;

                        var binary = Convert.ToString(fingsNumSum, 2);

                        for (var i = 0; i < binary.Length; i++)
                        {
                            a[i] = Convert.ToInt32(binary[(binary.Length - 1) - i].ToString());
                        }
                        for (var i = binary.Length; i < a.Length; i++)
                        {
                            a[i] = 0;
                        }

                        return Convert.ToInt32(id);
                    }
                }
                return -1;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }
    }
}