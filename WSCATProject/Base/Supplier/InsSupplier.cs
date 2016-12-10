using BLL;
using DevComponents.AdvTree;
using DevComponents.DotNetBar.Controls;
using HelperUtility;
using HelperUtility.Encrypt;
using Model;
using System;
using System.Data;
using System.Windows.Forms;
using WSCATProject.Base;

namespace WSCATProject
{
    public partial class InsSupplier : Form
    {
        SupplierManager sm = new SupplierManager();
        ProfessionManager pm = new ProfessionManager();
        CityManager cm = new CityManager();
        public InsSupplier()
        {
            InitializeComponent();
        }

        #region 加载事件
        /// <summary>
        /// 加载事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void InsSupplier_Load(object sender, EventArgs e)
        {
            AddTree("", null, "", comboTree1);
            comboTree1.AdvTree.NodeDoubleClick += AdvTree_NodeDoubleClick;
            SupplierForm supplierMaterial = (SupplierForm)this.Owner;
            switch (supplierMaterial.stats)
            {
                case 0:
                    su_code.Text = BuildCode.ModuleCode("Su");
                    break;
                case 1:
                    BindControl();
                    break;
                default:
                    MessageBox.Show("类型错误！");
                    break;
            }
            //if (supplierMaterial.stats == 0)
            //{
            //    su_code.Text = BuildCode.ModuleCode("Supplier");
            //    //    int result = InsSupplierFun();
            //    //    if (result > 0)
            //    //    {
            //    //        MessageBox.Show(string.Format("编号：{0},新增成功", su_code.ToString()));
            //    //        supplierMaterial.isflag = true;
            //    //    }
            //    //    else
            //    //    {
            //    //        MessageBox.Show("未知错误，添加失败");
            //    //        supplierMaterial.isflag = false;
            //    //    }
            //}
            //if (supplierMaterial.stats == 1)
            //{
            //    BindControl();
            //}
        }
        #endregion

        #region 赋值函数
        private void BindControl()
        {
            SupplierForm supplierMaterial = (SupplierForm)this.Owner;
            Supplier supplier = sm.SelUpdateSupplierByCode(supplierMaterial.code);
            su_name.Text = supplier.Su_Name;
            su_code.Text = supplierMaterial.code;
            su_phone.Text = supplier.Su_Phone;
            su_address.Text = supplier.Su_Address;
            su_fax.Text = supplier.Su_fax;
            su_email.Text = supplier.Su_Email;
            su_bankaccounts.Text = supplier.Su_Bankaccounts;
            su_bank.Text = supplier.Su_Bank;
            su_credit.RatingValue = supplier.Su_Credit;
            su_money.Text = supplier.Su_Money;
            su_surplus.Text = supplier.Su_Surplus;
            su_Reckoning.Text = supplier.Su_Reckoning;
            su_empname.Text = supplier.Su_Empname;
            su_empPhone.Text = supplier.Su_EmpPhone;
            su_remark.Text = supplier.Su_Remark;
            su_enable.Checked = supplier.Su_Enable == 1 ? false : true;
        }
        #endregion

        #region 非空验证
        /// <summary>
        /// 非空验证
        /// </summary>
        /// <returns></returns>
        private bool InsTextIsNull()
        {
            if (string.IsNullOrWhiteSpace(su_name.Text))
            {
                MessageBox.Show("单位名称不能为空！");
                return false;
            }
            if (string.IsNullOrWhiteSpace(su_code.Text))
            {
                MessageBox.Show("单位编码不能为空！");
                return false;
            }
            return true;
        }
        #endregion

        #region 新增函数
        /// <summary>
        /// 新增函数
        /// </summary>
        /// <returns></returns>
        private int InsSupplierFun(int state)
        {
            Supplier supplier = new Supplier();
            supplier.Su_Code = su_code.Text.Trim();
            supplier.Su_Name = su_name.Text.Trim();
            supplier.Su_Phone = su_phone.Text.Trim();
            supplier.Su_Address = su_address.Text.Trim();
            supplier.Su_fax = su_fax.Text.Trim();
            supplier.Su_Email = su_email.Text.Trim();
            supplier.Su_Bankaccounts = su_bankaccounts.Text.Trim();
            supplier.Su_Bank = su_bank.Text.Trim();
            supplier.Su_Money = su_money.Text.Trim();
            supplier.Su_Surplus = su_surplus.Text.Trim();
            supplier.Su_Reckoning = su_Reckoning.Text.Trim();
            supplier.Su_Empname = su_empname.Text.Trim();
            supplier.Su_EmpPhone = su_empPhone.Text.Trim();
            supplier.Su_Remark = su_remark.Text.Trim();
            supplier.Su_Clear = 1;
            supplier.Su_Credit = su_credit.RatingValue.ToString();
            supplier.Su_Enable = su_enable.Checked ? 0 : 1;
            supplier.Su_Area = comboTree1.SelectedNode == null ? "所有地区" : comboTree1.SelectedNode.FullPath.Replace(";", "/");
            supplier.Su_ProCode = "0";
            if (state == 0)
            {
                return sm.InsSupplier(supplier);
            }
            else
            {
                return sm.UpdateSupplier(supplier);
            }
        }
        #endregion

        #region 保存
        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void saveIns_Click(object sender, EventArgs e)
        {
            SupplierForm supplierMaterial = (SupplierForm)Owner;
            int result = 0;
            if (InsTextIsNull() == false)
            {
                return;
            }
            try
            {
                result = InsSupplierFun(supplierMaterial.stats);
                if (result > 0)
                {
                    MessageBox.Show("保存成功！");
                    supplierMaterial.isflag = true;
                    Close();
                    Dispose();
                }
                else
                {
                    MessageBox.Show("未知原因，保存失败！");
                    supplierMaterial.isflag = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("保存失败,请检查服务器连接并尝试重新保存.错误:" + ex.Message);
            }
        }
        #endregion

        #region 退出事件
        /// <summary>
        /// 退出事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormExit_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
        }
        #endregion

        #region 递归添加树的节点
        /// <summary>
        /// 递归添加树的节点
        /// </summary>
        /// <param name="ParentID">父级ID：默认为空</param>
        /// <param name="pNode">父级节点：默认为null，可选</param>
        /// <param name="table">表名：默认为City，可选参数：P</param>
        /// <param name="ControlName">控件名：必选</param>
        private void AddTree(string ParentID, Node pNode, string table, ComboTree ControlName)
        {
            if (ParentID == "")
            {
                ParentID = "D4";
            }
            string ParentId = "City_ParentId";
            string Code = "City_Code";
            string Name = "City_Name";
            try
            {
                DataTable dt = cm.SelCityTable();
                if (table == "P")
                {
                    ParentId = "ST_ParentId";
                    Code = "ST_Code";
                    Name = "ST_Name";
                    dt = pm.SelProfession();
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
                        ControlName.Nodes.Add(node);
                        AddTree(Row[Code].ToString(), node, table, ControlName);
                        //展开第一级节点
                        node.Expand();
                    }
                    else
                    {
                        //添加当前节点的子节点                  
                        node.Text = XYEEncoding.strHexDecode(Row[Name].ToString());
                        node.Tag = XYEEncoding.strHexDecode(Row[Code].ToString());
                        pNode.Nodes.Add(node);
                        AddTree(Row[Code].ToString(), node, table, ControlName);     //再次递归 
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("加载数据失败,请检查服务器连接并尝试刷新.错误:" + ex.Message);
            }
        }
        #endregion

        #region 双击收缩节点
        /// <summary>
        /// 双击收缩节点
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AdvTree_NodeDoubleClick(object sender, TreeNodeMouseEventArgs e)
        {
            comboTree1.IsPopupOpen = false;
        }
        #endregion
    }
}
