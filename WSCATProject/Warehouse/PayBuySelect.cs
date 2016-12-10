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
using DevComponents.DotNetBar.SuperGrid;
using HelperUtility.Encrypt;
using InterfaceLayer;
using InterfaceLayer.Warehouse;
using BaseLayer;
using WSCATProject.Warehouse;

namespace WSCATProject.Buys
{
    public partial class PayBuySelect : Form
    {
        //BuyManager bm = new BuyManager();
        //SellManager sm = new SellManager();
        //ConllectionWaitManager cwm = new ConllectionWaitManager();
        WarehouseInInterface ware = new WarehouseInInterface();
        DataTable dt = null;
        CodingHelper ch = new CodingHelper();
        public string whereField;
        public string orderField;
        private string _selectForm;//判断窗体选中的列表
        //判断窗体选中的列表
        public string SelectForm
        {
            get { return _selectForm; }
            set { _selectForm = value; }
        }

        public PayBuySelect()
        {
            InitializeComponent();

            this.toolStrip1.Items.Insert(8, new ToolStripControlHost(dateTimePicker1));
            this.toolStrip1.Items.Insert(7, new ToolStripControlHost(dateTimePicker2));
            今天ToolStripMenuItem.Click += ToolStripMenuDateTimeItem_Click;
            本周ToolStripMenuItem.Click += ToolStripMenuDateTimeItem_Click;
            上周ToolStripMenuItem.Click += ToolStripMenuDateTimeItem_Click;
            本月ToolStripMenuItem.Click += ToolStripMenuDateTimeItem_Click;
            上月ToolStripMenuItem.Click += ToolStripMenuDateTimeItem_Click;
            本年ToolStripMenuItem.Click += ToolStripMenuDateTimeItem_Click;
            上年ToolStripMenuItem.Click += ToolStripMenuDateTimeItem_Click;
            全部ToolStripMenuItem.Click += ToolStripMenuDateTimeItem_Click;

            今天ToolStripMenuItem1.Click += ToolStripMenuDateTimeItem_Click;
            本周ToolStripMenuItem1.Click += ToolStripMenuDateTimeItem_Click;
            上周ToolStripMenuItem1.Click += ToolStripMenuDateTimeItem_Click;
            本月ToolStripMenuItem1.Click += ToolStripMenuDateTimeItem_Click;
            上月ToolStripMenuItem1.Click += ToolStripMenuDateTimeItem_Click;
            本年ToolStripMenuItem1.Click += ToolStripMenuDateTimeItem_Click;
            上年ToolStripMenuItem1.Click += ToolStripMenuDateTimeItem_Click;
            全部ToolStripMenuItem1.Click += ToolStripMenuDateTimeItem_Click;

            dateTimePicker1.ValueChanged += DateTimePicker1_ValueChanged;
            dateTimePicker2.ValueChanged += DateTimePicker1_ValueChanged;
        }


        private void DateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                string startDate = dateTimePicker1.Value.ToString();
                string stopDate = dateTimePicker2.Value.ToString();
                superGridControl1.PrimaryGrid.DataSource = WhereDateBetween(dt, whereField, startDate, stopDate, orderField);
            }
            catch (Exception ex)
            {
                MessageBox.Show("错误代码:3215-业务查找：采购单数据加载时异常，异常信息：" + ex.Message);
            }
        }
        #region 日期范围查询公用函数
        /// <summary>
        /// 日期范围查询公用函数   
        /// </summary>
        /// <param name="dt">筛选数据源</param>
        /// <param name="stratWeek">开始日期</param>
        /// <param name="stopWeek">结束日期</param>
        /// <returns></returns>
        private static DataTable WhereDateBetween(DataTable dt, string whereField, string stratWeek, string stopWeek, string orderField)
        {
            if (dt == null)
            {
                MessageBox.Show("列表为空!");
            }
            else
            {
                DataRow[] dr = dt.Select(string.Format("{0}>'{1}' and {0}<'{2}'", whereField, stratWeek, stopWeek), orderField);
                DataTable dtNew = dt.Clone();
                foreach (DataRow item in dr)
                {
                    dtNew.ImportRow(item);
                }
                dt = dtNew;
            }
            return dt;
        }
        #endregion
        /// <summary>
        /// 日期范围筛选公用事件  
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToolStripMenuDateTimeItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem tsmi = (ToolStripMenuItem)sender;
            int dayofweek = Convert.ToInt32(DateTime.Now.DayOfWeek);
            string stratWeek;
            string stopWeek;
            try
            {
                switch (tsmi.Text)
                {
                    case "今天":
                        stratWeek = DateTime.Now.AddDays(dayofweek - 2).ToShortDateString();
                        stopWeek = DateTime.Now.AddDays(dayofweek).ToShortDateString();
                        superGridControl1.PrimaryGrid.DataSource = WhereDateBetween(dt, whereField, stratWeek, stopWeek, orderField);
                        break;
                    case "本周":
                        //本周开始日期
                        stratWeek = DateTime.Now.AddDays(1 - dayofweek).ToShortDateString();
                        //结束日期
                        stopWeek = DateTime.Now.AddDays(6 - dayofweek + 1).ToShortDateString();
                        superGridControl1.PrimaryGrid.DataSource = WhereDateBetween(dt, whereField, stratWeek, stopWeek, orderField);
                        break;
                    case "上周":
                        stratWeek = DateTime.Now.AddDays(1 - dayofweek - 7).ToShortDateString();
                        stopWeek = DateTime.Now.AddDays(1 - dayofweek - 7).AddDays(6).ToShortDateString();
                        superGridControl1.PrimaryGrid.DataSource = WhereDateBetween(dt, whereField, stratWeek, stopWeek, orderField);
                        break;
                    case "本月":
                        stratWeek = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-01")).AddMonths(0).ToShortDateString();
                        stopWeek = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-01")).AddMonths(1).AddDays(-1).ToShortDateString();
                        superGridControl1.PrimaryGrid.DataSource = WhereDateBetween(dt, whereField, stratWeek, stopWeek, orderField);
                        break;
                    case "上月":
                        stratWeek = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-01")).AddMonths(-1).ToShortDateString();
                        stopWeek = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-01")).AddDays(-1).ToShortDateString();
                        superGridControl1.PrimaryGrid.DataSource = WhereDateBetween(dt, whereField, stratWeek, stopWeek, orderField);
                        break;
                    case "本年":
                        stratWeek = DateTime.Parse(DateTime.Now.ToString("yyyy-01-01")).ToShortDateString();
                        stopWeek = DateTime.Parse(DateTime.Now.ToString("yyyy-01-01")).AddYears(1).AddDays(-1).ToShortDateString();
                        superGridControl1.PrimaryGrid.DataSource = WhereDateBetween(dt, whereField, stratWeek, stopWeek, orderField);
                        break;
                    case "上年":
                        stratWeek = DateTime.Parse(DateTime.Now.ToString("yyyy-01-01")).AddYears(-1).ToShortDateString();
                        stopWeek = DateTime.Parse(DateTime.Now.ToString("yyyy-01-01")).AddDays(-1).ToShortDateString();
                        superGridControl1.PrimaryGrid.DataSource = WhereDateBetween(dt, whereField, stratWeek, stopWeek, orderField);
                        break;
                    case "全部":
                        superGridControl1.PrimaryGrid.DataSource = dt;
                        break;
                    default:
                        MessageBox.Show("选择错误！");
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("错误代码:3216-业务查找：采购单日期筛选异常，异常信息：" + ex.Message);
            }
        }
        /// <summary>
        /// 窗体加载事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PayBuySelect_Load(object sender, EventArgs e)
        {
            superGridControl1.PrimaryGrid.AutoGenerateColumns = false;
            superGridControl1.PrimaryGrid.SelectionGranularity = SelectionGranularity.Row;
            superGridControl1.PrimaryGrid.InitialSelection = RelativeSelection.None;
            superGridControl1.PrimaryGrid.FocusCuesEnabled = false;
            superGridControl1.PrimaryGrid.ActiveRowIndicatorStyle = ActiveRowIndicatorStyle.None;
            toolStripComboBox1.SelectedIndex = 0;
            // toolStripComboBox2.SelectedIndex = 0;
            GridColumn gc = null;
            switch (_selectForm)
            {
                case "采购开单":
                    superGridControl1.PrimaryGrid.DataSource = null;
                    superGridControl1.PrimaryGrid.Columns.Clear();
                    try
                    {
                        #region 初始化采购开单列
                        gc = new GridColumn();
                        gc.DataPropertyName = "ID";
                        gc.Name = "ColumnsID";
                        gc.HeaderText = "ID";
                        superGridControl1.PrimaryGrid.Columns.Add(gc);

                        gc = new GridColumn();
                        gc.DataPropertyName = "编号";
                        gc.Name = "ColumnsCode";
                        gc.HeaderText = "编号";
                        superGridControl1.PrimaryGrid.Columns.Add(gc);

                        gc = new GridColumn();
                        gc.DataPropertyName = "单据日期";
                        gc.Name = "ColumnsDate";
                        gc.HeaderText = "单据日期";
                        superGridControl1.PrimaryGrid.Columns.Add(gc);

                        gc = new GridColumn();
                        gc.DataPropertyName = "审核状态";
                        gc.Name = "ColumnsAuditStatus";
                        gc.HeaderText = "审核状态";
                        superGridControl1.PrimaryGrid.Columns.Add(gc);

                        gc = new GridColumn();
                        gc.DataPropertyName = "单据状态";
                        gc.Name = "ColumnsPurchaseStatus";
                        gc.HeaderText = "单据状态";
                        superGridControl1.PrimaryGrid.Columns.Add(gc);

                        gc = new GridColumn();
                        gc.DataPropertyName = "供应商";
                        gc.Name = "ColumnsSuName";
                        gc.HeaderText = "供应商";
                        superGridControl1.PrimaryGrid.Columns.Add(gc);

                        gc = new GridColumn();
                        gc.DataPropertyName = "结算账户";
                        gc.Name = "ColumnsBank";
                        gc.HeaderText = "结算账户";
                        superGridControl1.PrimaryGrid.Columns.Add(gc);

                        gc = new GridColumn();
                        gc.DataPropertyName = "总金额";
                        gc.Name = "ColumnsAmountMone";
                        gc.HeaderText = "总金额";
                        superGridControl1.PrimaryGrid.Columns.Add(gc);

                        gc = new GridColumn();
                        gc.DataPropertyName = "业务员";
                        gc.Name = "ColumnsSalesMan";
                        gc.HeaderText = "业务员";
                        superGridControl1.PrimaryGrid.Columns.Add(gc);

                        gc = new GridColumn();
                        gc.DataPropertyName = "备注";
                        gc.Name = "ColumnsRemark";
                        gc.HeaderText = "备注";
                        superGridControl1.PrimaryGrid.Columns.Add(gc);

                        //dt = bm.SelBuyDataTableToCheck();
                        //superGridControl1.PrimaryGrid.DataSource = dt;
                        //whereField = "单据日期";
                        //orderField = "ID";
                        #endregion
                        MessageBox.Show("列表为空！");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("错误代码:3218-采购业务查找：采购单加载全部数据异常，异常信息：" + ex.Message);
                    }
                    break;
                case "销售开单":
                    superGridControl1.PrimaryGrid.DataSource = null;
                    superGridControl1.PrimaryGrid.Columns.Clear();

                    try
                    {
                        #region 初始化销售开单列
                        gc = new GridColumn();
                        gc.DataPropertyName = "Sell_ID";
                        gc.Name = "Sell_ID";
                        gc.HeaderText = "ID";
                        gc.Visible = true;
                        superGridControl1.PrimaryGrid.Columns.Add(gc);

                        gc = new GridColumn();
                        gc.DataPropertyName = "Sell_Type";
                        gc.Name = "Sell_Type";
                        gc.HeaderText = "单据类型";
                        gc.Visible = true;
                        superGridControl1.PrimaryGrid.Columns.Add(gc);

                        gc = new GridColumn();
                        gc.DataPropertyName = "Sell_Code";
                        gc.Name = "Sell_Code";
                        gc.HeaderText = "编号";
                        gc.Visible = true;
                        superGridControl1.PrimaryGrid.Columns.Add(gc);

                        gc = new GridColumn();
                        gc.DataPropertyName = "Sell_Date";
                        gc.Name = "Sell_Date";
                        gc.HeaderText = "单据日期";
                        gc.Visible = true;
                        superGridControl1.PrimaryGrid.Columns.Add(gc);

                        gc = new GridColumn();
                        gc.DataPropertyName = "Sell_Review";
                        gc.Name = "Sell_Review";
                        gc.HeaderText = "审核状态";
                        gc.Visible = true;
                        superGridControl1.PrimaryGrid.Columns.Add(gc);

                        gc = new GridColumn();
                        gc.DataPropertyName = "Sell_OddStatus";
                        gc.Name = "Sell_OddStatus";
                        gc.HeaderText = "单据状态";
                        gc.Visible = true;
                        superGridControl1.PrimaryGrid.Columns.Add(gc);

                        gc = new GridColumn();
                        gc.DataPropertyName = "Sell_ClientName";
                        gc.Name = "Sell_ClientName";
                        gc.HeaderText = "客户";
                        gc.Visible = true;
                        superGridControl1.PrimaryGrid.Columns.Add(gc);

                        gc = new GridColumn();
                        gc.DataPropertyName = "Sell_AccountCode";
                        gc.Name = "Sell_AccountCode";
                        gc.HeaderText = "收款账户";
                        gc.Visible = true;
                        superGridControl1.PrimaryGrid.Columns.Add(gc);

                        gc = new GridColumn();
                        gc.DataPropertyName = "Sell_OddMoney";
                        gc.Name = "Sell_OddMoney";
                        gc.HeaderText = "总金额";
                        gc.Visible = true;
                        superGridControl1.PrimaryGrid.Columns.Add(gc);

                        gc = new GridColumn();
                        gc.DataPropertyName = "Sell_Salesman";
                        gc.Name = "Sell_Salesman";
                        gc.HeaderText = "业务员";
                        gc.Visible = true;
                        superGridControl1.PrimaryGrid.Columns.Add(gc);

                        gc = new GridColumn();
                        gc.DataPropertyName = "Sell_Remark";
                        gc.Name = "Sell_Remark";
                        gc.HeaderText = "备注";
                        gc.Visible = true;
                        superGridControl1.PrimaryGrid.Columns.Add(gc);



                        gc = new GridColumn();
                        gc.DataPropertyName = "Sell_PayMathod";
                        gc.Name = "Sell_PayMathod";
                        gc.HeaderText = "预收百分百";
                        gc.Visible = false;
                        superGridControl1.PrimaryGrid.Columns.Add(gc);

                        gc = new GridColumn();
                        gc.DataPropertyName = "Sell_InMoney";
                        gc.Name = "Sell_InMoney";
                        gc.HeaderText = "本次收款";
                        gc.Visible = false;
                        superGridControl1.PrimaryGrid.Columns.Add(gc);

                        gc = new GridColumn();
                        gc.DataPropertyName = "Sell_LastMoney";
                        gc.Name = "Sell_LastMoney";
                        gc.HeaderText = "剩余尾款";
                        gc.Visible = false;
                        superGridControl1.PrimaryGrid.Columns.Add(gc);

                        gc = new GridColumn();
                        gc.DataPropertyName = "Sell_TransportType";
                        gc.Name = "Sell_TransportType";
                        gc.HeaderText = "运输方式";
                        gc.Visible = false;
                        superGridControl1.PrimaryGrid.Columns.Add(gc);

                        gc = new GridColumn();
                        gc.DataPropertyName = "Sell_Operation";
                        gc.Name = "Sell_Operation";
                        gc.HeaderText = "制单人";
                        gc.Visible = false;
                        superGridControl1.PrimaryGrid.Columns.Add(gc);

                        gc = new GridColumn();
                        gc.DataPropertyName = "Sell_Auditman";
                        gc.Name = "Sell_Auditman";
                        gc.HeaderText = "审核人";
                        gc.Visible = false;
                        superGridControl1.PrimaryGrid.Columns.Add(gc);

                        gc = new GridColumn();
                        gc.DataPropertyName = "Sell_fukuanfangshi";
                        gc.Name = "Sell_fukuanfangshi";
                        gc.HeaderText = "收款方式";
                        gc.Visible = false;
                        superGridControl1.PrimaryGrid.Columns.Add(gc);

                        gc = new GridColumn();
                        gc.DataPropertyName = "Sell_Address";
                        gc.Name = "Sell_Address";
                        gc.HeaderText = "送货地址";
                        gc.Visible = false;
                        superGridControl1.PrimaryGrid.Columns.Add(gc);

                        gc = new GridColumn();
                        gc.DataPropertyName = "Sell_LinkMan";
                        gc.Name = "Sell_LinkMan";
                        gc.HeaderText = "联系人";
                        gc.Visible = false;
                        superGridControl1.PrimaryGrid.Columns.Add(gc);

                        gc = new GridColumn();
                        gc.DataPropertyName = "Sell_CliPhone";
                        gc.Name = "Sell_CliPhone";
                        gc.HeaderText = "联系电话";
                        gc.Visible = false;
                        superGridControl1.PrimaryGrid.Columns.Add(gc);

                        //dt = sm.GetList("");
                        //superGridControl1.PrimaryGrid.DataSource = dt;
                        //whereField = "单据日期";
                        //orderField = "ID";


                        #endregion
                        MessageBox.Show("列表为空！");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("错误代码:1219-销售业务查找：销售单加载全部数据异常，异常信息：" + ex.Message);
                    }
                    break;
                case "其他收货单":
                    break;
                case "其他发货单":
                    break;
                case "入库开单":
                    this.toolStripLabel8.Visible = true;
                    this.toolStripComboBox4.Visible = true;
                    this.toolStripComboBox2.Text = "入库开单";
                    this.toolStripComboBox4.Items.Clear();
                    this.toolStripComboBox4.Items.Add("采购申请单");
                    this.toolStripComboBox4.Items.Add("采购退货单");
                    this.toolStripComboBox4.Items.Add("赠商品入库");
                    this.toolStripComboBox4.Items.Add("获赔商品入库");
                    this.toolStripComboBox4.Items.Add("以货抵债");
                    BindWareHouesIn(0,"");
                    商品入库ToolStripMenuItem.Visible = true;
                    break;
                case "出库开单":
                    this.toolStripLabel8.Visible = true;
                    this.toolStripComboBox4.Visible = true;
                    this.toolStripComboBox2.Text = "出库开单";
                    this.toolStripComboBox4.Items.Clear();
                    this.toolStripComboBox4.Items.Add("销售申请单");
                    this.toolStripComboBox4.Items.Add("销售退货单");
                    this.toolStripComboBox4.Items.Add("销售补货单");
                    this.toolStripComboBox4.Items.Add("赠商品出库");
                    this.toolStripComboBox4.Items.Add("获赔商品出库");
                    BanDWareHouesOut(99,"");
                    商品出库ToolStripMenuItem.Visible = false;
                    break;
                case "领料单":
                    break;
                case "调拨单":
                    break;
                case "报损单":
                    break;
                case "盘点单":
                    break;
                case "调价单":
                    break;
                case "费用开支":
                    break;
                case "其他收入":
                    break;
                case "应付款单":
                    superGridControl1.PrimaryGrid.Columns.Clear();
                    //Band();
                    break;
                case "资金收款单":
                    superGridControl1.PrimaryGrid.Columns.Clear();
                    try
                    {
                        #region 初始化资金收款列     
                        gc = new GridColumn();
                        gc.DataPropertyName = "Sell_Code";
                        gc.Name = "ColumnsSellCode";
                        gc.HeaderText = "销售单号";
                        superGridControl1.PrimaryGrid.Columns.Add(gc);

                        gc = new GridColumn();
                        gc.DataPropertyName = "Sell_ClientName";
                        gc.Name = "ColumnsClientName";
                        gc.HeaderText = "客户";
                        superGridControl1.PrimaryGrid.Columns.Add(gc);

                        gc = new GridColumn();
                        gc.DataPropertyName = "Sell_Date";
                        gc.Name = "ColumnsDate";
                        gc.HeaderText = "单据日期";
                        superGridControl1.PrimaryGrid.Columns.Add(gc);

                        gc = new GridColumn();
                        gc.DataPropertyName = "Sell_Review";
                        gc.Name = "ColumnsReview";
                        gc.HeaderText = "审核状态";
                        superGridControl1.PrimaryGrid.Columns.Add(gc);

                        gc = new GridColumn();
                        gc.DataPropertyName = "Sell_IsPay";
                        gc.Name = "ColumnsIsPay";
                        gc.HeaderText = "收款状态";
                        superGridControl1.PrimaryGrid.Columns.Add(gc);

                        gc = new GridColumn();
                        gc.DataPropertyName = "Sell_fukuanfangshi";
                        gc.Name = "Columnsfukuanfangshi";
                        gc.HeaderText = "收款方式";
                        superGridControl1.PrimaryGrid.Columns.Add(gc);

                        gc = new GridColumn();
                        gc.DataPropertyName = "Sell_AccountCode";
                        gc.Name = "ColumnsAccountCode";
                        gc.HeaderText = "收款账户";
                        superGridControl1.PrimaryGrid.Columns.Add(gc);

                        gc = new GridColumn();
                        gc.DataPropertyName = "Sell_OddMoney";
                        gc.Name = "ColumnsSell_OddMoney";
                        gc.HeaderText = "本单总金额";
                        superGridControl1.PrimaryGrid.Columns.Add(gc);

                        gc = new GridColumn();
                        gc.DataPropertyName = "Sell_InMoney";
                        gc.Name = "ColumnsSell_InMoney";
                        gc.HeaderText = "本次收款";
                        gc.Visible = false;
                        superGridControl1.PrimaryGrid.Columns.Add(gc);

                        gc = new GridColumn();
                        gc.DataPropertyName = "Sell_LastMoney";
                        gc.Name = "ColumnsSell_LastMoney";
                        gc.HeaderText = "剩余尾款";
                        gc.Visible = false;
                        superGridControl1.PrimaryGrid.Columns.Add(gc);

                        gc = new GridColumn();
                        gc.DataPropertyName = "Sell_Salesman";
                        gc.Name = "ColumnsSalesMan";
                        gc.HeaderText = "业务员";
                        superGridControl1.PrimaryGrid.Columns.Add(gc);

                        gc = new GridColumn();
                        gc.DataPropertyName = "Sell_Operation";
                        gc.Name = "ColumnsSell_Operation";
                        gc.HeaderText = "制单人";
                        gc.Visible = false;
                        superGridControl1.PrimaryGrid.Columns.Add(gc);

                        gc = new GridColumn();
                        gc.DataPropertyName = "Sell_Auditman";
                        gc.Name = "ColumnsSell_Auditman";
                        gc.HeaderText = "审核人";
                        gc.Visible = false;
                        superGridControl1.PrimaryGrid.Columns.Add(gc);

                        gc = new GridColumn();
                        gc.DataPropertyName = "Sell_Remark";
                        gc.Name = "ColumnsRemark";
                        gc.HeaderText = "摘要";
                        superGridControl1.PrimaryGrid.Columns.Add(gc);

                        //dt = cwm.GetList();
                        //superGridControl1.PrimaryGrid.DataSource = dt;
                        //whereField = "单据日期";
                        //orderField = "ID";
                        #endregion
                        MessageBox.Show("列表为空！");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("错误代码:3230-资金收款业务查找：资金收款单加载全部数据异常，异常信息：" + ex.Message);
                    }

                    break;
                case "银行存取款":
                    break;
                case "资金拆借":
                    break;
                case "欠货发货单":
                    superGridControl1.PrimaryGrid.DataSource = null;
                    superGridControl1.PrimaryGrid.Columns.Clear();

                    try
                    {
                        #region 初始化欠货发货单列
                        gc = new GridColumn();
                        gc.DataPropertyName = "Sell_ID";
                        gc.Name = "Sell_ID";
                        gc.HeaderText = "ID";
                        gc.Visible = true;
                        superGridControl1.PrimaryGrid.Columns.Add(gc);

                        gc = new GridColumn();
                        gc.DataPropertyName = "Sell_Type";
                        gc.Name = "Sell_Type";
                        gc.HeaderText = "单据类型";
                        gc.Visible = true;
                        superGridControl1.PrimaryGrid.Columns.Add(gc);

                        gc = new GridColumn();
                        gc.DataPropertyName = "Sell_Code";
                        gc.Name = "Sell_Code";
                        gc.HeaderText = "编号";
                        gc.Visible = true;
                        superGridControl1.PrimaryGrid.Columns.Add(gc);

                        gc = new GridColumn();
                        gc.DataPropertyName = "Sell_Date";
                        gc.Name = "Sell_Date";
                        gc.HeaderText = "单据日期";
                        gc.Visible = true;
                        superGridControl1.PrimaryGrid.Columns.Add(gc);

                        gc = new GridColumn();
                        gc.DataPropertyName = "Sell_Review";
                        gc.Name = "Sell_Review";
                        gc.HeaderText = "审核状态";
                        gc.Visible = true;
                        superGridControl1.PrimaryGrid.Columns.Add(gc);

                        gc = new GridColumn();
                        gc.DataPropertyName = "Sell_OddStatus";
                        gc.Name = "Sell_OddStatus";
                        gc.HeaderText = "单据状态";
                        gc.Visible = true;
                        superGridControl1.PrimaryGrid.Columns.Add(gc);

                        gc = new GridColumn();
                        gc.DataPropertyName = "Sell_ClientName";
                        gc.Name = "Sell_ClientName";
                        gc.HeaderText = "客户";
                        gc.Visible = true;
                        superGridControl1.PrimaryGrid.Columns.Add(gc);

                        gc = new GridColumn();
                        gc.DataPropertyName = "Sell_AccountCode";
                        gc.Name = "Sell_AccountCode";
                        gc.HeaderText = "收款账户";
                        gc.Visible = true;
                        superGridControl1.PrimaryGrid.Columns.Add(gc);

                        gc = new GridColumn();
                        gc.DataPropertyName = "Sell_OddMoney";
                        gc.Name = "Sell_OddMoney";
                        gc.HeaderText = "总金额";
                        gc.Visible = true;
                        superGridControl1.PrimaryGrid.Columns.Add(gc);

                        gc = new GridColumn();
                        gc.DataPropertyName = "Sell_Salesman";
                        gc.Name = "Sell_Salesman";
                        gc.HeaderText = "业务员";
                        gc.Visible = true;
                        superGridControl1.PrimaryGrid.Columns.Add(gc);

                        gc = new GridColumn();
                        gc.DataPropertyName = "Sell_Remark";
                        gc.Name = "Sell_Remark";
                        gc.HeaderText = "备注";
                        gc.Visible = true;
                        superGridControl1.PrimaryGrid.Columns.Add(gc);

                        gc = new GridColumn();
                        gc.DataPropertyName = "Sell_PayMathod";
                        gc.Name = "Sell_PayMathod";
                        gc.HeaderText = "预收百分百";
                        gc.Visible = false;
                        superGridControl1.PrimaryGrid.Columns.Add(gc);

                        gc = new GridColumn();
                        gc.DataPropertyName = "Sell_InMoney";
                        gc.Name = "Sell_InMoney";
                        gc.HeaderText = "本次收款";
                        gc.Visible = false;
                        superGridControl1.PrimaryGrid.Columns.Add(gc);

                        gc = new GridColumn();
                        gc.DataPropertyName = "Sell_LastMoney";
                        gc.Name = "Sell_LastMoney";
                        gc.HeaderText = "剩余尾款";
                        gc.Visible = false;
                        superGridControl1.PrimaryGrid.Columns.Add(gc);

                        gc = new GridColumn();
                        gc.DataPropertyName = "Sell_TransportType";
                        gc.Name = "Sell_TransportType";
                        gc.HeaderText = "运输方式";
                        gc.Visible = false;
                        superGridControl1.PrimaryGrid.Columns.Add(gc);

                        gc = new GridColumn();
                        gc.DataPropertyName = "Sell_Operation";
                        gc.Name = "Sell_Operation";
                        gc.HeaderText = "制单人";
                        gc.Visible = false;
                        superGridControl1.PrimaryGrid.Columns.Add(gc);

                        gc = new GridColumn();
                        gc.DataPropertyName = "Sell_Auditman";
                        gc.Name = "Sell_Auditman";
                        gc.HeaderText = "审核人";
                        gc.Visible = false;
                        superGridControl1.PrimaryGrid.Columns.Add(gc);

                        gc = new GridColumn();
                        gc.DataPropertyName = "Sell_fukuanfangshi";
                        gc.Name = "Sell_fukuanfangshi";
                        gc.HeaderText = "收款方式";
                        gc.Visible = false;
                        superGridControl1.PrimaryGrid.Columns.Add(gc);

                        gc = new GridColumn();
                        gc.DataPropertyName = "Sell_Address";
                        gc.Name = "Sell_Address";
                        gc.HeaderText = "送货地址";
                        gc.Visible = false;
                        superGridControl1.PrimaryGrid.Columns.Add(gc);

                        gc = new GridColumn();
                        gc.DataPropertyName = "Sell_LinkMan";
                        gc.Name = "Sell_LinkMan";
                        gc.HeaderText = "联系人";
                        gc.Visible = false;
                        superGridControl1.PrimaryGrid.Columns.Add(gc);

                        gc = new GridColumn();
                        gc.DataPropertyName = "Sell_CliPhone";
                        gc.Name = "Sell_CliPhone";
                        gc.HeaderText = "联系电话";
                        gc.Visible = false;
                        superGridControl1.PrimaryGrid.Columns.Add(gc);

                        //dt = sm.GetList("  Sell_OddStatus=1 ");
                        //superGridControl1.PrimaryGrid.DataSource = dt;
                        //whereField = "单据日期";
                        //orderField = "ID";
                        #endregion
                        MessageBox.Show("列表为空！");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("错误代码:1224-欠货发货单业务查找：欠货发货单加载全部数据异常，异常信息：" + ex.Message);
                    }
                    break;
                default:
                    break;
            }

        }
        /// <summary>
        /// 快捷搜索下拉框功能实现
        /// </summary> 
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(toolStripTextBox1.Text))
                {
                    return;
                }
                string typeName = toolStripComboBox1.Text;
                string searchTxt = toolStripTextBox1.Text.Trim();
                string sql = "";
                switch (typeName)
                {
                    case "货品编号":
                        sql = "Buy_Code='{0}'";
                        break;
                    case "货品名称":
                        sql = "Sell_MaName='{0}'";
                        break;
                    case "规格型号":
                        sql = "Sell_Model='{0}'";
                        break;
                    default:
                        MessageBox.Show("类型错误！请重新选择。");
                        break;
                }
                DataRow[] dr = dt.Select(string.Format(sql, searchTxt), "Buy_ID");
                DataTable dtNew = dt.Clone();
                foreach (DataRow item in dr)
                {
                    dtNew.ImportRow(item);
                }
                dt = dtNew;
                superGridControl1.PrimaryGrid.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("错误代码:3217-业务查找：采购单快捷搜索异常，异常信息：" + ex.Message);
            }
        }

        /// <summary>
        /// 单据类型下拉框内容实现
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripComboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            string cb2 = toolStripComboBox2.Text;

            #region 固定列名，考虑用table查询的as
            GridColumn gc = null;
            string[] BuysColumns = { "单据类型", "单据编号", "单据日期", "单据状态", "供应商", "结算账户", "本次付款", "总金额", "业务员", "摘要" };
            string[] Sellcolumns = { "单据类型", "单据编号", "单据日期", "单据状态", "客户", "结算账户", "本次收款", "总金额", "业务员", "摘要" };
            string[] OtherReceiptColumns = { "仓库", "单据编号", "单据日期", "单据状态", "单据自定义一", "单据自定义二", "单据自定义三", "业务员", "摘要" };
            string[] OtherSendColumns = OtherReceiptColumns;
            string[] RequisitionColumns = { "单据类型", "仓库", "单据编号", "单据日期", "单据状态", "单据自定义一", "单据自定义二", "单据自定义三", "领料人", "摘要" };
            string[] MoveColumns = { "单据类型", "调出仓库", "调入仓库", "单据编号", "单据日期", "单据状态", "业务员", "制单人", "摘要" };
            string[] BreakageColumns = { "仓库", "单据编号", "单据日期", "单据状态", "业务员", "摘要" };
            string[] CheckColumns = OtherReceiptColumns;
            string[] AdjustPriceColumns = { "仓库", "单据编号", "单据日期", "单据状态", "调价比率%", "业务员", "摘要" };
            string[] OtherCostColumns = { "单据类型", "单据编号", "单据日期", "单据状态", "往来单位", "结算账户", "总金额", "业务员", "摘要" };
            string[] OtherInCostColumns = OtherCostColumns;
            string[] PaymentWaitColumns = { "单据类型", "单据编号", "单据日期", "单据状态", "往来单位", "结算账户", "付款金额", "实付金额", "业务员", "摘要" };
            string[] ReceiptColumns = { "单据类型", "单据编号", "单据日期", "单据状态", "往来单位", "结算账户", "收款金额", "实付金额", "业务员", "摘要" };
            string[] AccessMoneyColumns = { "单据编号", "单据日期", "单据状态", "付款账户", "收款金额", "收款账户", "收款金额", "业务员", "摘要" };
            string[] EmbezzleColumns = AccessMoneyColumns;
            //二维数组  用法：实例名[0][0]  便于更改表头时不用去改实现代码
            string[][] ColumnsHeaderText =
            {
                BuysColumns,
                Sellcolumns,
                OtherReceiptColumns,
                OtherSendColumns,
                RequisitionColumns,
                MoveColumns,
                BreakageColumns,
                CheckColumns,
                AdjustPriceColumns,
                OtherCostColumns,
                OtherInCostColumns,
                PaymentWaitColumns,
                ReceiptColumns,
                AccessMoneyColumns,
                EmbezzleColumns
            };
            #endregion

            switch (cb2)
            {
                case "采购开单":
                    superGridControl1.PrimaryGrid.DataSource = null;
                    superGridControl1.PrimaryGrid.Columns.Clear();
                    try
                    {
                        #region 初始化采购开单列
                        gc = new GridColumn();
                        gc.DataPropertyName = "ID";
                        gc.Name = "ColumnsID";
                        gc.HeaderText = "ID";
                        superGridControl1.PrimaryGrid.Columns.Add(gc);

                        gc = new GridColumn();
                        gc.DataPropertyName = "编号";
                        gc.Name = "ColumnsCode";
                        gc.HeaderText = "编号";
                        superGridControl1.PrimaryGrid.Columns.Add(gc);

                        gc = new GridColumn();
                        gc.DataPropertyName = "单据日期";
                        gc.Name = "ColumnsDate";
                        gc.HeaderText = "单据日期";
                        superGridControl1.PrimaryGrid.Columns.Add(gc);

                        gc = new GridColumn();
                        gc.DataPropertyName = "审核状态";
                        gc.Name = "ColumnsAuditStatus";
                        gc.HeaderText = "审核状态";
                        superGridControl1.PrimaryGrid.Columns.Add(gc);

                        gc = new GridColumn();
                        gc.DataPropertyName = "单据状态";
                        gc.Name = "ColumnsPurchaseStatus";
                        gc.HeaderText = "单据状态";
                        superGridControl1.PrimaryGrid.Columns.Add(gc);

                        gc = new GridColumn();
                        gc.DataPropertyName = "供应商";
                        gc.Name = "ColumnsSuName";
                        gc.HeaderText = "供应商";
                        superGridControl1.PrimaryGrid.Columns.Add(gc);

                        gc = new GridColumn();
                        gc.DataPropertyName = "结算账户";
                        gc.Name = "ColumnsBank";
                        gc.HeaderText = "结算账户";
                        superGridControl1.PrimaryGrid.Columns.Add(gc);

                        gc = new GridColumn();
                        gc.DataPropertyName = "总金额";
                        gc.Name = "ColumnsAmountMone";
                        gc.HeaderText = "总金额";
                        superGridControl1.PrimaryGrid.Columns.Add(gc);

                        gc = new GridColumn();
                        gc.DataPropertyName = "业务员";
                        gc.Name = "ColumnsSalesMan";
                        gc.HeaderText = "业务员";
                        superGridControl1.PrimaryGrid.Columns.Add(gc);

                        gc = new GridColumn();
                        gc.DataPropertyName = "备注";
                        gc.Name = "ColumnsRemark";
                        gc.HeaderText = "备注";
                        superGridControl1.PrimaryGrid.Columns.Add(gc);

                        //dt = bm.SelBuyDataTableToCheck();
                        //superGridControl1.PrimaryGrid.DataSource = dt;
                        //whereField = "单据日期";
                        //orderField = "ID";
                        #endregion
                        MessageBox.Show("列表为空！");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("错误代码:3218-采购业务查找：采购单加载全部数据异常，异常信息：" + ex.Message);
                    }
                    break;
                case "销售开单":
                    superGridControl1.PrimaryGrid.DataSource = null;
                    superGridControl1.PrimaryGrid.Columns.Clear();

                    try
                    {
                        #region 初始化销售开单列
                        gc = new GridColumn();
                        gc.DataPropertyName = "Sell_ID";
                        gc.Name = "Sell_ID";
                        gc.HeaderText = "ID";
                        gc.Visible = true;
                        superGridControl1.PrimaryGrid.Columns.Add(gc);

                        gc = new GridColumn();
                        gc.DataPropertyName = "Sell_Type";
                        gc.Name = "Sell_Type";
                        gc.HeaderText = "单据类型";
                        gc.Visible = true;
                        superGridControl1.PrimaryGrid.Columns.Add(gc);

                        gc = new GridColumn();
                        gc.DataPropertyName = "Sell_Code";
                        gc.Name = "Sell_Code";
                        gc.HeaderText = "编号";
                        gc.Visible = true;
                        superGridControl1.PrimaryGrid.Columns.Add(gc);

                        gc = new GridColumn();
                        gc.DataPropertyName = "Sell_Date";
                        gc.Name = "Sell_Date";
                        gc.HeaderText = "单据日期";
                        gc.Visible = true;
                        superGridControl1.PrimaryGrid.Columns.Add(gc);

                        gc = new GridColumn();
                        gc.DataPropertyName = "Sell_Review";
                        gc.Name = "Sell_Review";
                        gc.HeaderText = "审核状态";
                        gc.Visible = true;
                        superGridControl1.PrimaryGrid.Columns.Add(gc);

                        gc = new GridColumn();
                        gc.DataPropertyName = "Sell_OddStatus";
                        gc.Name = "Sell_OddStatus";
                        gc.HeaderText = "单据状态";
                        gc.Visible = true;
                        superGridControl1.PrimaryGrid.Columns.Add(gc);

                        gc = new GridColumn();
                        gc.DataPropertyName = "Sell_ClientName";
                        gc.Name = "Sell_ClientName";
                        gc.HeaderText = "客户";
                        gc.Visible = true;
                        superGridControl1.PrimaryGrid.Columns.Add(gc);

                        gc = new GridColumn();
                        gc.DataPropertyName = "Sell_AccountCode";
                        gc.Name = "Sell_AccountCode";
                        gc.HeaderText = "收款账户";
                        gc.Visible = true;
                        superGridControl1.PrimaryGrid.Columns.Add(gc);

                        gc = new GridColumn();
                        gc.DataPropertyName = "Sell_OddMoney";
                        gc.Name = "Sell_OddMoney";
                        gc.HeaderText = "总金额";
                        gc.Visible = true;
                        superGridControl1.PrimaryGrid.Columns.Add(gc);

                        gc = new GridColumn();
                        gc.DataPropertyName = "Sell_Salesman";
                        gc.Name = "Sell_Salesman";
                        gc.HeaderText = "业务员";
                        gc.Visible = true;
                        superGridControl1.PrimaryGrid.Columns.Add(gc);

                        gc = new GridColumn();
                        gc.DataPropertyName = "Sell_Remark";
                        gc.Name = "Sell_Remark";
                        gc.HeaderText = "备注";
                        gc.Visible = true;
                        superGridControl1.PrimaryGrid.Columns.Add(gc);



                        gc = new GridColumn();
                        gc.DataPropertyName = "Sell_PayMathod";
                        gc.Name = "Sell_PayMathod";
                        gc.HeaderText = "预收百分百";
                        gc.Visible = false;
                        superGridControl1.PrimaryGrid.Columns.Add(gc);

                        gc = new GridColumn();
                        gc.DataPropertyName = "Sell_InMoney";
                        gc.Name = "Sell_InMoney";
                        gc.HeaderText = "本次收款";
                        gc.Visible = false;
                        superGridControl1.PrimaryGrid.Columns.Add(gc);

                        gc = new GridColumn();
                        gc.DataPropertyName = "Sell_LastMoney";
                        gc.Name = "Sell_LastMoney";
                        gc.HeaderText = "剩余尾款";
                        gc.Visible = false;
                        superGridControl1.PrimaryGrid.Columns.Add(gc);

                        gc = new GridColumn();
                        gc.DataPropertyName = "Sell_TransportType";
                        gc.Name = "Sell_TransportType";
                        gc.HeaderText = "运输方式";
                        gc.Visible = false;
                        superGridControl1.PrimaryGrid.Columns.Add(gc);

                        gc = new GridColumn();
                        gc.DataPropertyName = "Sell_Operation";
                        gc.Name = "Sell_Operation";
                        gc.HeaderText = "制单人";
                        gc.Visible = false;
                        superGridControl1.PrimaryGrid.Columns.Add(gc);

                        gc = new GridColumn();
                        gc.DataPropertyName = "Sell_Auditman";
                        gc.Name = "Sell_Auditman";
                        gc.HeaderText = "审核人";
                        gc.Visible = false;
                        superGridControl1.PrimaryGrid.Columns.Add(gc);

                        gc = new GridColumn();
                        gc.DataPropertyName = "Sell_fukuanfangshi";
                        gc.Name = "Sell_fukuanfangshi";
                        gc.HeaderText = "收款方式";
                        gc.Visible = false;
                        superGridControl1.PrimaryGrid.Columns.Add(gc);

                        gc = new GridColumn();
                        gc.DataPropertyName = "Sell_Address";
                        gc.Name = "Sell_Address";
                        gc.HeaderText = "送货地址";
                        gc.Visible = false;
                        superGridControl1.PrimaryGrid.Columns.Add(gc);

                        gc = new GridColumn();
                        gc.DataPropertyName = "Sell_LinkMan";
                        gc.Name = "Sell_LinkMan";
                        gc.HeaderText = "联系人";
                        gc.Visible = false;
                        superGridControl1.PrimaryGrid.Columns.Add(gc);

                        gc = new GridColumn();
                        gc.DataPropertyName = "Sell_CliPhone";
                        gc.Name = "Sell_CliPhone";
                        gc.HeaderText = "联系电话";
                        gc.Visible = false;
                        superGridControl1.PrimaryGrid.Columns.Add(gc);

                        //dt = sm.GetList("");
                        //superGridControl1.PrimaryGrid.DataSource = dt;
                        //whereField = "单据日期";
                        //orderField = "ID";


                        #endregion
                        MessageBox.Show("列表为空！");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("错误代码:1219-销售业务查找：销售单加载全部数据异常，异常信息：" + ex.Message);
                    }
                    break;
                case "其他收货单":
                    break;
                case "其他发货单":
                    break;
                case "入库开单":
                    this.toolStripLabel8.Visible = true;
                    this.toolStripComboBox4.Visible = true;
                    this.toolStripComboBox4.Items.Clear();
                    this.toolStripComboBox4.Items.Add("采购申请单");
                    this.toolStripComboBox4.Items.Add("采购退货单");
                    this.toolStripComboBox4.Items.Add("赠商品入库");
                    this.toolStripComboBox4.Items.Add("获赔商品入库");
                    this.toolStripComboBox4.Items.Add("以货抵债");

                    BindWareHouesIn(99,"");
                    break;
                case "出库开单":
                    this.toolStripLabel8.Visible = true;
                    this.toolStripComboBox4.Visible = true;
                    this.toolStripComboBox4.Items.Clear();
                    this.toolStripComboBox4.Items.Add("销售申请单");
                    this.toolStripComboBox4.Items.Add("销售退货单");
                    this.toolStripComboBox4.Items.Add("销售补货单");
                    this.toolStripComboBox4.Items.Add("赠商品出库");
                    this.toolStripComboBox4.Items.Add("获赔商品出库");
                    toolStripComboBox4.SelectedIndex = 0;
                    BanDWareHouesOut(99,"");
                    break;
                case "领料单":
                    break;
                case "调拨单":
                    break;
                case "报损单":
                    break;
                case "盘点单":
                    break;
                case "调价单":
                    break;
                case "费用开支":
                    break;
                case "其他收入":
                    break;
                case "应付款单":
                    superGridControl1.PrimaryGrid.Columns.Clear();
                    //Band();
                    break;
                case "资金收款单":
                    superGridControl1.PrimaryGrid.Columns.Clear();
                    try
                    {
                        #region 初始化资金收款列     
                        gc = new GridColumn();
                        gc.DataPropertyName = "Sell_Code";
                        gc.Name = "ColumnsSellCode";
                        gc.HeaderText = "销售单号";
                        superGridControl1.PrimaryGrid.Columns.Add(gc);

                        gc = new GridColumn();
                        gc.DataPropertyName = "Sell_ClientName";
                        gc.Name = "ColumnsClientName";
                        gc.HeaderText = "客户";
                        superGridControl1.PrimaryGrid.Columns.Add(gc);

                        gc = new GridColumn();
                        gc.DataPropertyName = "Sell_Date";
                        gc.Name = "ColumnsDate";
                        gc.HeaderText = "单据日期";
                        superGridControl1.PrimaryGrid.Columns.Add(gc);

                        gc = new GridColumn();
                        gc.DataPropertyName = "Sell_Review";
                        gc.Name = "ColumnsReview";
                        gc.HeaderText = "审核状态";
                        superGridControl1.PrimaryGrid.Columns.Add(gc);

                        gc = new GridColumn();
                        gc.DataPropertyName = "Sell_IsPay";
                        gc.Name = "ColumnsIsPay";
                        gc.HeaderText = "收款状态";
                        superGridControl1.PrimaryGrid.Columns.Add(gc);

                        gc = new GridColumn();
                        gc.DataPropertyName = "Sell_fukuanfangshi";
                        gc.Name = "Columnsfukuanfangshi";
                        gc.HeaderText = "收款方式";
                        superGridControl1.PrimaryGrid.Columns.Add(gc);

                        gc = new GridColumn();
                        gc.DataPropertyName = "Sell_AccountCode";
                        gc.Name = "ColumnsAccountCode";
                        gc.HeaderText = "收款账户";
                        superGridControl1.PrimaryGrid.Columns.Add(gc);

                        gc = new GridColumn();
                        gc.DataPropertyName = "Sell_OddMoney";
                        gc.Name = "ColumnsSell_OddMoney";
                        gc.HeaderText = "本单总金额";
                        superGridControl1.PrimaryGrid.Columns.Add(gc);

                        gc = new GridColumn();
                        gc.DataPropertyName = "Sell_InMoney";
                        gc.Name = "ColumnsSell_InMoney";
                        gc.HeaderText = "本次收款";
                        gc.Visible = false;
                        superGridControl1.PrimaryGrid.Columns.Add(gc);

                        gc = new GridColumn();
                        gc.DataPropertyName = "Sell_LastMoney";
                        gc.Name = "ColumnsSell_LastMoney";
                        gc.HeaderText = "剩余尾款";
                        gc.Visible = false;
                        superGridControl1.PrimaryGrid.Columns.Add(gc);

                        gc = new GridColumn();
                        gc.DataPropertyName = "Sell_Salesman";
                        gc.Name = "ColumnsSalesMan";
                        gc.HeaderText = "业务员";
                        superGridControl1.PrimaryGrid.Columns.Add(gc);

                        gc = new GridColumn();
                        gc.DataPropertyName = "Sell_Operation";
                        gc.Name = "ColumnsSell_Operation";
                        gc.HeaderText = "制单人";
                        gc.Visible = false;
                        superGridControl1.PrimaryGrid.Columns.Add(gc);

                        gc = new GridColumn();
                        gc.DataPropertyName = "Sell_Auditman";
                        gc.Name = "ColumnsSell_Auditman";
                        gc.HeaderText = "审核人";
                        gc.Visible = false;
                        superGridControl1.PrimaryGrid.Columns.Add(gc);

                        gc = new GridColumn();
                        gc.DataPropertyName = "Sell_Remark";
                        gc.Name = "ColumnsRemark";
                        gc.HeaderText = "摘要";
                        superGridControl1.PrimaryGrid.Columns.Add(gc);

                        //dt = cwm.GetList();
                        //superGridControl1.PrimaryGrid.DataSource = dt;
                        //whereField = "单据日期";
                        //orderField = "ID";
                        #endregion
                        MessageBox.Show("列表为空！");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("错误代码:3230-资金收款业务查找：资金收款单加载全部数据异常，异常信息：" + ex.Message);
                    }

                    break;
                case "银行存取款":
                    break;
                case "资金拆借":
                    break;
                case "欠货发货单":
                    superGridControl1.PrimaryGrid.DataSource = null;
                    superGridControl1.PrimaryGrid.Columns.Clear();

                    try
                    {
                        #region 初始化欠货发货单列
                        gc = new GridColumn();
                        gc.DataPropertyName = "Sell_ID";
                        gc.Name = "Sell_ID";
                        gc.HeaderText = "ID";
                        gc.Visible = true;
                        superGridControl1.PrimaryGrid.Columns.Add(gc);

                        gc = new GridColumn();
                        gc.DataPropertyName = "Sell_Type";
                        gc.Name = "Sell_Type";
                        gc.HeaderText = "单据类型";
                        gc.Visible = true;
                        superGridControl1.PrimaryGrid.Columns.Add(gc);

                        gc = new GridColumn();
                        gc.DataPropertyName = "Sell_Code";
                        gc.Name = "Sell_Code";
                        gc.HeaderText = "编号";
                        gc.Visible = true;
                        superGridControl1.PrimaryGrid.Columns.Add(gc);

                        gc = new GridColumn();
                        gc.DataPropertyName = "Sell_Date";
                        gc.Name = "Sell_Date";
                        gc.HeaderText = "单据日期";
                        gc.Visible = true;
                        superGridControl1.PrimaryGrid.Columns.Add(gc);

                        gc = new GridColumn();
                        gc.DataPropertyName = "Sell_Review";
                        gc.Name = "Sell_Review";
                        gc.HeaderText = "审核状态";
                        gc.Visible = true;
                        superGridControl1.PrimaryGrid.Columns.Add(gc);

                        gc = new GridColumn();
                        gc.DataPropertyName = "Sell_OddStatus";
                        gc.Name = "Sell_OddStatus";
                        gc.HeaderText = "单据状态";
                        gc.Visible = true;
                        superGridControl1.PrimaryGrid.Columns.Add(gc);

                        gc = new GridColumn();
                        gc.DataPropertyName = "Sell_ClientName";
                        gc.Name = "Sell_ClientName";
                        gc.HeaderText = "客户";
                        gc.Visible = true;
                        superGridControl1.PrimaryGrid.Columns.Add(gc);

                        gc = new GridColumn();
                        gc.DataPropertyName = "Sell_AccountCode";
                        gc.Name = "Sell_AccountCode";
                        gc.HeaderText = "收款账户";
                        gc.Visible = true;
                        superGridControl1.PrimaryGrid.Columns.Add(gc);

                        gc = new GridColumn();
                        gc.DataPropertyName = "Sell_OddMoney";
                        gc.Name = "Sell_OddMoney";
                        gc.HeaderText = "总金额";
                        gc.Visible = true;
                        superGridControl1.PrimaryGrid.Columns.Add(gc);

                        gc = new GridColumn();
                        gc.DataPropertyName = "Sell_Salesman";
                        gc.Name = "Sell_Salesman";
                        gc.HeaderText = "业务员";
                        gc.Visible = true;
                        superGridControl1.PrimaryGrid.Columns.Add(gc);

                        gc = new GridColumn();
                        gc.DataPropertyName = "Sell_Remark";
                        gc.Name = "Sell_Remark";
                        gc.HeaderText = "备注";
                        gc.Visible = true;
                        superGridControl1.PrimaryGrid.Columns.Add(gc);

                        gc = new GridColumn();
                        gc.DataPropertyName = "Sell_PayMathod";
                        gc.Name = "Sell_PayMathod";
                        gc.HeaderText = "预收百分百";
                        gc.Visible = false;
                        superGridControl1.PrimaryGrid.Columns.Add(gc);

                        gc = new GridColumn();
                        gc.DataPropertyName = "Sell_InMoney";
                        gc.Name = "Sell_InMoney";
                        gc.HeaderText = "本次收款";
                        gc.Visible = false;
                        superGridControl1.PrimaryGrid.Columns.Add(gc);

                        gc = new GridColumn();
                        gc.DataPropertyName = "Sell_LastMoney";
                        gc.Name = "Sell_LastMoney";
                        gc.HeaderText = "剩余尾款";
                        gc.Visible = false;
                        superGridControl1.PrimaryGrid.Columns.Add(gc);

                        gc = new GridColumn();
                        gc.DataPropertyName = "Sell_TransportType";
                        gc.Name = "Sell_TransportType";
                        gc.HeaderText = "运输方式";
                        gc.Visible = false;
                        superGridControl1.PrimaryGrid.Columns.Add(gc);

                        gc = new GridColumn();
                        gc.DataPropertyName = "Sell_Operation";
                        gc.Name = "Sell_Operation";
                        gc.HeaderText = "制单人";
                        gc.Visible = false;
                        superGridControl1.PrimaryGrid.Columns.Add(gc);

                        gc = new GridColumn();
                        gc.DataPropertyName = "Sell_Auditman";
                        gc.Name = "Sell_Auditman";
                        gc.HeaderText = "审核人";
                        gc.Visible = false;
                        superGridControl1.PrimaryGrid.Columns.Add(gc);

                        gc = new GridColumn();
                        gc.DataPropertyName = "Sell_fukuanfangshi";
                        gc.Name = "Sell_fukuanfangshi";
                        gc.HeaderText = "收款方式";
                        gc.Visible = false;
                        superGridControl1.PrimaryGrid.Columns.Add(gc);

                        gc = new GridColumn();
                        gc.DataPropertyName = "Sell_Address";
                        gc.Name = "Sell_Address";
                        gc.HeaderText = "送货地址";
                        gc.Visible = false;
                        superGridControl1.PrimaryGrid.Columns.Add(gc);

                        gc = new GridColumn();
                        gc.DataPropertyName = "Sell_LinkMan";
                        gc.Name = "Sell_LinkMan";
                        gc.HeaderText = "联系人";
                        gc.Visible = false;
                        superGridControl1.PrimaryGrid.Columns.Add(gc);

                        gc = new GridColumn();
                        gc.DataPropertyName = "Sell_CliPhone";
                        gc.Name = "Sell_CliPhone";
                        gc.HeaderText = "联系电话";
                        gc.Visible = false;
                        superGridControl1.PrimaryGrid.Columns.Add(gc);

                        //dt = sm.GetList("  Sell_OddStatus=1 ");
                        //superGridControl1.PrimaryGrid.DataSource = dt;
                        //whereField = "单据日期";
                        //orderField = "ID";
                        #endregion
                        MessageBox.Show("列表为空！");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("错误代码:1224-欠货发货单业务查找：欠货发货单加载全部数据异常，异常信息：" + ex.Message);
                    }
                    break;
                default:
                    break;
            }
        }

        private void 刷新ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GridColumn gc = null;
            string cb2 = toolStripComboBox2.Text;
            switch (cb2)
            {
                case "采购开单":
                    superGridControl1.PrimaryGrid.Columns.Clear();
                    try
                    {
                        gc = new GridColumn();
                        gc.DataPropertyName = "ID";
                        gc.Name = "ColumnsID";
                        gc.HeaderText = "ID";
                        superGridControl1.PrimaryGrid.Columns.Add(gc);

                        gc = new GridColumn();
                        gc.DataPropertyName = "编号";
                        gc.Name = "ColumnsCode";
                        gc.HeaderText = "编号";
                        superGridControl1.PrimaryGrid.Columns.Add(gc);

                        gc = new GridColumn();
                        gc.DataPropertyName = "单据日期";
                        gc.Name = "ColumnsDate";
                        gc.HeaderText = "单据日期";
                        superGridControl1.PrimaryGrid.Columns.Add(gc);

                        gc = new GridColumn();
                        gc.DataPropertyName = "审核状态";
                        gc.Name = "ColumnsAuditStatus";
                        gc.HeaderText = "审核状态";
                        superGridControl1.PrimaryGrid.Columns.Add(gc);

                        gc = new GridColumn();
                        gc.DataPropertyName = "单据状态";
                        gc.Name = "ColumnsPurchaseStatus";
                        gc.HeaderText = "单据状态";
                        superGridControl1.PrimaryGrid.Columns.Add(gc);

                        gc = new GridColumn();
                        gc.DataPropertyName = "供应商";
                        gc.Name = "ColumnsSuName";
                        gc.HeaderText = "供应商";
                        superGridControl1.PrimaryGrid.Columns.Add(gc);

                        gc = new GridColumn();
                        gc.DataPropertyName = "结算账户";
                        gc.Name = "ColumnsBank";
                        gc.HeaderText = "结算账户";
                        superGridControl1.PrimaryGrid.Columns.Add(gc);

                        gc = new GridColumn();
                        gc.DataPropertyName = "总金额";
                        gc.Name = "ColumnsAmountMone";
                        gc.HeaderText = "总金额";
                        superGridControl1.PrimaryGrid.Columns.Add(gc);

                        gc = new GridColumn();
                        gc.DataPropertyName = "业务员";
                        gc.Name = "ColumnsSalesMan";
                        gc.HeaderText = "业务员";
                        superGridControl1.PrimaryGrid.Columns.Add(gc);

                        gc = new GridColumn();
                        gc.DataPropertyName = "备注";
                        gc.Name = "ColumnsRemark";
                        gc.HeaderText = "备注";
                        superGridControl1.PrimaryGrid.Columns.Add(gc);

                        //dt = bm.SelBuyDataTableToCheck();
                        //superGridControl1.PrimaryGrid.DataSource = dt;
                        //whereField = "单据日期";
                        //orderField = "ID";
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("错误代码:3218-业务查找：采购单加载全部数据异常，异常信息：" + ex.Message);
                    }
                    break;
                case "销售开单":
                    break;
                case "其他收货单":
                    break;
                case "入库开单":
                    this.toolStripLabel8.Visible = true;
                    this.toolStripComboBox4.Visible = true;
                    this.toolStripComboBox4.Items.Clear();
                    this.toolStripComboBox4.Items.Add("采购申请单");
                    this.toolStripComboBox4.Items.Add("采购退货单");
                    this.toolStripComboBox4.Items.Add("赠商品入库");
                    this.toolStripComboBox4.Items.Add("获赔商品入库");
                    this.toolStripComboBox4.Items.Add("以货抵债");
                    BindWareHouesIn(0,"");
                    break;
                case "出库开单":
                    this.toolStripLabel8.Visible = true;
                    this.toolStripComboBox4.Visible = true;
                    this.toolStripComboBox4.Items.Clear();
                    this.toolStripComboBox4.Items.Add("销售申请单");
                    this.toolStripComboBox4.Items.Add("销售退货单");
                    this.toolStripComboBox4.Items.Add("销售补货单");
                    this.toolStripComboBox4.Items.Add("赠商品出库");
                    this.toolStripComboBox4.Items.Add("获赔商品出库");
                    toolStripComboBox4.SelectedIndex = 0;

                    break;
                case "其他发货单":
                    break;
                case "领料单":
                    break;
                case "调拨单":
                    break;
                case "报损单":
                    break;
                case "盘点单":
                    break;
                case "调价单":
                    break;
                case "费用开支":
                    break;
                case "其他收入":
                    break;
                case "应付款单":
                    superGridControl1.PrimaryGrid.Columns.Clear();
                    //Band();
                    break;
                case "银行存取款":
                    break;
                case "资金拆借":
                    break;
                case "欠货发货单":
                    break;
                default:
                    break;
            }
        }

        private void 去付款ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (superGridControl1.PrimaryGrid.GetSelectedRows() != null)
            {
                SelectedElementCollection col = superGridControl1.PrimaryGrid.GetSelectedRows();
                if (col.Count > 0)
                {
                    //GridRow row = col[0] as GridRow;
                    //string zhuangtai = row.Cells[2].Value.ToString();
                    //switch (zhuangtai)
                    //{
                    //    case "未付款":
                    //        AppDomain.CurrentDomain.SetData("s", row.Cells[1].Value);
                    //        AppDomain.CurrentDomain.SetData("q", row.Cells[2].Value);
                    //        BuyPayment buy = new BuyPayment(this);
                    //        buy.Weifujine = Convert.ToDouble(row.Cells[8].Value);
                    //        buy.Show();
                    //        break;
                    //    case "已付款":
                    //        AppDomain.CurrentDomain.SetData("s", row.Cells[1].Value);
                    //        AppDomain.CurrentDomain.SetData("q", row.Cells[2].Value);
                    //        BuyPayment bu = new BuyPayment(this);
                    //        bu.Show();
                    //        break;
                    //}
                }
                else
                {
                    MessageBox.Show("请先选中要修改的数据所在行");
                }
            }
            else
            {
                MessageBox.Show("请先选中要修改的数据所在行");
            }
        }

        /// <summary>
        /// 绑定应付款单
        /// </summary>
        //public void Band()
        //{
        //    dt = bm.GetYinFuList();
        //    superGridControl1.PrimaryGrid.DataSource = dt;
        //}

        private void superGridControl1_DoubleClick(object sender, EventArgs e)
        {
            string cb2 = toolStripComboBox2.Text;
            switch (cb2)
            {
                case "采购开单":
                    break;
                case "销售开单":
                    if (superGridControl1.PrimaryGrid.GetSelectedRows() != null)
                    {

                        SelectedElementCollection cols = superGridControl1.PrimaryGrid.GetSelectedRows();
                        //if (cols.Count > 0)
                        //{
                        //    GridRow rows = cols[0] as GridRow;
                        //    string shengh = rows.Cells["Sell_Review"].Value.ToString();
                        //    //未审核查看
                        //    if (shengh == "0")
                        //    {
                        //        Sell.InSellForm sell = new Sell.InSellForm();
                        //        sell.Sellmodel = rows;
                        //        sell.State = 1;//1，审核查看
                        //        sell.Show();
                        //    }
                        //    //以审核查看
                        //    if (shengh == "1")
                        //    {
                        //        Sell.InSellForm sell = new Sell.InSellForm();
                        //        sell.Sellmodel = rows;
                        //        sell.State = 1;//1，审核查看
                        //        sell.Show();
                        //    }
                        //}
                        //else
                        //{
                        //    MessageBox.Show("请选择要查看的数据行！");
                        //}
                    }
                    else
                    {
                        MessageBox.Show("请选择要查看的数据行！");
                    }
                    break;
                case "其他收货单":
                    break;
                case "入库开单":
                    break;
                case "出库开单":
                    break;
                case "其他发货单":
                    break;
                case "领料单":
                    break;
                case "调拨单":
                    break;
                case "报损单":
                    break;
                case "盘点单":
                    break;
                case "调价单":
                    break;
                case "费用开支":
                    break;
                case "其他收入":
                    break;
                case "应付款单":
                    if (superGridControl1.PrimaryGrid.GetSelectedRows() != null)
                    {
                        //SelectedElementCollection col = superGridControl1.PrimaryGrid.GetSelectedRows();
                        //if (col.Count > 0)
                        //{
                        //    GridRow row = col[0] as GridRow;
                        //    string zhuangtai = row.Cells[2].Value.ToString();
                        //    AppDomain.CurrentDomain.SetData("s", row.Cells[1].Value);
                        //    AppDomain.CurrentDomain.SetData("q", row.Cells[2].Value);
                        //    BuyPayment bu = new BuyPayment(this);
                        //    bu.Show();
                        //}
                        //else
                        //{
                        //    MessageBox.Show("请先选中要查看的数据所在行");
                        //}
                    }
                    else
                    {
                        MessageBox.Show("请先选中要查看的数据所在行");
                    }
                    break;
                case "银行存取款":
                    break;
                case "资金拆借":
                    break;
                case "欠货发货单":
                    if (superGridControl1.PrimaryGrid.GetSelectedRows() != null)
                    {

                        //SelectedElementCollection cols = superGridControl1.PrimaryGrid.GetSelectedRows();
                        //if (cols.Count > 0)
                        //{
                        //    GridRow rows = cols[0] as GridRow;
                        //    Sell.InSellForm sell = new Sell.InSellForm();
                        //    sell.Sellmodel = rows;
                        //    sell.State = 2;//2，缺货销售单
                        //    sell.Show();
                        //}
                        //else
                        //{
                        //    MessageBox.Show("请选择要查看的数据行！");
                        //}
                    }
                    else
                    {
                        MessageBox.Show("请选择要查看的数据行！");
                    }
                    break;
                default:
                    break;
            }
        }
        /// <summary>
        /// 查看物流
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 查看物流ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (superGridControl1.PrimaryGrid.GetSelectedRows() != null)
            {
                //SelectedElementCollection col = superGridControl1.PrimaryGrid.GetSelectedRows();
                //if (col.Count > 0)
                //{
                //    GridRow row = col[0] as GridRow;
                //    FollowLoisticalForm folloe = new FollowLoisticalForm();
                //    folloe.DanHaoCode = row.Cells[1].Value.ToString();
                //    folloe.Show();
                //}
                //else
                //{
                //    MessageBox.Show("请先选中要查看的数据所在行");
                //}
            }
            else
            {
                MessageBox.Show("请先选中要查看的数据所在行");
            }
        }

        private void 新增物料信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (superGridControl1.PrimaryGrid.GetSelectedRows() != null)
                {
                    SelectedElementCollection col = superGridControl1.PrimaryGrid.GetSelectedRows();
                    if (col.Count > 0)
                    {
                        //GridRow row = col[0] as GridRow;
                        //if (bm.Exists(XYEEncoding.strCodeHex(row.Cells[1].Value.ToString())))
                        //{
                        //    InLogisticalForm inLog = new InLogisticalForm();
                        //    inLog.Danhao = row.Cells[1].Value.ToString();
                        //    inLog.Show();
                        //}
                        //else
                        //{
                        //    MessageBox.Show("未审核或者未付款，不能进行添加物流信息。");
                        //    return;
                        //}
                    }
                    else
                    {
                        MessageBox.Show("请先选中要查看的数据所在行");
                    }
                }
                else
                {
                    MessageBox.Show("请先选中要查看的数据所在行");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void 申请付款ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (superGridControl1.PrimaryGrid.GetSelectedRows() != null)
            {
                SelectedElementCollection col = superGridControl1.PrimaryGrid.GetSelectedRows();
                //if (col.Count > 0)
                //{
                //    GridRow row = col[0] as GridRow;
                //    string shenghestate = row.Cells["ColumnsAuditStatus"].Value.ToString();
                //    string danjustate = row.Cells["ColumnsPurchaseStatus"].Value.ToString();
                //    if (shenghestate == "已审核" && danjustate == "进行中")
                //    {
                //        BuyPaymentApplication bpf = new BuyPaymentApplication();
                //        bpf.BuyCode = row.Cells["ColumnsCode"].Value.ToString();
                //        bpf.Suname = row.Cells["ColumnsSuName"].Value.ToString();
                //        bpf.Acountname = row.Cells["ColumnsBank"].Value.ToString();
                //        bpf.Fukuan = row.Cells["ColumnsAmountMone"].Value.ToString();
                //        bpf.Saleman = row.Cells["ColumnsSalesMan"].Value.ToString();
                //        bpf.ShowDialog();
                //        superGridControl1.PrimaryGrid.DataSource = dt;
                //        return;
                //    }
                //}
                //else
                //{
                //    MessageBox.Show("请先选择要操作的行！");
                //}
            }
            else
            {
                MessageBox.Show("请先选择要操作的行！");
            }

        }

        private void 审核过账ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SelectedElementCollection col = superGridControl1.PrimaryGrid.GetSelectedRows();
            if (col == null)
            {
                MessageBox.Show("请先选中要查看的数据所在行");
                return;
            }
            //if (col.Count == 1)
            //{
            //    GridRow row = col[0] as GridRow;
            //    string code = row.Cells["ColumnsCode"].Value.ToString();
            //    BuyInForm bif = new BuyInForm();
            //    bif.BuyOdd = code;
            //    bif.AuditStatus = 0;
            //    bif.ShowDialog(this);
            //}
            //else
            //{
            //    MessageBox.Show("请先选中要查看的数据所在行");
            //}
        }

        private void 全部ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            superGridControl1.PrimaryGrid.DataSource = dt;
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            审核过账ToolStripMenuItem.Visible = false;
            申请付款ToolStripMenuItem.Visible = false;
            去付款ToolStripMenuItem.Visible = false;
            查看物流ToolStripMenuItem.Visible = false;
            新增物料信息ToolStripMenuItem.Visible = false;
            销售审核ToolStripMenuItem.Visible = false;
            欠货补货销售ToolStripMenuItem.Visible = false;
            商品入库ToolStripMenuItem.Visible = false;
            商品出库ToolStripMenuItem.Visible = false;
            资金收款单ToolStripMenuItem.Visible = false;
            string cb2 = toolStripComboBox2.Text;
            switch (cb2)
            {
                case "采购开单":
                    SelectedElementCollection col = superGridControl1.PrimaryGrid.GetSelectedRows();
                    GridRow row = col[0] as GridRow;
                    string shenghestate = row.Cells["ColumnsAuditStatus"].Value.ToString();
                    string danjustate = row.Cells["ColumnsPurchaseStatus"].Value.ToString();
                    if (shenghestate == "未审核" && danjustate == "已提交")
                    {
                        审核过账ToolStripMenuItem.Visible = true;
                    }
                    if (shenghestate == "已审核" && danjustate == "进行中")
                    {
                        申请付款ToolStripMenuItem.Visible = true;
                    }
                    if (shenghestate == "已审核" && danjustate == "待付款")
                    {
                        去付款ToolStripMenuItem.Visible = true;
                    }
                    if (shenghestate == "已审核" && danjustate == "已付款" || danjustate == "部分付款")
                    {
                        查看物流ToolStripMenuItem.Visible = true;
                    }
                    break;
                case "销售开单":
                    if (superGridControl1.PrimaryGrid.GetSelectedRows() != null)
                    {
                        SelectedElementCollection cols = superGridControl1.PrimaryGrid.GetSelectedRows();
                        if (cols.Count > 0)
                        {
                            GridRow rows = cols[0] as GridRow;
                            string shengh = rows.Cells["Sell_Review"].Value.ToString();
                            //未审核查看
                            if (shengh == "0")
                            {
                                销售审核ToolStripMenuItem.Visible = true;
                            }
                            if (shengh == "1")
                            {
                                销售审核ToolStripMenuItem.Visible = false;
                            }
                        }
                        else
                        {
                            MessageBox.Show("请选择要审核的数据行！");
                        }
                    }
                    else
                    {
                        MessageBox.Show("请选择要审核的数据行！");
                    }
                    break;
                case "其他收货单":
                    break;
                case "入库开单":
                    if (superGridControl1.PrimaryGrid.GetSelectedRows() != null)
                    {
                        SelectedElementCollection cols = superGridControl1.PrimaryGrid.GetSelectedRows();
                        if (cols.Count > 0)
                        {
                            GridRow rows = cols[0] as GridRow;
                            string shengh = rows.Cells["state"].Value.ToString();
                            //待入库查看
                            if (shengh == "0")
                            {
                                商品入库ToolStripMenuItem.Visible = true;
                            }
                            //部分入库查看
                            if (shengh == "1")
                            {
                                商品入库ToolStripMenuItem.Visible = true;
                            }
                            //已完成查看
                            if (shengh == "2")
                            {
                                商品入库ToolStripMenuItem.Visible = false;
                            }
                        }
                        else
                        {
                            MessageBox.Show("请选择要审核的数据行！");
                        }
                    }
                    else
                    {
                        MessageBox.Show("请选择要审核的数据行！");
                    }
                    break;
                case "出库开单":
                    if (superGridControl1.PrimaryGrid.GetSelectedRows() != null)
                    {
                        SelectedElementCollection cols = superGridControl1.PrimaryGrid.GetSelectedRows();
                        if (cols.Count > 0)
                        {
                            GridRow rows = cols[0] as GridRow;
                            string shengh = rows.Cells["state"].Value.ToString();
                            //待出库查看
                            if (shengh == "0")
                            {
                                商品出库ToolStripMenuItem.Visible = true;
                            }
                            //部分出库查看
                            if (shengh == "1")
                            {
                                商品出库ToolStripMenuItem.Visible = true;
                            }
                            //已完成查看
                            if (shengh == "2")
                            {
                                商品出库ToolStripMenuItem.Visible = false;
                            }
                        }
                        else
                        {
                            MessageBox.Show("请选择要审核的数据行！");
                        }
                    }
                    else
                    {
                        MessageBox.Show("请选择要审核的数据行！");
                    }
                    break;

                case "其他发货单":
                    break;
                case "领料单":
                    break;
                case "调拨单":
                    break;
                case "报损单":
                    break;
                case "盘点单":
                    break;
                case "调价单":
                    break;
                case "费用开支":
                    break;
                case "其他收入":
                    break;
                case "应付款单":
                    break;
                case "资金收款单":
                    break;
                case "银行存取款":
                    break;
                case "资金拆借":
                    break;
                case "欠货发货单":
                    if (superGridControl1.PrimaryGrid.GetSelectedRows() != null)
                    {
                        SelectedElementCollection cols = superGridControl1.PrimaryGrid.GetSelectedRows();
                        if (cols.Count > 0)
                        {
                            欠货补货销售ToolStripMenuItem.Visible = true;
                        }
                        else
                        {
                            MessageBox.Show("请选择要审核的数据行！");
                        }
                    }
                    break;
                default:
                    break;
            }
        }

        private void 销售审核ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (superGridControl1.PrimaryGrid.GetSelectedRows() != null)
                {

                    //SelectedElementCollection cols = superGridControl1.PrimaryGrid.GetSelectedRows();
                    //if (cols.Count > 0)
                    //{
                    //    GridRow rows = cols[0] as GridRow;
                    //    Sell.InSellForm sell = new Sell.InSellForm();
                    //    sell.Sellmodel = rows;
                    //    sell.State = 1;//1，审核查看
                    //    sell.Show();
                    //}
                    //else
                    //{
                    //    MessageBox.Show("请选择要审核的数据行！");
                    //}
                }
                else
                {
                    MessageBox.Show("请选择要审核的数据行！");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("错误" + ex.Message);
            }
        }

        private void 欠货补货销售ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (superGridControl1.PrimaryGrid.GetSelectedRows() != null)
            {

                //SelectedElementCollection cols = superGridControl1.PrimaryGrid.GetSelectedRows();
                //if (cols.Count > 0)
                //{
                //    GridRow rows = cols[0] as GridRow;

                //    Sell.InSellForm sell = new Sell.InSellForm();
                //    sell.Sellmodel = rows;
                //    sell.State = 2;//2，缺货销售单
                //    sell.Show();
                //}
                //else
                //{
                //    MessageBox.Show("请选择要查看的数据行！");
                //}
            }
            else
            {
                MessageBox.Show("请选择要查看的数据行！");
            }
        }

        private void 资金收款单ToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (superGridControl1.PrimaryGrid.GetSelectedRows() != null)
                {
                    SelectedElementCollection col = superGridControl1.PrimaryGrid.GetSelectedRows();
                    //if (col.Count > 0)
                    //{
                    //    GridRow row = col[0] as GridRow;
                    //    InsSellGathering isg = new InsSellGathering();
                    //    isg.Sell_Code = row.Cells["ColumnsSellCode"].Value.ToString();
                    //    isg.Sell_ClientName = row.Cells["ColumnsClientName"].Value.ToString();
                    //    // isg.A_AccountName = row.Cells["ColumnsAccountCode"].Value.ToString();
                    //    isg.Sell_OddMoney = row.Cells["ColumnsSell_OddMoney"].Value.ToString();
                    //    isg.Sell_InMoney = row.Cells["ColumnsSell_InMoney"].Value.ToString();
                    //    isg.Sell_LastMoney = row.Cells["ColumnsSell_LastMoney"].Value.ToString();
                    //    isg.Sell_fukuanfangshi = row.Cells["Columnsfukuanfangshi"].Value.ToString();
                    //    isg.Sell_Salesman = row.Cells["ColumnsSalesMan"].Value.ToString();
                    //    isg.Sell_Operation = row.Cells["ColumnsSell_Operation"].Value.ToString();
                    //    isg.Sell_Remark = row.Cells["ColumnsRemark"].Value.ToString();
                    //    isg.ShowDialog();
                    //    superGridControl1.PrimaryGrid.DataSource = dt;
                    //    return;
                    //}
                    //else
                    //{
                    //    MessageBox.Show("请先选择要操作的行！");
                    //}
                }
                else
                {
                    MessageBox.Show("请先选择要操作的行！");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("错误" + ex.Message);
            }
        }
        private void 商品入库ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (superGridControl1.PrimaryGrid.GetSelectedRows() != null)
                {

                    SelectedElementCollection cols = superGridControl1.PrimaryGrid.GetSelectedRows();
                    if (cols.Count > 0)
                    {
                        GridRow rows = cols[0] as GridRow;
                        string shengh = rows.Cells["state"].Value.ToString();
                        //待入库查看
                        if (shengh == "0")
                        {
                            WareHouseInMain ware = new WareHouseInMain();
                            ware.WareHouseModel = rows;
                            ware.State = 0;
                            ware.Show();
                        }
                        //部分入库查看
                        if (shengh == "1")
                        {
                            WareHouseInMain ware = new WareHouseInMain();
                            ware.WareHouseModel = rows;
                            ware.State = 1;
                            ware.Show();
                        }
                        //已完成查看
                        if (shengh == "2")
                        {
                            WareHouseInMain ware = new WareHouseInMain();
                            ware.WareHouseModel = rows;
                            ware.State = 2;
                            ware.Show();
                        }
                    }
                    else
                    {
                        MessageBox.Show("请选择要入库的数据行！");
                    }
                }
                else
                {
                    MessageBox.Show("请选择要入库的数据行！");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("错误" + ex.Message);
            }
        }
        /// <summary>
        /// 入库和出库下拉框发生变化的时候
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripComboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            string cb4 = toolStripComboBox4.Text;
            switch (cb4)
            {
                case "采购申请单":
                    BindWareHouesIn(2,"562D5D5E2D0E230F5141");
                    break;
                case "采购退货单":
                   BindWareHouesIn(2, "562D5D5E292F5F115141");
                    break;
                case "赠商品入库":
                    BindWareHouesIn(2, "301D2D2822532C0F5B06");
                    break;
                case "获赔商品入库":
                
                    BindWareHouesIn(2,"5F1521062D2822532C0F5B06");
                    break;
                case "以货抵债":
                    BindWareHouesIn(2,"36305F115132314A");
                    break;
                case "销售申请单":
                    BanDWareHouesOut(1,"2B1E2E3F2D0E230F5141");
                    break;
                case "销售退货单":
                    BanDWareHouesOut(1,"2B1E2E3F292F5F115141");
                    break;
                case "销售补货单":
                    BanDWareHouesOut(1, "2B1E2E3F565D5F115141");
                    break;
                case "赠商品出库":
                    BanDWareHouesOut(1, "301D2D28225357125B06");
                    break;
                case "获赔商品出库":
                    BanDWareHouesOut(1, "5F1521062D28225357125B06");
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// 初始化入库的列表
        /// </summary>
        /// <param name="where"></param>
    
        private void BindWareHouesIn(int fieldName, string fieldValue)
        {
            GridColumn gc = null;

            superGridControl1.PrimaryGrid.DataSource = null;
            superGridControl1.PrimaryGrid.Columns.Clear();
            gc = new GridColumn();
            gc.DataPropertyName = "id";
            gc.Name = "id";
            gc.HeaderText = "ID";
            superGridControl1.PrimaryGrid.Columns.Add(gc);

            gc = new GridColumn();
            gc.DataPropertyName = "code";
            gc.Name = "code";
            gc.HeaderText = "入货单号";
            superGridControl1.PrimaryGrid.Columns.Add(gc);

            gc = new GridColumn();
            gc.DataPropertyName = "type";
            gc.Name = "type";
            gc.HeaderText = "单据类型";
            superGridControl1.PrimaryGrid.Columns.Add(gc);


            gc = new GridColumn();
            gc.DataPropertyName = "purchaseCode";
            gc.Name = "purchaseCode";
            gc.HeaderText = "采购单号";
            superGridControl1.PrimaryGrid.Columns.Add(gc);

            gc = new GridColumn();
            gc.DataPropertyName = "date";
            gc.Name = "date";
            gc.HeaderText = "开单时间";
            superGridControl1.PrimaryGrid.Columns.Add(gc);

            gc = new GridColumn();
            gc.DataPropertyName = "state";
            gc.Name = "state";
            gc.HeaderText = "单据状态";
            superGridControl1.PrimaryGrid.Columns.Add(gc);

            gc = new GridColumn();
            gc.DataPropertyName = "operation";
            gc.Name = "operation";
            gc.HeaderText = "入库员";
            superGridControl1.PrimaryGrid.Columns.Add(gc);

            gc = new GridColumn();
            gc.DataPropertyName = "examine";
            gc.Name = "examine";
            gc.HeaderText = "审核人";
            superGridControl1.PrimaryGrid.Columns.Add(gc);

            gc = new GridColumn();
            gc.DataPropertyName = "remark";
            gc.Name = "remark";
            gc.HeaderText = "备注";
            superGridControl1.PrimaryGrid.Columns.Add(gc);

            dt =  ch.DataTableReCoding(ware.GetList(fieldName,fieldValue).Tables[0]);
            if (dt.Rows.Count > 0)
            {
                superGridControl1.PrimaryGrid.DataSource = dt;
                whereField = "单据日期";
                orderField = "ID";
            }
            else
            {
                MessageBox.Show("查无数据!");
            }

        }
        /// <summary>
        /// 初始化出库的列表
        /// </summary>
        /// <param name="where"></param>
        private void BanDWareHouesOut(int fieldName,string fieldValue)
        {
            GridColumn gc = null;

            superGridControl1.PrimaryGrid.DataSource = null;
            superGridControl1.PrimaryGrid.Columns.Clear();
            gc = new GridColumn();
            gc.DataPropertyName = "ID";
            gc.Name = "id";
            gc.HeaderText = "ID";
            superGridControl1.PrimaryGrid.Columns.Add(gc);

            gc = new GridColumn();
            gc.DataPropertyName = "出库单号";
            gc.Name = "code";
            gc.HeaderText = "出库单号";
            superGridControl1.PrimaryGrid.Columns.Add(gc);

            gc = new GridColumn();
            gc.DataPropertyName = "单据类型";
            gc.Name = "type";
            gc.HeaderText = "单据类型";
            superGridControl1.PrimaryGrid.Columns.Add(gc);

            gc = new GridColumn();
            gc.DataPropertyName = "销售单号";
            gc.Name = "salesCode";
            gc.HeaderText = "销售单号";
            superGridControl1.PrimaryGrid.Columns.Add(gc);

            gc = new GridColumn();
            gc.DataPropertyName = "开单时间";
            gc.Name = "date";
            gc.HeaderText = "开单时间";
            superGridControl1.PrimaryGrid.Columns.Add(gc);

            gc = new GridColumn();
            gc.DataPropertyName = "单据状态";
            gc.Name = "state";
            gc.HeaderText = "单据状态";
            superGridControl1.PrimaryGrid.Columns.Add(gc);

            gc = new GridColumn();
            gc.DataPropertyName = "出库员";
            gc.Name = "operation";
            gc.HeaderText = "出库员";
            superGridControl1.PrimaryGrid.Columns.Add(gc);

            gc = new GridColumn();
            gc.DataPropertyName = "审核人";
            gc.Name = "examine";
            gc.HeaderText = "审核人";
            superGridControl1.PrimaryGrid.Columns.Add(gc);

            gc = new GridColumn();
            gc.DataPropertyName = "备注";
            gc.Name = "remark";
            gc.HeaderText = "备注";
            superGridControl1.PrimaryGrid.Columns.Add(gc);

            gc = new GridColumn();
            gc.DataPropertyName = "运送方式";
            gc.Name = "transportMathod";
            gc.HeaderText = "运送方式";
            gc.Visible = false;
            superGridControl1.PrimaryGrid.Columns.Add(gc);

            gc = new GridColumn();
            gc.DataPropertyName = "快递名称";
            gc.Name = "logistics";
            gc.HeaderText = "快递名称";
            gc.Visible = false;
            superGridControl1.PrimaryGrid.Columns.Add(gc);

            gc = new GridColumn();
            gc.DataPropertyName = "快递单号";
            gc.Name = "logisticsOddCode";
            gc.HeaderText = "快递单号";
            gc.Visible = false;
            superGridControl1.PrimaryGrid.Columns.Add(gc);

            gc = new GridColumn();
            gc.DataPropertyName = "快递电话";
            gc.Name = "logisticsPhone";
            gc.HeaderText = "快递电话";
            gc.Visible = false;
            superGridControl1.PrimaryGrid.Columns.Add(gc);

            dt = ch.DataTableReCoding(new WarehouseOutInterface().GetList(fieldName, fieldValue));
            superGridControl1.PrimaryGrid.DataSource = dt;
            whereField = "单据日期";
            orderField = "ID";
        }

        private void 商品出库ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (superGridControl1.PrimaryGrid.GetSelectedRows() != null)
                {

                    SelectedElementCollection cols = superGridControl1.PrimaryGrid.GetSelectedRows();
                    if (cols.Count > 0)
                    {
                        GridRow rows = cols[0] as GridRow;
                        string shengh = rows.Cells["state"].Value.ToString();

                        //待出库查看
                        if (shengh == "0")
                        {

                            //WSCATProject.WareHouse ware = new WareHouse.WareHouseOut();
                            //ware.WareHouseoutModel = rows;
                            //ware.State = 0;
                            //ware.ShowDialog();
                        }
                        //部分出库查看
                        if (shengh == "1")
                        {
                            //WSCATProject.WareHouse.WareHouseOut ware = new WareHouse.WareHouseOut();
                            //ware.WareHouseoutModel = rows;
                            //ware.State = 1;
                            //ware.Show();
                        }
                        //已完成查看
                        if (shengh == "2")
                        {
                            //WSCATProject.WareHouse.WareHouseOut ware = new WareHouse.WareHouseOut();
                            //ware.WareHouseoutModel = rows;
                            //ware.State = 2;
                            //ware.Show();
                        }
                    }
                    else
                    {
                        MessageBox.Show("请选择要入库的数据行！");
                    }
                }
                else
                {
                    MessageBox.Show("请选择要入库的数据行！");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("错误" + ex.Message);
            }
        }
    }
}
