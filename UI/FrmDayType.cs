using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;
using BLL;
using DevExpress.XtraScheduler;
using Model;

namespace Eco
{
    public partial class FrmDayType : Form
    {
        private readonly List<DaySchedule> _daySchedules = new List<DaySchedule>();
        private readonly DayTypeBll _dayTypeBll = new DayTypeBll();
        private string _status;


        public FrmDayType()
        {
            _status = "Add";
            InitializeComponent();
        }

        private void FrmDayType_Load(object sender, EventArgs e)
        {
            TimeLine.Show();
            TimeLine.ActiveViewType = SchedulerViewType.Timeline;
            TimeLine.OptionsView.HideSelection = true;

            LoadDayTypeComboBox();

            TimeLine.Storage.Appointments.Clear();
        }

        private void LoadDayTypeComboBox()
        {
            var dt = ConvertToDataTable(_dayTypeBll.SelectAll());
            const string text = "انتخاب کنید";
            var row = dt.NewRow();
            row["Name"] = text;
            dt.Rows.InsertAt(row, 0);

            comboDayType.DataSource = dt;
            comboDayType.ValueMember = "ID";
            comboDayType.DisplayMember = "Name";
        }


        private void schedulerControl1_PopupMenuShowing(object sender, PopupMenuShowingEventArgs e)
        {
            e.Menu.Items.Clear();
        }


        private void TimeLine_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                foreach (var apt in TimeLine.Storage.Appointments.Items)
                {
                    if (TimeLine.SelectedInterval.Start > apt.Start && TimeLine.SelectedInterval.Start < apt.End
                        && TimeLine.SelectedInterval.End > apt.Start && TimeLine.SelectedInterval.Start < apt.End)
                        return;
                }

                var frmAccessTypeMenu = new FrmAccessTypeMenu(TimeLine);
                var result = frmAccessTypeMenu.ShowDialog();


                if (result == DialogResult.OK)
                {
                    _daySchedules.Add(frmAccessTypeMenu.DaySch);
                }
                
                if (result == DialogResult.Retry)
                {
                    _daySchedules.Add(frmAccessTypeMenu.DaySch);
                    
                    foreach (var daysch in _daySchedules)
                    {
                        if (daysch.ID == frmAccessTypeMenu.DaySch.ID)
                        {
                            daysch.AccessTypeID = frmAccessTypeMenu.DaySch.AccessTypeID;
                        }
                    }
                }
            }
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            var dayScheduleBll = new DayScheduleBll();
            var dayTypeBll = new DayTypeBll();

            if (_status == "Add")
            {
                if (txtName.Text == string.Empty)
                {
                    MessageBox.Show(@"نام نوع روز را مشخص کنید", @"پیغام", MessageBoxButtons.OK,
                        MessageBoxIcon.None, MessageBoxDefaultButton.Button1,
                        MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                }
                else
                {
                    var dayType = new DayType
                    {
                        Name = txtName.Text
                    };

                    var daytypeId = dayTypeBll.InsertDayType(dayType);

                    foreach (var dayschedule in _daySchedules)
                    {
                        dayschedule.DayTypeID = daytypeId;

                        dayScheduleBll.InsertDayScheduler(dayschedule);
                    }
                    MessageBox.Show(@"عملیات با موفقیت انجام شد", @"پیغام", MessageBoxButtons.OK,
                        MessageBoxIcon.None, MessageBoxDefaultButton.Button1,
                        MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);

                    ClearForm();
                }
            }
            if (_status == "Edit")
            {
                if (txtName.Text == string.Empty)
                {
                    MessageBox.Show(@"نام نوع روز را مشخص کنید", @"پیغام", MessageBoxButtons.OK,
                        MessageBoxIcon.None, MessageBoxDefaultButton.Button1,
                        MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                }
                else
                {
                    var dayType = new DayType
                    {
                        Name = txtName.Text,
                        ID = Convert.ToInt32(comboDayType.SelectedValue)
                    };

                    var daytypeId = dayTypeBll.UpdateDayType(dayType);

                    foreach (var dayschedule in _daySchedules)
                    {
                        dayschedule.DayTypeID = (int?) daytypeId;

                        dayScheduleBll.DeleteDayScheduler(dayschedule.ID);

                        dayScheduleBll.InsertDayScheduler(dayschedule);
                        // dayScheduleBll.UpdateDaySch(dayschedule);
                    }

                    MessageBox.Show(@"عملیات با موفقیت انجام شد", @"پیغام", MessageBoxButtons.OK,
                        MessageBoxIcon.None, MessageBoxDefaultButton.Button1,
                        MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                }
            }
        }

        private void ClearForm()
        {
            LoadDayTypeComboBox();
            txtName.Text = string.Empty;
            TimeLine.Storage.Appointments.Clear();
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


        private void comboDayType_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                if (comboDayType.SelectedIndex == 0)
                {
                    _status = "Add";
                    ClearForm();
                    return;
                }
                _status = "Edit";
                var dayScheduleBll = new DayScheduleBll();
                var daySchedules =
                    dayScheduleBll.SelectDaySchWithDayTypeId(Convert.ToInt32(comboDayType.SelectedValue.ToString()));

                txtName.Text = comboDayType.Text;
                SetToScheduler(daySchedules);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
        }


        private void SetToScheduler(List<DaySchedule> daySchedules)
        {
            try
            {
                TimeLine.Storage.Appointments.Clear();
                foreach (var daysch in daySchedules)
                {
                    var apt = TimeLine.Storage.CreateAppointment(AppointmentType.Normal);//3/2/2020
                    apt.Start = Convert.ToDateTime("2020-03-02" + " "+ ConvertTime(daysch.StartTime));

                    if (daysch.EndTime == "235959")
                    {
                        apt.End = Convert.ToDateTime("2020-03-02" + " " + ConvertTime("000000"));
                    }
                    else
                    {
                        apt.End = Convert.ToDateTime("2020-03-02" + " " + ConvertTime(daysch.EndTime));
                    }

                    apt.StatusId = daysch.ID;

                    apt.LabelId = (int) daysch.AccessTypeID;

                    apt.Subject = ConvertToAccessTypeName(daysch.AccessTypeID);
                    TimeLine.Storage.Appointments.Add(apt);
                }
            }
            catch (Exception ex)
            {
               Console.WriteLine(ex.Message);
            }
        }


        private string ConvertTime(string taTime)
        {
            var time = taTime.Substring(0, 2);
            time += ":";
            time += taTime.Substring(2, 2);
            time += ":";
            time += taTime.Substring(4, 2);
            return time;
        }


        private string ConvertToAccessTypeName(int? id)
        {
            try
            {
                switch (id)
                {
                    case 1:
                        return "ورود آزاد";
                    case 2:
                        return "خروج آزاد";
                    case 3:
                        return "ورود و خروج آزاد";
                    case 4:
                        return "ورود و خروج ممنوع";
                    default:
                        return "";
                }
            }
            catch (Exception)
            {
                return "";
                throw;
            }
        }
    }
}