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

        #region ʵ�����ӿںͽ�����
        CodingHelper ch = new CodingHelper();
        MaterialInterface material = new MaterialInterface();//����
        #endregion

        //����Ľڵ�text
        private string materialNodeText = "���";

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

        #region �˵�����

        //�½�
        private void ToolStripMenuItemCreate_Click(object sender, EventArgs e)
        {
            MaterialCreateForm mf = new MaterialCreateForm();
            mf.ShowDialog(this);
            closeDispose();
        }

        //�༭
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
                MessageBox.Show("��ѡ��Ҫ�޸ĵ���");
            }

        }

        //ɾ��
        private void ToolStripMenuItemDelete_Click(object sender, EventArgs e)
        {
            if (superGridControlMaterial.GetSelectedRows().Count > 0)
            {
                if (DialogResult.No == MessageBox.Show("ȷ��Ҫɾ��ѡ���е�������?", "��ע��",
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
                            MessageBox.Show("ɾ���ɹ�!");
                            isflag = true;
                            closeDispose();
                        }
                        else
                        {
                            MessageBox.Show("ɾ��ʧ��,�����Ƿ�ѡ��ָ����");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("ɾ���쳣,�������������:" + ex.Message);
                    }
                }
            }
            else
            {
                MessageBox.Show("����ѡ��Ҫ����ɾ������");
            }
        }

        //ɾ��ȫ��
        private void ToolStripMenuItemAll_Click(object sender, EventArgs e)
        {

        }

        //����excel
        private void ToolStripMenuItemExcel_Click(object sender, EventArgs e)
        {
            string defaultName = DateTime.Now.ToString("yyyyMMddHHmm") + "��Ʒ����";
            saveFileDialog1.FileName = defaultName + ".xls";
            saveFileDialog1.Filter = "Excel�ļ���*.xls��|*.xls|Excel �ļ�(*.xlsx)|*.xlsx";
            saveFileDialog1.AddExtension = true;
            if (saveFileDialog1.ShowDialog() != DialogResult.OK)
            {
                return;
            }
            DataTable dt = ((DataSet)superGridControlMaterial.PrimaryGrid.DataSource).Tables[0];
            GridColumnCollection gcc = superGridControlMaterial.PrimaryGrid.Columns;
            string[] x = {
                "��Ʒ����", "����ͺ�", "����", "������", "���", "�������", "�ۼ�", "Ԥ���ۼ�A", "Ԥ���ۼ�B", "Ԥ���ۼ�C",
                "Ԥ���ۼ�D", "Ԥ���ۼ�E", "����ʱ��", "��Ӧ��", "��λ", "����", "����ʱ��", "��ע", "���ñ�־", "Ԥ��1", "Ԥ��2" };
            dt.Columns.Remove("Ma_ID");
            dt.Columns.Remove("Ma_PicName");
            dt.Columns.Remove("Ma_RFID");
            dt.Columns.Remove("Ma_TypeID");
            dt.Columns.Remove("Ma_SupID");
            dt.Columns.Remove("Ma_Clear");
            try
            {
                NPOIExcelHelper.DataTableToExcel(dt, "sdfe", saveFileDialog1.FileName, x);
                MessageBox.Show("Excel�ļ��ѳɹ��������뵽����Ŀ¼�²鿴��");
            }
            catch (Exception ex)
            {
                MessageBox.Show("����ʧ��,�����쳣���:" + ex.Message);
            }
        }

        //�˵�������ť ģ�������������Ƿ��з��ϵ�����
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

        //ˢ��
        private void ToolStripMenuItemRefresh_Click(object sender, EventArgs e)
        {
            loadData();
            treeViewMaterial.SelectedNode = treeViewMaterial.Nodes[0];
        }

        #endregion 

        #region treeview���Ҽ��˵�����

        private void �����¼��ڵ�ToolStripMenuItem_Click(object sender, EventArgs e)
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
            //    MessageBox.Show("��ѡ����Ҫ���ӵ��ϼ�����");
            //}
        }

        private void �༭ToolStripMenuItem_Click(object sender, EventArgs e)
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
            //    MessageBox.Show("��ѡ����Ҫ���ӵ��ϼ�����");
            //}
        }

        private void ɾ��ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (treeViewMaterial.SelectedNode != null)
            {
                if (DialogResult.Yes != MessageBox.Show("ȷ��Ҫɾ����ѡ�ڵ���?�ò��������ɻָ�,��ע��.", "��ȷ��",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2))
                {
                    return;
                }
                MaterialTypeInterface mtm = new MaterialTypeInterface();
                try
                {
                    if (mtm.Delete(treeViewMaterial.SelectedNode.Tag.ToString()))
                    {
                        MessageBox.Show("ɾ���ɹ�!");
                        DataTable dt = mtm.GetList(999,"",false,false);
                        DataView dvTree = new DataView(dt);
                        treeViewMaterial.Nodes.Clear();
                        AddTree("", null, dvTree);
                    }
                    else
                    {
                        MessageBox.Show("ɾ��ʧ��,������.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("ɾ���ڵ����,�������������.�쳣:" + ex.Message);
                }
            }
        }

        //����ڵ��������ϸ÷�Χ������
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
            //                    materialNodeText, "�������");
            //    }
            //    catch (Exception ex)
            //    {
            //        MessageBox.Show(ex.Message);
            //    }
            //}
        }

        #endregion

        #region dgv���Ҽ��˵�����

        private void ����ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItemCreate.PerformClick();
        }

        private void �༭ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ToolStripMenuItemEdit.PerformClick();
        }

        private void ɾ��ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ToolStripMenuItemDelete.PerformClick();
        }

        private void ɾ��ȫ��ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItemAll.PerformClick();
        }

        private void ������ExcelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItemExcel.PerformClick();
        }

        private void ˢ��ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItemRefresh.PerformClick();
        }

        #endregion

        #region ͨ�÷���

        /// <summary>
        /// �ر��Ӵ��������������ݵĴ���
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
        /// ����datagridview������
        /// </summary>
        private void loadData()
        {
            string value = "";
            allData = material.GetList(99999, value);
            superGridControlMaterial.PrimaryGrid.DataSource = ch.DataTableReCoding( allData);
        }

        /// <summary>
        /// �ص�������״ͼ
        /// </summary>
        /// <param name="ParentID">����ID ��ʼӦΪ""</param>
        /// <param name="pNode">��ǰ�ڵ� ��ʼΪnull</param>
        /// <param name="dvTree">data��ͼ ��ʼΪ���е�datatable����</param>
        private void AddTree(object ParentID, TreeNode pNode, DataView dvTree)
        {
            string ParentId = "parentId";
            string Code = "code";
            string Name = "name";

            //����ParentID,�õ���ǰ�������ӽڵ�
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
                    //��Ӹ��ڵ�
                    Node.Text = Row[Name].ToString();
                    Node.Tag = Row[Code].ToString();
                    treeViewMaterial.Nodes.Add(Node);
                    AddTree(Row[Code].ToString(), Node, dvTree);
                    //չ����һ���ڵ�
                    Node.Expand();
                }
                else
                {
                    //��ӵ�ǰ�ڵ���ӽڵ�
                    Node.Text = Row[Name].ToString();
                    Node.Tag = Row[Code].ToString();
                    pNode.Nodes.Add(Node);
                    AddTree(Row[Code].ToString(), Node, dvTree);//�ٴεݹ�
                }
            }
        }
        #endregion
    }
}