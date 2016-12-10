using DevComponents.DotNetBar;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;
using Model;
using DevComponents.DotNetBar.SuperGrid;

namespace WSCATProject.Base.Department
{
    public partial class DepartmentListForm : RibbonForm
    {
        public DepartmentListForm()
        {
            InitializeComponent();
        }

        DepartmentManager depm = new DepartmentManager();
        private void DepartmentListForm_Load(object sender, EventArgs e)
        {
            superGridControl1.PrimaryGrid.AutoGenerateColumns = false;
            this.superGridControl1.PrimaryGrid.DataSource = depm.GetListDep();
        }

        private void 新增ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InDepartment AddDep = new InDepartment();
            AddDep._update = false;
            AddDep.ShowDialog(this);
        }

        private void 编辑ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (superGridControl1.GetSelectedRows().Count > 0)
            {
              Model.Department dep = new Model.Department();
                SelectedElementCollection col = superGridControl1.GetSelectedRows();
                if (col.Count > 0)
                {
                    GridRow gridRow = col[0] as GridRow;
                    dep.Dt_Code = gridRow["gridColumn2"].Value.ToString();
                    dep.Dt_Name = gridRow["gridColumn4"].Value.ToString();
                    dep.Dt_RoleCode = gridRow["gridColumn3"].Value.ToString();
                }
                InDepartment updatedep = new InDepartment();
                updatedep._update = true;
                updatedep._Department = dep;
                updatedep.ShowDialog(this);
            }
            else
            {
                MessageBox.Show("请先选择需要编辑的信息");
            }
        }

        private void 删除DToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (superGridControl1.GetSelectedRows().Count > 0)
            {
                SelectedElementCollection col = superGridControl1.GetSelectedRows();
                if (col.Count > 0)
                {
                    
                    GridRow gridRow = col[0] as GridRow;
                    try
                    {
                        int result = depm.FalseDelClear(gridRow["gridColumn2"].Value.ToString());
                        if (result==1)
                        {
                            MessageBox.Show("删除成功!");

                        }
                        else
                        {
                            MessageBox.Show("删除失败,请重试");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("删除异常,请检查服务器连接.异常信息:" + ex.Message);
                    }
                }
            }
            else
            {
                MessageBox.Show("请先选择需要删除的信息");
            }
        }

        private void 全部删除AToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        private void 刷新ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            superGridControl1.PrimaryGrid.AutoGenerateColumns = false;
            this.superGridControl1.PrimaryGrid.DataSource = depm.GetListDep();
        }

        private void 新增ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            新增ToolStripMenuItem_Click(sender, e);
        }

        private void 修改ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            编辑ToolStripMenuItem_Click(sender, e);
        }

        private void 删除ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            删除DToolStripMenuItem_Click(sender, e);
        }

        private void 删除全部ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            全部删除AToolStripMenuItem_Click(sender, e);
        }

        private void 刷新ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            刷新ToolStripMenuItem_Click(sender, e);
        }
    }
}
