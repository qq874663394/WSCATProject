using BLL;
using Model;
using System;
using System.Windows.Forms;
using WSCATProject.Base;

namespace WSCATProject.Base
{
    public partial class InsOrderTypeNode : MaterialNodes
    {
        OrderTypeManager otm = new OrderTypeManager();
        public InsOrderTypeNode()
        {
            InitializeComponent();
        }

        private void InsOrderTypeNode_Load(object sender, EventArgs e)
        {
            OrderTypeForm ot = (OrderTypeForm)Owner;
            if (ot.StateType == 0)
            {
                Text = "添加单据类型";
                label1.Text = "请输入类型名称";
            }
            else
            {
                Text = "编辑单据类型";
                label1.Text = "请输入修改后的名称";
                try
                {
                    OrderType tot = otm.SelOrderTypeByCode(Convert.ToInt32(ot.id));
                    textBox1.Text = tot.Ot_Name;
                }
                catch (Exception ex)
                { 
                    MessageBox.Show("加载数据失败,请检查服务器连接并尝试刷新.错误:" + ex.Message);
                }
            }
        }

        private void form_save_Click_1(object sender, EventArgs e)
        {
            OrderTypeForm bt = (OrderTypeForm)Owner;
            OrderType tot = new OrderType();
            if (!string.IsNullOrWhiteSpace(textBox1.Text.Trim()))
            {
                int result = 0;
                try
                {
                    if (bt.StateType == 0)
                    {
                        tot.Ot_Name = textBox1.Text.Trim();
                        result = otm.InsOrderType(tot);
                    }
                    else
                    {
                        tot.Ot_ID = int.Parse(bt.id);
                        tot.Ot_Name = textBox1.Text.Trim();
                        result = otm.UpdateOrderType(tot);
                    }
                    if (result > 0)
                    {
                        bt.isflag = true;
                        MessageBox.Show("保存成功");
                        form_exit.PerformClick();
                    }
                    else
                    {
                        bt.isflag = false;
                        MessageBox.Show("保存失败");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("保存失败,请检查服务器连接并尝试重新保存.错误:" + ex.Message);
                }
            }
        }

        private void form_exit_Click_1(object sender, EventArgs e)
        {
            base.form_exit_Click(sender, e);
        }
    }
}
