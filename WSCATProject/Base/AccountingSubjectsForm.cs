using DevComponents.AdvTree;
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

namespace WSCATProject.Base
{
    public partial class AccountingSubjectsForm : Form
    {
        public AccountingSubjectsForm()
        {
            InitializeComponent();
        }

        CodingHelper ch = new CodingHelper();
        StorageRackInterface srif = new StorageRackInterface();
        StorageInterface sif = new StorageInterface();

        private void AccountingSubjectsForm_Load(object sender, EventArgs e)
        {
            
        }

        private void AddTree(string ParentID, Node pNode, string table)
        {
            if (ParentID == "")
            {
                ParentID = "D4";
            }
            string ParentId = "parentID";
            string Code = "code";
            string Name = "name";
            DataTable dt = sif.GetList(999,"");
            if (table == "P")
            {
                ParentId = "parentID";
                Code = "code";
                Name = "name";
                dt = srif.SelStorageRackByCode(ParentId);
            }
            DataView dvTree = new DataView(dt);
            //过滤ParentID,得到当前的所有子节点
            dvTree.RowFilter = string.Format("{0} = '{1}'", ParentId, ParentID);
            foreach (DataRowView Row in dvTree)
            {
                Node node = new Node();
                if (pNode == null)
                {
                    //添加根节点
                    node.Text = XYEEncoding.strHexDecode(Row[Name].ToString());
                    node.Tag = XYEEncoding.strHexDecode(Row[Code].ToString());
                    treeView1.Nodes.Add(node.ToString());
                    AddTree(Row[Code].ToString(), node, table);
                    //展开第一级节点
                    node.Expand();
                }
                else
                {
                    //添加当前节点的子节点
                    node.Text = XYEEncoding.strHexDecode(Row[Name].ToString());
                    node.Tag = XYEEncoding.strHexDecode(Row[Code].ToString());
                    pNode.Nodes.Add(node);
                    AddTree(Row[Code].ToString(), node, table);//再次递归 
                }
            }
        }


        /// <summary>
        /// 资产
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tabItemZiChan_Click(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// 负债
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tabItemFuZhai_Click(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// 权益
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tabItemQuanYi_Click(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// 成本
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tabItemChengBen_Click(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// 损益
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tabItemSunYi_Click(object sender, EventArgs e)
        {

        }
    }
}
