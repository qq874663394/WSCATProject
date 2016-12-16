using DevComponents.AdvTree;
using DevComponents.DotNetBar.Controls;
using HelperUtility;
using HelperUtility.Encrypt;
using InterfaceLayer.Base;
using Model;
using System;
using System.Data;
using System.Windows.Forms;
using WSCATProject.Base;

namespace WSCATProject
{
    public partial class InsSupplier : Form
    {
        CodingHelper ch = new CodingHelper();
        SupplierInterface sm = new SupplierInterface();
        ProfessionInterface pm = new ProfessionInterface();
        AreaInterface cm = new AreaInterface();
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
            //    su_code.Text = BuildCode.ModuleCode("su");
            //    int result = InsSupplierFun();
            //    if (result > 0)
            //    {
            //        MessageBox.Show(string.Format("编号：{0},新增成功", su_code.ToString()));
            //        supplierMaterial.isflag = true;
            //    }
            //    else
            //    {
            //        MessageBox.Show("未知错误，添加失败");
            //        supplierMaterial.isflag = false;
            //    }
            //}
            if (supplierMaterial.stats == 1)
            {
                BindControl();
            }
        }
        #endregion

        #region 赋值函数
        private void BindControl()
        {
            SupplierForm supplierMaterial = (SupplierForm)this.Owner;
            DataTable supplier = ch.DataTableReCoding(sm.GetList(4, XYEEncoding.strCodeHex(supplierMaterial.code), false, false));
            su_name.Text = supplier.Rows[0]["name"].ToString();
            su_code.Text = supplierMaterial.code;
            su_phone.Text = supplier.Rows[0]["phone"].ToString();//.Su_Phone;
            su_address.Text = supplier.Rows[0]["address"].ToString();
            su_fax.Text = supplier.Rows[0]["fax"].ToString();
            su_email.Text = supplier.Rows[0]["email"].ToString();
            su_bankaccounts.Text = supplier.Rows[0]["bankCard"].ToString();
            su_bank.Text = supplier.Rows[0]["openBank"].ToString();
            su_credit.RatingValue = supplier.Rows[0]["creditRank"].ToString();
            su_money.Text = supplier.Rows[0]["availableBalance"].ToString();
            su_surplus.Text = supplier.Rows[0]["balance"].ToString();
            su_Reckoning.Text = supplier.Rows[0]["statementDate"].ToString();
            su_empname.Text = supplier.Rows[0]["linkMan"].ToString();
            su_empPhone.Text = supplier.Rows[0]["mobilePhone"].ToString();
            su_remark.Text = supplier.Rows[0]["remark"].ToString();
            su_enable.Checked = Convert.ToInt32(supplier.Rows[0]["isEnable"]) == 1 ? false : true;
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
            BaseSupplier supplier = new BaseSupplier();
            supplier.code = XYEEncoding.strCodeHex(su_code.Text.Trim());
            supplier.name = XYEEncoding.strCodeHex(su_name.Text.Trim());
            supplier.phone = XYEEncoding.strCodeHex(su_phone.Text.Trim());
            supplier.address = XYEEncoding.strCodeHex(su_address.Text.Trim());
            supplier.fax = XYEEncoding.strCodeHex(su_fax.Text.Trim());
            supplier.email = XYEEncoding.strCodeHex(su_email.Text.Trim());
            supplier.bankCard = XYEEncoding.strCodeHex(su_bankaccounts.Text.Trim());
            supplier.openBank = XYEEncoding.strCodeHex(su_bank.Text.Trim());
            supplier.availableBalance = su_money.Text.Trim() == "" ? 0 : Convert.ToDecimal(su_money.Text.Trim());
            supplier.balance = su_surplus.Text.Trim() == "" ? 0 : Convert.ToDecimal(su_surplus.Text.Trim());
            supplier.statementDate = su_Reckoning.Text.Trim() == "" ? Convert.ToDateTime("2000-01-01") : Convert.ToDateTime(su_Reckoning.Text.Trim());
            supplier.linkMan = XYEEncoding.strCodeHex(su_empname.Text.Trim());
            supplier.mobilePhone = XYEEncoding.strCodeHex(su_empPhone.Text.Trim());
            supplier.remark = XYEEncoding.strCodeHex(su_remark.Text.Trim());
            supplier.isClear = 1;
            supplier.creditRank = Convert.ToInt32(su_credit.RatingValue);
            supplier.isEnable = su_enable.Checked ? 0 : 1;
            supplier.cityName = comboTree1.SelectedNode == null ? XYEEncoding.strCodeHex("所有地区") : XYEEncoding.strCodeHex(comboTree1.SelectedNode.FullPath.Replace(";", "/"));
            supplier.industryCode = "0";
            if (state == 0)
            {
                return sm.Add(supplier);
            }
            else
            {
                return sm.Update(supplier);
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
            string ParentId = "parentId";
            string Code = "code";
            string Name = "name";
            try
            {
                DataTable dt = cm.GetList(999, "", false, false);
                DataView dvTree = new DataView(dt);
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
                    Node node = new Node();
                    if (pNode == null)
                    {
                        //添加根节点    
                        node.Text = Row[Name].ToString();
                        node.Tag = Row[Code].ToString();
                        ControlName.Nodes.Add(node);
                        AddTree(Row[Code].ToString(), node, table, ControlName);
                        //展开第一级节点
                        node.Expand();
                    }
                    else
                    {
                        //添加当前节点的子节点                  
                        node.Text = Row[Name].ToString();
                        node.Tag = Row[Code].ToString();
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
