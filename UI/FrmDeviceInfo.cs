using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using BLL;
using Model;

namespace UI
{
    public partial class FrmDeviceInfo : Form
    {
        /// <summary>
        ///     FrmAccess
        /// </summary>
        private readonly Device _device = new Device();

        private readonly DeviceBLL _deviceBll = new DeviceBLL();
        private readonly EmployeeBLL _employeeBll = new EmployeeBLL();
        private readonly DeviceEmpBll _deviceEmpBll = new DeviceEmpBll();
        private readonly FingerBLL _fingerBll = new FingerBLL();

        public FrmDeviceInfo()
        {
            InitializeComponent();
            var imagesDirectory =
                // ReSharper disable once AssignNullToNotNullAttribute
                Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "Images");
            PicEcho.Image = Image.FromFile(imagesDirectory + "\\Eco.gif");
        }

        public FrmDeviceInfo(Device device)
        {
            _device = device;
            InitializeComponent();
        }


        private void FrmDeviceInfo_Load(object sender, EventArgs e)
        {
            gridAccess.DataSource = _deviceEmpBll.EmployeesInOneDevices(_device.ID).ToList();
            GrpBoxAccess.Text = @"لیست دسترسی اشخاص به دستگاه " + _device.DeviceName;
            grdAccess.GroupPanelText = @"جهت فیلتر کردن هر ستون ستون مورد نظر را به این قسمت بکشید";
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            try
            {
                if (!_deviceBll.Ping(_device.IP, _device.Port))
                    //if (!_deviceBll.Ping(_device.IP, _device.Port, _device.ServerIP))
                {
                    MessageBox.Show(@"این دستگاه در شبکه موجود نمی باشد", @"پیام", MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    return;
                }
                //EnabledForm(false);
                InitializeProgressBarPic(100);

                var employees = new List<Employee>();
                var employeeInDevice = (List<EmployeesInOneDevice>) grdAccess.DataSource;


                // ReSharper disable once AssignNullToNotNullAttribute
                var dbPath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location),
                    "Db");
                // ReSharper disable once AssignNullToNotNullAttribute
                var picturePath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location),
                    "Pics\\" + _device.IP);

                //   _employeeBll.BuildDBfile(ref employeeInDevice, _device);

                var sentDb = SendDB(dbPath);
                SendProgress.Increment(20);
                SendProgress.Refresh();


                employees = EmployeeForSendPicture(employeeInDevice);
                _employeeBll.GetPictureOfEmployee(employees, _device);

                SendProgress.Increment(10);
                SendProgress.Refresh();

                employees = EmployeeForDeletePicture(employeeInDevice);
                _employeeBll.BuildDeletePictureFile(employees, _device);

                SendProgress.Increment(10);
                SendProgress.Refresh();

                var sentPic = SendPicture(picturePath);


                SendProgress.Increment(20);
                SendProgress.Refresh();

                employees = EmployeeForDeleteFinger(employeeInDevice);
                bool sentSync;
                sentSync = employees.Count == 0 || SendDeleteFinger(employees);

                SendProgress.Increment(20);
                SendProgress.Refresh();


                //method for select edite employee and then send for update
                var editedEmployeeAccess = EmployeeForUpdateAccess(employeeInDevice);
                UpdateAccess(editedEmployeeAccess);

                SendProgress.Increment(20);
                SendProgress.Refresh();

                if (sentDb && sentPic && sentSync & SendProgress.Position == 100)
                {
                    MessageBox.Show(@"عملیات با موفقیت به اتمام رسید", @"پیام", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    DeleteFiles();
                    //  EnabledForm(true);
                    InitializeProgressBarPic(100);
                    gridAccess.DataSource = _deviceEmpBll.EmployeesInOneDevices(_device.ID).ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void EnabledForm(bool p)
        {
            //           this.Enabled = p;
            btnSend.Enabled = p;
            GrpBoxAccess.Enabled = p;
            gridAccess.Enabled = p;
        }

        private List<EmployeesInOneDevice> EmployeeForUpdateAccess(List<EmployeesInOneDevice> employeeInDevice)
        {
            var employee = new List<EmployeesInOneDevice>();
            try
            {
                foreach (var empInDevice in employeeInDevice)
                {
                    if (empInDevice.Db != empInDevice.DeviceEmp.Db ||
                        empInDevice.Picture != empInDevice.DeviceEmp.Picture ||
                        empInDevice.Finger != empInDevice.DeviceEmp.Finger)
                        employee.Add(empInDevice);
                }
                return employee;
            }
            catch (Exception)
            {
                return null;
                throw;
            }
        }

        private bool SendDeleteFinger(List<Employee> employees)
        {
            try
            {
                foreach (var employee in employees)
                {
                    Application.DoEvents();
                    foreach (var finger in employee.Fingers)
                    {
                        _fingerBll.GenerateSyncFile((-1*employee.ID), finger.FingerNum);
                    }
                }
                // ReSharper disable once AssignNullToNotNullAttribute
                var syncPath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location),
                    "Sync");
                var syncdestination = "Sync2.fpt";
                var requestFileName = _deviceBll.CreateRequestFileName(_device, syncPath + "\\Sync.txt", syncdestination);
                if (_deviceBll.Ping(_device.IP, _device.Port))
                    if (_device.UDPPort != null &&
                        _deviceBll.SendTftp(syncPath + "\\Sync.txt", requestFileName, _device.IP, (int) _device.UDPPort) ==
                        0)
                        return true;
                return false;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private bool SendPicture(string picturePath)
        {
            try
            {
                var filePath = Directory.GetFiles(picturePath, "*.bmp*");

                foreach (var f in filePath)
                {
                    Application.DoEvents();
                    var index = f.IndexOf(_device.IP, StringComparison.Ordinal);
                    var destination = "Pics\\" + f.Substring(index + _device.IP.Length + 1);

                    var requestFileName = _deviceBll.CreateRequestFileName(_device, f, destination);

                    if (_device.UDPPort != null)
                        _deviceBll.SendTftp(f, requestFileName, _device.IP, (int) _device.UDPPort);
                }
                return true;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }

        private List<Employee> EmployeeForDeleteFinger(List<EmployeesInOneDevice> employeeInDevice)
        {
            try
            {
                var employee = new List<Employee>();
                employee.AddRange(from empInDvc in employeeInDevice
                    where (empInDvc.Db == false && empInDvc.Finger == false && empInDvc.Db != empInDvc.DeviceEmp.Db)
                    //                                      || (empInDvc.Db == false && empInDvc.Employee.Image != null && empInDvc.Db != empInDvc.DeviceEmp.Db)
                    select empInDvc.Employee);
                return employee;
            }
            catch (Exception)
            {
                throw;
            }
        }

        private bool SendDB(string dbPath)
        {
            var file = Directory.GetFiles(dbPath, _device.IP + ".txt")[0];
            var destination = "db\\db.txt";
            var requestFileName = _deviceBll.CreateRequestFileName(_device, file, destination);
            if (_device.UDPPort != null &&
                _deviceBll.SendTftp(file, requestFileName, _device.IP, (int) _device.UDPPort) == 0)
                return true;
            return false;
        }

        private List<Employee> EmployeeForDeletePicture(List<EmployeesInOneDevice> employeeInDevice)
        {
            var employee = new List<Employee>();
            try
            {
                employee.AddRange(from empInDvc in employeeInDevice
                    where
                        (empInDvc.Picture != empInDvc.DeviceEmp.Picture && empInDvc.Picture == false &&
                         empInDvc.Employee.Image != null)
                    //                                      || (empInDvc.Db == false && empInDvc.Employee.Image != null && empInDvc.Db != empInDvc.DeviceEmp.Db)
                    select empInDvc.Employee);

                return employee;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        private List<Employee> EmployeeForSendPicture(List<EmployeesInOneDevice> employeeInDevice)
        {
            var employee = new List<Employee>();
            try
            {
                employee.AddRange(from empInDvc in employeeInDevice
                    where
                        empInDvc.Picture != empInDvc.DeviceEmp.Picture && empInDvc.Picture == true &&
                        empInDvc.Employee.Image != null
                    select empInDvc.Employee);

                return employee;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        private void UpdateAccess(List<EmployeesInOneDevice> employeeInDevice)
        {
            try
            {
                _deviceEmpBll.UpdateAccess(employeeInDevice);
            }
            catch (Exception)
            {
                throw;
            }
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
            if (Directory.Exists(syncPath))
            {
                var filePath = Directory.GetFiles(syncPath, "*.txt");
                foreach (var file in filePath)
                {
                    File.Delete(file);
                }
            }
        }


        private void InitializeProgressBarPic(int maximum)
        {
            SendProgress.Position = 0;
            SendProgress.Properties.Step = 1;
            SendProgress.Properties.PercentView = true;
            SendProgress.Properties.Maximum = maximum;
            SendProgress.Properties.Minimum = 0;
        }

        private void Button1_Click(object sender, EventArgs e)
        {

        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {

        }
    }
}