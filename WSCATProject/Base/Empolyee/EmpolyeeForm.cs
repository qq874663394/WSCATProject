using BLL;
using DevComponents.DotNetBar.SuperGrid;
using HelperUtility.Encrypt;
using HelperUtility.Excel;
using System;
using System.Data;
using System.Windows.Forms;

namespace WSCATProject.Base
{
    public partial class EmpolyeeForm : MaterialEmpolyee
    {
        EmpolyeeManager em = new EmpolyeeManager();
        public EmpolyeeForm()
        {
            InitializeComponent();
        }

        private void EmpolyeeMaterial_Load(object sender, EventArgs e)
        {
            superGridControl1.PrimaryGrid.AutoGenerateColumns = true;
            superGridControl1.PrimaryGrid.SelectionGranularity = SelectionGranularity.Row;
            superGridControl1.PrimaryGrid.InitialSelection = RelativeSelection.None;
            superGridControl1.PrimaryGrid.FocusCuesEnabled = false;
            superGridControl1.PrimaryGrid.ActiveRowIndicatorStyle = ActiveRowIndicatorStyle.None;
            BindDGV();
        }

        private void BindDGV()
        {
            try
            {
                superGridControl1.PrimaryGrid.DataSource = em.SelEmpolyee(false);
            }
            catch (Exception ex)
            {
                MessageBox.Show("加载数据失败,请检查服务器连接并尝试刷新.错误:" + ex.Message);
            }
        }
        #region 增
        /// <summary>
        /// 增
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected override void InsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InsEmpolyee ie = new InsEmpolyee();
            StateType = 0;
            ie.ShowDialog(this);
            if (base.isflag == true)
            {
                BindDGV();
            }
        }
        #endregion

        #region 删
        /// <summary>
        /// 删
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected override void DelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SelectedElementCollection col = superGridControl1.PrimaryGrid.GetSelectedRows();
            if (col.Count <= 0)
            {
                MessageBox.Show("请先选择一行!");
                return;
            }
            if (DialogResult.Yes == MessageBox.Show("确定全部删除吗? 删除后将不可恢复!", "WACAT管家", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1))
            {
                GridRow row = col[0] as GridRow;
                string code = row.Cells[0].Value.ToString();
                try
                {
                    int result = em.FalseDelClear(code);
                    if (result > 0)
                    {
                        MessageBox.Show("删除成功!");
                        BindDGV();
                        return;
                    }
                    else
                    {
                        MessageBox.Show("删除失败!");
                        return;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("删除失败,请检查服务器连接并尝试重新删除.错误:" + ex.Message);
                }
            }
        }
        #endregion

        #region 全删
        /// <summary>
        /// 全删
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected override void AllDelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (DialogResult.Yes == MessageBox.Show("确定全部删除吗? 删除后将不可恢复!", "WACAT管家", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1))
            {
                try
                {
                    int result = em.FalseALLDelClear();
                    if (result > 0)
                    {
                        MessageBox.Show("删除成功!");
                        BindDGV();
                        return;
                    }
                    else
                    {
                        MessageBox.Show("删除失败!");
                        return;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("删除失败,请检查服务器连接并尝试重新删除.错误:" + ex.Message);
                }
            }
        }
        #endregion

        #region 改
        /// <summary>
        /// 改
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected override void UpdToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SelectedElementCollection col = superGridControl1.PrimaryGrid.GetSelectedRows();
            if (col.Count <= 0)
            {
                MessageBox.Show("请先选择一行!");
                return;
            }
            GridRow row = col[0] as GridRow;
            id = XYEEncoding.strCodeHex(row.Cells[0].Value.ToString());
            InsEmpolyee ibn = new InsEmpolyee();
            StateType = 1;
            ibn.ShowDialog(this);
            if (base.isflag == true)
            {
                BindDGV();
            }
        }
        #endregion

        #region 刷新
        /// <summary>
        /// 刷新
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected override void RefreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BindDGV();
        }
        #endregion
        protected override void toolStripButton4_Click(object sender, EventArgs e)
        {
            try
            {
                if (isflag == false)
                {
                    superGridControl1.PrimaryGrid.DataSource = em.SelEmpolyee(true);
                    isflag = true;
                    return;
                }
                if (isflag == true)
                {
                    superGridControl1.PrimaryGrid.DataSource = em.SelEmpolyee(false);
                    isflag = false;
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("加载数据失败,请检查服务器连接并尝试刷新.错误:" + ex.Message);
            }
        }
        protected override void ExportExcelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            string defaultName = DateTime.Now.ToString("yyyyMMddHHmm") + "供应商资料";
            saveFileDialog1.FileName = defaultName + ".xls";
            saveFileDialog1.Filter = @"Excel 97-2003 (*.xls)|*.xls|All files (*.*)|*.*";
            saveFileDialog1.FilterIndex = 1;
            saveFileDialog1.RestoreDirectory = true;

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                GridItemsCollection col = superGridControl1.PrimaryGrid.Rows;
                GridRow row = col[0] as GridRow;

                DataTable dt = new DataTable();
                DataRow dr = null;
                DataColumn dc = null;
                for (int i = 0; i < row.Cells.Count; i++)
                {
                    dc = new DataColumn(superGridControl1.PrimaryGrid.Columns[i].Name);
                    dt.Columns.Add(dc);   //添加表头   当第二行的时候还会添加一次  由于table中的columns必须是唯一的  所以会导致冲突
                }
                for (int i = 0; i < col.Count; i++)
                {
                    dr = dt.NewRow();
                    for (int j = 0; j < row.Cells.Count; j++)
                    {
                        GridRow rows = col[i] as GridRow;
                        dr[j] = rows.Cells[j].Value;  //添加列的值
                    }
                    dt.Rows.Add(dr);
                }
                try
                {
                    NPOIExcelHelper.DataTableToExcel(dt, "人员资料", saveFileDialog1.FileName);
                    MessageBox.Show("Excel文件已成功导出，请到保存目录下查看。");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("保存失败,请检查异常情况:" + ex.Message);
                }
            }
        }
    }
}
