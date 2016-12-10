using System;
using System.Windows.Forms;
using DevComponents.DotNetBar.SuperGrid;

namespace WSCATProject.Base
{
    public partial class MaterialEmpolyee : Form
    {
        public bool isflag;
        public int StateType;
        public string id;
        public MaterialEmpolyee()
        {
            InitializeComponent();
        }

        protected void EmplyeeMaster_Load(object sender, EventArgs e)
        {
            superGridControl1.PrimaryGrid.AutoGenerateColumns = false;
            //去默认选中
            superGridControl1.PrimaryGrid.InitialSelection = RelativeSelection.None;
            //去焦点的虚线框
            superGridControl1.PrimaryGrid.FocusCuesEnabled = false;
            //去当前行的小箭头
            superGridControl1.PrimaryGrid.ActiveRowIndicatorStyle = ActiveRowIndicatorStyle.None;
            
            //superGridControl1.PrimaryGrid.AllowEmptyCellSelection = false;//允许空单元格选择
            // superGridControl1.PrimaryGrid.AutoSelectNewBoundRows = false;//自动选择新绑定行
            //superGridControl1.PrimaryGrid.AllowEmptyCellSelection = false;
            //superGridControl1.PrimaryGrid.AllowSelection = true;
        }
        #region 快捷键
        /// <summary>
        /// 快捷键
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SupplierMaterial_KeyDown(object sender, KeyEventArgs e)
        {
            ///新增(Ctrl+N),编辑(Ctrl+E),删除(Ctrl+D),全部删除(Shift+Delete),过滤(Ctrl+F),刷新(F5)
            e.Handled = true;
            if (e.KeyCode == Keys.N && e.Control)
            {
                InsToolStripMenuItem.PerformClick(); //执行单击button1的动作    
            }
            if (e.KeyCode == Keys.E && e.Control)
            {
                UpdToolStripMenuItem.PerformClick();
            }
            if (e.KeyCode == Keys.D && e.Control)
            {
                DelToolStripMenuItem.PerformClick();
            }
            if (e.KeyCode == Keys.Delete && e.Shift)
            {
                AllDelToolStripMenuItem.PerformClick();
            }
            if (e.KeyCode == Keys.T && e.Control)
            {
                ExportExcelToolStripMenuItem.PerformClick();
            }
            if (e.KeyCode == Keys.F5)
            {
                RefreshToolStripMenuItem.PerformClick();
            }
        }
        #endregion

        #region 添加
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected virtual void InsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        #endregion

        #region 删除
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected virtual void DelToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }
        #endregion

        #region 全部删除
        /// <summary>
        /// 全部删除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected virtual void AllDelToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }
        #endregion

        #region 编辑
        /// <summary>
        /// 编辑
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected virtual void UpdToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }
        #endregion

        #region 全部显示[包含禁用]
        /// <summary>
        /// 全部显示[包含禁用]
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected virtual void toolStripButton4_Click(object sender, EventArgs e)
        {
        }
        #endregion


        #region 导出功能
        /// <summary>
        /// 导出
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected virtual void ExportExcelToolStripMenuItem_Click(object sender, EventArgs e)
        {

        } 
        #endregion

        #region 刷新
        /// <summary>
        /// 刷新
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected virtual void RefreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }
        #endregion


        private void 新增NToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InsToolStripMenuItem.PerformClick();
        }

        private void 编辑EToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UpdToolStripMenuItem.PerformClick();
        }

        private void 删除DToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DelToolStripMenuItem.PerformClick();
        }

        private void 全部删除ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AllDelToolStripMenuItem.PerformClick();
        }

        private void 导出到ExcelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExportExcelToolStripMenuItem.PerformClick();
        }

        private void 刷新ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RefreshToolStripMenuItem.PerformClick();
        }
    }
}
