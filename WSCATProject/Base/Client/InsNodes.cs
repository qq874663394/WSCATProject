using HelperUtility;
using HelperUtility.Encrypt;
using InterfaceLayer.Base;
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

        private readonly AreaInterface cm = new AreaInterface();

        public string city_code { get; set; }
        public BaseArea city { get; set; }

        private void form_save_Click(object sender, EventArgs e)
        {
            if (city == null)
            {
                ClientForm clientForm = (ClientForm)this.Owner;
                BaseArea city = new BaseArea()
                {
                    name = XYEEncoding.strCodeHex(textBox1.Text.Trim()),
                    parentId = XYEEncoding.strCodeHex(city_code),
                    isClear = 1,
                    isEnable = 1,
                    code = XYEEncoding.strCodeHex(BuildCode.ModuleCode("area")),
                    updateDate = DateTime.Now
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
                catch (Exception ex)
                {
                    MessageBox.Show("新增地区资料错误,请检查服务器连接.错误信息:" + ex.Message);
                }

            }
            else
            {
                city.name = textBox1.Text.Trim();
                try
                {
                    int result = cm.Update(city);
                    if (result>0)
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
            if (city != null)
            {
                textBox1.Text = city.name;
            }
        }
    }
}
