using DataGridViewProcessEditTest;
using DevComponents.DotNetBar.SuperGrid;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WSCATProject
{
    public partial class ScheduleForm : Form
    {
        public ScheduleForm()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 模块类型
        /// </summary>
        private string _Mokualiex;
        /// <summary>
        /// 接收的状态值
        /// </summary>
        private int _state;
        /// <summary>
        /// 仓库出库的类型
        /// </summary>
        private string _canku;
        /// <summary>
        /// 模块类型
        /// </summary>
        public string Mokualiex
        {
            get { return _Mokualiex; }

            set { _Mokualiex = value; }
        }
        /// <summary>
        /// 接收状态值
        /// </summary>
        public int State
        {
            get { return _state; }
            set { _state = value; }
        }
        /// <summary>
        /// 仓库出库的类型
        /// </summary>
        public string Canku
        {
            get { return _canku; }
            set { _canku = value; }
        }
        /// <summary>
        /// 窗体加载事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ScheduleForm_Load(object sender, EventArgs e)
        {
            //superGridControl1.PrimaryGrid.DefaultRowHeight = 40;
            //this.superGridControl1.PrimaryGrid.ShowRowHeaders = false;

            switch (_Mokualiex)
            {
                case "用户资料":
                    break;
                case "权限分配":
                    break;
                case "仓库资料":
                    break;
                case "货品资料":
                    break;
                case "供应商资料":
                    break;
                case "物料信息":
                    break;
                case "仓库系统":
                    InStorage();
                    break;
                case "销售系统":
                    break;
                case "售后系统":
                    break;
                case "采购系统":
                    break;
                case "财务系统":
                    break;
                case "考勤系统":
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// 初始化出库模块的窗体
        /// </summary>
        private void InStorage()
        {
            this.Size = new Size(330,120);
            switch (_canku)
            {
                case "入库开单":
                    if (_state == 0)
                    {
                        this.pictureBox0.Image = Properties.Resources.ye;
                        this.pictureBox1.Image = Properties.Resources.gr;
                        this.pictureBox2.Image = Properties.Resources.gr;
                        this.label1.Text = "未入库";
                        this.label2.Text = "部分入库";
                        this.label3.Text = "已入库";
                    }
                    if (_state == 1)
                    {
                        this.pictureBox0.Image = Properties.Resources.red;
                        this.pictureBox1.Image = Properties.Resources.ye;
                        this.pictureBox2.Image = Properties.Resources.gr;
                        this.label1.Text = "未入库";
                        this.label2.Text = "部分入库";
                        this.label3.Text = "已入库";
                    }
                    if (_state == 2)
                    {
                        this.pictureBox0.Image = Properties.Resources.red;
                        this.pictureBox1.Image = Properties.Resources.red;
                        this.pictureBox2.Image = Properties.Resources.ye;
                        this.label1.Text = "未入库";
                        this.label2.Text = "部分入库";
                        this.label3.Text = "已入库";
                    }
                    break;
                case "出库开单":
                    if (_state == 0)
                    {
                        this.pictureBox0.Image = Properties.Resources.ye;
                        this.pictureBox1.Image = Properties.Resources.gr;
                        this.pictureBox2.Image = Properties.Resources.gr;
                        this.label1.Text = "未出库";
                        this.label2.Text = "部分出库";
                        this.label3.Text = "已出库";
                    }
                    if (_state == 1)
                    {
                        this.pictureBox0.Image = Properties.Resources.red;
                        this.pictureBox1.Image = Properties.Resources.ye;
                        this.pictureBox2.Image = Properties.Resources.gr;
                        this.label1.Text = "未出库";
                        this.label2.Text = "部分出库";
                        this.label3.Text = "已出库";
                    }
                    if (_state == 2)
                    {
                        this.pictureBox0.Image = Properties.Resources.red;
                        this.pictureBox1.Image = Properties.Resources.red;
                        this.pictureBox2.Image = Properties.Resources.ye;
                        this.label1.Text = "未出库";
                        this.label2.Text = "部分出库";
                        this.label3.Text = "已出库";
                    }
                    break;
            }
        }

        private void ScheduleForm_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Escape)
            {
                this.Close();
                this.Dispose();
            }
        }
        /// <summary>
        /// 鼠标滑入滑出
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void superGridControl1_CellMouseEnter(object sender, GridCellEventArgs e)
        {

            switch (_Mokualiex)
            {
                case "用户资料":
                    break;
                case "权限分配":
                    break;
                case "仓库资料":
                    break;
                case "货品资料":
                    break;
                case "供应商资料":
                    break;
                case "物料信息":
                    break;
                case "仓库系统":
                    switch (_canku)
                    {
                        case "入库开单":
                            if (_state == 0)
                            {
                                toolTip1.Show("当前单据并没有入库", pictureBox0);
                            }
                            if (_state == 1)
                            {
                                toolTip1.Show("当前单据只有部分入库", pictureBox1);
                            }
                            if (_state == 2)
                            {
                                toolTip1.Show("当前单据已全部入库", pictureBox2);
                            }
                            break;
                        case "出库开单":
                            if (_state == 0)
                            {
                                toolTip1.Show("当前单据并没有出库", pictureBox0);
                            }
                            if (_state == 1)
                            {
                                toolTip1.Show("当前单据只有部分出库", pictureBox1);
                            }
                            if (_state == 2)
                            {
                                toolTip1.Show("当前单据已全部出库", pictureBox2);
                            }
                            break;
                    }
                    break;
                case "销售系统":
                    break;
                case "售后系统":
                    break;
                case "采购系统":
                    break;
                case "财务系统":
                    break;
                case "考勤系统":
                    break;
                default:
                    break;
            }
        }

        private void superGridControl1_MouseEnter(object sender, EventArgs e)
        {
            switch (_Mokualiex)
            {
                case "用户资料":
                    break;
                case "权限分配":
                    break;
                case "仓库资料":
                    break;
                case "货品资料":
                    break;
                case "供应商资料":
                    break;
                case "物料信息":
                    break;
                case "仓库系统":
                    switch (_canku)
                    {
                        case "入库开单":
                            if (_state == 0)
                            {
                                toolTip1.Show("当前单据并没有入库", pictureBox0);
                            }
                            if (_state == 1)
                            {
                                toolTip1.Show("当前单据只有部分入库", pictureBox1);
                            }
                            if (_state == 2)
                            {
                                toolTip1.Show("当前单据已全部入库", pictureBox2);
                            }
                            break;
                        case "出库开单":
                            if (_state == 0)
                            {
                                toolTip1.Show("当前单据并没有出库", pictureBox0);
                            }
                            if (_state == 1)
                            {
                                toolTip1.Show("当前单据只有部分出库", pictureBox1);
                            }
                            if (_state == 2)
                            {
                                toolTip1.Show("当前单据已全部出库", pictureBox2);
                            }
                            break;
                    }
                    break;
                case "销售系统":
                    break;
                case "售后系统":
                    break;
                case "采购系统":
                    break;
                case "财务系统":
                    break;
                case "考勤系统":
                    break;
                default:
                    break;
            }
        }

        private void panel1_MouseLeave(object sender, EventArgs e)
        {
            toolTip1.Hide(panel1);
        }
    }
}
