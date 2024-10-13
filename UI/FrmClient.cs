using System;
using System.Drawing;
using System.Windows.Forms;
using BLL;
using DevExpress.XtraGrid.Views.Grid;
using Model;

namespace Eco
{
    public partial class FrmClient : Form
    {
        private readonly ClientBll _clientBll = new ClientBll();
        private bool _edit;
        private int _rowIndex;

        public FrmClient()
        {
            InitializeComponent();
        }


        private void FrmClient_Load(object sender, EventArgs e)
        {
            GridClient.DataSource = _clientBll.SelectClients();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                var client = new Client();
                if (txtPCName.Text == "" || txtPCIP.Text == "" || txtServerIp.Text == "")
                {
                    MessageBox.Show(@"تمام اطلاعات خواسته شده را وارد نمایید!!!", @"خطا", MessageBoxButtons.OK,
                        MessageBoxIcon.Error, MessageBoxDefaultButton.Button1,
                        MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                }
                else
                {
                    client.ClientName = txtPCName.Text;
                    client.ClientIP = txtPCIP.Text;
                    client.ClientPort = 8000;
                    client.ServerIP = txtServerIp.Text;
                    int result;

                    if (_edit)
                    {
                        client.ID = _rowIndex;
                        result = _clientBll.UpdateClient(client);
                        _edit = false;
                    }
                    else
                    {
                        result = _clientBll.Insert(client);
                    }


                    if (result > 0)
                    {
                        GridClient.DataSource = _clientBll.SelectClients();
                        ClearForm();
                    }
                }
            }
            catch (Exception exception)
            {
                throw;
            }
        }

        private void ClearForm()
        {
            try
            {
                txtPCName.Text = string.Empty;
                txtPCIP.Text = string.Empty;
                // txtPCPort.Text = String.Empty;
                txtServerIp.Text = string.Empty;
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void grdClient_RowClick(object sender, RowClickEventArgs e)
        {
            try
            {
                if (e.Button == MouseButtons.Left)
                {
                    _edit = true;

                    var index = grdClient.FocusedRowHandle;
                    _rowIndex = (int) grdClient.GetRowCellValue(index, "ID");

                    txtPCName.Text = grdClient.GetRowCellValue(index, "ClientName").ToString();
                    txtPCIP.Text = grdClient.GetRowCellValue(index, "ClientIP").ToString();
                    //     txtPCPort.Text = grdClient.GetRowCellValue(index, "ClientPort").ToString();
                    txtServerIp.Text = grdClient.GetRowCellValue(index, "ServerIP").ToString();
                }
                if (e.Button == MouseButtons.Right)
                {
                    var rigthCLickMenu = new ContextMenu();

                    rigthCLickMenu.MenuItems.Add(new MenuItem("حذف"));

                    var point = new Point(e.X, e.Y);

                    rigthCLickMenu.Show(GridClient, point);

                    rigthCLickMenu.MenuItems[0].Click += rightClickDeleteClient_Click;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void rightClickDeleteClient_Click(object sender, EventArgs e)
        {
            try
            {
                var index = grdClient.FocusedRowHandle;
                _rowIndex = (int) grdClient.GetRowCellValue(index, "ID");

                var dialogResult = MessageBox.Show(@"آیا مطمئن به حذف هستید!!!", @"هشدار", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1,
                    MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                if (dialogResult == DialogResult.Yes)
                {
                    var result = _clientBll.Delete(_rowIndex);

                    if (result > 0)
                    {
                        GridClient.DataSource = _clientBll.SelectClients();
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