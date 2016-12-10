using HelperUtility;
using InterfaceLayer.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WSCATProject
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }
        public string[] strContentsps;
        private string strFilePath = Application.StartupPath + "\\FileConfig.txt";//获取INI文件路径
        private void LoginForm_Load(object sender, EventArgs e)
        {
            #region 初始化窗体
            label1.Parent = pictureBox2;
            label1.ForeColor = Color.White;
            label2.Parent = pictureBox2;
            label2.ForeColor = Color.White;
            label3.Parent = pictureBox2;
            label3.ForeColor = Color.White;
            label4.Parent = pictureBox2;
            label4.ForeColor = Color.White;
            btnLogin.Parent = pictureBox2;
            btnLogin.FlatStyle = FlatStyle.Flat;
            btnLogin.BackColor = Color.FromArgb(74, 77, 110);
            btnLogin.FlatAppearance.BorderColor = btnLogin.BackColor;
            btnLogin.ForeColor = Color.White;
            btnClose.Parent = pictureBox2;
            btnClose.FlatStyle = FlatStyle.Flat;
            btnClose.BackColor = Color.FromArgb(74, 77, 110);
            btnClose.FlatAppearance.BorderColor = btnClose.BackColor;
            btnClose.ForeColor = Color.White;

            #endregion

            if (File.Exists(strFilePath) == false)
            {
                MessageBox.Show("记录文件不存在");
                return;
            }
            StreamReader st;
            string[] strContentspsTemp=null;
            st = new StreamReader(strFilePath, Encoding.UTF8);//UTF8为编码
            string strContent = st.ReadToEnd();
            comboBox2.AutoCompleteSource = AutoCompleteSource.CustomSource;
            strContent = strContent.Replace("\r\n", ",");
            strContent = strContent.Replace("\n\r", ",");
            try
            {
                strContent = strContent.Remove(strContent.IndexOf(","), 1);
                strContent = strContent.Remove(strContent.LastIndexOf(","), 1);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                strContentsps = strContent.Split(',');
                strContentspsTemp = strContentsps.Distinct().ToArray();

                comboBox2.AutoCompleteCustomSource.AddRange(strContentspsTemp);
                comboBox2.Items.AddRange(strContentspsTemp);
                st.Dispose();
                st.Close();
            }
            comboBox1.SelectedIndex = 0;
            comboBox2.SelectedIndex = 0;
        }

        #region 设置窗体无边框可以拖动
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();

        private void LoginForm_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }
        #endregion

        /// <summary>
        /// 关闭登陆窗体
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClose_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }
        /// <summary>
        /// 登录按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLogin_Click(object sender, EventArgs e)
        {
            StreamWriter sw;
            EmpolyeeInterface EmpInter = new EmpolyeeInterface();
            if (EmpInter.Exists(comboBox2.Text.Trim(), textBox2.Text) == true)
                return;
            sw = new StreamWriter(strFilePath, true);//流写写入 new建取一个缓存区
            if (File.Exists(strFilePath) == false)
            {
                sw = new StreamWriter(strFilePath, false);
            }
            try
            {
                if (strContentsps == null)
                {
                    sw.WriteLine(comboBox2.Text.Trim());    //写入
                }
                else
                {
                    for (int i = 0; i < strContentsps.Length - 1; i++)
                    {
                        if (strContentsps[i].Equals(comboBox2.Text.Trim()) == false && i == strContentsps.Length - 1)
                        {
                            sw.WriteLine(comboBox2.Text.Trim());    //写入
                        }
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                sw.Flush();
                sw.Close();
            }

            LoginInfomation.getInstance().UserName = comboBox2.Text.Trim();
            Close();
            Dispose();
            MainForm mf = new MainForm();
            mf._ShowOrHide = false;
            mf.Show();
        }
    }
}
