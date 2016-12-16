using System;
using System.Data;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using Model;
using HelperUtility.Excel;
using HelperUtility.Encrypt;
using DevComponents.DotNetBar.SuperGrid;
using InterfaceLayer.Base;

namespace WSCATProject.Base
{
    public partial class ClientForm : RibbonForm
    {
        CodingHelper ch = new CodingHelper();
        ClientInterface CI = new ClientInterface();

        private bool isflag = false;
        //是否子窗体确定后需要刷新
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
        //所有的客户列表
        private DataTable allDS = null;
        //点击的节点text
        private string clientNodeText = "所有节点";

        public ClientForm()
        {
            InitializeComponent();
        }

        #region 初始化

        private void ClientForm_Load(object sender, EventArgs e)
        {
            //禁止自动创建列
            superGridControlClient.PrimaryGrid.AutoGenerateColumns = false;
            //内容居中
            superGridControlClient.DefaultVisualStyles.CellStyles.Default.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleCenter;
            loadTree();
            loadData();
            MultiColumn();
            toolStripComboBoxKey.SelectedIndex = 0;
        }

        //加载数据绑定到dgv
        private void loadData()
        {
            try
            {
                allDS = CI.GetClientByBool(false);
                superGridControlClient.PrimaryGrid.DataSource = ch.DataTableReCoding(allDS);
            }
            catch (Exception ex)
            {

                MessageBox.Show("查询数据失败,请检查服务器连接。异常:" + ex.Message);
            }
        }

        //递归添加树的节点
        private void AddTree(string ParentID, TreeNode pNode, DataTable table)
        {
            string ParentId = "parentID";
            string Code = "code";
            string Name = "name";

            DataView dvTree = new DataView(table);
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
                    treeViewClient.Nodes.Add(Node);
                    AddTree(Row[Code].ToString(), Node, table);
                    //展开第一级节点
                    Node.Expand();
                }
                else
                {
                    //添加当前节点的子节点
                    Node.Text = XYEEncoding.strHexDecode(Row[Name].ToString());
                    Node.Tag = XYEEncoding.strHexDecode(Row[Code].ToString());
                    pNode.Nodes.Add(Node);
                    AddTree(Row[Code].ToString(), Node, table);//再次递归 
                }
            }
        }

        #endregion

        #region treeview的操作
        //新增节点
        private void conToolStripMenuItemChild_Click(object sender, EventArgs e)
        {
            if (treeViewClient.SelectedNode != null)
            {
                InsNodes insN = new InsNodes();
                insN.city_code = treeViewClient.SelectedNode.Tag.ToString();
                insN.ShowDialog(this);
                if (Isflag)
                {
                    loadTree();
                    isflag = false;
                    this.Focus();
                }
            }
            else
            {
                MessageBox.Show("请选择需要增加的上级城市");
            }
        }

        //删除节点 
        private void conToolStripMenuItemDelete_Click(object sender, EventArgs e)
        {
            if (treeViewClient.SelectedNode != null)
            {
                AreaInterface cm = new AreaInterface();
                try
                {
                    if (cm.UpdateAllClear(0, 0, treeViewClient.SelectedNode.Tag.ToString()) > 0)
                    {
                        treeViewClient.SelectedNode.Remove();
                        MessageBox.Show("删除该城市成功!");
                    }
                    else
                    {
                        MessageBox.Show("删除该城市信息失败,请重新尝试");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("删除城市信息出现异常,请检查服务器连接." + ex.Message);
                }
            }
        }

        //编辑节点 
        private void conToolStripMenuItemEdit_Click(object sender, EventArgs e)
        {
            if (treeViewClient.SelectedNode != null)
            {
                InsNodes insNodes = new InsNodes();
                BaseArea city = new BaseArea();
                city.name = treeViewClient.SelectedNode.Text;
                city.code = treeViewClient.SelectedNode.Tag.ToString();
                city.parentId = treeViewClient.SelectedNode.Parent.Tag.ToString();
                city.isClear = 1;
                city.isEnable = 1;
                insNodes.city = city;
                insNodes.ShowDialog(this);
                if (isflag)
                {
                    loadTree();
                }
            }
            else
            {
                MessageBox.Show("请先选择要编辑的节点");
            }
        }

        /// <summary>
        /// 点右边空白定位到左边节点
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void treeViewClient_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                treeViewClient.SelectedNode = treeViewClient.GetNodeAt(e.X, e.Y);
            }
        }

        //点击节点筛选数据中符合点击的节点的项
        private void treeViewClient_AfterSelect(object sender, TreeViewEventArgs e)
        {
            clientNodeText = e.Node.Text;
            AreaInterface cm = new AreaInterface();
            if (allDS != null)
            {
                try
                {
                    superGridControlClient.PrimaryGrid.DataSource =
                                cm.searchClientByNodeClick(allDS,
                                clientNodeText, "地区");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
        #endregion

        #region 导航菜单的操作

        private void ToolStripMenuItemRefresh_Click(object sender, EventArgs e)
        {
            loadData();
            treeViewClient.SelectedNode = treeViewClient.Nodes[0];
        }

        //搜索按钮
        private void toolStripButtonSeach_Click(object sender, EventArgs e)
        {
            string field = toolStripComboBoxKey.Text;
            string text = toolStripTextBoxValue.Text.Trim();
            AreaInterface cm = new AreaInterface();

            if (allDS != null)
            {
                try
                {
                    superGridControlClient.PrimaryGrid.DataSource =
                                cm.searchClientByNodeClick(allDS,
                                text, field);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        //新增
        private void ToolStripMenuItemCreate_Click(object sender, EventArgs e)
        {
            CreateClientForm ccf = new CreateClientForm();
            ccf.ShowDialog(this);
            closeDispose();
        }

        //编辑
        private void ToolStripMenuItemEdit_Click(object sender, EventArgs e)
        {
            BaseClient client = null;
            if (superGridControlClient.GetSelectedRows().Count > 0)
            {
                SelectedElementCollection col = superGridControlClient.GetSelectedRows();
                if (col.Count > 0)
                {
                    GridRow gridRow = col[0] as GridRow;
                    client = new BaseClient()
                    {
                        id = gridRow.Cells["gridColumnID"].Value == null ? 0 : Convert.ToInt32(gridRow.Cells["gridColumnID"].Value),
                        code = gridRow.Cells["gridColumnCode"].Value == null ? "" : Convert.ToString(gridRow.Cells["gridColumnCode"].Value),
                        fingerPrints = gridRow.Cells["gridColumnZ"].Value == null ? "" : gridRow.Cells["gridColumnZ"].Value.ToString(),
                        name = gridRow.Cells["gridColumnCliName"].Value == null ? "" : gridRow.Cells["gridColumnCliName"].Value.ToString(),
                        linkMan = gridRow.Cells["gridColumnMan"].Value == null ? "" : gridRow.Cells["gridColumnMan"].Value.ToString(),
                        companyName = gridRow.Cells["gridColumnCo"].Value == null ? "" : gridRow.Cells["gridColumnCo"].Value.ToString(),
                        mobilePhone = gridRow.Cells["gridColumnPho"].Value == null ? "" : gridRow.Cells["gridColumnPho"].Value.ToString(),
                        fixedPhone = gridRow.Cells["gridColumnPho2"].Value == null ? "" : gridRow.Cells["gridColumnPho2"].Value.ToString(),
                        fax = gridRow.Cells["gridColumnFax"].Value == null ? "" : gridRow.Cells["gridColumnFax"].Value.ToString(),
                        cityCode = gridRow.Cells["gridColumnCiCode"].Value == null ? "" : gridRow.Cells["gridColumnCiCode"].Value.ToString(),
                        cityName = gridRow.Cells["gridColumnArea"].Value == null ? "" : gridRow.Cells["gridColumnArea"].Value.ToString(),
                        address = gridRow.Cells["gridColumnAd"].Value == null ? "" : gridRow.Cells["gridColumnAd"].Value.ToString(),
                        typeCode = gridRow.Cells["gridColumnTy"].Value == null ? "" : gridRow.Cells["gridColumnTy"].Value.ToString(),
                        typeName = gridRow.Cells["gridColumnTyName"].Value == null ? "" : gridRow.Cells["gridColumnTyName"].Value.ToString(),
                        discountCode = gridRow.Cells["gridColumnDiCode"].Value == null ? "" : gridRow.Cells["gridColumnDiCode"].Value.ToString(),
                        bankCard = gridRow.Cells["gridColumnBa"].Value == null ? "" : gridRow.Cells["gridColumnBa"].Value.ToString(),
                        openBank = gridRow.Cells["gridColumnOpB"].Value == null ? "" : gridRow.Cells["gridColumnOpB"].Value.ToString(),
                        createTime = gridRow.Cells["gridColumnCre"].Value == null ? Convert.ToDateTime("2000-01-01") : Convert.ToDateTime(gridRow.Cells["gridColumnCre"].Value),
                        availableBalance = gridRow.Cells["gridColumnLim"].Value == null ? 0 : Convert.ToDecimal(gridRow.Cells["gridColumnLim"].Value),
                        balance = gridRow.Cells["gridColumnReLim"].Value == null ? 0 : Convert.ToDecimal(gridRow.Cells["gridColumnReLim"].Value),
                        statementDate = gridRow.Cells["gridColumnDay"].Value == null ? Convert.ToDateTime("2000-01-01") : Convert.ToDateTime(gridRow.Cells["gridColumnDay"].Value),
                        receivables = gridRow.Cells["gridColumnSho"].Value == null ? 0 : Convert.ToDecimal(gridRow.Cells["gridColumnSho"].Value),
                        moneyReceipt = gridRow.Cells["gridColumnGet"].Value == null ? 0 : Convert.ToDecimal(gridRow.Cells["gridColumnGet"].Value),
                        advanceReceipts = gridRow.Cells["gridColumnPre"].Value == null ? 0 : Convert.ToDecimal(gridRow.Cells["gridColumnPre"].Value),
                        remark = gridRow.Cells["gridColumnRem"].Value == null ? "" : gridRow.Cells["gridColumnRem"].Value.ToString(),
                        reserved1 = gridRow.Cells["gridColumnsafetone"].Value == null ? "" : gridRow.Cells["gridColumnsafetone"].Value.ToString(),
                        reserved2 = gridRow.Cells["gridColumnsafettwo"].Value == null ? "" : gridRow.Cells["gridColumnsafettwo"].Value.ToString(),
                        picName = gridRow.Cells["gridColumnPic"].Value == null ? "" : gridRow.Cells["gridColumnPic"].Value.ToString(),
                        enable = 1,
                        initialReturnTime = Convert.ToDateTime("2000-01-01"),
                        initialSalesTime = Convert.ToDateTime("2000-01-01"),
                        lastReturnTime = Convert.ToDateTime("2000-01-01"),
                        lastSalesTime = Convert.ToDateTime("2000-01-01"),
                        updateDate = DateTime.Now
                    };
                }
                CreateClientForm ccf = new CreateClientForm();
                ccf.Client = client;
                ccf.ShowDialog(this);
                closeDispose();
            }
            else
            {
                MessageBox.Show("请选择要修改的行");
            }
        }

        private void ToolStripMenuItemDelete_Click(object sender, EventArgs e)
        {
            if (superGridControlClient.GetSelectedRows().Count > 0)
            {
                if (DialogResult.No == MessageBox.Show("确认要删除选中行的数据吗?", "请注意",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2))
                {
                    return;
                }
                BaseArea client = new BaseArea();
                AreaInterface cm = new AreaInterface();
                SelectedElementCollection col = superGridControlClient.GetSelectedRows();
                if (col.Count > 0)
                {
                    GridRow gridRow = col[0] as GridRow;
                    try
                    {
                        int result = cm.UpdateAllClear(0, 0, gridRow.Cells[1].Value.ToString());
                        if (result > 0)
                        {
                            MessageBox.Show("删除成功!");
                            isflag = true;
                            closeDispose();
                        }
                        else
                        {
                            MessageBox.Show("删除失败,请检查是否选中指定行");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("删除异常,请检查服务器连接:" + ex.Message);
                    }
                }
            }
            else
            {
                MessageBox.Show("请先选中要进行删除的行");
            }
        }

        private void ToolStripMenuItemAll_Click(object sender, EventArgs e)
        {

        }

        private void ToolStripMenuItemExcel_Click(object sender, EventArgs e)
        {
            string defaultName = DateTime.Now.ToString("yyyyMMddHHmm") + "客户资料";
            saveFileDialog1.FileName = defaultName + ".xls";
            saveFileDialog1.Filter = "Excel文件（*.xls）|*.xls|Excel 文件(*.xlsx)|*.xlsx";
            saveFileDialog1.AddExtension = true;
            if (saveFileDialog1.ShowDialog() != DialogResult.OK)
            {
                return;
            }
            DataTable dt = (DataTable)superGridControlClient.PrimaryGrid.DataSource;
            GridColumnCollection gcc = superGridControlClient.PrimaryGrid.Columns;
            string[] x = {
                "客户名称", "手机", "电话", "传真", "地区", "详细地址", "联系人", "单位", "所属类别", "银行帐号",
                "开户行", "新增时间", "可用额度", "剩余额度", "结账日", "应收款", "已收款", "预收款", "备注" };
            dt.Columns.Remove("Cli_ID");
            dt.Columns.Remove("Cli_Code");
            dt.Columns.Remove("Cli_zhiwen");
            dt.Columns.Remove("Cli_PicName");
            dt.Columns.Remove("Cli_CityCode");
            dt.Columns.Remove("Cli_TypeCode");
            dt.Columns.Remove("Cli_DiscountCode");
            dt.Columns.Remove("Cli_Olddata");
            dt.Columns.Remove("Cli_Oldreturn");
            dt.Columns.Remove("Cli_Newoutdata");
            dt.Columns.Remove("Cli_Newintodata");
            dt.Columns.Remove("Cli_safetone");
            dt.Columns.Remove("Cli_safettwo");
            dt.Columns.Remove("Cli_Enable");
            try
            {
                NPOIExcelHelper.DataTableToExcel(dt, "sdfe", saveFileDialog1.FileName, x);
                MessageBox.Show("Excel文件已成功导出，请到保存目录下查看。");
            }
            catch (Exception ex)
            {
                MessageBox.Show("保存失败,请检查异常情况:" + ex.Message);
            }
        }

        #endregion

        #region 绑定DGV控件，合并列
        /// <summary>
        /// 绑定DGV控件，合并列
        /// </summary>
        private void MultiColumn()
        {
            GridPanel panel = superGridControlClient.PrimaryGrid;
            GridColumnCollection columns = panel.Columns;

            panel.ColumnHeader.GroupHeaders.Add(
                GetSlCompanyInfoHeader(
                    columns,
                    "Columnsbase",
                    "客户基础资料",
                    "gridColumnCliName",
                    "gridColumnFax"));
            panel.ColumnHeader.GroupHeaders.Add(
                GetSlCompanyInfoHeader(
                    columns,
                    "Columnslocation",
                    "联系地址",
                    "gridColumnArea",
                    "gridColumnAd"));
            //panel.ColumnHeader.GroupHeaders.Add(
            //    GetSlCompanyInfoHeader(
            //        columns,
            //        "Columnsother",
            //        "其他信息",
            //        "gridColumnBa",
            //        "gridColumnPic"));
        }

        /// <summary>
        /// 合并列方法
        /// </summary>
        /// <returns></returns>
        private ColumnGroupHeader GetSlCompanyInfoHeader(
            GridColumnCollection columns,
            string name,
            string headerText,
            string startName,
            string endName)
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

        #region dgv的右键菜单

        private void 新增ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItemCreate.PerformClick();
        }

        private void 编辑ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItemEdit.PerformClick();
        }

        private void 删除ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItemDelete.PerformClick();
        }

        private void 删除全部ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItemAll.PerformClick();
        }

        private void 导出到ExcelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItemExcel.PerformClick();
        }

        private void 刷新ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItemRefresh.PerformClick();
        }



        #endregion

        #region 通用方法

        //双击弹出编辑
        private void superGridControlClient_CellDoubleClick(object sender,
            GridCellDoubleClickEventArgs e)
        {
            if (e.MouseEventArgs.Button == MouseButtons.Left)
            {
                ToolStripMenuItemEdit.PerformClick();
            }
        }

        /// <summary>
        /// 关闭子窗体后对主窗体数据的处理 
        /// </summary>
        private void closeDispose()
        {
            if (isflag)
            {
                loadData();
                treeViewClient.SelectedNode = treeViewClient.Nodes[0];
            }
            else
            {
                treeViewClient.SelectedNode = treeViewClient.Nodes[0];
            }
            isflag = false;
        }

        private void loadTree()
        {
            treeViewClient.Nodes.Clear();
            AreaInterface cm = new AreaInterface();
            DataTable dt = cm.GetList(999,"",false,false);
            AddTree("", null, dt);
        }
        #endregion
    }
}