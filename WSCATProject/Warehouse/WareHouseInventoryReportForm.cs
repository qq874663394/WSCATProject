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

namespace WSCATProject.Warehouse
{
    public partial class WareHouseInventoryReportForm : Form
    {
        public WareHouseInventoryReportForm()
        {
            InitializeComponent();
        }
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
        /// 盘点Code
        /// </summary>
        private string _inventoryCode;
        public string InventoryCode
        {
            get { return _inventoryCode; }
            set { _inventoryCode = value; }
        }
        /// <summary>
        /// 仓库Code
        /// </summary>
        private string _storageCode;
        public string StorageCode
        {
            get { return _storageCode; }
            set { _storageCode = value; }
        }

        /// <summary>
        /// 仓库Name
        /// </summary>
        private string _storageName;
        public string StorageName
        {
            get { return _storageName; }
            set { _storageName = value; }
        }

        #endregion

        #region 调用接口以及加密解密的方法
        StorageInterface si = new StorageInterface();
        WarehouseInventoryDetailInterface whidi = new WarehouseInventoryDetailInterface();
        CodingHelper codeh = new CodingHelper();
        #endregion

        #region  窗体加载事件
        private void WareHouseInventoryReportForm_Load(object sender, EventArgs e)
        {
            try
            {
                this.labelTitle.BackColor = Color.FromArgb(85, 177, 238);
                this.pictureBoxMax.BackColor = Color.FromArgb(85, 177, 238);
                this.pictureBoxMin.BackColor = Color.FromArgb(85, 177, 238);
                this.pictureBoxClose.BackColor = Color.FromArgb(85, 177, 238);
                //显示行号
                superGridControlShangPing.PrimaryGrid.ShowRowGridIndex = true;
                toolStripButtonLoss.Enabled = false;
                toolStripButtonProfit.Enabled = false;
                //不可自动添加列
                this.superGridControlShangPing.PrimaryGrid.AutoGenerateColumns = false;
                superGridControlShangPing.HScrollBarVisible = true;
                //表格内容居中
                superGridControlShangPing.DefaultVisualStyles.CellStyles.Default.Alignment =
                DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleCenter;
                InitDataGridView();//表格初始化

                this.textBoxpandiancode.Text = _inventoryCode;//盘点单号
                barcodeXYE.Code128 _Code = new barcodeXYE.Code128();
                _Code.ValueFont = new Font("微软雅黑", 20);
                System.Drawing.Bitmap imgTemp = _Code.GetCodeImage(textBoxpandiancode.Text, barcodeXYE.Code128.Encode.Code128A);
                picbpandianBarCode.Image = imgTemp;//条形码
            }
            catch (Exception ex)
            {
                MessageBox.Show("错误代码：2401-窗体加载时，初始化数据错误,请检查：" + ex.Message, "盘点报告单温馨提示！");
                this.Close();
                return;
            }


            #region 加载盘点方案的数据
            DataTable dt = codeh.DataTableReCoding(si.GetList(999, ""));
            cboPanDianIdea.DisplayMember = "name";
            cboPanDianIdea.ValueMember = "code";
            cboPanDianIdea.DataSource = dt;
            this.cboPanDianIdea.Text = _storageName;//仓库名称
            superGridControlShangPing.PrimaryGrid.DataSource = codeh.DataTableReCoding(whidi.Search(2, (XYEEncoding.strCodeHex(_storageCode))));
            superGridControlShangPing.PrimaryGrid.EnsureVisible();
            InitDataGridView();
            try
            {
                GridRow gr = new GridRow();
                decimal tempAllzhucun = 0;
                decimal tempAllpandian = 0;
                decimal tempAllpanying = 0;
                decimal tempAllpankui = 0;
                //逐行统计数据总数
                for (int i = 0; i < superGridControlShangPing.PrimaryGrid.Rows.Count - 1; i++)
                {
                    GridRow tempGR = superGridControlShangPing.PrimaryGrid.Rows[i] as GridRow;
                    tempAllzhucun += Convert.ToDecimal(tempGR["zhangcunnumber"].FormattedValue);
                    tempAllpandian += Convert.ToDecimal(tempGR["pandiannumber"].FormattedValue);
                    tempAllpanying += Convert.ToDecimal(tempGR["panyingnumber"].FormattedValue);
                    tempAllpankui += Convert.ToDecimal(tempGR["pankuinumber"].FormattedValue);
                }
                _ZhangCunShuLiang = tempAllzhucun;
                _PanDianShuLiang = tempAllpandian;
                _PanYingShuLiang = tempAllpanying;
                _PanKuiShuLiang = tempAllpankui;
                gr = (GridRow)superGridControlShangPing.PrimaryGrid.LastSelectableRow;
                gr["zhangcunnumber"].Value = _ZhangCunShuLiang.ToString();
                gr["pandiannumber"].Value = _PanDianShuLiang.ToString();
                gr["panyingnumber"].Value = _PanYingShuLiang.ToString();
                gr["pankuinumber"].Value = _PanKuiShuLiang.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("商品盘点表统计数量错误" + ex.Message);
            }
            //设置盘盈,盘亏按钮是否可用
            GridItemsCollection grs = superGridControlShangPing.PrimaryGrid.Rows;
            int y = 0;
            int k = 0;
            foreach (GridRow gr in grs)
            {
                if (gr["pankuinumber"].FormattedValue != "0.00")
                {
                    k++;
                }
                if (gr["panyingnumber"].FormattedValue != "0.00")
                {
                    y++;
                }
            }
            if (k > 0)
            {
                toolStripButtonLoss.Enabled = true;
            }
            if (y > 0)
            {
                toolStripButtonProfit.Enabled = true;
            }
            #endregion

        }
        #endregion

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
                    superGridControlShangPing.PrimaryGrid.DataSource = codeh.DataTableReCoding(whidi.Search(2, (XYEEncoding.strCodeHex(cboPanDianIdea.SelectedValue.ToString()))));
                    superGridControlShangPing.PrimaryGrid.EnsureVisible();
                    InitDataGridView();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("错误代码：2402-下拉框选择仓库查询商品盘点数据错误，请检查：" + ex.Message, "商品盘点报告单温馨提示");
                }
                try
                {

                    GridRow gr = new GridRow();
                    decimal tempAllzhucun = 0;
                    decimal tempAllpandian = 0;
                    decimal tempAllpanying = 0;
                    decimal tempAllpankui = 0;
                    //逐行统计数据总数
                    for (int i = 0; i < superGridControlShangPing.PrimaryGrid.Rows.Count - 1; i++)
                    {
                        GridRow tempGR = superGridControlShangPing.PrimaryGrid.Rows[i] as GridRow;
                        tempAllzhucun += Convert.ToDecimal(tempGR["zhangcunnumber"].FormattedValue);
                        tempAllpandian += Convert.ToDecimal(tempGR["pandiannumber"].FormattedValue);
                        tempAllpanying += Convert.ToDecimal(tempGR["panyingnumber"].FormattedValue);
                        tempAllpankui += Convert.ToDecimal(tempGR["pankuinumber"].FormattedValue);
                    }
                    _ZhangCunShuLiang = tempAllzhucun;
                    _PanDianShuLiang = tempAllpandian;
                    _PanYingShuLiang = tempAllpanying;
                    _PanKuiShuLiang = tempAllpankui;
                    gr = (GridRow)superGridControlShangPing.PrimaryGrid.LastSelectableRow;
                    gr["zhangcunnumber"].Value = _ZhangCunShuLiang.ToString();
                    gr["pandiannumber"].Value = _PanDianShuLiang.ToString();
                    gr["panyingnumber"].Value = _PanYingShuLiang.ToString();
                    gr["pankuinumber"].Value = _PanKuiShuLiang.ToString();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("错误代码：2403-商品盘点报告表统计数量错误" + ex.Message, "盘点报告单温馨提示！");
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
            //贮存数量
            gr.Cells["zhangcunnumber"].Value = 0;
            gr.Cells["zhangcunnumber"].CellStyles.Default.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleCenter;
            gr.Cells["zhangcunnumber"].CellStyles.Default.Background.Color1 = Color.Orange;
            //盘点数量
            gr.Cells["pandiannumber"].Value = 0;
            gr.Cells["pandiannumber"].CellStyles.Default.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleCenter;
            gr.Cells["pandiannumber"].CellStyles.Default.Background.Color1 = Color.Orange;
            //盘盈数量
            gr.Cells["panyingnumber"].Value = 0;
            gr.Cells["panyingnumber"].CellStyles.Default.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleCenter;
            gr.Cells["panyingnumber"].CellStyles.Default.Background.Color1 = Color.Orange;
            //盘亏数量
            gr.Cells["pankuinumber"].Value = 0;
            gr.Cells["pankuinumber"].CellStyles.Default.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleCenter;
            gr.Cells["pankuinumber"].CellStyles.Default.Background.Color1 = Color.Orange;
        }
        #endregion

        #region 设置窗体无边框可以拖动
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();

        private void superGridControlShangPing_MouseDown(object sender, MouseEventArgs e)
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

        /// <summary>
        /// 生成盘亏单的点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButtonLoss_Click(object sender, EventArgs e)
        {
            WareHouseInventoryLossForm wareinventloss = new WareHouseInventoryLossForm();
            wareinventloss.StorageCode = _storageCode;
            wareinventloss.StorageName = _storageName;
            wareinventloss.ShowDialog();
        }

        /// <summary>
        /// 生成盘盈单的点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButtonProfit_Click(object sender, EventArgs e)
        {
            WareHouseInventoryProfitForm warehouseprofit = new WareHouseInventoryProfitForm();
            warehouseprofit.StorageCode = _storageCode;
            warehouseprofit.StorageName = _storageName;
            warehouseprofit.ShowDialog();
        }

        private void WareHouseInventoryReportForm_Activated(object sender, EventArgs e)
        {
            cboPanDianIdea.Focus();
        }

        /// <summary>
        /// 快捷方式
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void WareHouseInventoryReportForm_KeyDown(object sender, KeyEventArgs e)
        {
            //盘盈单
            if (e.KeyCode == Keys.Y  )
            {
                toolStripButtonProfit_Click(sender, e);
                return;
            }
            //盘亏单
            if (e.KeyCode == Keys.L  )
            {
                toolStripButtonLoss_Click(sender, e);
                return;
            }
            //刷新
            if (e.KeyCode == Keys.F5)
            {
                MessageBox.Show("刷新");
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
