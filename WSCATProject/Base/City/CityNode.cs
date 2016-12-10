using BLL;
using HelperUtility;
using Model;
using System;
using System.Windows.Forms;

namespace WSCATProject.Base
{
    public partial class CityNode : MaterialNodes
    {
        CityManager cm = new CityManager();
        public CityNode()
        {
            InitializeComponent();
        }

        private void CityNode_Load(object sender, EventArgs e)
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

        private void form_save_Click_1(object sender, EventArgs e)
        {
            if (InsTextIsNull() == false)
            {
                return;
            }
            City city = null;
            CityType ct = (CityType)Owner;
            try
            {
                switch (state)
                {
                    case 0:
                        city = new City()
                        {
                            City_Name = textBox1.Text.Trim(),
                            City_Clear = 1,
                            City_Enable = 1,
                            City_Code = BuildCode.ModuleCode("CN"),
                            City_ParentId = code
                        };
                        int result = cm.InsCity(city);
                        if (result > 0)
                        {
                            MessageBox.Show("保存成功!");
                            ct.isflag = true;
                            Close();
                            Dispose();
                            return;
                        }
                        else
                        {
                            MessageBox.Show("保存失败!");
                            ct.isflag = false;
                            return;
                        }
                    case 1:
                        city = new City()
                        {
                            City_Name = textBox1.Text.Trim(),
                            City_Clear = 1,
                            City_Enable = 1,
                            City_Code = BuildCode.ModuleCode("CN"),
                            City_ParentId = code
                        };
                        result = cm.InsCity(city);
                        if (result > 0)
                        {
                            MessageBox.Show("保存成功!");
                            ct.isflag = true;
                            Close();
                            Dispose();
                            return;
                        }
                        else
                        {
                            MessageBox.Show("保存失败");
                            ct.isflag = false;
                            return;
                        }
                    case 2:
                        result = cm.UpdateNameCity(textBox1.Text, code, txtName);
                        if (result > 0)
                        {
                            MessageBox.Show("保存成功!");
                            ct.isflag = true;
                            Close();
                            Dispose();
                            return;
                        }
                        else
                        {
                            MessageBox.Show("保存失败!");
                            ct.isflag = false;
                            return;
                        }
                    default:
                        MessageBox.Show("选择错误!");
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("保存失败,请检查服务器连接并尝试保存.错误:" + ex.Message);
            }
        }
    }
}
