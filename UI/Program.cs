using System;
using System.Windows.Forms;

namespace UI
{
    internal static class Program
    {
        /// <summary>
        ///     The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            var frmLogin = new FrmLogin();

            frmLogin.ShowDialog();
            if (frmLogin.CheckedUser)
                Application.Run(new MainFrm());
        }
    }
}