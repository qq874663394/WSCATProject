using System;
using System.Data;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using Model;
using DevComponents.DotNetBar.SuperGrid;
using InterfaceLayer.Base;
using HelperUtility.Encrypt;

namespace WSCATProject.Base
{
    public partial class StorageForm : RibbonForm
    {
        public StorageForm()
        {
            InitializeComponent();
        }

        StorageInterface storage = new StorageInterface();
        CodingHelper ch = new CodingHelper();

        private void StorageForm_Load(object sender, EventArgs e)
        {
            StartPosition = FormStartPosition.CenterParent;
            //禁止自动创建列
            superGridControlStorage.PrimaryGrid.AutoGenerateColumns = false;
            //内容居中
            superGridControlStorage.DefaultVisualStyles.CellStyles.Default.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleCenter;
            loadData();
        }

        private void loadData()
        {
            
            try
            {
                DataTable dt = storage.GetList(00,"");
                superGridControlStorage.PrimaryGrid.DataSource =ch.DataTableReCoding(dt);
            }
            catch (Exception ex)
            {
                MessageBox.Show("查询出错,请检查服务器连接.错误:" + ex.Message);
            }
        }

        #region 菜单操作

        private void 新增ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //StorageCreateForm scf = new StorageCreateForm();
            //scf._update = false;
            //scf.ShowDialog(this);
        }

        private void 编辑ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (superGridControlStorage.GetSelectedRows().Count > 0)
            {
                //Storage storage = new Storage();
                //SelectedElementCollection col = superGridControlStorage.GetSelectedRows();
                //if (col.Count > 0)
                //{
                //    GridRow gridRow = col[0] as GridRow;
                //    storage.St_Address = gridRow["St_Address"].Value.ToString();
                //    storage.St_Clear = Convert.ToInt32(gridRow["St_Clear"].Value);
                //    storage.St_Code = gridRow["St_Code"].Value.ToString();
                //    storage.St_EmpName = gridRow["St_EmpName"].Value.ToString();
                //    storage.St_Enable = Convert.ToInt32(gridRow["St_Enable"].Value);
                //    storage.St_ID = Convert.ToInt32(gridRow["St_ID"].Value);
                //    storage.St_Name = gridRow["St_Name"].Value.ToString();
                //    storage.St_Phone = gridRow["St_Phone"].Value.ToString();
                //    storage.St_Remark = gridRow["St_Remark"].Value.ToString();
                //    storage.St_Safetyone = gridRow["St_Safetyone"].Value.ToString(); 
                //    storage.St_Safetytwo = gridRow["St_Safetytwo"].Value.ToString();
                //}
                //StorageCreateForm scf = new StorageCreateForm();
                //scf._update = true;
                //scf._storage = storage;
                //scf.ShowDialog(this);
            }
            else
            {
                MessageBox.Show("请先选择需要编辑的信息");
            }
        }

        private void 删除ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (superGridControlStorage.GetSelectedRows().Count > 0)
            {
                //SelectedElementCollection col = superGridControlStorage.GetSelectedRows();
                //if (col.Count > 0)
                //{
                //    StorageManager sm = new StorageManager();
                //    GridRow gridRow = col[0] as GridRow;
                //    try
                //    {
                //        bool result = sm.DeleteFake(gridRow["St_Code"].Value.ToString());
                //        if (result)
                //        {
                //            MessageBox.Show("删除成功!");
                            
                //        }
                //        else
                //        {
                //            MessageBox.Show("删除失败,请重试");
                //        }
                //    }
                //    catch(Exception ex)
                //    {
                //        MessageBox.Show("删除异常,请检查服务器连接.异常信息:" + ex.Message);
                //    }
                //}
            }
            else
            {
                MessageBox.Show("请先选择需要删除的信息");
            }
        }

        private void 全部删除ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void 刷新ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            loadData();
        }

        #endregion

        #region 右键菜单操作
        
        private void 新增ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            新增ToolStripMenuItem.PerformClick();
        }

        private void 编辑ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            编辑ToolStripMenuItem.PerformClick();
        }

        private void 删除ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            删除DToolStripMenuItem.PerformClick();
        }

        private void 全部删除ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            全部删除AToolStripMenuItem.PerformClick();
        }

        private void 刷新ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            刷新ToolStripMenuItem.PerformClick();
        }

        #endregion

        /// <summary>
        /// 若新增仓库数据成功 则将新增的数据绑定到datagridview上显示
        /// </summary>
        /// <param name="id"></param>
        /// <param name="code"></param>
        /// <param name="name"></param>
        /// <param name="empName"></param>
        /// <param name="phone"></param>
        /// <param name="address"></param>
        /// <param name="enable"></param>
        /// <param name="clear"></param>
        /// <param name="remark"></param>
        /// <param name="safetyone"></param>
        /// <param name="safetytwo"></param>
        public void DataGridViewRowsAdd(int id,string code,string name,string empName,string phone,
            string address,int enable,int clear,string remark,string safetyone,string safetytwo)
        {
            //DataSet ds = (DataSet)superGridControlStorage.PrimaryGrid.DataSource;
            //DataRow dr = ds.Tables[0].Rows.Add();
            //dr["St_ID"] = id;
            //dr["St_Code"] = code;
            //dr["St_Name"] = name;
            //dr["St_EmpName"] = empName;
            //dr["St_Phone"] = phone;
            //dr["St_Address"] = address;
            //dr["St_Enable"] = enable;
            //dr["St_Clear"] = clear;
            //dr["St_Remark"] = remark;
            //dr["St_Safetyone"] = safetyone;
            //dr["St_Safetytwo"] = safetytwo;
        }
    }
}
