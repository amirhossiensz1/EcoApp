using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using BLL;
using DevExpress.XtraEditors;
using Model;

namespace UI
{
    public partial class FrmSetting : Form
    {
        private readonly CheckEdit[] _chkeditCard = new CheckEdit[3];
        private readonly CheckEdit[] _chkeditFinger = new CheckEdit[3];
        private readonly CheckEdit[] _chkeditId = new CheckEdit[3];
        private readonly CheckEdit[] _chkeditPass = new CheckEdit[3];
        private readonly bool _edit;
        private Device _devices = new Device();

        public FrmSetting()
        {
            InitializeComponent();
            SettingTab.Enabled = false;
            btnSave.Enabled = false;
        }

        public FrmSetting(bool edit, Device device)
        {
            _devices = device;
            _edit = edit;
            InitializeComponent();
        }

        public FrmSetting(bool enabled)
        {
            InitializeComponent();
            SettingTab.Enabled = enabled;
            Text = @"ویرایش تنظیمات";
            cmbBoxSelectDvc.Visible = enabled;
            grpSelectCevice.Text = @"نام دستگاه ";
            lblSelectDvc.Text = _devices.DeviceName;
            lblSelectDvc.Enabled = enabled;
            SettingTab.Enabled = enabled;
            btnSave.Enabled = enabled;
        }

        public override sealed string Text
        {
            get { return base.Text; }
            set { base.Text = value; }
        }

        private void FrmSetting_Load(object sender, EventArgs e)
        {
            SetCheckEditsUi();
            LoadComboBoxs();

            if (_edit)
            {
                Text = @"ویرایش تنظیمات";
                cmbBoxSelectDvc.Visible = false;
                grpSelectCevice.Text = @"نام دستگاه ";
                lblSelectDvc.Text = _devices.DeviceName;
                LoadDataEdit();
            }
        }

        private void SetCheckEditsUi()
        {
            for (var i = 0; i < _chkeditFinger.Length; i++)
            {
                _chkeditFinger[i] = new CheckEdit
                {
                    Location = new Point(50, 80 + (60*i)),
                    Text = "",
                    Size = new Size(20, 10)
                };
                GrpPanelAuthentication.Controls.Add(_chkeditFinger[i]);

                _chkeditCard[i] = new CheckEdit
                {
                    Location = new Point(150, 80 + (60*i)),
                    Text = "",
                    Size = new Size(20, 10)
                };

                GrpPanelAuthentication.Controls.Add(_chkeditCard[i]);

                _chkeditId[i] = new CheckEdit
                {
                    Location = new Point(250, 80 + (60*i)),
                    Text = "",
                    Size = new Size(20, 10)
                };
                GrpPanelAuthentication.Controls.Add(_chkeditId[i]);

                _chkeditPass[i] = new CheckEdit
                {
                    Location = new Point(350, 80 + (60*i)),
                    Text = "",
                    Size = new Size(20, 10)
                };
                GrpPanelAuthentication.Controls.Add(_chkeditPass[i]);
            }
        }

        private void LoadComboBoxs()
        {
            var deviceBll = new DeviceBLL();
            var settingBll = new SettingBLL();
            var text = @"انتخاب کنید";

            var dt = ConvertToDataTable(deviceBll.SelectDevices());
            var row = dt.NewRow();
            row["DeviceName"] = text;
            dt.Rows.InsertAt(row, 0);
            cmbBoxSelectDvc.DataSource = dt;
            //cmbBoxSelectDvc.DataSource = deviceBll.SelectDevices();
            cmbBoxSelectDvc.DisplayMember = "DeviceName";
            cmbBoxSelectDvc.ValueMember = "ID";

            cmbBoxEcoDir.DataSource = settingBll.GetEchoDir();
            CmbBoxServerEnabled.DataSource = settingBll.GetServerEnable();
            cmbBoxLock.DataSource = settingBll.GetLockHomeScreen();
            cmbBoxVacationDuty.DataSource = settingBll.GetVacationDuty();
            cmbBoxDeviceMenu.DataSource = settingBll.GetDeviceInfo();
            cmbBoxAudio.DataSource = settingBll.GetAudio();
            cmbBoxRelay.DataSource = settingBll.GetRelay();
            cmbBoxDuration.DataSource = settingBll.GetRelayDriven();
            cmbBoxPrevent.DataSource = settingBll.GetPreventConsecutive();
        }

        private void LoadDataEdit()
        {
            try
            {
                var error = GetSettingFromDevice();

                if (error == 5)
                {
                    SettingTab.Enabled = false;
                    btnSave.Enabled = false;
                    lblOfline.Text = @"دریافت تنظیمات با مشکل مواجه شد !";
                }
                if (error == 6)
                {
                    SettingTab.Enabled = false;
                    btnSave.Enabled = false;
                    lblOfline.Text = @"کد فعال سازی با سریال سیستم هم خوانی ندارد !";
                }
                if (error == 2)
                {
                    SettingTab.Enabled = false;
                    btnSave.Enabled = false;
                    lblOfline.Text = @"کد فعال سازی وارد شده نا معتبر می باشد!";
                }
                if (error == 3)
                {
                    SettingTab.Enabled = false;
                    btnSave.Enabled = false;
                    lblOfline.Text = @"کد کاربری/رمز وب دستگاه با نرم افزار یکسان نیست!";
                }
                if (error == 4)
                {
                    SettingTab.Enabled = false;
                    btnSave.Enabled = false;
                    lblOfline.Text = @"زمان دستگاه با سرور یکسان نمی باشد" + Environment.NewLine +
                                     @"لطفا ابتدا زمان را یکسان سازی کنید!";
                }


                var setting = ReadSettingFile(_devices.IP);

                FillForm(setting);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }


        private void LoadDataEdit(Device device)
        {
            try
            {
                _devices = device;

                var error = GetSettingFromDevice();

                if (error == 5)
                {
                    SettingTab.Enabled = false;
                    btnSave.Enabled = false;
                    lblOfline.Text = @"دریافت تنظیمات با مشکل مواجه شد !";
                }
                if (error == 6)
                {
                    SettingTab.Enabled = false;
                    btnSave.Enabled = false;
                    lblOfline.Text = @"کد فعال سازی با سریال دستگاه هم خوانی ندارد !";
                }
                if (error == 2)
                {
                    SettingTab.Enabled = false;
                    btnSave.Enabled = false;
                    lblOfline.Text = @"کد فعال سازی وارد شده نا معتبر می باشد!";
                }
                if (error == 3)
                {
                    SettingTab.Enabled = false;
                    btnSave.Enabled = false;
                    lblOfline.Text = @"کد کاربری/رمز وب دستگاه با نرم افزار یکسان نیست!";
                }
                if (error == 4)
                {
                    SettingTab.Enabled = false;
                    btnSave.Enabled = false;
                    lblOfline.Text = @"زمان دستگاه با سرور یکسان نمی باشد" + Environment.NewLine +
                                     @"لطفا ابتدا زمان را یکسان سازی کنید!";
                }

                var setting = ReadSettingFile(_devices.IP);

                FillForm(setting);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        private void FillForm(Setting setting)
        {
            try
            {
                //Basic
                if (setting == null)
                    return;
                txtEcoName.Text = setting.EchoName;
                cmbBoxEcoDir.SelectedItem = setting.EchoDir;
                txtBoxSerial.Text = ConvertIdToSerial(Convert.ToInt32(_devices.DeviceSerial));
                DescriptionText.Text = setting.Description;

                // ReSharper disable once PossibleInvalidOperationException

                //NetWork
                chkBoxDHCP.Checked = (bool) setting.DHCP;
                txtBoxIP.Text = setting.IP;
                txtBoxSubnet.Text = setting.Subnet;
                txtBoxGetway.Text = setting.gateway;
                var temp = setting.ServerEnabled == true ? "Enable" : "Disable";
                CmbBoxServerEnabled.SelectedItem = temp;
                txtBoxServerIP.Text = setting.ServerIP;
                txtBoxServerPort.Text = setting.ServerPort;
                txtBoxTftpPort.Text = setting.UDPPort;


                //Audio&Screen
                if (setting.TimeOutMenu != null) trackTimeOutMenu.Value = setting.TimeOutMenu.Value;
                if (setting.NormalBrightness != null) trackNormalBrithnes.Value = setting.NormalBrightness.Value;
                if (setting.SleepBrightness != null) trackBrightnessSleep.Value = setting.SleepBrightness.Value;

                temp = setting.LockHomeScreen == true ? "Enable" : "Disable";
                cmbBoxLock.SelectedItem = temp;
                temp = setting.VacationDuty == true ? "Enable" : "Disable";
                cmbBoxVacationDuty.SelectedItem = temp;
                temp = setting.DeviceInfo == true ? "Enable" : "Disable";
                cmbBoxDeviceMenu.SelectedItem = temp;
                temp = setting.Audio == true ? "Enable" : "Disable";
                cmbBoxAudio.SelectedItem = temp;

                // Relay
                temp = setting.Relay == true ? "Enable" : "Disable";
                cmbBoxRelay.SelectedItem = temp;

                cmbBoxDuration.SelectedItem = setting.RelayDuration;
                if (setting.RelayDriven != null) trackRelayDriven.Value = setting.RelayDriven.Value;

                temp = setting.PreventConsecutive == true ? "Enable" : "Disable";
                cmbBoxPrevent.SelectedItem = temp;
                if (setting.ConsecutivePassessDelay != null)
                    trackConsecutiveDelay.Value = setting.ConsecutivePassessDelay.Value;

                //Authentication
                FillCheckEdit(setting.AuthenticationType);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        private void DeleteSettingdirectory()
        {
            // ReSharper disable once AssignNullToNotNullAttribute
            var settingPath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location),
                "Setting");
            if (Directory.Exists(settingPath))
            {
                var filePath = Directory.GetFiles(settingPath, "*.xml");
                foreach (var file in filePath)
                {
                    File.Delete(file);
                }
                Directory.Delete(settingPath);
            }
        }

        private string ConvertIdToSerial(int? id)
        {
            if (id == null)
            {
                return "";
            }
            var str = id.ToString();
            str = str.Substring(1);
            return "ECO940T" + str;
        }

        private int GetSettingFromDevice()
        {
            try
            {
                var deviceBll = new DeviceBLL();


                // ReSharper disable once AssignNullToNotNullAttribute
                var settingdirectory = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location),
                    "Setting");
                var temp = File.Create(settingdirectory + ".xml");
                temp.Close();

                var requestFileName = deviceBll.CreateRequestFileName(_devices, settingdirectory + ".xml",
                    "Settings\\setting.xml");

                var setting = deviceBll.GetFile(requestFileName, _devices.IP, _devices.UDPPort);

                if (setting == null)
                    return 5;

                if (setting[3] == 13)
                    return 2;

                if (setting[3] == 12)
                    return 6;

                if (setting[3] == 11)
                    return 3;

                if (setting[3] == 10)
                    return 4;


                var returndata = Encoding.ASCII.GetString(setting);

                if (!Directory.Exists(settingdirectory))
                {
                    Directory.CreateDirectory(settingdirectory);
                }
                File.WriteAllText(settingdirectory + "\\" + _devices.IP + ".xml", returndata, Encoding.BigEndianUnicode);

                return 1;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return 0;
            }
        }

        private Setting ReadSettingFile(string ipAddress)
        {
            try
            {
                var setting = new Setting();
                var element = string.Empty;
                // ReSharper disable once AssignNullToNotNullAttribute
                var settingdirectory = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location),
                    "Setting");
                if (Directory.Exists(settingdirectory))
                {
                    var settingPath = Directory.GetFiles(settingdirectory, ipAddress + ".xml");

                    if (settingPath[0] != null)
                    {
                        var reader = new XmlTextReader(settingPath[0]);
                        var contents = "";
                        while (reader.Read())
                        {
                            reader.MoveToContent();
                            if (reader.NodeType == XmlNodeType.Element)
                                // contents += "<" + reader.Name + ">\n";
                            {
                                element = reader.Name;
                            }
                            if (reader.NodeType == XmlNodeType.Text)
                            {
                                switch (element)
                                {
                                    case "DHCP":
                                        var temp = reader.Value == "Enable" ? true : false;
                                        setting.DHCP = temp;
                                        break;
                                    case "IP":
                                        setting.IP = reader.Value;
                                        break;
                                    case "Gateway":
                                        setting.gateway = reader.Value;
                                        break;
                                    case "Subnet":
                                        setting.Subnet = reader.Value;
                                        break;
                                    case "FTP_Port":
                                        setting.UDPPort = reader.Value;
                                        break;
                                    case "Server_Enabled":
                                        temp = reader.Value == "Enable" ? true : false;
                                        setting.ServerEnabled = temp;
                                        break;
                                    case "Server_IP":
                                        setting.ServerIP = reader.Value;
                                        break;
                                    case "Server_Port":
                                        setting.ServerPort = reader.Value;
                                        break;
                                    case "Authentication_Mode_Num":
                                        setting.AuthenticationType = reader.Value;
                                        break;
                                    case "LockHomeScreen":
                                        temp = reader.Value == "Enable" ? true : false;
                                        setting.LockHomeScreen = temp;
                                        break;
                                    case "Normal_Brightness":
                                        setting.NormalBrightness = Convert.ToInt32(reader.Value);
                                        break;
                                    case "Sleep_Brightness":
                                        setting.SleepBrightness = Convert.ToInt32(reader.Value);
                                        break;
                                    case "Menu_Time_Out":
                                        setting.TimeOutMenu = Convert.ToInt32(reader.Value);
                                        break;
                                    case "Duty_Vac_Menu":
                                        temp = reader.Value == "Enable" ? true : false;
                                        setting.VacationDuty = temp;
                                        break;
                                    case "DeviceInfoMenu":
                                        temp = reader.Value == "Enable" ? true : false;
                                        setting.DeviceInfo = temp;
                                        break;
                                    case "Relay1_Enabled":
                                        temp = reader.Value == "Enable" ? true : false;
                                        setting.Relay = temp;
                                        break;
                                    case "Relay1_Driven_By":
                                        setting.RelayDriven = Convert.ToInt32(reader.Value);
                                        break;
                                    case "Relay1_Duration":
                                        setting.RelayDuration = reader.Value;
                                        break;
                                    case "BUZZER":
                                        temp = reader.Value == "Enable" ? true : false;
                                        setting.Audio = temp;
                                        break;
                                    case "SamePersonCheck":
                                        temp = reader.Value == "Enable" ? true : false;
                                        setting.PreventConsecutive = temp;
                                        break;
                                    case "SamePersonTime":
                                        setting.ConsecutivePassessDelay = Convert.ToInt32(reader.Value);
                                        break;
                                    case "PDP_NAME":
                                        setting.EchoName = reader.Value;
                                        break;
                                    case "PDP_DIR":
                                        setting.EchoDir = reader.Value;
                                        break;
                                    case "PDP_Description":
                                        setting.Description = reader.Value;
                                        break;
                                    case "WebUser":
                                        setting.WebUser = reader.Value;
                                        break;
                                    case "WebPass":
                                        setting.WebPass = reader.Value;
                                        break;
                                    default:
                                        break;
                                }
                            }
                        }

                        reader.Close();
                        return setting;
                    }
                    return null;
                }
                return null;
            }
            catch (Exception)
            {
                return null;
            }
        }


        private void btnSave_Click(object sender, EventArgs e)
        {
            var settingBll = new SettingBLL();
            var setting = GetSettingsFromOpert();
            var deviceBll = new DeviceBLL();
            setting.WebUser = _devices.webUser;
            setting.WebPass = _devices.webPass;

            var device = _edit
                ? _devices
                : deviceBll.SelectOneDevices(Convert.ToInt32(cmbBoxSelectDvc.SelectedValue.ToString()));

            if (deviceBll.Ping(device.IP, device.Port) == false)
                MessageBox.Show(@"ارتباط دستگاه با نرم افزار قطع شده است!!!", @"پیام", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1,
                    MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
            else
            {
                // ReSharper disable once AssignNullToNotNullAttribute
                var settingdirectory = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location),
                    "setting");
                // ReSharper disable once AssignNullToNotNullAttribute
                var resetdirectory = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location),
                    "Reset");
                BuildResetFile();

                settingBll.BuildSetting(setting, device);

                var result = DialogResult.Cancel;

                var destination = "Settings\\setting.xml";
                var reset = "Reset.pdp";
                var requestResetFileName = deviceBll.CreateRequestFileName(device, resetdirectory + ".txt", reset);
                var requestFileName = deviceBll.CreateRequestFileName(device, settingdirectory + ".xml", destination);

                if (device.UDPPort != null &&
                    deviceBll.SendTftp(settingdirectory + ".xml", requestFileName, device.IP,
                        (int) device.UDPPort) == 0)
                {
                    deviceBll.SendTftp(resetdirectory + ".txt", requestResetFileName, device.IP,
                        (int) device.UDPPort);


                    if (settingBll.GetSetting(device.ID) == null)
                        settingBll.Insert(setting);
                    else
                    {
                        if (device.ID == settingBll.GetSetting(device.ID).DeviceID)
                        {
                            settingBll.Update(setting);
                            //  device.DeviceName = setting.EchoName;
                            device.IP = setting.IP;
                            device.Port = Convert.ToInt32(setting.ServerPort);
                            device.UDPPort = Convert.ToInt32(setting.UDPPort);
                            deviceBll.UpdateDevice(device);
                        }

                        else
                        {
                            settingBll.Insert(setting);
                        }
                    }
                    result = MessageBox.Show(@"فایل تنظیمات به دستگاه ارسال شد!!!", @"پیام", MessageBoxButtons.OK,
                        MessageBoxIcon.Information, MessageBoxDefaultButton.Button1,
                        MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                }
                else
                {
                    result = MessageBox.Show(@"فایل تنظیمات به دستگاه ارسال نشد!!!", @"پیام", MessageBoxButtons.OK,
                        MessageBoxIcon.Information, MessageBoxDefaultButton.Button1,
                        MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                }
                if (result == DialogResult.OK)
                {
                    if (Directory.Exists(settingdirectory))
                    {
                        File.Delete(settingdirectory + ".xml");
                    }
                    DeleteSettingdirectory();
                }
            }
        }

        private void BuildResetFile()
        {
            try
            {
                // ReSharper disable once AssignNullToNotNullAttribute
                var resetdirectory = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location),
                    "reset");
                File.WriteAllText(resetdirectory + ".txt", "1", Encoding.BigEndianUnicode);
            }
            catch (IOException ioe)
            {
                Console.WriteLine(ioe);
                throw;
            }
        }

        private Setting GetSettingsFromOpert()
        {
            try
            {
                var setting = new Setting();

                setting.DeviceID = _edit ? Convert.ToInt32(_devices.ID) : Convert.ToInt32(cmbBoxSelectDvc.SelectedValue);
                setting.EchoDir = cmbBoxEcoDir.SelectedValue.ToString();
                setting.EchoName = "ECO";
                setting.UDPPort = txtBoxTftpPort.Text;
                setting.Description = "Test";
                setting.DHCP = chkBoxDHCP.Checked ? true : false;
                setting.IP = txtBoxIP.Text;
                setting.Subnet = txtBoxSubnet.Text;
                setting.gateway = txtBoxGetway.Text;
                setting.ServerEnabled = CmbBoxServerEnabled.SelectedValue.ToString() == "Enable" ? true : false;
                setting.ServerIP = txtBoxServerIP.Text;
                setting.ServerPort = txtBoxServerPort.Text;
                setting.TimeOutMenu = trackTimeOutMenu.Value;
                setting.NormalBrightness = trackNormalBrithnes.Value;
                setting.SleepBrightness = trackBrightnessSleep.Value;
                setting.LockHomeScreen = cmbBoxLock.SelectedValue.ToString() == "Enable" ? true : false;
                setting.VacationDuty = cmbBoxVacationDuty.SelectedValue.ToString() == "Enable" ? true : false;
                setting.DeviceInfo = cmbBoxDeviceMenu.SelectedValue.ToString() == "Enable" ? true : false;
                setting.Audio = cmbBoxAudio.SelectedValue.ToString() == "Enable" ? true : false;
                setting.Relay = cmbBoxRelay.SelectedValue.ToString() == "Enable" ? true : false;
                setting.RelayDriven = trackRelayDriven.Value;
                if (cmbBoxDuration.SelectedValue != null)
                    setting.RelayDuration = cmbBoxDuration.SelectedValue.ToString();
                else
                {
                    setting.RelayDuration = "";
                }
                setting.PreventConsecutive = cmbBoxPrevent.SelectedValue.ToString() == "Enable" ? true : false;
                setting.ConsecutivePassessDelay = trackConsecutiveDelay.Value;
                setting.AuthenticationType = GetAuthenticationType();
                setting.WebUser = "";
                setting.WebPass = "";

                return setting;
            }
            catch (Exception e)
            {
                return null;
                throw;
            }
        }

        private string GetAuthenticationType()
        {
            var type1 = 0;
            var type2 = 0;
            var type3 = 0;
            var authenticationtype = "";

            for (var i = 0; i < _chkeditPass.Length; i++)
            {
                if (_chkeditPass[i].Checked)
                {
                    switch (i)
                    {
                        case 0:
                            type1 += 1;
                            break;
                        case 1:
                            type2 += 1;
                            break;
                        case 2:
                            type3 += 1;
                            break;
                    }
                }
            }
            for (var i = 0; i < _chkeditId.Length; i++)
            {
                if (_chkeditId[i].Checked)
                {
                    switch (i)
                    {
                        case 0:
                            type1 += 2;
                            break;
                        case 1:
                            type2 += 2;
                            break;
                        case 2:
                            type3 += 2;
                            break;
                    }
                }
            }
            for (var i = 0; i < _chkeditCard.Length; i++)
            {
                if (_chkeditCard[i].Checked)
                {
                    switch (i)
                    {
                        case 0:
                            type1 += 4;
                            break;
                        case 1:
                            type2 += 4;
                            break;
                        case 2:
                            type3 += 4;
                            break;
                    }
                }
            }
            for (var i = 0; i < _chkeditFinger.Length; i++)
            {
                if (_chkeditFinger[i].Checked)
                {
                    switch (i)
                    {
                        case 0:
                            type1 += 8;
                            break;
                        case 1:
                            type2 += 8;
                            break;
                        case 2:
                            type3 += 8;
                            break;
                    }
                }
            }

            authenticationtype =
                int.Parse((type3 != 0 ? type3.ToString("X") : "0") + type2.ToString("X") + type1.ToString("X"),
                    NumberStyles.HexNumber).ToString();

            return authenticationtype;
        }

        private void FillCheckEdit(string authenticationtype)
        {
            authenticationtype = Convert.ToInt32(authenticationtype).ToString("X");
            if (authenticationtype.Length == 1)
                authenticationtype = "00" + authenticationtype;

            var type1 = authenticationtype.Substring(2) == "" ? "0" : authenticationtype.Substring(2);
            var type2 = authenticationtype.Substring(1, 1) == "" ? "0" : authenticationtype.Substring(1, 1);
            var type3 = authenticationtype.Substring(0, 1) == "" ? "0" : authenticationtype.Substring(0, 1);

            SignCheckedit(0, Gettypes(int.Parse(type1, NumberStyles.HexNumber)));
            SignCheckedit(1, Gettypes(int.Parse(type2, NumberStyles.HexNumber)));
            SignCheckedit(2, Gettypes(int.Parse(type3, NumberStyles.HexNumber)));
        }

        private int[] Gettypes(int authenticationType)
        {
            var type = new int[4];

            if (authenticationType >= 8)
            {
                authenticationType -= 8;
                type[3] = 8;
            }
            if (authenticationType >= 4 && authenticationType < 8)
            {
                authenticationType -= 4;
                type[2] = 4;
            }

            if (authenticationType >= 2 && authenticationType < 4)
            {
                authenticationType -= 2;
                type[1] = 2;
            }

            if (authenticationType >= 1 && authenticationType < 2)
            {
                authenticationType -= 1;
                type[0] = 1;
            }

            return type;
        }

        private void SignCheckedit(int i, int[] type)
        {
            if (type[3] == 8)
                _chkeditFinger[i].Checked = true;
            if (type[2] == 4)
                _chkeditCard[i].Checked = true;
            if (type[1] == 2)
                _chkeditId[i].Checked = true;
            if (type[0] == 1)
                _chkeditPass[i].Checked = true;
        }

        private void EmptyForm()
        {
            txtEcoName.Text = string.Empty;
            DescriptionText.Text = string.Empty;
            txtBoxSerial.Text = string.Empty;
            txtBoxServerIP.Text = string.Empty;
            txtBoxServerPort.Text = string.Empty;
            txtBoxTftpPort.Text = string.Empty;
            txtBoxIP.Text = string.Empty;
            txtBoxSubnet.Text = string.Empty;
            txtBoxGetway.Text = string.Empty;
            chkBoxDHCP.Checked = false;
            trackBrightnessSleep.Value = 0;
            trackNormalBrithnes.Value = 0;
            trackTimeOutMenu.Value = 0;
            trackRelayDriven.Value = 0;
            trackConsecutiveDelay.Value = 0;
            EmptyCheckEdit();
            //LoadComboBox();
        }

        private void EmptyCheckEdit()
        {
            for (var i = 0; i < 3; i++)
            {
                _chkeditFinger[i].Checked = false;
                _chkeditCard[i].Checked = false;
                _chkeditId[i].Checked = false;
                _chkeditPass[i].Checked = false;
            }
        }

        private void cmbBoxSelectDvc_SelectionChangeCommitted(object sender, EventArgs e)
        {
            var deviceBll = new DeviceBLL();
            cmbBoxSelectDvc.DisplayMember = "DeviceName";
            cmbBoxSelectDvc.ValueMember = "ID";
            var device = deviceBll.SelectOneDevices(Convert.ToInt32(cmbBoxSelectDvc.SelectedValue.ToString()));

            if (device != null)
            {
                // if (deviceBll.Ping(device.IP, device.Port,device.ServerIP))
                if (deviceBll.Ping(device.IP, device.Port))
                {
                    EmptyForm();
                    SettingTab.Enabled = true;
                    btnSave.Enabled = true;
                    lblOfline.Text = string.Empty;
                    LoadDataEdit(device);
                }
                else
                {
                    SettingTab.Enabled = false;
                    btnSave.Enabled = false;
                    lblOfline.Text = @"امکان برقراری ارتباط با این دستگاه موجود نمی باشد";
                    EmptyForm();
                }
            }
        }

        private void FrmSetting_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                DeleteSettingdirectory();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }


        public DataTable ConvertToDataTable<T>(IList<T> data)
        {
            var properties =
                TypeDescriptor.GetProperties(typeof (T));
            var table = new DataTable();
            foreach (PropertyDescriptor prop in properties)
                table.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);
            foreach (var item in data)
            {
                var row = table.NewRow();
                foreach (PropertyDescriptor prop in properties)
                    row[prop.Name] = prop.GetValue(item) ?? DBNull.Value;
                table.Rows.Add(row);
            }
            return table;
        }

        private void cmbBoxSelectDvc_SelectedIndexChanged(object sender, EventArgs e)
        {
        }
    }
}