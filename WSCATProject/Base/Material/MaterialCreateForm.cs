using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Model;
using HelperUtility;
using HelperUtility.Encrypt;
using DevComponents.DotNetBar.Controls;
using DevComponents.AdvTree;
using InterfaceLayer.Base;

namespace WSCATProject.Base
{
    public partial class MaterialCreateForm : Form
    {
        public MaterialCreateForm()
        {
            InitializeComponent();
        }

        private BaseMaterial material = null;

        public BaseMaterial Material
        {
            get
            {
                return material;
            }

            set
            {
                material = value;
            }
        }

        private void MaterialCreateForm_Load(object sender, EventArgs e)
        {
            MaterialTypeInterface mtm = new MaterialTypeInterface();
            DataTable dt = mtm.GetList(999, "", false, false);
            DataView dvTree = new DataView(dt);
            AddTree("", null, dvTree);
            bindCombo();
            comboTreeType.AdvTree.NodeDoubleClick += AdvTree_NodeDoubleClick;
            initUI();
        }

        private void buttonXEnter_Click(object sender, EventArgs e)
        {
            if (material == null)
            {
                if (!string.IsNullOrWhiteSpace(textBoxXName.Text))
                {
                    BaseMaterial material = new BaseMaterial();
                    material.barCode = XYEEncoding.strCodeHex(textBoxXBarcode.Text.Trim());
                    material.isClear = 1;
                    material.code = XYEEncoding.strCodeHex(BuildCode.ModuleCode("MA"));
                    if (dateTimeInputCreate.Text != "")
                    {
                        material.createDate = dateTimeInputCreate.Value.Date;
                    }
                    material.isEnable = checkBoxXEnable.Checked ? 0 : 1;
                    if (dateTimeInputInput.Text != "")
                    {
                        material.inDate = dateTimeInputInput.Value.Date;
                    }
                    material.inPrice = Convert.ToDecimal(textBoxXInPrice.Text.Trim());
                    material.model = XYEEncoding.strCodeHex(textBoxXTypeModel.Text.Trim());
                    material.name = XYEEncoding.strCodeHex(textBoxXName.Text.Trim());
                    material.picName = "";
                    material.outPrice = Convert.ToDecimal(textBoxXOutPrice.Text.Trim());
                    material.price = Convert.ToDecimal(textBoxXPA.Text.Trim());
                    material.priceB = Convert.ToDecimal(textBoxXPB.Text.Trim());
                    material.priceC = Convert.ToDecimal(textBoxXPC.Text.Trim());
                    material.priceD = Convert.ToDecimal(textBoxXPD.Text.Trim());
                    material.priceE = 0;
                    material.remark = XYEEncoding.strCodeHex(textBoxXRemark.Text.Trim());
                    //material.Ma_RFID = XYEEncoding.strCodeHex(textBoxXRFID.Text.Trim());
                    if (comboBoxExSupplier.SelectedText != null &&
                        comboBoxExSupplier.SelectedValue != null)
                    {
                        material.supplierCode = XYEEncoding.strCodeHex(comboBoxExSupplier.SelectedValue.ToString());
                        material.supplierName = XYEEncoding.strCodeHex(comboBoxExSupplier.SelectedText);
                    }
                    if (comboTreeType.SelectedNode != null)
                    {
                        material.typeID = XYEEncoding.strCodeHex(comboTreeType.SelectedNode.Tag.ToString());
                        material.typeName = XYEEncoding.strCodeHex(comboTreeType.SelectedNode.FullPath.Replace(';', '/'));
                    }
                    material.unit = textBoxXUnit.Text.Trim();
                    material.materialDaima = XYEEncoding.strCodeHex(textBoxXzhujima.Text.Trim());

                    MaterialInterface mm = new MaterialInterface();

                    try
                    {
                        int result = mm.Add(material);
                        if (result > 0)
                        {
                            MessageBox.Show("新增产品成功!");
                            MaterialForm mf = (MaterialForm)this.Owner;
                            mf.Isflag = true;
                        }
                        else
                        {
                            MessageBox.Show("更新失败,请检查服务器连接并尝试重新更新数据");
                        }
                        Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("新增产品出错,请检查服务器连接.错误:" + ex.Message);
                        Close();
                    }
                }
                else
                {
                    MessageBox.Show("货品名称不可为空,请注意 电影时间确实太短了，要把故事说全的话估计");
                }
            }
            else
            {
                if (!string.IsNullOrWhiteSpace(textBoxXName.Text))
                {
                    material.barCode = XYEEncoding.strCodeHex(textBoxXBarcode.Text.Trim());
                    if (dateTimeInputCreate.Text != "")
                    {
                        material.createDate = dateTimeInputCreate.Value;
                    }
                    if (dateTimeInputInput.Text != "")
                    {
                        material.inDate = dateTimeInputInput.Value;
                    }
                    material.inPrice = Convert.ToDecimal(textBoxXInPrice.Text.Trim());
                    material.model = XYEEncoding.strCodeHex(textBoxXTypeModel.Text.Trim());
                    material.name = XYEEncoding.strCodeHex(textBoxXName.Text.Trim());
                    material.outPrice = Convert.ToDecimal(textBoxXOutPrice.Text.Trim());
                    material.price = Convert.ToDecimal(textBoxXPA.Text.Trim());
                    material.priceB = Convert.ToDecimal(textBoxXPB.Text.Trim());
                    material.priceC = Convert.ToDecimal(textBoxXPC.Text.Trim());
                    material.priceD = Convert.ToDecimal(textBoxXPD.Text.Trim());
                    material.priceE = 0;
                    material.remark = XYEEncoding.strCodeHex(textBoxXRemark.Text.Trim());
                    //material.Ma_RFID = XYEEncoding.strCodeHex(textBoxXRFID.Text.Trim());
                    if (comboBoxExSupplier.SelectedText != null &&
                        comboBoxExSupplier.SelectedValue != null)
                    {
                        material.supplierCode = XYEEncoding.strCodeHex(comboBoxExSupplier.SelectedValue.ToString());
                        material.supplierName = XYEEncoding.strCodeHex(comboBoxExSupplier.SelectedText);
                    }
                    if (comboTreeType.SelectedNode != null)
                    {
                        material.typeID = XYEEncoding.strCodeHex(comboTreeType.SelectedNode.Tag.ToString());
                        material.typeName = XYEEncoding.strCodeHex(comboTreeType.SelectedNode.FullPath.Replace(';', '/'));
                    }
                    material.unit = textBoxXUnit.Text.Trim();
                    material.materialDaima = XYEEncoding.strCodeHex(textBoxXzhujima.Text.Trim());

                    MaterialInterface mm = new MaterialInterface();

                    try
                    {
                        bool result = mm.Update(material);
                        if (result)
                        {
                            MessageBox.Show("更新产品信息成功!");
                            MaterialForm mf = (MaterialForm)this.Owner;
                            mf.Isflag = true;
                        }
                        else
                        {
                            MessageBox.Show("更新失败,请检查服务器连接并尝试重新更新数据");
                        }
                        Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("更新产品出错,请检查服务器连接.错误:" + ex.Message);
                        Close();
                    }
                }
                else
                {
                    MessageBox.Show("货品名称不可为空,请注意");
                }
            }
        }

        /// <summary>
        /// 回调加载树状图
        /// </summary>
        /// <param name="ParentID">父级ID 初始应为""</param>
        /// <param name="pNode">当前节点 初始为null</param>
        /// <param name="dvTree">data视图 初始为所有的datatable数据</param>
        private void AddTree(string ParentID, Node pNode, DataView dvTree)
        {
            if (ParentID == "")
            {
                ParentID = "0";
            }
            string ParentId = "MT_ParentID";
            string Code = "MT_Code";
            string Name = "MT_Name";

            //过滤ParentID,得到当前的所有子节点
            dvTree.RowFilter = string.Format("{0} = '{1}'", ParentId, ParentID);
            foreach (DataRowView Row in dvTree)
            {
                Node Node = new Node();
                if (pNode == null)
                {
                    //添加根节点
                    Node.Text = Row[Name].ToString();
                    Node.Tag = Row[Code].ToString();
                    comboTreeType.Nodes.Add(Node);
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

        private void buttonXCacel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void bindCombo()
        {

        }

        private void initUI()
        {
            if(material != null)
            {
                textBoxXBarcode.Text = material.barCode;
                if (material.createDate != null)
                {
                    dateTimeInputCreate.Value = material.createDate.Value;
                }
                if (material.inDate != null)
                {
                    dateTimeInputInput.Value = material.inDate.Value;
                }
                textBoxXInPrice.Text = material.inPrice.ToString();
                textBoxXTypeModel.Text = material.model;
                textBoxXName.Text = material.name;
                textBoxXOutPrice.Text = material.outPrice.ToString();
                textBoxXPA.Text = material.price.ToString();
                textBoxXPB.Text = material.priceB.ToString();
                textBoxXPC.Text = material.priceC.ToString();
                textBoxXPD.Text = material.priceD.ToString();
                textBoxXRemark.Text = material.remark;
                //textBoxXRFID.Text = material;
                //if (comboBoxExSupplier.SelectedText != null &&
                //    comboBoxExSupplier.SelectedValue != null)
                //{
                //    material.Ma_SupID = XYEEncoding.strCodeHex(comboBoxExSupplier.SelectedValue.ToString());
                //    material.Ma_Supplier = XYEEncoding.strCodeHex(comboBoxExSupplier.SelectedText);
                //}
                //if (comboTreeType.SelectedNode != null)
                //{
                //    material.Ma_TypeID = XYEEncoding.strCodeHex(comboTreeType.SelectedNode.Tag.ToString());
                //    material.Ma_TypeName = XYEEncoding.strCodeHex(comboTreeType.SelectedNode.FullPath.Replace(';', '/'));
                //}
                textBoxXUnit.Text = material.unit.ToString();
                textBoxXzhujima.Text = material.materialDaima;

                if (!string.IsNullOrWhiteSpace(material.typeName) && comboTreeType.Nodes.Count > 0)
                {
                    comboTreeType.SelectedIndex = 0;
                    string[] areas = material.typeName.Split('/');
                    int len = areas.Length;
                    //判断头节点的文本是否是当前树的头结点 不是则不调用遍历(节点不存在于当前树状结构)
                    if (comboTreeType.Nodes[0].Text == areas[0])
                    {
                        searchTreeNode(comboTreeType.Nodes[0], areas, len, 1);
                    }
                    else
                    {
                        comboTreeType.SelectedIndex = -1;
                    }
                }
                else
                {
                    comboTreeType.SelectedIndex = -1;
                }
            }
        }

        private void AdvTree_NodeDoubleClick(object sender, TreeNodeMouseEventArgs e)
        {
            comboTreeType.IsPopupOpen = false;
        }

        /// <summary>
        /// 遍历节点找到末尾节点
        /// </summary>
        /// <param name="pNode">头节点</param>
        /// <param name="path">路径数组,从头到尾正序</param>
        /// <param name="len">总长度</param>
        /// <param name="depth">当前深度</param>
        private void searchTreeNode(Node pNode, string[] path, int len, int depth)
        {
            //循环子节点
            foreach (Node childNode in pNode.Nodes)
            {
                if (childNode.Text == path[depth])
                {
                    depth++;
                    if (depth == len)
                    {
                        comboTreeType.SelectedNode = childNode;
                        break;
                    }
                    else
                    {
                        searchTreeNode(childNode, path, len, depth);
                    }
                }
            }
        }
    }
}
