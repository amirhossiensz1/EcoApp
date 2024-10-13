using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using BLL;
using DevExpress.XtraEditors;
using Model;
using ItemCheckEventArgs = DevExpress.XtraEditors.Controls.ItemCheckEventArgs;

namespace Eco
{
    public partial class FrmHolidaygroup : Form
    {
        private readonly HoliDay _holiDay = new HoliDay();
        private readonly HoliDayBll _holiDayBll = new HoliDayBll();
        private readonly HoliDaysGroup _holiDaysGroup = new HoliDaysGroup();
        private readonly HoliDaysGroupBll _holiDaysGroupBll = new HoliDaysGroupBll();

        public FrmHolidaygroup()
        {
            EditFlag = false;
            InitializeComponent();
        }

        public bool EditFlag { get; set; }

        public int SelectedGroupId { get; set; }


        private void FrmHolidaygroup_Load(object sender, EventArgs e)
        {
            SetDateTimePickerProp();
            SetHoliDaysList();
            SetHoliDaysGroupList();
            UncheckAll.CheckState = CheckState.Checked;
        }

        private void SetHoliDaysGroupList()
        {
            HolidaysGroupList.DataSource = _holiDaysGroupBll.SelectAll();
        }


        private void SetHoliDaysList()
        {
            HoliDayList.DataSource = _holiDayBll.SelectAll();
        }


        private void SetDateTimePickerProp()
        {
            Application.CurrentCulture = new CultureInfo("fa-IR");
            HolidaysPicker.Culture = new CultureInfo("fa-IR");
            HolidaysPicker.Format = DateTimePickerFormat.Custom;
            HolidaysPicker.CustomFormat = Application.CurrentCulture.DateTimeFormat.ShortDatePattern;
        }


        private void btnAddList_Click(object sender, EventArgs e)
        {
            _holiDay.Date = ConvertAlign(HolidaysPicker.Text);

            if (_holiDay.Date == _holiDayBll.ExistDate(_holiDay.Date))
            {
                MessageBox.Show(@"این تاریخ در لیست موجود می باشد !!!", @"هشدار", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1,
                    MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
            }
            else
            {
                var result = _holiDayBll.Add(_holiDay);

                if (result > 1)
                {
                    SetHoliDaysList();
                }
            }
        }

        private string ConvertAlign(string date)
        {
            var correctDate = date.Substring(6, 4);
            correctDate += "/" + date.Substring(3, 2);
            correctDate += "/" + date.Substring(0, 2);
            return correctDate;
        }


        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }


        private void AddHolidayGroupList_Click(object sender, EventArgs e)
        {
            if (txtGroupName.Text == string.Empty)
            {
                MessageBox.Show(@"جهت افزودن نام گروه تعطیلات باید نام آن را مشخص کنید!!!",
                    @"", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1,
                    MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                return;
            }

            _holiDaysGroup.Name = txtGroupName.Text;
            var result = -1;


            if (EditFlag)
            {
                EditFlag = false;
                result = _holiDaysGroupBll.Update(_holiDaysGroup, SelectedGroupId);
            }
            else
            {
                result = _holiDaysGroupBll.Add(_holiDaysGroup);
            }

            if (result > 0)
            {
                SetHoliDaysGroupList();
                txtGroupName.Text = string.Empty;

                MessageBox.Show(@"ثبت گروه تعطیلات با موفقیت انجام شد",
                    @"", MessageBoxButtons.OK,
                    MessageBoxIcon.Information, MessageBoxDefaultButton.Button1,
                    MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
            }
        }


        private void HolidaysGroupList_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (e.State != CheckState.Checked)
            {
                if (HolidaysGroupList.CheckedItemsCount == 0)
                {
                    UncheckAll.CheckState = CheckState.Checked;
                    HoliDayList.UnCheckAll();
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

            var groupId = (int) HolidaysGroupList.GetItemValue(e.Index);

            HoliDayList.UnCheckAll();

            EditFlag = true;
            SelectedGroupId = groupId;
            txtGroupName.Text = HolidaysGroupList.GetItemText(e.Index);
            BtnAddHolidayGroupList.Text = @"ویرایش";

            ShowCheckedHoliday(groupId);
            UncheckAll.CheckState = CheckState.Unchecked;
        }

        private void ShowCheckedHoliday(int groupId)
        {
            var holidayList = _holiDayBll.SelectHolidayByHolidayGroupId(groupId);
            var holidayIndexList = FindindexfromValue(holidayList);
            if (holidayIndexList != null)
            {
                foreach (var index in holidayIndexList)
                {
                    HoliDayList.SetItemChecked(index, true);
                }
            }
        }

        private List<int> FindindexfromValue(List<HoliDay> holidayList)
        {
            var indexList = new List<int>();
            foreach (var holiday in holidayList)
            {
                for (var i = 0; i < HoliDayList.ItemCount; i++)
                {
                    if ((int) HoliDayList.GetItemValue(i) == holiday.ID)
                    {
                        indexList.Add(i);
                        break;
                    }
                }
            }
            return indexList;
        }


        private string ConvertDateToString(string date)
        {
            var dateStr = date.Replace("/", "");
            return dateStr;
        }

        private void HoliDayList_MouseClick(object sender1, MouseEventArgs e1)
        {
            if (e1.Button == MouseButtons.Right)
            {
                var rightClickMenu = new ContextMenu();
                rightClickMenu.MenuItems.Add(new MenuItem("حذف"));
                var point = new Point(e1.X, e1.Y);


                rightClickMenu.Show(HoliDayList, point);
                rightClickMenu.MenuItems[0].Click +=
                    (sender, e) => rightClickDeleteHoliDay_Delete(sender, e, sender1, e1.Location);
            }
        }

        private void rightClickDeleteHoliDay_Delete(object sender, EventArgs e, object sender1, Point location)
        {
            try
            {
                var holiDayList = (CheckedListBoxControl) sender1;
                var indexFromPoint = holiDayList.IndexFromPoint(location);
                var id = (int) HoliDayList.GetItemValue(indexFromPoint);
                var date = HoliDayList.GetItemText(indexFromPoint);
                var dialogResult = MessageBox.Show(@"آیا مطمئن به حذف تاریخ " + date + @" هستید !!!", @"هشدار",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1,
                    MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);

                if (dialogResult == DialogResult.Yes)
                {
                    var result = _holiDayBll.Delete(id);
                    SetHoliDaysList();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }


        private void HolidaysGroupList_MouseClick(object sender1, MouseEventArgs e1)
        {
            if (e1.Button == MouseButtons.Right)
            {
                var rightClickMenu = new ContextMenu();
                rightClickMenu.MenuItems.Add(new MenuItem("حذف"));

                var pointloc = new Point(e1.X, e1.Y);


                rightClickMenu.Show(HolidaysGroupList, pointloc);
                rightClickMenu.MenuItems[0].Click +=
                    (sender, e) => HolidaysGroupList_Delete(sender, e, sender1, e1.Location);
            }
        }

        private void HolidaysGroupList_Delete(object sender, EventArgs eventArgs, object sender1, Point location)
        {
            try
            {
                var holidaysGroupList = (CheckedListBoxControl) sender1;
                var indexFromPoint = holidaysGroupList.IndexFromPoint(location);
                var id = (int) holidaysGroupList.GetItemValue(indexFromPoint);
                var groupName = holidaysGroupList.GetItemText(indexFromPoint);
                var dialogResult = MessageBox.Show(@"آیا مطمئن به حذف گروه تعطیلات " + groupName + @" هستید !!!",
                    @"هشدار", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1,
                    MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);

                if (dialogResult == DialogResult.Yes)
                {
                    var result = _holiDaysGroupBll.Delete(id);
                    SetHoliDaysGroupList();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                var holidaysList = new List<int>();
                var notInholidayList = new List<int>();

                if (HolidaysGroupList.CheckedItems.Count == 0)
                {
                    MessageBox.Show(
                        @"جهت تخصیص تعطیلات به گروه تعطیلات حداقل باید تیک  یکی از موارد لیست گروه تعطیلات را بزنید",
                        @"", MessageBoxButtons.OK,
                        MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1,
                        MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                    return;
                }
                var holidaysGroupId = (int) HolidaysGroupList.GetItemValue(HolidaysGroupList.CheckedIndices[0]);

                holidaysList.AddRange(from object holiday in HoliDayList.CheckedIndices
                    select (int) HoliDayList.GetItemValue((int) holiday));

                var result = _holiDayBll.UpdateGroupId(holidaysList, holidaysGroupId);


                for (var i = 0; i < HoliDayList.ItemCount; i++)
                {
                    if (holidaysList.Contains((int) HoliDayList.GetItemValue(i)))
                        continue;
                    notInholidayList.Add((int) HoliDayList.GetItemValue(i));
                }

                var rst = _holiDayBll.UpdateGroupIdToNull(notInholidayList, holidaysGroupId);

                if (result >= 0 && rst >= 0)
                {
                    ResetForm();
                    MessageBox.Show(@"گروه تعطیلات ثبت شد",
                        @"", MessageBoxButtons.OK,
                        MessageBoxIcon.Information, MessageBoxDefaultButton.Button1,
                        MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                }
            }
            catch (Exception exception)
            {
                throw;
            }
        }

        private void ResetForm()
        {
            try
            {
                HoliDayList.UnCheckAll();
                UncheckAll.CheckState = CheckState.Checked;
                HolidaysGroupList.UnCheckAll();
                txtGroupName.Text = string.Empty;
                BtnAddHolidayGroupList.Text = @"افزودن";
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private void CheckedAll_CheckedChanged(object sender, EventArgs e)
        {
            var edit = sender as CheckBox;
            if (edit == null) return;
            switch (edit.CheckState)
            {
                case CheckState.Checked:
                    HoliDayList.CheckAll();
                    break;
                case CheckState.Indeterminate:
                    CheckedAll.CheckState = CheckState.Indeterminate;
                    break;
                case CheckState.Unchecked:
                    HoliDayList.UnCheckAll();
                    break;
            }
        }

        private void UncheckAll_CheckedChanged(object sender, EventArgs e)
        {
            var edit = sender as CheckBox;
            if (edit == null) return;
            switch (edit.CheckState)
            {
                case CheckState.Unchecked:
                    UncheckAll.CheckState = CheckState.Unchecked;
                    break;
                case CheckState.Indeterminate:
                    UncheckAll.CheckState = CheckState.Unchecked;
                    break;
                case CheckState.Checked:
                    HolidaysGroupList.UnCheckAll();
                    BtnAddHolidayGroupList.Text = @"افزودن";
                    txtGroupName.Text = string.Empty;
                    EditFlag = false;
                    break;
            }
        }

        private void HoliDayList_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (HoliDayList.CheckedItemsCount == HoliDayList.ItemCount)
                CheckedAll.CheckState = CheckState.Checked;
            if (HoliDayList.CheckedItemsCount < HoliDayList.ItemCount)
                CheckedAll.CheckState = CheckState.Indeterminate;
            if (HoliDayList.CheckedItemsCount == 0)
                CheckedAll.CheckState = CheckState.Unchecked;
        }
    }
}