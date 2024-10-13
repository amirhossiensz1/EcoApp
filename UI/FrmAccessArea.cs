using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using BLL;
using DevExpress.XtraEditors;
using Model;
using ItemCheckEventArgs = DevExpress.XtraEditors.Controls.ItemCheckEventArgs;

namespace Eco
{
    public partial class FrmAccessArea : Form
    {
        public FrmAccessArea()
        {
            InitializeComponent();
        }

        public bool EditFlag { get; set; }


        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                var acsAreaBll = new AccessAreaBll();
                var deviceSchGroupBll = new DeviceSchGroupBll();
                var acsArea = new AccessArea();
                var deviceSchGroup = new DeviceSchGroup();


                if (txtName.Text == string.Empty)
                {
                    MessageBox.Show(@"جهت ایجاد ناحیه دسترسی  باید نام ناحیه دسترسی را مشخص کنید", @"هشدار",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error, MessageBoxDefaultButton.Button1,
                        MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                    return;
                }
                if (cmbSchGroup.SelectedIndex == 0)
                {
                    MessageBox.Show(@"جهت ایجاد ناحیه دسترسی  باید یک گروه زمانبندی را مشخص کنید", @"هشدار",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error, MessageBoxDefaultButton.Button1,
                        MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                    return;
                }

                if (chkListDevices.CheckedItems.Count == 0)
                {
                    MessageBox.Show(@"جهت ایجاد ناحیه دسترسی باید حداقل یک  دستگاه  را مشخص کنید", @"هشدار",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error, MessageBoxDefaultButton.Button1,
                        MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                    return;
                }

                if (EditFlag)
                {
                    acsArea.Name = txtName.Text;
                    acsArea.ID = (int) chkListAcsArea.CheckedItems[0];

                    deviceSchGroup.AcsAreaID = acsAreaBll.Update(acsArea);
                    deviceSchGroup.SchgroupID = (int) cmbSchGroup.SelectedValue;


                    for (var i = 0; i < chkListDevices.ItemCount; i++)
                    {
                        if (chkListDevices.GetItemCheckState(i) == CheckState.Checked)
                        {
                            deviceSchGroupBll.UpdateAndAdd((Device) chkListDevices.GetItem(i), deviceSchGroup);
                        }
                        else
                        {
                            deviceSchGroupBll.Delete((Device) chkListDevices.GetItem(i), deviceSchGroup);
                        }
                    }

                    MessageBox.Show(@"ناحیه دسترسی ثبت شد",
                        @"", MessageBoxButtons.OK,
                        MessageBoxIcon.Information, MessageBoxDefaultButton.Button1,
                        MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                    ClearForm();
                    FillAcsAreaList();
                    chkListAcsArea.UnCheckAll();
                    btnSave.Text = @"ثبت";
                }
                else
                {
                    acsArea.Name = txtName.Text;
                    deviceSchGroup.AcsAreaID = acsAreaBll.Insert(acsArea);

                    deviceSchGroup.SchgroupID = (int) cmbSchGroup.SelectedValue;
                    var devices = chkListDevices.CheckedItems;

                    foreach (Device device in devices)
                    {
                        deviceSchGroup.DeviceID = device.ID;
                        deviceSchGroupBll.Insert(deviceSchGroup);
                    }


                    MessageBox.Show(@"ناحیه دسترسی ثبت شد",
                        @"", MessageBoxButtons.OK,
                        MessageBoxIcon.Information, MessageBoxDefaultButton.Button1,
                        MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);

                    ClearForm();
                    chkListAcsArea.UnCheckAll();
                    FillAcsAreaList();
                }
            }
            catch (Exception exception)
            {
                throw;
            }
        }

        private void ClearForm()
        {
            // chkListAcsArea.UnCheckAll();
            txtName.Text = string.Empty;
            chkListDevices.UnCheckAll();
            cmbSchGroup.SelectedIndex = 0;
        }

        private void FrmAccessArea_Load(object sender, EventArgs e)
        {
            FillSchGroupCombobox();
            FillAcsAreaList();
            FillDeviceList();
            EditFlag = false;
        }

        private void FillDeviceList()
        {
            try
            {
                var deviceBll = new DeviceBLL();
                chkListDevices.DataSource = deviceBll.SelectDevices();
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void FillAcsAreaList()
        {
            try
            {
                var acsAreaBll = new AccessAreaBll();
                chkListAcsArea.DataSource = acsAreaBll.SelectAll();
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void FillSchGroupCombobox()
        {
            try
            {
                var scheduleGroupBll = new ScheduleGroupBll();
                var schgrouplist = scheduleGroupBll.SelectAll();

                var dtschGroup = ConvertToDataTable(schgrouplist);

                var schgroup = new ScheduleGroup
                {
                    ID = 0,
                    Name = "انتخاب کنید"
                };

                var row = dtschGroup.NewRow();
                row["ID"] = schgroup.ID;
                row["Name"] = schgroup.Name;
                dtschGroup.Rows.InsertAt(row, 0);

                cmbSchGroup.DataSource = dtschGroup;
                cmbSchGroup.ValueMember = "ID";
                cmbSchGroup.DisplayMember = "Name";
            }
            catch (Exception ex)
            {
                throw;
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

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }


        private void chkListAcsArea_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (e.State != CheckState.Checked)
            {
                if (chkListAcsArea.CheckedItemsCount == 0)
                {
                    UnCheckAll.CheckState = CheckState.Checked;
                    btnSave.Text = @"ثبت";
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

            ClearForm();
            var acsAreaId = (int) chkListAcsArea.GetItemValue(e.Index);

            txtName.Text = chkListAcsArea.GetItemText(e.Index);

            btnSave.Text = @"ویرایش";
            EditFlag = true;

            ShowSchGroup(acsAreaId);
            ShowCheckedDevices(acsAreaId);

            UnCheckAll.CheckState = CheckState.Unchecked;
        }

        private void ShowCheckedDevices(int acsAreaId)
        {
            try
            {
                var deviceSchGroupBll = new DeviceSchGroupBll();
                var deviceIdList = deviceSchGroupBll.SelectDeviceIdByAcsAreaId(acsAreaId);
                var deviceIndexList = FindindexfromValue(deviceIdList);
                if (deviceIdList != null)
                {
                    foreach (var index in  deviceIndexList)
                    {
                        chkListDevices.SetItemChecked(index, true);
                    }
                }
            }
            catch (Exception exception)
            {
                throw;
            }
        }

        private List<int> FindindexfromValue(List<DeviceSchGroup> deviceIdList)
        {
            var indexList = new List<int>();
            foreach (var device in deviceIdList)
            {
                for (var i = 0; i < chkListDevices.ItemCount; i++)
                {
                    if ((int) chkListDevices.GetItemValue(i) == device.DeviceID)
                    {
                        indexList.Add(i);
                        break;
                    }
                }
            }
            return indexList;
        }

        private void ShowSchGroup(int acsAreaId)
        {
            try
            {
                var deviceSchGroupBll = new DeviceSchGroupBll();
                cmbSchGroup.SelectedValue = deviceSchGroupBll.SelectSchIdById(acsAreaId);
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void UnCheckAll_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                var edit = sender as CheckBox;
                if (edit == null) return;

                switch (edit.CheckState)
                {
                    case CheckState.Unchecked:
                        UnCheckAll.CheckState = CheckState.Unchecked;
                        break;
                    case CheckState.Checked:
                        UnCheckAll.CheckState = CheckState.Checked;
                        chkListAcsArea.UnCheckAll();
                        ClearForm();
                        EditFlag = false;
                        break;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void chkListAcsArea_MouseClick(object sender1, MouseEventArgs e1)
        {
            try
            {
                if (e1.Button == MouseButtons.Right)
                {
                    var rightClickMenu = new ContextMenu();
                    rightClickMenu.MenuItems.Add(new MenuItem("حذف"));

                    var pointloc = new Point(e1.X, e1.Y);
                    rightClickMenu.Show(chkListAcsArea, pointloc);
                    rightClickMenu.MenuItems[0].Click +=
                        (sender, e) => chkListAcsArea_Delete(sender, e, sender1, e1.Location);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void chkListAcsArea_Delete(object sender, EventArgs e, object sender1, Point location)
        {
            try
            {
                var chkListAcsAreaListBox = (CheckedListBoxControl) sender1;

                var indexFromPoint = chkListAcsAreaListBox.IndexFromPoint(location);
                if (indexFromPoint == -1)
                    return;

                var id = (int) chkListAcsAreaListBox.GetItemValue(indexFromPoint);
                var groupName = chkListAcsAreaListBox.GetItemText(indexFromPoint);

                var dialogResult = MessageBox.Show(@"آیا مطمئن به حذف ناحیه دسترسی   " + groupName + @" هستید !!!",
                    @"هشدار", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1,
                    MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);

                if (dialogResult == DialogResult.Yes)
                {
                    var deviceSchGroupBll = new DeviceSchGroupBll();
                    var accessAreaBll = new AccessAreaBll();

                    var a = deviceSchGroupBll.Delete(id);
                    var b = accessAreaBll.Delete(id);

                    if (a > 0 && b > 0)
                    {
                        chkListAcsArea.UnCheckAll();
                        ClearForm();
                        EditFlag = false;
                        FillAcsAreaList();
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}