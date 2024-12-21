using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Globalization;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using BLL;
using DevExpress.XtraEditors;
using DevExpress.XtraTab;
using Eco.Properties;
using Model;
using Telerik.WinControls.UI;
using zkemkeeper;

namespace UI
{
    public partial class FrmAddEmployee : Form
    {
        private readonly CheckEdit[] _chkeditCard = new CheckEdit[3];
        private readonly CheckEdit[] _chkeditFinger = new CheckEdit[3];
        private readonly CheckEdit[] _chkeditId = new CheckEdit[3];
        private readonly CheckEdit[] _chkeditPass = new CheckEdit[3];
        private readonly DeviceBLL _deviceBll = new DeviceBLL();
        private readonly bool _edit;
        private readonly EmployeeBLL _employeeBll = new EmployeeBLL();
        private readonly Employee _employees = new Employee();
        private readonly OrganizationBll _organizationBll = new OrganizationBll();
        private bool _applyMode;
        private bool _checkDbSend = false;
        private bool _checkPicSend = false;
        private readonly DeviceEmpBll _deviceEmpBll = new DeviceEmpBll();
        private Thread[] _deviceThread;
        private readonly FingerBLL _fingerBll = new FingerBLL();
        private int[] _flag;
        private bool[] _sendFlag;
        private List<Employee> employees;
        private bool finishSync = false;
        private readonly List<EmployeeInDevice> onlineDevices = new List<EmployeeInDevice>();

        private CZKEMClass _czkem = new CZKEMClass();
        private bool bIsConnected = false;//the boolean value identifies whether the device is connected
        private int iMachineNumber = 1;//the serial number of the device.After connecting the device ,this value will be changed.

        public FrmAddEmployee()
        {
            InitializeComponent();
        }

        public FrmAddEmployee(bool edit, Employee employee)
        {
            InitializeComponent();
            _employees = employee;
            employees = new List<Employee> { _employees };
            _edit = edit;
        }

        private bool ConnectToDevice(string Ip, int? port)
        {
            int idwErrorCode = 0;

            bIsConnected = _czkem.Connect_Net(Ip, (int)port);
            if (bIsConnected)
                return true;
            return false;
        }

        public bool HardwareConnected { get; set; }

        public static string EncoderComPortName { get; set; }

        private void EmptyFrmAddEmployee()
        {
            txtFName.Text = string.Empty;
            txtLName.Text = string.Empty;
            txtNational.Text = string.Empty;
            txtPin.Text = string.Empty;
            txtRePin.Text = string.Empty;
            txtEmpId.Text = string.Empty;
            txtTel.Text = string.Empty;
            txtPost.Text = string.Empty;
            pictureEmployee.Image = Resources.avatar;
            EmptyCheckEdit();
            grpEcoder.Enabled = false;
            TabFinger.PageEnabled = false;
            //new Version
            TabInfoDevices.PageEnabled = false;

            _employees.Image = null;
            _employees.HasFinger = null;
            _employees.HasCard = null;

            cmbAcsGroup.SelectedValue = 0;

            LoadDataToTreeView();

            chkPrivateAccess.CheckState = CheckState.Unchecked;
        }

        private void SetTreeViewProp()
        {
            try
            {
                var allNodes = TreeOrganization.TreeViewElement.GetNodes().ToList();
                foreach (var node in allNodes)
                {
                    node.CheckType = CheckType.RadioButton;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void LoadDataToTreeView()
        {
            try
            {
                var dt = ConvertToDataTable(_organizationBll.SelectAll());
                TreeOrganization.DataSource = dt;
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
        }


        private DataTable ConvertToDataTable<T>(IList<T> data)
        {
            var properties =
                TypeDescriptor.GetProperties(typeof(T));
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

        private void EmptyCheckEdit()
        {
            for (var i = 0; i < 3; i++)
            {
                _chkeditFinger[i].Checked = false;
                _chkeditCard[i].Checked = false;
                _chkeditId[i].Checked = false;
                _chkeditPass[i].Checked = false;
            }
            chkNetworkMenu.Checked = false;
            chkOperatorMenu.Checked = false;
            chkDeviceMenu.Checked = false;
        }

        private void FrmAddEmployee_Load(object sender, EventArgs e)
        {
            var cardBll = new CardBLL();

            SetBtnFinger();
            LoadDataToTreeView();
            FillAcsGroup();
            TreeOrganization.ExpandAll();
            SetCheckEdits();
            progressPanel.Visible = false;
            grpAuthType.Visible = true;
            grpAuthTypeForZk.Visible = false;
            grpAuthTypeForZk.Location = new Point(378, 461);
            cmbAcsGroup.Enabled = false;
            FillAuthenticationComboBox();
            

            if (_edit)
            {
                btnEdit.Visible = true;
                btnSaveEmp.Visible = false;
                btnApply.Visible = false;
                BtnSend.Visible = false;
                grpEcoder.Enabled = true;
                TabFinger.PageEnabled = true;
                if (_employees.AuthenticationMode == "0")
                    chkAuth.Checked = true;
                if(Convert.ToInt32(_employees.AuthenticationMode)>127 && Convert.ToInt32(_employees.AuthenticationMode) < 149)
                {
                    chkAuth.Checked = false;
                    VerfiCombo.SelectedIndex = Convert.ToInt32(_employees.AuthenticationMode) - 128;
                }


                //new Version
                TabInfoDevices.PageEnabled = false;
                //LoadDeviceEmployeeData();

                btnCancelEmp.Location = new Point(506, 483);
                //  ShowFingerPrint();
                if (cardBll.SelectOneCard(_employees.ID))
                {
                    picExistCard.Visible = true;
                    btnDeleteCard.Visible = true;
                }

                if (_employees.IsAdmin != null && (bool) _employees.IsAdmin)
                    rdbAdmin.Checked= true;
                else
                {
                    rdbUser.Checked= true;
                }

            }

            if (_edit == false)
            {
                btnSaveEmp.Visible = true;
                btnEdit.Visible = false;
                BtnSend.Visible = false;
                grpEcoder.Enabled = false;
                TabFinger.PageEnabled = false;

                btnDeleteCard.Visible = true;
                //new Version
                TabInfoDevices.PageEnabled = false;
            }

            FillComponent();
            FillcmbEncoder();

        }

        private void FillAuthenticationComboBox()
        {
            try
            {
                VerfiCombo.DataSource = Enum.GetValues(typeof(VerificationEnum));
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        private void FillAcsGroup()
        {
            try
            {
                var acsGroupBll = new AccessGroupBll();
                var acsGroups = acsGroupBll.SelectAll();

                var dtAcsGroup = ConvertToDataTable(acsGroups);

                var accessGroup = new AccessGroup
                {
                    ID = 0,
                    Name = "انتخاب کنید"
                };
                var row = dtAcsGroup.NewRow();
                row["ID"] = accessGroup.ID;
                row["Name"] = accessGroup.Name;
                dtAcsGroup.Rows.InsertAt(row, 0);

                cmbAcsGroup.DataSource = dtAcsGroup;
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void FillcmbEncoder()
        {
            try
            {
                var deviceBll = new DeviceBLL();
                var dt = ConvertToDataTable(deviceBll.SelectDevices());
                var device = new Device
                {
                    ID = 0,
                    DeviceName = "انکدر مایفر",
                    DeviceType = new DeviceType()
                };
                var device0 = new Device
                {
                    ID = -1,
                    DeviceName = "انتخاب کنید"
                };


                var row1 = dt.NewRow();
                row1["ID"] = device0.ID;
                row1["DeviceName"] = device0.DeviceName;
                dt.Rows.InsertAt(row1, 0);

                var row = dt.NewRow();
                row["ID"] = device.ID;
                row["DeviceName"] = device.DeviceName;
                dt.Rows.InsertAt(row, 1);


                cmbbxSelectEncoder.DataSource = dt;
                cmbbxSelectEncoder.DisplayMember = "DeviceName";
                cmbbxSelectEncoder.ValueMember = "ID";
            }
            catch (Exception ex)
            {
                throw;
            }
        }


        private void LoadDeviceEmployeeData()
        {
            try
            {
                var deviceEmp = new DeviceEmpBll();
                gridDeviceInfo.DataSource = deviceEmp.EmployeeInDevices(_employees.ID).ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void ShowFingerPrint()
        {
            var fingerBll = new FingerBLL();
            var finger = fingerBll.SelectFingersEmployee(_employees.ID);
            foreach (var fngr in finger)
            {
                if (fngr.FingerNum != null) Setfingerprint((int)fngr.FingerNum);
            }
        }

        private void SetBtnFinger()
        {
            var btnfinger = new Button[10];


            SetBtnFingerproperties(btnfinger[0], 0, 188, 69);
            SetBtnFingerproperties(btnfinger[1], 1, 149, 31);
            SetBtnFingerproperties(btnfinger[2], 2, 96, 2);
            SetBtnFingerproperties(btnfinger[3], 3, 43, 31);
            SetBtnFingerproperties(btnfinger[4], 4, 4, 69);

            SetBtnFingerproperties(btnfinger[5], 5, 185, 69);
            SetBtnFingerproperties(btnfinger[6], 6, 146, 31);
            SetBtnFingerproperties(btnfinger[7], 7, 93, 2);
            SetBtnFingerproperties(btnfinger[8], 8, 40, 31);
            SetBtnFingerproperties(btnfinger[9], 9, 1, 69);
        }

        private void SetBtnFingerproperties(Button btnfinger, int index, int x, int y)
        {
            btnfinger = new Button
            {
                Size = new Size(29, 28),
                Location = new Point(x, y),
                BackColor = Color.Transparent,
                FlatStyle = FlatStyle.Flat,
                TabIndex = index
            };

            btnfinger.Click += btnfinger_click;

            btnfinger.FlatAppearance.BorderSize = 0;

            var imagesDirectory =
                // ReSharper disable once AssignNullToNotNullAttribute
                Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "Images");

            btnfinger.Image = Image.FromFile(imagesDirectory + "\\Untitled-5.png");
            if (index > 4)
                LeftHand.Controls.Add(btnfinger);
            else
            {
                RightHand.Controls.Add(btnfinger);
            }
        }

        private void FillComponent()
        {
            var size = new Size(120, 140);
            var device = new DeviceBLL();
            txtFName.Text = _employees.EmpFname;
            txtLName.Text = _employees.EmpLname;
            txtNational.Text = _employees.EmpNationalCode;
            txtPin.Text = _employees.EmpPinCode;
            txtRePin.Text = _employees.EmpPinCode;
            txtEmpId.Text = _employees.PersonalNum;
            txtTel.Text = _employees.TelePhone;
            txtPost.Text = _employees.Post;
            FillCheckEdit(_employees.AuthenticationMode);
            FillAccessMenu(_employees.MenuAccess);

            if (_employees.PrivateAccess != null)
                chkPrivateAccess.CheckState = _employees.PrivateAccess == true
                    ? CheckState.Checked
                    : CheckState.Unchecked;
            else
            {
                chkPrivateAccess.CheckState = CheckState.Unchecked;
                cmbAcsGroup.Enabled = false;
            }
            if (_employees.PrivateAccess == true)
            {
                cmbAcsGroup.Enabled = true;
            }


            var node = FindNodeByValue(_employees.OrganizationID, TreeOrganization.Nodes);
            if (node != null) node.Checked = true;

            if (_employees.AcsGroupID != null) cmbAcsGroup.SelectedValue = _employees.AcsGroupID;

            if (_employees.Image != null)
            {
                var image = ResizeImage(ByteArrayToImage(_employees.Image), size, true);
                pictureEmployee.Image = image;
            }
        }

        private void FillAccessMenu(string menuAccess)
        {
            var result = GetAccessMenuResult(Convert.ToInt32(menuAccess));

            if (result[0] == 1)
                chkNetworkMenu.Checked = true;
            if (result[1] == 1)
                chkOperatorMenu.Checked = true;
            if (result[2] == 1)
                chkDeviceMenu.Checked = true;
        }

        private int[] GetAccessMenuResult(int MenuAccess)
        {
            int[] result = { 0, 0, 0 };
            for (var i = 0; i < 3; i++)
            {
                if (MenuAccess == 1)
                {
                    result[i] = 1;
                    break;
                }
                result[i] = MenuAccess % 2;
                MenuAccess = MenuAccess / 2;
            }
            return result;
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

        private void SetCheckEdits()
        {
            for (var i = 0; i < _chkeditFinger.Length; i++)
            {
                _chkeditFinger[i] = new CheckEdit
                {
                    Location = new Point(40, 60 + (30 * i)),
                    Text = "",
                    Size = new Size(20, 10)
                };
                grpAuthType.Controls.Add(_chkeditFinger[i]);

                _chkeditCard[i] = new CheckEdit
                {
                    Location = new Point(110, 60 + (30 * i)),
                    Text = "",
                    Size = new Size(20, 10)
                };
                grpAuthType.Controls.Add(_chkeditCard[i]);

                _chkeditId[i] = new CheckEdit
                {
                    Location = new Point(180, 60 + (30 * i)),
                    Text = "",
                    Size = new Size(20, 10)
                };
                grpAuthType.Controls.Add(_chkeditId[i]);

                _chkeditPass[i] = new CheckEdit
                {
                    Location = new Point(250, 60 + (30 * i)),
                    Text = "",
                    Size = new Size(20, 10)
                };
                grpAuthType.Controls.Add(_chkeditPass[i]);
            }
        }

        private static Image ResizeImage(Image image, Size size, bool preserveAspectRatio = true)
        {
            int newWidth;
            int newHeight;

            if (preserveAspectRatio)
            {
                var originalWidth = image.Width;
                var originalHeight = image.Height;
                var percentWidth = size.Width / (float)originalWidth;
                var percentHeight = size.Height / (float)originalHeight;
                var percent = percentHeight < percentWidth ? percentHeight : percentWidth;
                newWidth = (int)(originalWidth * percent);
                newHeight = (int)(originalHeight * percent);
            }
            else
            {
                newWidth = size.Width;
                newHeight = size.Height;
            }
            Image newImage = new Bitmap(newWidth, newHeight);
            using (var graphicsHandle = Graphics.FromImage(newImage))
            {
                graphicsHandle.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphicsHandle.DrawImage(image, 0, 0, newWidth, newHeight);
            }
            return newImage;
        }

        private Image ByteArrayToImage(byte[] byteArrayIn)
        {
            var ms = new MemoryStream(byteArrayIn);
            var returnImage = Image.FromStream(ms);
            return returnImage;
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

        private void txtNational_TextChanged(object sender, EventArgs e)
        {
            if (txtNational.TextLength >= 11)
            {
                lblNationalErr.Text = @"کدملی بیشتر از ده رقم وارد کردید";
                lblNationalErr.ForeColor = Color.Red;
            }
            else
            {
                lblNationalErr.Text = "";
            }
        }

        private void txtPin_TextChanged(object sender, EventArgs e)
        {
            if (txtPin.TextLength >= 11)
            {
                //       lblPinErr.Text = @"کلمه عبور حداکثر 10 کاراکتر می تواند داشته باشد";
                //        lblPinErr.ForeColor = Color.Red;
            }
        }

        private void txtEmpId_TextChanged(object sender, EventArgs e)
        {
            if (txtEmpId.TextLength >= 11)
            {
                lblEmpIdErr.Text = @"شماره کارمندی حداکثر 10 کاراکتر می تواند داشته باشد";
                lblEmpIdErr.ForeColor = Color.Red;
            }
            else
            {
                lblEmpIdErr.Text = "";
            }
        }

        private void btnfinger_click(object sender, EventArgs e)
        {
            try
            {
                var employeeBll = new EmployeeBLL();
                var fingerBll = new FingerBLL();
                var deviceBll = new DeviceBLL();
                var btn = (Button)sender;


                var fingerNum = btn.TabIndex;
                //this should be change
                var id = (int)cmbbxSelectEncoder.SelectedValue;

                var device = deviceBll.SelectOneDevices(id);
                if (device == null)
                {
                    MessageBox.Show(@"یک دستگاه از منوی بالا انتخاب کنید", @"پیام", MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    return;
                }

                var fingerEmpId = employeeBll.SelectOneEmployees(_employees.ID).ID;


                var enrollOk = -1;

                if (device.DeviceType.Type == "ZK")
                {
                    Thread enrolfinger =
                        new Thread(() =>
                        {
                            enrollOk = fingerBll.GetFingerTmpFromZK(device, _employees.PersonalNum,
                                fingerNum);
                        });

                        
                    enrolfinger.Start();


                }
                if (device.DeviceType.Type == "ECO")
                {
                    var enrolfinger =
                        new Thread(() => { enrollOk = fingerBll.EnrollFinger(device, fingerEmpId, fingerNum); });
                    enrolfinger.Start();
                }

                EnabledFrom(false);
                waiting.Visible = true;
                while (enrollOk == -1)
                {
                    Application.DoEvents();
                }
                //  var enrollOk = fingerBll.EnrollFinger(device, fingerEmpId, fingerNum);
                //   waiting.Visible = false;
                EnabledFrom(true);
                waiting.Visible = false;
                //  ALlow main UI thread to properly display please wait form.


                switch (enrollOk)
                {
                    case -1:
                        MessageBox.Show(@" عملیات گرفتن اثر انگشت با مشکل مواجه شد.", @"پیام",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning);
                        break;
                    case 0:
                        employeeBll.SetHasFinger(_employees.ID);
                        _employees.HasFinger = true;
                        btnApply.Enabled = false;
                        Setfingerprint(fingerNum);
                        break;
                    case 1:
                        MessageBox.Show(@"لطفا انگشت  خود را به موقع در محل تعبیه شده قرار دهید", @"پیام",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning);
                        break;

                    case 2:
                        MessageBox.Show(@"این دستگاه انکدر در شبکه موجود نمی باشد", @"پیام", MessageBoxButtons.OK,
                            MessageBoxIcon.Warning);
                        break;
                    case 3:
                        MessageBox.Show(@"انگشت خود را  دقیقا در محل تعبیه شده قرار دهید", @"پیام", MessageBoxButtons.OK,
                            MessageBoxIcon.Warning);
                        break;

                    case 4:
                        MessageBox.Show(@" تا پایان زمان اسکن انگشت خود را بر روی محل نگه دارید ", @"پیام",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning);
                        break;

                    case 5:
                        MessageBox.Show(@" عملیات را به یک زمان دیگر موکول کنید ", @"پیام",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning);
                        break;
                    case 6:
                        MessageBox.Show(@"عملیات توسط کاربر لغو شد ", @"پیام",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning);
                        break;
                    case 7:
                        MessageBox.Show(@"مجددا تلاش کنید ", @"پیام",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning);
                        break;
                    case 8:
                        MessageBox.Show(@"اطلاعات  این اثر انگشت شما در دستگاه وجود ندارد ", @"پیام",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning);
                        break;
                }
            }
            catch (Exception)
            {
                MessageBox.Show(@" عملیات با مشکل مواجه شد.", @"پیام",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
        }

        private void EnabledFrom(bool p)
        {
            LeftHand.Enabled = p;
            RightHand.Enabled = p;
            grpEcoder.Enabled = p;
            cmbbxSelectEncoder.Enabled = p;
            TabBasicInfo.Enabled = p;
            btnApply.Enabled = p;
            btnEdit.Enabled = p;
            TabInfoDevices.Enabled = p;
            BtnSend.Enabled = p;
            GrpctrInfoDevices.Enabled = p;
            gridDeviceInfo.Enabled = p;
        }

        private void Setfingerprint(int fingerNum)
        {
            // PictureBox fingerPrint = new PictureBox();
            var fingerPrint = new Button[10];
            switch (fingerNum)
            {
                case 0:
                    SetBtnFingerPrintproperties(fingerPrint[0], 0, 188, 69);
                    break;
                case 1:
                    SetBtnFingerPrintproperties(fingerPrint[1], 1, 149, 31);
                    break;
                case 2:
                    SetBtnFingerPrintproperties(fingerPrint[2], 2, 96, 2);
                    break;
                case 3:
                    SetBtnFingerPrintproperties(fingerPrint[3], 3, 43, 31);
                    break;
                case 4:
                    SetBtnFingerPrintproperties(fingerPrint[4], 4, 4, 69);
                    break;

                case 5:
                    SetBtnFingerPrintproperties(fingerPrint[5], 5, 185, 69);
                    break;

                case 6:
                    SetBtnFingerPrintproperties(fingerPrint[6], 6, 146, 31);
                    break;
                case 7:
                    SetBtnFingerPrintproperties(fingerPrint[7], 7, 93, 2);
                    break;

                case 8:
                    SetBtnFingerPrintproperties(fingerPrint[8], 8, 40, 31);
                    break;

                case 9:
                    SetBtnFingerPrintproperties(fingerPrint[9], 9, 1, 69);
                    break;
            }
        }

        private void SetBtnFingerPrintproperties(Button fingerPrint, int fingerNum, int x, int y)
        {
            try
            {
                fingerPrint = new Button();
                var imagesDirectory =
                    // ReSharper disable once AssignNullToNotNullAttribute
                    Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "Images");
                fingerPrint.FlatAppearance.BorderSize = 0;
                fingerPrint.FlatStyle = FlatStyle.Flat;
                fingerPrint.BackColor = Color.Transparent;
                fingerPrint.Click += fingerPrint_click;
                //                fingerPrint.MouseUp += new MouseEventHandler(fingerPrint_MouseUP);
                //                fingerPrint.MouseDown += new MouseEventHandler(fingerPrint_MouseDown); 
                fingerPrint.TabIndex = fingerNum;
                fingerPrint.Size = new Size(29, 28);
                fingerPrint.Location = new Point(x, y);
                fingerPrint.Image = Image.FromFile(imagesDirectory + "\\Untitled-6.png");
                fingerPrint.Visible = true;

                if (fingerNum < 5)
                    RightHand.Controls.Add(fingerPrint);
                else
                {
                    LeftHand.Controls.Add(fingerPrint);
                }
                fingerPrint.BringToFront();
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void fingerPrint_MouseDown(object sender, MouseEventArgs e)
        {
            try
            {
                var fingerBll = new FingerBLL();
                var deviceEmpBll = new DeviceEmpBll();
                var employeeBll = new EmployeeBLL();


                var flag = false;
                var fingerPrint = (Button)sender;
                var fingerNum = fingerPrint.TabIndex;


                var text = @"اگر میخواهید به طورکلی پا ک شود گزینه بله کلیک کنید " + "\r\n" +
                           "اگر میخواهید فقط از دستگاه پاک شود گزینه خیر  کلیک کنید";
                var result = MessageBox.Show(text, @"پیام", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
                //FrmMessageBox frmMessageBox = new FrmMessageBox(@"پیام", @"آیا می خواهید از پایگاه داده پاک کنید یا دستگاهها؟", "از پایگاه داده", "از دستگاهها", "لغو");
                //                frmMessageBox.ShowDialog();
                //                flag = frmMessageBox.Result1;
                if (result == DialogResult.Yes)
                {
                    Application.DoEvents();
                    fingerPrint.Visible = false;
                    fingerPrint.SendToBack();

                    var message = DeleteFingerFromDevice(_employees.ID, fingerNum);

                    fingerBll.DeleteOneFingerEmployee(_employees.ID, fingerNum);

                    if (fingerBll.SelectOneFinger(_employees.ID) == false)
                    {
                        employeeBll.SetFalseFinger(_employees);
                        deviceEmpBll.DeleteFingerfromDeviceEmp(_employees.ID);
                    }

                    MessageBox.Show(message, @"لیست دستگاههایی که اثر انگشت پاک نشده است", MessageBoxButtons.OK,
                        MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading);
                }
                if (result == DialogResult.No)
                {
                    var frmDeleteFingerDevice = new FrmDeleteFingerDevice(_employees, fingerNum);
                    frmDeleteFingerDevice.ShowDialog();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void fingerPrint_MouseUP(object sender, MouseEventArgs e)
        {
            try
            {
                var flag = false;
                var fingerPrint = (Button)sender;
                var fingerNum = fingerPrint.TabIndex;
                fingerPrint.Visible = false;
                fingerPrint.SendToBack();
            }
            catch (Exception)
            {
                throw;
            }
            //            try
        }


        private void fingerPrint_click(object sender, EventArgs e)
        {
            try
            {
                var fingerBll = new FingerBLL();
                var deviceEmpBll = new DeviceEmpBll();
                var employeeBll = new EmployeeBLL();

                var fingerPrint = (Button)sender;
                var fingerNum = fingerPrint.TabIndex;


                var text = @"اگر میخواهید به طورکلی پا ک شود گزینه بله کلیک کنید " + "\r\n" +
                           "اگر میخواهید فقط از دستگاه پاک شود گزینه خیر  کلیک کنید";
                var result = MessageBox.Show(text, @"پیام", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
                //  FrmMessageBox frmMessageBox = new FrmMessageBox(@"پیام", @"آیا می خواهید از دیتابیس پاک کنید یا دستگاه؟","از پایگاه داده","از دستگاهها","لغو");
                if (result == DialogResult.Yes)
                {
                    fingerPrint.Visible = false;
                    fingerPrint.SendToBack();

                    var message = DeleteFingerFromDevice(_employees.ID, fingerNum);

                    fingerBll.DeleteOneFingerEmployee(_employees.ID, fingerNum);

                    if (fingerBll.SelectOneFinger(_employees.ID) == false)
                    {
                        employeeBll.SetFalseFinger(_employees);
                        deviceEmpBll.DeleteFingerfromDeviceEmp(_employees.ID);
                    }

                    MessageBox.Show(message, @"لیست دستگاههایی که اثر انگشت پاک نشده است", MessageBoxButtons.OK,
                        MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading);
                }
                if (result == DialogResult.No)
                {
                    var frmDeleteFingerDevice = new FrmDeleteFingerDevice(_employees, fingerNum);
                    frmDeleteFingerDevice.ShowDialog();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        private string DeleteFingerFromDevice(int empId, int fingerNum)
        {
            try
            {
                //                // ReSharper disable once AssignNullToNotNullAttribute
                //                string syncPath= Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location),
                //                    "Sync");
                var fingerBll = new FingerBLL();
                var deviceBll = new DeviceBLL();

                var flag = -1;
                var devices = deviceBll.SelectDevices();
                var deviceThread = new Thread[devices.Count];
                fingerBll.GenerateSyncFile((-1 * empId), fingerNum);

                _flag = new int[devices.Count];
                for (var i = 0; i < _flag.Length; i++)
                {
                    _flag[i] = -1;
                }

                for (var i = 0; i < devices.Count; i++)
                {
                    var index = i;
                    deviceThread[index] = new Thread(() => SendThread(devices[index], _employees, index, fingerNum));
                    deviceThread[index].Start();
                }
                var Message = "";

                while (true)
                {
                    if (checkThreadLive(0))
                    {
                        for (var i = 0; i < _flag.Length; i++)
                        {
                            if (_flag[i] == 0)
                                continue;
                            if (_flag[i] == 6)
                            {
                                Message = Message + devices[i].DeviceName + " : " + "Can't create request file.\r\n";
                                continue;
                            }

                            if (_flag[i] == 5)
                            {
                                Message = Message + devices[i].DeviceName + " : " + "No ping.\r\n";
                                continue;
                            }
                            if (_flag[i] == 7)
                            {
                                Message = Message + devices[i].DeviceName + " : " + "دستگاه مورد نظر از اثر انگشت پشتیبانی نمی کند" + "\r\n";

                                continue;
                            }
                            if (_flag[i] == 8)
                            {
                                Message = Message + devices[i].DeviceName + " : " + "ارسال اطلاعات با مشکل مواجه شد" + "\r\n";
                                continue;
                            }
                            if (_flag[i] == 9)
                            {
                                Message = Message + devices[i].DeviceName + " : " + "ارتباط با دستگاه برقرار نشد" + "\r\n";
                                continue;
                            }


                            Message = Message + devices[i].DeviceName + " : " + CheckError(_flag[i]) + "\r\n";
                        }
                        break;
                    }
                }
                return Message;
            }

            catch (Exception exception)
            {
                return "";
                Console.WriteLine(exception);
            }
        }

        private string CheckError(int p)
        {
            switch (p)
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

        private bool checkThreadLive(int i)
        {
            try
            {
                if (_flag[i] != -1)
                {
                    if (_flag.Length - 1 == i)
                        return true;
                    i++;
                    return checkThreadLive(i);
                }
                return false;
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
                throw;
            }
        }


        private int SendThread(Device device, Employee employee, int index, int fingerindex)
        {
            try
            {
                var deviceBll = new DeviceBLL();
                var deviceType = deviceBll.SelectOneDevices(device.ID).DeviceType.Type;
                if (deviceType == "ECO")
                {
                    // ReSharper disable once AssignNullToNotNullAttribute
                    var syncPath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location),
                        "Sync");

                    var syncdestination = "Sync2.fpt";
                    var requestFileName = deviceBll.CreateRequestFileName(device, syncPath + "\\Sync.txt", syncdestination);

                    if (requestFileName == null)
                    {
                        _flag[index] = 6;
                        return 6;
                    }
                    if (deviceBll.Ping(device.IP, device.Port))
                    {
                        if (device.UDPPort != null)
                        {
                            _flag[index] = deviceBll.SendTftp(syncPath + "\\Sync.txt", requestFileName, device.IP,
                                (int)device.UDPPort);
                        }
                    }
                    else
                    {
                        _flag[index] = 5;
                        return 5;
                    }

                    return _flag[index];
                }

                if (deviceType == "ZK")
                {
                    if (deviceBll.Ping(device.IP, device.Port))
                    {
                        CZKEMClass c = new CZKEMClass();
                        if (c.Connect_Net(device.IP, (int)device.Port))
                        {
                            if (c.SSR_DelUserTmp(iMachineNumber, employee.PersonalNum, fingerindex + (9 - (2 * fingerindex))))
                            {
                                _flag[index] = 0;

                            }
                            else
                            {
                                _flag[index] = 8;
                            }
                            c.Disconnect();
                        }
                        else
                        {
                            _flag[index] = 9;
                        }
                    }
                    else
                    {
                        _flag[index] = 5;
                    }
                    return _flag[index];

                }

                _flag[index] = 7;
                return _flag[index];
            }
            catch (Exception ex)
            {

                Console.Write(ex.Message);
                return 8;
            }
        }

        private void btnCancelEmp_Click(object sender, EventArgs e)
        {
            Close();

        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            var employeeBll = new EmployeeBLL();
            var deviceEmpBll = new DeviceEmpBll();
            var deviceBll = new DeviceBLL();

            if (txtFName.Text == "" || txtLName.Text == "" || txtNational.Text == "" || txtPin.Text == "" ||
                txtEmpId.Text == "")
            {
                MessageBox.Show(@"اطلاعات ضروری خواسته شده را وارد نمایید!!!", @"خطا", MessageBoxButtons.OK,
                    MessageBoxIcon.Error, MessageBoxDefaultButton.Button1,
                    MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
            }
            else
            {
                if (txtNational.TextLength <= 11 && txtPin.TextLength <= 11 && txtEmpId.TextLength <= 11)
                {
                    if (txtPin.Text != txtRePin.Text || (txtPin.Text == "" && txtRePin.Text == ""))
                        MessageBox.Show(@"کلمه عبور ها با  هم مغایرت دارد!!!", @"خطا", MessageBoxButtons.OK,
                            MessageBoxIcon.Error, MessageBoxDefaultButton.Button1,
                            MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                    else
                    {
                        if (_employeeBll.ExistPersonalNum(txtEmpId.Text))
                        {
                            MessageBox.Show(@"این شماره کارمندی  در دیتا بیس وجود دارد!!!", @"خطا", MessageBoxButtons.OK,
                                MessageBoxIcon.Error, MessageBoxDefaultButton.Button1,
                                MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                        }
                        else
                        {
                            _employees.EmpFname = txtFName.Text;
                            _employees.EmpLname = txtLName.Text;
                            _employees.EmpNationalCode = txtNational.Text;
                            _employees.EmpPinCode = txtPin.Text;
                            _employees.PersonalNum = txtEmpId.Text;
                            _employees.TelePhone = txtTel.Text;
                            _employees.Post = txtPost.Text;

                            if (rdbtnEco.Checked)
                                _employees.AuthenticationMode = GetAuthenticationType();
                            if (rdbtnZk.Checked & !chkAuth.Checked)
                                _employees.AuthenticationMode = ((int)VerfiCombo.SelectedValue + 128).ToString();
                            if (rdbtnZk.Checked & chkAuth.Checked)
                                _employees.AuthenticationMode = (0).ToString();

                            _employees.MenuAccess = GetAccessMenu();
                            _employees.PrivateAccess = chkPrivateAccess.Checked;
                            if (rdbUser.Checked)
                                _employees.IsAdmin = false;
                            if (rdbAdmin.Checked)
                                _employees.IsAdmin = true;



                            if (chkPrivateAccess.Checked && (int)cmbAcsGroup.SelectedValue == 0)
                            {
                                MessageBox.Show(@"برا ی این شخص گروه دسترسی تخصصی انتخاب کنید", @"",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Information, MessageBoxDefaultButton.Button1,
                                    MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                                return;
                            }


                            if (TreeOrganization.CheckedNodes.Count > 0)
                            {
                                _employees.OrganizationID =
                                    (int?)TreeOrganization.TreeViewElement.CheckedNodes[0].Value;
                            }
                            else
                            {
                                _employees.OrganizationID = null;
                            }


                            if ((int)cmbAcsGroup.SelectedValue != 0 &&
                                chkPrivateAccess.CheckState == CheckState.Checked)
                                _employees.AcsGroupID = (int)cmbAcsGroup.SelectedValue;
                            else
                            {
                                _employees.AcsGroupID = null;
                            }

                            employeeBll.AddEmployee(_employees);
                            deviceEmpBll.InsertOneEmpToAccess(_employees, deviceBll.SelectDevices());
                            _applyMode = true;
                            btnApply.Enabled = false;
                            grpEcoder.Enabled = true;
                            TabFinger.PageEnabled = true;
                            TabInfoDevices.PageEnabled = true;
                            //      BtnSend.Visible = true;
                            //     LoadDeviceEmployeeData();
                            employees = new List<Employee> { _employees };

                            MessageBox.Show(@"اطلاعات با موفقیت ثبت شد!!!", @"پیغام", MessageBoxButtons.OK,
                                MessageBoxIcon.Information, MessageBoxDefaultButton.Button1,
                                MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                        }
                    }
                }
                else
                {
                    MessageBox.Show(@"اطلاعات وارد شده راتصحیح نمایید!!!", @"خطا", MessageBoxButtons.OK,
                        MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1,
                        MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                }
            }
        }

        private string GetAccessMenu()
        {
            var result = 0;
            if (chkNetworkMenu.Checked)
                result += 1;
            if (chkOperatorMenu.Checked)
                result += 2;
            if (chkDeviceMenu.Checked)
                result += 4;
            return result.ToString();
        }


        private void btnSaveEmp_Click(object sender, EventArgs e)
        {
            var deviceEmpBll = new DeviceEmpBll();
            var deviceBll = new DeviceBLL();
            var employeeBll = new EmployeeBLL();

            if (txtFName.Text == "" || txtLName.Text == "" || txtNational.Text == "" || txtPin.Text == "" ||
                txtEmpId.Text == "")
            {
                MessageBox.Show(@"اطلاعات خواسته شده را وارد نمایید!!!", @"خطا", MessageBoxButtons.OK,
                    MessageBoxIcon.Error, MessageBoxDefaultButton.Button1,
                    MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
            }

            else
            {
                if (txtNational.TextLength <= 11 && txtPin.TextLength <= 11 && txtEmpId.TextLength <= 11)
                {
                    if (txtPin.Text != txtRePin.Text || (txtPin.Text == "" && txtRePin.Text == ""))
                        MessageBox.Show(@"کلمه عبور ها با  هم مغایرت دارد!!!", @"خطا", MessageBoxButtons.OK,
                            MessageBoxIcon.Error, MessageBoxDefaultButton.Button1,
                            MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);

                    else
                    {
                        _employees.EmpFname = txtFName.Text;
                        _employees.EmpLname = txtLName.Text;
                        _employees.EmpNationalCode = txtNational.Text;
                        _employees.EmpPinCode = txtPin.Text;
                        _employees.PersonalNum = txtEmpId.Text;
                        _employees.TelePhone = txtTel.Text;
                        _employees.Post = txtPost.Text;
                        if(rdbtnEco.Checked)
                            _employees.AuthenticationMode = GetAuthenticationType();
                        if (rdbtnZk.Checked & !chkAuth.Checked)
                            _employees.AuthenticationMode = ((int)VerfiCombo.SelectedValue + 128).ToString();
                        if (rdbtnZk.Checked & chkAuth.Checked)
                            _employees.AuthenticationMode = (0).ToString();
                        _employees.MenuAccess = GetAccessMenu();
                        _employees.PrivateAccess = chkPrivateAccess.Checked;
                        if (rdbUser.Checked)
                            _employees.IsAdmin = false;
                        if (rdbAdmin.Checked)
                            _employees.IsAdmin = true;
                        

                        if (chkPrivateAccess.Checked && (int)cmbAcsGroup.SelectedValue == 0)
                        {
                            MessageBox.Show(@"برا ی این شخص گروه دسترسی تخصصی انتخاب کنید", @"", MessageBoxButtons.OK,
                                MessageBoxIcon.Information, MessageBoxDefaultButton.Button1,
                                MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                            return;
                        }

                        if (TreeOrganization.CheckedNodes.Count > 0)
                        {
                            _employees.OrganizationID = (int?)TreeOrganization.TreeViewElement.CheckedNodes[0].Value;
                        }
                        else
                        {
                            _employees.OrganizationID = null;
                        }


                        if ((int)cmbAcsGroup.SelectedValue != 0 && chkPrivateAccess.CheckState == CheckState.Checked)
                            _employees.AcsGroupID = (int)cmbAcsGroup.SelectedValue;
                        else
                        {
                            _employees.AcsGroupID = null;
                        }


                        if (_applyMode)
                        {
                            employeeBll.UpdateEmployee(_employees);


                            MessageBox.Show(@"اطلاعات کارمند ویرایش شد!!!", @"پیغام", MessageBoxButtons.OK,
                                MessageBoxIcon.Information, MessageBoxDefaultButton.Button1,
                                MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                        }


                        else
                        {
                            if (_employeeBll.ExistPersonalNum(txtEmpId.Text))
                            {
                                MessageBox.Show(@"این شماره کارمندی  در دیتا بیس وجود دارد!!!", @"خطا",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error, MessageBoxDefaultButton.Button1,
                                    MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                            }
                            else
                            {
                                employeeBll.AddEmployee(_employees);
                                deviceEmpBll.InsertOneEmpToAccess(_employees, deviceBll.SelectDevices());

                                //if (ConnectToDevice("192.168.0.10", "4370"))
                                //{
                                //    bool flag = _czkem.SSR_SetUserInfo(1, "3" , txtFName.Text + txtLName.Text, "1", 0, true);
                                //}



                                MessageBox.Show(@"اطلاعات با موفقیت ثبت شد!!!", @"پیغام", MessageBoxButtons.OK,
                                    MessageBoxIcon.Information, MessageBoxDefaultButton.Button1,
                                    MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);

                                EmptyFrmAddEmployee();
                                _applyMode = false;
                                btnApply.Enabled = true;
                            }
                        }
                    }


                    //         BtnSend.Visible = false;
                }
                else
                {
                    MessageBox.Show(@"اطلاعات وارد شده راتصحیح نمایید!!!", @"خطا", MessageBoxButtons.OK,
                        MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1,
                        MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                }
            }
        }


        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (txtFName.Text == "" || txtLName.Text == "" || txtNational.Text == "" || txtPin.Text == "")
            {
                MessageBox.Show(@"اطلاعات ضروری خواسته شده را وارد نمایید!!!", @"خطا", MessageBoxButtons.OK,
                    MessageBoxIcon.Error, MessageBoxDefaultButton.Button1,
                    MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
            }

            else
            {
                if (txtNational.TextLength <= 11 && txtPin.TextLength <= 11 && txtEmpId.TextLength <= 11)
                {
                    if (txtPin.Text != txtRePin.Text || (txtPin.Text == "" && txtRePin.Text == ""))
                        MessageBox.Show(@"کلمه عبور ها با  هم مغایرت دارد!!!", @"خطا", MessageBoxButtons.OK,
                            MessageBoxIcon.Error, MessageBoxDefaultButton.Button1,
                            MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                    else
                    {
                        if (_employeeBll.ExistPersonalNum(txtEmpId.Text) &&
                            _employeeBll.SelectOneEmployees(txtEmpId.Text).ID != _employees.ID)
                        {
                            MessageBox.Show(@"این شماره کارمندی  در دیتا بیس وجود دارد!!!", @"خطا", MessageBoxButtons.OK,
                                MessageBoxIcon.Error, MessageBoxDefaultButton.Button1,
                                MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                        }
                        else
                        {
                            var cardBll = new CardBLL();
                            var fingerBll = new FingerBLL();
                            var employeeBll = new EmployeeBLL();

                            _employees.EmpFname = txtFName.Text;
                            _employees.EmpLname = txtLName.Text;
                            _employees.EmpNationalCode = txtNational.Text;
                            _employees.EmpPinCode = txtPin.Text;
                            _employees.PersonalNum = txtEmpId.Text;
                            _employees.TelePhone = txtTel.Text;
                            _employees.Post = txtPost.Text;
                            if (rdbtnEco.Checked)
                                _employees.AuthenticationMode = GetAuthenticationType();
                            if (rdbtnZk.Checked & !chkAuth.Checked)
                                _employees.AuthenticationMode = ((int) VerfiCombo.SelectedValue + 128).ToString();
                            if (rdbtnZk.Checked & chkAuth.Checked)
                                _employees.AuthenticationMode = (0).ToString();

                            _employees.MenuAccess = GetAccessMenu();
                            _employees.PrivateAccess = chkPrivateAccess.Checked;

                            if (rdbUser.Checked)
                                _employees.IsAdmin = false;
                            if (rdbAdmin.Checked)
                                _employees.IsAdmin = true;

                            if (chkPrivateAccess.Checked && (int)cmbAcsGroup.SelectedValue == 0)
                            {
                                MessageBox.Show(@"برا ی این شخص گروه دسترسی تخصصی انتخاب کنید", @"",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Information, MessageBoxDefaultButton.Button1,
                                    MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);

                                return;
                            }

                            _employees.HasCard = cardBll.SelectOneCard(_employees.ID);
                            _employees.HasFinger = fingerBll.SelectOneFinger(_employees.ID);

                            if (TreeOrganization.CheckedNodes.Count > 0)
                            {
                                _employees.OrganizationID =
                                    (int?)TreeOrganization.TreeViewElement.CheckedNodes[0].Value;
                            }
                            else
                            {
                                _employees.OrganizationID = null;
                            }


                            if ((int)cmbAcsGroup.SelectedValue != 0 &&
                                chkPrivateAccess.CheckState == CheckState.Checked)
                                _employees.AcsGroupID = (int)cmbAcsGroup.SelectedValue;
                            else
                            {
                                _employees.AcsGroupID = null;
                            }

                            employeeBll.UpdateEmployee(_employees);
                            MessageBox.Show(@"اطلاعات با موفقیت ثبت شد!!!", @"پیغام", MessageBoxButtons.OK,
                                MessageBoxIcon.Information, MessageBoxDefaultButton.Button1,
                                MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);

                            Close();
                        }
                    }
                }
                else
                {
                    MessageBox.Show(@"اطلاعات وارد شده راتصحیح نمایید!!!", @"خطا", MessageBoxButtons.OK,
                        MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1,
                        MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                }
            }
        }


        private void BtnBrows_Click(object sender, EventArgs e)
        {
            byte[] imageData;
            var size = new Size(120, 140);

            openFileDialog.Filter = @"Image Files (*.bmp, *.jpg, *.png)|*.bmp;*.jpg; *.png";
            openFileDialog.FilterIndex = 1;
            openFileDialog.Multiselect = false;

            var result = openFileDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                try
                {
                    // imageData = File.ReadAllBytes(openFileDialog.FileName);
                    _employees.Image = ImageToByteArray(ResizeImage(Image.FromFile(openFileDialog.FileName), size, true));
                    pictureEmployee.Image = (ResizeImage(Image.FromFile(openFileDialog.FileName), size, true));
                }
                catch (Exception ex)
                {
                    MessageBox.Show(@"Error: Could not read file from disk. Original error: " + ex.Message);
                }
            }
        }

        public byte[] ImageToByteArray(Image x)
        {
            var imageConverter = new ImageConverter();
            var xByte = (byte[])imageConverter.ConvertTo(x, typeof(byte[]));
            return xByte;
        }

        private void btnDeleteCard_Click(object sender, EventArgs e)
        {
            var cardBll = new CardBLL();
            var employeeBll = new EmployeeBLL();

            if (cardBll.SelectOneCard(_employees.ID))
            {
                var result = MessageBox.Show(@"آیا مطمئن به حذف کارت هستید", @"پیام", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    cardBll.DeleteOneCard(_employees.ID);
                    employeeBll.GetCard(_employees);
                    picExistCard.Visible = false;
                    btnDeleteCard.Visible = false;
                }
            }
            else
            {
                MessageBox.Show(@" برای این شخص کارت رزرو نشده  ", @"پیام",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
        }

        private void btnEncode_Click(object sender, EventArgs e)
        {
            try
            {
                var employeeBll = new EmployeeBLL();
                var cardBll = new CardBLL();
                var deviceBll = new DeviceBLL();
                var deviceType = string.Empty;
                //this should be change
                if (cmbbxSelectEncoder.SelectedIndex == 1)
                {
                    var ip = ((DataRowView)cmbbxSelectEncoder.SelectedItem).Row[2].ToString();
                    if ((int)cmbbxSelectEncoder.SelectedValue != 0)
                    {
                        var ipAddress = IPAddress.Parse(ip);
                    }
                    else
                    {
                        deviceType = "controller";
                    }


                    var empId = employeeBll.SelectOneEmployees(_employees.ID).ID;


                    var device = deviceBll.SelectOneDevices(ip);

                    if (cardBll.SelectOneCard(_employees.ID))
                        MessageBox.Show(@"این شخص یک کارت دارد", @"پیام", MessageBoxButtons.OK, MessageBoxIcon.None);
                    else
                    {
                        var enrollOk = 7;

                        enrollOk = deviceType == "controller"
                            ? cardBll.EnrolCardWithUsb(EncoderComPortName, empId)
                            : cardBll.EnrolCard(device, empId);


                        switch (enrollOk)
                        {
                            case 0:
                                _employees.HasCard = true;
                                employeeBll.SetHasCard(_employees.ID);
                                MessageBox.Show(@"کارت شما با موفقیت کد شد", @"پیام", MessageBoxButtons.OK,
                                    MessageBoxIcon.None);
                                picExistCard.Visible = true;
                                btnDeleteCard.Visible = true;
                                break;
                            case 1:
                                MessageBox.Show(@"لطفا کارت  خود را به موقع در محل تعبیه شده قرار دهید", @"پیام",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Warning);
                                break;
                            case 2:
                                MessageBox.Show(@"از متصل بودن دستگاه اطمینان حاصل بفرمایید", @"پیام", MessageBoxButtons.OK,
                                    MessageBoxIcon.Warning);
                                break;
                            case 3:
                                MessageBox.Show(@"این کارت یک بار انکد شده است", @"پیام", MessageBoxButtons.OK,
                                    MessageBoxIcon.Warning);
                                break;
                            case 4:
                                MessageBox.Show(@"عملیات انکد کردن را به یک زمان دیگر موکول کنید", @"پیام",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Warning);
                                break;
                            case 5:
                                MessageBox.Show(@"عملیات توسط کاربر لغو شد", @"پیام", MessageBoxButtons.OK,
                                    MessageBoxIcon.Warning);
                                break;
                            case 6:
                                MessageBox.Show(@"مجددا امتحان کنید", @"پیام", MessageBoxButtons.OK,
                                    MessageBoxIcon.Warning);
                                break;
                        }
                    }
                }
                if (((DeviceType)((DataRowView)cmbbxSelectEncoder.SelectedItem).Row[14]).ID == 4)
                {
                    if (bIsConnected)
                    {
                        string cardData;
                        Card card = new Card();

                        _czkem.SSR_GetUserInfo(1, _employees.PersonalNum, out _, out _, out _, out _);
                        var a = _czkem.GetStrCardNumber(out cardData);
                        if (!a)
                        {
                            MessageBox.Show($@"داده ای از دستگاه دریافت نشد", @"پیام", MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                        }

                        if (cardBll.CardReserved(cardData))
                        {
                            MessageBox.Show($@"این اطلاعات کارت یک بار ذخیره شده", @"پیام", MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                            return;
                        }
                        if (a && cardData != "0")
                        {
                            _employees.HasCard = true;
                            employeeBll.SetHasCard(_employees.ID);
                            card.CardData = cardData;
                            card.EmpID = new EmployeeBLL().SelectOneEmployees(_employees.PersonalNum).ID;
                            cardBll.InsertCardData(card);
                            MessageBox.Show(@"اطلاعات کارت ذخیره شد", @"پیام", MessageBoxButtons.OK,
                                MessageBoxIcon.None);
                            picExistCard.Visible = true;
                            btnDeleteCard.Visible = true;
                            _czkem.Disconnect();
                        }

                        if (cardData == "0")
                        {
                            MessageBox.Show(@"اطلاعات کارت این شخص در دستگاه وجود ندارد", @"پیام", MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                            return;
                        }
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void FrmAddEmployee_FormClosing(object sender, FormClosingEventArgs e)
        {
            // ReSharper disable once AssignNullToNotNullAttribute
            var syncPath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location),
                "Sync");
            if (Directory.Exists(syncPath))
                File.Delete(syncPath + "\\Sync.txt");
        }


        private void BtnSend_Click(object sender, EventArgs e)
        {
            //new version

            progressPanel.Visible = true;
            // EnabledFrom(false);

            var editDeviceEmps = gridDeviceInfo.DataSource;


            var editEmployeeInDevices = EmployeeForSendInfo((List<EmployeeInDevice>)editDeviceEmps);

            foreach (var editEmployeeInDevice in editEmployeeInDevices)
            {
                if (_deviceBll.Ping(editEmployeeInDevice.Device.IP, editEmployeeInDevice.Device.Port))
                {
                    onlineDevices.Add(editEmployeeInDevice);
                }
            }

            if (onlineDevices.Count == 0)
            {
                MessageBox.Show(@"هیچیک از دستگاه های ویرایش شده در شبکه موجود نمی باشد", @"پیام", MessageBoxButtons.OK,
                    MessageBoxIcon.None);
                progressPanel.Visible = false;
                //        EnabledFrom(true);
                return;
            }

            _deviceThread = new Thread[onlineDevices.Count];
            _sendFlag = new bool[onlineDevices.Count];
            for (var i = 0; i < onlineDevices.Count; i++)
            {
                var index = i;
                _deviceThread[index] =
                    new Thread(() => { _sendFlag[index] = SendThread(index, onlineDevices[index], _sendFlag); });
                _deviceThread[index].Start();
            }


            while (true)
            {
                Application.DoEvents();
                if (Finished(0))
                {
                    MessageBox.Show(@"عملیات با موفقیت به اتمام رسید", @"پیام", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    _deviceEmpBll.UpdateAccess(onlineDevices);
                    DeleteFiles();
                    LoadDeviceEmployeeData();
                    onlineDevices.Clear();
                    // EnabledFrom(true);
                    progressPanel.Visible = false;
                    return;
                }
            }
        }

        private bool Finished(int i)
        {
            if (_sendFlag[i])
            {
                if (_sendFlag.Length - 1 == i)
                    return true;
                i++;
                return Finished(i);
            }
            return false;
        }

        private bool SendThread(int i, EmployeeInDevice editDeviceEmp, bool[] sendFlag)
        {
            var errorMessage = "";
            int response;
            var deviceBll = new DeviceBLL();
            // ReSharper disable once AssignNullToNotNullAttribute
            var dbPath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location),
                "Db");
            // ReSharper disable once AssignNullToNotNullAttribute
            var picturePath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location),
                "Pics\\" + editDeviceEmp.Device.IP);


            _employeeBll.BuildDBfile(employees, ref editDeviceEmp, onlineDevices);

            if (editDeviceEmp.Picture == true && editDeviceEmp.Employee.Image == null)
            {
                foreach (var onlineDevice in onlineDevices)
                {
                    if (onlineDevice == editDeviceEmp)
                        onlineDevice.Picture = false;
                }
            }

            if (editDeviceEmp.Picture != null && editDeviceEmp.Picture.Value && editDeviceEmp.Employee.Image != null)
            {
                _employeeBll.GetPictureOfEmployee(employees, editDeviceEmp.Device);
            }
            if (editDeviceEmp.Picture != null && editDeviceEmp.Picture.Value == false &&
                editDeviceEmp.Employee.Image != null)
            {
                _employeeBll.BuildDeletePictureFile(employees, editDeviceEmp.Device);
            }

            try
            {
                // _checkDbSend = SendDB(dbPath, editDeviceEmp.Device);
                var file = Directory.GetFiles(dbPath, editDeviceEmp.Device.IP + ".txt")[0];

                var destination = "db\\db.txt";

                var requestFileName = _deviceBll.CreateRequestFileName(editDeviceEmp.Device, file, destination);

                response = deviceBll.SendTftp(file, requestFileName, editDeviceEmp.Device.IP,
                    (int)editDeviceEmp.Device.UDPPort);
                if (response == 0)
                    editDeviceEmp.Db = editDeviceEmp.Db == true;
                if (response != 0)
                {
                    errorMessage = CheckerError(response);
                    editDeviceEmp.Db = editDeviceEmp.Db == false;
                }
            }
            catch (Exception dbException)
            {
                Console.WriteLine(dbException);
                throw;
            }


            try
            {
                // _checkPicSend = editDeviceEmp.Employee.Image == null || SendPicture(picturePath, editDeviceEmp.Device);
                if (editDeviceEmp.Employee.Image != null)
                {
                    var filePath = Directory.GetFiles(picturePath, "*.bmp*");
                    var index = filePath[0].IndexOf(editDeviceEmp.Device.IP, StringComparison.Ordinal);
                    var destination = "Pics\\" + filePath[0].Substring(index + editDeviceEmp.Device.IP.Length + 1);

                    var requestFileName = deviceBll.CreateRequestFileName(editDeviceEmp.Device, filePath[0], destination);

                    response = deviceBll.SendTftp(filePath[0], requestFileName, editDeviceEmp.Device.IP,
                        (int)editDeviceEmp.Device.UDPPort);
                    if (response == 0)
                        editDeviceEmp.Picture = editDeviceEmp.Picture == true;
                    if (response != 0)
                    {
                        errorMessage = "ارسال عکس  انجام نشد";
                        editDeviceEmp.Picture = editDeviceEmp.Picture != true;
                    }
                }
                else
                {
                    editDeviceEmp.Picture = false;
                }
            }
            catch (Exception picException)
            {
                Console.WriteLine(picException);
                throw;
            }


            try
            {
                if (editDeviceEmp.Finger != null && editDeviceEmp.Finger.Value == false &&
                    editDeviceEmp.DeviceEmp.Finger == true)
                {
                    // finishSync = SendDeleteFinger(employees, editDeviceEmp.Device);

                    foreach (var employee in employees)
                    {
                        foreach (var finger in employee.Fingers)
                        {
                            _fingerBll.GenerateSyncFile((-1 * employee.ID), finger.FingerNum);
                        }
                    }
                    // ReSharper disable once AssignNullToNotNullAttribute
                    var syncPath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location),
                        "Sync");
                    var syncdestination = "Sync2.fpt";
                    var requestFileName = _deviceBll.CreateRequestFileName(editDeviceEmp.Device, syncPath + "\\Sync.txt",
                        syncdestination);

                    response = deviceBll.SendTftp(syncPath + "\\Sync.txt", requestFileName, editDeviceEmp.Device.IP,
                        (int)editDeviceEmp.Device.UDPPort);
                    if (response == 0)
                        editDeviceEmp.Finger = editDeviceEmp.Finger == true;
                    if (response != 0)
                    {
                        errorMessage = CheckerError(response);
                        editDeviceEmp.Finger = editDeviceEmp.Finger != true;
                    }
                }
            }
            catch (Exception fingException)
            {
                Console.WriteLine(fingException);
                throw;
            }


            sendFlag[i] = true;
            return true;
        }

        private bool SendDeleteFinger(List<Employee> employeeList, Device device)
        {
            try
            {
                foreach (var employee in employeeList)
                {
                    foreach (var finger in employee.Fingers)
                    {
                        _fingerBll.GenerateSyncFile((-1 * employee.ID), finger.FingerNum);
                    }
                }
                // ReSharper disable once AssignNullToNotNullAttribute
                var syncPath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location),
                    "Sync");
                var syncdestination = "Sync2.fpt";
                var requestFileName = _deviceBll.CreateRequestFileName(device, syncPath + "\\Sync.txt", syncdestination);
                if (_deviceBll.Ping(device.IP, device.Port))
                    if (device.UDPPort != null &&
                        _deviceBll.SendTftp(syncPath + "\\Sync.txt", requestFileName, device.IP, (int)device.UDPPort) ==
                        0)
                        return true;
                return false;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private bool SendDB(string dbPath, Device device)
        {
            try
            {
                var file = Directory.GetFiles(dbPath, device.IP + ".txt")[0];

                var destination = "db\\db.txt";

                var requestFileName = _deviceBll.CreateRequestFileName(device, file, destination);

                if (device.UDPPort != null &&
                    _deviceBll.SendTftp(file, requestFileName, device.IP, (int)device.UDPPort) == 0)
                    return true;
                return false;
            }
            catch (Exception ex)
            {
                return false;
                Console.WriteLine(ex);
            }
        }

        private bool SendPicture(string picturePath, Device device)
        {
            try
            {
                var filePath = Directory.GetFiles(picturePath, "*.bmp*");
                var index = filePath[0].IndexOf(device.IP, StringComparison.Ordinal);
                var destination = "Pics\\" + filePath[0].Substring(index + device.IP.Length + 1);

                var requestFileName = _deviceBll.CreateRequestFileName(device, filePath[0], destination);

                if (device.UDPPort != null &&
                    _deviceBll.SendTftp(filePath[0], requestFileName, device.IP, (int)device.UDPPort) == 0)
                    return true;
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return false;
            }
        }

        private List<EmployeeInDevice> EmployeeForSendInfo(List<EmployeeInDevice> editEmployeeInDevices)
        {
            try
            {
                var employeeInDevices = new List<EmployeeInDevice>();

                foreach (var editEmployeeInDevice in editEmployeeInDevices)
                {
                    if (editEmployeeInDevice.Db != editEmployeeInDevice.DeviceEmp.Db ||
                        editEmployeeInDevice.Picture != editEmployeeInDevice.DeviceEmp.Picture ||
                        editEmployeeInDevice.Finger != editEmployeeInDevice.DeviceEmp.Finger)
                        employeeInDevices.Add(editEmployeeInDevice);
                }
                return employeeInDevices;
            }
            catch (Exception)
            {
                throw;
            }
        }


        private void FigerLink_Click(object sender, EventArgs e)
        {
            try
            {
                var index = GrdInfoInDevices.FocusedRowHandle;
                var id = GrdInfoInDevices.GetRowCellValue(index, "DeviceID");
                var device = _deviceBll.SelectOneDevices((int)id);

                //if (!_deviceBll.Ping(device.IP, device.Port, device.ServerIP))
                if (!_deviceBll.Ping(device.IP, device.Port))
                {
                    MessageBox.Show(@"این دستگاه در شبکه موجود نمی باشد", @"پیام", MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    return;
                }
                var deviceEmp = _deviceEmpBll.SelectEmployeeInDevice(employees[0], device);
                if (deviceEmp.Db == false)
                {
                    MessageBox.Show(@"شخص به این دستگاه دسترسی ندارد", @"....", MessageBoxButtons.OK,
                        MessageBoxIcon.Information, MessageBoxDefaultButton.Button1,
                        MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                }
                else
                {
                    var frmFingersInDevice = new FrmFingersInDevice(device, _employees);

                    frmFingersInDevice.ShowDialog();

                    LoadDeviceEmployeeData();
                }
            }
            catch (Exception ex)
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

        private void xtraTab_SelectedPageChanged(object sender, TabPageChangedEventArgs e)
        {
            var tabObject = (XtraTabControl)sender;

            var tabIndex = tabObject.SelectedTabPageIndex;
            btnGetFace.Visible = true;

            if (tabIndex == 2)
            {
                BtnSend.Visible = true;
                LoadDeviceEmployeeData();
            }
            else
            {
                BtnSend.Visible = false;
            }
            if (tabIndex == 1)
            {
                ShowFingerPrint();
                ShowFacePicture();
            }
        }

        private void ShowFacePicture()
        {
            try
            {
                FaceBll faceBll = new FaceBll();
                byte[] img = faceBll.GetImage(_employees.ID);

                if (img != null)
                {
                    using (MemoryStream msCamera = new MemoryStream(img, 0, img.Length))
                    {

                        PicBox.Image = ResizeImage(new Bitmap(msCamera), new Size(116, 129));

                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        private void TreeOrganization_NodeCheckedChanging(object sender, RadTreeViewCancelEventArgs e)
        {
            foreach (var node in TreeOrganization.TreeViewElement.GetNodes().ToList())
            {
                if (node.Index != e.Node.Index)
                    node.Checked = false;
                if (node.Level != e.Node.Level)
                    node.Checked = false;
            }
        }


        private RadTreeNode FindNodeByValue(object value, RadTreeNodeCollection nodes)
        {
            foreach (var node in nodes)
            {
                if (node.Value.Equals(value))
                {
                    return node;
                }
                var n = FindNodeByValue(value, node.Nodes);
                if (n != null)
                {
                    return n;
                }
            }

            return null;
        }


        private void btnConnect_Click(object sender, EventArgs e)
        {
            try
            {
                if ((int)cmbbxSelectEncoder.SelectedValue == -1)
                {
                    return;
                }

                if (cmbbxSelectEncoder.SelectedIndex == 1)
                {
                    for (var i = 1; i <= 50; i++)
                    {
                        try
                        {
                            if (HardwareConnected)
                                break;

                            var comPortName = "COM" + i.ToString(CultureInfo.InvariantCulture);

                            var connectToHardware = new ConnectToHardware(comPortName, 19200);

                            connectToHardware.StartEncoding();

                            var counter = 0;

                            while (true)
                            {
                                Thread.Sleep(50);
                                if (connectToHardware.ConnectedHardware == 1)
                                {
                                    EncoderComPortName = comPortName;

                                    connectToHardware.SerialPort.Close();
                                    HardwareConnected = true;
                                    btnEncode.Enabled = true;
                                    cmbbxSelectEncoder.Enabled = false;
                                    break;
                                }

                                if (counter == 50)
                                {
                                    try
                                    {
                                        connectToHardware.SerialPort.Close();
                                    }
                                    // ReSharper disable once EmptyGeneralCatchClause
                                    catch
                                    {
                                    }
                                    break;
                                }
                                counter++;
                            }
                            Thread.Sleep(100);
                        }
                        catch
                        {
                            // ignored
                        }
                    }

                    if (HardwareConnected == false)
                    {
                        MessageBox.Show(
                            @"از اتصال دستگاه اطمینان حاصل کنید، در صورت متصل بودن دستگاه درایور انکدر را نصب بفرمایید",
                            @"پیام", MessageBoxButtons.OK,
                            MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1,
                            MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                    }
                }

                if (((DeviceType)((DataRowView)cmbbxSelectEncoder.SelectedItem).Row[14]).ID == 4)
                {

                    if (_deviceBll.Ping(((DataRowView) cmbbxSelectEncoder.SelectedItem).Row[2].ToString(),
                        (Convert.ToInt32(((DataRowView) cmbbxSelectEncoder.SelectedItem).Row[3]))))
                    {
                        bIsConnected =
                            ConnectToDevice(((DataRowView)cmbbxSelectEncoder.SelectedItem).Row[2].ToString(),
                                (Convert.ToInt32(((DataRowView)cmbbxSelectEncoder.SelectedItem).Row[3])));
                    }
                    else
                    {
                        MessageBox.Show(
                            @"از اتصال دستگاه به شبکه اطمینان حاصل کنید",
                            @"پیام", MessageBoxButtons.OK,
                            MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1,
                            MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                    }



                    if (bIsConnected)
                    {
                        btnEncode.Enabled = true;
                        cmbbxSelectEncoder.Enabled = false;
                        btnEncode.Text = @"دریافت کد";
                        return;
                    }
                    else
                    {
                        MessageBox.Show(
                            @"از اتصال دستگاه اطمینان حاصل کنید ",
                            @"پیام", MessageBoxButtons.OK,
                            MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1,
                            MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                    }

                }

            }
            catch (Exception)
            {
                throw;
            }
        }

        private void cmbbxSelectEncoder_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if ((int)cmbbxSelectEncoder.SelectedValue == -1)
            {
                return;
            }

            if (((int)cmbbxSelectEncoder.SelectedValue == 0 || ((DeviceType)((DataRowView)cmbbxSelectEncoder.SelectedItem).Row[14]).ID == 4))
            {
                btnConnect.Visible = true;
            }
            else
            {
                //  btnConnect.Visible = false;

                MessageBox.Show(@"جهت انکد کارت برای دستگاه کنترلر باید از دستگاه انکدر مایفر استفاده کنید", @"هشدار",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error, MessageBoxDefaultButton.Button1,
                    MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
            }
        }

        private void chkPrivateAccess_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                var edit = sender as CheckBox;
                if (edit == null) return;

                switch (edit.CheckState)
                {
                    case CheckState.Unchecked:
                        cmbAcsGroup.Enabled = false;
                        cmbAcsGroup.SelectedIndex = 0;
                        break;
                    case CheckState.Checked:
                        cmbAcsGroup.Enabled = true;
                        break;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
        string tempData = "";
        int tempLength = 0;
        private void BtnGetFace_Click(object sender, EventArgs e)
        {
            try
            {
                CZKEMClass czkem = new CZKEMClass();
                FaceBll faceBll = new FaceBll();

                Byte[] photoData = new Byte[1024*1024];
                int photoSize = 0;
                var id = (int)cmbbxSelectEncoder.SelectedValue;

                var device = _deviceBll.SelectOneDevices(id);
                if (device == null)
                {
                    MessageBox.Show(@"یک دستگاه از منوی بالا انتخاب کنید", @"پیام", MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    return;
                }
                if(!_deviceBll.Ping(device.IP, (int)device.Port))
                {
                    MessageBox.Show(@"از اتصال دستگاه به شبکه اطمینان حاصل کنید", @"پیام", MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    return;
                }
                if (czkem.Connect_Net(device.IP, (int)device.Port))
                {
                    var res = czkem.GetUserFaceStr(iMachineNumber, employees[0].PersonalNum, 50, ref tempData, ref tempLength);
                    var result2 = czkem.GetUserFace(iMachineNumber, employees[0].PersonalNum, 50, ref photoData[0],
                       ref tempLength);


                   byte[] bytes = System.Convert.FromBase64String(tempData);
                    var result = czkem.GetUserFacePhotoByName(iMachineNumber, employees[0].PersonalNum + ".jpg", out photoData[0], out photoSize);
                    if (result)
                    {
                        var a = new MemoryStream(photoData, 0, photoData.Length);
                        //var a = new MemoryStream(bytes, 0, bytes.Length);
                        var b = new Bitmap(a);
                        this.PicBox.Image = ResizeImage(b,new Size(116, 129));
                    }



                    if (res || result)
                    {
                        if (FaceBll.ExistEmployeeFace(_employees.ID))
                        {
                            DialogResult r = MessageBox.Show(@"یک تصویر از این شخص در دیتابیس موجود است آیا می خواهید جایگزین شود؟", @"پیام", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                            if (r == DialogResult.Yes)
                            {
                                if (faceBll.UpdateFace(new Face()
                                {
                                    FaceData = tempData,
                                    EmpId = employees[0].ID,
                                    PersonalNum = employees[0].PersonalNum,
                                    image = photoData
                                }))
                                {
                                    MessageBox.Show(@"تصویر چهره با موفقیت  ذخیره شد", @"پیام", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                            }
                        }
                        else
                        {
                            if (faceBll.InsertFace(new Face()
                            {
                                FaceData = tempData,
                                EmpId = employees[0].ID,
                                PersonalNum = employees[0].PersonalNum,
                                image = photoData
                            }))
                            {
                                MessageBox.Show(@"اطلاعات چهره در دستگاه وجود ندارد", @"پیام", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }

                    }
                    else
                    {
                        MessageBox.Show(@"عملیات دریافت اطلاعات چهره با مشکل مواجه شد", @"هشدار", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    MessageBox.Show(@"ارتباط با دستگاه برقرار نشد", @"هشدار", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                czkem.Disconnect();
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                //throw;
            }
        }

        private void BtnSendFace_Click(object sender, EventArgs e)
        {
            try
            {

                CZKEMClass czkem = new CZKEMClass();

                FrmSendInfo frmSendInfo = new FrmSendInfo(true, _employees);
                frmSendInfo.ShowDialog();
            }
            catch (Exception ex)
            {
            }
        }

        private static Image ResizeImage(Image imgToResize, Size size)
        {
            //Get the image current width  
            int sourceWidth = imgToResize.Width;
            //Get the image current height  
            int sourceHeight = imgToResize.Height;
            float nPercent = 0;
            float nPercentW = 0;
            float nPercentH = 0;
            //Calulate  width with new desired size  
            nPercentW = ((float)size.Width / (float)sourceWidth);
            //Calculate height with new desired size  
            nPercentH = ((float)size.Height / (float)sourceHeight);
            if (nPercentH < nPercentW)
                nPercent = nPercentH;
            else
                nPercent = nPercentW;
            //New Width  
            int destWidth = (int)(sourceWidth * nPercent);
            //New Height  
            int destHeight = (int)(sourceHeight * nPercent);
            Bitmap b = new Bitmap(destWidth, destHeight);
            Graphics g = Graphics.FromImage((Image)b);
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;
            // Draw image with new width and height  
            g.DrawImage(imgToResize, 0, 0, destWidth, destHeight);
            g.Dispose();
            return (Image)b;
        }

        private void BtnGetPalm_Click(object sender, EventArgs e)
        {

        }

        private void rdbtnZk_CheckedChanged(object sender, EventArgs e)
        {
            grpAuthType.Visible = false;
            grpAuthType.Enabled = false;
            grpMenuAccess.Visible = false;
            grpAuthTypeForZk.Visible = true;
        }

        private void rdbtnEco_CheckedChanged(object sender, EventArgs e)
        {
            grpAuthType.Visible = true;
            grpMenuAccess.Visible = true;
            grpAuthTypeForZk.Visible = false;
            grpAuthType.Enabled = true;
        }

        private void rdbtnRaya_CheckedChanged(object sender, EventArgs e)
        {
            grpAuthType.Visible = true; 
            grpAuthType.Enabled = false;
            grpMenuAccess.Visible = false;
            grpAuthTypeForZk.Visible = false;
        }


        private void chkAuth_CheckedChanged(object sender, EventArgs e)
        {
            VerfiCombo.Enabled = !((CheckBox)sender).Checked;
        }

        private void button2_Click(object sender, EventArgs e)
        {

            string name= String.Empty;
            string pass= String.Empty;
            int privilage = 0;
            bool enabled= true;
            _czkem.Connect_Net("192.168.0.10",4370);
            var s = _czkem.SSR_GetUserInfo(1, _employees.PersonalNum.ToString(), out name,out pass ,out privilage, out enabled);
            s = _czkem.GetAllRole(1, out name);
            s = _czkem.GetAppOfRole(1, 4, out name);
            s = _czkem.GetFunOfRole(1,4,out name);
            s = _czkem.SetPermOfAppFun(1, 4, "comset", "wifiset");
        }
    }

    public class ConnectToHardware

    {
        private const int MaxBuffer = 50;
        private readonly int _boudRate;
        private readonly byte[] _buzzerIsOk = { 0x02, 0x01, 0x05, 0x04, 0x03 };
        private readonly byte[] _dataReceived = new byte[MaxBuffer];
        private readonly string _portNumber;
        private readonly byte[] _testBuzzerCommand = { 0x02, 0x04, 0x05, 0x02, 0x02, 0x02, 0x03, 0x03 };
        public SerialPort SerialPort;

        public ConnectToHardware(string portNumber, int boudRate)
        {
            _portNumber = portNumber;
            _boudRate = boudRate;
        }

        public int ConnectedHardware { get; set; }
        public bool CheckBuzzerIsOk { get; set; }

        public void StartEncoding()
        {
            try
            {
                CheckBuzzerIsOk = false;

                if (SerialConnection())
                {
                    SendCommand(_testBuzzerCommand);
                    Thread.Sleep(100);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }


        private bool SerialConnection()
        {
            try
            {
                SerialPort = new SerialPort(_portNumber, _boudRate, Parity.None, 8, StopBits.One)
                {
                    WriteTimeout = 400,
                    ReadTimeout = 400
                };
                // ReSharper disable once RedundantDelegateCreation
                SerialPort.DataReceived += new SerialDataReceivedEventHandler(Port_DataReceived);
                SerialPort.Open();
                return true;
            }
            catch (Exception ex)
            {
                SerialPort.Close();
                throw new Exception(ex.Message, ex);
            }
        }


        private void SendCommand(byte[] command)
        {
            try
            {
                SerialPort.Write(command, 0, command.Length);
                Thread.Sleep(500);
                ConnectedHardware = 2;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }


        private void Port_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            try
            {
                ConnectedHardware = 3;
                var i = 0;
                var sPort = (SerialPort)sender;
                Thread.Sleep(200);
                while (sPort.IsOpen && sPort.BytesToRead > 0)
                {
                    _dataReceived[i] = Convert.ToByte(SerialPort.ReadByte());
                    i++;
                    if (i >= MaxBuffer)
                    {
                        i = 0;
                    }
                }

                var data = new byte[i];

                if (i > 1 && _dataReceived[0] != Encoding.ASCII.GetBytes("^")[0])
                {
                    for (var j = 0; j < i; j++)
                        data[j] = _dataReceived[j];

                    if (!CheckBuzzerIsOk)
                    {
                        CheckBuzzerIsOk = CheckBuzzer(data);
                        ConnectedHardware = 1;
                        SerialPort.Close();
                    }

                    SerialPort.Close();
                }
            }
            catch (Exception ex)
            {
                SerialPort.Close();
                throw new Exception(ex.Message, ex);
            }
        }


        private bool CheckBuzzer(byte[] data)
        {
            var dataHexCheckBuzzer = ByteArrayToString(data);
            var commandHexCheckBuzzer = ByteArrayToString(_buzzerIsOk);

            if (dataHexCheckBuzzer == commandHexCheckBuzzer)
                return true;
            return false;
        }

        public static string ByteArrayToString(byte[] data)
        {
            var hexData = BitConverter.ToString(data);
            hexData = hexData.Replace("-", "");
            return hexData;
        }
    }
}