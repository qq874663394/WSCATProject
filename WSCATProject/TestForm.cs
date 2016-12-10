using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using DevComponents.DotNetBar.SuperGrid;

namespace WSCATProject
{
    public partial class TestForm : Form
    {
        public TestForm()
        {
            InitializeComponent();
        }

        #region 需要的数据字段
        /// 当前被点击的行位置
        /// </summary>
        protected int ClickRowIndex
        {
            get; set;
        }
        private bool _clickStorage = false;
        protected bool ClickStorage
        {
            get { return _clickStorage; }
            set { _clickStorage = value; }
        }

        //控制面板是否显示
        private bool _btnAdd = false;

        protected bool BtnAdd
        {
            get { return _btnAdd; }
            set { _btnAdd = value; }
        }
        #endregion

        /// <summary>
        /// 窗体加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TestForm_Load(object sender, EventArgs e)
        {
            this.labelTitle.BackColor = Color.FromArgb(85, 177, 238);
            this.pictureBoxMax.BackColor = Color.FromArgb(85, 177, 238);
            this.pictureBoxMin.BackColor = Color.FromArgb(85, 177, 238);
            this.pictureBoxClose.BackColor = Color.FromArgb(85, 177, 238);
        }

        /// <summary>
        ///退出的按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
        }

        #region 设置窗体无边框可以拖动
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();

        private void TestForm_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }
        #endregion

        //对view添加列标题 
        protected virtual void InitDataGridViewHeaderColumn()
        {

        }

        /// <summary>
        /// 初始化上方lab
        /// </summary>
        protected virtual void InitTopLab()
        {

        }

        /// <summary>
        ///初始化上方输入框 
        /// </summary>
        protected virtual void InitTopLabText()
        {

        }

        /// <summary>
        /// 初始化下方lab
        /// </summary>
        protected virtual void InitBottomLab()
        {

        }

        /// <summary>
        /// 初始化下方输入框
        /// </summary>
        protected virtual void InitBottonLabText()
        {

        }

        /// <summary>
        /// 初始化界面按钮
        /// </summary>
        protected virtual void InitButton()
        {

        }

        /// <summary>
        /// 点击panel隐藏扩展panel
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected virtual void panel6_Click(object sender, EventArgs e)
        {
            if (resizablePanel1.Visible)
                resizablePanel1.Visible = false;
            if (resizablePanelData.Visible)
                resizablePanelData.Visible = false;
        }

        protected virtual void ClickPicBox(object sender, EventArgs e)
        {
            PictureBox pb = sender as PictureBox;
            switch (pb.Name)
            {
                case "pictureBox1":
                    resizablePanel1.Location = new Point(120, 100);
                    break;
                case "pictureBox2":
                    resizablePanel1.Location = new Point(640, 110);
                    break;
                case "pictureBox3":
                    resizablePanel1.Location = new Point(400, 130);
                    break;
                case "pictureBox4":
                    resizablePanel1.Location = new Point(120, 160);
                    break;
                case "pictureBox5":
                    resizablePanel1.Location = new Point(234, 440);
                    break;
            }
            if (!_btnAdd)
            {
                resizablePanel1.Visible = true;
                _btnAdd = true;
            }
            else
            {
                resizablePanel1.Size = new System.Drawing.Size(248, 144);
                resizablePanel1.Visible = true;
                resizablePanel1.Focus();
            }
        }


        private void superGridControlShangPing_BeginEdit(object sender, GridEditEventArgs e)
        {
            if (e.GridCell.GridColumn.Name == "material")
            {
                ClickRowIndex = e.GridCell.RowIndex;
                resizablePanelData.Visible = true;
                resizablePanelData.Location = new Point(e.GridCell.UnMergedBounds.X,
                    e.GridCell.UnMergedBounds.Bottom + panel3.Location.Y);
            }
            if (e.GridCell.GridColumn.Name == "gridColumnStock")
            {
                ClickRowIndex = e.GridCell.RowIndex;
                ClickStorage = true;
                resizablePanel1.Visible = true;
                resizablePanel1.Size = new Size(190, 120);
                resizablePanel1.Location = new Point(e.GridCell.UnMergedBounds.X,
                    e.GridCell.UnMergedBounds.Bottom + panel3.Location.Y);
            }
            if (e.GridCell.GridColumn.Name == "gridColumnStockIn")
            {
                ClickRowIndex = e.GridCell.RowIndex;
                ClickStorage = true;
                resizablePanel1.Visible = true;
                resizablePanel1.Size = new Size(190, 120);
                resizablePanel1.Location = new Point(e.GridCell.UnMergedBounds.X,
                    e.GridCell.UnMergedBounds.Bottom + panel3.Location.Y);
            }

            if (e.GridCell.GridColumn.Name == "sup1material")
            {
                ClickRowIndex = e.GridCell.RowIndex;
                resizablePanelData.Visible = true;
                resizablePanelData.Location = new Point(e.GridCell.UnMergedBounds.X,
                    e.GridCell.UnMergedBounds.Bottom + panel3.Location.Y);
            }
            if (resizablePanelData.Visible == true)
            {
                dataGridViewShangPing.Focus();
            }
        }


        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
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

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void toolStripBtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
        }

        private void pictureBox6_MouseEnter(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Maximized)
            {
                toolTip2.SetToolTip(pictureBoxMax, "还原");
                return;
            }
            if (this.WindowState == FormWindowState.Normal)
            {
                toolTip2.SetToolTip(pictureBoxMax, "最大化");
                return;
            }
        }

        private void dataGridViewFuJia_MouseEnter(object sender, EventArgs e)
        {
            ToolTip p = new ToolTip();
            p.ShowAlways = true;
            dataGridViewFuJia.ShowCellToolTips = true;
            p.SetToolTip(resizablePanel1, "按Esc键关闭");
        }

        private void dataGridViewShangPing_Leave(object sender, EventArgs e)
        {
            
        }

        private void dataGridViewFuJia_Leave(object sender, EventArgs e)
        {
            resizablePanel1.Visible = false;
        }        //获取鼠标的位置

        private void pictureBoxClose_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
        }


    }
}
