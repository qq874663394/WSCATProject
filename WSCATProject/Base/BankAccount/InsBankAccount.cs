using BLL;
using HelperUtility;
using HelperUtility.Encrypt;
using Model;
using System;
using System.Windows.Forms;

namespace WSCATProject.Base
{
    public partial class InsBankAccount : Form
    {
        BankAccountManager bm = new BankAccountManager();
        public InsBankAccount()
        {
            InitializeComponent();
        }

        private void InsBankAccount_Load(object sender, EventArgs e)
        {
            BankAccountForm bam = (BankAccountForm)Owner;
            try
            {
                switch (bam.StateType)
                {
                    case 0:
                        textBox1.Text = BuildCode.ModuleCode("BA");
                        break;
                    case 1:
                        BankAccount tba = bm.SelBankAccountByCode(bam.id);
                        textBox1.Text = XYEEncoding.strHexDecode(tba.Ba_Code);
                        textBox3.Text = XYEEncoding.strHexDecode(tba.Ba_CardHolder);
                        textBox2.Text = XYEEncoding.strHexDecode(tba.Ba_Account);
                        textBox4.Text = XYEEncoding.strHexDecode(tba.Ba_OpenBank);
                        textBox5.Text = XYEEncoding.strHexDecode(tba.Ba_AvailablePrice);
                        textBox6.Text = XYEEncoding.strHexDecode(tba.Ba_Remark);
                        if (tba.Ba_Enable == 1)
                        {
                            radioButton2.Checked = true;
                        }
                        else
                        {
                            radioButton1.Checked = true;
                        }
                        break;
                    default:
                        MessageBox.Show("类型错误！");
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("加载数据失败,请检查服务器连接并尝试刷新.错误:" + ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            UpdateBA();
        }

        private void UpdateBA()
        {
            BankAccountForm bam = (BankAccountForm)Owner;
            BankAccount ba = new BankAccount();
            int result = 0;
            ba.Ba_Code = textBox1.Text.Trim();
            ba.Ba_CardHolder = textBox3.Text.Trim();
            ba.Ba_Account = textBox2.Text.Trim();
            ba.Ba_OpenBank = textBox4.Text.Trim();
            ba.Ba_Remark = textBox6.Text.Trim();
            ba.Ba_AvailablePrice = textBox5.Text.Trim();
            ba.Ba_Clear = 1;
            if (radioButton2.Checked == true)
            {
                ba.Ba_Enable = 1;
            }
            else
            {
                ba.Ba_Enable = 0;
            }

            try
            {
                if (bam.StateType == 0)
                {
                    result = bm.InsBankAccount(ba);
                }
                else
                {
                    result = bm.UpdateBA(ba);
                }
                if (result > 0)
                {
                    bam.isflag = true;
                    MessageBox.Show("保存成功");
                    Close();
                    Dispose();
                    return;
                }
                else
                {
                    bam.isflag = false;
                    MessageBox.Show("保存失败");
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("保存数据失败,请检查服务器连接并尝试重新保存.错误:" + ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
            Dispose();
        }
    }
}
