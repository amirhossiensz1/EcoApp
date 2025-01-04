using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using BLL;
using DevExpress.Data;
using DevExpress.Utils;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraRichEdit.Model;
using zkemkeeper;

namespace UI
{
    public partial class FrmAllLogs : Form
    {
        public FrmAllLogs()
        {
            InitializeComponent();
            girdViewAllLogs.GroupPanelText = @"جهت فیلتر کردن هر ستون ستون مورد نظر را به این قسمت بکشید";
        }

        private List<string> TypeList()
        {
            var typeList = new List<string>();

            foreach (var i in Enum.GetValues(typeof (TypeExport)))
            {
                typeList.Add(((TypeExport) i).ToString());
            }
            return typeList;
        }

        public void FrmAllLogs_Load(object sender, EventArgs e)
        {

            var trafficLogBll = new TrafficLogBLL();
            grdViewAllLogs.DataSource = trafficLogBll.SelectLog();
            CmbBxType.DataSource = TypeList();
             


            girdViewAllLogs.Columns["Date"].SortOrder = ColumnSortOrder.Descending;
            girdViewAllLogs.Columns["Time"].SortOrder = ColumnSortOrder.Descending;

            // ReSharper disable once AssignNullToNotNullAttribute
            var imagesDirectory = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "Images");
           
            var imageCombo = grdViewAllLogs.RepositoryItems.Add("ImageComboBoxEdit") as RepositoryItemImageComboBox;
            var acessCombo = grdViewAllLogs.RepositoryItems.Add("ImageComboBoxEdit") as RepositoryItemImageComboBox;
            var reqTypeCombo = grdViewAllLogs.RepositoryItems.Add("ImageComboBoxEdit") as RepositoryItemImageComboBox;

            var images = new ImageCollection();
            var imagesReqType = new ImageCollection();
            images.ImageSize = new Size(32, 32);
            imagesReqType.ImageSize = new Size(64, 64);

            images.AddImage(Image.FromFile(imagesDirectory + "\\inputTrue.png"));

            images.AddImage(Image.FromFile(imagesDirectory + "\\outputTrue.png"));

            images.AddImage(Image.FromFile(imagesDirectory + "\\inputFalse.png"));

            images.AddImage(Image.FromFile(imagesDirectory + "\\outputFalse.png"));

            images.AddImage(Image.FromFile(imagesDirectory + "\\check.png"));

            images.AddImage(Image.FromFile(imagesDirectory + "\\multiply.png"));



            imagesReqType.AddImage(Image.FromFile(imagesDirectory + "\\Id.png"));

            imagesReqType.AddImage(Image.FromFile(imagesDirectory + "\\Num.png"));

            imagesReqType.AddImage(Image.FromFile(imagesDirectory + "\\Pbi.png"));

            imagesReqType.AddImage(Image.FromFile(imagesDirectory + "\\Dsi.png"));

            imagesReqType.AddImage(Image.FromFile(imagesDirectory + "\\Card.png"));

            imagesReqType.AddImage(Image.FromFile(imagesDirectory + "\\Num1.png"));

            imagesReqType.AddImage(Image.FromFile(imagesDirectory + "\\Finger.png"));

            imagesReqType.AddImage(Image.FromFile(imagesDirectory + "\\Face.png"));



            imageCombo.LargeImages = images;
            acessCombo.LargeImages = images;
            reqTypeCombo.LargeImages = imagesReqType;

            imageCombo.Items.Add(new ImageComboBoxItem("input", 1, 0));

            imageCombo.Items.Add(new ImageComboBoxItem("output", 2, 1));

            imageCombo.Items.Add(new ImageComboBoxItem("input", 3, 2));

            imageCombo.Items.Add(new ImageComboBoxItem("output", 4, 3));


            acessCombo.Items.Add(new ImageComboBoxItem("check", true, 4));

            acessCombo.Items.Add(new ImageComboBoxItem("multiply", false, 5));



            reqTypeCombo.Items.Add(new ImageComboBoxItem("Id", "Id", 0));

            reqTypeCombo.Items.Add(new ImageComboBoxItem("Num", "Num", 1));

            reqTypeCombo.Items.Add(new ImageComboBoxItem("Pbi", "Pbi", 2));

            reqTypeCombo.Items.Add(new ImageComboBoxItem("Dsi", "Dsi", 3));

            reqTypeCombo.Items.Add(new ImageComboBoxItem("Card", "Card", 4));

            reqTypeCombo.Items.Add(new ImageComboBoxItem("Num1", "Num1", 5));

            reqTypeCombo.Items.Add(new ImageComboBoxItem("Finger", "Finger", 6));

            reqTypeCombo.Items.Add(new ImageComboBoxItem("Face", "Face", 7));



            imageCombo.GlyphAlignment = HorzAlignment.Center;

            girdViewAllLogs.Columns["Type"].ColumnEdit = imageCombo;

            acessCombo.GlyphAlignment = HorzAlignment.Center;
            girdViewAllLogs.Columns["SuccessPass"].ColumnEdit = acessCombo;

            reqTypeCombo.GlyphAlignment = HorzAlignment.Center;

            girdViewAllLogs.Columns["ReqType"].ColumnEdit = reqTypeCombo;
        }

        private void BtnExport_Click(object sender, EventArgs e)
        {
            var logDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\Logs";
            if (!Directory.Exists(logDirectory))
            {
                Directory.CreateDirectory(logDirectory);
            }
            if (CmbBxType.SelectedValue.ToString() == TypeExport.Pdf.ToString())
            {
                // ReSharper disable once AssignNullToNotNullAttribute
                var pdfDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) +
                                   "\\Logs\\AllTraffic.pdf";

                girdViewAllLogs.ExportToPdf(pdfDirectory);
            }
            if (CmbBxType.SelectedValue.ToString() == TypeExport.Excel.ToString())
            {
                // ReSharper disable once AssignNullToNotNullAttribute
                var xlsDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) +
                                   "\\Logs\\Alltraffic.xlsx";

                girdViewAllLogs.ExportToXlsx(xlsDirectory);
            }
            if (CmbBxType.SelectedValue.ToString() == TypeExport.Csv.ToString())
            {
                // ReSharper disable once AssignNullToNotNullAttribute
                var cvsDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) +
                                   "\\Logs\\Alltraffic.csv";


                girdViewAllLogs.ExportToCsv(cvsDirectory);
            }
        }

        private void BtnPrint_Click(object sender, EventArgs e)
        {
            girdViewAllLogs.ShowPrintPreview();
        }

        private void grdViewAllLogs_Click(object sender, EventArgs e)
        {
        }

        private enum TypeExport
        {
            Pdf = 0,
            Excel,
            Csv
        };

        private void lblTypeExport_Click(object sender, EventArgs e)
        {

        }

        private void CmbBxType_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}