using DevComponents.DotNetBar.SuperGrid;
using HelperUtility;
using HelperUtility.Encrypt;
using InterfaceLayer.Base;
using InterfaceLayer.Warehouse;
using Model.Warehouse;
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
    public partial class WareHouseInventoryProfitForm : TestForm
    {
        public WareHouseInventoryProfitForm()
        {
            InitializeComponent();
        }

        #region 调用接口以及加密解密方法
        CodingHelper ch = new CodingHelper();
        EmpolyeeInterface employee = new EmpolyeeInterface();
        WarehouseInventoryDetailInterface warehouseinv = new WarehouseInventoryDetailInterface();
        WareHouseInventoryProfitInterface warehouseProfitinterface = new WareHouseInventoryProfitInterface();
        #endregion

        #region 数据字段

        /// <summary>
        /// 所有业务员
        /// </summary>
        private DataTable _AllEmployee = null;
        /// <summary>
        /// 点击的项 1为业务员
        /// </summary>
        private int _Click = 0;
        /// <summary>
        /// 入库code
        /// </summary>
        private string _WareHousePanYingCode;
        /// <summary>
        /// 统计贮存数量
        /// </summary>
        private decimal _ZhangCunShuLiang;
        /// <summary>
        /// 统计盘点数量
        /// </summary>
        private decimal _PanDianShuLiang;
        /// <summary>
        /// 统计盘盈数量
        /// </summary>
        private decimal _PanYingShuLiang;
        /// <summary>
        /// 统计盘盈金额
        /// </summary>
        private decimal _PanYingMoney;

        /// <summary>
        /// 仓库code
        /// </summary>
        private string _storageCode;
        public string StorageCode
        {
            get { return _storageCode; }
            set { _storageCode = value; }
        }
        /// <summary>
        /// 仓库名称
        /// </summary>
        private string _storageName;
        public string StorageName
        {
            get { return _storageName; }
            set { _storageName = value; }
        }
        #endregion

        /// <summary>
        /// 窗体加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void WareHouseInventoryProfit_Load(object sender, EventArgs e)
        {
            try
            {
                //业务员
                _AllEmployee = employee.SelSupplierTable(false);
                //显示行号
                superGridControlShangPing.PrimaryGrid.ShowRowGridIndex = true;
                //禁用自动创建列
                dataGridViewShangPing.AutoGenerateColumns = false;
                dataGridViewFuJia.AutoGenerateColumns = false;
                this.superGridControlShangPing.PrimaryGrid.AutoGenerateColumns = false;
                superGridControlShangPing.HScrollBarVisible = true;
                //绑定事件 双击事填充内容并隐藏列表
                dataGridViewFuJia.CellDoubleClick += dataGridViewFuJia_CellDoubleClick;
                dataGridViewShangPing.CellDoubleClick += dataGridViewShangPing_CellDoubleClick;
                // 将dataGridView中的内容居中显示
                dataGridViewFuJia.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                toolStripBtnSave.Click += toolStripBtnSave_Click;//保存按钮
                toolStripBtnShengHe.Click += toolStripBtnShengHe_Click;//审核按钮
                dataGridViewFuJia.KeyDown += DataGridViewFuJia_KeyDown;
                picBoxShengHeProfit.Parent = labelTitle;
                cboInType.SelectedIndex = 0;
                //绑定摘要
                labtextboxBotton2.Text = "由【" + _storageName + "】生成";
                //生成code 和显示条形码
                _WareHousePanYingCode = BuildCode.ModuleCode("WIP");
                textBoxOddNumbers.Text = _WareHousePanYingCode;
                barcodeXYE.Code128 _Code = new barcodeXYE.Code128();
                _Code.ValueFont = new Font("微软雅黑", 20);
                System.Drawing.Bitmap imgTemp = _Code.GetCodeImage(textBoxOddNumbers.Text, barcodeXYE.Code128.Encode.Code128A);
                pictureBox9.Image = imgTemp;

                superGridControlShangPing.PrimaryGrid.DataSource = ch.DataTableReCoding(warehouseinv.Search(6, XYEEncoding.strCodeHex(_storageCode)));
                superGridControlShangPing.PrimaryGrid.EnsureVisible();
            }
            catch (Exception ex)
            {
                MessageBox.Show("错误代码：2501-窗体加载时，初始化数据错误！请检查：" + ex.Message, "盘盈单温馨提示");
                return;
            }
            //调用合计行数据
            InitDataGridView();
            try
            {
                GridRow gr = new GridRow();
                decimal tempAllzhucun = 0;//账面数量
                decimal tempAllpandian = 0;//盘点数量
                decimal tempAllpanying = 0;//盘盈数量
                decimal tempAllpanyingmoney = 0;//盘盈金额
                //逐行统计数据总数
                for (int i = 0; i < superGridControlShangPing.PrimaryGrid.Rows.Count - 1; i++)
                {
                    GridRow tempGR = superGridControlShangPing.PrimaryGrid.Rows[i] as GridRow;
                    tempAllzhucun += Convert.ToDecimal(tempGR["gridColumnzhangmianshu"].FormattedValue);
                    tempAllpandian += Convert.ToDecimal(tempGR["gridColumnpandianshu"].FormattedValue);
                    tempAllpanying += Convert.ToDecimal(tempGR["gridColumnpanyingshu"].FormattedValue);
                    tempAllpanyingmoney += Convert.ToDecimal(tempGR["gridColumnmoney"].FormattedValue);
                }
                _ZhangCunShuLiang = tempAllzhucun;
                _PanDianShuLiang = tempAllpandian;
                _PanYingShuLiang = tempAllpanying;
                _PanYingMoney = tempAllpanyingmoney;
                gr = (GridRow)superGridControlShangPing.PrimaryGrid.LastSelectableRow;
                gr["gridColumnzhangmianshu"].Value = _ZhangCunShuLiang.ToString();
                gr["gridColumnpandianshu"].Value = _PanDianShuLiang.ToString();
                gr["gridColumnpanyingshu"].Value = _PanYingShuLiang.ToString();
                gr["gridColumnmoney"].Value = _PanYingMoney.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("错误代码2502-盘盈单加载时统计数量失败！请检查：" + ex.Message, "盘盈单温馨提示");
                this.Close();
                return;
            }
        }

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
        private void toolStripBtnShengHe_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("是否一键审核？", "提示信息", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            if (result == DialogResult.OK)
            {
                ShengHe();
            }
        }

        /// <summary>
        /// 保存按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripBtnSave_Click(object sender, EventArgs e)
        {
            Save();
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
            gr.Cells["gridColumnzhangmianshu"].Value = 0;
            gr.Cells["gridColumnzhangmianshu"].CellStyles.Default.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleCenter;
            gr.Cells["gridColumnzhangmianshu"].CellStyles.Default.Background.Color1 = Color.Orange;
            gr.Cells["gridColumnpandianshu"].Value = 0;
            gr.Cells["gridColumnpandianshu"].CellStyles.Default.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleCenter;
            gr.Cells["gridColumnpandianshu"].CellStyles.Default.Background.Color1 = Color.Orange;
            gr.Cells["gridColumnpanyingshu"].Value = 0;
            gr.Cells["gridColumnpanyingshu"].CellStyles.Default.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleCenter;
            gr.Cells["gridColumnpanyingshu"].CellStyles.Default.Background.Color1 = Color.Orange;
            gr.Cells["gridColumnmoney"].Value = 0;
            gr.Cells["gridColumnmoney"].CellStyles.Default.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleCenter;
            gr.Cells["gridColumnmoney"].CellStyles.Default.Background.Color1 = Color.Orange;

            #region 合计行不能点击
            gr.Cells["material"].AllowSelection = false;
            gr.Cells["gridColumnname"].AllowSelection = false;
            gr.Cells["gridColumnmodel"].AllowSelection = false;
            gr.Cells["gridColumntiaoxingma"].AllowSelection = false;
            gr.Cells["gridColumnStock"].AllowSelection = false;
            gr.Cells["gridColumnunit"].AllowSelection = false;
            gr.Cells["gridColumnzhangmianshu"].AllowSelection = false;
            gr.Cells["gridColumnpandianshu"].AllowSelection = false;
            gr.Cells["gridColumnpanyingshu"].AllowSelection = false;
            gr.Cells["gridColumnprice"].AllowSelection = false;
            gr.Cells["gridColumnmoney"].AllowSelection = false;
            gr.Cells["gridColumndate"].AllowSelection = false;
            gr.Cells["gridColumnbaozhe"].AllowSelection = false;
            gr.Cells["gridColumnyouxiao"].AllowSelection = false;
            gr.Cells["gridColumnremark"].AllowSelection = false;
            #endregion
        }

        /// <summary>
        /// 非空验证
        /// </summary>
        private bool isNUllValidate()
        {
            if (cboInType.Text.Trim() == null)
            {
                MessageBox.Show("入库类别不能为空！");
                return false;
            }
            if (ltxtbSalsMan.Text.Trim() == null || ltxtbSalsMan.Text == "")
            {
                MessageBox.Show("盘点员不能为空！");
                return false;
            }
            return true;
        }

        /// <summary>
        /// 初始化盘盈员
        /// </summary>
        private void InitEmployee()
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
                    dgvc.HeaderText = "员工工号";
                    dgvc.DataPropertyName = "员工工号";
                    dataGridViewFuJia.Columns.Add(dgvc);

                    dgvc = new DataGridViewTextBoxColumn();
                    dgvc.Name = "name";
                    dgvc.HeaderText = "姓名";
                    dgvc.DataPropertyName = "姓名";
                    dataGridViewFuJia.Columns.Add(dgvc);

                    resizablePanel1.Location = new Point(234, 420);
                    dataGridViewFuJia.DataSource = ch.DataTableReCoding(_AllEmployee);
                    resizablePanel1.Visible = true;

                    if (this.WindowState == FormWindowState.Maximized)
                    {
                        resizablePanel1.Location = new Point(230, 650);
                        return;
                    }
                    if (this.WindowState == FormWindowState.Normal)
                    {
                        resizablePanel1.Location = new Point(234, 420);
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("错误代码：2507-点击盘盈员数据显示出错！请检查：" + ex.Message, "盘盈单温馨提示");
            }
        }

        /// <summary>
        /// 标示那个控件不可用
        /// </summary>
        private void InitForm()
        {
            this.cboInType.Enabled = false;
            this.labtextboxBotton2.ReadOnly = true;
            this.textBoxOddNumbers.ReadOnly = true;
            this.ltxtbSalsMan.ReadOnly = true;
            this.ltxtbMakeMan.ReadOnly = true;
            this.ltxtbShengHeMan.ReadOnly = true;
            this.resizablePanel1.Visible = false;
            this.dateTimePicker1.Enabled = false;
            this.superGridControlShangPing.PrimaryGrid.ReadOnly = true;
            this.toolStripBtnSave.Enabled = false;
            this.panel2.BackColor = Color.FromArgb(240, 240, 240);
            this.panel5.BackColor = Color.FromArgb(240, 240, 240);
            this.superGridControlShangPing.BackColor = Color.FromArgb(240, 240, 240);
            labtextboxBotton2.BackColor = Color.FromArgb(240, 240, 240);
            cboInType.BackColor = Color.FromArgb(240, 240, 240);
            textBoxOddNumbers.BackColor = Color.FromArgb(240, 240, 240);
        }

        #endregion

        #region 小箭头图标和表格数据的点击事件
        private void pictureBoxEmployee_Click(object sender, EventArgs e)
        {
            if (_Click != 1)
            {
                InitEmployee();
                dataGridViewFuJia.Focus();
            }
            _Click = 2;
        }

        private void dataGridViewFuJia_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
            {
                return;
            }
            dataGridViewFuJiTableClick();
        }

        private void dataGridViewShangPing_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //表的点击事件
        }

        #endregion

        #region 修改Panel的边框颜色
        /// <summary>
        /// 修改Panel的边框颜色
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

        private void WareHouseInventoryProfit_Activated(object sender, EventArgs e)
        {
            cboInType.Focus();
        }

        /// <summary>
        /// 盘盈员模糊查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ltxtbSalsMan_TextChanged(object sender, EventArgs e)
        {
            if (ltxtbSalsMan.Text.Trim() == "")
            {
                _Click = 2;
                InitEmployee();
                return;
            }
            try
            {
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
                MessageBox.Show("错误代码：2509-模糊查询盘盈员出错！请检查：" + ex.Message, "盘盈单温馨提示");
            }
        }

        /// <summary>
        /// 按下ESC按钮关闭子窗体
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void WareHouseInventoryProfit_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Escape)
            {
                this.resizablePanel1.Visible = false;
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
            //盘盈单
            WarehouseInventoryProfit warehouseprofit = new WarehouseInventoryProfit();
            //盘盈商品列表
            List<WarehouseInventoryProfitDetail> wareHouseprofitList = new List<WarehouseInventoryProfitDetail>();
            try
            {
                #region 盘盈单基本数据
                warehouseprofit.code = YanZhengCode() == "" ? "" : XYEEncoding.strCodeHex(YanZhengCode());
                if (cboInType.Text != null || cboInType.Text.ToString() != "")
                {
                    warehouseprofit.type = cboInType.Text == "" ? "" : XYEEncoding.strCodeHex(cboInType.Text);
                }
                else
                {
                    MessageBox.Show("盘盈单入库类别不能为空！");
                    cboInType.Focus();
                    return;
                }
                if (ltxtbSalsMan.Text != null || ltxtbSalsMan.Text.ToString() != "")
                {
                    warehouseprofit.operation = ltxtbSalsMan.Text == "" ? "" : XYEEncoding.strCodeHex(ltxtbSalsMan.Text);
                }
                else
                {
                    MessageBox.Show("盘盈员不能为空！");
                    ltxtbSalsMan.Focus();
                    return;
                }
                warehouseprofit.date = dateTimePicker1.Value;
                warehouseprofit.makeMan = ltxtbMakeMan.Text == "" ? "" : XYEEncoding.strCodeHex(ltxtbMakeMan.Text);
                warehouseprofit.examine = ltxtbShengHeMan.Text == "" ? "" : XYEEncoding.strCodeHex(ltxtbShengHeMan.Text);
                warehouseprofit.remark = labtextboxBotton2.Text == "" ? "" : XYEEncoding.strCodeHex(labtextboxBotton2.Text);
                warehouseprofit.checkState = 0;
                warehouseprofit.isClear = 1;
                warehouseprofit.updatetime = DateTime.Now;
                warehouseprofit.reserved1 = "";
                warehouseprofit.reserved2 = "";
                #endregion
            }
            catch (Exception ex)
            {
                MessageBox.Show("错误代码:2503-尝试创建盘盈单商品数据出错,请检查输入" + ex.Message, "盘盈单温馨提示");
                return;
            }

            try
            {
                #region 盘盈单表格详细数据
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
                        WarehouseInventoryProfitDetail warehouseprofitDetail = new WarehouseInventoryProfitDetail();
                        warehouseprofitDetail.barCode = gr["gridColumntiaoxingma"].Value.ToString() == "" ? "" : XYEEncoding.strCodeHex(gr["gridColumntiaoxingma"].Value.ToString());//条形码
                        warehouseprofitDetail.code = XYEEncoding.strCodeHex(textBoxOddNumbers.Text) + i.ToString();//单据code
                        warehouseprofitDetail.mainCode = XYEEncoding.strCodeHex(textBoxOddNumbers.Text);//主表code
                        warehouseprofitDetail.materialCode = gr["gridColumnmaterialcode"].Value.ToString() == "" ? "" : XYEEncoding.strCodeHex(gr["gridColumnmaterialcode"].Value.ToString());//物料code
                        warehouseprofitDetail.materialDaima = gr["material"].Value.ToString() == "" ? "" : XYEEncoding.strCodeHex(gr["material"].Value.ToString());//物料代码
                        warehouseprofitDetail.materialModel = gr["gridColumnmodel"].Value.ToString() == "" ? "" : XYEEncoding.strCodeHex(gr["gridColumnmodel"].Value.ToString());//规格型号
                        warehouseprofitDetail.materialName = gr["gridColumnname"].Value.ToString() == "" ? "" : XYEEncoding.strCodeHex(gr["gridColumnname"].Value.ToString());//物料名称
                        warehouseprofitDetail.materialUnit = gr["gridColumnunit"].Value.ToString() == "" ? "" : XYEEncoding.strCodeHex(gr["gridColumnunit"].Value.ToString());//单位
                        warehouseprofitDetail.price = Convert.ToDecimal(gr["gridColumnprice"].Value.ToString() == "" ? null : gr["gridColumnprice"].Value);//单价
                        warehouseprofitDetail.number = Convert.ToDecimal(gr["gridColumnzhangmianshu"].Value.ToString());//账面数量
                        warehouseprofitDetail.inventoryNumber = Convert.ToDecimal(gr["gridColumnpandianshu"].Value.ToString());//盘点数量
                        warehouseprofitDetail.profitNumber = Convert.ToDecimal(gr["gridColumnpanyingshu"].Value.ToString());//盘盈数量
                        warehouseprofitDetail.profitMoney = Convert.ToDecimal(gr["gridColumnmoney"].Value.ToString());//盘盈金额
                        warehouseprofitDetail.productionDate = Convert.ToDateTime(gr["gridColumndate"].Value.ToString() == "" ? "1990-01-01" : gr["gridColumndate"].Value);//生产日期
                        warehouseprofitDetail.qualityDate = Convert.ToDecimal(gr["gridColumnbaozhe"].Value.ToString() == "" ? 0 : gr["gridColumnbaozhe"].Value);//保质期
                        warehouseprofitDetail.effectiveDate = gr["gridColumnyouxiao"].Value == DBNull.Value ? Convert.ToDateTime("1990-01-01") : Convert.ToDateTime(gr["gridColumnyouxiao"].Value);//有效期至
                        warehouseprofitDetail.remark = gr["gridColumnremark"].Value.ToString() == "" ? "" : XYEEncoding.strCodeHex(gr["gridColumnremark"].Value.ToString());//备注
                        warehouseprofitDetail.isClear = 1;
                        warehouseprofitDetail.reserved1 = "";
                        warehouseprofitDetail.reserved2 = "";
                        warehouseprofitDetail.updateDate = DateTime.Now;
                        warehouseprofitDetail.warehouseCode = _storageCode;//仓库code
                        warehouseprofitDetail.warehouseName = _storageName;//仓库名称
                        GridRow dr = superGridControlShangPing.PrimaryGrid.Rows[0] as GridRow;
                        wareHouseprofitList.Add(warehouseprofitDetail);

                    }
                }
                #endregion
            }
            catch (Exception ex)
            {
                MessageBox.Show("错误代码：2504-尝试创建盘盈单商品详细数据出错,请检查输入" + ex.Message, "盘盈单温馨提示");
                return;
            }

            //增加一条盘盈单和盘盈详细数据
            object warehouseProfitResult = warehouseProfitinterface.AddAndModify(warehouseprofit, wareHouseprofitList);
            //this.textBoxid.Text = warehouseProfitResult.ToString();
            if (warehouseProfitResult != null)
            {
                MessageBox.Show("新增盘盈单数据成功", "盘盈单温馨提示");
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

            //盘盈单
            WarehouseInventoryProfit warehouseprofit = new WarehouseInventoryProfit();
            //盘盈商品列表
            List<WarehouseInventoryProfitDetail> wareHouseprofitList = new List<WarehouseInventoryProfitDetail>();
            try
            {
                #region 盘盈单基本数据
                warehouseprofit.code = textBoxOddNumbers.Text == "" ? "" : XYEEncoding.strCodeHex(textBoxOddNumbers.Text);//单据code
                if (cboInType.Text != null || cboInType.Text.ToString() != "")
                {
                    warehouseprofit.type = cboInType.Text == "" ? "" : XYEEncoding.strCodeHex(cboInType.Text);
                }
                else
                {
                    MessageBox.Show("盘盈单入库类别不能为空！");
                    cboInType.Focus();
                    return;
                }
                if (ltxtbSalsMan.Text != null || ltxtbSalsMan.Text.ToString() != "")
                {
                    warehouseprofit.operation = ltxtbSalsMan.Text == "" ? "" : XYEEncoding.strCodeHex(ltxtbSalsMan.Text);
                }
                else
                {
                    MessageBox.Show("盘盈员不能为空！");
                    ltxtbSalsMan.Focus();
                    return;
                }
                warehouseprofit.date = dateTimePicker1.Value;
                warehouseprofit.makeMan = ltxtbMakeMan.Text == "" ? "" : XYEEncoding.strCodeHex(ltxtbMakeMan.Text);
                warehouseprofit.examine = ltxtbShengHeMan.Text == "" ? "" : XYEEncoding.strCodeHex(ltxtbShengHeMan.Text);
                warehouseprofit.remark = labtextboxBotton2.Text == "" ? "" : XYEEncoding.strCodeHex(labtextboxBotton2.Text);
                warehouseprofit.checkState = 1;//审核状态
                warehouseprofit.isClear = 1;
                warehouseprofit.updatetime = DateTime.Now;
                warehouseprofit.reserved1 = "";
                warehouseprofit.reserved2 = "";
                #endregion
            }
            catch (Exception ex)
            {
                MessageBox.Show("错误代码:2505-尝试创建并审核盘盈单商品数据出错,请检查输入" + ex.Message, "盘盈单温馨提示");
                return;
            }

            try
            {
                #region 盘盈单表格详细数据
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
                        WarehouseInventoryProfitDetail warehouseprofitDetail = new WarehouseInventoryProfitDetail();
                        warehouseprofitDetail.barCode = gr["gridColumntiaoxingma"].Value.ToString() == "" ? "" : XYEEncoding.strCodeHex(gr["gridColumntiaoxingma"].Value.ToString());//条形码
                        warehouseprofitDetail.code = XYEEncoding.strCodeHex(textBoxOddNumbers.Text) + i.ToString();//单据code
                        warehouseprofitDetail.mainCode = XYEEncoding.strCodeHex(textBoxOddNumbers.Text);//主表code
                        warehouseprofitDetail.materialCode = gr["gridColumnmaterialcode"].Value.ToString() == "" ? "" : XYEEncoding.strCodeHex(gr["gridColumnmaterialcode"].Value.ToString());//物料code
                        warehouseprofitDetail.materialDaima = gr["material"].Value.ToString() == "" ? "" : XYEEncoding.strCodeHex(gr["material"].Value.ToString());//物料代码
                        warehouseprofitDetail.materialModel = gr["gridColumnmodel"].Value.ToString() == "" ? "" : XYEEncoding.strCodeHex(gr["gridColumnmodel"].Value.ToString());//规格型号
                        warehouseprofitDetail.materialName = gr["gridColumnname"].Value.ToString() == "" ? "" : XYEEncoding.strCodeHex(gr["gridColumnname"].Value.ToString());//物料名称
                        warehouseprofitDetail.materialUnit = gr["gridColumnunit"].Value.ToString() == "" ? "" : XYEEncoding.strCodeHex(gr["gridColumnunit"].Value.ToString());//单位
                        warehouseprofitDetail.price = Convert.ToDecimal(gr["gridColumnprice"].Value.ToString() == "" ? null : gr["gridColumnprice"].Value);//单价
                        warehouseprofitDetail.number = Convert.ToDecimal(gr["gridColumnzhangmianshu"].Value.ToString());//账面数量
                        warehouseprofitDetail.inventoryNumber = Convert.ToDecimal(gr["gridColumnpandianshu"].Value.ToString());//盘点数量
                        warehouseprofitDetail.profitNumber = Convert.ToDecimal(gr["gridColumnpanyingshu"].Value.ToString());//盘盈数量
                        warehouseprofitDetail.profitMoney = Convert.ToDecimal(gr["gridColumnmoney"].Value.ToString());//盘盈金额
                        warehouseprofitDetail.productionDate = Convert.ToDateTime(gr["gridColumndate"].Value.ToString() == "" ? "1990-01-01" : gr["gridColumndate"].Value);//生产日期
                        warehouseprofitDetail.qualityDate = Convert.ToDecimal(gr["gridColumnbaozhe"].Value.ToString() == "" ? 0 : gr["gridColumnbaozhe"].Value);//保质期
                        warehouseprofitDetail.effectiveDate = gr["gridColumnyouxiao"].Value == DBNull.Value ? Convert.ToDateTime("1990-01-01") : Convert.ToDateTime(gr["gridColumnyouxiao"].Value);//有效期至
                        warehouseprofitDetail.remark = gr["gridColumnremark"].Value.ToString() == "" ? "" : XYEEncoding.strCodeHex(gr["gridColumnremark"].Value.ToString());//备注
                        warehouseprofitDetail.isClear = 1;
                        warehouseprofitDetail.reserved1 = "";
                        warehouseprofitDetail.reserved2 = "";
                        warehouseprofitDetail.updateDate = DateTime.Now;
                        warehouseprofitDetail.warehouseCode = _storageCode;//仓库code
                        warehouseprofitDetail.warehouseName = _storageName;//仓库名称
                        GridRow dr = superGridControlShangPing.PrimaryGrid.Rows[0] as GridRow;
                        wareHouseprofitList.Add(warehouseprofitDetail);
                    }
                }
                #endregion
            }
            catch (Exception ex)
            {
                MessageBox.Show("错误代码：2506-尝试创建并审核盘盈单商品详细数据出错,请检查输入" + ex.Message, "盘盈单温馨提示");
                return;
            }

            //增加一条盘盈单和盘盈详细数据
            object warehouseProfitResult = warehouseProfitinterface.AddAndModify(warehouseprofit, wareHouseprofitList);
            //this.textBoxid.Text = warehouseProfitResult.ToString();
            if (warehouseProfitResult != null)
            {
                MessageBox.Show("新增并审核盘盈单数据成功", "盘盈单温馨提示");
                InitForm();
                this.picBoxShengHeProfit.Image = Properties.Resources.审核;
            }
        }

        /// <summary>
        /// 快捷方式设置
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void WareHouseInventoryProfitForm_KeyDown(object sender, KeyEventArgs e)
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
        /// 小表格的点击事件
        /// </summary>
        private void dataGridViewFuJiTableClick()
        {
            try
            {
                //业务员
                if (_Click == 1 || _Click == 2)
                {
                    string name = dataGridViewFuJia.Rows[dataGridViewFuJia.CurrentRow.Index].Cells["name"].Value.ToString();
                    ltxtbSalsMan.Text = name;
                    resizablePanel1.Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("错误代码：2508-双击绑定盘盈员数据出错！请检查：" + ex.Message, "盘盈单温馨提示");
            }
        }

        /// <summary>
        /// 验证Code是否重复
        /// </summary>
        private string YanZhengCode()
        {
            if (warehouseProfitinterface.Exists(XYEEncoding.strCodeHex(_WareHousePanYingCode)))
            {
                _WareHousePanYingCode = BuildCode.ModuleCode("WIP");
            }
            else
            {
                _WareHousePanYingCode = textBoxOddNumbers.Text;
            }
            return _WareHousePanYingCode;
        }

    }
}
