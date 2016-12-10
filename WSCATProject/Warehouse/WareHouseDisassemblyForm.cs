using DevComponents.DotNetBar.SuperGrid;
using HelperUtility;
using HelperUtility.Encrypt;
using InterfaceLayer.Base;
using InterfaceLayer.Warehouse;
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
    public partial class WareHouseDisassemblyForm : TestForm
    {
        public WareHouseDisassemblyForm()
        {
            InitializeComponent();
        }

        #region 数据字段
        /// <summary>
        /// 所有拆卸员
        /// </summary>
        private DataTable _AllEmployee = null;
        /// <summary>
        /// 拆卸单code
        /// </summary>
        private string _WareHouseDisassemblyCode;
        /// <summary>
        /// 点击的项,1业务员
        /// </summary>
        private int _Click = 0;
        /// <summary>
        /// 所有仓库
        /// </summary>
        private DataTable _AllStorage = null;
        /// <summary>
        /// 保存仓库的Code
        /// </summary>
        private string _StorageCode = "";
        /// <summary>
        /// 仓库列表
        /// </summary>
        private KeyValuePair<string, string> _ClickStorageList;
        /// <summary>
        /// 所有商品列表
        /// </summary>
        private DataTable _AllMaterial = null;
        /// <summary>
        /// 保存仓库
        /// </summary>
        private int _WareHouse;
        /// <summary>
        ///保存商品
        /// </summary>
        private int _Material;
        /// <summary>
        /// 统计数量
        /// </summary>
        private decimal _MaterialNumber;
        private decimal _number;
        #endregion

        #region 实例化接口层 以及解密方法

        CodingHelper ch = new CodingHelper();
        EmpolyeeInterface employee = new EmpolyeeInterface();
        StorageInterface storage = new StorageInterface();
        WarehouseMainInterface waremain = new WarehouseMainInterface();
        WarehouseDisassemblyInterface warehouseDisassemblyinterface = new WarehouseDisassemblyInterface();
        #endregion

        #region 初始化数据
        /// <summary>
        /// 初始化拆卸员
        /// </summary>
        private void InitEmployee()
        {
            try
            {
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
                    resizablePanel1.Location = new Point(230, 500);
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("初始化拆卸员错误！请检查：" + ex.Message, "拆卸单温馨提示");
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
            gr.Cells["sup1material"].Value = "合计";
            gr.Cells["sup1material"].CellStyles.Default.Alignment =
                DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleCenter;
            gr.Cells["number"].Value = 0;
            gr.Cells["number"].CellStyles.Default.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleCenter;
            gr.Cells["number"].CellStyles.Default.Background.Color1 = Color.Orange;

            #region 合计行不能点击
            gr.Cells["gridColumnStockIn"].AllowSelection = false;
            gr.Cells["sup1material"].AllowSelection = false;
            gr.Cells["name"].AllowSelection = false;
            gr.Cells["model"].AllowSelection = false;
            gr.Cells["barcode"].AllowSelection = false;
            gr.Cells["unit"].AllowSelection = false;
            gr.Cells["number"].AllowSelection = false;
            gr.Cells["remark"].AllowSelection = false;
            #endregion
        }

        /// <summary>
        /// 非空验证
        /// </summary>
        private bool isNUllValidate()
        {
            if (cbotype.Text.Trim() == null)
            {
                MessageBox.Show("费用类型不能为空！");
                return false;
            }

            GridRow gr = (GridRow)superGridControlChaiXei.PrimaryGrid.Rows[0];
            if (gr.Cells["gridColumnStock"].Value == null || gr.Cells["gridColumnStock"].Value.ToString() == "")
            {
                MessageBox.Show("仓库1不能为空！");
                return false;
            }
            if (gr.Cells["material"].Value == null || gr.Cells["material"].Value.ToString() == "")
            {
                MessageBox.Show("商品代码1不能为空！");
                return false;
            }

            GridRow grs = (GridRow)superGridControlShangPing.PrimaryGrid.Rows[1];
            if (grs.Cells["gridColumnStockIn"].Value == null || grs.Cells["gridColumnStockIn"].Value.ToString() == "")
            {
                MessageBox.Show("仓库2不能为空！");
                return false;
            }
            if (grs.Cells["sup1material"].Value == null || grs.Cells["sup1material"].Value.ToString() == "")
            {
                MessageBox.Show("商品代码2不能为空！");
                return false;
            }

            if (ltxtbSalsMan.Text.Trim() == null || ltxtbSalsMan.Text == "")
            {
                MessageBox.Show("组装员不能为空！");
                return false;
            }
            return true;
        }

        /// <summary>
        /// 标识那个控件不可用
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
            
            this.superGridControlShangPing.PrimaryGrid.ReadOnly = true;;
            this.superGridControlChaiXei.PrimaryGrid.ReadOnly = true;
            this.toolStripBtnSave.Enabled = false;
            pictureBoxshenghe.Parent = pictureBoxtitle;
            pictureBoxshenghe.Image = Properties.Resources.审核;
            pictureBoxshenghe.Visible = true;
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
                MessageBox.Show("初始化仓库出错！请检查：" + ex.Message);
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

        #endregion

        private void WareHouseDisassemblyForm_Load(object sender, EventArgs e)
        {
            try
            {
                //业务员
               _AllEmployee = employee.SelSupplierTable(false);
                //仓库
               _AllStorage = storage.GetList(00, "");
                superGridControlShangPing.PrimaryGrid.SortCycle = SortCycle.AscDesc;    //排序方式范围
                superGridControlShangPing.PrimaryGrid.AddSort(superGridControlShangPing.PrimaryGrid.Columns[0], SortDirection.Ascending);//设置排序列和排序方式
                cbotype.SelectedIndex = 0;
                //禁用自动创建列
                dataGridViewShangPing.AutoGenerateColumns = false;
                dataGridViewFuJia.AutoGenerateColumns = false;
                this.superGridControlShangPing.PrimaryGrid.AutoGenerateColumns = false;
                this.superGridControlChaiXei.PrimaryGrid.AutoGenerateColumns = false;
                superGridControlShangPing.HScrollBarVisible = true;
                // 内容居中显示
                dataGridViewFuJia.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dataGridViewShangPing.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                //显示行号
                superGridControlShangPing.PrimaryGrid.ShowRowGridIndex = true;
                //内容居中
                superGridControlShangPing.DefaultVisualStyles.CellStyles.Default.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleCenter;
                superGridControlChaiXei.DefaultVisualStyles.CellStyles.Default.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleCenter;


                //绑定事件 双击事填充内容并隐藏列表
                dataGridViewFuJia.CellDoubleClick += dataGridViewFuJia_CellDoubleClick;
                dataGridViewShangPing.CellDoubleClick += dataGridViewShangPing_CellDoubleClick;
                dataGridViewFuJia.KeyDown += DataGridViewFuJia_KeyDown;
                dataGridViewShangPing.KeyDown += DataGridViewShangPing_KeyDown;
                //调用表格初始化
                superGridControlShangPing.PrimaryGrid.EnsureVisible();
                InitDataGridView();
                toolStripBtnSave.Click += toolStripBtnSave_Click;//保存
                toolStripBtnShengHe.Click += toolStripBtnShengHe_Click;//审核

                //生成code 和显示条形码
                _WareHouseDisassemblyCode = BuildCode.ModuleCode("WHD");
                textBoxOddNumbers.Text = _WareHouseDisassemblyCode;
                barcodeXYE.Code128 _Code = new barcodeXYE.Code128();
                _Code.ValueFont = new Font("微软雅黑", 20);
                System.Drawing.Bitmap imgTemp = _Code.GetCodeImage(textBoxOddNumbers.Text, barcodeXYE.Code128.Encode.Code128A);
                pictureBox9.Image = imgTemp;
            }
            catch (Exception ex)
            {
                MessageBox.Show("错误代码：2901-窗体初始化数据错误！请检查：" + ex.Message, "拆卸单温馨提示");
                this.Close();
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
                Review();
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

        #region 两个副框的双击事件和下拉箭头的点击事件

        private void dataGridViewShangPing_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
            {
                return;
            }
            dataGridViewShangPingTableClick();
        }

        private void dataGridViewFuJia_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
            {
                return;
            }
            dataGridViewFuJiTableClick();
        }

        private void pictureBoxEmployee_Click(object sender, EventArgs e)
        {
            InitEmployee();
            _Click = 3;
        }

        #endregion

        protected  void superGridControlShangPing_BeginEdit(object sender, GridEditEventArgs e)
        {
            try
            {
                if (e.GridCell.GridColumn.Name == "gridColumnStockIn")
                {
                    ClickRowIndex = e.GridCell.RowIndex;
                    ClickStorage = true;
                    resizablePanel1.Visible = true;
                    resizablePanel1.Size = new Size(190, 120);
                    resizablePanel1.Location = new Point(38, 350);
                    InitStorageList();
                    _WareHouse = 1;
                    return;
                }
                if (e.GridCell.GridColumn.Name == "sup1material")
                {
                    if (_StorageCode != "")
                    {
                        ClickRowIndex = e.GridCell.RowIndex;
                        resizablePanelData.Visible = true;
                        resizablePanelData.Location = new Point(156, 350);
                        //查询商品列表
                        _AllMaterial = waremain.GetWMainAndMaterialByWMCode(999, "", XYEEncoding.strCodeHex(_StorageCode));
                        InitMaterialDataGridView();
                        _Material = 1;
                    }
                    else
                    {
                        resizablePanelData.Visible = false;
                        MessageBox.Show("请先选择仓库：");
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

        private void superGridControlChaiXei_BeginEdit(object sender, GridEditEventArgs e)
        {
            try
            {
                if (e.GridCell.GridColumn.Name == "gridColumnStock")
                {
                    ClickRowIndex = e.GridCell.RowIndex;
                    ClickStorage = true;
                    resizablePanel1.Visible = true;
                    resizablePanel1.Size = new Size(190, 120);
                    resizablePanel1.Location = new Point(e.GridCell.UnMergedBounds.X,
                        e.GridCell.UnMergedBounds.Bottom + panel3.Location.Y);
                    InitStorageList();
                    _WareHouse = 2;
                    return;
                }
                if (e.GridCell.GridColumn.Name == "material")
                {
                    if (_StorageCode != "")
                    {
                        ClickRowIndex = e.GridCell.RowIndex;
                        resizablePanelData.Visible = true;
                        resizablePanelData.Location = new Point(e.GridCell.UnMergedBounds.X,
                            e.GridCell.UnMergedBounds.Bottom + panel3.Location.Y);
                        //查询商品列表
                        _AllMaterial = waremain.GetWMainAndMaterialByWMCode(999, "", XYEEncoding.strCodeHex(_StorageCode));
                        InitMaterialDataGridView();
                        _Material = 2;
                    }
                    else
                    {
                        resizablePanelData.Visible = false;
                        MessageBox.Show("请先选择仓库：");
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
        /// 验证只能输入数字和小数点
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ltxtChaiXieCost_KeyPress(object sender, KeyPressEventArgs e)
        {
            //判断按键是不是要输入的类型。
            if (((int)e.KeyChar < 48 || (int)e.KeyChar > 57) && (int)e.KeyChar != 8 && (int)e.KeyChar != 46)
                e.Handled = true;
            //小数点的处理。
            if ((int)e.KeyChar == 46)//小数点
            {
                if (labtextboxTop6.Text.Length <= 0)
                    e.Handled = true;   //小数点不能在第一位
                else
                {
                    float f;
                    float oldf;
                    bool b1 = false, b2 = false;
                    b1 = float.TryParse(labtextboxTop6.Text, out oldf);
                    b2 = float.TryParse(labtextboxTop6.Text + e.KeyChar.ToString(), out f);
                    if (b2 == false)
                    {
                        if (b1 == true)
                            e.Handled = true;
                        else
                            e.Handled = false;
                    }
                }
            }
        }

        /// <summary>
        /// 按下ESC关闭子窗体
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void WareHouseDisassemblyForm_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Escape)
            {
                this.resizablePanel1.Visible = false;
                this.resizablePanelData.Visible = false;
            }
        }

        #region 修改Panel的边框颜色
        /// <summary>
        /// 修改Panel的边框颜色
        /// </summary>
        /// <param name = "sender" ></ param >
        /// < param name="e"></param>
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
        /// 拆卸员模糊查询
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
                MessageBox.Show("错误代码：2908-模糊查询拆卸员数据错误" + ex.Message, "拆卸单温馨提示");
            }


        }

        #region  表格模糊查询
        private void superGridControlChaiXei_EditorValueChanged(object sender, GridEditEventArgs e)
        {
            try
            {
                string SS = "";
                GridRow gr = (GridRow)superGridControlChaiXei.PrimaryGrid.Rows[ClickRowIndex];
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
                MessageBox.Show("错误代码:2909-表格商品模糊查询错误，查询数据错误" + ex.Message, "拆卸单温馨提示");
            }
        }

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
                MessageBox.Show("错误代码:2910-表格商品拆卸明细模糊查询错误，查询数据错误" + ex.Message, "拆卸单温馨提示");
            }
        }



        #endregion

        private void superGridControlShangPing_CellValidated(object sender, GridCellValidatedEventArgs e)
        {
            GridRow gr = e.GridPanel.Rows[e.GridCell.RowIndex] as GridRow;
            //计算金额及统计数量
            try
            {
                decimal tempAllnumber = 0;
                //数量
                decimal number = Convert.ToDecimal(gr.Cells["number"].FormattedValue);
                //单价
                decimal Price = Convert.ToDecimal(gr.Cells["price"].FormattedValue);
                //金额
                decimal money = number * Price;
                gr.Cells["money"].Value = money;

                //逐行统计数据总数
                for (int i = 0; i < superGridControlShangPing.PrimaryGrid.Rows.Count - 1; i++)
                {
                    GridRow tempGR = superGridControlShangPing.PrimaryGrid.Rows[i] as GridRow;
                    tempAllnumber += Convert.ToDecimal(tempGR["number"].FormattedValue);
                }
                _MaterialNumber = tempAllnumber;
                gr = (GridRow)superGridControlShangPing.PrimaryGrid.LastSelectableRow;
                gr["number"].Value = _MaterialNumber.ToString();

            }
            catch (Exception ex)
            {
                MessageBox.Show("错误代码：2911-统计数量错误！请检查：" + ex.Message);
            }
        }

        private void WareHouseDisassemblyForm_Activated(object sender, EventArgs e)
        {
            superGridControlChaiXei.Focus();
        }

        private void superGridControlShangPing_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                panel2.Focus();
            }
        }

        /// <summary>
        /// 验证单号是否重复
        /// </summary>
        /// <returns></returns>
        private string validateCode()
        {
            //验证单号
            if (warehouseDisassemblyinterface.Exists(XYEEncoding.strCodeHex(_WareHouseDisassemblyCode)))
            {
                _WareHouseDisassemblyCode = BuildCode.ModuleCode("WAP");
            }
            else
            {
                _WareHouseDisassemblyCode = textBoxOddNumbers.Text;
            }

            return _WareHouseDisassemblyCode;
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
            //WarehouseDisassemblyInterface warehouseDisassemblyinterface = new WarehouseDisassemblyInterface();
            //拆卸单
            WarehouseDisassembly warehousedisassembly = new WarehouseDisassembly();
            //拆卸单商品列表
            List<WarehouseDisassemblyDetail> warehousedisassemblydetailList = new List<WarehouseDisassemblyDetail>();
            try
            {
                warehousedisassembly.code = XYEEncoding.strCodeHex(validateCode());//单据code
                warehousedisassembly.date = dateTimePicker1.Value;//单据日期
                warehousedisassembly.type = cbotype.Text == "" ? "" : XYEEncoding.strCodeHex(cbotype.Text);//费用类型
                warehousedisassembly.disAssemblyCost = Convert.ToDecimal(labtextboxTop6.Text == "" ? "" : labtextboxTop6.Text);//拆卸费用
                warehousedisassembly.Abstract = labtextboxTop2.Text == "" ? "" : XYEEncoding.strCodeHex(labtextboxTop9.Text);//摘要
                warehousedisassembly.operation = ltxtbSalsMan.Text == "" ? "" : XYEEncoding.strCodeHex(ltxtbSalsMan.Text);//拆卸员
                warehousedisassembly.makeMan = ltxtbMakeMan.Text == "" ? "" : XYEEncoding.strCodeHex(ltxtbMakeMan.Text);//制单人
                warehousedisassembly.examine = ltxtbShengHeMan.Text == "" ? "" : XYEEncoding.strCodeHex(ltxtbShengHeMan.Text);//审核人
                warehousedisassembly.checkState = 0;//审核状态
                warehousedisassembly.isClear = 1;
                warehousedisassembly.updatetime = DateTime.Now;
                warehousedisassembly.reserved1 = "";
                warehousedisassembly.reserved2 = "";
                GridRow gr = (GridRow)superGridControlChaiXei.PrimaryGrid.Rows[0];
                warehousedisassembly.materialCode = gr.Cells["gridColumncode"].Value == null ? "" : XYEEncoding.strCodeHex(gr.Cells["gridColumncode"].Value.ToString());//商品code
                warehousedisassembly.materialDaima = gr.Cells["material"].Value == null ? "" : XYEEncoding.strCodeHex(gr.Cells["material"].Value.ToString());//商品代码
                warehousedisassembly.barCode = gr.Cells["gridColumnbarcode"].Value == null ? "" : XYEEncoding.strCodeHex(gr.Cells["gridColumnbarcode"].Value.ToString());//条形码
                warehousedisassembly.materialName = gr.Cells["gridColumnname"].Value == null ? "" : XYEEncoding.strCodeHex(gr.Cells["gridColumnname"].Value.ToString());//商品名称
                warehousedisassembly.materialMode = gr.Cells["gridColumnmodel"].Value == null ? "" : XYEEncoding.strCodeHex(gr.Cells["gridColumnmodel"].Value.ToString());//规格型号
                warehousedisassembly.materialUnit = gr.Cells["gridColumnunit"].Value == null ? "" : XYEEncoding.strCodeHex(gr.Cells["gridColumnunit"].Value.ToString());//单位
                warehousedisassembly.stockCode = gr.Cells["gridColumnstockCode"].Value == null ? "" : XYEEncoding.strCodeHex(gr.Cells["gridColumnstockCode"].Value.ToString());//仓库code
                warehousedisassembly.stockName = gr.Cells["gridColumnStock"].Value == null ? "" : XYEEncoding.strCodeHex(gr.Cells["gridColumnStock"].Value.ToString());//仓库名称
                warehousedisassembly.number = Convert.ToDecimal(gr.Cells["gridColumnnumber"].Value == null ? 0 : gr.Cells["gridColumnnumber"].Value);//数量
                warehousedisassembly.materialremark = gr.Cells["gridColumnremark"].Value == null ? "" : XYEEncoding.strCodeHex(gr.Cells["gridColumnremark"].Value.ToString());//备注

            }
            catch (Exception ex)
            {
                MessageBox.Show("错误代码:2904-尝试创建拆卸单商品数据出错,请检查输入" + ex.Message, "拆卸单温馨提示");
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
                        WarehouseDisassemblyDetail warehosuedisassemblydetail = new WarehouseDisassemblyDetail();
                        warehosuedisassemblydetail.mainCode = XYEEncoding.strCodeHex(textBoxOddNumbers.Text);
                        warehosuedisassemblydetail.materialCode = gr.Cells["code"].Value == null ? "" : XYEEncoding.strCodeHex(gr.Cells["code"].Value.ToString());//商品code
                        warehosuedisassemblydetail.materialDaima = gr.Cells["sup1material"].Value == null ? "" : XYEEncoding.strCodeHex(gr.Cells["sup1material"].Value.ToString());//商品代码
                        warehosuedisassemblydetail.barCode = gr.Cells["barcode"].Value == null ? "" : XYEEncoding.strCodeHex(gr.Cells["barcode"].Value.ToString());//条形码
                        warehosuedisassemblydetail.materialName = gr.Cells["name"].Value == null ? "" : XYEEncoding.strCodeHex(gr.Cells["name"].Value.ToString());//商品名称
                        warehosuedisassemblydetail.materialMode = gr.Cells["model"].Value == null ? "" : XYEEncoding.strCodeHex(gr.Cells["model"].Value.ToString());//规格型号
                        warehosuedisassemblydetail.materialUnit = gr.Cells["unit"].Value == null ? "" : XYEEncoding.strCodeHex(gr.Cells["unit"].Value.ToString());//单位
                        warehosuedisassemblydetail.stockCode = gr.Cells["stockInCode"].Value == null ? "" : XYEEncoding.strCodeHex(gr.Cells["stockInCode"].Value.ToString());//仓库code
                        warehosuedisassemblydetail.stockName = gr.Cells["gridColumnStockIn"].Value == null ? "" : XYEEncoding.strCodeHex(gr.Cells["gridColumnStockIn"].Value.ToString());//仓库名称
                        warehosuedisassemblydetail.number = Convert.ToDecimal(gr.Cells["number"].Value == null ? 0 : gr.Cells["number"].Value);//数量
                        warehosuedisassemblydetail.price = Convert.ToDecimal(gr.Cells["price"].Value == null ? 0 : gr.Cells["price"].Value);//单价
                        warehosuedisassemblydetail.money = Convert.ToDecimal(gr.Cells["money"].Value == null ? 0 : gr.Cells["money"].Value);//金额
                        warehosuedisassemblydetail.remark = gr.Cells["remark"].Value == null ? "" : XYEEncoding.strCodeHex(gr.Cells["remark"].Value.ToString());//备注
                        warehosuedisassemblydetail.isClear = 1;
                        warehosuedisassemblydetail.updatetime = DateTime.Now;
                        warehosuedisassemblydetail.reserved1 = "";
                        warehosuedisassemblydetail.reserved2 = "";
                        GridRow dr = superGridControlShangPing.PrimaryGrid.Rows[0] as GridRow;
                        warehousedisassemblydetailList.Add(warehosuedisassemblydetail);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("错误代码：2905-尝试创建拆卸单详情商品数据出错,请检查输入" + ex.Message, "拆卸单温馨提示");
                return;
            }

            //增加一条拆卸单和拆卸详细数据
            object warehouseDisAssemblyResult = warehouseDisassemblyinterface.AddAndModify(warehousedisassembly, warehousedisassemblydetailList);
            if (warehouseDisAssemblyResult != null)
            {
                MessageBox.Show("新增拆卸单数据成功", "拆卸单温馨提示");
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
           // WarehouseDisassemblyInterface warehouseDisassemblyinterface = new WarehouseDisassemblyInterface();
            //拆卸单
            WarehouseDisassembly warehousedisassembly = new WarehouseDisassembly();
            //拆卸单商品列表
            List<WarehouseDisassemblyDetail> warehousedisassemblydetailList = new List<WarehouseDisassemblyDetail>();
            try
            {
                warehousedisassembly.code = textBoxOddNumbers.Text == "" ? "" : XYEEncoding.strCodeHex(textBoxOddNumbers.Text);//单据code
                warehousedisassembly.date = dateTimePicker1.Value;//单据日期
                warehousedisassembly.type = cbotype.Text == "" ? "" : XYEEncoding.strCodeHex(cbotype.Text);//费用类型
                warehousedisassembly.disAssemblyCost = Convert.ToDecimal(labtextboxTop6.Text == "" ? "" : labtextboxTop6.Text);//拆卸费用
                warehousedisassembly.Abstract = labtextboxTop2.Text == "" ? "" : XYEEncoding.strCodeHex(labtextboxTop9.Text);//摘要
                warehousedisassembly.operation = ltxtbSalsMan.Text == "" ? "" : XYEEncoding.strCodeHex(ltxtbSalsMan.Text);//拆卸员
                warehousedisassembly.makeMan = ltxtbMakeMan.Text == "" ? "" : XYEEncoding.strCodeHex(ltxtbMakeMan.Text);//制单人
                warehousedisassembly.examine = ltxtbShengHeMan.Text == "" ? "" : XYEEncoding.strCodeHex(ltxtbShengHeMan.Text);//审核人
                warehousedisassembly.checkState = 1;//审核状态
                warehousedisassembly.isClear = 1;
                warehousedisassembly.updatetime = DateTime.Now;
                warehousedisassembly.reserved1 = "";
                warehousedisassembly.reserved2 = "";
                GridRow gr = (GridRow)superGridControlChaiXei.PrimaryGrid.Rows[0];
                warehousedisassembly.materialCode = gr.Cells["gridColumncode"].Value == null ? "" : XYEEncoding.strCodeHex(gr.Cells["gridColumncode"].Value.ToString());//商品code
                warehousedisassembly.materialDaima = gr.Cells["material"].Value == null ? "" : XYEEncoding.strCodeHex(gr.Cells["material"].Value.ToString());//商品代码
                warehousedisassembly.barCode = gr.Cells["gridColumnbarcode"].Value == null ? "" : XYEEncoding.strCodeHex(gr.Cells["gridColumnbarcode"].Value.ToString());//条形码
                warehousedisassembly.materialName = gr.Cells["gridColumnname"].Value == null ? "" : XYEEncoding.strCodeHex(gr.Cells["gridColumnname"].Value.ToString());//商品名称
                warehousedisassembly.materialMode = gr.Cells["gridColumnmodel"].Value == null ? "" : XYEEncoding.strCodeHex(gr.Cells["gridColumnmodel"].Value.ToString());//规格型号
                warehousedisassembly.materialUnit = gr.Cells["gridColumnunit"].Value == null ? "" : XYEEncoding.strCodeHex(gr.Cells["gridColumnunit"].Value.ToString());//单位
                warehousedisassembly.stockCode = gr.Cells["gridColumnstockCode"].Value == null ? "" : XYEEncoding.strCodeHex(gr.Cells["gridColumnstockCode"].Value.ToString());//仓库code
                warehousedisassembly.stockName = gr.Cells["gridColumnStock"].Value == null ? "" : XYEEncoding.strCodeHex(gr.Cells["gridColumnStock"].Value.ToString());//仓库名称
                warehousedisassembly.number = Convert.ToDecimal(gr.Cells["gridColumnnumber"].Value == null ? 0 : gr.Cells["gridColumnnumber"].Value);//数量
                warehousedisassembly.materialremark = gr.Cells["gridColumnremark"].Value == null ? "" : XYEEncoding.strCodeHex(gr.Cells["gridColumnremark"].Value.ToString());//备注

            }
            catch (Exception ex)
            {
                MessageBox.Show("错误代码:2902-尝试创建和审核拆卸单商品数据出错,请检查输入" + ex.Message, "拆卸单温馨提示");
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
                        WarehouseDisassemblyDetail warehosuedisassemblydetail = new WarehouseDisassemblyDetail();
                        warehosuedisassemblydetail.mainCode = XYEEncoding.strCodeHex(textBoxOddNumbers.Text);
                        warehosuedisassemblydetail.materialCode = gr.Cells["code"].Value == null ? "" : XYEEncoding.strCodeHex(gr.Cells["code"].Value.ToString());//商品code
                        warehosuedisassemblydetail.materialDaima = gr.Cells["sup1material"].Value == null ? "" : XYEEncoding.strCodeHex(gr.Cells["sup1material"].Value.ToString());//商品代码
                        warehosuedisassemblydetail.barCode = gr.Cells["barcode"].Value == null ? "" : XYEEncoding.strCodeHex(gr.Cells["barcode"].Value.ToString());//条形码
                        warehosuedisassemblydetail.materialName = gr.Cells["name"].Value == null ? "" : XYEEncoding.strCodeHex(gr.Cells["name"].Value.ToString());//商品名称
                        warehosuedisassemblydetail.materialMode = gr.Cells["model"].Value == null ? "" : XYEEncoding.strCodeHex(gr.Cells["model"].Value.ToString());//规格型号
                        warehosuedisassemblydetail.materialUnit = gr.Cells["unit"].Value == null ? "" : XYEEncoding.strCodeHex(gr.Cells["unit"].Value.ToString());//单位
                        warehosuedisassemblydetail.stockCode = gr.Cells["stockInCode"].Value == null ? "" : XYEEncoding.strCodeHex(gr.Cells["stockInCode"].Value.ToString());//仓库code
                        warehosuedisassemblydetail.stockName = gr.Cells["gridColumnStockIn"].Value == null ? "" : XYEEncoding.strCodeHex(gr.Cells["gridColumnStockIn"].Value.ToString());//仓库名称
                        warehosuedisassemblydetail.number = Convert.ToDecimal(gr.Cells["number"].Value == null ? 0 : gr.Cells["number"].Value);//数量
                        warehosuedisassemblydetail.price = Convert.ToDecimal(gr.Cells["price"].Value == null ? 0 : gr.Cells["price"].Value);//单价
                        warehosuedisassemblydetail.money = Convert.ToDecimal(gr.Cells["money"].Value == null ? 0 : gr.Cells["money"].Value);//金额
                        warehosuedisassemblydetail.remark = gr.Cells["remark"].Value == null ? "" : XYEEncoding.strCodeHex(gr.Cells["remark"].Value.ToString());//备注
                        warehosuedisassemblydetail.isClear = 1;
                        warehosuedisassemblydetail.updatetime = DateTime.Now;
                        warehosuedisassemblydetail.reserved1 = "";
                        warehosuedisassemblydetail.reserved2 = "";
                        GridRow dr = superGridControlShangPing.PrimaryGrid.Rows[0] as GridRow;
                        warehousedisassemblydetailList.Add(warehosuedisassemblydetail);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("错误代码：2903-尝试创建审核拆卸单详情商品数据出错,请检查输入" + ex.Message, "拆卸单温馨提示");
                return;
            }

            //增加一条拆卸单和拆卸详细数据
            object warehouseDisAssemblyResult = warehouseDisassemblyinterface.AddAndModify(warehousedisassembly, warehousedisassemblydetailList);
            if (warehouseDisAssemblyResult != null)
            {
                MessageBox.Show("新增并审核拆卸单数据成功", "拆卸单温馨提示");
                InitForm();
            }
        }

        /// <summary>
        /// dataGridViewFuJia的点击事件函数
        /// </summary>
        private void dataGridViewFuJiTableClick()
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
                    if (_WareHouse == 2)
                    {
                        GridRow gr = (GridRow)superGridControlChaiXei.PrimaryGrid.Rows[ClickRowIndex];
                        string code = dataGridViewFuJia.Rows[dataGridViewFuJia.CurrentRow.Index].Cells["code"].Value.ToString();
                        string Name = dataGridViewFuJia.Rows[dataGridViewFuJia.CurrentRow.Index].Cells["name"].Value.ToString();
                        gr.Cells["gridColumnstockCode"].Value = code;
                        gr.Cells["gridColumnStock"].Value = Name;
                        _StorageCode = code;
                        _ClickStorageList = new KeyValuePair<string, string>(code, Name);
                        //_StorageCode = code;
                        resizablePanel1.Visible = false;
                    }
                    if (_WareHouse == 1)
                    {
                        GridRow gr = (GridRow)superGridControlShangPing.PrimaryGrid.Rows[ClickRowIndex];
                        string code = dataGridViewFuJia.Rows[dataGridViewFuJia.CurrentRow.Index].Cells["code"].Value.ToString();
                        string Name = dataGridViewFuJia.Rows[dataGridViewFuJia.CurrentRow.Index].Cells["name"].Value.ToString();
                        gr.Cells["stockInCode"].Value = code;
                        gr.Cells["gridColumnStockIn"].Value = Name;
                        _ClickStorageList = new KeyValuePair<string, string>(code, Name);
                        _StorageCode = code;
                        resizablePanel1.Visible = false;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("错误代码：2907-双击绑定拆卸员或仓库信息数据错误！请检查：" + ex.Message);
            }
        }

        /// <summary>
        /// dataGridViewShangPing的点击事件函数
        /// </summary>
        private void dataGridViewShangPingTableClick()
        {
            try
            {
                if (_Material == 2)
                {
                    GridRow grs = (GridRow)superGridControlChaiXei.PrimaryGrid.Rows[ClickRowIndex];
                    grs.Cells["gridColumncode"].Value = dataGridViewShangPing.Rows[dataGridViewShangPing.CurrentRow.Index].Cells["code"].Value;//商品code
                    grs.Cells["material"].Value = dataGridViewShangPing.Rows[dataGridViewShangPing.CurrentRow.Index].Cells["materialDaima"].Value;//商品代码
                    grs.Cells["gridColumnname"].Value = dataGridViewShangPing.Rows[dataGridViewShangPing.CurrentRow.Index].Cells["name"].Value;//商品名称
                    grs.Cells["gridColumnmodel"].Value = dataGridViewShangPing.Rows[dataGridViewShangPing.CurrentRow.Index].Cells["model"].Value;//规格型号
                    grs.Cells["gridColumnbarcode"].Value = dataGridViewShangPing.Rows[dataGridViewShangPing.CurrentRow.Index].Cells["barCode"].Value;//条码
                    grs.Cells["gridColumnunit"].Value = dataGridViewShangPing.Rows[dataGridViewShangPing.CurrentRow.Index].Cells["unit"].Value;//单位
                    grs.Cells["gridColumnnumber"].Value = dataGridViewShangPing.Rows[dataGridViewShangPing.CurrentRow.Index].Cells["currentNumber"].Value;//商品数量
                    grs.Cells["gridColumnremark"].Value = dataGridViewShangPing.Rows[dataGridViewShangPing.CurrentRow.Index].Cells["remark"].Value;//备注  
                    resizablePanelData.Visible = false;
                }
                if (_Material == 1)
                {
                    ////是否要新增一行的标记
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
                        if (g.Cells["code"].Value == null)
                        {
                            newAdd = true;
                            continue;
                        }
                        if (g.Cells["code"].Value.Equals(dataGridViewShangPing.Rows[dataGridViewShangPing.CurrentRow.Index].Cells["code"].Value))
                        {
                            decimal shuliang = Convert.ToDecimal(g.Cells["number"].Value);
                            decimal needNumber = Convert.ToDecimal(dataGridViewShangPing.Rows[dataGridViewShangPing.CurrentRow.Index].Cells["currentNumber"].Value);
                            shuliang += needNumber;
                            g.Cells["number"].Value = shuliang;
                            //逐行统计数据总数
                            decimal tempAllNumber = 0;
                            for (int i = 0; i < superGridControlShangPing.PrimaryGrid.Rows.Count - 1; i++)
                            {
                                GridRow tempGR = superGridControlShangPing.PrimaryGrid.Rows[i] as GridRow;
                                tempAllNumber += Convert.ToDecimal(tempGR["number"].FormattedValue);
                            }
                            _MaterialNumber = tempAllNumber;
                            gr = (GridRow)superGridControlShangPing.PrimaryGrid.LastSelectableRow;
                            gr["number"].Value = _MaterialNumber.ToString();
                            resizablePanelData.Visible = false;
                            return;
                        }
                        continue;
                    }
                    gr.Cells["code"].Value = dataGridViewShangPing.Rows[dataGridViewShangPing.CurrentRow.Index].Cells["code"].Value;//商品code
                    gr.Cells["sup1material"].Value = dataGridViewShangPing.Rows[dataGridViewShangPing.CurrentRow.Index].Cells["materialDaima"].Value;//商品代码
                    gr.Cells["name"].Value = dataGridViewShangPing.Rows[dataGridViewShangPing.CurrentRow.Index].Cells["name"].Value;//商品名称
                    gr.Cells["model"].Value = dataGridViewShangPing.Rows[dataGridViewShangPing.CurrentRow.Index].Cells["model"].Value;//规格型号
                    gr.Cells["barcode"].Value = dataGridViewShangPing.Rows[dataGridViewShangPing.CurrentRow.Index].Cells["barCode"].Value;//条码
                    gr.Cells["unit"].Value = dataGridViewShangPing.Rows[dataGridViewShangPing.CurrentRow.Index].Cells["unit"].Value;//单位
                    gr.Cells["number"].Value = dataGridViewShangPing.Rows[dataGridViewShangPing.CurrentRow.Index].Cells["currentNumber"].Value;//商品数量
                    gr.Cells["price"].Value = dataGridViewShangPing.Rows[dataGridViewShangPing.CurrentRow.Index].Cells["price"].Value;//单价
                    decimal number = Convert.ToDecimal(dataGridViewShangPing.Rows[dataGridViewShangPing.CurrentRow.Index].Cells["currentNumber"].Value);
                    decimal price = Convert.ToDecimal(dataGridViewShangPing.Rows[dataGridViewShangPing.CurrentRow.Index].Cells["price"].Value);
                    decimal money = number * price;
                    gr.Cells["money"].Value = money;
                    gr.Cells["remark"].Value = dataGridViewShangPing.Rows[dataGridViewShangPing.CurrentRow.Index].Cells["remark"].Value;//备注       

                    _number = Convert.ToDecimal(dataGridViewShangPing.Rows[dataGridViewShangPing.CurrentRow.Index].Cells["currentNumber"].Value);
                    //当上一次有选择仓库时 默认本次也为上次选择仓库
                    if (!string.IsNullOrEmpty(_ClickStorageList.Value) && !string.IsNullOrEmpty(_ClickStorageList.Key))
                    {
                        gr.Cells["stockInCode"].Value = _ClickStorageList.Key;
                        gr.Cells["gridColumnStockIn"].Value = _ClickStorageList.Value;
                    }
                    //新增一行 
                    if (newAdd)
                    {
                        superGridControlShangPing.PrimaryGrid.NewRow(superGridControlShangPing.PrimaryGrid.Rows.Count);
                        //递增数量 默认为1 
                        gr = (GridRow)superGridControlShangPing.PrimaryGrid.LastSelectableRow;
                        _MaterialNumber += _number;
                        gr.Cells["number"].Value = _MaterialNumber;
                    }
                    superGridControlShangPing.Focus();
                    SendKeys.Send("^{End}{Home}");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("错误代码：2906-双击绑定物料信息数据错误！请检查：" + ex.Message);
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
                dataGridViewFuJiTableClick();
            }
        }
        private void DataGridViewShangPing_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                dataGridViewShangPingTableClick();
            }
        }

        /// <summary>
        /// 快捷方式设置
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void WareHouseDisassemblyForm_KeyDown(object sender, KeyEventArgs e)
        {
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
