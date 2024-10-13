using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Threading;
using System.Windows.Forms;
using BLL;
using Model;

namespace UI
{
    public partial class FrmDeleteFingerDevice : Form
    {
        private List<Device> _devices = new List<Device>();
        private readonly Employee _employee = new Employee();
        private readonly FingerBLL _fingerBll = new FingerBLL();
        private readonly DeviceBLL deviceBll = new DeviceBLL();
        private readonly DeviceEmpBll deviceEmpBll = new DeviceEmpBll();
        private EmployeeBLL employeeBll = new EmployeeBLL();
        private readonly int fingerNum;

        public FrmDeleteFingerDevice()
        {
            InitializeComponent();
        }

        public FrmDeleteFingerDevice(Employee employees, int fingerNum)
        {
            InitializeComponent();
            _employee = employees;
            this.fingerNum = fingerNum;
        }

        private void FrmDeleteFingerDevice_Load(object sender, EventArgs e)
        {
            grdDevices.DataSource = deviceBll.SelectDevices();
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (!selectDevice())
                {
                    MessageBox.Show(@"لطفا حداقل یک دستگاه برای ارسال اطلاعات انتخاب شود!!!", @"خطا",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1,
                        MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                }
                else
                {
                    var rst = MessageBox.Show(@"آیا مطمئن به حذف اثر انگشت هستید", @"پیام", MessageBoxButtons.YesNo,
                        MessageBoxIcon.Warning);

                    if (rst == DialogResult.Yes)
                    {
                        DeleteFingerFromDevice(_employee.ID, fingerNum);

                        deviceEmpBll.DeleteFingerfromDeviceEmp(_employee.ID, _devices);

                        if (_fingerBll.SelectOneFinger(_employee.ID) == false)
                        {
                            deviceEmpBll.DeleteFingerfromDeviceEmp(_employee.ID, _devices);
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                throw;
            }
        }

        private bool selectDevice()
        {
            try
            {
                var selectedDevice = grdDevice.GetSelectedRows();

                if (selectedDevice.Length == 0)
                {
                    return false;
                }
                var result = new object[selectedDevice.Length];

                for (var i = 0; i < selectedDevice.Length; i++)
                {
                    var rowHandle = selectedDevice[i];

                    if (!grdDevice.IsGroupRow(rowHandle))
                    {
                        result[i] = grdDevice.GetRowCellValue(rowHandle, "ID");
                    }
                    else
                    {
                        result[i] = -1; // default value
                    }
                }

                _devices = deviceBll.SelectDevices(result);
                return true;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }

        private void DeleteFingerFromDevice(int empId, int fingerNum)
        {
            try
            {
                var flag = -1;

                //var devices = deviceBll.SelectDevices();
                var deviceThread = new Thread[_devices.Count];

                _fingerBll.GenerateSyncFile((-1*empId), fingerNum);


                for (var i = 0; i < _devices.Count; i++)
                {
                    var index = i;
                    deviceThread[index] = new Thread(() => SendThread(_devices[index]));
                    deviceThread[index].Start();
                }
                //                for (int i = 0; i < devices.Count; i++)
                //                {
                //                    
                //                    flag = SendThread(devices[i]);
                //                }
                //                if (flag == 0)
                //                {
                //                    if (Directory.Exists(syncPath))
                //                        File.Delete(syncPath + "\\Sync.txt");
                //                    return;
                //                }           
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
            }
        }

        private int SendThread(Device device)
        {
            var flag = -1;
            var deviceBll = new DeviceBLL();
            // ReSharper disable once AssignNullToNotNullAttribute
            var syncPath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location),
                "Sync");
            var syncdestination = "Sync2.fpt";

            var requestFileName = deviceBll.CreateRequestFileName(device, syncPath + "\\Sync.txt", syncdestination);

            if (deviceBll.Ping(device.IP, device.Port))
                if (device.UDPPort != null)
                    flag = deviceBll.SendTftp(syncPath + "\\Sync.txt", requestFileName, device.IP, (int) device.UDPPort);
            return flag;
        }
    }
}