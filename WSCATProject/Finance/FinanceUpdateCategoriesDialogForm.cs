using HelperUtility;
using InterfaceLayer.Finance;
using Model.Finance;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WSCATProject.Finance
{
    public partial class FinanceUpdateCategoriesDialogForm : Form
    {
        public FinanceUpdateCategoriesDialogForm()
        {
            InitializeComponent();
        }

        FinanceSummaryLibrary fsl = new FinanceSummaryLibrary();
        FinanceSummaryLibraryInterface fsli = new FinanceSummaryLibraryInterface();
        public static int flag; //判断是否修改成功，0失败，1成功

        /// <summary>
        /// 确认按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnYes_Click(object sender, EventArgs e)
        {
            string name; //类别名称
            try
            {
                name = this.txtName.Text;
                if (string.IsNullOrWhiteSpace(name))
                {
                    MessageBox.Show("请在输入值后再进行添加操作！");
                    return;
                }
                else
                {
                    //传值
                    fsl.name = this.txtName.Text;
                    fsl.code = FinanceSummaryLibraryForm.code;
                    flag = fsli.UpdateNode(fsl);
                    if (flag == 0)
                    {
                        //修改失败
                        flag = 0;
                        return;
                    }
                    else
                    {
                        //修改成功
                        flag = 1;
                    }
                }
            }
            catch
            {
                //执行失败
            }
            this.Close();
        }

        /// <summary>
        /// 取消按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnNo_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FinanceUpdateCategoriesDialogForm_Load(object sender, EventArgs e)
        {
            this.txtName.Text = FinanceSummaryLibraryForm.name;
        }
    }
}
