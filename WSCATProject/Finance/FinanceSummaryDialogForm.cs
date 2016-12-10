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
    public partial class FinanceSummaryDialogForm : Form
    {
        public FinanceSummaryDialogForm()
        {
            InitializeComponent();
        }
        FinanceSummaryLibraryForm fslf = new FinanceSummaryLibraryForm();
        FinanceSummaryLibrary fsl = new FinanceSummaryLibrary();
        FinanceSummaryLibraryInterface fsli = new FinanceSummaryLibraryInterface();
        public static int flag; //判断修改是否成功

        /// <summary>
        /// 确认
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnYes_Click(object sender, EventArgs e)
        {
            //添加
            if (FinanceSummaryLibraryForm.dialog == 0)
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
                        fsl.parentCode = FinanceSummaryLibraryForm.code;
                        fsl.hotKey = this.txtKey.Text;
                        flag = fsli.AddParentNode(fsl);
                        if (flag == 0)
                        {
                            //添加失败
                            flag = 0;
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
            }
            //修改
            else if (FinanceSummaryLibraryForm.dialog == 1)
            {
                string name; //节点名称
                string key; //快捷代码名称
                try
                {
                    name = this.txtName.Text;
                    key = this.txtKey.Text;
                    if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(key))
                    {
                        MessageBox.Show("请在输入值后再进行添加操作！");
                        return;
                    }
                    else
                    {
                        //传值
                        fsl.name = this.txtName.Text;
                        fsl.hotKey = this.txtKey.Text;
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
            }
            this.Close();
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
        /// 加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FinanceSummaryDialogForm_Load(object sender, EventArgs e)
        {
            //添加
            if (FinanceSummaryLibraryForm.dialog == 0)
            {
                this.Text = "摘要-添加";
                this.btnYes.Text = "新增";
            }
            //修改
            else if (FinanceSummaryLibraryForm.dialog == 1)
            {
                this.Text = "摘要-修改";
                this.txtKey.Text = FinanceSummaryLibraryForm.hotKey;
                this.txtName.Text = FinanceSummaryLibraryForm.name;
                this.btnYes.Text = "修改";
            }
        }
    }
}
