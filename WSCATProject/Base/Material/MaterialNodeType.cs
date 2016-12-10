
using HelperUtility.Encrypt;
using System;
using System.Collections;
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
    public partial class MaterialNodeType : Form
    {
        ProjectInCostManager picm = new ProjectInCostManager();
        public bool isflag = false; //添加地区的返回值
        public MaterialNodeType()
        {
            InitializeComponent();
        }

        #region 点击控件空白处选中对应节点
        /// <summary>
        /// 点击控件空白处选中对应节点
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void treeView1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                treeView1.SelectedNode = treeView1.GetNodeAt(e.X, e.Y);
            }
        }
        #endregion

        #region 控件默认选中和禁用右键
        /// <summary>
        /// 控件默认选中和禁用右键
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void contextMenuStrip1_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            ///判断集合中有数据才进入后面的if  否则直接跳出
            if (treeView1.GetNodeCount(true) > 0)
            {
                InsChildNodeToolStripMenuItem.Enabled = true;
                InsChildNodeToolStripMenuItem.Enabled = true;
                新增下级分类ToolStripMenuItem1.Enabled = true;
                新增同级分类ToolStripMenuItem1.Enabled = true;
                编辑ToolStripMenuItem1.Enabled = true;
                删除ToolStripMenuItem1.Enabled = true;
                if (treeView1.SelectedNode == null) //如果当前没有选中  则默认选中从0开始的第一个
                {
                    treeView1.SelectedNode = treeView1.Nodes[0];
                    return;
                }
                int treeviewLevel = treeView1.SelectedNode.Level;   //获取当前选中的等级
                if (treeviewLevel >= 4) //如果当前选中节点的等级大于等于4  则启用新增按钮
                {
                    新增下级分类ToolStripMenuItem1.Enabled = false;
                    return;
                }
                if (treeviewLevel == 0)
                {
                    新增同级分类ToolStripMenuItem1.Enabled = false;
                    编辑ToolStripMenuItem1.Enabled = false;
                    删除ToolStripMenuItem1.Enabled = false;
                    return;
                }
                return;
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
        protected virtual void AddTree(string ParentID, TreeNode pNode, DataTable dts, string tableName)
        {
            if (ParentID == "")
            {
                ParentID = "D4";
            }
            string ParentId = "PIC_ParentId";
            string Code = "PIC_Code";
            string Name = "PIC_Name";
            if (tableName == "C")
            {
                ParentId = "City_ParentId";
                Code = "City_Code";
                Name = "City_Name";
            }

            DataTable dt = dts;
            DataView dvTree = new DataView(dt);

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
        private void toolStripButton1_DropDownOpening(object sender, EventArgs e)
        {
            新增下级分类ToolStripMenuItem.Enabled = true;
            新增同级分类ToolStripMenuItem.Enabled = true;
            编辑ToolStripMenuItem.Enabled = true;
            删除ToolStripMenuItem.Enabled = true;

            if (treeView1.SelectedNode != null)
            {
                int treeviewLevel = treeView1.SelectedNode.Level;
                if (treeviewLevel >= 4) //如果当前选中节点的等级大于等于4  则启用新增按钮
                {
                    新增下级分类ToolStripMenuItem.Enabled = false;
                    return;
                }
                if (treeviewLevel == 0)
                {
                    新增同级分类ToolStripMenuItem.Enabled = false;
                    编辑ToolStripMenuItem.Enabled = false;
                    删除ToolStripMenuItem.Enabled = false;
                    return;
                }
            }
        }

        private void 新增同级分类ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            新增同级分类ToolStripMenuItem.PerformClick();
        }

        private void 新增下级分类ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            新增下级分类ToolStripMenuItem.PerformClick();
        }

        private void 编辑ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            编辑ToolStripMenuItem.PerformClick();
        }

        private void 删除ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            删除ToolStripMenuItem.PerformClick();
        }

        private void 全部删除ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            全部删除ToolStripMenuItem.PerformClick();
        }

        private void 展开第一节ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            展开第一节ToolStripMenuItem.PerformClick();
        }

        private void 全部展开ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            全部展开ToolStripMenuItem.PerformClick();
        }

        private void 刷新ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            刷新ToolStripMenuItem.PerformClick();
        }

        private void NodeTypeMster_KeyDown(object sender, KeyEventArgs e)
        {
            e.Handled = true;
            if (e.KeyCode == Keys.B && e.Control)
            {
                新增同级分类ToolStripMenuItem.PerformClick();
            }
            if (e.KeyCode == Keys.N && e.Control)
            {
                新增下级分类ToolStripMenuItem.PerformClick();
            }
            if (e.KeyCode == Keys.E && e.Control)
            {
                编辑ToolStripMenuItem.PerformClick();
            }
            if (e.KeyCode == Keys.D && e.Control)
            {
                删除ToolStripMenuItem.PerformClick();
            }
            if (e.KeyCode == Keys.T && e.Control)
            {
                展开第一节ToolStripMenuItem.PerformClick();
            }
            if (e.KeyCode == Keys.A && e.Control)
            {
                全部展开ToolStripMenuItem.PerformClick();
            }
            if (e.KeyCode == Keys.Delete && e.Shift)
            {
                全部删除ToolStripMenuItem.PerformClick();
            }
            if (e.KeyCode == Keys.F5)
            {
                刷新ToolStripMenuItem.PerformClick();
            }
        }
    }
}
