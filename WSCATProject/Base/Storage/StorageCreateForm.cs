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
using BLL;
using HelperUtility;

namespace WSCATProject.Base
{
    public partial class StorageCreateForm : Form
    {

        public StorageCreateForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 是否为更新操作
        /// </summary>
        public bool _update { get; set; }
        /// <summary>
        /// 传递过来的实体 
        /// </summary>
        public Storage _storage { get; set; }

        private void StorageCreateForm_Load(object sender, EventArgs e)
        {
            if (_update)
            {
                textBoxXAddress.Text = _storage.St_Address;
                textBoxXMan.Text = _storage.St_EmpName;
                checkBoxXEnable.Checked = _storage.St_Enable == 0 ? true : false;
                textBoxXName.Text = _storage.St_Name;
                textBoxXRemark.Text = _storage.St_Remark;
                textBoxXPhone.Text = _storage.St_Phone;
            }
        }

        //保存 
        private void buttonX2_Click(object sender, EventArgs e)
        {
            if(!_update)
            {
                if (string.IsNullOrWhiteSpace(textBoxXName.Text))
                {
                    MessageBox.Show("仓库名称不可为空,请检查.");
                    return;
                }
                
                StorageManager sm = new StorageManager();

                try
                {
                    //获取实体,增加该实体数据
                    int result = sm.Add(fillStorage());
                    if (result > 0)
                    {
                        MessageBox.Show("新增仓库信息成功!");
                        StorageForm sf = (StorageForm)Owner;
                        //绑定
                        sf.DataGridViewRowsAdd(0, "", textBoxXName.Text,
                            textBoxXMan.Text,
                            textBoxXPhone.Text,
                            textBoxXAddress.Text,
                            checkBoxXEnable.Checked ? 0 : 1,
                            1,
                            textBoxXRemark.Text,
                            "",
                            "");
                        
                    }
                    else
                    {
                        MessageBox.Show("新增仓库信息失败,请尝试重新增加");
                        Close();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("查询异常,请检查服务器连接.错误:" + ex.Message);
                }
            }
            else
            {
                if(!string.IsNullOrWhiteSpace(textBoxXName.Text))
                {
                    StorageManager sm = new StorageManager();

                    try
                    {
                        //获取实体,增加该实体数据
                        bool result = sm.UpdateByCode(fillStorage());
                        if (result)
                        {
                            MessageBox.Show("更改仓库信息成功!");
                        }
                        else
                        {
                            MessageBox.Show("更改仓库信息失败,请尝试重新增加");
                            Close();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("查询异常,请检查服务器连接.错误:" + ex.Message);
                    }
                }
                else
                {
                    MessageBox.Show("仓库名称不可为空,请检查.");
                }
            }
        }

        //取消
        private void buttonX1_Click(object sender, EventArgs e)
        {
            Close();
        }

        //保存并退出 
        private void buttonX3_Click(object sender, EventArgs e)
        {
            buttonX2.PerformClick();
            Close();
        }

        /// <summary>
        /// 根据文本框内容建立实体数据
        /// </summary>
        /// <returns></returns>
        private Storage fillStorage()
        {
            Storage storage = new Storage();

            storage.St_Address = textBoxXAddress.Text;
            storage.St_Clear = 1;
            storage.St_Code = BuildCode.ModuleCode("ST");
            storage.St_EmpName = textBoxXMan.Text.Trim();
            storage.St_Enable = checkBoxXEnable.Checked ? 0 : 1;
            storage.St_Name = textBoxXName.Text.Trim();
            storage.St_Phone = textBoxXPhone.Text.Trim();
            storage.St_Remark = textBoxXRemark.Text;
            storage.St_Safetyone = "";
            storage.St_Safetytwo = "";

            return storage;
        }
    }
}
