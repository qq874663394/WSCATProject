using DevComponents.AdvTree;
using DevComponents.DotNetBar.Controls;
using HelperUtility.Encrypt;
using InterfaceLayer.Finance;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace WSCATProject.Finance
{
    public partial class FinanceSummaryLibraryForm : Form
    {
        public static int dialog = 0; //摘要的添加或删除对话框
        public static string code; //修改传递的code数据
        public static string name; //修改传递的name数据
        public static string hotKey; //快捷代码
        public static string nodeName; //选中的节点
        FinanceSummaryLibraryInterface fsli = new FinanceSummaryLibraryInterface();

        public FinanceSummaryLibraryForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 加载事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FinanceSummaryLibraryForm_Load(object sender, EventArgs e)
        {
            loadTreeDate();
        }

        /// <summary>
        /// 添加类别
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCAdd_Click(object sender, EventArgs e)
        {
            FinanceCategoriesDialogForm fcd = new FinanceCategoriesDialogForm();
            fcd.ShowDialog();
            //判断是否添加成功
            if (FinanceCategoriesDialogForm.flag == 1)
            {
                loadTreeDate();
            }
        }


        #region 递归添加树的节点
        /// <summary>
        /// 递归添加树的节点
        /// </summary>
        /// <param name="ParentID">父级ID：默认为空</param>
        /// <param name="pNode">父级节点：默认为null，可选</param>
        /// <param name="table">表名：默认为City，可选参数：P</param>
        /// <param name="ControlName">控件名：必选</param>
        private void AddTree(object ParentID, TreeNode pNode, DataTable dt, TreeView ControlName)
        {
            string ParentId = "parentCode";
            string Code = "code";
            string Name = "name";
            string HotKey = "hotKey";
            try
            {
                dt = fsli.SeleteTreeDate();
                DataView dvTree = new DataView(dt);
                //过滤ParentID,得到当前的所有子节点
                if (ParentID == null)
                {
                    dvTree.RowFilter = string.Format("{0} is NULL", ParentId);
                }
                else
                {
                    dvTree.RowFilter = string.Format("{0} = '{1}'", ParentId, ParentID);
                }
                foreach (DataRowView Row in dvTree)
                {
                    TreeNode node = new TreeNode();
                    if (pNode == null)
                    {
                        //添加根节点    
                        node.Text = Row[Name].ToString();//Text
                        node.Tag = Row[Code].ToString();//Tag
                        ControlName.Nodes.Add(node);
                        AddTree(Row[Code].ToString(), node, dt, ControlName);//调用本身
                        //展开第一级节点
                        node.Expand();
                    }
                    else
                    {
                        //添加当前节点的子节点                  
                        node.Text = Row[HotKey].ToString() + " - " + Row[Name].ToString();
                        node.Tag = Row[Code].ToString();
                        pNode.Nodes.Add(node);
                        AddTree(Row[Code].ToString(), node, dt, ControlName);     //再次递归 
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("加载数据失败,请检查服务器连接并尝试刷新.错误:" + ex.Message);
            }
        }
        #endregion

        /// <summary>
        /// 加载树形列表
        /// </summary>
        public void loadTreeDate()
        {
            tvSummary.Nodes.Clear();
            DataTable dt = new DataTable();
            AddTree(null, null, dt, tvSummary);
        }

        /// <summary>
        /// 类别修改
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCRevise_Click(object sender, EventArgs e)
        {
            //判断是否选中类别
            if (tvSummary.SelectedNode == null)
            {
                MessageBox.Show("请选中某个类别在进行操作！");
                return;
            }
            name = this.tvSummary.SelectedNode.Text;
            code = this.tvSummary.SelectedNode.Tag.ToString();
            FinanceUpdateCategoriesDialogForm fucd = new FinanceUpdateCategoriesDialogForm();
            fucd.ShowDialog();
            //判断是否修改成功
            if (FinanceUpdateCategoriesDialogForm.flag == 1)
            {
                loadTreeDate();
            }
        }

        /// <summary>
        /// 选项改变
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tvSummary_AfterSelect(object sender, TreeViewEventArgs e)
        {
            //类别
            if (tvSummary.SelectedNode.Parent == null)
            {
                this.btnCAdd.Enabled = true;
                this.btnCDel.Enabled = true;
                this.btnCRevise.Enabled = true;
                this.btnSAdd.Enabled = true;
                this.btnSDel.Enabled = false;
                this.btnSRevise.Enabled = false;
            }
            //摘要
            else
            {
                this.btnSAdd.Enabled = true;
                this.btnSDel.Enabled = true;
                this.btnSRevise.Enabled = true;
                this.btnCAdd.Enabled = false;
                this.btnCDel.Enabled = false;
                this.btnCRevise.Enabled = false;
            }
        }

        /// <summary>
        /// 删除类别
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCDel_Click(object sender, EventArgs e)
        {
            //判断是否选中类别
            if (tvSummary.SelectedNode == null)
            {
                MessageBox.Show("请选中某个类别在进行操作！");
                return;
            }
            //判断类别内是否有子节点
            if (tvSummary.SelectedNode.Nodes.Count > 0)
            {
                MessageBox.Show("当前类别内存在摘要，请删除摘要后再尝试删除类别！");
            }
            else
            {
                string delCode = tvSummary.SelectedNode.Tag.ToString();
                int num = fsli.DelNode(delCode);
                if (num == 1)
                {
                    tvSummary.SelectedNode.Remove();
                }
            }
        }

        /// <summary>
        /// 添加摘要
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSAdd_Click(object sender, EventArgs e)
        {
            dialog = 0;
            if (tvSummary.SelectedNode == null)
            {
                MessageBox.Show("请选中某个摘要在进行操作！");
                return;
            }
            code = this.tvSummary.SelectedNode.Tag.ToString();
            FinanceSummaryDialogForm fcd = new FinanceSummaryDialogForm();
            fcd.ShowDialog();
            //判断是否添加成功
            if (FinanceSummaryDialogForm.flag == 1)
            {
                loadTreeDate();
            }
        }

        /// <summary>
        /// 修改摘要
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSRevise_Click(object sender, EventArgs e)
        {
            dialog = 1;
            //判断是否选中类别
            if (tvSummary.SelectedNode == null)
            {
                MessageBox.Show("请选中某个摘要在进行操作！");
                return;
            }
            code = this.tvSummary.SelectedNode.Tag.ToString();
            //拆分快捷代码和名称
            string updateCode = this.tvSummary.SelectedNode.Text;
            int count = updateCode.Length;
            int frist = updateCode.IndexOf('-');
            name = updateCode.Substring(frist + 2, count - frist - 2);
            hotKey = updateCode.Substring(0, frist - 1);
            FinanceSummaryDialogForm fucd = new FinanceSummaryDialogForm();
            fucd.ShowDialog();
            //判断是否修改成功
            if (FinanceSummaryDialogForm.flag == 1)
            {
                loadTreeDate();
            }
        }

        /// <summary>
        /// 删除摘要
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSDel_Click(object sender, EventArgs e)
        {
            //判断是否选中类别
            if (tvSummary.SelectedNode == null)
            {
                MessageBox.Show("请选中某个摘要在进行操作！");
                return;
            }
            string delCode = tvSummary.SelectedNode.Tag.ToString();
            int num = fsli.DelNode(delCode);
            if (num == 1)
            {
                tvSummary.SelectedNode.Remove();
            }
        }

        /// <summary>
        /// treeview双击
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tvSummary_DoubleClick(object sender, EventArgs e)
        {
            if (tvSummary.SelectedNode.Parent != null)
            {
                string updateCode = this.tvSummary.SelectedNode.Text;
                int count = updateCode.Length;
                int frist = updateCode.IndexOf('-');
                name = updateCode.Substring(frist + 2, count - frist - 2);
                nodeName = name;
                this.Close();
            }
        }

        /// <summary>
        /// 确定按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnYes_Click(object sender, EventArgs e)
        {
            if (tvSummary.SelectedNode.Parent != null)
            {
                string updateCode = this.tvSummary.SelectedNode.Text;
                int count = updateCode.Length;
                int frist = updateCode.IndexOf('-');
                name = updateCode.Substring(frist + 2, count - frist - 2);
                nodeName = name;
                this.Close();
            }
        }

        /// <summary>
        /// 取消
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnNo_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
