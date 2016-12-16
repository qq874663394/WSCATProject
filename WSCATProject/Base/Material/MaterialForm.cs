using System;
using System.Data;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using Model;
using DevComponents.DotNetBar.SuperGrid;
using HelperUtility.Excel;
using HelperUtility.Encrypt;
using InterfaceLayer.Base;

namespace WSCATProject.Base
{
    public partial class MaterialForm : RibbonForm
    {
        public MaterialForm()
        {
            InitializeComponent();
        }

        DataTable allData = new DataTable();

        #region 实例化接口和解密类
        CodingHelper ch = new CodingHelper();
        MaterialInterface material = new MaterialInterface();//物料
        #endregion

        //点击的节点text
        private string materialNodeText = "类别";

        private bool isflag;
        public bool Isflag
        {
            get
            {
                return isflag;
            }

            set
            {
                isflag = value;
            }
        }

        private void MaterialForm_Load(object sender, EventArgs e)
        {
            StartPosition = FormStartPosition.CenterParent;
            MaterialTypeInterface mtm = new MaterialTypeInterface();
            DataTable dt = mtm.GetList(999,"",false,false);
            DataView dvTree = new DataView(dt);
            AddTree(null, null, dvTree);
            superGridControlMaterial.PrimaryGrid.AutoGenerateColumns = false;
            loadData();
        }

        #region 菜单操作

        //新建
        private void ToolStripMenuItemCreate_Click(object sender, EventArgs e)
        {
            MaterialCreateForm mf = new MaterialCreateForm();
            mf.ShowDialog(this);
            closeDispose();
        }

        //编辑
        private void ToolStripMenuItemEdit_Click(object sender, EventArgs e)
        {
            if (superGridControlMaterial.GetSelectedRows().Count > 0)
            {
                BaseMaterial material = new BaseMaterial();
                SelectedElementCollection col = superGridControlMaterial.GetSelectedRows();
                if (col.Count > 0)
                {
                    GridRow gridRow = col[0] as GridRow;
                    material.barCode = gridRow.Cells["barCode"].Value.ToString();
                    material.isClear = 1;
                    material.code = gridRow.Cells["code"].Value.ToString();
                    if (gridRow.Cells["createDate"].Value == null ||
                        gridRow.Cells["inDate"].Value == DBNull.Value)
                    {
                        material.createDate = Convert.ToDateTime("2000-01-01");
                    }
                    else
                    {
                        material.createDate = Convert.
                            ToDateTime(gridRow.Cells["createDate"].Value);
                    }
                    material.isEnable = Convert.ToInt32(gridRow.Cells["isEnable"].Value);
                    material.id = Convert.ToInt32(gridRow.Cells["id"].Value);
                    if (gridRow.Cells["inDate"].Value == null ||
                        gridRow.Cells["inDate"].Value == DBNull.Value)
                    {
                        material.inDate = Convert.ToDateTime("2000-01-01"); ;
                    }
                    else
                    {
                        material.inDate = Convert.ToDateTime(gridRow.Cells["inDate"].Value);
                    }
                    material.inPrice = Convert.ToDecimal(gridRow.Cells["inPrice"].Value);
                    material.model = gridRow.Cells["model"].Value.ToString();
                    material.name = gridRow.Cells["name"].Value.ToString();
                    material.picName = gridRow.Cells["picName"].Value.ToString();
                    material.outPrice = Convert.ToDecimal(gridRow.Cells["outPrice"].Value);
                    material.price = Convert.ToDecimal(gridRow.Cells["price"].Value);
                    material.priceB = Convert.ToDecimal(gridRow.Cells["priceB"].Value);
                    material.priceC = Convert.ToDecimal(gridRow.Cells["priceC"].Value);
                    material.priceD = Convert.ToDecimal(gridRow.Cells["priceD"].Value);
                    material.priceE = 0;
                    material.remark = gridRow.Cells["remark"].Value.ToString();
                    //material. = gridRow.Cells["Ma_RFID"].Value.ToString();
                    material.reserved1 = "";
                    material.reserved2 = "";
                    material.supplierCode = gridRow.Cells["supplierCode"].Value.ToString();
                    material.supplierName = gridRow.Cells["supplierName"].Value.ToString();
                    material.typeID = gridRow.Cells["typeID"].Value.ToString();
                    material.typeName = gridRow.Cells["typeName"].Value.ToString();
                    material.unit = gridRow.Cells["unit"].Value.ToString();
                    material.materialDaima = gridRow.Cells["materialDaima"].Value.ToString();
                }
                MaterialCreateForm mcf = new MaterialCreateForm();
                mcf.Material = material;
                mcf.ShowDialog(this);
                closeDispose();
            }
            else
            {
                MessageBox.Show("请选择要修改的行");
            }

        }

        //删除
        private void ToolStripMenuItemDelete_Click(object sender, EventArgs e)
        {
            if (superGridControlMaterial.GetSelectedRows().Count > 0)
            {
                if (DialogResult.No == MessageBox.Show("确认要删除选中行的数据吗?", "请注意",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2))
                {
                    return;
                }
                BaseClient client = new BaseClient();
                MaterialInterface cm = new MaterialInterface();
                SelectedElementCollection col = superGridControlMaterial.GetSelectedRows();
                if (col.Count > 0)
                {
                    GridRow gridRow = col[0] as GridRow;
                    try
                    {
                        bool result = cm.Delete(gridRow.Cells["code"].Value.ToString());
                        if (result)
                        {
                            MessageBox.Show("删除成功!");
                            isflag = true;
                            closeDispose();
                        }
                        else
                        {
                            MessageBox.Show("删除失败,请检查是否选中指定行");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("删除异常,请检查服务器连接:" + ex.Message);
                    }
                }
            }
            else
            {
                MessageBox.Show("请先选中要进行删除的行");
            }
        }

        //删除全部
        private void ToolStripMenuItemAll_Click(object sender, EventArgs e)
        {

        }

        //生成excel
        private void ToolStripMenuItemExcel_Click(object sender, EventArgs e)
        {
            string defaultName = DateTime.Now.ToString("yyyyMMddHHmm") + "产品资料";
            saveFileDialog1.FileName = defaultName + ".xls";
            saveFileDialog1.Filter = "Excel文件（*.xls）|*.xls|Excel 文件(*.xlsx)|*.xlsx";
            saveFileDialog1.AddExtension = true;
            if (saveFileDialog1.ShowDialog() != DialogResult.OK)
            {
                return;
            }
            DataTable dt = ((DataSet)superGridControlMaterial.PrimaryGrid.DataSource).Tables[0];
            GridColumnCollection gcc = superGridControlMaterial.PrimaryGrid.Columns;
            string[] x = {
                "产品名称", "规格型号", "条码", "助记码", "编号", "所属类别", "售价", "预设售价A", "预设售价B", "预设售价C",
                "预设售价D", "预设售价E", "创建时间", "供应商", "单位", "进价", "进货时间", "备注", "启用标志", "预留1", "预留2" };
            dt.Columns.Remove("Ma_ID");
            dt.Columns.Remove("Ma_PicName");
            dt.Columns.Remove("Ma_RFID");
            dt.Columns.Remove("Ma_TypeID");
            dt.Columns.Remove("Ma_SupID");
            dt.Columns.Remove("Ma_Clear");
            try
            {
                NPOIExcelHelper.DataTableToExcel(dt, "sdfe", saveFileDialog1.FileName, x);
                MessageBox.Show("Excel文件已成功导出，请到保存目录下查看。");
            }
            catch (Exception ex)
            {
                MessageBox.Show("保存失败,请检查异常情况:" + ex.Message);
            }
        }

        //菜单搜索按钮 模糊检索条件下是否有符合的数据
        private void toolStripButtonSeach_Click(object sender, EventArgs e)
        {
            //string field = toolStripComboBoxKey.Text;
            //string text = toolStripTextBoxValue.Text.Trim();
            //MaterialInterface mm = new MaterialInterface();

            //if (allData != null)
            //{
            //    try
            //    {
            //        superGridControlMaterial.PrimaryGrid.DataSource =
            //                    mm.searchClientByNodeClick(allData.Tables[0],
            //                    text, field);
            //    }
            //    catch (Exception ex)
            //    {
            //        MessageBox.Show(ex.Message);
            //    }
            //}
        }

        //刷新
        private void ToolStripMenuItemRefresh_Click(object sender, EventArgs e)
        {
            loadData();
            treeViewMaterial.SelectedNode = treeViewMaterial.Nodes[0];
        }

        #endregion 

        #region treeview的右键菜单操作

        private void 新增下级节点ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //if (treeViewMaterial.SelectedNode != null)
            //{
            //    MaterialTypeInterface mtm = new MaterialTypeInterface();
            //    DataTable dt = mtm.GetList(999,"",false,false);
            //    DataView dvTree = new DataView(dt);
            //    InsNodes insN = new InsNodes();
            //    insN.city_code = treeViewMaterial.SelectedNode.Tag.ToString();
            //    insN.ShowDialog(this);
            //    if (Isflag)
            //    {
            //        treeViewMaterial.Nodes.Clear();
            //        AddTree("", null, dvTree);
            //        isflag = false;
            //        this.Focus();
            //    }
            //}
            //else
            //{
            //    MessageBox.Show("请选择需要增加的上级城市");
            //}
        }

        private void 编辑ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //if (treeViewMaterial.SelectedNode != null)
            //{
            //    MaterialTypeInsNodes insN = new MaterialTypeInsNodes();
            //    BaseMaterialType mt = new BaseMaterialType();
            //    mt.MT_Clear = 1;
            //    mt.MT_Code = treeViewMaterial.SelectedNode.Tag.ToString();
            //    mt.MT_Enable = 1;
            //    mt.MT_Name = treeViewMaterial.SelectedNode.Text;
            //    mt.MT_ParentID = treeViewMaterial.SelectedNode.Parent.Tag.ToString();
            //    insN.ShowDialog(this);
            //    if (Isflag)
            //    {
            //        MaterialTypeInterface mtm = new MaterialTypeInterface();
            //        DataTable dt = mtm.GetList(999,"",false,false);
            //        DataView dvTree = new DataView(dt);
            //        treeViewMaterial.Nodes.Clear();
            //        AddTree("", null, dvTree);
            //        isflag = false;
            //        Focus();
            //    }
            //}
            //else
            //{
            //    MessageBox.Show("请选择需要增加的上级城市");
            //}
        }

        private void 删除ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (treeViewMaterial.SelectedNode != null)
            {
                if (DialogResult.Yes != MessageBox.Show("确定要删除所选节点吗?该操作将不可恢复,请注意.", "请确认",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2))
                {
                    return;
                }
                MaterialTypeInterface mtm = new MaterialTypeInterface();
                try
                {
                    if (mtm.Delete(treeViewMaterial.SelectedNode.Tag.ToString()))
                    {
                        MessageBox.Show("删除成功!");
                        DataTable dt = mtm.GetList(999,"",false,false);
                        DataView dvTree = new DataView(dt);
                        treeViewMaterial.Nodes.Clear();
                        AddTree("", null, dvTree);
                    }
                    else
                    {
                        MessageBox.Show("删除失败,请重试.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("删除节点出错,请检查服务器连接.异常:" + ex.Message);
                }
            }
        }

        //点击节点搜索符合该范围的数据
        private void treeViewMaterial_AfterSelect(object sender, TreeViewEventArgs e)
        {
            //materialNodeText = e.Node.Text;
            //MaterialInterface mm = new MaterialInterface();
            //if (allData != null)
            //{
            //    try
            //    {
            //        superGridControlMaterial.PrimaryGrid.DataSource =
            //                    mm.searchClientByNodeClick(allData.Tables[0],
            //                    materialNodeText, "类别名称");
            //    }
            //    catch (Exception ex)
            //    {
            //        MessageBox.Show(ex.Message);
            //    }
            //}
        }

        #endregion

        #region dgv的右键菜单操作

        private void 新增ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItemCreate.PerformClick();
        }

        private void 编辑ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ToolStripMenuItemEdit.PerformClick();
        }

        private void 删除ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ToolStripMenuItemDelete.PerformClick();
        }

        private void 删除全部ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItemAll.PerformClick();
        }

        private void 导出到ExcelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItemExcel.PerformClick();
        }

        private void 刷新ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItemRefresh.PerformClick();
        }

        #endregion

        #region 通用方法

        /// <summary>
        /// 关闭子窗体后对主窗体数据的处理
        /// </summary>
        private void closeDispose()
        {
            if (Isflag)
            {
                loadData();
                treeViewMaterial.SelectedNode = treeViewMaterial.Nodes[0];
            }
            else
            {
                treeViewMaterial.SelectedNode = treeViewMaterial.Nodes[0];
            }
            Isflag = false;
        }

        /// <summary>
        /// 加载datagridview的数据
        /// </summary>
        private void loadData()
        {
            string value = "";
            allData = material.GetList(99999, value);
            superGridControlMaterial.PrimaryGrid.DataSource = ch.DataTableReCoding( allData);
        }

        /// <summary>
        /// 回调加载树状图
        /// </summary>
        /// <param name="ParentID">父级ID 初始应为""</param>
        /// <param name="pNode">当前节点 初始为null</param>
        /// <param name="dvTree">data视图 初始为所有的datatable数据</param>
        private void AddTree(object ParentID, TreeNode pNode, DataView dvTree)
        {
            string ParentId = "parentId";
            string Code = "code";
            string Name = "name";

            //过滤ParentID,得到当前的所有子节点
            if (ParentID == null)
            {
                dvTree.RowFilter = string.Format("{0} is NULL", ParentId);
            }
            else
            {
                dvTree.RowFilter = string.Format("{0} = '{1}'", ParentId, ParentID);
            }
            foreach (DataRowView Row in dvTree)
            {
                TreeNode Node = new TreeNode();
                if (pNode == null)
                {
                    //添加根节点
                    Node.Text = Row[Name].ToString();
                    Node.Tag = Row[Code].ToString();
                    treeViewMaterial.Nodes.Add(Node);
                    AddTree(Row[Code].ToString(), Node, dvTree);
                    //展开第一级节点
                    Node.Expand();
                }
                else
                {
                    //添加当前节点的子节点
                    Node.Text = Row[Name].ToString();
                    Node.Tag = Row[Code].ToString();
                    pNode.Nodes.Add(Node);
                    AddTree(Row[Code].ToString(), Node, dvTree);//再次递归
                }
            }
        }
        #endregion
    }
}