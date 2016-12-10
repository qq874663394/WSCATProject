using DevComponents.DotNetBar.SuperGrid;
using HelperUtility.Encrypt;
using InterfaceLayer.Finance;
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

namespace WSCATProject.Finance
{
    public partial class FinanceVoucherManagementForm : Form
    {
        public FinanceVoucherManagementForm()
        {
            InitializeComponent();
        }
        private int _indexRows;//supergrid当前选中行索引
        public static string Updatecode;//修改按钮传递当前选中行的code
        FinanceVoucherManagementInterface financeVoucherManagementInterface = new FinanceVoucherManagementInterface();
        public int _IndexRows { get; set; }
        public static int type;
        #region 设置窗体无边框可以拖动
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();

        private void FinanceVoucherManagementForm_MouseDown(object sender, MouseEventArgs e)
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

        /// <summary>
        /// 最大化
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// 最小化
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pictureBoxMin_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        /// <summary>
        /// 关闭窗体
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pictureBoxClose_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
        }
        #endregion

        #region 改变边框颜色
        /// <summary>
        /// 改变边框颜色
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void panel_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics,
                                 this.panel1.ClientRectangle,
                                 Color.FromArgb(85, 177, 238),
                                 1,
                                ButtonBorderStyle.Solid,
                                 Color.FromArgb(85, 177, 238),
                                 1,
                                 ButtonBorderStyle.Solid,
                                  Color.White,
                                 1,
                                 ButtonBorderStyle.Solid,
                                  Color.FromArgb(85, 177, 238),
                                 1,
                                 ButtonBorderStyle.Solid);
        }
        #endregion
        /// <summary>
        /// 窗体加载事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FinanceVoucherManagementForm_Load(object sender, EventArgs e)
        {
            //显示行号
            superGridControlPingZheng.PrimaryGrid.ShowRowGridIndex = true;
            //不可自动添加列
            this.superGridControlPingZheng.PrimaryGrid.AutoGenerateColumns = false;
            ///是否显示滚动条
            superGridControlPingZheng.HScrollBarVisible = true;
            //表格内容居中
            superGridControlPingZheng.DefaultVisualStyles.CellStyles.Default.Alignment =
            DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleCenter;
            superGridControlPingZheng.PrimaryGrid.SelectionGranularity = SelectionGranularity.Row;//选中模式
            //绑定supergird数据
            #region
            DataTable dt = new DataTable();
            dt = financeVoucherManagementInterface.SelectData();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (i >= 0)
                {
                    //新增行
                    superGridControlPingZheng.PrimaryGrid.NewRow(superGridControlPingZheng.PrimaryGrid.Rows.Count);
                }
                GridRow gr = (GridRow)superGridControlPingZheng.PrimaryGrid.Rows[i];   //获取
                //主表数据判断与填充
                if (i >= 1)
                {
                    if (dt.Rows[i]["examineState"].ToString() == dt.Rows[i - 1]["examineState"].ToString() && dt.Rows[i]["date"].ToString() == dt.Rows[i - 1]["date"].ToString())
                    {
                    }
                    else
                    {
                        if (dt.Rows[i]["examineState"].ToString() == "0")
                        {
                            gr["gridColumnShengHe"].Value = "未审核";
                        }
                        else
                        {
                            gr["gridColumnShengHe"].Value = "已审核";
                        }
                        gr["gridColumnDate"].Value = dt.Rows[i]["date"].ToString();
                    }
                }
                //第一行数据的赋值
                else
                {
                    if (dt.Rows[i]["examineState"].ToString() == "0")
                    {
                        gr["gridColumnShengHe"].Value = "未审核";
                    }
                    else
                    {
                        gr["gridColumnShengHe"].Value = "已审核";
                    }
                    gr["gridColumnDate"].Value = dt.Rows[i]["date"].ToString();
                }
                //子表字段
                gr["gridColumnZhaiYao"].Value = XYEEncoding.strHexDecode(dt.Rows[i][8].ToString());
                gr["gridColumnJieFang"].Value = dt.Rows[i][9].ToString();
                gr["gridColumnDaiFang"].Value = dt.Rows[i][10].ToString();
                gr["gridColumnMakeMan"].Value = XYEEncoding.strHexDecode(dt.Rows[i][5].ToString());
                gr["gridColumnGuoZhangMan"].Value = XYEEncoding.strHexDecode(dt.Rows[i][4].ToString());
                gr["gridColumnShengHeMan"].Value = XYEEncoding.strHexDecode(dt.Rows[i][3].ToString());
                gr["gridColumnCode"].Value = dt.Rows[i][1].ToString();
            }
            #endregion

        }
        /// <summary>
        /// 新增按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripBtnInsert_Click(object sender, EventArgs e)
        {
            //打开凭证录入窗体，隐藏当前窗体
            FinanceVoucherEntryForm financeVoucherEntryForm = new FinanceVoucherEntryForm();
            financeVoucherEntryForm.ShowDialog();

        }

        private void FinanceVoucherManagementForm_KeyDown(object sender, KeyEventArgs e)
        {
            //新增
            if (e.Modifiers.CompareTo(Keys.Control) == 0 && e.KeyCode == Keys.W)
            {
                MessageBox.Show("新增！");
                return;
            }
            //复制
            if (e.Modifiers.CompareTo(Keys.Control) == 0 && e.KeyCode == Keys.C)
            {
                MessageBox.Show("复制！");
                return;
            }
            //修改
            if (e.Modifiers.CompareTo(Keys.Control) == 0 && e.KeyCode == Keys.U)
            {
                MessageBox.Show("修改！");
                return;
            }
            //删除
            if (e.Modifiers.CompareTo(Keys.Control) == 0 && e.KeyCode == Keys.D)
            {
                MessageBox.Show("删除！");
                return;
            }
            //审核
            if (e.Modifiers.CompareTo(Keys.Control) == 0 && e.KeyCode == Keys.E)
            {
                MessageBox.Show("审核！");
                return;
            }
            //关闭
            if (e.Modifiers.CompareTo(Keys.Control) == 0 && e.KeyCode == Keys.X)
            {
                this.Close();
                this.Dispose();
            }
        }

        /// <summary>
        /// 修改按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripBtnHuanYuan_Click(object sender, EventArgs e)
        {
            type = 0;
            //打开凭证录入窗体
            GridRow gr = (GridRow)superGridControlPingZheng.PrimaryGrid.Rows[_IndexRows];
            Updatecode = gr["gridColumnCode"].Value.ToString();
            FinanceVoucherEntryForm financeVoucherEntryForm = new FinanceVoucherEntryForm();
            financeVoucherEntryForm.ShowDialog();
        }

        /// <summary>
        /// 删除按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripBtnShangChu_Click(object sender, EventArgs e)
        {
            GridRow gr = (GridRow)superGridControlPingZheng.PrimaryGrid.Rows[_IndexRows];//获取要删除行的数据
            string delCode = gr["gridColumnCode"].Value.ToString();
            int rowindex = Convert.ToInt32(superGridControlPingZheng.PrimaryGrid.GridIndex);//获取行号
            int falg = financeVoucherManagementInterface.DeleteData("proc_FVEManagment", delCode);
            if (falg == 1)
            {
                //删除表中的选中行
                superGridControlPingZheng.PrimaryGrid.Rows.RemoveAt(rowindex);

                MessageBox.Show("删除成功！");
            }
            else
            {
                MessageBox.Show("删除失败！");

            }
        }
        /// <summary>
        /// supergrid按键触发事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void superGridControlPingZheng_KeyDown(object sender, KeyEventArgs e)
        {
            _indexRows = superGridControlPingZheng.PrimaryGrid.ActiveRow.Index; //获取当前选中行
        }

        private void toolStripBtnWaiBi_Click(object sender, EventArgs e)
        {
            type = 1;
            //打开凭证录入窗体
            GridRow gr = (GridRow)superGridControlPingZheng.PrimaryGrid.Rows[_IndexRows];
            Updatecode = gr["gridColumnCode"].Value.ToString();
            FinanceVoucherEntryForm financeVoucherEntryForm = new FinanceVoucherEntryForm();
            financeVoucherEntryForm.ShowDialog();
        }
    }
}
