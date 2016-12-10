using DevComponents.DotNetBar.SuperGrid;
using HelperUtility;
using HelperUtility.Encrypt;
using InterfaceLayer.Base;
using Model;
using InterfaceLayer.Purchase;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WSCATProject.Purchase
{
    public partial class PurchaseTicketForm : TestForm
    {
        public PurchaseTicketForm()
        {
            InitializeComponent();
        }

        #region 调用接口以及加密解密方法
        CodingHelper ch = new CodingHelper();
        SupplierInterface supplier = new SupplierInterface();//供应商
        EmpolyeeInterface employee = new EmpolyeeInterface();//员工  
        StorageInterface storage = new StorageInterface();//仓库
        BankAccountInterface bank = new BankAccountInterface();//结算账户
        PurchaseMainInterface purchaseMianInterface = new PurchaseMainInterface();
        #endregion

        #region 数据字段

        /// <summary>
        /// 所有供应商
        /// </summary>
        private DataTable _AllSupplier = null;
        /// <summary>
        /// 所有销售员
        /// </summary>
        private DataTable _AllEmployee = null;
        /// <summary>
        /// 所有仓库
        /// </summary>
        private DataTable _AllStorage = null;
        /// <summary>
        /// 所有结算账户
        /// </summary>
        private DataTable _AllBank = null;
        /// <summary>
        /// 点击的项,1供应商  2为销售员  3为仓库   
        /// </summary>
        private int _Click = 0;
        /// <summary>
        /// 保存供应商Code
        /// </summary>
        private string _supplierCode;
        /// <summary>
        /// 保存销售员Code
        /// </summary>
        private string _employeeCode;
        /// <summary>
        /// 保存仓库Code
        /// </summary>
        private string _storgeCode;
        /// <summary>
        /// 仓库名称
        /// </summary>
        private string _storgeName;
        /// <summary>
        /// 保存账户code
        /// </summary>
        private string _bankCode;
        /// <summary>
        /// 保存仓库的字典集合
        /// </summary>
        private KeyValuePair<string, string> _ClickStorageList;
        /// <summary>
        /// 统计数量
        /// </summary>
        private decimal _Materialnumber;
        /// <summary>
        /// 统计金额
        /// </summary>
        private decimal _Money;
        /// <summary>
        /// 统计税额
        /// </summary>
        private decimal _TaxMoney;
        /// <summary>
        /// 统计价税合计
        /// </summary>
        private decimal _PriceAndTaxMoney;
        /// <summary>
        /// 统计采购费用合计
        /// </summary>
        private decimal _purchaseCost;
        /// <summary>
        /// 采购单code
        /// </summary>
        private decimal _benCiShouKuan;
        /// <summary>
        /// 总金额
        /// </summary>
        private decimal _zongJinE;
        /// <summary>
        /// 未付款金额
        /// </summary>
        private decimal _weiFuKuan;
        /// <summary>
        /// 缺少数量
        /// </summary>
        private decimal _lostNumber;
        /// <summary>
        /// 发货数量
        /// </summary>
        private decimal _faHuoShuLiang;
        /// <summary>
        /// 订购数量
        /// </summary>
        private decimal _dingGouShuLiang;
        private string _purchaseMainCode;
        private string _shangPinCode;
        /// <summary>
        /// 商品code
        /// </summary>
        public string ShangPinCode
        {
            get { return _shangPinCode; }
            set { _shangPinCode = value; }
        }

        private decimal _MaterialNumber;
        /// <summary>
        /// 采购主表code
        /// </summary>
        private string _purchaseMainCodel;
        public string PurchaseMainCodel
        {
            get { return _purchaseMainCodel; }
            set { _purchaseMainCodel = value; }
        }

        /// <summary>
        /// 采购明细的code
        /// </summary>
        private string _purchaseCode;
        public string PurchaseCode
        {
            get { return _purchaseCode; }
            set { _purchaseCode = value; }
        }
        /// <summary>
        /// 交货方式
        /// </summary>
        public string JiaoHuoFangShi
        {
            get { return _jiaoHuoFangShi; }
            set { _jiaoHuoFangShi = value; }
        }
        private string _jiaoHuoFangShi;
        private decimal _caiGoiJinE;
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
                    dgvc.Visible = false;
                    dataGridViewFuJia.Columns.Add(dgvc);

                    dgvc = new DataGridViewTextBoxColumn();
                    dgvc.Name = "linkMan";
                    dgvc.HeaderText = "联系人";
                    dgvc.DataPropertyName = "联系人";
                    dgvc.Visible = false;
                    dataGridViewFuJia.Columns.Add(dgvc);

                    dgvc = new DataGridViewTextBoxColumn();
                    dgvc.Name = "fax";
                    dgvc.HeaderText = "传真";
                    dgvc.DataPropertyName = "传真";
                    dgvc.Visible = false;
                    dataGridViewFuJia.Columns.Add(dgvc);

                    resizablePanel1.Location = new Point(439, 150);
                    dataGridViewFuJia.DataSource = ch.DataTableReCoding(_AllSupplier);
                    resizablePanel1.Visible = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("错误代码：3304-尝试点击供应商数据出错或者无数据！请检查：" + ex.Message, "购货温馨提示！");
            }
        }

        /// <summary>
        /// 初始化采购员
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
                MessageBox.Show("错误代码：3305-尝试点击采购员数据出错或者无数据！请检查：" + ex.Message, "购货单温馨提示！");
            }
        }

        /// <summary>
        /// 初始化仓库
        /// </summary>
        private void InitStorage()
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
                    dgvc.Visible = true;
                    dgvc.HeaderText = "仓库编号";
                    dgvc.DataPropertyName = "code";
                    dgvc.SortMode = DataGridViewColumnSortMode.NotSortable;
                    dataGridViewFuJia.Columns.Add(dgvc);

                    dgvc = new DataGridViewTextBoxColumn();
                    dgvc.Name = "name";
                    dgvc.Visible = true;
                    dgvc.HeaderText = "仓库名称";
                    dgvc.DataPropertyName = "name";
                    dgvc.SortMode = DataGridViewColumnSortMode.NotSortable;
                    dataGridViewFuJia.Columns.Add(dgvc);

                    dgvc = new DataGridViewTextBoxColumn();
                    dgvc.Name = "address";
                    dgvc.Visible = false;
                    dgvc.HeaderText = "仓库地址";
                    dgvc.DataPropertyName = "address";
                    dataGridViewFuJia.Columns.Add(dgvc);

                    //查询仓库的方法
                    dataGridViewFuJia.DataSource = ch.DataTableReCoding(_AllStorage);
                    resizablePanel1.Visible = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("错误代码：3306-尝试点击仓库数据出错或者无数据！请检查：" + ex.Message, "购货单温馨提示！");
            }
        }

        /// <summary>
        /// 初始化结算账户
        /// </summary>
        private void InitBank()
        {
            try
            {
                if (_Click != 4)
                {
                    _Click = 4;
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

                    resizablePanel1.Location = new Point(439, 190);
                    dataGridViewFuJia.DataSource = ch.DataTableReCoding(_AllBank);
                    resizablePanel1.Visible = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("错误代码：3307-尝试点击结算账户，数据显示失败或者无数据！" + ex.Message, "购货单温馨提示！");
            }
        }

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
            gr.Cells["gridColumndinggoushu"].Value = 0;
            gr.Cells["gridColumndinggoushu"].CellStyles.Default.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleCenter;
            gr.Cells["gridColumndinggoushu"].CellStyles.Default.Background.Color1 = Color.Orange;
            gr.Cells["gridColumnNumber"].Value = 0;
            gr.Cells["gridColumnNumber"].CellStyles.Default.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleCenter;
            gr.Cells["gridColumnNumber"].CellStyles.Default.Background.Color1 = Color.Orange;
            gr.Cells["gridColumnMoney"].Value = 0;
            gr.Cells["gridColumnMoney"].CellStyles.Default.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleCenter;
            gr.Cells["gridColumnMoney"].CellStyles.Default.Background.Color1 = Color.Orange;
            gr.Cells["gridColumnshuie"].Value = 0;
            gr.Cells["gridColumnshuie"].CellStyles.Default.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleCenter;
            gr.Cells["gridColumnshuie"].CellStyles.Default.Background.Color1 = Color.Orange;
            gr.Cells["gridColumncaihouMoney"].Value = 0;
            gr.Cells["gridColumncaihouMoney"].CellStyles.Default.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleCenter;
            gr.Cells["gridColumncaihouMoney"].CellStyles.Default.Background.Color1 = Color.Orange;
            gr.Cells["gridColumnjiashuiheji"].Value = 0;
            gr.Cells["gridColumnjiashuiheji"].CellStyles.Default.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleCenter;
            gr.Cells["gridColumnjiashuiheji"].CellStyles.Default.Background.Color1 = Color.Orange;
            #region 合计行不能点击
            gr.Cells["gridColumnStock"].AllowSelection = false;
            gr.Cells["material"].AllowSelection = false;
            gr.Cells["gridColumnname"].AllowSelection = false;
            gr.Cells["gridColumnModel"].AllowSelection = false;
            gr.Cells["gridColumntiaoxingma"].AllowSelection = false;
            gr.Cells["gridColumnunit"].AllowSelection = false;
            gr.Cells["gridColumnNumber"].AllowSelection = false;
            gr.Cells["gridColumndanjia"].AllowSelection = false;
            gr.Cells["gridColumnzhekoul"].AllowSelection = false;
            gr.Cells["gridColumnzengzhishiu"].AllowSelection = false;
            gr.Cells["gridColumnzhekoue"].AllowSelection = false;
            gr.Cells["gridColumnMoney"].AllowSelection = false;
            gr.Cells["gridColumnshuie"].AllowSelection = false;
            gr.Cells["gridColumncaihouMoney"].AllowSelection = false;
            gr.Cells["gridColumnjiashuiheji"].AllowSelection = false;
            gr.Cells["gridColumnshengchandate"].AllowSelection = false;
            gr.Cells["gridColumnbaozhiqi"].AllowSelection = false;
            gr.Cells["gridColumnyouxiaoqi"].AllowSelection = false;
            gr.Cells["gridColumnyuandancode"].AllowSelection = false;
            gr.Cells["gridColumndingdanbianhao"].AllowSelection = false;
            gr.Cells["gridColumnbeizhu"].AllowSelection = false;
            #endregion
        }

        /// <summary>
        /// 非空验证
        /// </summary>
        private bool isNUllValidate()
        {
            if (labtextboxTop2.Text.Trim() == null || labtextboxTop2.Text == "")
            {
                MessageBox.Show("供应商不能为空！");
                labtextboxTop2.Focus();
                return false;
            }
            GridRow gr = (GridRow)superGridControlShangPing.PrimaryGrid.Rows[1];
            if (gr.Cells["gridColumnStock"].Value == null || gr.Cells["gridColumnStock"].Value.ToString() == "")
            {
                MessageBox.Show("仓库不能为空！");
                superGridControlShangPing.Focus();
                return false;
            }
            if (gr.Cells["gridColumnname"].Value == null || gr.Cells["gridColumnname"].Value.ToString() == "")
            {
                MessageBox.Show("商品代码不能为空！");
                superGridControlShangPing.Focus();
                return false;
            }
            if (ltxtbSalsMan.Text.Trim() == null || ltxtbSalsMan.Text == "")
            {
                MessageBox.Show("采购员不能为空！");
                ltxtbSalsMan.Focus();
                return false;
            }
            return true;
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
        }
        #endregion

        /// <summary>
        /// 窗体加载事件
        /// </summary> 
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PurchaseTicketForm_Load(object sender, EventArgs e)
        {
            try
            {
                toolStripButtonXuanYuanDan.Visible = true;
                //供应商
                _AllSupplier = supplier.SelSupplierTable();
                //采购员
                _AllEmployee = employee.SelSupplierTable(false);
                //仓库
                _AllStorage = storage.GetList(00, "");
                //结算账户
                _AllBank = bank.GetList(999, "", false, false);

                //绑定事件 双击事填充内容并隐藏列表
                dataGridViewFuJia.CellDoubleClick += dataGridViewFuJia_CellDoubleClick;
                dataGridViewShangPing.CellDoubleClick += dataGridViewShangPing_CellDoubleClick;

                toolStripButtonXuanYuanDan.Visible = true;
                toolStripBtnSave.Click += ToolStripBtnSave_Click;//保存按钮
                toolStripBtnShengHe.Click += ToolStripBtnShengHe_Click;//审核按钮
                toolStripButtonXuanYuanDan.Click += ToolStripButtonXuanYuanDan_Click;//选源单的点击事件
                dataGridViewFuJia.KeyDown += DataGridViewFuJia_KeyDown;

                #region 初始化窗体

                comboBoxEWuLiuType.SelectedIndex = 0;
                comboBoxExJieSuaType.SelectedIndex = 0;
                comboBoxExType.SelectedIndex = 0;
                pictureBoxShengHe.Parent = pictureBoxtitle;
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

                //生成采购单code和显示条形码
                _purchaseMainCode = BuildCode.ModuleCode("PCT");
                textBoxOddNumbers.Text = _purchaseMainCode;
                barcodeXYE.Code128 _Code = new barcodeXYE.Code128();
                _Code.ValueFont = new Font("微软雅黑", 20);
                System.Drawing.Bitmap imgTemp = _Code.GetCodeImage(textBoxOddNumbers.Text, barcodeXYE.Code128.Encode.Code128A);
                pictureBoxTiaoXiangMa.Image = imgTemp;
                //审核图标
                pictureBoxShengHe.Parent = pictureBoxtitle;
            }
            catch (Exception ex)
            {
                MessageBox.Show("错误代码：3301-窗体加载时，初始化数据失败！请检查：" + ex.Message, "购货单温馨提示！");
                this.Close();
                return;
            }
        }

        private void DataGridViewFuJia_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                DataGridViewTableClick();
            }
        }

        /// <summary>
        /// 选源单按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToolStripButtonXuanYuanDan_Click(object sender, EventArgs e)
        {
            try
            {
                XuanYuanDan();
            }
            catch (Exception ex)
            {
                MessageBox.Show("错误代码：3303-点击选源单数据错误！" + ex.Message, "购货单温馨提示：");
            }

        }

        /// <summary>
        /// 审核按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToolStripBtnShengHe_Click(object sender, EventArgs e)
        {
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

        #region 小箭头和两个附表的点击事件
        /// <summary>
        /// 商品附表的点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridViewShangPing_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
        }
        /// <summary>
        /// 小箭头的点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridViewFuJia_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
            {
                return;
            }
            DataGridViewTableClick();

        }

        /// <summary>
        /// 光标定位
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PurchaseTicketForm_Activated(object sender, EventArgs e)
        {
            labtextboxTop2.Focus();
        }

        /// <summary>
        /// 供应商点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pictureBoxSupplier_Click(object sender, EventArgs e)
        {
            if (_Click != 1)
            {
                InitSupplier();
                dataGridViewFuJia.Focus();
            }
            _Click = 7;
        }

        /// <summary>
        /// 结算账户点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pictureBoxBank_Click(object sender, EventArgs e)
        {
            if (_Click != 4)
            {
                InitBank();
                dataGridViewFuJia.Focus();
            }
            _Click = 6;
        }

        /// <summary>
        /// 采购员的点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pictureBoxEmployee_Click(object sender, EventArgs e)
        {
            if (_Click != 2)
            {
                InitEmployee();
                dataGridViewFuJia.Focus();
            }
            _Click = 5;
        }
        /// <summary>
        /// 第一列的第一格的点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void superGridControlShangPing_BeginEdit(object sender, GridEditEventArgs e)
        {
            try
            {
                if (e.GridCell.GridColumn.Name == "gridColumnStock")
                {
                    if (_Click != 3)
                    {
                        InitStorage();
                    }
                    _Click = 8;
                    return;
                }
                if (e.GridCell.GridColumn.Name == "material")
                {
                    this.resizablePanelData.Visible = false;
                    toolStripButtonXuanYuanDan.PerformClick();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("错误代码：3308-选择表格第一个数据错误！" + ex.Message);
                return;
            }

        }

        #endregion

        #region 模糊查询
        /// <summary>
        /// 供应商模糊查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void labtextboxTopSupplier_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.labtextboxTop2.Text.Trim() == "")
                {
                    InitSupplier();
                    _Click = 7;
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

                resizablePanel1.Location = new Point(439, 150);
                string name = XYEEncoding.strCodeHex(this.labtextboxTop2.Text.Trim());
                dataGridViewFuJia.DataSource = ch.DataTableReCoding(supplier.GetList(0, name));
                resizablePanel1.Visible = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("错误代码：3309-模糊查询供应商数据错误" + ex.Message, "购货单温馨提示");
            }
        }
        /// <summary>
        /// 账户的模糊查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void labtextboxTopBank_TextChanged(object sender, EventArgs e)
        {

            try
            {
                if (this.labtextboxTop4.Text.Trim() == "")
                {
                    InitBank();
                    _Click = 6;
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

                resizablePanel1.Location = new Point(439, 190);
                string name = XYEEncoding.strCodeHex(this.labtextboxTop4.Text.Trim());
                dataGridViewFuJia.DataSource = ch.DataTableReCoding(bank.GetList(1, name, false, false));
                resizablePanel1.Visible = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("错误代码：3310-模糊查询结算账户数据错误！请检查：" + ex.Message, "购货单温馨提示");
            }
        }
        /// <summary>
        /// 采购员的模糊查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ltxtbSalsMan_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (ltxtbSalsMan.Text.Trim() == "")
                {
                    _Click = 5;
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
                MessageBox.Show("错误代码：3311-模糊查询采购员数据错误！" + ex.Message, "购货单单温馨提示！");
            }
        }


        #endregion

        /// <summary>
        /// 表格按回车的时候
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void superGridControlShangPing_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                int jishu = 0;
                //GridRow gr=superGridControlShangPing.PrimaryGrid.Rows[superGridControlShangPing.PrimaryGrid.Rows.Coun]
                for (int i = 0; i < superGridControlShangPing.PrimaryGrid.Rows.Count; i++)
                {
                    GridRow gr = superGridControlShangPing.PrimaryGrid.Rows[i] as GridRow;
                    if (gr["material"].Value == null || gr["material"].Value.ToString() == "")
                    {
                        jishu++;
                        if (jishu >= 2)
                        {
                            superGridControlShangPing.PrimaryGrid.Rows.RemoveAt(i);
                        }
                    }
                }

                labtextboxTop2.Focus();
            }
        }

        /// <summary>
        /// 选源单的封装函数
        /// </summary>
        private void XuanYuanDan()
        {

            if (_supplierCode == "" || labtextboxTop2.Text == "")
            {
                MessageBox.Show("请先选择供应商！");
                return;
            }
            //显示窗体
            PurchaseOrderReportForm purchaseOrder = new PurchaseOrderReportForm();
            purchaseOrder.SupplierCode = _supplierCode;
            purchaseOrder.ShowDialog(this);

            labTop1.ForeColor = Color.Gray;
            comboBoxExType.Enabled = false;
            if (_jiaoHuoFangShi == "2")
            {
                labTop6.ForeColor = Color.Black;
                comboBoxEWuLiuType.Enabled = true;
                labelWuLiuDanHao.ForeColor = Color.Black;
                textBoxKuaiDiDanHao.ReadOnly = false;
            }
            GridItemsCollection grs = superGridControlShangPing.PrimaryGrid.Rows;
            GridRow grid = (GridRow)superGridControlShangPing.PrimaryGrid.Rows[ClickRowIndex];


            PurchaseOrderInterface purchaseOrderinter = new PurchaseOrderInterface();
            if (_purchaseMainCodel == null)
            {
                return;
            }
            DataTable dt = ch.DataTableReCoding(purchaseOrderinter.GetJoinSearch(XYEEncoding.strCodeHex(_purchaseMainCodel), XYEEncoding.strCodeHex(_purchaseCode)));

            foreach (GridRow g in grs)
            {
                if (g.Cells["material"].Value == null || g.Cells["material"].Value.ToString() == "合计")
                {
                    continue;
                }
                if (g.Cells["gridColumnwuliaocode"].Value.Equals(dt.Rows[0]["materialCode"]))
                {
                    decimal dingdanshu = Convert.ToDecimal(g.Cells["gridColumndinggoushu"].Value);
                    decimal shuliang = Convert.ToDecimal(g.Cells["gridColumnNumber"].Value);
                    decimal gridColumnmoney = Convert.ToDecimal(g.Cells["gridColumnMoney"].Value);
                    decimal gridColumnshuie = Convert.ToDecimal(g.Cells["gridColumnshuie"].Value);
                    decimal gridColumnjiashuiheji = Convert.ToDecimal(g.Cells["gridColumnjiashuiheji"].Value);
                    decimal gridColumncaihouMoney = Convert.ToDecimal(g.Cells["gridColumncaihouMoney"].Value);
                    dingdanshu += dingdanshu;
                    shuliang += 1;
                    gridColumnmoney += gridColumnmoney;
                    gridColumnshuie += gridColumnshuie;
                    gridColumnjiashuiheji += gridColumnjiashuiheji;
                    gridColumncaihouMoney += gridColumncaihouMoney;

                    g.Cells["gridColumndinggoushu"].Value = dingdanshu;
                    g.Cells["gridColumnNumber"].Value = shuliang;
                    g.Cells["gridColumnMoney"].Value = gridColumnmoney;
                    g.Cells["gridColumnshuie"].Value = gridColumnshuie;
                    g.Cells["gridColumnjiashuiheji"].Value = gridColumnjiashuiheji;
                    g.Cells["gridColumncaihouMoney"].Value = gridColumncaihouMoney;
                    //统计数据
                    TongJi();
                    labtextboxTop5.Text = _PriceAndTaxMoney.ToString();
                    labtextboxTop3.Text = _PriceAndTaxMoney.ToString();
                    resizablePanelData.Visible = false;
                    return;
                }
                continue;
            }

            superGridControlShangPing.PrimaryGrid.Rows.Add(new GridRow(_storgeName, dt.Rows[0]["materialDaima"],
                dt.Rows[0]["name"],
                dt.Rows[0]["model"],
                dt.Rows[0]["barCode"],
                dt.Rows[0]["unit"],
                dt.Rows[0]["materialNumber"].ToString() == "" ? 1.0M : dt.Rows[0]["materialNumber"],
                dt.Rows[0]["materialNumber"].ToString() == "" ? 1.0M : dt.Rows[0]["materialNumber"],
                dt.Rows[0]["materialPrice"].ToString() == "" ? 0.0M : dt.Rows[0]["materialPrice"],
                dt.Rows[0]["discountRate"].ToString() == "" ? 0.0M : dt.Rows[0]["discountRate"],
                dt.Rows[0]["VATRate"].ToString() == "" ? 0.0M : dt.Rows[0]["VATRate"],
                dt.Rows[0]["discountMoney"].ToString() == "" ? 0.0M : dt.Rows[0]["discountMoney"],
                dt.Rows[0]["materialMoney"].ToString() == "" ? 0.0M : dt.Rows[0]["materialMoney"],
                dt.Rows[0]["tax"],
                dt.Rows[0]["purchaseAmount"].ToString() == "" ? 0.0M : dt.Rows[0]["purchaseAmount"],
                dt.Rows[0]["taxTotal"],
                dt.Rows[0]["createDate"].ToString(),
                dt.Rows[0]["qualityDate"],
                dt.Rows[0]["effectiveDate"],
                dt.Rows[0]["mainCode"],
                dt.Rows[0]["code"],
                dt.Rows[0]["remark"],
                _storgeCode,
                _shangPinCode
                ));
            if (dt.Rows[0]["isDouble"].ToString() == "0")
            {
                GridRow gridrow = (GridRow)superGridControlShangPing.PrimaryGrid.Rows[superGridControlShangPing.PrimaryGrid.Rows.Count - 2];
                gridrow.Cells["gridColumnNumber"].EditorType = typeof(GridDoubleInputEditControl);
            }
            TongJi();
            _purchaseMainCodel = null;
        }

        /// <summary>
        /// 统计数据
        /// </summary>
        private void TongJi()
        {
            try
            {
                GridRow grid = (GridRow)superGridControlShangPing.PrimaryGrid.Rows[ClickRowIndex];
                //逐行统计数据总数
                decimal tempAllDingDanShu = 0;
                decimal tempAllMaterialNumber = 0;
                decimal tempAllMoney = 0;
                decimal tempAllTaxMoney = 0;
                decimal tempAllPriceAndTax = 0;
                decimal tempAllCaiGouJine = 0;

                for (int i = 0; i < superGridControlShangPing.PrimaryGrid.Rows.Count - 1; i++)
                {
                    GridRow tempGR = superGridControlShangPing.PrimaryGrid.Rows[i] as GridRow;
                    tempAllDingDanShu += Convert.ToDecimal(tempGR["gridColumndinggoushu"].FormattedValue);
                    tempAllMaterialNumber += Convert.ToDecimal(tempGR["gridColumnNumber"].FormattedValue);
                    tempAllMoney += Convert.ToDecimal(tempGR["gridColumnMoney"].FormattedValue);
                    tempAllTaxMoney += Convert.ToDecimal(tempGR["gridColumnshuie"].FormattedValue);
                    tempAllPriceAndTax += Convert.ToDecimal(tempGR["gridColumnjiashuiheji"].FormattedValue);
                    tempAllCaiGouJine += Convert.ToDecimal(tempGR["gridColumncaihouMoney"].FormattedValue);
                }
                _dingGouShuLiang = tempAllDingDanShu;
                _MaterialNumber = tempAllMaterialNumber;
                _Money = tempAllMoney;
                _TaxMoney = tempAllTaxMoney;
                _PriceAndTaxMoney = tempAllPriceAndTax;
                _caiGoiJinE = tempAllCaiGouJine;
                grid = (GridRow)superGridControlShangPing.PrimaryGrid.LastSelectableRow;
                grid["gridColumndinggoushu"].Value = _dingGouShuLiang;
                grid["gridColumnNumber"].EditorType = typeof(GridDoubleIntInputEditControl);
                grid["gridColumnNumber"].Value = _MaterialNumber;
                grid["gridColumnMoney"].Value = _Money.ToString();
                grid["gridColumnshuie"].Value = _TaxMoney.ToString();
                grid["gridColumnjiashuiheji"].Value = _PriceAndTaxMoney.ToString();
                grid["gridColumncaihouMoney"].Value = _caiGoiJinE.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("错误代码：3312-逐行统计数据总数错误！" + ex.Message, "购货单温馨提示:");
            }

        }

        /// <summary>
        /// 本次收款
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ltxtBenCiShouKuan_Validated(object sender, EventArgs e)
        {
            try
            {
                decimal BenCiFuKuan = Convert.ToDecimal(labtextboxTop3.Text);
                decimal BenCiHeXiao = Convert.ToDecimal(labtextboxTop5.Text);
                if (BenCiFuKuan > BenCiHeXiao)
                {
                    MessageBox.Show("本次付款不能大于所付金额！");
                    labtextboxTop3.Focus();
                    labtextboxTop3.Text = BenCiHeXiao.ToString("0.00");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("错误代码：3313-验证本次付款金额出错！请检查:" + ex.Message, "购货单温馨提示！");
            }
        }

        /// <summary>
        /// 验证本次付款
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ltxtBenCiShouKuan_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                //小数点的处理。
                if ((int)e.KeyChar == 46)//小数点
                {
                    if (labtextboxTop3.Text.Length <= 0)
                        e.Handled = true;   //小数点不能在第一位
                    else
                    {
                        float f;
                        float oldf;
                        bool b1 = false, b2 = false;
                        b1 = float.TryParse(labtextboxTop3.Text, out oldf);
                        b2 = float.TryParse(labtextboxTop3.Text + e.KeyChar.ToString(), out f);
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
                MessageBox.Show("错误代码：3314-本次付款输入的值为非法字符，请重新输入:" + ex.Message, "购货单温馨提示！");
            }
        }

        /// <summary>
        /// 验证表格数据及统计
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void superGridControlShangPing_CellValidated(object sender, GridCellValidatedEventArgs e)
        {
            try
            {
                GridRow g = (GridRow)superGridControlShangPing.PrimaryGrid.Rows[1];
                if (g.Cells["gridColumnname"].Value == null || g.Cells["gridColumnname"].Value.ToString() == "")
                {
                    MessageBox.Show("请选择商品代码：");
                    g.Cells["gridColumnNumber"].Value = 0.00;
                    g.Cells["gridColumndanjia"].Value = 0.00;
                    g.Cells["gridColumnzhekoul"].Value = 100.00;
                    return;
                }
                //最后一行做统计行
                GridRow gr = e.GridPanel.Rows[e.GridCell.RowIndex] as GridRow;
                ////计算金额
                decimal number = Convert.ToDecimal(gr.Cells["gridColumnNumber"].FormattedValue);//数量
                decimal price = Convert.ToDecimal(gr.Cells["gridColumndanjia"].FormattedValue);//单价               
                decimal money = number * price;//金额
                gr.Cells["gridColumnMoney"].Value = money;
                decimal discountRate = Convert.ToDecimal(gr.Cells["gridColumnzhekoul"].FormattedValue);//折扣率
                decimal discountAfter = money * (discountRate / 100);
                decimal discountMoney = money - discountAfter;//折扣额
                gr.Cells["gridColumnzhekoue"].Value = discountMoney;
                decimal taxRate = Convert.ToDecimal(gr.Cells["gridColumnzengzhishiu"].FormattedValue);//增值税税率
                decimal rateMoney = money * (taxRate / 100);//税额
                gr.Cells["gridColumnshuie"].Value = rateMoney;
                decimal priceAndtax = money + rateMoney;//价税合计
                gr.Cells["gridColumnjiashuiheji"].Value = priceAndtax;

                TongJi();
                labtextboxTop7.Text = _purchaseCost.ToString("0.00");
                labtextboxTop5.Text = _PriceAndTaxMoney.ToString("0.00");
                labtextboxTop3.Text = _PriceAndTaxMoney.ToString("0.00");
            }
            catch (Exception ex)
            {
                MessageBox.Show("错误代码：3315-验证表格里的金额以及统计数量出错！请检查：" + ex.Message, "购货单温馨提示！");
            }
        }

        /// <summary>
        /// 保存按钮的封装函数
        /// </summary>
        private void Save()
        {
            if (isNUllValidate() == false)
            {
                return;
            }

            PurchaseMain purchasemain = new PurchaseMain();

            ////采购单商品列表
            List<PurchaseDetail> purchasedetailList = new List<PurchaseDetail>();
            try
            {
                purchasemain.code = XYEEncoding.strCodeHex(YanZhengCode());//采购单code
                purchasemain.supplierCode = XYEEncoding.strCodeHex(_supplierCode);//供应商code
                //供应商
                if (labtextboxTop2.Text != null || labtextboxTop2.Text != "")
                {
                    purchasemain.supplierName = XYEEncoding.strCodeHex(labtextboxTop2.Text.Trim());
                }
                else
                {
                    MessageBox.Show("供应商不能为空！");
                    labtextboxTop2.Focus();
                    return;
                }
                if (_jiaoHuoFangShi == "2")
                {
                    if (textBoxKuaiDiDanHao.Text == "")
                    {
                        MessageBox.Show("请选择快递公司和输入快递单号！");
                        textBoxKuaiDiDanHao.Focus();
                        return;
                    }
                }
                purchasemain.purchaseManCode = XYEEncoding.strCodeHex(_employeeCode);//采购员code
                //采购员
                if (ltxtbSalsMan.Text != null || ltxtbSalsMan.Text != "")
                {
                    purchasemain.salesMan = XYEEncoding.strCodeHex(ltxtbSalsMan.Text.Trim());
                }
                else
                {
                    MessageBox.Show("采购员不能为空！");
                    ltxtbSalsMan.Focus();
                    return;
                }
                //加急状态  0为不加急，1为加急
                if (checkBoxJiaoJi.Checked == true)
                {
                    purchasemain.urgentState = 1;
                }
                else
                {
                    purchasemain.urgentState = 0;
                }
                purchasemain.data = this.dateTimePicker1.Value;//开单日期
                purchasemain.type = XYEEncoding.strCodeHex(comboBoxExType.Text);//单据类别
                purchasemain.payMethod = XYEEncoding.strCodeHex(comboBoxExJieSuaType.Text);//结算方式
                purchasemain.payDate = this.dateTimePickerFuKuan.Value;
                purchasemain.accountCode = XYEEncoding.strCodeHex(_bankCode);//结算账户code
                purchasemain.logistics = XYEEncoding.strCodeHex(comboBoxEWuLiuType.Text);//物流类型
                purchasemain.logisticsCode = XYEEncoding.strCodeHex(textBoxKuaiDiDanHao.Text == null ? "" : textBoxKuaiDiDanHao.Text.ToString());//物流单号
                purchasemain.invoicedAmount = Convert.ToDecimal(textBoxYiKaiPiao.Text.ToString() == "" ? 0.0M : Convert.ToDecimal(textBoxYiKaiPiao.Text));//已开票金额
                purchasemain.unbilledAmount = Convert.ToDecimal(textBoxWeiKaiPiao.Text.ToString() == "" ? 0.0M : Convert.ToDecimal(textBoxWeiKaiPiao.Text));//未开票金额
                purchasemain.purchaseAmount = Convert.ToDecimal(labtextboxTop7.Text.ToString() == "" ? 0.0M : Convert.ToDecimal(labtextboxTop7.Text));//采购费用合计           
                purchasemain.remark = XYEEncoding.strCodeHex(labtextboxBotton2.Text == null ? "" : labtextboxBotton2.Text.ToString());//摘要    
                purchasemain.operationMan = XYEEncoding.strCodeHex(ltxtbMakeMan.Text == null ? "" : ltxtbMakeMan.Text.Trim());//制单人
                purchasemain.checkMan = XYEEncoding.strCodeHex(ltxtbShengHeMan.Text == null ? "" : ltxtbShengHeMan.Text.Trim());//审核人
                purchasemain.checkState = 0;//审核状态
                purchasemain.purchaseOrderState = 0;
                purchasemain.isPay = 0;
                purchasemain.putStorageState = 0;
                purchasemain.deliveryDate = DateTime.Now;
                purchasemain.logisticsPhone = "";
                purchasemain.oddMoney = 0;
                purchasemain.inMoney = 0;
                purchasemain.lastMoney = 0;
                purchasemain.examineDate = DateTime.Now;
                purchasemain.updateDate = DateTime.Now;
                purchasemain.reserved1 = "";
                purchasemain.reserved2 = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show("错误代码:3316-尝试创建购货单数据出错！请检查：" + ex.Message, "购货单温馨提示");
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
                    if (gr["gridColumnname"].Value != null)
                    {

                        i++;
                        PurchaseDetail purchaseDetail = new PurchaseDetail();
                        purchaseDetail.storageCode = XYEEncoding.strCodeHex(_storgeCode);//仓库code
                        //仓库名
                        if (gr["gridColumnStock"].Value != null || gr["gridColumnStock"].Value.ToString() != "")
                        {
                            purchaseDetail.storageName = XYEEncoding.strCodeHex(gr["gridColumnStock"].Value);
                        }
                        else
                        {
                            MessageBox.Show("仓库不能为空！");
                            return;
                        }
                        purchaseDetail.materialCode = XYEEncoding.strCodeHex(_shangPinCode);//商品code
                        //商品代码
                        if (gr["material"].Value != null || gr["material"].Value.ToString() != "")
                        {
                            purchaseDetail.storageName = XYEEncoding.strCodeHex(gr["material"].Value);
                        }
                        else
                        {
                            MessageBox.Show("商品代码不能为空！");
                            return;
                        }
                        //判断表格里的金额与实际值是否相符     
                        decimal money = Convert.ToDecimal(gr["gridColumnNumber"].Value) * Convert.ToDecimal(gr["gridColumndanjia"].Value);
                        if (money == Convert.ToDecimal(gr["gridColumnMoney"].Value))
                        {
                            purchaseDetail.money = Convert.ToDecimal(gr["gridColumnMoney"].Value);//金额
                        }
                        else
                        {
                            MessageBox.Show("表格里金额的值与实际值不符！请重新输入数量：");
                            return;
                        }
                        decimal discountAfter = money * (Convert.ToDecimal(gr["gridColumnzhekoul"].Value) / 100);
                        decimal discountMoney = money - discountAfter;
                        //判断表格里的折扣额与实际值是否相符
                        if (discountMoney == Convert.ToDecimal(gr["gridColumnzhekoue"].Value))
                        {
                            purchaseDetail.discountMoney = Convert.ToDecimal(gr["gridColumnzhekoue"].Value);//折扣额
                        }
                        else
                        {
                            MessageBox.Show("表格里折扣额的值与实际值不符！请重新输入折扣率：");
                            return;
                        }
                        ////判断表格里的税额与实际值是否相符
                        decimal rateMoney = money * (Convert.ToDecimal(gr["gridColumnzengzhishiu"].Value) / 100);
                        if (rateMoney == Convert.ToDecimal(gr["gridColumnshuie"].Value))
                        {
                            purchaseDetail.tax = Convert.ToDecimal(gr["gridColumnshuie"].Value);//税额
                        }
                        else
                        {
                            MessageBox.Show("表格里税额的值错误！");
                            return;
                        }
                        //判断表格里的价税合计与实际值是否相符
                        decimal jiashui = money + rateMoney;
                        if (jiashui == Convert.ToDecimal(gr["gridColumnjiashuiheji"].Value))
                        {
                            purchaseDetail.taxTotal = Convert.ToDecimal(gr["gridColumnjiashuiheji"].Value);//价税合计
                        }
                        else
                        {
                            MessageBox.Show("表格里价税合计的值错误！");
                            return;
                        }
                        purchaseDetail.purchaseCode = XYEEncoding.strCodeHex(this.textBoxOddNumbers.Text);//采购单单据code
                        purchaseDetail.code = XYEEncoding.strCodeHex(_purchaseMainCode + i.ToString());//采购单明细code
                        purchaseDetail.materialName = gr["gridColumnname"].Value == null ? "" : XYEEncoding.strCodeHex(gr["gridColumnname"].Value.ToString() == "");//商品名称
                        purchaseDetail.materialModel = gr["gridColumnModel"].Value == null ? "" : XYEEncoding.strCodeHex(gr["gridColumnModel"].Value.ToString() == "");//规格型号
                        purchaseDetail.unit = gr["gridColumnunit"].Value == null ? "" : XYEEncoding.strCodeHex(gr["gridColumnunit"].Value.ToString() == "");//单位
                        purchaseDetail.barCode = gr["gridColumntiaoxingma"].Value == null ? "" : XYEEncoding.strCodeHex(gr["gridColumntiaoxingma"].Value.ToString() == "");//条形码
                        purchaseDetail.number = Convert.ToDecimal(gr["gridColumnNumber"].Value.ToString() == "" ? 0.0M : Convert.ToDecimal(gr["gridColumnNumber"].Value));//数量
                        purchaseDetail.discountBeforePrice = Convert.ToDecimal(gr["gridColumndanjia"].Value.ToString() == "" ? 0.0M : Convert.ToDecimal(gr["gridColumndanjia"].Value));//单价                        
                        purchaseDetail.discount = Convert.ToDecimal(gr["gridColumnzhekoul"].Value.ToString() == "" ? 0.0M : Convert.ToDecimal(gr["gridColumnzhekoul"].Value));//折扣率                        
                        purchaseDetail.VATRate = Convert.ToDecimal(gr["gridColumnzengzhishiu"].Value.ToString() == "" ? 0.0M : Convert.ToDecimal(gr["gridColumnzengzhishiu"].Value));//增值税税率
                        purchaseDetail.remark = XYEEncoding.strCodeHex(gr["gridColumnbeizhu"].Value == null ? "" : gr["gridColumnbeizhu"].Value.ToString());//备注
                        purchaseDetail.productionDate = gr["gridColumnshengchandate"].Value == DBNull.Value ? Convert.ToDateTime("1990-01-01") : Convert.ToDateTime(gr["gridColumnshengchandate"].Value);//生产日期
                        purchaseDetail.qualityDate = Convert.ToDecimal(gr["gridColumnbaozhiqi"].Value.ToString() == "" ? 0.0M : Convert.ToDecimal(gr["gridColumnbaozhiqi"].Value));//保质期
                        purchaseDetail.effectiveDate = gr["gridColumnyouxiaoqi"].Value == DBNull.Value ? Convert.ToDateTime("1990-01-01") : Convert.ToDateTime(gr["gridColumnyouxiaoqi"].Value);//有限期至

                        GridRow dr = superGridControlShangPing.PrimaryGrid.Rows[0] as GridRow;
                        purchasedetailList.Add(purchaseDetail);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("错误代码：3317-尝试创建购货单商品详细数据出错!请检查:" + ex.Message, "购货单温馨提示");
                return;
            }

            ////增加一条采购单和采购单详细数据
            object purchaseResult = purchaseMianInterface.AddOrUpdateToMainOrDetail(purchasemain, purchasedetailList);
            if (purchaseResult != null)
            {
                MessageBox.Show("新增购货单数据成功", "购货单温馨提示");
            }
        }

        /// <summary>
        /// 审核按钮的封装函数
        /// </summary>
        private void Review()
        {
            if (isNUllValidate() == false)
            {
                return;
            }

            ////采购单
            PurchaseMain purchasemain = new PurchaseMain();
            ////采购单商品列表
            List<PurchaseDetail> purchasedetailList = new List<PurchaseDetail>();
            try
            {
                purchasemain.code = XYEEncoding.strCodeHex(_purchaseMainCode);//采购单code
                purchasemain.supplierCode = XYEEncoding.strCodeHex(_supplierCode);//供应商code
                //供应商
                if (labtextboxTop2.Text != null || labtextboxTop2.Text != "")
                {
                    purchasemain.supplierName = XYEEncoding.strCodeHex(labtextboxTop2.Text.Trim());
                }
                else
                {
                    MessageBox.Show("供应商不能为空！");
                    labtextboxTop2.Focus();
                    return;
                }
                //加急状态  0为不加急，1为加急
                if (checkBoxJiaoJi.Checked == true)
                {
                    purchasemain.urgentState = 1;
                }
                else
                {
                    purchasemain.urgentState = 0;
                }
                purchasemain.purchaseManCode = XYEEncoding.strCodeHex(_employeeCode);//采购员code
                //采购员
                if (ltxtbSalsMan.Text != null || ltxtbSalsMan.Text != "")
                {
                    purchasemain.salesMan = XYEEncoding.strCodeHex(ltxtbSalsMan.Text.Trim());
                }
                else
                {
                    MessageBox.Show("采购员不能为空！");
                    ltxtbSalsMan.Focus();
                    return;
                }
                purchasemain.data = this.dateTimePicker1.Value;//开单日期
                purchasemain.type = XYEEncoding.strCodeHex(comboBoxExType.Text);//单据类别
                purchasemain.payMethod = XYEEncoding.strCodeHex(comboBoxExJieSuaType.Text);//结算方式
                purchasemain.payDate = this.dateTimePickerFuKuan.Value;
                purchasemain.accountCode = XYEEncoding.strCodeHex(_bankCode);//结算账户code
                purchasemain.logistics = XYEEncoding.strCodeHex(comboBoxEWuLiuType.Text);//物流类型
                purchasemain.logisticsCode = XYEEncoding.strCodeHex(textBoxKuaiDiDanHao.Text == null ? "" : textBoxKuaiDiDanHao.Text.ToString());//物流单号
                purchasemain.invoicedAmount = Convert.ToDecimal(textBoxYiKaiPiao.Text.ToString() == "" ? 0.0M : Convert.ToDecimal(textBoxYiKaiPiao.Text));//已开票金额
                purchasemain.unbilledAmount = Convert.ToDecimal(textBoxWeiKaiPiao.Text.ToString() == "" ? 0.0M : Convert.ToDecimal(textBoxWeiKaiPiao.Text));//未开票金额
                purchasemain.purchaseAmount = Convert.ToDecimal(labtextboxTop7.Text.ToString() == "" ? 0.0M : Convert.ToDecimal(labtextboxTop7.Text));//采购费用合计           
                purchasemain.remark = XYEEncoding.strCodeHex(labtextboxBotton2.Text == null ? "" : labtextboxBotton2.Text.ToString());//摘要    
                purchasemain.operationMan = XYEEncoding.strCodeHex(ltxtbMakeMan.Text == null ? "" : ltxtbMakeMan.Text.Trim());//制单人
                purchasemain.checkMan = XYEEncoding.strCodeHex(ltxtbShengHeMan.Text == null ? "" : ltxtbShengHeMan.Text.Trim());//审核人
                purchasemain.checkState = 1;//审核状态

                purchasemain.purchaseOrderState = 0;
                purchasemain.isPay = 0;
                purchasemain.putStorageState = 0;
                purchasemain.deliveryDate = DateTime.Now;
                purchasemain.logisticsPhone = "";
                purchasemain.oddMoney = 0;
                purchasemain.inMoney = 0;
                purchasemain.lastMoney = 0;
                purchasemain.examineDate = DateTime.Now;
                purchasemain.updateDate = DateTime.Now;
                purchasemain.reserved1 = "";
                purchasemain.reserved2 = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show("错误代码:3318-尝试创建并审核购货单数据出错！请检查：" + ex.Message, "购货单温馨提示");
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
                    if (gr["gridColumnname"].Value != null)
                    {
                        i++;
                        PurchaseDetail purchaseDetail = new PurchaseDetail();
                        purchaseDetail.storageCode = XYEEncoding.strCodeHex(_storgeCode);//仓库code
                        //仓库名
                        if (gr["gridColumnStock"].Value != null || gr["gridColumnStock"].Value.ToString() != "")
                        {
                            purchaseDetail.storageName = XYEEncoding.strCodeHex(gr["gridColumnStock"].Value);
                        }
                        else
                        {
                            MessageBox.Show("仓库不能为空！");
                            return;
                        }
                        purchaseDetail.materialCode = XYEEncoding.strCodeHex(_shangPinCode);//商品code
                        //商品代码
                        if (gr["material"].Value != null || gr["material"].Value.ToString() != "")
                        {
                            purchaseDetail.storageName = XYEEncoding.strCodeHex(gr["material"].Value);
                        }
                        else
                        {
                            MessageBox.Show("商品代码不能为空！");
                            return;
                        }
                        //判断表格里的金额与实际值是否相符     
                        decimal money = Convert.ToDecimal(gr["gridColumnNumber"].Value) * Convert.ToDecimal(gr["gridColumndanjia"].Value);
                        if (money == Convert.ToDecimal(gr["gridColumnMoney"].Value))
                        {
                            purchaseDetail.money = Convert.ToDecimal(gr["gridColumnMoney"].Value);//金额
                        }
                        else
                        {
                            MessageBox.Show("表格里计算金额的值与实际值不符！请重新输入数量：");
                            return;
                        }
                        decimal discountAfter = money * (Convert.ToDecimal(gr["gridColumnzhekoul"].Value) / 100);
                        decimal discountMoney = money - discountAfter;
                        //判断表格里的折扣额与实际值是否相符
                        if (discountMoney == Convert.ToDecimal(gr["gridColumnzhekoue"].Value))
                        {
                            purchaseDetail.discountMoney = Convert.ToDecimal(gr["gridColumnzhekoue"].Value);//折扣额
                        }
                        else
                        {
                            MessageBox.Show("表格里计算折扣额的值与实际值！请重新输入折扣率：");
                            return;
                        }
                        ////判断表格里的税额与实际值是否相符
                        decimal rateMoney = money * (Convert.ToDecimal(gr["gridColumnzengzhishiu"].Value) / 100);
                        if (rateMoney == Convert.ToDecimal(gr["gridColumnshuie"].Value))
                        {
                            purchaseDetail.tax = Convert.ToDecimal(gr["gridColumnshuie"].Value);//税额
                        }
                        else
                        {
                            MessageBox.Show("表格里税额的值错误！");
                            return;
                        }
                        //判断表格里的价税合计与实际值是否相符
                        decimal jiashui = money + rateMoney;
                        if (jiashui == Convert.ToDecimal(gr["gridColumnjiashuiheji"].Value))
                        {
                            purchaseDetail.taxTotal = Convert.ToDecimal(gr["gridColumnjiashuiheji"].Value);//价税合计
                        }
                        else
                        {
                            MessageBox.Show("表格里价税合计的值错误！");
                            return;
                        }
                        purchaseDetail.purchaseCode = XYEEncoding.strCodeHex(this.textBoxOddNumbers.Text);//采购单单据code
                        purchaseDetail.code = XYEEncoding.strCodeHex(_purchaseMainCode + i.ToString());//采购单明细code
                        purchaseDetail.materialName = gr["gridColumnname"].Value == null ? "" : XYEEncoding.strCodeHex(gr["gridColumnname"].Value.ToString() == "");//商品名称
                        purchaseDetail.materialModel = gr["gridColumnModel"].Value == null ? "" : XYEEncoding.strCodeHex(gr["gridColumnModel"].Value.ToString() == "");//规格型号
                        purchaseDetail.unit = gr["gridColumnunit"].Value == null ? "" : XYEEncoding.strCodeHex(gr["gridColumnunit"].Value.ToString() == "");//单位
                        purchaseDetail.barCode = gr["gridColumntiaoxingma"].Value == null ? "" : XYEEncoding.strCodeHex(gr["gridColumntiaoxingma"].Value.ToString() == "");//条形码
                        purchaseDetail.number = Convert.ToDecimal(gr["gridColumnNumber"].Value.ToString() == "" ? 0.0M : Convert.ToDecimal(gr["gridColumnNumber"].Value));//数量
                        purchaseDetail.discountBeforePrice = Convert.ToDecimal(gr["gridColumndanjia"].Value.ToString() == "" ? 0.0M : Convert.ToDecimal(gr["gridColumndanjia"].Value));//单价                        
                        purchaseDetail.discount = Convert.ToDecimal(gr["gridColumnzhekoul"].Value.ToString() == "" ? 0.0M : Convert.ToDecimal(gr["gridColumnzhekoul"].Value));//折扣率                        
                        purchaseDetail.VATRate = Convert.ToDecimal(gr["gridColumnzengzhishiu"].Value.ToString() == "" ? 0.0M : Convert.ToDecimal(gr["gridColumnzengzhishiu"].Value));//增值税税率
                        purchaseDetail.remark = XYEEncoding.strCodeHex(gr["gridColumnbeizhu"].Value == null ? "" : gr["gridColumnbeizhu"].Value.ToString());//备注
                        purchaseDetail.productionDate = gr["gridColumnshengchandate"].Value == DBNull.Value ? Convert.ToDateTime("1990-01-01") : Convert.ToDateTime(gr["gridColumnshengchandate"].Value);//生产日期
                        purchaseDetail.qualityDate = Convert.ToDecimal(gr["gridColumnbaozhiqi"].Value.ToString() == "" ? 0.0M : Convert.ToDecimal(gr["gridColumnbaozhiqi"].Value));//保质期
                        purchaseDetail.effectiveDate = gr["gridColumnyouxiaoqi"].Value == DBNull.Value ? Convert.ToDateTime("1990-01-01") : Convert.ToDateTime(gr["gridColumnyouxiaoqi"].Value);//有限期至

                        GridRow dr = superGridControlShangPing.PrimaryGrid.Rows[0] as GridRow;
                        purchasedetailList.Add(purchaseDetail);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("错误代码：3319-尝试创建并审核购货单商品详细数据出错!请检查:" + ex.Message, "购货单温馨提示");
                return;
            }

            ////增加一条采购单和采购单详细数据
            object purchaseResult = purchaseMianInterface.AddOrUpdateToMainOrDetail(purchasemain, purchasedetailList);
            if (purchaseResult != null)
            {
                pictureBoxShengHe.Visible = true;
                InitForm();
                MessageBox.Show("新增并审核购货单数据成功", "购货单温馨提示");
            }
        }

        /// <summary>
        /// 验证Code是否重复函数
        /// </summary>
        /// <returns></returns>
        private string YanZhengCode()
        {
            if (purchaseMianInterface.Exists(XYEEncoding.strCodeHex(_purchaseMainCode)))
            {
                _purchaseMainCode = BuildCode.ModuleCode("PCT");
            }
            else
            {
                _purchaseMainCode = textBoxOddNumbers.Text;
            }

            return _purchaseMainCode;
        }

        /// <summary>
        /// 小表格的点击绑定事件函数
        /// </summary>
        private void DataGridViewTableClick()
        {
            try
            {
                //供应商
                if (_Click == 1 || _Click == 7)
                {
                    _supplierCode = dataGridViewFuJia.Rows[dataGridViewFuJia.CurrentRow.Index].Cells["code"].Value.ToString();//供应商code
                    string name = dataGridViewFuJia.Rows[dataGridViewFuJia.CurrentRow.Index].Cells["name"].Value.ToString();//供应商名称
                    string linkman = dataGridViewFuJia.Rows[dataGridViewFuJia.CurrentRow.Index].Cells["linkMan"].Value.ToString();//联系人
                    string phone = dataGridViewFuJia.Rows[dataGridViewFuJia.CurrentRow.Index].Cells["mobilePhone"].Value.ToString();//电话
                    labtextboxTop2.Text = name;
                    labtextboxTop8.Text = linkman;
                    labtextboxTop9.Text = phone;
                    resizablePanel1.Visible = false;
                }
                //仓库
                if (_Click == 3 || _Click == 8)
                {
                    GridRow gr = (GridRow)superGridControlShangPing.PrimaryGrid.Rows[ClickRowIndex];
                    string code = dataGridViewFuJia.Rows[dataGridViewFuJia.CurrentRow.Index].Cells["code"].Value.ToString();
                    string Name = dataGridViewFuJia.Rows[dataGridViewFuJia.CurrentRow.Index].Cells["name"].Value.ToString();
                    gr.Cells["gridColumnStock"].Value = Name;
                    gr.Cells["gridColumncode"].Value = code;
                    _ClickStorageList = new KeyValuePair<string, string>(code, Name);
                    _storgeCode = code;
                    _storgeName = Name;
                    resizablePanel1.Visible = false;
                }
                //销售员
                if (_Click == 2 || _Click == 5)
                {
                    _employeeCode = dataGridViewFuJia.Rows[dataGridViewFuJia.CurrentRow.Index].Cells["code"].Value.ToString();//销售员code
                    string name = dataGridViewFuJia.Rows[dataGridViewFuJia.CurrentRow.Index].Cells["name"].Value.ToString();//销售员
                    ltxtbSalsMan.Text = name;
                    resizablePanel1.Visible = false;
                }
                //结算账户
                if (_Click == 4 || _Click == 6)
                {

                    _bankCode = dataGridViewFuJia.Rows[dataGridViewFuJia.CurrentRow.Index].Cells["code"].Value.ToString();
                    string Name = dataGridViewFuJia.Rows[dataGridViewFuJia.CurrentRow.Index].Cells["openBank"].Value.ToString();
                    labtextboxTop4.Text = Name;
                    resizablePanel1.Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("错误代码：3302-按回车绑定供应商、采购员、结算账户数据错误！请检查：" + ex.Message, "购货单温馨提示！");
            }
        }

        /// <summary>
        /// 快捷方式
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PurchaseTicketForm_KeyDown(object sender, KeyEventArgs e)
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
    }
}

