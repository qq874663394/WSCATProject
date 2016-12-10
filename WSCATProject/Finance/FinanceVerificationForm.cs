using DevComponents.DotNetBar.SuperGrid;
using HelperUtility;
using HelperUtility.Encrypt;
using InterfaceLayer.Base;
using InterfaceLayer.Finance;
using Model.Finance;
using InterfaceLayer.Purchase;
using InterfaceLayer.Sales;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace WSCATProject.Finance
{
    public partial class FinanceVerificationForm : TestForm
    {
        public FinanceVerificationForm()
        {
            InitializeComponent();
        }

        #region 调用接口以及加密解密方法
        CodingHelper ch = new CodingHelper();
        ClientInterface client = new ClientInterface();//客户
        SupplierInterface supplier = new SupplierInterface();//供应商
        EmpolyeeInterface employee = new EmpolyeeInterface();//员工
        FinanceVerificationMainInterface financeVerificationInterface = new FinanceVerificationMainInterface();
        #endregion

        #region 数据字段

        /// <summary>
        /// 所有客户
        /// </summary>
        private DataTable _AllClient = null;
        /// <summary>
        /// 所有供应商
        /// </summary>
        private DataTable _AllSupplier = null;
        /// <summary>
        /// 所有核销员
        /// </summary>
        private DataTable _AllEmployee = null;
        /// <summary>
        /// 点击的项,1客户  2为供应商  3为核销员
        /// </summary>
        private int _Click = 0;
        /// <summary>
        /// 保存客户Code
        /// </summary>
        private string _clientCode;
        /// <summary>
        /// 保存转入客户code
        /// </summary>
        private string _clientCodeIn;
        /// <summary>
        /// 保存供应商code
        /// </summary>
        private string _supplierCode;
        /// <summary>
        /// 保存转入供应商code
        /// </summary>
        private string _supplierCodeIn;
        /// <summary>
        /// 保存核销员Code
        /// </summary>
        private string _employeeCode;
        /// <summary>
        /// 核销单code
        /// </summary>
        private string _financeVerificationCode;
        /// <summary>
        /// 统计上表格单据金额
        /// </summary>
        private decimal _danJuMoneyTop;
        /// <summary>
        /// 统计上表格已核销金额
        /// </summary>
        private decimal _yiHeXiaoMoneyTop;
        /// <summary>
        /// 统计上表格未核销金额
        /// </summary>
        private decimal _weiHeXiaoMoneyTop;
        /// <summary>
        /// 统计上表格本次核销金额
        /// </summary>
        private decimal _benCiHeXiaoMoneyTop;
        /// <summary>
        /// 统计下表格单据金额
        /// </summary>
        private decimal _danJuMoneyBottom;
        /// <summary>
        /// 统计下表格已核销金额
        /// </summary>
        private decimal _yiHeXiaoMoneyBottom;
        /// <summary>
        /// 统计下表格未核销金额
        /// </summary>
        private decimal _weiHeXiaoMoneyBottom;
        /// <summary>
        /// 统计下表格本次核销金额
        /// </summary>
        private decimal _benCiHeXiaoMoneyBottom;
        /// <summary>
        /// 付款单的单据code
        /// </summary>
        private string _fuKuanCode;

        /// <summary>
        /// 收款code
        /// </summary>
        public string FuKuanCode
        {
            get
            {
                return _fuKuanCode;
            }

            set
            {
                _fuKuanCode = value;
            }
        }

        public string ShouKuanCode
        {
            get
            {
                return _shouKuanCode;
            }

            set
            {
                _shouKuanCode = value;
            }
        }

        private string _shouKuanCode;

        /// <summary>
        /// 上面表格的code
        /// </summary>
        private string _mainCode;
        /// <summary>
        /// 客户List
        /// </summary>
        private List<string> _ClientMainList = new List<string>();
        public List<string> ClientMainList
        {
            get
            {
                return _ClientMainList;
            }

            set
            {
                _ClientMainList = value;
            }
        }

        /// <summary>
        /// 供应商List
        /// </summary>
        public List<string> SupplierList
        {
            get
            {
                return _SupplierList;
            }

            set
            {
                _SupplierList = value;
            }
        }

        public List<string> YingFuList
        {
            get
            {
                return _yingFuList;
            }

            set
            {
                _yingFuList = value;
            }
        }

        private List<string> _SupplierList = new List<string>();

        private List<string> _yingFuList = new List<string>();
        #endregion

        #region 初始化数据
        /// <summary>
        /// 统计行数据
        /// </summary>
        private void InitDataGridView()
        {
            #region 上表格统计行
            //新增一行 用于给客户操作
            superGridControlTop.PrimaryGrid.NewRow(true);
            //最后一行做统计行
            GridRow gr = (GridRow)superGridControlTop.PrimaryGrid.
                Rows[superGridControlTop.PrimaryGrid.Rows.Count - 1];
            gr.ReadOnly = true;
            gr.CellStyles.Default.Background.Color1 = Color.SkyBlue;
            gr.Cells["gridColumnSelect"].Value = "合计";
            gr.Cells["gridColumnSelect"].CellStyles.Default.Alignment =
                DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleCenter;
            gr.Cells["gridColumnSelect"].EditorType = typeof(GridTextBoxXEditControl);
            gr.Cells["gridColumnDanJuMoney"].Value = 0;
            gr.Cells["gridColumnDanJuMoney"].CellStyles.Default.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleCenter;
            gr.Cells["gridColumnDanJuMoney"].CellStyles.Default.Background.Color1 = Color.Orange;
            gr.Cells["gridColumnYiHeXiao"].Value = 0;
            gr.Cells["gridColumnYiHeXiao"].CellStyles.Default.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleCenter;
            gr.Cells["gridColumnYiHeXiao"].CellStyles.Default.Background.Color1 = Color.Orange;
            gr.Cells["gridColumnWeiHeXiao"].Value = 0;
            gr.Cells["gridColumnWeiHeXiao"].CellStyles.Default.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleCenter;
            gr.Cells["gridColumnWeiHeXiao"].CellStyles.Default.Background.Color1 = Color.Orange;
            gr.Cells["gridColumnBenCi"].Value = 0;
            gr.Cells["gridColumnBenCi"].CellStyles.Default.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleCenter;
            gr.Cells["gridColumnBenCi"].CellStyles.Default.Background.Color1 = Color.Orange;

            #region 表格最后一行不能点击
            gr.Cells["gridColumnSelect"].AllowSelection = false;
            gr.Cells["gridColumnYuanDanCode"].AllowSelection = false;
            gr.Cells["gridColumnYuanDanDate"].AllowSelection = false;
            gr.Cells["gridColumnYuanDanType"].AllowSelection = false;
            gr.Cells["gridColumnDanJuMoney"].AllowSelection = false;
            gr.Cells["gridColumnYiHeXiao"].AllowSelection = false;
            gr.Cells["gridColumnWeiHeXiao"].AllowSelection = false;
            gr.Cells["gridColumnBenCi"].AllowSelection = false;
            gr.Cells["gridColumnRemark"].AllowSelection = false;
            #endregion

            #endregion

            #region 下表格统计行
            //新增一行 用于给客户操作
            superGridControlShangPing.PrimaryGrid.NewRow(true);
            //最后一行做统计行
            GridRow grs = (GridRow)superGridControlShangPing.PrimaryGrid.
                Rows[superGridControlShangPing.PrimaryGrid.Rows.Count - 1];
            grs.ReadOnly = true;
            grs.CellStyles.Default.Background.Color1 = Color.SkyBlue;
            grs.Cells["select"].Value = "合计";
            grs.Cells["select"].CellStyles.Default.Alignment =
                DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleCenter;
            grs.Cells["select"].EditorType = typeof(GridTextBoxXEditControl);
            grs.Cells["danJuMoney"].Value = 0;
            grs.Cells["danJuMoney"].CellStyles.Default.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleCenter;
            grs.Cells["danJuMoney"].CellStyles.Default.Background.Color1 = Color.Orange;
            grs.Cells["yiHeXiao"].Value = 0;
            grs.Cells["yiHeXiao"].CellStyles.Default.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleCenter;
            grs.Cells["yiHeXiao"].CellStyles.Default.Background.Color1 = Color.Orange;
            grs.Cells["weiHeXiao"].Value = 0;
            grs.Cells["weiHeXiao"].CellStyles.Default.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleCenter;
            grs.Cells["weiHeXiao"].CellStyles.Default.Background.Color1 = Color.Orange;
            grs.Cells["benCiHeXiao"].Value = 0;
            grs.Cells["benCiHeXiao"].CellStyles.Default.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleCenter;
            grs.Cells["benCiHeXiao"].CellStyles.Default.Background.Color1 = Color.Orange;

            #region 表格最后一行不能点击
            grs.Cells["select"].AllowSelection = false;
            grs.Cells["yuanDanCode"].AllowSelection = false;
            grs.Cells["danJuDate"].AllowSelection = false;
            grs.Cells["yuanDanType"].AllowSelection = false;
            grs.Cells["danJuMoney"].AllowSelection = false;
            grs.Cells["yiHeXiao"].AllowSelection = false;
            grs.Cells["weiHeXiao"].AllowSelection = false;
            grs.Cells["benCiHeXiao"].AllowSelection = false;
            grs.Cells["remark"].AllowSelection = false;
            #endregion

            #endregion
        }

        /// <summary>
        /// 非空验证
        /// </summary>
        private bool isNUllValidate()
        {
            #region 根据核销类型进行非空验证
            if (cboHeXiaoType.Text == "预收冲应收")
            {
                if (labtextboxTop2.Text == null || labtextboxTop2.Text.Trim() == "")
                {
                    MessageBox.Show("客户不能为空！");
                    labtextboxTop2.Focus();
                    return false;
                }
            }
            if (cboHeXiaoType.Text == "预付冲应付")
            {
                if (labtextboxTop5.Text == null || labtextboxTop5.Text.Trim() == "")
                {
                    MessageBox.Show("供应商不能为空！");
                    labtextboxTop5.Focus();
                    return false;
                }
            }
            if (cboHeXiaoType.Text == "应收冲应付")
            {
                if (labtextboxTop2.Text == null || labtextboxTop2.Text.Trim() == "")
                {
                    MessageBox.Show("客户不能为空！");
                    labtextboxTop2.Focus();
                    return false;
                }
                if (labtextboxTop5.Text == null || labtextboxTop5.Text.Trim() == "")
                {
                    MessageBox.Show("供应商不能为空！");
                    labtextboxTop5.Focus();
                    return false;
                }
            }
            if (cboHeXiaoType.Text == "应收转应收")
            {
                if (labtextboxTop2.Text == null || labtextboxTop2.Text.Trim() == "")
                {
                    MessageBox.Show("转出客户不能为空！");
                    labtextboxTop2.Focus();
                    return false;
                }
                if (labtextboxTop7.Text == null || labtextboxTop7.Text.Trim() == "")
                {
                    MessageBox.Show("转入客户不能为空！");
                    labtextboxTop7.Focus();
                    return false;
                }
            }
            if (cboHeXiaoType.Text == "应付转应付")
            {
                if (labtextboxTop5.Text == null || labtextboxTop5.Text.Trim() == "")
                {
                    MessageBox.Show("转出供应商不能为空！");
                    labtextboxTop5.Focus();
                    return false;
                }
                if (labtextboxTop4.Text == null || labtextboxTop4.Text.Trim() == "")
                {
                    MessageBox.Show("转入供应商不能为空！");
                    labtextboxTop4.Focus();
                    return false;
                }
            }
            #endregion

            #region 上表格
            GridRow grTop = (GridRow)superGridControlTop.PrimaryGrid.Rows[1];
            double BenCiMoneyTop = Convert.ToDouble(grTop.Cells["gridColumnBenCi"].Value);
            //if (grTop.Cells["gridColumnYuanDanCode"].Value == null)
            //{
            //    MessageBox.Show("单据体上表格里源单不能为空！请选择");
            //    superGridControlTop.Focus();
            //    return false;
            //}
            if (BenCiMoneyTop == 0.00)
            {
                MessageBox.Show("上表格金额不能为0，请检查：");
                superGridControlTop.Focus();
                return false;
            }
            #endregion

            #region  下表格
            GridRow gr = (GridRow)superGridControlShangPing.PrimaryGrid.Rows[1];
            double BenCiMoney = Convert.ToDouble(gr.Cells["benCiHeXiao"].Value);
            //if (gr.Cells["yuanDanCode"].Value == null)
            //{
            //    MessageBox.Show("单据体下表格里源单不能为空！请选择");
            //    superGridControlShangPing.Focus();
            //    return false;
            //}
            if (BenCiMoney == 0.00)
            {
                MessageBox.Show("下表格金额不能为0，请检查：");
                superGridControlShangPing.Focus();
                return false;
            }
            #endregion

            if (ltxtbSalsMan.Text.Trim() == null || ltxtbSalsMan.Text == "")
            {
                MessageBox.Show("核销员不能为空！");
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

                    //resizablePanel1.Location = new Point(550, 160);
                    dataGridViewFuJia.DataSource = ch.DataTableReCoding(_AllClient);
                    resizablePanel1.Visible = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("错误代码：5301-尝试点击客户数据显示失败或者无数据！请检查：" + ex.Message, "核销单单温馨提示！");
            }
        }

        /// <summary>
        /// 初始化供应商
        /// </summary>
        private void InitSupplier()
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
                    dgvc.SortMode = DataGridViewColumnSortMode.NotSortable;
                    dgvc.Visible = false;
                    dataGridViewFuJia.Columns.Add(dgvc);

                    dgvc = new DataGridViewTextBoxColumn();
                    dgvc.Name = "linkMan";
                    dgvc.HeaderText = "联系人";
                    dgvc.DataPropertyName = "联系人";
                    dgvc.SortMode = DataGridViewColumnSortMode.NotSortable;
                    dgvc.Visible = false;
                    dataGridViewFuJia.Columns.Add(dgvc);

                    dgvc = new DataGridViewTextBoxColumn();
                    dgvc.Name = "fax";
                    dgvc.HeaderText = "传真";
                    dgvc.DataPropertyName = "传真";
                    dgvc.SortMode = DataGridViewColumnSortMode.NotSortable;
                    dgvc.Visible = false;
                    dataGridViewFuJia.Columns.Add(dgvc);

                    //resizablePanel1.Location = new Point(230, 160);
                    dataGridViewFuJia.DataSource = ch.DataTableReCoding(_AllSupplier);
                    resizablePanel1.Visible = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("错误代码：5302-尝试点击供应商数据出错或者无数据！请检查：" + ex.Message, "核销单温馨提示！");
            }
        }

        /// <summary>
        /// 初始化核销员
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
                MessageBox.Show("错误代码：5303-尝试点击经手人，数据显示失败或者无数据！请检查：" + ex.Message, "其它收款单温馨提示！");
            }
        }

        /// <summary>
        /// 标记那个控件不可用
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
            superGridControlTop.Enabled = false;
            superGridControlShangPing.Enabled = false;
            pictureBoxShengHe.Visible = true;
            toolStripBtnSave.Enabled = false;
            toolStripBtnShengHe.Enabled = false;
            panel2.Enabled = false;
            panel5.Enabled = false;
        }


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
                                  Color.FromArgb(85, 177, 238),
                                 //Color.White,
                                 1,
                                 ButtonBorderStyle.Solid);
        }
        #endregion

        /// <summary>
        /// 加载事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FinanceVerificationForm_Load(object sender, EventArgs e)
        {
            try
            {
                #region 初始化窗体
                //superGridControlShangPing.PrimaryGrid.ShowInsertRow = true;
                //superGridControlTop.PrimaryGrid.ShowInsertRow = true;
                pictureBoxShengHe.Parent = pictureBoxtitle;
                cboHeXiaoType.SelectedIndex = 0;
                toolStripButtonXuanYuanDan.Visible = true;
                //禁用自动创建列
                dataGridViewShangPing.AutoGenerateColumns = false;
                dataGridViewFuJia.AutoGenerateColumns = false;
                //是否显示滚动条
                superGridControlShangPing.HScrollBarVisible = true;
                superGridControlTop.HScrollBarVisible = true;
                // 将dataGridView中的内容居中显示
                dataGridViewFuJia.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                //显示行号
                superGridControlShangPing.PrimaryGrid.ShowRowGridIndex = true;
                superGridControlTop.PrimaryGrid.ShowRowGridIndex = true;
                //内容居中
                superGridControlShangPing.DefaultVisualStyles.CellStyles.Default.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleCenter;
                superGridControlTop.DefaultVisualStyles.CellStyles.Default.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleCenter;
                //排序方式范围
                superGridControlShangPing.PrimaryGrid.SortCycle = SortCycle.AscDesc;
                superGridControlTop.PrimaryGrid.SortCycle = SortCycle.AscDesc;
                //设置排序列和排序方式
                superGridControlShangPing.PrimaryGrid.AddSort(superGridControlShangPing.PrimaryGrid.Columns[0], SortDirection.Ascending);
                superGridControlTop.PrimaryGrid.AddSort(superGridControlTop.PrimaryGrid.Columns[0], SortDirection.Ascending);
                //调用合计行数据
                InitDataGridView();

                //上表格本次核销金额金额
                GridDoubleInputEditControl gdiecMoneyTop = superGridControlTop.PrimaryGrid.Columns["gridColumnBenCi"].EditControl as GridDoubleInputEditControl;
                gdiecMoneyTop.MinValue = 1;
                gdiecMoneyTop.MaxValue = 999999999;
                //下表格本次核销金额金额
                GridDoubleInputEditControl gdiecMoneyBottom = superGridControlShangPing.PrimaryGrid.Columns["benCiHeXiao"].EditControl as GridDoubleInputEditControl;
                gdiecMoneyBottom.MinValue = 1;
                gdiecMoneyBottom.MaxValue = 999999999;
                #endregion

                //客户
                _AllClient = client.GetClientByBool(false);
                //供应商
                _AllSupplier = supplier.SelSupplierTable();
                //核销员
                _AllEmployee = employee.SelSupplierTable(false);

                //生成其它收款单code和显示条形码
                _financeVerificationCode = BuildCode.ModuleCode("FVC");
                textBoxOddNumbers.Text = _financeVerificationCode;
                barcodeXYE.Code128 _Code = new barcodeXYE.Code128();
                _Code.ValueFont = new Font("微软雅黑", 20);
                System.Drawing.Bitmap imgTemp = _Code.GetCodeImage(textBoxOddNumbers.Text, barcodeXYE.Code128.Encode.Code128A);
                pictureBoxBarCode.Image = imgTemp;

                toolStripBtnSave.Click += toolStripBtnSave_Click;//保存按钮
                toolStripBtnShengHe.Click += toolStripBtnShengHe_Click;//审核按钮
                dataGridViewFuJia.CellDoubleClick += dataGridViewFuJia_CellDoubleClick;//dataGridViewFuJia表格双击事件
                toolStripButtonXuanYuanDan.Click += ToolStripButtonXuanYuanDan_Click;//选源单
                dataGridViewFuJia.KeyDown += DataGridViewFuJia_KeyDown;
            }
            catch (Exception ex)
            {
                MessageBox.Show("错误代码：5304-窗体加载时，初始化数据错误！请检查：" + ex.Message, "核销单温馨提示！");
                return;
            }
        }

        /// <summary>
        /// 选源单的点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToolStripButtonXuanYuanDan_Click(object sender, EventArgs e)
        {
            switch (cboHeXiaoType.Text)
            {

                case "预收冲应收":
                    XuanYuanDanYuShou();
                    break;

                case "预付冲应付":
                    XuanYuanDanYuFu();
                    break;

                case "应收冲应付":
                    YingShouXuanYuanDan();
                    break;

                case "应收转应收":
                    YingShouZhuanYingShouXuanYuanDan();
                    break;

                case "应付转应付":
                    YingFuZhuanYingFuXuanYuanDan();
                    break;
            }
        }

        /// <summary>
        /// 预收冲应收
        /// </summary>
        private void XuanYuanDanYuShou()
        {
            try
            {
                //如果点击了上面的表格
                if (superGridControlTop.Focused)
                {
                    if (labtextboxTop2.Text != "")
                    {
                        Finance.FinanceVerificationReportForm financeReport = new FinanceVerificationReportForm();
                        financeReport.ClientCode = _clientCode;
                        financeReport.ShowDialog(this);



                        if (_fuKuanCode == null)
                        {
                            return;
                        }
                        FinanceCollectionInterface financeCollection = new FinanceCollectionInterface();
                        GridItemsCollection grs = superGridControlTop.PrimaryGrid.Rows;
                        GridRow grid = (GridRow)superGridControlTop.PrimaryGrid.Rows[ClickRowIndex];
                        DataTable dt = ch.DataTableReCoding(financeCollection.GetList(2, XYEEncoding.strCodeHex(_fuKuanCode)));

                        superGridControlTop.PrimaryGrid.Rows.Add(new GridRow("", dt.Rows[0]["code"],
                         dt.Rows[0]["date"],
                         dt.Rows[0]["type"],
                         dt.Rows[0]["totalCollection"].ToString() == "" ? 0.0M : dt.Rows[0]["totalCollection"],
                         dt.Rows[0]["totalCollection"].ToString() == "" ? 0.0M : dt.Rows[0]["totalCollection"],
                         dt.Rows[0]["totalCollection"].ToString() == "" ? 0.0M : dt.Rows[0]["totalCollection"],
                           0.0M,
                           0.0M,
                         dt.Rows[0]["remark"].ToString() == "" ? "" : dt.Rows[0]["remark"]
                         ));

                        _mainCode = dt.Rows[0]["saleCode"].ToString();

                        foreach (GridRow g in grs)
                        {
                            if (g.Cells["gridColumnYuanDanCode"].Value == null || g.Cells["gridColumnYuanDanCode"].Value.ToString() == "")
                            {
                                continue;
                            }
                            _ClientMainList.Add(g.Cells["gridColumnYuanDanCode"].Value.ToString());
                        }
                        TongJiTopTable();
                        _fuKuanCode = null;
                    }
                    else
                    {
                        MessageBox.Show("请先选择客户：");
                        labtextboxTop2.Focus();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("错误代码：5305-核销类型为预收冲应收时，绑定数据到上表格失败！请检查：" + ex.Message, "核销单温馨提示！");
            }

            try
            {
                //如果点击了下面的表格
                if (superGridControlShangPing.Focused)
                {
                    if (labtextboxTop2.Text != "")
                    {
                        Finance.FinanceVerificationReportForm financeReport = new FinanceVerificationReportForm();
                        financeReport.SalerMainCode = _mainCode;
                        financeReport.ShowDialog(this);

                        if (_mainCode == null)
                        {
                            return;
                        }
                        SalesMainInterface salesMain = new SalesMainInterface();
                        GridItemsCollection grs = superGridControlShangPing.PrimaryGrid.Rows;
                        GridRow grid = (GridRow)superGridControlShangPing.PrimaryGrid.Rows[ClickRowIndex];
                        DataTable dt = ch.DataTableReCoding(salesMain.GetList(1, XYEEncoding.strCodeHex(_mainCode)));
                        superGridControlShangPing.PrimaryGrid.Rows.Add(new GridRow("", dt.Rows[0]["code"],
                         dt.Rows[0]["date"],
                         dt.Rows[0]["type"],
                         dt.Rows[0]["oddAllMoney"].ToString() == "" ? 0.0M : dt.Rows[0]["oddAllMoney"],
                         dt.Rows[0]["collectMoney"].ToString() == "" ? 0.0M : dt.Rows[0]["collectMoney"],
                         dt.Rows[0]["lastMoney"].ToString() == "" ? 0.0M : dt.Rows[0]["lastMoney"],
                           0.0M,
                           0.0M,
                         dt.Rows[0]["remark"].ToString() == "" ? "" : dt.Rows[0]["remark"]
                         ));
                        TongJiBottomTable();
                        foreach (GridRow g in grs)
                        {
                            if (g.Cells["yuanDanCode"].Value == null || g.Cells["yuanDanCode"].Value.ToString() == "")
                            {
                                continue;
                            }
                            _SupplierList.Add(g.Cells["yuanDanCode"].Value.ToString());
                        }
                        _mainCode = null;
                    }
                    else
                    {
                        MessageBox.Show("请先选择客户：");
                        labtextboxTop2.Focus();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("错误代码：5306-核销类型为预收冲应收时，绑定数据到下表格失败！请检查：" + ex.Message, "核销单温馨提示！");
            }
        }

        /// <summary>
        /// 预付冲应付
        /// </summary>
        private void XuanYuanDanYuFu()
        {
            try
            {
                //如果点击了上面的表格
                if (superGridControlTop.Focused)
                {
                    if (labtextboxTop5.Text != "")
                    {
                        Finance.FinanceVerificationReportForm financeReport = new FinanceVerificationReportForm();
                        financeReport.SupplierCode = _supplierCode;
                        financeReport.ShowDialog(this);
                        if (_shouKuanCode == null)
                        {
                            return;
                        }
                        FinancePaymentInterface financePayment = new FinancePaymentInterface();
                        GridItemsCollection grs = superGridControlTop.PrimaryGrid.Rows;
                        GridRow grid = (GridRow)superGridControlTop.PrimaryGrid.Rows[ClickRowIndex];
                        DataTable dt = ch.DataTableReCoding(financePayment.GetList(1, XYEEncoding.strCodeHex(_shouKuanCode)));

                        superGridControlTop.PrimaryGrid.Rows.Add(new GridRow("", dt.Rows[0]["code"],
                         dt.Rows[0]["date"],
                         dt.Rows[0]["type"],
                         dt.Rows[0]["totalCollection"].ToString() == "" ? 0.0M : dt.Rows[0]["totalCollection"],
                         dt.Rows[0]["totalCollection"].ToString() == "" ? 0.0M : dt.Rows[0]["totalCollection"],
                         dt.Rows[0]["totalCollection"].ToString() == "" ? 0.0M : dt.Rows[0]["totalCollection"],
                           0.0M,
                           0.0M,
                         dt.Rows[0]["remark"].ToString() == "" ? "" : dt.Rows[0]["remark"]
                         ));

                        _mainCode = dt.Rows[0]["purchaseCode"].ToString();
                        TongJiTopTable();
                        foreach (GridRow g in grs)
                        {
                            if (g.Cells["gridColumnYuanDanCode"].Value == null || g.Cells["gridColumnYuanDanCode"].Value.ToString() == "")
                            {
                                continue;
                            }
                            _ClientMainList.Add(g.Cells["gridColumnYuanDanCode"].Value.ToString());
                        }
                        _shouKuanCode = null;
                    }
                    else
                    {
                        MessageBox.Show("请先选择供应商：");
                        labtextboxTop5.Focus();
                    }
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show("错误代码：5307-核销类型为预付冲应付时，绑定数据到上表格失败！请检查：" + ex.Message, "核销单温馨提示！");
            }

            try
            {
                //如果点击了下面的表格
                if (superGridControlShangPing.Focused)
                {
                    if (labtextboxTop5.Text != "")
                    {
                        Finance.FinanceVerificationReportForm financeReport = new FinanceVerificationReportForm();
                        financeReport.PurchaseCode = _mainCode;
                        financeReport.ShowDialog(this);
                        if (_mainCode == null)
                        {
                            return;
                        }
                        PurchaseMainInterface purchase = new PurchaseMainInterface();
                        GridItemsCollection grs = superGridControlShangPing.PrimaryGrid.Rows;
                        GridRow grid = (GridRow)superGridControlShangPing.PrimaryGrid.Rows[ClickRowIndex];
                        DataTable dt = ch.DataTableReCoding(purchase.GetList(3, XYEEncoding.strCodeHex(_mainCode)));
                        superGridControlShangPing.PrimaryGrid.Rows.Add(new GridRow("", dt.Rows[0]["code"],
                         dt.Rows[0]["data"],
                         dt.Rows[0]["type"],
                         dt.Rows[0]["oddMoney"].ToString() == "" ? 0.0M : dt.Rows[0]["oddMoney"],
                         dt.Rows[0]["inMoney"].ToString() == "" ? 0.0M : dt.Rows[0]["inMoney"],
                         dt.Rows[0]["lastMoney"].ToString() == "" ? 0.0M : dt.Rows[0]["lastMoney"],
                           0.0M,
                           0.0M,
                         dt.Rows[0]["remark"].ToString() == "" ? "" : dt.Rows[0]["remark"]
                         ));
                        TongJiBottomTable();

                        foreach (GridRow g in grs)
                        {
                            if (g.Cells["yuanDanCode"].Value == null || g.Cells["yuanDanCode"].Value.ToString() == "")
                            {
                                continue;
                            }
                            _SupplierList.Add(g.Cells["yuanDanCode"].Value.ToString());
                        }
                        _mainCode = null;
                    }
                    else
                    {
                        MessageBox.Show("请先选择供应商：");
                    }
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show("错误代码：5308-核销类型为预付冲应付时，绑定数据到下表格失败！请检查：" + ex.Message, "核销单温馨提示！");
            }
        }

        /// <summary>
        /// 应收冲应付
        /// </summary>
        private void YingShouXuanYuanDan()
        {
            try
            {
                //如果点击了上面的表格
                if (superGridControlTop.Focused)
                {
                    if (labtextboxTop2.Text != "")
                    {
                        Finance.FinanceVerificationReportForm financeReport = new FinanceVerificationReportForm();
                        financeReport.ClientCode = _clientCode;
                        financeReport.ShowDialog(this);

                        if (_fuKuanCode == null)
                        {
                            return;
                        }
                        FinanceCollectionInterface financeCollection = new FinanceCollectionInterface();
                        GridItemsCollection grs = superGridControlTop.PrimaryGrid.Rows;
                        GridRow grid = (GridRow)superGridControlTop.PrimaryGrid.Rows[ClickRowIndex];
                        DataTable dt = ch.DataTableReCoding(financeCollection.GetList(2, XYEEncoding.strCodeHex(_fuKuanCode)));

                        superGridControlTop.PrimaryGrid.Rows.Add(new GridRow("", dt.Rows[0]["code"],
                         dt.Rows[0]["date"],
                         dt.Rows[0]["type"],
                         dt.Rows[0]["totalCollection"].ToString() == "" ? 0.0M : dt.Rows[0]["totalCollection"],
                         dt.Rows[0]["totalCollection"].ToString() == "" ? 0.0M : dt.Rows[0]["totalCollection"],
                         dt.Rows[0]["totalCollection"].ToString() == "" ? 0.0M : dt.Rows[0]["totalCollection"],
                           0.0M,
                           0.0M,
                         dt.Rows[0]["remark"].ToString() == "" ? "" : dt.Rows[0]["remark"]
                         ));
                        TongJiTopTable();
                        foreach (GridRow g in grs)
                        {
                            if (g.Cells["gridColumnYuanDanCode"].Value == null || g.Cells["gridColumnYuanDanCode"].Value.ToString() == "")
                            {
                                continue;
                            }
                            _ClientMainList.Add(g.Cells["gridColumnYuanDanCode"].Value.ToString());
                        }
                        _fuKuanCode = null;
                    }
                    else
                    {
                        MessageBox.Show("请选择客户：");
                        labtextboxTop2.Focus();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("错误代码：5309-核销类型为应收冲应付时，绑定数据到上表格失败！请检查：" + ex.Message, "核销单温馨提示！");
            }

            try
            {
                if (superGridControlShangPing.Focused)
                {
                    if (labtextboxTop5.Text != "")
                    {
                        Finance.FinanceVerificationReportForm financeReport = new FinanceVerificationReportForm();
                        financeReport.SupplierCode = _supplierCode;
                        financeReport.ShowDialog(this);

                        if (_shouKuanCode == null)
                        {
                            return;
                        }


                        FinancePaymentInterface financePayment = new FinancePaymentInterface();
                        GridItemsCollection grs = superGridControlShangPing.PrimaryGrid.Rows;
                        GridRow grid = (GridRow)superGridControlShangPing.PrimaryGrid.Rows[ClickRowIndex];
                        DataTable dt = ch.DataTableReCoding(financePayment.GetList(1, XYEEncoding.strCodeHex(_shouKuanCode)));

                        superGridControlShangPing.PrimaryGrid.Rows.Add(new GridRow("", dt.Rows[0]["code"],
                         dt.Rows[0]["date"],
                         dt.Rows[0]["type"],
                         dt.Rows[0]["totalCollection"].ToString() == "" ? 0.0M : dt.Rows[0]["totalCollection"],
                         dt.Rows[0]["totalCollection"].ToString() == "" ? 0.0M : dt.Rows[0]["totalCollection"],
                         dt.Rows[0]["totalCollection"].ToString() == "" ? 0.0M : dt.Rows[0]["totalCollection"],
                           0.0M,
                           0.0M,
                         dt.Rows[0]["remark"].ToString() == "" ? "" : dt.Rows[0]["remark"]
                         ));
                        TongJiBottomTable();
                        foreach (GridRow g in grs)
                        {
                            if (g.Cells["yuanDanCode"].Value == null || g.Cells["yuanDanCode"].Value.ToString() == "")
                            {
                                continue;
                            }
                            _SupplierList.Add(g.Cells["yuanDanCode"].Value.ToString());
                        }
                        _shouKuanCode = null;
                    }
                    else
                    {
                        MessageBox.Show("请选择供应商：");
                        labtextboxTop5.Focus();
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("错误代码：5310-核销类型为应收冲应付时，绑定数据到下表格失败！请检查：" + ex.Message, "核销单温馨提示！");
            }
        }

        /// <summary>
        /// 应收转应收
        /// </summary>
        private void YingShouZhuanYingShouXuanYuanDan()
        {
            try
            {
                //如果点击了上面的表格
                if (superGridControlTop.Focused)
                {
                    if (labtextboxTop2.Text != "")
                    {
                        Finance.FinanceVerificationReportForm financeReport = new FinanceVerificationReportForm();
                        financeReport.ClientCode = _clientCode;
                        financeReport.ShowDialog(this);

                        if (_fuKuanCode == null)
                        {
                            return;
                        }
                        FinanceCollectionInterface financeCollection = new FinanceCollectionInterface();
                        GridItemsCollection grs = superGridControlTop.PrimaryGrid.Rows;
                        GridRow grid = (GridRow)superGridControlTop.PrimaryGrid.Rows[ClickRowIndex];
                        DataTable dt = ch.DataTableReCoding(financeCollection.GetList(2, XYEEncoding.strCodeHex(_fuKuanCode)));

                        superGridControlTop.PrimaryGrid.Rows.Add(new GridRow("", dt.Rows[0]["code"],
                         dt.Rows[0]["date"],
                         dt.Rows[0]["type"],
                         dt.Rows[0]["totalCollection"].ToString() == "" ? 0.0M : dt.Rows[0]["totalCollection"],
                         dt.Rows[0]["totalCollection"].ToString() == "" ? 0.0M : dt.Rows[0]["totalCollection"],
                         dt.Rows[0]["totalCollection"].ToString() == "" ? 0.0M : dt.Rows[0]["totalCollection"],
                           0.0M,
                           0.0M,
                         dt.Rows[0]["remark"].ToString() == "" ? "" : dt.Rows[0]["remark"]
                         ));
                        TongJiTopTable();

                        foreach (GridRow g in grs)
                        {
                            if (g.Cells["gridColumnYuanDanCode"].Value == null || g.Cells["gridColumnYuanDanCode"].Value.ToString() == "")
                            {
                                continue;
                            }
                            _ClientMainList.Add(g.Cells["gridColumnYuanDanCode"].Value.ToString());
                        }
                        _fuKuanCode = null;
                    }
                    else
                    {
                        MessageBox.Show("请选择转出客户：");
                        labtextboxTop2.Focus();
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("错误代码：5311-核销类型为应收转应收时，绑定数据到上表格失败！请检查：" + ex.Message, "核销单温馨提示！");
            }
        }

        /// <summary>
        /// 应付转应付
        /// </summary>
        private void YingFuZhuanYingFuXuanYuanDan()
        {
            try
            {
                if (superGridControlTop.Focused)
                {
                    if (labtextboxTop5.Text != "")
                    {
                        Finance.FinanceVerificationReportForm financeReport = new FinanceVerificationReportForm();
                        financeReport.SupplierCode = _supplierCode;
                        financeReport.ShowDialog(this);

                        if (_shouKuanCode == null)
                        {
                            return;
                        }

                        FinancePaymentInterface financePayment = new FinancePaymentInterface();
                        GridItemsCollection grs = superGridControlTop.PrimaryGrid.Rows;
                        GridRow grid = (GridRow)superGridControlTop.PrimaryGrid.Rows[ClickRowIndex];
                        DataTable dt = ch.DataTableReCoding(financePayment.GetList(1, XYEEncoding.strCodeHex(_shouKuanCode)));

                        superGridControlTop.PrimaryGrid.Rows.Add(new GridRow("", dt.Rows[0]["code"],
                         dt.Rows[0]["date"],
                         dt.Rows[0]["type"],
                         dt.Rows[0]["totalCollection"].ToString() == "" ? 0.0M : dt.Rows[0]["totalCollection"],
                         dt.Rows[0]["totalCollection"].ToString() == "" ? 0.0M : dt.Rows[0]["totalCollection"],
                         dt.Rows[0]["totalCollection"].ToString() == "" ? 0.0M : dt.Rows[0]["totalCollection"],
                           0.0M,
                           0.0M,
                         dt.Rows[0]["remark"].ToString() == "" ? "" : dt.Rows[0]["remark"]
                         ));
                        TongJiTopTable();
                        foreach (GridRow g in grs)
                        {
                            if (g.Cells["gridColumnYuanDanCode"].Value == null || g.Cells["gridColumnYuanDanCode"].Value.ToString() == "")
                            {
                                continue;
                            }
                            _ClientMainList.Add(g.Cells["gridColumnYuanDanCode"].Value.ToString());
                        }
                        _shouKuanCode = null;
                    }
                    else
                    {
                        MessageBox.Show("请选择转出供应商：");
                        labtextboxTop5.Focus();
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("错误代码：5312-核销类型为应付转应付时，绑定数据到上表格失败！请检查：" + ex.Message, "核销单温馨提示！");
            }
        }
        
        /// <summary>
        /// 窗体加载时，焦点在核销类型上
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FinanceVerificationForm_Activated(object sender, EventArgs e)
        {
            cboHeXiaoType.Focus();
        }

        /// <summary>
        /// 按Esc关闭表格
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FinanceVerificationForm_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Escape)
            {
                this.resizablePanel1.Visible = false;
                this.resizablePanelData.Visible = false;
            }
        }

        /// <summary>
        /// 快捷方式设置
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FinanceVerificationForm_KeyDown(object sender, KeyEventArgs e)
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

        /// <summary>
        /// 核销类型下拉框选择改变事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cboHeXiaoType_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cboHeXiaoType.Text)
            {
                #region  预收冲应收
                case "预收冲应收":
                    //客户
                    labTop2.ForeColor = Color.Black;
                    labTop2.Text = "客户：";
                    labTop2.Visible = true;
                    labtextboxTop2.Enabled = true;
                    labtextboxTop2.Visible = true;
                    labtextboxTop2.Border.BorderBottomColor = Color.Black;
                    labtextboxTop2.Clear();
                    pictureBox2.Enabled = true;
                    pictureBox2.Visible = true;
                    //供应商
                    labTop5.ForeColor = Color.Gray;
                    labTop5.Visible = true;
                    labTop5.Text = "供应商：";
                    labtextboxTop5.Enabled = false;
                    labtextboxTop5.Visible = true;
                    labtextboxTop5.Clear();
                    pictureBox3.Enabled = false;
                    pictureBox3.Visible = true;
                    //转入客户
                    labTop7.Visible = false;
                    labtextboxTop7.Visible = false;
                    labtextboxTop7.Clear();
                    pictureBox4.Visible = false;
                    //转入供应商
                    labTop4.Visible = false;
                    labtextboxTop4.Visible = false;
                    labtextboxTop4.Clear();
                    pictureBoxDanJuType.Visible = false;
                    //说明
                    labtextboxTop6.Text = "预收";
                    textBox1.Text = "应收";
                    //表格
                    superGridControlShangPing.Enabled = true;
                    superGridControlTop.PrimaryGrid.Rows.Clear();
                    superGridControlShangPing.PrimaryGrid.Rows.Clear();
                    superGridControlTop.PrimaryGrid.Rows.Add(new GridRow("", "", "", "", 0.00, 0.00, 0.00, 0.00, ""));
                    superGridControlShangPing.PrimaryGrid.Rows.Add(new GridRow("", "", "", "", 0.00, 0.00, 0.00, 0.00, ""));
                    TongJiTopTable();
                    TongJiBottomTable();
                    resizablePanel1.Visible = false;
                    break;
                #endregion
                #region  预付冲应付
                case "预付冲应付":
                    //客户
                    labTop2.ForeColor = Color.Gray;
                    labTop2.Text = "客户：";
                    labTop2.Visible = true;
                    labtextboxTop2.Enabled = false;
                    labtextboxTop2.Visible = true;
                    labtextboxTop2.Border.BorderBottomColor = Color.Gray;
                    labtextboxTop2.Clear();
                    pictureBox2.Enabled = false;
                    pictureBox2.Visible = true;
                    //供应商
                    labTop5.ForeColor = Color.Black;
                    labTop5.Text = "供应商：";
                    labTop5.Visible = true;
                    labtextboxTop5.Enabled = true;
                    labtextboxTop5.Visible = true;
                    labtextboxTop5.Clear();
                    labtextboxTop5.Border.BorderBottomColor = Color.Black;
                    pictureBox3.Enabled = true;
                    pictureBox3.Visible = true;
                    //转入客户
                    labTop7.Visible = false;
                    labtextboxTop7.Visible = false;
                    pictureBox4.Visible = false;
                    //转入供应商
                    labTop4.Visible = false;
                    labtextboxTop4.Visible = false;
                    pictureBoxDanJuType.Visible = false;
                    //说明
                    labtextboxTop6.Text = "预付";
                    textBox1.Text = "应付";
                    //表格
                    superGridControlShangPing.Enabled = true;
                    superGridControlTop.PrimaryGrid.Rows.Clear();
                    superGridControlShangPing.PrimaryGrid.Rows.Clear();
                    superGridControlTop.PrimaryGrid.Rows.Add(new GridRow("", "", "", "", 0.00, 0.00, 0.00, 0.00, ""));
                    superGridControlShangPing.PrimaryGrid.Rows.Add(new GridRow("", "", "", "", 0.00, 0.00, 0.00, 0.00, ""));
                    TongJiTopTable();
                    TongJiBottomTable();
                    resizablePanel1.Visible = false;
                    break;
                #endregion
                #region  应收冲应付
                case "应收冲应付":
                    //客户
                    labTop2.ForeColor = Color.Black;
                    labTop2.Text = "客户：";
                    labTop2.Visible = true;
                    labtextboxTop2.Enabled = true;
                    labtextboxTop2.Visible = true;
                    labtextboxTop2.Border.BorderBottomColor = Color.Black;
                    labtextboxTop2.Clear();
                    pictureBox2.Enabled = true;
                    pictureBox2.Visible = true;
                    //供应商
                    labTop5.ForeColor = Color.Black;
                    labTop5.Text = "供应商:";
                    labTop5.Visible = true;
                    labtextboxTop5.Enabled = true;
                    labtextboxTop5.Visible = true;
                    labtextboxTop5.Border.BorderBottomColor = Color.Black;
                    labtextboxTop5.Clear();
                    pictureBox3.Enabled = true;
                    pictureBox3.Visible = true;
                    //转入客户
                    labTop7.Visible = false;
                    labtextboxTop7.Visible = false;
                    labtextboxTop7.Clear();
                    pictureBox4.Visible = false;
                    //转入供应商
                    labTop4.Visible = false;
                    labtextboxTop4.Visible = false;
                    labtextboxTop4.Clear();
                    pictureBoxDanJuType.Visible = false;
                    //说明
                    labtextboxTop6.Text = "应收";
                    textBox1.Text = "应付";
                    //表格
                    superGridControlShangPing.Enabled = true;
                    superGridControlTop.PrimaryGrid.Rows.Clear();
                    superGridControlShangPing.PrimaryGrid.Rows.Clear();
                    superGridControlTop.PrimaryGrid.Rows.Add(new GridRow("", "", "", "", 0.00, 0.00, 0.00, 0.00, ""));
                    superGridControlShangPing.PrimaryGrid.Rows.Add(new GridRow("", "", "", "", 0.00, 0.00, 0.00, 0.00, ""));
                    TongJiTopTable();
                    TongJiBottomTable();
                    resizablePanel1.Visible = false;
                    break;
                #endregion
                #region  应收转应收
                case "应收转应收":
                    //转出客户
                    labTop2.ForeColor = Color.Black;
                    labTop2.Text = "转出客户：";
                    labTop2.Visible = true;
                    labtextboxTop2.Enabled = true;
                    labtextboxTop2.Visible = true;
                    labtextboxTop2.Border.BorderBottomColor = Color.Black;
                    labtextboxTop2.Clear();
                    pictureBox2.Enabled = true;
                    //供应商
                    labTop5.Visible = false;
                    labtextboxTop5.Visible = false;
                    labtextboxTop5.Clear();
                    pictureBox3.Visible = false;
                    //转入客户
                    labTop7.Visible = true;
                    labtextboxTop7.Visible = true;
                    labtextboxTop7.Clear();
                    pictureBox4.Visible = true;
                    //转入供应商
                    labTop4.Visible = false;
                    labtextboxTop4.Visible = false;
                    labtextboxTop4.Clear();
                    pictureBoxDanJuType.Visible = false;
                    //说明
                    labtextboxTop6.Text = "应收";
                    textBox1.Text = "";
                    //表格
                    superGridControlShangPing.Enabled = false;
                    superGridControlTop.PrimaryGrid.Rows.Clear();
                    superGridControlShangPing.PrimaryGrid.Rows.Clear();
                    superGridControlTop.PrimaryGrid.Rows.Add(new GridRow("", "", "", "", 0.00, 0.00, 0.00, 0.00, ""));
                    superGridControlShangPing.PrimaryGrid.Rows.Add(new GridRow("", "", "", "", 0.00, 0.00, 0.00, 0.00, ""));
                    TongJiTopTable();
                    TongJiBottomTable();
                    resizablePanel1.Visible = false;
                    break;
                #endregion
                #region  应付转应付
                case "应付转应付":
                    //转出供应商
                    labTop5.Visible = true;
                    labTop5.ForeColor = Color.Black;
                    labTop5.Text = "转出供应商：";
                    labtextboxTop5.Enabled = true;
                    labtextboxTop5.Visible = true;
                    labtextboxTop5.Border.BorderBottomColor = Color.Black;
                    labtextboxTop5.Clear();
                    pictureBox3.Enabled = true;
                    pictureBox3.Visible = true;
                    //客户
                    labTop2.Visible = false;
                    labtextboxTop2.Visible = false;
                    labtextboxTop2.Clear();
                    pictureBox2.Visible = false;
                    //转入客户
                    labTop7.Visible = false;
                    labtextboxTop7.Visible = false;
                    labtextboxTop7.Clear();
                    pictureBox4.Visible = false;
                    //转入供应商
                    labTop4.Visible = true;
                    labtextboxTop4.Visible = true;
                    labtextboxTop4.Clear();
                    pictureBoxDanJuType.Visible = true;
                    //说明
                    labtextboxTop6.Text = "应付";
                    textBox1.Text = "";
                    //表格
                    superGridControlShangPing.Enabled = false;
                    superGridControlTop.PrimaryGrid.Rows.Clear();
                    superGridControlShangPing.PrimaryGrid.Rows.Clear();
                    superGridControlTop.PrimaryGrid.Rows.Add(new GridRow("", "", "", "", 0.00, 0.00, 0.00, 0.00, ""));
                    superGridControlShangPing.PrimaryGrid.Rows.Add(new GridRow("", "", "", "", 0.00, 0.00, 0.00, 0.00, ""));
                    TongJiTopTable();
                    TongJiBottomTable();
                    resizablePanel1.Visible = false;
                    break;
                    #endregion
            }
        }

        #region  小箭头点击事件

        /// <summary>
        /// 客户小箭头点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pictureBoxClient_Click(object sender, EventArgs e)
        {
            if (_Click != 1)
            {
                InitClient();
                resizablePanel1.Location = new Point(560, 155);
                dataGridViewFuJia.Focus();
            }
            _Click = 6;
        }

        /// <summary>
        /// 转入客户小箭头点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pictureBoxClientIn_Click(object sender, EventArgs e)
        {
            if (_Click != 2)
            {
                InitClient();
                resizablePanel1.Location = new Point(630, 155);
                dataGridViewFuJia.Focus();
            }
            _Click = 7;
        }

        /// <summary>
        /// 供应商小箭头点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pictureBoxSupply_Click(object sender, EventArgs e)
        {
            if (_Click != 3)
            {
                InitSupplier();
                resizablePanel1.Location = new Point(560, 190);
                dataGridViewFuJia.Focus();
            }
            _Click = 8;
        }

        /// <summary>
        /// 转入供应商小箭头点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pictureBoxSupplyIn_Click(object sender, EventArgs e)
        {
            if (_Click != 4)
            {
                InitSupplier();
                resizablePanel1.Location = new Point(630, 190);
                dataGridViewFuJia.Focus();
            }
            _Click = 9;
        }

        /// <summary>
        ///核销员小箭头点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pictureBoxEmployee_Click(object sender, EventArgs e)
        {
            if (_Click != 5)
            {
                InitEmployee();
                dataGridViewFuJia.Focus();
            }
            _Click = 10;
        }

        #endregion

        /// <summary>
        /// 双击绑定客户、供应商、核销员数据
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
        /// dataGridViewFuJia表格双击事件函数
        /// </summary>
        private void dataGridViewFuJiaTableClick()
        {
            try
            {
                //客户
                if (_Click == 1 || _Click == 6)
                {
                    _clientCode = dataGridViewFuJia.Rows[dataGridViewFuJia.CurrentRow.Index].Cells["code"].Value.ToString();//客户code
                    string name = dataGridViewFuJia.Rows[dataGridViewFuJia.CurrentRow.Index].Cells["name"].Value.ToString();//客户名称
                    labtextboxTop2.Text = name;
                    resizablePanel1.Visible = false;
                }
                //转入客户
                if (_Click == 2 || _Click == 7)
                {
                    _clientCodeIn = dataGridViewFuJia.Rows[dataGridViewFuJia.CurrentRow.Index].Cells["code"].Value.ToString();//转入客户code
                    string nameIn = dataGridViewFuJia.Rows[dataGridViewFuJia.CurrentRow.Index].Cells["name"].Value.ToString();//转入客户名称
                    labtextboxTop7.Text = nameIn;
                    resizablePanel1.Visible = false;
                }
                //供应商
                if (_Click == 3 || _Click == 8)
                {
                    _supplierCode = dataGridViewFuJia.Rows[dataGridViewFuJia.CurrentRow.Index].Cells["code"].Value.ToString();//供应商code
                    string name = dataGridViewFuJia.Rows[dataGridViewFuJia.CurrentRow.Index].Cells["name"].Value.ToString();//供应商名称
                    labtextboxTop5.Text = name;
                    resizablePanel1.Visible = false;
                }
                //转入供应商
                if (_Click == 4 || _Click == 9)
                {
                    _supplierCodeIn = dataGridViewFuJia.Rows[dataGridViewFuJia.CurrentRow.Index].Cells["code"].Value.ToString();//转入供应商code
                    string nameIn = dataGridViewFuJia.Rows[dataGridViewFuJia.CurrentRow.Index].Cells["name"].Value.ToString();//转入供应商名称
                    labtextboxTop4.Text = nameIn;
                    resizablePanel1.Visible = false;
                }
                //核销员
                if (_Click == 5 || _Click == 10)
                {
                    _employeeCode = dataGridViewFuJia.Rows[dataGridViewFuJia.CurrentRow.Index].Cells["code"].Value.ToString();//核销员code
                    string name = dataGridViewFuJia.Rows[dataGridViewFuJia.CurrentRow.Index].Cells["name"].Value.ToString();//核销员名称
                    ltxtbSalsMan.Text = name;
                    resizablePanel1.Visible = false;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("错误代码：5313-双击绑定客户、供应商、核销员数据错误！请检查：" + ex.Message, "核销单温馨提示！");
            }
        }

        /// <summary>
        /// 表格按键
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
                if (this.labtextboxTop2.Text.Trim() == "")
                {
                    InitClient();
                    _Click = 6;
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

                resizablePanel1.Location = new Point(560, 155);
                string name = XYEEncoding.strCodeHex(this.labtextboxTop2.Text.Trim());
                dataGridViewFuJia.DataSource = ch.DataTableReCoding(client.GetList(0, name));
                resizablePanel1.Visible = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("错误代码：5314-模糊查询客户数据错误" + ex.Message, "核销单温馨提示");
            }
        }

        /// <summary>
        /// 转入客户模糊查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtClientIn_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.labtextboxTop7.Text.Trim() == "")
                {
                    InitClient();
                    _Click = 7;
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

                resizablePanel1.Location = new Point(630, 155);
                string name = XYEEncoding.strCodeHex(this.labtextboxTop7.Text.Trim());
                dataGridViewFuJia.DataSource = ch.DataTableReCoding(client.GetList(0, name));
                resizablePanel1.Visible = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("错误代码：5315-模糊查询转入客户数据错误" + ex.Message, "核销单温馨提示");
            }
        }

        /// <summary>
        /// 供应商模糊查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtSupply_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.labtextboxTop5.Text.Trim() == "")
                {
                    InitSupplier();
                    _Click = 8;
                    return;
                }

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
                dgvc.SortMode = DataGridViewColumnSortMode.NotSortable;
                dgvc.Visible = false;
                dataGridViewFuJia.Columns.Add(dgvc);

                dgvc = new DataGridViewTextBoxColumn();
                dgvc.Name = "linkMan";
                dgvc.HeaderText = "联系人";
                dgvc.DataPropertyName = "联系人";
                dgvc.SortMode = DataGridViewColumnSortMode.NotSortable;
                dgvc.Visible = false;
                dataGridViewFuJia.Columns.Add(dgvc);

                dgvc = new DataGridViewTextBoxColumn();
                dgvc.Name = "fax";
                dgvc.HeaderText = "传真";
                dgvc.DataPropertyName = "传真";
                dgvc.SortMode = DataGridViewColumnSortMode.NotSortable;
                dgvc.Visible = false;
                dataGridViewFuJia.Columns.Add(dgvc);

                resizablePanel1.Location = new Point(560, 190);
                string name = XYEEncoding.strCodeHex(this.labtextboxTop5.Text.Trim());
                dataGridViewFuJia.DataSource = ch.DataTableReCoding(supplier.GetList(0, name));
                resizablePanel1.Visible = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("错误代码：5316-模糊查询供应商数据错误" + ex.Message, "核销单温馨提示");
            }
        }

        /// <summary>
        /// 转入供应商模糊查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtSupplyIn_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.labtextboxTop4.Text.Trim() == "")
                {
                    InitSupplier();
                    _Click = 9;
                    return;
                }

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
                dgvc.SortMode = DataGridViewColumnSortMode.NotSortable;
                dgvc.Visible = false;
                dataGridViewFuJia.Columns.Add(dgvc);

                dgvc = new DataGridViewTextBoxColumn();
                dgvc.Name = "linkMan";
                dgvc.HeaderText = "联系人";
                dgvc.DataPropertyName = "联系人";
                dgvc.SortMode = DataGridViewColumnSortMode.NotSortable;
                dgvc.Visible = false;
                dataGridViewFuJia.Columns.Add(dgvc);

                dgvc = new DataGridViewTextBoxColumn();
                dgvc.Name = "fax";
                dgvc.HeaderText = "传真";
                dgvc.DataPropertyName = "传真";
                dgvc.SortMode = DataGridViewColumnSortMode.NotSortable;
                dgvc.Visible = false;
                dataGridViewFuJia.Columns.Add(dgvc);

                resizablePanel1.Location = new Point(630, 190);
                string name = XYEEncoding.strCodeHex(this.labtextboxTop4.Text.Trim());
                dataGridViewFuJia.DataSource = ch.DataTableReCoding(supplier.GetList(0, name));
                resizablePanel1.Visible = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("错误代码：5317-模糊查询转入供应商数据错误" + ex.Message, "核销单温馨提示");
            }
        }

        /// <summary>
        ///经手人模糊查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ltxtbSalsMan_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (ltxtbSalsMan.Text.Trim() == "")
                {
                    _Click = 10;
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
                MessageBox.Show("错误代码：5318-模糊查询核销员数据失败！" + ex.Message);
            }
        }

        #endregion

        /// <summary>
        /// 上表格验证统计
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void superGridControlTop_CellValidated(object sender, GridCellValidatedEventArgs e)
        {
            try
            {
                GridRow gr = e.GridPanel.Rows[e.GridCell.RowIndex] as GridRow;
                if (gr.Cells["gridColumnYuanDanCode"].FormattedValue == null || gr.Cells["gridColumnYuanDanCode"].FormattedValue == "")
                {
                    MessageBox.Show("请先选择单据：");
                    gr.Cells["gridColumnBenCi"].Value = 0.00;
                    return;
                }
                decimal benciHeXiaoMoney = Convert.ToDecimal(gr.Cells["gridColumnBenCi"].FormattedValue);//本次核销金额
                decimal weiHeXiaoMoney = Convert.ToDecimal(gr.Cells["gridColumnWeiHeXiao"].FormattedValue);//未核销金额
                if (benciHeXiaoMoney > weiHeXiaoMoney)
                {
                    MessageBox.Show("本次核销金额不能大于未核销金额！");
                    gr.Cells["gridColumnBenCi"].Value = 0.00;
                    return;
                }
                TongJiTopTable();
            }
            catch (Exception ex)
            {
                MessageBox.Show("错误代码：5319-验证上表格里数据以及统计出错！请检查：" + ex.Message, "核销单温馨提示！");
            }
        }

        /// <summary>
        /// 统计上表格数据
        /// </summary>
        private void TongJiTopTable()
        {
            try
            {
                GridRow gr = (GridRow)superGridControlTop.PrimaryGrid.Rows[ClickRowIndex];
                //逐行统计数据总数
                decimal tempDanJuMoney = 0;
                decimal tempYiHeXiaoMoney = 0;
                decimal tempWeiHeXiaoMoney = 0;
                decimal tempBenCiHeXiao = 0;
                for (int i = 0; i < superGridControlTop.PrimaryGrid.Rows.Count - 1; i++)
                {
                    GridRow tempGR = superGridControlTop.PrimaryGrid.Rows[i] as GridRow;
                    tempDanJuMoney += Convert.ToDecimal(tempGR["gridColumnDanJuMoney"].FormattedValue);
                    tempYiHeXiaoMoney += Convert.ToDecimal(tempGR["gridColumnYiHeXiao"].FormattedValue);
                    tempWeiHeXiaoMoney += Convert.ToDecimal(tempGR["gridColumnWeiHeXiao"].FormattedValue);
                    tempBenCiHeXiao += Convert.ToDecimal(tempGR["gridColumnBenCi"].FormattedValue);
                }
                _danJuMoneyTop = tempDanJuMoney;
                _yiHeXiaoMoneyTop = tempYiHeXiaoMoney;
                _weiHeXiaoMoneyTop = tempWeiHeXiaoMoney;
                _benCiHeXiaoMoneyTop = tempBenCiHeXiao;
                gr = (GridRow)superGridControlTop.PrimaryGrid.LastSelectableRow;
                gr["gridColumnDanJuMoney"].Value = _danJuMoneyTop.ToString();
                gr["gridColumnYiHeXiao"].Value = _yiHeXiaoMoneyTop.ToString();
                gr["gridColumnWeiHeXiao"].Value = _weiHeXiaoMoneyTop.ToString();
                gr["gridColumnBenCi"].Value = _benCiHeXiaoMoneyTop.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("错误代码：5320-逐行统计上表格数据错误！" + ex.Message, "核销单温馨提示：");
            }
        }

        /// <summary>
        /// 下表格验证统计
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void superGridControlShangPing_CellValidated(object sender, GridCellValidatedEventArgs e)
        {
            try
            {
                GridRow gr = e.GridPanel.Rows[e.GridCell.RowIndex] as GridRow;
                if (gr.Cells["yuanDanCode"].FormattedValue == null || gr.Cells["yuanDanCode"].FormattedValue == "")
                {
                    MessageBox.Show("请先选择单据：");
                    gr.Cells["benCiHeXiao"].Value = 0.00;
                    return;
                }
                decimal benciHeXiaoMoney = Convert.ToDecimal(gr.Cells["benCiHeXiao"].FormattedValue);//本次核销金额
                decimal weiHeXiaoMoney = Convert.ToDecimal(gr.Cells["weiHeXiao"].FormattedValue);//未核销金额
                if (benciHeXiaoMoney > weiHeXiaoMoney)
                {
                    MessageBox.Show("本次核销金额不能大于未核销金额！");
                    gr.Cells["benCiHeXiao"].Value = 0.00;
                    return;
                }
                TongJiBottomTable();
            }
            catch (Exception ex)
            {
                MessageBox.Show("错误代码：5321-验证下表格里的数据以及统计出错！请检查：" + ex.Message, "核销单温馨提示！");
            }
        }

        /// <summary>
        /// 统计下表格数据
        /// </summary>
        private void TongJiBottomTable()
        {
            try
            {
                GridRow gr = (GridRow)superGridControlShangPing.PrimaryGrid.Rows[ClickRowIndex];
                //逐行统计数据总数
                decimal tempDanJuMoney = 0;
                decimal tempYiHeXiaoMoney = 0;
                decimal tempWeiHeXiaoMoney = 0;
                decimal tempBenCiHeXiao = 0;
                for (int i = 0; i < superGridControlShangPing.PrimaryGrid.Rows.Count - 1; i++)
                {
                    GridRow tempGR = superGridControlShangPing.PrimaryGrid.Rows[i] as GridRow;
                    tempDanJuMoney += Convert.ToDecimal(tempGR["danJuMoney"].FormattedValue);
                    tempYiHeXiaoMoney += Convert.ToDecimal(tempGR["yiHeXiao"].FormattedValue);
                    tempWeiHeXiaoMoney += Convert.ToDecimal(tempGR["weiHeXiao"].FormattedValue);
                    tempBenCiHeXiao += Convert.ToDecimal(tempGR["benCiHeXiao"].FormattedValue);
                }
                _danJuMoneyBottom = tempDanJuMoney;
                _yiHeXiaoMoneyBottom = tempYiHeXiaoMoney;
                _weiHeXiaoMoneyBottom = tempWeiHeXiaoMoney;
                _benCiHeXiaoMoneyBottom = tempBenCiHeXiao;
                gr = (GridRow)superGridControlShangPing.PrimaryGrid.LastSelectableRow;
                gr["danJuMoney"].Value = _danJuMoneyBottom.ToString();
                gr["yiHeXiao"].Value = _yiHeXiaoMoneyBottom.ToString();
                gr["weiHeXiao"].Value = _weiHeXiaoMoneyBottom.ToString();
                gr["benCiHeXiao"].Value = _benCiHeXiaoMoneyBottom.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("错误代码：5322-逐行统计下表格数据错误！" + ex.Message, "核销单温馨提示：");
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
        /// 保存按钮函数
        /// </summary>
        private void Save()
        {
            if (isNUllValidate() == false)
            {
                return;
            }
            ///核销单
            FinanceVerificationMain financeVerification = new FinanceVerificationMain();
            //核销单详细列表
            List<FinanceVerificationDetail> financeVerificationList = new List<FinanceVerificationDetail>();

            #region 核销单基本数据
            try
            {
                financeVerification.code = XYEEncoding.strCodeHex(validateCode());//核销单单号
                if (cboHeXiaoType.Text != null || cboHeXiaoType.Text.Trim() != "")
                {
                    financeVerification.verificationType = XYEEncoding.strCodeHex(cboHeXiaoType.Text);//核销类型
                }
                else
                {
                    MessageBox.Show("核销类型不能为空！请选择");
                    cboHeXiaoType.Focus();
                    return;
                }

                #region 根据核销类型判断是否为空

                switch (cboHeXiaoType.Text)
                {
                    case "预收冲应收":
                        if (labtextboxTop2.Text.Trim() != "")
                        {
                            financeVerification.outClientCode = XYEEncoding.strCodeHex(_clientCode);
                        }
                        else
                        {
                            MessageBox.Show("客户不能为空！请选择");
                            labtextboxTop2.Focus();
                            return;
                        }
                        break;
                    case "预付冲应付":
                        if (labtextboxTop5.Text.Trim() != "")
                        {
                            financeVerification.outSupplierCode = XYEEncoding.strCodeHex(_supplierCode);
                        }
                        else
                        {
                            MessageBox.Show("供应商不能为空！请选择");
                            labtextboxTop5.Focus();
                            return;
                        }
                        break;
                    case "应收冲应付":
                        if (labtextboxTop2.Text.Trim() != "")
                        {
                            financeVerification.outClientCode = XYEEncoding.strCodeHex(_clientCode);
                        }
                        else
                        {
                            MessageBox.Show("客户不能为空！请选择");
                            labtextboxTop2.Focus();
                            return;
                        }
                        if (labtextboxTop5.Text.Trim() != "")
                        {
                            financeVerification.outSupplierCode = XYEEncoding.strCodeHex(_supplierCode);
                        }
                        else
                        {
                            MessageBox.Show("供应商不能为空！请选择");
                            labtextboxTop5.Focus();
                            return;
                        }
                        break;
                    case "应收转应收":
                        if (labtextboxTop2.Text.Trim() != "")
                        {
                            financeVerification.outClientCode = XYEEncoding.strCodeHex(_clientCode);
                        }
                        else
                        {
                            MessageBox.Show("转出客户不能为空！请选择");
                            labtextboxTop2.Focus();
                            return;
                        }
                        if (labtextboxTop7.Text.Trim() != "")
                        {
                            financeVerification.inClientCode = XYEEncoding.strCodeHex(_clientCodeIn);
                        }
                        else
                        {
                            MessageBox.Show("转入客户不能为空！请选择");
                            labtextboxTop7.Focus();
                            return;
                        }
                        break;
                    case "应付转应付":
                        if (labtextboxTop5.Text.Trim() != "")
                        {
                            financeVerification.outSupplierCode = XYEEncoding.strCodeHex(_supplierCode);
                        }
                        else
                        {
                            MessageBox.Show("转出供应商不能为空！请选择");
                            labtextboxTop5.Focus();
                            return;
                        }
                        if (labtextboxTop4.Text.Trim() != "")
                        {
                            financeVerification.inSupplierCode = XYEEncoding.strCodeHex(_supplierCodeIn);
                        }
                        else
                        {
                            MessageBox.Show("转入供应商不能为空！请选择");
                            labtextboxTop4.Focus();
                            return;
                        }
                        break;
                }
                #endregion

                if (ltxtbSalsMan.Text != null || ltxtbSalsMan.Text.Trim() != "")
                {
                    financeVerification.salesMan = XYEEncoding.strCodeHex(ltxtbSalsMan.Text.Trim());//核销员
                }
                else
                {
                    MessageBox.Show("核销员不能为空！请选择");
                    ltxtbSalsMan.Focus();
                    return;
                }
                financeVerification.date = this.dateTimePicker1.Value;//开单日期
                financeVerification.description = XYEEncoding.strCodeHex(labtextboxTop6.Text == null ? "" : labtextboxTop6.Text.Trim());//说明
                financeVerification.summary = XYEEncoding.strCodeHex(labtextboxTop3.Text == null ? "" : labtextboxTop3.Text.Trim());//摘要
                financeVerification.operators = XYEEncoding.strCodeHex(ltxtbMakeMan.Text == null ? "" : ltxtbMakeMan.Text.Trim());//制单人
                financeVerification.auditors = XYEEncoding.strCodeHex(ltxtbShengHeMan.Text == null ? "" : ltxtbShengHeMan.Text.Trim());//审核人
                financeVerification.departmentCode = "";
                financeVerification.checkState = 0;//审核状态
            }
            catch (Exception ex)
            {
                MessageBox.Show("错误代码:5323-尝试创建核销单基本数据出错!请检查:" + ex.Message, "核销单温馨提示");
                return;
            }
            #endregion

            #region 核销单上表格详细数据
            try
            {
                //获得商品列表数据,准备传给base层新增数据
                GridRow g = (GridRow)superGridControlTop.PrimaryGrid.Rows[ClickRowIndex];
                GridItemsCollection grs = superGridControlTop.PrimaryGrid.Rows;
                int i = 0;
                DateTime nowDataTime = DateTime.Now;
                foreach (GridRow gr in grs)
                {
                    if (gr["gridColumnYuanDanCode"].Value != null)
                    {
                        i++;
                        FinanceVerificationDetail financeverificationDetail = new FinanceVerificationDetail();
                        if (gr.Cells["gridColumnYuanDanCode"].Value != null || gr.Cells["gridColumnYuanDanCode"].Value.ToString() != "")
                        {
                            financeverificationDetail.sourceCode = XYEEncoding.strCodeHex(gr.Cells["gridColumnYuanDanCode"].Value);
                        }
                        else
                        {
                            MessageBox.Show("单据体上表格源单编号不能为空！");
                            superGridControlTop.Focus();
                            return;
                        }
                        financeverificationDetail.mainCode = XYEEncoding.strCodeHex(textBoxOddNumbers.Text);//主表code
                        financeverificationDetail.code = XYEEncoding.strCodeHex(_financeVerificationCode + i.ToString());
                        financeverificationDetail.sourceType = XYEEncoding.strCodeHex(gr.Cells["gridColumnYuanDanType"].Value == null ? "" : gr.Cells["gridColumnYuanDanType"].Value.ToString());//源单类型
                        financeverificationDetail.date = Convert.ToDateTime(gr.Cells["gridColumnYuanDanDate"].Value);//单据日期
                        financeverificationDetail.sourceAmount = Convert.ToDecimal(gr.Cells["gridColumnDanJuMoney"].Value.ToString() == "" ? 0.0M : gr.Cells["gridColumnDanJuMoney"].Value);//单据金额
                        financeverificationDetail.alreadyVerificationAmount = Convert.ToDecimal(gr.Cells["gridColumnYiHeXiao"].Value.ToString() == "" ? 0.0M : gr.Cells["gridColumnYiHeXiao"].Value);//已核销金额
                        financeverificationDetail.notVerificationAmount = Convert.ToDecimal(gr.Cells["gridColumnWeiHeXiao"].Value.ToString() == "" ? 0.0M : gr.Cells["gridColumnWeiHeXiao"].Value);//未核销金额  
                        financeverificationDetail.theVerificationAmount = Convert.ToDecimal(gr.Cells["gridColumnBenCi"].Value.ToString() == "" ? 0.0M : gr.Cells["gridColumnBenCi"].Value);//本次核销
                        financeverificationDetail.remark = XYEEncoding.strCodeHex(gr.Cells["gridColumnRemark"].Value == null ? "" : gr.Cells["gridColumnRemark"].Value.ToString());//备注

                        GridRow dr = superGridControlTop.PrimaryGrid.Rows[0] as GridRow;
                        financeVerificationList.Add(financeverificationDetail);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("错误代码：5324-尝试创建核销单上表格数据错误！请检查：" + ex.Message, "核销单温馨提示！");
            }
            #endregion

            #region 核销单下表格详细数据
            try
            {
                //获得商品列表数据,准备传给base层新增数据
                GridRow g = (GridRow)superGridControlShangPing.PrimaryGrid.Rows[ClickRowIndex];
                GridItemsCollection grs = superGridControlShangPing.PrimaryGrid.Rows;
                int i = 0;
                DateTime nowDataTime = DateTime.Now;
                foreach (GridRow gr in grs)
                {
                    if (gr["yuanDanCode"].Value != null)
                    {
                        i++;
                        FinanceVerificationDetail financeverificationDetail = new FinanceVerificationDetail();
                        if (gr.Cells["yuanDanCode"].Value != null || gr.Cells["yuanDanCode"].Value.ToString() != "")
                        {
                            financeverificationDetail.sourceCode = XYEEncoding.strCodeHex(gr.Cells["yuanDanCode"].Value);
                        }
                        else
                        {
                            MessageBox.Show("单据体下表格源单编号不能为空！");
                            superGridControlShangPing.Focus();
                            return;
                        }
                        financeverificationDetail.sourceType = XYEEncoding.strCodeHex(gr.Cells["yuanDanType"].Value == null ? "" : gr.Cells["yuanDanType"].Value.ToString());//源单类型
                        financeverificationDetail.date = Convert.ToDateTime(gr.Cells["danJuDate"].Value);//单据日期
                        financeverificationDetail.sourceAmount = Convert.ToDecimal(gr.Cells["danJuMoney"].Value.ToString() == "" ? 0.0M : gr.Cells["danJuMoney"].Value);//单据金额
                        financeverificationDetail.alreadyVerificationAmount = Convert.ToDecimal(gr.Cells["yiHeXiao"].Value.ToString() == "" ? 0.0M : gr.Cells["yiHeXiao"].Value);//已核销金额
                        financeverificationDetail.notVerificationAmount = Convert.ToDecimal(gr.Cells["weiHeXiao"].Value.ToString() == "" ? 0.0M : gr.Cells["weiHeXiao"].Value);//未核销金额  
                        financeverificationDetail.theVerificationAmount = Convert.ToDecimal(gr.Cells["benCiHeXiao"].Value.ToString() == "" ? 0.0M : gr.Cells["benCiHeXiao"].Value);//本次核销
                        financeverificationDetail.remark = XYEEncoding.strCodeHex(gr.Cells["remark"].Value == null ? "" : gr.Cells["remark"].Value.ToString());//备注

                        GridRow dr = superGridControlShangPing.PrimaryGrid.Rows[0] as GridRow;
                        financeVerificationList.Add(financeverificationDetail);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("错误代码：5325-尝试创建核销单下表格数据错误！请检查：" + ex.Message, "核销单温馨提示！");
            }
            #endregion

            //增加核销单和核销单详细数据
            object financeVerificationResult = financeVerificationInterface.AddOrUpdateToMainOrDetail(financeVerification, financeVerificationList);
            if (financeVerificationResult != null)
            {
                MessageBox.Show("新增核销单数据成功！");
            }
        }

        /// <summary>
        /// 验证单号是否重复
        /// </summary>
        /// <returns></returns>
        private string validateCode()
        {
            if (financeVerificationInterface.Exists(XYEEncoding.strCodeHex(_financeVerificationCode)))
            {
                _financeVerificationCode = BuildCode.ModuleCode("FVC");
            }
            else
            {
                _financeVerificationCode = textBoxOddNumbers.Text;
            }
            return _financeVerificationCode;
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
                Review();
                InitForm();
            }
        }

        /// <summary>
        /// 审核按钮函数
        /// </summary>
        private void Review()
        {
            if (isNUllValidate() == false)
            {
                return;
            }
            ///核销单
            FinanceVerificationMain financeVerification = new FinanceVerificationMain();
            //核销单详细列表
            List<FinanceVerificationDetail> financeVerificationList = new List<FinanceVerificationDetail>();

            #region 核销单基本数据
            try
            {
                financeVerification.code = XYEEncoding.strCodeHex(validateCode());//核销单单号
                if (cboHeXiaoType.Text != null || cboHeXiaoType.Text.Trim() != "")
                {
                    financeVerification.verificationType = XYEEncoding.strCodeHex(cboHeXiaoType.Text);//核销类型
                }
                else
                {
                    MessageBox.Show("核销类型不能为空！请选择");
                    cboHeXiaoType.Focus();
                    return;
                }

                #region 根据核销类型判断是否为空

                switch (cboHeXiaoType.Text)
                {
                    case "预收冲应收":
                        if (labtextboxTop2.Text.Trim() != "")
                        {
                            financeVerification.outClientCode = XYEEncoding.strCodeHex(_clientCode);
                        }
                        else
                        {
                            MessageBox.Show("客户不能为空！请选择");
                            labtextboxTop2.Focus();
                            return;
                        }
                        break;
                    case "预付冲应付":
                        if (labtextboxTop5.Text.Trim() != "")
                        {
                            financeVerification.outSupplierCode = XYEEncoding.strCodeHex(_supplierCode);
                        }
                        else
                        {
                            MessageBox.Show("供应商不能为空！请选择");
                            labtextboxTop5.Focus();
                            return;
                        }
                        break;
                    case "应收冲应付":
                        if (labtextboxTop2.Text.Trim() != "")
                        {
                            financeVerification.outClientCode = XYEEncoding.strCodeHex(_clientCode);
                        }
                        else
                        {
                            MessageBox.Show("客户不能为空！请选择");
                            labtextboxTop2.Focus();
                            return;
                        }
                        if (labtextboxTop5.Text.Trim() != "")
                        {
                            financeVerification.outSupplierCode = XYEEncoding.strCodeHex(_supplierCode);
                        }
                        else
                        {
                            MessageBox.Show("供应商不能为空！请选择");
                            labtextboxTop5.Focus();
                            return;
                        }
                        break;
                    case "应收转应收":
                        if (labtextboxTop2.Text.Trim() != "")
                        {
                            financeVerification.outClientCode = XYEEncoding.strCodeHex(_clientCode);
                        }
                        else
                        {
                            MessageBox.Show("转出客户不能为空！请选择");
                            labtextboxTop2.Focus();
                            return;
                        }
                        if (labtextboxTop7.Text.Trim() != "")
                        {
                            financeVerification.inClientCode = XYEEncoding.strCodeHex(_clientCodeIn);
                        }
                        else
                        {
                            MessageBox.Show("转入客户不能为空！请选择");
                            labtextboxTop7.Focus();
                            return;
                        }
                        break;
                    case "应付转应付":
                        if (labtextboxTop5.Text.Trim() != "")
                        {
                            financeVerification.outSupplierCode = XYEEncoding.strCodeHex(_supplierCode);
                        }
                        else
                        {
                            MessageBox.Show("转出供应商不能为空！请选择");
                            labtextboxTop5.Focus();
                            return;
                        }
                        if (labtextboxTop4.Text.Trim() != "")
                        {
                            financeVerification.inSupplierCode = XYEEncoding.strCodeHex(_supplierCodeIn);
                        }
                        else
                        {
                            MessageBox.Show("转入供应商不能为空！请选择");
                            labtextboxTop4.Focus();
                            return;
                        }
                        break;
                }
                #endregion

                if (ltxtbSalsMan.Text != null || ltxtbSalsMan.Text.Trim() != "")
                {
                    financeVerification.salesMan = XYEEncoding.strCodeHex(ltxtbSalsMan.Text.Trim());//核销员
                }
                else
                {
                    MessageBox.Show("核销员不能为空！请选择");
                    ltxtbSalsMan.Focus();
                    return;
                }
                financeVerification.date = this.dateTimePicker1.Value;//开单日期
                financeVerification.description = XYEEncoding.strCodeHex(labtextboxTop6.Text == null ? "" : labtextboxTop6.Text.Trim());//说明
                financeVerification.summary = XYEEncoding.strCodeHex(labtextboxTop3.Text == null ? "" : labtextboxTop3.Text.Trim());//摘要
                financeVerification.operators = XYEEncoding.strCodeHex(ltxtbMakeMan.Text == null ? "" : ltxtbMakeMan.Text.Trim());//制单人
                financeVerification.auditors = XYEEncoding.strCodeHex(ltxtbShengHeMan.Text == null ? "" : ltxtbShengHeMan.Text.Trim());//审核人
                financeVerification.departmentCode = "";
                financeVerification.checkState = 1;//审核状态
            }
            catch (Exception ex)
            {
                MessageBox.Show("错误代码:5326-尝试创建并审核核销单数据出错!请检查:" + ex.Message, "核销单温馨提示");
                return;
            }
            #endregion

            #region 核销单上表格详细数据
            try
            {
                //获得商品列表数据,准备传给base层新增数据
                GridRow g = (GridRow)superGridControlTop.PrimaryGrid.Rows[ClickRowIndex];
                GridItemsCollection grs = superGridControlTop.PrimaryGrid.Rows;
                int i = 0;
                DateTime nowDataTime = DateTime.Now;
                foreach (GridRow gr in grs)
                {
                    if (gr["gridColumnYuanDanCode"].Value != null)
                    {
                        i++;
                        FinanceVerificationDetail financeverificationDetail = new FinanceVerificationDetail();
                        if (gr.Cells["gridColumnYuanDanCode"].Value != null || gr.Cells["gridColumnYuanDanCode"].Value.ToString() != "")
                        {
                            financeverificationDetail.sourceCode = XYEEncoding.strCodeHex(gr.Cells["gridColumnYuanDanCode"].Value);
                        }
                        else
                        {
                            MessageBox.Show("单据体上表格源单编号不能为空！");
                            superGridControlTop.Focus();
                            return;
                        }
                        financeverificationDetail.mainCode = XYEEncoding.strCodeHex(textBoxOddNumbers.Text);//主表code
                        financeverificationDetail.code = XYEEncoding.strCodeHex(_financeVerificationCode + i.ToString());
                        financeverificationDetail.sourceType = XYEEncoding.strCodeHex(gr.Cells["gridColumnYuanDanType"].Value == null ? "" : gr.Cells["gridColumnYuanDanType"].Value.ToString());//源单类型
                        financeverificationDetail.date = Convert.ToDateTime(gr.Cells["gridColumnYuanDanDate"].Value);//单据日期
                        financeverificationDetail.sourceAmount = Convert.ToDecimal(gr.Cells["gridColumnDanJuMoney"].Value.ToString() == "" ? 0.0M : gr.Cells["gridColumnDanJuMoney"].Value);//单据金额
                        financeverificationDetail.alreadyVerificationAmount = Convert.ToDecimal(gr.Cells["gridColumnYiHeXiao"].Value.ToString() == "" ? 0.0M : gr.Cells["gridColumnYiHeXiao"].Value);//已核销金额
                        financeverificationDetail.notVerificationAmount = Convert.ToDecimal(gr.Cells["gridColumnWeiHeXiao"].Value.ToString() == "" ? 0.0M : gr.Cells["gridColumnWeiHeXiao"].Value);//未核销金额  
                        financeverificationDetail.theVerificationAmount = Convert.ToDecimal(gr.Cells["gridColumnBenCi"].Value.ToString() == "" ? 0.0M : gr.Cells["gridColumnBenCi"].Value);//本次核销
                        financeverificationDetail.remark = XYEEncoding.strCodeHex(gr.Cells["gridColumnRemark"].Value == null ? "" : gr.Cells["gridColumnRemark"].Value.ToString());//备注

                        GridRow dr = superGridControlTop.PrimaryGrid.Rows[0] as GridRow;
                        financeVerificationList.Add(financeverificationDetail);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("错误代码：5327-尝试创建并审核核销单上表格数据错误！请检查：" + ex.Message, "核销单温馨提示！");
            }
            #endregion

            #region 核销单下表格详细数据
            try
            {
                //获得商品列表数据,准备传给base层新增数据
                GridRow g = (GridRow)superGridControlShangPing.PrimaryGrid.Rows[ClickRowIndex];
                GridItemsCollection grs = superGridControlShangPing.PrimaryGrid.Rows;
                int i = 0;
                DateTime nowDataTime = DateTime.Now;
                foreach (GridRow gr in grs)
                {
                    if (gr["yuanDanCode"].Value != null)
                    {
                        i++;
                        FinanceVerificationDetail financeverificationDetail = new FinanceVerificationDetail();
                        if (gr.Cells["yuanDanCode"].Value != null || gr.Cells["yuanDanCode"].Value.ToString() != "")
                        {
                            financeverificationDetail.sourceCode = XYEEncoding.strCodeHex(gr.Cells["yuanDanCode"].Value);
                        }
                        else
                        {
                            MessageBox.Show("单据体下表格源单编号不能为空！");
                            superGridControlShangPing.Focus();
                            return;
                        }
                        financeverificationDetail.sourceType = XYEEncoding.strCodeHex(gr.Cells["yuanDanType"].Value == null ? "" : gr.Cells["yuanDanType"].Value.ToString());//源单类型
                        financeverificationDetail.date = Convert.ToDateTime(gr.Cells["danJuDate"].Value);//单据日期
                        financeverificationDetail.sourceAmount = Convert.ToDecimal(gr.Cells["danJuMoney"].Value.ToString() == "" ? 0.0M : gr.Cells["danJuMoney"].Value);//单据金额
                        financeverificationDetail.alreadyVerificationAmount = Convert.ToDecimal(gr.Cells["yiHeXiao"].Value.ToString() == "" ? 0.0M : gr.Cells["yiHeXiao"].Value);//已核销金额
                        financeverificationDetail.notVerificationAmount = Convert.ToDecimal(gr.Cells["weiHeXiao"].Value.ToString() == "" ? 0.0M : gr.Cells["weiHeXiao"].Value);//未核销金额 
                        financeverificationDetail.theVerificationAmount = Convert.ToDecimal(gr.Cells["benCiHeXiao"].Value.ToString() == "" ? 0.0M : gr.Cells["benCiHeXiao"].Value);//本次核销 
                        financeverificationDetail.remark = XYEEncoding.strCodeHex(gr.Cells["remark"].Value == null ? "" : gr.Cells["remark"].Value.ToString());//备注

                        GridRow dr = superGridControlShangPing.PrimaryGrid.Rows[0] as GridRow;
                        financeVerificationList.Add(financeverificationDetail);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("错误代码：5328-尝试创建并审核核销单下表格数据错误！请检查：" + ex.Message, "核销单温馨提示！");
            }
            #endregion

            //增加核销单和核销单详细数据
            object financeVerificationResult = financeVerificationInterface.AddOrUpdateToMainOrDetail(financeVerification, financeVerificationList);
            if (financeVerificationResult != null)
            {
                MessageBox.Show("新增并审核核销单数据成功！");
            }
        }
    }
}

