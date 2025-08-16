using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Deployment.Application;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;
using DevExpress.CodeParser;
using Model;
using UI;
using zkemkeeper;

namespace Eco
{
    public partial class FrmGetInfo : Form
    {
        private readonly EmployeeBLL _employeeBll = new EmployeeBLL();

        private readonly Device _device;
        private readonly CZKEMClass _czkem = new CZKEMClass();
        private bool _bIsConnected = false;
        public int MachineNumber { get; }

        private int[] _progressbarIndex;

        private List<EmployeeDto> _employees;
        private string[] _sendingResult;

        private ThreadStart GertInfoThreadStart;
        private Thread getInfoThread;


        public FrmGetInfo()
        {
            InitializeComponent();

        }

        private void IntialProgressbarIndex(int employeeCount)
        {
            _progressbarIndex = new int[employeeCount];
            for (var i = 0; i < _progressbarIndex.Length; i++)
            {
                _progressbarIndex[i] = 0;
            }
        }

        public FrmGetInfo(Device device)
        {
            try
            {
                this._device = device;
                _employees = _employeeBll.SelectEmployeesList();
                MachineNumber = 1;
                InitializeComponent();

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        private void SetProgressBar()
        {
            for (var i = 0; i < _progressbarIndex.Length; i++)
            {
                grdGetInfo.SetRowCellValue(i, basicInfoCol, _progressbarIndex[i]);
            }
        }

        private void IntialSendingResult()
        {
            _sendingResult = new string[_employees.Count];
            for (var i = 0; i < _sendingResult.Length; i++)
            {
                _sendingResult[i] = " ";
            }
        }

        private void SetSendingResult()
        {
            try
            {
                for (var i = 0; i < _sendingResult.Length - 1; i++)
                {

                    grdGetInfo.SetRowCellValue(i, message, _sendingResult[i]);

                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

        }

        private void EmptyProgressBar()
        {
            try
            {
                for (var i = 0; i < _employees.Count; i++)
                {
                    grdGetInfo.SetRowCellValue(i, basicInfoCol, 0);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            getInfoThread.Abort();
            Close();
        }

        private List<Employee> GetSelectedEmployees()
        {
            object[] result = new object[] { };
            this.Invoke((MethodInvoker)delegate
           {
               var selectedEmployee = grdGetInfo.GetSelectedRows();
               result = new object[selectedEmployee.Length];

               for (var i = 0; i < selectedEmployee.Length; i++)
               {
                   var rowHandle = selectedEmployee[i];

                   if (!grdGetInfo.IsGroupRow(rowHandle))
                   {
                       result[i] = grdGetInfo.GetRowCellValue(rowHandle, "ID");
                   }
                   else
                   {
                       result[i] = -1; // default value 
                   }
               }

           });
            return _employeeBll.SelectEmployees(result);
        }


        private void StartGetInfoThread()
        {
            GertInfoThreadStart = new ThreadStart(GetInfo);
            getInfoThread = new Thread(GertInfoThreadStart);
            getInfoThread.Start();
        }

        private void GetInfo()
        {
            try
            {
                DevExpress.XtraGrid.Views.Base.ColumnView View = grdGetInfo.Columns.View;

                if (new DeviceBLL().Ping(_device.IP, _device.Port))
                {
                    if (ConnectToDevice())
                    {
                        int[] selectedEmployee = new int[] { };
                        gridGetInfo.BeginInvoke(new Action(() =>
                        {
                            selectedEmployee = View.GetSelectedRows();
                        }));
                        int j = 0;
                        foreach (var employee in GetSelectedEmployees())
                        {
                            string messeage = "";
                            var rowHandle = selectedEmployee[j];
                            if (chkBasicInfo.Checked)
                            {
                                _czkem.SSR_GetUserInfo(1, employee.PersonalNum, out _, out _, out _, out _);

                                var res = _czkem.GetStrCardNumber(out var cardData);

                                messeage += SaveCardData(res, (int)rowHandle, cardData, employee);


                                gridGetInfo.BeginInvoke(new Action(() =>
                                {
                                    View.SetRowCellValue((int)rowHandle, basicInfoCol, 20);
                                }));

                            }

                            if (chkFinger.Checked)
                            {
                                bool getLeastOneFinger = false;
                                for (int i = 0; i < 10; i++)
                                {
                                    var res = GetFinger(employee.PersonalNum, i);
                                    if (res == 0)
                                    {
                                        messeage += @" انگشت شماره " + (i + 1) + "،";
                                        getLeastOneFinger = true;
                                    }
                                }

                                if (getLeastOneFinger)
                                {
                                    messeage += @" دریافت شد";
                                }


                                gridGetInfo.BeginInvoke(new Action(() =>
                                {
                                    View.SetRowCellValue((int)rowHandle, basicInfoCol, 50);
                                }));

                            }

                            if (chkFace.Checked)
                            {

                                gridGetInfo.BeginInvoke(new Action(() =>
                                {
                                    messeage += GetFace(employee);
                                    View.SetRowCellValue((int)rowHandle, basicInfoCol, 80);
                                }));
                            }


                            gridGetInfo.BeginInvoke(new Action(() =>
                            {
                                View.SetRowCellValue((int)rowHandle, basicInfoCol, 100);
                                View.SetRowCellValue((int)rowHandle, message, messeage);
                            }));


                            this.BeginInvoke(new Action(() =>
                            {
                                // SetSendingResult();
                                gridGetInfo.Refresh();
                            }));

                            j++;

                        }

                        this.BeginInvoke(new Action(() =>
                        {
                            btnGet.Enabled = true;
                            MessageBox.Show(@"اتمام  دریافت اطلاعات", @"پیام", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }));


                    }
                    else
                    {
                        btnGet.Enabled = true;
                        MessageBox.Show(@"دستگاه به شبکه متصل است اما امکان برقراری ارتباط وجود ندارد", @"پیام", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                }
                else
                {
                    this.BeginInvoke(new Action(() =>
                    {
                        btnGet.Enabled = true;
                        MessageBox.Show(@"از اتصال دستگاه مورد نظر به شبکه اطمینان حاصل کنید", @"پیام", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }));
                }



            }
            catch (Exception e)
            {
                Console.WriteLine(e);

            }

        }

        private void btnGet_Click(object sender, EventArgs e)
        {
            try
            {
                btnGet.Enabled = false;
                this.Invoke((MethodInvoker)StartGetInfoThread);


            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                throw;
            }
        }

        private int GetFinger(string fingerEmpId, int fingerNum)
        {
            try
            {
                string data;
                int length;
                var result = false;
                var employeeBll = new EmployeeBLL();
                var fingerBll = new FingerBLL();


                result = _czkem.SSR_GetUserTmpStr(MachineNumber, fingerEmpId, fingerNum + (9 - (2 * fingerNum)), out data, out length);

                if (result)
                {
                    var finger = new Finger()
                    {
                        FingerNum = fingerNum,
                        DataLength = length,
                        DataStr = data,
                        EmpID = employeeBll.SelectOneEmployees(fingerEmpId).ID,
                        PdpID = _device.ID.ToString()
                    };
                    fingerBll.InsertFingerToDb(finger);
                    employeeBll.SetHasFinger((int)finger.EmpID);

                    return 0;
                }
                else
                {
                    return 1;
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return -1;
            }
        }



        private string GetFace(Employee employee)
        {
            try
            {
                FaceBll faceBll = new FaceBll();
                string tempData = "";
                int tempLength = 0;
                Byte[] photoData = new Byte[300 * 300];
                int photoSize = 0;

                var res = _czkem.GetUserFaceStr(MachineNumber, employee.PersonalNum, 50, ref tempData, ref tempLength);

                var result = _czkem.GetUserFacePhotoByName(MachineNumber, employee.PersonalNum + ".jpg", out photoData[0], out photoSize);

                if (res & result)
                {
                    if (FaceBll.ExistEmployeeFace(employee.ID))
                    {

                        if (faceBll.UpdateFace(new Face()
                        {
                            FaceData = tempData,
                            EmpId = employee.ID,
                            PersonalNum = employee.PersonalNum,
                            image = photoData
                        }))
                        {
                            return @"  چهره با موفقیت  ذخیره شد ";
                        }
                        else
                        {
                            return @" این تصویر از قبل وجود دارد از  پروفایل شخص جهت دریافت چهره جدید استفاده کنید ";
                        }
                    }
                    else
                    {
                        if (faceBll.InsertFace(new Face()
                        {
                            FaceData = tempData,
                            EmpId = employee.ID,
                            PersonalNum = employee.PersonalNum,
                            image = photoData
                        }))
                        {
                            return @" چهره با موفقیت  ذخیره شد ";
                        }
                    }

                }
                else
                {
                    return @" اطلاعات چهره در دستگاه وجود ندارد ";
                }
                return "";
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return e.Message;
            }
        }

        private string SaveCardData(bool res, int row, string cardData, Employee employee)
        {
            try
            {
                CardBLL _cardBll = new CardBLL();
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
                    card.EmpID = new EmployeeBLL().SelectOneEmployees(employee.PersonalNum).ID;
                    _cardBll.InsertCardData(card);
                    _employeeBll.SetHasCard((int)card.EmpID);
                    return @" اطلاعات کارت ذخیره شد";
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

        public bool ConnectToDevice()
        {
            int idwErrorCode = 0;


            _bIsConnected = _czkem.Connect_Net(_device.IP, (int)_device.Port);
            if (_bIsConnected)
                return true;
            return false;
        }

        private void FrmGetInfo_Load(object sender, EventArgs e)
        {
            CheckForIllegalCrossThreadCalls = false;

            BindGrid();
            IntialSendingResult();
            SetSendingResult();
            IntialProgressbarIndex(_employees.Count);
            SetProgressBar();
        }

        private void BindGrid()
        {
            try
            {
                gridGetInfo.DataSource = _employees;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        private void FrmGetInfo_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                getInfoThread.Abort();
                this.Close();
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
            }

        }
    }
}
