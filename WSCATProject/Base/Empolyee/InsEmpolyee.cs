using BLL;
using HelperUtility;
using HelperUtility.Encrypt;
using Model;
using System;
using System.Data;
using System.Windows.Forms;

namespace WSCATProject.Base
{
    public partial class InsEmpolyee : Form
    {
        EmpolyeeManager em = new EmpolyeeManager();
        DepartmentManager dm = new DepartmentManager();
        RoleManager role = new RoleManager();
        UserManager um = new UserManager();
        public string area;
        public InsEmpolyee()
        {
            InitializeComponent();
        }

        private void InsEmpolyee_Load(object sender, EventArgs e)
        {

            textBox2.Enabled = false;
            comboBox1.SelectedIndex = 0;
            textBox11.Text = DateTime.Now.ToString();
            comboBox1.DataSource = dm.SelDepartment();
            comboBox1.DisplayMember = "Dt_Name";
            comboBox1.ValueMember = "Dt_Code";
            //绑定角色下拉框
            DataTable dt = role.GetAllList().Tables[0];
            cbe_juese.DataSource = dt;
            cbe_juese.DisplayMember = "Role_Name";
            cbe_juese.ValueMember = "Role_Code";
            cbe_juese.SelectedIndex = 0;

            EmpolyeeForm empM = (EmpolyeeForm)Owner;
            try
            {
                switch (empM.StateType)
                {
                    case 0:
                        textBox2.Text = BuildCode.ModuleCode("EMP");
                        break;
                    case 1:
                        Model.Empolyee empolyee = em.SelEmpolyeeByCode(empM.id);

                        textBox1.Text = empolyee.Emp_Name;
                        textBox2.Text = empolyee.Emp_Code;
                        //获取选中的地址，绑定在地址的三个控件上面
                        string str = empolyee.Emp_Area;
                        string[] sArray = str.Split(new char[] { '/' });
                        tb_sheng.Text = sArray[0].ToString();
                        tb_shi.Text = sArray[1].ToString();
                        tb_qu.Text = sArray[2].ToString();
                        //
                        tb_pws.Text = empolyee.Emp_Password;
                        textBox3.Text = empolyee.Emp_CardCode;
                        textBox4.Text = empolyee.Emp_Phone;
                        textBox5.Text = empolyee.Emp_Card;
                        textBox6.Text = empolyee.Emp_Birthday.ToString();
                        textBox7.Text = empolyee.Emp_Email;
                        textBox8.Text = empolyee.Emp_School;
                        textBox9.Text = empolyee.Emp_Bank;
                        textBox10.Text = empolyee.Emp_OpenBank;
                        textBox11.Text = empolyee.Emp_Entry.ToString();
                        comboBox1.Text = XYEEncoding.strHexDecode(dm.SelDepartmentByCode(XYEEncoding.strCodeHex(empolyee.Emp_Depid)).Dt_Name);
                        //
                        cbe_juese.Text = XYEEncoding.strHexDecode(role.GetModel(XYEEncoding.strCodeHex(empolyee.Emp_UserRole)).Role_Name);
                        //
                        comboBox2.Text = empolyee.Emp_Education;
                        if (empolyee.Emp_Sex == "男")
                            radioButton1.Checked = true;
                        else
                            radioButton2.Checked = true;

                        if (empolyee.Emp_State == 0)
                        {
                            checkBox2.Checked = true;
                        }
                        if (empolyee.Emp_Enable == 0)
                        {
                            checkBox1.Checked = true;
                        }
                        break;
                    default:
                        MessageBox.Show("类型错误！");
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("加载数据失败,请检查服务器连接并尝试刷新.错误:" + ex.Message);

            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            EmpolyeeForm empM = (EmpolyeeForm)Owner;
            
            if (InsTextIsNull() == false)
            {
                return;
            }
            try
            {
                int result = InsEmpolyeeFun(empM.StateType);
                if (result > 0)
                {
                    empM.isflag = true;
                    if (checkBoxLogin.Checked)
                    {
                        //保存user表
                        User u = new User();
                        u.User_CardCode = "";
                        u.User_code = BuildCode.ModuleCode("US");
                        u.User_Manager = 0;
                        u.User_Name = textBox1.Text.Trim();
                        u.User_Password = "654321";
                        u.User_Role = cbe_juese.SelectedValue.ToString();
                        u.User_zhiwen = "";
                        int uresult = um.Add(u);
                        if(uresult < 1)
                        {
                            MessageBox.Show("在给该成员分配登录权限时失败,请尝试使用新增登录用户功能添加");
                        }
                    }
                    MessageBox.Show("保存成功");
                    Close();
                    Dispose();
                }
                else
                {
                    empM.isflag = false;
                    MessageBox.Show("保存失败");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("保存数据失败,请检查服务器连接并尝试重新保存.错误:" + ex.Message);

            }
        }

        private int InsEmpolyeeFun(int state)
        {
            Model.Empolyee emp = new Model.Empolyee();
            area = tb_sheng.Text + "/" + tb_shi.Text + "/" + tb_qu.Text;//保存地区
            emp.Emp_Name = textBox1.Text.Trim();
            emp.Emp_Code = textBox2.Text.Trim();

            emp.Emp_Password = tb_pws.Text.Trim();

            emp.Emp_Area = area;

            emp.Emp_CardCode = textBox3.Text.Trim();
            emp.Emp_Phone = textBox4.Text.Trim();
            emp.Emp_Card = textBox5.Text.Trim();
            emp.Emp_Birthday = Convert.ToDateTime(textBox6.Text);//textBox6
            emp.Emp_Email = textBox7.Text.Trim();
            emp.Emp_School = textBox8.Text.Trim();
            emp.Emp_Bank = textBox9.Text.Trim();
            emp.Emp_OpenBank = textBox10.Text.Trim();
            emp.Emp_Entry = Convert.ToDateTime(textBox11.Text); //textBox11
            emp.Emp_Depid = comboBox1.SelectedValue == null ? "" : comboBox1.SelectedValue.ToString();

            emp.Emp_UserRole = cbe_juese.SelectedValue == null ? "" : cbe_juese.SelectedValue.ToString();

            emp.Emp_Education = comboBox2.Text;
            emp.Emp_Sex = radioButton1.Checked == true ? "男" : "女";
            emp.Emp_Enable = checkBox1.Checked == true ? 0 : 1;
            emp.Emp_State = checkBox2.Checked == true ? 0 : 1;
            emp.Emp_Clear = 1;
            if (state == 0)
            {
                return em.InsEmpolyee(emp);
            }
            else
            {
                return em.UpdateEmpolyee(emp);
            }
        }

        #region 非空验证
        /// <summary>
        /// 非空验证
        /// </summary>
        /// <returns></returns>
        private bool InsTextIsNull()
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                MessageBox.Show("员工姓名不能为空！");
                return false;
            }
            if (string.IsNullOrWhiteSpace(textBox2.Text))
            {
                MessageBox.Show("员工工号不能为空！");
                return false;
            }
            if (string.IsNullOrWhiteSpace(textBox6.Text))
            {
                MessageBox.Show("生日不能为空！");
                return false;
            }
            if (comboBox1.SelectedText == "请选择")
            {
                MessageBox.Show("最高学历不能为空！");
                return false;
            }
            return true;
        }
        #endregion

        #region 退出
        /// <summary>
        /// 退出
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button3_Click_1(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
        }
        #endregion


    }
}
