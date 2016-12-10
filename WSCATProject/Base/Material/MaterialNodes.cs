
using HelperUtility;
using HelperUtility.Encrypt;
using Model;
using System;
using System.Windows.Forms;

namespace WSCATProject.Base
{
    public partial class MaterialNodes : Form
    {
        public string code { get; set; }
        public string name { get; set; }
        public int state { get; set; }
        public bool flag = false;
        public bool Flag { get { return flag; } set { flag = value; } }
        public string txtName { get; set; }
        public MaterialNodes()
        {
            InitializeComponent();
        }

        protected virtual void form_save_Click(object sender, EventArgs e)
        {
        }
        #region 非空验证
        /// <summary>
        /// 非空验证
        /// </summary>
        /// <returns></returns>
        protected bool InsTextIsNull()
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                MessageBox.Show("节点名称不能为空！");
                return false;
            }
            return true;
        }
        #endregion
        protected virtual void form_exit_Click(object sender, EventArgs e)
        {
            flag = false;
            this.Close();
            this.Dispose();
        }
    }
}
