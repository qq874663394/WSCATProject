using DevComponents.DotNetBar.SuperGrid;
using DevComponents.DotNetBar.SuperGrid.Style;
using HelperUtility;
using HelperUtility.Encrypt;
using InterfaceLayer.Finance;
using Model.Finance;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WSCATProject.Base;

namespace WSCATProject.Finance
{
    public partial class FinanceVoucherEntryForm : Form
    {
        public FinanceVoucherEntryForm()
        {
            InitializeComponent();
        }

        private object _cellValue;
        private int _indexRows;
        private string code;
        public object _CellValue { get; set; }
        public int _IndexRows { get; set; }
        FinanceVoucherEntryInterface fve = new FinanceVoucherEntryInterface();

        #region 设置窗体无边框可以拖动
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();

        private void FinanceVoucherEntryForm_MouseDown(object sender, MouseEventArgs e)
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
        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics,
                                 this.panel2.ClientRectangle,
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

        #region 获取dateTimePicker年份月份的值
        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            DateTime date = DateTime.Parse(dateTimePicker1.Text);
            string year = date.Year.ToString();
            string month = date.Month.ToString();
            lblyear.Text = year + " 年";
            lblmonth.Text = "第 " + month + " 期";

        }
        #endregion

        #region 合并表头
        private ColumnGroupHeader GetSlCompanyInfoHeader(GridColumnCollection columns, string name, string headerText, string startName, string endName)
        {
            ColumnGroupHeader cgh = new ColumnGroupHeader();

            cgh.Name = name;
            cgh.HeaderText = headerText;

            cgh.MinRowHeight = 36;
            cgh.RowHeight = 50;

            cgh.StartDisplayIndex = GetDisplayIndex(columns, startName);
            cgh.EndDisplayIndex = GetDisplayIndex(columns, endName);

            return (cgh);
        }
        private int GetDisplayIndex(GridColumnCollection columns, string name)
        {
            return (columns.GetDisplayIndex(columns[name]));
        }
        #endregion

        #region 统计合计行
        /// <summary>
        /// 统计行数据
        /// </summary>
        private void InitDataGridView()
        {
            //新增一行 用于给客户操作
            superGridControlPingZheng.PrimaryGrid.NewRow(true);
            //最后一行做统计行
            GridRow gr = (GridRow)superGridControlPingZheng.PrimaryGrid.
                Rows[superGridControlPingZheng.PrimaryGrid.Rows.Count - 1];
            gr.ReadOnly = true;
            gr.AllowSelection = false;
            gr.CellStyles.Default.Background.Color1 = Color.Yellow;
        }
        #endregion

        /// <summary>
        /// 加载事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FinanceVoucherEntryForm_Load(object sender, EventArgs e)
        {
            #region 加载时，初始化表格

            GridPanel panel = superGridControlPingZheng.PrimaryGrid;
            GridColumnCollection columns = panel.Columns;
            panel.ColumnHeader.GroupHeaders.Add(GetSlCompanyInfoHeader(columns, "gridColumnSubject", "借方", "gridColumn1", "gridColumn19"));
            panel.ColumnHeader.GroupHeaders.Add(GetSlCompanyInfoHeader(columns, "gridColumn19", "贷方", "gridColumn20", "gridColumn38"));

            superGridControlPingZheng.PrimaryGrid.ColumnHeader.ShowGroupColumnHeaders = false;//合并表头后，是否显示原有的列
            superGridControlPingZheng.PrimaryGrid.AutoGenerateColumns = false;//禁止自动创建列
            superGridControlPingZheng.DefaultVisualStyles.CellStyles.Default.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleCenter;//内容居中           
            superGridControlPingZheng.PrimaryGrid.ShowRowGridIndex = true;//显示行号
            pictureBoxMin.Parent = pictureBoxtitle;
            pictureBoxMax.Parent = pictureBoxtitle;
            pictureBoxClose.Parent = pictureBoxtitle;
            cboPingZhengZi.SelectedIndex = 0;
            superGridControlPingZheng.PrimaryGrid.GridLines = GridLines.Horizontal;//只允许显示行线
            //排序方式范围
            superGridControlPingZheng.PrimaryGrid.SortCycle = SortCycle.AscDesc;
            //设置排序列和排序方式
            superGridControlPingZheng.PrimaryGrid.AddSort(superGridControlPingZheng.PrimaryGrid.Columns[0], SortDirection.Ascending);
            InitDataGridView();//调用统计行

            //GridTextBoxXEditControl gdiec1 = superGridControlPingZheng.PrimaryGrid.Columns["gridColumn1"].EditControl as GridTextBoxXEditControl;
            // gdiec1.EditorValue = "";
            //GridTextBoxXEditControl gdiec2 = superGridControlPingZheng.PrimaryGrid.Columns["gridColumn2"].EditControl as GridTextBoxXEditControl;
            //gdiec2.MaxValue = 9;
            //gdiec2.MinValue = 0;

            #region  获取日期值
            DateTime date = DateTime.Parse(dateTimePicker1.Text);
            string year = date.Year.ToString();
            string month = date.Month.ToString();
            lblyear.Text = year + " 年";
            lblmonth.Text = "第 " + month + " 期";
            #endregion

            #endregion
            #region 凭证管理修改按钮跳转
            FinanceVoucherManagementForm financeVoucherManagementForm = new FinanceVoucherManagementForm();
            //判断是否存在updatecode
            if (!string.IsNullOrWhiteSpace(FinanceVoucherManagementForm.Updatecode))
            {
                if (FinanceVoucherManagementForm.type == 1)
                {
                    toolStripBtnShenHe.Visible = true;
                }
                else

                {
                    toolStripBtnShenHe.Visible = false;
                }
                FinanceVoucherManagementInterface fvmi = new FinanceVoucherManagementInterface();
                DataTable dt = new DataTable();
                try
                {
                    //清空现有的文本数据
                    //清空行
                    superGridControlPingZheng.PrimaryGrid.Rows.Clear();
                    //新增统计行
                    InitDataGridView();
                    this.lblcode.Text = null;
                    this.ltxtbMakeMan.Text = null;
                    this.ltxtbShengHeMan.Text = null;
                    this.ltxtbSalsMan.Text = null;
                    this.dateTimePicker1.Value = DateTime.Now;
                    //下页变成不可点击
                    this.toolStripBtnHouDan.Enabled = false;
                    //上页变成可点击
                    this.toolStripBtnQianDan.Enabled = true;
                    dt = fvmi.GetUpdateData(FinanceVoucherManagementForm.Updatecode);
                    //文本框赋值
                    this.ltxtbMakeMan.Text = XYEEncoding.strHexDecode(dt.Rows[0][2].ToString());
                    this.ltxtbShengHeMan.Text = XYEEncoding.strHexDecode(dt.Rows[0][3].ToString());
                    this.ltxtbSalsMan.Text = XYEEncoding.strHexDecode(dt.Rows[0][4].ToString());
                    this.dateTimePicker1.Value = DateTime.Parse(dt.Rows[0][1].ToString());
                    this.lblcode.Text = dt.Rows[0][0].ToString();
                    InitSupergridView(dt);
                }
                catch
                {
                    //获取数据失败
                }
            }
            #endregion

        }

        /// <summary>
        /// 计算器点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripBtnJiSuanQi_Click(object sender, EventArgs e)
        {
            Process sysCalculator = null;
            sysCalculator = Process.Start("calc.exe");
        }

        /// <summary>
        /// 还原点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripBtnHuanYuan_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("凭证已经修改，是否保存？", "信息提示", MessageBoxButtons.YesNoCancel);
            if (result == DialogResult.OK)
            {
                MessageBox.Show("暂不能进行保存！");
            }
            if (result == DialogResult.No)
            {
                numericUpDownFuJian.Value = 0;
                numericUpDownXuHao.Value = 0;
                superGridControlPingZheng.PrimaryGrid.Rows.Clear();
                FinanceVoucherEntryForm_Load(sender, e);
            }
            return;
        }

        /// <summary>
        /// 插入点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButtonChaRu_Click(object sender, EventArgs e)
        {
            InitDataGridView();
        }

        private void superGridControlPingZheng_EditorValueChanged(object sender, GridEditEventArgs e)
        {
            //e.EditControl.EditorValue = _CellValue;
        }
        private void superGridControlPingZheng_GridPreviewKeyDown(object sender, GridPreviewKeyDownEventArgs e)
        {
            //_IndexRows = superGridControlPingZheng.PrimaryGrid.ActiveRow.Index;
            GridColumn[] item1 = { gridColumn1, gridColumn2, gridColumn3, gridColumn4, gridColumn5, gridColumn6, gridColumn7, gridColumn8, gridColumn9, gridColumn10, gridColumn11, gridColumn12, gridColumn13, gridColumn14, gridColumn15, gridColumn16, gridColumn17 };
            GridColumn[] item2 = { gridColumn18, gridColumn19 };
            GridRow gr = (GridRow)superGridControlPingZheng.PrimaryGrid.Rows[_IndexRows];   //获取
            SelectedElementCollection ge = superGridControlPingZheng.PrimaryGrid.GetSelectedCells();
            GridCell gc = null;
            object str = "";
            if (ge.Count <= 0)
            {
                return;
            }
            gc = ge[0] as GridCell;

            //MessageBox.Show(gc.ColumnIndex.ToString());
            //if (true)
            //{

            //    return;
            //}
            #region 验证按键
            switch (e.KeyCode)
            {
                case Keys.Decimal:
                case Keys.OemPeriod:
                case Keys.ProcessKey:
                    str = ".";
                    break;
                case Keys.NumPad0:
                case Keys.D0:
                    str = "0";
                    break;
                case Keys.NumPad1:
                case Keys.D1:
                    str = "1";
                    break;
                case Keys.NumPad2:
                case Keys.D2:
                    str = "2";
                    break;
                case Keys.NumPad3:
                case Keys.D3:
                    str = "3";
                    break;
                case Keys.NumPad4:
                case Keys.D4:
                    str = "4";
                    break;
                case Keys.NumPad5:
                case Keys.D5:
                    str = "5";
                    break;
                case Keys.NumPad6:
                case Keys.D6:
                    str = "6";
                    break;
                case Keys.NumPad7:
                case Keys.D7:
                    str = "7";
                    break;
                case Keys.NumPad8:
                case Keys.D8:
                    str = "8";
                    break;
                case Keys.NumPad9:
                case Keys.D9:
                    str = "9";
                    break;
                case Keys.Back:
                case Keys.Delete:
                    str = "\b";
                    break;
                default:
                    str = null;
                    break;
            }
            #endregion
            if (str == null)
            {
                return;
            }
            if (gc.ColumnIndex >= 2 && gc.ColumnIndex <= 18)//借方左边
            {
                #region 左删除
                if (e.KeyCode == Keys.ProcessKey)
                {
                    gr["gridColumn18"].SetActive();
                    gr["gridColumn18"].IsSelected = true;
                    gr["gridColumn17"].IsSelected = false;
                    gr["gridColumn17"].Value = _CellValue;
                    return;
                }
                //左删除
                if (gr["gridColumn17"].IsActiveCell == true || gr["gridColumn17"].AllowSelection == true)//焦点在左边输入点
                {
                    if (str.Equals("\b"))//按键是退格键
                    {
                        for (int i = item1.Length - 1; i >= 0; i--)
                        {
                            gr = (GridRow)superGridControlPingZheng.PrimaryGrid.Rows[_IndexRows];
                            if ((i - 1) >= 0)
                            {
                                if (i == item1.Length - 1)
                                {
                                    //    if (superGridControlPingZheng.EditorCell//gr["gridColumn17"].EditControl.EditorValue==null)
                                    //    {
                                    //        gr["gridColumn17"].EditControl.EditorValue = gr["gridColumn16"].Value;
                                    //    }
                                    gr["gridColumn17"].Value = gr["gridColumn16"].Value;
                                }
                                gr[item1[i]].Value = gr[item1[i - 1]].Value;
                                gr[item1[i - 1]].Value = null;
                                _CellValue = null;
                            }
                        }
                        return;
                    }
                }
                if (gr[item1[0]].Value != null)
                {
                    if (!string.IsNullOrEmpty(gr["gridColumn1"].Value.ToString()))
                    {
                        return;
                    }
                }

                //左移动
                for (int i = 0; i < item1.Length - 1; i++)
                {
                    gr = (GridRow)superGridControlPingZheng.PrimaryGrid.Rows[_IndexRows];   //获取双击进去后处于编辑状态的行
                    if ((i + 1) <= item1.Length - 1)//下一条数组不能大于总长度
                    {
                        if (gr[item1[i + 1]].Value == null)//如果等于null 可以移动
                        {
                            gr[item1[i]].Value = gr[item1[i + 1]].Value;
                            gr[item1[i + 1]].Value = null;
                        }
                        else
                        {
                            if (gr[item1[i + 1]].Value.ToString() == "" || gr[item1[i + 1]].Value.ToString() == ".")//如果等于空字符串  则赋值为null
                            {
                                gr[item1[i]].Value = _CellValue;
                                gr[item1[i + 1]].Value = null;
                            }
                            else//如果不为null也不为空字符串  就正常移动
                            {
                                gr[item1[i]].Value = gr[item1[i + 1]].Value;
                                gr[item1[i + 1]].Value = null;
                            }
                        }
                    }
                }
                SelectedElementCollection sec = superGridControlPingZheng.GetSelectedCells();
                if (gr[(sec[0] as GridCell).GridColumn.Name].Value == null)
                {
                    gr[(sec[0] as GridCell).GridColumn.Name].Value = str;

                }
                if (_CellValue != null)//如果全局变量不等于null就赋值给源单元格前一个单元格
                {
                    gr["gridColumn17"].Value = str;
                    gr["gridColumn16"].Value = _CellValue;
                }
                #endregion
            }
            else if (gc.ColumnIndex >= 19 && gc.ColumnIndex <= 20)//借方右边
            {

                //superGridControlPingZheng.GetSelectedCells();
                gr["gridColumn18"].Value = str;
            }
            else if (gc.ColumnIndex >= 21 && gc.ColumnIndex <= 37)//贷方左边
            {
                #region 左删除
                if (e.KeyCode == Keys.ProcessKey)
                {
                    gr["gridColumn37"].SetActive();
                    gr["gridColumn37"].IsSelected = true;
                    gr["gridColumn36"].IsSelected = false;
                    gr["gridColumn36"].Value = _CellValue;
                    return;
                }
                //左删除
                if (gr["gridColumn36"].IsActiveCell == true || gr["gridColumn36"].AllowSelection == true)//焦点在左边输入点
                {
                    if (str.Equals("\b"))//按键是退格键
                    {
                        for (int i = item1.Length - 1; i >= 0; i--)
                        {
                            gr = (GridRow)superGridControlPingZheng.PrimaryGrid.Rows[_IndexRows];
                            if ((i - 1) >= 0)
                            {
                                if (i == item1.Length - 1)
                                {
                                    //    if (superGridControlPingZheng.EditorCell//gr["gridColumn17"].EditControl.EditorValue==null)
                                    //    {
                                    //        gr["gridColumn17"].EditControl.EditorValue = gr["gridColumn16"].Value;
                                    //    }
                                    gr["gridColumn37"].Value = gr["gridColumn36"].Value;
                                }
                                gr[item1[i]].Value = gr[item1[i - 1]].Value;
                                gr[item1[i - 1]].Value = null;
                                _CellValue = null;
                            }
                        }
                        return;
                    }
                }
                if (gr[item1[0]].Value != null)
                {
                    if (!string.IsNullOrEmpty(gr["gridColumn21"].Value.ToString()))
                    {
                        return;
                    }
                }

                //左移动
                for (int i = 0; i < item1.Length - 1; i++)
                {
                    gr = (GridRow)superGridControlPingZheng.PrimaryGrid.Rows[_IndexRows];   //获取双击进去后处于编辑状态的行
                    if ((i + 1) <= item1.Length - 1)//下一条数组不能大于总长度
                    {
                        if (gr[item1[i + 1]].Value == null)//如果等于null 可以移动
                        {
                            gr[item1[i]].Value = gr[item1[i + 1]].Value;
                            gr[item1[i + 1]].Value = null;
                        }
                        else
                        {
                            if (gr[item1[i + 1]].Value.ToString() == "" || gr[item1[i + 1]].Value.ToString() == ".")//如果等于空字符串  则赋值为null
                            {
                                gr[item1[i]].Value = _CellValue;
                                gr[item1[i + 1]].Value = null;
                            }
                            else//如果不为null也不为空字符串  就正常移动
                            {
                                gr[item1[i]].Value = gr[item1[i + 1]].Value;
                                gr[item1[i + 1]].Value = null;
                            }
                        }
                    }
                }
                SelectedElementCollection sec = superGridControlPingZheng.GetSelectedCells();
                if (gr[(sec[0] as GridCell).GridColumn.Name].Value == null)
                {
                    gr[(sec[0] as GridCell).GridColumn.Name].Value = str;

                }
                if (_CellValue != null)//如果全局变量不等于null就赋值给源单元格前一个单元格
                {
                    gr["gridColumn17"].Value = str;
                    gr["gridColumn16"].Value = _CellValue;
                }
                #endregion
            }
            else if (gc.ColumnIndex >= 38 && gc.ColumnIndex <= 39)//贷方右边
            {

            }
            _CellValue = str;//将获取的字符赋值给全局变量,用于下一次输入后把上一次输入的赋值给前一个单元格
        }
        /// <summary>
        /// 删除当前分录
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripBtnShangChu_Click(object sender, EventArgs e)
        {
            int rowindex = Convert.ToInt32(superGridControlPingZheng.PrimaryGrid.GridIndex);//获取行号
            if (superGridControlPingZheng.PrimaryGrid.Rows.Count > 2)
            {
                superGridControlPingZheng.PrimaryGrid.Rows.RemoveAt(rowindex);
            }
        }

        /// <summary>
        /// 查看代码点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripBtnDaiMa_Click(object sender, EventArgs e)
        {
            LookDaiMa();
        }

        /// <summary>
        /// 查看代码函数
        /// </summary>
        private void LookDaiMa()
        {
            try
            {
                SelectedElementCollection ge = superGridControlPingZheng.PrimaryGrid.GetSelectedCells();
                GridCell gc = ge[0] as GridCell;
                if (gc.GridColumn.Name == "gridColumnSubject")
                {
                    AccountingSubjectsForm accountSubject = new AccountingSubjectsForm();
                    accountSubject.ShowDialog(this);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// 快捷方式设置
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FinanceVoucherEntryForm_KeyDown(object sender, KeyEventArgs e)
        {
            //上一站凭证
            if (e.Modifiers.CompareTo(Keys.Control) == 0 && e.KeyCode == Keys.B)
            {
                MessageBox.Show("上一站凭证！");
                return;
            }
            //下一张凭证
            if (e.Modifiers.CompareTo(Keys.Control) == 0 && e.KeyCode == Keys.A)
            {
                MessageBox.Show("下一张凭证！");
                return;
            }
            //新增凭证
            if (e.Modifiers.CompareTo(Keys.Control) == 0 && e.KeyCode == Keys.N)
            {
                MessageBox.Show("新增凭证！");
                return;
            }
            //保存凭证
            if (e.Modifiers.CompareTo(Keys.Control) == 0 && e.KeyCode == Keys.S)
            {
                MessageBox.Show("保存凭证！");
                return;
            }
            //打印凭证
            if (e.Modifiers.CompareTo(Keys.Control) == 0 && e.KeyCode == Keys.P)
            {
                MessageBox.Show("保存凭证！");
                return;
            }
            //取消所做的更改
            if (e.KeyCode == Keys.Z)
            {
                toolStripBtnHuanYuan_Click(sender, e);
                return;
            }
            //插入一条分录
            if (e.Modifiers.CompareTo(Keys.Control) == 0 && e.KeyCode == Keys.I)
            {
                InitDataGridView();
                return;
            }
            //删除一条分录
            if (e.Modifiers.CompareTo(Keys.Control) == 0 && e.KeyCode == Keys.D)
            {
                toolStripBtnShangChu_Click(sender, e);
                return;
            }
            //查看代码
            if (e.Modifiers.CompareTo(Keys.Control) == 0 && e.KeyCode == Keys.F7)
            {
                LookDaiMa();
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
        /// 光标定位
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FinanceVoucherEntryForm_Activated(object sender, EventArgs e)
        {
            superGridControlPingZheng.Focus();
        }

        private void superGridControlPingZheng_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SelectedElementCollection ge = superGridControlPingZheng.PrimaryGrid.GetSelectedCells();
                GridCell gc = ge[0] as GridCell;
                if (gc.GridColumn.Name == "gridColumnSubject")
                {
                    MessageBox.Show("科目无权使用或不存在！");
                }
            }
        }

        private void superGridControlPingZheng_CellClick(object sender, GridCellClickEventArgs e)
        {
            //MessageBox.Show(_IndexRows.ToString());

        }

        /// <summary>
        /// supergrid数据填充
        /// </summary>
        /// <param name="dt"></param>
        public void InitSupergridView(DataTable dt)
        {
            //清空行
            superGridControlPingZheng.PrimaryGrid.Rows.Clear();
            //新增统计行
            InitDataGridView();
            GridColumn[] item1 = { gridColumn17, gridColumn16, gridColumn15, gridColumn14, gridColumn13, gridColumn12, gridColumn11, gridColumn10, gridColumn9, gridColumn8, gridColumn7, gridColumn6, gridColumn5, gridColumn4, gridColumn3, gridColumn2, gridColumn1 };
            GridColumn[] item2 = { gridColumn36, gridColumn35, gridColumn34, gridColumn33, gridColumn32, gridColumn31, gridColumn30, gridColumn29, gridColumn28, gridColumn27, gridColumn26, gridColumn25, gridColumn24, gridColumn23, gridColumn22, gridColumn21, gridColumn20 };
            for (int i = 0; i < dt.Rows.Count; i++)
            {

                if (i > 0)
                {
                    //新增行
                    superGridControlPingZheng.PrimaryGrid.NewRow(superGridControlPingZheng.PrimaryGrid.Rows.Count);
                }
                GridRow gr = (GridRow)superGridControlPingZheng.PrimaryGrid.Rows[i];   //获取
                gr["gridColumnZhaiYao"].Value = XYEEncoding.strHexDecode(dt.Rows[i][7].ToString());
                gr["gridColumnSubject"].Value = XYEEncoding.strHexDecode(dt.Rows[i][8].ToString());
                gr["gridColumncode"].Value = dt.Rows[i]["code"].ToString();
                string de = dt.Rows[i][9].ToString();
                int first1 = de.IndexOf(".", 0); //截取小数点位置的索引
                //借方金额
                for (int n = 0; n < first1; n++)
                {
                    gr[item1[n]].Value = de.Substring(first1 - n - 1, 1);
                }
                gr["gridColumn18"].Value = de.Substring(first1 + 1, 1);
                gr["gridColumn19"].Value = de.Substring(first1 + 2, 1);
                string cre = dt.Rows[i][10].ToString();
                int first2 = cre.IndexOf(".", 0); //截取小数点位置的索引
                //贷方金额
                for (int n = 0; n < first2; n++)
                {
                    gr[item2[n]].Value = cre.Substring(first2 - n - 1, 1);
                }
                gr["gridColumn37"].Value = cre.Substring(first2 + 1, 1);
                gr["gridColumn38"].Value = cre.Substring(first2 + 2, 1);
            }
            superGridControlPingZheng.PrimaryGrid.NewRow(superGridControlPingZheng.PrimaryGrid.Rows.Count);
        }

        /// <summary>
        /// 上一单按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripBtnQianDan_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            try
            {
                //判断是否code是否存在
                if (string.IsNullOrWhiteSpace(this.lblcode.Text))
                {
                    code = fve.GetNewCode();
                    dt = fve.GetFLastDetail(code);
                }
                else
                {
                    code = this.lblcode.Text;
                    dt = fve.GetLastDetail(code);
                    toolStripBtnHouDan.Enabled = true;
                }

                //文本框赋值
                this.ltxtbMakeMan.Text = XYEEncoding.strHexDecode(dt.Rows[0][2].ToString());
                this.ltxtbShengHeMan.Text = XYEEncoding.strHexDecode(dt.Rows[0][3].ToString());
                this.ltxtbSalsMan.Text = XYEEncoding.strHexDecode(dt.Rows[0][4].ToString());
                this.dateTimePicker1.Value = DateTime.Parse(dt.Rows[0][1].ToString());
                this.lblcode.Text = dt.Rows[0][0].ToString();
                InitSupergridView(dt);
                //判断是否到上限
                string lcode = dt.Rows[0][0].ToString();
                dt = fve.GetLastDetail(lcode);
                if (dt.Rows.Count == 0)
                {
                    toolStripBtnQianDan.Enabled = false; //上一单没有数据
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("错误代码：2106-尝试点击后单数据错误" + ex.Message, "财务凭证条目单温馨提示");
            }
        }


        /// <summary>
        /// 金额单元格合并
        /// </summary>
        /// <param name="num">1借方金额，2贷方金额</param>
        /// <param name="i">for循环参数</param>
        /// <returns></returns>
        private string Money(int num, int i)
        {
            GridColumn[] item1 = { gridColumn17, gridColumn16, gridColumn15, gridColumn14, gridColumn13, gridColumn12, gridColumn11, gridColumn10, gridColumn9, gridColumn8, gridColumn7, gridColumn6, gridColumn5, gridColumn4, gridColumn3, gridColumn2, gridColumn1 };
            GridColumn[] item2 = { gridColumn36, gridColumn35, gridColumn34, gridColumn33, gridColumn32, gridColumn31, gridColumn30, gridColumn29, gridColumn28, gridColumn27, gridColumn26, gridColumn25, gridColumn24, gridColumn23, gridColumn22, gridColumn21, gridColumn20 };
            GridRow gr = (GridRow)superGridControlPingZheng.PrimaryGrid.Rows[i - 1];   //获取
            string money = ""; //金额
            //借方
            if (num == 1)
            {
                for (int j = item1.Length - 1; j > 0; j--)
                {
                    if (!string.IsNullOrWhiteSpace(gr[item1[j]].Value == null ? "" : gr[item1[j]].Value.ToString()))
                    {
                        money += gr[item1[j]].Value.ToString();
                    }
                }
            }
            //贷方
            else
            {
                for (int j = item2.Length - 1; j >= 0; j--)
                {
                    if (!string.IsNullOrWhiteSpace(gr[item2[j]].Value == null ? "" : gr[item2[j]].Value.ToString()))
                    {
                        money += gr[item2[j]].Value.ToString();
                    }
                }
            }
            return money;
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
        /// 保存方法
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Save()
        {
            FinanceVoucherEntryMain financeVoucherEntry = new FinanceVoucherEntryMain();
            //其它收款单详细列表
            List<FinanceVoucherEntryDetail> financeVoucherEntryDetail = new List<FinanceVoucherEntryDetail>();
            try
            {
                //其它收款单
                if (string.IsNullOrWhiteSpace(this.lblcode.Text))
                {
                    financeVoucherEntry.code = XYEEncoding.strCodeHex(BuildCode.ModuleCode("FVEM"));  //其它收款单单号
                }
                else
                {
                    financeVoucherEntry.code = this.lblcode.Text;
                }
                financeVoucherEntry.date = DateTime.Now;
                financeVoucherEntry.examine = XYEEncoding.strCodeHex(ltxtbShengHeMan.Text);
                financeVoucherEntry.examineState = 0;
                financeVoucherEntry.isClear = 1;
                financeVoucherEntry.makeMan = XYEEncoding.strCodeHex(ltxtbMakeMan.Text);
                financeVoucherEntry.posting = XYEEncoding.strCodeHex(ltxtbSalsMan.Text);

            }
            catch (Exception ex)
            {
                MessageBox.Show("错误代码:5203-尝试录入凭证数据出错!请检查:" + ex.Message, "录入凭证温馨提示");
                return;
            }

            try
            {

                //获得商品列表数据,准备传给base层新增数据
                //GridRow g = (GridRow)superGridControlPingZheng.PrimaryGrid.Rows[];
                GridItemsCollection grs = superGridControlPingZheng.PrimaryGrid.Rows;
                int i = 0;
                string detailCode = BuildCode.ModuleCode("FVED");
                DateTime nowDataTime = DateTime.Now;
                foreach (GridRow gr in grs)
                {
                    if (gr["gridColumnZhaiYao"].Value != null)
                    {
                        i++;
                        if (i == (superGridControlPingZheng.PrimaryGrid.Rows.Count))
                        {
                            break;
                        }
                        FinanceVoucherEntryDetail fved = new FinanceVoucherEntryDetail();
                        if (gr["gridColumncode"].Value != null)
                        {
                            fved.code = gr["gridColumncode"].Value.ToString();
                        }
                        else
                        {
                            fved.code = XYEEncoding.strCodeHex(detailCode + i);//其它收款单详细code 
                        }
                        fved.debitAmount = Convert.ToDecimal(Money(1, i));
                        fved.creditAmount = Convert.ToDecimal(Money(2, i));
                        fved.mainCode = financeVoucherEntry.code;//主表code 
                        fved.summary = gr["gridColumnZhaiYao"].Value == null ? "" : XYEEncoding.strCodeHex(gr["gridColumnZhaiYao"].Value.ToString());//摘要
                        fved.subject = gr["gridColumnSubject"].Value == null ? "" : XYEEncoding.strCodeHex(gr["gridColumnSubject"].Value.ToString());//科目
                        GridRow dr = superGridControlPingZheng.PrimaryGrid.Rows[0] as GridRow;
                        financeVoucherEntryDetail.Add(fved);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("错误代码：5204-尝试录入凭证数据出错!请检查:" + ex.Message, "录入凭证温馨提示");
                return;
            }
            //判断凭证录入是否成功
            object financePaymentResult = fve.AddOrUpdateToMainOrDetail(financeVoucherEntry, financeVoucherEntryDetail);
            if (financePaymentResult != null)
            {
                if (!string.IsNullOrWhiteSpace(this.lblcode.Text))
                {
                    MessageBox.Show("修改录入凭证数据成功", "录入凭证温馨提示");
                }
                else
                {
                    MessageBox.Show("新增录入凭证数据成功", "录入凭证温馨提示");
                    this.toolStripBtnHouDan.Enabled = false;
                }
                DataTable dt = new DataTable();
                dt = fve.GetLastDetail(financeVoucherEntry.code);
                if (dt.Rows.Count == 0)
                {
                    toolStripBtnQianDan.Enabled = false; //上一单没有数据
                }
                this.lblcode.Text = financeVoucherEntry.code;
            }
        }

        /// <summary>
        /// 下一单按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripBtnHouDan_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            try
            {
                code = this.lblcode.Text;
                dt = fve.GetNextDetail(code);
                //文本框赋值
                this.ltxtbMakeMan.Text = XYEEncoding.strHexDecode(dt.Rows[0][2].ToString());
                this.ltxtbShengHeMan.Text = XYEEncoding.strHexDecode(dt.Rows[0][3].ToString());
                this.ltxtbSalsMan.Text = XYEEncoding.strHexDecode(dt.Rows[0][4].ToString());
                this.dateTimePicker1.Value = DateTime.Parse(dt.Rows[0][1].ToString());
                this.lblcode.Text = dt.Rows[0][0].ToString();
                InitSupergridView(dt);
                //判断是否到上限
                string lcode = dt.Rows[0][0].ToString();
                dt = fve.GetNextDetail(lcode);
                toolStripBtnQianDan.Enabled = true;
                if (dt.Rows.Count == 0)
                {
                    toolStripBtnHouDan.Enabled = false; //上一单没有数据
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("错误代码：2106-尝试点击后单数据错误" + ex.Message, "财务凭证条目单温馨提示");
            }
        }

        /// <summary>
        /// 新增凭证
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripBtnInsert_Click(object sender, EventArgs e)
        {
            //清空现有的文本数据
            //清空行
            superGridControlPingZheng.PrimaryGrid.Rows.Clear();
            //新增统计行
            InitDataGridView();
            this.lblcode.Text = null;
            this.ltxtbMakeMan.Text = null;
            this.ltxtbShengHeMan.Text = null;
            this.ltxtbSalsMan.Text = null;
            this.dateTimePicker1.Value = DateTime.Now;
            //下页变成不可点击
            this.toolStripBtnHouDan.Enabled = false;
            //上页变成可点击
            this.toolStripBtnQianDan.Enabled = true;
            this.lblcode.Text = "";
        }

        /// <summary>
        /// 双击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void superGridControlPingZheng_DoubleClick(object sender, EventArgs e)
        {
            _IndexRows = superGridControlPingZheng.PrimaryGrid.ActiveRow.Index;
            SelectedElementCollection ge = superGridControlPingZheng.PrimaryGrid.GetSelectedCells();
            GridRow gr = (GridRow)superGridControlPingZheng.PrimaryGrid.Rows[_IndexRows];
            GridCell gc = null;
            object str = "";
            if (ge.Count <= 0)
            {
                return;
            }
            gc = ge[0] as GridCell;
            //摘要单元格
            if (gc.ColumnIndex == 0)
            {
                FinanceSummaryLibraryForm fslf = new FinanceSummaryLibraryForm();
                fslf.ShowDialog();
                if (!string.IsNullOrWhiteSpace(FinanceSummaryLibraryForm.nodeName))
                {
                    gr[0].Value = FinanceSummaryLibraryForm.nodeName;
                }
            }
            //科目
            if (gc.ColumnIndex == 1)
            {
                FinanceAccountingSubjectsForm fas = new FinanceAccountingSubjectsForm();
                fas.ShowDialog();
                if (!string.IsNullOrWhiteSpace(FinanceAccountingSubjectsForm.subjectName))
                {
                    gr[1].Value = FinanceAccountingSubjectsForm.subjectName;
                }
            }
        }
    }
}