using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Eco
{
    public partial class FrmZkRoleManagment : Form
    {
        public FrmZkRoleManagment()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            int perId = GetCustomeRole();
             
            var a = GetFunctionItem();
            WriteListInTextFile(a,perId);
        }

        private int GetCustomeRole()
        {
            if (rdbCustome1.Checked)
                return 4;
            if (rdbCustome2.Checked)
                return 8;
            if (rdbCustome3.Checked)
                return 10;
            else
            {
                return 0;
            }
        }

        private void WriteListInTextFile(List<string> list,int perId)
        {
            try
            {
                File.WriteAllLines(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location),
                    "AppRolePerm"+perId+".txt"), list);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        private List<string> GetFunctionItem()
        {
            try
            {
                List<string> appList = new List<string>();
                if(chkEnabel.Checked)
                    appList.Add("Enabel");
                foreach (var item in chk0.CheckedItems)
                {
                    appList.Add(item.ToString());
                }
                foreach (var item in chk1.CheckedItems)
                {
                    appList.Add(item.ToString());
                }
                foreach (var item in chk2.CheckedItems)
                {
                    appList.Add(item.ToString());
                }
                foreach (var item in chk3.CheckedItems)
                {
                    appList.Add(item.ToString());
                }
                foreach (var item in chk4.CheckedItems)
                {
                    appList.Add(item.ToString());
                }
                foreach (var item in chk5.CheckedItems)
                {
                    appList.Add(item.ToString());
                }
                foreach (var item in chk6.CheckedItems)
                {
                    appList.Add(item.ToString());
                }
                foreach (var item in chk7.CheckedItems)
                {
                    appList.Add(item.ToString());
                }
                foreach (var item in chk8.CheckedItems)
                {
                    appList.Add(item.ToString());
                }


                return appList;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }

        


    }
}
