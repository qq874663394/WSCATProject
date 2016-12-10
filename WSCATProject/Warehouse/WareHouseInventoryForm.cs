using DevComponents.DotNetBar.SuperGrid;
using HelperUtility;
using HelperUtility.Encrypt;
using InterfaceLayer.Base;
using InterfaceLayer.Warehouse;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Model;

namespace WSCATProject.Warehouse
{
    public partial class WareHouseInventoryForm : Form
    {
        public WareHouseInventoryForm()
        {
            InitializeComponent();
        }
        #region 调用接口以及加密解密的方法
        StorageInterface si = new StorageInterface();
        CodingHelper codeh = new CodingHelper();
        WarehouseMainInterface warehousemain = new WarehouseMainInterface();
        WarehouseInventoryDetailInterface warehousinvdet = new WarehouseInventoryDetailInterface();
        #endregion

        #region  数据字段
        /// <summary>
        /// 统计账存数量
        /// </summary>
        private decimal _ZhangCunShuLiang;
        /// <summary>
        /// 统计判定数量
        /// </summary>
        private decimal _PanDianShuLiang;
        /// <summary>
        /// 统计盘盈数量
        /// </summary>
        private decimal _PanYingShuLiang;
        /// <summary>
        /// 统计盘亏数量
        /// </summary>
        private decimal _PanKuiShuLiang;
        /// <summary>
        /// 盘盈金额
        /// </summary>
        private decimal _PanYingMoney;
        /// <summary>
        /// 盘亏金额
        /// </summary>
        private decimal _PankuiMoney;
        /// <summary>
        /// 盘点code
        /// </summary>
        private string _PanDianCode;
        #endregion

        #region 设置窗体无边框可以拖动
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();
        private void WareHouseInventoryForm_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }
        #endregion

        #region 最小化、最大化、关闭的点击事件
        private void pictureBoxMax_MouseEnter(object sender, EventArgs e)
        {
            //当窗体的状态为最大化时，工具提示文本为还原
            if (this.WindowState == FormWindowState.Maximized)
            {
                toolTip1.SetToolTip(pictureBoxMax, "还原");
                return;
            }
            //当窗体的状态为正常时时，工具提示文本为最大化
            if (this.WindowState == FormWindowState.Normal)
            {
                toolTip1.SetToolTip(pictureBoxMax, "最大化");
                return;
            }
        }

        private void pictureBoxMax_Click(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Maximized)
            {
                this.WindowState = FormWindowState.Normal;
                pictureBoxMax.Image = Properties.Resources.zuidahua1;
                return;
            }
            if (this.WindowState == FormWindowState.Normal)
            {
                this.WindowState = FormWindowState.Maximized;
                pictureBoxMax.Image = Properties.Resources.zuidahua;
                return;
            }
        }

        private void pictureBoxMin_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        //关闭
        private void pictureBoxClose_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
        }
        #endregion

        private void WareHouseInventoryForm_Load(object sender, EventArgs e)
        {
            try
            {
                this.labelTitle.BackColor = Color.FromArgb(85, 177, 238);
                this.pictureBoxMax.BackColor = Color.FromArgb(85, 177, 238);
                this.pictureBoxMin.BackColor = Color.FromArgb(85, 177, 238);
                this.pictureBoxClose.BackColor = Color.FromArgb(85, 177, 238);

                //设置盘点数量可输入的最大值和最小值
                GridDoubleInputEditControl gdiecNumber = superGridControlShangPing.PrimaryGrid.Columns["pandiannumber"].EditControl as GridDoubleInputEditControl;
                gdiecNumber.MinValue = 0;
                gdiecNumber.MaxValue = 999999999;

                superGridControlShangPing.PrimaryGrid.ShowRowGridIndex = true;
                superGridControlShangPing.HScrollBarVisible = true;
                superGridControlShangPing.PrimaryGrid.AutoGenerateColumns = false;//禁止自动创建列
                superGridControlShangPing.DefaultVisualStyles.CellStyles.Default.Alignment =
                DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleCenter;//设置内容居中
                InitDataGridView(); //调用表格初始化

                //生成code 和显示条形码
                _PanDianCode = BuildCode.ModuleCode("WII");
                textBoxpandiancode.Text = _PanDianCode;
                barcodeXYE.Code128 _Code = new barcodeXYE.Code128();
                _Code.ValueFont = new Font("微软雅黑", 20);
                System.Drawing.Bitmap imgTemp = _Code.GetCodeImage(textBoxpandiancode.Text, barcodeXYE.Code128.Encode.Code128A);
                picbpandianBarCode.Image = imgTemp;

                #region 盘点方案
                DataTable dt = codeh.DataTableReCoding(si.GetList(999, ""));
                cboPanDianIdea.DisplayMember = "name";
                cboPanDianIdea.ValueMember = "code";
                cboPanDianIdea.DataSource = dt;
                string code = cboPanDianIdea.SelectedValue.ToString();
                superGridControlShangPing.PrimaryGrid.DataSource = codeh.DataTableReCoding(warehousemain.GetMaterialByMain(XYEEncoding.strCodeHex(code)));
                superGridControlShangPing.PrimaryGrid.EnsureVisible();
                InitDataGridView();
                try
                {
                    GridRow gr = new GridRow();
                    decimal tempAllzhucun = 0;
                    decimal tempAllpandian = 0;
                    //逐行统计数据总数
                    for (int i = 0; i < superGridControlShangPing.PrimaryGrid.Rows.Count - 1; i++)
                    {
                        GridRow tempGR = superGridControlShangPing.PrimaryGrid.Rows[i] as GridRow;
                        tempAllzhucun += Convert.ToDecimal(tempGR["zhangcunnumber"].FormattedValue);
                        tempAllpandian += Convert.ToDecimal(tempGR["pandiannumber"].FormattedValue);
                    }
                    _ZhangCunShuLiang = tempAllzhucun;
                    _PanDianShuLiang = tempAllpandian;
                    gr = (GridRow)superGridControlShangPing.PrimaryGrid.LastSelectableRow;
                    gr["zhangcunnumber"].Value = _ZhangCunShuLiang.ToString();
                    gr["pandiannumber"].Value = _PanDianShuLiang.ToString();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("商品盘点表统计数量错误" + ex.Message);
                }
                #endregion
            }
            catch (Exception ex)
            {
                MessageBox.Show("错误代码：2301-窗体加载时，初始化数据错误！" + ex.Message,"盘点表温馨提示！");
                this.Close();
                return;
            }
     
        }

        #region  下拉框选择改变事件
        private void cboPanDianIdea_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cboPanDianIdea.Text == "")
            {
                return;
            }

            if (cboPanDianIdea.Text != "")
            {
                try
                {
                    string code = cboPanDianIdea.SelectedValue.ToString();
                    this.superGridControlShangPing.PrimaryGrid.DataSource = null;
                    superGridControlShangPing.PrimaryGrid.AutoGenerateColumns = false;
                    superGridControlShangPing.PrimaryGrid.DataSource = codeh.DataTableReCoding(warehousemain.GetMaterialByMain(XYEEncoding.strCodeHex(cboPanDianIdea.SelectedValue.ToString())));
                    superGridControlShangPing.PrimaryGrid.EnsureVisible();
                    InitDataGridView();

                    GridRow gr = new GridRow();
                    decimal tempAllzhucun = 0;
                    decimal tempAllpandian = 0;
                    //逐行统计数据总数
                    for (int i = 0; i < superGridControlShangPing.PrimaryGrid.Rows.Count - 1; i++)
                    {
                        GridRow tempGR = superGridControlShangPing.PrimaryGrid.Rows[i] as GridRow;
                        tempAllzhucun += Convert.ToDecimal(tempGR["zhangcunnumber"].FormattedValue);
                        tempAllpandian += Convert.ToDecimal(tempGR["pandiannumber"].FormattedValue);
                    }
                    _ZhangCunShuLiang = tempAllzhucun;
                    _PanDianShuLiang = tempAllpandian;
                    gr = (GridRow)superGridControlShangPing.PrimaryGrid.LastSelectableRow;
                    gr["zhangcunnumber"].Value = _ZhangCunShuLiang.ToString();
                    gr["pandiannumber"].Value = _PanDianShuLiang.ToString();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("错误代码：2302-商品盘点表统计数量错误" + ex.Message,"盘点表温馨提示！");
                }
            }
        }
        #endregion

        #region  表格初始化
        /// <summary>
        /// supergridControl表格初始化
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
            gr.Cells["name"].Value = "合计";
            gr.Cells["name"].CellStyles.Default.Alignment =
                DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleCenter;
            //账存数量
            gr.Cells["zhangcunnumber"].Value = 0;
            gr.Cells["zhangcunnumber"].CellStyles.Default.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleCenter;
            gr.Cells["zhangcunnumber"].CellStyles.Default.Background.Color1 = Color.Orange;
            //盘点数量
            gr.Cells["pandiannumber"].Value = 0;
            gr.Cells["pandiannumber"].CellStyles.Default.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleCenter;
            gr.Cells["pandiannumber"].CellStyles.Default.Background.Color1 = Color.Orange;
        }
        /// <summary>
        /// 如果盘点单有这个商品就显示上次盘点的数量和账面数量
        /// </summary>
        private void InitSupGridInventoru()
        {
            GridColumn gc = null;

            gc = new GridColumn();
            gc.DataPropertyName = "stockName";
            gc.Name = "storge";
            gc.HeaderText = "仓库";
            gc.Width = 80;
            superGridControlShangPing.PrimaryGrid.Columns.Add(gc);

            gc = new GridColumn();
            gc.DataPropertyName = "materialDaima";
            gc.Name = "daima";
            gc.HeaderText = "商品代码";
            gc.Width = 120;
            gc.AutoSizeMode = ColumnAutoSizeMode.Fill;
            superGridControlShangPing.PrimaryGrid.Columns.Add(gc);

            gc = new GridColumn();
            gc.DataPropertyName = "materialName";
            gc.Name = "name";
            gc.HeaderText = "商品名称";
            gc.Width = 140;
            gc.AutoSizeMode = ColumnAutoSizeMode.Fill;
            superGridControlShangPing.PrimaryGrid.Columns.Add(gc);

            gc = new GridColumn();
            gc.DataPropertyName = "materialCode";
            gc.Name = "gridColumncode";
            gc.HeaderText = "商品名称";
            gc.Width = 140;
            gc.AutoSizeMode = ColumnAutoSizeMode.Fill;
            gc.Visible = false;
            superGridControlShangPing.PrimaryGrid.Columns.Add(gc);

            gc = new GridColumn();
            gc.DataPropertyName = "materialModel";
            gc.Name = "model";
            gc.HeaderText = "规格型号";
            gc.Width = 130;
            gc.AutoSizeMode = ColumnAutoSizeMode.Fill;
            superGridControlShangPing.PrimaryGrid.Columns.Add(gc);

            gc = new GridColumn();
            gc.DataPropertyName = "barCode";
            gc.Name = "tiaoxingma";
            gc.HeaderText = "条形码";
            gc.Width = 150;
            gc.AutoSizeMode = ColumnAutoSizeMode.Fill;
            superGridControlShangPing.PrimaryGrid.Columns.Add(gc);

            gc = new GridColumn();
            gc.DataPropertyName = "productionDate";
            gc.Name = "shengchandate";
            gc.HeaderText = "采购/生产日期";
            gc.Width = 70;
            gc.HeaderStyles.Default.AllowWrap = DevComponents.DotNetBar.SuperGrid.Style.Tbool.True;
            superGridControlShangPing.PrimaryGrid.Columns.Add(gc);

            gc = new GridColumn();
            gc.DataPropertyName = "qualityDate";
            gc.Name = "baozhiqi";
            gc.HeaderText = "保质期(天)";
            gc.Width = 50;
            gc.HeaderStyles.Default.AllowWrap = DevComponents.DotNetBar.SuperGrid.Style.Tbool.True;
            superGridControlShangPing.PrimaryGrid.Columns.Add(gc);

            gc = new GridColumn();
            gc.DataPropertyName = "materialUnit";
            gc.Name = "unit";
            gc.HeaderText = "单位";
            gc.Width = 70;
            superGridControlShangPing.PrimaryGrid.Columns.Add(gc);

            gc = new GridColumn();
            gc.DataPropertyName = "curNumber";
            gc.Name = "zhangcunnumber";
            gc.HeaderText = "账面数量";
            gc.Width = 80;
            superGridControlShangPing.PrimaryGrid.Columns.Add(gc);

            gc = new GridColumn();
            gc.Name = "pandiannumber";
            gc.DataPropertyName = "checkNumber";
            gc.HeaderText = "盘点数量";
            gc.Width = 80;
            superGridControlShangPing.PrimaryGrid.Columns.Add(gc);

            gc = new GridColumn();
            gc.DataPropertyName = "remark";
            gc.Name = "remark";
            gc.HeaderText = "备注";
            gc.Width = 110;
            superGridControlShangPing.PrimaryGrid.Columns.Add(gc);

            gc = new GridColumn();
            gc.Name = "panyingnumber";
            gc.HeaderText = "盘盈数量";
            gc.Width = 70;
            gc.Visible = false;
            superGridControlShangPing.PrimaryGrid.Columns.Add(gc);

            gc = new GridColumn();
            gc.Name = "pankuinumber";
            gc.HeaderText = "盘亏数量";
            gc.Width = 80;
            gc.Visible = false;
            superGridControlShangPing.PrimaryGrid.Columns.Add(gc);

            gc = new GridColumn();
            gc.Name = "gridColumnprice";
            gc.DataPropertyName = "price";
            gc.HeaderText = "单价";
            gc.Width = 80;
            gc.Visible = false;
            superGridControlShangPing.PrimaryGrid.Columns.Add(gc);

            gc = new GridColumn();
            gc.Name = "panyingMoney";
            gc.HeaderText = "盘盈金额";
            gc.Width = 110;
            gc.Visible = false;
            superGridControlShangPing.PrimaryGrid.Columns.Add(gc);

            gc = new GridColumn();
            gc.DataPropertyName = "pankuiMoney";
            gc.HeaderText = "盘亏金额";
            gc.Width = 80;
            gc.Visible = false;
            superGridControlShangPing.PrimaryGrid.Columns.Add(gc);
        }

        private void InitSupGrid()
        {
            GridColumn gc = null;

            gc = new GridColumn();
            gc.DataPropertyName = "storageName";
            gc.Name = "storge";
            gc.HeaderText = "仓库";
            gc.Width = 80;
            superGridControlShangPing.PrimaryGrid.Columns.Add(gc);

            gc = new GridColumn();
            gc.DataPropertyName = "materialDaima";
            gc.Name = "daima";
            gc.HeaderText = "商品代码";
            gc.Width = 120;
            gc.AutoSizeMode = ColumnAutoSizeMode.Fill;
            superGridControlShangPing.PrimaryGrid.Columns.Add(gc);

            gc = new GridColumn();
            gc.DataPropertyName = "name";
            gc.Name = "name";
            gc.HeaderText = "商品名称";
            gc.Width = 140;
            gc.AutoSizeMode = ColumnAutoSizeMode.Fill;
            superGridControlShangPing.PrimaryGrid.Columns.Add(gc);

            gc = new GridColumn();
            gc.DataPropertyName = "code";
            gc.Name = "gridColumncode";
            gc.HeaderText = "商品名称";
            gc.Width = 140;
            gc.AutoSizeMode = ColumnAutoSizeMode.Fill;
            gc.Visible = false;
            superGridControlShangPing.PrimaryGrid.Columns.Add(gc);

            gc = new GridColumn();
            gc.DataPropertyName = "model";
            gc.Name = "model";
            gc.HeaderText = "规格型号";
            gc.Width = 130;
            gc.AutoSizeMode = ColumnAutoSizeMode.Fill;
            superGridControlShangPing.PrimaryGrid.Columns.Add(gc);

            gc = new GridColumn();
            gc.DataPropertyName = "barcode";
            gc.Name = "tiaoxingma";
            gc.HeaderText = "条形码";
            gc.Width = 150;
            gc.AutoSizeMode = ColumnAutoSizeMode.Fill;
            superGridControlShangPing.PrimaryGrid.Columns.Add(gc);

            gc = new GridColumn();
            gc.DataPropertyName = "productionDate";
            gc.Name = "shengchandate";
            gc.HeaderText = "采购/生产日期";
            gc.Width = 70;
            gc.HeaderStyles.Default.AllowWrap = DevComponents.DotNetBar.SuperGrid.Style.Tbool.True;
            superGridControlShangPing.PrimaryGrid.Columns.Add(gc);

            gc = new GridColumn();
            gc.DataPropertyName = "qualityDate";
            gc.Name = "baozhiqi";
            gc.HeaderText = "保质期(天)";
            gc.Width = 50;
            gc.HeaderStyles.Default.AllowWrap = DevComponents.DotNetBar.SuperGrid.Style.Tbool.True;
            superGridControlShangPing.PrimaryGrid.Columns.Add(gc);

            gc = new GridColumn();
            gc.DataPropertyName = "unit";
            gc.Name = "unit";
            gc.HeaderText = "单位";
            gc.Width = 70;
            superGridControlShangPing.PrimaryGrid.Columns.Add(gc);

            gc = new GridColumn();
            gc.DataPropertyName = "number";
            gc.Name = "zhangcunnumber";
            gc.HeaderText = "账面数量";
            gc.Width = 80;
            superGridControlShangPing.PrimaryGrid.Columns.Add(gc);

            gc = new GridColumn();
            gc.Name = "pandiannumber";
            gc.HeaderText = "盘点数量";
            gc.Width = 80;
            superGridControlShangPing.PrimaryGrid.Columns.Add(gc);

            gc = new GridColumn();
            gc.DataPropertyName = "remark";
            gc.Name = "remark";
            gc.HeaderText = "备注";
            gc.Width = 110;
            superGridControlShangPing.PrimaryGrid.Columns.Add(gc);

            gc = new GridColumn();
            gc.Name = "panyingnumber";
            gc.HeaderText = "盘盈数量";
            gc.Width = 70;
            gc.Visible = false;
            superGridControlShangPing.PrimaryGrid.Columns.Add(gc);

            gc = new GridColumn();
            gc.Name = "pankuinumber";
            gc.HeaderText = "盘亏数量";
            gc.Width = 80;
            gc.Visible = false;
            superGridControlShangPing.PrimaryGrid.Columns.Add(gc);

            gc = new GridColumn();
            gc.Name = "gridColumnprice";
            gc.DataPropertyName = "price";
            gc.HeaderText = "单价";
            gc.Width = 80;
            gc.Visible = false;
            superGridControlShangPing.PrimaryGrid.Columns.Add(gc);

            gc = new GridColumn();
            gc.Name = "panyingMoney";
            gc.HeaderText = "盘盈金额";
            gc.Width = 110;
            gc.Visible = false;
            superGridControlShangPing.PrimaryGrid.Columns.Add(gc);

            gc = new GridColumn();
            gc.DataPropertyName = "pankuiMoney";
            gc.HeaderText = "盘亏金额";
            gc.Width = 80;
            gc.Visible = false;
            superGridControlShangPing.PrimaryGrid.Columns.Add(gc);

        }
        #endregion

        #region superGridControl单元格验证事件
        private void superGridControlShangPing_CellValidated(object sender, GridCellValidatedEventArgs e)
        {
            GridRow gr = e.GridPanel.Rows[e.GridCell.RowIndex] as GridRow;
            decimal tempAllzhucun = 0;//账面数
            decimal tempAllpandian = 0;//盘点数
            //计算盘盈、盘亏的数量
            try
            {
                decimal zhucunnumber = Convert.ToDecimal(gr.Cells["zhangcunnumber"].FormattedValue);//账存数量
                decimal pandiannumber = Convert.ToDecimal(gr.Cells["pandiannumber"].FormattedValue);//盘点数量
                decimal price = Convert.ToDecimal(gr.Cells["gridColumnprice"].FormattedValue);//单价
                decimal panying = pandiannumber - zhucunnumber;//盘盈数量
                if (panying > 0)
                {
                    gr.Cells["panyingnumber"].Value = panying;
                    gr.Cells["pankuinumber"].Value = "0.00";
                    decimal panyingnumber = Convert.ToDecimal(gr.Cells["panyingnumber"].FormattedValue);
                    gr.Cells["panyingMoney"].Value = panyingnumber * price;
                    gr.Cells["pankuiMoney"].Value = "0.00";
                }
                if (panying < 0)
                {
                    gr.Cells["pankuinumber"].Value = panying.ToString().Replace("-", "");
                    gr.Cells["panyingnumber"].Value = "0.00";
                    decimal pankuinumber = Convert.ToDecimal(gr.Cells["pankuinumber"].FormattedValue.Replace("-", ""));
                    gr.Cells["pankuiMoney"].Value = (pankuinumber * price).ToString().Replace("-", "");
                    gr.Cells["panyingMoney"].Value = "0.00";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("错误代码：2303-计算盘盈，盘亏数量出错！请检查：" + ex.Message,"盘点表温馨提示！");
            }


            try
            {
                //逐行统计数据总数
                for (int i = 0; i < superGridControlShangPing.PrimaryGrid.Rows.Count - 1; i++)
                {
                    GridRow tempGR = superGridControlShangPing.PrimaryGrid.Rows[i] as GridRow;
                    tempAllzhucun += Convert.ToDecimal(tempGR["zhangcunnumber"].FormattedValue);
                    tempAllpandian += Convert.ToDecimal(tempGR["pandiannumber"].FormattedValue);
                }
                _ZhangCunShuLiang = tempAllzhucun;
                _PanDianShuLiang = tempAllpandian;
                gr = (GridRow)superGridControlShangPing.PrimaryGrid.LastSelectableRow;
                gr["zhangcunnumber"].Value = _ZhangCunShuLiang.ToString();
                gr["pandiannumber"].Value = _PanDianShuLiang.ToString();
                //获取一行数据，添加进数据库
                try
                {
                    GridRow gr1 = e.GridPanel.Rows[e.GridCell.RowIndex] as GridRow;
                    WarehouseInventoryDetail warehouseinv = new WarehouseInventoryDetail();
                    warehouseinv.cause = "";
                    warehouseinv.checkNumber = gr1.Cells["pandiannumber"].FormattedValue == null ? 0.0M : Convert.ToDecimal(gr1.Cells["pandiannumber"].FormattedValue.ToString());
                    warehouseinv.code = XYEEncoding.strCodeHex(textBoxpandiancode.Text);
                    warehouseinv.curNumber = gr1.Cells["zhangcunnumber"].Value == null ? 0.0M : Convert.ToDecimal(gr1.Cells["zhangcunnumber"].Value.ToString());
                    warehouseinv.isClear = 1;
                    warehouseinv.lossMoney = gr1.Cells["pankuiMoney"].Value == null ? 0.0M : Convert.ToDecimal(gr1.Cells["pankuiMoney"].Value.ToString());
                    warehouseinv.lossNumber = gr1.Cells["pankuinumber"].Value == null ? 0.0M : Convert.ToDecimal(gr1.Cells["pankuinumber"].Value.ToString());
                    warehouseinv.materialCode = gr1.Cells["gridColumncode"].Value == null ? "" : XYEEncoding.strCodeHex(gr1.Cells["gridColumncode"].Value.ToString());
                    warehouseinv.materialModel = gr1.Cells["model"].Value == null ? "" : XYEEncoding.strCodeHex(gr1.Cells["model"].Value.ToString());
                    warehouseinv.materialName = gr1.Cells["name"].Value == null ? "" : XYEEncoding.strCodeHex(gr1.Cells["name"].Value.ToString());
                    warehouseinv.materialUnit = gr1.Cells["unit"].Value == null ? "" : XYEEncoding.strCodeHex(gr1.Cells["unit"].Value.ToString());
                    warehouseinv.price = gr1.Cells["gridColumnprice"].Value == null ? 0.0M : Convert.ToDecimal(gr1.Cells["gridColumnprice"].Value);
                    warehouseinv.remark = gr1.Cells["remark"].Value == null ? "" : XYEEncoding.strCodeHex(gr1.Cells["remark"].Value.ToString());
                    warehouseinv.updateDate = DateTime.Now;
                    warehouseinv.barCode = gr1.Cells["tiaoxingma"].Value == null ? "" : XYEEncoding.strCodeHex(gr1.Cells["tiaoxingma"].Value.ToString());
                    warehouseinv.effectiveDate = DateTime.Now;
                    warehouseinv.profitNumber = gr1.Cells["panyingnumber"].Value == null ? 0.0M : Convert.ToDecimal(gr1.Cells["panyingnumber"].Value.ToString());
                    warehouseinv.profitMoney = gr1.Cells["panyingMoney"].Value == null ? 0.0M : Convert.ToDecimal(gr1.Cells["panyingMoney"].Value.ToString());
                    warehouseinv.mainCode = XYEEncoding.strCodeHex(textBoxpandiancode.Text);
                    warehouseinv.materialDaima = gr1.Cells["daima"].Value == null ? "" : XYEEncoding.strCodeHex(gr1.Cells["daima"].Value.ToString());
                    warehouseinv.productionDate = gr1.Cells["shengchandate"].Value.ToString() == "" ? DateTime.Now : Convert.ToDateTime(gr1.Cells["shengchandate"].Value);
                    warehouseinv.qualityDate = gr1.Cells["baozhiqi"].Value.ToString() == "" ? 0.0M : Convert.ToDecimal(gr1.Cells["baozhiqi"].Value.ToString());
                    warehouseinv.stockCode = XYEEncoding.strCodeHex(cboPanDianIdea.SelectedValue.ToString());
                    warehouseinv.stockName = XYEEncoding.strCodeHex(cboPanDianIdea.Text);
                    warehouseinv.reserved1 = "";
                    warehouseinv.reserved2 = "";
                    WarehouseInventoryDetailInterface wareinvent = new WarehouseInventoryDetailInterface();
                    int result = wareinvent.Add(warehouseinv);
                    if (result == 1)
                    {
                        return;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("错误代码:2304-添加盘点表数据错误，请检查：" + ex.Message,"盘点表温馨提示");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("错误代码：2305-商品盘点表统计数量错误，请检查：" + ex.Message, "盘点表温馨提示");
            }
        }
        #endregion

        /// <summary>
        /// 盘点编制的点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButtonBianZhi_Click(object sender, EventArgs e)
        {
            WareHouseInventoryReportForm warehouseinvent = new WareHouseInventoryReportForm();
            warehouseinvent.StorageCode = cboPanDianIdea.SelectedValue.ToString();
            warehouseinvent.StorageName = cboPanDianIdea.Text;
            warehouseinvent.InventoryCode = this.textBoxpandiancode.Text;
            warehouseinvent.Show();
        }

        private void WareHouseInventoryForm_Activated(object sender, EventArgs e)
        {
            cboPanDianIdea.Focus();
        }

        /// <summary>
        /// 快捷方式
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void WareHouseInventoryForm_KeyDown(object sender, KeyEventArgs e)
        {
            //前单
            if (e.KeyCode == Keys.A  )
            {
                MessageBox.Show("添加");
                return;
            }
            //后单
            if (e.KeyCode == Keys.C  )
            {
                MessageBox.Show("清除");
                return;
            }
            //新增
            if (e.KeyCode == Keys.Z  )
            {
                toolStripButtonBianZhi_Click(sender,e);
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