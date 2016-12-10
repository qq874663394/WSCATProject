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
using BLL;
using HelperUtility;

namespace WSCATProject.Base
{
    public partial class RoleCreateForm : Form
    {
        public delegate void delegateHandle(string nodeText, string code);
        public event delegateHandle refresh;

        public RoleCreateForm()
        {
            InitializeComponent();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            RoleManager rm = new RoleManager();
            PermissionManager pm = new PermissionManager();
            Role role = new Role();
            string percode = BuildCode.ModuleCode("PE");
            string rolecode = BuildCode.ModuleCode("RO");
            // 新增一个角色信息
            role.Role_Code = rolecode;
            role.Role_Modules = "";
            role.Role_Name = textBoxName.Text.Trim();
            int roleAddResult = 0;

            try
            {
                roleAddResult = rm.Add(role);
                
            }
            catch(Exception ex)
            {
                MessageBox.Show("增加角色失败,请检查服务器连接.错误信息:" + ex.Message);
            }

            if (roleAddResult == 0)
            {
                MessageBox.Show("未能成功新增角色数据,请重试");
                return;
            }

            try
            {
                List<Permission> permList = new List<Permission>();
                string[] nameList =
                    {   "用户资料", "权限分配", "仓库资料", "货品资料",
                            "供应商资料", "物料信息","仓库系统","销售系统",
                            "售后系统","采购系统","财务系统","考勤系统" };
                //填充权限实体列表
                initPermission(permList, rolecode, nameList);
                int result = pm.AddBatch(permList);
                if (result > 0)
                {
                    MessageBox.Show("新增用户角色成功,该角色所有模块默认不可读写.");
                }
                //触发事件新增节点
                refresh?.Invoke(textBoxName.Text, rolecode);
            }
            catch(Exception ex)
            {
                rm.Delete(roleAddResult);
                MessageBox.Show("分配角色权限,请检查服务器连接.错误信息:" + ex.Message);
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
        
        /// <summary>
        /// 根据权限名称来新增名称数量个权限信息,绑定到该角色上.默认没有有任何权限
        /// </summary>
        /// <param name="permList"></param>
        /// <param name="roleCode"></param>
        /// <param name="nameList"></param>
        private void initPermission(List<Permission> permList, string roleCode, string[] nameList)
        {
            for (int i = 0; i < nameList.Count(); i++)
            {
                Permission permission = new Permission();
                permission.Per_Clear = 1;
                permission.Per_Code = roleCode;
                permission.Per_ModuleName = nameList[i];
                permission.Per_ReadState = 0;
                permission.Per_RoleCode = roleCode;
                switch(permission.Per_ModuleName)
                {
                    case "用户资料":
                        permission.Per_Type = "用户模块";
                        break;
                    case "权限分配":
                        permission.Per_Type = "用户模块";
                        break;
                    case "仓库资料":
                        permission.Per_Type = "基础资料";
                        break;
                    case "货品资料":
                        permission.Per_Type = "基础资料";
                        break;
                    case "供应商资料":
                        permission.Per_Type = "基础资料";
                        break;
                    case "物料信息":
                        permission.Per_Type = "基础资料";
                        break;
                    case "仓库系统":
                        permission.Per_Type = "仓库系统";
                        break;
                    case "销售系统":
                        permission.Per_Type = "销售系统";
                        break;
                    case "售后系统":
                        permission.Per_Type = "售后系统";
                        break;
                    case "采购系统":
                        permission.Per_Type = "采购系统";
                        break;
                    case "财务系统":
                        permission.Per_Type = "财务系统";
                        break;
                    case "考勤系统":
                        permission.Per_Type = "考勤系统";
                        break;
                }
                permission.Per_Type = "";
                permission.Per_AuditState = 0;
                permission.Per_WriteState = 0;
                permList.Add(permission);
            }
        }
    }
}
