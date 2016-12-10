using DevComponents.DotNetBar.SuperGrid;
using HelperUtility;
using HelperUtility.Encrypt;
using InterfaceLayer.Base;
using InterfaceLayer.Sales;
using Model.Sales;
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
    public partial class SalesOrderForm : TestForm
    {
        public SalesOrderForm()
        {
            InitializeComponent();
        }

        #region 调用接口以及加密解密方法
        CodingHelper ch = new CodingHelper();
        ClientInterface client = new ClientInterface();//客户
        EmpolyeeInterface employee = new EmpolyeeInterface();//员工  
        StorageInterface storage = new StorageInterface();//交货地点
        MaterialInterface materialInterface = new MaterialInterface();
        SalesOrderInterface saleorderinterface = new SalesOrderInterface();
        #endregion

        #region 数据字段

        /// <summary>
        /// 所有客户
        /// </summary>
        private DataTable _AllClient = null;
        /// <summary>
        /// 所有销售员
        /// </summary>
        private DataTable _AllEmployee = null;
        /// <summary>
        /// 所有仓库
        /// </summary>
        private DataTable _AllStorage = null;
        /// <summary>
        /// 点击的项,1客户  2为销售员  3为仓库   
        /// </summary>
        private int _Click = 0;
        /// <summary>
        /// 保存客户Code
        /// </summary>
        private string _clientCode;
        /// <summary>
        /// 保存销售员Code
        /// </summary>
        private string _employeeCode;
        /// <summary>
        /// 保存仓库Code
        /// </summary>
        private string _storgeCode;
        /// <summary>
        /// 所有商品列表
        /// </summary>
        private DataTable _AllMaterial = null;
        /// <summary>
        /// 商品code
        /// </summary>
        private string _materialCode;
        /// <summary>
        /// 统计数量
        /// </summary>
        private decimal _Materialnumber;
        private decimal _MaterialNumber;
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
        /// 销售订单code
        /// </summary>
        private string _SalesOrderCode;
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
                                 Color.White,
                                 1,
                                 ButtonBorderStyle.Solid);
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
            gr.Cells["material"].Value = "合计";
            gr.Cells["material"].CellStyles.Default.Alignment =
                DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleCenter;
            gr.Cells["dinggouNumber"].Value = 0;
            gr.Cells["dinggouNumber"].EditorType = typeof(GridDoubleInputEditControl);
            gr.Cells["dinggouNumber"].CellStyles.Default.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleCenter;
            gr.Cells["dinggouNumber"].CellStyles.Default.Background.Color1 = Color.Orange;
            gr.Cells["money"].Value = 0;
            gr.Cells["money"].CellStyles.Default.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleCenter;
            gr.Cells["money"].CellStyles.Default.Background.Color1 = Color.Orange;
            gr.Cells["TaxMoney"].Value = 0;
            gr.Cells["TaxMoney"].CellStyles.Default.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleCenter;
            gr.Cells["TaxMoney"].CellStyles.Default.Background.Color1 = Color.Orange;
            gr.Cells["priceANDtax"].Value = 0;
            gr.Cells["priceANDtax"].CellStyles.Default.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleCenter;
            gr.Cells["priceANDtax"].CellStyles.Default.Background.Color1 = Color.Orange;
            #region  合计行不能点击
            gr.Cells["material"].AllowSelection = false;
            gr.Cells["name"].AllowSelection = false;
            gr.Cells["model"].AllowSelection = false;
            gr.Cells["barcode"].AllowSelection = false;
            gr.Cells["unit"].AllowSelection = false;
            gr.Cells["dinggouNumber"].AllowSelection = false;
            gr.Cells["price"].AllowSelection = false;
            gr.Cells["money"].AllowSelection = false;
            gr.Cells["DiscountRate"].AllowSelection = false;
            gr.Cells["DiscountMoney"].AllowSelection = false;
            gr.Cells["TaxRate"].AllowSelection = false;
            gr.Cells["TaxMoney"].AllowSelection = false;
            gr.Cells["priceANDtax"].AllowSelection = false;
            gr.Cells["remark"].AllowSelection = false;
            #endregion
        }

        /// <summary>
        /// 非空验证
        /// </summary>
        private bool isNUllValidate()
        {
            if (labtxtDanJuType.Text.Trim() == null || labtxtDanJuType.Text == "")
            {
                MessageBox.Show("客户不能为空！");
                labtxtDanJuType.Focus();
                return false;
            }
            if (labtextboxTop2.Text.Trim() == null || labtextboxTop2.Text == "")
            {
                MessageBox.Show("联系人不能为空！");
                labtextboxTop2.Focus();
                return false;
            }
            if (labtextboxTop3.Text.Trim() == null || labtextboxTop3.Text == "")
            {
                MessageBox.Show("电话不能为空！");
                labtextboxTop3.Focus();
                return false;
            }
            if (cboMethod.Text.Trim() == null || cboMethod.Text == "")
            {
                MessageBox.Show("交货方式不能为空！");
                cboMethod.Focus();
                return false;
            }
            if (labtextboxTop5.Text.Trim() == null || labtextboxTop5.Text == "")
            {
                MessageBox.Show("交货地点不能为空！");
                labtextboxTop5.Focus();
                return false;
            }
            GridRow gr = (GridRow)superGridControlShangPing.PrimaryGrid.Rows[1];
            if (gr.Cells["name"].Value == null || gr.Cells["name"].Value.ToString() == "")
            {
                MessageBox.Show("商品代码不能为空！");
                superGridControlShangPing.Focus();
                return false;
            }
            if (ltxtbSalsMan.Text.Trim() == null || ltxtbSalsMan.Text == "")
            {
                MessageBox.Show("销售员不能为空！");
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

                    dgvc = new DataGridViewTextBoxColumn();
                    dgvc.Name = "mobilePhone";
                    dgvc.HeaderText = "电话";
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
                    dataGridViewFuJia.DataSource = ch.DataTableReCoding(_AllClient);
                    resizablePanel1.Visible = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("错误代码：1106-尝试点击客户数据出错或者无数据！请检查：" + ex.Message, "销售订单温馨提示！");
            }
        }

        /// <summary>
        /// 初始化销售员
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
                MessageBox.Show("错误代码：1107-尝试点击销售员数据出错或者无数据！请检查：" + ex.Message, "销售订单温馨提示！");
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

                    resizablePanel1.Location = new Point(560, 190);
                    //查询仓库的方法
                    dataGridViewFuJia.DataSource = ch.DataTableReCoding(_AllStorage);
                    resizablePanel1.Visible = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("错误代码：1108-尝试点击交货地点数据出错或者无数据！请检查：" + ex.Message, "销售订单温馨提示！");
            }
        }

        /// <summary>
        /// 初始化商品下拉别表的数据
        /// </summary>
        private void InitMaterialDataGridView()
        {
            try
            {
                dataGridViewShangPing.DataSource = null;
                dataGridViewShangPing.Columns.Clear();
                DataGridViewTextBoxColumn dgvc = new DataGridViewTextBoxColumn();
                dgvc.Name = "code";
                dgvc.Visible = false;
                dgvc.HeaderText = "code";
                dgvc.DataPropertyName = "code";
                dgvc.SortMode = DataGridViewColumnSortMode.NotSortable;
                dataGridViewShangPing.Columns.Add(dgvc);

                dgvc = new DataGridViewTextBoxColumn();
                dgvc.Name = "materialDaima";
                dgvc.HeaderText = "商品代码";
                dgvc.DataPropertyName = "materialDaima";
                dgvc.SortMode = DataGridViewColumnSortMode.NotSortable;
                dataGridViewShangPing.Columns.Add(dgvc);

                dgvc = new DataGridViewTextBoxColumn();
                dgvc.Name = "name";
                dgvc.HeaderText = "商品名称";
                dgvc.DataPropertyName = "name";
                dgvc.SortMode = DataGridViewColumnSortMode.NotSortable;
                dataGridViewShangPing.Columns.Add(dgvc);

                dgvc = new DataGridViewTextBoxColumn();
                dgvc.Name = "model";
                dgvc.Visible = false;
                dgvc.HeaderText = "规格型号";
                dgvc.DataPropertyName = "model";
                dgvc.SortMode = DataGridViewColumnSortMode.NotSortable;
                dataGridViewShangPing.Columns.Add(dgvc);

                dgvc = new DataGridViewTextBoxColumn();
                dgvc.Name = "barCode";
                dgvc.Visible = false;
                dgvc.HeaderText = "条形码";
                dgvc.DataPropertyName = "barCode";
                dgvc.SortMode = DataGridViewColumnSortMode.NotSortable;
                dataGridViewShangPing.Columns.Add(dgvc);

                dgvc = new DataGridViewTextBoxColumn();
                dgvc.Name = "unit";
                dgvc.Visible = false;
                dgvc.HeaderText = "单位";
                dgvc.DataPropertyName = "unit";
                dgvc.SortMode = DataGridViewColumnSortMode.NotSortable;
                dataGridViewShangPing.Columns.Add(dgvc);

                dgvc = new DataGridViewTextBoxColumn();
                dgvc.Name = "price";
                dgvc.Visible = false;
                dgvc.HeaderText = "单价";
                dgvc.DataPropertyName = "price";
                dgvc.SortMode = DataGridViewColumnSortMode.NotSortable;
                dataGridViewShangPing.Columns.Add(dgvc);

                dgvc = new DataGridViewTextBoxColumn();
                dgvc.Name = "remark";
                dgvc.Visible = false;
                dgvc.HeaderText = "备注";
                dgvc.DataPropertyName = "remark";
                dgvc.SortMode = DataGridViewColumnSortMode.NotSortable;
                dataGridViewShangPing.Columns.Add(dgvc);

                dgvc = new DataGridViewTextBoxColumn();
                dgvc.Name = "isDouble";
                dgvc.Visible = false;
                dgvc.HeaderText = "是否可输入小数点";
                dgvc.DataPropertyName = "isDouble";
                dgvc.SortMode = DataGridViewColumnSortMode.NotSortable;
                dataGridViewShangPing.Columns.Add(dgvc);
            }
            catch (Exception ex)
            {
                MessageBox.Show("初始化商品列表失败，请检查：" + ex.Message);
            }
        }

        /// <summary>
        /// 标示那个控件不可用
        /// </summary>
        private void InitForm()
        {
            labTop1.ForeColor = Color.Gray;
            labtxtDanJuType.Border.BorderBottomColor = Color.Gray;
            labtxtDanJuType.ForeColor = Color.Gray;
            labtxtDanJuType.ReadOnly = true;
            labTop2.ForeColor = Color.Gray;
            labtextboxTop2.Border.BorderBottomColor = Color.Gray;
            labtextboxTop2.ForeColor = Color.Red;
            labtextboxTop2.ReadOnly = true;
            labTop3.ForeColor = Color.Gray;
            labtextboxTop3.Border.BorderBottomColor = Color.Gray;
            labtextboxTop3.ForeColor = Color.Gray;
            labtextboxTop3.ReadOnly = true;
            labTop4.ForeColor = Color.Gray;
            cboMethod.BackColor = Color.Gray;
            cboMethod.ForeColor = Color.Gray;
            cboMethod.Enabled = false;
            labTop5.ForeColor = Color.Gray;
            labtextboxTop5.Border.BorderBottomColor = Color.Gray;
            labtextboxTop5.ForeColor = Color.Gray;
            labtextboxTop5.ReadOnly = true;
            labTop6.ForeColor = Color.Gray;
            dateTimePicker2.Enabled = false;
            dateTimePicker2.CalendarForeColor = Color.Gray;
            labTop7.ForeColor = Color.Gray;
            labtextboxTop7.Border.BorderBottomColor = Color.Gray;
            labtextboxTop7.ForeColor = Color.Gray;
            labtextboxTop7.ReadOnly = true;
            labTop8.ForeColor = Color.Gray;
            labtextboxTop8.Border.BorderBottomColor = Color.Gray;
            labtextboxTop8.ForeColor = Color.Gray;
            labtextboxTop8.ReadOnly = true;
            labTop9.ForeColor = Color.Gray;
            labtextboxTop9.Border.BorderBottomColor = Color.Gray;
            labtextboxTop9.ForeColor = Color.Gray;
            labtextboxTop9.ReadOnly = true;
            textBoxOddNumbers.BackColor = Color.FromArgb(240, 240, 240);
            this.panel2.BackColor = Color.FromArgb(240, 240, 240);
            this.panel5.BackColor = Color.FromArgb(240, 240, 240);
            this.superGridControlShangPing.BackColor = Color.Gray;
            this.superGridControlShangPing.Enabled = false;
            ltxtbSalsMan.ReadOnly = true;
            ltxtbMakeMan.ReadOnly = true;
            ltxtbShengHeMan.ReadOnly = true;
            picShengHe.Visible = true;
            picShengHe.Parent = pictureBoxtitle;
            dateTimePicker1.Enabled = false;
            labeldata.ForeColor = Color.Gray;
            labelprie.ForeColor = Color.Gray;
            labelprie.BackColor = Color.FromArgb(240, 240, 240);
        }

        #endregion

        /// <summary>
        /// 窗体加载事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SalesOrderForm_Load(object sender, EventArgs e)
        {
            try
            {
                //客户
                _AllClient = client.GetClientByBool(false);
                //销售员
                _AllEmployee = employee.SelSupplierTable(false);
                //仓库
                _AllStorage = storage.GetList(00, "");
                superGridControlShangPing.PrimaryGrid.SortCycle = SortCycle.AscDesc;    //排序方式范围
                superGridControlShangPing.PrimaryGrid.AddSort(superGridControlShangPing.PrimaryGrid.Columns[0], SortDirection.Ascending);//设置排序列和排序方式
                superGridControlShangPing.PrimaryGrid.ShowRowGridIndex = true;//显示行号

                #region 初始化窗体
                cboMethod.SelectedIndex = 0;
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

                //订购数量
                GridIntegerInputEditControl gdiecNumber = superGridControlShangPing.PrimaryGrid.Columns["dinggouNumber"].EditControl as GridIntegerInputEditControl;
                gdiecNumber.MinValue = 1;
                gdiecNumber.MaxValue = 999999999;
                //单价
                GridDoubleInputEditControl gdiecPrice = superGridControlShangPing.PrimaryGrid.Columns["price"].EditControl as GridDoubleInputEditControl;
                gdiecNumber.MinValue = 1;
                gdiecNumber.MaxValue = 999999999;
                //折扣率
                GridDoubleInputEditControl gdiecDiscountRate = superGridControlShangPing.PrimaryGrid.Columns["DiscountRate"].EditControl as GridDoubleInputEditControl;
                gdiecNumber.MinValue = 1;
                gdiecNumber.MaxValue = 100;

                //生成销售订单code和显示条形码
                _SalesOrderCode = BuildCode.ModuleCode("SOR");
                textBoxOddNumbers.Text = _SalesOrderCode;
                barcodeXYE.Code128 _Code = new barcodeXYE.Code128();
                _Code.ValueFont = new Font("微软雅黑", 20);
                System.Drawing.Bitmap imgTemp = _Code.GetCodeImage(textBoxOddNumbers.Text, barcodeXYE.Code128.Encode.Code128A);
                pictureBoxBarCode.Image = imgTemp;

                //绑定事件 双击事填充内容并隐藏列表
                dataGridViewFuJia.CellDoubleClick += dataGridViewFuJia_CellDoubleClick;
                dataGridViewShangPing.CellDoubleClick += dataGridViewShangPing_CellDoubleClick;

                toolStripBtnSave.Click += toolStripBtnSave_Click;//保存按钮
                toolStripBtnShengHe.Click += toolStripBtnShengHe_Click;//审核按钮
                dataGridViewFuJia.KeyDown += DataGridViewFuJia_KeyDown;
            }
            catch (Exception ex)
            {

                MessageBox.Show("错误代码：1101-窗体加载时，初始化数据错误！请检查：" + ex.Message);
                this.Close();
                return;
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
        /// 保存按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripBtnSave_Click(object sender, EventArgs e)
        {
            Save();
        }

        #region  调用的函数

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
            //SalesOrderInterface saleorderinterface = new SalesOrderInterface();
            //销售订单
            SalesOrder salesorder = new SalesOrder();
            //销售订单商品列表
            List<SalesOrderDetail> salesorderList = new List<SalesOrderDetail>();
            try
            {
                salesorder.code = XYEEncoding.strCodeHex(validateCode());//销售订单Code           
                //客户code
                if (labtxtDanJuType.Text != null || labtxtDanJuType.Text.Trim() != "")
                {
                    salesorder.clientCode = XYEEncoding.strCodeHex(_clientCode);
                }
                else
                {
                    MessageBox.Show("客户不能为空！");
                    labtxtDanJuType.Focus();
                    return;
                }
                //判断交货地点是否为空
                if (labtextboxTop5.Text.Trim() != null || labtextboxTop5.Text != "")
                {
                    salesorder.deliversLocation = XYEEncoding.strCodeHex(labtextboxTop5.Text);//交货地点
                }
                else
                {
                    MessageBox.Show("交货地点不能为空！");
                    labtextboxTop5.Focus();
                    return;
                }
                //判断已收订金是否为空
                if (labtextboxTop7.Text == null || labtextboxTop7.Text == "")
                {
                    salesorder.depositReceived = Convert.ToDecimal(0.00);
                }
                else
                {
                    salesorder.depositReceived = Convert.ToDecimal(labtextboxTop7.Text);
                }
                //判断销售员是否为空
                if (ltxtbSalsMan.Text.Trim() != null || ltxtbSalsMan.Text != "")
                {
                    salesorder.operation = XYEEncoding.strCodeHex(ltxtbSalsMan.Text);//销售员                 
                }
                else
                {
                    MessageBox.Show("销售员不能为空！");
                    ltxtbSalsMan.Focus();
                    return;
                }
                switch (cboMethod.Text.Trim())//交货方式
                {
                    case "提货":
                        salesorder.deliversMethod = 0;
                        break;
                    case "送货":
                        salesorder.deliversMethod = 1;
                        break;
                    case "发货":
                        salesorder.deliversMethod = 2;
                        break;
                }
                salesorder.date = this.dateTimePicker1.Value;//开单日期
                salesorder.deliversDate = dateTimePicker2.Value;//交货日期
                salesorder.remark = XYEEncoding.strCodeHex(labtextboxTop9.Text);//摘要           
                salesorder.makeMan = XYEEncoding.strCodeHex(ltxtbMakeMan.Text);//制单人
                salesorder.examine = XYEEncoding.strCodeHex(ltxtbShengHeMan.Text);//审核人
                salesorder.checkState = 0;//审核状态
            }
            catch (Exception ex)
            {
                MessageBox.Show("错误代码:1102-尝试创建销售订单数据出错！请检查：" + ex.Message, "销售订单温馨提示");
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
                    if (gr["name"].Value != null)
                    {

                        i++;
                        SalesOrderDetail salesorderDetail = new SalesOrderDetail();
                        salesorderDetail.mainCode = XYEEncoding.strCodeHex(this.textBoxOddNumbers.Text);//销售订单单据Code
                        salesorderDetail.code = XYEEncoding.strCodeHex(_SalesOrderCode + i.ToString());//销售订单明细Code
                        //物料code
                        if (gr.Cells["name"].Value != null || gr.Cells["name"].Value.ToString() != "")
                        {
                            salesorderDetail.materialCode = XYEEncoding.strCodeHex(_materialCode);
                        }
                        else
                        {
                            MessageBox.Show("商品代码不能为空！");
                            superGridControlShangPing.Focus();
                            return;
                        }
                        //判断表格里的金额与实际值是否相符     
                        decimal money = Convert.ToDecimal(gr["dinggouNumber"].Value) * Convert.ToDecimal(gr["price"].Value);
                        if (money == Convert.ToDecimal(gr["money"].Value))
                        {
                            salesorderDetail.materialMoney = Convert.ToDecimal(gr["money"].Value);//金额
                        }
                        else
                        {
                            MessageBox.Show("表格里金额的值错误！");
                            return;
                        }
                        decimal discountAfter = money * (Convert.ToDecimal(gr["DiscountRate"].Value) / 100);
                        decimal discountMoney = money - discountAfter;
                        //判断表格里的折扣额与实际值是否相符
                        if (discountMoney == Convert.ToDecimal(gr["DiscountMoney"].Value))
                        {
                            salesorderDetail.discountMoney = Convert.ToDecimal(gr["DiscountMoney"].Value);//折扣额
                        }
                        else
                        {
                            MessageBox.Show("表格里折扣额的值错误！");
                            return;
                        }
                        //判断表格里的税额与实际值是否相符
                        decimal rateMoney = money * (Convert.ToDecimal(gr["TaxRate"].Value) / 100);
                        if (rateMoney == Convert.ToDecimal(gr["TaxMoney"].Value))
                        {
                            salesorderDetail.tax = Convert.ToDecimal(gr["TaxMoney"].Value);//税额
                        }
                        else
                        {
                            MessageBox.Show("表格里税额的值错误！");
                            return;
                        }
                        //判断表格里的价税合计与实际值是否相符
                        decimal jiashui = money + rateMoney;
                        if (jiashui == Convert.ToDecimal(gr["priceANDtax"].Value))
                        {
                            salesorderDetail.taxTotal = Convert.ToDecimal(gr["priceANDtax"].Value);//价税合计
                        }
                        else
                        {
                            MessageBox.Show("表格里价税合计的值错误！");
                            return;
                        }
                        salesorderDetail.materialNumber = Convert.ToDecimal(gr["dinggouNumber"].Value.ToString() == "" ? 0.0M : Convert.ToDecimal(gr["dinggouNumber"].Value));//数量
                        salesorderDetail.materialPrice = Convert.ToDecimal(gr["price"].Value.ToString() == "" ? 0.0M : Convert.ToDecimal(gr["price"].Value));//单价                         
                        salesorderDetail.discountRate = Convert.ToDecimal(gr["DiscountRate"].Value.ToString() == "" ? 0.0M : Convert.ToDecimal(gr["DiscountRate"].Value));//折扣率                   
                        salesorderDetail.VATRate = Convert.ToDecimal(gr["TaxRate"].Value.ToString() == "" ? 0.0M : Convert.ToDecimal(gr["TaxRate"].Value));//增值税税率                 
                        salesorderDetail.remark = XYEEncoding.strCodeHex(gr["remark"].Value == null ? "" : gr["remark"].Value.ToString());//备注
                        salesorderDetail.deliveryNumber = Convert.ToDecimal(gr["FaHuoNumber"].Value == null ? 0.0M : Convert.ToDecimal(gr["FaHuoNumber"].Value));//发货数量    

                        GridRow dr = superGridControlShangPing.PrimaryGrid.Rows[0] as GridRow;
                        salesorderList.Add(salesorderDetail);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("错误代码：1103-尝试创建销售订单商品详细数据出错!请检查:" + ex.Message, "销售订单温馨提示");
                return;
            }

            //增加一条销售订单和销售订单详细数据
            object saleOrderResult = saleorderinterface.AddOrUpdate(salesorder, salesorderList);
            if (saleOrderResult != null)
            {
                MessageBox.Show("新增销售订单数据成功", "销售订单温馨提示");
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
            //SalesOrderInterface saleorderinterface = new SalesOrderInterface();
            //销售订单
            SalesOrder salesorder = new SalesOrder();
            //销售订单商品列表
            List<SalesOrderDetail> salesorderList = new List<SalesOrderDetail>();
            try
            {
                salesorder.code = XYEEncoding.strCodeHex(_SalesOrderCode);//销售订单Code
                                                                          //客户code
                if (labtxtDanJuType.Text != null || labtxtDanJuType.Text.Trim() != "")
                {
                    salesorder.clientCode = XYEEncoding.strCodeHex(_clientCode);
                }
                else
                {
                    MessageBox.Show("客户不能为空！");
                    labtxtDanJuType.Focus();
                    return;
                }
                //判断交货地点是否为空
                if (labtextboxTop5.Text.Trim() != null || labtextboxTop5.Text != "")
                {
                    salesorder.deliversLocation = XYEEncoding.strCodeHex(labtextboxTop5.Text);//交货地点
                }
                else
                {
                    MessageBox.Show("交货地点不能为空！");
                    labtextboxTop5.Focus();
                    return;
                }
                //判断已收订金是否为空
                if (labtextboxTop7.Text == null || labtextboxTop7.Text == "")
                {
                    salesorder.depositReceived = Convert.ToDecimal(0.00);
                }
                else
                {
                    salesorder.depositReceived = Convert.ToDecimal(labtextboxTop7.Text);
                }
                //判断销售员是否为空
                if (ltxtbSalsMan.Text.Trim() != null || ltxtbSalsMan.Text != "")
                {
                    salesorder.operation = XYEEncoding.strCodeHex(ltxtbSalsMan.Text);//销售员                 
                }
                else
                {
                    MessageBox.Show("销售员不能为空！");
                    ltxtbSalsMan.Focus();
                    return;
                }
                salesorder.date = this.dateTimePicker1.Value;//开单日期
                switch (cboMethod.Text.Trim())//交货方式
                {
                    case "提货":
                        salesorder.deliversMethod = 0;
                        break;
                    case "送货":
                        salesorder.deliversMethod = 1;
                        break;
                    case "发货":
                        salesorder.deliversMethod = 2;
                        break;
                }
                salesorder.deliversDate = dateTimePicker2.Value;//交货日期
                salesorder.remark = XYEEncoding.strCodeHex(labtextboxTop9.Text == null ? "" : labtextboxTop9.Text.ToString());//摘要               
                salesorder.makeMan = XYEEncoding.strCodeHex(ltxtbMakeMan.Text == null ? "" : ltxtbMakeMan.Text.ToString());//制单人
                salesorder.examine = XYEEncoding.strCodeHex(ltxtbShengHeMan.Text == null ? "" : ltxtbShengHeMan.Text.ToString());//审核人
                salesorder.checkState = 1;//审核状态
            }
            catch (Exception ex)
            {
                MessageBox.Show("错误代码:1104-尝试创建销售订单商品数据出错！请检查：" + ex.Message, "销售订单温馨提示");
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
                    if (gr["name"].Value != null)
                    {

                        i++;
                        SalesOrderDetail salesorderDetail = new SalesOrderDetail();
                        salesorderDetail.mainCode = XYEEncoding.strCodeHex(this.textBoxOddNumbers.Text);//销售订单单据Code
                        salesorderDetail.code = XYEEncoding.strCodeHex(_SalesOrderCode + i.ToString());//销售订单明细Code
                        //物料code
                        if (gr.Cells["name"].Value != null || gr.Cells["name"].Value.ToString() != "")
                        {
                            salesorderDetail.materialCode = XYEEncoding.strCodeHex(_materialCode);
                        }
                        else
                        {
                            MessageBox.Show("商品代码不能为空！");
                            superGridControlShangPing.Focus();
                            return;
                        }
                        //判断表格里的金额与实际值是否相符     
                        decimal money = Convert.ToDecimal(gr["dinggouNumber"].Value) * Convert.ToDecimal(gr["price"].Value);
                        if (money == Convert.ToDecimal(gr["money"].Value))
                        {
                            salesorderDetail.materialMoney = Convert.ToDecimal(gr["money"].Value);//金额
                        }
                        else
                        {
                            MessageBox.Show("表格里金额的值错误！");
                            return;
                        }
                        decimal discountAfter = money * (Convert.ToDecimal(gr["DiscountRate"].Value) / 100);
                        decimal discountMoney = money - discountAfter;
                        //判断表格里的折扣额与实际值是否相符
                        if (discountMoney == Convert.ToDecimal(gr["DiscountMoney"].Value))
                        {
                            salesorderDetail.discountMoney = Convert.ToDecimal(gr["DiscountMoney"].Value);//折扣额
                        }
                        else
                        {
                            MessageBox.Show("表格里折扣额的值错误！");
                            return;
                        }
                        //判断表格里的税额与实际值是否相符
                        decimal rateMoney = money * (Convert.ToDecimal(gr["TaxRate"].Value) / 100);
                        if (rateMoney == Convert.ToDecimal(gr["TaxMoney"].Value))
                        {
                            salesorderDetail.tax = Convert.ToDecimal(gr["TaxMoney"].Value);//税额
                        }
                        else
                        {
                            MessageBox.Show("表格里税额的值错误！");
                            return;
                        }
                        //判断表格里的价税合计与实际值是否相符
                        decimal jiashui = money + rateMoney;
                        if (jiashui == Convert.ToDecimal(gr["priceANDtax"].Value))
                        {
                            salesorderDetail.taxTotal = Convert.ToDecimal(gr["priceANDtax"].Value);//价税合计
                        }
                        else
                        {
                            MessageBox.Show("表格里价税合计的值错误！");
                            return;
                        }
                        salesorderDetail.materialNumber = Convert.ToDecimal(gr["dinggouNumber"].Value.ToString() == "" ? 0.0M : Convert.ToDecimal(gr["dinggouNumber"].Value));//数量
                        salesorderDetail.materialPrice = Convert.ToDecimal(gr["price"].Value.ToString() == "" ? 0.0M : Convert.ToDecimal(gr["price"].Value));//单价                      
                        salesorderDetail.discountRate = Convert.ToDecimal(gr["DiscountRate"].Value.ToString() == "" ? 0.0M : Convert.ToDecimal(gr["DiscountRate"].Value));//折扣率                  
                        salesorderDetail.VATRate = Convert.ToDecimal(gr["TaxRate"].Value.ToString() == "" ? 0.0M : Convert.ToDecimal(gr["TaxRate"].Value));//增值税税率                    
                        salesorderDetail.remark = XYEEncoding.strCodeHex(gr["remark"].Value == null ? "" : gr["remark"].Value.ToString());//备注
                        salesorderDetail.deliveryNumber = Convert.ToDecimal(gr["FaHuoNumber"].Value == null ? 0.0M : Convert.ToDecimal(gr["FaHuoNumber"].Value));//发货数量    

                        GridRow dr = superGridControlShangPing.PrimaryGrid.Rows[0] as GridRow;
                        salesorderList.Add(salesorderDetail);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("错误代码：1105-尝试创建并审核销售订单商品详细数据出错！请检查：" + ex.Message, "销售订单温馨提示");
                return;
            }

            //增加一条销售订单和销售订单详细数据
            object saleOrderResult = saleorderinterface.AddOrUpdate(salesorder, salesorderList);
            if (saleOrderResult != null)
            {
                MessageBox.Show("新增并审核销售订单数据成功", "销售订单温馨提示");
                InitForm();
                this.picShengHe.Image = Properties.Resources.审核;
            }
        }
        #endregion

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

        #region 小箭头和表格点击事件以及两个表格双击绑定数据

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
        /// 销售员
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
        /// 交货地点
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pictureBoxAddress_Click(object sender, EventArgs e)
        {
            if (_Click != 3)
            {
                InitStorage();
                dataGridViewFuJia.Focus();
            }
            _Click = 6;
        }

        /// <summary>
        /// 查询商品
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void superGridControlShangPing_BeginEdit(object sender, GridEditEventArgs e)
        {
            try
            {
                if (labtxtDanJuType.Text.Trim() == null || labtxtDanJuType.Text == "")
                {
                    resizablePanelData.Visible = false;
                    MessageBox.Show("请先选择客户");
                    return;
                }
                else if (e.GridCell.GridColumn.Name == "material")
                {

                    SelectedElementCollection ge = superGridControlShangPing.PrimaryGrid.GetSelectedCells();
                    GridCell gc = ge[0] as GridCell;
                    string materialDaima = XYEEncoding.strCodeHex(e.EditControl.EditorValue.ToString());
                    if (gc.GridRow.Cells[material].Value != null && (gc.GridRow.Cells[material].Value).ToString() != "")
                    {
                        //模糊查询商品列表
                        _AllMaterial = materialInterface.GetList(0, "" + materialDaima + "");
                        InitMaterialDataGridView();
                    }
                    else
                    {
                        //绑定商品列表
                        _AllMaterial = materialInterface.GetList(999, "");
                        InitMaterialDataGridView();
                    }
                    dataGridViewShangPing.DataSource = ch.DataTableReCoding(_AllMaterial);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("错误代码：1109-尝试点击商品代码出错或者无数据！请检查：" + ex.Message, "销售订单温馨提示！");
            }
        }

        /// <summary>
        /// 双击绑定客户、销售员、仓库数据
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
            superGridControlShangPing.Focus();
            SendKeys.Send("^{End}{Home}");
        }

        #endregion

        #region 模糊查询

        /// <summary>
        /// 销售员模糊查询
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
                MessageBox.Show("错误代码：1115-模糊查询销售员数据错误！" + ex.Message, "销售订单温馨提示！");
            }
        }

        /// <summary>
        /// 客户模糊查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void labtxtDanJuType_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.labtxtDanJuType.Text.Trim() == "")
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

                dgvc = new DataGridViewTextBoxColumn();
                dgvc.Name = "mobilePhone";
                dgvc.HeaderText = "电话";
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
                string name = XYEEncoding.strCodeHex(this.labtxtDanJuType.Text.Trim());
                dataGridViewFuJia.DataSource = ch.DataTableReCoding(client.GetList(0, name));
                resizablePanel1.Visible = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("错误代码：1114-模糊查询客户数据错误" + ex.Message, "销售订单温馨提示");
            }
        }

        /// <summary>
        /// 商品代码模糊搜索
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
                string materialDaima = XYEEncoding.strCodeHex(e.EditControl.EditorValue.ToString());
                if (SS == "")
                {
                    //模糊查询商品列表
                    _AllMaterial = materialInterface.GetList(0, "" + materialDaima + "");
                    InitMaterialDataGridView();
                    dataGridViewShangPing.DataSource = ch.DataTableReCoding(_AllMaterial);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("错误代码:1116-模糊查询表格商品数据错误！请检查：" + ex.Message, "销售订单温馨提示");
            }
        }

        #endregion

        /// <summary>
        /// 按ESC关闭副表格
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SalesOrderForm_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Escape)
            {
                this.resizablePanel1.Visible = false;
                this.resizablePanelData.Visible = false;
            }
        }

        /// <summary>
        /// 验证和统计数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void superGridControlShangPing_CellValidated(object sender, GridCellValidatedEventArgs e)
        {
            try
            {
                GridRow g = (GridRow)superGridControlShangPing.PrimaryGrid.Rows[1];
                if (g.Cells["name"].Value == null || g.Cells["name"].Value.ToString() == "")
                {
                    MessageBox.Show("请选择商品代码：");
                    return;
                }
                //最后一行做统计行
                GridRow gr = e.GridPanel.Rows[e.GridCell.RowIndex] as GridRow;
                ////计算金额
                decimal number = Convert.ToDecimal(gr.Cells["dinggouNumber"].FormattedValue);//订购数量
                decimal price = Convert.ToDecimal(gr.Cells["price"].FormattedValue);//单价               
                decimal money = number * price;//金额
                gr.Cells["money"].Value = money;
                decimal discountRate = Convert.ToDecimal(gr.Cells["DiscountRate"].FormattedValue);//折扣率
                decimal discountAfter = money * (discountRate / 100);
                decimal discountMoney = money - discountAfter;//折扣额
                gr.Cells["DiscountMoney"].Value = discountMoney;
                decimal taxRate = Convert.ToDecimal(gr.Cells["TaxRate"].FormattedValue);//增值税税率
                decimal rateMoney = money * (taxRate / 100);//税额
                gr.Cells["TaxMoney"].Value = rateMoney;
                decimal priceAndtax = money + rateMoney;//价税合计
                gr.Cells["priceANDtax"].Value = priceAndtax;

                TongJi();
            }
            catch (Exception ex)
            {
                MessageBox.Show("错误代码：1113-验证表格里的金额以及统计数量出错！请检查：" + ex.Message, "销售订单温馨提示！");
            }
        }

        #region 验证只能输入数字和小数点
        /// <summary>
        /// 验证只能输入数字和小数点
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ltxtTopYiShouDingJin_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                //小数点的处理。
                if ((int)e.KeyChar == 46)//小数点
                {
                    if (labtextboxTop7.Text.Length <= 0)
                        e.Handled = true;   //小数点不能在第一位
                    else
                    {
                        float f;
                        float oldf;
                        bool b1 = false, b2 = false;
                        b1 = float.TryParse(labtextboxTop7.Text, out oldf);
                        b2 = float.TryParse(labtextboxTop7.Text + e.KeyChar.ToString(), out f);
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
                        if (((TextBox)sender).Text.Trim().IndexOf('.') > 0)
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
                MessageBox.Show("错误代码：1117-已收金额输入的值为非法字符，请输入数字：" + ex.Message, "销售订单温馨提示！");
            }
        }

        private void labtextboxTop7_Validated(object sender, EventArgs e)
        {
            try
            {
                if (labtextboxTop7.Text == null || labtextboxTop7.Text.Trim() == "")
                {
                    labtextboxTop7.Text = 0.00.ToString();
                }
                if (labtextboxTop7.MaxLength > 12)
                {
                    labtextboxTop7.Focus();
                    labtextboxTop7.Text = "0.00";
                }
                else
                {
                    decimal yishou = Convert.ToDecimal(labtextboxTop7.Text);
                    labtextboxTop7.Text = yishou.ToString("0.00");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("错误代码：1117-已收金额输入的值为非法字符，请输入数字：" + ex.Message, "销售订单温馨提示！");
            }
        }
        #endregion

        /// <summary>
        /// 快捷方式设置
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SalesOrderForm_KeyDown(object sender, KeyEventArgs e)
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
        /// 表格按回车键
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
                labtxtDanJuType.Focus();
            }
        }

        /// <summary>
        /// 点击panel隐藏控件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void panel2_Click(object sender, EventArgs e)
        {
            this.resizablePanel1.Visible = false;
            this.resizablePanelData.Visible = false;
        }

        private void SalesOrderForm_Activated(object sender, EventArgs e)
        {
            labtxtDanJuType.Focus();
        }

        private void superGridControlShangPing_KeyUp(object sender, KeyEventArgs e)
        {
            superGridControlShangPing_KeyDown(sender, e);
        }

        /// <summary>
        /// 统计数据行
        /// </summary>
        private void TongJi()
        {
            GridRow gr = (GridRow)superGridControlShangPing.PrimaryGrid.Rows[ClickRowIndex];
            //逐行统计数据总数
            decimal TempAllNumber = 0;
            decimal tempallMoney = 0;
            decimal tempallTaxMoney = 0;
            decimal tempallPriceAndTax = 0;
            for (int i = 0; i < superGridControlShangPing.PrimaryGrid.Rows.Count - 1; i++)
            {
                GridRow tempGR = superGridControlShangPing.PrimaryGrid.Rows[i] as GridRow;
                TempAllNumber += Convert.ToDecimal(tempGR["dinggouNumber"].FormattedValue);
                tempallMoney += Convert.ToDecimal(tempGR["money"].FormattedValue);
                tempallTaxMoney += Convert.ToDecimal(tempGR["TaxMoney"].FormattedValue);
                tempallPriceAndTax += Convert.ToDecimal(tempGR["priceANDtax"].FormattedValue);
            }
            _MaterialNumber = TempAllNumber;
            _Money = tempallMoney;
            _TaxMoney = tempallTaxMoney;
            _PriceAndTaxMoney = tempallPriceAndTax;
            gr = (GridRow)superGridControlShangPing.PrimaryGrid.LastSelectableRow;
            gr["dinggouNumber"].Value = _MaterialNumber.ToString();
            gr["money"].Value = _Money.ToString();
            gr["TaxMoney"].Value = _TaxMoney.ToString();
            gr["priceANDtax"].Value = _PriceAndTaxMoney.ToString();
        }

        /// <summary>
        /// 验证单号是否重复
        /// </summary>
        /// <returns></returns>
        private string validateCode()
        {
            if (saleorderinterface.Exists(XYEEncoding.strCodeHex(_SalesOrderCode)))
            {
                _SalesOrderCode = BuildCode.ModuleCode("SOR");
            }
            else
            {
                _SalesOrderCode = textBoxOddNumbers.Text;//销售订单Code 
            }
            return _SalesOrderCode;
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
                    string linkman = dataGridViewFuJia.Rows[dataGridViewFuJia.CurrentRow.Index].Cells["linkMan"].Value.ToString();//联系人
                    string phone = dataGridViewFuJia.Rows[dataGridViewFuJia.CurrentRow.Index].Cells["mobilePhone"].Value.ToString();//电话
                    string fax = dataGridViewFuJia.Rows[dataGridViewFuJia.CurrentRow.Index].Cells["fax"].Value.ToString();//传真
                    labtxtDanJuType.Text = name;
                    labtextboxTop2.Text = linkman;
                    labtextboxTop3.Text = phone;
                    labtextboxTop8.Text = fax;
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
                //仓库
                if (_Click == 3 || _Click == 6)
                {
                    _storgeCode = dataGridViewFuJia.Rows[dataGridViewFuJia.CurrentRow.Index].Cells["code"].Value.ToString();//仓库code
                    string name = dataGridViewFuJia.Rows[dataGridViewFuJia.CurrentRow.Index].Cells["name"].Value.ToString();//仓库
                    labtextboxTop5.Text = name;
                    resizablePanel1.Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("错误代码：1110-双击绑定客户或者销售员或者仓库数据错误！请检查：" + ex.Message, "销售订单温馨提示！");
            }
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
                try
                {
                    foreach (GridRow g in grs)
                    {
                        if (g.Cells["materialCode"].Value == null)
                        {
                            newAdd = true;
                            continue;
                        }
                        if (g.Cells["materialCode"].Value.Equals(dataGridViewShangPing.Rows[dataGridViewShangPing.CurrentRow.Index].Cells["code"].Value))
                        {
                            decimal shuliang = Convert.ToDecimal(g.Cells["dinggouNumber"].Value);
                            shuliang += 1;
                            g.Cells["dinggouNumber"].Value = shuliang;

                            //计算金额
                            decimal dingguoshu = Convert.ToDecimal(g.Cells["dinggouNumber"].FormattedValue);//订购数量
                            decimal danJa = Convert.ToDecimal(g.Cells["price"].FormattedValue);//单价               
                            decimal Jine = dingguoshu * danJa;//金额
                            g.Cells["money"].Value = Jine;
                            decimal zheKou = Convert.ToDecimal(g.Cells["DiscountRate"].FormattedValue);//折扣率
                            decimal zheKouJine = Jine * (zheKou / 100);
                            decimal zheKouE = Jine - zheKouJine;//折扣额
                            g.Cells["DiscountMoney"].Value = zheKouE;
                            decimal taxrate = Convert.ToDecimal(g.Cells["TaxRate"].FormattedValue);//增值税税率
                            decimal ratemoney = Jine * (taxrate / 100);//税额
                            g.Cells["TaxMoney"].Value = ratemoney;
                            decimal priceandtax = Jine + ratemoney;//价税合计
                            g.Cells["priceANDtax"].Value = priceandtax;
                            resizablePanelData.Visible = false;

                            TongJi();
                            resizablePanelData.Visible = false;
                            return;
                        }
                        continue;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("错误代码：1111-重复添加商品并且计算数据错误" + ex.Message, "销售订单温馨提示！");
                }

                _materialCode = dataGridViewShangPing.Rows[dataGridViewShangPing.CurrentRow.Index].Cells["code"].Value.ToString();//商品code 
                gr.Cells["materialCode"].Value = _materialCode;//商品code 
                gr.Cells["material"].Value = dataGridViewShangPing.Rows[dataGridViewShangPing.CurrentRow.Index].Cells["materialDaima"].Value;//商品代码
                gr.Cells["name"].Value = dataGridViewShangPing.Rows[dataGridViewShangPing.CurrentRow.Index].Cells["name"].Value;//商品名称
                gr.Cells["model"].Value = dataGridViewShangPing.Rows[dataGridViewShangPing.CurrentRow.Index].Cells["model"].Value;//规格型号
                gr.Cells["barcode"].Value = dataGridViewShangPing.Rows[dataGridViewShangPing.CurrentRow.Index].Cells["barCode"].Value;//条形码
                gr.Cells["unit"].Value = dataGridViewShangPing.Rows[dataGridViewShangPing.CurrentRow.Index].Cells["unit"].Value;//单位

                if (dataGridViewShangPing.Rows[dataGridViewShangPing.CurrentRow.Index].Cells["isDouble"].Value.ToString() == "0")
                {
                    gr.Cells["dinggouNumber"].EditorType = typeof(GridDoubleInputEditControl);
                }

                gr.Cells["dinggouNumber"].Value = 1.00;//数量
                gr.Cells["price"].Value = dataGridViewShangPing.Rows[dataGridViewShangPing.CurrentRow.Index].Cells["price"].Value;//单价
                double discount = 100.00;
                gr.Cells["DiscountRate"].Value = discount;//折扣率
                gr.Cells["TaxRate"].Value = 17.00;//增值税税率
                gr.Cells["remark"].Value = dataGridViewShangPing.Rows[dataGridViewShangPing.CurrentRow.Index].Cells["remark"].Value;//备注

                ////计算金额
                decimal number = Convert.ToDecimal(gr.Cells["dinggouNumber"].FormattedValue);//订购数量
                decimal price = Convert.ToDecimal(gr.Cells["price"].FormattedValue);//单价               
                decimal money = number * price;//金额
                gr.Cells["money"].Value = money;
                decimal discountRate = Convert.ToDecimal(gr.Cells["DiscountRate"].FormattedValue);//折扣率
                decimal discountAfter = money * (discountRate / 100);
                decimal discountMoney = money - discountAfter;//折扣额
                gr.Cells["DiscountMoney"].Value = discountMoney;
                decimal taxRate = Convert.ToDecimal(gr.Cells["TaxRate"].FormattedValue);//增值税税率
                decimal rateMoney = money * (taxRate / 100);//税额
                gr.Cells["TaxMoney"].Value = rateMoney;
                decimal priceAndtax = money + rateMoney;//价税合计
                gr.Cells["priceANDtax"].Value = priceAndtax;
                resizablePanelData.Visible = false;

                TongJi();
                //新增一行
                if (newAdd)
                {
                    superGridControlShangPing.PrimaryGrid.NewRow(superGridControlShangPing.PrimaryGrid.Rows.Count);
                    //递增数量和金额 默认为1和单价 
                    gr = (GridRow)superGridControlShangPing.PrimaryGrid.LastSelectableRow;
                    _MaterialNumber += 1;
                    gr.Cells["dinggouNumber"].Value = _Materialnumber;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("错误代码：1112-双击绑定物料数据错误" + ex.Message, "销售订单温馨提示！");
            }
        }
    }
}

