using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using Model;
using HelperUtility.Encrypt;

namespace WSCATProject.Base
{
    public partial class MaterialTypeForm : RibbonForm
    {
        public MaterialTypeForm()
        {
            InitializeComponent();
        }

        private bool isflag = false;
        /// <summary>
        /// 判断是否刷新数据
        /// </summary>
        public bool Isflag
        {
            get
            {
                return isflag;
            }

            set
            {
                isflag = value;
            }
        }

        #region 初始化

        private void MaterialTypeForm_Load(object sender, EventArgs e)
        {
            StartPosition = FormStartPosition.CenterParent;
            try
            {
                loadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("程序异常，请检查服务器连接。异常：" + ex.Message);
                Close();
            }
        }

        private void loadData()
        {
            AddTree("", null, "", selectDataView());

        }

        //递归添加树的节点
        private void AddTree(string ParentID, TreeNode pNode, string table, DataView dvTree )
        {
            if (ParentID == "")
            {
                ParentID = "0";
            }
            string ParentId = "MT_ParentID";
            string Code = "MT_Code";
            string Name = "MT_Name";
            
            //过滤ParentID,得到当前的所有子节点
            dvTree.RowFilter = string.Format("{0} = '{1}'", ParentId, ParentID);
            foreach (DataRowView Row in dvTree)
            {
                TreeNode Node = new TreeNode();
                if (pNode == null)
                {
                    //添加根节点
                    Node.Text = Row[Name].ToString();
                    Node.Tag = Row[Code].ToString();
                    treeViewType.Nodes.Add(Node);
                    AddTree(Row[Code].ToString(), Node, table, dvTree);
                    //展开第一级节点
                    Node.Expand();
                }
                else
                {
                    //添加当前节点的子节点
                    Node.Text = Row[Name].ToString();
                    Node.Tag = Row[Code].ToString();
                    pNode.Nodes.Add(Node);
                    AddTree(Row[Code].ToString(), Node, table, dvTree);//再次递归
                }
            }
        }

        #endregion

        #region 菜单操作

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            if (treeViewType.SelectedNode != null && treeViewType.SelectedNode.Text != "所有类型")
            {
                MateCreateTypeForm materialF = new MateCreateTypeForm();
                materialF.matype_code = treeViewType.SelectedNode.Parent.Tag.ToString();
                materialF.ShowDialog(this);
                refresh();
            }
            else
            {
                MessageBox.Show("请选择不为'所有类型'节点的其他节点");
            }
        }

        private void 新增ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (treeViewType.SelectedNode != null)
            {
                MateCreateTypeForm materialF = new MateCreateTypeForm();
                materialF.matype_code = treeViewType.SelectedNode.Tag.ToString();
                materialF.ShowDialog(this);
                refresh();
            }
            else
            {
                MessageBox.Show("请先选择要增加的下级节点的父级节点");
            }
        }

        private void 编辑ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (treeViewType.SelectedNode != null)
            {
                MaterialType mt = new MaterialType();
                mt.MT_Code = treeViewType.SelectedNode.Tag.ToString();
                mt.MT_Name = treeViewType.SelectedNode.Text;
                mt.MT_ParentID = treeViewType.SelectedNode.Parent.Tag.ToString();
                mt.MT_Clear = 1;
                mt.MT_Enable = 1;
                MateCreateTypeForm mateCreateF = new MateCreateTypeForm();
                //赋值子窗体的实体,填充修改项
                mateCreateF.materialType = mt;
                mateCreateF.ShowDialog(this);
                refresh();
            }
            else
            {
                MessageBox.Show("请选择要更改的客户类型");
            }
        }

        private void 删除DToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (treeViewType.SelectedNode != null || 
                treeViewType.SelectedNode.Text != "所有类型")
            {
                if(MessageBox.Show("确定要删除该数据吗?操作不可恢复", "请注意",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes)
                {
                    return;
                }
                MaterialTypeManager mtm = new MaterialTypeManager();
                try
                {
                    if (mtm.DeleteFake(treeViewType.SelectedNode.Tag.ToString()))
                    {
                        MessageBox.Show("删除成功，请检查!");
                        isflag = true;
                        refresh();
                    }
                    else
                    {
                        MessageBox.Show("删除失败,未删除任何行");
                    }
                }
                catch (Exception ex)
                {

                    MessageBox.Show("删除失败,请检查服务器连接,错误:" + ex.Message);
                }
            }
        }

        private void 全部删除AToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确定要删除该数据吗?操作不可恢复", "请注意",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes)
            {
                return;
            }
            MaterialTypeManager mtm = new MaterialTypeManager();
            try
            {
                if (mtm.DeleteAllFake())
                {
                    MessageBox.Show("删除成功");
                    isflag = true;
                    refresh();
                }
                else
                {
                    MessageBox.Show("删除失败,未删除任何数据,请重试");
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("删除失败,请检查服务器连接,错误:" + ex.Message);
            }
        }

        private void 全部展开ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            treeViewType.Nodes[0].ExpandAll();
        }

        private void 展开ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(treeViewType.SelectedNode != null)
            {
                treeViewType.SelectedNode.Expand();
            }
        }

        #endregion

        #region 右键菜单操作

        /// <summary>
        /// 点右边空白定位到左边节点
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void treeViewClient_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                treeViewType.SelectedNode = treeViewType.GetNodeAt(e.X, e.Y);
            }
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (treeViewType.SelectedNode != null && treeViewType.SelectedNode.Text != "所有类型")
            {
                MateCreateTypeForm materialF = new MateCreateTypeForm();
                materialF.matype_code = treeViewType.SelectedNode.Parent.Tag.ToString();
                materialF.ShowDialog(this);
                refresh();
            }
            else
            {
                MessageBox.Show("请选择不为'所有类型'节点的其他节点");
            }
        }

        private void 新增下级分类ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            新增ToolStripMenuItem.PerformClick();
        }

        private void 编辑ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            编辑ToolStripMenuItem.PerformClick();
        }

        private void 删除ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            删除DToolStripMenuItem.PerformClick();
        }

        private void 全部删除ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            全部删除AToolStripMenuItem.PerformClick();
        }

        private void 展开ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            展开ToolStripMenuItem.PerformClick();
        }

        private void 展开全部ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            全部展开ToolStripMenuItem.PerformClick();
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            //判断集合中有数据才进入后面的if  否则直接跳出
            if (treeViewType.GetNodeCount(true) > 0)
            {
                新增ToolStripMenuItem.Enabled = true;
                新增下级分类ToolStripMenuItem.Enabled = true;
                toolStripMenuItem2.Enabled = true;
                toolStripMenuItem1.Enabled = true;
                编辑ToolStripMenuItem.Enabled = true;
                编辑ToolStripMenuItem1.Enabled = true;
                删除DToolStripMenuItem.Enabled = true;
                删除ToolStripMenuItem.Enabled = true;

                if (treeViewType.SelectedNode == null) //如果当前没有选中  则默认选中从0开始的第一个
                {
                    treeViewType.SelectedNode = treeViewType.Nodes[0];
                    return;
                }
                int treeviewLevel = treeViewType.SelectedNode.Level;   //获取当前选中的等级
                if (treeviewLevel >= 4) //如果当前选中节点的等级大于等于4  则启用新增按钮
                {
                    新增下级分类ToolStripMenuItem.Enabled = false;
                    新增ToolStripMenuItem.Enabled = false;
                    return;
                }
                if (treeviewLevel == 0)
                {
                    toolStripMenuItem2.Enabled = false;
                    toolStripMenuItem1.Enabled = false;
                    编辑ToolStripMenuItem.Enabled = false;
                    编辑ToolStripMenuItem1.Enabled = false;
                    删除DToolStripMenuItem.Enabled = false;
                    删除ToolStripMenuItem.Enabled = false;
                    return;
                }
                return;
            }
        }

        #endregion

        #region 通用方法

        /// <summary>
        /// 返回所有存在的节点
        /// </summary>
        /// <returns></returns>
        private DataView selectDataView()
        {
            DataView dvTree;
            MaterialTypeManager mtm = new MaterialTypeManager();
            DataTable dt = mtm.GetList("").Tables[0];
            dvTree = new DataView(dt);
            return dvTree;
        }

        /// <summary>
        /// 由之前的创建或修改结果确定是否刷新数据,子窗体关闭前给标志赋值.
        /// </summary>
        private void refresh()
        {
            if (Isflag)
            {
                treeViewType.Nodes.Clear();
                try
                {
                    AddTree("", null, "", selectDataView());
                }
                catch (Exception ex)
                {
                    MessageBox.Show("查询错误，请检查服务器连接。错误:" + ex.Message);
                    Close();
                }
                Isflag = false;
                this.Focus();
            }
        }




        #endregion
    }
}