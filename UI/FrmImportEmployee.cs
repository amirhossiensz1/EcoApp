using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Threading;
using BLL;
using Timer = System.Windows.Forms;

namespace UI
{
    public partial class FrmImportEmployee : Timer.Form
    {
        private readonly DeviceBLL _deviceBll = new DeviceBLL();
        private readonly DeviceEmpBll _deviceEmpBll = new DeviceEmpBll();
        private readonly EmployeeBLL _employeeBll = new EmployeeBLL();
        private string _excelfilepath = string.Empty;
        private readonly Timer.Timer _timer = new Timer.Timer();

        public FrmImportEmployee()
        {
            InitializeComponent();
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            try
            {
                // ReSharper disable once NotAccessedVariable
                var sendflag = _employeeBll.ImportEmployeeFromExcel(_excelfilepath);
                if (sendflag)
                {
                    int max;
                    if (_deviceBll.SelectDevices().Count != 0)
                    {
                        var importAccessThread = new Thread(() => ImportAccess());
                        importAccessThread.Start();
                        max = _employeeBll.SelectEmployees().Count*_deviceBll.SelectDevices().Count;
                    }
                    else
                    {
                        max = _employeeBll.SelectEmployees().Count;
                    }
                    InitializeProgressBarImportInfo(max);

                    _timer.Interval = 20;
                    if (progressBarImportInfo.Position < max)
                    {
                        _timer.Tick += timer_Tick;
                        _timer.Start();
                    }
                }
                else
                {
                    Timer.MessageBox.Show(@" نوع اطلاعات موجود در فایل استاندارد نیست!!!", @"هشدار",
                        Timer.MessageBoxButtons.OK,
                        Timer.MessageBoxIcon.Warning, Timer.MessageBoxDefaultButton.Button1,
                        Timer.MessageBoxOptions.RightAlign | Timer.MessageBoxOptions.RtlReading);
                }
            }
            catch (Exception ex)
            {
                Timer.MessageBox.Show(ex.Message, @"هشدار", Timer.MessageBoxButtons.OK,
                    Timer.MessageBoxIcon.Warning, Timer.MessageBoxDefaultButton.Button1,
                    Timer.MessageBoxOptions.RightAlign | Timer.MessageBoxOptions.RtlReading);
                throw;
            }
        }

        private void timer_Tick(object sender, EventArgs eventArgs)
        {
            progressBarImportInfo.Increment(1);
            progressBarImportInfo.Refresh();
            if (progressBarImportInfo.Position == progressBarImportInfo.Properties.Maximum)
            {
                _timer.Stop();
                Timer.MessageBox.Show(@"اطلاعات با موفقیت وارد دیتا بیس شد!!!", @"پیام", Timer.MessageBoxButtons.OK,
                    Timer.MessageBoxIcon.Information, Timer.MessageBoxDefaultButton.Button1,
                    Timer.MessageBoxOptions.RightAlign | Timer.MessageBoxOptions.RtlReading);
            }
        }


        private bool ImportAccess()
        {
            return _deviceEmpBll.InsertFirstAccessEmployee(_employeeBll.SelectEmployees(), _deviceBll.SelectDevices());
        }

        private void FrmImportEmployee_Load(object sender, EventArgs e)
        {
            ExcelPicture.Visible = false;
            btnSend.Visible = false;
            DbPicture.Visible = false;
        }

        private void BtnSendPic_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtPicPath.Text))
                    Timer.MessageBox.Show(@"لطفا پوشه حاوی عکس ها را انتخاب کنید!!!", @"هشدار",
                        Timer.MessageBoxButtons.OK,
                        Timer.MessageBoxIcon.Warning, Timer.MessageBoxDefaultButton.Button1,
                        Timer.MessageBoxOptions.RightAlign | Timer.MessageBoxOptions.RtlReading);
                else
                {
                    if (File.Exists(txtPicPath.Text + "این تصاویر وارد دیتا بیس نشدن!!!.txt"))
                        File.Delete(txtPicPath.Text + "این تصاویر وارد دیتا بیس نشدن!!!.txt");

                    if ((radioGif.Checked == false) && (radioJpeg.Checked == false))
                        Timer.MessageBox.Show(@"یکی از انواع تصویر را انتخاب کنید!!!", @"هشدار",
                            Timer.MessageBoxButtons.OK,
                            Timer.MessageBoxIcon.Warning, Timer.MessageBoxDefaultButton.Button1,
                            Timer.MessageBoxOptions.RightAlign | Timer.MessageBoxOptions.RtlReading);
                    else
                    {
                        if ((radioNationalCode.Checked == false) && (radioPersonalNum.Checked == false))
                            Timer.MessageBox.Show(@"یکی از انواع نام را انتخاب کنید!!!", @"هشدار",
                                Timer.MessageBoxButtons.OK,
                                Timer.MessageBoxIcon.Warning, Timer.MessageBoxDefaultButton.Button1,
                                Timer.MessageBoxOptions.RightAlign | Timer.MessageBoxOptions.RtlReading);
                        else
                        {
                            var path = txtPicPath.Text;
                            var typePic = string.Empty;
                            byte[] dataPic;
                            var id = string.Empty;
                            var employeeBll = new EmployeeBLL();
                            Image image;
                            var size = new Size(120, 140);

                            if (radioJpeg.Checked)
                                typePic = ".Jpg";
                            if (radioGif.Checked)
                                typePic = ".Gif";

                            var picPaths = Directory.GetFiles(path, "*" + typePic);
                            InitializeProgressBarPic(picPaths.Count());

                            foreach (var picPath in picPaths)
                            {
                                var fileName = picPath;
                                fileName = fileName.Remove(fileName.Length - 4);
                                var index = fileName.LastIndexOf("\\", StringComparison.Ordinal);
                                id = fileName.Substring(index + 1);


                                if (radioNationalCode.Checked)
                                {
                                    if (employeeBll.ExistNationalCode(id))
                                    {
                                        image = ResizeImage(Image.FromFile(picPath), size, true);
                                        dataPic = ImageToByte(image);
                                        employeeBll.InsertPicToDbBasedNationalCode(dataPic, id);
                                        progressBarPic.Increment(1);
                                        progressBarPic.Refresh();
                                    }
                                    else
                                    {
                                        using (
                                            var writer =
                                                new StreamWriter(
                                                    txtPicPath.Text + "\\" + "این تصاویر وارد دیتا بیس نشدن!!!.txt",
                                                    true))
                                        {
                                            writer.WriteLine(id);
                                        }
                                        progressBarPic.Increment(1);
                                        progressBarPic.Refresh();
                                    }
                                }
                                if (radioPersonalNum.Checked)
                                {
                                    if (employeeBll.ExistPersonalNum(id))
                                    {
                                        image = ResizeImage(Image.FromFile(picPath), size, true);
                                        dataPic = ImageToByte(image);
                                        employeeBll.InsertPicToDbBasedPersonalNum(dataPic, id);
                                        progressBarPic.Increment(1);
                                        progressBarPic.Refresh();
                                    }
                                    else
                                    {
                                        using (
                                            var writer =
                                                new StreamWriter(
                                                    txtPicPath.Text + "\\" + "این تصاویر وارد دیتا بیس نشدن!!!.txt",
                                                    true))
                                        {
                                            writer.WriteLine(id);
                                        }
                                        progressBarPic.Increment(1);
                                        progressBarPic.Refresh();
                                    }
                                }
                            }
                            if (progressBarPic.Position == progressBarPic.Properties.Maximum)
                            {
                                Timer.MessageBox.Show(@"عملیات انتقال به اتمام رسید", @"پیام",
                                    Timer.MessageBoxButtons.OK,
                                    Timer.MessageBoxIcon.Information);
                                Close();
                            }
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                Timer.MessageBox.Show(@"عملیات با مشکل مواجه شد!!!/n" + exception, @"خطا", Timer.MessageBoxButtons.OK,
                    Timer.MessageBoxIcon.Error, Timer.MessageBoxDefaultButton.Button1,
                    Timer.MessageBoxOptions.RightAlign | Timer.MessageBoxOptions.RtlReading);
            }
        }

        private void InitializeProgressBarPic(int maximum)
        {
            progressBarPic.Position = 0;
            progressBarPic.Properties.Step = 1;
            progressBarPic.Properties.PercentView = true;
            progressBarPic.Properties.Maximum = maximum;
            progressBarPic.Properties.Minimum = 0;
        }

        private void InitializeProgressBarImportInfo(int maximum)
        {
            progressBarImportInfo.Position = 0;
            progressBarImportInfo.Properties.Step = 1;
            progressBarImportInfo.Properties.PercentView = true;
            progressBarImportInfo.Properties.Maximum = maximum;
            progressBarImportInfo.Properties.Minimum = 0;
        }

        private static Image ResizeImage(Image image, Size size, bool preserveAspectRatio = true)
        {
            int newWidth;
            int newHeight;

            if (preserveAspectRatio)
            {
                var originalWidth = image.Width;
                var originalHeight = image.Height;
                var percentWidth = size.Width/(float) originalWidth;
                var percentHeight = size.Height/(float) originalHeight;
                var percent = percentHeight < percentWidth ? percentHeight : percentWidth;
                newWidth = (int) (originalWidth*percent);
                newHeight = (int) (originalHeight*percent);
            }
            else
            {
                newWidth = size.Width;
                newHeight = size.Height;
            }
            Image newImage = new Bitmap(newWidth, newHeight);
            using (var graphicsHandle = Graphics.FromImage(newImage))
            {
                graphicsHandle.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphicsHandle.DrawImage(image, 0, 0, newWidth, newHeight);
            }
            return newImage;
        }

        public static byte[] ImageToByte(Image img)
        {
            var converter = new ImageConverter();
            return (byte[]) converter.ConvertTo(img, typeof (byte[]));
        }

        private void PicBrows_Click(object sender, EventArgs e)
        {
            if (PicfolderBrowser.ShowDialog() == Timer.DialogResult.OK)
            {
                txtPicPath.Text = PicfolderBrowser.SelectedPath;
            }
        }

        private void btnBrows_Click_1(object sender, EventArgs e)
        {
            ExcelFileDialog.Filter = @"Excel Files (*.xlsx , *.xls)|*.xlsx;*.xls;";
            ExcelFileDialog.FilterIndex = 1;
            ExcelFileDialog.Multiselect = false;

            var result = ExcelFileDialog.ShowDialog();
            if (result == Timer.DialogResult.OK)
            {
                ExcelPicture.Visible = true;
                btnSend.Visible = true;
                DbPicture.Visible = true;
                txtPath.Text = ExcelFileDialog.FileName;
                _excelfilepath = ExcelFileDialog.FileName;
            }
        }
    }
}