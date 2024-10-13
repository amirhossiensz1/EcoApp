using System;
using System.Windows.Forms;
using BLL;

namespace UI
{
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
        }


        public bool CheckedUser { get; set; }

        private void BtnEnter_Click(object sender, EventArgs e)
        {
            Login();
        }

        private void Login()
        {
            try
            {
                var operatorBll = new OperatorBll();

                if (operatorBll.CheckValidate(txtUserName.Text, txtPass.Text))
                {
                    Close();
                    CheckedUser = true;
                }
                else
                {
                    MessageBox.Show(@"کلمه عبور و یا نام کاربری اشتباه می باشد!", @"خطا", MessageBoxButtons.OK,
                        MessageBoxIcon.Error, MessageBoxDefaultButton.Button1,
                        MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                    CheckedUser = false;
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(@"ارتباط با پایگاه داده برقرار نیست!", @"خطا", MessageBoxButtons.OK,
                    MessageBoxIcon.Error, MessageBoxDefaultButton.Button1,
                    MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                CheckedUser = false;
            }
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void txtUserName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txtPass.Focus();
        }

        private void txtPass_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                Login();
        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {

        }
    }
}