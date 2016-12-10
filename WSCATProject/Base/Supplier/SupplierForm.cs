using BLL;
using HelperUtility.Encrypt;
using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using DevComponents.DotNetBar.SuperGrid;
using HelperUtility.Excel;

namespace WSCATProject.Base
{
    public partial class SupplierForm : Form
    {
        public SupplierForm()
        {
            InitializeComponent();
        }
        CityManager cm = new CityManager();
        SupplierManager sm = new SupplierManager();
        ProfessionManager pm = new ProfessionManager();
        public bool isflag = false; //添加地区的返回值
        public string code;  //标识
        public int stats;  //0为新增  1为修改
        private string name;

        #region 快捷键
        /// <summary>
        /// 快捷键
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SupplierMaterial_KeyDown(object sender, KeyEventArgs e)
        {
            ///新增(Ctrl+N),编辑(Ctrl+E),删除(Ctrl+D),全部删除(Shift+Delete),过滤(Ctrl+F),刷新(F5)
            e.Handled = true;
            if (e.KeyCode == Keys.N && e.Control)
            {
                InsToolStripMenuItem.PerformClick(); //执行单击button1的动作    
            }
            if (e.KeyCode == Keys.E && e.Control)
            {
                UpdToolStripMenuItem.PerformClick();
            }
            if (e.KeyCode == Keys.D && e.Control)
            {
                DelToolStripMenuItem.PerformClick();
            }
            if (e.KeyCode == Keys.Delete && e.Shift)
            {
                AllDelToolStripMenuItem.PerformClick();
            }
            if (e.KeyCode == Keys.T && e.Control)
            {
                ExportExcelToolStripMenuItem.PerformClick();
            }
            if (e.KeyCode == Keys.F5)
            {
                RefreshToolStripMenuItem.PerformClick();
            }
        }
        #endregion

        #region 窗体加载事件
        /// <summary>
        /// 窗体加载事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SupplierMaterial_Load(object sender, EventArgs e)
        {
            StartPosition = FormStartPosition.CenterParent;
            superGridControl1.PrimaryGrid.AutoGenerateColumns = false;
            superGridControl1.PrimaryGrid.SelectionGranularity = SelectionGranularity.Row;
            superGridControl1.PrimaryGrid.InitialSelection = RelativeSelection.None;
            superGridControl1.PrimaryGrid.FocusCuesEnabled = false;
            superGridControl1.PrimaryGrid.ActiveRowIndicatorStyle = ActiveRowIndicatorStyle.None;
            name = "所有地区";
            BindComboBox();
            BindSupGrid();
        }
        #endregion

        #region 绑定DGV控件，合并列
        /// <summary>
        /// 绑定DGV控件，合并列
        /// </summary>
        private void BindSupGrid()
        {
            try
            {
                List<Supplier> list = sm.SelSupplier(false);
                superGridControl1.PrimaryGrid.DataSource = list;
                superGridControl1.PrimaryGrid.ShowInsertRow = false;

                GridPanel panel = superGridControl1.PrimaryGrid;
                GridColumnCollection columns = panel.Columns;

                panel.ColumnHeader.GroupHeaders.Add(GetSlCompanyInfoHeader(columns,"CodeAndName", "编码及单位名称", "gridColumn1", "gridColumn3"));
                panel.ColumnHeader.GroupHeaders.Add(GetSlCompanyInfoHeader(columns, "Contact", "联系方式", "gridColumn4", "gridColumn10"));
            }
            catch (Exception ex)
            {
                MessageBox.Show("加载数据失败,请检查服务器连接并尝试刷新.错误:" + ex.Message);
            }
        }
        #endregion

        #region 控件默认选中和禁用右键
        /// <summary>
        /// 控件默认选中和禁用右键
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void contextMenuStrip1_Opening(object sender,

System.ComponentModel.CancelEventArgs e)
        {
            ///判断集合中有数据才进入后面的if  否则直接跳出
            if (treeView1.GetNodeCount(true) > 0)
            {
                if (treeView1.SelectedNode == null) //如果当前没有选中  则默认选中从0开始的第一个
                {
                    treeView1.SelectedNode = treeView1.Nodes[0];
                    return;
                }
                return;
            }
        }
        #endregion

        #region 多条件查询(地区类型-地区列表-关键词)
        /// <summary>
        /// 多条件查询(地区类型-地区列表-关键词)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            try
            {
                List<Supplier> list = new List<Supplier>();
                string SQLWhere = "";
                string treeName = treeView1.SelectedNode.Text;
                string treeTag = treeView1.SelectedNode.Tag.ToString();
                string searchType = toolStripComboBox2.Text.Trim();
                string searchKey = XYEEncoding.strCodeHex(toolStripSelTxt.Text.Trim());

                if (treeView1.SelectedNode == null)  //如果TreeView选中项为空
                {
                    return;
                }
                if (string.IsNullOrWhiteSpace(toolStripSelTxt.Text.Trim()))  //如果搜索关键字为空
                {
                    return;
                }
                SQLWhere += string.Format("Su_Area like '%{0}%'", XYEEncoding.strCodeHex(treeName));

                //模糊查询城市名
                switch (searchType) //搜索框内容加密后
                {
                    case "单位名称":
                        SQLWhere += string.Format(" and Su_Name like '%{0}%'", searchKey);
                        break;
                    case "联系人":
                        SQLWhere += string.Format(" and Su_Empname like '%{0}%'", searchKey);
                        break;
                    case "联系手机":
                        SQLWhere += string.Format(" and Su_EmpPhone like '%{0}%'", searchKey);
                        break;
                    case "常用电话":
                        SQLWhere += string.Format(" and Su_Phone like '%{0}%'", searchKey);
                        break;
                    default:
                        MessageBox.Show("类型选择错误，请重新选择！");
                        break;
                }
                list = sm.SelSupplierByWhere(SQLWhere);  //拼接where
                superGridControl1.PrimaryGrid.DataSource = list;
            }
            catch (Exception ex)
            {
                MessageBox.Show("加载数据失败,请检查服务器连接并尝试刷新.错误:" + ex.Message);
            }
        }
        #endregion

        #region 地区类型下拉框改变索引时触发
        /// <summary>
        /// 地区类型下拉框改变索引时触发
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comboBoxEx1_SelectedIndexChanged(object sender, EventArgs e)
        {

            try
            {
                int cbType = Convert.ToInt32(comboBox1.SelectedValue.ToString());
                if (cbType == 1)
                {
                    treeView1.Nodes.Clear();
                    DataTable dt = cm.SelCityTable();
                    AddTree("", null, "", dt);  //加载节点数据
                    return;
                }
                if (cbType == 2)
                {
                    DataTable dt = pm.SelProfession();
                    treeView1.Nodes.Clear();
                    AddTree("", null, "P", dt);  //加载节点数据
                    return;
                }
                else
                {
                    MessageBox.Show("类型选择错误！");
                    return;
                }
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
        /// <param name="ParentID">条件ID</param>
        /// <param name="pNode">父级ID：null</param>
        /// <param name="table">表名：默认：T_City，可选：P</param>
        private void AddTree(string ParentID, TreeNode pNode, string table, DataTable dt)
        {
            if (ParentID == "")
            {
                ParentID = "D4";
            }
            string ParentId = "City_ParentId";
            string Code = "City_Code";
            string Name = "City_Name";
            if (table == "P")
            {
                ParentId = "ST_ParentId";
                Code = "ST_Code";
                Name = "ST_Name";
            }
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
                    AddTree(Row[Code].ToString(), Node, table, dt);
                    //展开第一级节点
                    Node.Expand();
                }
                else
                {
                    //添加当前节点的子节点                  
                    Node.Text = XYEEncoding.strHexDecode(Row[Name].ToString());
                    Node.Tag = XYEEncoding.strHexDecode(Row[Code].ToString());
                    pNode.Nodes.Add(Node);
                    AddTree(Row[Code].ToString(), Node, table, dt);     //再次递归 
                }
            }
        }
        #endregion

        #region 绑定方法-地区和往来类型
        /// <summary>
        /// 绑定方法-地区和往来类型
        /// </summary>
        private void BindComboBox()
        {
            DataTable dt = new DataTable();

            DataColumn dc1 = new DataColumn("id");
            DataColumn dc2 = new DataColumn("name");
            dt.Columns.Add(dc1);
            dt.Columns.Add(dc2);

            DataRow dr1 = dt.NewRow();
            dr1["id"] = "1";
            dr1["name"] = "地区";

            //DataRow dr2 = dt.NewRow();
            //dr2["id"] = "2";
            //dr2["name"] = "往来类型";

            dt.Rows.Add(dr1);
            //dt.Rows.Add(dr2);
            comboBox1.ValueMember = "id";
            comboBox1.DisplayMember = "name";
            comboBox1.DataSource = dt;  //设置数据源时默认选择第一项
            treeView1.SelectedNode = treeView1.Nodes[0];
        }
        #endregion

        #region 更改选定后查询
        /// <summary>
        /// 地区-更改选定后查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            string cityName = treeView1.SelectedNode.Text.ToString();
            superGridControl1.PrimaryGrid.DataSource = sm.SelSupplierByCityCode(cityName);
        }
        #endregion

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

        #region 合并列方法
        /// <summary>
        /// 合并列方法
        /// </summary>
        /// <returns></returns>
        private ColumnGroupHeader GetSlCompanyInfoHeader(GridColumnCollection columns, string 
name, string headerText, string startName, string endName)
        {
            ColumnGroupHeader cgh = new ColumnGroupHeader();

            cgh.Name = name;
            cgh.HeaderText = headerText;

            cgh.MinRowHeight = 36;

            cgh.StartDisplayIndex = GetDisplayIndex(columns, startName);
            cgh.EndDisplayIndex = GetDisplayIndex(columns, endName);

            //superGridControl1.PrimaryGrid
            return (cgh);
        }
        private int GetDisplayIndex(GridColumnCollection columns, string name)
        {
            return (columns.GetDisplayIndex(columns[name]));
        }
        #endregion


        #region 操作-新增信息
        /// <summary>
        /// 新增信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void InsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            stats = 0;
            InsSupplier isupplier = new InsSupplier();
            isupplier.ShowDialog(this);
            if (isflag)
            {
                if (treeView1.SelectedNode == null || treeView1.SelectedNode.Text == "所有地区")
                {
                    BindSupGrid();
                }
                else
                {
                    name = treeView1.SelectedNode.Text.ToString();
                    try
                    {
                        string cityName = treeView1.SelectedNode.Text.ToString();
                        superGridControl1.PrimaryGrid.DataSource = sm.SelSupplierByCityCode(cityName);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("加载数据失败,请检查服务器连接并尝试刷新.错误:" + ex.Message);
                    }
                }
            }
        }
        #endregion

        #region 操作-删除
        /// <summary>
        /// 操作-删除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SelectedElementCollection col = superGridControl1.PrimaryGrid.GetSelectedRows();
            int result = 0;
            if (col.Count > 0)
            {
                if (DialogResult.Yes == MessageBox.Show("确定全部删除吗? 删除后将不可恢复!", "WACAT管家", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1))
                {
                    GridRow row = col[0] as GridRow;
                    try
                    {
                        code = row.Cells["gridColumn1"].Value.ToString();
                        result = sm.FalseDelClear(code);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("删除失败,请检查服务器连接并尝试重新删除.错误:" + ex.Message);
                    }

                    if (result > 0)
                    {
                        MessageBox.Show("删除成功!");
                        List<Supplier> list = new List<Supplier>();
                        string treeName = treeView1.SelectedNode.Text;
                        string searchType = toolStripComboBox2.Text.Trim();
                        string searchKey = XYEEncoding.strCodeHex(toolStripSelTxt.Text.Trim());
                        string SQLWhere = "";
                        if (treeView1.SelectedNode != null)
                        {
                            SQLWhere += string.Format("Su_Area like '%{0}%'", XYEEncoding.strCodeHex(treeName));
                        }
                        if (!string.IsNullOrWhiteSpace(toolStripSelTxt.Text.Trim()))
                        {
                            switch (searchType)
                            {
                                case "单位名称":
                                    SQLWhere += string.Format(" and Su_Name like '%{0}%'", searchKey);
                                    break;
                                case "联系人":
                                    SQLWhere += string.Format(" and Su_Empname like '%{0}%'", searchKey);
                                    break;
                                case "联系手机":
                                    SQLWhere += string.Format(" and Su_EmpPhone like '%{0}%'", searchKey);
                                    break;
                                case "常用电话":
                                    SQLWhere += string.Format(" and Su_Phone like '%{0}%'", searchKey);
                                    break;
                                default:
                                    MessageBox.Show("类型选择错误，请重新选择!");
                                    break;
                            }
                        }
                        try
                        {
                            list = sm.SelSupplierByWhere(SQLWhere);
                            superGridControl1.PrimaryGrid.DataSource = list;
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("加载数据失败,请检查服务器连接并尝试刷新.错误:" + ex.Message);
                        }
                    }
                    else
                    {
                        MessageBox.Show("删除失败!");
                        return;
                    }
                }
            }
            else
            {
                MessageBox.Show("请先选择一行!");
                return;
            }
        }
        #endregion

        #region 操作-修改信息
        /// <summary>
        /// 操作-修改信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UpdToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SelectedElementCollection col = superGridControl1.PrimaryGrid.GetSelectedRows();
            if (col.Count > 0)
            {
                GridRow row = col[0] as GridRow;
                code = row.Cells["gridColumn1"].Value.ToString();
                stats = 1;      //0为新增   1为修改
                InsSupplier inssupplier = new InsSupplier();
                inssupplier.ShowDialog(this);
                if (isflag)
                {
                    if (treeView1.SelectedNode == null || treeView1.SelectedNode.Text == "所有地区")
                    {
                        BindSupGrid();
                    }
                    else
                    {
                        name = treeView1.SelectedNode.Text.ToString();
                        try
                        {
                            string cityName = treeView1.SelectedNode.Text.ToString();
                            superGridControl1.PrimaryGrid.DataSource = sm.SelSupplierByCityCode(cityName);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("保存失败,请检查服务器连接并尝试重新保存.错误:" + ex.Message);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("请先选择一行!");
                return;
            }
        }
        #endregion

        #region 操作-刷新
        /// <summary>
        /// 操作-刷新
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RefreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (treeView1.SelectedNode == null || treeView1.SelectedNode.Text == "所有地区")
            {
                BindSupGrid();
            }
            else
            {
                name = treeView1.SelectedNode.Text.ToString();
                try
                {
                    string cityName = treeView1.SelectedNode.Text.ToString();
                    superGridControl1.PrimaryGrid.DataSource = sm.SelSupplierByCityCode(cityName);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("加载数据失败,请检查服务器连接并尝试刷新.错误:" + ex.Message);
                }
            }
        }
        #endregion

        #region 操作-导出到Excel
        /// <summary>
        /// 操作-导出到Excel
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ExportExcelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            string defaultName = DateTime.Now.ToString("yyyyMMddHHmm") + "供应商资料";
            saveFileDialog1.FileName = defaultName + ".xls";
            saveFileDialog1.Filter = @"Excel 97-2003 (*.xls)|*.xls|All files (*.*)|*.*";
            saveFileDialog1.FilterIndex = 1;
            saveFileDialog1.RestoreDirectory = true;

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                GridItemsCollection col = superGridControl1.PrimaryGrid.Rows;
                GridRow row = col[0] as GridRow;

                DataTable dt = new DataTable();
                DataRow dr = null;
                DataColumn dc = null;
                for (int i = 0; i < row.Cells.Count; i++)
                {
                    dc = new DataColumn(superGridControl1.PrimaryGrid.Columns[i].HeaderText);
                    dt.Columns.Add(dc);   //添加表头   当第二行的时候还会添加一次  由于table中的columns必须是唯一的 所以会导致冲突
                }
                for (int i = 0; i < col.Count; i++)
                {
                    dr = dt.NewRow();
                    for (int j = 0; j < row.Cells.Count; j++)
                    {
                        GridRow rows = col[i] as GridRow;
                        dr[j] = rows.Cells[j].Value;  //添加列的值
                    }
                    dt.Rows.Add(dr);
                }
                try
                {
                    NPOIExcelHelper.DataTableToExcel(dt, "供应商资料", saveFileDialog1.FileName);
                    MessageBox.Show("Excel文件已成功导出，请到保存目录下查看。");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("保存失败,请检查异常情况:" + ex.Message);
                }
            }
        }
        #endregion


        #region 右键菜单-新增
        /// <summary>
        /// 右键菜单-新增
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 新增NToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InsToolStripMenuItem.PerformClick();
        }
        #endregion

        #region 右键菜单-编辑
        /// <summary>
        /// 右键菜单-编辑
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 编辑EToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UpdToolStripMenuItem.PerformClick();
        }
        #endregion

        #region 右键菜单-删除
        /// <summary>
        /// 右键菜单-删除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 删除DToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DelToolStripMenuItem.PerformClick();
        }
        #endregion

        #region 右键菜单-全部删除
        /// <summary>
        /// 右键菜单-全部删除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 全部删除ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AllDelToolStripMenuItem.PerformClick();
        }
        #endregion

        #region 右键菜单-刷新
        /// <summary>
        /// 右键菜单-刷新
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 刷新ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RefreshToolStripMenuItem.PerformClick();
        }
        #endregion

        #region 右键菜单-导出到Excel
        /// <summary>
        /// 右键菜单-导出到Excel
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 导出到ExcelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExportExcelToolStripMenuItem.PerformClick();
        }
        #endregion

        #region 显示全部[含停用]
        /// <summary>
        /// 显示全部[含停用]
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            try
            {
                if (isflag == false)
                {
                    List<Supplier> list = sm.SelSupplier(true);
                    superGridControl1.PrimaryGrid.DataSource = list;
                    isflag = true;
                    return;
                }
                if (isflag == true)
                {
                    List<Supplier> list = sm.SelSupplier(false);
                    superGridControl1.PrimaryGrid.DataSource = list;
                    isflag = false;
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("加载数据失败,请检查服务器连接并尝试刷新.错误:" + ex.Message);
            }
        }
        #endregion

        #region 删除全部
        /// <summary>
        /// 删除全部
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AllDelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (DialogResult.Yes == MessageBox.Show("确定全部删除吗？删除后将不可恢复！", "WACAT管家", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1))
            {
                int result = sm.FalseALLDelClear();
                if (result > 0)
                {
                    if (treeView1.SelectedNode == null || treeView1.SelectedNode.Text == "所有地区")
                    {
                        BindSupGrid();
                    }
                    else
                    {
                        name = treeView1.SelectedNode.Text.ToString();
                        try
                        {
                            string cityName = treeView1.SelectedNode.Text.ToString();
                            superGridControl1.PrimaryGrid.DataSource = sm.SelSupplierByCityCode(cityName);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("删除失败,请检查服务器连接并尝试重新删除.错误:" + ex.Message);
                        }
                    }
                }
            }
        }
        #endregion
    }
}