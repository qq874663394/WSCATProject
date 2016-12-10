using System;
using System.Windows.Forms;
using Model;
using HelperUtility;
using HelperUtility.Encrypt;
using BLL;

namespace WSCATProject.Base
{
    public partial class CreateClientTypeForm : Form
    {
        //使用结构体初始化窗体控件的一部分,并将窗体的tag赋值,标识所要进行的是增加还是修改
        public CreateClientTypeForm(formType ft)
        {
            InitializeComponent();
            this.Text = ft.formText;
            this.richTextBoxExRe.Text = ft.richTextbox;
            this.textBoxXName.Text = ft.textboxName;
            formStatic = ft.formStatic;
        }

        //窗体初始化状态 必须初始化
        public struct formType
        {
            public string formText { get; set; }
            public string formStatic { get; set; }
            public string textboxName { get; set; }
            public string richTextbox { get; set; }
        }

        private string formStatic = "";
        private bool exceptionFlag = true;

        private void CreateClientTypeForm_Load(object sender, EventArgs e)
        {

        }

        private void buttonXOK_Click(object sender, EventArgs e)
        {
            ClientType ct = new ClientType();
            ClientTypeManager ctm = new ClientTypeManager();
            ClientTypeForm ctf = (ClientTypeForm)this.Owner;

            switch (formStatic)
            {
                case "增":
                    ct.CT_Name = XYEEncoding.strCodeHex(textBoxXName.Text.Trim());
                    ct.CT_Remark = XYEEncoding.strCodeHex(richTextBoxExRe.Text);
                    ct.CT_Code = XYEEncoding.strCodeHex(BuildCode.ModuleCode("CL"));
                    ct.CT_Enable = 1;

                    int insertResult = 0;
                    try
                    {
                        insertResult = ctm.Add(ct);
                    }
                    catch(Exception ex)
                    {
                        MessageBox.Show("系统异常:" + ex.Message);
                        exceptionFlag = false;
                    }

                    if(insertResult > 0 && exceptionFlag)
                    {
                        ctf.loadData();
                        MessageBox.Show("添加成功!");
                    }
                    else
                    {
                        MessageBox.Show("添加失败，请尝试重新添加");
                    }
                    break;
                case "改":
                    ct.CT_Name = XYEEncoding.strCodeHex(textBoxXName.Text.Trim());
                    ct.CT_Remark = XYEEncoding.strCodeHex(richTextBoxExRe.Text);
                    ct.CT_Enable = 1;

                    bool updateResult = false;
                    try
                    {
                         updateResult = ctm.Update(ct);
                    }
                    catch(Exception ex)
                    {
                        MessageBox.Show("系统异常:" + ex.Message);
                        exceptionFlag = false;
                    }

                    if(updateResult && exceptionFlag)
                    {
                        ctf.loadData();
                        MessageBox.Show("更新成功!");
                    }
                    else
                    {
                        MessageBox.Show("更新失败，请尝试重新添加");
                    }
                    break;
                case "":
                    MessageBox.Show("初始化异常,请重新操作");
                    break;
            }
            if(!exceptionFlag)
                this.Close();
        }

        private void buttonXCancel_Click(object sender, EventArgs e)
        {
            ClientTypeForm ctf = (ClientTypeForm)this.Owner;
            Close();
        }

        //禁用关闭按钮
        private const int CP_NOCLOSE_BUTTON = 0x200;
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams myCp = base.CreateParams;
                myCp.ClassStyle = myCp.ClassStyle | CP_NOCLOSE_BUTTON;
                return myCp;
            }
        }
    }
}
