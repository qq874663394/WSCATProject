using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;
using Model;
using HelperUtility;
using HelperUtility.Encrypt;

namespace WSCATProject.Base.Department
{
    public partial class InDepartment : Form
    {
        public InDepartment()
        {
            InitializeComponent();
        }
        public bool _update { get; set; }

        public Model.Department _Department { get; set; }

        RoleManager role = new RoleManager();
        DepartmentManager depm = new DepartmentManager();
        private void InDepartment_Load(object sender, EventArgs e)
        {
            //绑定角色下拉框
            DataTable dt = role.GetAllList().Tables[0];
            comboBoxEx1.DataSource = dt;
            comboBoxEx1.DisplayMember = "Role_Name";
            comboBoxEx1.ValueMember = "Role_Code";
            comboBoxEx1.SelectedIndex = 0;

            if (_update)
            {
                this.textBoxXName.Text = _Department.Dt_Name;
                this.comboBoxEx1.Text = _Department.Dt_RoleCode;
            }
        }
        //取消按钮
        private void buttonX1_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
        }
        //保存按钮
        private void buttonX2_Click(object sender, EventArgs e)
        {
            Model.Department dep = new Model.Department();
            try
            {
                if (_update == false)
                {
                    dep.Dt_Name = XYEEncoding.strCodeHex(this.textBoxXName.Text.Trim());
                    dep.Dt_RoleCode = comboBoxEx1.SelectedValue == null ? "" : XYEEncoding.strCodeHex(comboBoxEx1.SelectedValue.ToString());
                    dep.Dt_Code = XYEEncoding.strCodeHex(BuildCode.ModuleCode("DT"));
                    dep.Dt_Clear = 1;
                    int result = depm.InsDepartment(dep);
                    if (result == 1)
                    {
                        MessageBox.Show("部门添加成功！");
                    }
                    else
                    {
                        MessageBox.Show("部门保存失败！");
                    }
                }
                else
                {
                    dep.Dt_Name = this.textBoxXName.Text.Trim();
                    dep.Dt_RoleCode = comboBoxEx1.SelectedValue == null ? "" : comboBoxEx1.SelectedValue.ToString();
                    dep.Dt_Code = _Department.Dt_Code;
                    int r = depm.UpdateDepartment(dep);
                    if (r == 1)
                    {
                        MessageBox.Show("修改部门成功！");
                    }
                    else
                    {
                        MessageBox.Show("修改部门失败!");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("错误添加或者修改部门错误"+ex.Message);
            }
         
        }
        //保存并退出按钮
        private void buttonX3_Click(object sender, EventArgs e)
        {
            Model.Department dep = new Model.Department();
            try
            {
                if (_update == false)
                {
                    dep.Dt_Name = XYEEncoding.strCodeHex(this.textBoxXName.Text.Trim());
                    dep.Dt_RoleCode = comboBoxEx1.SelectedValue == null ? "" : XYEEncoding.strCodeHex(comboBoxEx1.SelectedValue.ToString());
                    dep.Dt_Code = XYEEncoding.strCodeHex(BuildCode.ModuleCode("DT"));
                    dep.Dt_Clear = 1;
                    int result = depm.InsDepartment(dep);
                    if (result == 1)
                    {
                        MessageBox.Show("部门添加成功！");
                        this.Close();
                        this.Dispose();
                    }
                    else
                    {
                        MessageBox.Show("部门保存失败！");
                    }
                }
                else
                {
                    dep.Dt_Name = this.textBoxXName.Text.Trim();
                    dep.Dt_RoleCode = comboBoxEx1.SelectedValue == null ? "" : comboBoxEx1.SelectedValue.ToString();
                    dep.Dt_Code = _Department.Dt_Code;
                    int r = depm.UpdateDepartment(dep);
                    if (r == 1)
                    {
                        MessageBox.Show("修改部门成功！");
                        this.Close();
                        this.Dispose();
                    }
                    else
                    {
                        MessageBox.Show("修改部门失败!");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("错误，添加或者修改错误"+ex.Message);
            }
     
        }
    }
}
