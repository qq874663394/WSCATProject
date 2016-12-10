namespace WSCATProject.Base.Department
{
    partial class InDepartment
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
            this.tabItem2 = new DevComponents.DotNetBar.TabItem(this.components);
            this.tabControlPanel1 = new DevComponents.DotNetBar.TabControlPanel();
            this.comboBoxEx1 = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.label6 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxXName = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.label1 = new System.Windows.Forms.Label();
            this.tabControl1 = new DevComponents.DotNetBar.TabControl();
            this.tabItem1 = new DevComponents.DotNetBar.TabItem(this.components);
            this.buttonX3 = new DevComponents.DotNetBar.ButtonX();
            this.buttonX2 = new DevComponents.DotNetBar.ButtonX();
            this.panel1 = new System.Windows.Forms.Panel();
            this.buttonX1 = new DevComponents.DotNetBar.ButtonX();
            this.tabControlPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tabControl1)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabItem2
            // 
            this.tabItem2.AttachedControl = this.tabControlPanel1;
            this.tabItem2.Name = "tabItem2";
            this.tabItem2.Text = "基本信息";
            // 
            // tabControlPanel1
            // 
            this.tabControlPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2010;
            this.tabControlPanel1.Controls.Add(this.comboBoxEx1);
            this.tabControlPanel1.Controls.Add(this.label6);
            this.tabControlPanel1.Controls.Add(this.label3);
            this.tabControlPanel1.Controls.Add(this.textBoxXName);
            this.tabControlPanel1.Controls.Add(this.label1);
            this.tabControlPanel1.DisabledBackColor = System.Drawing.Color.Empty;
            this.tabControlPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlPanel1.Location = new System.Drawing.Point(0, 26);
            this.tabControlPanel1.Name = "tabControlPanel1";
            this.tabControlPanel1.Padding = new System.Windows.Forms.Padding(1);
            this.tabControlPanel1.Size = new System.Drawing.Size(501, 116);
            this.tabControlPanel1.Style.BackColor1.Color = System.Drawing.Color.PowderBlue;
            this.tabControlPanel1.Style.BackColor2.Color = System.Drawing.Color.Azure;
            this.tabControlPanel1.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.tabControlPanel1.Style.BorderColor.Color = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(157)))), ((int)(((byte)(185)))));
            this.tabControlPanel1.Style.BorderSide = ((DevComponents.DotNetBar.eBorderSide)(((DevComponents.DotNetBar.eBorderSide.Left | DevComponents.DotNetBar.eBorderSide.Right) 
            | DevComponents.DotNetBar.eBorderSide.Bottom)));
            this.tabControlPanel1.Style.GradientAngle = 90;
            this.tabControlPanel1.TabIndex = 0;
            this.tabControlPanel1.TabItem = this.tabItem2;
            // 
            // comboBoxEx1
            // 
            this.comboBoxEx1.DisplayMember = "Text";
            this.comboBoxEx1.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.comboBoxEx1.FormattingEnabled = true;
            this.comboBoxEx1.ItemHeight = 15;
            this.comboBoxEx1.Location = new System.Drawing.Point(355, 39);
            this.comboBoxEx1.Name = "comboBoxEx1";
            this.comboBoxEx1.Size = new System.Drawing.Size(121, 21);
            this.comboBoxEx1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.comboBoxEx1.TabIndex = 12;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.ForeColor = System.Drawing.Color.Red;
            this.label6.Location = new System.Drawing.Point(254, 46);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(11, 12);
            this.label6.TabIndex = 11;
            this.label6.Text = "*";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("宋体", 10F);
            this.label3.Location = new System.Drawing.Point(296, 44);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 14);
            this.label3.TabIndex = 4;
            this.label3.Text = "角色：";
            // 
            // textBoxXName
            // 
            // 
            // 
            // 
            this.textBoxXName.Border.Class = "TextBoxBorder";
            this.textBoxXName.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.textBoxXName.Location = new System.Drawing.Point(107, 40);
            this.textBoxXName.Name = "textBoxXName";
            this.textBoxXName.PreventEnterBeep = true;
            this.textBoxXName.Size = new System.Drawing.Size(144, 21);
            this.textBoxXName.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("宋体", 10F);
            this.label1.Location = new System.Drawing.Point(34, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 14);
            this.label1.TabIndex = 0;
            this.label1.Text = "部门名称：";
            // 
            // tabControl1
            // 
            this.tabControl1.BackColor = System.Drawing.Color.Azure;
            this.tabControl1.CanReorderTabs = true;
            this.tabControl1.ColorScheme.TabBackground = System.Drawing.Color.Azure;
            this.tabControl1.ColorScheme.TabBackground2 = System.Drawing.Color.Azure;
            this.tabControl1.ColorScheme.TabItemBackground = System.Drawing.Color.PowderBlue;
            this.tabControl1.ColorScheme.TabItemBackground2 = System.Drawing.Color.White;
            this.tabControl1.ColorScheme.TabItemBackgroundColorBlend.AddRange(new DevComponents.DotNetBar.BackgroundColorBlend[] {
            new DevComponents.DotNetBar.BackgroundColorBlend(System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(220)))), ((int)(((byte)(244))))), 0F),
            new DevComponents.DotNetBar.BackgroundColorBlend(System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(210)))), ((int)(((byte)(254))))), 0.45F),
            new DevComponents.DotNetBar.BackgroundColorBlend(System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(191)))), ((int)(((byte)(243))))), 0.45F),
            new DevComponents.DotNetBar.BackgroundColorBlend(System.Drawing.Color.FromArgb(((int)(((byte)(181)))), ((int)(((byte)(204)))), ((int)(((byte)(233))))), 1F)});
            this.tabControl1.ColorScheme.TabItemBorder = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(239)))), ((int)(((byte)(226)))));
            this.tabControl1.ColorScheme.TabItemHotBackgroundColorBlend.AddRange(new DevComponents.DotNetBar.BackgroundColorBlend[] {
            new DevComponents.DotNetBar.BackgroundColorBlend(System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(237)))), ((int)(((byte)(255))))), 0F),
            new DevComponents.DotNetBar.BackgroundColorBlend(System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(232)))), ((int)(((byte)(255))))), 0.45F),
            new DevComponents.DotNetBar.BackgroundColorBlend(System.Drawing.Color.FromArgb(((int)(((byte)(176)))), ((int)(((byte)(210)))), ((int)(((byte)(255))))), 0.45F),
            new DevComponents.DotNetBar.BackgroundColorBlend(System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(218)))), ((int)(((byte)(255))))), 1F)});
            this.tabControl1.ColorScheme.TabItemSelectedBackground = System.Drawing.Color.PowderBlue;
            this.tabControl1.ColorScheme.TabItemSelectedBackgroundColorBlend.AddRange(new DevComponents.DotNetBar.BackgroundColorBlend[] {
            new DevComponents.DotNetBar.BackgroundColorBlend(System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(227)))), ((int)(((byte)(217))))), 0F),
            new DevComponents.DotNetBar.BackgroundColorBlend(System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(189)))), ((int)(((byte)(116))))), 0.45F),
            new DevComponents.DotNetBar.BackgroundColorBlend(System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(180)))), ((int)(((byte)(89))))), 0.45F),
            new DevComponents.DotNetBar.BackgroundColorBlend(System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255))))), 1F)});
            this.tabControl1.ColorScheme.TabPanelBackground = System.Drawing.Color.PowderBlue;
            this.tabControl1.Controls.Add(this.tabControlPanel1);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedTabFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold);
            this.tabControl1.SelectedTabIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(501, 142);
            this.tabControl1.Style = DevComponents.DotNetBar.eTabStripStyle.VS2005Document;
            this.tabControl1.TabIndex = 5;
            this.tabControl1.TabLayoutType = DevComponents.DotNetBar.eTabLayoutType.FixedWithNavigationBox;
            this.tabControl1.Tabs.Add(this.tabItem2);
            this.tabControl1.Text = "tabControl1";
            // 
            // tabItem1
            // 
            this.tabItem1.Name = "tabItem1";
            this.tabItem1.Text = "基础资料";
            // 
            // buttonX3
            // 
            this.buttonX3.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX3.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonX3.Location = new System.Drawing.Point(309, 12);
            this.buttonX3.Name = "buttonX3";
            this.buttonX3.Size = new System.Drawing.Size(75, 23);
            this.buttonX3.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonX3.TabIndex = 2;
            this.buttonX3.Text = "保存并退出";
            this.buttonX3.Click += new System.EventHandler(this.buttonX3_Click);
            // 
            // buttonX2
            // 
            this.buttonX2.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX2.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonX2.Location = new System.Drawing.Point(401, 12);
            this.buttonX2.Name = "buttonX2";
            this.buttonX2.Size = new System.Drawing.Size(75, 23);
            this.buttonX2.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonX2.TabIndex = 1;
            this.buttonX2.Text = "保存";
            this.buttonX2.Click += new System.EventHandler(this.buttonX2_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel1.Controls.Add(this.buttonX3);
            this.panel1.Controls.Add(this.buttonX2);
            this.panel1.Controls.Add(this.buttonX1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 142);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(501, 46);
            this.panel1.TabIndex = 4;
            // 
            // buttonX1
            // 
            this.buttonX1.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX1.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonX1.Location = new System.Drawing.Point(212, 12);
            this.buttonX1.Name = "buttonX1";
            this.buttonX1.Size = new System.Drawing.Size(75, 23);
            this.buttonX1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonX1.TabIndex = 0;
            this.buttonX1.Text = "取消";
            this.buttonX1.Click += new System.EventHandler(this.buttonX1_Click);
            // 
            // InDepartment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(501, 188);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.panel1);
            this.Name = "InDepartment";
            this.Text = "部门资料";
            this.Load += new System.EventHandler(this.InDepartment_Load);
            this.tabControlPanel1.ResumeLayout(false);
            this.tabControlPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tabControl1)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.TabItem tabItem2;
        private DevComponents.DotNetBar.TabControlPanel tabControlPanel1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label3;
        private DevComponents.DotNetBar.Controls.TextBoxX textBoxXName;
        private System.Windows.Forms.Label label1;
        private DevComponents.DotNetBar.TabControl tabControl1;
        private DevComponents.DotNetBar.TabItem tabItem1;
        private DevComponents.DotNetBar.ButtonX buttonX3;
        private DevComponents.DotNetBar.ButtonX buttonX2;
        private System.Windows.Forms.Panel panel1;
        private DevComponents.DotNetBar.ButtonX buttonX1;
        private DevComponents.DotNetBar.Controls.ComboBoxEx comboBoxEx1;
    }
}