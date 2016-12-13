using DevComponents.Tree;
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

namespace WSCATProject.Finance
{
    public partial class FinanceAccountingSubjectsForm : Form
    {
        public FinanceAccountingSubjectsForm()
        {
            InitializeComponent();
        }
        public static string code;   //节点code
        public static string name;   //节点名称
        public static string parentCode;  //父节点
        public static int dialog;   //判断修改还是新建
        public static int addNode;  //判断是新建类别还是科目
        public static string hotKey;  //快捷代码
        public static int nodeType;  //选项
        public static string subjectName; //科目名称
        private int type;
        FinanceAccountingSubjectsInterface financeAccountingSubjectsInterface = new FinanceAccountingSubjectsInterface();

        /// <summary>
        /// 加载事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FinanceAccountingSubjects_Load(object sender, EventArgs e)
        {
            loadTreeDate(0);
        }

        #region 递归添加树的节点
        /// <summary>
        /// 递归添加树的节点
        /// </summary>
        /// <param name="ParentID">父级ID：默认为空</param>
        /// <param name="pNode">父级节点：默认为null，可选</param>
        /// <param name="table">表名：默认为City，可选参数：P</param>
        /// <param name="ControlName">控件名：必选</param>
        /// <param name="nodeType">加载的选项卡nodeType</param>
        private void AddTree(object ParentID, TreeNode pNode, DataTable dt, TreeView ControlName, int nodeType)
        {
            string ParentId = "parentCode";
            string Code = "code";
            string Name = "name";
            string HotKey = "hotKey";
            try
            {
                dt = financeAccountingSubjectsInterface.GetList(0, nodeType);
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
                        AddTree(Row[Code].ToString(), node, dt, ControlName, nodeType);//调用本身
                        //展开第一级节点
                        node.Expand();
                    }
                    else
                    {
                        //添加当前节点的子节点                  
                        node.Text = Row[HotKey].ToString() + " - " + Row[Name].ToString();
                        node.Tag = Row[Code].ToString();
                        pNode.Nodes.Add(node);
                        AddTree(Row[Code].ToString(), node, dt, ControlName, nodeType);     //再次递归 
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
        /// 加载数据
        /// </summary>
        /// <param name="type">0加载全部，1，2，3，4，5分别指代单个刷新</param>
        public void loadTreeDate(int type)
        {
            if (type == 0 || type == 1)
            {
                //资产
                treeView1.Nodes.Clear();
                DataTable dt1 = new DataTable();
                AddTree(null, null, dt1, treeView1, 1);
            }
            if (type == 0 || type == 2)
            {
                //负债
                treeView2.Nodes.Clear();
                DataTable dt2 = new DataTable();
                AddTree(null, null, dt2, treeView2, 2);
            }
            if (type == 0 || type == 3)
            {
                //权益
                treeView3.Nodes.Clear();
                DataTable dt3 = new DataTable();
                AddTree(null, null, dt3, treeView3, 3);
            }
            if (type == 0 || type == 4)
            {
                //成本
                treeView4.Nodes.Clear();
                DataTable dt4 = new DataTable();
                AddTree(null, null, dt4, treeView4, 4);
            }
            if (type == 0 || type == 5)
            {
                //损益
                treeView5.Nodes.Clear();
                DataTable dt5 = new DataTable();
                AddTree(null, null, dt5, treeView5, 5);
            }
        }

        /// <summary>
        /// 刷新
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            loadTreeDate(0);
        }

        /// <summary>
        /// 新增按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            FinanceSubjectAddDialogForm fsad = new FinanceSubjectAddDialogForm();
            dialog = 1;
            //资产
            if (superTabItem1.IsSelected == true)
            {
                //判断是否选中
                if (treeView1.SelectedNode == null)
                {
                    MessageBox.Show("请选中某个类别在进行操作");
                    return;
                }
                if (treeView1.SelectedNode.Parent == null)
                {
                    addNode = 1;
                    parentCode = treeView1.SelectedNode.Tag.ToString();
                }
                else
                {
                    addNode = 0;
                    parentCode = treeView1.SelectedNode.Parent.Tag.ToString();
                }
                nodeType = 1;  //选项
            }
            //负债
            else if (superTabItem2.IsSelected == true)
            {
                //判断是否选中
                if (treeView2.SelectedNode == null)
                {
                    MessageBox.Show("请选中某个类别在进行操作");
                    return;
                }
                if (treeView2.SelectedNode.Parent == null)
                {
                    addNode = 1;
                    parentCode = treeView2.SelectedNode.Tag.ToString();
                }
                else
                {
                    addNode = 0;
                    parentCode = treeView2.SelectedNode.Parent.Tag.ToString();
                }
                nodeType = 2;  //选项
            }
            //权益
            else if (superTabItem3.IsSelected == true)
            {
                //判断是否选中
                if (treeView3.SelectedNode == null)
                {
                    MessageBox.Show("请选中某个类别在进行操作");
                    return;
                }
                if (treeView3.SelectedNode.Parent == null)
                {
                    addNode = 1;
                    parentCode = treeView3.SelectedNode.Tag.ToString();
                }
                else
                {
                    addNode = 0;
                    parentCode = treeView3.SelectedNode.Parent.Tag.ToString();
                }
                nodeType = 3;  //选项
            }
            //成本
            else if (superTabItem4.IsSelected == true)
            {
                //判断是否选中
                if (treeView4.SelectedNode == null)
                {
                    MessageBox.Show("请选中某个类别在进行操作");
                    return;
                }
                if (treeView4.SelectedNode.Parent == null)
                {
                    addNode = 1;
                    parentCode = treeView4.SelectedNode.Tag.ToString();
                }
                else
                {
                    addNode = 0;
                    parentCode = treeView4.SelectedNode.Parent.Tag.ToString();
                }
                nodeType = 4;  //选项
            }
            //损益
            else if (superTabItem5.IsSelected == true)
            {
                //判断是否选中
                if (treeView5.SelectedNode == null)
                {
                    MessageBox.Show("请选中某个类别在进行操作");
                    return;
                }
                if (treeView5.SelectedNode.Parent == null)
                {
                    addNode = 1;
                    parentCode = treeView5.SelectedNode.Tag.ToString();
                }
                else
                {
                    addNode = 0;
                    parentCode = treeView5.SelectedNode.Parent.Tag.ToString();
                }
                nodeType = 5;  //选项
            }
            fsad.ShowDialog();
            //判断添加成功重新加载数据
            if (FinanceSubjectAddDialogForm.flag == 1)
            {
                loadTreeDate(nodeType);
            }
            else
            {
                //添加失败
            }
        }

        //修改
        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            dialog = 2;
            //判断是否修改成功
            if (superTabItem1.IsSelected == true)
            {
                //判断是否选中
                if (treeView1.SelectedNode == null)
                {
                    MessageBox.Show("请选中某个类别在进行操作");
                    return;
                }
                if (treeView1.SelectedNode.Parent == null)
                {
                    name = this.treeView1.SelectedNode.Text;
                    code = this.treeView1.SelectedNode.Tag.ToString();
                }
                else
                {
                    code = this.treeView1.SelectedNode.Tag.ToString();
                    //拆分快捷代码和名称
                    string updateCode = this.treeView1.SelectedNode.Text;
                    int count = updateCode.Length;
                    int frist = updateCode.IndexOf('-');
                    name = updateCode.Substring(frist + 2, count - frist - 2);
                    hotKey = updateCode.Substring(0, frist - 1);
                }
                nodeType = 1;  //选项
            }
            //负债
            else if (superTabItem2.IsSelected == true)
            {
                //判断是否选中
                if (treeView2.SelectedNode == null)
                {
                    MessageBox.Show("请选中某个类别在进行操作");
                    return;
                }
                if (treeView2.SelectedNode.Parent == null)
                {
                    name = this.treeView2.SelectedNode.Text;
                    code = this.treeView2.SelectedNode.Tag.ToString();
                }
                else
                {
                    code = this.treeView2.SelectedNode.Tag.ToString();
                    //拆分快捷代码和名称
                    string updateCode = this.treeView2.SelectedNode.Text;
                    int count = updateCode.Length;
                    int frist = updateCode.IndexOf('-');
                    name = updateCode.Substring(frist + 2, count - frist - 2);
                    hotKey = updateCode.Substring(0, frist - 1);
                }
                nodeType = 2;  //选项
            }
            //权益
            else if (superTabItem3.IsSelected == true)
            {
                //判断是否选中
                if (treeView3.SelectedNode == null)
                {
                    MessageBox.Show("请选中某个类别在进行操作");
                    return;
                }
                if (treeView3.SelectedNode.Parent == null)
                {
                    name = this.treeView3.SelectedNode.Text;
                    code = this.treeView3.SelectedNode.Tag.ToString();
                }
                else
                {
                    code = this.treeView3.SelectedNode.Tag.ToString();
                    //拆分快捷代码和名称
                    string updateCode = this.treeView3.SelectedNode.Text;
                    int count = updateCode.Length;
                    int frist = updateCode.IndexOf('-');
                    name = updateCode.Substring(frist + 2, count - frist - 2);
                    hotKey = updateCode.Substring(0, frist - 1);
                }
                nodeType = 3;  //选项
            }
            //成本
            else if (superTabItem4.IsSelected == true)
            {
                //判断是否选中
                if (treeView4.SelectedNode == null)
                {
                    MessageBox.Show("请选中某个类别在进行操作");
                    return;
                }
                if (treeView4.SelectedNode.Parent == null)
                {
                    name = this.treeView4.SelectedNode.Text;
                    code = this.treeView4.SelectedNode.Tag.ToString();
                }
                else
                {
                    code = this.treeView4.SelectedNode.Tag.ToString();
                    //拆分快捷代码和名称
                    string updateCode = this.treeView4.SelectedNode.Text;
                    int count = updateCode.Length;
                    int frist = updateCode.IndexOf('-');
                    name = updateCode.Substring(frist + 2, count - frist - 2);
                    hotKey = updateCode.Substring(0, frist - 1);
                }
                nodeType = 4;  //选项
            }
            //损益
            else if (superTabItem5.IsSelected == true)
            {
                //判断是否选中
                if (treeView5.SelectedNode == null)
                {
                    MessageBox.Show("请选中某个类别在进行操作");
                    return;
                }
                if (treeView5.SelectedNode.Parent == null)
                {
                    name = this.treeView5.SelectedNode.Text;
                    code = this.treeView5.SelectedNode.Tag.ToString();
                }
                else
                {
                    code = this.treeView5.SelectedNode.Tag.ToString();
                    //拆分快捷代码和名称
                    string updateCode = this.treeView5.SelectedNode.Text;
                    int count = updateCode.Length;
                    int frist = updateCode.IndexOf('-');
                    name = updateCode.Substring(frist + 2, count - frist - 2);
                    hotKey = updateCode.Substring(0, frist - 1);
                }
                nodeType = 5;  //选项
            }
            FinanceSubjectAddDialogForm fsad = new FinanceSubjectAddDialogForm();
            fsad.ShowDialog();
            //判断是否修改成功
            if (FinanceSubjectAddDialogForm.flag == 1)
            {
                loadTreeDate(nodeType);
            }
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            if (superTabItem1.IsSelected == true)
            {
                //判断是否选中
                if (treeView1.SelectedNode == null)
                {
                    MessageBox.Show("请选中某个类别在进行操作！");
                    return;
                }
                //判断类别内是否有子节点
                if (treeView1.SelectedNode.Nodes.Count > 0)
                {
                    MessageBox.Show("当前类别内存在摘要，请删除摘要后再尝试删除类别！");
                    return;
                }
                string delCode = treeView1.SelectedNode.Tag.ToString();
                int num = financeAccountingSubjectsInterface.DelNode(delCode);
                if (num == 1)
                {
                    treeView1.SelectedNode.Remove();
                    //删除成功
                }
            }
            else if (superTabItem2.IsSelected == true)
            {
                //判断是否选中
                if (treeView2.SelectedNode == null)
                {
                    MessageBox.Show("请选中某个类别在进行操作！");
                    return;
                }
                //判断类别内是否有子节点
                if (treeView2.SelectedNode.Nodes.Count > 0)
                {
                    MessageBox.Show("当前类别内存在摘要，请删除摘要后再尝试删除类别！");
                    return;
                }
                string delCode = treeView2.SelectedNode.Tag.ToString();
                int num = financeAccountingSubjectsInterface.DelNode(delCode);
                if (num == 1)
                {
                    treeView2.SelectedNode.Remove();
                    //删除成功
                }
            }
            else if (superTabItem3.IsSelected == true)
            {
                //判断是否选中
                if (treeView3.SelectedNode == null)
                {
                    MessageBox.Show("请选中某个类别在进行操作！");
                    return;
                }
                //判断类别内是否有子节点
                if (treeView3.SelectedNode.Nodes.Count > 0)
                {
                    MessageBox.Show("当前类别内存在摘要，请删除摘要后再尝试删除类别！");
                    return;
                }
                string delCode = treeView3.SelectedNode.Tag.ToString();
                int num = financeAccountingSubjectsInterface.DelNode(delCode);
                if (num == 1)
                {
                    treeView3.SelectedNode.Remove();
                    //删除成功
                }
            }
            else if (superTabItem4.IsSelected == true)
            {
                //判断是否选中
                if (treeView4.SelectedNode == null)
                {
                    MessageBox.Show("请选中某个类别在进行操作！");
                    return;
                }
                //判断类别内是否有子节点
                if (treeView4.SelectedNode.Nodes.Count > 0)
                {
                    MessageBox.Show("当前类别内存在摘要，请删除摘要后再尝试删除类别！");
                    return;
                }
                string delCode = treeView4.SelectedNode.Tag.ToString();
                int num = financeAccountingSubjectsInterface.DelNode(delCode);
                if (num == 1)
                {
                    treeView4.SelectedNode.Remove();
                    //删除成功
                }
            }
            else if (superTabItem5.IsSelected == true)
            {
                //判断是否选中
                if (treeView5.SelectedNode == null)
                {
                    MessageBox.Show("请选中某个类别在进行操作！");
                    return;
                }
                //判断类别内是否有子节点
                if (treeView5.SelectedNode.Nodes.Count > 0)
                {
                    MessageBox.Show("当前类别内存在摘要，请删除摘要后再尝试删除类别！");
                    return;
                }
                string delCode = treeView5.SelectedNode.Tag.ToString();
                int num = financeAccountingSubjectsInterface.DelNode(delCode);
                if (num == 1)
                {
                    treeView5.SelectedNode.Remove();
                    //删除成功
                }
            }
        }

        /// <summary>
        /// 双击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void treeView1_DoubleClick(object sender, EventArgs e)
        {
            if (superTabItem1.IsSelected == true)
            {
                if (treeView1.SelectedNode.Parent != null)
                {
                    string updateCode = this.treeView1.SelectedNode.Text;
                    int count = updateCode.Length;
                    int frist = updateCode.IndexOf('-');
                    subjectName = updateCode.Substring(frist + 2, count - frist - 2);
                    type = 1;
                    this.Close();
                }
            }
        }

        private void treeView2_DoubleClick(object sender, EventArgs e)
        {
            if (superTabItem2.IsSelected == true)
            {
                if (treeView2.SelectedNode.Parent != null)
                {
                    string updateCode = this.treeView2.SelectedNode.Text;
                    int count = updateCode.Length;
                    int frist = updateCode.IndexOf('-');
                    subjectName = updateCode.Substring(frist + 2, count - frist - 2);
                    type = 1;
                    this.Close();
                }
            }
        }

        private void treeView3_DoubleClick(object sender, EventArgs e)
        {
            if (superTabItem3.IsSelected == true)
            {

                if (treeView3.SelectedNode.Parent != null)
                {
                    string updateCode = this.treeView3.SelectedNode.Text;
                    int count = updateCode.Length;
                    int frist = updateCode.IndexOf('-');
                    subjectName = updateCode.Substring(frist + 2, count - frist - 2);
                    type = 1;
                    this.Close();
                }
            }
        }

        private void treeView4_DoubleClick(object sender, EventArgs e)
        {
            if (superTabItem4.IsSelected == true)
            {
                if (treeView4.SelectedNode.Parent != null)
                {
                    string updateCode = this.treeView4.SelectedNode.Text;
                    int count = updateCode.Length;
                    int frist = updateCode.IndexOf('-');
                    subjectName = updateCode.Substring(frist + 2, count - frist - 2);
                    type = 1;
                    this.Close();
                }
            }
        }

        private void treeView5_DoubleClick(object sender, EventArgs e)
        {
            if (superTabItem5.IsSelected == true)
            {
                if (treeView5.SelectedNode.Parent != null)
                {
                    string updateCode = this.treeView5.SelectedNode.Text;
                    int count = updateCode.Length;
                    int frist = updateCode.IndexOf('-');
                    subjectName = updateCode.Substring(frist + 2, count - frist - 2);
                    type = 1;
                    this.Close();
                }
            }
        }

        /// <summary>
        /// 退出事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FinanceAccountingSubjectsForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (type == 0)
            {
                subjectName = "";
            }
            type = 0;
        }
    }
}
