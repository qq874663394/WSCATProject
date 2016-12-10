using DevComponents.DotNetBar.SuperGrid;
using HelperUtility;
using HelperUtility.Encrypt;
using InterfaceLayer.Base;
using InterfaceLayer.Finance;
using Model;
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
    public partial class FinanceOtherReceivablesForm : TestForm
    {
        public FinanceOtherReceivablesForm()
        {
            InitializeComponent();
        }

        #region 调用接口以及加密解密方法
        CodingHelper ch = new CodingHelper();
        ClientInterface client = new ClientInterface();//客户
        BankAccountInterface bank = new BankAccountInterface();//结算账户
        EmpolyeeInterface employee = new EmpolyeeInterface();//员工
        ProjectInCostInterface projectInCost = new ProjectInCostInterface();//收入类别
        FinanceOtherExpensesInInterface financeOtherExpensesInterface = new FinanceOtherExpensesInInterface();//
        #endregion

        #region 数据字段

        /// <summary>
        /// 所有客户
        /// </summary>
        private DataTable _AllClient = null;
        /// <summary>
        /// 所有账户
        /// </summary>
        private DataTable _AllBank = null;
        /// <summary>
        /// 所有经手人
        /// </summary>
        private DataTable _AllEmployee = null;
        /// <summary>
        /// 点击的项,1客户  2为结算账户  3为经手人
        /// </summary>
        private int _Click = 0;
        /// <summary>
        /// 保存客户Code
        /// </summary>
        private string _clientCode;
        /// <summary>
        /// 保存银行账户code
        /// </summary>
        private string _bankCode;
        /// <summary>
        /// 保存经手人Code
        /// </summary>
        private string _employeeCode;
        /// <summary>
        /// 其它收款单单code
        /// </summary>
        private string _financeReceivablesCode;
        /// <summary>
        ///所有收入类别
        /// </summary>
        private DataTable _AllProjectInCost = null;
        /// <summary>
        /// 保存收入类别code
        /// </summary>
        private string _ProjectInCostCode;
        /// <summary>
        /// 统计单据金额
        /// </summary>
        private decimal _Money;


        #endregion

        #region 初始化数据
        /// <summary>
        /// 统计行数据
        /// </summary>
        private void InitDataGridView()
        {
            //新增一行 用于给客户操作
            superGridControlShangPing.PrimaryGrid.NewRow(true);
            //最后一行做统计行
            GridRow gr = (GridRow)superGridControlShangPing.PrimaryGrid.
                Rows[superGridControlShangPing.PrimaryGrid.Rows.Count - 1];
            gr.ReadOnly = true;
            gr.CellStyles.Default.Background.Color1 = Color.SkyBlue;
            gr.Cells["material"].Value = "合计";
            gr.Cells["material"].CellStyles.Default.Alignment =
                DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleCenter;
            gr.Cells["gridColumnMoney"].Value = 0;
            gr.Cells["gridColumnMoney"].CellStyles.Default.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleCenter;
            gr.Cells["gridColumnMoney"].CellStyles.Default.Background.Color1 = Color.Orange;
            #region 表格最后一行不能点击
            gr.Cells["material"].AllowSelection = false;
            gr.Cells["gridColumnMoney"].AllowSelection = false;
            gr.Cells["gridColumnRemark"].AllowSelection = false;
            #endregion
        }

        /// <summary>
        /// 非空验证
        /// </summary>
        private bool isNUllValidate()
        {
            if (labtextboxTop2.Text.Trim() == null || labtextboxTop2.Text == "")
            {
                MessageBox.Show("客户不能为空！");
                labtextboxTop2.Focus();
                return false;
            }
            if (labtextboxTop4.Text.Trim() == null || labtextboxTop4.Text == "")
            {
                MessageBox.Show("结算账户不能为空！");
                labtextboxTop4.Focus();
                return false;
            }
            GridRow gr = (GridRow)superGridControlShangPing.PrimaryGrid.Rows[1];
            double money = Convert.ToDouble(gr.Cells["gridColumnMoney"].Value);
            if (gr.Cells["material"].Value == null || gr.Cells["material"].Value.ToString() == "合计")
            {
                MessageBox.Show("表格里收入类别不能为空！");
                superGridControlShangPing.Focus();
                return false;
            }
            if (money == 0.00)
            {
                MessageBox.Show("金额不能为0，请检查：");
                superGridControlShangPing.Focus();
                return false;
            }
            if (ltxtbSalsMan.Text.Trim() == null || ltxtbSalsMan.Text == "")
            {
                MessageBox.Show("经手人不能为空！");
                ltxtbSalsMan.Focus();
                return false;
            }
            return true;
        }

        /// <summary>
        /// 初始化客户
        /// </summary>
        private void InitClient()
        {
            try
            {
                if (_Click != 1)
                {
                    _Click = 1;
                    dataGridViewFuJia.DataSource = null;
                    dataGridViewFuJia.Columns.Clear();

                    DataGridViewTextBoxColumn dgvc = new DataGridViewTextBoxColumn();
                    dgvc.Name = "code";
                    dgvc.HeaderText = "客户编号";
                    dgvc.DataPropertyName = "code";
                    dgvc.SortMode = DataGridViewColumnSortMode.NotSortable;
                    dataGridViewFuJia.Columns.Add(dgvc);

                    dgvc = new DataGridViewTextBoxColumn();
                    dgvc.Name = "name";
                    dgvc.HeaderText = "客户姓名";
                    dgvc.DataPropertyName = "name";
                    dgvc.SortMode = DataGridViewColumnSortMode.NotSortable;
                    dataGridViewFuJia.Columns.Add(dgvc);

                    resizablePanel1.Location = new Point(550, 160);
                    dataGridViewFuJia.DataSource = ch.DataTableReCoding(_AllClient);
                    resizablePanel1.Visible = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("错误代码：5101-尝试点击客户数据显示失败或者无数据！请检查：" + ex.Message, "其它收款单温馨提示！");
            }
        }

        /// <summary>
        /// 初始化结算账户
        /// </summary>
        private void InitBank()
        {
            try
            {
                if (_Click != 2)
                {
                    _Click = 2;
                    dataGridViewFuJia.DataSource = null;
                    dataGridViewFuJia.Columns.Clear();

                    DataGridViewTextBoxColumn dgvc = new DataGridViewTextBoxColumn();
                    dgvc.Name = "code";
                    dgvc.HeaderText = "账户编号";
                    dgvc.DataPropertyName = "code";
                    dgvc.SortMode = DataGridViewColumnSortMode.NotSortable;
                    dataGridViewFuJia.Columns.Add(dgvc);

                    dgvc = new DataGridViewTextBoxColumn();
                    dgvc.Name = "openBank";
                    dgvc.HeaderText = "开户行";
                    dgvc.DataPropertyName = "openBank";
                    dgvc.SortMode = DataGridViewColumnSortMode.NotSortable;
                    dataGridViewFuJia.Columns.Add(dgvc);

                    dgvc = new DataGridViewTextBoxColumn();
                    dgvc.Name = "bankCard";
                    dgvc.HeaderText = "银行账户";
                    dgvc.DataPropertyName = "bankCard";
                    dgvc.Visible = false;
                    dgvc.SortMode = DataGridViewColumnSortMode.NotSortable;
                    dataGridViewFuJia.Columns.Add(dgvc);

                    dgvc = new DataGridViewTextBoxColumn();
                    dgvc.Name = "cardHolder";
                    dgvc.HeaderText = "持卡人";
                    dgvc.DataPropertyName = "cardHolder";
                    dgvc.Visible = false;
                    dgvc.SortMode = DataGridViewColumnSortMode.NotSortable;
                    dataGridViewFuJia.Columns.Add(dgvc);

                    dgvc = new DataGridViewTextBoxColumn();
                    dgvc.Name = "remark";
                    dgvc.HeaderText = "备注";
                    dgvc.DataPropertyName = "remark";
                    dgvc.Visible = false;
                    dgvc.SortMode = DataGridViewColumnSortMode.NotSortable;
                    dataGridViewFuJia.Columns.Add(dgvc);

                    dgvc = new DataGridViewTextBoxColumn();
                    dgvc.Name = "availableBalance";
                    dgvc.HeaderText = "可用额度";
                    dgvc.DataPropertyName = "availableBalance";
                    dgvc.Visible = false;
                    dgvc.SortMode = DataGridViewColumnSortMode.NotSortable;
                    dataGridViewFuJia.Columns.Add(dgvc);

                    resizablePanel1.Location = new Point(550, 190);
                    dataGridViewFuJia.DataSource = ch.DataTableReCoding(_AllBank);
                    resizablePanel1.Visible = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("错误代码：5102-尝试点击结算账户，数据显示失败或者无数据！请检查：" + ex.Message, "其它收款单温馨提示！");
            }
        }

        /// <summary>
        /// 初始化经手人
        /// </summary>
        private void InitEmployee()
        {
            try
            {
                if (_Click != 3)
                {
                    _Click = 3;
                    dataGridViewFuJia.DataSource = null;
                    dataGridViewFuJia.Columns.Clear();

                    DataGridViewTextBoxColumn dgvc = new DataGridViewTextBoxColumn();
                    dgvc.Name = "code";
                    dgvc.HeaderText = "员工工号";
                    dgvc.DataPropertyName = "员工工号";
                    dgvc.SortMode = DataGridViewColumnSortMode.NotSortable;
                    dataGridViewFuJia.Columns.Add(dgvc);

                    dgvc = new DataGridViewTextBoxColumn();
                    dgvc.Name = "name";
                    dgvc.HeaderText = "姓名";
                    dgvc.DataPropertyName = "姓名";
                    dgvc.SortMode = DataGridViewColumnSortMode.NotSortable;
                    dataGridViewFuJia.Columns.Add(dgvc);

                    dataGridViewFuJia.DataSource = ch.DataTableReCoding(_AllEmployee);
                    resizablePanel1.Visible = true;
                    if (this.WindowState == FormWindowState.Maximized)
                    {
                        resizablePanel1.Location = new Point(220, 670);
                        return;
                    }
                    if (this.WindowState == FormWindowState.Normal)
                    {
                        resizablePanel1.Location = new Point(234, 460);
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("错误代码：5103-尝试点击经手人，数据显示失败或者无数据！请检查：" + ex.Message, "其它收款单温馨提示！");
            }
        }

        /// <summary>
        /// 初始化收入类别
        /// </summary>
        private void InitProjectInCost()
        {
            try
            {
                dataGridViewShangPing.DataSource = null;
                dataGridViewShangPing.Columns.Clear();
                DataGridViewTextBoxColumn dgvc = new DataGridViewTextBoxColumn();
                dgvc.Name = "code";
                dgvc.Visible = false;
                dgvc.HeaderText = "编号";
                dgvc.DataPropertyName = "code";
                dgvc.SortMode = DataGridViewColumnSortMode.NotSortable;
                dataGridViewShangPing.Columns.Add(dgvc);

                dgvc = new DataGridViewTextBoxColumn();
                dgvc.Name = "projectCode";
                dgvc.HeaderText = "收入类别代码";
                dgvc.DataPropertyName = "projectCode";
                dgvc.SortMode = DataGridViewColumnSortMode.NotSortable;
                dataGridViewShangPing.Columns.Add(dgvc);

                dgvc = new DataGridViewTextBoxColumn();
                dgvc.Name = "name";
                dgvc.HeaderText = "收入类别名称";
                dgvc.DataPropertyName = "name";
                dgvc.SortMode = DataGridViewColumnSortMode.NotSortable;
                dataGridViewShangPing.Columns.Add(dgvc);

                dgvc = new DataGridViewTextBoxColumn();
                dgvc.Name = "parentId";
                dgvc.Visible = false;
                dgvc.HeaderText = "parentId";
                dgvc.DataPropertyName = "parentId";
                dgvc.SortMode = DataGridViewColumnSortMode.NotSortable;
                dataGridViewShangPing.Columns.Add(dgvc);
            }
            catch (Exception ex)
            {
                MessageBox.Show("错误代码：5104-尝试点击收入类别，数据显示失败或者无数据，请检查：" + ex.Message);
            }
        }

        /// <summary>
        /// 标记那个控件不可用
        /// </summary>
        private void InitForm()
        {
            foreach (Control c in panel2.Controls)
            {
                switch (c.GetType().Name)
                {
                    case "Label":
                        c.Enabled = false;
                        c.ForeColor = Color.Gray;
                        break;
                    case "TextBoxX":
                        c.Enabled = false;
                        c.BackColor = Color.White;
                        break;
                    case "ComboBoxEx":
                        c.Enabled = false;
                        c.BackColor = Color.White;
                        break;
                    case "PictureBox":
                        c.Enabled = false;
                        break;
                }
            }
            foreach (Control c in panel5.Controls)
            {
                switch (c.GetType().Name)
                {
                    case "Label":
                        c.Enabled = false;
                        c.ForeColor = Color.Gray;
                        break;
                    case "TextBoxX":
                        c.Enabled = false;
                        c.BackColor = Color.White;
                        break;
                    case "PictureBox":
                        c.Enabled = false;
                        break;
                }
            }
            superGridControlShangPing.PrimaryGrid.ReadOnly = true;
            pictureBoxShengHe.Visible = true;
            toolStripBtnSave.Enabled = false;
            toolStripBtnShengHe.Enabled = false;
        }

        #endregion

        #region 改变边框颜色
        /// <summary>
        /// 改变边框颜色
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics,
                                 this.panel2.ClientRectangle,
                                 Color.FromArgb(85, 177, 238),
                                 2,
                                 ButtonBorderStyle.Solid,
                                 Color.FromArgb(85, 177, 238),
                                 1,
                                 ButtonBorderStyle.Solid,
                                 Color.FromArgb(85, 177, 238),
                                 2,
                                 ButtonBorderStyle.Solid,
                                  Color.FromArgb(85, 177, 238),
                                 //Color.White,
                                 1,
                                 ButtonBorderStyle.Solid);
        }
        #endregion

        /// <summary>
        /// 加载事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FinanceOtherReceivablesForm_Load(object sender, EventArgs e)
        {
            try
            {
                #region 初始化
                pictureBoxShengHe.Parent = pictureBoxtitle;
                cboType.SelectedIndex = 0;
                cboMethed.SelectedIndex = 0;
                //禁用自动创建列
                dataGridViewShangPing.AutoGenerateColumns = false;
                dataGridViewFuJia.AutoGenerateColumns = false;
                //是否显示滚动条
                superGridControlShangPing.HScrollBarVisible = true;
                // 将dataGridView中的内容居中显示
                dataGridViewFuJia.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dataGridViewShangPing.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                superGridControlShangPing.DefaultVisualStyles.CellStyles.Default.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleCenter;
                // 将dataGridView表头居中显示
                dataGridViewShangPing.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                //显示行号
                superGridControlShangPing.PrimaryGrid.ShowRowGridIndex = true;
                //排序方式范围
                superGridControlShangPing.PrimaryGrid.SortCycle = SortCycle.AscDesc;
                //设置排序列和排序方式
                superGridControlShangPing.PrimaryGrid.AddSort(superGridControlShangPing.PrimaryGrid.Columns[0], SortDirection.Ascending);
                //调用合计行数据
                InitDataGridView();

                //金额
                GridDoubleInputEditControl gdiecMoney = superGridControlShangPing.PrimaryGrid.Columns["gridColumnMoney"].EditControl as GridDoubleInputEditControl;
                gdiecMoney.MinValue = 1;
                gdiecMoney.MaxValue = 999999999;
                #endregion

                //客户
                _AllClient = client.GetClientByBool(false);
                //结算账户
                _AllBank = bank.GetList(999, "", false, false);
                //收款员
                _AllEmployee = employee.SelSupplierTable(false);
                //收入类别
                _AllProjectInCost = projectInCost.GetList(999, "");

                //生成其它收款单code和显示条形码
                _financeReceivablesCode = BuildCode.ModuleCode("FOR");
                textBoxOddNumbers.Text = _financeReceivablesCode;
                barcodeXYE.Code128 _Code = new barcodeXYE.Code128();
                _Code.ValueFont = new Font("微软雅黑", 20);
                System.Drawing.Bitmap imgTemp = _Code.GetCodeImage(textBoxOddNumbers.Text, barcodeXYE.Code128.Encode.Code128A);
                pictureBoxBarCode.Image = imgTemp;
            }
            catch (Exception ex)
            {
                MessageBox.Show("错误代码：5105-窗体加载时，初始化数据失败" + ex.Message, "其它收款单温馨提示！");
            }

            toolStripBtnSave.Click += toolStripBtnSave_Click;//保存按钮
            toolStripBtnShengHe.Click += toolStripBtnShengHe_Click;//审核按钮
            dataGridViewFuJia.CellDoubleClick += dataGridViewFuJia_CellDoubleClick;//dataGridViewFuJia表格双击事件
            dataGridViewShangPing.CellDoubleClick += dataGridViewShangPing_CellDoubleClick;//dataGridViewShangPing表格双击事件
            dataGridViewFuJia.KeyDown += DataGridViewFuJia_KeyDown;
            dataGridViewShangPing.KeyDown += dataGridViewShangPing_KeyDown;
        }

        /// <summary>
        /// 单据类型下拉框选择改变事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cboType_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cboType.Text.Trim())
            {
                case "收款结算":
                    labTop4.ForeColor = Color.Black;
                    labtextboxTop4.Enabled = true;
                    labtextboxTop4.Border.BorderBottomColor = Color.Black;
                    labTop8.ForeColor = Color.Black;
                    cboMethed.Enabled = true;
                    break;
                case "其它应收":
                    labTop4.ForeColor = Color.Gray;
                    labtextboxTop4.Enabled = false;
                    labtextboxTop4.BackColor = Color.White;
                    labtextboxTop4.Border.BorderBottomColor = Color.Gray;
                    labTop8.ForeColor = Color.Gray;
                    cboMethed.Enabled = false;
                    pictureBox3.Enabled = false;
                    break;
            }
        }

        #region 小箭头点击事件和表格的双击事件
        /// <summary>
        /// 客户小箭头点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pictureBoxDanJuType_Click(object sender, EventArgs e)
        {
            if (_Click != 1)
            {
                InitClient();
                dataGridViewFuJia.Focus();
            }
            _Click = 4;
        }

        /// <summary>
        /// 结算账户小箭头点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pictureBoxBank_Click(object sender, EventArgs e)
        {
            if (_Click != 2)
            {
                InitBank();
                dataGridViewFuJia.Focus();
            }
            _Click = 5;
        }

        /// <summary>
        ///经手人小箭头点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pictureBoxEmployee_Click(object sender, EventArgs e)
        {
            if (_Click != 3)
            {
                InitEmployee();
                dataGridViewFuJia.Focus();
            }
            _Click = 6;
        }

        /// <summary>
        /// 双击绑定客户、结算账户、经手人数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridViewFuJia_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
            {
                return;
            }
            dataGridViewFuJiaTableClick();
        }

        /// <summary>
        /// dataGridViewFuJia表格双击事件函数
        /// </summary>
        private void dataGridViewFuJiaTableClick()
        {
            try
            {
                //客户
                if (_Click == 1 || _Click == 4)
                {
                    _clientCode = dataGridViewFuJia.Rows[dataGridViewFuJia.CurrentRow.Index].Cells["code"].Value.ToString();//客户code
                    string name = dataGridViewFuJia.Rows[dataGridViewFuJia.CurrentRow.Index].Cells["name"].Value.ToString();//客户名称
                    labtextboxTop2.Text = name;
                    resizablePanel1.Visible = false;
                }
                //结算账户
                if (_Click == 2 || _Click == 5)
                {
                    _bankCode = dataGridViewFuJia.Rows[dataGridViewFuJia.CurrentRow.Index].Cells["code"].Value.ToString();//银行账户code
                    string name = dataGridViewFuJia.Rows[dataGridViewFuJia.CurrentRow.Index].Cells["openBank"].Value.ToString();//账户名称
                    labtextboxTop4.Text = name;
                    resizablePanel1.Visible = false;
                }
                //收款员
                if (_Click == 3 || _Click == 6)
                {
                    _employeeCode = dataGridViewFuJia.Rows[dataGridViewFuJia.CurrentRow.Index].Cells["code"].Value.ToString();//经手人code
                    string name = dataGridViewFuJia.Rows[dataGridViewFuJia.CurrentRow.Index].Cells["name"].Value.ToString();//经手人
                    ltxtbSalsMan.Text = name;
                    resizablePanel1.Visible = false;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("错误代码：5106-双击绑定客户、结算账户、经手人数据错误！请检查：" + ex.Message, "其它收款单温馨提示！");
            }
        }

        private void DataGridViewFuJia_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                dataGridViewFuJiaTableClick();
            }
        }

        private void dataGridViewShangPing_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                dataGridViewShangPingTableClick();
            }
        }

        /// <summary>
        /// 表格里查询收入类别
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void superGridControlShangPing_BeginEdit(object sender, GridEditEventArgs e)
        {
            try
            {
                if (e.GridCell.GridColumn.Name == "material")
                {
                    SelectedElementCollection ge = superGridControlShangPing.PrimaryGrid.GetSelectedCells();
                    GridCell gc = ge[0] as GridCell;
                    string typeDaima = XYEEncoding.strCodeHex(e.EditControl.EditorValue.ToString());
                    if (gc.GridRow.Cells[material].Value != null && (gc.GridRow.Cells[material].Value).ToString() != "")
                    {
                        //模糊查询收入类别列表
                        _AllProjectInCost = projectInCost.GetList(0, "" + typeDaima + "");
                        InitProjectInCost();
                    }
                    else
                    {
                        //查询收入类别列表
                        _AllProjectInCost = projectInCost.GetList(999, "");
                        InitProjectInCost();
                    }

                    dataGridViewShangPing.DataSource = ch.DataTableReCoding(_AllProjectInCost);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("错误代码：5107-尝试点击表格的收入类别，数据显示失败或者无数据，请检查：" + ex.Message);
            }
        }

        /// <summary>
        /// 双击绑定商品数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridViewShangPing_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
            {
                return;
            }
            dataGridViewShangPingTableClick();
        }

        /// <summary>
        /// dataGridViewShangPing表格双击事件函数
        /// </summary>
        private void dataGridViewShangPingTableClick()
        {
            try
            {
                //是否要新增一行的标记
                bool newAdd = false;
                GridRow gr = (GridRow)superGridControlShangPing.PrimaryGrid.Rows[ClickRowIndex];
                GridItemsCollection grs = superGridControlShangPing.PrimaryGrid.Rows;
                //id字段为空 说明是没有数据的行 不是修改而是新增
                if (gr.Cells["gridColumnid"].Value == null)
                {
                    newAdd = true;
                }
                gr.Cells["material"].Value = dataGridViewShangPing.Rows[dataGridViewShangPing.CurrentRow.Index].Cells["name"].Value;
                resizablePanelData.Visible = false;
                //新增一行
                if (newAdd)
                {
                    superGridControlShangPing.PrimaryGrid.NewRow(superGridControlShangPing.PrimaryGrid.Rows.Count);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("错误代码：5108-双击绑定收入类别失败！" + ex.Message, "其它收款单温馨提示！");
            }
            superGridControlShangPing.Focus();
            SendKeys.Send("^{End}{Home}");
        }

        #endregion

        #region 模糊查询
        /// <summary>
        /// 客户模糊查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtClient_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.labtextboxTop2.Text.Trim() == "")
                {
                    InitClient();
                    _Click = 4;
                    return;
                }
                dataGridViewFuJia.DataSource = null;
                dataGridViewFuJia.Columns.Clear();

                DataGridViewTextBoxColumn dgvc = new DataGridViewTextBoxColumn();
                dgvc.Name = "code";
                dgvc.HeaderText = "客户编号";
                dgvc.DataPropertyName = "code";
                dataGridViewFuJia.Columns.Add(dgvc);

                dgvc = new DataGridViewTextBoxColumn();
                dgvc.Name = "name";
                dgvc.HeaderText = "客户姓名";
                dgvc.DataPropertyName = "name";
                dataGridViewFuJia.Columns.Add(dgvc);

                resizablePanel1.Location = new Point(500, 160);
                string name = XYEEncoding.strCodeHex(this.labtextboxTop2.Text.Trim());
                dataGridViewFuJia.DataSource = ch.DataTableReCoding(client.GetList(0, name));
                resizablePanel1.Visible = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("错误代码：5109-模糊查询客户数据错误" + ex.Message, "收款单温馨提示");
            }
        }

        /// <summary>
        /// 结算账户模糊查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtBank_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.labtextboxTop4.Text.Trim() == "")
                {
                    InitBank();
                    _Click = 5;
                    return;
                }

                dataGridViewFuJia.DataSource = null;
                dataGridViewFuJia.Columns.Clear();

                DataGridViewTextBoxColumn dgvc = new DataGridViewTextBoxColumn();
                dgvc.Name = "code";
                dgvc.HeaderText = "账户编号";
                dgvc.DataPropertyName = "code";
                dataGridViewFuJia.Columns.Add(dgvc);

                dgvc = new DataGridViewTextBoxColumn();
                dgvc.Name = "openBank";
                dgvc.HeaderText = "开户行";
                dgvc.DataPropertyName = "openBank";
                dataGridViewFuJia.Columns.Add(dgvc);

                dgvc = new DataGridViewTextBoxColumn();
                dgvc.Name = "bankCard";
                dgvc.HeaderText = "银行账户";
                dgvc.DataPropertyName = "bankCard";
                dgvc.Visible = false;
                dataGridViewFuJia.Columns.Add(dgvc);

                dgvc = new DataGridViewTextBoxColumn();
                dgvc.Name = "cardHolder";
                dgvc.HeaderText = "持卡人";
                dgvc.DataPropertyName = "cardHolder";
                dgvc.Visible = false;
                dataGridViewFuJia.Columns.Add(dgvc);

                dgvc = new DataGridViewTextBoxColumn();
                dgvc.Name = "remark";
                dgvc.HeaderText = "备注";
                dgvc.DataPropertyName = "remark";
                dgvc.Visible = false;
                dataGridViewFuJia.Columns.Add(dgvc);

                dgvc = new DataGridViewTextBoxColumn();
                dgvc.Name = "availableBalance";
                dgvc.HeaderText = "可用额度";
                dgvc.DataPropertyName = "availableBalance";
                dgvc.Visible = false;
                dataGridViewFuJia.Columns.Add(dgvc);

                resizablePanel1.Location = new Point(500, 200);
                string name = XYEEncoding.strCodeHex(this.labtextboxTop4.Text.Trim());
                dataGridViewFuJia.DataSource = ch.DataTableReCoding(bank.GetList(1, name, false, false));
                resizablePanel1.Visible = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("错误代码：5110-模糊查询结算账户数据错误" + ex.Message, "其它收款单温馨提示");
            }
        }

        /// <summary>
        ///经手人模糊查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ltxtbSalsMan_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (ltxtbSalsMan.Text.Trim() == "")
                {
                    _Click = 6;
                    InitEmployee();
                    return;
                }
                dataGridViewFuJia.DataSource = null;
                dataGridViewFuJia.Columns.Clear();

                DataGridViewTextBoxColumn dgvc = new DataGridViewTextBoxColumn();
                dgvc.Name = "code";
                dgvc.HeaderText = "员工工号";
                dgvc.DataPropertyName = "code";
                dataGridViewFuJia.Columns.Add(dgvc);

                dgvc = new DataGridViewTextBoxColumn();
                dgvc.Name = "name";
                dgvc.HeaderText = "姓名";
                dgvc.DataPropertyName = "name";
                dataGridViewFuJia.Columns.Add(dgvc);

                dataGridViewFuJia.DataSource = ch.DataTableReCoding(employee.GetList(0, "" + XYEEncoding.strCodeHex(ltxtbSalsMan.Text.Trim()) + ""));
                resizablePanel1.Visible = true;
                if (this.WindowState == FormWindowState.Maximized)
                {
                    resizablePanel1.Location = new Point(220, 670);
                    return;
                }
                if (this.WindowState == FormWindowState.Normal)
                {
                    resizablePanel1.Location = new Point(234, 460);
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("错误代码：5111-模糊查询经手人数据失败！" + ex.Message);
            }
        }

        /// <summary>
        /// 表格里收入类别模糊查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void superGridControlShangPing_EditorValueChanged(object sender, GridEditEventArgs e)
        {
            try
            {
                string SS = "";
                GridRow gr = (GridRow)superGridControlShangPing.PrimaryGrid.Rows[ClickRowIndex];
                GridCell gc = gr[0] as GridCell;
                string TypeDaima = XYEEncoding.strCodeHex(e.EditControl.EditorValue.ToString());
                if (SS == "")
                {
                    //模糊查询收入类别列表
                    _AllProjectInCost = projectInCost.GetList(0, "" + TypeDaima + "");
                    InitProjectInCost();
                    dataGridViewShangPing.DataSource = ch.DataTableReCoding(_AllProjectInCost);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("错误代码:5112-模糊查询表格收入类别数据错误！请检查：" + ex.Message, "其它收款单温馨提示");
            }
        }
        #endregion

        /// <summary>
        /// 按Esc关闭表格
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FinanceOtherReceivablesForm_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Escape)
            {
                this.resizablePanel1.Visible = false;
                this.resizablePanelData.Visible = false;
            }
        }

        /// <summary>
        /// 窗体加载时，焦点在客户上
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FinanceOtherReceivablesForm_Activated(object sender, EventArgs e)
        {
            labtextboxTop2.Focus();//窗体活动时焦点在客户
        }

        /// <summary>
        /// 快捷方式设置
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FinanceOtherReceivablesForm_KeyDown(object sender, KeyEventArgs e)
        {
            //前单
            if (e.KeyCode == Keys.B  )
            {
                MessageBox.Show("前单");
                return;
            }
            //后单
            if (e.KeyCode == Keys.A  )
            {
                MessageBox.Show("后单");
                return;
            }
            //新增
            if (e.KeyCode == Keys.N  )
            {
                MessageBox.Show("新增");
                return;
            }
            //保存
            if (e.KeyCode == Keys.S  )
            {
                Save();
                return;
            }
            //审核
            if (e.KeyCode == Keys.F4)
            {
                DialogResult result = MessageBox.Show("是否一键审核？", "提示信息", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                if (result == DialogResult.OK)
                {
                    Review();
                }
                return;
            }
            //打印
            if (e.KeyCode == Keys.P  )
            {
                MessageBox.Show("打印");
                return;
            }
            //导出Excel
            if (e.KeyCode == Keys.T  )
            {
                MessageBox.Show("导出Excel");
                return;
            }
            //关闭
            if (e.KeyCode == Keys.X  )
            {
                this.Close();
                this.Dispose();
            }
        }

        /// <summary>
        /// 表格验证事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void superGridControlShangPing_CellValidated(object sender, GridCellValidatedEventArgs e)
        {
            try
            {
                //GridRow g = (GridRow)superGridControlShangPing.PrimaryGrid.Rows[1];
                //if (g.Cells["gridColumnShouRuType"].Value == null || g.Cells["gridColumnShouRuType"].Value.ToString() == "")
                //{
                //    MessageBox.Show("请选择收入类别：");
                //    return;
                //}
                TongJi();
            }
            catch (Exception ex)
            {
                MessageBox.Show("错误代码：5113-验证表格里的金额以及统计金额出错！请检查：" + ex.Message, "其它收款单温馨提示！");
            }
        }

        /// <summary>
        /// 统计表格里的金额
        /// </summary>
        private void TongJi()
        {
            GridRow gr = (GridRow)superGridControlShangPing.PrimaryGrid.Rows[ClickRowIndex];
            //逐行统计数据总数
            decimal tempAllMoney = 0;
            for (int i = 0; i < superGridControlShangPing.PrimaryGrid.Rows.Count - 1; i++)
            {
                GridRow tempGR = superGridControlShangPing.PrimaryGrid.Rows[i] as GridRow;
                tempAllMoney += Convert.ToDecimal(tempGR["gridColumnMoney"].FormattedValue);
            }
            _Money = tempAllMoney;
            gr = (GridRow)superGridControlShangPing.PrimaryGrid.LastSelectableRow;
            gr["gridColumnMoney"].Value = _Money.ToString();
            labtextboxTop3.Text = _Money.ToString("0.00");
            labtextboxTop5.Text = _Money.ToString("0.00");
        }

        /// <summary>
        /// 保存按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripBtnSave_Click(object sender, EventArgs e)
        {
            Save();
            toolStripBtnSave.Enabled = false;
        }

        /// <summary>
        /// 审核按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripBtnShengHe_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("是否一键审核？", "提示信息", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            if (result == DialogResult.OK)
            {
                Review();
            }
        }

        /// <summary>
        /// 保存按钮函数
        /// </summary>
        private void Save()
        {
            //非空验证
            if (isNUllValidate() == false)
            {
                return;
            }
            //其它收款单
            FinanceOtherExpensesIn financeOtherExpensesIn = new FinanceOtherExpensesIn();
            //其它收款单详细列表
            List<FinanceOtherExpenseInDetail> financeOtherExpenseInDetailList = new List<FinanceOtherExpenseInDetail>();
            try
            {

                financeOtherExpensesIn.code = XYEEncoding.strCodeHex(validateCode());//其它收款单单号
                if (labtextboxTop2.Text == null || labtextboxTop2.Text == "")
                {
                    MessageBox.Show("客户不能为空！请输入：");
                    labtextboxTop2.Focus();
                    return;
                }
                if (labtextboxTop4.Text == null || labtextboxTop4.Text == "")
                {
                    MessageBox.Show("结算账户不能为空！请输入：");
                    labtextboxTop4.Focus();
                    return;
                }
                if (ltxtbSalsMan.Text == null || ltxtbSalsMan.Text == "")
                {
                    MessageBox.Show("经手人不能为空！请输入：");
                    ltxtbSalsMan.Focus();
                }
                else
                {
                    financeOtherExpensesIn.salesMan = XYEEncoding.strCodeHex(ltxtbSalsMan.Text.Trim());
                }
                financeOtherExpensesIn.type = XYEEncoding.strCodeHex(cboType.Text);//单据类型
                financeOtherExpensesIn.date = this.dateTimePicker1.Value;//开单日期
                financeOtherExpensesIn.clientCode = XYEEncoding.strCodeHex(_clientCode);//客户code
                financeOtherExpensesIn.accountCode = XYEEncoding.strCodeHex(_bankCode);//结算账户code
                financeOtherExpensesIn.settlementType = XYEEncoding.strCodeHex(cboMethed.Text);//结算方式
                financeOtherExpensesIn.settlementNumber = XYEEncoding.strCodeHex(labtextboxTop6.Text == null ? "" : labtextboxTop6.Text.Trim());//结算号
                financeOtherExpensesIn.Abstract = XYEEncoding.strCodeHex(labtextboxTop7.Text == null ? "" : labtextboxTop7.Text.Trim());//摘要
                financeOtherExpensesIn.salesCode = XYEEncoding.strCodeHex(_employeeCode);//经手人code
                financeOtherExpensesIn.operationMan = XYEEncoding.strCodeHex(ltxtbMakeMan.Text == null ? "" : ltxtbMakeMan.Text.Trim());//制单人
                financeOtherExpensesIn.checkMan = XYEEncoding.strCodeHex(ltxtbShengHeMan.Text == null ? "" : ltxtbShengHeMan.Text.Trim());//审核人
                financeOtherExpensesIn.Checkstate = 0;//审核状态
                financeOtherExpensesIn.isClear = 1;
                financeOtherExpensesIn.updateDate = DateTime.Now;
            }
            catch (Exception ex)
            {
                MessageBox.Show("错误代码:5114-尝试创建其它收款单数据出错!请检查:" + ex.Message, "其它收款单温馨提示");
                return;
            }

            try
            {
                //获得商品列表数据,准备传给base层新增数据
                GridRow g = (GridRow)superGridControlShangPing.PrimaryGrid.Rows[ClickRowIndex];
                GridItemsCollection grs = superGridControlShangPing.PrimaryGrid.Rows;
                int i = 0;
                DateTime nowDataTime = DateTime.Now;
                foreach (GridRow gr in grs)
                {
                    if (gr["material"].Value != null)
                    {
                        i++;
                        FinanceOtherExpenseInDetail financeOtherExpensesInDetail = new FinanceOtherExpenseInDetail();
                        if (gr["material"].Value.ToString() != "" || gr["material"].Value != null)
                        {
                            financeOtherExpensesInDetail.Abstract = XYEEncoding.strCodeHex(gr["material"].Value);//收入类别
                        }
                        else
                        {
                            MessageBox.Show("收入类别不能为空，请输入：");
                            superGridControlShangPing.Focus();
                            return;
                        }
                        double money = Convert.ToDouble(gr["gridColumnMoney"].Value);
                        if (money == 0.00)
                        {
                            MessageBox.Show("表格里金额不能为0，请输入：");
                            superGridControlShangPing.Focus();
                            return;
                        }
                        else
                        {
                            financeOtherExpensesInDetail.money = Convert.ToDecimal(gr["gridColumnMoney"].Value);//金额
                        }
                        financeOtherExpensesInDetail.mainCode = XYEEncoding.strCodeHex(this.textBoxOddNumbers.Text);//主表code
                        financeOtherExpensesInDetail.code = XYEEncoding.strCodeHex(_financeReceivablesCode + i.ToString());//其它收款单详细code
                        financeOtherExpensesInDetail.projectInCode = XYEEncoding.strCodeHex(_ProjectInCostCode);//收入类别code                   
                        financeOtherExpensesInDetail.remark = XYEEncoding.strCodeHex(gr["gridColumnRemark"].Value == null ? "" : gr["gridColumnRemark"].Value);//备注  
                        GridRow dr = superGridControlShangPing.PrimaryGrid.Rows[0] as GridRow;
                        financeOtherExpenseInDetailList.Add(financeOtherExpensesInDetail);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("错误代码：5115-尝试创建其它收款单详细数据出错!请检查:" + ex.Message, "其它收款单温馨提示");
                return;
            }
            //增加一条其他收款单和其它收款单详细数据
            object financeOtherReceivablesResult = financeOtherExpensesInterface.AddOrUpdateToMainOrDetail(financeOtherExpensesIn, financeOtherExpenseInDetailList);
            if (financeOtherReceivablesResult != null)
            {
                MessageBox.Show("新增其它收款单数据成功", "其它收款单温馨提示");
            }
        }

        /// <summary>
        /// 审核按钮函数
        /// </summary>
        private void Review()
        {
            //非空验证
            if (isNUllValidate() == false)
            {
                return;
            }
            //其它收款单
            FinanceOtherExpensesIn financeOtherExpensesIn = new FinanceOtherExpensesIn();
            //其它收款单详细列表
            List<FinanceOtherExpenseInDetail> financeOtherExpenseInDetailList = new List<FinanceOtherExpenseInDetail>();
            try
            {
                financeOtherExpensesIn.code = XYEEncoding.strCodeHex(_financeReceivablesCode);//其它收款单单号
                if (labtextboxTop2.Text == null || labtextboxTop2.Text == "")
                {
                    MessageBox.Show("客户不能为空！请输入：");
                    labtextboxTop2.Focus();
                    return;
                }
                if (labtextboxTop4.Text == null || labtextboxTop4.Text == "")
                {
                    MessageBox.Show("结算账户不能为空！请输入：");
                    labtextboxTop4.Focus();
                    return;
                }
                if (ltxtbSalsMan.Text == null || ltxtbSalsMan.Text == "")
                {
                    MessageBox.Show("经手人不能为空！请输入：");
                    ltxtbSalsMan.Focus();
                }
                else
                {
                    financeOtherExpensesIn.salesMan = XYEEncoding.strCodeHex(ltxtbSalsMan.Text.Trim());
                }
                financeOtherExpensesIn.type = XYEEncoding.strCodeHex(cboType.Text);//单据类型
                financeOtherExpensesIn.date = this.dateTimePicker1.Value;//开单日期
                financeOtherExpensesIn.clientCode = XYEEncoding.strCodeHex(_clientCode);//客户code
                financeOtherExpensesIn.accountCode = XYEEncoding.strCodeHex(_bankCode);//结算账户code
                financeOtherExpensesIn.settlementType = XYEEncoding.strCodeHex(cboMethed.Text);//结算方式
                financeOtherExpensesIn.settlementNumber = XYEEncoding.strCodeHex(labtextboxTop6.Text == null ? "" : labtextboxTop6.Text.Trim());//结算号
                financeOtherExpensesIn.Abstract = XYEEncoding.strCodeHex(labtextboxTop7.Text == null ? "" : labtextboxTop7.Text.Trim());//摘要
                financeOtherExpensesIn.salesCode = XYEEncoding.strCodeHex(_employeeCode);//经手人code
                financeOtherExpensesIn.operationMan = XYEEncoding.strCodeHex(ltxtbMakeMan.Text == null ? "" : ltxtbMakeMan.Text.Trim());//制单人
                financeOtherExpensesIn.checkMan = XYEEncoding.strCodeHex(ltxtbShengHeMan.Text == null ? "" : ltxtbShengHeMan.Text.Trim());//审核人
                financeOtherExpensesIn.Checkstate = 1;//审核状态
                financeOtherExpensesIn.isClear = 1;
                financeOtherExpensesIn.updateDate = DateTime.Now;
            }
            catch (Exception ex)
            {
                MessageBox.Show("错误代码:5116-尝试创建并审核其它收款单数据出错!请检查:" + ex.Message, "其它收款单温馨提示");
                return;
            }

            try
            {
                //获得商品列表数据,准备传给base层新增数据
                GridRow g = (GridRow)superGridControlShangPing.PrimaryGrid.Rows[ClickRowIndex];
                GridItemsCollection grs = superGridControlShangPing.PrimaryGrid.Rows;
                int i = 0;
                DateTime nowDataTime = DateTime.Now;
                foreach (GridRow gr in grs)
                {
                    if (gr["material"].Value != null)
                    {
                        i++;
                        FinanceOtherExpenseInDetail financeOtherExpensesInDetail = new FinanceOtherExpenseInDetail();
                        if (gr["material"].Value.ToString() != "" || gr["material"].Value != null)
                        {
                            financeOtherExpensesInDetail.Abstract = XYEEncoding.strCodeHex(gr["material"].Value.ToString());//收入类别
                        }
                        else
                        {
                            MessageBox.Show("收入类别不能为空，请输入：");
                            superGridControlShangPing.Focus();
                            return;
                        }
                        double money = Convert.ToDouble(gr["gridColumnMoney"].Value);
                        if (money == 0.00)
                        {
                            MessageBox.Show("表格里金额不能为0，请输入：");
                            superGridControlShangPing.Focus();
                            return;
                        }
                        else
                        {
                            financeOtherExpensesInDetail.money = Convert.ToDecimal(gr["gridColumnMoney"].Value);//金额
                        }
                        financeOtherExpensesInDetail.mainCode = XYEEncoding.strCodeHex(this.textBoxOddNumbers.Text);//主表code
                        financeOtherExpensesInDetail.code = XYEEncoding.strCodeHex(_financeReceivablesCode + i.ToString());//其它收款单详细code
                        financeOtherExpensesInDetail.projectInCode = XYEEncoding.strCodeHex(_ProjectInCostCode);//收入类别code                   
                        financeOtherExpensesInDetail.remark = XYEEncoding.strCodeHex(gr["gridColumnRemark"].Value == null ? "" : gr["gridColumnRemark"].Value);//备注  
                        GridRow dr = superGridControlShangPing.PrimaryGrid.Rows[0] as GridRow;
                        financeOtherExpenseInDetailList.Add(financeOtherExpensesInDetail);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("错误代码：5117-尝试创建并审核其它收款单详细数据出错!请检查:" + ex.Message, "其它收款单温馨提示");
                return;
            }
            //增加一条其他收款单和其它收款单详细数据
            object financeOtherReceivablesResult = financeOtherExpensesInterface.AddOrUpdateToMainOrDetail(financeOtherExpensesIn, financeOtherExpenseInDetailList);
            if (financeOtherReceivablesResult != null)
            {
                InitForm();
                MessageBox.Show("新增并审核其它收款单数据成功", "其它收款单温馨提示");
            }
        }

        /// <summary>
        /// 验证其它收款单单号是否重复
        /// </summary>
        /// <returns></returns>
        private string validateCode()
        {
            if (financeOtherExpensesInterface.Exists(XYEEncoding.strCodeHex(_financeReceivablesCode)))
            {
                _financeReceivablesCode = BuildCode.ModuleCode("FOR");
            }
            else
            {
                _financeReceivablesCode = textBoxOddNumbers.Text;
            }
            return _financeReceivablesCode;
        }

        /// <summary>
        /// 表格按回车键
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void superGridControlShangPing_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                superGridControlShangPing.Focus();
            }
        }

    }
}
