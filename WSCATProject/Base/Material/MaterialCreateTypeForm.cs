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

using HelperUtility.Encrypt;
using HelperUtility;
using InterfaceLayer.Base;

namespace WSCATProject.Base
{
    public partial class MateCreateTypeForm : Form
    {
        public MateCreateTypeForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 父级CODE 
        /// </summary>
        public string matype_code { get; set; }

        /// <summary>
        /// 实体 若该实体为空 则为创建 否则为修改
        /// </summary>
        public BaseMaterialType materialType { get; set; }

        private void form_save_Click(object sender, EventArgs e)
        {
            if (materialType == null)
            {
                MaterialTypeInterface mtm = new MaterialTypeInterface();
                MaterialTypeForm clientForm = (MaterialTypeForm)this.Owner;
                BaseMaterialType materialType = new BaseMaterialType()
                {
                    code = BuildCode.ModuleCode("MT"),
                    name = textBox1.Text.Trim(),
                    parentId = matype_code,
                    isClear = 1,
                    isEnable = 1,
                    id = 0,
                    updateDate = DateTime.Now
                };
                try
                {
                    int result = mtm.Add(materialType);
                    if (result > 0)
                    {
                        clientForm.Isflag = true;
                        MessageBox.Show("产品类别：" + textBox1.Text + " \n添加成功");
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
                    MessageBox.Show("商品插入异常:" + ex.Message);
                    Close();
                }
            }
            else
            {
                MaterialTypeInterface mtm = new MaterialTypeInterface();
                try
                {
                    if (mtm.Update(materialType))
                    {
                        MessageBox.Show("更改成功!");
                        Close();
                    }
                    else
                    {
                        MessageBox.Show("更改失败,请检查服务器连接");
                        Close();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("更改错误,请检查服务器连接.异常:" + ex.Message);
                    Close();
                }
            }
        }

        private void form_exit_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
