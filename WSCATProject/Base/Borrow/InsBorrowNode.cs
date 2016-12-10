using BLL;
using Model;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace WSCATProject.Base
{
    public partial class InsBorrowNode : MaterialNodes
    {
        BorrowManager bm = new BorrowManager();
        public InsBorrowNode()
        {
            InitializeComponent();
        }
        private void InsBorrowNode_Load(object sender, EventArgs e)
        {
            BorrowType bt = (BorrowType)Owner;
            if (bt.StateType == 0)
            {
                Text = "添加借款类型";
                label1.Text = "请输入类型名称";
            }
            else
            {
                Text = "编辑借款类型";
                label1.Text = "请输入修改后的名称";
                try
                {
                    List<Borrow> list = bm.SelBorrowByTypeID(Convert.ToInt32(bt.id));
                    textBox1.Text = list[0].Bo_TypeName;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("加载数据失败,请检查服务器连接并尝试刷新.错误:" + ex.Message);
                }
            }
        }
        protected override void form_save_Click(object sender, EventArgs e)
        {
            BorrowType bt = (BorrowType)Owner;
            string typename = textBox1.Text.Trim();
            if (!string.IsNullOrWhiteSpace(textBox1.Text.Trim()))
            {
                try
                {
                    int result = 0;
                    if (bt.StateType == 0)
                    {
                        result = bm.InsBorrow(typename);
                    }
                    else
                    {
                        Borrow bw = new Borrow()
                        {
                            Bo_TypeID = int.Parse(bt.id),
                            Bo_TypeName = textBox1.Text.Trim()
                        };
                        result = bm.UpdateBorrow(bw);
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
        protected override void form_exit_Click(object sender, EventArgs e)
        {
            base.form_exit_Click(sender, e);
        }
    }
}
