namespace WSCATProject.Base
{
    partial class LoginForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxXName = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.textBoxXPassword = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.buttonXLogin = new DevComponents.DotNetBar.ButtonX();
            this.buttonXClose = new DevComponents.DotNetBar.ButtonX();
            this.labelNull = new System.Windows.Forms.Label();
            this.labelName = new System.Windows.Forms.Label();
            this.labelPW = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(161, 144);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "用户名：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(173, 170);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "密码：";
            // 
            // textBoxXName
            // 
            // 
            // 
            // 
            this.textBoxXName.Border.Class = "TextBoxBorder";
            this.textBoxXName.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.textBoxXName.Font = new System.Drawing.Font("宋体", 9F);
            this.textBoxXName.Location = new System.Drawing.Point(214, 139);
            this.textBoxXName.Name = "textBoxXName";
            this.textBoxXName.PreventEnterBeep = true;
            this.textBoxXName.Size = new System.Drawing.Size(115, 21);
            this.textBoxXName.TabIndex = 2;
            this.textBoxXName.TextChanged += new System.EventHandler(this.textBoxXPassword_TextChanged);
            // 
            // textBoxXPassword
            // 
            // 
            // 
            // 
            this.textBoxXPassword.Border.Class = "TextBoxBorder";
            this.textBoxXPassword.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.textBoxXPassword.Font = new System.Drawing.Font("宋体", 9F);
            this.textBoxXPassword.Location = new System.Drawing.Point(214, 166);
            this.textBoxXPassword.Name = "textBoxXPassword";
            this.textBoxXPassword.PasswordChar = '*';
            this.textBoxXPassword.PreventEnterBeep = true;
            this.textBoxXPassword.Size = new System.Drawing.Size(115, 21);
            this.textBoxXPassword.TabIndex = 3;
            this.textBoxXPassword.UseSystemPasswordChar = true;
            this.textBoxXPassword.TextChanged += new System.EventHandler(this.textBoxXPassword_TextChanged);
            // 
            // buttonXLogin
            // 
            this.buttonXLogin.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonXLogin.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonXLogin.Location = new System.Drawing.Point(211, 220);
            this.buttonXLogin.Name = "buttonXLogin";
            this.buttonXLogin.Size = new System.Drawing.Size(54, 21);
            this.buttonXLogin.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonXLogin.TabIndex = 4;
            this.buttonXLogin.Text = "登录";
            this.buttonXLogin.Click += new System.EventHandler(this.buttonXLogin_Click);
            // 
            // buttonXClose
            // 
            this.buttonXClose.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonXClose.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonXClose.Location = new System.Drawing.Point(276, 220);
            this.buttonXClose.Name = "buttonXClose";
            this.buttonXClose.Size = new System.Drawing.Size(54, 21);
            this.buttonXClose.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonXClose.TabIndex = 5;
            this.buttonXClose.Text = "退出";
            this.buttonXClose.Click += new System.EventHandler(this.buttonXClose_Click);
            // 
            // labelNull
            // 
            this.labelNull.AutoSize = true;
            this.labelNull.ForeColor = System.Drawing.Color.Red;
            this.labelNull.Location = new System.Drawing.Point(264, 197);
            this.labelNull.Name = "labelNull";
            this.labelNull.Size = new System.Drawing.Size(11, 12);
            this.labelNull.TabIndex = 6;
            this.labelNull.Text = "-";
            this.labelNull.Visible = false;
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.ForeColor = System.Drawing.Color.Red;
            this.labelName.Location = new System.Drawing.Point(332, 144);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(11, 12);
            this.labelName.TabIndex = 7;
            this.labelName.Text = "*";
            // 
            // labelPW
            // 
            this.labelPW.AutoSize = true;
            this.labelPW.ForeColor = System.Drawing.Color.Red;
            this.labelPW.Location = new System.Drawing.Point(332, 172);
            this.labelPW.Name = "labelPW";
            this.labelPW.Size = new System.Drawing.Size(11, 12);
            this.labelPW.TabIndex = 8;
            this.labelPW.Text = "*";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::WSCATProject.Properties.Resources.loginBKI;
            this.ClientSize = new System.Drawing.Size(484, 312);
            this.ControlBox = false;
            this.Controls.Add(this.labelPW);
            this.Controls.Add(this.labelName);
            this.Controls.Add(this.labelNull);
            this.Controls.Add(this.buttonXClose);
            this.Controls.Add(this.buttonXLogin);
            this.Controls.Add(this.textBoxXPassword);
            this.Controls.Add(this.textBoxXName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "Form1";
            this.Text = "用户登录";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private DevComponents.DotNetBar.Controls.TextBoxX textBoxXName;
        private DevComponents.DotNetBar.Controls.TextBoxX textBoxXPassword;
        private DevComponents.DotNetBar.ButtonX buttonXLogin;
        private DevComponents.DotNetBar.ButtonX buttonXClose;
        private System.Windows.Forms.Label labelNull;
        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.Label labelPW;
    }
}