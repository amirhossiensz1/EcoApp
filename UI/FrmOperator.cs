using System;
using System.Drawing;
using System.Windows.Forms;
using BLL;
using DevExpress.XtraGrid.Views.Grid;
using Model;

namespace UI
{
    public partial class FrmEditOperator : Form
    {
        private readonly Operator _opert = new Operator();
        private readonly OperatorBll _opertBll = new OperatorBll();
        private bool _edit;
        private int _rowindex;

        public FrmEditOperator()
        {
            InitializeComponent();
            grdOperator.GroupPanelText = @"جهت فیلتر کردن هر ستون ستون مورد نظر را به این قسمت بکشید";
        }

        private void FrmEditOperator_Load(object sender, EventArgs e)
        {
            try
            {
                GridOperator.DataSource = _opertBll.SelectAllOperator();
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtName.Text == null || txtLName.Text == null || txtUserName.Text == null || txtPass.Text == null ||
                    txtRePass.Text == null)
                    MessageBox.Show(@"تمام اطلاعات خواسته شده را وارد نمایید!!!", @"خطا", MessageBoxButtons.OK,
                        MessageBoxIcon.Error, MessageBoxDefaultButton.Button1,
                        MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                else
                {
                    var opert = new Operator();
                    int result;

                    opert.ID = _rowindex;
                    opert.Name = txtName.Text;
                    opert.Lname = txtLName.Text;
                    opert.UserName = txtUserName.Text;

                    if (txtPass.Text != txtRePass.Text || (txtPass.Text == "" && txtRePass.Text == ""))
                        MessageBox.Show(@"کلمه عبور ها با  هم مغایرت دارد!!!", @"خطا", MessageBoxButtons.OK,
                            MessageBoxIcon.Error, MessageBoxDefaultButton.Button1,
                            MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                    else
                    {
                        opert.Password = txtPass.Text;

                        if (_opertBll.CheckUserExist(txtUserName.Text) && _opert.UserName != opert.UserName)
                            MessageBox.Show(@"این نام کاربری استفاده شده است!!!", @"خطا", MessageBoxButtons.OK,
                                MessageBoxIcon.Error, MessageBoxDefaultButton.Button1,
                                MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                        else
                        {
                            if (_opertBll.CheckPassExist(txtPass.Text) && _opert.Password != opert.Password)
                                MessageBox.Show(@" این کلمه عبور استفاده شده است!!!", @"خطا", MessageBoxButtons.OK,
                                    MessageBoxIcon.Error, MessageBoxDefaultButton.Button1,
                                    MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                            else
                            {
                                result = _edit ? _opertBll.UpdateOneOperator(opert) : _opertBll.Insert(opert);

                                if (result > 0)
                                {
                                    _edit = false;
                                    GridOperator.DataSource = _opertBll.SelectAllOperator();
                                    ClearForm();
                                    MessageBox.Show(@"تغییرات ذخیره شد", @"پیام", MessageBoxButtons.OK,
                                        MessageBoxIcon.None);
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }


        private void ClearForm()
        {
            try
            {
                txtName.Text = string.Empty;
                txtLName.Text = string.Empty;
                txtUserName.Text = string.Empty;
                txtPass.Text = string.Empty;
                txtRePass.Text = string.Empty;
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void grdOperator_RowClick(object sender, RowClickEventArgs e)
        {
            try
            {
                if (e.Button == MouseButtons.Left)
                {
                    _edit = true;
                    var opert = new Operator();

                    var index = grdOperator.FocusedRowHandle;
                    _rowindex = (int) grdOperator.GetRowCellValue(index, "ID");

                    opert = _opertBll.SelectOneOperator(_rowindex);

                    txtName.Text = grdOperator.GetRowCellValue(index, "Name").ToString();
                    txtLName.Text = grdOperator.GetRowCellValue(index, "Lname").ToString();
                    txtUserName.Text = grdOperator.GetRowCellValue(index, "UserName").ToString();
                    txtPass.Text = opert.Password;
                    txtRePass.Text = opert.Password;
                }

                if (e.Button == MouseButtons.Right)
                {
                    var rigthCLickMenu = new ContextMenu();

                    rigthCLickMenu.MenuItems.Add(new MenuItem("حذف"));

                    var point = new Point(e.X, e.Y);

                    rigthCLickMenu.Show(GridOperator, point);

                    rigthCLickMenu.MenuItems[0].Click += rightClickDeleteOperator_Click;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void rightClickDeleteOperator_Click(object sender, EventArgs e)
        {
            try
            {
                var index = grdOperator.FocusedRowHandle;
                _rowindex = (int) grdOperator.GetRowCellValue(index, "ID");

                var dialogResult = MessageBox.Show(@"آیا مطمئن به حذف هستید!!!", @"هشدار", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1,
                    MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                if (dialogResult == DialogResult.Yes)
                {
                    var result = _opertBll.Delete(_rowindex);

                    if (result > 0)
                    {
                        GridOperator.DataSource = _opertBll.SelectAllOperator();
                        _edit = false;
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