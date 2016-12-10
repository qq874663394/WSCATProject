using DevComponents.DotNetBar.SuperGrid;
using HelperUtility;
using HelperUtility.Encrypt;
using InterfaceLayer.Base;
using InterfaceLayer.Warehouse;
using LogicLayer.Warehouse;
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
    public partial class WareHouseInventoryLossForm : TestForm
    {
        public WareHouseInventoryLossForm()
        {
            InitializeComponent();
        }

        #region 调用接口以及加密解密方法
        CodingHelper ch = new CodingHelper();
        EmpolyeeInterface employee = new EmpolyeeInterface();
        WarehouseInventoryDetailInterface warehouseinv = new WarehouseInventoryDetailInterface();
        WarehouseInventoryLossInterface warehouseinvloss = new WarehouseInventoryLossInterface();
        #endregion

        #region  数据字段
        /// <summary>
        /// 所有业务员
        /// </summary>
        private DataTable _AllEmployee = null;
        /// <summary>
        /// 点击的项 1为业务员
        /// </summary>
        private int _Click = 0;
        /// <summary>
        /// 盘亏单code
        /// </summary>
        private string _WareHousePanKuiCode;
        /// <summary>
        /// 统计贮存数量
        /// </summary>
        private decimal _AllZhuCunShuLiang;
        /// <summary>
        /// 统计盘点数量
        /// </summary>
        private decimal _AllPanDianShuLiang;
        /// <summary>
        /// 统计盘亏数量
        /// </summary>
        private decimal _AllPanKuiShuLiang;
        /// <summary>
        /// 统计盘亏金额
        /// </summary>
        private decimal _AllPanKuiMoney;
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
        /// 仓库code
        /// </summary>
        private string _storageName;
        public string StorageName
        {
            get { return _storageName; }
            set { _storageName = value; }
        }
        #endregion

        private void WareHouseInventoryLossForm_Load(object sender, EventArgs e)
        {
            try
            {
                //业务员
                _AllEmployee = employee.SelSupplierTable(false);

                //数量
                GridDoubleInputEditControl gdiecNumber = superGridControlShangPing.PrimaryGrid.Columns["pandiannumber"].EditControl as GridDoubleInputEditControl;
                gdiecNumber.MinValue = 0;
                gdiecNumber.MaxValue = 999999999;

                //禁用自动创建列
                dataGridViewShangPing.AutoGenerateColumns = false;
                dataGridViewFuJia.AutoGenerateColumns = false;
                superGridControlShangPing.HScrollBarVisible = true;
                //绑定事件 双击事填充内容并隐藏列表
                dataGridViewFuJia.CellDoubleClick += dataGridViewFuJia_CellDoubleClick;
                dataGridViewShangPing.CellDoubleClick += dataGridViewShangPing_CellDoubleClick;
                // 将dataGridView中的内容居中显示
                dataGridViewFuJia.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                toolStripBtnSave.Click += toolStripBtnSave_Click;//保存按钮
                toolStripBtnShengHe.Click += toolStripBtnShengHe_Click;//审核按钮
                dataGridViewFuJia.KeyDown += DataGridViewFuJia_KeyDown;

                //生成code 和显示条形码
                _WareHousePanKuiCode = BuildCode.ModuleCode("WIL");
                textBoxOddNumbers.Text = _WareHousePanKuiCode;
                barcodeXYE.Code128 _Code = new barcodeXYE.Code128();
                _Code.ValueFont = new Font("微软雅黑", 20);
                System.Drawing.Bitmap imgTemp = _Code.GetCodeImage(textBoxOddNumbers.Text, barcodeXYE.Code128.Encode.Code128A);
                pictureBox9.Image = imgTemp;
                superGridControlShangPing.PrimaryGrid.AutoGenerateColumns = false;//禁止自动创建列
                superGridControlShangPing.DefaultVisualStyles.CellStyles.Default.Alignment =
                DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleCenter;//设置内容居中
                superGridControlShangPing.PrimaryGrid.DataSource = ch.DataTableReCoding(warehouseinv.Search(5, XYEEncoding.strCodeHex(_storageCode)));
                superGridControlShangPing.PrimaryGrid.EnsureVisible();
                //调用合计行数据
                InitDataGridView();
                //最后一行做统计行
                try
                {
                    GridRow gr = new GridRow();
                    //逐行统计数据总数
                    decimal tempAllzhucun = 0;
                    decimal tempAllpandian = 0;
                    decimal tempAllpankui = 0;
                    decimal tempAllpankuimoney = 0;
                    for (int i = 0; i < superGridControlShangPing.PrimaryGrid.Rows.Count - 1; i++)
                    {
                        GridRow tempGR = superGridControlShangPing.PrimaryGrid.Rows[i] as GridRow;
                        tempAllzhucun += Convert.ToDecimal(tempGR["zhangcunnumber"].FormattedValue);
                        tempAllpandian += Convert.ToDecimal(tempGR["pandiannumber"].FormattedValue);
                        tempAllpankui += Convert.ToDecimal(tempGR["pankuinumber"].FormattedValue);
                        tempAllpankuimoney += Convert.ToDecimal(tempGR["pankuimoney"].FormattedValue);
                    }
                    _AllZhuCunShuLiang = tempAllzhucun;
                    _AllPanDianShuLiang = tempAllpandian;
                    _AllPanKuiShuLiang = tempAllpankui;
                    _AllPanKuiMoney = tempAllpankuimoney;
                    gr = (GridRow)superGridControlShangPing.PrimaryGrid.LastSelectableRow;
                    gr["zhangcunnumber"].Value = _AllZhuCunShuLiang.ToString();
                    gr["pandiannumber"].Value = _AllPanDianShuLiang.ToString();
                    gr["pankuinumber"].Value = _AllPanKuiShuLiang.ToString();
                    gr["pankuimoney"].Value = _AllPanKuiMoney.ToString();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("错误代码：2602-盘亏单加载时统计数量失败！请检查：" + ex.Message, "盘亏单温馨提示");
                    return;
                }
                //绑定盘亏摘要
                labtextboxTop7.Text = "由【" + _storageName + "】生成";
                pictureBoxshenghe.Parent = pictureBoxtitle;
                cboOutType.SelectedIndex = 0;

            }
            catch (Exception ex)
            {
                MessageBox.Show("错误代码：2601-窗体加载时，初始化数据错误，没有仓库code" + ex.Message, "盘亏单温馨提示");
                this.Close();
                return;
            }
        }

        private void DataGridViewFuJia_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode==Keys.Enter)
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

        #region  初始化数据

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
            gr.Cells["zhangcunnumber"].Value = 0;
            gr.Cells["zhangcunnumber"].CellStyles.Default.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleCenter;
            gr.Cells["zhangcunnumber"].CellStyles.Default.Background.Color1 = Color.Orange;
            gr.Cells["pandiannumber"].Value = 0;
            gr.Cells["pandiannumber"].CellStyles.Default.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleCenter;
            gr.Cells["pandiannumber"].CellStyles.Default.Background.Color1 = Color.Orange;
            gr.Cells["pankuinumber"].Value = 0;
            gr.Cells["pankuinumber"].CellStyles.Default.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleCenter;
            gr.Cells["pankuinumber"].CellStyles.Default.Background.Color1 = Color.Orange;
            gr.Cells["pankuimoney"].Value = 0;
            gr.Cells["pankuimoney"].CellStyles.Default.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleCenter;
            gr.Cells["pankuimoney"].CellStyles.Default.Background.Color1 = Color.Orange;
        }

        /// <summary>
        /// 非空验证
        /// </summary>
        private bool isNUllValidate()
        {
            if (cboOutType.Text.Trim() == null)
            {
                MessageBox.Show("出库类别不能为空！");
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
        /// 初始化盘亏员
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

                    resizablePanel1.Location = new Point(234, 440);
                    dataGridViewFuJia.DataSource = ch.DataTableReCoding(_AllEmployee);
                    resizablePanel1.Visible = true;

                    if (this.WindowState == FormWindowState.Maximized)
                    {
                        resizablePanel1.Location = new Point(230, 670);
                        return;
                    }
                    if (this.WindowState == FormWindowState.Normal)
                    {
                        resizablePanel1.Location = new Point(230, 450);
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("错误代码：2607-点击盘亏员数据显示出错，请检查：" + ex.Message, "盘亏单温馨提示");
            }
        }

        /// <summary>
        /// 设置盘点
        /// </summary>
        private void InitForm()
        {
            cboOutType.Enabled = false;
            labtextboxTop7.ReadOnly = true;
            superGridControlShangPing.PrimaryGrid.ReadOnly = true;
            ltxtbMakeMan.ReadOnly = true;
            ltxtbSalsMan.ReadOnly = true;
            ltxtbShengHeMan.ReadOnly = true;
            toolStripBtnSave.Enabled = false;
            toolStripBtnShengHe.Enabled = false;
            pictureBoxEmployee.Enabled = false;
            dateTimePicker1.Enabled = false;
            textBoxOddNumbers.ReadOnly = true;
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

        /// <summary>
        ///盘亏员模糊查询
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
                MessageBox.Show("错误代码：2609-模糊查询盘亏员出错" + ex.Message,"盘亏单温馨提示");
            }

        }

        /// <summary>
        /// 按下ESC关闭子窗体
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void WareHouseInventoryLossForm_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Escape)
            {
                this.resizablePanel1.Visible = false;
            }
        }

        /// <summary>
        /// 统计和验证数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void superGridControlShangPing_CellValidated(object sender, GridCellValidatedEventArgs e)
        {
            //最后一行做统计行
            GridRow gr = e.GridPanel.Rows[e.GridCell.RowIndex] as GridRow;
            try
            {
                //逐行统计数据总数
                decimal tempAllzhucun = 0;
                decimal tempAllpandian = 0;
                decimal tempAllpankui = 0;
                decimal tempAllpankuimoney = 0;
                for (int i = 0; i < superGridControlShangPing.PrimaryGrid.Rows.Count - 1; i++)
                {
                    GridRow tempGR = superGridControlShangPing.PrimaryGrid.Rows[i] as GridRow;
                    tempAllzhucun += Convert.ToDecimal(tempGR["zhangcunnumber"].FormattedValue);
                    tempAllpandian += Convert.ToDecimal(tempGR["pandiannumber"].FormattedValue);
                    tempAllpankui += Convert.ToDecimal(tempGR["pankuinumber"].FormattedValue);
                    tempAllpankuimoney += Convert.ToDecimal(tempGR["pankuimoney"].FormattedValue);
                }
                _AllZhuCunShuLiang = tempAllzhucun;
                _AllPanDianShuLiang = tempAllpandian;
                _AllPanKuiShuLiang = tempAllpankui;
                _AllPanKuiMoney = tempAllpankuimoney;
                gr = (GridRow)superGridControlShangPing.PrimaryGrid.LastSelectableRow;
                gr["zhangcunnumber"].Value = _AllZhuCunShuLiang.ToString();
                gr["pandiannumber"].Value = _AllPanDianShuLiang.ToString();
                gr["pankuinumber"].Value = _AllPanKuiShuLiang.ToString();
                gr["pankuimoney"].Value = _AllPanKuiMoney.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("错误代码：2610-统计表格里数量出错！请检查：" + ex.Message);
            }
        }

        private void WareHouseInventoryLossForm_Activated(object sender, EventArgs e)
        {
            cboOutType.Focus();
        }

        /// <summary>
        /// 保存按钮的函数
        /// </summary>
        private void  Save()
        {
            //非空验证
            if (isNUllValidate() == false)
            {
                return;
            }

            //盘亏单
            WarehouseInventoryLoss warehouseloss = new WarehouseInventoryLoss();
            //盘亏商品列表
            List<WarehouseInventoryLossDetail> wareHouselossList = new List<WarehouseInventoryLossDetail>();
            try
            {
                #region 盘亏单基本数据
                warehouseloss.code = YanZhengCode() == "" ? "" : XYEEncoding.strCodeHex(YanZhengCode());
                if (cboOutType.Text != null || cboOutType.Text.ToString() != "")
                {
                    warehouseloss.type = cboOutType.Text == "" ? "" : XYEEncoding.strCodeHex(cboOutType.Text);
                }
                else
                {
                    MessageBox.Show("出库类别不能为空！");
                    cboOutType.Focus();
                    return;
                }
                if (ltxtbSalsMan.Text != null || ltxtbSalsMan.Text.ToString() != "")
                {
                    warehouseloss.operation = ltxtbSalsMan.Text == "" ? "" : XYEEncoding.strCodeHex(ltxtbSalsMan.Text);
                }
                else
                {
                    MessageBox.Show("盘亏员不能为空！");
                    ltxtbSalsMan.Focus();
                    return;
                }
                warehouseloss.date = dateTimePicker1.Value;
                warehouseloss.examine = ltxtbShengHeMan.Text == "" ? "" : XYEEncoding.strCodeHex(ltxtbShengHeMan.Text);
                warehouseloss.isClear = 1;
                warehouseloss.makeMan = ltxtbMakeMan.Text == "" ? "" : XYEEncoding.strCodeHex(ltxtbMakeMan.Text);   
                warehouseloss.remark = labtextboxTop7.Text == "" ? "" : XYEEncoding.strCodeHex(labtextboxTop7.Text);
                warehouseloss.reserved1 = "";
                warehouseloss.reserved2 = "";
                warehouseloss.checkState =0;
                warehouseloss.updatetime = DateTime.Now;
                #endregion
            }
            catch (Exception ex)
            {
                MessageBox.Show("错误代码:2603-尝试创建盘亏单商品数据出错,请检查输入" + ex.Message, "盘亏单温馨提示");
                return;
            }

            try
            {
                #region 盘亏单表格详细数据
                //获得商品列表数据,准备传给base层新增数据
                GridRow g = (GridRow)superGridControlShangPing.PrimaryGrid.Rows[ClickRowIndex];
                GridItemsCollection grs = superGridControlShangPing.PrimaryGrid.Rows;
                int i = 0;
                DateTime nowDataTime = DateTime.Now;
                foreach (GridRow gr in grs)
                {
                    if (gr["name"].FormattedValue != "")
                    {
                        i++;
                        WarehouseInventoryLossDetail warehouselossDetail = new WarehouseInventoryLossDetail();
                        warehouselossDetail.barCode = gr["tiaoxingma"].Value.ToString() == "" ? "" : XYEEncoding.strCodeHex(gr["tiaoxingma"].Value.ToString());
                        warehouselossDetail.code = XYEEncoding.strCodeHex(textBoxOddNumbers.Text) + i.ToString();
                        warehouselossDetail.effectiveDate = gr["youxiaoqi"].Value == DBNull.Value ? Convert.ToDateTime("1990-01-01") : Convert.ToDateTime(gr["youxiaoqi"].Value); ;
                        warehouselossDetail.inventoryNumber = Convert.ToDecimal(gr["pandiannumber"].Value.ToString());
                        warehouselossDetail.isClear = 1;
                        warehouselossDetail.lossMoney = Convert.ToDecimal(gr["pankuimoney"].Value.ToString());
                        warehouselossDetail.lossNumber = Convert.ToDecimal(gr["pankuinumber"].Value.ToString());
                        warehouselossDetail.mainCode = XYEEncoding.strCodeHex(textBoxOddNumbers.Text);
                        warehouselossDetail.materialCode = gr["materialcode"].Value.ToString() == "" ? "" : XYEEncoding.strCodeHex(gr["materialcode"].Value.ToString());
                        warehouselossDetail.materialDaima = gr["material"].Value.ToString() == "" ? "" : XYEEncoding.strCodeHex(gr["material"].Value.ToString());
                        warehouselossDetail.materialModel = gr["model"].Value.ToString() == "" ? "" : XYEEncoding.strCodeHex(gr["model"].Value.ToString());
                        warehouselossDetail.materialName = gr["name"].Value.ToString() == "" ? "" : XYEEncoding.strCodeHex(gr["name"].Value.ToString());
                        warehouselossDetail.materialUnit = gr["unit"].Value.ToString() == "" ? "" : XYEEncoding.strCodeHex(gr["unit"].Value.ToString());
                        warehouselossDetail.number = Convert.ToDecimal(gr["zhangcunnumber"].Value.ToString());
                        warehouselossDetail.price = Convert.ToDecimal(gr["price"].Value.ToString());
                        warehouselossDetail.productionDate = gr["shengchandate"].Value == DBNull.Value ? Convert.ToDateTime("1990-01-01") : Convert.ToDateTime(gr["shengchandate"].Value);
                        warehouselossDetail.qualityDate = Convert.ToDecimal(gr["baozhiqi"].Value.ToString());
                        warehouselossDetail.reserved1 = "";
                        warehouselossDetail.reserved2 = "";
                        warehouselossDetail.updateDate = DateTime.Now;
                        warehouselossDetail.warehouseCode = "";
                        warehouselossDetail.warehouseName = "";
                        GridRow dr = superGridControlShangPing.PrimaryGrid.Rows[0] as GridRow;
                        wareHouselossList.Add(warehouselossDetail);
                    }
                }
                #endregion
            }
            catch (Exception ex)
            {
                MessageBox.Show("错误代码：2604-尝试创建盘亏单商品详细数据出错,请检查输入" + ex.Message, "盘亏单温馨提示");
                return;
            }
            //增加一条入库单和入库单详细数据
            object Result = warehouseinvloss.AddAndModify(warehouseloss, wareHouselossList);
            // this.textBoxid.Text = warehouseInResult.ToString(); //前单后单
            if (Result != null)
            {
                MessageBox.Show("新增盘亏单数据成功", "盘亏单温馨提示");
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
            //盘亏单
            WarehouseInventoryLoss warehouseloss = new WarehouseInventoryLoss();
            //盘亏商品列表
            List<WarehouseInventoryLossDetail> wareHouselossList = new List<WarehouseInventoryLossDetail>();
            try
            {
                #region 盘亏单基本数据
                warehouseloss.code = textBoxOddNumbers.Text == "" ? "" : XYEEncoding.strCodeHex(textBoxOddNumbers.Text);
                warehouseloss.code = YanZhengCode() == "" ? "" : XYEEncoding.strCodeHex(YanZhengCode());
                if (cboOutType.Text != null || cboOutType.Text.ToString() != "")
                {
                    warehouseloss.type = cboOutType.Text == "" ? "" : XYEEncoding.strCodeHex(cboOutType.Text);
                }
                else
                {
                    MessageBox.Show("出库类别不能为空！");
                    cboOutType.Focus();
                    return;
                }
                if (ltxtbSalsMan.Text != null || ltxtbSalsMan.Text.ToString() != "")
                {
                    warehouseloss.operation = ltxtbSalsMan.Text == "" ? "" : XYEEncoding.strCodeHex(ltxtbSalsMan.Text);
                }
                else
                {
                    MessageBox.Show("盘亏员不能为空！");
                    ltxtbSalsMan.Focus();
                    return;
                }
                warehouseloss.date = dateTimePicker1.Value;
                warehouseloss.examine = ltxtbShengHeMan.Text == "" ? "" : XYEEncoding.strCodeHex(ltxtbShengHeMan.Text);
                warehouseloss.isClear = 1;
                warehouseloss.makeMan = ltxtbMakeMan.Text == "" ? "" : XYEEncoding.strCodeHex(ltxtbMakeMan.Text);
                warehouseloss.remark = labtextboxTop7.Text == "" ? "" : XYEEncoding.strCodeHex(labtextboxTop7.Text);
                warehouseloss.reserved1 = "";
                warehouseloss.reserved2 = "";
                warehouseloss.checkState =1;
                warehouseloss.updatetime = DateTime.Now;
                #endregion
            }
            catch (Exception ex)
            {
                MessageBox.Show("错误代码:2605-尝试创建并审核盘亏单商品数据出错,请检查输入" + ex.Message, "盘亏单温馨提示");
                return;
            }
            try
            {
                #region 盘亏单表格详细数据
                //获得商品列表数据,准备传给base层新增数据
                GridRow g = (GridRow)superGridControlShangPing.PrimaryGrid.Rows[ClickRowIndex];
                GridItemsCollection grs = superGridControlShangPing.PrimaryGrid.Rows;
                int i = 0;
                DateTime nowDataTime = DateTime.Now;
                foreach (GridRow gr in grs)
                {
                    if (gr["name"].FormattedValue != "")
                    {
                        i++;
                        WarehouseInventoryLossDetail warehouselossDetail = new WarehouseInventoryLossDetail();
                        warehouselossDetail.barCode = gr["tiaoxingma"].Value.ToString() == "" ? "" : XYEEncoding.strCodeHex(gr["tiaoxingma"].Value.ToString());
                        warehouselossDetail.code = XYEEncoding.strCodeHex(textBoxOddNumbers.Text) + i.ToString();
                        warehouselossDetail.effectiveDate = gr["youxiaoqi"].Value == DBNull.Value ? Convert.ToDateTime("1990-01-01") : Convert.ToDateTime(gr["youxiaoqi"].Value);
                        warehouselossDetail.inventoryNumber = Convert.ToDecimal(gr["pandiannumber"].Value.ToString());
                        warehouselossDetail.isClear = 1;
                        warehouselossDetail.lossMoney = Convert.ToDecimal(gr["pankuimoney"].Value.ToString());
                        warehouselossDetail.lossNumber = Convert.ToDecimal(gr["pankuinumber"].Value.ToString());
                        warehouselossDetail.mainCode = XYEEncoding.strCodeHex(textBoxOddNumbers.Text);
                        warehouselossDetail.materialCode = gr["materialcode"].Value.ToString() == "" ? "" : XYEEncoding.strCodeHex(gr["materialcode"].Value.ToString());
                        warehouselossDetail.materialDaima = gr["material"].Value.ToString() == "" ? "" : XYEEncoding.strCodeHex(gr["material"].Value.ToString());
                        warehouselossDetail.materialModel = gr["model"].Value.ToString() == "" ? "" : XYEEncoding.strCodeHex(gr["model"].Value.ToString());
                        warehouselossDetail.materialName = gr["name"].Value.ToString() == "" ? "" : XYEEncoding.strCodeHex(gr["name"].Value.ToString());
                        warehouselossDetail.materialUnit = gr["unit"].Value.ToString() == "" ? "" : XYEEncoding.strCodeHex(gr["unit"].Value.ToString());
                        warehouselossDetail.number = Convert.ToDecimal(gr["zhangcunnumber"].Value.ToString());
                        warehouselossDetail.price = Convert.ToDecimal(gr["price"].Value.ToString());
                        warehouselossDetail.productionDate = gr["shengchandate"].Value == DBNull.Value ? Convert.ToDateTime("1990-01-01") : Convert.ToDateTime(gr["shengchandate"].Value);
                        warehouselossDetail.qualityDate = Convert.ToDecimal(gr["baozhiqi"].Value.ToString());
                        warehouselossDetail.reserved1 = "";
                        warehouselossDetail.reserved2 = "";
                        warehouselossDetail.updateDate = DateTime.Now;
                        warehouselossDetail.warehouseCode = "";
                        warehouselossDetail.warehouseName = "";
                        GridRow dr = superGridControlShangPing.PrimaryGrid.Rows[0] as GridRow;
                        wareHouselossList.Add(warehouselossDetail);
                    }
                }
                #endregion
            }
            catch (Exception ex)
            {
                MessageBox.Show("错误代码：2606-尝试创建并审核盘亏单商品数据出错,请检查输入" + ex.Message, "盘亏单温馨提示");
                return;
            }

            //增加一条入库单和入库单详细数据
            object Result = warehouseinvloss.AddAndModify(warehouseloss, wareHouselossList);
            // this.textBoxid.Text = warehouseInResult.ToString(); //前单后单
            if (Result != null)
            {
                MessageBox.Show("审核盘亏单数据成功", "盘亏单温馨提示");
                pictureBoxshenghe.Image = Properties.Resources.审核;
                InitForm();
            }
        }

        /// <summary>
        /// 快捷方式函数
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void WareHouseInventoryLossForm_KeyDown(object sender, KeyEventArgs e)
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
                    ShengHe();
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
        /// 判断code是否重复
        /// </summary>
        /// <returns></returns>
        private string YanZhengCode()
        {
            if (warehouseinvloss.Exists(XYEEncoding.strCodeHex(_WareHousePanKuiCode)))
            {
                //生成code 和显示条形码
                _WareHousePanKuiCode = BuildCode.ModuleCode("WIL");
            }
            else
            {
                _WareHousePanKuiCode = textBoxOddNumbers.Text;
            }
            return _WareHousePanKuiCode;
        }

    }
}
