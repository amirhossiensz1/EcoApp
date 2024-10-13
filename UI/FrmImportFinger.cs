using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BLL;
using Model;

namespace UI
{
    public partial class FrmImportFinger : Form
    {
        private readonly EmployeeBLL _employeeBll = new EmployeeBLL();
        private readonly FingerBLL _fingerBll = new FingerBLL();


        public FrmImportFinger()
        {
            InitializeComponent();
        }

        private void btnSendFings_Click(object sender, EventArgs e)
        {
            try
            {
                var fileBytes = new byte[924];
                var fingerdata = new byte[860];
                var headerdata = new byte[64];
                var employeeBll = new EmployeeBLL();

                if (!Directory.Exists(txtFingPath.Text + "\\Fingers"))
                {
                    MessageBox.Show(@"پوشه Fingers  موجود نمی باشد", @"خطا", MessageBoxButtons.OK,
                        MessageBoxIcon.Error, MessageBoxDefaultButton.Button1,
                        MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                    return;
                }

                var fingsFiles = Directory.GetFiles(txtFingPath.Text + "\\Fingers", "*.eft");


                InitializeProgressBarPic(fingsFiles.Count());


                foreach (var fingerfile in fingsFiles)
                {
                    var startIndex = fingerfile.IndexOf("Fingers\\", StringComparison.Ordinal);
                    var endIndex = fingerfile.IndexOf(".eft", StringComparison.Ordinal);
                    var employeeIdFingNum = fingerfile.Substring(startIndex + 8, endIndex - (startIndex + 8));
                    var fingerNum = Convert.ToInt32(employeeIdFingNum.Substring(employeeIdFingNum.Length - 1, 1));
                    var employeeId = Convert.ToInt32(employeeIdFingNum.Substring(0, employeeIdFingNum.Length - 1));
                    fileBytes = File.ReadAllBytes(fingerfile);

                    for (var i = 0; i < 64; i++)
                    {
                        headerdata[i] = fileBytes[i];
                    }

                    for (var i = 64; i < fileBytes.Length; i++)
                    {
                        fingerdata[i - 64] = fileBytes[i];
                    }

                    var md5 = Getmd5FromHeader(headerdata);
                    var enrollTime = GetEnrollTimeFromHeader(headerdata);

                    var newfinger = new Finger
                    {
                        EmpID = employeeId,
                        FingerNum = fingerNum,
                        Data = fingerdata,
                        Md5 = md5,
                        DataLength = fingerdata.Length,
                        EnrollTime = enrollTime,
                        fingerQuality = 95
                    };


                    if (_employeeBll.SelectOneEmployees(employeeId) != null)
                    {
                        if (_fingerBll.SelectOneFinger(employeeId))
                        {
                            if (_fingerBll.SelectFingerMd5(employeeId, md5))
                            {
                                //break;
                            }
                            else
                            {
                                var finger = _fingerBll.SelectOneFinger(employeeId, fingerNum);
                                if (finger == null)
                                {
                                    employeeBll.SetHasFinger(employeeId);
                                    _fingerBll.InsertFingerToDb(newfinger);
                                }
                                else
                                {
                                    if (Convert.ToInt64(finger.EnrollTime) < Convert.ToInt64(enrollTime))
                                    {
                                        _fingerBll.Upadate(newfinger);
                                    }
                                }
                            }
                        }
                        else
                        {
                            employeeBll.SetHasFinger(employeeId);
                            _fingerBll.InsertFingerToDb(newfinger);
                        }
                    }
                    progressBarFings.Increment(1);
                    progressBarFings.Refresh();
                }

                MessageBox.Show(@"عملیات انتقال به اتمام رسید", @"پیام", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            catch (Exception exception)
            {
                MessageBox.Show(@"عملیات با مشکل مواجه شد!!!/n" + exception, @"خطا", MessageBoxButtons.OK,
                    MessageBoxIcon.Error, MessageBoxDefaultButton.Button1,
                    MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
            }
        }


        private void InitializeProgressBarPic(int maximum)
        {
            progressBarFings.Position = 0;
            progressBarFings.Properties.Step = 1;
            progressBarFings.Properties.PercentView = true;
            progressBarFings.Properties.Maximum = maximum;
            progressBarFings.Properties.Minimum = 0;
        }

        private string GetEnrollTimeFromHeader(byte[] headerdata)
        {
            var enrollTime = new byte[12];
            for (var i = 50; i < 62; i++)
            {
                enrollTime[i - 50] = headerdata[i];
            }
            var aaa = Encoding.UTF8.GetString(enrollTime);
            return aaa;
        }

        private string Getmd5FromHeader(byte[] headerdata)
        {
            var md5 = new byte[16];
            for (var i = 2; i < 18; i++)
            {
                md5[i - 2] = headerdata[i];
            }
            return ConvertByteArrayToString(md5);
        }

        private string ConvertByteArrayToString(byte[] ba)
        {
            var hex = new StringBuilder(ba.Length*2);
            foreach (var b in ba)
                hex.AppendFormat("{0:x2}", b);
            return hex.ToString();
        }

        private void FingBrows_Click(object sender, EventArgs e)
        {
            if (fingsfolderBrowser.ShowDialog() == DialogResult.OK)
                txtFingPath.Text = fingsfolderBrowser.SelectedPath;
        }
    }
}