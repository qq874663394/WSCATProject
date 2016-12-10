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

namespace WSCATProject.Base
{
    public partial class MaterialCreateForm : Form
    {
        public MaterialCreateForm()
        {
            InitializeComponent();
        }

        private Model.Material material = null;

        public Model.Material Material
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
            MaterialTypeManager mtm = new MaterialTypeManager();
            DataTable dt = mtm.GetList("").Tables[0];
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
                    Model.Material material = new Model.Material();
                    material.Ma_Barcode = XYEEncoding.strCodeHex(textBoxXBarcode.Text.Trim());
                    material.Ma_Clear = 1;
                    material.Ma_Code = XYEEncoding.strCodeHex(BuildCode.ModuleCode("MA"));
                    if (dateTimeInputCreate.Text != "")
                    {
                        material.Ma_CreateDate = dateTimeInputCreate.Value.Date;
                    }
                    material.Ma_Enable = checkBoxXEnable.Checked ? 0 : 1;
                    if (dateTimeInputInput.Text != "")
                    {
                        material.Ma_InDate = dateTimeInputInput.Value.Date;
                    }
                    material.Ma_InPrice = Convert.ToDecimal(textBoxXInPrice.Text.Trim());
                    material.Ma_Model = XYEEncoding.strCodeHex(textBoxXTypeModel.Text.Trim());
                    material.Ma_Name = XYEEncoding.strCodeHex(textBoxXName.Text.Trim());
                    material.Ma_PicName = "";
                    material.Ma_Price = Convert.ToDecimal(textBoxXOutPrice.Text.Trim());
                    material.Ma_PriceA = Convert.ToDecimal(textBoxXPA.Text.Trim());
                    material.Ma_PriceB = Convert.ToDecimal(textBoxXPB.Text.Trim());
                    material.Ma_PriceC = Convert.ToDecimal(textBoxXPC.Text.Trim());
                    material.Ma_PriceD = Convert.ToDecimal(textBoxXPD.Text.Trim());
                    material.Ma_PriceE = 0;
                    material.Ma_Remark = XYEEncoding.strCodeHex(textBoxXRemark.Text.Trim());
                    material.Ma_RFID = XYEEncoding.strCodeHex(textBoxXRFID.Text.Trim());
                    if (comboBoxExSupplier.SelectedText != null &&
                        comboBoxExSupplier.SelectedValue != null)
                    {
                        material.Ma_SupID = XYEEncoding.strCodeHex(comboBoxExSupplier.SelectedValue.ToString());
                        material.Ma_Supplier = XYEEncoding.strCodeHex(comboBoxExSupplier.SelectedText);
                    }
                    if (comboTreeType.SelectedNode != null)
                    {
                        material.Ma_TypeID = XYEEncoding.strCodeHex(comboTreeType.SelectedNode.Tag.ToString());
                        material.Ma_TypeName = XYEEncoding.strCodeHex(comboTreeType.SelectedNode.FullPath.Replace(';', '/'));
                    }
                    material.Ma_Unit = textBoxXUnit.Text.Trim();
                    material.Ma_zhujima = XYEEncoding.strCodeHex(textBoxXzhujima.Text.Trim());

                    MaterialManager mm = new MaterialManager();

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
                    material.Ma_Barcode = XYEEncoding.strCodeHex(textBoxXBarcode.Text.Trim());
                    if (dateTimeInputCreate.Text != "")
                    {
                        material.Ma_CreateDate = dateTimeInputCreate.Value;
                    }
                    if (dateTimeInputInput.Text != "")
                    {
                        material.Ma_InDate = dateTimeInputInput.Value;
                    }
                    material.Ma_InPrice = Convert.ToDecimal(textBoxXInPrice.Text.Trim());
                    material.Ma_Model = XYEEncoding.strCodeHex(textBoxXTypeModel.Text.Trim());
                    material.Ma_Name = XYEEncoding.strCodeHex(textBoxXName.Text.Trim());
                    material.Ma_Price = Convert.ToDecimal(textBoxXOutPrice.Text.Trim());
                    material.Ma_PriceA = Convert.ToDecimal(textBoxXPA.Text.Trim());
                    material.Ma_PriceB = Convert.ToDecimal(textBoxXPB.Text.Trim());
                    material.Ma_PriceC = Convert.ToDecimal(textBoxXPC.Text.Trim());
                    material.Ma_PriceD = Convert.ToDecimal(textBoxXPD.Text.Trim());
                    material.Ma_PriceE = 0;
                    material.Ma_Remark = XYEEncoding.strCodeHex(textBoxXRemark.Text.Trim());
                    material.Ma_RFID = XYEEncoding.strCodeHex(textBoxXRFID.Text.Trim());
                    if (comboBoxExSupplier.SelectedText != null &&
                        comboBoxExSupplier.SelectedValue != null)
                    {
                        material.Ma_SupID = XYEEncoding.strCodeHex(comboBoxExSupplier.SelectedValue.ToString());
                        material.Ma_Supplier = XYEEncoding.strCodeHex(comboBoxExSupplier.SelectedText);
                    }
                    if (comboTreeType.SelectedNode != null)
                    {
                        material.Ma_TypeID = XYEEncoding.strCodeHex(comboTreeType.SelectedNode.Tag.ToString());
                        material.Ma_TypeName = XYEEncoding.strCodeHex(comboTreeType.SelectedNode.FullPath.Replace(';', '/'));
                    }
                    material.Ma_Unit = textBoxXUnit.Text.Trim();
                    material.Ma_zhujima = XYEEncoding.strCodeHex(textBoxXzhujima.Text.Trim());

                    MaterialManager mm = new MaterialManager();

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
                textBoxXBarcode.Text = material.Ma_Barcode;
                if (material.Ma_CreateDate != null)
                {
                    dateTimeInputCreate.Value = material.Ma_CreateDate.Value;
                }
                if (material.Ma_InDate != null)
                {
                    dateTimeInputInput.Value = material.Ma_InDate.Value;
                }
                textBoxXInPrice.Text = material.Ma_InPrice.ToString();
                textBoxXTypeModel.Text = material.Ma_Model;
                textBoxXName.Text = material.Ma_Name;
                textBoxXOutPrice.Text = material.Ma_Price.ToString();
                textBoxXPA.Text = material.Ma_PriceA.ToString();
                textBoxXPB.Text = material.Ma_PriceB.ToString();
                textBoxXPC.Text = material.Ma_PriceC.ToString();
                textBoxXPD.Text = material.Ma_PriceD.ToString();
                textBoxXRemark.Text = material.Ma_Remark;
                textBoxXRFID.Text = material.Ma_RFID;
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
                textBoxXUnit.Text = material.Ma_Unit.ToString();
                textBoxXzhujima.Text = material.Ma_zhujima;

                if (!string.IsNullOrWhiteSpace(material.Ma_TypeName) && comboTreeType.Nodes.Count > 0)
                {
                    comboTreeType.SelectedIndex = 0;
                    string[] areas = material.Ma_TypeName.Split('/');
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
