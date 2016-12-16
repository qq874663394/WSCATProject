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
using InterfaceLayer.Base;

namespace WSCATProject.Base.Department
{
    public partial class InDepartment : Form
    {
        public InDepartment()
        {
            InitializeComponent();
        }
        public bool _update { get; set; }

        public BaseDepartment _Department { get; set; }

        RoleManager role = new RoleManager();
        DepartmentInterface depm = new DepartmentInterface();
        private void InDepartment_Load(object sender, EventArgs e)
        {
            //绑定角色下拉框
            DataTable dt = role.GetAllList().Tables[0];
            comboBoxEx1.DataSource = dt;
            comboBoxEx1.DisplayMember = "Name";
            comboBoxEx1.ValueMember = "Code";
            comboBoxEx1.SelectedIndex = 0;

            if (_update)
            {
                this.textBoxXName.Text = _Department.name;
                this.comboBoxEx1.Text = _Department.roleCode;
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
            BaseDepartment dep = new BaseDepartment();
            try
            {
                if (_update == false)
                {
                    dep.name = XYEEncoding.strCodeHex(this.textBoxXName.Text.Trim());
                    dep.roleCode = comboBoxEx1.SelectedValue == null ? "" : XYEEncoding.strCodeHex(comboBoxEx1.SelectedValue.ToString());
                    dep.code = XYEEncoding.strCodeHex(BuildCode.ModuleCode("DT"));
                    dep.isClear = 1;
                    int result = depm.Add(dep);
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
                    dep.name = this.textBoxXName.Text.Trim();
                    dep.roleCode = comboBoxEx1.SelectedValue == null ? "" : comboBoxEx1.SelectedValue.ToString();
                    dep.code = _Department.code;
                    bool r = depm.Update(dep);
                    if (r)
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
            BaseDepartment dep = new Model.BaseDepartment();
            try
            {
                if (_update == false)
                {
                    dep.name = XYEEncoding.strCodeHex(this.textBoxXName.Text.Trim());
                    dep.roleCode = comboBoxEx1.SelectedValue == null ? "" : XYEEncoding.strCodeHex(comboBoxEx1.SelectedValue.ToString());
                    dep.code = XYEEncoding.strCodeHex(BuildCode.ModuleCode("DT"));
                    dep.isClear = 1;
                    int result = depm.Add(dep);
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
                    dep.name = this.textBoxXName.Text.Trim();
                    dep.roleCode = comboBoxEx1.SelectedValue == null ? "" : comboBoxEx1.SelectedValue.ToString();
                    dep.code = _Department.code;
                    bool r = depm.Update(dep);
                    if (r)
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
