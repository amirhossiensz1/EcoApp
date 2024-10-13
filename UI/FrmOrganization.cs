using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using BLL;
using Model;
using Telerik.WinControls.Primitives;
using Telerik.WinControls.UI;

namespace Eco
{
    public partial class FrmOrganization : Form
    {
        private readonly OrganizationBll _organizationBll = new OrganizationBll();

        public FrmOrganization()
        {
            InitializeComponent();
        }


        private void FrmOrganization_Load(object sender, EventArgs e)
        {
            TreeViewLocalizationProvider.CurrentProvider = new PersianTreeViewLocalizationProvider();

            LoadData();
            TreeOrganization.ExpandAll();
            // TreeOrganization.ContextMenu.MenuItems.Add("", new MenuItem[8]);
        }

        private void LoadData()
        {
            try
            {
                var dt = ConvertToDataTable(_organizationBll.SelectAll());
                TreeOrganization.DataSource = dt;
            }
            catch (Exception)
            {
                throw;
            }
        }


        public DataTable ConvertToDataTable<T>(IList<T> data)
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


        private void BtnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
        }

        private void TreeOrganization_NodeAdded(object sender, RadTreeViewEventArgs e)
        {
            try
            {
                e.Node.Text = "گره جدید";
                var organization = new Organization();
                var arrayItem = (DataRowView) e.TreeView.SelectedNode.DataBoundItem;
                if (!(arrayItem[0] is int))
                    return;
                organization.OrganizationID = (int) arrayItem[0];
                organization.name = e.Node.Text;
                var result = _organizationBll.Insert(organization);

                if (result > 0)
                {
                    var dataRow = (DataRowView) e.Node.DataBoundItem;
                    dataRow[0] = result;
                    e.Node.BeginEdit();
                }
            }
            catch (Exception exception)
            {
                throw;
            }
        }


        private void TreeOrganization_Edited(object sender, TreeNodeEditedEventArgs e)
        {
            try
            {
                var arrayItem = (DataRowView) e.TreeView.SelectedNode.DataBoundItem;
                if (!(arrayItem[0] is int) || !(arrayItem[1] is int))
                    return;
                var org = new Organization
                {
                    name = e.Node.Text,
                    ID = (int) arrayItem[0],
                    OrganizationID = (int) arrayItem[1]
                };

                var result = _organizationBll.Update(org);
                if (result > 0)
                {
                    LoadData();
                    TreeOrganization.ExpandAll();
                    TreeOrganization.Refresh();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void TreeOrganization_NodeRemoving(object sender, RadTreeViewCancelEventArgs e)
        {
            try
            {
                var arrayItem = (DataRowView) e.TreeView.SelectedNode.DataBoundItem;
                if (!(arrayItem[0] is int))
                    return;
                var result = _organizationBll.Delete((int) arrayItem[0]);
                if (result > 0)
                {
                   // MessageBox.Show("ok");
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void TreeOrganization_DragDrop(object sender, DragEventArgs e)
        {
            var a = e.Data;
        }

        private void TreeOrganization_ContextMenuOpening(object sender, TreeViewContextMenuOpeningEventArgs e)
        {
            e.Menu.Items.Remove(e.Menu.Items[e.Menu.Items.Count - 1]);
            e.Menu.Items.Remove(e.Menu.Items[e.Menu.Items.Count - 1]);
            e.Menu.Items.Remove(e.Menu.Items[e.Menu.Items.Count - 1]);
            try
            {
                var rt = new RadMenuItem {Text = @"تخصیص گروه دسترسی"};
                e.Menu.Items.Add(rt);
                if (e.TreeView.SelectedNode.DataBoundItem != null)
                {
                    var arrayItem = (DataRowView) e.TreeView.SelectedNode.DataBoundItem;
                    if (!(arrayItem[0] is int))
                        return;
                    e.Menu.Items[4].Click += (sender1, e1) => assignAccessGroup_Click(sender, e, (int) arrayItem[0]);
                }
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("Object reference not set to an instance of an object"))
                    Console.Write(@"Object reference not set to an instance of an object.");
            }
        }

        private void assignAccessGroup_Click(object sender, EventArgs e, int organizationId)
        {
            try
            {
                var frmSelectAccessGroup = new FrmSelectAccessGroup(organizationId);
                var organizationBll = new OrganizationBll();
                var result = frmSelectAccessGroup.ShowDialog();
                TreeOrganization.ClearSelection();
                if (result == DialogResult.OK)
                {
                    if (frmSelectAccessGroup.AccessGroupId != 0)
                    {
                        organizationBll.UpdateAcsGroup(organizationId, frmSelectAccessGroup.AccessGroupId);
                        LoadData();
                        TreeOrganization.ExpandAll();
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void TreeOrganization_CreateNodeElement(object sender, CreateTreeNodeElementEventArgs e)
        {
            try
            {
                e.NodeElement = new CustomTreeNodeElement();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }

    public class CustomTreeNodeElement : TreeNodeElement
    {
        protected override Type ThemeEffectiveType
        {
            get { return typeof (TreeNodeElement); }
        }

        protected override TreeNodeContentElement CreateContentElement()
        {
            return new CustomContentElement();
        }

        protected override void InitializeFields()
        {
            base.InitializeFields();
            StretchHorizontally = false;
        }

        public override bool IsCompatible(RadTreeNode data, object context)
        {
            return data.Level == 0;
        }
    }

    public class CustomContentElement : TreeNodeContentElement
    {
        public RadLabelElement lbAccessGroup;
        private LinePrimitive _lineElement;
        private StackLayoutElement nodeContentContainer;
        private RadLabelElement textElement;

        protected override Type ThemeEffectiveType
        {
            get { return typeof (TreeNodeContentElement); }
        }


        protected override void CreateChildElements()
        {
            textElement = new RadLabelElement();
            textElement.Margin = new Padding(100, 15, 2, 0);
            textElement.ShouldHandleMouseInput = false;
            textElement.NotifyParentOnMouseInput = true;
            textElement.StretchVertically = false;
            Children.Add(textElement);


            lbAccessGroup = new RadLabelElement();
            lbAccessGroup.Margin = new Padding(5, 30, 10, 0);
            lbAccessGroup.StretchVertically = true;
            Children.Add(lbAccessGroup);
        }

        public override void Synchronize()
        {
            try
            {
                var a = (DataRowView) NodeElement.Data.DataBoundItem;
                var accessGroupBll = new AccessGroupBll();

                lbAccessGroup.Text = @"";

                
           //     Write_File(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location),"Db"),a[4].ToString()+"\r\n");

                /*   if (a[4] is int)
                   {
                         var name = accessGroupBll.Select((int) a[4]).Name;
                         if (name != null)
                             lbAccessGroup.Text = @"(نام گروه دسترسی :" + name + ")";
                   }*/
                textElement.Text = NodeElement.Data.Text;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public void Write_File(string path, string log)
        {
            try
            {
                    if (!Directory.Exists(path))
                        Directory.CreateDirectory(path);
                    File.AppendAllText(path + "\\" +  ".txt", log);
            }
            catch (Exception ex)
            {

            }
        }
    }



    public class PersianTreeViewLocalizationProvider : TreeViewLocalizationProvider
    {
        public override string GetLocalizedString(string id)
        {
            switch (id)
            {
                case TreeViewStringId.ContextMenuCollapse:
                    return "بستن گره ها";
                case TreeViewStringId.ContextMenuDelete:
                    return "حذف";
                case TreeViewStringId.ContextMenuEdit:
                    return "ویرایش";
                case TreeViewStringId.ContextMenuExpand:
                    return "باز کردن گره ها";
                case TreeViewStringId.ContextMenuNew:
                    return "اضافه کردن";
                case TreeViewStringId.ContextMenuCopy:
                    return "کپی";
                case TreeViewStringId.ContextMenuPaste:
                    return "چسباندن";
                case TreeViewStringId.ContextMenuCut:
                    return "برداشتن";
            }

            return "";
        }
    }
}