using System;
using System.Windows.Forms;
using BLL;
using DevExpress.XtraScheduler;
using Model;

namespace Eco
{
    public partial class FrmAccessTypeMenu : Form
    {
        private readonly DayScheduleBll _dayScheduleBll = new DayScheduleBll();
        private readonly SchedulerControl _timeLine;
        public readonly AccessTypeBll AccessTypeBll = new AccessTypeBll();


        //test

        //  public Appointment apttest = new Appointment();
        public FrmAccessTypeMenu(SchedulerControl timeLine)
        {
            _timeLine = timeLine;
            InitializeComponent();
        }

        public DaySchedule DaySch { get; set; }

        private void FrmAccessTypeMenu_Load(object sender, EventArgs e)
        {
            cmbAccessType.ValueMember = "ID";
            cmbAccessType.DisplayMember = "Name";
            cmbAccessType.DataSource = AccessTypeBll.SelectAccessType();
        }


        private void btnOk_Click(object sender, EventArgs e)
        {
            var apt = _timeLine.Storage.CreateAppointment(AppointmentType.Normal);
            apt.Start = _timeLine.SelectedInterval.Start;
            if (_timeLine.SelectedInterval.End == Convert.ToDateTime("12/12/1398 " + "00:00:00"))
            {
                apt.End = Convert.ToDateTime("12/12/1398 " + ConvertTime("235959"));
            }
            else
            {
                apt.End = _timeLine.SelectedInterval.End;
            }

            apt.ResourceId = _timeLine.SelectedResource.Id;

            var timeInterval = new TimeInterval(apt.Start, apt.End);

            var sameApt = _timeLine.SelectedAppointments.GetAppointments(timeInterval);


            var startTime = apt.Start.TimeOfDay.ToString().Replace(":", string.Empty);
            var endTime = apt.End.TimeOfDay.ToString().Replace(":", string.Empty);
            var asctype = 0;

            if (cmbAccessType.SelectedValue.ToString() == "1")
            {
                apt.LabelId = 1;
                apt.Subject = "ورود آزاد";
                apt.Description = "";
                asctype = 1;
            }

            if (cmbAccessType.SelectedValue.ToString() == "2")
            {
                apt.LabelId = 2;
                apt.Subject = "خروج آزاد";
                apt.Description = "";
                asctype = 2;
            }

            if (cmbAccessType.SelectedValue.ToString() == "3")
            {
                apt.LabelId = 3;
                apt.Subject = "ورود و خروج آزاد";
                apt.Description = "";
                asctype = 3;
            }

            if (cmbAccessType.SelectedValue.ToString() == "4")
            {
                apt.LabelId = 4;
                apt.Subject = "ورود و خروج ممنوع";
                apt.Description = "";
                asctype = 4;
            }

            var daySch = new DaySchedule
            {
                StartTime = startTime,
                EndTime = endTime,
                AccessTypeID = asctype
            };

            if (sameApt.Count > 0)
            {
                daySch.ID = sameApt[0].StatusId;
            }

            // apt.StatusId = _dayScheduleBll.InsertDayScheduler(daySch);

            DaySch = daySch;
            if (sameApt.Count > 0)
            {
                if (sameApt[0].Start == apt.Start && sameApt[0].End == apt.End)
                {
                    _timeLine.SelectedAppointments[0].LabelId = apt.LabelId;
                    _timeLine.SelectedAppointments[0].Subject = apt.Subject;
                    _timeLine.SelectedAppointments[0].Description = apt.Description;
                }
                DialogResult = DialogResult.Retry;
            }
            else
            {
                _timeLine.Storage.Appointments.Add(apt);
                DialogResult = DialogResult.OK;
            }
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            try
            {
                if (_timeLine.SelectedAppointments.Count == 0) return;
                if (_timeLine.SelectedAppointments[0].StatusId != 0)
                    _dayScheduleBll.DeleteDayScheduler(_timeLine.SelectedAppointments[0].StatusId);
                _timeLine.DeleteAppointment(_timeLine.SelectedAppointments[0]);
            }
            catch (Exception exception)
            {
                throw;
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
    }
}