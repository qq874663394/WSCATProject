using HelperUtility;
using InterfaceLayer.Base;
using Model;
using System;
using System.Windows.Forms;

namespace WSCATProject.Base
{
    public partial class AreaNode : MaterialNodes
    {
        public AreaNode()
        {
            InitializeComponent();
        }

        private void AreaNode_Load(object sender, EventArgs e)
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
                text_childName.Text = txtName;
                return;
            }
        }
        /// <summary>
        /// 保存按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void form_save_Click(object sender, EventArgs e)
        {
            if (InsTextIsNull() == false)
            {
                return;
            }
            AreaInterface _dal = new AreaInterface();
            BaseArea area = null;
            AreaType ct = (AreaType)Owner;
            area = new BaseArea()
            {
                name = text_childName.Text.Trim(),
                isClear = 1,
                isEnable = 1,
                code = BuildCode.ModuleCode("A"),
                parentId = code,
                updateDate = DateTime.Now
            };
            try
            {
                switch (state)
                {
                    case 0:
                        int result = _dal.Add(area);
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
                        result = _dal.Add(area);
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
                        result = _dal.Update(area);
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
