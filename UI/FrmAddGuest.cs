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
    public partial class FrmAddGuest : Form
    {
        private bool _cancel;
        private bool _pause;
        private string imagesDirectory;

        public FrmAddGuest()
        {
            InitializeComponent();
            FillTypeEncodeComboBox();
            FillEncoderComboBox();
            FillGridView();
            BtnRecieve.Enabled = false;


            //please check it
            imagesDirectory =
                // ReSharper disable once AssignNullToNotNullAttribute
                Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "Images");
        }

        private void FillGridView()
        {
            try
            {
                var guestBll = new GuestBLL();
                var cards = guestBll.SelectGuestCards().ToList();
                gridViewGuest.DataSource = cards;
                EmptyProgressBar(cards);
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void FillEncoderComboBox()
        {
            var deviceBll = new DeviceBLL();
            cmbEncoder.DataSource = deviceBll.SelectDevices();
            cmbEncoder.DisplayMember = "DeviceName";
            cmbEncoder.ValueMember = "IP";
        }

        private void FillTypeEncodeComboBox()
        {
            cmbSelectType.DataSource = TypGuestEncode();
        }

        private List<string> TypGuestEncode()
        {
            var typeList = new List<string>();

            foreach (var i in Enum.GetValues(typeof (TypeGuestEncode)))
            {
                typeList.Add(((TypeGuestEncode) i).ToString());
            }
            return typeList;
        }

        private void cmbSelectType_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (cmbSelectType.SelectedIndex == 0)
            {
                GrpIndivitual.Visible = false;
                grpGroups.Visible = true;
            }

            else
            {
                if (cmbSelectType.SelectedIndex == 1)
                {
                    GrpIndivitual.Visible = true;
                    grpGroups.Visible = false;
                }
            }
        }

        private void BtnIndivitualStart_Click(object sender, EventArgs e)
        {
            try
            {
                var deviceBll = new DeviceBLL();
                var cardBll = new CardBLL();
                var employeeBll = new EmployeeBLL();
                var deviceEmpBll = new DeviceEmpBll();
                DialogResult result;
                var allDevice = new List<Device>();
                var device = deviceBll.SelectOneDevices(cmbEncoder.SelectedValue.ToString());
                var empId = 0;
                var cardNumber = Convert.ToInt32(CounterCardNumber.Text);

                allDevice = deviceBll.SelectDevices();
         
                var employee = new Employee
                {
                    EmpFname = "مهمان",
                    EmpLname = cardNumber.ToString(),
                    PersonalNum = Convert.ToString(99999999 + cardNumber),
                    EmpPinCode = Convert.ToString(99999999 + cardNumber),
                    IsGuest = true,
                    IsAdmin = false
                };
                if (employeeBll.ExistPersonalNum(employee.PersonalNum) && cardBll.ExistCardNumber(cardNumber))
                {
                    result = MessageBox.Show(@"این شماره کارت از قبل وجود دارد آیا میخواهید به روز رسانی کنید", @"پیام",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Warning);

                    if (result == DialogResult.Yes)
                    {
                        empId = employeeBll.SelectOneEmployees(employee.PersonalNum).ID;
                    }
                    else
                    {
                        return;
                    }
                }
                if (employeeBll.ExistPersonalNum(employee.PersonalNum))
                {
                    empId = employeeBll.SelectOneEmployees(employee.PersonalNum).ID;
                }
                if (!employeeBll.ExistPersonalNum(employee.PersonalNum))
                {
                    employeeBll.AddEmployee(employee);
                    empId = employeeBll.SelectOneEmployees(employee.PersonalNum).ID;
                }


                if (device.DeviceType.Type == "ECO")
                {
                    var enrollOk = cardBll.EnrolGuestCard(device, empId, cardNumber);
                    ShowResult(empId, employee, enrollOk);
                }
                if (device.DeviceType.Type == "ZK")
                {
                    
                    CZKEMClass _czkem = new CZKEMClass();

                    if (ConnectToDevice(device.IP, device.Port, _czkem))
                    {
                       
                        var res = _czkem.SSR_SetUserInfo(1, employee.PersonalNum, employee.EmpFname + employee.EmpLname, employee.EmpPinCode, 0, true);
                        if (res)
                        {
                            MessageBox.Show(@"اطلاعات مهمان در دستگه ثبت شد لطفا از طریق دستگاه کارت را کد کنید و سپس دکمه دریافت را بزنید.", @"پیام", MessageBoxButtons.OK, MessageBoxIcon.None);
                            btnGet.Visible = true;
                        }
                           

                    }
                    else {
                        MessageBox.Show(@"ارتباط  با دستگاه برقرار نشد.", @"پیام", MessageBoxButtons.OK, MessageBoxIcon.None);
                    }
                        
                }
                 
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool ConnectToDevice(string Ip, int? port, CZKEM _czkem)
        {
            int idwErrorCode = 0;

            if (_czkem.Connect_Net(Ip, (int)port))
                return true;
            return false;
        }

        private void EnabledFrom(bool p)
        {
            // GrpDefineGuest.Enabled = p;
            // gridViewGuest.Enabled = true;
            //  this.Enabled = p;
        }

        private void ShowResult(int empId, Employee employee, int enrollOk)
        {
            var employeeBll = new EmployeeBLL();
            switch (enrollOk)
            {
                case 0:
                    employee.HasCard = true;
                    employeeBll.SetHasCard(empId);
                    MessageBox.Show(@"کارت شما با موفقیت کد شد", @"پیام", MessageBoxButtons.OK, MessageBoxIcon.None);
                    FillGridView();
                    break;
                case 1:
                    MessageBox.Show(@"لطفا کارت  خود را به موقع در محل تعبیه شده قرار دهید", @"پیام",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    break;
                case 2:
                    MessageBox.Show(@"این دستگاه انکدر در شبکه موجود نمی باشد", @"پیام", MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    break;
                case 3:
                    MessageBox.Show(@"این کارت یک بار انکد شده است", @"پیام", MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    break;
                case 4:
                    MessageBox.Show(@"عملیات انکد کردن را به یک زمان دیگر موکول کنید", @"پیام", MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    break;
                case 5:
                    MessageBox.Show(@"عملیات توسط کاربر لغو شد", @"پیام", MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    break;
            }
        }

        private void BtnGroupStart_Click(object sender, EventArgs e)
        {
            try
            {
                var deviceBll = new DeviceBLL();
                var guestBll = new GuestBLL();
                var cardBll = new CardBLL();
                var deviceEmpBll = new DeviceEmpBll();
                var employeeBll = new EmployeeBLL();
                DialogResult result;
                var allDevice = new List<Device>();
                var device = deviceBll.SelectOneDevices(cmbEncoder.SelectedValue.ToString());
                var empId = 0;
                var fromcardNumber = Convert.ToInt32(CounterFrom.Text);
                var tocardNumber = Convert.ToInt32(CounterTo.Text);

                _pause = false;
                _cancel = false;

                var cardList = guestBll.CreateListCard(fromcardNumber, tocardNumber);
                gridViewGuest.DataSource = cardList;
                EmptyProgressBar(cardList);
                BtnRecieve.Enabled = false;
                if (!deviceBll.Ping(device.IP,device.Port))
                {
                    MessageBox.Show(@"این دستگاه انکدر در شبکه موجود نمی باشد", @"پیام", MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    return;
                }


                for (var cardNumber = fromcardNumber; cardNumber <= tocardNumber; cardNumber++)
                {
                    grdviewGuest.SetRowCellValue(cardNumber - fromcardNumber, Progressbar, 30);
                    Refresh();

                    var employee = new Employee
                    {
                        EmpFname = "مهمان",
                        EmpLname = cardNumber.ToString(),
                        PersonalNum = Convert.ToString(99999999 + cardNumber),
                        EmpPinCode = Convert.ToString(99999999 + cardNumber),
                        IsGuest = true
                    };


                    if (_pause)
                        return;
                    if (_cancel)
                        return;

                    if (employeeBll.ExistPersonalNum(employee.PersonalNum) && cardBll.ExistCardNumber(cardNumber))
                    {
                        result = MessageBox.Show(@"این شماره کارت از قبل وجود دارد آیا میخواهید به روز رسانی کنید",
                            @"پیام", MessageBoxButtons.YesNo,
                            MessageBoxIcon.Question);

                        if (result == DialogResult.Yes)
                        {
                            empId = employeeBll.SelectOneEmployees(employee.PersonalNum).ID;
                        }
                        else
                        {
                            grdviewGuest.SetRowCellValue(cardNumber - fromcardNumber, Progressbar, 0);
                            continue;
                        }
                    }
                    if (employeeBll.ExistPersonalNum(employee.PersonalNum))
                    {
                        empId = employeeBll.SelectOneEmployees(employee.PersonalNum).ID;
                    }
                    if (!employeeBll.ExistPersonalNum(employee.PersonalNum))
                    {
                        employeeBll.AddEmployee(employee);
                        empId = employeeBll.SelectOneEmployees(employee.PersonalNum).ID;
                        deviceEmpBll.InsertOneEmpToAccess(employee, allDevice);
                    }

                    if (device.DeviceType.Type == "ECO")
                    {
                        var enrollOk = cardBll.EnrolGuestCard(device, empId, cardNumber);

                        grdviewGuest.SetRowCellValue(cardNumber - fromcardNumber, Progressbar, 50);

                        switch (enrollOk)
                        {
                            case 0:
                                employee.HasCard = true;
                                grdviewGuest.SetRowCellValue(cardNumber - fromcardNumber, Progressbar, 100);
                                employeeBll.SetHasCard(empId);
                                break;
                            case 1:
                                result =
                                    MessageBox.Show(
                                        @"لطفا کارت  خود را به موقع در محل تعبیه شده قرار دهید دوباره تلاش می کنید؟",
                                        @"پیام", MessageBoxButtons.RetryCancel,
                                        MessageBoxIcon.Question);
                                if (result == DialogResult.Retry)
                                {
                                    cardNumber--;
                                    continue;
                                }
                                grdviewGuest.SetRowCellValue(cardNumber - fromcardNumber, Progressbar, 0);
                                continue;
                                break;
                            case 2:
                                MessageBox.Show(@"این دستگاه انکدر در شبکه موجود نمی باشد", @"پیام", MessageBoxButtons.OK,
                                    MessageBoxIcon.Warning);
                                grdviewGuest.SetRowCellValue(cardNumber - fromcardNumber, Progressbar, 0);
                                return;
                                break;
                            case 3:
                                result = MessageBox.Show(@"این کارت یک بار انکد شده است دوباره تلاش می کنید؟", @"پیام",
                                    MessageBoxButtons.RetryCancel,
                                    MessageBoxIcon.Question);
                                if (result == DialogResult.Retry)
                                {
                                    cardNumber--;
                                    continue;
                                }
                                grdviewGuest.SetRowCellValue(cardNumber - fromcardNumber, Progressbar, 0);
                                continue;
                                break;
                            case 4:
                                MessageBox.Show(@"عملیات انکد کردن را به یک زمان دیگر موکول کنید", @"پیام",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Warning);
                                grdviewGuest.SetRowCellValue(cardNumber - fromcardNumber, Progressbar, 0);
                                return;
                                break;
                            case 5:
                                result = MessageBox.Show(@"عملیات توسط کاربر لغو شد دوباره تلاش می کنید؟", @"پیام",
                                    MessageBoxButtons.RetryCancel,
                                    MessageBoxIcon.Question);
                                if (result == DialogResult.Retry)
                                {
                                    cardNumber--;
                                    continue;
                                }
                                grdviewGuest.SetRowCellValue(cardNumber - fromcardNumber, Progressbar, 0);
                                continue;
                                break;
                            case 6:
                                MessageBox.Show(@"در وارد کردن اطلاعات به دیتا بیس مشکلی به وجود آمده !!", @"پیام",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Warning);
                                grdviewGuest.SetRowCellValue(cardNumber - fromcardNumber, Progressbar, 0);
                                return;
                                break;
                        }
                        Thread.Sleep(1000);
                    }

                    if (device.DeviceType.Type == "ZK")
                    {
                        CZKEMClass _czkem = new CZKEMClass();

                        if (ConnectToDevice(device.IP, device.Port, _czkem))
                        {
                            employee.EmpPinCode = CardNumber.ToString();
                            var res = _czkem.SSR_SetUserInfo(1, employee.PersonalNum, employee.EmpFname + employee.EmpLname, employee.EmpPinCode, 0, true);
                            if (res)
                            {
                                employee.HasCard = true;
                                grdviewGuest.SetRowCellValue(cardNumber - fromcardNumber, Progressbar, 50);
                                employeeBll.SetHasCard(empId);


                                Thread.Sleep(1000);
                            }


                        }
                    }   
                }
                if (device.DeviceType.Type == "ZK")
                {
                        MessageBox.Show(@"لیست میهمانان در دستگاه ثبت شده، به منوی دستگاه رفته و کارتهای مهیمانان را کد کنید و سپس دکمه دریافت را بزنید ", @"پیام", MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
                }
                BtnRecieve.Enabled = true;
                if (device.DeviceType.Type == "ECO")
                {
                    MessageBox.Show(@"عملیات به اتمام رسید ", @"پیام", MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
                }

            }
            catch (Exception)
            {
                throw;
            }
        }

        private void BtnPause_Click(object sender, EventArgs e)
        {
            _pause = true;
            CounterFrom.Enabled = false;
            CounterTo.Enabled = false;
            BtnGroupStart.Text = @"ادامه";
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            _cancel = true;
            CounterFrom.Enabled = true;
            CounterTo.Enabled = true;
            BtnGroupStart.Text = @"شروع";
        }


        private void EmptyProgressBar(List<GuestCard> cards)
        {
            try
            {
                for (var i = 0; i < cards.Count; i++)
                {
                    grdviewGuest.SetRowCellValue(i, Progressbar, 0);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        private enum TypeGuestEncode
        {
            گروهی = 0,
            دستی
        };

        private void BtnGet_Click(object sender, EventArgs e)
        {
            try
            {
                CZKEM _czkem = new CZKEM();
                DeviceBLL deviceBll = new DeviceBLL();
                EmployeeBLL employeeBLL = new EmployeeBLL();


                var device = deviceBll.SelectOneDevices(cmbEncoder.SelectedValue.ToString());
                var empId = 0;
                var cardNumber = Convert.ToInt32(CounterCardNumber.Text);

                Employee employee = employeeBLL.SelectOneEmployees(Convert.ToString(99999999 + cardNumber));
                if (device.DeviceType.Type == "ZK")
                {
                    if (ConnectToDevice(device.IP, device.Port, _czkem))
                    {

                        _czkem.SSR_GetUserInfo(1, employee.PersonalNum, out _, out _, out _, out _);

                        var res = _czkem.GetStrCardNumber(out var cardData);

                        MessageBox.Show(@SaveCardData(res, cardNumber, cardData, employee), @"پیام", MessageBoxButtons.OK, MessageBoxIcon.None);
                        DeleteGuestFromDevice(employee.PersonalNum,device);
                    }

                }


                //messeage += SaveCardData(res, (int)rowHandle, cardData, employee);
            }
            catch (Exception exp)
            {

                throw;
            }
        }

        private string SaveCardData(bool res,int cardNumber, string cardData, Employee employee)
        {
            try
            {
                CardBLL _cardBll = new CardBLL();
                EmployeeBLL _employeeBll = new EmployeeBLL();
                Card card = new Card();
                
                if (!res)
                {
                    return @"داده ای از دستگاه دریافت نشد ";
                }

                if (_cardBll.CardReserved(cardData))
                {
                    return @" این اطلاعات کارت یک بار ذخیره شده";
                }
                if (res && cardData != "0")
                {
                    employee.HasCard = true;
                    _employeeBll.SetHasCard(employee.ID);
                    card.CardData = cardData;
                    card.CardNumber = cardNumber;
                    card.IsGuest = true;
                    card.EmpID = new EmployeeBLL().SelectOneEmployees(employee.PersonalNum).ID;
                    if (_cardBll.ExistCard(card.EmpID))
                        _cardBll.UpdateGuestCard(card);
                    else
                    {
                        _cardBll.InsertCardData(card);
                    }
                    return @" اطلاعات کارت ذخیره شد";

                    

                    //Delete Guest

                }

                if (cardData == "0")
                {
                    return @"اطلاعات کارت این شخص در دستگاه وجود ندارد ";
                }

                return " ";
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return e.Message;
            }
        }

        private void DeleteGuestFromDevice(string personalNum,Device device)
        {
            CZKEM czk = new CZKEM();
            if (czk.Connect_Net(device.IP, (int)device.Port))
            {
                var r = czk.SSR_DeleteEnrollData(1, personalNum , 12);
            }
        }

        private void BtnRecieve_Click(object sender, EventArgs e)
        {
            try
            {
                CZKEM _czkem = new CZKEM();
                GuestBLL guestBll = new GuestBLL(); 
                DeviceBLL deviceBll = new DeviceBLL();
                EmployeeBLL employeeBLL = new EmployeeBLL();
                var fromcardNumber = Convert.ToInt32(CounterFrom.Text);
                var tocardNumber = Convert.ToInt32(CounterTo.Text);
                var cardList = guestBll.CreateListCard(fromcardNumber, tocardNumber);
                gridViewGuest.DataSource = cardList;


                var device = deviceBll.SelectOneDevices(cmbEncoder.SelectedValue.ToString());
                var empId = 0;

                for (var cardNumber = fromcardNumber; cardNumber <= tocardNumber; cardNumber++)
                {
                    var employee = employeeBLL.SelectOneEmployees(Convert.ToString(99999999 + cardNumber));
                    if (device.DeviceType.Type == "ZK")
                    {
                        if (ConnectToDevice(device.IP, device.Port, _czkem))
                        {

                            _czkem.SSR_GetUserInfo(1, employee.PersonalNum, out _, out _, out _, out _);

                            var res = _czkem.GetStrCardNumber(out var cardData);
                            grdviewGuest.SetRowCellValue(cardNumber - fromcardNumber, Progressbar, 100);
                            MessageBox.Show(@SaveCardData(res, cardNumber, cardData, employee), @"پیام", MessageBoxButtons.OK, MessageBoxIcon.None);

                            DeleteGuestFromDevice(employee.PersonalNum, device);
                        }

                    }

                }
                
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}