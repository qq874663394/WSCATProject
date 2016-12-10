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
    public partial class FinanceCategoriesDialogForm : Form
    {
        public static int flag; //0为新增失败，1为新增成功
        FinanceSummaryLibrary fsl = new FinanceSummaryLibrary();
        FinanceSummaryLibraryInterface fsli = new FinanceSummaryLibraryInterface();
        public FinanceCategoriesDialogForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 加载事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FinanceCategoriesDialogForm_Load(object sender, EventArgs e)
        {
        }

        /// <summary>
        /// 取消
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnNo_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// 确定
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
                    fsl.code = BuildCode.ModuleCode("summaryLibrary");
                    flag = fsli.AddParentNode(fsl);
                    if (flag == 0)
                    {
                        //添加失败
                        return;
                    }
                    else
                    {
                        //添加成功
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
    }
}
