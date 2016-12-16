using DevComponents.DotNetBar.Controls;
using DevComponents.DotNetBar.SuperGrid;
using HelperUtility;
using HelperUtility.Encrypt;
using InterfaceLayer.Base;
using InterfaceLayer.Finance;
using InterfaceLayer.Sales;
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

namespace WSCATProject.Sales
{
    public partial class SalesReceivablesForm : TestForm
    {
        public SalesReceivablesForm()
        {
            InitializeComponent();
        }

        #region 调用接口以及加密解密方法
        CodingHelper ch = new CodingHelper();
        ClientInterface client = new ClientInterface();//客户
        BankAccountInterface bank = new BankAccountInterface();//结算账户
        EmpolyeeInterface employee = new EmpolyeeInterface();//员工
        FinanceCollectionInterface financeCollectionInterface = new FinanceCollectionInterface();
        string code;
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
        /// 所有收款员
        /// </summary>
        private DataTable _AllEmployee = null;
        /// <summary>
        /// 点击的项,1客户  2为结算账户  3为收款员
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
        /// 保存收款员Code
        /// </summary>
        private string _employeeCode;
        /// <summary>
        /// 所有商品列表
        /// </summary>
        private DataTable _AllMaterial = null;
        /// <summary>
        /// 商品code
        /// </summary>
        private string _materialCode;
        /// <summary>
        /// 收款单单code
        /// </summary>
        private string _SaleReceivablesCode;
        /// <summary>
        /// 统计单据金额
        /// </summary>
        private decimal _danJuMoney;
        /// <summary>
        /// 统计已核销金额
        /// </summary>
        private decimal _yiHeXiaoMoney;
        /// <summary>
        /// 统计未核销金额
        /// </summary>
        private decimal _weiHeXiaoMoney;
        /// <summary>
        /// 统计本次核销金额
        /// </summary>
        private decimal _benCiHeXiaoMoney;
        /// <summary>
        /// 统计剩余尾款
        /// </summary>
        private decimal _shengYuMoney;
        List<string> _salesMainList = new List<string>();
        /// <summary>
        /// 销售单code
        /// </summary>
        private string _salesMainCode;
        public string SalesMainCode
        {
            get { return _salesMainCode; }
            set { _salesMainCode = value; }
        }

        public List<string> SalesMainList
        {
            get { return _salesMainList; }
            set { _salesMainList = value; }
        }
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
            gr.Cells["danjuDate"].Value = "合计";
            gr.Cells["yuandanCode"].CellStyles.Default.Alignment =
                DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleCenter;
            gr.Cells["danjuMoney"].Value = 0;
            gr.Cells["danjuMoney"].CellStyles.Default.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleCenter;
            gr.Cells["danjuMoney"].CellStyles.Default.Background.Color1 = Color.Orange;
            gr.Cells["YiHeXiaoMoney"].Value = 0;
            gr.Cells["YiHeXiaoMoney"].CellStyles.Default.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleCenter;
            gr.Cells["YiHeXiaoMoney"].CellStyles.Default.Background.Color1 = Color.Orange;
            gr.Cells["WeiHeXiaoMoney"].Value = 0;
            gr.Cells["WeiHeXiaoMoney"].CellStyles.Default.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleCenter;
            gr.Cells["WeiHeXiaoMoney"].CellStyles.Default.Background.Color1 = Color.Orange;
            gr.Cells["BenCiHeXiao"].Value = 0;
            gr.Cells["BenCiHeXiao"].CellStyles.Default.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleCenter;
            gr.Cells["BenCiHeXiao"].CellStyles.Default.Background.Color1 = Color.Orange;
            gr.Cells["WeuFuMoney"].Value = 0;
            gr.Cells["WeuFuMoney"].CellStyles.Default.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleCenter;
            gr.Cells["WeuFuMoney"].CellStyles.Default.Background.Color1 = Color.Orange;
            #region 表格最后一行不能点击
            gr.Cells["yuandanCode"].AllowSelection = false;
            gr.Cells["danjuDate"].AllowSelection = false;
            gr.Cells["yuandanType"].AllowSelection = false;
            gr.Cells["danjuMoney"].AllowSelection = false;
            gr.Cells["YiHeXiaoMoney"].AllowSelection = false;
            gr.Cells["WeiHeXiaoMoney"].AllowSelection = false;
            gr.Cells["BenCiHeXiao"].AllowSelection = false;
            gr.Cells["WeuFuMoney"].AllowSelection = false;
            gr.Cells["remark"].AllowSelection = false;
            #endregion
        }

        /// <summary>
        /// 非空验证
        /// </summary>
        private bool isNUllValidate()
        {
            if (txtClient.Text.Trim() == null || txtClient.Text == "")
            {
                MessageBox.Show("客户不能为空！");
                txtClient.Focus();
                return false;
            }
            if (txtBank.Text.Trim() == null || txtBank.Text == "")
            {
                MessageBox.Show("结算账户不能为空！");
                txtBank.Focus();
                return false;
            }
            GridRow gr = (GridRow)superGridControlShangPing.PrimaryGrid.Rows[1];
            double benci = Convert.ToDouble(gr.Cells["BenCiHeXiao"].Value);
            if (gr.Cells["yuandanCode"].Value == null || gr.Cells["yuandanCode"].Value.ToString() == "")
            {
                MessageBox.Show("表格里源单编号不能为空！");
                superGridControlShangPing.Focus();
                return false;
            }
            if (benci == 0.00)
            {
                MessageBox.Show("本次核销不应该是等于零的数据！请检查：");
                superGridControlShangPing.Focus();
                return false;
            }
            if (ltxtbSalsMan.Text.Trim() == null || ltxtbSalsMan.Text == "")
            {
                MessageBox.Show("收款员不能为空！");
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

                    resizablePanel1.Location = new Point(500, 160);
                    dataGridViewFuJia.DataSource = ch.DataTableReCoding(_AllClient);
                    resizablePanel1.Visible = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("错误代码：1506-尝试点击客户，数据显示失败或者无数据！请检查：" + ex.Message, "收款单温馨提示！");
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

                    resizablePanel1.Location = new Point(500, 200);
                    dataGridViewFuJia.DataSource = ch.DataTableReCoding(_AllBank);
                    resizablePanel1.Visible = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("错误代码：1507-尝试点击结算账户，数据显示失败或者无数据！请检查：" + ex.Message, "收款单温馨提示！");
            }
        }

        /// <summary>
        /// 初始化收款员
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
                MessageBox.Show("错误代码：1508-尝试点击收款员，数据显示失败或者无数据！请检查：" + ex.Message, "收款单温馨提示！");
            }
        }
        /// <summary>
        /// 标示那个控件不可用
        /// </summary>
        private void InitForm()
        {
            foreach (Control c in panel2.Controls)
            {
                switch (c.GetType().Name)
                {
                    case "Label":
                        c.Enabled = false;
                        break;
                    case "TextBoxX":
                        c.Enabled = false;
                        break;
                    case "ComboBoxEx":
                        c.Enabled = false;
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
                        break;
                    case "TextBoxX":
                        c.Enabled = false;
                        break;
                    case "PictureBox":
                        c.Enabled = false;
                        break;
                }
            }
            superGridControlShangPing.PrimaryGrid.ReadOnly = true;
            pictureBoxShengHe.Visible = true;
            toolStripBtnSave.Enabled = false;
        }

        /// <summary>
        /// 标示那个控件可用
        /// </summary>
        private void EnabledForm()
        {
            foreach (Control c in panel2.Controls)
            {
                switch (c.GetType().Name)
                {
                    case "Label":
                        c.Enabled = true;
                        break;
                    case "TextBoxX":
                        c.Enabled = true;
                        break;
                    case "ComboBoxEx":
                        c.Enabled = true;
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
                        break;
                    case "TextBoxX":
                        c.Enabled = true;
                        break;
                    case "PictureBox":
                        c.Enabled = true;
                        break;
                }
            }
            superGridControlShangPing.PrimaryGrid.ReadOnly = false;
            pictureBoxShengHe.Visible = false;
            this.toolStripBtnShengHe.Enabled = true;
            toolStripBtnSave.Enabled = true;
        }

        #endregion

        private void SalesReceivablesForm_Load(object sender, EventArgs e)
        {
            try
            {
                #region 初始化窗体
                pictureBoxShengHe.Parent = pictureBoxtitle;
                cboDanJuType.SelectedIndex = 0;
                cboJieSuanMethod.SelectedIndex = 0;
                toolStripButtonXuanYuanDan.Visible = true;
                txtDiscount.Text = "100.00";
                txtBenCiHeXiao.Text = "0.00";
                txtBenCiShouKuan.Text = "0.00";
                //禁用自动创建列
                dataGridViewShangPing.AutoGenerateColumns = false;
                dataGridViewFuJia.AutoGenerateColumns = false;
                superGridControlShangPing.HScrollBarVisible = true;
                // 将dataGridView中的内容居中显示
                dataGridViewFuJia.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                //显示行号
                superGridControlShangPing.PrimaryGrid.ShowRowGridIndex = true;
                //内容居中
                superGridControlShangPing.DefaultVisualStyles.CellStyles.Default.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleCenter;
                //调用合计行数据
                InitDataGridView();
                #endregion

                //客户
                _AllClient = client.GetClientByBool(false);
                //结算账户
                _AllBank = bank.GetList(999, "", false, false);
                //收款员
                _AllEmployee = employee.SelSupplierTable(false);

                //生成销售订单code和显示条形码
                _SaleReceivablesCode = BuildCode.ModuleCode("SRS");
                textBoxOddNumbers.Text = _SaleReceivablesCode;
                barcodeXYE.Code128 _Code = new barcodeXYE.Code128();
                _Code.ValueFont = new Font("微软雅黑", 20);
                System.Drawing.Bitmap imgTemp = _Code.GetCodeImage(textBoxOddNumbers.Text, barcodeXYE.Code128.Encode.Code128A);
                pictureBoxBarCode.Image = imgTemp;

                //绑定事件 双击事填充内容并隐藏列表
                dataGridViewFuJia.CellDoubleClick += dataGridViewFuJia_CellDoubleClick;
                toolStripBtnSave.Click += toolStripBtnSave_Click;//保存按钮
                toolStripBtnShengHe.Click += toolStripBtnShengHe_Click;//审核按钮 
                toolStripButtonXuanYuanDan.Click += ToolStripButtonXuanYuanDan_Click;//选源单的点击事件
                dataGridViewFuJia.KeyDown += DataGridViewFuJia_KeyDown;
                toolStripBtnHouDan.Click += ToolStripBtnHouDan_Click;
                toolStripBtnQianDan.Click += ToolStripBtnQianDan_Click;
                toolStripBtnHouDan.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("错误代码：1501-窗体加载时，初始化数据失败！" + ex.Message, "收款单温馨提示！");
                this.Close();
                return;
            }

        }

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
                gr["yuandanCode"].Value = XYEEncoding.strHexDecode(dt.Rows[0]["saleCode"].ToString());  //源单编号
                gr["danjuDate"].Value = dt.Rows[0]["salesDate"].ToString();  //源单日期
                gr["yuandanType"].Value = XYEEncoding.strHexDecode(dt.Rows[0]["salesType"].ToString());   //源单类型
                gr["danjuMoney"].Value = dt.Rows[0]["amountReceivable"].ToString();  //单据金额
                gr["YiHeXiaoMoney"].Value = dt.Rows[0]["amountReceived"].ToString();   //已核销金额
                gr["WeiHeXiaoMoney"].Value = dt.Rows[0]["amountUnpaid"].ToString();   //未核销金额
                gr["BenCiHeXiao"].Value = dt.Rows[i]["nowMoney"].ToString();   //本次核销
                gr["WeuFuMoney"].Value = dt.Rows[i]["unCollection"].ToString();   //剩余尾款
                gr["remark"].Value = dt.Rows[i]["remark"].ToString();   //备注
            }
            TongJi();
            superGridControlShangPing.PrimaryGrid.NewRow(superGridControlShangPing.PrimaryGrid.Rows.Count);
        }

        /// <summary>
        /// 前单
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
                    code = financeCollectionInterface.GetNewCode();
                    dt = financeCollectionInterface.GetFLastData(code);
                }
                else
                {
                    code = this.lblcode.Text;
                    dt = financeCollectionInterface.GetLastData(code);
                    toolStripBtnHouDan.Enabled = true;
                }
                this.cboDanJuType.SelectedText = XYEEncoding.strHexDecode(dt.Rows[0]["type"].ToString());
                this.txtClient.Text = XYEEncoding.strHexDecode(client.GetList(3, dt.Rows[0]["clientCode"].ToString()).Rows[0]["name"].ToString());
                //this.txtBenCiHeXiao.Text = 
                _clientCode = XYEEncoding.strHexDecode(dt.Rows[0]["clientCode"].ToString());
                BankAccountInterface bankAccountInterface = new BankAccountInterface();
                this.txtBank.Text = XYEEncoding.strHexDecode(dt.Rows[0]["accountName"].ToString());
                //this.txtBankcode.text = XYEEncoding.strHexDecode(dt.Rows[0]["accountCode"]);
                this.cboDanJuType.SelectedText = XYEEncoding.strHexDecode(dt.Rows[0]["settlementMethod"].ToString());
                this.txtDiscount.Text = dt.Rows[0]["discount"].ToString();
                this.txtRemark.Text = XYEEncoding.strHexDecode(dt.Rows[0]["remark"].ToString());

                this.ltxtbSalsMan.Text = XYEEncoding.strHexDecode(dt.Rows[0]["salesMan"].ToString());
                this.ltxtbMakeMan.Text = XYEEncoding.strHexDecode(dt.Rows[0]["operationMan"].ToString());
                this.ltxtbShengHeMan.Text = XYEEncoding.strHexDecode(dt.Rows[0]["checkMan"].ToString());
                this.lblcode.Text = dt.Rows[0]["code"].ToString();
                this.lblcheckState.Text = dt.Rows[0]["checkState"].ToString(); //审核
                //判断审核
                //if (this.lblcheckState.Text == "1")
                //{
                //    picShengHe.Parent = pictureBoxtitle;
                //    InitForm();  //标记控件不可用
                //    toolStripBtnShengHe.Enabled = false;
                //}
                //else
                //{
                //    EnabledForm(); //标记控件可用
                //    toolStripBtnShengHe.Enabled = true;
                //}
                resizablePanel1.Visible = false;
                InitSupergridView(dt);
                //判断是否到上限
                string lcode = dt.Rows[0]["code"].ToString();
                dt = financeCollectionInterface.GetLastData(lcode);
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

        /// <summary>
        /// 后单
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToolStripBtnHouDan_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            try
            {
                code = this.lblcode.Text;
                dt = financeCollectionInterface.GetNextData(code);
                toolStripBtnHouDan.Enabled = true;
                this.cboDanJuType.SelectedText = XYEEncoding.strHexDecode(dt.Rows[0]["type"].ToString());
                this.txtClient.Text = XYEEncoding.strHexDecode(client.GetList(3, dt.Rows[0]["clientCode"].ToString()).Rows[0]["name"].ToString());
                //this.txtBenCiHeXiao.Text = 
                _clientCode = XYEEncoding.strHexDecode(dt.Rows[0]["clientCode"].ToString());
                BankAccountInterface bankAccountInterface = new BankAccountInterface();
                this.txtBank.Text = XYEEncoding.strHexDecode(dt.Rows[0]["accountName"].ToString());
                //this.txtBankcode.text = XYEEncoding.strHexDecode(dt.Rows[0]["accountCode"]);
                this.cboDanJuType.SelectedText = XYEEncoding.strHexDecode(dt.Rows[0]["settlementMethod"].ToString());
                this.txtDiscount.Text = dt.Rows[0]["discount"].ToString();
                this.txtRemark.Text = XYEEncoding.strHexDecode(dt.Rows[0]["remark"].ToString());

                this.ltxtbSalsMan.Text = XYEEncoding.strHexDecode(dt.Rows[0]["salesMan"].ToString());
                this.ltxtbMakeMan.Text = XYEEncoding.strHexDecode(dt.Rows[0]["operationMan"].ToString());
                this.ltxtbShengHeMan.Text = XYEEncoding.strHexDecode(dt.Rows[0]["checkMan"].ToString());
                this.lblcode.Text = dt.Rows[0]["code"].ToString();
                this.lblcheckState.Text = dt.Rows[0]["checkState"].ToString(); //审核
                //判断审核
                //if (this.lblcheckState.Text == "1")
                //{
                //    picShengHe.Parent = pictureBoxtitle;
                //    InitForm();  //标记控件不可用
                //    toolStripBtnShengHe.Enabled = false;
                //}
                //else
                //{
                //    EnabledForm(); //标记控件可用
                //    toolStripBtnShengHe.Enabled = true;
                //}
                resizablePanel1.Visible = false;
                InitSupergridView(dt);
                //判断是否到上限
                string lcode = dt.Rows[0]["code"].ToString();
                dt = financeCollectionInterface.GetNextData(lcode);
                toolStripBtnQianDan.Enabled = true;
                if (dt.Rows.Count == 0)
                {
                    toolStripBtnHouDan.Enabled = false; //下一单没有数据
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("错误代码：2106-尝试点击前单数据错误" + ex.Message, "财务凭证条目单温馨提示");
            }
        }

        private void DataGridViewFuJia_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                dataGridViewFuJiaTableClick();
            }
        }

        /// <summary>
        /// 选源单点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToolStripButtonXuanYuanDan_Click(object sender, EventArgs e)
        {
            XuanYuanDan();
        }

        #region 选源单、保存、审核函数
        /// <summary>
        /// 选源单的函数
        /// </summary>
        private void XuanYuanDan()
        {
            if (txtClient.Text == null || txtClient.Text == "" || _clientCode == null || _clientCode == "")
            {
                MessageBox.Show("请先选择客户：");
                return;
            }

            SalesTicketReportForm salesTickeReport = new SalesTicketReportForm();
            salesTickeReport.ClientCode = _clientCode;
            salesTickeReport.ShowDialog(this);

            SalesMainInterface salesInterface = new SalesMainInterface();
            if (_salesMainCode == null)
            {
                return;
            }
            labTop1.ForeColor = Color.Gray;
            cboDanJuType.Enabled = false;
            GridItemsCollection grs = superGridControlShangPing.PrimaryGrid.Rows;
            GridRow grid = (GridRow)superGridControlShangPing.PrimaryGrid.Rows[ClickRowIndex];
            DataTable dt = ch.DataTableReCoding(salesInterface.GetExamineAndPay(XYEEncoding.strCodeHex(_clientCode), XYEEncoding.strCodeHex(_salesMainCode)));

            superGridControlShangPing.PrimaryGrid.Rows.Add(new GridRow(dt.Rows[0]["code"],
           dt.Rows[0]["date"],
           dt.Rows[0]["type"],
           dt.Rows[0]["oddAllMoney"].ToString() == "" ? 0.0M : dt.Rows[0]["oddAllMoney"],
           dt.Rows[0]["firstMoney"].ToString() == "" ? 0.0M : dt.Rows[0]["firstMoney"],
           dt.Rows[0]["lastMoney"].ToString() == "" ? 0.0M : dt.Rows[0]["lastMoney"],
             0.0M,
             0.0M,
           dt.Rows[0]["remark"].ToString() == "" ? "" : dt.Rows[0]["remark"]
           ));
            TongJi();

            foreach (GridRow g in grs)
            {
                if (g.Cells["yuandanCode"].Value == null || g.Cells["yuandanCode"].Value.ToString() == "合计")
                {
                    continue;
                }
                SalesMainList.Add(g.Cells["yuandanCode"].Value.ToString());
            }
            _salesMainCode = null;
        }

        /// <summary>
        /// 保存的函数
        /// </summary>
        private void Save()
        {
            if (isNUllValidate() == false)
            {
                return;
            }
            //获得界面上的数据,准备传给base层新增数据
            //FinanceCollectionInterface financeCollectionInterface = new FinanceCollectionInterface();
            //收款单
            FinanceCollection financecollection = new FinanceCollection();
            //收款详单
            List<FinanceCollectionDetail> financecollectionList = new List<FinanceCollectionDetail>();
            try
            {
                financecollection.code = XYEEncoding.strCodeHex(validateCode());//收款单单号
                if (txtClient.Text != null || txtClient.Text != "")
                {
                    financecollection.clientName = XYEEncoding.strCodeHex(txtClient.Text.Trim());//客户名称
                }
                else
                {
                    MessageBox.Show("客户名称不能为空，请输入：");
                    txtClient.Focus();
                    return;
                }

                if (txtBank.Text != null || txtBank.Text.Trim() != "")
                {
                    financecollection.accountName = XYEEncoding.strCodeHex(txtBank.Text.Trim());//账户名称
                }
                else
                {
                    MessageBox.Show("账户名称不能为空，请输入：");
                    txtBank.Focus();
                    return;
                }

                if (ltxtbSalsMan.Text != null || ltxtbSalsMan.Text.Trim() != "")
                {
                    financecollection.salesMan = XYEEncoding.strCodeHex(ltxtbSalsMan.Text.Trim());//收款员
                }
                else
                {
                    MessageBox.Show("收款不能为空，请输入：");
                    ltxtbSalsMan.Focus();
                    return;
                }
                financecollection.date = this.dateTimePicker1.Value;//开单日期
                financecollection.type = XYEEncoding.strCodeHex(cboDanJuType.Text.Trim());//单据类型    
                financecollection.clientCode = XYEEncoding.strCodeHex(_clientCode);//客户编号 
                financecollection.accountCode = XYEEncoding.strCodeHex(_bankCode);//账户code
                financecollection.salesCode = XYEEncoding.strCodeHex(_employeeCode);//收款员code
                financecollection.settlementMethod = XYEEncoding.strCodeHex(cboJieSuanMethod.Text.Trim());//结算方式
                financecollection.discount = Convert.ToDecimal(txtDiscount.Text.Trim() == "" ? 0.0M : Convert.ToDecimal(txtDiscount.Text));//整单折扣率
                financecollection.totalCollection = Convert.ToDecimal(txtBenCiShouKuan.Text.Trim() == "" ? 0.0M : Convert.ToDecimal(txtBenCiShouKuan.Text));//整单收款   
                financecollection.remark = XYEEncoding.strCodeHex(txtRemark.Text.Trim() == null ? "" : txtRemark.Text.ToString());//摘要                
                financecollection.operationMan = XYEEncoding.strCodeHex(ltxtbMakeMan.Text.Trim() == null ? "" : ltxtbMakeMan.Text);//制单人
                financecollection.checkMan = XYEEncoding.strCodeHex(ltxtbShengHeMan.Text.Trim() == null ? "" : ltxtbShengHeMan.Text);//审核人   
                financecollection.isClear = 1;
                financecollection.updatedate = DateTime.Now;
                financecollection.checkState = 0;//审核状态
                financecollection.Reserved1 = "";
                financecollection.Reserved2 = "";

                if (_shengYuMoney == _danJuMoney)
                {
                    financecollection.financeCollectionState = 0;//单据状态 (0为未收款)
                }
                if (_shengYuMoney < _danJuMoney)
                {
                    financecollection.financeCollectionState = 1;//单据状态 (1为部分收款)
                }
                if (_shengYuMoney == Convert.ToDecimal(0.00))
                {
                    financecollection.financeCollectionState = 2;//单据状态（2为已收款）
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("错误代码:1502-尝试创建收款单数据出错!请检查:" + ex.Message, "收款单温馨提示");
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
                    if (gr["yuandanCode"].Value != null)
                    {
                        i++;
                        FinanceCollectionDetail financecollectionDetail = new FinanceCollectionDetail();

                        if (gr["yuandanType"].Value.ToString() != "" || gr["yuandanType"].Value != null)
                        {
                            financecollectionDetail.salesType = XYEEncoding.strCodeHex(gr["yuandanType"].Value.ToString());//销售单类型
                        }
                        else
                        {
                            MessageBox.Show("选源单不能为空，请输入：");
                            superGridControlShangPing.Focus();
                            return;
                        }
                        financecollectionDetail.code = XYEEncoding.strCodeHex(_SaleReceivablesCode + i.ToString());//收款详单code
                        financecollectionDetail.saleCode = XYEEncoding.strCodeHex(gr["yuandanCode"].Value.ToString());//销售单code
                        financecollectionDetail.salesDate = Convert.ToDateTime(gr["danjuDate"].Value);//销售单开单日期
                        financecollectionDetail.mainCode = XYEEncoding.strCodeHex(this.textBoxOddNumbers.Text);//主表code（收款单code）
                        financecollectionDetail.amountReceivable = Convert.ToDecimal(gr["danjuMoney"].Value == null ? 0.0M : Convert.ToDecimal(gr["danjuMoney"].Value));//应收金额
                        financecollectionDetail.amountReceived = Convert.ToDecimal(gr["YiHeXiaoMoney"].Value == null ? 0.0M : Convert.ToDecimal(gr["YiHeXiaoMoney"].Value));//已核销金额
                        financecollectionDetail.amountUnpaid = Convert.ToDecimal(gr["WeiHeXiaoMoney"].Value == null ? 0.0M : Convert.ToDecimal(gr["WeiHeXiaoMoney"].Value));//未核销金额
                        financecollectionDetail.nowMoney = Convert.ToDecimal(gr["BenCiHeXiao"].Value.ToString() == "" ? 0.0M : Convert.ToDecimal(gr["BenCiHeXiao"].Value));//本次收款金额
                        financecollectionDetail.unCollection = Convert.ToDecimal(gr["WeuFuMoney"].Value == null ? 0.0M : Convert.ToDecimal(gr["WeuFuMoney"].Value));//未收金额
                        financecollectionDetail.remark = XYEEncoding.strCodeHex(gr["remark"].Value.ToString());//备注  

                        GridRow dr = superGridControlShangPing.PrimaryGrid.Rows[0] as GridRow;
                        financecollectionList.Add(financecollectionDetail);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("错误代码：1503-尝试创建收款单详细数据出错!请检查:" + ex.Message, "收款单温馨提示");
                return;
            }

            //增加一条收款单和收款单详细数据
            object financelCollectionResult = financeCollectionInterface.AddOrUpdateToMainOrDetail(financecollection, financecollectionList);
            if (financelCollectionResult != null)
            {
                MessageBox.Show("新增收款单数据成功", "收款单温馨提示");
            }
        }

        /// <summary>
        /// 审核的函数
        /// </summary>
        private void ShengHe()
        {
            if (isNUllValidate() == false)
            {
                return;
            }
            //获得界面上的数据,准备传给base层新增数据
            FinanceCollectionInterface financeCollectionInterface = new FinanceCollectionInterface();
            //收款单
            FinanceCollection financecollection = new FinanceCollection();
            //收款详单
            List<FinanceCollectionDetail> financecollectionList = new List<FinanceCollectionDetail>();
            try
            {
                if (txtClient.Text != null || txtClient.Text != "")
                {
                    financecollection.clientName = XYEEncoding.strCodeHex(txtClient.Text.Trim());//客户名称
                }
                else
                {
                    MessageBox.Show("客户名称不能为空，请输入：");
                    txtClient.Focus();
                    return;
                }
                if (txtBank.Text != null || txtBank.Text.Trim() != "")
                {
                    financecollection.accountName = XYEEncoding.strCodeHex(txtBank.Text.Trim());//账户名称
                }
                else
                {
                    MessageBox.Show("账户名称不能为空，请输入：");
                    txtBank.Focus();
                    return;
                }

                if (ltxtbSalsMan.Text != null || ltxtbSalsMan.Text.Trim() != "")
                {
                    financecollection.salesMan = XYEEncoding.strCodeHex(ltxtbSalsMan.Text.Trim());//收款员
                }
                else
                {
                    MessageBox.Show("收款不能为空，请输入：");
                    ltxtbSalsMan.Focus();
                    return;
                }
                financecollection.code = XYEEncoding.strCodeHex(_SaleReceivablesCode);//收款单单号
                financecollection.date = this.dateTimePicker1.Value;//开单日期
                financecollection.type = XYEEncoding.strCodeHex(cboDanJuType.Text.Trim());//单据类型
                financecollection.clientCode = XYEEncoding.strCodeHex(_clientCode);//客户编号
                financecollection.accountCode = XYEEncoding.strCodeHex(_bankCode);//账户code
                financecollection.settlementMethod = XYEEncoding.strCodeHex(cboJieSuanMethod.Text.Trim());//结算方式
                financecollection.discount = Convert.ToDecimal(txtDiscount.Text.Trim() == "" ? 0.0M : Convert.ToDecimal(txtDiscount.Text));//整单折扣率
                financecollection.totalCollection = Convert.ToDecimal(txtBenCiShouKuan.Text.Trim() == "" ? 0.0M : Convert.ToDecimal(txtBenCiShouKuan.Text));//整单收款   
                financecollection.remark = XYEEncoding.strCodeHex(txtRemark.Text.Trim() == null ? "" : txtRemark.Text.ToString());//摘要 
                financecollection.salesCode = XYEEncoding.strCodeHex(_employeeCode);//收款员code
                financecollection.operationMan = XYEEncoding.strCodeHex(ltxtbMakeMan.Text.Trim() == null ? "" : ltxtbMakeMan.Text);//制单人
                financecollection.checkMan = XYEEncoding.strCodeHex(ltxtbShengHeMan.Text.Trim() == null ? "" : ltxtbShengHeMan.Text);//审核人   
                financecollection.isClear = 1;
                financecollection.updatedate = DateTime.Now;
                financecollection.checkState = 1;//审核状态
                financecollection.Reserved1 = "";
                financecollection.Reserved2 = "";
                if (_shengYuMoney == _danJuMoney)
                {
                    financecollection.financeCollectionState = 0;//单据状态 (0为未收款)
                }
                if (_shengYuMoney < _danJuMoney)
                {
                    financecollection.financeCollectionState = 1;//单据状态 (1为部分收款)
                }
                if (_shengYuMoney == Convert.ToDecimal(0.00))
                {
                    financecollection.financeCollectionState = 2;//单据状态（2为已收款）
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("错误代码:1504-尝试创建并审核收款单数据出错！请检查：" + ex.Message, "收款单温馨提示");
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
                    if (gr["yuandanCode"].Value != null)
                    {
                        i++;
                        FinanceCollectionDetail financecollectionDetail = new FinanceCollectionDetail();
                        if (gr["yuandanType"].Value.ToString() != "" || gr["yuandanType"].Value != null)
                        {
                            financecollectionDetail.salesType = XYEEncoding.strCodeHex(gr["yuandanType"].Value.ToString());//销售单类型
                        }
                        else
                        {
                            MessageBox.Show("选源单不能为空，请输入：");
                            superGridControlShangPing.Focus();
                            return;
                        }
                        financecollectionDetail.mainCode = XYEEncoding.strCodeHex(this.textBoxOddNumbers.Text);//主表code（收款单code）
                        financecollectionDetail.code = XYEEncoding.strCodeHex(_SaleReceivablesCode + i.ToString());//收款详单code
                        financecollectionDetail.saleCode = XYEEncoding.strCodeHex(gr["yuandanCode"].Value.ToString());//销售单code
                        financecollectionDetail.salesDate = Convert.ToDateTime(gr["danjuDate"].Value);//销售单开单日期
                        financecollectionDetail.amountReceivable = Convert.ToDecimal(gr["danjuMoney"].Value == null ? 0.0M : Convert.ToDecimal(gr["danjuMoney"].Value));//应收金额
                        financecollectionDetail.amountReceived = Convert.ToDecimal(gr["YiHeXiaoMoney"].Value == null ? 0.0M : Convert.ToDecimal(gr["YiHeXiaoMoney"].Value));//已核销金额
                        financecollectionDetail.amountUnpaid = Convert.ToDecimal(gr["WeiHeXiaoMoney"].Value == null ? 0.0M : Convert.ToDecimal(gr["WeiHeXiaoMoney"].Value));//未核销金额
                        financecollectionDetail.nowMoney = Convert.ToDecimal(gr["BenCiHeXiao"].Value.ToString() == "" ? 0.0M : Convert.ToDecimal(gr["BenCiHeXiao"].Value));//本次收款金额
                        financecollectionDetail.unCollection = Convert.ToDecimal(gr["WeuFuMoney"].Value == null ? 0.0M : Convert.ToDecimal(gr["WeuFuMoney"].Value));//未收金额
                        financecollectionDetail.remark = XYEEncoding.strCodeHex(gr["remark"].Value.ToString());//备注  

                        GridRow dr = superGridControlShangPing.PrimaryGrid.Rows[0] as GridRow;
                        financecollectionList.Add(financecollectionDetail);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("错误代码：1505-尝试创建并审核收款单详细数据出错！请检查：" + ex.Message, "收款单温馨提示");
                return;
            }

            //增加一条收款单和收款单详细数据
            object financelCollectionResult = financeCollectionInterface.AddOrUpdateToMainOrDetail(financecollection, financecollectionList);
            if (financelCollectionResult != null)
            {
                MessageBox.Show("新增并审核收款单数据成功", "收款单温馨提示");
                InitForm();
            }
        }
        #endregion

        /// <summary>
        /// 下拉框选择改变事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cboDanJuType_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cboDanJuType.Text.Trim())
            {
                case "销售收款":
                    labTop6.ForeColor = Color.Black;
                    txtBenCiShouKuan.ReadOnly = false;
                    txtBenCiShouKuan.Border.BorderBottomColor = Color.Black;
                    labTop7.ForeColor = Color.Black;
                    txtDiscount.ReadOnly = false;
                    txtDiscount.Border.BorderBottomColor = Color.Black;
                    break;
                case "预收款":
                    labTop6.ForeColor = Color.Gray;
                    txtBenCiShouKuan.ReadOnly = true;
                    txtBenCiShouKuan.BackColor = Color.White;
                    txtBenCiShouKuan.Border.BorderBottomColor = Color.Gray;
                    labTop7.ForeColor = Color.Gray;
                    txtDiscount.ReadOnly = true;
                    txtDiscount.BackColor = Color.White;
                    txtDiscount.Border.BorderBottomColor = Color.Gray;
                    break;
                case "预收退款":
                    labTop6.ForeColor = Color.Gray;
                    txtBenCiShouKuan.ReadOnly = true;
                    txtBenCiShouKuan.BackColor = Color.White;
                    txtBenCiShouKuan.Border.BorderBottomColor = Color.Gray;
                    labTop7.ForeColor = Color.Gray;
                    txtDiscount.ReadOnly = true;
                    txtDiscount.BackColor = Color.White;
                    txtDiscount.Border.BorderBottomColor = Color.Gray;
                    break;
            }
        }

        #region 小箭头点击事件和表格的双击事件

        /// <summary>
        /// 客户
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
        /// 结算账户
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
        /// 销售员
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
        /// 双击绑定客户、结算账户、收款员数据
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
                if (this.txtClient.Text.Trim() == "")
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
                string name = XYEEncoding.strCodeHex(this.txtClient.Text.Trim());
                dataGridViewFuJia.DataSource = ch.DataTableReCoding(client.GetList(0, name));
                resizablePanel1.Visible = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("错误代码：1510-模糊查询客户数据错误" + ex.Message, "收款单温馨提示");
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
                if (this.txtBank.Text.Trim() == "")
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
                string name = XYEEncoding.strCodeHex(this.txtBank.Text.Trim());
                dataGridViewFuJia.DataSource = ch.DataTableReCoding(bank.GetList(1, name, false, false));
                resizablePanel1.Visible = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("错误代码：1511-模糊查询结算账户数据错误" + ex.Message, "收款单温馨提示");
            }
        }

        /// <summary>
        ///收款员模糊查询
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
                MessageBox.Show("错误代码：1512-模糊查询收款员数据失败！" + ex.Message);
            }
        }
        #endregion

        private void SalesReceivablesForm_Activated(object sender, EventArgs e)
        {
            txtClient.Focus();//窗体活动时焦点在客户
        }

        /// <summary>
        /// 按ESC关闭副表格
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SalesReceivablesForm_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Escape)
            {
                this.resizablePanel1.Visible = false;
                this.resizablePanelData.Visible = false;
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
                ShengHe();
            }
        }

        /// <summary>
        /// 验证、统计数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void superGridControlShangPing_CellValidated(object sender, GridCellValidatedEventArgs e)
        {
            try
            {
                //最后一行做统计行
                GridRow gr = e.GridPanel.Rows[e.GridCell.RowIndex] as GridRow;
                if (gr.Cells["yuandanCode"].FormattedValue == null || gr.Cells["yuandanCode"].FormattedValue == "")
                {
                    MessageBox.Show("请先选择源单：");
                    return;
                }
                ////计算金额
                decimal benciHeXiaoMoney = Convert.ToDecimal(gr.Cells["BenCiHeXiao"].FormattedValue);//本次核销金额
                decimal weiHeXiaoMoney = Convert.ToDecimal(gr.Cells["WeiHeXiaoMoney"].FormattedValue);//未核销金额
                if (benciHeXiaoMoney > weiHeXiaoMoney)
                {
                    MessageBox.Show("本次核销金额不能大于未核销金额！");
                    return;
                }

                decimal weishouMoney = weiHeXiaoMoney - benciHeXiaoMoney;//未收金额
                gr.Cells["WeuFuMoney"].Value = weishouMoney;

                //逐行统计数据总数
                decimal tempDanJuMoney = 0;
                decimal tempYiHeXiaoMoney = 0;
                decimal tempWeiHeXiaoMoney = 0;
                decimal tempBenCiHeXiao = 0;
                decimal tempShengYuMoney = 0;
                for (int i = 0; i < superGridControlShangPing.PrimaryGrid.Rows.Count - 1; i++)
                {
                    GridRow tempGR = superGridControlShangPing.PrimaryGrid.Rows[i] as GridRow;
                    tempDanJuMoney += Convert.ToDecimal(tempGR["danjuMoney"].FormattedValue);
                    tempYiHeXiaoMoney += Convert.ToDecimal(tempGR["YiHeXiaoMoney"].FormattedValue);
                    tempWeiHeXiaoMoney += Convert.ToDecimal(tempGR["WeiHeXiaoMoney"].FormattedValue);
                    tempBenCiHeXiao += Convert.ToDecimal(tempGR["BenCiHeXiao"].FormattedValue);
                    tempShengYuMoney += Convert.ToDecimal(tempGR["WeuFuMoney"].FormattedValue);
                }
                _danJuMoney = tempDanJuMoney;
                _yiHeXiaoMoney = tempYiHeXiaoMoney;
                _weiHeXiaoMoney = tempWeiHeXiaoMoney;
                _benCiHeXiaoMoney = tempBenCiHeXiao;
                _shengYuMoney = tempShengYuMoney;
                gr = (GridRow)superGridControlShangPing.PrimaryGrid.LastSelectableRow;
                gr["danjuMoney"].Value = _danJuMoney.ToString();
                gr["YiHeXiaoMoney"].Value = _yiHeXiaoMoney.ToString();
                gr["WeiHeXiaoMoney"].Value = _weiHeXiaoMoney.ToString();
                gr["BenCiHeXiao"].Value = _benCiHeXiaoMoney.ToString();
                gr["WeuFuMoney"].Value = tempShengYuMoney.ToString();

                txtBenCiHeXiao.Text = _benCiHeXiaoMoney.ToString("0.00");
                txtBenCiShouKuan.Text = _benCiHeXiaoMoney.ToString("0.00");
            }
            catch (Exception ex)
            {
                MessageBox.Show("错误代码：1513-验证表格里的金额以及统计数量出错！请检查：" + ex.Message, "收款单温馨提示！");
            }
        }

        #region  验证数据
        /// <summary>
        /// 整单折扣
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtDiscount_Validated(object sender, EventArgs e)
        {
            try
            {
                decimal zhekou = Convert.ToDecimal(txtDiscount.Text);
                decimal hexiao = Convert.ToDecimal(txtBenCiHeXiao.Text);
                if (zhekou > 100 || zhekou < 0)
                {
                    MessageBox.Show("折扣率不能大于100或者不能小于0！");
                    txtDiscount.Clear();
                    txtDiscount.Text = "100.00";
                }
                decimal bencishoukuan = hexiao * (Convert.ToDecimal(txtDiscount.Text) / 100);
                txtBenCiShouKuan.Text = bencishoukuan.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("错误代码：1515-验证整单折扣金额出错！请检查:" + ex.Message, "收款单温馨提示！");
            }
        }

        private void txtDiscount_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                //小数点的处理。
                if ((int)e.KeyChar == 46)//小数点
                {
                    if (txtDiscount.Text.Length <= 0)
                        e.Handled = true;   //小数点不能在第一位
                    else
                    {
                        float f;
                        float oldf;
                        bool b1 = false, b2 = false;
                        b1 = float.TryParse(txtDiscount.Text, out oldf);
                        b2 = float.TryParse(txtDiscount.Text + e.KeyChar.ToString(), out f);
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
                MessageBox.Show("错误代码：1514-整单折扣输入的值为非法字符，请重新输入:" + ex.Message, "收款单温馨提示！");
            }
        }

        private string skipComma(string str)
        {
            string[] ss = null;
            string strnew = "";
            if (str == "")
            {
                strnew = "0";
            }
            else
            {
                ss = str.Split(',');
                for (int i = 0; i < ss.Length; i++)
                {
                    strnew += ss[i];
                }
            }
            return strnew;
        }

        /// <summary>
        /// 本次核销金额
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtBenCiHeXiao_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtBenCiHeXiao.Text))
                return;

            // 按千分位逗号格式显示！
            double d = Convert.ToDouble(skipComma(txtBenCiHeXiao.Text));
            txtBenCiHeXiao.Text = string.Format("{0:#,#}", d);
            // 确保输入光标在最右侧
            txtBenCiHeXiao.Select(txtBenCiHeXiao.Text.Length, 0);
        }

        /// <summary>
        /// 本次收款金额
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtBenCiShouKuan_TextChanged(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(txtBenCiShouKuan.Text))
                return;

            // 按千分位逗号格式显示！
            double d = Convert.ToDouble(skipComma(txtBenCiShouKuan.Text));
            txtBenCiShouKuan.Text = string.Format("{0:#,#}", d);

            // 确保输入光标在最右侧
            txtBenCiShouKuan.Select(txtBenCiShouKuan.Text.Length, 0);
        }

        /// <summary>
        /// 当控件失去焦点时，控件的值精确到两位小数
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtDiscount_Leave(object sender, EventArgs e)
        {
            //控件失去焦点后将它的值的格式精确到两位小数
            TextBoxX name = (sender as TextBoxX);

            if (name.Text == "")
            {
                name.Text = "0.00";
            }
            name.Text = Convert.ToDecimal(name.Text).ToString("0.00");
        }

        #endregion

        /// <summary>
        /// 快捷方式
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SalesReceivablesForm_KeyDown(object sender, KeyEventArgs e)
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
            if (e.KeyCode == Keys.C)
            {
                XuanYuanDan();
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
                    ShengHe();
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
        /// 设置边框
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
                             Color.White,
                             1,
                             ButtonBorderStyle.Solid);
        }
        /// <summary>
        /// 表格回车键
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void superGridControlShangPing_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtClient.Focus();
            }
        }

        private void superGridControlShangPing_CellDoubleClick(object sender, GridCellDoubleClickEventArgs e)
        {
            //MessageBox.Show("Test");
        }

        /// <summary>
        /// 统计行数据
        /// </summary>
        private void TongJi()
        {
            GridRow grid = (GridRow)superGridControlShangPing.PrimaryGrid.Rows[ClickRowIndex];
            //逐行统计数据总数
            decimal tempDanJuMoney = 0;
            decimal tempYiHeXiaoMoney = 0;
            decimal tempWeiHeXiaoMoney = 0;
            decimal tempBenCiHeXiao = 0;
            for (int i = 0; i < superGridControlShangPing.PrimaryGrid.Rows.Count - 1; i++)
            {
                GridRow tempGR = superGridControlShangPing.PrimaryGrid.Rows[i] as GridRow;
                tempDanJuMoney += Convert.ToDecimal(tempGR["danjuMoney"].FormattedValue);
                tempYiHeXiaoMoney += Convert.ToDecimal(tempGR["YiHeXiaoMoney"].FormattedValue);
                tempWeiHeXiaoMoney += Convert.ToDecimal(tempGR["WeiHeXiaoMoney"].FormattedValue);
                tempBenCiHeXiao += Convert.ToDecimal(tempGR["BenCiHeXiao"].FormattedValue);
            }
            _danJuMoney = tempDanJuMoney;
            _yiHeXiaoMoney = tempYiHeXiaoMoney;
            _weiHeXiaoMoney = tempWeiHeXiaoMoney;
            _benCiHeXiaoMoney = tempBenCiHeXiao;
            grid = (GridRow)superGridControlShangPing.PrimaryGrid.LastSelectableRow;
            grid["danjuMoney"].Value = _danJuMoney.ToString();
            grid["YiHeXiaoMoney"].Value = _yiHeXiaoMoney.ToString();
            grid["WeiHeXiaoMoney"].Value = _weiHeXiaoMoney.ToString();
            grid["BenCiHeXiao"].Value = _benCiHeXiaoMoney.ToString();
        }

        /// <summary>
        /// 验证单号是否重复
        /// </summary>
        /// <returns></returns>
        private string validateCode()
        {
            if (financeCollectionInterface.Exists(XYEEncoding.strCodeHex(_SaleReceivablesCode)))
            {
                _SaleReceivablesCode = BuildCode.ModuleCode("SRS");
            }
            else
            {
                _SaleReceivablesCode = textBoxOddNumbers.Text;//收款单单号
            }
            return _SaleReceivablesCode;
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
                    txtClient.Text = name;
                    resizablePanel1.Visible = false;
                }
                //结算账户
                if (_Click == 2 || _Click == 5)
                {
                    _bankCode = dataGridViewFuJia.Rows[dataGridViewFuJia.CurrentRow.Index].Cells["code"].Value.ToString();//银行账户code
                    string name = dataGridViewFuJia.Rows[dataGridViewFuJia.CurrentRow.Index].Cells["openBank"].Value.ToString();//账户名称
                    txtBank.Text = name;
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
                MessageBox.Show("错误代码：1509-双击绑定客户、结算账户、收款员数据错误！请检查：" + ex.Message, "收款单温馨提示！");
            }
        }
    }
}
