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
    public partial class PurchaseOrderReportForm : Form
    {
        public PurchaseOrderReportForm()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 供应商code
        /// </summary>
        private string _supplierCode;
        public string SupplierCode
        {
            get {return _supplierCode; }
            set{ _supplierCode = value; }
        }
        CodingHelper ch = new CodingHelper();
        /// <summary>
        /// 窗体加载事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PurchaseOrderReportForm_Load(object sender, EventArgs e)
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

                PurchaseOrderInterface purchaseinter = new PurchaseOrderInterface();

                DataTable dt1 = ch.DataTableReCoding(purchaseinter.GetMainTable(XYEEncoding.strCodeHex(_supplierCode)));//主表
                this.labelPurchaseMain.Text = dt1.Rows.Count.ToString() + "张单据";

                DataTable dt2 = ch.DataTableReCoding(purchaseinter.GetMinorTable());//从表

                this.labelPurchaseDetile.Text = dt2.Rows.Count.ToString() + "条记录";

                if (dt1.Rows.Count == 0 || dt2.Rows.Count == 0)
                {
                    MessageBox.Show("此供应商暂无采购订单信息！请重新选择");
                    this.Close();
                    return;
                }
                for (int i = 0; i < dt1.Rows.Count; i++)
                {
                    for (int j = 0; j < dt2.Rows.Count; j++)
                    {
                        if (dt1.Rows[i]["code"].Equals(dt2.Rows[j]["mainCode"]))
                        {
                            #region 绑定列
                            superGridControlShangPing.PrimaryGrid.Rows.Insert(i, new GridRow(
                                dt1.Rows[i]["code"],
                                dt1.Rows[i]["date"],
                                dt1.Rows[i]["name"],
                                dt1.Rows[i]["phone"],
                                dt1.Rows[i]["fax"],
                                dt1.Rows[i]["deliversMethod"],
                                dt1.Rows[i]["deliversDate"],
                                dt1.Rows[i]["examine"],
                                dt1.Rows[i]["remark"],
                                dt1.Rows[i]["checkState"],
                                dt2.Rows[j]["code"],
                                dt2.Rows[j]["materialDaima"],
                                dt2.Rows[j]["name"],
                                dt2.Rows[j]["model"],
                                dt2.Rows[j]["barCode"],
                                dt2.Rows[j]["unit"],
                                dt2.Rows[j]["materialNumber"],
                                dt2.Rows[j]["price"],
                                dt2.Rows[j]["materialMoney"],
                                dt2.Rows[j]["discountRate"],
                                dt2.Rows[j]["VATRate"],
                                dt2.Rows[j]["allNumber"],
                                dt2.Rows[j]["materialcode"]
                                ));

                            #endregion
                        }
                        else
                        {
                            continue;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("错误代码：3201-采购订单序时薄初始化数据错误！"+ex.Message, "销售订单序时薄温馨提示！");
                this.Close();
            }

        }

        #region 设置窗体无边框可以拖动
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;



        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();

        private void PurchaseOrderReportForm_MouseDown(object sender, MouseEventArgs e)
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
        private void PurchaseOrderReportForm_KeyDown(object sender, KeyEventArgs e)
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
        /// 行点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void superGridControlShangPing_CellDoubleClick(object sender, DevComponents.DotNetBar.SuperGrid.GridCellDoubleClickEventArgs e)
        {
          
            try
            {
                if (superGridControlShangPing.PrimaryGrid.GetSelectedRows() != null)
                {
                    SelectedElementCollection col = superGridControlShangPing.PrimaryGrid.GetSelectedRows();
                    if (col.Count > 0)
                    {
                        GridRow row = col[0] as GridRow;
                        string mainCode = row.Cells["DanJuCode"].Value.ToString();
                        string code = row.Cells["purchaseDetilecode"].Value.ToString();
                        string shangPinCode = row.Cells["gridColumnmaterialcode"].Value.ToString();
                        string jiaohuofangshi = row.Cells["JiaoHuoMethod"].Value.ToString();
                        PurchaseTicketForm purchaseTicket = (PurchaseTicketForm)this.Owner;
                        purchaseTicket.PurchaseMainCodel = mainCode;
                        purchaseTicket.PurchaseCode = code;
                        purchaseTicket.ShangPinCode = shangPinCode;
                        purchaseTicket.JiaoHuoFangShi = jiaohuofangshi;
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
                MessageBox.Show("错误代码：3202-尝试双击表格选中行失败！请检查：" + ex.Message, "销售订单序时薄温馨提示！");
            }
        }
    }
}
