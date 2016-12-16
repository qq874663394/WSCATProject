using System;
using System.Data;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using Model;
using HelperUtility.Excel;
using HelperUtility.Encrypt;
using DevComponents.DotNetBar.SuperGrid;
using InterfaceLayer.Base;

namespace WSCATProject.Base
{
    public partial class ClientForm : RibbonForm
    {
        CodingHelper ch = new CodingHelper();
        ClientInterface CI = new ClientInterface();

        private bool isflag = false;
        //�Ƿ��Ӵ���ȷ������Ҫˢ��
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
        //���еĿͻ��б�
        private DataTable allDS = null;
        //����Ľڵ�text
        private string clientNodeText = "���нڵ�";

        public ClientForm()
        {
            InitializeComponent();
        }

        #region ��ʼ��

        private void ClientForm_Load(object sender, EventArgs e)
        {
            //��ֹ�Զ�������
            superGridControlClient.PrimaryGrid.AutoGenerateColumns = false;
            //���ݾ���
            superGridControlClient.DefaultVisualStyles.CellStyles.Default.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleCenter;
            loadTree();
            loadData();
            MultiColumn();
            toolStripComboBoxKey.SelectedIndex = 0;
        }

        //�������ݰ󶨵�dgv
        private void loadData()
        {
            try
            {
                allDS = CI.GetClientByBool(false);
                superGridControlClient.PrimaryGrid.DataSource = ch.DataTableReCoding(allDS);
            }
            catch (Exception ex)
            {

                MessageBox.Show("��ѯ����ʧ��,������������ӡ��쳣:" + ex.Message);
            }
        }

        //�ݹ�������Ľڵ�
        private void AddTree(string ParentID, TreeNode pNode, DataTable table)
        {
            string ParentId = "parentID";
            string Code = "code";
            string Name = "name";

            DataView dvTree = new DataView(table);
            //����ParentID,�õ���ǰ�������ӽڵ�
            dvTree.RowFilter = string.Format("{0} = '{1}'", ParentId, ParentID);
            foreach (DataRowView Row in dvTree)
            {
                TreeNode Node = new TreeNode();
                if (pNode == null)
                {
                    //��Ӹ��ڵ�
                    Node.Text = XYEEncoding.strHexDecode(Row[Name].ToString());
                    Node.Tag = XYEEncoding.strHexDecode(Row[Code].ToString());
                    treeViewClient.Nodes.Add(Node);
                    AddTree(Row[Code].ToString(), Node, table);
                    //չ����һ���ڵ�
                    Node.Expand();
                }
                else
                {
                    //��ӵ�ǰ�ڵ���ӽڵ�
                    Node.Text = XYEEncoding.strHexDecode(Row[Name].ToString());
                    Node.Tag = XYEEncoding.strHexDecode(Row[Code].ToString());
                    pNode.Nodes.Add(Node);
                    AddTree(Row[Code].ToString(), Node, table);//�ٴεݹ� 
                }
            }
        }

        #endregion

        #region treeview�Ĳ���
        //�����ڵ�
        private void conToolStripMenuItemChild_Click(object sender, EventArgs e)
        {
            if (treeViewClient.SelectedNode != null)
            {
                InsNodes insN = new InsNodes();
                insN.city_code = treeViewClient.SelectedNode.Tag.ToString();
                insN.ShowDialog(this);
                if (Isflag)
                {
                    loadTree();
                    isflag = false;
                    this.Focus();
                }
            }
            else
            {
                MessageBox.Show("��ѡ����Ҫ���ӵ��ϼ�����");
            }
        }

        //ɾ���ڵ� 
        private void conToolStripMenuItemDelete_Click(object sender, EventArgs e)
        {
            if (treeViewClient.SelectedNode != null)
            {
                AreaInterface cm = new AreaInterface();
                try
                {
                    if (cm.UpdateAllClear(0, 0, treeViewClient.SelectedNode.Tag.ToString()) > 0)
                    {
                        treeViewClient.SelectedNode.Remove();
                        MessageBox.Show("ɾ���ó��гɹ�!");
                    }
                    else
                    {
                        MessageBox.Show("ɾ���ó�����Ϣʧ��,�����³���");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("ɾ��������Ϣ�����쳣,�������������." + ex.Message);
                }
            }
        }

        //�༭�ڵ� 
        private void conToolStripMenuItemEdit_Click(object sender, EventArgs e)
        {
            if (treeViewClient.SelectedNode != null)
            {
                InsNodes insNodes = new InsNodes();
                BaseArea city = new BaseArea();
                city.name = treeViewClient.SelectedNode.Text;
                city.code = treeViewClient.SelectedNode.Tag.ToString();
                city.parentId = treeViewClient.SelectedNode.Parent.Tag.ToString();
                city.isClear = 1;
                city.isEnable = 1;
                insNodes.city = city;
                insNodes.ShowDialog(this);
                if (isflag)
                {
                    loadTree();
                }
            }
            else
            {
                MessageBox.Show("����ѡ��Ҫ�༭�Ľڵ�");
            }
        }

        /// <summary>
        /// ���ұ߿հ׶�λ����߽ڵ�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void treeViewClient_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                treeViewClient.SelectedNode = treeViewClient.GetNodeAt(e.X, e.Y);
            }
        }

        //����ڵ�ɸѡ�����з��ϵ���Ľڵ����
        private void treeViewClient_AfterSelect(object sender, TreeViewEventArgs e)
        {
            clientNodeText = e.Node.Text;
            AreaInterface cm = new AreaInterface();
            if (allDS != null)
            {
                try
                {
                    superGridControlClient.PrimaryGrid.DataSource =
                                cm.searchClientByNodeClick(allDS,
                                clientNodeText, "����");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
        #endregion

        #region �����˵��Ĳ���

        private void ToolStripMenuItemRefresh_Click(object sender, EventArgs e)
        {
            loadData();
            treeViewClient.SelectedNode = treeViewClient.Nodes[0];
        }

        //������ť
        private void toolStripButtonSeach_Click(object sender, EventArgs e)
        {
            string field = toolStripComboBoxKey.Text;
            string text = toolStripTextBoxValue.Text.Trim();
            AreaInterface cm = new AreaInterface();

            if (allDS != null)
            {
                try
                {
                    superGridControlClient.PrimaryGrid.DataSource =
                                cm.searchClientByNodeClick(allDS,
                                text, field);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        //����
        private void ToolStripMenuItemCreate_Click(object sender, EventArgs e)
        {
            CreateClientForm ccf = new CreateClientForm();
            ccf.ShowDialog(this);
            closeDispose();
        }

        //�༭
        private void ToolStripMenuItemEdit_Click(object sender, EventArgs e)
        {
            BaseClient client = null;
            if (superGridControlClient.GetSelectedRows().Count > 0)
            {
                SelectedElementCollection col = superGridControlClient.GetSelectedRows();
                if (col.Count > 0)
                {
                    GridRow gridRow = col[0] as GridRow;
                    client = new BaseClient()
                    {
                        id = gridRow.Cells["gridColumnID"].Value == null ? 0 : Convert.ToInt32(gridRow.Cells["gridColumnID"].Value),
                        code = gridRow.Cells["gridColumnCode"].Value == null ? "" : Convert.ToString(gridRow.Cells["gridColumnCode"].Value),
                        fingerPrints = gridRow.Cells["gridColumnZ"].Value == null ? "" : gridRow.Cells["gridColumnZ"].Value.ToString(),
                        name = gridRow.Cells["gridColumnCliName"].Value == null ? "" : gridRow.Cells["gridColumnCliName"].Value.ToString(),
                        linkMan = gridRow.Cells["gridColumnMan"].Value == null ? "" : gridRow.Cells["gridColumnMan"].Value.ToString(),
                        companyName = gridRow.Cells["gridColumnCo"].Value == null ? "" : gridRow.Cells["gridColumnCo"].Value.ToString(),
                        mobilePhone = gridRow.Cells["gridColumnPho"].Value == null ? "" : gridRow.Cells["gridColumnPho"].Value.ToString(),
                        fixedPhone = gridRow.Cells["gridColumnPho2"].Value == null ? "" : gridRow.Cells["gridColumnPho2"].Value.ToString(),
                        fax = gridRow.Cells["gridColumnFax"].Value == null ? "" : gridRow.Cells["gridColumnFax"].Value.ToString(),
                        cityCode = gridRow.Cells["gridColumnCiCode"].Value == null ? "" : gridRow.Cells["gridColumnCiCode"].Value.ToString(),
                        cityName = gridRow.Cells["gridColumnArea"].Value == null ? "" : gridRow.Cells["gridColumnArea"].Value.ToString(),
                        address = gridRow.Cells["gridColumnAd"].Value == null ? "" : gridRow.Cells["gridColumnAd"].Value.ToString(),
                        typeCode = gridRow.Cells["gridColumnTy"].Value == null ? "" : gridRow.Cells["gridColumnTy"].Value.ToString(),
                        typeName = gridRow.Cells["gridColumnTyName"].Value == null ? "" : gridRow.Cells["gridColumnTyName"].Value.ToString(),
                        discountCode = gridRow.Cells["gridColumnDiCode"].Value == null ? "" : gridRow.Cells["gridColumnDiCode"].Value.ToString(),
                        bankCard = gridRow.Cells["gridColumnBa"].Value == null ? "" : gridRow.Cells["gridColumnBa"].Value.ToString(),
                        openBank = gridRow.Cells["gridColumnOpB"].Value == null ? "" : gridRow.Cells["gridColumnOpB"].Value.ToString(),
                        createTime = gridRow.Cells["gridColumnCre"].Value == null ? Convert.ToDateTime("2000-01-01") : Convert.ToDateTime(gridRow.Cells["gridColumnCre"].Value),
                        availableBalance = gridRow.Cells["gridColumnLim"].Value == null ? 0 : Convert.ToDecimal(gridRow.Cells["gridColumnLim"].Value),
                        balance = gridRow.Cells["gridColumnReLim"].Value == null ? 0 : Convert.ToDecimal(gridRow.Cells["gridColumnReLim"].Value),
                        statementDate = gridRow.Cells["gridColumnDay"].Value == null ? Convert.ToDateTime("2000-01-01") : Convert.ToDateTime(gridRow.Cells["gridColumnDay"].Value),
                        receivables = gridRow.Cells["gridColumnSho"].Value == null ? 0 : Convert.ToDecimal(gridRow.Cells["gridColumnSho"].Value),
                        moneyReceipt = gridRow.Cells["gridColumnGet"].Value == null ? 0 : Convert.ToDecimal(gridRow.Cells["gridColumnGet"].Value),
                        advanceReceipts = gridRow.Cells["gridColumnPre"].Value == null ? 0 : Convert.ToDecimal(gridRow.Cells["gridColumnPre"].Value),
                        remark = gridRow.Cells["gridColumnRem"].Value == null ? "" : gridRow.Cells["gridColumnRem"].Value.ToString(),
                        reserved1 = gridRow.Cells["gridColumnsafetone"].Value == null ? "" : gridRow.Cells["gridColumnsafetone"].Value.ToString(),
                        reserved2 = gridRow.Cells["gridColumnsafettwo"].Value == null ? "" : gridRow.Cells["gridColumnsafettwo"].Value.ToString(),
                        picName = gridRow.Cells["gridColumnPic"].Value == null ? "" : gridRow.Cells["gridColumnPic"].Value.ToString(),
                        enable = 1,
                        initialReturnTime = Convert.ToDateTime("2000-01-01"),
                        initialSalesTime = Convert.ToDateTime("2000-01-01"),
                        lastReturnTime = Convert.ToDateTime("2000-01-01"),
                        lastSalesTime = Convert.ToDateTime("2000-01-01"),
                        updateDate = DateTime.Now
                    };
                }
                CreateClientForm ccf = new CreateClientForm();
                ccf.Client = client;
                ccf.ShowDialog(this);
                closeDispose();
            }
            else
            {
                MessageBox.Show("��ѡ��Ҫ�޸ĵ���");
            }
        }

        private void ToolStripMenuItemDelete_Click(object sender, EventArgs e)
        {
            if (superGridControlClient.GetSelectedRows().Count > 0)
            {
                if (DialogResult.No == MessageBox.Show("ȷ��Ҫɾ��ѡ���е�������?", "��ע��",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2))
                {
                    return;
                }
                BaseArea client = new BaseArea();
                AreaInterface cm = new AreaInterface();
                SelectedElementCollection col = superGridControlClient.GetSelectedRows();
                if (col.Count > 0)
                {
                    GridRow gridRow = col[0] as GridRow;
                    try
                    {
                        int result = cm.UpdateAllClear(0, 0, gridRow.Cells[1].Value.ToString());
                        if (result > 0)
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

        private void ToolStripMenuItemAll_Click(object sender, EventArgs e)
        {

        }

        private void ToolStripMenuItemExcel_Click(object sender, EventArgs e)
        {
            string defaultName = DateTime.Now.ToString("yyyyMMddHHmm") + "�ͻ�����";
            saveFileDialog1.FileName = defaultName + ".xls";
            saveFileDialog1.Filter = "Excel�ļ���*.xls��|*.xls|Excel �ļ�(*.xlsx)|*.xlsx";
            saveFileDialog1.AddExtension = true;
            if (saveFileDialog1.ShowDialog() != DialogResult.OK)
            {
                return;
            }
            DataTable dt = (DataTable)superGridControlClient.PrimaryGrid.DataSource;
            GridColumnCollection gcc = superGridControlClient.PrimaryGrid.Columns;
            string[] x = {
                "�ͻ�����", "�ֻ�", "�绰", "����", "����", "��ϸ��ַ", "��ϵ��", "��λ", "�������", "�����ʺ�",
                "������", "����ʱ��", "���ö��", "ʣ����", "������", "Ӧ�տ�", "���տ�", "Ԥ�տ�", "��ע" };
            dt.Columns.Remove("Cli_ID");
            dt.Columns.Remove("Cli_Code");
            dt.Columns.Remove("Cli_zhiwen");
            dt.Columns.Remove("Cli_PicName");
            dt.Columns.Remove("Cli_CityCode");
            dt.Columns.Remove("Cli_TypeCode");
            dt.Columns.Remove("Cli_DiscountCode");
            dt.Columns.Remove("Cli_Olddata");
            dt.Columns.Remove("Cli_Oldreturn");
            dt.Columns.Remove("Cli_Newoutdata");
            dt.Columns.Remove("Cli_Newintodata");
            dt.Columns.Remove("Cli_safetone");
            dt.Columns.Remove("Cli_safettwo");
            dt.Columns.Remove("Cli_Enable");
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

        #endregion

        #region ��DGV�ؼ����ϲ���
        /// <summary>
        /// ��DGV�ؼ����ϲ���
        /// </summary>
        private void MultiColumn()
        {
            GridPanel panel = superGridControlClient.PrimaryGrid;
            GridColumnCollection columns = panel.Columns;

            panel.ColumnHeader.GroupHeaders.Add(
                GetSlCompanyInfoHeader(
                    columns,
                    "Columnsbase",
                    "�ͻ���������",
                    "gridColumnCliName",
                    "gridColumnFax"));
            panel.ColumnHeader.GroupHeaders.Add(
                GetSlCompanyInfoHeader(
                    columns,
                    "Columnslocation",
                    "��ϵ��ַ",
                    "gridColumnArea",
                    "gridColumnAd"));
            //panel.ColumnHeader.GroupHeaders.Add(
            //    GetSlCompanyInfoHeader(
            //        columns,
            //        "Columnsother",
            //        "������Ϣ",
            //        "gridColumnBa",
            //        "gridColumnPic"));
        }

        /// <summary>
        /// �ϲ��з���
        /// </summary>
        /// <returns></returns>
        private ColumnGroupHeader GetSlCompanyInfoHeader(
            GridColumnCollection columns,
            string name,
            string headerText,
            string startName,
            string endName)
        {
            ColumnGroupHeader cgh = new ColumnGroupHeader();

            cgh.Name = name;
            cgh.HeaderText = headerText;

            cgh.MinRowHeight = 36;

            cgh.StartDisplayIndex = GetDisplayIndex(columns, startName);
            cgh.EndDisplayIndex = GetDisplayIndex(columns, endName);

            //superGridControl1.PrimaryGrid
            return (cgh);
        }
        private int GetDisplayIndex(GridColumnCollection columns, string name)
        {
            return (columns.GetDisplayIndex(columns[name]));
        }
        #endregion

        #region dgv���Ҽ��˵�

        private void ����ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItemCreate.PerformClick();
        }

        private void �༭ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItemEdit.PerformClick();
        }

        private void ɾ��ToolStripMenuItem_Click(object sender, EventArgs e)
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

        //˫�������༭
        private void superGridControlClient_CellDoubleClick(object sender,
            GridCellDoubleClickEventArgs e)
        {
            if (e.MouseEventArgs.Button == MouseButtons.Left)
            {
                ToolStripMenuItemEdit.PerformClick();
            }
        }

        /// <summary>
        /// �ر��Ӵ��������������ݵĴ��� 
        /// </summary>
        private void closeDispose()
        {
            if (isflag)
            {
                loadData();
                treeViewClient.SelectedNode = treeViewClient.Nodes[0];
            }
            else
            {
                treeViewClient.SelectedNode = treeViewClient.Nodes[0];
            }
            isflag = false;
        }

        private void loadTree()
        {
            treeViewClient.Nodes.Clear();
            AreaInterface cm = new AreaInterface();
            DataTable dt = cm.GetList(999,"",false,false);
            AddTree("", null, dt);
        }
        #endregion
    }
}