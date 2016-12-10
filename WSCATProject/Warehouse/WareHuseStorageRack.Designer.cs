namespace WSCATProject.Warehouse
{
    partial class WareHuseStorageRack
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
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.labelX4 = new DevComponents.DotNetBar.LabelX();
            this.cboCangKu = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.comboItem1 = new DevComponents.Editors.ComboItem();
            this.cboQuYu = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.comboItem2 = new DevComponents.Editors.ComboItem();
            this.cboHuoJia = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.comboItem3 = new DevComponents.Editors.ComboItem();
            this.cboPai = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.comboItem4 = new DevComponents.Editors.ComboItem();
            this.btnQueDing = new DevComponents.DotNetBar.ButtonX();
            this.btnCancel = new DevComponents.DotNetBar.ButtonX();
            this.checkBoxX1 = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.labelX5 = new DevComponents.DotNetBar.LabelX();
            this.cboLie = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.comboItem5 = new DevComponents.Editors.ComboItem();
            this.labelX3 = new DevComponents.DotNetBar.LabelX();
            this.SuspendLayout();
            // 
            // labelX1
            // 
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.Location = new System.Drawing.Point(15, 23);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(42, 23);
            this.labelX1.TabIndex = 0;
            this.labelX1.Text = "仓库：";
            // 
            // labelX2
            // 
            // 
            // 
            // 
            this.labelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX2.Location = new System.Drawing.Point(162, 23);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(47, 23);
            this.labelX2.TabIndex = 1;
            this.labelX2.Text = "区域：";
            // 
            // labelX4
            // 
            // 
            // 
            // 
            this.labelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX4.Location = new System.Drawing.Point(467, 23);
            this.labelX4.Name = "labelX4";
            this.labelX4.Size = new System.Drawing.Size(33, 23);
            this.labelX4.TabIndex = 3;
            this.labelX4.Tag = "";
            this.labelX4.Text = "排：";
            // 
            // cboCangKu
            // 
            this.cboCangKu.DisplayMember = "Text";
            this.cboCangKu.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboCangKu.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCangKu.FormattingEnabled = true;
            this.cboCangKu.ItemHeight = 15;
            this.cboCangKu.Items.AddRange(new object[] {
            this.comboItem1});
            this.cboCangKu.Location = new System.Drawing.Point(63, 24);
            this.cboCangKu.Name = "cboCangKu";
            this.cboCangKu.Size = new System.Drawing.Size(85, 21);
            this.cboCangKu.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cboCangKu.TabIndex = 4;
            this.cboCangKu.SelectedValueChanged += new System.EventHandler(this.cboCangKu_SelectedValueChanged);
            // 
            // comboItem1
            // 
            this.comboItem1.Text = "请选择";
            // 
            // cboQuYu
            // 
            this.cboQuYu.DisplayMember = "Text";
            this.cboQuYu.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboQuYu.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboQuYu.FormattingEnabled = true;
            this.cboQuYu.ItemHeight = 15;
            this.cboQuYu.Items.AddRange(new object[] {
            this.comboItem2});
            this.cboQuYu.Location = new System.Drawing.Point(205, 24);
            this.cboQuYu.Name = "cboQuYu";
            this.cboQuYu.Size = new System.Drawing.Size(85, 21);
            this.cboQuYu.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cboQuYu.TabIndex = 5;
            this.cboQuYu.SelectedIndexChanged += new System.EventHandler(this.cboQuYu_SelectedIndexChanged);
            // 
            // comboItem2
            // 
            this.comboItem2.Text = "请选择";
            // 
            // cboHuoJia
            // 
            this.cboHuoJia.DisplayMember = "Text";
            this.cboHuoJia.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboHuoJia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboHuoJia.FormattingEnabled = true;
            this.cboHuoJia.ItemHeight = 15;
            this.cboHuoJia.Items.AddRange(new object[] {
            this.comboItem3});
            this.cboHuoJia.Location = new System.Drawing.Point(360, 24);
            this.cboHuoJia.Name = "cboHuoJia";
            this.cboHuoJia.Size = new System.Drawing.Size(85, 21);
            this.cboHuoJia.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cboHuoJia.TabIndex = 6;
            this.cboHuoJia.SelectedValueChanged += new System.EventHandler(this.cboHuoJia_SelectedValueChanged);
            // 
            // comboItem3
            // 
            this.comboItem3.Text = "请选择";
            // 
            // cboPai
            // 
            this.cboPai.DisplayMember = "Text";
            this.cboPai.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboPai.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPai.FormattingEnabled = true;
            this.cboPai.ItemHeight = 15;
            this.cboPai.Items.AddRange(new object[] {
            this.comboItem4});
            this.cboPai.Location = new System.Drawing.Point(495, 24);
            this.cboPai.Name = "cboPai";
            this.cboPai.Size = new System.Drawing.Size(85, 21);
            this.cboPai.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cboPai.TabIndex = 7;
            this.cboPai.SelectedValueChanged += new System.EventHandler(this.cboPai_SelectedValueChanged);
            // 
            // comboItem4
            // 
            this.comboItem4.Text = "请选择";
            // 
            // btnQueDing
            // 
            this.btnQueDing.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnQueDing.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnQueDing.Location = new System.Drawing.Point(268, 108);
            this.btnQueDing.Name = "btnQueDing";
            this.btnQueDing.Size = new System.Drawing.Size(75, 23);
            this.btnQueDing.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnQueDing.TabIndex = 8;
            this.btnQueDing.Text = "确定";
            this.btnQueDing.Click += new System.EventHandler(this.btnQueDing_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnCancel.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnCancel.Location = new System.Drawing.Point(373, 108);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnCancel.TabIndex = 9;
            this.btnCancel.Text = "取消";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // checkBoxX1
            // 
            // 
            // 
            // 
            this.checkBoxX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.checkBoxX1.Location = new System.Drawing.Point(37, 70);
            this.checkBoxX1.Name = "checkBoxX1";
            this.checkBoxX1.Size = new System.Drawing.Size(100, 23);
            this.checkBoxX1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.checkBoxX1.TabIndex = 10;
            this.checkBoxX1.Text = "临时存放地";
            // 
            // labelX5
            // 
            // 
            // 
            // 
            this.labelX5.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX5.Location = new System.Drawing.Point(607, 23);
            this.labelX5.Name = "labelX5";
            this.labelX5.Size = new System.Drawing.Size(47, 23);
            this.labelX5.TabIndex = 1;
            this.labelX5.Text = "列：";
            // 
            // cboLie
            // 
            this.cboLie.DisplayMember = "Text";
            this.cboLie.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboLie.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLie.FormattingEnabled = true;
            this.cboLie.ItemHeight = 15;
            this.cboLie.Items.AddRange(new object[] {
            this.comboItem5});
            this.cboLie.Location = new System.Drawing.Point(650, 24);
            this.cboLie.Name = "cboLie";
            this.cboLie.Size = new System.Drawing.Size(85, 21);
            this.cboLie.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cboLie.TabIndex = 5;
            // 
            // comboItem5
            // 
            this.comboItem5.Text = "请选择";
            // 
            // labelX3
            // 
            // 
            // 
            // 
            this.labelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX3.Location = new System.Drawing.Point(312, 23);
            this.labelX3.Name = "labelX3";
            this.labelX3.Size = new System.Drawing.Size(42, 23);
            this.labelX3.TabIndex = 2;
            this.labelX3.Text = "货架：";
            // 
            // WareHuseStorageRack
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(753, 146);
            this.Controls.Add(this.checkBoxX1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnQueDing);
            this.Controls.Add(this.cboPai);
            this.Controls.Add(this.cboHuoJia);
            this.Controls.Add(this.cboLie);
            this.Controls.Add(this.cboQuYu);
            this.Controls.Add(this.cboCangKu);
            this.Controls.Add(this.labelX4);
            this.Controls.Add(this.labelX5);
            this.Controls.Add(this.labelX3);
            this.Controls.Add(this.labelX2);
            this.Controls.Add(this.labelX1);
            this.Name = "WareHuseStorageRack";
            this.Text = "仓库";
            this.Activated += new System.EventHandler(this.WareHuseStorageRack_Activated);
            this.Load += new System.EventHandler(this.WareHuseStorageRack_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.DotNetBar.LabelX labelX2;
        private DevComponents.DotNetBar.LabelX labelX4;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cboCangKu;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cboQuYu;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cboHuoJia;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cboPai;
        private DevComponents.DotNetBar.ButtonX btnQueDing;
        private DevComponents.DotNetBar.ButtonX btnCancel;
        private DevComponents.DotNetBar.Controls.CheckBoxX checkBoxX1;
        private DevComponents.Editors.ComboItem comboItem1;
        private DevComponents.Editors.ComboItem comboItem2;
        private DevComponents.Editors.ComboItem comboItem3;
        private DevComponents.Editors.ComboItem comboItem4;
        private DevComponents.DotNetBar.LabelX labelX5;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cboLie;
        private DevComponents.Editors.ComboItem comboItem5;
        private DevComponents.DotNetBar.LabelX labelX3;
    }
}