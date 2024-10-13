using System;
using System.Windows.Forms;

namespace UI
{
    public partial class FrmMessageBox : Form
    {
        public bool Result1;
        public bool Result2;
        public bool Result3;

        public FrmMessageBox()
        {
            InitializeComponent();
        }

        public FrmMessageBox(string title, string message, string buttonText1, string buttonText2, string buttonText3)
        {
            InitializeComponent();
            Text = title;
            lblMessage.Text = message;
            button1.Text = buttonText1;
            button2.Text = buttonText2;
            button3.Text = buttonText3;
        }

        private void FrmMessageBox_Load(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Result1 = true;
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Result2 = true;
            Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}