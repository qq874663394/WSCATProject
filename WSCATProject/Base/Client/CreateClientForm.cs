using System;
using System.Data;
using System.Windows.Forms;
using DevComponents.AdvTree;
using BLL;
using Model;
using HelperUtility.Encrypt;
using HelperUtility;
using DevComponents.DotNetBar.Controls;

namespace WSCATProject.Base
{
    public partial class CreateClientForm : Form
    {
        public CreateClientForm()
        {
            InitializeComponent();
        }

        private Client client = null;//由父窗体传递的client实体

        public Client Client
        {
            get
            {
                return client;
            }

            set
            {
                client = value;
            }
        }

        private void CreateClientForm_Load(object sender, EventArgs e)
        {
            Node n = new Node();
            AddTree("",null,"",comboTreeCity);//初始化下拉树状列表
            AddTree("", null, "P", comboTreeType);
            comboTreeCity.AdvTree.NodeDoubleClick += AdvTree_NodeDoubleClick;
            initUI();
        }

        private void initUI()
        {
            comboBoxExDeadline.SelectedIndex = 0;
            checkBoxXDis.Checked = false;
            //不为空时为修改
            if(client != null)
            {
                textBoxXCompany.Text = client.Cli_Company;
                textBoxXAmout.Text = client.Cli_Limit;
                textBoxXName.Text = client.Cli_Name;
                textBoxXPhone2.Text = client.Cli_PhoneTwo;
                textBoxXPhone.Text = client.Cli_Phone;
                textBoxXMan.Text = client.Cli_LinkMan;
                textBoxXFax.Text = client.Cli_faxes;
                textBoxXAddress.Text = client.Cli_Address;
                textBoxXBank.Text = client.Cli_OpenBank;
                textBoxXBankCode.Text = client.Cli_Bankaccounts;
                integerInputDay.Text = client.Cli_ClearLimitdate;
                textBoxXRemark.Text = client.Cli_Remark;

                labelX7.Visible = false;
                textBoxXDisc.Visible = false;
                labelX13.Visible = false;
                checkBoxXDis.Visible = false;
                textBoxXDeadline.Visible = false;
                labelX12.Visible = false;
                comboBoxExDeadline.Visible = false;

                if(!string.IsNullOrWhiteSpace(client.Cli_area) && comboTreeCity.Nodes.Count > 0)
                {
                    comboTreeCity.SelectedIndex = 0;
                    string[] areas = client.Cli_area.Split('/');
                    int len = areas.Length;
                    //判断头节点的文本是否是当前树的头结点 不是则不调用遍历(节点不存在于当前树状结构)
                    if (comboTreeCity.Nodes[0].Text == areas[0])
                    {
                        searchTreeNode(comboTreeCity.Nodes[0], areas, len, 1);
                    }
                    else
                    {
                        comboTreeCity.SelectedIndex = -1;
                    }
                }
                else
                {
                    comboTreeCity.SelectedIndex = -1;
                }
            }
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
                        comboTreeCity.SelectedNode = childNode;
                        break;
                    }
                    else
                    {
                        searchTreeNode(childNode, path, len, depth);
                    }
                }
            }
        }

        //回调遍历节点
        private void AddTree(string ParentID, Node pNode, string table,ComboTree ct)
        {
            CityManager cm = new CityManager();
            ProfessionManager pm = new ProfessionManager();

            if (ParentID == "")
            {
                ParentID = "D4";
            }
            string ParentId = "City_ParentID";
            string Code = "City_Code";
            string Name = "City_Name";
            DataTable dt = cm.GetList("").Tables[0];
            if (table == "P")
            {
                ParentId = "ST_ParentID";
                Code = "ST_Code";
                Name = "ST_Name";
                dt = pm.GetList("").Tables[0];
            }
            DataView dvTree = new DataView(dt);
            //过滤ParentID,得到当前的所有子节点
            dvTree.RowFilter = string.Format("{0} = '{1}'", ParentId, ParentID);
            foreach (DataRowView Row in dvTree)
            {
                Node node = new Node();
                if (pNode == null)
                {
                    //添加根节点
                    node.Text = XYEEncoding.strHexDecode(Row[Name].ToString());
                    node.Tag = XYEEncoding.strHexDecode(Row[Code].ToString());
                    ct.Nodes.Add(node);
                    AddTree(Row[Code].ToString(), node, table,ct);
                    //展开第一级节点 
                    node.Expand();
                }
                else
                {
                    //添加当前节点的子节点
                    node.Text = XYEEncoding.strHexDecode(Row[Name].ToString());
                    node.Tag = XYEEncoding.strHexDecode(Row[Code].ToString());
                    pNode.Nodes.Add(node);
                    AddTree(Row[Code].ToString(), node, table,ct);//再次递归 
                }
            }
        }

        
        private void textBoxX5_KeyPress(object sender, KeyPressEventArgs e)
        {
            keyPress(sender, e);
        }

        private void textBoxXAmout_KeyPress(object sender, KeyPressEventArgs e)
        {
            keyPress(sender, e);
        }

        private void textBoxXDeadline_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(((e.KeyChar >= '0') && (e.KeyChar <= '9')) || e.KeyChar <= 31))
            {
                    e.Handled = true;
            }
            else
            {
                if (e.KeyChar == '\b')
                {
                    e.Handled = false;
                }
            }
        }

        /// <summary>
        /// 输入完成后判断是否符合规格
        /// </summary>
        private void textBoxX5_Validated(object sender, EventArgs e)
        {
            decimal dd;
            if(decimal.TryParse(textBoxXDisc.Text,out dd))
            {
                if(dd > 10)
                {
                    MessageBox.Show("只可输入0~9.9以内的数");
                    textBoxXDisc.Text = "0";
                }
            }
            if(textBoxXDisc.TextLength == 0)
            {
                textBoxXDisc.Text = "0";
            }
        }

        //输入不可为空
        private void integerInputDay_Validated(object sender, EventArgs e)
        {
            if(string.IsNullOrWhiteSpace(integerInputDay.Text))
            {
                integerInputDay.Value = 1;
            }
        }

        //输入不可为空
        private void textBoxXAmout_Validated(object sender, EventArgs e)
        {
            if (textBoxXAmout.TextLength == 0)
            {
                textBoxXAmout.Text = "0";
            }
        }

        //让pannel能获得焦点
        private void tabControlPanel2_Click(object sender, EventArgs e)
        {
            tabControl1.Focus();
        }

        //双击关闭树状图下拉列表
        private void AdvTree_NodeDoubleClick(object sender, TreeNodeMouseEventArgs e)
        {
            comboTreeCity.IsPopupOpen = false;
        }

        //新增客户时把对应的客户折扣新增 
        private void buttonXEnter_Click(object sender, EventArgs e)
        {
            //等于null为新增,不等于为更新
            if(client != null)
            {
                if(string.IsNullOrWhiteSpace(textBoxXName.Text) &&
                    string.IsNullOrWhiteSpace(textBoxXCompany.Text))
                {
                    MessageBox.Show("单位名称和客户名不可为空");
                    return;
                }
                Client newClient = new Client();
                ClientManager cm = new ClientManager();

                newClient.Cli_Code = XYEEncoding.strCodeHex(client.Cli_Code);
                newClient.Cli_Name = XYEEncoding.strCodeHex(textBoxXName.Text.Trim());
                newClient.Cli_Phone = XYEEncoding.strCodeHex(textBoxXPhone.Text.Trim());
                newClient.Cli_PhoneTwo = XYEEncoding.strCodeHex(textBoxXPhone2.Text.Trim());
                newClient.Cli_LinkMan = XYEEncoding.strCodeHex(textBoxXMan.Text.Trim());
                newClient.Cli_faxes = XYEEncoding.strCodeHex(textBoxXFax.Text.Trim());
                newClient.Cli_Address = XYEEncoding.strCodeHex(textBoxXAddress.Text.Trim());
                newClient.Cli_Company = XYEEncoding.strCodeHex(textBoxXCompany.Text);

                newClient.Cli_Citycode = XYEEncoding.strCodeHex(comboTreeCity.SelectedNode == null ?
                    "" : comboTreeCity.SelectedNode.Tag.ToString());

                newClient.Cli_area = XYEEncoding.strCodeHex(comboTreeCity.SelectedNode == null ?
                    "" : comboTreeCity.SelectedNode.FullPath.Replace(";", "/"));

                newClient.Cli_TypeCode = XYEEncoding.strCodeHex(comboTreeType.SelectedNode == null ?
                    "" : comboTreeType.SelectedNode.Tag.ToString());

                newClient.Cli_typename = XYEEncoding.strCodeHex(comboTreeType.SelectedNode == null ?
                    "" : comboTreeType.SelectedNode.FullPath.Replace(";", "/"));

                newClient.Cli_Bankaccounts = XYEEncoding.strCodeHex(textBoxXBankCode.Text.Trim());
                newClient.Cli_OpenBank = XYEEncoding.strCodeHex(textBoxXBank.Text.Trim());
                newClient.Cli_Limit = XYEEncoding.strCodeHex(textBoxXAmout.Text.Trim());
                newClient.Cli_ClearLimitdate = XYEEncoding.strCodeHex(integerInputDay.Value.ToString());
                newClient.Cli_Remark = XYEEncoding.strCodeHex(textBoxXRemark.Text);

                newClient.Cli_zhiwen = client.Cli_zhiwen;
                newClient.Cli_PicName = client.Cli_PicName;
                newClient.Cli_DiscountCode = XYEEncoding.strCodeHex(client.Cli_DiscountCode);
                newClient.Cli_Olddata = null;
                newClient.Cli_Oldreturn = null;
                newClient.Cli_Newoutdata = null;
                newClient.Cli_Newintodata = null;
                newClient.Cli_Createdata = client.Cli_Createdata;
                newClient.Cli_RemainLimit = XYEEncoding.strCodeHex(newClient.Cli_Limit);
                newClient.Cli_ShouldMoney = XYEEncoding.strCodeHex(client.Cli_ShouldMoney);
                newClient.Cli_GetMoney = XYEEncoding.strCodeHex(client.Cli_GetMoney);
                newClient.Cli_PreMoney = XYEEncoding.strCodeHex(client.Cli_PreMoney);
                newClient.Cli_safetone = client.Cli_safetone;
                newClient.Cli_safettwo = client.Cli_safettwo;

                newClient.Cli_Enable = 1;
                newClient.Cli_ID = client.Cli_ID;

                try
                {
                    bool result = cm.UpdateByCode(newClient);
                    if(result)
                    {
                        MessageBox.Show("更新成功,数据已更改!");
                        ClientForm cf = (ClientForm)this.Owner;
                        cf.Isflag = true;
                    }
                    else
                    {
                        MessageBox.Show("更新失败,请检查服务器连接并尝试重新更新数据");
                    }
                    Close();
                }
                catch(Exception ex)
                {
                    MessageBox.Show("异常:" + ex.Message);
                    Close();
                }
            }
            else
            {
                if (textBoxXCompany.Text.Trim() == "" ||
                textBoxXName.Text.Trim() == "")
                {
                    MessageBox.Show("单位名称和客户名不可为空");
                }
                else
                {
                    if (checkBoxXDis.Checked && string.IsNullOrWhiteSpace(textBoxXDeadline.Text))
                    {
                        MessageBox.Show("若折扣有期限则需输入期限长度,若无期限请取消勾选");
                        return;
                    }

                    Discount d = new Discount();
                    string clcode = XYEEncoding.strCodeHex(BuildCode.ModuleCode("CL"));
                    string dicode = XYEEncoding.strCodeHex(BuildCode.ModuleCode("DI"));

                    d.Dis_Code = dicode;
                    d.Dis_ClientCode = clcode;
                    d.Dis_Name = XYEEncoding.strCodeHex(textBoxXName.Text.Trim());
                    d.Dis_CreateDate = DateTime.Now;
                    if (checkBoxXDis.Checked)
                    {
                        int number = Convert.ToInt32(textBoxXDeadline.Text.Trim());
                        DateTime tempD = DateTime.Now;
                        switch (comboBoxExDeadline.Text)
                        {
                            case "年":
                                tempD.AddYears(number);
                                break;
                            case "月":
                                tempD.AddMonths(number);
                                break;
                            case "日":
                                tempD.AddDays(number);
                                break;
                        }
                        d.Dis_ClearDate = tempD;
                    }
                    else
                    {
                        d.Dis_ClearDate = null;
                    }
                    d.Dis_Enable = 1;
                    d.Dis_Remark = "";
                    d.Dis_Clear = 1;
                    d.Dis_Discount = XYEEncoding.strCodeHex(textBoxXDisc.Text.Trim());

                    ClientManager cm = new ClientManager();
                    Client c = new Client();

                    c.Cli_Name = XYEEncoding.strCodeHex(textBoxXName.Text.Trim());
                    c.Cli_Code = clcode;
                    c.Cli_Phone = XYEEncoding.strCodeHex(textBoxXPhone.Text.Trim());
                    c.Cli_PhoneTwo = XYEEncoding.strCodeHex(textBoxXPhone2.Text.Trim());
                    c.Cli_LinkMan = XYEEncoding.strCodeHex(textBoxXMan.Text.Trim());
                    c.Cli_faxes = XYEEncoding.strCodeHex(textBoxXFax.Text.Trim());
                    c.Cli_Address = XYEEncoding.strCodeHex(textBoxXAddress.Text.Trim());

                    c.Cli_Citycode = XYEEncoding.strCodeHex(comboTreeCity.SelectedNode == null ?
                        "" : comboTreeCity.SelectedNode.Tag.ToString());

                    c.Cli_area = XYEEncoding.strCodeHex(comboTreeCity.SelectedNode == null ?
                        "" : comboTreeCity.SelectedNode.FullPath.Replace(";", "/"));

                    c.Cli_Company = XYEEncoding.strCodeHex(textBoxXCompany.Text);

                    c.Cli_TypeCode = XYEEncoding.strCodeHex(comboTreeType.SelectedNode == null ?
                        "" : comboTreeType.SelectedNode.Tag.ToString());

                    c.Cli_typename = XYEEncoding.strCodeHex(comboTreeType.SelectedNode == null ?
                        "" : comboTreeType.SelectedNode.FullPath.Replace(";", "/"));

                    c.Cli_DiscountCode = XYEEncoding.strCodeHex(clcode);
                    c.Cli_Bankaccounts = XYEEncoding.strCodeHex(textBoxXBankCode.Text.Trim());
                    c.Cli_OpenBank = XYEEncoding.strCodeHex(textBoxXBank.Text.Trim());
                    c.Cli_Createdata = DateTime.Now;
                    c.Cli_Limit = XYEEncoding.strCodeHex(textBoxXAmout.Text.Trim());
                    c.Cli_RemainLimit = c.Cli_Limit;
                    c.Cli_ClearLimitdate = XYEEncoding.strCodeHex(integerInputDay.Value.ToString());
                    c.Cli_ShouldMoney = XYEEncoding.strCodeHex("0");
                    c.Cli_GetMoney = XYEEncoding.strCodeHex(textBoxXAmout.Text.Trim());
                    c.Cli_PreMoney = XYEEncoding.strCodeHex(textBoxXAmout.Text.Trim());
                    c.Cli_Remark = XYEEncoding.strCodeHex(textBoxXRemark.Text);
                    c.Cli_Enable = 1;
                    try
                    {
                        bool result = cm.AddClientAndDiscount(c, d);
                        if (result)
                        {
                            MessageBox.Show("添加客户成功");
                            ClientForm cf = (ClientForm)this.Owner;
                            cf.Isflag = true;
                            Close();
                        }
                        else
                        {
                            MessageBox.Show("添加客户失败,请检查服务器连接并重新添加");
                            Close();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("更新失败,请检查错误:" + ex.Message);
                        Close();
                    }
                }
            }
        }

        private void buttonXCacel_Click(object sender, EventArgs e)
        {
            Close();
        }

        /// <summary>
        /// 只可输入数字和小数点
        /// </summary>
        private void keyPress(object sender, KeyPressEventArgs e)
        {
            if (!(((e.KeyChar >= '0') && (e.KeyChar <= '9')) || e.KeyChar <= 31))
            {
                if (e.KeyChar == '.')
                {
                    if (((TextBox)sender).Text.Trim().IndexOf('.') > -1)
                        e.Handled = true;
                }
                else
                    e.Handled = true;
            }
            else
            {
                if (e.KeyChar == '\b')
                {
                    e.Handled = false;
                }
            }
        }

        private void buttonXSelect_Click(object sender, EventArgs e)
        {

        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {

        }

        
    }
}
