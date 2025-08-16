using System;
using System.Drawing;
using System.IO;
using System.Net;
using System.Reflection;
using System.Windows.Forms;
using BLL;
using Model;

namespace UI
{
    public partial class FrmAddDevice : Form
    {
        private readonly Device _devices = new Device();
        private readonly bool _edit;
        private string _deviceType = "PDP";

        public FrmAddDevice()
        {
            InitializeComponent();
            var imagesDirectory =
                // ReSharper disable once AssignNullToNotNullAttribute
                Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "Images");
            PicEcho.Image = Image.FromFile(imagesDirectory + "\\Eco.gif");
        }

        public FrmAddDevice(bool edit, Device device)
        {
            InitializeComponent();
            var imagesDirectory =
                // ReSharper disable once AssignNullToNotNullAttribute
                Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "Images");
            _devices = device;
            _edit = edit;
            PicEcho.Image = Image.FromFile(imagesDirectory + "\\Eco.gif");
        }

        private string ConvertSerialToId(string serial)
        {
            if (_deviceType == "Eco")
            {
                var str = serial.Substring(7, 4);
                return 4 + str;
            }
            return serial;
        }

        private string ConvertIdToSerial(int? id)
        {
            if (id == null)
            {
                return "";
            }
            if (_deviceType == "Eco")
            {
                var str = id.ToString();
                str = str.Substring(1);
                return "ECO940T" + str;
            }

            return id.ToString();
        }

        private void FrmAddDevice_Load(object sender, EventArgs e)
        {
            var deviceBll = new DeviceBLL();

            switch (_devices.TypeId)
            {
                case 1:
                    _deviceType = "PDP";
                    break;
                case 2:
                    _deviceType = "Eco";
                    break;
                case 3:
                    _deviceType = "Controller";
                    break;
                case 4:
                    _deviceType = "ZK";
                    break;
            }

            cmbType.DataSource = deviceBll.SelectDevicesType();
            cmbType.DisplayMember = "Type";
            cmbType.ValueMember = "ID";

            txtBxDeviceName.Text = _devices.DeviceName;
            txtBxDeviceIP.Text = _devices.IP;
            txtBxIpServer.Text = _devices.ServerIP;
            txtBxDevicePort.Text = (_devices.Port).ToString();
            txtBxFtpPort.Text = (_devices.UDPPort).ToString();
          //  txtBxSerial.Text = ConvertIdToSerial(_devices.DeviceSerial);
            txtBxSerial.Text = _devices.DeviceSerial;

            if (_deviceType == "Eco")
            {
                txtBxRegistrationCode.Text = _devices.RegistrationCode;
                txtBxActivation.Text = _devices.ActivationCode;
                txtwebuser.Text = _devices.webUser;
                txtwebpass.Text = _devices.webPass;
            }
            if (_deviceType == "ZK")
            {
                txtBxRegistrationCode.Enabled = false;
                txtBxActivation.Enabled = false;
                txtwebuser.Enabled = false;
                txtwebpass.Enabled = false;
                txtBxFtpPort.Enabled = false;
                txtBxSerial.Enabled = false;
            }
            else
            {
                txtBxRegistrationCode.Enabled = false;
                txtBxActivation.Enabled = false;
                txtwebuser.Enabled = false;
                txtwebpass.Enabled = false;
            }


            if (_edit)
            {
                cmbType.Enabled = false;
                btnSave.Visible = false;
                btnEdit.Visible = true;
                var i = _devices.TypeId - 1;
                if (i != null) cmbType.SelectedIndex = (int) i;
            }
        }

        private void btnSave_Click_1(object sender, EventArgs e)
        {
            try
            {
                var device = new Device();
                var deviceBll = new DeviceBLL();

                var deviceEmpBll = new DeviceEmpBll();
                var employeeBll = new EmployeeBLL();

                if (_deviceType == "Eco")
                {
                    if (txtBxDeviceName.Text == "" || txtBxDeviceIP.Text == "" || txtBxDevicePort.Text == "" ||
                        txtBxFtpPort.Text == "" || txtBxSerial.Text == "" ||
                        txtBxRegistrationCode.Text == "" || txtBxActivation.Text == "" || txtBxIpServer.Text == "" ||
                        txtwebuser.Text == "" || txtwebpass.Text == "")
                    {
                        MessageBox.Show(@"اطلاعات خواسته شده را وارد نمایید!!!", @"خطا", MessageBoxButtons.OK,
                            MessageBoxIcon.Error, MessageBoxDefaultButton.Button1,
                            MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                        return;
                    }
                }
                if(_deviceType == "Controller")
                {
                    if (txtBxDeviceName.Text == "" || txtBxDeviceIP.Text == "" || txtBxDevicePort.Text == "" ||
                        txtBxFtpPort.Text == "" ||
                        txtBxSerial.Text == "" || txtBxIpServer.Text == "")
                    {
                        MessageBox.Show(@"اطلاعات خواسته شده را وارد نمایید!!!", @"خطا", MessageBoxButtons.OK,
                            MessageBoxIcon.Error, MessageBoxDefaultButton.Button1,
                            MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                        return;
                    }
                }
                if (_deviceType == "ZK")
                {
                    if (txtBxDeviceName.Text == "" || txtBxDeviceIP.Text == "" || txtBxDevicePort.Text == "" ||
                         txtBxIpServer.Text == "")
                    {
                        MessageBox.Show(@"اطلاعات خواسته شده را وارد نمایید!!!", @"خطا", MessageBoxButtons.OK,
                            MessageBoxIcon.Error, MessageBoxDefaultButton.Button1,
                            MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                        return;
                    }
                }


                if (deviceBll.IpReserved(IPAddress.Parse(txtBxDeviceIP.Text)))
                {
                    MessageBox.Show(@"این IP Address قبلا استفاده شده است!", @"خطا", MessageBoxButtons.OK,
                        MessageBoxIcon.Error, MessageBoxDefaultButton.Button1,
                        MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                }

                else
                {
                    var serial = txtBxSerial.Text;
                    if ((serial.Length != 11 || serial.Substring(0, 3) != "ECO") && _deviceType == "Eco")
                    {
                        MessageBox.Show(@"شماره سریال  را کامل وارد کنید!", @"خطا", MessageBoxButtons.OK,
                            MessageBoxIcon.Error, MessageBoxDefaultButton.Button1,
                            MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                    }
                    else
                    {

                        if (_deviceType != "ZK")
                        {
                            if (deviceBll.ExistSerial(ConvertSerialToId(txtBxSerial.Text)))
                            {
                                MessageBox.Show(@"این شماره سریال تکراری می باشد!", @"خطا", MessageBoxButtons.OK,
                                    MessageBoxIcon.Error, MessageBoxDefaultButton.Button1,
                                    MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                                return;
                            }
                        }
                        device.DeviceName = txtBxDeviceName.Text;
                        device.IP = txtBxDeviceIP.Text;
                        device.Port = Convert.ToInt32(txtBxDevicePort.Text);
                        device.UDPPort = txtBxFtpPort.Text == String.Empty
                            ? (int?)null
                            : Convert.ToInt32(txtBxFtpPort.Text);
                        device.DeviceSerial = ConvertSerialToId(serial);
                        device.RegistrationCode = txtBxRegistrationCode.Text;
                        device.ActivationCode = txtBxActivation.Text;
                        device.ServerIP = txtBxIpServer.Text;
                        device.webUser = txtwebpass.Text;
                        device.webPass = txtwebuser.Text;
                        device.TypeId = cmbType.SelectedIndex + 1;


                        deviceBll.AddDevice(device);


                        //این باید بازبینی شود

                        //deviceEmpBll.InsertOneDeviceToAccess(employeeBll.SelectEmployeesAndGuest(), device);

                        Close();
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show(@"اطلاعات وارد شده فرمت مناسبی ندارد!", @"خطا", MessageBoxButtons.OK,
                    MessageBoxIcon.Error, MessageBoxDefaultButton.Button1,
                    MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                var deviceBll = new DeviceBLL();

                if (_deviceType == "Eco")
                {
                    if (txtBxDeviceName.Text == "" || txtBxDeviceIP.Text == "" || txtBxDevicePort.Text == "" ||
                        txtBxFtpPort.Text == "" || txtBxSerial.Text == "" ||
                        txtBxRegistrationCode.Text == "" || txtBxActivation.Text == "" || txtBxIpServer.Text == "" ||
                        txtwebuser.Text == "" || txtwebpass.Text == "")
                    {
                        MessageBox.Show(@"اطلاعات خواسته شده را وارد نمایید!!!", @"خطا", MessageBoxButtons.OK,
                            MessageBoxIcon.Error, MessageBoxDefaultButton.Button1,
                            MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                    }
                }
                if (_deviceType == "Controller")
                {
                    if (txtBxDeviceName.Text == "" || txtBxDeviceIP.Text == "" || txtBxDevicePort.Text == "" ||
                        txtBxFtpPort.Text == "" || txtBxSerial.Text == "" || txtBxIpServer.Text == "")
                    {
                        MessageBox.Show(@"اطلاعات خواسته شده را وارد نمایید!!!", @"خطا", MessageBoxButtons.OK,
                            MessageBoxIcon.Error, MessageBoxDefaultButton.Button1,
                            MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                    }
                }
                if (_deviceType == "ZK")
                {
                    if (txtBxDeviceName.Text == "" || txtBxDeviceIP.Text == "" || txtBxDevicePort.Text == "" ||
                        txtBxIpServer.Text == "")
                    {
                        MessageBox.Show(@"اطلاعات خواسته شده را وارد نمایید!!!", @"خطا", MessageBoxButtons.OK,
                            MessageBoxIcon.Error, MessageBoxDefaultButton.Button1,
                            MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                        return;
                    }
                }

                if (_devices.IP != txtBxDeviceIP.Text)
                {
                    if (deviceBll.IpReserved(IPAddress.Parse(txtBxDeviceIP.Text)))
                    {
                        MessageBox.Show(@"این IP Address قبلا استفاده شده است!", @"خطا", MessageBoxButtons.OK,
                            MessageBoxIcon.Error, MessageBoxDefaultButton.Button1,
                            MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                        return;
                    }
                }

                var serial = txtBxSerial.Text;

                if ((serial.Length != 11 || serial.Substring(0, 3) != "ECO") && _deviceType == "Eco")
                {
                    MessageBox.Show(@"شماره سریال  را کامل وارد کنید!", @"خطا", MessageBoxButtons.OK,
                        MessageBoxIcon.Error, MessageBoxDefaultButton.Button1,
                        MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                    return;
                }

                if (_deviceType != "ZK")
                {
                    if (ConvertIdToSerial(Convert.ToInt32(_devices.DeviceSerial)) != txtBxSerial.Text)
                    {
                        if (deviceBll.ExistSerial(ConvertSerialToId(txtBxSerial.Text)))
                        {
                            MessageBox.Show(@"این شماره سریال تکراری می باشد!", @"خطا", MessageBoxButtons.OK,
                                MessageBoxIcon.Error, MessageBoxDefaultButton.Button1,
                                MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                            return;
                        }
                    }
                }

                _devices.DeviceName = txtBxDeviceName.Text;
                _devices.IP = txtBxDeviceIP.Text;
                _devices.DeviceSerial = ConvertSerialToId(txtBxSerial.Text);
                _devices.Port = Convert.ToInt32(txtBxDevicePort.Text);
                _devices.UDPPort = txtBxFtpPort.Text == String.Empty
                    ? (int?)null
                    : Convert.ToInt32(txtBxFtpPort.Text);
                _devices.RegistrationCode = txtBxRegistrationCode.Text;
                _devices.ActivationCode = txtBxActivation.Text;
                _devices.ServerIP = txtBxIpServer.Text;
                _devices.webUser = txtwebuser.Text;
                _devices.webPass = txtwebpass.Text;
                _devices.TypeId = cmbType.SelectedIndex + 1;

//                    if (deviceBll.Ping(_devices.IP, _devices.Port))
//                    {
//                        MessageBox.Show(@"دستگاهی در شبکه با این Ip وجود دارد", @"خطا", MessageBoxButtons.OK,
//                                MessageBoxIcon.Error, MessageBoxDefaultButton.Button1,
//                                    MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
//                        return;
//                    }

                deviceBll.UpdateDevice(_devices);
                Close();
            }
            catch (Exception)
            {
                MessageBox.Show(@"اطلاعات وارد شده فرمت مناسبی ندارد!", @"خطا", MessageBoxButtons.OK,
                    MessageBoxIcon.Error, MessageBoxDefaultButton.Button1,
                    MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
            }
        }

        private void cmbType_SelectionChangeCommitted(object sender, EventArgs e)
        {
            var i = cmbType.SelectedIndex;
            switch (i)
            {
                case 0:
                    txtBxRegistrationCode.Enabled = false;
                    txtBxActivation.Enabled = false;
                    txtwebuser.Enabled = false;
                    txtwebpass.Enabled = false;
                    txtBxFtpPort.Enabled = true;
                    txtBxSerial.Enabled = false;
                    _deviceType = "PDP";
                    break;
                case 1:
                    txtBxRegistrationCode.Enabled = true;
                    txtBxActivation.Enabled = true;
                    txtwebuser.Enabled = true;
                    txtwebpass.Enabled = true;
                    txtBxFtpPort.Enabled = true;
                    txtBxSerial.Enabled = true;
                    _deviceType = "Eco";
                    break;
                case 2:
                    txtBxRegistrationCode.Enabled = false;
                    txtBxActivation.Enabled = false;
                    txtwebuser.Enabled = false;
                    txtwebpass.Enabled = false;
                    txtBxFtpPort.Enabled = true;
                    txtBxSerial.Enabled = true;
                    _deviceType = "Controller";
                    break;
                case 3:
                    txtBxRegistrationCode.Enabled = false;
                    txtBxActivation.Enabled = false;
                    txtwebuser.Enabled = false;
                    txtwebpass.Enabled = false;
                    txtBxFtpPort.Enabled = false;
                    txtBxSerial.Enabled = false;
                    _deviceType = "ZK";
                    break;
            }
        }
    }
}