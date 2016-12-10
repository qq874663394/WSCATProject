using BLL;
using HelperUtility;
using HelperUtility.Encrypt;
using Model;
using System;
using System.Windows.Forms;

namespace WSCATProject.Base
{
    public partial class InsNodes : Form
    {
        public InsNodes()
        {
            InitializeComponent();
        }

        private readonly CityManager cm = new CityManager();

        public string city_code { get; set; }
        public City city { get; set; }

        private void form_save_Click(object sender, EventArgs e)
        {
            if(city == null)
            {
                ClientForm clientForm = (ClientForm)this.Owner;
                City city = new City()
                {
                    City_Name = XYEEncoding.strCodeHex(textBox1.Text.Trim()),
                    City_ParentId = XYEEncoding.strCodeHex(city_code),
                    City_Clear = 1,
                    City_Enable = 1,
                    City_Code = XYEEncoding.strCodeHex(BuildCode.ModuleCode("City"))
                };
                try
                {
                    int result = cm.Add(city);
                    if (result > 0)
                    {
                        clientForm.Isflag = true;
                        MessageBox.Show("地区名称：" + textBox1.Text + " \n添加成功");
                        Close();
                    }
                    else
                    {
                        clientForm.Isflag = false;
                        MessageBox.Show("添加失败,请重新添加");
                        Close();
                    }
                }
                catch(Exception ex)
                {
                    MessageBox.Show("新增地区资料错误,请检查服务器连接.错误信息:" + ex.Message);
                }
                
            }
            else
            {
                city.City_Name = textBox1.Text.Trim();
                try
                {
                    bool result = cm.UpdateByCode(city);
                    if (result)
                    {
                        ClientForm clientForm = (ClientForm)this.Owner;
                        clientForm.Isflag = true;
                        MessageBox.Show("地区名称：" + textBox1.Text + " \n修改成功");
                        Close();
                    }
                    else
                    {
                        ClientForm clientForm = (ClientForm)this.Owner;
                        clientForm.Isflag = false;
                        MessageBox.Show("修改失败,请重新修改");
                        Close();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("新增地区资料错误,请检查服务器连接.错误信息:" + ex.Message);
                }
            }
        }

        private void form_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void InsNodes_Load(object sender, EventArgs e)
        {
            if(city != null)
            {
                textBox1.Text = city.City_Name;
            }
        }
    }
}
