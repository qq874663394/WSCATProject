using HelperUtility;
using HelperUtility.Encrypt;
using InterfaceLayer.Base;
using InterfaceLayer.Finance;
using Model.Finance;
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
    public partial class FinanceBankAccessForm : TestForm
    {
        public FinanceBankAccessForm()
        {
            InitializeComponent();
        }

        #region 实例化接口层
        CodingHelper ch = new CodingHelper();
        BankAccountInterface bank = new BankAccountInterface();//结算账户
        EmpolyeeInterface employee = new EmpolyeeInterface();//员工  
        FinanceBankAccessInterface finaceBankAccessInterface = new FinanceBankAccessInterface();
        #endregion

        #region 数据字段
        /// <summary>
        /// 银行存取code
        /// </summary>
        private string _financeBankAccessCode;
        /// <summary>
        /// 所以经手人
        /// </summary>
        private DataTable _AllEmployee = null;

        /// <summary>
        /// 所有账户
        /// </summary>
        private DataTable _AllBank = null;

        /// <summary>
        /// 保存经手人Code
        /// </summary>
        private string _employeeCode;

        /// <summary>
        /// 付款账号code
        /// </summary>
        private string _fuBankCode;

        /// <summary>
        /// 收款的账号code
        /// </summary>
        private string _shouBankCode;

        /// <summary>
        /// 点击的项,1供应商  2为采购员  3为仓库   
        /// </summary>
        private int _Click = 0;
        #endregion

        #region 初始化数据
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
                MessageBox.Show("错误代码：5401-尝试点击经手人数据出错或者无数据！请检查：" + ex.Message, "其他付款单温馨提示！");
            }
        }

        /// <summary>
        /// 初始化收款账户
        /// </summary>
        private void InitInBank()
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

                    resizablePanel1.Location = new Point(250, 150);
                    dataGridViewFuJia.DataSource = ch.DataTableReCoding(_AllBank);
                    resizablePanel1.Visible = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("错误代码：5402-尝试点击结算账户，数据显示失败或者无数据！请检查：" + ex.Message, "其他付款单温馨提示！");
            }
        }

        /// <summary>
        /// 初始化付款账户
        /// </summary>
        private void InitOutBank()
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

                    resizablePanel1.Location = new Point(570, 150);
                    dataGridViewFuJia.DataSource = ch.DataTableReCoding(_AllBank);
                    resizablePanel1.Visible = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("错误代码：5403-尝试点击结算账户，数据显示失败或者无数据！请检查：" + ex.Message, "其他付款单温馨提示！");
            }
        }

        /// <summary>
        /// 非空验证
        /// </summary>
        private bool isNUllValidate()
        {
            if (labtxtDanJuType.Text == null || labtxtDanJuType.Text.Trim() == "")
            {
                MessageBox.Show("付款账号不能为空！");
                labtxtDanJuType.Focus();
                return false;
            }
            if (labtextboxTop2.Text == null || labtextboxTop2.Text.Trim() == "")
            {
                MessageBox.Show("收款账号不能为空！");
                labtextboxTop2.Focus();
                return false;
            }
            double money = Convert.ToDouble(labtextboxTop5.Text.Trim());
            if (money < 0.00)
            {
                MessageBox.Show("金额必须大于0！");
                labtextboxTop5.Focus();
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
                    case "dateTimePicker":
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
            pictureBoxShengHe.Visible = true;
            toolStripBtnSave.Enabled = false;
            toolStripBtnShengHe.Enabled = false;
            panel2.Enabled = false;
            panel5.Enabled = false;
        }
        #endregion

        private void FinanceBankAccessForm_Load(object sender, EventArgs e)
        {
            try
            {
                //经手人
                _AllEmployee = employee.SelSupplierTable(false);
                //结算账户
                _AllBank = bank.GetList(999, "", false, false);

                pictureBoxShengHe.Parent = pictureBoxtitle;
                dataGridViewFuJia.AutoGenerateColumns = false;
                dataGridViewFuJia.CellDoubleClick += dataGridViewFuJia_CellDoubleClick;
                dataGridViewFuJia.KeyDown += DataGridViewFuJia_KeyDown;

                _financeBankAccessCode = BuildCode.ModuleCode("FBA");
                textBoxOddNumbers.Text = _financeBankAccessCode;
                barcodeXYE.Code128 _Code = new barcodeXYE.Code128();
                _Code.ValueFont = new Font("微软雅黑", 20);
                System.Drawing.Bitmap imgTemp = _Code.GetCodeImage(textBoxOddNumbers.Text, barcodeXYE.Code128.Encode.Code128A);
                pictureBoxtiaoxingma.Image = imgTemp;

                toolStripBtnSave.Click += toolStripBtnSave_Click;//保存按钮
                toolStripBtnShengHe.Click += toolStripBtnShengHe_Click;//审核按钮

            }
            catch (Exception ex)
            {
                MessageBox.Show("错误代码：5404-窗体加载时，初始化数据错误！请检查：" + ex.Message, "银行存取款单温馨提示！");
            }
        }

        /// <summary>
        /// 小表格按回车键事件
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
        /// 关标定位
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FinanceBankAccessForm_Activated(object sender, EventArgs e)
        {
            labtxtDanJuType.Focus();
        }

        #region 小箭头事件和点击事件

        /// <summary>
        /// 付款账户的小箭头点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pictureBoxDanJuType_Click(object sender, EventArgs e)
        {
            if (_Click != 2)
            {
                InitInBank();
                dataGridViewFuJia.Focus();
            }
            _Click = 5;
        }

        /// <summary>
        /// 收款账号的小箭头点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if (_Click != 1)
            {
                InitOutBank();
                dataGridViewFuJia.Focus();
            }
            _Click = 4;
        }

        /// <summary>
        /// 经手人的小箭头的点击事件
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
        /// 小表格的点击事件
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
        /// 绑定控件的函数
        /// </summary>
        private void dataGridViewFuJiTableClick()
        {
            try
            {
                //付款账户
                if (_Click == 2 || _Click == 5)
                {
                    if (dataGridViewFuJia.Columns["code"] ==null)
                    {
                        return;
                    }
                    _fuBankCode = dataGridViewFuJia.Rows[dataGridViewFuJia.CurrentRow.Index].Cells["code"].Value.ToString();//供应商code
                    if (dataGridViewFuJia.Columns["openBank"]==null)
                    {
                        return;
                    }
                    string name = dataGridViewFuJia.Rows[dataGridViewFuJia.CurrentRow.Index].Cells["openBank"].Value.ToString();//供应商名称

                    labtxtDanJuType.Text = name;
                    resizablePanel1.Visible = false;
                }
                //收款账号
                if (_Click == 1 || _Click == 4)
                {
                    _shouBankCode = dataGridViewFuJia.Rows[dataGridViewFuJia.CurrentRow.Index].Cells["code"].Value.ToString();//银行账户code
                    string name = dataGridViewFuJia.Rows[dataGridViewFuJia.CurrentRow.Index].Cells["openBank"].Value.ToString();//账户名称
                    labtextboxTop2.Text = name;
                    resizablePanel1.Visible = false;
                }
                //经手人
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
                MessageBox.Show("错误代码：5405-双击绑定付款账户、收款账户、经手人数据错误！请检查：" + ex.Message, "其他付款单温馨提示！");
            }
        }
        #endregion

        #region 模糊查询

        /// <summary>
        /// 付款账号的模糊查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void labtxtDanJuType_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.labtxtDanJuType.Text.Trim() == "")
                {
                    InitInBank();
                    dataGridViewFuJia.Focus();
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

                resizablePanel1.Location = new Point(250, 150);
                string name = XYEEncoding.strCodeHex(this.labtxtDanJuType.Text.Trim());
                dataGridViewFuJia.DataSource = ch.DataTableReCoding(bank.GetList(1, name, false, false));
                resizablePanel1.Visible = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("错误代码：5406-模糊查询付款账户数据错误" + ex.Message, "其它收付款单温馨提示");
            }
        }

        /// <summary>
        /// 收款账号的模糊查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void labtextboxTopBank_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.labtextboxTop2.Text.Trim() == "")
                {
                    InitOutBank();
                    dataGridViewFuJia.Focus();
                    _Click = 4;
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

                resizablePanel1.Location = new Point(570, 150);
                string name = XYEEncoding.strCodeHex(this.labtextboxTop2.Text.Trim());
                dataGridViewFuJia.DataSource = ch.DataTableReCoding(bank.GetList(1, name, false, false));
                resizablePanel1.Visible = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("错误代码：5407-模糊查询收款账户数据错误" + ex.Message, "其它收付款单温馨提示");
            }
        }

        /// <summary>
        /// 经手人模糊查询
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
                    dataGridViewFuJia.Focus();
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
                MessageBox.Show("错误代码：5408-模糊查询经手人数据失败！" + ex.Message, "其他付款单温馨提示:");
            }
        }
        #endregion

        /// <summary>
        /// 快捷键设置
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FinanceBankAccessForm_KeyDown(object sender, KeyEventArgs e)
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
        /// 保存事件函数
        /// </summary>
        private void Save()
        {
            if (isNUllValidate() == false)
            {
                return;
            }
            FinanceBankAccess financeBankAccess = new FinanceBankAccess();
            try
            {
                financeBankAccess.code = XYEEncoding.strCodeHex(textBoxOddNumbers.Text);//单号
                financeBankAccess.date = this.dateTimePicker1.Value;
                if (labtxtDanJuType.Text != null || labtxtDanJuType.Text != "")
                {
                    financeBankAccess.paymentAccount = XYEEncoding.strCodeHex(labtxtDanJuType.Text);
                }
                else
                {
                    MessageBox.Show("付款账户不能为空！");
                    labtxtDanJuType.Focus();
                    return;
                }
                if (labtextboxTop2.Text != null || labtextboxTop2.Text != "")
                {
                    financeBankAccess.receiptAccount = XYEEncoding.strCodeHex(labtextboxTop2.Text);
                }
                else
                {
                    MessageBox.Show("收款账户不能为空！");
                    labtextboxTop2.Focus();
                    return;
                }
                double Money = Convert.ToDouble(labtextboxTop5.Text.Trim());
                if (Money > 0.00)
                {
                    financeBankAccess.amount = Convert.ToDecimal(Money);
                }
                else
                {
                    MessageBox.Show("金额不能小于0！");
                    labtextboxTop5.Focus();
                    return;
                }
                if (ltxtbSalsMan.Text != null || ltxtbSalsMan.Text.Trim() != "")
                {
                    financeBankAccess.handled = XYEEncoding.strCodeHex(ltxtbSalsMan.Text);
                }
                else
                {
                    MessageBox.Show("经手人不能为空！");
                    ltxtbSalsMan.Focus();
                    return;
                }
                financeBankAccess.summary = XYEEncoding.strCodeHex(labtextboxBotton2.Text == null ? "" : labtextboxBotton2.Text);//摘要
                financeBankAccess.operators = XYEEncoding.strCodeHex(ltxtbMakeMan.Text == null ? "" : ltxtbMakeMan.Text);//制单人
                financeBankAccess.auditors = XYEEncoding.strCodeHex(ltxtbShengHeMan.Text == null ? "" : ltxtbShengHeMan.Text);//审核人
                financeBankAccess.departmentCode = "";
                financeBankAccess.checkState = 0;//审核状态
            }
            catch (Exception ex)
            {
                MessageBox.Show("错误代码:5409-尝试创建银行存取款单数据出错!请检查:" + ex.Message, "银行存取款单温馨提示");
                return;
            }

            object financeBankAccessResult = finaceBankAccessInterface.AddOrUpdate(financeBankAccess);
            if (financeBankAccessResult != null)
            {
                MessageBox.Show("创建银行存取款单成功！");
            }

        }

        /// <summary>
        /// 审核事件函数
        /// </summary>
        private void Review()
        {
            if (isNUllValidate() == false)
            {
                return;
            }
            FinanceBankAccess financeBankAccess = new FinanceBankAccess();
            try
            {
                financeBankAccess.code = XYEEncoding.strCodeHex(textBoxOddNumbers.Text);//单号
                financeBankAccess.date = this.dateTimePicker1.Value;
                if (labtxtDanJuType.Text != null || labtxtDanJuType.Text != "")
                {
                    financeBankAccess.paymentAccount = XYEEncoding.strCodeHex(labtxtDanJuType.Text);
                }
                else
                {
                    MessageBox.Show("付款账户不能为空！");
                    labtxtDanJuType.Focus();
                    return;
                }
                if (labtextboxTop2.Text != null || labtextboxTop2.Text != "")
                {
                    financeBankAccess.receiptAccount = XYEEncoding.strCodeHex(labtextboxTop2.Text);
                }
                else
                {
                    MessageBox.Show("收款账户不能为空！");
                    labtextboxTop2.Focus();
                    return;
                }
                double Money = Convert.ToDouble(labtextboxTop5.Text.Trim());
                if (Money > 0.00)
                {
                    financeBankAccess.amount = Convert.ToDecimal(Money);
                }
                else
                {
                    MessageBox.Show("金额不能小于0！");
                    labtextboxTop5.Focus();
                    return;
                }
                if (ltxtbSalsMan.Text != null || ltxtbSalsMan.Text.Trim() != "")
                {
                    financeBankAccess.handled = XYEEncoding.strCodeHex(ltxtbSalsMan.Text);
                }
                else
                {
                    MessageBox.Show("经手人不能为空！");
                    ltxtbSalsMan.Focus();
                    return;
                }
                financeBankAccess.summary = XYEEncoding.strCodeHex(labtextboxBotton2.Text == null ? "" : labtextboxBotton2.Text);//摘要
                financeBankAccess.operators = XYEEncoding.strCodeHex(ltxtbMakeMan.Text == null ? "" : ltxtbMakeMan.Text);//制单人
                financeBankAccess.auditors = XYEEncoding.strCodeHex(ltxtbShengHeMan.Text == null ? "" : ltxtbShengHeMan.Text);//审核人
                financeBankAccess.departmentCode = "";
                financeBankAccess.checkState = 1;//审核状态
            }
            catch (Exception ex)
            {
                MessageBox.Show("错误代码:5410-尝试创建并审核银行存取款单数据出错!请检查:" + ex.Message, "银行存取款单温馨提示");
                return;
            }

            object financeBankAccessResult = finaceBankAccessInterface.AddOrUpdate(financeBankAccess);
            if (financeBankAccessResult != null)
            {
                MessageBox.Show("创建并审核银行存取款单成功！");
            }
        }

        /// <summary>
        /// 保存按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripBtnSave_Click(object sender, EventArgs e)
        {
            Save();
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
                InitForm();
            }
        }

        /// <summary>
        /// 验证金额
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtMoney_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                //小数点的处理。
                if ((int)e.KeyChar == 46)//小数点
                {
                    if (labtextboxTop5.Text.Length <= 0)
                        e.Handled = true;   //小数点不能在第一位
                    else
                    {
                        float f;
                        float oldf;
                        bool b1 = false, b2 = false;
                        b1 = float.TryParse(labtextboxTop5.Text, out oldf);
                        b2 = float.TryParse(labtextboxTop5.Text + e.KeyChar.ToString(), out f);
                        if (b2 == false)
                        {
                            if (b1 == true)
                                e.Handled = true;
                            else
                                e.Handled = false;
                        }
                    }

                }
                if (!(((e.KeyChar >= '0') && (e.KeyChar <= '9')) || e.KeyChar <= 31))
                {
                    if (e.KeyChar == '.')
                    {
                        if (((TextBox)sender).Text.Trim().IndexOf('.') > -1)
                            e.Handled = true;
                    }
                    else
                        e.Handled = true;
                }
                else
                {
                    if (e.KeyChar <= 31)
                    {
                        e.Handled = false;
                    }
                    else if (((TextBox)sender).Text.Trim().IndexOf('.') > -1)
                    {
                        if (((TextBox)sender).Text.Trim().Substring(((TextBox)sender).Text.Trim().IndexOf('.') + 1).Length >= 2)
                            e.Handled = true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("错误代码：5411-金额的值为非法字符，请重新输入:" + ex.Message, "银行收取款单温馨提示！");
            }
        }

        /// <summary>
        /// 本次核销金额
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtMoney_Validated(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(labtextboxTop5.Text))
                return;
            double d = Convert.ToDouble(labtextboxTop5.Text);
            labtextboxTop5.Text = d.ToString("0.00");
            //// 确保输入光标在最右侧
            labtextboxTop5.Select(labtextboxTop5.Text.Length, 0);
        }

        private void txtMoney_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ltxtbSalsMan.Focus();
            }
        }
    }
}
