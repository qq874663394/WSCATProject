using DevComponents.DotNetBar.SuperGrid;
using HelperUtility;
using HelperUtility.Encrypt;
using InterfaceLayer.Base;
using InterfaceLayer.Warehouse;
using Model;
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
    public partial class WareHouseAdjustPriceForm : TestForm
    {
        public WareHouseAdjustPriceForm()
        {
            InitializeComponent();
        }

        #region 调用接口以及加密解密方法
        CodingHelper ch = new CodingHelper();
        EmpolyeeInterface employee = new EmpolyeeInterface();
        StorageInterface storage = new StorageInterface();
        WarehouseMainInterface waremain = new WarehouseMainInterface();
        WarehouseAdjustPriceInterface warehouseAdjust = new WarehouseAdjustPriceInterface();
        #endregion

        #region  数据字段
        /// <summary>
        /// 所有业务员
        /// </summary>
        private DataTable _AllEmployee = null;
        /// <summary>
        /// 点击的项,1业务员
        /// </summary>
        private int _Click = 0;
        /// <summary>
        /// 调价单code
        /// </summary>
        private string _WareHouseAdjCode;
        /// <summary>
        /// 所有商品列表
        /// </summary>
        private DataTable _AllMaterial = null;
        /// <summary>
        /// 保存商品Code
        /// </summary>
        private string B = "";
        /// <summary>
        /// 所有仓库
        /// </summary>
        private DataTable _AllStorage = null;
        /// <summary>
        /// 仓库列表
        /// </summary>
        private KeyValuePair<string, string> _ClickStorageList;
        /// <summary>
        /// 保存仓库的Code
        /// </summary>
        private string _StorageCode = "";
        /// <summary>
        /// 保存仓库
        /// </summary>
        private string _Storage;
        /// <summary>
        /// 统计调前金额
        /// </summary>
        private decimal _MaterialBeforeMoney;
        /// <summary>
        /// 统计调后金额
        /// </summary>
        private decimal _MaterialAfterMoney;
        /// <summary>
        /// 统计调价金额
        /// </summary>
        private decimal _MaterialAdjMoney;
        /// <summary>
        /// 统计数量
        /// </summary>
        private decimal _MaterialNumber;
        ///// <summary>
        ///// 保存仓库状态 1、仓库 2、商品列表
        ///// </summary>
        private int _StorageState;
        /// <summary>
        /// 统计调前金额
        /// </summary>
        private decimal _beforeMoney;
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

        private void WareHouseAdjustPriceForm_Load(object sender, EventArgs e)
        {
            try
            {
                //业务员
                _AllEmployee = employee.SelSupplierTable(false);
                //仓库
                _AllStorage = storage.GetList(00, "");
                superGridControlShangPing.PrimaryGrid.SortCycle = SortCycle.AscDesc;    //排序方式范围
                superGridControlShangPing.PrimaryGrid.AddSort(superGridControlShangPing.PrimaryGrid.Columns[0], SortDirection.Ascending);//设置排序列和排序方式
                //调后单价
                GridDoubleInputEditControl diaoruprice = superGridControlShangPing.PrimaryGrid.Columns["gridColumnafterprice"].EditControl as GridDoubleInputEditControl;
                diaoruprice.MinValue = 0;
                diaoruprice.MaxValue = 999999999;
                //禁用自动创建列
                dataGridViewShangPing.AutoGenerateColumns = false;
                dataGridViewFuJia.AutoGenerateColumns = false;
                superGridControlShangPing.HScrollBarVisible = true;
                //绑定事件 双击事填充内容并隐藏列表
                dataGridViewFuJia.CellDoubleClick += dataGridViewFuJia_CellDoubleClick;
                dataGridViewShangPing.CellDoubleClick += dataGridViewShangPing_CellDoubleClick;
                toolStripBtnSave.Click += toolStripBtnSave_Click;//保存按钮
                toolStripBtnShengHe.Click += toolStripBtnShengHe_Click;//审核按钮
                dataGridViewFuJia.KeyDown += DataGridViewFuJia_KeyDown;

                cboadjType.SelectedIndex = 0;
                // 将dataGridView中的内容居中显示
                dataGridViewFuJia.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                //显示行号
                superGridControlShangPing.PrimaryGrid.ShowRowGridIndex = true;
                //内容居中
                superGridControlShangPing.DefaultVisualStyles.CellStyles.Default.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleCenter;
                //调用合计行数据
                InitDataGridView();
                //生成code 和显示条形码
                _WareHouseAdjCode = BuildCode.ModuleCode("WAP");
                textBoxOddNumbers.Text = _WareHouseAdjCode;
                barcodeXYE.Code128 _Code = new barcodeXYE.Code128();
                _Code.ValueFont = new Font("微软雅黑", 20);
                System.Drawing.Bitmap imgTemp = _Code.GetCodeImage(textBoxOddNumbers.Text, barcodeXYE.Code128.Encode.Code128A);
                pictureBox9.Image = imgTemp;
            }
            catch (Exception ex)
            {
                MessageBox.Show("错误代码：2701-窗体加载时出错！请检查：" + ex.Message, "调价单温馨提示！");
                this.Close();
                return;
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
        /// 验证单号
        /// </summary>
        /// <returns></returns>
        private string validateCode()
        {
            //验证单号
            if (warehouseAdjust.Exists(XYEEncoding.strCodeHex(_WareHouseAdjCode)))
            {
                _WareHouseAdjCode = BuildCode.ModuleCode("WAP");
            }
            else
            {
                _WareHouseAdjCode = textBoxOddNumbers.Text;
            }

            return _WareHouseAdjCode;
        }

        /// <summary>
        /// 保存的封装函数
        /// </summary>
        private void Save()
        {
            //非空验证
            if (isNUllValidate() == false)
            {
                return;
            }
            //获得界面上的数据,准备传给base层新增数据
            //WarehouseAdjustPriceInterface warehouseAdjpriceinterface = new WarehouseAdjustPriceInterface();
            //调价单
            WarehouseAdjustPrice warehouseADJprice = new WarehouseAdjustPrice();
            //调价单商品列表
            List<WarehouseAdjustPriceDetail> warehouseADJpriceList = new List<WarehouseAdjustPriceDetail>();
            try
            {
                #region 调价单基本数据
                warehouseADJprice.code = XYEEncoding.strCodeHex(validateCode());//单据code
                if (cboadjType.Text != null || cboadjType.Text.ToString() != "")
                {
                    warehouseADJprice.type = cboadjType.Text == "" ? "" : XYEEncoding.strCodeHex(cboadjType.Text);//调价类别
                }
                else
                {
                    MessageBox.Show("调价类别不能为空！");
                    cboadjType.Focus();
                    return;
                }
                if (ltxtbSalsMan.Text != null || ltxtbSalsMan.Text.ToString() != "")
                {
                    warehouseADJprice.operationMan = ltxtbSalsMan.Text == "" ? "" : XYEEncoding.strCodeHex(ltxtbSalsMan.Text);//调价员
                }
                else
                {
                    MessageBox.Show("调价员不能为空！");
                    ltxtbSalsMan.Focus();
                    return;
                }
                warehouseADJprice.date = dateTimePicker1.Value;//单据日期
                warehouseADJprice.makeMan = ltxtbMakeMan.Text == "" ? "" : XYEEncoding.strCodeHex(ltxtbMakeMan.Text);//制单人
                warehouseADJprice.checkMan = ltxtbShengHeMan.Text == "" ? "" : XYEEncoding.strCodeHex(ltxtbShengHeMan.Text);//审核人
                warehouseADJprice.remark = labtextboxTop9.Text == "" ? "" : XYEEncoding.strCodeHex(labtextboxTop9.Text);//摘要
                warehouseADJprice.checkState = 0; //审核状态
                warehouseADJprice.isClear = 1;
                warehouseADJprice.updateDate = DateTime.Now;
                warehouseADJprice.reserved1 = "";
                warehouseADJprice.reserved2 = "";
                #endregion
            }
            catch (Exception ex)
            {
                MessageBox.Show("错误代码:2702-尝试创建调价单商品数据出错,请检查输入" + ex.Message, "调价单温馨提示");
                return;
            }

            try
            {
                #region 调价单表格详细数据
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
                        WarehouseAdjustPriceDetail warehouseAdjDetail = new WarehouseAdjustPriceDetail();
                        if (gr["gridColumnStock"].Value.ToString() != "")
                        {
                            warehouseAdjDetail.stockName =XYEEncoding.strCodeHex(gr["gridColumnStock"].Value.ToString());//仓库名称
                        }
                        else
                        {
                            MessageBox.Show("单据体表格里仓库不能为空！");
                            return;
                        }
                        if (gr["material"].Value.ToString() != "")
                        {
                            warehouseAdjDetail.materiaDaima = XYEEncoding.strCodeHex(gr["material"].Value.ToString());//商品代码
                        }
                        else
                        {
                            MessageBox.Show("单据体表格里商品代码不能为空！");
                            return;
                        }
                        decimal beforeMoney = Convert.ToDecimal(gr["gridColumnnumber"].Value) * Convert.ToDecimal(gr["gridColumnbeforeprice"].Value);
                        if (beforeMoney == Convert.ToDecimal(gr["gridColumnbeforemoney"].Value))
                        {
                            warehouseAdjDetail.curMoney = Convert.ToDecimal(gr["gridColumnbeforemoney"].Value);//调前金额
                        }
                        else
                        {
                            MessageBox.Show("单据体表格里调前金额计算错误！");
                            return;
                        }
                        decimal afterMoney = Convert.ToDecimal(gr["gridColumnnumber"].Value) * Convert.ToDecimal(gr["gridColumnafterprice"].Value);
                        if (afterMoney == Convert.ToDecimal(gr["gridColumnaftermoney"].Value))
                        {
                            warehouseAdjDetail.money = Convert.ToDecimal(gr["gridColumnaftermoney"].Value);//调后金额
                        }
                        else
                        {
                            MessageBox.Show("单据体表格里调后金额计算错误！");
                            return;
                        }
                        decimal tiaojiaMoney = afterMoney - beforeMoney;
                        if (tiaojiaMoney == Convert.ToDecimal(gr["gridColumnmoneyadj"].Value))
                        {
                            warehouseAdjDetail.lostMoney = Convert.ToDecimal(gr["gridColumnmoneyadj"].Value);//调价差额
                        }
                        else
                        {
                            MessageBox.Show("单据体表格里调价金额计算错误！");
                            return;
                        }
                        warehouseAdjDetail.stockCode = gr["gridColumnstockcode"].Value == null ? "" : XYEEncoding.strCodeHex(gr["gridColumnstockcode"].Value.ToString());//仓库code                     
                        warehouseAdjDetail.code = XYEEncoding.strCodeHex(textBoxOddNumbers.Text) + i.ToString();//单据code
                        warehouseAdjDetail.mainCode = XYEEncoding.strCodeHex(textBoxOddNumbers.Text);//主表code                      
                        warehouseAdjDetail.materialCode = gr["gridColumnmaterialcode"].Value == null ? "" : XYEEncoding.strCodeHex(gr["gridColumnmaterialcode"].Value.ToString());//商品code
                        warehouseAdjDetail.barCode = gr["gridColumntiaoma"].Value == null ? "" : XYEEncoding.strCodeHex(gr["gridColumntiaoma"].Value.ToString());//条形码
                        warehouseAdjDetail.materialName = gr["gridColumnname"].Value == null ? "" : XYEEncoding.strCodeHex(gr["gridColumnname"].Value.ToString());//物料名称
                        warehouseAdjDetail.materialModel = gr["gridColumnmodel"].Value == null ? "" : XYEEncoding.strCodeHex(gr["gridColumnmodel"].Value.ToString());//规格型号
                        warehouseAdjDetail.materialUnit = gr["gridColumnunit"].Value == null ? "" : XYEEncoding.strCodeHex(gr["gridColumnunit"].Value.ToString());//单位
                        warehouseAdjDetail.number = Convert.ToDecimal(gr["gridColumnnumber"].Value == null ? 0 : gr["gridColumnnumber"].Value);//数量
                        warehouseAdjDetail.curPrice = Convert.ToDecimal(gr["gridColumnbeforeprice"].Value == null ? 0 : gr["gridColumnbeforeprice"].Value);//调前单价
                        warehouseAdjDetail.price = Convert.ToDecimal(gr["gridColumnafterprice"].Value == null ? 0 : gr["gridColumnafterprice"].Value);//调后单价
                        warehouseAdjDetail.remark = gr["gridColumnremark"].Value == null ? "" : XYEEncoding.strCodeHex(gr["gridColumnremark"].Value.ToString());//备注
                        warehouseAdjDetail.isClear = 1;
                        warehouseAdjDetail.updateDate = DateTime.Now;
                        warehouseAdjDetail.reserved1 = "";
                        warehouseAdjDetail.reserved2 = "";
                        warehouseAdjDetail.scale = 1;
                        warehouseAdjDetail.cause = "";
                        GridRow dr = superGridControlShangPing.PrimaryGrid.Rows[0] as GridRow;
                        warehouseADJpriceList.Add(warehouseAdjDetail);
                    }
                }
                #endregion
            }
            catch (Exception ex)
            {
                MessageBox.Show("错误代码：2703-尝试创建调价单详情商品数据出错,请检查输入" + ex.Message, "调价单温馨提示");
                return;
            }

            //增加一条调价单和调价详细数据
            object warehouseAdjResult = warehouseAdjust.AddAndModify(warehouseADJprice, warehouseADJpriceList);
            //this.textBoxid.Text = warehouseProfitResult.ToString();
            if (warehouseAdjResult != null)
            {
                MessageBox.Show("新增调价单数据成功", "调价单温馨提示");
            }
        }

        /// <summary>
        /// 审核的封装函数
        /// </summary>
        private void ShengHe()
        {
            //非空验证
            if (isNUllValidate() == false)
            {
                return;
            }
            //获得界面上的数据,准备传给base层新增数据
            WarehouseAdjustPriceInterface warehouseAdjpriceinterface = new WarehouseAdjustPriceInterface();
            //调价单
            WarehouseAdjustPrice warehouseADJprice = new WarehouseAdjustPrice();
            //调价单商品列表
            List<WarehouseAdjustPriceDetail> warehouseADJpriceList = new List<WarehouseAdjustPriceDetail>();
            try
            {
                #region 调价单基本数据
                warehouseADJprice.code = textBoxOddNumbers.Text == "" ? "" : XYEEncoding.strCodeHex(textBoxOddNumbers.Text);//单据code
                if (cboadjType.Text != null || cboadjType.Text.ToString() != "")
                {
                    warehouseADJprice.type = cboadjType.Text == "" ? "" : XYEEncoding.strCodeHex(cboadjType.Text);//调价类别
                }
                else
                {
                    MessageBox.Show("调价类别不能为空！");
                    cboadjType.Focus();
                    return;
                }
                if (ltxtbSalsMan.Text != null || ltxtbSalsMan.Text.ToString() != "")
                {
                    warehouseADJprice.operationMan = ltxtbSalsMan.Text == "" ? "" : XYEEncoding.strCodeHex(ltxtbSalsMan.Text);//调价员
                }
                else
                {
                    MessageBox.Show("调价员不能为空！");
                    ltxtbSalsMan.Focus();
                    return;
                }
                warehouseADJprice.date = dateTimePicker1.Value;//单据日期
                warehouseADJprice.makeMan = ltxtbMakeMan.Text == "" ? "" : XYEEncoding.strCodeHex(ltxtbMakeMan.Text);//制单人
                warehouseADJprice.checkMan = ltxtbShengHeMan.Text == "" ? "" : XYEEncoding.strCodeHex(ltxtbShengHeMan.Text);//审核人
                warehouseADJprice.remark = labtextboxTop9.Text == "" ? "" : XYEEncoding.strCodeHex(labtextboxTop9.Text);//摘要
                warehouseADJprice.checkState = 1; //审核状态
                warehouseADJprice.isClear = 1;
                warehouseADJprice.updateDate = DateTime.Now;
                warehouseADJprice.reserved1 = "";
                warehouseADJprice.reserved2 = "";
                #endregion
            }
            catch (Exception ex)
            {
                MessageBox.Show("错误代码:2705；尝试审核创建调价单商品数据出错,请检查输入" + ex.Message, "调价单温馨提示");
                return;
            }

            try
            {
                #region 调价单表格详细数据
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
                        WarehouseAdjustPriceDetail warehouseAdjDetail = new WarehouseAdjustPriceDetail();
                        if (gr["gridColumnStock"].Value.ToString() != "")
                        {
                            warehouseAdjDetail.stockName = XYEEncoding.strCodeHex(gr["gridColumnStock"].Value.ToString());//仓库名称
                        }
                        else
                        {
                            MessageBox.Show("单据体表格里仓库不能为空！");
                            return;
                        }
                        if (gr["material"].Value.ToString() != "")
                        {
                            warehouseAdjDetail.materiaDaima = XYEEncoding.strCodeHex(gr["material"].Value.ToString());//商品代码
                        }
                        else
                        {
                            MessageBox.Show("单据体表格里商品代码不能为空！");
                            return;
                        }
                        decimal beforeMoney = Convert.ToDecimal(gr["gridColumnnumber"].Value) * Convert.ToDecimal(gr["gridColumnbeforeprice"].Value);
                        if (beforeMoney == Convert.ToDecimal(gr["gridColumnbeforemoney"].Value))
                        {
                            warehouseAdjDetail.curMoney = Convert.ToDecimal(gr["gridColumnbeforemoney"].Value);//调前金额
                        }
                        else
                        {
                            MessageBox.Show("单据体表格里调前金额计算错误！");
                            return;
                        }
                        decimal afterMoney = Convert.ToDecimal(gr["gridColumnnumber"].Value) * Convert.ToDecimal(gr["gridColumnafterprice"].Value);
                        if (afterMoney == Convert.ToDecimal(gr["gridColumnaftermoney"].Value))
                        {
                            warehouseAdjDetail.money = Convert.ToDecimal(gr["gridColumnaftermoney"].Value);//调后金额
                        }
                        else
                        {
                            MessageBox.Show("单据体表格里调后金额计算错误！");
                            return;
                        }
                        decimal tiaojiaMoney = afterMoney - beforeMoney;
                        if (tiaojiaMoney == Convert.ToDecimal(gr["gridColumnmoneyadj"].Value))
                        {
                            warehouseAdjDetail.lostMoney = Convert.ToDecimal(gr["gridColumnmoneyadj"].Value);//调价差额
                        }
                        else
                        {
                            MessageBox.Show("单据体表格里调价金额计算错误！");
                            return;
                        }
                        warehouseAdjDetail.stockCode = gr["gridColumnstockcode"].Value == null ? "" : XYEEncoding.strCodeHex(gr["gridColumnstockcode"].Value.ToString());//仓库code                     
                        warehouseAdjDetail.code = XYEEncoding.strCodeHex(textBoxOddNumbers.Text) + i.ToString();//单据code
                        warehouseAdjDetail.mainCode = XYEEncoding.strCodeHex(textBoxOddNumbers.Text);//主表code                      
                        warehouseAdjDetail.materialCode = gr["gridColumnmaterialcode"].Value == null ? "" : XYEEncoding.strCodeHex(gr["gridColumnmaterialcode"].Value.ToString());//商品code
                        warehouseAdjDetail.barCode = gr["gridColumntiaoma"].Value == null ? "" : XYEEncoding.strCodeHex(gr["gridColumntiaoma"].Value.ToString());//条形码
                        warehouseAdjDetail.materialName = gr["gridColumnname"].Value == null ? "" : XYEEncoding.strCodeHex(gr["gridColumnname"].Value.ToString());//物料名称
                        warehouseAdjDetail.materialModel = gr["gridColumnmodel"].Value == null ? "" : XYEEncoding.strCodeHex(gr["gridColumnmodel"].Value.ToString());//规格型号
                        warehouseAdjDetail.materialUnit = gr["gridColumnunit"].Value == null ? "" : XYEEncoding.strCodeHex(gr["gridColumnunit"].Value.ToString());//单位
                        warehouseAdjDetail.number = Convert.ToDecimal(gr["gridColumnnumber"].Value == null ? 0 : gr["gridColumnnumber"].Value);//数量
                        warehouseAdjDetail.curPrice = Convert.ToDecimal(gr["gridColumnbeforeprice"].Value == null ? 0 : gr["gridColumnbeforeprice"].Value);//调前单价
                        warehouseAdjDetail.price = Convert.ToDecimal(gr["gridColumnafterprice"].Value == null ? 0 : gr["gridColumnafterprice"].Value);//调后单价
                        warehouseAdjDetail.remark = gr["gridColumnremark"].Value == null ? "" : XYEEncoding.strCodeHex(gr["gridColumnremark"].Value.ToString());//备注
                        warehouseAdjDetail.isClear = 1;
                        warehouseAdjDetail.updateDate = DateTime.Now;
                        warehouseAdjDetail.reserved1 = "";
                        warehouseAdjDetail.reserved2 = "";
                        warehouseAdjDetail.scale = 1;
                        warehouseAdjDetail.cause = "";
                        GridRow dr = superGridControlShangPing.PrimaryGrid.Rows[0] as GridRow;
                        warehouseADJpriceList.Add(warehouseAdjDetail);
                    }
                }
                #endregion
            }
            catch (Exception ex)
            {
                MessageBox.Show("错误代码：2704-尝试审核创建调价单详情商品数据出错,请检查输入" + ex.Message, "调价单温馨提示");
                return;
            }

            //增加一条调价单和调价详细数据
            object warehouseAdjResult = warehouseAdjpriceinterface.AddAndModify(warehouseADJprice, warehouseADJpriceList);
            if (warehouseAdjResult != null)
            {
                MessageBox.Show("新增并审核调价单数据成功", "调价单温馨提示");
                InitForm();
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
            gr.Cells["gridColumnStock"].Value = "合计";
            gr.Cells["gridColumnStock"].CellStyles.Default.Alignment =
                DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleCenter;
            //数量
            gr.Cells["gridColumnnumber"].Value = 0;
            gr.Cells["gridColumnnumber"].CellStyles.Default.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleCenter;
            gr.Cells["gridColumnnumber"].CellStyles.Default.Background.Color1 = Color.Orange;
            //调前金额
            gr.Cells["gridColumnbeforemoney"].Value = 0;
            gr.Cells["gridColumnbeforemoney"].CellStyles.Default.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleCenter;
            gr.Cells["gridColumnbeforemoney"].CellStyles.Default.Background.Color1 = Color.Orange;
            //调后金额
            gr.Cells["gridColumnaftermoney"].Value = 0;
            gr.Cells["gridColumnaftermoney"].CellStyles.Default.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleCenter;
            gr.Cells["gridColumnaftermoney"].CellStyles.Default.Background.Color1 = Color.Orange;
            //调价金额
            gr.Cells["gridColumnmoneyadj"].Value = 0;
            gr.Cells["gridColumnmoneyadj"].CellStyles.Default.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleCenter;
            gr.Cells["gridColumnmoneyadj"].CellStyles.Default.Background.Color1 = Color.Orange;

            #region 合计行不能点击
            gr.Cells["gridColumnStock"].AllowSelection = false;
            gr.Cells["material"].AllowSelection = false;
            gr.Cells["gridColumnname"].AllowSelection = false;
            gr.Cells["gridColumnmodel"].AllowSelection = false;
            gr.Cells["gridColumntiaoma"].AllowSelection = false;
            gr.Cells["gridColumnunit"].AllowSelection = false;
            gr.Cells["gridColumnbeforeprice"].AllowSelection = false;
            gr.Cells["gridColumnbeforemoney"].AllowSelection = false;
            gr.Cells["gridColumnafterprice"].AllowSelection = false;
            gr.Cells["gridColumnaftermoney"].AllowSelection = false;
            gr.Cells["gridColumnmoneyadj"].AllowSelection = false;
            gr.Cells["gridColumnremark"].AllowSelection = false;
            #endregion
        }

        /// <summary>
        /// 非空验证
        /// </summary>
        private bool isNUllValidate()
        {
            if (cboadjType.Text.Trim() == null)
            {
                MessageBox.Show("调价科目不能为空！");
                return false;
            }
            GridRow gr = (GridRow)superGridControlShangPing.PrimaryGrid.Rows[1];
            if (gr.Cells["gridColumnStock"].Value == null || gr.Cells["gridColumnStock"].Value.ToString() == "")
            {
                MessageBox.Show("仓库不能为空！");
                return false;
            }
            if (gr.Cells["material"].Value == null || gr.Cells["material"].Value.ToString() == "")
            {
                MessageBox.Show("商品代码不能为空！");
                return false;
            }
            if (ltxtbSalsMan.Text.Trim() == null || ltxtbSalsMan.Text == "")
            {
                MessageBox.Show("调价员不能为空！");
                return false;
            }
            return true;
        }

        /// <summary>
        /// 初始化调价员
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
                        resizablePanel1.Location = new Point(230, 670);
                        return;
                    }
                    if (this.WindowState == FormWindowState.Normal)
                    {
                        resizablePanel1.Location = new Point(230, 420);
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("错误代码：2706-初始化调价员出错！请检查：" + ex.Message);
            }
        }

        /// <summary>
        /// 初始化仓库列和数据
        /// </summary>
        private void InitStorageList()
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
                    dgvc.Visible = false;
                    dgvc.HeaderText = "code";
                    dgvc.DataPropertyName = "code";
                    dataGridViewFuJia.Columns.Add(dgvc);

                    dgvc = new DataGridViewTextBoxColumn();
                    dgvc.Name = "name";
                    dgvc.Visible = true;
                    dgvc.HeaderText = "仓库名称";
                    dgvc.DataPropertyName = "name";
                    dataGridViewFuJia.Columns.Add(dgvc);

                    dgvc = new DataGridViewTextBoxColumn();
                    dgvc.Name = "address";
                    dgvc.Visible = true;
                    dgvc.HeaderText = "仓库地址";
                    dgvc.DataPropertyName = "address";
                    dataGridViewFuJia.Columns.Add(dgvc);

                    //查询仓库的方法
                    dataGridViewFuJia.DataSource = ch.DataTableReCoding(_AllStorage);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("错误代码：2707-初始化仓库出错！请检查：" + ex.Message);
            }
        }

        /// <summary>
        /// 初始化商品下拉别表的数据
        /// </summary>
        private void InitMaterialDataGridView()
        {
            dataGridViewShangPing.DataSource = null;
            dataGridViewShangPing.Columns.Clear();

            DataGridViewTextBoxColumn dgvc = new DataGridViewTextBoxColumn();
            dgvc = new DataGridViewTextBoxColumn();
            dgvc.Name = "remark";
            dgvc.Visible = false;
            dgvc.HeaderText = "备注";
            dgvc.DataPropertyName = "remark";
            dataGridViewShangPing.Columns.Add(dgvc);

            dgvc = new DataGridViewTextBoxColumn();
            dgvc.Name = "price";
            dgvc.Visible = false;
            dgvc.HeaderText = "单价";
            dgvc.DataPropertyName = "price";
            dataGridViewShangPing.Columns.Add(dgvc);

            dgvc = new DataGridViewTextBoxColumn();
            dgvc.Name = "currentNumber";
            dgvc.Visible = false;
            dgvc.HeaderText = "数量";
            dgvc.DataPropertyName = "currentNumber";
            dataGridViewShangPing.Columns.Add(dgvc);

            dgvc = new DataGridViewTextBoxColumn();
            dgvc.Name = "unit";
            dgvc.Visible = false;
            dgvc.HeaderText = "单位";
            dgvc.DataPropertyName = "unit";
            dataGridViewShangPing.Columns.Add(dgvc);

            dgvc = new DataGridViewTextBoxColumn();
            dgvc.Name = "code";
            dgvc.Visible = false;
            dgvc.HeaderText = "商品code";
            dgvc.DataPropertyName = "code";
            dataGridViewShangPing.Columns.Add(dgvc);

            dgvc = new DataGridViewTextBoxColumn();
            dgvc.Name = "storageCode";
            dgvc.Visible = false;
            dgvc.HeaderText = "仓库code";
            dgvc.DataPropertyName = "storageCode";
            dataGridViewShangPing.Columns.Add(dgvc);

            dgvc = new DataGridViewTextBoxColumn();
            dgvc.Name = "storageName";
            dgvc.Visible = false;
            dgvc.HeaderText = "仓库名称";
            dgvc.DataPropertyName = "storageName";
            dataGridViewShangPing.Columns.Add(dgvc);

            dgvc = new DataGridViewTextBoxColumn();
            dgvc.Name = "materialDaima";
            dgvc.Visible = true;
            dgvc.HeaderText = "商品代码";
            dgvc.DataPropertyName = "materialDaima";
            dataGridViewShangPing.Columns.Add(dgvc);

            dgvc = new DataGridViewTextBoxColumn();
            dgvc.Name = "name";
            dgvc.Visible = true;
            dgvc.HeaderText = "商品名称";
            dgvc.DataPropertyName = "name";
            dataGridViewShangPing.Columns.Add(dgvc);

            dgvc = new DataGridViewTextBoxColumn();
            dgvc.Name = "model";
            dgvc.Visible = true;
            dgvc.HeaderText = "规格型号";
            dgvc.DataPropertyName = "model";
            dataGridViewShangPing.Columns.Add(dgvc);

            dgvc = new DataGridViewTextBoxColumn();
            dgvc.Name = "barCode";
            dgvc.Visible = true;
            dgvc.HeaderText = "条码";
            dgvc.DataPropertyName = "barCode";
            dataGridViewShangPing.Columns.Add(dgvc);

            dataGridViewShangPing.DataSource = ch.DataTableReCoding(_AllMaterial);

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
            this.picAdj.Parent = pictureBoxtitle;
            this.picAdj.Image = Properties.Resources.审核;
            picAdj.Visible = true;
            this.toolStripBtnInsert.Enabled = false;
            this.toolStripBtnSave.Enabled = false;
            this.toolStripBtnShengHe.Enabled = false;
        }

        #endregion

        #region 小箭头图标和表格数据的点击事件

        private void pictureBoxEmployee_Click(object sender, EventArgs e)
        {
            if (_Click != 1)
            {
                InitEmployee();
            }
            _Click = 3;
        }

        /// <summary>
        /// 双击调价员或者仓库信息填写在表格里面
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
        /// 双击物料信息填写在表格里面
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

        #endregion

        /// <summary>
        /// 第一个表格选择仓库
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void superGridControlShangPing_BeginEdit(object sender, GridEditEventArgs e)
        {
            try
            {
                if (e.GridCell.GridColumn.Name == "gridColumnStock")
                {
                    InitStorageList();
                    return;
                }
                if (e.GridCell.GridColumn.Name == "material")
                {
                    if (_StorageCode != "")
                    {
                        //查询商品列表
                        _AllMaterial = waremain.GetWMainAndMaterialByWMCode(999, "", XYEEncoding.strCodeHex(_StorageCode));
                        InitMaterialDataGridView();
                    }
                    else
                    {
                        resizablePanelData.Visible = false;
                        MessageBox.Show("请先选择仓库！");
                    }

                }
            }
            catch (Exception)
            {
                if (_StorageCode != "")
                {
                    //查询商品列表
                    _AllMaterial = waremain.GetWMainAndMaterialByWMCode(999, "", XYEEncoding.strCodeHex(_StorageCode));
                    InitMaterialDataGridView();
                }
                else
                {
                    this.resizablePanelData.Visible = false;
                    MessageBox.Show("请先选择仓库！");
                }
            }
        }

        /// <summary>
        /// 验证完成后，统计单元格数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void superGridControlShangPing_CellValidated(object sender, GridCellValidatedEventArgs e)
        {
            GridRow gr = e.GridPanel.Rows[e.GridCell.RowIndex] as GridRow;
            //计算调后金额以及调价金额
            try
            {
                decimal tempAllBeforemoney = 0;
                decimal tempAllAftermoney = 0;
                decimal tempALLadjmoney = 0;
                decimal tempAllnumber = 0;
                //数量
                decimal number = Convert.ToDecimal(gr.Cells["gridColumnnumber"].FormattedValue);
                //调前单价
                decimal tiaoqianPrice = Convert.ToDecimal(gr.Cells["gridColumnbeforeprice"].FormattedValue);
                //调前金额
                decimal tiaoqianMoney = Convert.ToDecimal(gr.Cells["gridColumnbeforemoney"].FormattedValue);
                //调后单价
                decimal tiaohouPrice = Convert.ToDecimal(gr.Cells["gridColumnafterprice"].FormattedValue);
                //调后金额
                decimal tiaohouMoney = number * tiaohouPrice;
                gr.Cells["gridColumnaftermoney"].Value = tiaohouMoney;
                //调价金额
                decimal ADJmoney = tiaohouMoney - tiaoqianMoney;
                gr.Cells["gridColumnmoneyadj"].Value = ADJmoney;
                labtextboxTop7.Text = ADJmoney.ToString("0.00");

                //逐行统计数据总数
                for (int i = 0; i < superGridControlShangPing.PrimaryGrid.Rows.Count - 1; i++)
                {
                    GridRow tempGR = superGridControlShangPing.PrimaryGrid.Rows[i] as GridRow;
                    tempAllBeforemoney += Convert.ToDecimal(tempGR["gridColumnbeforemoney"].FormattedValue);
                    tempAllAftermoney += Convert.ToDecimal(tempGR["gridColumnaftermoney"].FormattedValue);
                    tempALLadjmoney += Convert.ToDecimal(tempGR["gridColumnmoneyadj"].FormattedValue);
                    tempAllnumber += Convert.ToDecimal(tempGR["gridColumnnumber"].FormattedValue);
                }
                _MaterialBeforeMoney = tempAllBeforemoney;
                _MaterialAfterMoney = tempAllAftermoney;
                _MaterialAdjMoney = tempALLadjmoney;
                _MaterialNumber = tempAllnumber;
                gr = (GridRow)superGridControlShangPing.PrimaryGrid.LastSelectableRow;
                gr["gridColumnbeforemoney"].Value = _MaterialBeforeMoney.ToString();
                gr["gridColumnaftermoney"].Value = _MaterialAfterMoney.ToString();
                gr["gridColumnmoneyadj"].Value = _MaterialAdjMoney.ToString();
                gr["gridColumnnumber"].Value = _MaterialNumber.ToString();

            }
            catch (Exception ex)
            {
                MessageBox.Show("错误代码：2710-统计数量错误！请检查：" + ex.Message);
            }
        }

        /// <summary>
        /// 调价员模糊查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ltxtbSalsMan_TextChanged(object sender, EventArgs e)
        {
            if (ltxtbSalsMan.Text.Trim() == "")
            {
                _Click = 3;
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

                resizablePanel1.Location = new Point(234, 420);
                dataGridViewFuJia.DataSource = ch.DataTableReCoding(employee.GetList(0, "" + XYEEncoding.strCodeHex(ltxtbSalsMan.Text.Trim()) + ""));
                resizablePanel1.Visible = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(" 错误代码：2711-模糊查询调价员出错！请检查：" + ex.Message);
            }
        }

        /// <summary>
        /// 窗体任意位置隐藏resizablePanel1
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected override void panel6_Click(object sender, EventArgs e)
        {
            resizablePanel1.Visible = false;
        }

        /// <summary>
        /// 按下ESC按钮关闭子窗体
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void WareHouseAdjustPriceForm_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Escape)
            {
                this.resizablePanel1.Visible = false;
            }
        }

        /// <summary>
        /// 模糊查询商品
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
                    _AllMaterial = waremain.GetWMainAndMaterialByWMCode(0, "" + materialDaima + "", XYEEncoding.strCodeHex(_StorageCode));
                    InitMaterialDataGridView();
                    dataGridViewShangPing.DataSource = ch.DataTableReCoding(_AllMaterial);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("错误代码:2712-表格商品模糊查询错误，查询数据错误" + ex.Message, "调价单温馨提示");
            }
        }

        private void WareHouseAdjustPriceForm_Activated(object sender, EventArgs e)
        {
            superGridControlShangPing.Focus();
        }

        private void superGridControlShangPing_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                panel2.Focus();
            }
        }

        /// <summary>
        /// dataGridViewFuJia双击表格函数
        /// </summary>
        private void dataGridViewFuJiaTableClick()
        {
            try
            {
                //调价员
                if (_Click == 1 || _Click == 3)
                {
                    string name = dataGridViewFuJia.Rows[dataGridViewFuJia.CurrentRow.Index].Cells["name"].Value.ToString();
                    ltxtbSalsMan.Text = name;
                    resizablePanel1.Visible = false;
                }
                //仓库信息
                if (_Click == 2)
                {

                    GridRow gr = (GridRow)superGridControlShangPing.PrimaryGrid.Rows[ClickRowIndex];
                    string code = dataGridViewFuJia.Rows[dataGridViewFuJia.CurrentRow.Index].Cells["code"].Value.ToString();
                    string Name = dataGridViewFuJia.Rows[dataGridViewFuJia.CurrentRow.Index].Cells["name"].Value.ToString();
                    gr.Cells["gridColumnStock"].Value = Name;
                    //gr.Cells["gridColumncode"].Value = code;
                    _ClickStorageList = new KeyValuePair<string, string>(code, Name);
                    _StorageCode = code;
                    resizablePanel1.Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("错误代码：2708-双击绑定调价员或仓库信息数据错误！请检查：" + ex.Message);
            }
        }

        /// <summary>
        /// dataGridViewShangPing双击表格函数
        /// </summary>
        private void dataGridViewShangPingTableClick()

        {
            try
            {
                //是否要新增一行的标记
                bool newAdd = false;
                GridRow gr = (GridRow)superGridControlShangPing.PrimaryGrid.Rows[ClickRowIndex];
                //id字段为空 说明是没有数据的行 不是修改而是新增
                if (gr.Cells["gridColumnid"].Value == null)
                {
                    newAdd = true;
                }
                gr.Cells["material"].Value = dataGridViewShangPing.Rows[dataGridViewShangPing.CurrentRow.Index].Cells["materialDaima"].Value;//商品代码
                gr.Cells["gridColumnname"].Value = dataGridViewShangPing.Rows[dataGridViewShangPing.CurrentRow.Index].Cells["name"].Value;//商品名称
                gr.Cells["gridColumnmodel"].Value = dataGridViewShangPing.Rows[dataGridViewShangPing.CurrentRow.Index].Cells["model"].Value;//规格型号
                gr.Cells["gridColumntiaoma"].Value = dataGridViewShangPing.Rows[dataGridViewShangPing.CurrentRow.Index].Cells["barCode"].Value;//条码
                gr.Cells["gridColumnunit"].Value = dataGridViewShangPing.Rows[dataGridViewShangPing.CurrentRow.Index].Cells["unit"].Value;//单位
                gr.Cells["gridColumnnumber"].Value = dataGridViewShangPing.Rows[dataGridViewShangPing.CurrentRow.Index].Cells["currentNumber"].Value;//商品数量
                gr.Cells["gridColumnbeforeprice"].Value = dataGridViewShangPing.Rows[dataGridViewShangPing.CurrentRow.Index].Cells["price"].Value;//单价
                gr.Cells["gridColumnremark"].Value = dataGridViewShangPing.Rows[dataGridViewShangPing.CurrentRow.Index].Cells["remark"].Value;//备注
                gr.Cells["gridColumnmaterialcode"].Value = dataGridViewShangPing.Rows[dataGridViewShangPing.CurrentRow.Index].Cells["code"].Value;//商品code

                decimal number = Convert.ToDecimal(dataGridViewShangPing.Rows[dataGridViewShangPing.CurrentRow.Index].Cells["currentNumber"].Value);//数量
                decimal beforeprice = Convert.ToDecimal(dataGridViewShangPing.Rows[dataGridViewShangPing.CurrentRow.Index].Cells["price"].Value);//调前单价
                _MaterialBeforeMoney = number * beforeprice;
                gr.Cells["gridColumnbeforemoney"].Value = _MaterialBeforeMoney;//调前金额

                //当上一次有选择仓库时 默认本次也为上次选择仓库
                if (!string.IsNullOrEmpty(_ClickStorageList.Value) && !string.IsNullOrEmpty(_ClickStorageList.Key))
                {
                    gr.Cells["gridColumnstockcode"].Value = _ClickStorageList.Key;
                    gr.Cells["gridColumnStock"].Value = _ClickStorageList.Value;
                }
                //新增一行 
                if (newAdd)
                {
                    superGridControlShangPing.PrimaryGrid.NewRow(superGridControlShangPing.PrimaryGrid.Rows.Count);
                    //递增数量和金额 默认为1和单价 
                    gr = (GridRow)superGridControlShangPing.PrimaryGrid.LastSelectableRow;
                    _MaterialNumber += 1;
                    _beforeMoney += _MaterialBeforeMoney;
                    gr.Cells["gridColumnnumber"].Value = _MaterialNumber;
                    gr.Cells["gridColumnbeforemoney"].Value = _beforeMoney;
                }
                superGridControlShangPing.Focus();
                SendKeys.Send("^{End}{Home}");
            }
            catch (Exception ex)
            {
                MessageBox.Show(" 错误代码：2709-双击绑定物料信息数据错误！请检查：" + ex.Message);
            }
        }

        /// <summary>
        /// 快捷方式设置
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void WareHouseAdjustPriceForm_KeyDown(object sender, KeyEventArgs e)
        {
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
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DataGridViewFuJia_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                dataGridViewFuJiaTableClick();
            }
        }
    }
}
