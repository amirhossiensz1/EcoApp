using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using BLL;
using DevExpress.XtraEditors;
using Model;
using zkemkeeper;
using ItemCheckEventArgs = DevExpress.XtraEditors.Controls.ItemCheckEventArgs;

namespace Eco
{
    public partial class FrmAccessGroup : Form
    {
        private CZKEMClass czkem;
        public bool PrivateAccesss { get; set; }
        public string LastName { get; set; }

        public int AcessGroupID { get; set; }
        public FrmAccessGroup()
        {
            InitializeComponent();
        }

        public FrmAccessGroup(bool privateAccess, string lastName)
        {
            InitializeComponent();
            PrivateAccesss = privateAccess;
            LastName = lastName;
        }

        public bool EditFlag { get; set; }

        private void FrmAccessGroup_Load(object sender, EventArgs e)
        {
            FillAcsGroup();
            FillAcsArea();
            LoadVerfiyCombo();
            EditFlag = false;
            if(PrivateAccesss)
                txtAcsGroupName.Text = @"دسترسی اختصاصی " + LastName;    
        }

        private void LoadVerfiyCombo()
        {
            try
            {
                VerfiCombo.DataSource = Enum.GetValues(typeof(VerificationEnum));
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        private void FillAcsGroup()
        {
            try
            {
                var accessGroupBll = new AccessGroupBll();
                chkListAcsGroup.DataSource = accessGroupBll.SelectAllForViewModel();
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void FillAcsArea()
        {
            try
            {
                var accessAreaBll = new AccessAreaBll();
                chkListAcsArea.DataSource = accessAreaBll.SelectAll();
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
                var acsGroupBll = new AccessGroupBll();
                var acsGroupAcsAreaBll = new AcsGroupAcsAreaBll();

                var accessGroup = new AccessGroup();
                var acsGroupAcsArea = new AcsGroupAcsArea();

                if (txtAcsGroupName.Text == string.Empty)
                {
                    MessageBox.Show(@"جهت ایجاد گروه دسترسی  باید نام گروه دسترسی را مشخص کنید", @"هشدار",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error, MessageBoxDefaultButton.Button1,
                        MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                    return;
                }

                if (EditFlag)
                {
                    accessGroup.Name = txtAcsGroupName.Text;
                    accessGroup.ID = (int) chkListAcsGroup.CheckedItems[0];

                    acsGroupAcsArea.AcsGroupID = acsGroupBll.Update(accessGroup);

                    for (var i = 0; i < chkListAcsArea.ItemCount; i++)
                    {
                        if (chkListAcsArea.GetItemCheckState(i) == CheckState.Checked)
                        {
                            acsGroupAcsAreaBll.UpdateAndAdd((AccessArea) chkListAcsArea.GetItem(i), acsGroupAcsArea);
                        }
                        else
                        {
                            acsGroupAcsAreaBll.Delete((AccessArea) chkListAcsArea.GetItem(i), acsGroupAcsArea);
                        }
                    }

                    FillAcsGroup();
                    ClearForm();
                   
                    //SendToZkDevices(acsGroupAcsArea.AcsGroupID);

                    EditFlag = false;
                    AcessGroupID = acsGroupBll.Select(accessGroup.ID).ID;   

                    MessageBox.Show(@"گروه دسترسی ثبت شد",
                        @"", MessageBoxButtons.OK,
                        MessageBoxIcon.Information, MessageBoxDefaultButton.Button1,
                        MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                }
                else
                {
                    accessGroup.Name = txtAcsGroupName.Text;
                    acsGroupAcsArea.AcsGroupID = acsGroupBll.Insert(accessGroup);

                    var acsAreas = chkListAcsArea.CheckedItems;
                    foreach (AccessArea acsArea in acsAreas)
                    {
                        acsGroupAcsArea.AcsAreaID = acsArea.ID;
                        acsGroupAcsAreaBll.Insert(acsGroupAcsArea);
                    }

                    FillAcsGroup();
                    
                    ClearForm();

                   // SendToZkDevices(acsGroupAcsArea.AcsGroupID);
                    AcessGroupID = (int)acsGroupAcsArea.AcsGroupID;
                    MessageBox.Show(@"گروه دسترسی ثبت شد",
                        @"", MessageBoxButtons.OK,
                        MessageBoxIcon.Information, MessageBoxDefaultButton.Button1,
                        MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private void SendToZkDevices(int? acsGroupId)
        {
            try
            {
                DeviceBLL deviceBll = new DeviceBLL();
                AccessGroupBll accessGroupBll = new AccessGroupBll();
                var accessgroup = accessGroupBll.Select((int) acsGroupId);

                var acsgroupArea = accessgroup.AcsGroupAcsAreas.ToList();
                List<Device> notSendDevices = new List<Device>();

                var zkdevices = deviceBll.SelectDevices().ToList().Where(c => c.DeviceType.ID == 4);

                foreach (var device in zkdevices)
                {
                    if (deviceBll.Ping(device.IP, device.Port))
                    {
                        czkem = new CZKEMClass();
                        if (czkem.Connect_Net(device.IP, (int) device.Port))
                        {
                            foreach (var acsGroupAcsArea in acsgroupArea)
                            {
                                var deviceSch = device.DeviceSchGroups.ToList().FirstOrDefault(dsg => dsg.AcsAreaID == acsGroupAcsArea.AcsAreaID);
                                if (deviceSch != null)
                                {
                                    var res = czkem.SSR_SetGroupTZ(1, (int)acsGroupId, (int)deviceSch.SchgroupID, 0, 0, 0, (int)VerfiCombo.SelectedValue);
                                    var rest = czkem.SSR_SetUnLockGroup(1, (int)acsGroupId, (int)acsGroupId,0,0,0,0);
                                    if (!(res & rest))
                                        notSendDevices.Add(device);


                                }
                                else
                                {
                                    var res = czkem.SSR_SetGroupTZ(1, (int)acsGroupId, (int)0, 0, 0, 0, 0);
                                    var rest = czkem.SSR_SetUnLockGroup(1, (int)acsGroupId, (int)acsGroupId, 0, 0, 0, 0);
                                    if (!(res & rest))
                                        notSendDevices.Add(device);
                                }
                            }
                        }
                        else
                        {
                            notSendDevices.Add(device);
                        }
                    }
                    else
                    {
                        notSendDevices.Add(device);
                    }
                }
                if (notSendDevices.Count != 0)
                    ShowMessage(notSendDevices);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        private void ShowMessage(List<Device> notSendDevices)
        {
            string result = "";
            foreach (var device in notSendDevices)
            {
                result += " " + device.DeviceName;
            }
            MessageBox.Show(@" گروه دسترسی به دستگاه ها روبرو ارسال نشد" + result);
        }

        private void ClearForm()
        {
            try
            {
                txtAcsGroupName.Text = string.Empty;
                chkListAcsArea.UnCheckAll();
                btnSave.Text = @"ثبت";
            }
            catch (Exception ex)
            {
                throw;
            }
        }


        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void chkListAcsGroup_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (e.State != CheckState.Checked)
            {
                if (chkListAcsGroup.CheckedItemsCount == 0)
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
            var acsGroupId = (int) chkListAcsGroup.GetItemValue(e.Index);


            txtAcsGroupName.Text = chkListAcsGroup.GetItemText(e.Index).Substring(0, chkListAcsGroup.GetItemText(e.Index).Length-4);

            btnSave.Text = @"ویرایش";
            EditFlag = true;

            ShowCheckedAcsArea(acsGroupId);


            UnCheckAll.CheckState = CheckState.Unchecked;
        }

        private void ShowCheckedAcsArea(int acsGroupId)
        {
            try
            {
                var acsGroupAcsAreaBll = new AcsGroupAcsAreaBll();
                var acsAreaIdList = acsGroupAcsAreaBll.SelectAcsAreaIdByAcsgroup(acsGroupId);

                var acsGroupIndexList = FindindexfromValue(acsAreaIdList);

                if (acsGroupIndexList != null)
                {
                    foreach (var index in acsGroupIndexList)
                    {
                        chkListAcsArea.SetItemChecked(index, true);
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }


        private List<int> FindindexfromValue(List<AcsGroupAcsArea> accessAreaIdList)
        {
            var indexList = new List<int>();
            foreach (var accessArea in accessAreaIdList)
            {
                for (var i = 0; i < chkListAcsArea.ItemCount; i++)
                {
                    if ((int) chkListAcsArea.GetItemValue(i) == accessArea.AcsAreaID)
                    {
                        indexList.Add(i);
                        break;
                    }
                }
            }
            return indexList;
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
                        chkListAcsGroup.UnCheckAll();
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

        private void chkListAcsGroup_MouseClick(object sender1, MouseEventArgs e1)
        {
            if (e1.Button == MouseButtons.Right)
            {
                var rightClickMenu = new ContextMenu();
                rightClickMenu.MenuItems.Add(new MenuItem("حذف"));

                var pointloc = new Point(e1.X, e1.Y);
                rightClickMenu.Show(chkListAcsGroup, pointloc);
                rightClickMenu.MenuItems[0].Click +=
                    (sender, e) => chkListAcsGroup_Delete(sender, e, sender1, e1.Location);
            }
        }

        private void chkListAcsGroup_Delete(object sender, EventArgs e, object sender1, Point location)
        {
            try
            {
                var chkListAcsGroupListBox = (CheckedListBoxControl) sender1;

                var indexFromPoint = chkListAcsGroupListBox.IndexFromPoint(location);
                if (indexFromPoint == -1)
                    return;

                var id = (int) chkListAcsGroupListBox.GetItemValue(indexFromPoint);
                var groupName = chkListAcsGroupListBox.GetItemText(indexFromPoint);

                var dialogResult = MessageBox.Show(@"آیا مطمئن به حذف گروه دسترسی   " + groupName + @" هستید !!!",
                    @"هشدار", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1,
                    MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);

                if (dialogResult == DialogResult.Yes)
                {
                    var accessGroupBll = new AccessGroupBll();
                    var acsGroupAcsAreaBll = new AcsGroupAcsAreaBll();

                    var a = acsGroupAcsAreaBll.Delete(id);
                    var b = accessGroupBll.Delete(id);

                    if (b >= 0)
                    {
                        FillAcsGroup();
                        ClearForm();
                        EditFlag = false;
                    }
                }
            }
            catch (Exception ex)
            {
                //throw;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CZKEM ckeCzkem = new CZKEMClass();
            int Tz1 = 0;
            int Tz2 = 0;
            int Tz3 = 0;
            int ValidHoli = 0;
            int Verify =0;
            ckeCzkem.Connect_Net("192.168.0.10", 4370);
            ckeCzkem.SSR_GetGroupTZ(1, 1, ref Tz1, ref Tz2, ref Tz3, ref ValidHoli, ref Verify);

        }


    }
}