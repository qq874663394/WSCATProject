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
    public partial class FinanceSubjectAddDialogForm : Form
    {
        public FinanceSubjectAddDialogForm()
        {
            InitializeComponent();
        }
        FinanceAccountingSubjects fas = new FinanceAccountingSubjects();
        FinanceAccountingSubjectsInterface fasi = new FinanceAccountingSubjectsInterface();
        public static int flag;  //判断新添修改是否成功
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
        /// 加载事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FinanceSubjectAddDialog_Load(object sender, EventArgs e)
        {
            if (FinanceAccountingSubjectsForm.dialog == 1)
            {
                this.Text = "科目-新添";
                this.btnYes.Text = "添加";
                //类别
                if (FinanceAccountingSubjectsForm.addNode == 1)
                {
                    rdbClass.Checked = true;
                    txtCode.Visible = false;
                    label1.Visible = false;
                }
                //科目
                else
                {
                    rdbSubject.Checked = true;
                    txtCode.Visible = true;
                    label1.Visible = true;
                    rdbClass.Enabled = false;
                }
            }
            else
            {
                this.Text = "科目-修改";
                this.btnYes.Text = "修改";
                //判断修改
                if (string.IsNullOrWhiteSpace(FinanceAccountingSubjectsForm.hotKey))
                {
                    rdbClass.Checked = true;
                    rdbSubject.Enabled = false;
                    txtName.Text = FinanceAccountingSubjectsForm.name;
                    txtCode.Visible = false;
                    label1.Visible = false;
                }
                else
                {
                    rdbSubject.Checked = true;
                    rdbClass.Enabled = false;
                    txtCode.Visible = true;
                    label1.Visible = true;
                    txtName.Text = FinanceAccountingSubjectsForm.name;
                    txtCode.Text = FinanceAccountingSubjectsForm.hotKey;
                    FinanceAccountingSubjectsForm.hotKey = ""; //清空hotkey
                }
            }
        }

        /// <summary>
        /// 确认按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnYes_Click(object sender, EventArgs e)
        {
            //添加判断
            if (FinanceAccountingSubjectsForm.dialog == 1)
            {

                flag = 0;
                //类别
                if (rdbClass.Checked == true)
                {
                    fas.name = txtName.Text;
                    fas.code = BuildCode.ModuleCode("SubjectAdd");
                    fas.nodeType = FinanceAccountingSubjectsForm.nodeType;
                }
                //科目
                else
                {
                    fas.name = txtName.Text;
                    fas.code = BuildCode.ModuleCode("SubjectAdd");
                    fas.hotKey = txtCode.Text;
                    fas.parentCode = FinanceAccountingSubjectsForm.parentCode;
                    fas.nodeType = FinanceAccountingSubjectsForm.nodeType;
                }
                //执行添加
                int num = fasi.AddParentNode(fas);
                if (num == 1)
                {
                    flag = 1;
                }
                else
                {
                    flag = 0;
                    //添加失败
                }
            }
            //修改
            else
            {
                flag = 0;
                //类别
                if (string.IsNullOrWhiteSpace(txtCode.Text))
                {
                    fas.name = txtName.Text;
                    fas.code = FinanceAccountingSubjectsForm.code;
                }
                //科目
                else
                {
                    fas.name = txtName.Text;
                    fas.code = FinanceAccountingSubjectsForm.code;
                    fas.hotKey = txtCode.Text;
                }
                //执行修改
                int num = fasi.UpdateNode(fas);
                if (num == 1)
                {
                    flag = 1;
                }
                else
                {
                    flag = 0;
                    //添加失败
                }
            }
            this.Close();
        }

        //类别改变
        private void rdbClass_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbClass.Checked == true)
            {
                txtCode.Visible = false;
                label1.Visible = false;
            }
        }

        //科目改变
        private void rdbSubject_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbSubject.Checked == true)
            {
                txtCode.Visible = true;
                label1.Visible = true;
            }
        }
    }
}
