using BLL;
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
    public partial class ProjectInCostType : MaterialNodeType
    {
        ProjectInCostManager picm = new ProjectInCostManager();
        ProjectInCostNode picn = null;
        public ProjectInCostType()
        {
            InitializeComponent();
            //菜单工具栏
            新增同级分类ToolStripMenuItem.Click += 新增同级分类ToolStripMenuItem_Click;
            新增下级分类ToolStripMenuItem.Click += 新增下级分类ToolStripMenuItem_Click;
            编辑ToolStripMenuItem.Click += 编辑ToolStripMenuItem_Click;
            删除ToolStripMenuItem.Click += 删除ToolStripMenuItem_Click;
            全部删除ToolStripMenuItem.Click += 全部删除ToolStripMenuItem_Click;
            展开第一节ToolStripMenuItem.Click += 展开第一节ToolStripMenuItem_Click;
            全部展开ToolStripMenuItem.Click += 全部展开ToolStripMenuItem_Click;
            刷新ToolStripMenuItem.Click += 刷新ToolStripMenuItem_Click;

            //右键菜单
        }

        private void ProjectInCostType_Load(object sender, EventArgs e)
        {
            StartPosition = FormStartPosition.CenterParent;
            Text = "其他收入项目";
            BindTreeViewList();
        }

        private void 刷新ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            treeView1.Nodes.Clear();
            BindTreeViewList();
        }

        private void 全部展开ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            treeView1.Nodes[0].ExpandAll();
        }

        private void 展开第一节ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            treeView1.Nodes[0].Expand();
        }

        private void 全部删除ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (DialogResult.Yes == MessageBox.Show("确定全部删除吗? 删除后将不可恢复!", "WACAT管家", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1))
            {
                try
                {
                    int result = picm.UpdateAllClearProjectInCost();
                    if (result > 0)
                    {
                        MessageBox.Show("删除成功!");
                        treeView1.Nodes.Clear();
                        BindTreeViewList();
                    }
                    else
                    {
                        MessageBox.Show("删除失败!");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("删除失败,请检查服务器连接并尝试重新删除.错误:" + ex.Message);
                }
            }
        }

        private void 删除ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (DialogResult.Yes == MessageBox.Show("确定删除吗? 删除后将不可恢复!", "WACAT管家", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1))
            {
                if (treeView1.SelectedNode == null)
                {
                    return;
                }
                string code = treeView1.SelectedNode.Tag.ToString();
                try
                {
                    int result = picm.UpdateClearProjectInCost(code);
                    if (result > 0)
                    {
                        MessageBox.Show("删除成功");
                        treeView1.Nodes.Clear();
                        BindTreeViewList();
                    }
                    else
                    {
                        MessageBox.Show("删除失败");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("删除失败,请检查服务器连接并尝试重新删除.错误:" + ex.Message);
                }
            }
        }

        private void 编辑ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            picn = new ProjectInCostNode();
            picn.state = 2;
            picn.txtName = treeView1.SelectedNode.Text;
            picn.code = treeView1.SelectedNode.Tag.ToString();
            picn.ShowDialog(this);
            if (isflag)
            {
                treeView1.Nodes.Clear();
                BindTreeViewList();
            }
        }

        private void 新增下级分类ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            picn = new ProjectInCostNode();
            picn.state = 1;
            picn.txtName = treeView1.SelectedNode.Text;
            picn.code = treeView1.SelectedNode.Tag.ToString();
            picn.ShowDialog(this);
            if (isflag)
            {
                treeView1.Nodes.Clear();
                BindTreeViewList();
            }
        }

        private void 新增同级分类ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            picn = new ProjectInCostNode();
            picn.state = 0;
            picn.txtName = treeView1.SelectedNode.Text;
            picn.code = treeView1.SelectedNode.Parent.Tag.ToString();
            picn.ShowDialog(this);
            if (isflag)
            {
                treeView1.Nodes.Clear();
                BindTreeViewList();
            }
        }

        private void BindTreeViewList()
        {
            try
            {
                DataTable dts = picm.SelProjectInCostTable();
                base.AddTree("D4", null, dts, "");
            }
            catch (Exception ex)
            {
                MessageBox.Show("加载数据失败,请检查服务器连接并尝试刷新.错误:" + ex.Message);
            }
        }
    }
}
