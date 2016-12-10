using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using BLL;
using HelperUtility.Encrypt;
using DevComponents.DotNetBar.SuperGrid;

namespace WSCATProject.Base
{
    public partial class ClientTypeForm : DevComponents.DotNetBar.RibbonForm
    {
        public ClientTypeForm()
        {
            InitializeComponent();
        }

        private bool refresh;
        public bool ReFresh
        {

            get { return refresh; }
            set { refresh = value; }
        }

        private void ClientTypeForm_Load(object sender, EventArgs e)
        {
            superGridControl1.PrimaryGrid.AutoGenerateColumns = false;//设置列不自动增加
            loadData();
        }

        /// <summary>
        /// 刷新数据列表
        /// </summary>
        public void loadData()
        {
            ClientTypeManager cts = new ClientTypeManager();
            DataSet ds = cts.GetList("CT_Enable = 1");
            bindingDGVByDataTable(ds);
        }

        #region MenuItem

        /// <summary>
        /// 新增按钮,调用创建窗体的结构块创建结构 传递给创建窗体
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 新增ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateClientTypeForm.formType ft =
                new CreateClientTypeForm.formType();
            ft.formStatic = "增";
            ft.formText = "增加类别";
            ft.richTextbox = "";
            ft.textboxName = "";

            CreateClientTypeForm cltf = new CreateClientTypeForm(ft);

            cltf.StartPosition = FormStartPosition.CenterParent;
            cltf.ShowDialog(this);
        }

        /// <summary>
        /// 编辑按钮 获取用户选定的行 若行大于0则创建实体传递给创建窗体 填充创建窗体的
        /// 文本编辑控件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 编辑ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (superGridControl1.PrimaryGrid.GetSelectedRows() != null)
            {
                SelectedElementCollection col = superGridControl1.PrimaryGrid.GetSelectedRows();
                if (col.Count > 0)
                {
                    GridRow row = col[0] as GridRow;

                    CreateClientTypeForm.formType ft =
                        new CreateClientTypeForm.formType();
                    ft.formStatic = "改";
                    ft.formText = "修改类别";
                    ft.richTextbox = row.Cells[2].Value ==
                        null ? "" : row.Cells[2].Value.ToString();
                    ft.textboxName = row.Cells[3].Value ==
                        null ? "" : row.Cells[3].Value.ToString();

                    CreateClientTypeForm cltf =
                         new CreateClientTypeForm(ft);

                    cltf.ShowDialog();
                    if (refresh)
                    {
                        loadData();
                        refresh = false;
                    }
                }
                else
                {
                    MessageBox.Show("请先选中要修改的数据所在行");
                }
            }
            else
            {
                MessageBox.Show("请先选中要修改的数据所在行");
            }
        }

        /// <summary>
        /// 删除按钮 转码code用于删除的where条件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 删除DToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (superGridControl1.PrimaryGrid.GetSelectedRows() == null)
            {
                ClientTypeManager ctm = new ClientTypeManager();
                SelectedElementCollection col = superGridControl1.PrimaryGrid.GetSelectedRows();
                DialogResult dr = MessageBox.Show("确定要删除该数据吗?操作不可恢复", "请注意",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dr == DialogResult.No)
                {
                    return;
                }

                GridRow row = col[0] as GridRow;

                string code = XYEEncoding.
                    strCodeHex(row.Cells["TypeCode"].Value.ToString());

                bool result = ctm.Delete(code);
                if (result)
                {
                    loadData();
                    MessageBox.Show("客户类别删除成功");
                }
                else
                {
                    MessageBox.Show("删除失败,请检查是否选中列");
                }
            }
            else
            {
                MessageBox.Show("请先选中要修改的数据所在行");
            }
        }

        /// <summary>
        /// 假删除所有的数据列表
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 全部删除AToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (superGridControl1.PrimaryGrid.Rows != null)
            {

                DialogResult dr = MessageBox.Show("确定要删除所有客户类别吗?该操作不可恢复", "请注意",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                GridItemsCollection col = superGridControl1.PrimaryGrid.Rows;
                if (col.Count > 0 && dr == DialogResult.No)
                {

                    List<string> ids = new List<string>();
                    //遍历ID 填充到list里
                    foreach (GridRow gr in col)
                    {

                        ids.Add(gr.Cells["TypeID"].Value.ToString());
                    }
                    //用逗号分割所有id数据 返回ID,ID形式的字符串
                    string idList = string.Join(",", ids);

                    ClientTypeManager ctm = new ClientTypeManager();
                    try
                    {
                        if (ctm.FakeDeleteList())
                        {
                            loadData();
                            MessageBox.Show("清除数据成功");
                        }
                        else
                        {
                            MessageBox.Show("清除数据失败,请检查错误");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("清除数据失败,请检查错误:" + ex.Message);
                    }
                }
                else
                {
                    MessageBox.Show("客户类型已为空,不存在需要删除的数据");
                }
            }
        }

        #endregion

        #region contextMenu 
        //右键菜单 触发相同功能的开始菜单的按钮动作
        private void 新增类型ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            新增ToolStripMenuItem.PerformClick();
        }

        private void 删除类型ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            删除DToolStripMenuItem.PerformClick();
        }

        private void 删除全部ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            全部删除AToolStripMenuItem.PerformClick();
        }

        private void 刷新ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            loadData();
        }

        private void superGridControl1_CellDoubleClick(object sender, GridCellDoubleClickEventArgs e)
        {
            编辑ToolStripMenuItem.PerformClick();
        }

        #endregion

        /// <summary>
        /// 将DataSet里的第一个table解密后绑定到控件上
        /// </summary>
        /// <param name="ds"></param>
        private void bindingDGVByDataTable(DataSet ds)
        {
            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    CodingHelper codingHelper = new CodingHelper();

                    superGridControl1.PrimaryGrid.DataSource =
                        codingHelper.DataTableReCoding(ds.Tables[0]);
                }
                else
                {
                    DataTable dt = ds.Tables[0].Clone();

                    CodingHelper codingHelper = new CodingHelper();

                    superGridControl1.PrimaryGrid.DataSource =
                        codingHelper.DataTableReCoding(dt);
                }
            }
        }
    }
}
