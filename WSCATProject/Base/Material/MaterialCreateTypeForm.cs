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
        public MaterialType materialType { get; set; }

        private void form_save_Click(object sender, EventArgs e)
        {
            if(materialType == null)
            {
                MaterialTypeManager mtm = new MaterialTypeManager();
                MaterialTypeForm clientForm = (MaterialTypeForm)this.Owner;
                MaterialType materialType = new MaterialType()
                {
                    MT_Code = BuildCode.ModuleCode("MT"),
                    MT_Name = textBox1.Text.Trim(),
                    MT_ParentID = matype_code,
                    MT_Clear = 1,
                    MT_Enable = 1,
                    MT_ID = 0
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
                catch(Exception ex)
                {
                    MessageBox.Show("商品插入异常:" + ex.Message);
                    Close();
                }
            }
            else
            {
                MaterialTypeManager mtm = new MaterialTypeManager();
                try
                {
                    if (mtm.UpdateByCode(materialType))
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
