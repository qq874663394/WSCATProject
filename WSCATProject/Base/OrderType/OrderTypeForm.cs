using BLL;
using DevComponents.DotNetBar.SuperGrid;
using HelperUtility.Excel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WSCATProject.Base;

namespace WSCATProject.Base
{
    public partial class OrderTypeForm : MaterialEmpolyee
    {
        OrderTypeManager otm = new OrderTypeManager();
        public OrderTypeForm()
        {
            InitializeComponent();
        }

        private void OrderType_Load(object sender, EventArgs e)
        {
            superGridControl1.PrimaryGrid.AutoGenerateColumns = true;
            superGridControl1.PrimaryGrid.SelectionGranularity = SelectionGranularity.Row;
            superGridControl1.PrimaryGrid.InitialSelection = RelativeSelection.None;
            superGridControl1.PrimaryGrid.FocusCuesEnabled = false;
            superGridControl1.PrimaryGrid.ActiveRowIndicatorStyle = ActiveRowIndicatorStyle.None;
            toolStripButton4.Visible = false;
            BindDGV();
        }

        public void BindDGV()
        {
            try
            {
                superGridControl1.PrimaryGrid.DataSource = otm.SelOrderType();
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
            InsOrderTypeNode iotn = new InsOrderTypeNode();
            StateType = 0;
            iotn.ShowDialog(this);
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
                MessageBox.Show("请先选择一行！");
                return;
            }
            if (DialogResult.Yes == MessageBox.Show("确定全部删除吗？删除后将不可恢复！", "WACAT管家", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1))
            {
                GridRow row = col[0] as GridRow;
                string code = row.Cells["gridColumn1"].Value.ToString();
                try
                {
                    int result = otm.DelOrderType(code);
                    if (result > 0)
                    {
                        MessageBox.Show("删除成功！");
                        BindDGV();
                        return;
                    }
                    else
                    {
                        MessageBox.Show("删除失败！");
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
            if (DialogResult.Yes == MessageBox.Show("确定全部删除吗？删除后将不可恢复！", "WACAT管家", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1))
            {
                try
                {
                    int result = otm.DelAllOrderType();
                    if (result > 0)
                    {
                        MessageBox.Show("删除成功！");
                        BindDGV();
                        return;
                    }
                    else
                    {
                        MessageBox.Show("删除失败！");
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
                MessageBox.Show("请先选择一行！");
                return;
            }
            GridRow row = col[0] as GridRow;
            id = row.Cells["gridColumn1"].Value.ToString();
            InsOrderTypeNode iotn = new InsOrderTypeNode();
            StateType = 1;
            iotn.ShowDialog(this);
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
                    NPOIExcelHelper.DataTableToExcel(dt, "单据类型", saveFileDialog1.FileName);
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
