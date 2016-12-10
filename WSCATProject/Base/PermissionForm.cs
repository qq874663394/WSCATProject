using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;
using HelperUtility;
using System.Collections;
using DevComponents.DotNetBar.SuperGrid;
using Model;
using HelperUtility.Encrypt;

namespace WSCATProject.Base
{
    public partial class PermissionForm : Form
    {
        public PermissionForm()
        {
            InitializeComponent();
        }

        DataTable _datalist = new DataTable();

        private void PermissionForm_Load(object sender, EventArgs e)
        {
            loadUser();
            loadModuleList();
            loadPermission();
        }

        /// <summary>
        /// 初始化用户列表
        /// </summary>
        private void loadUser()
        {
            RoleManager rm = new RoleManager();
            DataSet ds = rm.GetList("");
            if(ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    treeViewUser.Nodes.Add(
                        ds.Tables[0].Rows[i]["Role_Name"].ToString());
                    treeViewUser.Nodes[i].Tag = ds.Tables[0].Rows[i]["Role_Code"].ToString();
                }
            }
            
        }

        /// <summary>
        /// 加载类型列表(固定) 读取INI列表 
        /// </summary>
        private void loadModuleList()
        {
            string[] key;
            string[] value;
            INIHelper.GetAllKeyValues("info", out key, out value, Application.StartupPath + "\\permission.ini");
            if(key.Length > 0)
            {
                ArrayList list = new ArrayList();
                for(int i=0;i<key.Length;i++)
                {
                    list.Add(new DictionaryEntry(key[i], value[i]));
                }
                comboBoxEx1.DataSource = list;
                comboBoxEx1.DisplayMember = "Key";
                comboBoxEx1.ValueMember = "Value";
            }
        }

        /// <summary>
        /// 加载datagridview 
        /// </summary>
        private void loadPermission()
        {
            //PermissionManager pm = new PermissionManager();
            //_datalist = pm.GetList("Per_RoleCode = '" + 
            //    XYEEncoding.strCodeHex(treeViewUser.SelectedNode.Tag.ToString()) + "'").Tables[0];
            //superGridControlPer.PrimaryGrid.DataSource = _datalist;
            //_datalist.AcceptChanges();
        }
        //全选
        private void buttonSelectAll_Click(object sender, EventArgs e)
        {
            GridItemsCollection gc = superGridControlPer.PrimaryGrid.Rows;
            foreach(GridRow gr in gc)
            {
                gr.Cells["Per_ReadState"].Value = true;
                gr.Cells["Per_WriteState"].Value = true;
                gr.Cells["Per_AuditState"].Value = true;
            }
        }
        //反选
        private void buttonInverse_Click(object sender, EventArgs e)
        {
            GridItemsCollection gc = superGridControlPer.PrimaryGrid.Rows;
            foreach (GridRow gr in gc)
            {
                gr.Cells["Per_ReadState"].Value = 
                    (bool)gr.Cells["Per_ReadState"].Value == true ? false : true;
                gr.Cells["Per_WriteState"].Value = 
                    (bool)gr.Cells["Per_WriteState"].Value == true ? false : true;
                gr.Cells["Per_AuditState"].Value = 
                    (bool)gr.Cells["Per_AuditState"].Value == true ? false : true;
            }
        }

        private void comboBoxEx1_SelectedIndexChanged(object sender, EventArgs e)
        {
            PermissionManager pm = new PermissionManager();
            string itemText = comboBoxEx1.Text;
            //模糊检索数据并绑定  
            superGridControlPer.PrimaryGrid.DataSource = 
                pm.searchClientByNodeClick(_datalist, itemText);
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            PermissionManager pm = new PermissionManager();

            try
            {
                if (pm.UpdateBatch(_datalist))
                {
                    MessageBox.Show("权限分配保存成功");
                }
                else
                {
                    MessageBox.Show("权限并未做任何更改");
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("保存异常,请检查服务器连接.异常信息:" + ex.Message);
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void 新增角色ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RoleCreateForm rcf = new RoleCreateForm();
            rcf.refresh += refresh;
            rcf.ShowDialog();
        }

        private void 修改角色ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void 删除角色ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void refresh(string nodeText,string code)
        {
            TreeNode tn = new TreeNode();
            tn.Text = nodeText;
            tn.Tag = code;
            treeViewUser.Nodes.Add(tn);
        }

        private void treeViewUser_AfterSelect(object sender, TreeViewEventArgs e)
        {
            //根据点击的节点来查询权限信息,若点击的是管理员,则把编辑给禁止掉
            if (treeViewUser.SelectedNode.Text == "管理员")
            {
                superGridControlPer.PrimaryGrid.AllowEdit = false;
                buttonSelectAll.Enabled = false;
                buttonInverse.Enabled = false;
                buttonSave.Enabled = false;
            }
            else
            {
                superGridControlPer.PrimaryGrid.AllowEdit = true;
            }
            PermissionManager pm = new PermissionManager();
            string rolecode = treeViewUser.SelectedNode.Tag.ToString();
            _datalist = pm.
                GetList("Per_RoleCode = '" + XYEEncoding.strCodeHex(rolecode) + "'").Tables[0];
            superGridControlPer.PrimaryGrid.DataSource = _datalist;
            _datalist.AcceptChanges();
        }
    }
    
}
