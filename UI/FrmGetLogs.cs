using BLL;
using Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using zkemkeeper;

namespace Eco
{
    public partial class FrmGetLogs : Form
    {
        public FrmGetLogs()
        {
            InitializeComponent();
            FillcmbDevice();
        }

        private async void BtnGet_Click(object sender, EventArgs e)
        {
            var deviceBll = new DeviceBLL();
            var id = (int)cmbbxSelectEncoder.SelectedValue;
            var device = deviceBll.SelectOneDevices(id);

            if (device == null)
            {
                MessageBox.Show(@"یک دستگاه از منوی بالا انتخاب کنید", @"پیام", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            var dateOfLastTrafficDate = ConvertDateToMiladi(txtFRomDate.Text + " " + "00:00:00");
            var timeOfTrafficDate = ConvertDateToMiladi(txtToDate.Text + " " + "23:59:59");

            var startdate = GetDateTime(dateOfLastTrafficDate);
            var endtdate = GetDateTime(timeOfTrafficDate);
            this.Enabled = false;
            var result =await GetOfflineLogAndInsert(device, startdate, endtdate);
            if (result >= 0)
            {
                this.Enabled = true;
                MessageBox.Show($"تعداد {result} لاگ از دستگاه دریافت شد", @"پیغام", MessageBoxButtons.OK,
                    MessageBoxIcon.Information, MessageBoxDefaultButton.Button1,
                    MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
            }
            if (result < -1)
            {
                this.Enabled = true;
                MessageBox.Show($"اتصال با دستگاه برقرار نشد", @"هشدار", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1,
                    MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
            }

        }

        private DateTime ConvertDateToMiladi(string dateOfLastTraffic)
        {
            string[] date = dateOfLastTraffic.Substring(0, 10).Split('/');
            string[] time = dateOfLastTraffic.Substring(11, 8).Split(':');
            PersianCalendar pc = new PersianCalendar();
            DateTime dt = new DateTime(Convert.ToInt32(date[0]), Convert.ToInt32(date[1]), Convert.ToInt32(date[2])
                , Convert.ToInt32(time[0]), Convert.ToInt32(time[1]), Convert.ToInt32(time[2]), pc);
            return dt;
        }

        private void FillcmbDevice()
        {
            try
            {
                var deviceBll = new DeviceBLL();
                var dt = ConvertToDataTable(deviceBll.SelectDevices());

                var device0 = new Device
                {
                    ID = 0,
                    DeviceName = "انتخاب کنید"
                };

                var row1 = dt.NewRow();
                row1["ID"] = device0.ID;
                row1["DeviceName"] = device0.DeviceName;
                dt.Rows.InsertAt(row1, 0);

                cmbbxSelectEncoder.DataSource = dt;
                cmbbxSelectEncoder.DisplayMember = "DeviceName";
                cmbbxSelectEncoder.ValueMember = "ID";
            }
            catch (Exception ex)
            {
                throw;
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

        private string verifymethodMode(int verifymethod)
        {
            try
            {
                switch (verifymethod)
                {
                    case 1:
                        return "Finger";
                    case 2://Pin
                        return "Num";
                    case 3://Password
                        return "Num1";
                    case 4:
                        return "Card";
                    case 5:
                        return "Finger/pw";
                    case 6:
                        return "Finger/Card";
                    case 7:
                        return "pw/Card";
                    case 8:
                        return "Pin&Finger";
                    case 9:
                        return "Finger&pw";
                    case 10:
                        return "Finger&Card";
                    case 11:
                        return "pw&Card";
                    case 12:
                        return "Finger&Pw&Card";
                    case 13:
                        return "Pin&Finger&pw";
                    case 14:
                        return "Finger&Card/Pin";
                    case 15:
                        return "Face";
                    default:
                        return "";
                }
            }
            catch (Exception e)
            {
                return "";
            }

        }

        private string GetDateTime(DateTime time)
        {
            try
            {
                var date = time.ToString("yyyy/MM/dd HH:mm:ss");
                var dateTime = date.Substring(0, 4) + "-" + date.Substring(5, 2) + "-" +
                               date.Substring(8, 2) + " "
                               + (time.Hour > 9 ? time.Hour.ToString() : '0' + time.Hour.ToString()) + ":"
                               + (time.Minute > 9 ? time.Minute.ToString() : '0' + time.Minute.ToString()) + ":"
                               + (time.Second > 9 ? time.Second.ToString() : '0' + time.Second.ToString());
                return dateTime;
            }
            catch (Exception e)
            {
                return "";
            }
        }

        private string GetTime(int dwHour, int dwMinute, int dwSecond)
        {
            try
            {
                return (dwHour > 9 ? dwHour.ToString() : '0' + dwHour.ToString()) + ":" + (dwMinute > 9 ? dwMinute.ToString() : '0' + dwMinute.ToString()) + ":" + (dwSecond > 9 ? dwSecond.ToString() : '0' + dwSecond.ToString());

            }
            catch (Exception e)
            {
                return "";
            }
        }

        public string GetTodayShamsiDate(int y, int m, int d)
        {
            try
            {
                PersianCalendar _perCalendar = new PersianCalendar();
                DateTime date = new DateTime(y, m, d);
                var year = _perCalendar.GetYear(date).ToString(CultureInfo.InvariantCulture);
                var month = _perCalendar.GetMonth(date).ToString(CultureInfo.InvariantCulture);
                var day = _perCalendar.GetDayOfMonth(date).ToString(CultureInfo.InvariantCulture);
                day = (day.Length == 1) ? "0" + day : day;
                month = (month.Length == 1) ? "0" + month : month;
                return ConvertDate((year + month + day));
            }
            catch (Exception e)
            {
                return "";
            }

        }

        private string ConvertDate(string taDate)
        {
            try
            {
                string Date;
                Date = taDate.Substring(0, 4);
                Date += "/";
                Date += taDate.Substring(4, 2);
                Date += "/";
                Date += taDate.Substring(6, 2);

                return Date;
            }
            catch (Exception e)
            {
                return "";
            }

        }

        private async Task<int> GetOfflineLogAndInsert(Device device, string startdate, string endtdate)
        {
            CZKEM eczema = new CZKEM();
            EmployeeBLL employeeBLL = new EmployeeBLL();
            TrafficLogBLL trafficLogBLL = new TrafficLogBLL();
            int workCode = 0;


            var connected = eczema.Connect_Net(device.IP, (int)device.Port);
            if (connected)
            {
                var d = eczema.ReadTimeGLogData(1, startdate, endtdate);
                var count = 0;

                while (d)
                {
                    var a = eczema.SSR_GetGeneralLogData(1, out var personalNum, out var verifyMode, out var InOrOut, out var year, out var Month, out var day,
                        out var hour, out var minute, out var second, ref workCode);
                    if (!a)
                        break;
                    Employee emp = employeeBLL.SelectEmployeeWithPersonalNumber(personalNum);
                    if (emp == null)
                        continue;
                    string reqtype = verifymethodMode(verifyMode);
                    TrafficLog t = new TrafficLog()
                    {
                        Date = GetTodayShamsiDate(year, Month, day),
                        Time = GetTime(hour, minute, second),
                        EmpID = emp.ID,
                        PersonalNum = personalNum,
                        Access = true,
                        status = false,
                        DeviceID = device.ID,
                        ReqType = reqtype,
                        Type = InOrOut,
                    };
                    if (trafficLogBLL.SelectLog(t).Count > 0)
                    {
                        continue;
                    }
                    else
                    {
                        trafficLogBLL.InsertTrafficLog(t);
                        count++;
                    }
                    //check db if we havw same traffic log continue


                }
                return count;
            }
            return -1;
        }
    }
}
