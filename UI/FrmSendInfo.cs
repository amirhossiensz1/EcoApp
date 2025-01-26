using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Windows.Forms;
using BLL;
using Model;
using zkemkeeper;

namespace UI
{
    public partial class FrmSendInfo : Form
    {
        private readonly DeviceEmpBll _deviceEmpBll = new DeviceEmpBll();
        private readonly EmployeeBLL _employeeBll = new EmployeeBLL();
        private readonly List<Employee> _employees = new List<Employee>();
        private bool _db;
        private Thread[] _deviceThread;
        private bool _finger;
        private bool[] _finishFlag;
        private bool _picture;
        private bool _face;
        private int[] _progressbarIndex;
        private string[] _sendingResult;


        private bool bIsConnected = false;//the boolean value identifies whether the device is connected
        private int iMachineNumber = 1;//the serial number of the device.After connecting the device ,this value will be changed.
        private bool justFaceSend = false;

        public FrmSendInfo()
        {
            InitializeComponent();
        }

        public FrmSendInfo(bool flagSend, Employee employee)
        {
            InitializeComponent();
            justFaceSend = flagSend;
            _employees.Add(employee);

            var fullName = " " + employee.EmpFname + " " + employee.EmpLname;
            grpInfo.Text += fullName;
        }

        public FrmSendInfo(Employee employee)
        {
            InitializeComponent();
            _employees.Add(employee);

            var fullName = " " + employee.EmpFname + " " + employee.EmpLname;
            grpInfo.Text += fullName;
        }

        private void EmptyProgressBar(int count)
        {
            try
            {
                for (var i = 0; i < count; i++)
                {
                    grdSendInfo.SetRowCellValue(i, basicInfoCol, 0);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }


        private void FrmSendInfo_Load(object sender, EventArgs e)
        {
            var deviceEmpBll = new DeviceEmpBll();
            var deviceBll = new DeviceBLL();
            grdSendInfo.GroupPanelText = @"جهت فیلتر کردن هر ستون ستون مورد نظر را به این قسمت بکشید";

            //this should be change
            var devices = deviceBll.SelectDevices();

            gridSendInfo.DataSource = devices;
            gridSendInfo.Show();
            if (_employees[0].HasFinger != true)
                chkFinger.Enabled = false;
            if (_employees[0].Image == null)
                chkPic.Enabled = false;
            EmptyProgressBar(devices.Count);
            EmptrySendingResult(devices.Count);
            IntialProgressbarIndex(devices.Count);
            if (justFaceSend)
            {
                chkBasicDb.Checked = true;
                chkFace.Checked = true;
                chkFinger.Enabled = false;
                chkPalm.Enabled = false;
                chkPic.Enabled = false;
            }
        }

        private void EmptrySendingResult(int count)
        {
            try
            {
                for (var i = 0; i < count; i++)
                {
                    grdSendInfo.SetRowCellValue(i, message, "");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        private void IntialFinishFlag(List<Device> devices)
        {
            _finishFlag = new bool[devices.Count];
            for (var i = 0; i < _finishFlag.Length; i++)
            {
                _finishFlag[i] = false;
            }
        }

        private void IntialSendingResult(List<Device> devices)
        {
            _sendingResult = new string[devices.Count];
            for (var i = 0; i < _sendingResult.Length; i++)
            {
                _sendingResult[i] = "";
            }
        }

        private void IntialProgressbarIndex(int count)
        {
            _progressbarIndex = new int[count];
            for (var i = 0; i < _progressbarIndex.Length; i++)
            {
                _progressbarIndex[i] = 0;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            var deviceBll = new DeviceBLL();
            var onlineDevices = new List<Device>();


            //---------------------------------------------------------
            if (chkFinger.Checked == false && chkPic.Checked == false && chkBasicDb.Checked == false)
            {
                MessageBox.Show(@"یکی از گزینه های ارسال را انتخاب نمایید!!!", @"خطا", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1,
                    MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                btnSend.Enabled = true;
                btnCancel.Enabled = true;
            }

            else
            {
                var allDevices = deviceBll.SelectDevices();
                var selectedDevice = grdSendInfo.GetSelectedRows();

                if (selectedDevice.Length == 0)
                {
                    MessageBox.Show(@"لطفا حداقل یک دستگاه برای ارسال اطلاعات انتخاب شود!!!", @"خطا",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1,
                        MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                    btnSend.Enabled = true;
                    btnCancel.Enabled = true;
                }

                else
                {
                    btnSend.Enabled = false;
                    btnCancel.Enabled = false;
                    var result = new object[selectedDevice.Length];
                    var rowNum = new int[selectedDevice.Length];

                    for (var i = 0; i < selectedDevice.Length; i++)
                    {
                        var rowHandle = selectedDevice[i];

                        if (!grdSendInfo.IsGroupRow(rowHandle))
                        {
                            result[i] = grdSendInfo.GetRowCellValue(rowHandle, "ID");
                            rowNum[i] = rowHandle;
                        }
                        else
                        {
                            result[i] = -1; // default value
                            rowNum[i] = rowHandle;
                        }
                    }

                    var devices = deviceBll.SelectDevices(result);

                    foreach (var device in devices)
                    {
                        if (deviceBll.Ping(device.IP, device.Port))
                        {
                            onlineDevices.Add(device);
                        }
                    }
                    _deviceThread = new Thread[onlineDevices.Count];
                    IntialFinishFlag(onlineDevices);

                    IntialSendingResult(allDevices);

                    //this should be change
                    var updateAccessThread = new Thread(() => UpdateAccess(onlineDevices));

                    _finger = chkFinger.Checked;
                    _picture = chkPic.Checked;
                    _db = chkBasicDb.Checked;
                    _face = chkFace.Checked;

                    for (var i = 0; i < onlineDevices.Count; i++)
                    {
                        var index = i;
                        var row = 0;
                        for (var j = 0; j < result.Length; j++)
                        {
                            if (onlineDevices[index].ID == (int)result[j])
                                row = rowNum[j];
                        }
                        if (selectedDevice.Length > index)
                            _deviceThread[index] = new Thread(() => SendThread(index, row, onlineDevices[index]));
                        _deviceThread[index].Start();
                    }
                    if (onlineDevices.Count == 0)
                    {
                        MessageBox.Show(@"دستگاه انتخاب شده در شبکه وجود ندارد", @"پیام", MessageBoxButtons.OK,
                            MessageBoxIcon.None);
                        btnSend.Enabled = true;
                        btnCancel.Enabled = true;
                    }
                    else
                    {
                        var updateFlag = true;
                        while (true)
                        {
                            Application.DoEvents();
                            for (var i = 0; i < _progressbarIndex.Length; i++)
                            {
                                grdSendInfo.SetRowCellValue(i, basicInfoCol, _progressbarIndex[i]);
                            }
                            if (Finished(0))
                            {
                                if (updateFlag)
                                {
                                    updateAccessThread.Start();
                                    updateFlag = false;
                                    SetSendingResult(onlineDevices);
                                }
                                if (!updateAccessThread.IsAlive)
                                {
                                    //     DeleteFiles();
                                    MessageBox.Show(@"عملیات به اتمام رسید", @"پیام", MessageBoxButtons.OK,
                                        MessageBoxIcon.None);
                                    EmptyProgressBar(deviceBll.SelectDevices().Count);
                                    IntialProgressbarIndex(deviceBll.SelectDevices().Count);
                                    btnSend.Enabled = true;
                                    btnCancel.Enabled = true;
                                    return;
                                }
                            }
                        }
                    }
                }
            }
        }

        private void SetSendingResult(List<Device> devices)
        {
            for (var i = 0; i < _sendingResult.Length; i++)
            {
                grdSendInfo.SetRowCellValue(i, message, _sendingResult[i]);
            }
        }

        private void UpdateAccess(List<Device> onlineDevices)
        {
            _deviceEmpBll.UpdateAccess2(_employees, onlineDevices, _finger, _picture, _db);
        }

        private void DeleteFiles()
        {
            // ReSharper disable once AssignNullToNotNullAttribute
            var dbPath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location),
                "Db");
            // ReSharper disable once AssignNullToNotNullAttribute
            var picturePath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location),
                "Pics");
            // ReSharper disable once AssignNullToNotNullAttribute
            var fingsPath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location),
                "Fings");
            // ReSharper disable once AssignNullToNotNullAttribute
            var syncPath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location),
                "Sync");


            if (Directory.Exists(dbPath))
            {
                var filePath = Directory.GetFiles(dbPath, "*.txt");
                foreach (var file in filePath)
                {
                    File.Delete(file);
                }
            }

            if (Directory.Exists(picturePath))
            {
                var subfolders = Directory.GetDirectories(picturePath);
                foreach (var subfolder in subfolders)
                {
                    var filePath = Directory.GetFiles(subfolder, "*.bmp*");
                    foreach (var file in filePath)
                    {
                        File.Delete(file);
                    }
                    Directory.Delete(subfolder);
                }
            }

            if (Directory.Exists(fingsPath))
            {
                var subfolders = Directory.GetDirectories(fingsPath);
                foreach (var subfolder in subfolders)
                {
                    var filePath = Directory.GetFiles(subfolder, "*.txt");
                    foreach (var file in filePath)
                    {
                        File.Delete(file);
                    }
                    Directory.Delete(subfolder);
                }
            }

            if (Directory.Exists(syncPath))
            {
                var subfolders = Directory.GetDirectories(syncPath);
                foreach (var subfolder in subfolders)
                {
                    var filePath = Directory.GetFiles(subfolder, "*.txt");
                    foreach (var file in filePath)
                    {
                        File.Delete(file);
                    }
                    Directory.Delete(subfolder);
                }
            }
        }

        private bool Finished(int i)
        {
            if (_finishFlag[i])
            {
                if (_finishFlag.Length - 1 == i)
                    return true;
                i++;
                return Finished(i);
            }
            return false;
        }

        private void SendThread(int i, int row, Device device)
        {
            var errorMessage = "";
            int response;
            var finishSync = true;
            var checkFingSend = true;
            var checkPicSend = true;
            var checkDbSend = true;

            var syncCorrupt = false;
            var fingSendCorrupt = false;
            var PicSendCorrupt = false;
            var DbSendCorrupt = false;



            var deviceBll = new DeviceBLL();

            var dbPath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location),
                "Db");

            var schPath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location),
                "SCH");


            // ReSharper disable once AssignNullToNotNullAttribute
            var picturePath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location),
                "Pics\\" + device.IP);
            // ReSharper disable once AssignNullToNotNullAttribute
            var fingsPath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location),
                "Fings\\" + device.IP);
            // ReSharper disable once AssignNullToNotNullAttribute
            var syncPath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location),
                "Sync\\" + device.IP);

            var facePath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location),
                  "Faces\\" + device.IP);


            if (device.DeviceType.Type == "Controller")
            {
                _progressbarIndex[row] = 10;
                // ReSharper disable once AssignNullToNotNullAttribute



                if (_finger)
                {
                    _employeeBll.GetFingersOfEmployees(_employees, device);
                }
                if (_picture)
                {
                    _employeeBll.GetPictureOfEmployee(_employees, device);
                }
                if (_db)
                {
                    // کارمند انتخاب شده  به همراه دستگاه های آنلاین
                    _employeeBll.BuildDBfileCotroller(_employees, device);
                    //   _employeeBll.BuildDBfile(_employees, device);
                }

                _progressbarIndex[row] = 50;
                if (_db)
                {
                    try
                    {
                        checkDbSend = false;

                        var file = Directory.GetFiles(dbPath, device.IP + ".txt")[0];


                        var destination = "db\\db.txt";


                        // var requestFileName = deviceBll.CreateRequestFileName(device, file, destination);

                        response = deviceBll.SendTftp(file, destination, device.IP, (int)device.UDPPort);
                        //   response = deviceBll.SendTftp(file, requestFileName, device.IP, (int) device.UDPPort);


                        var devices = device.DeviceSchGroups;
                        foreach (var dvc in devices)
                        {
                            var SchFile = schPath + "\\" + dvc.SchgroupID + ".sch";
                            var schdestination = "db\\" + dvc.SchgroupID + ".sch";
                            deviceBll.SendTftp(SchFile, schdestination, device.IP, (int)device.UDPPort);
                        }

                        if (response == 0)
                            checkDbSend = true;
                        if (response != 0)
                        {
                            errorMessage = CheckerError(response);
                            DbSendCorrupt = true;
                        }
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e);
                    }
                }
                _progressbarIndex[row] = 60;

                if (_picture & checkDbSend)
                {
                    try
                    {
                        checkPicSend = false;
                        var filePath = Directory.GetFiles(picturePath, "*.bmp");

                        foreach (var file in filePath)
                        {
                            var index = file.IndexOf(device.IP, StringComparison.Ordinal);
                            var destination = "Pics\\" + file.Substring(index + device.IP.Length + 1);

                            var requestFileName = deviceBll.CreateRequestFileName(device, file, destination);

                            response = deviceBll.SendTftp(file, requestFileName, device.IP, (int)device.UDPPort);
                            if (response == 0)
                                checkPicSend = true;
                            if (response != 0)
                            {
                                PicSendCorrupt = true;
                                errorMessage = "عدم موفقیت در ارسال کامل عکس ";
                                break;
                            }
                        }
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e);
                    }
                }

                _progressbarIndex[row] = 70;
                if (_finger & checkPicSend & checkDbSend)
                {
                    try
                    {
                        finishSync = false;
                        checkFingSend = false;

                        var filePath = Directory.GetFiles(fingsPath, "*.txt");

                        int index;
                        int endIndex;
                        foreach (var file in filePath)
                        {
                            index = file.IndexOf(device.IP, StringComparison.Ordinal);
                            endIndex = file.IndexOf(".txt", StringComparison.Ordinal);
                            var destination = "Fings\\" +
                                              file.Substring(index + device.IP.Length + 1,
                                                  endIndex - (index + device.IP.Length + 1)) + ".eft";

                            var requestFileName = deviceBll.CreateRequestFileName(device, file, destination);

                            response = deviceBll.SendTftp(file, requestFileName, device.IP, (int)device.UDPPort);
                            if (response == 0)
                                checkFingSend = true;
                            if (response != 0)
                            {
                                errorMessage = "عدم موفقیت در ارسال کامل اثرانگشت";
                                fingSendCorrupt = true;
                                break;
                            }
                        }


                        var syncdestination = "Sync2.fpt";
                        var requestFileNameSync = deviceBll.CreateRequestFileName(device, syncPath + "\\Sync.txt",
                            syncdestination);

                        response = deviceBll.SendTftp(syncPath + "\\Sync.txt", requestFileNameSync, device.IP,
                            (int)device.UDPPort);
                        if (response == 0)
                            finishSync = true;
                        if (response != 0)
                        {
                            errorMessage = "عدم موفقیت در ارسال فایل سینک";
                            syncCorrupt = true;
                        }
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e);
                    }
                }
                if (checkDbSend & checkPicSend & checkFingSend & finishSync)
                {
                    _progressbarIndex[row] = 100;
                    _finishFlag[i] = true;
                }
                if ((!checkDbSend & DbSendCorrupt) || (PicSendCorrupt & !checkPicSend) || (fingSendCorrupt & !checkFingSend) ||
                    (syncCorrupt & !finishSync))
                {
                    _finishFlag[i] = true;
                    _progressbarIndex[row] = 0;
                    _sendingResult[row] = errorMessage;
                }
            }

            if (device.DeviceType.Type == "ZK")
            {
                CZKEMClass _czkem = new CZKEMClass();
                _progressbarIndex[row] = 0;
                int idwErrorCode = 0;

                bool flag = false;
                int j = 0;
                if (ConnectToDevice(device.IP, device.Port, _czkem))
                {
                    foreach (var employee in _employees)
                    {
                        if (ConnectToDevice(device.IP, device.Port, _czkem))
                        {
                            if (_db)
                            {

                                var a = from l in _employeeBll.SelectOneEmployees(employee.PersonalNum).Cards
                                        select l.CardData;
                                if (a.Any())
                                {
                                    _czkem.SetStrCardNumber(a.First());

                                }

                                //SendTimeZone();
                                ScheduleGroupBll schBll = new ScheduleGroupBll();
                                WeekScheduleBll weekScheduleBll = new WeekScheduleBll();
                                var ScheduleGroups = schBll.SelectAll();

                                foreach (var ScheduleGroup in ScheduleGroups)
                                {
                                    var weekSchedule = weekScheduleBll.SelectWeekDaysBySchGroupId(ScheduleGroup.ID);
                                    List<string> TimeZoneInfo = new List<string>();
                                    for (int k = 0; k < 7; k++)
                                    {

                                        for (int q = 0; q < weekSchedule.Count; q++)
                                        {
                                            if (weekSchedule[q].weekday == k)
                                            {
                                                if (weekSchedule[q].DayType.DaySchedules.ToList()
                                                    .FirstOrDefault(c => c.AccessTypeID == 3) != null)
                                                {

                                                    TimeZoneInfo.Add(weekSchedule[q].DayType.DaySchedules.ToList()
                                                                         .FirstOrDefault(c => c.AccessTypeID == 3).StartTime.Substring(0, 4)
                                                                     + weekSchedule[q].DayType.DaySchedules.ToList()
                                                                         .FirstOrDefault(c => c.AccessTypeID == 3).EndTime.Substring(0, 4));
                                                    break;
                                                }
                                                TimeZoneInfo.Add("00000000");
                                                break;
                                            }
                                        }
                                        if (j == weekSchedule.Count)
                                            TimeZoneInfo.Add("00000000");
                                    }

                                    var re = _czkem.SetTZInfo(1, ScheduleGroup.ID, TimeZoneInfo[1] + TimeZoneInfo[2] + TimeZoneInfo[3] + TimeZoneInfo[4] + TimeZoneInfo[5] + TimeZoneInfo[6] + TimeZoneInfo[0]);
                                }


                                //Send Holiday

                                var holidaysGroups = new HoliDaysGroupBll().SelectAll();

                                foreach (var holidaysGroup in holidaysGroups)
                                {
                                    var holidays = new HoliDayBll().SelectHolidayByHolidayGroupId((int)holidaysGroup.ID);

                                    var holidayschGroups = new HoliDaysSchGroupBll().SelectAllHolidaySchGroup(holidaysGroup.ID);

                                    foreach (var holidayschGroup in holidayschGroups)
                                    {
                                        foreach (var holiday in holidays)
                                        {
                                            _czkem.SSR_SetHoliday(1, holiday.ID,
                                                Convert.ToInt32(holiday.Date.Substring(5, 2)),
                                                Convert.ToInt32(holiday.Date.Substring(8, 2)),
                                                Convert.ToInt32(holiday.Date.Substring(5, 2)),
                                                Convert.ToInt32(holiday.Date.Substring(8, 2)), (int)holidayschGroup.SchGroupID);
                                        }
                                    }

                                }
                                //send AceessGroup
                                AccessGroupBll accessGroupBll = new AccessGroupBll();
                                var accessGroupList = accessGroupBll.SelectAll();
                                foreach (var accessGroup in accessGroupList)
                                {
                                    var acsgroupArea = accessGroup.AcsGroupAcsAreas.ToList();
                                    foreach (var acsGroupAcsArea in acsgroupArea)
                                    {
                                        var deviceSch = device.DeviceSchGroups.ToList().FirstOrDefault(dsg => dsg.AcsAreaID == acsGroupAcsArea.AcsAreaID);
                                        if (deviceSch != null)
                                        {
                                            var re = _czkem.SSR_SetGroupTZ(1, (int)accessGroup.ID, (int)deviceSch.SchgroupID, 0, 0, 0, (int)0);
                                            var r = _czkem.SSR_SetUnLockGroup(1, (int)accessGroup.ID, (int)accessGroup.ID, 0, 0, 0, 0);
                                        }
                                        else
                                        {
                                            var re = _czkem.SSR_SetGroupTZ(1, (int)accessGroup.ID, (int)0, 0, 0, 0, 0);
                                            var r= _czkem.SSR_SetUnLockGroup(1, (int)accessGroup.ID, (int)accessGroup.ID, 0, 0, 0, 0);
                                        }
                                    }
                                }

                                if ((bool)employee.IsAdmin)
                                    flag = _czkem.SSR_SetUserInfo(1, employee.PersonalNum,
                                        employee.EmpFname + employee.EmpLname, employee.EmpPinCode, 2, true);
                                else
                                {
                                    flag = _czkem.SSR_SetUserInfo(1, employee.PersonalNum,
                                        employee.EmpFname + employee.EmpLname, employee.EmpPinCode, 0, true);
                                }

                                if (employee.PrivateAccess != null && (bool)employee.PrivateAccess)
                                {
                                    var h = _czkem.SetUserGroup(1, Convert.ToInt32(employee.PersonalNum), (int)employee.AcsGroupID);
                                }
                                else
                                {
                                    if (employee.Organization != null)
                                        if (employee.Organization.AcsGroupID != null)
                                            _czkem.SetUserGroup(1, Convert.ToInt32(employee.PersonalNum), (int)employee.Organization.AcsGroupID);
                                }

                                byte _ = 0;
                                var res = _czkem.SetUserInfoEx(1, Convert.ToInt32(employee.PersonalNum),
                                    Convert.ToInt32(employee.AuthenticationMode), ref _);


                            }

                            if (_finger)
                            {
                                foreach (var finger in employee.Fingers)
                                {
                                    if (finger.DataStr != null)
                                    {
                                        bool result;
                                        result = _czkem.SSR_SetUserTmpStr(iMachineNumber, employee.PersonalNum, (int)(finger.FingerNum + (9 - (2 * finger.FingerNum))), finger.DataStr);
                                    }
                                }
                            }

                            if (_face)
                            {
                                if (!Directory.Exists(facePath))
                                    Directory.CreateDirectory(facePath);
                                if (new FaceBll().GetImage(employee.ID) != null)
                                {
                                    MemoryStream msCamera = new MemoryStream(new FaceBll().GetImage(employee.ID), 0, 300 * 300);
                                    FileStream fs = new FileStream(facePath + "\\verify_biophoto_9_" + employee.PersonalNum + ".jpg", FileMode.OpenOrCreate);
                                    msCamera.WriteTo(fs);
                                    fs.Close();
                                }

                                var fce = _czkem.SendFile(iMachineNumber, facePath + "\\verify_biophoto_9_" + employee.PersonalNum + ".jpg");
                                _czkem.GetLastError(ref idwErrorCode);

                                if (!fce)
                                {
                                    var success = _czkem.SendFile(iMachineNumber, facePath + "\\verify_biophoto_9_" + employee.PersonalNum + ".jpg");
                                    if (!success)
                                        success = _czkem.SendFile(iMachineNumber, facePath + "\\verify_biophoto_9_" + employee.PersonalNum + ".jpg");
                                }
                            }

                            if (_picture)
                            {
                                var r = _employeeBll.GetPictureOfEmployeeForZK(employee, device);
                                if (r)
                                {
                                    var pic = _czkem.SendFile(iMachineNumber, picturePath + "\\" + employee.PersonalNum + ".jpg");
                                }
                            }

                        }
                        j++;
                        if (flag)
                        {
                            _progressbarIndex[row] = j * 100 / _employees.Count;
                            employee.SendToZK = flag;
                            _employeeBll.UpdateEmployeeforZK(employee);
                        }

                    }
                    _czkem.Disconnect();
                    _finishFlag[i] = true;
                    _progressbarIndex[row] = 0;
                    _sendingResult[row] = "ارسال موفق بود.";
                }
                else
                {
                    _czkem.Disconnect();
                    _finishFlag[i] = true;
                    _progressbarIndex[row] = 0;
                    _sendingResult[row] = "ارسال ناموفق بود.";
                }
            }
        }

        public bool ConnectToDevice(string Ip, int? port, CZKEM czkem)
        {
            int idwErrorCode = 0;


            bIsConnected = czkem.Connect_Net(Ip, (int)port);
            if (bIsConnected)
                return true;
            return false;
        }
        private string CheckerError(int response)
        {
            switch (response)
            {
                case 0:
                    return "عملیات موفقیت آمیز بود";
                    break;
                case 1:
                    return "عملیات با مشکل مواجه شد";
                    break;
                case 5:
                    return "در شبکه موجود نیست";
                    break;
                case 6:
                    return " در ایجاد کد انکریپت با مشکل مواجه شد";
                    break;
                case 10:
                    return "زمان این دستگاه با سرویس همزمان نیست";
                    break;
                case 11:
                    return "نام کربری و رمز وب دستگاه را تنظیم کنید";
                    break;
                case 12:
                    return "کد فعال سازی وارد شده  با سریال سیستم هم خوانی ندارد!";
                    break;
                case 13:
                    return "کد فعال سازی اشتباه می باشد";
                    break;
                default:
                    return "";
                    break;
            }
        }
    }
}