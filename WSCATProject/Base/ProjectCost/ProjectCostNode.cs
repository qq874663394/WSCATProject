using BLL;
using HelperUtility;
using Model;
using System;
using System.Windows.Forms;

namespace WSCATProject.Base
{
    public partial class ProjectCostNode : MaterialNodes
    {
        ProjectCostManager micm = new ProjectCostManager();
        public ProjectCostNode()
        {
            InitializeComponent();
        }
        private void ProjectCostNode_Load(object sender, EventArgs e)
        {
            if (state == 0)
            {
                label1.Text = "请输入同级名称：";
                Text = "请输入同级节点...";
                return;
            }
            if (state == 1)
            {
                label1.Text = "请输入下级名称：";
                Text = "请输入下级节点...";
                return;
            }
            if (state == 2)
            {
                label1.Text = "请输入修改后的名称：";
                Text = "请输入节点...";
                textBox1.Text = txtName;
                return;
            }
        }
        protected override void form_save_Click(object sender, EventArgs e)
        {
            if (InsTextIsNull() == false)
            {
                return;
            }
            ProjectCost pic = null;
            ProjectCostType pict = (ProjectCostType)Owner;
            int result = 0;
            switch (state)
            {
                case 0:
                    pic = new ProjectCost()
                    {
                        PC_Name = textBox1.Text.Trim(),
                        PC_Clear = 1,
                        PC_Enable = 1,
                        PC_Code = BuildCode.ModuleCode("PCN"),
                        PC_ParentId = code
                    };
                    try
                    {
                        result = micm.InsProjectCost(pic);
                        if (result > 0)
                        {
                            MessageBox.Show("保存成功!");
                            pict.isflag = true;
                            Close();
                            Dispose();
                            return;
                        }
                        else
                        {
                            MessageBox.Show("保存失败!");
                            pict.isflag = false;
                            return;
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("保存失败,请检查服务器连接并尝试重新保存.错误:" + ex.Message);
                    }
                    break;
                case 1:
                    pic = new ProjectCost()
                    {
                        PC_Name = textBox1.Text.Trim(),
                        PC_Clear = 1,
                        PC_Enable = 1,
                        PC_Code = BuildCode.ModuleCode("PCN"),
                        PC_ParentId = code
                    };
                    try
                    {
                        result = micm.InsProjectCost(pic);
                        if (result > 0)
                        {
                            MessageBox.Show("保存成功!");
                            pict.isflag = true;
                            Close();
                            Dispose();
                            return;
                        }
                        else
                        {
                            MessageBox.Show("保存失败!");
                            pict.isflag = false;
                            return;
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("保存失败,请检查服务器连接并尝试重新保存.错误:" + ex.Message);
                    }
                    break;
                case 2:
                    try
                    {
                        result = micm.UpdateNameProjectCost(textBox1.Text, code, txtName);
                        if (result > 0)
                        {
                            MessageBox.Show("保存成功!");
                            pict.isflag = true;
                            Close();
                            Dispose();
                            return;
                        }
                        else
                        {
                            MessageBox.Show("保存失败!");
                            pict.isflag = false;
                            return;
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("保存失败,请检查服务器连接并尝试重新保存.错误:" + ex.Message);
                    }
                    break;
                default:
                    MessageBox.Show("选择错误!");
                    break;
            }
        }
    }
}