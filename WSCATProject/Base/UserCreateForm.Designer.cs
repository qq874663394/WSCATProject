namespace WSCATProject.Base
{
    partial class UserCreateForm
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
            this.components = new System.ComponentModel.Container();
            this.styleManager1 = new DevComponents.DotNetBar.StyleManager(this.components);
            this.buttonItem1 = new DevComponents.DotNetBar.ButtonItem();
            this.ribbonControl1 = new DevComponents.DotNetBar.RibbonControl();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.labelX3 = new DevComponents.DotNetBar.LabelX();
            this.textBoxXName = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX4 = new DevComponents.DotNetBar.LabelX();
            this.textBoxXPassword = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX5 = new DevComponents.DotNetBar.LabelX();
            this.labelX6 = new DevComponents.DotNetBar.LabelX();
            this.textBoxXPasswordAgain = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX7 = new DevComponents.DotNetBar.LabelX();
            this.comboboxXRole = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.labelX8 = new DevComponents.DotNetBar.LabelX();
            this.labelX9 = new DevComponents.DotNetBar.LabelX();
            this.buttonXClose = new DevComponents.DotNetBar.ButtonX();
            this.buttonXSave = new DevComponents.DotNetBar.ButtonX();
            this.labelXNameWarning = new DevComponents.DotNetBar.LabelX();
            this.labelXPwWarning = new DevComponents.DotNetBar.LabelX();
            this.labelXPwAWarning = new DevComponents.DotNetBar.LabelX();
            this.labelXRoleWarning = new DevComponents.DotNetBar.LabelX();
            this.SuspendLayout();
            // 
            // styleManager1
            // 
            this.styleManager1.ManagerStyle = DevComponents.DotNetBar.eStyle.Office2010Blue;
            this.styleManager1.MetroColorParameters = new DevComponents.DotNetBar.Metro.ColorTables.MetroColorGeneratorParameters(System.Drawing.Color.White, System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(115)))), ((int)(((byte)(199))))));
            // 
            // buttonItem1
            // 
            this.buttonItem1.Name = "buttonItem1";
            this.buttonItem1.Text = "buttonItem1";
            // 
            // ribbonControl1
            // 
            // 
            // 
            // 
            this.ribbonControl1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.ribbonControl1.CaptionVisible = true;
            this.ribbonControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.ribbonControl1.KeyTipsFont = new System.Drawing.Font("Tahoma", 7F);
            this.ribbonControl1.Location = new System.Drawing.Point(5, 1);
            this.ribbonControl1.Name = "ribbonControl1";
            this.ribbonControl1.Padding = new System.Windows.Forms.Padding(0, 0, 0, 3);
            this.ribbonControl1.Size = new System.Drawing.Size(643, 28);
            this.ribbonControl1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.ribbonControl1.SystemText.MaximizeRibbonText = "&Maximize the Ribbon";
            this.ribbonControl1.SystemText.MinimizeRibbonText = "Mi&nimize the Ribbon";
            this.ribbonControl1.SystemText.QatAddItemText = "&Add to Quick Access Toolbar";
            this.ribbonControl1.SystemText.QatCustomizeMenuLabel = "<b>Customize Quick Access Toolbar</b>";
            this.ribbonControl1.SystemText.QatCustomizeText = "&Customize Quick Access Toolbar...";
            this.ribbonControl1.SystemText.QatDialogAddButton = "&Add >>";
            this.ribbonControl1.SystemText.QatDialogCancelButton = "Cancel";
            this.ribbonControl1.SystemText.QatDialogCaption = "Customize Quick Access Toolbar";
            this.ribbonControl1.SystemText.QatDialogCategoriesLabel = "&Choose commands from:";
            this.ribbonControl1.SystemText.QatDialogOkButton = "OK";
            this.ribbonControl1.SystemText.QatDialogPlacementCheckbox = "&Place Quick Access Toolbar below the Ribbon";
            this.ribbonControl1.SystemText.QatDialogRemoveButton = "&Remove";
            this.ribbonControl1.SystemText.QatPlaceAboveRibbonText = "&Place Quick Access Toolbar above the Ribbon";
            this.ribbonControl1.SystemText.QatPlaceBelowRibbonText = "&Place Quick Access Toolbar below the Ribbon";
            this.ribbonControl1.SystemText.QatRemoveItemText = "&Remove from Quick Access Toolbar";
            this.ribbonControl1.TabGroupHeight = 14;
            this.ribbonControl1.TabIndex = 0;
            this.ribbonControl1.Text = "ribbonControl1";
            this.ribbonControl1.TitleText = "用户注册";
            // 
            // labelX1
            // 
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.Font = new System.Drawing.Font("宋体", 21F, System.Drawing.FontStyle.Bold);
            this.labelX1.ForeColor = System.Drawing.Color.White;
            this.labelX1.Location = new System.Drawing.Point(32, 50);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(163, 37);
            this.labelX1.TabIndex = 1;
            this.labelX1.Text = "新增管理员";
            // 
            // labelX2
            // 
            // 
            // 
            // 
            this.labelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX2.Font = new System.Drawing.Font("宋体", 9F);
            this.labelX2.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.labelX2.Location = new System.Drawing.Point(33, 81);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(198, 22);
            this.labelX2.TabIndex = 2;
            this.labelX2.Text = "·新管理员根据角色分配模块权限";
            // 
            // labelX3
            // 
            // 
            // 
            // 
            this.labelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX3.Font = new System.Drawing.Font("宋体", 9F);
            this.labelX3.ForeColor = System.Drawing.Color.Honeydew;
            this.labelX3.Location = new System.Drawing.Point(136, 150);
            this.labelX3.Name = "labelX3";
            this.labelX3.Size = new System.Drawing.Size(59, 22);
            this.labelX3.TabIndex = 3;
            this.labelX3.Text = "用户名：";
            // 
            // textBoxXName
            // 
            this.textBoxXName.BackColor = System.Drawing.Color.Honeydew;
            // 
            // 
            // 
            this.textBoxXName.Border.Class = "TextBoxBorder";
            this.textBoxXName.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.textBoxXName.Location = new System.Drawing.Point(186, 150);
            this.textBoxXName.Name = "textBoxXName";
            this.textBoxXName.PreventEnterBeep = true;
            this.textBoxXName.Size = new System.Drawing.Size(184, 21);
            this.textBoxXName.TabIndex = 4;
            // 
            // labelX4
            // 
            // 
            // 
            // 
            this.labelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX4.Font = new System.Drawing.Font("宋体", 9F);
            this.labelX4.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.labelX4.Location = new System.Drawing.Point(424, 142);
            this.labelX4.Name = "labelX4";
            this.labelX4.Size = new System.Drawing.Size(194, 38);
            this.labelX4.TabIndex = 5;
            this.labelX4.Text = "用作用户登录，用户名不可重复。";
            this.labelX4.WordWrap = true;
            // 
            // textBoxXPassword
            // 
            this.textBoxXPassword.BackColor = System.Drawing.Color.Honeydew;
            // 
            // 
            // 
            this.textBoxXPassword.Border.Class = "TextBoxBorder";
            this.textBoxXPassword.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.textBoxXPassword.Location = new System.Drawing.Point(186, 203);
            this.textBoxXPassword.Name = "textBoxXPassword";
            this.textBoxXPassword.PreventEnterBeep = true;
            this.textBoxXPassword.Size = new System.Drawing.Size(184, 21);
            this.textBoxXPassword.TabIndex = 7;
            // 
            // labelX5
            // 
            // 
            // 
            // 
            this.labelX5.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX5.Font = new System.Drawing.Font("宋体", 9F);
            this.labelX5.ForeColor = System.Drawing.Color.Honeydew;
            this.labelX5.Location = new System.Drawing.Point(124, 203);
            this.labelX5.Name = "labelX5";
            this.labelX5.Size = new System.Drawing.Size(73, 22);
            this.labelX5.TabIndex = 6;
            this.labelX5.Text = "用户密码：";
            // 
            // labelX6
            // 
            // 
            // 
            // 
            this.labelX6.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX6.Font = new System.Drawing.Font("宋体", 9F);
            this.labelX6.ForeColor = System.Drawing.Color.Honeydew;
            this.labelX6.Location = new System.Drawing.Point(123, 309);
            this.labelX6.Name = "labelX6";
            this.labelX6.Size = new System.Drawing.Size(73, 22);
            this.labelX6.TabIndex = 10;
            this.labelX6.Text = "用户角色：";
            // 
            // textBoxXPasswordAgain
            // 
            this.textBoxXPasswordAgain.BackColor = System.Drawing.Color.Honeydew;
            // 
            // 
            // 
            this.textBoxXPasswordAgain.Border.Class = "TextBoxBorder";
            this.textBoxXPasswordAgain.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.textBoxXPasswordAgain.Location = new System.Drawing.Point(186, 256);
            this.textBoxXPasswordAgain.Name = "textBoxXPasswordAgain";
            this.textBoxXPasswordAgain.PreventEnterBeep = true;
            this.textBoxXPasswordAgain.Size = new System.Drawing.Size(184, 21);
            this.textBoxXPasswordAgain.TabIndex = 9;
            // 
            // labelX7
            // 
            // 
            // 
            // 
            this.labelX7.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX7.Font = new System.Drawing.Font("宋体", 9F);
            this.labelX7.ForeColor = System.Drawing.Color.Honeydew;
            this.labelX7.Location = new System.Drawing.Point(123, 256);
            this.labelX7.Name = "labelX7";
            this.labelX7.Size = new System.Drawing.Size(84, 22);
            this.labelX7.TabIndex = 8;
            this.labelX7.Text = "重复密码：";
            // 
            // comboboxXRole
            // 
            this.comboboxXRole.DisplayMember = "Text";
            this.comboboxXRole.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.comboboxXRole.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboboxXRole.FormattingEnabled = true;
            this.comboboxXRole.ItemHeight = 15;
            this.comboboxXRole.Location = new System.Drawing.Point(186, 310);
            this.comboboxXRole.Name = "comboboxXRole";
            this.comboboxXRole.Size = new System.Drawing.Size(184, 21);
            this.comboboxXRole.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.comboboxXRole.TabIndex = 11;
            // 
            // labelX8
            // 
            // 
            // 
            // 
            this.labelX8.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX8.Font = new System.Drawing.Font("宋体", 9F);
            this.labelX8.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.labelX8.Location = new System.Drawing.Point(424, 248);
            this.labelX8.Name = "labelX8";
            this.labelX8.Size = new System.Drawing.Size(194, 38);
            this.labelX8.TabIndex = 12;
            this.labelX8.Text = "再次输入与上述密码相同的密码";
            this.labelX8.WordWrap = true;
            // 
            // labelX9
            // 
            // 
            // 
            // 
            this.labelX9.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX9.Font = new System.Drawing.Font("宋体", 9F);
            this.labelX9.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.labelX9.Location = new System.Drawing.Point(424, 301);
            this.labelX9.Name = "labelX9";
            this.labelX9.Size = new System.Drawing.Size(194, 49);
            this.labelX9.TabIndex = 13;
            this.labelX9.Text = "该管理员的权限将根据角色拥有的权限来分配。角色权限在 用户资料-角色分配 里分配";
            this.labelX9.WordWrap = true;
            // 
            // buttonXClose
            // 
            this.buttonXClose.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonXClose.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonXClose.Location = new System.Drawing.Point(440, 400);
            this.buttonXClose.Name = "buttonXClose";
            this.buttonXClose.Size = new System.Drawing.Size(69, 26);
            this.buttonXClose.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonXClose.TabIndex = 14;
            this.buttonXClose.Text = "关闭";
            // 
            // buttonXSave
            // 
            this.buttonXSave.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonXSave.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonXSave.Location = new System.Drawing.Point(537, 400);
            this.buttonXSave.Name = "buttonXSave";
            this.buttonXSave.Size = new System.Drawing.Size(68, 26);
            this.buttonXSave.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonXSave.TabIndex = 15;
            this.buttonXSave.Text = "保存";
            this.buttonXSave.Click += new System.EventHandler(this.buttonXSave_Click);
            // 
            // labelXNameWarning
            // 
            this.labelXNameWarning.BackColor = System.Drawing.SystemColors.WindowFrame;
            // 
            // 
            // 
            this.labelXNameWarning.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelXNameWarning.Font = new System.Drawing.Font("宋体", 9F);
            this.labelXNameWarning.ForeColor = System.Drawing.Color.OrangeRed;
            this.labelXNameWarning.Location = new System.Drawing.Point(186, 175);
            this.labelXNameWarning.Name = "labelXNameWarning";
            this.labelXNameWarning.Size = new System.Drawing.Size(105, 22);
            this.labelXNameWarning.TabIndex = 16;
            this.labelXNameWarning.Text = "*用户名不可为空";
            this.labelXNameWarning.Visible = false;
            // 
            // labelXPwWarning
            // 
            this.labelXPwWarning.BackColor = System.Drawing.SystemColors.WindowFrame;
            // 
            // 
            // 
            this.labelXPwWarning.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelXPwWarning.Font = new System.Drawing.Font("宋体", 9F);
            this.labelXPwWarning.ForeColor = System.Drawing.Color.OrangeRed;
            this.labelXPwWarning.Location = new System.Drawing.Point(186, 230);
            this.labelXPwWarning.Name = "labelXPwWarning";
            this.labelXPwWarning.Size = new System.Drawing.Size(105, 22);
            this.labelXPwWarning.TabIndex = 17;
            this.labelXPwWarning.Text = "*密码不可为空";
            this.labelXPwWarning.Visible = false;
            // 
            // labelXPwAWarning
            // 
            this.labelXPwAWarning.BackColor = System.Drawing.SystemColors.WindowFrame;
            // 
            // 
            // 
            this.labelXPwAWarning.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelXPwAWarning.Font = new System.Drawing.Font("宋体", 9F);
            this.labelXPwAWarning.ForeColor = System.Drawing.Color.OrangeRed;
            this.labelXPwAWarning.Location = new System.Drawing.Point(186, 282);
            this.labelXPwAWarning.Name = "labelXPwAWarning";
            this.labelXPwAWarning.Size = new System.Drawing.Size(135, 22);
            this.labelXPwAWarning.TabIndex = 18;
            this.labelXPwAWarning.Text = "*两次输入的密码不一致";
            this.labelXPwAWarning.Visible = false;
            // 
            // labelXRoleWarning
            // 
            this.labelXRoleWarning.BackColor = System.Drawing.SystemColors.WindowFrame;
            // 
            // 
            // 
            this.labelXRoleWarning.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelXRoleWarning.Font = new System.Drawing.Font("宋体", 9F);
            this.labelXRoleWarning.ForeColor = System.Drawing.Color.OrangeRed;
            this.labelXRoleWarning.Location = new System.Drawing.Point(186, 337);
            this.labelXRoleWarning.Name = "labelXRoleWarning";
            this.labelXRoleWarning.Size = new System.Drawing.Size(105, 22);
            this.labelXRoleWarning.TabIndex = 19;
            this.labelXRoleWarning.Text = "*请选择用户角色";
            this.labelXRoleWarning.Visible = false;
            // 
            // UserCreateForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.ClientSize = new System.Drawing.Size(653, 456);
            this.Controls.Add(this.labelXRoleWarning);
            this.Controls.Add(this.labelXPwAWarning);
            this.Controls.Add(this.labelXPwWarning);
            this.Controls.Add(this.labelXNameWarning);
            this.Controls.Add(this.buttonXSave);
            this.Controls.Add(this.buttonXClose);
            this.Controls.Add(this.labelX9);
            this.Controls.Add(this.labelX8);
            this.Controls.Add(this.comboboxXRole);
            this.Controls.Add(this.labelX6);
            this.Controls.Add(this.textBoxXPasswordAgain);
            this.Controls.Add(this.labelX7);
            this.Controls.Add(this.textBoxXPassword);
            this.Controls.Add(this.labelX5);
            this.Controls.Add(this.labelX4);
            this.Controls.Add(this.textBoxXName);
            this.Controls.Add(this.labelX3);
            this.Controls.Add(this.labelX2);
            this.Controls.Add(this.labelX1);
            this.Controls.Add(this.ribbonControl1);
            this.EnableGlass = false;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "UserCreateForm";
            this.ShowIcon = false;
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.StyleManager styleManager1;
        private DevComponents.DotNetBar.ButtonItem buttonItem1;
        private DevComponents.DotNetBar.RibbonControl ribbonControl1;
        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.DotNetBar.LabelX labelX2;
        private DevComponents.DotNetBar.LabelX labelX3;
        private DevComponents.DotNetBar.Controls.TextBoxX textBoxXName;
        private DevComponents.DotNetBar.LabelX labelX4;
        private DevComponents.DotNetBar.Controls.TextBoxX textBoxXPassword;
        private DevComponents.DotNetBar.LabelX labelX5;
        private DevComponents.DotNetBar.LabelX labelX6;
        private DevComponents.DotNetBar.Controls.TextBoxX textBoxXPasswordAgain;
        private DevComponents.DotNetBar.LabelX labelX7;
        private DevComponents.DotNetBar.Controls.ComboBoxEx comboboxXRole;
        private DevComponents.DotNetBar.LabelX labelX8;
        private DevComponents.DotNetBar.LabelX labelX9;
        private DevComponents.DotNetBar.ButtonX buttonXClose;
        private DevComponents.DotNetBar.ButtonX buttonXSave;
        private DevComponents.DotNetBar.LabelX labelXNameWarning;
        private DevComponents.DotNetBar.LabelX labelXPwWarning;
        private DevComponents.DotNetBar.LabelX labelXPwAWarning;
        private DevComponents.DotNetBar.LabelX labelXRoleWarning;
    }
}