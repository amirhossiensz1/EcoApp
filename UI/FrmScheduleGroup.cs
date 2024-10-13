using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using BLL;
using DevExpress.XtraEditors;
//using FarsiLibrary.Utils;
using Model;
using Telerik.WinControls;
using Telerik.WinControls.UI.Gauges;
using ItemCheckEventArgs = DevExpress.XtraEditors.Controls.ItemCheckEventArgs;
using zkemkeeper;

namespace Eco
{
    public partial class FrmScheduleGroup : Form
    {
        private readonly ScheduleGroup _schGroup = new ScheduleGroup();
        private CZKEMClass _czkem;

        public FrmScheduleGroup()
        {
            InitializeComponent();
            EditFlag = false;
        }

        //   readonly WeekSchedule weekSchedule = new WeekSchedule();




        public bool EditFlag { get; set; }

        public int CheckedItemIndex { get; set; }


        private void FrmScheduleGroup_Load(object sender, EventArgs e)
        {
            try
            {
                LoadHolidayCombobox();
                LoadWeekdayCombobox();
                LoadScheduleGroupListBox();
                SetYearSpinEditor();
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
        }

        private void SetYearSpinEditor()
        {
            var persianDate = DateTime.Now;
            YearSpinEditor.Value = Convert.ToInt32(persianDate.Date.ToString().Substring(6, 4));
        }

        private void LoadHolidayCombobox()
        {
            try
            {
                var holiDaysGroupBll = new HoliDaysGroupBll();
                var holiDaysGroups = holiDaysGroupBll.SelectAll();

                var dtHolidays = ConvertToDataTable(holiDaysGroups);

                var holiDaysGroup = new HoliDaysGroup();
                holiDaysGroup.ID = 0;
                holiDaysGroup.Name = "انتخاب کنید";


                var row = dtHolidays.NewRow();
                row["ID"] = holiDaysGroup.ID;
                row["Name"] = holiDaysGroup.Name;
                dtHolidays.Rows.InsertAt(row, 0);

                comboHoliDayGroup.DataSource = dtHolidays;
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void LoadWeekdayCombobox()
        {
            try
            {
                var dayTypeBll = new DayTypeBll();
                var daytypeList = dayTypeBll.SelectAll();


                var dtSat = ConvertToDataTable(daytypeList);

                var dtSun = ConvertToDataTable(daytypeList);

                var dtMon = ConvertToDataTable(daytypeList);

                var dtTu = ConvertToDataTable(daytypeList);

                var dtWed = ConvertToDataTable(daytypeList);

                var dtThr = ConvertToDataTable(daytypeList);

                var dtfri = ConvertToDataTable(daytypeList);

                var dayType = new DayType
                {
                    ID = 0,
                    Name = "انتخاب کنید"
                };

                var row = dtSat.NewRow();
                row["ID"] = dayType.ID;
                row["Name"] = dayType.Name;
                dtSat.Rows.InsertAt(row, 0);

                row = dtSun.NewRow();
                row["ID"] = dayType.ID;
                row["Name"] = dayType.Name;
                dtSun.Rows.InsertAt(row, 0);

                row = dtMon.NewRow();
                row["ID"] = dayType.ID;
                row["Name"] = dayType.Name;
                dtMon.Rows.InsertAt(row, 0);

                row = dtTu.NewRow();
                row["ID"] = dayType.ID;
                row["Name"] = dayType.Name;
                dtTu.Rows.InsertAt(row, 0);

                row = dtWed.NewRow();
                row["ID"] = dayType.ID;
                row["Name"] = dayType.Name;
                dtWed.Rows.InsertAt(row, 0);

                row = dtThr.NewRow();
                row["ID"] = dayType.ID;
                row["Name"] = dayType.Name;
                dtThr.Rows.InsertAt(row, 0);

                row = dtfri.NewRow();
                row["ID"] = dayType.ID;
                row["Name"] = dayType.Name;
                dtfri.Rows.InsertAt(row, 0);

                combosat.DataSource = dtSat;
                combosat.ValueMember = "ID";
                combosat.DisplayMember = "Name";

                comboSun.DataSource = dtSun;
                comboSun.ValueMember = "ID";
                comboSun.DisplayMember = "Name";


                comboMon.DataSource = dtMon;
                comboMon.ValueMember = "ID";
                comboMon.DisplayMember = "Name";


                combotu.DataSource = dtTu;
                combotu.ValueMember = "ID";
                combotu.DisplayMember = "Name";

                combowed.DataSource = dtWed;
                combowed.ValueMember = "ID";
                combowed.DisplayMember = "Name";

                combothr.DataSource = dtThr;
                combothr.ValueMember = "ID";
                combothr.DisplayMember = "Name";

                combofri.DataSource = dtfri;
                combofri.ValueMember = "ID";
                combofri.DisplayMember = "Name";
            }
            catch (Exception)
            {
                throw;
            }
        }


        public DataTable ConvertToDataTable<T>(IList<T> data)
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


        private void BtnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }


        private void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                int schGroupId;

                if (EditFlag)
                {
                    schGroupId = UpdateSchGroup();

                    if (schGroupId == -1)
                    {
                        MessageBox.Show(@"عملیات با ویرایش انجام نشد", @"هشدار", MessageBoxButtons.OK,
                            MessageBoxIcon.Error, MessageBoxDefaultButton.Button1,
                            MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                        return;
                    }

                    UpdateWeekSch(schGroupId);

                    var rst = UpdateHolidaySchGroup(schGroupId);

                    if (rst >= 0)
                    {
                        CreateSchFile(schGroupId, YearSpinEditor.Text);
                        SendTimeZoneToDevices(schGroupId);


                        SendHolidayToZkDevice(schGroupId);

                        MessageBox.Show(@"عملیات با موفقیت انجام شد", @"پیغام", MessageBoxButtons.OK,
                            MessageBoxIcon.None, MessageBoxDefaultButton.Button1,
                            MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                        LoadScheduleGroupListBox();

                        chkSchGroupListBox.SetItemCheckState(CheckedItemIndex, CheckState.Checked);
                    }
                    else
                    {
                        MessageBox.Show(@"عملیات با ویرایش انجام نشد", @"هشدار", MessageBoxButtons.OK,
                            MessageBoxIcon.Error, MessageBoxDefaultButton.Button1,
                            MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                    }
                }
                else
                {
                    schGroupId = SaveSchGroup();
                    if (schGroupId == -1) return;
                    SaveWeekSch(schGroupId);

                    var result = SaveHolidaySchGroup(schGroupId);

                    if (result >= 0)
                    {
                        CreateSchFile(schGroupId, YearSpinEditor.Text);
                        SendTimeZoneToDevices(schGroupId);

                        SendHolidayToZkDevice(schGroupId);

                        MessageBox.Show(@"عملیات با موفقیت انجام شد", @"هشدار", MessageBoxButtons.OK,
                            MessageBoxIcon.None, MessageBoxDefaultButton.Button1,
                            MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                        LoadScheduleGroupListBox();



                        ResetFrm();
                        EditFlag = false;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void SendHolidayToZkDevice(int schGroupId)
        {
            DeviceBLL deviceBll = new DeviceBLL();
            var holidaySchGroupId = (int)comboHoliDayGroup.SelectedValue;
            var holidays = new HoliDayBll().SelectHolidayByHolidayGroupId(holidaySchGroupId);

            var devices = deviceBll.SelectDevices().Where(d => d.DeviceType.ID == 4);
            foreach (var device in devices)
            {
                if (deviceBll.Ping(device.IP, device.Port))
                {
                    _czkem = new CZKEMClass();

                    if (_czkem.Connect_Net(device.IP, (int)device.Port))
                    {
                        foreach (var holiday in holidays)
                        {
                            var a = _czkem.SSR_SetHoliday(1, holiday.ID,
                                Convert.ToInt32(holiday.Date.Substring(5, 2)),
                                Convert.ToInt32(holiday.Date.Substring(8, 2)),
                                Convert.ToInt32(holiday.Date.Substring(5, 2)),
                                Convert.ToInt32(holiday.Date.Substring(8, 2)), schGroupId);
                        }
                    }
                }
            }
        }

        private void SendTimeZoneToDevices(int schGroupId)
        {
            try
            {
                DeviceBLL deviceBll = new DeviceBLL();
                WeekScheduleBll weekScheduleBll = new WeekScheduleBll();

                var weekSchedule = weekScheduleBll.SelectWeekDaysBySchGroupId(schGroupId);

                List<string> TimeZoneInfo = new List<string>();


                for (int i = 0; i < 7; i++)
                {
                    int j;

                    for (j = 0; j < weekSchedule.Count; j++)
                    {
                        if (weekSchedule[j].weekday == i)
                        {
                            if (weekSchedule[j].DayType.DaySchedules.ToList()
                                .FirstOrDefault(c => c.AccessTypeID == 3) != null)
                            {

                                TimeZoneInfo.Add(weekSchedule[j].DayType.DaySchedules.ToList()
                                                     .FirstOrDefault(c => c.AccessTypeID == 3).StartTime.Substring(0, 4)
                                                 + weekSchedule[j].DayType.DaySchedules.ToList()
                                                     .FirstOrDefault(c => c.AccessTypeID == 3).EndTime.Substring(0, 4));
                                break;
                            }
                            TimeZoneInfo.Add("00000000");
                            break;
                        }
                    }
                    if (j == weekSchedule.Count)
                        TimeZoneInfo.Add("00000000");
                }

                var devices = deviceBll.SelectDevices().Where(d => d.DeviceType.ID == 4);

                foreach (var device in devices)
                {
                    if (deviceBll.Ping(device.IP, device.Port))
                    {
                        _czkem = new CZKEMClass();

                        if (_czkem.Connect_Net(device.IP, (int)device.Port))
                        {
                            var a = _czkem.SetTZInfo(1, schGroupId, TimeZoneInfo[1] + TimeZoneInfo[2] + TimeZoneInfo[3] + TimeZoneInfo[4] + TimeZoneInfo[5] + TimeZoneInfo[6] + TimeZoneInfo[0]);
                            //if (a)
                            //    return true;
                            //return false;
                        }

                        // return false;
                    }
                    // return false;
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        private void CreateSchFile(int schGroupId, string year)
        {
            try
            {
                IDictionary<int?, List<DaySchedule>> daySchedules = new Dictionary<int?, List<DaySchedule>>();
                IDictionary<string, int> holidaysDic = new Dictionary<string, int>();
                var weekScheduleBll = new WeekScheduleBll();
                var holiDaysSchGroupBll = new HoliDaysSchGroupBll();
                var holiDayBll = new HoliDayBll();

                var weekSchedule = weekScheduleBll.SelectWeekDaysBySchGroupId(schGroupId);
                var holidaygroupId = holiDaysSchGroupBll.SelectHolidayGroupId(schGroupId);
                var holidays = holiDayBll.SelectHolidayByHolidayGroupId(holidaygroupId);

                foreach (var weekSch in weekSchedule)
                {
                    if (weekSch.weekday != null)
                        daySchedules.Add(weekSch.weekday, weekSch.DayType.DaySchedules.ToList());
                }

                foreach (var holiday in holidays)
                {
                    holidaysDic.Add(holiday.Date, holiday.ID);
                }


                var schPath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location),
                    "SCH");

                // ReSharper disable once AssignNullToNotNullAttribute
                if (!Directory.Exists(schPath))
                    Directory.CreateDirectory(schPath);
                else
                {
                    var filePath = Directory.GetFiles(schPath, schGroupId + ".sch");
                    foreach (var file in filePath)
                    {
                        File.Delete(file);
                    }
                }
                PersianCalendar pc = new PersianCalendar();
                DateTime dPersian = new DateTime();


                for (var i = 1; i <= 12; i++)
                {
                    for (var j = 1; j <= pc.GetDaysInMonth(Convert.ToInt32(year), Convert.ToInt32(i), PersianCalendar.PersianEra); j++)
                    {
                        dPersian = pc.ToDateTime(Convert.ToInt32(year), Convert.ToInt32(i), j, 0, 0, 0, 0, PersianCalendar.CurrentEra);
                        var day = (int)pc.GetDayOfWeek(dPersian);
                        day = GetDayOfWeek(day);
                        if (!daySchedules.ContainsKey(day) || holidaysDic.ContainsKey(dPersian.ToString("yyyy/mm/dd")))
                            continue;

                        foreach (var daysch in daySchedules[day])
                        {
                            if (daysch.AccessTypeID == 4) continue;
                            var sch = year + i.ToString("00") + j.ToString("00") + ";" +
                                      year + i.ToString("00") + j.ToString("00") + ";" +
                                      daysch.StartTime + ";" + daysch.EndTime + ";" +
                                      (daysch.AccessTypeID - 1) + "\r\n";
                            File.AppendAllText(schPath + "\\" + schGroupId + ".sch", sch, Encoding.ASCII);
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                if (exception.Message == "Invalid Day value")
                    Console.WriteLine(@"سال غیر کبیسه ست");
                else
                {
                    throw;
                }
            }
        }

        private int GetDayOfWeek(int day)
        {
            if (day == 6) return 0;
            return day + 1;

        }


        private int UpdateHolidaySchGroup(int schGroupId)
        {
            try
            {
                var holiDaysSchGroupBll = new HoliDaysSchGroupBll();
                var holiDaysSchGroup = new HoliDaysSchGroup();
                if ((int)comboHoliDayGroup.SelectedValue != 0)
                {
                    holiDaysSchGroup.HoliDaysGroupID = (int)comboHoliDayGroup.SelectedValue;
                    holiDaysSchGroup.SchGroupID = schGroupId;
                    return holiDaysSchGroupBll.UpdateAndAdd(holiDaysSchGroup);
                }
                holiDaysSchGroup.SchGroupID = schGroupId;
                return holiDaysSchGroupBll.Delete(holiDaysSchGroup);
            }
            catch (Exception ex)
            {
                throw;
            }
        }


        private void UpdateWeekSch(int schGroupId)
        {
            try
            {
                var weekScheduleBll = new WeekScheduleBll();

                for (var i = 0; i < 7; i++)
                {
                    var weekSchedule = new WeekSchedule();
                    weekSchedule.SchGroupID = schGroupId;
                    weekSchedule.weekday = i;

                    switch (i)
                    {
                        case 0:
                            if ((int)combosat.SelectedValue != 0)
                            {
                                weekSchedule.DayTypeID = (int)combosat.SelectedValue;
                                weekScheduleBll.UpdateAndAdd(weekSchedule);
                            }
                            else
                            {
                                weekScheduleBll.DeleteBySchId(weekSchedule);
                            }

                            break;
                        case 1:
                            if ((int)comboSun.SelectedValue != 0)
                            {
                                weekSchedule.DayTypeID = (int)comboSun.SelectedValue;
                                weekScheduleBll.UpdateAndAdd(weekSchedule);
                            }
                            else
                            {
                                weekScheduleBll.DeleteBySchId(weekSchedule);
                            }

                            break;
                        case 2:
                            if ((int)comboMon.SelectedValue != 0)
                            {
                                weekSchedule.DayTypeID = (int)comboMon.SelectedValue;
                                weekScheduleBll.UpdateAndAdd(weekSchedule);
                            }
                            else
                            {
                                weekScheduleBll.DeleteBySchId(weekSchedule);
                            }

                            break;
                        case 3:
                            if ((int)combotu.SelectedValue != 0)
                            {
                                weekSchedule.DayTypeID = (int)combotu.SelectedValue;
                                weekScheduleBll.UpdateAndAdd(weekSchedule);
                            }
                            else
                            {
                                weekScheduleBll.DeleteBySchId(weekSchedule);
                            }

                            break;
                        case 4:
                            if ((int)combowed.SelectedValue != 0)
                            {
                                weekSchedule.DayTypeID = (int)combowed.SelectedValue;
                                weekScheduleBll.UpdateAndAdd(weekSchedule);
                            }
                            else
                            {
                                weekScheduleBll.DeleteBySchId(weekSchedule);
                            }
                            break;
                        case 5:
                            if ((int)combothr.SelectedValue != 0)
                            {
                                weekSchedule.DayTypeID = (int)combothr.SelectedValue;
                                weekScheduleBll.UpdateAndAdd(weekSchedule);
                            }
                            else
                            {
                                weekScheduleBll.DeleteBySchId(weekSchedule);
                            }

                            break;
                        case 6:
                            if ((int)combofri.SelectedValue != 0)
                            {
                                weekSchedule.DayTypeID = (int)combofri.SelectedValue;
                                weekScheduleBll.UpdateAndAdd(weekSchedule);
                            }
                            else
                            {
                                weekScheduleBll.DeleteBySchId(weekSchedule);
                            }

                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private int UpdateSchGroup()
        {
            try
            {
                if (txtSchGroup.Text == string.Empty)
                {
                    MessageBox.Show(@"نام گروه زمانبندی را مشخص کنید", @"هشدار", MessageBoxButtons.OK,
                        MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1,
                        MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                    return -1;
                }
                var schGroupBll = new ScheduleGroupBll();
                //   _schGroup.ID =(int) chkSchGroupListBox.SelectedValue;
                _schGroup.Name = txtSchGroup.Text.Substring(0, txtSchGroup.Text.Length - 4);
                _schGroup.year = YearSpinEditor.Text;
                return schGroupBll.Update(_schGroup);
            }
            catch (Exception exception)
            {
                throw;
            }
        }

        private void LoadScheduleGroupListBox()
        {
            try
            {
                var schGroupBll = new ScheduleGroupBll();
                chkSchGroupListBox.DataSource = schGroupBll.SelectAllForView();
            }
            catch (Exception)
            {
                throw;
            }
        }

        private int SaveHolidaySchGroup(int schGroupId)
        {
            try
            {
                var holiDaysSchGroupBll = new HoliDaysSchGroupBll();
                var holiDaysSchGroup = new HoliDaysSchGroup();
                if ((int)comboHoliDayGroup.SelectedValue != 0)
                {
                    holiDaysSchGroup.HoliDaysGroupID = (int)comboHoliDayGroup.SelectedValue;
                    holiDaysSchGroup.SchGroupID = schGroupId;
                    return holiDaysSchGroupBll.Insert(holiDaysSchGroup);
                }
                return 0;
            }
            catch (Exception)
            {
                return -1;
                throw;
            }
        }

        private void SaveWeekSch(int schGroupId)
        {
            try
            {
                var weekScheduleBll = new WeekScheduleBll();
                var weekSchedule = new WeekSchedule();
                for (var i = 0; i < 7; i++)
                {
                    weekSchedule.SchGroupID = schGroupId;
                    weekSchedule.weekday = i;

                    switch (i)
                    {
                        case 0:
                            if ((int)combosat.SelectedValue != 0)
                            {
                                weekSchedule.DayTypeID = (int)combosat.SelectedValue;
                                weekScheduleBll.Insert(weekSchedule);
                            }

                            break;
                        case 1:
                            if ((int)comboSun.SelectedValue != 0)
                            {
                                weekSchedule.DayTypeID = (int)comboSun.SelectedValue;
                                weekScheduleBll.Insert(weekSchedule);
                            }

                            break;
                        case 2:
                            if ((int)comboMon.SelectedValue != 0)
                            {
                                weekSchedule.DayTypeID = (int)comboMon.SelectedValue;
                                weekScheduleBll.Insert(weekSchedule);
                            }

                            break;
                        case 3:
                            if ((int)combotu.SelectedValue != 0)
                            {
                                weekSchedule.DayTypeID = (int)combotu.SelectedValue;
                                weekScheduleBll.Insert(weekSchedule);
                            }

                            break;
                        case 4:
                            if ((int)combowed.SelectedValue != 0)
                            {
                                weekSchedule.DayTypeID = (int)combowed.SelectedValue;
                                weekScheduleBll.Insert(weekSchedule);
                            }

                            break;
                        case 5:
                            if ((int)combothr.SelectedValue != 0)
                            {
                                weekSchedule.DayTypeID = (int)combothr.SelectedValue;
                                weekScheduleBll.Insert(weekSchedule);
                            }

                            break;
                        case 6:
                            if ((int)combofri.SelectedValue != 0)
                            {
                                weekSchedule.DayTypeID = (int)combofri.SelectedValue;
                                weekScheduleBll.Insert(weekSchedule);
                            }

                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private int SaveSchGroup()
        {
            try
            {
                if (txtSchGroup.Text == string.Empty)
                {
                    MessageBox.Show(@"نام گروه زمانبندی را مشخص کنید", @"هشدار", MessageBoxButtons.OK,
                        MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1,
                        MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                    return -1;
                }
                var schGroupBll = new ScheduleGroupBll();

                _schGroup.Name = txtSchGroup.Text;
                _schGroup.year = YearSpinEditor.Text;
                return schGroupBll.Insert(_schGroup);
            }
            catch (Exception exception)
            {
                throw;
            }
        }

        private void ClearLinearGuageBar(RadLinearGauge radLinearGauge)
        {
            foreach (var item in radLinearGauge.Items)
            {
                if (item.GetType() == linearGaugeBar1.GetType())
                    item.Visibility = ElementVisibility.Collapsed;
            }
        }

        private void combosat_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                var dayScheduleBll = new DayScheduleBll();
                ClearLinearGuageBar(satLinearGauge);
                var daySchs = dayScheduleBll.SelectDaySchWithDayTypeId((int)combosat.SelectedValue);
                foreach (var daySch in daySchs)
                {
                    SetLinearGaugeBar(satLinearGauge, daySch);
                }
            }
            catch (Exception exception)
            {
                throw;
            }
        }

        private void SetLinearGaugeBar(RadLinearGauge radLinearGauge, DaySchedule daySch)
        {
            var linearGaugeBar = new LinearGaugeBar
            {
                AutoSize = true,
                Offset = 20F,
                Padding = new Padding(0),
                IsTopToBottom = false,
                FitToSizeMode = RadFitToSizeMode.FitToParentContent,
                Width = 20F,
                Width2 = 20F,
                RangeStart = ConvertToFloat(daySch.StartTime),
                RangeEnd = ConvertToFloat(daySch.EndTime)
            };

            switch (daySch.AccessTypeID)
            {
                case 1:
                    linearGaugeBar.BackColor = Color.FromArgb(255, 194, 190);
                    linearGaugeBar.BackColor2 = Color.FromArgb(255, 194, 190);
                    break;
                case 2:
                    linearGaugeBar.BackColor = Color.FromArgb(168, 213, 255);
                    linearGaugeBar.BackColor2 = Color.FromArgb(168, 213, 255);
                    break;
                case 3:
                    linearGaugeBar.BackColor = Color.FromArgb(193, 244, 156);
                    linearGaugeBar.BackColor2 = Color.FromArgb(193, 244, 156);
                    break;
                case 4:
                    linearGaugeBar.BackColor = Color.FromArgb(243, 228, 199);
                    linearGaugeBar.BackColor2 = Color.FromArgb(243, 228, 199);
                    break;
            }
            radLinearGauge.Items.Add(linearGaugeBar);
        }

        private void comboSun_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                var dayScheduleBll = new DayScheduleBll();
                ClearLinearGuageBar(sunLinearGauge);

                var daySchs = dayScheduleBll.SelectDaySchWithDayTypeId((int)comboSun.SelectedValue);
                foreach (var daySch in daySchs)
                {
                    SetLinearGaugeBar(sunLinearGauge, daySch);
                }
            }
            catch (Exception exception)
            {
                throw;
            }
        }

        private void comboMon_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                var dayScheduleBll = new DayScheduleBll();
                ClearLinearGuageBar(MonLinearGauge);
                var daySchs = dayScheduleBll.SelectDaySchWithDayTypeId((int)comboMon.SelectedValue);
                foreach (var daySch in daySchs)
                {
                    SetLinearGaugeBar(MonLinearGauge, daySch);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void combotu_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                var dayScheduleBll = new DayScheduleBll();
                ClearLinearGuageBar(tuLinearGauge);
                var daySchs = dayScheduleBll.SelectDaySchWithDayTypeId((int)combotu.SelectedValue);
                foreach (var daySch in daySchs)
                {
                    SetLinearGaugeBar(tuLinearGauge, daySch);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void combowed_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                var dayScheduleBll = new DayScheduleBll();
                ClearLinearGuageBar(wedLinearGauge);
                var daySchs = dayScheduleBll.SelectDaySchWithDayTypeId((int)combowed.SelectedValue);
                foreach (var daySch in daySchs)
                {
                    SetLinearGaugeBar(wedLinearGauge, daySch);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void combothr_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                var dayScheduleBll = new DayScheduleBll();
                ClearLinearGuageBar(thrLinearGauge);
                var daySchs = dayScheduleBll.SelectDaySchWithDayTypeId((int)combothr.SelectedValue);
                foreach (var daySch in daySchs)
                {
                    SetLinearGaugeBar(thrLinearGauge, daySch);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void combofri_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                var dayScheduleBll = new DayScheduleBll();
                ClearLinearGuageBar(friLinearGauge);
                var daySchs = dayScheduleBll.SelectDaySchWithDayTypeId((int)combofri.SelectedValue);
                foreach (var daySch in daySchs)
                {
                    SetLinearGaugeBar(friLinearGauge, daySch);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }


        private float ConvertToFloat(string time)
        {
            var timeSpan = new TimeSpan(0, Convert.ToInt32(time.Substring(0, 2)), Convert.ToInt32(time.Substring(2, 2)),
                Convert.ToInt32(time.Substring(4, 2)));
            return (float)timeSpan.TotalHours;
        }

        private void chkSchGroupListBox_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (e.State != CheckState.Checked)
            {
                if (chkSchGroupListBox.CheckedItemsCount == 0)
                {
                    UncheckAll.CheckState = CheckState.Checked;
                }
                return;
            }

            var lb = sender as CheckedListBoxControl;
            Debug.Assert(lb != null, "lb != null");
            for (var i = 0; i < lb.ItemCount; i++)
            {
                if (i != e.Index)
                    lb.SetItemChecked(i, false);
            }

            var schGroupBll = new ScheduleGroupBll();
            //   ResetFrm();
            EditFlag = true;
            CheckedItemIndex = e.Index;
            var schGroupId = (int)chkSchGroupListBox.GetItemValue(e.Index);
            txtSchGroup.Text = chkSchGroupListBox.GetItemText(e.Index);
            YearSpinEditor.Text = schGroupBll.SelectYear(schGroupId);
            _schGroup.ID = schGroupId;
            ShowWeekDaysDayType(schGroupId);
            ShowHolidayGroup(schGroupId);
            UncheckAll.CheckState = CheckState.Unchecked;
        }

        private void ShowHolidayGroup(int schGroupId)
        {
            var holiDaysSchGroupBll = new HoliDaysSchGroupBll();
            var holidayGroupId = holiDaysSchGroupBll.SelectHolidayGroupId(schGroupId);

            comboHoliDayGroup.SelectedValue = holidayGroupId;
        }

        private void ResetFrm()
        {
            try
            {
                txtSchGroup.Text = string.Empty;
                SetYearSpinEditor();
                combosat.SelectedIndex = 0;
                ClearLinearGuageBar(satLinearGauge);
                comboSun.SelectedIndex = 0;
                ClearLinearGuageBar(sunLinearGauge);
                comboMon.SelectedIndex = 0;
                ClearLinearGuageBar(MonLinearGauge);
                combotu.SelectedIndex = 0;
                ClearLinearGuageBar(tuLinearGauge);
                combowed.SelectedIndex = 0;
                ClearLinearGuageBar(wedLinearGauge);
                combothr.SelectedIndex = 0;
                ClearLinearGuageBar(thrLinearGauge);
                combofri.SelectedIndex = 0;
                ClearLinearGuageBar(friLinearGauge);
                comboHoliDayGroup.SelectedIndex = 0;
            }
            catch (Exception)
            {
                throw;
            }
        }


        private void ShowWeekDaysDayType(int schGroupId)
        {
            try
            {
                var weekScheduleBll = new WeekScheduleBll();
                var weekScheduleList = weekScheduleBll.SelectWeekDaysBySchGroupId(schGroupId);

                var not = SelectWeekdayHasNotDayType(weekScheduleList);

                foreach (var n in not)
                {
                    switch (n)
                    {
                        case 0:
                            combosat.SelectedValue = 0;
                            ClearLinearGuageBar(satLinearGauge);
                            break;
                        case 1:
                            comboSun.SelectedValue = 0;
                            ClearLinearGuageBar(sunLinearGauge);
                            break;
                        case 2:
                            comboMon.SelectedValue = 0;
                            ClearLinearGuageBar(MonLinearGauge);
                            break;
                        case 3:
                            combotu.SelectedValue = 0;
                            ClearLinearGuageBar(tuLinearGauge);
                            break;
                        case 4:
                            combowed.SelectedValue = 0;
                            ClearLinearGuageBar(wedLinearGauge);
                            break;
                        case 5:
                            combothr.SelectedValue = 0;
                            ClearLinearGuageBar(thrLinearGauge);
                            break;
                        case 6:
                            combofri.SelectedValue = 0;
                            ClearLinearGuageBar(friLinearGauge);
                            break;
                        default:

                            break;
                    }
                }

                foreach (var weekday in weekScheduleList)
                {
                    switch (weekday.weekday)
                    {
                        case 0:
                            combosat.SelectedValue = weekday.DayTypeID;
                            combosat_SelectionChangeCommitted(new object(), new EventArgs());
                            break;
                        case 1:
                            comboSun.SelectedValue = weekday.DayTypeID;
                            comboSun_SelectionChangeCommitted(new object(), new EventArgs());
                            break;
                        case 2:
                            comboMon.SelectedValue = weekday.DayTypeID;
                            comboMon_SelectionChangeCommitted(new object(), new EventArgs());
                            break;
                        case 3:
                            combotu.SelectedValue = weekday.DayTypeID;
                            combotu_SelectionChangeCommitted(new object(), new EventArgs());
                            break;
                        case 4:
                            combowed.SelectedValue = weekday.DayTypeID;
                            combowed_SelectionChangeCommitted(new object(), new EventArgs());
                            break;
                        case 5:
                            combothr.SelectedValue = weekday.DayTypeID;
                            combothr_SelectionChangeCommitted(new object(), new EventArgs());
                            break;
                        case 6:
                            combofri.SelectedValue = weekday.DayTypeID;
                            combofri_SelectionChangeCommitted(new object(), new EventArgs());
                            break;
                        default:

                            break;
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        private List<int> SelectWeekdayHasNotDayType(List<WeekSchedule> weekScheduleList)
        {
            try
            {
                var week = new List<int> { 0, 1, 2, 3, 4, 5, 6 };
                var a = new List<int>();

                for (var i = 0; i < 7; i++)
                {
                    if (!weekScheduleList.Exists(x => x.weekday == i))
                    {
                        a.Add(i);
                    }
                }

                return a;
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void chkSchGroupListBox_MouseClick(object sender1, MouseEventArgs e1)
        {
            if (e1.Button == MouseButtons.Right)
            {
                var rightClickMenu = new ContextMenu();
                rightClickMenu.MenuItems.Add(new MenuItem("حذف"));

                var pointloc = new Point(e1.X, e1.Y);


                rightClickMenu.Show(chkSchGroupListBox, pointloc);
                rightClickMenu.MenuItems[0].Click +=
                    (sender, e) => chkSchGroupListBox_Delete(sender, e, sender1, e1.Location);
            }
        }

        private void chkSchGroupListBox_Delete(object sender, EventArgs eventArgs, object sender1, Point location)
        {
            try
            {
                var chkSchGroupList = (CheckedListBoxControl)sender1;
                var indexFromPoint = chkSchGroupList.IndexFromPoint(location);
                if (indexFromPoint == -1)
                    return;
                var id = (int)chkSchGroupList.GetItemValue(indexFromPoint);
                var groupName = chkSchGroupList.GetItemText(indexFromPoint);
                var dialogResult = MessageBox.Show(@"آیا مطمئن به حذف گروه زمانبندی " + groupName + @" هستید ",
                    @"هشدار", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1,
                    MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);

                if (dialogResult == DialogResult.Yes)
                {
                    var schGroupBll = new ScheduleGroupBll();
                    var holiDaysSchGroupBll = new HoliDaysSchGroupBll();
                    var weekScheduleBll = new WeekScheduleBll();


                    var res1 = weekScheduleBll.DeleteBySchGroupId(id);

                    var res2 = holiDaysSchGroupBll.DeleteBySchGroupId(id);
                    var res3 = schGroupBll.Delete(id);
                    if (res3 >= 0)
                    {
                        LoadHolidayCombobox();
                        SetYearSpinEditor();
                        LoadWeekdayCombobox();
                        LoadScheduleGroupListBox();
                        ResetFrm();
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void UncheckAll_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                var edit = sender as CheckBox;
                if (edit == null) return;
                switch (edit.CheckState)
                {
                    case CheckState.Unchecked:
                        UncheckAll.CheckState = CheckState.Unchecked;
                        break;
                    case CheckState.Checked:
                        UncheckAll.CheckState = CheckState.Checked;
                        chkSchGroupListBox.UnCheckAll();
                        txtSchGroup.Text = string.Empty;
                        SetYearSpinEditor();
                        LoadHolidayCombobox();
                        LoadWeekdayCombobox();
                        LoadScheduleGroupListBox();
                        ResetFrm();
                        EditFlag = false;
                        break;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}