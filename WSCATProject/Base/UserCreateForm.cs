using System;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using BLL;
using Model;
using HelperUtility;

namespace WSCATProject.Base
{
    public partial class UserCreateForm : RibbonForm
    {
        public UserCreateForm()
        {
            InitializeComponent();
        }

        private void buttonXSave_Click(object sender, EventArgs e)
        {
            string userName = textBoxXName.Text;
            string password = textBoxXPassword.Text;
            string userRole = comboboxXRole.Text;
            //检查是否为空
            if (string.IsNullOrWhiteSpace(userName))
            {
                labelXNameWarning.Visible = true;
                return;
            }
            if(string.IsNullOrWhiteSpace(password))
            {
                labelXPwWarning.Visible = true;
                return;
            }
            if(string.IsNullOrWhiteSpace(labelXPwAWarning.Text))
            {
                labelXPwAWarning.Visible = true;
                return;
            }
            if(string.IsNullOrWhiteSpace(userRole))
            {
                labelXRoleWarning.Visible = true;
                return;
            }
            labelXNameWarning.Visible = false;
            labelXPwWarning.Visible = false;
            labelXPwAWarning.Visible = false;
            labelXRoleWarning.Visible = false;

            //实体赋值,创建用户
            User u = new User();
            u.User_code = BuildCode.ModuleCode("US");
            u.User_CardCode = "";
            u.User_Manager = 0;
            u.User_Name = userName;
            u.User_Password = password;
            u.User_Role = userRole;
            u.User_zhiwen = "";

            UserManager um = new UserManager();

            try
            {
                int result = um.Add(u);
                if (result > 0)
                {
                    MessageBox.Show("增加用户 "+userName+" 成功");
                    textBoxXName.Text = "";
                    textBoxXPassword.Text = "";
                    textBoxXPasswordAgain.Text = "";
                    comboboxXRole.SelectedIndex = -1;
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("新增管理员异常,请检查服务器连接.异常:" + ex.Message);
            }
        }
    }
}
