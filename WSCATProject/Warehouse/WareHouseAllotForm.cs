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
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Model;

namespace WSCATProject.Warehouse
{
    public partial class WareHouseAllotForm : TestForm
    {
        public WareHouseAllotForm()
        {
            InitializeComponent();
        }

        #region 调用接口以及加密解密方法
        CodingHelper ch = new CodingHelper();
        EmpolyeeInterface employee = new EmpolyeeInterface();
        StorageInterface storage = new StorageInterface();
        WarehouseMainInterface waremain = new WarehouseMainInterface();
        WarehouseAllotInterface warehouseallterface = new WarehouseAllotInterface();
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
        /// 调拨单code
        /// </summary>
        private string _WareHouseAllotCode;
        /// <summary>
        /// 所有商品列表
        /// </summary>
        private DataTable _AllMaterial = null;
        /// <summary>
        /// 所有仓库列表
        /// </summary>
        private DataTable _AllStorage = null;
        /// <summary>
        /// 保存仓库的Code
        /// </summary>
        private string _StorageCode = "";
        /// <summary>
        /// 保存商品Code
        /// </summary>
        private string _MaterialCode = "";
        /// <summary>
        /// 调出仓库列表
        /// </summary>
        private KeyValuePair<string, string> _ClickOutStorageList;
        /// <summary>
        /// 调入仓库列表
        /// </summary>
        private KeyValuePair<string, string> _ClickInStorageList;
        //保存调入仓库
        private string _InStorage;
        /// <summary>
        /// 保存调出仓库
        /// </summary>
        private string _OutStorage;
        /// <summary>
        /// 保存仓库状态 1、调出仓库 2、调入仓库 3、商品列表
        /// </summary>
        private int _StorageState;
        /// <summary>
        /// 统计数量
        /// </summary>
        private decimal _MaterialNumber;
        /// <summary>
        /// 统计调出金额
        /// </summary>
        private decimal _MaterialMoney;
        /// <summary>
        /// 统计调入金额
        /// </summary>
        private decimal _MaterInMoney;
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

        private void WareHouseAllotForm_Load(object sender, EventArgs e)
        {
            try
            {
                //业务员
                _AllEmployee = employee.SelSupplierTable(false);
                //仓库
                _AllStorage = storage.GetList(00, "");
                superGridControlShangPing.PrimaryGrid.SortCycle = SortCycle.AscDesc;    //排序方式范围
                superGridControlShangPing.PrimaryGrid.AddSort(superGridControlShangPing.PrimaryGrid.Columns[0], SortDirection.Ascending);//设置排序列和排序方式
                superGridControlShangPing.PrimaryGrid.ShowRowGridIndex = true;//显示行号
                //调入单价
                GridDoubleInputEditControl diaoruprice = superGridControlShangPing.PrimaryGrid.Columns["gridColumnpricein"].EditControl as GridDoubleInputEditControl;
                diaoruprice.MinValue = 0;
                diaoruprice.MaxValue = 999999999;
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
                // 将dataGridView中的内容居中显示
                dataGridViewFuJia.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                //显示行号
                superGridControlShangPing.PrimaryGrid.ShowRowGridIndex = true;
                //内容居中
                superGridControlShangPing.DefaultVisualStyles.CellStyles.Default.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleCenter;
                //调用合计行数据
                InitDataGridView();
                cboType.SelectedIndex = 0;
                //生成code 和显示条形码
                _WareHouseAllotCode = BuildCode.ModuleCode("WIA");
                textBoxOddNumbers.Text = _WareHouseAllotCode;
                barcodeXYE.Code128 _Code = new barcodeXYE.Code128();
                _Code.ValueFont = new Font("微软雅黑", 20);
                System.Drawing.Bitmap imgTemp = _Code.GetCodeImage(textBoxOddNumbers.Text, barcodeXYE.Code128.Encode.Code128A);
                pictureBox9.Image = imgTemp;

                toolStripBtnSave.Click += toolStripBtnSave_Click;//保存按钮
                toolStripBtnShengHe.Click += toolStripBtnShengHe_Click;//审核按钮
                dataGridViewFuJia.KeyDown += DataGridViewFuJia_KeyDown;
            }
            catch (Exception ex)
            {
                MessageBox.Show("错误代码：2801-初始化调拨窗体数据错误" + ex.Message, "调拨单温馨提示");
                this.Close();
                return;
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
                Review();
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
            //调出金额
            gr.Cells["gridColumnmoneyout"].Value = 0;
            gr.Cells["gridColumnmoneyout"].CellStyles.Default.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleCenter;
            gr.Cells["gridColumnmoneyout"].CellStyles.Default.Background.Color1 = Color.Orange;
            //调入金额
            gr.Cells["gridColumnmoneyin"].Value = 0;
            gr.Cells["gridColumnmoneyin"].CellStyles.Default.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleCenter;
            gr.Cells["gridColumnmoneyin"].CellStyles.Default.Background.Color1 = Color.Orange;

            #region 合计行不能点击
            gr.Cells["gridColumnStock"].AllowSelection = false;
            gr.Cells["material"].AllowSelection = false;
            gr.Cells["gridColumnStockIn"].AllowSelection = false;
            gr.Cells["gridColumnnumber"].AllowSelection = false;
            gr.Cells["gridColumnpriceout"].AllowSelection = false;
            gr.Cells["gridColumnpricein"].AllowSelection = false;

            #endregion
        }

        /// <summary>
        /// 非空验证
        /// </summary>
        private bool isNUllValidate()
        {
            if (cboType.Text.Trim() == null)
            {
                MessageBox.Show("出库类别不能为空！");
                return false;
            }
            GridRow gr = (GridRow)superGridControlShangPing.PrimaryGrid.Rows[1];
            if (gr.Cells["gridColumnStock"].Value == null || gr.Cells["gridColumnStock"].Value.ToString() == "")
            {
                MessageBox.Show("调出仓库不能为空！");
                return false;
            }
            if (gr.Cells["gridColumnStockIn"].Value == null || gr.Cells["gridColumnStockIn"].Value.ToString() == "")
            {
                MessageBox.Show("调入仓库不能为空！");
                return false;
            }
            if (gr.Cells["material"].Value == null || gr.Cells["material"].Value.ToString() == "")
            {
                MessageBox.Show("商品代码不能为空！");
                return false;
            }
            if (ltxtbSalsMan.Text.Trim() == null || ltxtbSalsMan.Text == "")
            {
                MessageBox.Show("调拨员不能为空！");
                return false;
            }
            return true;
        }

        /// <summary>
        /// 初始化业务员
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
                MessageBox.Show("错误代码：2806-初始化调拨员数据错误" + ex.Message);
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
                MessageBox.Show("错误代码：2807-初始化仓库数据错误！" + ex.Message, "调拨单微信提示");
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
            dgvc.Name = "productionDate";
            dgvc.Visible = false;
            dgvc.HeaderText = "生产/采购日期";
            dgvc.DataPropertyName = "productionDate";
            dataGridViewShangPing.Columns.Add(dgvc);

            dgvc = new DataGridViewTextBoxColumn();
            dgvc.Name = "qualityDate";
            dgvc.Visible = false;
            dgvc.HeaderText = "保质期";
            dgvc.DataPropertyName = "qualityDate";
            dataGridViewShangPing.Columns.Add(dgvc);

            dgvc = new DataGridViewTextBoxColumn();
            dgvc.Name = "effectiveDate";
            dgvc.Visible = false;
            dgvc.HeaderText = "有效期至";
            dgvc.DataPropertyName = "effectiveDate";
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
        /// 初始化窗体控件可用不可用
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
            this.pictureBox6.Parent = pictureBoxtitle;
            this.pictureBox6.Image = Properties.Resources.审核;
            pictureBox6.Visible = true;
            this.toolStripBtnShengHe.Enabled = false;
            this.toolStripBtnSave.Enabled = false;
            this.toolStripBtnInsert.Enabled = false;
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

        private void dataGridViewFuJia_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
            {
                return;
            }
            dataGridViewFuJiaTableClick();
        }

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
        /// 第一个表格选择调出出库
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void superGridControlShangPing_BeginEdit(object sender, GridEditEventArgs e)
        {
            try
            {
                if (e.GridCell.GridColumn.Name == "gridColumnStock")
                {
                    //绑定仓库列表
                    InitStorageList();
                    _StorageState = 1;
                    return;
                }
                if (e.GridCell.GridColumn.Name == "gridColumnStockIn")
                {
                    //绑定仓库列表
                    InitStorageList();
                    _StorageState = 2;
                    return;
                }
                if (e.GridCell.GridColumn.Name == "material")
                {
                    if (_OutStorage != null || _InStorage != null)
                    {
                        _AllMaterial = waremain.GetWMainAndMaterialByWMCode(999, "", XYEEncoding.strCodeHex(_OutStorage));
                        InitMaterialDataGridView();
                        _StorageState = 3;
                    }
                    else
                    {
                        this.resizablePanelData.Visible = false;
                        MessageBox.Show("请先选择调入和调出仓库!");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("错误代码：2810-选择表格第一格数据错误！" + ex.Message);
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
            //若是没数据的行则不做处理
            if (gr.Cells["material"].Value == null)
            {
                return;
            }

            if (e.GridCell.GridColumn.Name == "gridColumnnumber" ||
                e.GridCell.GridColumn.Name == "gridColumnpriceout" ||
                e.GridCell.GridColumn.Name == "gridColumnpricein")
            {
                //添加对应的单价和总价
                if (e.GridCell.GridColumn.Name == "gridColumnnumber" &&
                    !string.IsNullOrEmpty(e.GridCell.FormattedValue))
                {
                    _MaterialNumber += decimal.Parse(e.GridCell.FormattedValue);
                }
                if (e.GridCell.GridColumn.Name == "gridColumnpriceout" &&
                    !string.IsNullOrEmpty(e.GridCell.FormattedValue))
                {
                    _MaterialMoney += decimal.Parse(e.GridCell.FormattedValue);
                }
                //调入价格单价
                if (e.GridCell.GridColumn.Name == "gridColumnpricein" &&
                 !string.IsNullOrEmpty(e.GridCell.FormattedValue))
                {
                    _MaterInMoney += decimal.Parse(e.GridCell.FormattedValue);
                }
                //计算金额
                try
                {
                    decimal number = 0;
                    decimal tempAllNumber = 0;//统计数量
                    decimal tempAllMoney = 0;//调出金额
                    decimal temAllInMoney = 0;//调入金额
                    if (cboType.Text == "同价调拨")
                    {
                        number = Convert.ToDecimal(gr.Cells["gridColumnnumber"].FormattedValue);
                        decimal priceout = Convert.ToDecimal(gr.Cells["gridColumnpriceout"].FormattedValue);
                        decimal allOutPrice = number * priceout;
                        gr.Cells["gridColumnmoneyout"].Value = allOutPrice;

                        //逐行统计数据总数
                        for (int i = 0; i < superGridControlShangPing.PrimaryGrid.Rows.Count - 1; i++)
                        {
                            GridRow tempGR = superGridControlShangPing.PrimaryGrid.Rows[i] as GridRow;
                            tempAllNumber += Convert.ToDecimal(tempGR["gridColumnnumber"].FormattedValue);
                            tempAllMoney += Convert.ToDecimal(tempGR["gridColumnmoneyout"].FormattedValue);
                        }
                        _MaterialNumber = tempAllNumber;
                        _MaterialMoney = tempAllMoney;
                        gr = (GridRow)superGridControlShangPing.PrimaryGrid.LastSelectableRow;
                        gr["gridColumnnumber"].Value = _MaterialNumber.ToString();
                        gr["gridColumnmoneyout"].Value = _MaterialMoney.ToString();
                    }
                    if (cboType.Text == "异价调拨")
                    {
                        number = Convert.ToDecimal(gr.Cells["gridColumnnumber"].FormattedValue);
                        decimal pricein = Convert.ToDecimal(gr.Cells["gridColumnpricein"].FormattedValue);
                        decimal allInmoney = number * pricein;
                        gr.Cells["gridColumnmoneyin"].Value = allInmoney;

                        for (int i = 0; i < superGridControlShangPing.PrimaryGrid.Rows.Count - 1; i++)
                        {
                            GridRow tempGR = superGridControlShangPing.PrimaryGrid.Rows[i] as GridRow;
                            tempAllNumber += Convert.ToDecimal(tempGR["gridColumnnumber"].FormattedValue);
                            temAllInMoney += Convert.ToDecimal(tempGR["gridColumnmoneyin"].FormattedValue);
                        }
                        _MaterialNumber = tempAllNumber;
                        _MaterInMoney = temAllInMoney;
                        gr = (GridRow)superGridControlShangPing.PrimaryGrid.LastSelectableRow;
                        gr["gridColumnnumber"].Value = _MaterialNumber.ToString();
                        gr["gridColumnmoneyin"].Value = _MaterInMoney.ToString();
                    }
                    labtextboxTop7.Text = (_MaterInMoney - _MaterialMoney).ToString();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("错误代码：2811-金额转换错误" + ex.Message);
                }
            }
        }

        /// <summary>
        ///下拉框的选择改变事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cboType_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                switch (cboType.Text.Trim())
                {
                    case "同价调拨":
                        superGridControlShangPing.PrimaryGrid.Columns["gridColumnpricein"].Visible = false;
                        superGridControlShangPing.PrimaryGrid.Columns["gridColumnmoneyin"].Visible = false;
                        labTop9.Visible = false;
                        labtextboxTop7.Visible = false;

                        break;
                    case "异价调拨":
                        superGridControlShangPing.PrimaryGrid.Columns["gridColumnpricein"].Visible = true;
                        superGridControlShangPing.PrimaryGrid.Columns["gridColumnmoneyin"].Visible = true;
                        labTop9.Visible = true;
                        labtextboxTop7.Visible = true;
                        superGridControlShangPing.PrimaryGrid.Columns["gridColumnmoneyin"].ReadOnly = true;
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("错误代码：2812-选择调拨类型数据错误" + ex.Message);
            }

        }

        /// <summary>
        /// 点击panel隐藏panel
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void panel2_Click(object sender, EventArgs e)
        {
            resizablePanel1.Visible = false;
        }

        /// <summary>
        /// 业务员模糊查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ltxtbSalsMan_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (ltxtbSalsMan.Text.Trim() == "")
                {
                    _Click = 3;
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

                resizablePanel1.Location = new Point(234, 420);
                dataGridViewFuJia.DataSource = ch.DataTableReCoding(employee.GetList(0, "" + XYEEncoding.strCodeHex(ltxtbSalsMan.Text.Trim()) + ""));
                resizablePanel1.Visible = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("错误代码：2813-业务员模糊查询数据失败！" + ex.Message);
            }

        }
        /// <summary>
        /// 表格里面模糊查询
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
                    _AllMaterial = waremain.GetWMainAndMaterialByWMCode(0, "" + materialDaima + "", "" + XYEEncoding.strCodeHex(_OutStorage + ""));
                    InitMaterialDataGridView();
                    dataGridViewShangPing.DataSource = ch.DataTableReCoding(_AllMaterial);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("错误代码:2814-商品表格模糊查询错误，查询数据错误" + ex.Message, "入库单温馨提示");
            }
        }

        private void WareHouseAllotForm_Activated(object sender, EventArgs e)
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
        /// 验证单号
        /// </summary>
        /// <returns></returns>
        private string validateCode()
        {
            //验证单号
            if (warehouseallterface.Exists(XYEEncoding.strCodeHex(_WareHouseAllotCode)))
            {
                _WareHouseAllotCode = BuildCode.ModuleCode("WIA");
            }
            else
            {
                _WareHouseAllotCode = textBoxOddNumbers.Text;
            }

            return _WareHouseAllotCode;
        }

        /// <summary>
        /// 保存按钮函数
        /// </summary>
        private void Save()
        {
            //非空验证
            if (isNUllValidate() == false)
            {
                return;
            }
            //获得界面上的数据,准备传给base层新增数据
            //WarehouseAllotInterface warehouseallterface = new WarehouseAllotInterface();
            //调拨单
            WarehouseAllot warehouseallot = new WarehouseAllot();
            //调拨商品列表
            List<WarehouseAllotDetail> wareHouseallList = new List<WarehouseAllotDetail>();
            try
            {
                #region 调拨单基本数据
                warehouseallot.code = XYEEncoding.strCodeHex(validateCode());//调拨单单号
                if (cboType.Text != null || cboType.Text.ToString() != "")
                {
                    warehouseallot.allotType = XYEEncoding.strCodeHex(cboType.Text);
                }
                else
                {
                    MessageBox.Show("调拨类型不能为空！");
                    cboType.Focus();
                    return;
                }
                if (ltxtbSalsMan.Text != null || ltxtbSalsMan.Text.ToString() != "")
                {
                    warehouseallot.makeMan = XYEEncoding.strCodeHex(ltxtbSalsMan.Text);
                }
                else
                {
                    MessageBox.Show("调拨员不能为空！");
                    ltxtbSalsMan.Focus();
                    return;
                }
                warehouseallot.allotGap = labtextboxTop7.Text == "" ? 0.0M : Convert.ToDecimal(labtextboxTop7.Text);
                warehouseallot.cause = labtextboxTop6.Text == "" ? "" : XYEEncoding.strCodeHex(labtextboxTop6.Text);
                warehouseallot.checkMan = ltxtbShengHeMan.Text == "" ? "" : XYEEncoding.strCodeHex(ltxtbShengHeMan.Text);
                warehouseallot.checkState = 0;
                warehouseallot.date = dateTimePicker1.Value;
                warehouseallot.isClear = 1;
                warehouseallot.operationMan = ltxtbMakeMan.Text == "" ? "" : XYEEncoding.strCodeHex(ltxtbMakeMan.Text);
                warehouseallot.remark = "";
                warehouseallot.reserved1 = "";
                warehouseallot.reserved2 = "";
                warehouseallot.updateDate = DateTime.Now;
                #endregion
            }
            catch (Exception ex)
            {
                MessageBox.Show("错误代码:2802;尝试创建调拨单商品数据出错,请检查输入" + ex.Message, "调拨单温馨提示");
                return;
            }
            try
            {
                #region 调拨单表格详细数据
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
                        WarehouseAllotDetail warehousealld = new WarehouseAllotDetail();
                        warehousealld.mainCode = XYEEncoding.strCodeHex(textBoxOddNumbers.Text);
                        warehousealld.code = XYEEncoding.strCodeHex(textBoxOddNumbers.Text) + i.ToString();
                        if (gr["gridColumnStockIn"].Value.ToString() != "")
                        {
                            warehousealld.stoInName = XYEEncoding.strCodeHex(gr["gridColumnStockIn"].Value.ToString());//调入仓库
                        }
                        else
                        {
                            MessageBox.Show("单据体表格内调入仓库不能为空！");
                            return;
                        }
                        if (gr["gridColumnStock"].Value.ToString() != "")
                        {
                            warehousealld.stoOutName = XYEEncoding.strCodeHex(gr["gridColumnStock"].Value.ToString());//调出仓库
                        }
                        else
                        {
                            MessageBox.Show("单据体表格内调出仓库不能为空！");
                            return;
                        }
                        if (gr["material"].Value.ToString() != "")
                        {
                            warehousealld.materialDaima = XYEEncoding.strCodeHex(gr["material"].Value.ToString());//商品代码
                        }
                        else
                        {
                            MessageBox.Show("单据体表格内商品代码不能为空！");
                            return;
                        }
                        decimal InMoney = Convert.ToDecimal(gr["gridColumnnumber"].Value) * Convert.ToDecimal(gr["gridColumnpricein"].Value);
                        if (InMoney == Convert.ToDecimal(gr["gridColumnmoneyin"].Value))
                        {
                            warehousealld.allotInSummoney = gr["gridColumnmoneyin"].Value == null ? 0.0M : Convert.ToDecimal(gr["gridColumnmoneyin"].Value.ToString());//调入金额
                        }
                        else
                        {
                            MessageBox.Show("单据体表格内调入金额计算错误！");
                            return;
                        }
                        decimal OutMoney = Convert.ToDecimal(gr["gridColumnnumber"].Value) * Convert.ToDecimal(gr["gridColumnpriceout"].Value);
                        if (OutMoney == Convert.ToDecimal(gr["gridColumnmoneyout"].Value))
                        {
                            warehousealld.allotOutSummoney = gr["gridColumnmoneyout"].Value == null ? 0.0M : Convert.ToDecimal(gr["gridColumnmoneyout"].Value.ToString());//调出金额
                        }
                        else
                        {
                            MessageBox.Show("单据体表格内调出金额计算错误！");
                            return;
                        }
                        warehousealld.allotInPrice = gr["gridColumnpricein"].Value == null ? 0.0M : Convert.ToDecimal(gr["gridColumnpricein"].Value.ToString()); //调入单价                    
                        warehousealld.allotOutPrice = gr["gridColumnpriceout"].Value == null ? 0.0M : Convert.ToDecimal(gr["gridColumnpriceout"].Value.ToString());//调出单价                
                        warehousealld.barcode = gr["gridColumntiaoxingma"].Value.ToString() == "" ? "" : XYEEncoding.strCodeHex(gr["gridColumntiaoxingma"].Value.ToString());    //条形码             
                        warehousealld.curNumber = gr["gridColumnnumber"].Value == null ? 0.0M : Convert.ToDecimal(gr["gridColumnnumber"].Value.ToString());//数量
                        warehousealld.effectiveDate = gr["gridColumnyouxiao"].Value == DBNull.Value ? Convert.ToDateTime("1990-01-01") : Convert.ToDateTime(gr["gridColumnyouxiao"].Value);//有效期至
                        warehousealld.isClear = 1;
                        warehousealld.materialCode = gr["gridColumnMaterialcode"].Value.ToString() == "" ? "" : XYEEncoding.strCodeHex(gr["gridColumnMaterialcode"].Value.ToString());//物料code                     
                        warehousealld.materiaModel = gr["gridColumnmodel"].Value.ToString() == "" ? "" : XYEEncoding.strCodeHex(gr["gridColumnmodel"].Value.ToString());//规格型号
                        warehousealld.materiaName = gr["gridColumnname"].Value.ToString() == "" ? "" : XYEEncoding.strCodeHex(gr["gridColumnname"].Value.ToString());//物料名称
                        warehousealld.materiaUnit = gr["gridColumnunit"].Value.ToString() == "" ? "" : XYEEncoding.strCodeHex(gr["gridColumnunit"].Value.ToString());//单位
                        warehousealld.productionDate = gr["gridColumnshengchandate"].Value == DBNull.Value ? Convert.ToDateTime("1990-01-01") : Convert.ToDateTime(gr["gridColumnshengchandate"].Value);//生产/采购日期
                        warehousealld.qualityDate = gr["gridColumnbaozhi"].Value.ToString() == "" ? 0.0M : Convert.ToDecimal(gr["gridColumnbaozhi"].Value.ToString());//保质期
                        warehousealld.remark = gr["gridColumnremark"].Value.ToString() == "" ? "" : XYEEncoding.strCodeHex(gr["gridColumnremark"].Value.ToString());//备注
                        warehousealld.reserved1 = "";
                        warehousealld.reserved2 = "";
                        warehousealld.stoIncode = _InStorage == "" ? "" : XYEEncoding.strCodeHex(_InStorage); //调入仓库code                     
                        warehousealld.stoOutcode = _OutStorage == "" ? "" : XYEEncoding.strCodeHex(_OutStorage);//调出仓库code            
                        warehousealld.updateDate = DateTime.Now;
                        GridRow dr = superGridControlShangPing.PrimaryGrid.Rows[0] as GridRow;
                        wareHouseallList.Add(warehousealld);
                    }
                }
                #endregion
            }
            catch (Exception ex)
            {
                MessageBox.Show("错误代码：2803-尝试创建调拨单详商品数据出错,请检查输入" + ex.Message, "调拨单温馨提示");
                return;
            }
            //增加一条入库单和入库单详细数据
            object warehouseInResult = warehouseallterface.AddAndModify(warehouseallot, wareHouseallList);
            //this.textBoxid.Text = warehouseInResult.ToString();
            if (warehouseInResult != null)
            {
                MessageBox.Show("新增调拨数据成功", "调拨单温馨提示");
                this.toolStripBtnSave.Enabled = false;
            }
        }

        /// <summary>
        /// 审核按钮函数
        /// </summary>
        private void Review()
        {
            //非空验证
            if (isNUllValidate() == false)
            {
                return;
            }
            //获得界面上的数据,准备传给base层新增数据
            WarehouseAllotInterface warehouseallterface = new WarehouseAllotInterface();
            //调拨单
            WarehouseAllot warehouseallot = new WarehouseAllot();
            //调拨商品列表
            List<WarehouseAllotDetail> wareHouseallList = new List<WarehouseAllotDetail>();
            try
            {
                #region 调拨单基本数据
                warehouseallot.code = XYEEncoding.strCodeHex(textBoxOddNumbers.Text);
                if (cboType.Text != null || cboType.Text.ToString() != "")
                {
                    warehouseallot.allotType = XYEEncoding.strCodeHex(cboType.Text);
                }
                else
                {
                    MessageBox.Show("调拨类型不能为空！");
                    cboType.Focus();
                    return;
                }
                if (ltxtbSalsMan.Text != null || ltxtbSalsMan.Text.ToString() != "")
                {
                    warehouseallot.makeMan = XYEEncoding.strCodeHex(ltxtbSalsMan.Text);
                }
                else
                {
                    MessageBox.Show("调拨员不能为空！");
                    ltxtbSalsMan.Focus();
                    return;
                }
                warehouseallot.allotGap = labtextboxTop7.Text == "" ? 0.0M : Convert.ToDecimal(labtextboxTop7.Text);
                warehouseallot.cause = labtextboxTop6.Text == "" ? "" : XYEEncoding.strCodeHex(labtextboxTop6.Text);
                warehouseallot.checkMan = ltxtbShengHeMan.Text == "" ? "" : XYEEncoding.strCodeHex(ltxtbShengHeMan.Text);
                warehouseallot.checkState = 1;
                warehouseallot.date = dateTimePicker1.Value;
                warehouseallot.isClear = 1;
                warehouseallot.operationMan = ltxtbMakeMan.Text == "" ? "" : XYEEncoding.strCodeHex(ltxtbMakeMan.Text);
                warehouseallot.remark = "";
                warehouseallot.reserved1 = "";
                warehouseallot.reserved2 = "";
                warehouseallot.updateDate = DateTime.Now;
                #endregion

            }
            catch (Exception ex)
            {
                MessageBox.Show("错误代码:2804;尝试创建和审核调拨单商品数据出错,请检查输入" + ex.Message, "调拨单温馨提示");
                return;
            }
            try
            {
                #region 调拨单表格详细数据
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
                        WarehouseAllotDetail warehousealld = new WarehouseAllotDetail();
                        warehousealld.mainCode = XYEEncoding.strCodeHex(textBoxOddNumbers.Text);
                        warehousealld.code = XYEEncoding.strCodeHex(textBoxOddNumbers.Text) + i.ToString();
                        if (gr["gridColumnStockIn"].Value.ToString() != "")
                        {
                            warehousealld.stoInName = XYEEncoding.strCodeHex(gr["gridColumnStockIn"].Value.ToString());//调入仓库
                        }
                        else
                        {
                            MessageBox.Show("单据体表格内调入仓库不能为空！");
                            return;
                        }
                        if (gr["gridColumnStock"].Value.ToString() != "")
                        {
                            warehousealld.stoOutName = XYEEncoding.strCodeHex(gr["gridColumnStock"].Value.ToString());//调出仓库
                        }
                        else
                        {
                            MessageBox.Show("单据体表格内调出仓库不能为空！");
                            return;
                        }
                        if (gr["material"].Value.ToString() != "")
                        {
                            warehousealld.materialDaima = XYEEncoding.strCodeHex(gr["material"].Value.ToString());//商品代码
                        }
                        else
                        {
                            MessageBox.Show("单据体表格内商品代码不能为空！");
                            return;
                        }
                        decimal InMoney = Convert.ToDecimal(gr["gridColumnnumber"].Value) * Convert.ToDecimal(gr["gridColumnpricein"].Value);
                        if (InMoney == Convert.ToDecimal(gr["gridColumnmoneyin"].Value))
                        {
                            warehousealld.allotInSummoney = gr["gridColumnmoneyin"].Value == null ? 0.0M : Convert.ToDecimal(gr["gridColumnmoneyin"].Value.ToString());//调入金额
                        }
                        else
                        {
                            MessageBox.Show("单据体表格内调入金额计算错误！");
                            return;
                        }
                        decimal OutMoney = Convert.ToDecimal(gr["gridColumnnumber"].Value) * Convert.ToDecimal(gr["gridColumnpriceout"].Value);
                        if (OutMoney == Convert.ToDecimal(gr["gridColumnmoneyout"].Value))
                        {
                            warehousealld.allotOutSummoney = gr["gridColumnmoneyout"].Value == null ? 0.0M : Convert.ToDecimal(gr["gridColumnmoneyout"].Value.ToString());//调出金额
                        }
                        else
                        {
                            MessageBox.Show("单据体表格内调出金额计算错误！");
                            return;
                        }
                        warehousealld.allotInPrice = gr["gridColumnpricein"].Value == null ? 0.0M : Convert.ToDecimal(gr["gridColumnpricein"].Value.ToString()); //调入单价                    
                        warehousealld.allotOutPrice = gr["gridColumnpriceout"].Value == null ? 0.0M : Convert.ToDecimal(gr["gridColumnpriceout"].Value.ToString());//调出单价                
                        warehousealld.barcode = gr["gridColumntiaoxingma"].Value.ToString() == "" ? "" : XYEEncoding.strCodeHex(gr["gridColumntiaoxingma"].Value.ToString());    //条形码             
                        warehousealld.curNumber = gr["gridColumnnumber"].Value == null ? 0.0M : Convert.ToDecimal(gr["gridColumnnumber"].Value.ToString());//数量
                        warehousealld.effectiveDate = gr["gridColumnyouxiao"].Value == DBNull.Value ? Convert.ToDateTime("1990-01-01") : Convert.ToDateTime(gr["gridColumnyouxiao"].Value);//有效期至
                        warehousealld.isClear = 1;
                        warehousealld.materialCode = gr["gridColumnMaterialcode"].Value.ToString() == "" ? "" : XYEEncoding.strCodeHex(gr["gridColumnMaterialcode"].Value.ToString());//物料code                     
                        warehousealld.materiaModel = gr["gridColumnmodel"].Value.ToString() == "" ? "" : XYEEncoding.strCodeHex(gr["gridColumnmodel"].Value.ToString());//规格型号
                        warehousealld.materiaName = gr["gridColumnname"].Value.ToString() == "" ? "" : XYEEncoding.strCodeHex(gr["gridColumnname"].Value.ToString());//物料名称
                        warehousealld.materiaUnit = gr["gridColumnunit"].Value.ToString() == "" ? "" : XYEEncoding.strCodeHex(gr["gridColumnunit"].Value.ToString());//单位
                        warehousealld.productionDate = gr["gridColumnshengchandate"].Value == DBNull.Value ? Convert.ToDateTime("1990-01-01") : Convert.ToDateTime(gr["gridColumnshengchandate"].Value);//生产/采购日期
                        warehousealld.qualityDate = gr["gridColumnbaozhi"].Value.ToString() == "" ? 0.0M : Convert.ToDecimal(gr["gridColumnbaozhi"].Value.ToString());//保质期
                        warehousealld.remark = gr["gridColumnremark"].Value.ToString() == "" ? "" : XYEEncoding.strCodeHex(gr["gridColumnremark"].Value.ToString());//备注
                        warehousealld.reserved1 = "";
                        warehousealld.reserved2 = "";
                        warehousealld.stoIncode = _InStorage == "" ? "" : XYEEncoding.strCodeHex(_InStorage); //调入仓库code                     
                        warehousealld.stoOutcode = _OutStorage == "" ? "" : XYEEncoding.strCodeHex(_OutStorage);//调出仓库code            
                        warehousealld.updateDate = DateTime.Now;
                        GridRow dr = superGridControlShangPing.PrimaryGrid.Rows[0] as GridRow;
                        wareHouseallList.Add(warehousealld);
                    }
                }
                #endregion
            }
            catch (Exception ex)
            {
                MessageBox.Show("错误代码：2805-尝试创建和审核调拨单详商品数据出错,请检查输入" + ex.Message, "调拨单温馨提示");
                return;
            }
            //增加一条入库单和入库单详细数据
            object warehouseInResult = warehouseallterface.AddAndModify(warehouseallot, wareHouseallList);
            if (warehouseInResult != null)
            {
                MessageBox.Show("新增并保存调拨数据成功", "调拨单温馨提示");
                InitForm();
            }
        }

        /// <summary>
        /// dataGridViewFuJia双击表格函数
        /// </summary>
        private void dataGridViewFuJiaTableClick()
        {
            try
            {
                //业务员
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
                    //判断是调入还是调出仓库
                    if (_StorageState == 1)
                    {
                        string codeout = dataGridViewFuJia.Rows[dataGridViewFuJia.CurrentRow.Index].Cells["code"].Value.ToString();
                        string OutName = dataGridViewFuJia.Rows[dataGridViewFuJia.CurrentRow.Index].Cells["name"].Value.ToString();
                        gr.Cells["gridColumnStock"].Value = OutName;
                        gr.Cells["gridColumnoutcode"].Value = codeout;
                        _ClickOutStorageList = new KeyValuePair<string, string>(codeout, OutName);
                        _OutStorage = codeout;

                    }
                    else
                    {
                        string codein = dataGridViewFuJia.Rows[dataGridViewFuJia.CurrentRow.Index].Cells["code"].Value.ToString();
                        string Inname = dataGridViewFuJia.Rows[dataGridViewFuJia.CurrentRow.Index].Cells["name"].Value.ToString();
                        gr.Cells["gridColumnStockIn"].Value = Inname;
                        gr.Cells["gridColumnincode"].Value = codein;
                        _ClickInStorageList = new KeyValuePair<string, string>(codein, Inname);
                        _InStorage = codein;
                    }
                    resizablePanel1.Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("错误代码：2808-双击绑定仓库或者业务员错误！请检查：" + ex.Message);
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
                GridItemsCollection grs = superGridControlShangPing.PrimaryGrid.Rows;
                //id字段为空 说明是没有数据的行 不是修改而是新增
                if (gr.Cells["gridColumnid"].Value == null)
                {
                    newAdd = true;
                }
                foreach (GridRow g in grs)
                {
                    if (g.Cells["gridColumnMaterialcode"].Value == null)
                    {
                        newAdd = true;
                        continue;
                    }
                    if (g.Cells["gridColumnMaterialcode"].Value.Equals(dataGridViewShangPing.Rows[dataGridViewShangPing.CurrentRow.Index].Cells["code"].Value))
                    {
                        decimal shuliang = Convert.ToDecimal(g.Cells["gridColumnnumber"].Value);
                        shuliang += 1;
                        g.Cells["gridColumnnumber"].Value = shuliang;
                        try
                        {
                            decimal tempAllNumber = 0;//统计数量
                            decimal tempAllMoney = 0;//调出金额

                            decimal priceout = Convert.ToDecimal(dataGridViewShangPing.Rows[dataGridViewShangPing.CurrentRow.Index].Cells["price"].Value);
                            decimal allOutPrice = shuliang * priceout;
                            g.Cells["gridColumnmoneyout"].Value = allOutPrice;

                            //逐行统计数据总数
                            for (int i = 0; i < superGridControlShangPing.PrimaryGrid.Rows.Count - 1; i++)
                            {
                                GridRow tempGR = superGridControlShangPing.PrimaryGrid.Rows[i] as GridRow;
                                tempAllNumber += Convert.ToDecimal(tempGR["gridColumnnumber"].FormattedValue);
                                tempAllMoney += Convert.ToDecimal(tempGR["gridColumnmoneyout"].FormattedValue);
                            }
                            _MaterialNumber = tempAllNumber;
                            _MaterialMoney = tempAllMoney;
                            gr = (GridRow)superGridControlShangPing.PrimaryGrid.LastSelectableRow;
                            gr["gridColumnnumber"].Value = _MaterialNumber.ToString();
                            gr["gridColumnmoneyout"].Value = _MaterialMoney.ToString();
                            labtextboxTop7.Text = (_MaterInMoney - _MaterialMoney).ToString();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("金额转换错误" + ex.Message);
                        }
                        resizablePanelData.Visible = false;
                        return;
                    }
                    continue;
                }
                gr.Cells["material"].Value = dataGridViewShangPing.Rows[dataGridViewShangPing.CurrentRow.Index].Cells["materialDaima"].Value;//商品代码
                gr.Cells["gridColumnname"].Value = dataGridViewShangPing.Rows[dataGridViewShangPing.CurrentRow.Index].Cells["name"].Value;//商品名称
                gr.Cells["gridColumnmodel"].Value = dataGridViewShangPing.Rows[dataGridViewShangPing.CurrentRow.Index].Cells["model"].Value;//规格型号
                gr.Cells["gridColumntiaoxingma"].Value = dataGridViewShangPing.Rows[dataGridViewShangPing.CurrentRow.Index].Cells["barCode"].Value;//条形码
                gr.Cells["gridColumnunit"].Value = dataGridViewShangPing.Rows[dataGridViewShangPing.CurrentRow.Index].Cells["unit"].Value;//单位
                if (true)
                {

                }
                gr.Cells["gridColumnnumber"].Value = dataGridViewShangPing.Rows[dataGridViewShangPing.CurrentRow.Index].Cells["currentNumber"].Value;//数量
                gr.Cells["gridColumnpriceout"].Value = dataGridViewShangPing.Rows[dataGridViewShangPing.CurrentRow.Index].Cells["price"].Value;//单价
                gr.Cells["gridColumnshengchandate"].Value = dataGridViewShangPing.Rows[dataGridViewShangPing.CurrentRow.Index].Cells["productionDate"].Value;//生产/采购日期
                gr.Cells["gridColumnbaozhi"].Value = dataGridViewShangPing.Rows[dataGridViewShangPing.CurrentRow.Index].Cells["qualityDate"].Value;//保质期
                gr.Cells["gridColumnyouxiao"].Value = dataGridViewShangPing.Rows[dataGridViewShangPing.CurrentRow.Index].Cells["effectiveDate"].Value;//有效期
                gr.Cells["gridColumnremark"].Value = dataGridViewShangPing.Rows[dataGridViewShangPing.CurrentRow.Index].Cells["remark"].Value;//备注
                gr.Cells["gridColumnincode"].Value = _InStorage;//调入仓库code
                gr.Cells["gridColumnoutcode"].Value = _OutStorage;//调出仓库code
                gr.Cells["gridColumnMaterialcode"].Value = dataGridViewShangPing.Rows[dataGridViewShangPing.CurrentRow.Index].Cells["code"].Value;//商品code 

                gr.Cells["gridColumnnumber"].Value = 1;

                decimal price = Convert.ToDecimal(dataGridViewShangPing.Rows[dataGridViewShangPing.CurrentRow.Index].Cells["price"].Value.Equals("") ?
                    0 : dataGridViewShangPing.Rows[dataGridViewShangPing.CurrentRow.Index].Cells["price"].Value);
                gr.Cells["gridColumnpriceout"].Value = price;
                gr.Cells["gridColumnmoneyout"].Value = price;
                resizablePanelData.Visible = false;

                //当上一次有选择仓库时 默认本次也为上次选择仓库
                if (!string.IsNullOrEmpty(_ClickOutStorageList.Value) && !string.IsNullOrEmpty(_ClickOutStorageList.Key))
                {
                    if (!string.IsNullOrEmpty(_ClickInStorageList.Value) && !string.IsNullOrEmpty(_ClickInStorageList.Key))
                    {
                        gr.Cells["gridColumnoutcode"].Value = _ClickOutStorageList.Key;
                        gr.Cells["gridColumnStock"].Value = _ClickOutStorageList.Value;
                        gr.Cells["gridColumnincode"].Value = _ClickInStorageList.Key;
                        gr.Cells["gridColumnStockIn"].Value = _ClickInStorageList.Value;
                    }
                }
                //新增一行 
                if (newAdd)
                {
                    superGridControlShangPing.PrimaryGrid.NewRow(superGridControlShangPing.PrimaryGrid.Rows.Count);
                    //递增数量和金额 默认为1和单价 
                    gr = (GridRow)superGridControlShangPing.PrimaryGrid.LastSelectableRow;
                    _MaterialNumber += 1;
                    _MaterialMoney += price;
                    gr.Cells["gridColumnnumber"].Value = _MaterialNumber;
                    gr.Cells["gridColumnmoneyout"].Value = _MaterialMoney;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("错误代码：2809-绑定商品数据错误" + ex.Message);
            }
            superGridControlShangPing.Focus();
            SendKeys.Send("^{End}{Home}");
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

        /// <summary>
        /// 快捷方式设置
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void WareHouseAllotForm_KeyDown(object sender, KeyEventArgs e)
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
    }
}
