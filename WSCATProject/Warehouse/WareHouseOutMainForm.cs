using DevComponents.DotNetBar.SuperGrid;
using HelperUtility;
using HelperUtility.Encrypt;
using InterfaceLayer.Base;
using InterfaceLayer.Warehouse;
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

namespace WSCATProject.Warehouse
{
    public partial class WareHouseOutMainForm : TestForm
    {
        public WareHouseOutMainForm()
        {
            InitializeComponent();
        }

        #region 调用接口以及加密解密方法
        CodingHelper ch = new CodingHelper();
        InterfaceLayer.Warehouse.WarehouseOutDetailInterface waredetaout = new WarehouseOutDetailInterface();
        EmpolyeeInterface employee = new EmpolyeeInterface();
        ClientInterface client = new ClientInterface();//客户
        InterfaceLayer.Sales.SalesMainInterface sales = new InterfaceLayer.Sales.SalesMainInterface();
        SalesDetailInterface salesdinterface = new SalesDetailInterface();
        WarehouseOutInterface warehouseoutinterface = new WarehouseOutInterface();
        #endregion

        #region 数据字段

        /// <summary>
        /// 所有客户
        /// </summary>
        private DataTable _AllClient = null;
        /// <summary>
        /// 所有业务员
        /// </summary>
        private DataTable _AllEmployee = null;
        /// <summary>
        /// 点击的项,1供应商  2为业务员
        /// </summary>
        private int _Click = 0;
        /// <summary>
        /// 定义显示类型 0,待入库的 1、部分入库 2、已入库的
        /// </summary>
        private int _state;
        /// <summary>
        /// 保存仓库商品明细
        /// </summary>
       // private GridRow _wareHouseModel;
        // private decimal _MaterialMoney;
        private decimal _MaterialNumber;
        /// <summary>
        /// 所有商品列表
        /// </summary>
        private DataTable _AllMaterial = null;
        /// <summary>
        /// 统计数量
        /// </summary>
        private decimal _Materialnumber;
        /// <summary>
        /// 保存客户Code
        /// </summary>
        private string _clientcode;
        /// <summary>
        /// 出库code
        /// </summary>
        private string _warehouseoutcode;
        /// <summary>
        /// 计算数量
        /// </summary>
        private decimal _beforeNumber;
        #endregion

        /// <summary>
        /// 加载事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void WareHouseOutMainForm_Load(object sender, EventArgs e)
        {
            try
            {
                //客户
                _AllClient = client.GetClientByBool(false);
                //业务员
                _AllEmployee = employee.SelSupplierTable(false);

                superGridControlShangPing.PrimaryGrid.SortCycle = SortCycle.AscDesc;    //排序方式范围
                superGridControlShangPing.PrimaryGrid.AddSort(superGridControlShangPing.PrimaryGrid.Columns[0], SortDirection.Ascending);//设置排序列和排序方式
                superGridControlShangPing.PrimaryGrid.ShowRowGridIndex = true;//显示行号
                //数量
                GridIntegerInputEditControl gdiecNumber = superGridControlShangPing.PrimaryGrid.Columns["gridColumnnumber"].EditControl as GridIntegerInputEditControl;
                gdiecNumber.MinValue = 0;
                gdiecNumber.MaxValue = 999999999;

                //禁用自动创建列
                dataGridViewShangPing.AutoGenerateColumns = false;
                dataGridViewFuJia.AutoGenerateColumns = false;
                superGridControlShangPing.HScrollBarVisible = true;
                //绑定事件 双击事填充内容并隐藏列表
                dataGridViewFuJia.CellDoubleClick += dataGridViewFuJia_CellDoubleClick;
                dataGridViewShangPing.CellDoubleClick += dataGridViewShangPing_CellDoubleClick;
                dataGridViewFuJia.KeyDown += DataGridViewFuJia_KeyDown;
                comboBoxEx1.SelectedIndex = 0;
                comboBoxExsonghuo.SelectedIndex = 0;
                InitDataGridView();
                toolStripBtnHouDan.Click += toolStripBtnHouDan_Click;//前单
                toolStripBtnQianDan.Click += toolStripBtnQianDan_Click;//后单
                toolStripBtnSave.Click += toolStripBtnSave_Click;//保存
                toolStripBtnShengHe.Click += toolStripBtnShengHe_Click;//审核
                //生成出库code 和显示条形码
                _warehouseoutcode = BuildCode.ModuleCode("WHO");
                textBoxOddNumbers.Text = _warehouseoutcode;
                barcodeXYE.Code128 _Code = new barcodeXYE.Code128();
                _Code.ValueFont = new Font("微软雅黑", 20);
                System.Drawing.Bitmap imgTemp = _Code.GetCodeImage(textBoxOddNumbers.Text, barcodeXYE.Code128.Encode.Code128A);
                pictureBox9.Image = imgTemp;
                pictureBox10.Parent = pictureBoxtitle;
            }
            catch (Exception ex)
            {
                MessageBox.Show("错误代码：2201-初始化数据错误" + ex.Message, "出库单温馨提示");
                this.Close();
                return;
            }
        }

        private void DataGridViewFuJia_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                dataGridViewTableClick();
            }
        }

        /// <summary>
        /// 审核按钮的点击事件
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
        /// 保存按钮的点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripBtnSave_Click(object sender, EventArgs e)
        {
            Save();
        }

        /// <summary>
        /// 前单的点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripBtnQianDan_Click(object sender, EventArgs e)
        {
            WarehouseOutInterface warehouseoutterface = new WarehouseOutInterface();
            try
            {
                if (textBoid.Text == "")
                {
                    textBoid.Text = "0";
                }

                WarehouseOut warehouseout = warehouseoutterface.GetPreAndNext(Convert.ToInt32(textBoid.Text), 1);
                this.comboBoxEx1.Text = XYEEncoding.strHexDecode(warehouseout.type);
                comboBoxExxiaos.Text = XYEEncoding.strHexDecode(warehouseout.salesCode);//销售单号
                labtextboxTop2.Text = XYEEncoding.strHexDecode(warehouseout.ClientName);//客户
                labtextboxTop9.Text = XYEEncoding.strHexDecode(warehouseout.SalesPhone);//销售电话
                comboBoxExsonghuo.Text = XYEEncoding.strHexDecode(warehouseout.delivery);//送货方式
                labtextboxBotton2.Text = XYEEncoding.strHexDecode(warehouseout.remark);//摘要
                this.ltxtbSalsMan.Text = XYEEncoding.strHexDecode(warehouseout.operation);
                this.ltxtbMakeMan.Text = XYEEncoding.strHexDecode(warehouseout.MakeMan);
                this.ltxtbShengHeMan.Text = XYEEncoding.strHexDecode(warehouseout.examine);
                if (warehouseout.id != 0)
                {
                    textBoid.Text = warehouseout.id.ToString();
                    WarehouseOutDetailInterface widiout = new WarehouseOutDetailInterface();
                    superGridControlShangPing.PrimaryGrid.DataSource = null;
                    superGridControlShangPing.PrimaryGrid.Columns.Clear();
                    superGridControlShangPing.PrimaryGrid.AutoGenerateColumns = false;
                    //DataTable dt = ch.DataTableReCoding(widiout.getListByMainCode(XYEEncoding.strCodeHex(textBoxOddNumbers.Text)).Tables[0]);
                    DataTable dt = new DataTable();
                    superGridControlShangPing.PrimaryGrid.DataSource = dt;
                    InitWarehouseDetail();
                    //InitForm();
                }
                barcodeXYE.Code128 _Code = new barcodeXYE.Code128();
                _Code.ValueFont = new Font("微软雅黑", 20);
                System.Drawing.Bitmap imgTemp = _Code.GetCodeImage(textBoxOddNumbers.Text, barcodeXYE.Code128.Encode.Code128A);
                pictureBox9.Image = imgTemp;
            }
            catch (Exception ex)
            {
                MessageBox.Show("错误代码：2206-尝试点击后单数据显示错误！请检查：" + ex.Message, "出库单温馨提示");
            }
        }

        /// <summary>
        /// 后单的点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripBtnHouDan_Click(object sender, EventArgs e)
        {
            WarehouseOutInterface warehouseoutterface = new WarehouseOutInterface();
            try
            {
                if (textBoid.Text == "")
                {
                    textBoid.Text = "0";
                }

                WarehouseOut warehouseout = warehouseoutterface.GetPreAndNext(Convert.ToInt32(textBoid.Text), 0);
                this.comboBoxEx1.Text = XYEEncoding.strHexDecode(warehouseout.type);
                comboBoxExxiaos.Text = XYEEncoding.strHexDecode(warehouseout.salesCode);//销售单号
                labtextboxTop2.Text = XYEEncoding.strHexDecode(warehouseout.ClientName);//客户
                labtextboxTop9.Text = XYEEncoding.strHexDecode(warehouseout.SalesPhone);//销售电话
                comboBoxExsonghuo.Text = XYEEncoding.strHexDecode(warehouseout.delivery);//送货方式
                labtextboxBotton2.Text = XYEEncoding.strHexDecode(warehouseout.remark);//摘要
                this.ltxtbSalsMan.Text = XYEEncoding.strHexDecode(warehouseout.operation);
                this.ltxtbMakeMan.Text = XYEEncoding.strHexDecode(warehouseout.MakeMan);
                this.ltxtbShengHeMan.Text = XYEEncoding.strHexDecode(warehouseout.examine);
                if (warehouseout.id != 0)
                {
                    textBoid.Text = warehouseout.id.ToString();
                    WarehouseOutDetailInterface widiout = new WarehouseOutDetailInterface();
                    superGridControlShangPing.PrimaryGrid.DataSource = null;
                    superGridControlShangPing.PrimaryGrid.Columns.Clear();
                    superGridControlShangPing.PrimaryGrid.AutoGenerateColumns = false;
                    //DataTable dt = ch.DataTableReCoding(widiout.getListByMainCode(XYEEncoding.strCodeHex(textBoxOddNumbers.Text)).Tables[0]);
                    DataTable dt = new DataTable();
                    superGridControlShangPing.PrimaryGrid.DataSource = dt;
                    InitWarehouseDetail();
                    //InitForm();
                }
                barcodeXYE.Code128 _Code = new barcodeXYE.Code128();
                _Code.ValueFont = new Font("微软雅黑", 20);
                System.Drawing.Bitmap imgTemp = _Code.GetCodeImage(textBoxOddNumbers.Text, barcodeXYE.Code128.Encode.Code128A);
                pictureBox9.Image = imgTemp;
            }
            catch (Exception ex)
            {
                MessageBox.Show("错误代码：2207-尝试点击后单数据显示错误" + ex.Message, "出库单温馨提示");
            }
        }

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
            gr.Cells["gridColumnnumber"].Value = 0;
            gr.Cells["gridColumnnumber"].CellStyles.Default.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleCenter;
            gr.Cells["gridColumnnumber"].CellStyles.Default.Background.Color1 = Color.Orange;

            #region 合计行不能点击
            gr.Cells["material"].AllowSelection = false;
            gr.Cells["gridColumnname"].AllowSelection = false;
            gr.Cells["gridColumnmodel"].AllowSelection = false;
            gr.Cells["gridColumntiaoxingma"].AllowSelection = false;
            gr.Cells["gridColumnunit"].AllowSelection = false;
            gr.Cells["gridColumnnumber"].AllowSelection = false;
            gr.Cells["gridColumnprice"].AllowSelection = false;
            gr.Cells["griCoulumcangku"].AllowSelection = false;
            gr.Cells["griCoulumhuojia"].AllowSelection = false;
            gr.Cells["gridColumndate"].AllowSelection = false;
            gr.Cells["gridColumnbaozhe"].AllowSelection = false;
            gr.Cells["gridColumnremark"].AllowSelection = false;
            #endregion
        }

        /// <summary>
        /// 初始化商品下拉别表的数据
        /// </summary>
        private void InitMaterialDataGridView()
        {
            dataGridViewShangPing.DataSource = null;
            dataGridViewShangPing.Columns.Clear();
            DataGridViewTextBoxColumn dgvc = new DataGridViewTextBoxColumn();
            dgvc.Name = "id";
            dgvc.Visible = false;
            dgvc.HeaderText = "maid";
            dgvc.DataPropertyName = "id";
            dataGridViewShangPing.Columns.Add(dgvc);

            dgvc = new DataGridViewTextBoxColumn();
            dgvc.Name = "code";
            dgvc.Visible = false;
            dgvc.HeaderText = "code";
            dgvc.DataPropertyName = "code";
            dataGridViewShangPing.Columns.Add(dgvc);


            dgvc = new DataGridViewTextBoxColumn();
            dgvc.Name = "materialCode";
            dgvc.Visible = false;
            dgvc.HeaderText = "materialCode";
            dgvc.DataPropertyName = "materialCode";
            dataGridViewShangPing.Columns.Add(dgvc);

            dgvc = new DataGridViewTextBoxColumn();
            dgvc.Name = "unit";
            dgvc.Visible = false;
            dgvc.HeaderText = "unit";
            dgvc.DataPropertyName = "unit";
            dataGridViewShangPing.Columns.Add(dgvc);

            dgvc = new DataGridViewTextBoxColumn();
            dgvc.Name = "needNumber";
            dgvc.Visible = false;
            dgvc.HeaderText = "needNumber";
            dgvc.DataPropertyName = "needNumber";
            dataGridViewShangPing.Columns.Add(dgvc);


            dgvc = new DataGridViewTextBoxColumn();
            dgvc.Name = "discountAfterPrice";
            dgvc.Visible = false;
            dgvc.HeaderText = "discountAfterPrice";
            dgvc.DataPropertyName = "discountAfterPrice";
            dataGridViewShangPing.Columns.Add(dgvc);

            dgvc = new DataGridViewTextBoxColumn();
            dgvc.Name = "money";
            dgvc.Visible = false;
            dgvc.HeaderText = "money";
            dgvc.DataPropertyName = "money";
            dataGridViewShangPing.Columns.Add(dgvc);

            dgvc = new DataGridViewTextBoxColumn();
            dgvc.Name = "productionDate";
            dgvc.Visible = false;
            dgvc.HeaderText = "productionDate";
            dgvc.DataPropertyName = "productionDate";
            dataGridViewShangPing.Columns.Add(dgvc);


            dgvc = new DataGridViewTextBoxColumn();
            dgvc.Name = "qualityDate";
            dgvc.Visible = false;
            dgvc.HeaderText = "qualityDate";
            dgvc.DataPropertyName = "qualityDate";
            dataGridViewShangPing.Columns.Add(dgvc);

            dgvc = new DataGridViewTextBoxColumn();
            dgvc.Name = "effectiveDate";
            dgvc.Visible = false;
            dgvc.HeaderText = "effectiveDate";
            dgvc.DataPropertyName = "effectiveDate";
            dataGridViewShangPing.Columns.Add(dgvc);

            dgvc = new DataGridViewTextBoxColumn();
            dgvc.Name = "remark";
            dgvc.Visible = false;
            dgvc.HeaderText = "remark";
            dgvc.DataPropertyName = "remark";
            dataGridViewShangPing.Columns.Add(dgvc);
            //货架路径
            dgvc = new DataGridViewTextBoxColumn();
            dgvc.Name = "storageRackLocation";
            dgvc.Visible = false;
            dgvc.HeaderText = "storageRackLocation";
            dgvc.DataPropertyName = "storageRackLocation";
            dataGridViewShangPing.Columns.Add(dgvc);

            dgvc = new DataGridViewTextBoxColumn();
            dgvc.Name = "zhujima";
            dgvc.Visible = true;
            dgvc.HeaderText = "助记码";
            dgvc.DataPropertyName = "zhujima";
            dataGridViewShangPing.Columns.Add(dgvc);


            dgvc = new DataGridViewTextBoxColumn();
            dgvc.Name = "materialName";
            dgvc.Visible = true;
            dgvc.HeaderText = "商品名称";
            dgvc.DataPropertyName = "materialName";
            dataGridViewShangPing.Columns.Add(dgvc);

            dgvc = new DataGridViewTextBoxColumn();
            dgvc.Name = "materiaModel";
            dgvc.Visible = true;
            dgvc.HeaderText = "规格型号";
            dgvc.DataPropertyName = "materiaModel";
            dataGridViewShangPing.Columns.Add(dgvc);

            dgvc = new DataGridViewTextBoxColumn();
            dgvc.Name = "barCode";
            dgvc.Visible = true;
            dgvc.HeaderText = "条形码";
            dgvc.DataPropertyName = "barCode";
            dataGridViewShangPing.Columns.Add(dgvc);
        }

        /// <summary>
        /// 初始化业务员
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
                    dataGridViewFuJia.Columns.Add(dgvc);

                    dgvc = new DataGridViewTextBoxColumn();
                    dgvc.Name = "name";
                    dgvc.HeaderText = "姓名";
                    dgvc.DataPropertyName = "姓名";
                    dataGridViewFuJia.Columns.Add(dgvc);

                    resizablePanel1.Location = new Point(234, 440);
                    dataGridViewFuJia.DataSource = ch.DataTableReCoding(_AllEmployee);
                    resizablePanel1.Visible = true;
                    if (this.WindowState == FormWindowState.Maximized)
                    {
                        resizablePanel1.Location = new Point(220, 670);
                        return;
                    }
                    if (this.WindowState == FormWindowState.Normal)
                    {
                        resizablePanel1.Location = new Point(234, 440);
                        return;
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("错误代码：2209-尝试点击出库员出错或者无数据！请检查：" + ex.Message, "出库单温馨提示！");
            }
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
                    dataGridViewFuJia.Columns.Add(dgvc);

                    dgvc = new DataGridViewTextBoxColumn();
                    dgvc.Name = "name";
                    dgvc.HeaderText = "客户姓名";
                    dgvc.DataPropertyName = "name";
                    dataGridViewFuJia.Columns.Add(dgvc);

                    dgvc = new DataGridViewTextBoxColumn();
                    dgvc.Name = "mobilePhone";
                    dgvc.HeaderText = "销售电话";
                    dgvc.DataPropertyName = "mobilePhone";
                    dgvc.Visible = false;
                    dataGridViewFuJia.Columns.Add(dgvc);

                    resizablePanel1.Location = new Point(470, 160);
                    dataGridViewFuJia.DataSource = ch.DataTableReCoding(_AllClient);
                    resizablePanel1.Visible = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("错误代码：2208-尝试点击客户出错或者无数据！请检查：" + ex.Message, "出库单温馨提示！");
            }
        }

        /// <summary>
        /// 初始化入库明细表格
        /// </summary>
        private void InitWarehouseDetail()
        {
            GridColumn gc = null;
            gc = new GridColumn();
            gc.DataPropertyName = "materialDaima";
            gc.Name = "materialDaima";
            gc.HeaderText = "商品代码";
            gc.Width = 120;
            gc.AutoSizeMode = ColumnAutoSizeMode.Fill;
            superGridControlShangPing.PrimaryGrid.Columns.Add(gc);

            gc = new GridColumn();
            gc.DataPropertyName = "materiaName";
            gc.Name = "materiaName";
            gc.HeaderText = "商品名称";
            gc.Width = 140;
            gc.AutoSizeMode = ColumnAutoSizeMode.Fill;
            superGridControlShangPing.PrimaryGrid.Columns.Add(gc);

            gc = new GridColumn();
            gc.DataPropertyName = "materiaModel";
            gc.Name = "materiaModel";
            gc.HeaderText = "规格型号";
            gc.Width = 130;
            gc.AutoSizeMode = ColumnAutoSizeMode.Fill;
            superGridControlShangPing.PrimaryGrid.Columns.Add(gc);

            gc = new GridColumn();
            gc.DataPropertyName = "barcode";
            gc.Name = "barcode";
            gc.HeaderText = "条形码";
            gc.Width = 150;
            gc.AutoSizeMode = ColumnAutoSizeMode.Fill;
            superGridControlShangPing.PrimaryGrid.Columns.Add(gc);

            gc = new GridColumn();
            gc.DataPropertyName = "materiaUnit";
            gc.Name = "materiaUnit";
            gc.HeaderText = "单位";
            gc.Width = 70;
            superGridControlShangPing.PrimaryGrid.Columns.Add(gc);

            gc = new GridColumn();
            gc.DataPropertyName = "number";
            gc.Name = "number";
            gc.HeaderText = "数量";
            gc.Width = 80;
            superGridControlShangPing.PrimaryGrid.Columns.Add(gc);

            gc = new GridColumn();
            gc.DataPropertyName = "warehouseName";
            gc.Name = "warehouseName";
            gc.HeaderText = "仓库";
            gc.Width = 80;
            superGridControlShangPing.PrimaryGrid.Columns.Add(gc);

            gc = new GridColumn();
            gc.DataPropertyName = "storageRackName";
            gc.Name = "storageRackName";
            gc.HeaderText = "区域/排/行/列";
            gc.Width = 80;
            superGridControlShangPing.PrimaryGrid.Columns.Add(gc);

            gc = new GridColumn();
            gc.DataPropertyName = "productionDate";
            gc.Name = "productionDate";
            gc.HeaderText = "采购/生产日期";
            gc.Width = 70;
            gc.HeaderStyles.Default.AllowWrap = DevComponents.DotNetBar.SuperGrid.Style.Tbool.True;
            superGridControlShangPing.PrimaryGrid.Columns.Add(gc);

            gc = new GridColumn();
            gc.DataPropertyName = "qualityDate";
            gc.Name = "qualityDate";
            gc.HeaderText = "保质期(天)";
            gc.Width = 50;
            gc.HeaderStyles.Default.AllowWrap = DevComponents.DotNetBar.SuperGrid.Style.Tbool.True;
            superGridControlShangPing.PrimaryGrid.Columns.Add(gc);

            gc = new GridColumn();
            gc.DataPropertyName = "effectiveDate";
            gc.Name = "effectiveDate";
            gc.HeaderText = "有效期至";
            gc.Width = 80;
            superGridControlShangPing.PrimaryGrid.Columns.Add(gc);

            gc = new GridColumn();
            gc.DataPropertyName = "remark";
            gc.Name = "remark";
            gc.HeaderText = "备注";
            gc.Width = 110;
            superGridControlShangPing.PrimaryGrid.Columns.Add(gc);
        }

        /// <summary>
        /// 标示那个控件不可用
        /// </summary>
        private void InitForm()
        {
            this.comboBoxExxiaos.Enabled = false;
            this.labtextboxTop2.ReadOnly = true;
            this.textBoxOddNumbers.ReadOnly = true;
            this.comboBoxEx1.Enabled = false;
            this.comboBoxExsonghuo.Enabled = false;
            this.textBoxSearch.ReadOnly = true;
            this.labtextboxTop9.ReadOnly = true;
            this.ltxtbSalsMan.ReadOnly = true;
            this.labtextboxBotton2.ReadOnly = true;
            this.ltxtbMakeMan.ReadOnly = true;
            this.ltxtbShengHeMan.ReadOnly = true;
            this.resizablePanel1.Visible = false;
            this.dateTimePicker1.Enabled = false;
            this.superGridControlShangPing.PrimaryGrid.ReadOnly = true;
            this.toolStripBtnSave.Enabled = false;
            this.panel2.BackColor = Color.FromArgb(240, 240, 240);
            this.panel5.BackColor = Color.FromArgb(240, 240, 240);
            this.superGridControlShangPing.BackColor = Color.FromArgb(240, 240, 240);
            labtextboxTop9.BackColor = Color.FromArgb(240, 240, 240);
            labtextboxTop2.BackColor = Color.FromArgb(240, 240, 240);
            comboBoxExxiaos.BackColor = Color.FromArgb(240, 240, 240);
            comboBoxEx1.BackColor = Color.FromArgb(240, 240, 240);
            comboBoxExsonghuo.BackColor = Color.FromArgb(240, 240, 240);
        }

        /// <summary>
        /// 非空验证
        /// </summary>
        private bool isNUllValidate()
        {
            if (comboBoxEx1.Text.Trim() == null)
            {
                MessageBox.Show("出库类型不能为空！");
                return false;
            }
            if (labtextboxTop2.Text.Trim() == null || labtextboxTop2.Text == "")
            {
                MessageBox.Show("客户不能为空！");
                return false;
            }
            GridRow gr = (GridRow)superGridControlShangPing.PrimaryGrid.Rows[1];
            if (gr.Cells["material"].Value == null || gr.Cells["material"].Value.ToString() == "")
            {
                MessageBox.Show("商品代码不能为空！");
                return false;
            }
            if (ltxtbSalsMan.Text.Trim() == null || ltxtbSalsMan.Text == "")
            {
                MessageBox.Show("出库员不能为空！");
                return false;
            }
            return true;
        }

        #endregion

        /// <summary>
        /// 第一列编辑的时候
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void superGridControlShangPing_BeginEdit(object sender, GridEditEventArgs e)
        {
            try
            {
                if (this.labtextboxTop2.Text.Trim() == "")
                {
                    resizablePanelData.Visible = false;
                    MessageBox.Show("请先选择客户，显示销售单号!");
                    return;
                }
                if (e.GridCell.GridColumn.Name == "material")
                {
                    SelectedElementCollection ge = superGridControlShangPing.PrimaryGrid.GetSelectedCells();
                    GridCell gc = ge[0] as GridCell;
                    if (gc.GridRow.Cells[material].Value != null && (gc.GridRow.Cells[material].Value).ToString() != "")
                    {
                        //模糊查询商品列表
                        _AllMaterial = salesdinterface.GetDetailByMainCode(XYEEncoding.strCodeHex(this.comboBoxExxiaos.Text.Trim()), 2, XYEEncoding.strCodeHex(gc.GridRow.Cells[material].Value.ToString()));
                        InitMaterialDataGridView();
                    }
                    else
                    {
                        //绑定商品列表
                        _AllMaterial = salesdinterface.GetDetailByMainCode(XYEEncoding.strCodeHex(this.comboBoxExxiaos.Text.Trim()), 4, "");
                        InitMaterialDataGridView();
                    }

                    dataGridViewShangPing.DataSource = ch.DataTableReCoding(_AllMaterial);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("错误代码：2210-尝试点击商品代码出错或者无数据！请检查：" + ex.Message, "出库单温馨提示！");
            }
        }

        /// <summary>
        /// 统计和验证数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void superGridControlShangPing_CellValidated(object sender, GridCellValidatedEventArgs e)
        {
            try
            {
                //最后一行做统计行
                GridRow gr = e.GridPanel.Rows[e.GridCell.RowIndex] as GridRow;
                ////计算金额
                decimal number = Convert.ToDecimal(gr.Cells["gridColumnnumber"].FormattedValue);
                decimal price = Convert.ToDecimal(gr.Cells["gridColumnprice"].FormattedValue);
                decimal allPrice = number * price;
                gr.Cells["gridColumnmoney"].Value = allPrice;
                //逐行统计数据总数
                decimal tempAllNumber = 0;
                for (int i = 0; i < superGridControlShangPing.PrimaryGrid.Rows.Count - 1; i++)
                {
                    GridRow tempGR = superGridControlShangPing.PrimaryGrid.Rows[i] as GridRow;
                    tempAllNumber += Convert.ToDecimal(tempGR["gridColumnnumber"].FormattedValue);
                }
                _MaterialNumber = tempAllNumber;
                gr = (GridRow)superGridControlShangPing.PrimaryGrid.LastSelectableRow;
                gr["gridColumnnumber"].Value = _MaterialNumber.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("统计数量出错！请检查：" + ex.Message);
            }
        }

        /// <summary>
        /// 第一个框的模糊查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void superGridControlShangPing_EditorValueChanged(object sender, GridEditEventArgs e)
        {
            try
            {
                string SS = "";
                GridRow gr = (GridRow)superGridControlShangPing.PrimaryGrid.Rows[ClickRowIndex];
                string materialDaima = XYEEncoding.strCodeHex(e.EditControl.EditorValue.ToString());
                if (SS == "")
                {
                    //模糊查询商品列表
                    _AllMaterial = salesdinterface.GetDetailByMainCode(XYEEncoding.strCodeHex(this.comboBoxExxiaos.Text.Trim()), 2, materialDaima);
                    InitMaterialDataGridView();
                    dataGridViewShangPing.DataSource = ch.DataTableReCoding(_AllMaterial);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("错误代码：2215-模糊查询商品代码数据错误" + ex.Message, "出库单温馨提示");
            }
        }

        #region 小箭头和两个附表的点击事件
        /// <summary>
        /// 出库员箭头点击事件
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
            _Click = 4;
        }

        /// <summary>
        /// 客户箭头的点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pictureBoxClient_Click(object sender, EventArgs e)
        {
            if (_Click != 1)
            {
                //调用客户的绑定列
                InitClient();
                dataGridViewFuJia.Focus();
            }
            _Click = 3;
        }

        private void dataGridViewShangPing_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
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
                    if (g.Cells["gridColumnmaterialcode"].Value == null)
                    {
                        newAdd = true;
                        continue;
                    }
                    if (g.Cells["gridColumnmaterialcode"].Value.Equals(dataGridViewShangPing.Rows[e.RowIndex].Cells["materialCode"].Value))
                    {
                        decimal shuliang = Convert.ToDecimal(g.Cells["gridColumnnumber"].Value);
                        shuliang += 1;
                        g.Cells["gridColumnnumber"].Value = shuliang;

                        //逐行统计数据总数
                        decimal tempAllNumber = 0;
                        for (int i = 0; i < superGridControlShangPing.PrimaryGrid.Rows.Count - 1; i++)
                        {
                            GridRow tempGR = superGridControlShangPing.PrimaryGrid.Rows[i] as GridRow;
                            tempAllNumber += Convert.ToDecimal(tempGR["gridColumnnumber"].FormattedValue);
                        }
                        _MaterialNumber = tempAllNumber;
                        gr = (GridRow)superGridControlShangPing.PrimaryGrid.LastSelectableRow;
                        gr["gridColumnnumber"].Value = _MaterialNumber.ToString();
                        resizablePanelData.Visible = false;
                        return;
                    }
                    continue;
                }
                //新增一行 
                if (newAdd)
                {

                    string storageRackLocation = dataGridViewShangPing.Rows[e.RowIndex].Cells["storageRackLocation"].Value.ToString();
                    string[] sArray = storageRackLocation.Split('/');
                    string Location = sArray[1] + "/" + sArray[2] + "/" + sArray[3] + "/" + sArray[4];
                    decimal number = Convert.ToDecimal(dataGridViewShangPing.Rows[e.RowIndex].Cells["needNumber"].Value);
                    decimal price = Convert.ToDecimal(dataGridViewShangPing.Rows[e.RowIndex].Cells["discountAfterPrice"].Value);
                    decimal JinE = number * price;//金额
                    GridRow gr1 = new GridRow();
                    //无法保证每次都对应
                    superGridControlShangPing.PrimaryGrid.Rows.Insert(0,
                        new GridRow(
                       dataGridViewShangPing.Rows[e.RowIndex].Cells["zhujima"].Value,
                       dataGridViewShangPing.Rows[e.RowIndex].Cells["materialName"].Value,
                       dataGridViewShangPing.Rows[e.RowIndex].Cells["materiaModel"].Value,
                       dataGridViewShangPing.Rows[e.RowIndex].Cells["barCode"].Value,
                       dataGridViewShangPing.Rows[e.RowIndex].Cells["unit"].Value,
                       1.ToString(),
                      Convert.ToDecimal(dataGridViewShangPing.Rows[e.RowIndex].Cells["discountAfterPrice"].Value),
                       sArray[0],
                       Location,
                         "",
                        dataGridViewShangPing.Rows[e.RowIndex].Cells["productionDate"].Value.ToString(),
                        dataGridViewShangPing.Rows[e.RowIndex].Cells["qualityDate"].Value.ToString(),
                        dataGridViewShangPing.Rows[e.RowIndex].Cells["effectiveDate"].Value,
                        dataGridViewShangPing.Rows[e.RowIndex].Cells["remark"].Value,
                        dataGridViewShangPing.Rows[e.RowIndex].Cells["materialCode"].Value,
                        JinE
                        )
                        );
                    if (dataGridViewShangPing.Rows[e.RowIndex].Cells["unit"].Value.ToString() == "斤")
                    {
                        GridRow gridrows = (GridRow)superGridControlShangPing.PrimaryGrid.Rows[0];
                        gr.Cells["gridColumnnumber"].EditorType = typeof(GridDoubleInputEditControl);
                    }
                    // superGridControlShangPing.PrimaryGrid.NewRow(superGridControlShangPing.PrimaryGrid.Rows.Count);
                    //递增数量和金额 默认为1和单价 
                    gr = (GridRow)superGridControlShangPing.PrimaryGrid.LastSelectableRow;
                    _Materialnumber += 1;
                    gr.Cells["gridColumnnumber"].Value = _Materialnumber;
                    resizablePanelData.Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("错误代码：2212-双击绑定物料数据错误！请检查：" + ex.Message, "出库单温馨提示！");
            }
            SendKeys.Send("^{End}{Home}");
        }

        private void dataGridViewFuJia_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
            {
                return;
            }
            dataGridViewTableClick();
        }

        #endregion

        /// <summary>
        /// 光标默认在哪个控件上面
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void WareHouseOutMainForm_Activated(object sender, EventArgs e)
        {
            labtextboxTop2.Focus();
        }

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

        /// <summary>
        /// 出库员模糊查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ltxtbSalsMan_TextChanged(object sender, EventArgs e)
        {
            try
            {

                if (ltxtbSalsMan.Text.Trim() == "")
                {
                    InitEmployee();
                    _Click = 4;
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

                resizablePanel1.Location = new Point(234, 440);
                dataGridViewFuJia.DataSource = ch.DataTableReCoding(employee.GetList(0, "" + XYEEncoding.strCodeHex(ltxtbSalsMan.Text.Trim()) + ""));
                resizablePanel1.Visible = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("错误代码：模糊查询出库员数据错误" + ex.Message, "出库单温馨提示");
            }


        }

        /// <summary>
        /// 客户的模糊查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void labtxtClient_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.labtextboxTop2.Text.Trim() == "")
                {
                    InitClient();
                    _Click = 3;
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
                dgvc.HeaderText = "销售电话";
                dgvc.DataPropertyName = "mobilePhone";
                dgvc.Visible = false;
                dataGridViewFuJia.Columns.Add(dgvc);

                resizablePanel1.Location = new Point(470, 160);
                string name = XYEEncoding.strCodeHex(this.labtextboxTop2.Text.Trim());
                dataGridViewFuJia.DataSource = ch.DataTableReCoding(client.GetList(0, name));
                resizablePanel1.Visible = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("错误代码：2213-模糊查询客户数据错误" + ex.Message, "出库单温馨提示");
            }
        }

        /// <summary>
        /// 按ESC关闭副表格
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void WareHouseOutMainForm_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Escape)
            {
                this.resizablePanel1.Visible = false;
                this.resizablePanelData.Visible = false;
            }
        }

        /// <summary>
        /// 产品检索
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBoxSearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.comboBoxExxiaos.Text.Trim() == "")
                {
                    resizablePanelData.Visible = false;
                    MessageBox.Show("请先选择客户，显示销售单号!");
                    return;
                }
                resizablePanelData.Location = new Point(91, 193);
                resizablePanelData.Visible = true;
                SalesDetailInterface salinf = new SalesDetailInterface();
                if (string.IsNullOrWhiteSpace(textBoxSearch.Text.Trim()))
                {
                    //模糊查询商品列表
                    _AllMaterial = salinf.GetWhereList(XYEEncoding.strCodeHex(this.textBoxSearch.Text), XYEEncoding.strCodeHex(comboBoxExxiaos.Text));
                    InitMaterialDataGridView();
                    dataGridViewShangPing.DataSource = ch.DataTableReCoding(_AllMaterial);
                    return;
                }
                //模糊查询商品列表
                _AllMaterial = salinf.GetWhereList(XYEEncoding.strCodeHex(this.textBoxSearch.Text), XYEEncoding.strCodeHex(comboBoxExxiaos.Text));
                InitMaterialDataGridView();
                dataGridViewShangPing.DataSource = ch.DataTableReCoding(_AllMaterial);
            }
            catch (Exception ex)
            {
                MessageBox.Show("错误代码：2216-产品检索模糊查询商品代码、名称、条形码数据失败！请检查：" + ex.Message, "出库单温馨提示");
            }
        }

        private void textBoxSearch_Enter(object sender, EventArgs e)
        {
            textBoxSearch_TextChanged(sender, e);
        }

        private void textBoxSearch_Leave(object sender, EventArgs e)
        {
            if (ActiveControl.Name == "dataGridView1")//如果当前活动控件是dataGridView1
            {
                resizablePanelData.Visible = true;
                return;
            }
            resizablePanelData.Visible = false;
        }

        private void superGridControlShangPing_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                panel2.Focus();
            }
        }

        /// <summary>
        /// 保存按钮的函数
        /// </summary>
        private void Save()
        {
            //非空验证
            if (isNUllValidate() == false)
            {
                return;
            }

            //入库单
            WarehouseOut warehouseout = new WarehouseOut();
            //入库商品列表
            List<WarehouseOutDetail> wareHouseOutList = new List<WarehouseOutDetail>();
            try
            {
                #region 基本数据
                warehouseout.code = XYEEncoding.strCodeHex(YanZhengCode());//单号
                if (comboBoxEx1.Text != null || comboBoxEx1.Text.ToString() != "")
                {
                    warehouseout.type = XYEEncoding.strCodeHex(comboBoxEx1.Text);//出货类型
                }
                else
                {
                    MessageBox.Show("出货类型不能为空！");
                    comboBoxEx1.Focus();
                    return;
                }
                if (labtextboxTop2.Text != null || labtextboxTop2.Text.ToString() != "")
                {
                    warehouseout.ClientName = XYEEncoding.strCodeHex(labtextboxTop2.Text);//客户名称
                }
                else
                {
                    MessageBox.Show("客户不能为空！");
                    labtextboxTop2.Focus();
                    return;
                }
                if (ltxtbSalsMan.Text != null || ltxtbSalsMan.Text.ToString() != "")
                {
                    warehouseout.operation = XYEEncoding.strCodeHex(ltxtbSalsMan.Text);//出库员
                }
                else
                {
                    MessageBox.Show("出库员不能为空！");
                    ltxtbSalsMan.Focus();
                    return;
                }
                warehouseout.checkState = 0;
                warehouseout.clientCode = _clientcode;//客户code              
                warehouseout.date = this.dateTimePicker1.Value;//开单日期
                warehouseout.defaultType = XYEEncoding.strCodeHex("出库开单");//默认单据类型
                warehouseout.delivery = XYEEncoding.strCodeHex(comboBoxExsonghuo.Text == null ? "" : comboBoxExsonghuo.Text.ToString());//配送方式
                warehouseout.examine = XYEEncoding.strCodeHex(ltxtbShengHeMan.Text == null ? "" : ltxtbShengHeMan.Text.ToString());//审核人
                warehouseout.MakeMan = XYEEncoding.strCodeHex(ltxtbMakeMan.Text == null ? "" : ltxtbMakeMan.Text.ToString());//制单人
                warehouseout.SalesPhone = XYEEncoding.strCodeHex(labtextboxTop9.Text == null ? "" : labtextboxTop9.Text.ToString());//销售电话        
                warehouseout.remark = XYEEncoding.strCodeHex(labtextboxBotton2.Text == null ? "" : labtextboxBotton2.Text.ToString());//备注
                warehouseout.salesCode = XYEEncoding.strCodeHex(comboBoxExxiaos.Text);//销售单Code
                warehouseout.expressMan = "";
                warehouseout.expressOdd = "";
                warehouseout.expressPhone = "";
                warehouseout.isClear = 1;
                warehouseout.reserved1 = "";
                warehouseout.reserved2 = "";
                warehouseout.state = 0;
                warehouseout.stock = "";
                warehouseout.updateDate = DateTime.Now;

                #endregion
            }
            catch (Exception ex)
            {
                MessageBox.Show("错误代码:-2202;尝试创建出库单商品数据出错,请检查：" + ex.Message, "出库单温馨提示");
                return;
            }

            try
            {
                #region  商品详细
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
                        WarehouseOutDetail warehouseoutd = new WarehouseOutDetail();
                        if (gr["material"].Value != null || gr["material"].Value.ToString() != "")
                        {
                            warehouseoutd.materialDaima = XYEEncoding.strCodeHex(gr["material"].Value.ToString());//物料编码
                        }
                        else
                        {
                            MessageBox.Show("单据体表格里商品代码不能为空！");
                            superGridControlShangPing.Focus();
                            return;
                        }
                        decimal money = Convert.ToDecimal(gr["gridColumnnumber"].Value) * Convert.ToDecimal(gr["gridColumnprice"].Value);
                        if (money == Convert.ToDecimal(gr["gridColumnmoney"].Value))
                        {
                            warehouseoutd.money = Convert.ToDecimal(gr["gridColumnmoney"].Value.ToString());//金额
                        }
                        else
                        {
                            MessageBox.Show("单据体表格里金额错误！");
                            superGridControlShangPing.Focus();
                            return;
                        }
                        warehouseoutd.barcode = XYEEncoding.strCodeHex(gr["gridColumntiaoxingma"].Value.ToString());//条形码
                        warehouseoutd.code = XYEEncoding.strCodeHex(_warehouseoutcode + i.ToString());//出库Code
                        warehouseoutd.date = dateTimePicker1.Value;//出库时间
                        warehouseoutd.effectiveDate = Convert.ToDateTime(gr["gridColumnyouxiao"].Value.ToString());//有效期至
                        warehouseoutd.IsArrive = 1;
                        warehouseoutd.isClear = 1;
                        warehouseoutd.MainCode = XYEEncoding.strCodeHex(_warehouseoutcode);//主表Code
                        warehouseoutd.materialCode = XYEEncoding.strCodeHex(gr["gridColumnmaterialcode"].Value == null ? "" : gr["gridColumnmaterialcode"].Value.ToString());//物料code                     
                        warehouseoutd.materialModel = XYEEncoding.strCodeHex(gr["gridColumnmodel"].Value == null ? "" : gr["gridColumnmodel"].Value.ToString());//规格型号
                        warehouseoutd.materialName = XYEEncoding.strCodeHex(gr["gridColumnname"].Value == null ? "" : gr["gridColumnname"].Value.ToString());//物料名称
                        warehouseoutd.materiaUnit = XYEEncoding.strCodeHex(gr["gridColumnunit"].Value == null ? "" : gr["gridColumnunit"].Value.ToString());//物料单位                    
                        warehouseoutd.number = gr["gridColumnnumber"].Value == null ? 0 : Convert.ToDecimal(gr["gridColumnnumber"].Value.ToString() == "" ? 0.00 : gr["gridColumnnumber"].Value);//数量
                        warehouseoutd.price = gr["gridColumnprice"].Value == null ? 0 : Convert.ToDecimal(gr["gridColumnprice"].Value.ToString() == "" ? 0.00 : gr["gridColumnprice"].Value);//价格
                        warehouseoutd.productionDate = Convert.ToDateTime(gr["gridColumndate"].Value.ToString());//生产日期
                        warehouseoutd.qualityDate = Convert.ToDecimal(gr["gridColumnbaozhe"].Value.ToString());//保质期
                        warehouseoutd.remark = XYEEncoding.strCodeHex(gr["gridColumnremark"].Value == null ?
                        "" : gr["gridColumnremark"].Value.ToString());//备注;
                        warehouseoutd.reserved1 = "";
                        warehouseoutd.reserved2 = "";
                        warehouseoutd.rfid = "";
                        warehouseoutd.state = 0;
                        warehouseoutd.StorageRackCode = "";
                        warehouseoutd.StorageRackName = XYEEncoding.strCodeHex(gr["griCoulumhuojia"].Value == null ? "" : gr["griCoulumhuojia"].Value.ToString());
                        warehouseoutd.updateDate = DateTime.Now;
                        warehouseoutd.WarehouseCode = "";
                        warehouseoutd.WarehouseName = XYEEncoding.strCodeHex(gr["griCoulumcangku"].Value == null ? "" : gr["griCoulumcangku"].Value.ToString());
                        GridRow dr = superGridControlShangPing.PrimaryGrid.Rows[0] as GridRow;
                        wareHouseOutList.Add(warehouseoutd);
                    }
                }
                #endregion
            }
            catch (Exception ex)
            {
                MessageBox.Show("错误代码：-2203；尝试创建出库单商品详细数据出错,请检查：" + ex.Message, "出库单温馨提示");
                return;
            }


            // 增加一条出库单和出库单详细数据
            object warehouseOutResult = warehouseoutinterface.Add(warehouseout, wareHouseOutList);
            this.textBoid.Text = warehouseOutResult.ToString();
            if (warehouseOutResult != null)
            {
                MessageBox.Show("新增出库数据成功", "出库单温馨提示");
            }
        }

        /// <summary>
        /// 审核按钮的函数
        /// </summary>
        private void ShengHe()
        {
            //非空验证
            if (isNUllValidate() == false)
            {
                return;
            }

            //入库单
            WarehouseOut warehouseout = new WarehouseOut();
            //入库商品列表
            List<WarehouseOutDetail> wareHouseOutList = new List<WarehouseOutDetail>();

            #region 基本数据
            try
            {
                warehouseout.code = XYEEncoding.strCodeHex(_warehouseoutcode);//单号
                if (comboBoxEx1.Text != null || comboBoxEx1.Text.ToString() != "")
                {
                    warehouseout.type = XYEEncoding.strCodeHex(comboBoxEx1.Text);//出货类型
                }
                else
                {
                    MessageBox.Show("出货类型不能为空！");
                    comboBoxEx1.Focus();
                    return;
                }
                if (labtextboxTop2.Text != null || labtextboxTop2.Text.ToString() != "")
                {
                    warehouseout.ClientName = XYEEncoding.strCodeHex(labtextboxTop2.Text);//客户名称
                }
                else
                {
                    MessageBox.Show("客户不能为空！");
                    labtextboxTop2.Focus();
                    return;
                }
                if (ltxtbSalsMan.Text != null || ltxtbSalsMan.Text.ToString() != "")
                {
                    warehouseout.operation = XYEEncoding.strCodeHex(ltxtbSalsMan.Text);//出库员
                }
                else
                {
                    MessageBox.Show("出库员不能为空！");
                    ltxtbSalsMan.Focus();
                    return;
                }
                warehouseout.checkState = 1;
                warehouseout.clientCode = _clientcode;//客户code              
                warehouseout.date = this.dateTimePicker1.Value;//开单日期
                warehouseout.defaultType = XYEEncoding.strCodeHex("出库开单");//默认单据类型
                warehouseout.delivery = XYEEncoding.strCodeHex(comboBoxExsonghuo.Text == null ? "" : comboBoxExsonghuo.Text.ToString());//配送方式
                warehouseout.examine = XYEEncoding.strCodeHex(ltxtbShengHeMan.Text == null ? "" : ltxtbShengHeMan.Text.ToString());//审核人
                warehouseout.MakeMan = XYEEncoding.strCodeHex(ltxtbMakeMan.Text == null ? "" : ltxtbMakeMan.Text.ToString());//制单人
                warehouseout.SalesPhone = XYEEncoding.strCodeHex(labtextboxTop9.Text == null ? "" : labtextboxTop9.Text.ToString());//销售电话        
                warehouseout.remark = XYEEncoding.strCodeHex(labtextboxBotton2.Text == null ? "" : labtextboxBotton2.Text.ToString());//备注
                warehouseout.salesCode = XYEEncoding.strCodeHex(comboBoxExxiaos.Text);//销售单Code
                warehouseout.expressMan = "";
                warehouseout.expressOdd = "";
                warehouseout.expressPhone = "";
                warehouseout.isClear = 1;
                warehouseout.reserved1 = "";
                warehouseout.reserved2 = "";
                warehouseout.state = 0;
                warehouseout.stock = "";
                warehouseout.updateDate = DateTime.Now;
            }
            catch (Exception ex)
            {
                MessageBox.Show("错误代码:2204-尝试创建并审核出库单商品数据出错,请检查：" + ex.Message, "出库单温馨提示");
                return;
            }
            #endregion

            try
            {
                #region 商品详细
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
                        WarehouseOutDetail warehouseoutd = new WarehouseOutDetail();
                        if (gr["material"].Value != null || gr["material"].Value.ToString() != "")
                        {
                            warehouseoutd.materialDaima = XYEEncoding.strCodeHex(gr["material"].Value.ToString());//物料编码
                        }
                        else
                        {
                            MessageBox.Show("单据体表格里商品代码不能为空！");
                            superGridControlShangPing.Focus();
                            return;
                        }
                        decimal money = Convert.ToDecimal(gr["gridColumnnumber"].Value) * Convert.ToDecimal(gr["gridColumnprice"].Value);
                        if (money == Convert.ToDecimal(gr["gridColumnmoney"].Value))
                        {
                            warehouseoutd.money = Convert.ToDecimal(gr["gridColumnmoney"].Value.ToString());//金额
                        }
                        else
                        {
                            MessageBox.Show("单据体表格里金额错误！");
                            superGridControlShangPing.Focus();
                            return;
                        }
                        warehouseoutd.barcode = XYEEncoding.strCodeHex(gr["gridColumntiaoxingma"].Value.ToString());//条形码
                        warehouseoutd.code = XYEEncoding.strCodeHex(_warehouseoutcode + i.ToString());//出库Code
                        warehouseoutd.date = dateTimePicker1.Value;//出库时间
                        warehouseoutd.effectiveDate = Convert.ToDateTime(gr["gridColumnyouxiao"].Value.ToString());//有效期至
                        warehouseoutd.IsArrive = 1;
                        warehouseoutd.isClear = 1;
                        warehouseoutd.MainCode = XYEEncoding.strCodeHex(_warehouseoutcode);//主表Code
                        warehouseoutd.materialCode = XYEEncoding.strCodeHex(gr["gridColumnmaterialcode"].Value == null ? "" : gr["gridColumnmaterialcode"].Value.ToString());//物料code                     
                        warehouseoutd.materialModel = XYEEncoding.strCodeHex(gr["gridColumnmodel"].Value == null ? "" : gr["gridColumnmodel"].Value.ToString());//规格型号
                        warehouseoutd.materialName = XYEEncoding.strCodeHex(gr["gridColumnname"].Value == null ? "" : gr["gridColumnname"].Value.ToString());//物料名称
                        warehouseoutd.materiaUnit = XYEEncoding.strCodeHex(gr["gridColumnunit"].Value == null ? "" : gr["gridColumnunit"].Value.ToString());//物料单位                    
                        warehouseoutd.number = gr["gridColumnnumber"].Value == null ? 0 : Convert.ToDecimal(gr["gridColumnnumber"].Value.ToString() == "" ? 0.00 : gr["gridColumnnumber"].Value);//数量
                        warehouseoutd.price = gr["gridColumnprice"].Value == null ? 0 : Convert.ToDecimal(gr["gridColumnprice"].Value.ToString() == "" ? 0.00 : gr["gridColumnprice"].Value);//价格
                        warehouseoutd.productionDate = Convert.ToDateTime(gr["gridColumndate"].Value.ToString());//生产日期
                        warehouseoutd.qualityDate = Convert.ToDecimal(gr["gridColumnbaozhe"].Value.ToString());//保质期
                        warehouseoutd.remark = XYEEncoding.strCodeHex(gr["gridColumnremark"].Value == null ?
                        "" : gr["gridColumnremark"].Value.ToString());//备注;
                        warehouseoutd.reserved1 = "";
                        warehouseoutd.reserved2 = "";
                        warehouseoutd.rfid = "";
                        warehouseoutd.state = 0;
                        warehouseoutd.StorageRackCode = "";
                        warehouseoutd.StorageRackName = XYEEncoding.strCodeHex(gr["griCoulumhuojia"].Value == null ? "" : gr["griCoulumhuojia"].Value.ToString());
                        warehouseoutd.updateDate = DateTime.Now;
                        warehouseoutd.WarehouseCode = "";
                        warehouseoutd.WarehouseName = XYEEncoding.strCodeHex(gr["griCoulumcangku"].Value == null ? "" : gr["griCoulumcangku"].Value.ToString());
                        GridRow dr = superGridControlShangPing.PrimaryGrid.Rows[0] as GridRow;
                        wareHouseOutList.Add(warehouseoutd);
                    }
                }
                #endregion
            }
            catch (Exception ex)
            {
                MessageBox.Show("错误代码：2205-尝试创建并审核出库单商品详细数据出错,请检查：" + ex.Message, "出库单温馨提示");
                return;
            }

            // 增加一条出库单和出库单详细数据
            object warehouseOutResult = warehouseoutinterface.update(warehouseout, wareHouseOutList);
            this.textBoid.Text = warehouseOutResult.ToString();
            if (warehouseOutResult != null)
            {
                MessageBox.Show("新增和审核出库数据成功", "出库单温馨提示");
                InitForm();
                this.pictureBox10.Image = Properties.Resources.审核;
            }
        }

        /// <summary>
        /// 快捷方式
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void WareHouseOutMainForm_KeyDown(object sender, KeyEventArgs e)
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
        /// 小表格的点击事件函数
        /// </summary>
        private void dataGridViewTableClick()
        {
            try
            {
                //客户
                if (_Click == 1 || _Click == 3)
                {
                    string name = dataGridViewFuJia.Rows[dataGridViewFuJia.CurrentRow.Index].Cells["name"].Value.ToString();
                    _clientcode = XYEEncoding.strCodeHex(dataGridViewFuJia.Rows[dataGridViewFuJia.CurrentRow.Index].Cells["code"].Value.ToString());
                    string phone = dataGridViewFuJia.Rows[dataGridViewFuJia.CurrentRow.Index].Cells["mobilePhone"].Value.ToString();
                    labtextboxTop2.Text = name;
                    labtextboxTop9.Text = phone;
                    resizablePanel1.Visible = false;
                    //根据搜索的客户来绑定下拉列表
                    DataTable dt = ch.DataTableReCoding(sales.GetTableByClientCode(_clientcode));
                    this.comboBoxExxiaos.DataSource = dt;
                    comboBoxExxiaos.ValueMember = "code";
                    comboBoxExxiaos.DisplayMember = "name";

                }
                //出库员
                if (_Click == 2 || _Click == 4)
                {
                    string name = dataGridViewFuJia.Rows[dataGridViewFuJia.CurrentRow.Index].Cells["name"].Value.ToString();
                    ltxtbSalsMan.Text = name;
                    resizablePanel1.Visible = false;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("错误代码：2211-双击绑定客户或者出库员数据错误！请检查：" + ex.Message, "出库单温馨提示！");
            }
        }

        /// <summary>
        /// 验证Code是否重复函数
        /// </summary>
        /// <returns></returns>
        private string YanZhengCode()
        {
            if (warehouseoutinterface.Exists(XYEEncoding.strCodeHex(_warehouseoutcode)))
            {
                _warehouseoutcode = BuildCode.ModuleCode("WHO");
            }
            else
            {
                _warehouseoutcode = textBoxOddNumbers.Text;
            }
            return _warehouseoutcode;
        }
    }
}
