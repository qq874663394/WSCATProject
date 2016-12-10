using HelperUtility.Encrypt;
using InterfaceLayer.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using InterfaceLayer;

namespace WSCATProject.Base.Shelves
{
    public partial class ShelvesListForm : Form
    {
        public ShelvesListForm()
        {
            InitializeComponent();
        }
        StorageRackInterface storage = new StorageRackInterface();
        #region 绑定TreeView
        /// <summary>
        /// 绑定TreeView
        /// </summary>
        private void BindTreeViewList()
        {
            try
            {
                DataTable dts = storage.SelStorageRack();
                AddTree("A7AFC9D5D6D5D6D0D1D0D3D1D1D1D1", null, dts, "C");
            }
            catch (Exception ex)
            {
                MessageBox.Show("加载数据失败,请检查服务器连接并尝试刷新.错误:" + ex.Message);
            }
        }
        #endregion

        #region 递归添加树的节点
        /// <summary>
        /// //递归添加树的节点
        /// </summary>
        /// <param name="ParentID">条件ID:默认D4</param>
        /// <param name="pNode">父级ID：null</param>
        /// <param name="dt">查询结果集:DataTable</param>
        protected void AddTree(string ParentID, TreeNode pNode, DataTable dts, string tableName)
        {
            if (ParentID == "")
            {
                ParentID = "A7AFC9D5D6D5D6D0D1D0D3D1D1D1D1";
            }
            string ParentId = "parentId";
            string Code = "code";
            string Name = "name";

            //DataTable dt = dts;
            DataView dvTree = new DataView(dts);

            //过滤ParentID,得到当前的所有子节点
            dvTree.RowFilter = string.Format("{0} = '{1}'", ParentId, ParentID);

            foreach (DataRowView Row in dvTree)
            {
                TreeNode Node = new TreeNode();
                if (pNode == null)
                {
                    //添加根节点    
                    Node.Text = XYEEncoding.strHexDecode(Row[Name].ToString());
                    Node.Tag = XYEEncoding.strHexDecode(Row[Code].ToString());

                    treeView1.Nodes.Add(Node);
                    AddTree(Row[Code].ToString(), Node, dts, tableName);
                    //展开第一级节点
                    Node.Expand();
                }
                else
                {
                    //添加当前节点的子节点                  
                    Node.Text = XYEEncoding.strHexDecode(Row[Name].ToString());
                    Node.Tag = XYEEncoding.strHexDecode(Row[Code].ToString());
                    pNode.Nodes.Add(Node);
                    AddTree(Row[Code].ToString(), Node, dts, tableName);     //再次递归 
                }
            }
        }
        #endregion
        /// <summary>
        /// 窗体加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ShelvesListForm_Load(object sender, EventArgs e)
        {
            comboBoxck.SelectedItem = 0;
            StorageInterface sif = new StorageInterface();
            DataTable dt = sif.GetList(999,"");
            DataRow dr = dt.NewRow();
            dr["name"] = "请选择";
            dt.Rows.InsertAt(dr, 0);

            comboBoxck.DisplayMember = "name";
            comboBoxck.ValueMember = "code";
            comboBoxck.DataSource = dt;

            BindTreeViewList();
        }
        /// <summary>
        /// 选择仓库显示不同货架
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comboBoxck_SelectedIndexChanged(object sender, EventArgs e)
        {
            string ck = this.comboBoxck.SelectedValue.ToString();
            try
            {
                string jiamck = XYEEncoding.strCodeHex(ck);
                DataTable dts = storage.SelStorageRackByCode(jiamck);
                AddTree(jiamck, null, dts, "C");
            }
            catch (Exception ex)
            {
                MessageBox.Show("加载数据失败,请检查服务器连接并尝试刷新.错误:" + ex.Message);
            }
        }
    }
}
