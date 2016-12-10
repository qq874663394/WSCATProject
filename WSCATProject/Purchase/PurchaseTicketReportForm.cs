using DevComponents.DotNetBar.SuperGrid;
using HelperUtility.Encrypt;
using InterfaceLayer.Purchase;
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

namespace WSCATProject.Purchase
{
    public partial class PurchaseTicketReportForm : Form
    {
        public PurchaseTicketReportForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 供应商Code
        /// </summary>
        private string _suppilerCode;
        public string SuppilerCode
        {
            get { return _suppilerCode;}
            set{_suppilerCode = value;}
        }

        public List<string> PursachList
        {
            get { return _pursachList; }
            set { _pursachList = value; }
        }

        private List<string> _pursachList;
        CodingHelper ch = new CodingHelper();

        private void PurchaseTicketReportForm_Load(object sender, EventArgs e)
        {
            try
            {
                this.labelTitle.BackColor = Color.FromArgb(85, 177, 238);
                this.pictureBoxMax.BackColor = Color.FromArgb(85, 177, 238);
                this.pictureBoxMin.BackColor = Color.FromArgb(85, 177, 238);
                this.pictureBoxClose.BackColor = Color.FromArgb(85, 177, 238);

                //不可自动添加列
                this.superGridControlShangPing.PrimaryGrid.AutoGenerateColumns = false;
                superGridControlShangPing.HScrollBarVisible = true;
                //表格内容居中
                superGridControlShangPing.DefaultVisualStyles.CellStyles.Default.Alignment =
                DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleCenter;
                superGridControlShangPing.PrimaryGrid.SelectionGranularity = SelectionGranularity.Row;

                PurchaseMainInterface purchaseInter = new PurchaseMainInterface();
                DataTable dt = ch.DataTableReCoding(purchaseInter.GetList(2, XYEEncoding.strCodeHex(_suppilerCode)));
                
                PurchasePaymentForm purchase = (PurchasePaymentForm)this.Owner;
                _pursachList = purchase.PurchaseMainList;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    foreach (var liat in _pursachList)
                    {
                        if (dt.Rows[i][2].ToString() == liat)
                        {
                            dt.Rows.RemoveAt(i);
                        }
                    }
                }
                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("此供应商暂无购货单信息！请重新选择");
                    this.Close();
                    return;
                }
                this.lbldanju.Text = dt.Rows.Count.ToString() + "张单据";
                superGridControlShangPing.PrimaryGrid.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("错误代码：3401-购货单报告表数据加载失败！"+ex.Message,"购货单序时薄温馨提示：");
                this.Close();
            }
        }

        #region  设置窗体无边框可以拖动
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;



        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();

        private void PurchaseTicketReportForm_MouseDown(object sender, MouseEventArgs e)
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
        /// 快捷方式
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PurchaseTicketReportForm_KeyDown(object sender, KeyEventArgs e)
        {
            //刷新
            if (e.KeyCode == Keys.F5)
            {
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
        /// 行双击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void superGridControlShangPing_CellDoubleClick(object sender, GridCellDoubleClickEventArgs e)
        {
            try
            {
                if (superGridControlShangPing.PrimaryGrid.GetSelectedRows() != null)
                {
                    SelectedElementCollection col = superGridControlShangPing.PrimaryGrid.GetSelectedRows();
                    if (col.Count > 0)
                    {
                        GridRow row = col[0] as GridRow;
                        string mainCode = row.Cells["BillCode"].Value.ToString();
                        PurchasePaymentForm purchasePay = (PurchasePaymentForm)this.Owner;
                        purchasePay.PurchaseMainCode = mainCode;
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("请先选择要操作的行！");
                    }
                }
                else
                {
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("错误代码：3402-尝试双击表格选中行失败！请检查：" + ex.Message, "购货单序时薄温馨提示！");
            }
        }
    }
}
