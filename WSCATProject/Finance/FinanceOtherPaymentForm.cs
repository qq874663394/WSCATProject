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
    public partial class FinanceOtherPaymentForm : TestForm
    {
        private string code;
        public FinanceOtherPaymentForm()
        {
            InitializeComponent();
        }

        #region 调用接口以及加密解密方法
        CodingHelper ch = new CodingHelper();
        SupplierInterface supplier = new SupplierInterface();//供应商
        BankAccountInterface bank = new BankAccountInterface();//结算账户
        EmpolyeeInterface employee = new EmpolyeeInterface();//员工  
        ProjectCostInterface projectCostInterface = new ProjectCostInterface();//其他付款项目
        FinanceOtherExpensesOutInterface financeOtherExpensesoutinter = new FinanceOtherExpensesOutInterface();
        #endregion

        #region 数据字段
        /// <summary>
        /// 所有供应商
        /// </summary>
        private DataTable _AllSupplier = null;

        /// <summary>
        /// 所以经手人
        /// </summary>
        private DataTable _AllEmployee = null;

        /// <summary>
        /// 所有账户
        /// </summary>
        private DataTable _AllBank = null;

        /// <summary>
        /// 点击的项,1供应商  2为采购员  3为仓库   
        /// </summary>
        private int _Click = 0;

        /// <summary>
        /// 保存供应商Code
        /// </summary>
        private string _supplierCode;

        /// <summary>
        /// 保存经手人Code
        /// </summary>
        private string _employeeCode;

        /// <summary>
        /// 账号code
        /// </summary>
        private string _bankCode;

        /// <summary>
        /// 其他付款单的code
        /// </summary>
        private string _financeOtherPaymentCode;

        /// <summary>
        /// 所以其他付款项目
        /// </summary>
        private DataTable _AllProjectInCost;

        /// <summary>
        /// 统计单据金额
        /// </summary>
        private decimal _Money;
        #endregion

        #region 初始化数据
        /// <summary>
        /// 初始化供应商
        /// </summary>
        private void InitSupplier()
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
                    dgvc.HeaderText = "编码";
                    dgvc.DataPropertyName = "编码";
                    dgvc.SortMode = DataGridViewColumnSortMode.NotSortable;
                    dataGridViewFuJia.Columns.Add(dgvc);

                    dgvc = new DataGridViewTextBoxColumn();
                    dgvc.Name = "name";
                    dgvc.HeaderText = "单位名称";
                    dgvc.DataPropertyName = "单位名称";
                    dgvc.SortMode = DataGridViewColumnSortMode.NotSortable;
                    dataGridViewFuJia.Columns.Add(dgvc);

                    dgvc = new DataGridViewTextBoxColumn();
                    dgvc.Name = "mobilePhone";
                    dgvc.HeaderText = "联系手机";
                    dgvc.DataPropertyName = "联系手机";
                    dgvc.SortMode = DataGridViewColumnSortMode.NotSortable;
                    dgvc.Visible = false;
                    dataGridViewFuJia.Columns.Add(dgvc);

                    dgvc = new DataGridViewTextBoxColumn();
                    dgvc.Name = "linkMan";
                    dgvc.HeaderText = "联系人";
                    dgvc.DataPropertyName = "联系人";
                    dgvc.SortMode = DataGridViewColumnSortMode.NotSortable;
                    dgvc.Visible = false;
                    dataGridViewFuJia.Columns.Add(dgvc);

                    dgvc = new DataGridViewTextBoxColumn();
                    dgvc.Name = "fax";
                    dgvc.HeaderText = "传真";
                    dgvc.DataPropertyName = "传真";
                    dgvc.SortMode = DataGridViewColumnSortMode.NotSortable;
                    dgvc.Visible = false;
                    dataGridViewFuJia.Columns.Add(dgvc);

                    resizablePanel1.Location = new Point(520, 160);
                    dataGridViewFuJia.DataSource = ch.DataTableReCoding(_AllSupplier);
                    resizablePanel1.Visible = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("错误代码：5208-尝试点击供应商数据出错或者无数据！请检查：" + ex.Message, "其他付款单温馨提示！");
            }
        }

        /// <summary>
        /// 初始化经手人
        /// </summary>
        private void InitEmployee()
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
                MessageBox.Show("错误代码：5209-尝试点击经手人数据出错或者无数据！请检查：" + ex.Message, "其他付款单温馨提示！");
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

                    resizablePanel1.Location = new Point(530, 190);
                    dataGridViewFuJia.DataSource = ch.DataTableReCoding(_AllBank);
                    resizablePanel1.Visible = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("错误代码：5210-尝试点击结算账户，数据显示失败或者无数据！请检查：" + ex.Message, "其他付款单温馨提示！");
            }
        }

        /// <summary>
        /// 统计行数据
        /// </summary>
        private void InitDataGridView()
        {
            //superGridControlShangPing.DefaultVisualStyles.CellStyles.Default.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleCenter;
            //superGridControlShangPing.PrimaryGrid.SortCycle = SortCycle.AscDesc;    //排序方式范围
            //superGridControlShangPing.PrimaryGrid.AddSort(superGridControlShangPing.PrimaryGrid.Columns[0], SortDirection.Ascending);//设置排序列和排序方式
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
            gr.Cells["material"].AllowSelection = false;
            gr.Cells["gridColumnMoney"].AllowSelection = false;
            gr.Cells["gridColumnbeizhu"].AllowSelection = false;
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
            dateTimePicker1.Enabled = false;
            pictureBoxshenghe.Visible = true;
        }

        /// <summary>
        /// 标记那个控件可用
        /// </summary>
        private void EnabledForm()
        {
            foreach (Control c in panel2.Controls)
            {
                switch (c.GetType().Name)
                {
                    case "Label":
                        c.Enabled = true;
                        c.ForeColor = Color.Gray;
                        break;
                    case "TextBoxX":
                        c.Enabled = true;
                        c.BackColor = Color.White;
                        break;
                    case "ComboBoxEx":
                        c.Enabled = true;
                        c.BackColor = Color.White;
                        break;
                    case "PictureBox":
                        c.Enabled = true;
                        break;
                }
            }
            foreach (Control c in panel5.Controls)
            {
                switch (c.GetType().Name)
                {
                    case "Label":
                        c.Enabled = true;
                        c.ForeColor = Color.Gray;
                        break;
                    case "TextBoxX":
                        c.Enabled = true;
                        c.BackColor = Color.White;
                        break;
                    case "PictureBox":
                        c.Enabled = true;
                        break;
                }
            }
            superGridControlShangPing.PrimaryGrid.ReadOnly = false;
            dateTimePicker1.Enabled = true;
            pictureBoxshenghe.Visible = false;
        }

        /// <summary>
        /// 初始化收入类别
        /// </summary>
        private void InitProjectCost()
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
                MessageBox.Show("初始化收入类别失败，请检查：" + ex.Message);
            }
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
            if (gr.Cells["material"].Value == null || gr.Cells["material"].Value.ToString() == "")
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
        /// 关标定位
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FinanceOtherPaymentForm_Activated(object sender, EventArgs e)
        {
            labtextboxTop2.Focus();
        }

        /// <summary>
        /// 窗体加载事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FinanceOtherPaymentForm_Load(object sender, EventArgs e)
        {
            try
            {
                //供应商
                _AllSupplier = supplier.SelSupplierTable();
                //经手人
                _AllEmployee = employee.SelSupplierTable(false);
                //结算账户
                _AllBank = bank.GetList(999, "", false, false);

                //生成采购订单code和显示条形码
                _financeOtherPaymentCode = BuildCode.ModuleCode("FOP");
                textBoxOddNumbers.Text = _financeOtherPaymentCode;
                barcodeXYE.Code128 _Code = new barcodeXYE.Code128();
                _Code.ValueFont = new Font("微软雅黑", 20);
                System.Drawing.Bitmap imgTemp = _Code.GetCodeImage(textBoxOddNumbers.Text, barcodeXYE.Code128.Encode.Code128A);
                pictureBoxtiaoxingma.Image = imgTemp;

                #region 初始化数据
                comboBoxType.SelectedIndex = 0;
                comboBoxjiesuanfangshi.SelectedIndex = 0;
                InitDataGridView();
                //禁用自动创建列
                dataGridViewShangPing.AutoGenerateColumns = false;
                dataGridViewFuJia.AutoGenerateColumns = false;
                superGridControlShangPing.HScrollBarVisible = true;
                // 将dataGridView中的内容居中显示
                dataGridViewFuJia.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dataGridViewShangPing.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dataGridViewShangPing.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                //显示行号
                superGridControlShangPing.PrimaryGrid.ShowRowGridIndex = true;
                //内容居中
                superGridControlShangPing.DefaultVisualStyles.CellStyles.Default.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleCenter;
                superGridControlShangPing.PrimaryGrid.SortCycle = SortCycle.AscDesc;    //排序方式范围
                superGridControlShangPing.PrimaryGrid.AddSort(superGridControlShangPing.PrimaryGrid.Columns[0], SortDirection.Ascending);//设置排序列和排序方式
                //金额
                GridDoubleInputEditControl gdiecMoney = superGridControlShangPing.PrimaryGrid.Columns["gridColumnMoney"].EditControl as GridDoubleInputEditControl;
                gdiecMoney.MinValue = 1;
                gdiecMoney.MaxValue = 999999999;
                #endregion

                //绑定事件 双击事填充内容并隐藏列表
                dataGridViewFuJia.CellDoubleClick += dataGridViewFuJia_CellDoubleClick;
                dataGridViewShangPing.CellDoubleClick += DataGridViewShangPing_CellDoubleClick;
                toolStripBtnSave.Click += ToolStripBtnSave_Click;//保存
                toolStripBtnShengHe.Click += ToolStripBtnShengHe_Click;//审核按钮
                dataGridViewFuJia.KeyDown += DataGridViewFuJia_KeyDown;
                toolStripBtnQianDan.Click += ToolStripBtnQianDan_Click;
                toolStripBtnHouDan.Click += ToolStripBtnHouDan_Click;
                toolStripBtnInsert.Click += ToolStripBtnInsert_Click;
                this.toolStripBtnHouDan.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("错误代码：5201-其他付款单初始化加载数据错误！" + ex.Message, "其他付款单温馨提示:");
                this.Close();
            }

        }

        /// <summary>
        /// 清除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToolStripBtnInsert_Click(object sender, EventArgs e)
        {
            //清空行
            superGridControlShangPing.PrimaryGrid.Rows.Clear();
            InitDataGridView();
            labtextboxTop2.Text = "";
            labtextboxTop3.Text = "0.00";
            labtextboxTop4.Text = "";
            labtextboxBotton2.Text = "";
            labtextboxTop5.Text = "0.00";
            labtextboxTop6.Text = "";
            ltxtbMakeMan.Text = "";
            ltxtbSalsMan.Text = "";
            ltxtbShengHeMan.Text = "";
            resizablePanel1.Visible = false;
            //审核的取消
            EnabledForm(); //标记控件可用
            toolStripBtnShengHe.Enabled = true;
            //隐藏lbl清空
            lblCheckState.Text = "";
            lblcode.Text = "";
        }

        /// <summary>
        /// 小表格的回车事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DataGridViewFuJia_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                dataGridViewFuJiTableClick();
            }
        }

        /// <summary>
        /// 审核按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToolStripBtnShengHe_Click(object sender, EventArgs e)
        {
            //审核
            DialogResult result = MessageBox.Show("是否一键审核？", "提示信息", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            if (result == DialogResult.OK)
            {
                Review();
            }
        }

        /// <summary>
        /// 保存按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToolStripBtnSave_Click(object sender, EventArgs e)
        {
            Save();
        }

        #region 小箭头和表格点击绑定事件

        /// <summary>
        /// 小表格的双击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridViewFuJia_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
            {
                return;
            }
            dataGridViewFuJiTableClick();
        }

        /// <summary>
        /// 小表格的项目点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DataGridViewShangPing_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
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
                MessageBox.Show("错误代码：5207-双击绑定收入类别失败！" + ex.Message, "其它收款单温馨提示！");
            }
            superGridControlShangPing.Focus();
            SendKeys.Send("^{End}{Home}");
        }

        /// <summary>
        /// 供应商小箭头的点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pictureBoxSupplier_Click(object sender, EventArgs e)
        {
            if (_Click != 1)
            {
                InitSupplier();
                this.dataGridViewFuJia.Focus();
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
        /// 经手人的小箭头点击事件
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

        private void dataGridViewFuJiTableClick()
        {
            try
            {
                //供应商
                if (_Click == 1 || _Click == 4)
                {
                    _supplierCode = dataGridViewFuJia.Rows[dataGridViewFuJia.CurrentRow.Index].Cells["code"].Value.ToString();//供应商code
                    string name = dataGridViewFuJia.Rows[dataGridViewFuJia.CurrentRow.Index].Cells["name"].Value.ToString();//供应商名称
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
                    _employeeCode = dataGridViewFuJia.Rows[dataGridViewFuJia.CurrentRow.Index].Cells["code"].Value.ToString();//收款员code
                    string name = dataGridViewFuJia.Rows[dataGridViewFuJia.CurrentRow.Index].Cells["name"].Value.ToString();//收款员
                    ltxtbSalsMan.Text = name;
                    resizablePanel1.Visible = false;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("错误代码：5202-双击绑定客户、结算账户、收款员数据错误！请检查：" + ex.Message, "其他付款单温馨提示！");
            }
        }

        #endregion

        /// <summary>
        /// 单据类别的选中改变事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comboBoxType_SelectedIndexChanged(object sender, EventArgs e)
        {
            string type = comboBoxType.Text;
            switch (type)
            {
                case "费用结算":
                    labTop4.ForeColor = Color.Black;
                    labtextboxTop4.ReadOnly = false;
                    labtextboxTop4.ForeColor = Color.Black;
                    labtextboxTop4.Text = "";
                    pictureBox3.Enabled = true;
                    labTop8.ForeColor = Color.Black;
                    labtextboxTop8.ReadOnly = false;
                    labtextboxTop8.ForeColor = Color.Black;
                    labTop6.ForeColor = Color.Black;
                    labtextboxTop6.ReadOnly = false;
                    labtextboxTop6.BackColor = Color.White;
                    labtextboxTop6.ForeColor = Color.Black;
                    break;
                case "其他应付":
                    labTop4.ForeColor = Color.Gray;
                    labtextboxTop4.ReadOnly = true;
                    labtextboxTop4.BackColor = Color.White;
                    labtextboxTop4.ForeColor = Color.Gray;
                    labtextboxTop4.Text = "应付账款账号";
                    pictureBox3.Enabled = false;
                    labTop8.ForeColor = Color.Gray;
                    labtextboxTop8.ReadOnly = true;
                    labtextboxTop8.BackColor = Color.White;
                    labtextboxTop8.ForeColor = Color.Gray;
                    labTop6.ForeColor = Color.Gray;
                    labtextboxTop6.ReadOnly = true;
                    labtextboxTop6.BackColor = Color.White;
                    labtextboxTop6.ForeColor = Color.Gray;
                    break;
            }
        }

        /// <summary>
        /// 设置快捷键
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FinanceOtherPaymentForm_KeyDown(object sender, KeyEventArgs e)
        {
            //前单
            if (e.KeyCode == Keys.B)
            {
                MessageBox.Show("前单");
                return;
            }
            //后单
            if (e.KeyCode == Keys.A)
            {
                MessageBox.Show("后单");
                return;
            }
            //新增
            if (e.KeyCode == Keys.N)
            {
                MessageBox.Show("新增");
                return;
            }
            //保存
            if (e.KeyCode == Keys.S)
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
            if (e.KeyCode == Keys.P)
            {
                MessageBox.Show("打印");
                return;
            }
            //导出Excel
            if (e.KeyCode == Keys.T)
            {
                MessageBox.Show("导出Excel");
                return;
            }
            //关闭
            if (e.KeyCode == Keys.X)
            {
                this.Close();
                this.Dispose();
            }
        }

        /// <summary>
        /// 保存按钮的函数
        /// </summary>
        private void Save()
        {
            FinanceOtherExpensesOut financeOtherExpensesOut = new FinanceOtherExpensesOut();
            //其它收款单详细列表
            List<FinanceOtherExpensesOutDetail> financeOtherExpenseOutDetailList = new List<FinanceOtherExpensesOutDetail>();
            //非空验证
            if (isNUllValidate() == false)
            {
                return;
            }
            try
            {
                //其它收款单
                if (string.IsNullOrWhiteSpace(this.lblcode.Text))
                {
                    financeOtherExpensesOut.code = XYEEncoding.strCodeHex(YanZhengCode());//其它收款单单号
                }
                else
                {
                    financeOtherExpensesOut.code = this.lblcode.Text;
                }
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
                    financeOtherExpensesOut.salesMan = XYEEncoding.strCodeHex(ltxtbSalsMan.Text.Trim());
                }
                financeOtherExpensesOut.type = XYEEncoding.strCodeHex(comboBoxType.Text);//单据类型
                financeOtherExpensesOut.date = this.dateTimePicker1.Value;//开单日期
                financeOtherExpensesOut.clientCode = "";
                financeOtherExpensesOut.supplierCode = XYEEncoding.strCodeHex(_supplierCode);//供应商code
                financeOtherExpensesOut.accountCode = XYEEncoding.strCodeHex(_bankCode);//结算账户code
                financeOtherExpensesOut.settlementType = XYEEncoding.strCodeHex(comboBoxjiesuanfangshi.Text);//结算方式
                financeOtherExpensesOut.settlementNumber = XYEEncoding.strCodeHex(labtextboxTop6.Text.Trim());//结算号
                financeOtherExpensesOut.settlementMoney = Convert.ToDecimal(labtextboxTop3.Text);
                financeOtherExpensesOut.Abstract = XYEEncoding.strCodeHex(labtextboxBotton2.Text.Trim());//摘要
                financeOtherExpensesOut.salesCode = XYEEncoding.strCodeHex(_employeeCode);//经手人code
                financeOtherExpensesOut.operationMan = XYEEncoding.strCodeHex(ltxtbMakeMan.Text.Trim());//制单人
                financeOtherExpensesOut.checkMan = XYEEncoding.strCodeHex(ltxtbShengHeMan.Text.Trim());//审核人
                financeOtherExpensesOut.checkState = 0;//审核状态
                financeOtherExpensesOut.isClear = 1;
                financeOtherExpensesOut.updateDate = DateTime.Now;
                SupplierInterface supplierInterface = new SupplierInterface();
                financeOtherExpensesOut.supplierCode = supplierInterface.GetList(5, XYEEncoding.strCodeHex(labtextboxTop2.Text)).Rows[0]["code"].ToString();//供应商code
                BankAccountInterface bankAccountInterface = new BankAccountInterface();
                financeOtherExpensesOut.accountCode = bankAccountInterface.GetList(3, XYEEncoding.strCodeHex(labtextboxTop4.Text), false, false).Rows[0]["code"].ToString();//结算账户code
                EmpolyeeInterface empolyeeInterface = new EmpolyeeInterface();
                financeOtherExpensesOut.salesCode = empolyeeInterface.GetList(6, XYEEncoding.strCodeHex(ltxtbSalsMan.Text)).Rows[0]["code"].ToString();//经手人code
            }
            catch (Exception ex)
            {
                MessageBox.Show("错误代码:5203-尝试创建其它付款单数据出错!请检查:" + ex.Message, "其它付款单温馨提示");
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
                        if (i == (superGridControlShangPing.PrimaryGrid.Rows.Count - 1))
                        {
                            break;
                        }
                        FinanceOtherExpensesOutDetail financeOtherExpenseOutDetail = new FinanceOtherExpensesOutDetail();
                        if (gr["material"].Value.ToString() != "" || gr["material"].Value != null)
                        {
                            financeOtherExpenseOutDetail.material = XYEEncoding.strCodeHex(gr["material"].Value.ToString());//收入类别
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
                            financeOtherExpenseOutDetail.money = Convert.ToDecimal(gr["gridColumnMoney"].Value);//金额
                        }
                        if (!string.IsNullOrWhiteSpace(this.lblcode.Text))
                        {
                            financeOtherExpenseOutDetail.id = Convert.ToInt32(gr["gridColumnid"].Value);
                        }
                        financeOtherExpenseOutDetail.outCode = financeOtherExpensesOut.code;//主表code
                        financeOtherExpenseOutDetail.projectOutCode = XYEEncoding.strCodeHex(_financeOtherPaymentCode + i);//其它收款单详细code  
                        financeOtherExpenseOutDetail.remark = gr["gridColumnbeizhu"].Value == null ? "" : XYEEncoding.strCodeHex(gr["gridColumnbeizhu"].Value.ToString());//备注  
                        GridRow dr = superGridControlShangPing.PrimaryGrid.Rows[0] as GridRow;
                        financeOtherExpenseOutDetailList.Add(financeOtherExpenseOutDetail);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("错误代码：5204-尝试创建其它付款单详细数据出错!请检查:" + ex.Message, "其它付款单温馨提示");
                return;
            }
            //增加一条其他收款单和其它收款单详细数据
            object financePaymentResult = financeOtherExpensesoutinter.AddOrUpdateToMainOrDetail(financeOtherExpensesOut, financeOtherExpenseOutDetailList);
            if (financePaymentResult != null)
            {
                if (!string.IsNullOrWhiteSpace(this.lblcode.Text))
                {
                    MessageBox.Show("修改其它付款单数据成功", "其它付款单温馨提示");
                }
                else
                {
                    MessageBox.Show("新增其它付款单数据成功", "其它付款单温馨提示");
                    this.toolStripBtnHouDan.Enabled = false;
                }
                DataTable dt = new DataTable();
                dt = financeOtherExpensesoutinter.GetLastDetail(financeOtherExpensesOut.code);
                if (dt.Rows.Count == 0)
                {
                    toolStripBtnQianDan.Enabled = false; //上一单没有数据
                }
                this.lblcode.Text = financeOtherExpensesOut.code;
            }
        }

        /// <summary>
        /// 审核按钮的函数
        /// </summary>
        private void Review()
        {
            FinanceOtherExpensesOut financeOtherExpensesOut = new FinanceOtherExpensesOut();
            //其它收款单详细列表
            List<FinanceOtherExpensesOutDetail> financeOtherExpenseOutDetailList = new List<FinanceOtherExpensesOutDetail>();
            //非空验证
            if (string.IsNullOrWhiteSpace(lblcode.Text))
            {
                return;
            }
            try
            {
                //其它收款单
                financeOtherExpensesOut.code = this.lblcode.Text;   //单号
                financeOtherExpensesOut.salesMan = XYEEncoding.strCodeHex(ltxtbSalsMan.Text.Trim()); //经手人
                financeOtherExpensesOut.type = XYEEncoding.strCodeHex(comboBoxType.Text);//单据类型
                financeOtherExpensesOut.date = this.dateTimePicker1.Value;//开单日期
                financeOtherExpensesOut.clientCode = "";
                financeOtherExpensesOut.supplierCode = XYEEncoding.strCodeHex(_supplierCode);//供应商code
                financeOtherExpensesOut.accountCode = XYEEncoding.strCodeHex(_bankCode);//结算账户code
                financeOtherExpensesOut.settlementType = XYEEncoding.strCodeHex(comboBoxjiesuanfangshi.Text);//结算方式
                financeOtherExpensesOut.settlementNumber = XYEEncoding.strCodeHex(labtextboxTop6.Text.Trim());//结算号
                financeOtherExpensesOut.settlementMoney = Convert.ToDecimal(labtextboxTop3.Text);
                financeOtherExpensesOut.Abstract = XYEEncoding.strCodeHex(labtextboxBotton2.Text.Trim());//摘要
                financeOtherExpensesOut.salesCode = XYEEncoding.strCodeHex(_employeeCode);//经手人code
                financeOtherExpensesOut.operationMan = XYEEncoding.strCodeHex(ltxtbMakeMan.Text.Trim());//制单人
                financeOtherExpensesOut.checkMan = XYEEncoding.strCodeHex(ltxtbShengHeMan.Text.Trim());//审核人
                financeOtherExpensesOut.checkState = 1;//审核状态
                financeOtherExpensesOut.isClear = 1;
                financeOtherExpensesOut.updateDate = DateTime.Now;
                SupplierInterface supplierInterface = new SupplierInterface();
                financeOtherExpensesOut.supplierCode = supplierInterface.GetList(5, XYEEncoding.strCodeHex(labtextboxTop2.Text)).Rows[0]["code"].ToString();//供应商code
                BankAccountInterface bankAccountInterface = new BankAccountInterface();
                financeOtherExpensesOut.accountCode = bankAccountInterface.GetList(3, XYEEncoding.strCodeHex(labtextboxTop4.Text), false, false).Rows[0]["code"].ToString();//结算账户code
                EmpolyeeInterface empolyeeInterface = new EmpolyeeInterface();
                financeOtherExpensesOut.salesCode = empolyeeInterface.GetList(6, XYEEncoding.strCodeHex(ltxtbSalsMan.Text)).Rows[0]["code"].ToString();//经手人code
            }
            catch (Exception ex)
            {
                MessageBox.Show("错误代码:5203-尝试创建其它付款单数据出错!请检查:" + ex.Message, "其它付款单温馨提示");
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
                        if (i == (superGridControlShangPing.PrimaryGrid.Rows.Count - 1))
                        {
                            break;
                        }
                        FinanceOtherExpensesOutDetail financeOtherExpenseOutDetail = new FinanceOtherExpensesOutDetail();
                        if (gr["material"].Value.ToString() != "" || gr["material"].Value != null)
                        {
                            financeOtherExpenseOutDetail.material = XYEEncoding.strCodeHex(gr["material"].Value.ToString());//收入类别
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
                            financeOtherExpenseOutDetail.money = Convert.ToDecimal(gr["gridColumnMoney"].Value);//金额
                        }
                        if (!string.IsNullOrWhiteSpace(this.lblcode.Text))
                        {
                            financeOtherExpenseOutDetail.id = Convert.ToInt32(gr["gridColumnid"].Value);
                        }
                        financeOtherExpenseOutDetail.outCode = financeOtherExpensesOut.code;//主表code
                        financeOtherExpenseOutDetail.projectOutCode = XYEEncoding.strCodeHex(_financeOtherPaymentCode + i);//其它收款单详细code  
                        financeOtherExpenseOutDetail.remark = gr["gridColumnbeizhu"].Value == null ? "" : XYEEncoding.strCodeHex(gr["gridColumnbeizhu"].Value.ToString());//备注  
                        GridRow dr = superGridControlShangPing.PrimaryGrid.Rows[0] as GridRow;
                        financeOtherExpenseOutDetailList.Add(financeOtherExpenseOutDetail);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("错误代码:5205-尝试创建和审核其它付款单数据出错!请检查:" + ex.Message, "其它付款单温馨提示");
                return;
            }
            //增加一条其他收款单和其它收款单详细数据
            object financePaymentResult = financeOtherExpensesoutinter.AddOrUpdateToMainOrDetail(financeOtherExpensesOut, financeOtherExpenseOutDetailList);
            if (financePaymentResult != null)
            {

                pictureBoxshenghe.Parent = pictureBoxtitle;
                InitForm();
                MessageBox.Show("保存和审核其它付款单数据成功", "其它付款单温馨提示");
            }
        }

        /// <summary>
        /// 表格的第一个格子的点击事件
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
                        _AllProjectInCost = projectCostInterface.GetList(0, "" + typeDaima + "");
                        InitProjectCost();
                    }
                    else
                    {
                        //查询收入类别列表
                        _AllProjectInCost = projectCostInterface.GetList(999, "");
                        InitProjectCost();
                    }
                    dataGridViewShangPing.DataSource = ch.DataTableReCoding(_AllProjectInCost);
                    superGridControlShangPing.DefaultVisualStyles.CellStyles.Default.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleCenter;
                    //superGridControlShangPing.PrimaryGrid.SortCycle = SortCycle.AscDesc;    //排序方式范围
                    //superGridControlShangPing.PrimaryGrid.AddSort(superGridControlShangPing.PrimaryGrid.Columns[0], SortDirection.Ascending);//设置排序列和排序方式
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("错误代码：5217-第一个显示数据错误或数据加载错误！" + ex.Message, "其他付款单温馨提示:");
            }
        }

        /// <summary>
        /// 表格输入验证
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void superGridControlShangPing_CellValidated(object sender, GridCellValidatedEventArgs e)
        {
            try
            {
                GridRow gr = (GridRow)superGridControlShangPing.PrimaryGrid.Rows[ClickRowIndex];//获取选中行

                if (e.GridCell.GridColumn.Name == "gridColumnMoney")
                {
                    //逐行统计数据总数
                    decimal tempAllMoney = 0;
                    for (int i = 0; i < superGridControlShangPing.PrimaryGrid.Rows.Count - 1; i++)
                    {
                        GridRow tempGR = superGridControlShangPing.PrimaryGrid.Rows[i] as GridRow;
                        tempAllMoney += Convert.ToDecimal(tempGR["gridColumnMoney"].FormattedValue);
                    }
                    _Money = tempAllMoney;
                    GridRow grCount = (GridRow)superGridControlShangPing.PrimaryGrid.Rows[superGridControlShangPing.PrimaryGrid.Rows.Count - 1];
                    grCount["gridColumnMoney"].Value = _Money.ToString();
                }
                TongJi();
            }
            catch (Exception ex)
            {
                MessageBox.Show("错误代码：5211-验证表格里的金额以及统计金额出错！请检查：" + ex.Message, "其它付款单温馨提示！");
            }
        }

        /// <summary>
        /// 统计表格里的金额
        /// </summary>
        private void TongJi()
        {
            try
            {
                superGridControlShangPing.DefaultVisualStyles.CellStyles.Default.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleCenter;
                //superGridControlShangPing.PrimaryGrid.SortCycle = SortCycle.AscDesc;    //排序方式范围

                labtextboxTop3.Text = _Money.ToString("0.00");
                labtextboxTop5.Text = _Money.ToString("0.00");
                //superGridControlShangPing.PrimaryGrid.SortCycle = SortCycle.AscDesc;    //排序方式范围
                //superGridControlShangPing.PrimaryGrid.AddSort(superGridControlShangPing.PrimaryGrid.Columns[0], SortDirection.Ascending);//设置排序列和排序方式
            }
            catch (Exception ex)
            {
                MessageBox.Show("错误代码：5212-逐行统计数据总数数据错误！" + ex.Message, "其他付款单温馨提示:");
            }

        }

        /// <summary>
        /// 按ESC关闭小表格
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FinanceOtherPaymentForm_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Escape)
            {
                this.resizablePanel1.Visible = false;
                this.resizablePanelData.Visible = false;
            }
        }

        /// <summary>
        /// 验证单号是否重复
        /// </summary>
        private string YanZhengCode()
        {
            if (financeOtherExpensesoutinter.Exists(XYEEncoding.strCodeHex(_financeOtherPaymentCode)))
            {
                _financeOtherPaymentCode = BuildCode.ModuleCode("FOP");
            }
            else
            {
                _financeOtherPaymentCode = textBoxOddNumbers.Text;
            }
            return _financeOtherPaymentCode;
        }

        #region 模糊查询
        /// <summary>
        /// 供应商的模糊查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void labtextboxSupplier_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.labtextboxTop2.Text.Trim() == "")
                {
                    InitSupplier();
                    _Click = 4;
                    return;
                }
                dataGridViewFuJia.DataSource = null;
                dataGridViewFuJia.Columns.Clear();

                DataGridViewTextBoxColumn dgvc = new DataGridViewTextBoxColumn();
                dgvc.Name = "code";
                dgvc.HeaderText = "编码";
                dgvc.DataPropertyName = "code";
                dataGridViewFuJia.Columns.Add(dgvc);

                dgvc = new DataGridViewTextBoxColumn();
                dgvc.Name = "name";
                dgvc.HeaderText = "单位名称";
                dgvc.DataPropertyName = "name";
                dataGridViewFuJia.Columns.Add(dgvc);

                dgvc = new DataGridViewTextBoxColumn();
                dgvc.Name = "mobilePhone";
                dgvc.HeaderText = "联系手机";
                dgvc.DataPropertyName = "mobilePhone";
                dgvc.Visible = false;
                dataGridViewFuJia.Columns.Add(dgvc);

                dgvc = new DataGridViewTextBoxColumn();
                dgvc.Name = "linkMan";
                dgvc.HeaderText = "联系人";
                dgvc.DataPropertyName = "linkMan";
                dgvc.Visible = false;
                dataGridViewFuJia.Columns.Add(dgvc);

                dgvc = new DataGridViewTextBoxColumn();
                dgvc.Name = "fax";
                dgvc.HeaderText = "传真";
                dgvc.DataPropertyName = "fax";
                dgvc.Visible = false;
                dataGridViewFuJia.Columns.Add(dgvc);

                resizablePanel1.Location = new Point(230, 160);
                string name = XYEEncoding.strCodeHex(this.labtextboxTop2.Text.Trim());
                dataGridViewFuJia.DataSource = ch.DataTableReCoding(supplier.GetList(0, name));
                resizablePanel1.Visible = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("错误代码：5214-模糊查询供应商数据错误" + ex.Message, "其他付款单温馨提示");
            }
        }


        /// <summary>
        /// 银行账户的模糊查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void labtextboxBank_TextChanged(object sender, EventArgs e)
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
                MessageBox.Show("错误代码：5215-模糊查询结算账户数据错误" + ex.Message, "其它收付款单温馨提示");
            }
        }

        /// <summary>
        /// 经手人的模糊查询
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
                MessageBox.Show("错误代码：5216-模糊查询收款员数据失败！" + ex.Message, "其他付款单温馨提示:");
            }
        }

        #endregion

        /// <summary>
        /// supergrid数据填充
        /// </summary>
        /// <param name="dt"></param>
        public void InitSupergridView(DataTable dt)
        {
            //清空行
            superGridControlShangPing.PrimaryGrid.Rows.Clear();
            //新增统计行
            InitDataGridView();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (i > 0)
                {
                    //新增行
                    superGridControlShangPing.PrimaryGrid.NewRow(superGridControlShangPing.PrimaryGrid.Rows.Count);
                }
                GridRow gr = (GridRow)superGridControlShangPing.PrimaryGrid.Rows[i];   //获取
                gr["gridColumnMoney"].Value = dt.Rows[i]["money"].ToString();
                gr["gridColumnbeizhu"].Value = XYEEncoding.strHexDecode(dt.Rows[i]["remark"].ToString());
                gr["gridColumnid"].Value = dt.Rows[i]["id1"].ToString();
                gr["material"].Value = XYEEncoding.strHexDecode(dt.Rows[i]["material"].ToString());
                _Money += decimal.Parse(dt.Rows[i]["money"].ToString());
            }
            GridRow gr1 = (GridRow)superGridControlShangPing.PrimaryGrid.Rows[ClickRowIndex];
            gr1 = (GridRow)superGridControlShangPing.PrimaryGrid.LastSelectableRow;
            gr1["gridColumnMoney"].Value = _Money.ToString();
            labtextboxTop3.Text = _Money.ToString("0.00");
            labtextboxTop5.Text = _Money.ToString("0.00");
            superGridControlShangPing.PrimaryGrid.NewRow(superGridControlShangPing.PrimaryGrid.Rows.Count);
        }

        /// <summary>
        /// 下单
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToolStripBtnHouDan_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            try
            {
                code = this.lblcode.Text;
                dt = financeOtherExpensesoutinter.GetNextDetail(code);
                SupplierInterface supplierInterface = new SupplierInterface();
                string suppliercode = dt.Rows[0]["supplierCode"].ToString();
                string supplierName = supplierInterface.GetList(4, suppliercode).Rows[0]["name"].ToString(); //单位名称
                BankAccountInterface bankAccountInterface = new BankAccountInterface();
                string openBank = bankAccountInterface.GetList(0, dt.Rows[0]["accountCode"].ToString(), false, false).Rows[0]["openBank"].ToString(); //银行名称
                //文本框赋值
                this.comboBoxType.Text = XYEEncoding.strHexDecode(dt.Rows[0]["type"].ToString());   //单据类型
                this.labtextboxTop2.Text = XYEEncoding.strHexDecode(supplierName);  //供应商
                this.labtextboxTop5.Text = dt.Rows[0]["settlementMoney"].ToString();  //应结算金额
                this.labtextboxTop3.Text = dt.Rows[0]["settlementMoney"].ToString();  //已结算金额
                this.labtextboxTop4.Text = XYEEncoding.strHexDecode(openBank);  //开户银行
                this.comboBoxjiesuanfangshi.Text = XYEEncoding.strHexDecode(dt.Rows[0]["settlementType"].ToString());  //结算方式
                this.labtextboxTop6.Text = XYEEncoding.strHexDecode(dt.Rows[0]["settlementNumber"].ToString());  //结算号
                this.labtextboxBotton2.Text = XYEEncoding.strHexDecode(dt.Rows[0]["Abstract"].ToString());  //摘要
                this.ltxtbSalsMan.Text = XYEEncoding.strHexDecode(dt.Rows[0]["salesMan"].ToString());  //业务员
                this.ltxtbMakeMan.Text = XYEEncoding.strHexDecode(dt.Rows[0]["operationMan"].ToString());  //制单人
                this.ltxtbShengHeMan.Text = XYEEncoding.strHexDecode(dt.Rows[0]["checkMan"].ToString());  //制单人
                this.lblcode.Text = dt.Rows[0]["code"].ToString();
                this.lblCheckState.Text = dt.Rows[0]["checkState"].ToString(); //审核
                //判断审核
                if (this.lblCheckState.Text == "1")
                {
                    pictureBoxshenghe.Parent = pictureBoxtitle;
                    InitForm();  //标记控件不可用
                    toolStripBtnShengHe.Enabled = false;
                }
                else
                {
                    EnabledForm(); //标记控件可用
                    toolStripBtnShengHe.Enabled = true;
                }
                resizablePanel1.Visible = false;
                InitSupergridView(dt);
                //判断是否到上限
                string lcode = dt.Rows[0]["code"].ToString();
                dt = financeOtherExpensesoutinter.GetNextDetail(lcode);
                toolStripBtnQianDan.Enabled = true;
                if (dt.Rows.Count == 0)
                {
                    toolStripBtnHouDan.Enabled = false; //上一单没有数据
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("错误代码：2106-尝试点击后单数据错误" + ex.Message, "财务凭证条目单温馨提示");
            }
        }

        /// <summary>
        /// 上单
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToolStripBtnQianDan_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            try
            {
                //判断是否code是否存在
                if (string.IsNullOrWhiteSpace(this.lblcode.Text))
                {
                    code = financeOtherExpensesoutinter.GetNewCode();
                    dt = financeOtherExpensesoutinter.GetFLastDetail(code);
                }
                else
                {
                    code = this.lblcode.Text;
                    dt = financeOtherExpensesoutinter.GetLastDetail(code);
                    toolStripBtnHouDan.Enabled = true;
                }

                SupplierInterface supplierInterface = new SupplierInterface();
                string suppliercode = dt.Rows[0]["supplierCode"].ToString();

                string supplierName = supplierInterface.GetList(4, suppliercode).Rows[0]["name"].ToString(); //单位名称
                BankAccountInterface bankAccountInterface = new BankAccountInterface();
                string openBank = bankAccountInterface.GetList(0, dt.Rows[0]["accountCode"].ToString(), false, false).Rows[0]["openBank"].ToString(); //银行名称
                //文本框赋值
                this.comboBoxType.Text = XYEEncoding.strHexDecode(dt.Rows[0]["type"].ToString());   //单据类型
                this.labtextboxTop2.Text = XYEEncoding.strHexDecode(supplierName);  //供应商
                this.labtextboxTop5.Text = dt.Rows[0]["settlementMoney"].ToString();  //应结算金额
                this.labtextboxTop3.Text = dt.Rows[0]["settlementMoney"].ToString();  //已结算金额
                this.labtextboxTop4.Text = XYEEncoding.strHexDecode(openBank);  //开户银行
                this.comboBoxjiesuanfangshi.Text = XYEEncoding.strHexDecode(dt.Rows[0]["settlementType"].ToString());  //结算方式
                this.labtextboxTop6.Text = XYEEncoding.strHexDecode(dt.Rows[0]["settlementNumber"].ToString());  //结算号
                this.labtextboxBotton2.Text = XYEEncoding.strHexDecode(dt.Rows[0]["Abstract"].ToString());  //摘要
                this.ltxtbSalsMan.Text = XYEEncoding.strHexDecode(dt.Rows[0]["salesMan"].ToString());  //业务员
                this.ltxtbMakeMan.Text = XYEEncoding.strHexDecode(dt.Rows[0]["operationMan"].ToString());  //制单人
                this.ltxtbShengHeMan.Text = XYEEncoding.strHexDecode(dt.Rows[0]["checkMan"].ToString());  //制单人
                this.lblcode.Text = dt.Rows[0]["code"].ToString();
                this.lblCheckState.Text = dt.Rows[0]["checkState"].ToString(); //审核

                //判断审核
                if (this.lblCheckState.Text == "1")
                {
                    pictureBoxshenghe.Parent = pictureBoxtitle;
                    InitForm();  //标记控件不可用
                    toolStripBtnShengHe.Enabled = false;

                }
                else
                {
                    EnabledForm(); //标记控件可用
                    toolStripBtnShengHe.Enabled = true;
                }
                resizablePanel1.Visible = false;
                InitSupergridView(dt);
                //判断是否到上限
                string lcode = dt.Rows[0]["code"].ToString();
                dt = financeOtherExpensesoutinter.GetLastDetail(lcode);
                if (dt.Rows.Count == 0)
                {
                    toolStripBtnQianDan.Enabled = false; //上一单没有数据
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("错误代码：2106-尝试点击前单数据错误" + ex.Message, "财务凭证条目单温馨提示");
            }
        }
    }
}