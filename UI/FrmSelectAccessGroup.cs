using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;
using BLL;
using Model;

namespace Eco
{
    public partial class FrmSelectAccessGroup : Form
    {
        public FrmSelectAccessGroup()
        {
            InitializeComponent();
        }

        public FrmSelectAccessGroup(int organizationId)
        {
            var organizationBll = new OrganizationBll();
            InitializeComponent();
            FillComboBox();
            var org = organizationBll.Select(organizationId);
            if (org == null) return;
            if (org.AcsGroupID != null) cmbAcsGroup.SelectedValue = org.AcsGroupID;
        }

        public int AccessGroupId { get; set; }

        private void btnOk_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            AccessGroupId = (int) cmbAcsGroup.SelectedValue;
        }


        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void FrmSelectAccessGroup_Load(object sender, EventArgs e)
        {
            try
            {
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void FillComboBox()
        {
            var acsGroupBll = new AccessGroupBll();

            var acsGroups = acsGroupBll.SelectAll();
            var dtAcsGroup = ConvertToDataTable(acsGroups);

            var accessGroup = new AccessGroup
            {
                ID = 0,
                Name = "انتخاب کنید"
            };
            var row = dtAcsGroup.NewRow();
            row["ID"] = accessGroup.ID;
            row["Name"] = accessGroup.Name;
            dtAcsGroup.Rows.InsertAt(row, 0);

            cmbAcsGroup.DataSource = dtAcsGroup;
        }

        private DataTable ConvertToDataTable<T>(IList<T> data)
        {
            var properties =
                TypeDescriptor.GetProperties(typeof (T));
            var table = new DataTable();
            foreach (PropertyDescriptor prop in properties)
                table.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);
            foreach (var item in data)
            {
                var row = table.NewRow();
                foreach (PropertyDescriptor prop in properties)
                    row[prop.Name] = prop.GetValue(item) ?? DBNull.Value;
                table.Rows.Add(row);
            }
            return table;
        }

        private void cmbAcsGroup_SelectionChangeCommitted(object sender, EventArgs e)
        {
            AccessGroupId = (int) cmbAcsGroup.SelectedValue;
        }
    }
}