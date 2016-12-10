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
using HelperUtility.Encrypt;

namespace WSCATProject.Base
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void buttonXLogin_Click(object sender, EventArgs e)
        {
            User u = new User();
            UserManager um = new UserManager();
            PermissionManager pm = new PermissionManager();
            string name = textBoxXName.Text.Trim();
            string password = textBoxXPassword.Text.Trim();
            if (string.IsNullOrWhiteSpace(name))
            {
                labelName.Visible = true;
                labelNull.Text = "请输入用户名";
                labelNull.Visible = true;
            }
            else if (string.IsNullOrWhiteSpace(password))
            {
                labelPW.Visible = true;
                labelNull.Text = "请输入密码";
                labelNull.Visible = true;
            }
            else
            {
                if(!um.Exists(name))
                {
                    labelName.Visible = false;
                    labelPW.Visible = false;
                    labelNull.Text = "用户名不存在";
                    labelNull.Visible = true;
                    return;

                }
                DataTable user = um.GetUserAndRoleModel(name, password);
                if (user.Rows.Count > 0)
                {
                    LoginInfomation information = LoginInfomation.getInstance();
                    information.UserName = user.Rows[0]["User_Name"].ToString();
                    information.UserRole = user.Rows[0]["Role_Name"].ToString();
                    information.UserCode = user.Rows[0]["User_Code"].ToString();
                    //根据角色里的权限编码查询所拥有的权限信息 
                    DataSet permission = pm.GetList("Per_Code = '" + 
                        XYEEncoding.strCodeHex(user.Rows[0]["Role_Modules"].ToString()) + "'");
                    getPermissionList(permission);
                    Close();
                }
                else
                {
                    labelNull.Text = "密码不正确";
                    labelNull.Visible = true;
                }
            }
        }

        private void buttonXClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void textBoxXPassword_TextChanged(object sender, EventArgs e)
        {
            labelNull.Visible = false;
        }

        /// <summary>
        /// 获取所有的权限列表并存储
        /// </summary>
        /// <param name="ds"></param>
        private void getPermissionList(DataSet ds)
        {
            LoginInfomation information = LoginInfomation.getInstance();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                if((int)dr["Per_ReadState"] == 1)
                {
                    information.ReadPermission.Add(dr["Per_ModuleName"].ToString());
                }
                if((int)dr["Per_WriteState"] == 1)
                {
                    information.WritePermission.Add(dr["Per_ModuleName"].ToString());
                }
                if((int)dr["Per_AuditState"] == 1)
                {
                    information.AuditPermission.Add(dr["Per_ModuleName"].ToString());
                }
            }
        }
    }
}
