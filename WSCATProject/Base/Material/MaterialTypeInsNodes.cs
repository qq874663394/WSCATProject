using System;
using System.Windows.Forms;
using Model;
using HelperUtility;
using WSCATProject.Base;
using InterfaceLayer.Base;

namespace WSCATProject.Base
{
    public partial class MaterialTypeInsNodes : Form
    {
        public MaterialTypeInsNodes()
        {
            InitializeComponent();
        }

        private readonly AreaInterface mtm = new AreaInterface();
        
        public BaseArea _MaterialType { get; set; }
        public string _MType_Code { get; set; }

        private void form_save_Click(object sender, EventArgs e)
        {
            if (_MaterialType == null)
            {

                BaseArea materialType = new BaseArea()
                {
                    code = BuildCode.ModuleCode("mt"),
                    name = textBox1.Text.Trim(),
                    parentId = _MType_Code,
                    isClear = 1,
                    isEnable = 1,
                    updateDate = DateTime.Now
                };
                try
                {
                    int result = mtm.Add(materialType);
                    MaterialForm materialForm = (MaterialForm)this.Owner;
                    if (result > 0)
                    {
                        materialForm.Isflag = true;
                        MessageBox.Show("地区名称：" + textBox1.Text + " \n添加成功");
                        Close();
                    }
                    else
                    {
                        materialForm.Isflag = false;
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
                _MaterialType.name = textBox1.Text.Trim();
                try
                {
                    int result = mtm.Update(_MaterialType);
                    if (result>0)
                    {
                        MaterialForm materialForm = (MaterialForm)this.Owner;
                        materialForm.Isflag = true;
                        MessageBox.Show("地区名称：" + textBox1.Text + " \n修改成功");
                        Close();
                    }
                    else
                    {
                        MaterialForm materialForm = (MaterialForm)this.Owner;
                        materialForm.Isflag = false;
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
            Close();
        }

        private void MaterialTypeInsNodes_Load(object sender, EventArgs e)
        {
            if (_MaterialType != null)
            {
                textBox1.Text = _MaterialType.name;
            }
        }
    }
}
