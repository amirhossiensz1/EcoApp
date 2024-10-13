using System;
using System.Collections.Generic;
using Model;
using BLL;
using System.Windows.Forms;
using System.Threading;
using zkemkeeper;

namespace Eco
{
    public partial class FrmDeleteInfo : Form
    {
        private readonly List<Employee> _employees = new List<Employee>();
        private readonly EmployeeBLL _employeeBll = new EmployeeBLL();
        DeviceBLL deviceBll = new DeviceBLL();
        private Thread[] _deviceThread;
        private int[] _progressbarIndex;
        private bool[] _finishFlag;
        private string[] _sendingResult;



        public FrmDeleteInfo()
        {
            InitializeComponent();
        }

        public FrmDeleteInfo(Employee employee)
        {
            InitializeComponent();
            _employees.Add(employee);
        }
        public FrmDeleteInfo(List<Employee> employees)
        {
            InitializeComponent();
            _employees = employees;
        }

        private void FrmDeleteInfo_Load(object sender, EventArgs e)
        {

            var devices = deviceBll.SelectDevices();
            gridSendInfo.DataSource = devices;
            gridSendInfo.Show();
            EmptyProgressBar(devices);
            EmptrySendingResult(devices);
            IntialProgressbarIndex(devices);

        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            var deviceBll = new DeviceBLL();

            var onlineDevices = new List<Device>();

            var allDevices = deviceBll.SelectDevices();

            var selectedDevice = grdSendInfo.GetSelectedRows();

            if (selectedDevice.Length == 0)
            {
                MessageBox.Show(@"لطفا حداقل یک دستگاه برای حذف اطلاعات انتخاب شود!!!", @"خطا",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1,
                    MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                btnSend.Enabled = true;
                btnCancel.Enabled = true;
            }
            else {
                btnSend.Enabled = false;
                btnCancel.Enabled = false;

                var result = new object[selectedDevice.Length];
                var rowNum = new int[selectedDevice.Length];

                for (int i = 0; i < selectedDevice.Length; i++)
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
                        rowNum[i] = -1;
                    }
                }

                var devices = deviceBll.SelectDevices(result);

                foreach (var device in devices)
                {
                    //   if (deviceBll.Ping(device.IP, device.Port,device.ServerIP))
                    if (deviceBll.Ping(device.IP, device.Port))
                    {
                        onlineDevices.Add(device);
                    }
                }

                _deviceThread = new Thread[onlineDevices.Count];

                IntialFinishFlag(onlineDevices);

                IntialSendingResult(allDevices);

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
                    while (true)
                    {
                        Application.DoEvents();
                        for (var i = 0; i < _progressbarIndex.Length; i++)
                        {
                            grdSendInfo.SetRowCellValue(i, basicInfoCol, _progressbarIndex[i]);
                        }
                        if (Finished(0))
                        {
                            MessageBox.Show(@"عملیات به اتمام رسید", @"پیام", MessageBoxButtons.OK,
                                MessageBoxIcon.None);
                            SetSendingResult(onlineDevices);
                            EmptyProgressBar(devices);
                            IntialProgressbarIndex(deviceBll.SelectDevices());
                            btnSend.Enabled = true;
                            btnCancel.Enabled = true;
                            return;
                        }
                    }
                }

            }

        }

        private void SendThread(int index, int row, Device device)
        {
            if (device.DeviceType.Type == "ZK")
            {
                CZKEMClass _czkem = new CZKEMClass();
                _progressbarIndex[row] = 0;

                bool flag = false;
                int j = 0;
                if (ConnectToDevice(device.IP, device.Port, _czkem))
                {
                    foreach (var employee in _employees)
                    {
                        if (ConnectToDevice(device.IP, device.Port, _czkem))
                        {
                            deviceBll.DeleteEmployeeFaceFromZK(_czkem, employee.PersonalNum);
                            deviceBll.DeleEmployeeFingerFromZK(_czkem, employee.PersonalNum);
                            flag = _czkem.SSR_DeleteEnrollDataExt(1, employee.PersonalNum, 12);
                        }
                        j++;
                        if (flag)
                        {
                            _progressbarIndex[row] = j * 100 / _employees.Count;
                            employee.SendToZK = false;
                            _employeeBll.UpdateEmployeeforZK(employee);
                        }
                    }
                    _czkem.Disconnect();
                    _finishFlag[index] = true;
                    _progressbarIndex[row] = 0;
                    _sendingResult[row] = "عملیات حذف به اتمام رسید.";
                }
                else
                {
                    _czkem.Disconnect();
                    _finishFlag[index] = true;
                    _progressbarIndex[row] = 0;
                    _sendingResult[row] = "برقراری ارتباط با دستگاه نا موفق";
                }
            }
        }

        public bool ConnectToDevice(string Ip, int? port, CZKEM _czkem)
        {
            if (_czkem.Connect_Net(Ip, (int)port))
                return true;
            return false;
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
        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
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
        private void IntialProgressbarIndex(List<Device> devices)
        {
            _progressbarIndex = new int[devices.Count];
            for (var i = 0; i < _progressbarIndex.Length; i++)
            {
                _progressbarIndex[i] = 0;
            }
        }
        private void EmptrySendingResult(List<Device> devices)
        {
            try
            {
                for (var i = 0; i < devices.Count; i++)
                {
                    grdSendInfo.SetRowCellValue(i, message, "");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        private void EmptyProgressBar(List<Device> devices)
        {
            try
            {
                for (var i = 0; i < devices.Count; i++)
                {
                    grdSendInfo.SetRowCellValue(i, basicInfoCol, 0);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        private void SetSendingResult(List<Device> devices)
        {
            for (var i = 0; i < _sendingResult.Length; i++)
            {
                grdSendInfo.SetRowCellValue(i, message, _sendingResult[i]);
            }
        }

    }
}
