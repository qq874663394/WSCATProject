namespace WSCATProject.Purchase
{
    partial class PurchasePaymentForm
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
            DevComponents.DotNetBar.SuperGrid.Style.Background background1 = new DevComponents.DotNetBar.SuperGrid.Style.Background();
            DevComponents.DotNetBar.SuperGrid.Style.Background background2 = new DevComponents.DotNetBar.SuperGrid.Style.Background();
            DevComponents.DotNetBar.SuperGrid.Style.Background background3 = new DevComponents.DotNetBar.SuperGrid.Style.Background();
            DevComponents.DotNetBar.SuperGrid.Style.Background background4 = new DevComponents.DotNetBar.SuperGrid.Style.Background();
            DevComponents.DotNetBar.SuperGrid.Style.Background background5 = new DevComponents.DotNetBar.SuperGrid.Style.Background();
            DevComponents.DotNetBar.SuperGrid.Style.Background background6 = new DevComponents.DotNetBar.SuperGrid.Style.Background();
            DevComponents.DotNetBar.SuperGrid.Style.Background background8 = new DevComponents.DotNetBar.SuperGrid.Style.Background();
            DevComponents.DotNetBar.SuperGrid.Style.Background background7 = new DevComponents.DotNetBar.SuperGrid.Style.Background();
            this.picBarCode = new System.Windows.Forms.PictureBox();
            this.cboType = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.comboItem1 = new DevComponents.Editors.ComboItem();
            this.comboItem2 = new DevComponents.Editors.ComboItem();
            this.comboItem3 = new DevComponents.Editors.ComboItem();
            this.cboMethod = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.comboItem4 = new DevComponents.Editors.ComboItem();
            this.comboItem5 = new DevComponents.Editors.ComboItem();
            this.comboItem6 = new DevComponents.Editors.ComboItem();
            this.comboItem7 = new DevComponents.Editors.ComboItem();
            this.comboItem8 = new DevComponents.Editors.ComboItem();
            this.BillCode = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            this.BillDate = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            this.BillType = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            this.BillMoney = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            this.yiHeXiao = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            this.weiHeXiao = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            this.benciHeXiao = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            this.remark = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            this.shengyuMoney = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            this.pictureBoxShengHe = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxDanJuType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxClose)).BeginInit();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxEmployee)).BeginInit();
            this.resizablePanelData.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxtitle)).BeginInit();
            this.panel3.SuspendLayout();
            this.resizablePanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxMax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxMin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBarCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxShengHe)).BeginInit();
            this.SuspendLayout();
            // 
            // textBoxOddNumbers
            // 
            this.textBoxOddNumbers.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxOddNumbers.ForeColor = System.Drawing.Color.Gray;
            this.textBoxOddNumbers.Size = new System.Drawing.Size(137, 14);
            // 
            // labelprie
            // 
            this.labelprie.Location = new System.Drawing.Point(1020, 11);
            this.labelprie.Size = new System.Drawing.Size(29, 12);
            this.labelprie.Text = "单号";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(1053, 80);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.pictureBoxShengHe);
            this.panel1.Controls.SetChildIndex(this.pictureBoxtitle, 0);
            this.panel1.Controls.SetChildIndex(this.labelTitle, 0);
            this.panel1.Controls.SetChildIndex(this.pictureBoxMax, 0);
            this.panel1.Controls.SetChildIndex(this.pictureBoxMin, 0);
            this.panel1.Controls.SetChildIndex(this.pictureBoxClose, 0);
            this.panel1.Controls.SetChildIndex(this.pictureBoxShengHe, 0);
            // 
            // labelTitle
            // 
            this.labelTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(177)))), ((int)(((byte)(238)))));
            // 
            // 
            // 
            this.labelTitle.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelTitle.Size = new System.Drawing.Size(150, 30);
            this.labelTitle.Text = "付    款    单";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.cboMethod);
            this.panel2.Controls.Add(this.cboType);
            this.panel2.Controls.Add(this.picBarCode);
            this.panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
            this.panel2.Controls.SetChildIndex(this.labtextboxBotton2, 0);
            this.panel2.Controls.SetChildIndex(this.labBotton2, 0);
            this.panel2.Controls.SetChildIndex(this.labTop1, 0);
            this.panel2.Controls.SetChildIndex(this.labTop2, 0);
            this.panel2.Controls.SetChildIndex(this.labTop3, 0);
            this.panel2.Controls.SetChildIndex(this.labTop4, 0);
            this.panel2.Controls.SetChildIndex(this.labTop5, 0);
            this.panel2.Controls.SetChildIndex(this.labTop6, 0);
            this.panel2.Controls.SetChildIndex(this.labTop7, 0);
            this.panel2.Controls.SetChildIndex(this.labTop8, 0);
            this.panel2.Controls.SetChildIndex(this.labTop9, 0);
            this.panel2.Controls.SetChildIndex(this.pictureBoxDanJuType, 0);
            this.panel2.Controls.SetChildIndex(this.checkBox1, 0);
            this.panel2.Controls.SetChildIndex(this.pictureBox2, 0);
            this.panel2.Controls.SetChildIndex(this.pictureBox3, 0);
            this.panel2.Controls.SetChildIndex(this.pictureBox4, 0);
            this.panel2.Controls.SetChildIndex(this.labtxtDanJuType, 0);
            this.panel2.Controls.SetChildIndex(this.labtextboxTop2, 0);
            this.panel2.Controls.SetChildIndex(this.labtextboxTop4, 0);
            this.panel2.Controls.SetChildIndex(this.labtextboxTop5, 0);
            this.panel2.Controls.SetChildIndex(this.labelprie, 0);
            this.panel2.Controls.SetChildIndex(this.textBoxOddNumbers, 0);
            this.panel2.Controls.SetChildIndex(this.labtextboxTop8, 0);
            this.panel2.Controls.SetChildIndex(this.labtextboxTop9, 0);
            this.panel2.Controls.SetChildIndex(this.labtextboxTop7, 0);
            this.panel2.Controls.SetChildIndex(this.labtextboxTop3, 0);
            this.panel2.Controls.SetChildIndex(this.labtextboxTop6, 0);
            this.panel2.Controls.SetChildIndex(this.picBarCode, 0);
            this.panel2.Controls.SetChildIndex(this.cboType, 0);
            this.panel2.Controls.SetChildIndex(this.cboMethod, 0);
            // 
            // labtextboxTop6
            // 
            this.labtextboxTop6.BackColor = System.Drawing.SystemColors.ControlLightLight;
            // 
            // 
            // 
            this.labtextboxTop6.Border.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.labtextboxTop6.Border.BorderBottomColor = System.Drawing.Color.Black;
            this.labtextboxTop6.Border.BorderBottomWidth = 1;
            this.labtextboxTop6.Border.BorderGradientAngle = 0;
            this.labtextboxTop6.Border.Class = "SideNavStrip";
            this.labtextboxTop6.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labtextboxTop6.FocusHighlightColor = System.Drawing.Color.AliceBlue;
            this.labtextboxTop6.FocusHighlightEnabled = true;
            this.labtextboxTop6.ForeColor = System.Drawing.Color.Gray;
            this.labtextboxTop6.MaxLength = 12;
            this.labtextboxTop6.ReadOnly = true;
            this.labtextboxTop6.Size = new System.Drawing.Size(150, 16);
            this.labtextboxTop6.Text = "0.00";
            this.labtextboxTop6.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.labtextboxTop6.TextChanged += new System.EventHandler(this.txtBenCiShouKuan_TextChanged);
            // 
            // labtextboxTop3
            // 
            this.labtextboxTop3.BackColor = System.Drawing.SystemColors.ControlLightLight;
            // 
            // 
            // 
            this.labtextboxTop3.Border.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.labtextboxTop3.Border.BorderBottomColor = System.Drawing.Color.Black;
            this.labtextboxTop3.Border.BorderBottomWidth = 1;
            this.labtextboxTop3.Border.BorderGradientAngle = 0;
            this.labtextboxTop3.Border.Class = "SideNavStrip";
            this.labtextboxTop3.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labtextboxTop3.FocusHighlightColor = System.Drawing.Color.AliceBlue;
            this.labtextboxTop3.FocusHighlightEnabled = true;
            this.labtextboxTop3.ForeColor = System.Drawing.Color.Gray;
            this.labtextboxTop3.Location = new System.Drawing.Point(91, 47);
            this.labtextboxTop3.MaxLength = 12;
            this.labtextboxTop3.ReadOnly = true;
            this.labtextboxTop3.Size = new System.Drawing.Size(150, 16);
            this.labtextboxTop3.Text = "0.00";
            this.labtextboxTop3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.labtextboxTop3.TextChanged += new System.EventHandler(this.txtBenCiHeXiao_TextChanged);
            // 
            // labtextboxTop7
            // 
            // 
            // 
            // 
            this.labtextboxTop7.Border.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.labtextboxTop7.Border.BorderBottomColor = System.Drawing.Color.Black;
            this.labtextboxTop7.Border.BorderBottomWidth = 1;
            this.labtextboxTop7.Border.BorderGradientAngle = 0;
            this.labtextboxTop7.Border.Class = "SideNavStrip";
            this.labtextboxTop7.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labtextboxTop7.FocusHighlightColor = System.Drawing.Color.AliceBlue;
            this.labtextboxTop7.FocusHighlightEnabled = true;
            this.labtextboxTop7.Location = new System.Drawing.Point(411, 76);
            this.labtextboxTop7.MaxLength = 12;
            this.labtextboxTop7.Size = new System.Drawing.Size(150, 16);
            this.labtextboxTop7.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.labtextboxTop7.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDiscount_KeyPress);
            this.labtextboxTop7.Validated += new System.EventHandler(this.txtDiscount_Validated);
            // 
            // labtextboxTop9
            // 
            // 
            // 
            // 
            this.labtextboxTop9.Border.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.labtextboxTop9.Border.BorderBottomColor = System.Drawing.Color.Black;
            this.labtextboxTop9.Border.BorderBottomWidth = 1;
            this.labtextboxTop9.Border.BorderGradientAngle = 0;
            this.labtextboxTop9.Border.Class = "SideNavStrip";
            this.labtextboxTop9.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labtextboxTop9.Location = new System.Drawing.Point(888, 111);
            this.labtextboxTop9.Visible = false;
            // 
            // labtextboxTop8
            // 
            // 
            // 
            // 
            this.labtextboxTop8.Border.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.labtextboxTop8.Border.BorderBottomColor = System.Drawing.Color.Black;
            this.labtextboxTop8.Border.BorderBottomWidth = 1;
            this.labtextboxTop8.Border.BorderGradientAngle = 0;
            this.labtextboxTop8.Border.Class = "SideNavStrip";
            this.labtextboxTop8.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labtextboxTop8.Location = new System.Drawing.Point(650, 111);
            this.labtextboxTop8.Visible = false;
            // 
            // labtextboxTop5
            // 
            // 
            // 
            // 
            this.labtextboxTop5.Border.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.labtextboxTop5.Border.BorderBottomColor = System.Drawing.Color.Black;
            this.labtextboxTop5.Border.BorderBottomWidth = 1;
            this.labtextboxTop5.Border.BorderGradientAngle = 0;
            this.labtextboxTop5.Border.Class = "SideNavStrip";
            this.labtextboxTop5.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labtextboxTop5.Location = new System.Drawing.Point(726, 47);
            this.labtextboxTop5.Size = new System.Drawing.Size(150, 16);
            this.labtextboxTop5.Visible = false;
            // 
            // labtextboxTop4
            // 
            // 
            // 
            // 
            this.labtextboxTop4.Border.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.labtextboxTop4.Border.BorderBottomColor = System.Drawing.Color.Black;
            this.labtextboxTop4.Border.BorderBottomWidth = 1;
            this.labtextboxTop4.Border.BorderGradientAngle = 0;
            this.labtextboxTop4.Border.Class = "SideNavStrip";
            this.labtextboxTop4.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labtextboxTop4.FocusHighlightColor = System.Drawing.Color.AliceBlue;
            this.labtextboxTop4.FocusHighlightEnabled = true;
            this.labtextboxTop4.Location = new System.Drawing.Point(411, 47);
            this.labtextboxTop4.Size = new System.Drawing.Size(130, 16);
            this.labtextboxTop4.TextChanged += new System.EventHandler(this.txtBank_TextChanged);
            // 
            // labtextboxTop2
            // 
            // 
            // 
            // 
            this.labtextboxTop2.Border.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.labtextboxTop2.Border.BorderBottomColor = System.Drawing.Color.Black;
            this.labtextboxTop2.Border.BorderBottomWidth = 1;
            this.labtextboxTop2.Border.BorderGradientAngle = 0;
            this.labtextboxTop2.Border.Class = "SideNavStrip";
            this.labtextboxTop2.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labtextboxTop2.FocusHighlightColor = System.Drawing.Color.AliceBlue;
            this.labtextboxTop2.FocusHighlightEnabled = true;
            this.labtextboxTop2.Location = new System.Drawing.Point(411, 16);
            this.labtextboxTop2.Size = new System.Drawing.Size(130, 16);
            this.labtextboxTop2.TextChanged += new System.EventHandler(this.txtSupply_TextChanged);
            // 
            // labtxtDanJuType
            // 
            // 
            // 
            // 
            this.labtxtDanJuType.Border.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.labtxtDanJuType.Border.BorderBottomColor = System.Drawing.Color.Black;
            this.labtxtDanJuType.Border.BorderBottomWidth = 1;
            this.labtxtDanJuType.Border.BorderGradientAngle = 0;
            this.labtxtDanJuType.Border.Class = "SideNavStrip";
            this.labtxtDanJuType.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labtxtDanJuType.Visible = false;
            // 
            // pictureBox4
            // 
            this.pictureBox4.Visible = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Location = new System.Drawing.Point(542, 46);
            this.pictureBox3.Click += new System.EventHandler(this.pictureBoxBank_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Location = new System.Drawing.Point(542, 12);
            this.pictureBox2.Click += new System.EventHandler(this.pictureBoxSupply_Click);
            // 
            // checkBox1
            // 
            this.checkBox1.Location = new System.Drawing.Point(199, 50);
            this.checkBox1.Visible = false;
            // 
            // pictureBoxDanJuType
            // 
            this.pictureBoxDanJuType.Visible = false;
            // 
            // labTop9
            // 
            this.labTop9.Location = new System.Drawing.Point(831, 113);
            this.labTop9.Visible = false;
            // 
            // labTop8
            // 
            this.labTop8.Location = new System.Drawing.Point(591, 111);
            this.labTop8.Visible = false;
            // 
            // labTop7
            // 
            this.labTop7.Location = new System.Drawing.Point(347, 79);
            this.labTop7.Text = "本单折扣：";
            // 
            // labTop6
            // 
            this.labTop6.Text = "本次付款：";
            // 
            // labTop5
            // 
            this.labTop5.Location = new System.Drawing.Point(667, 50);
            this.labTop5.Text = "结算方式：";
            // 
            // labTop4
            // 
            this.labTop4.Location = new System.Drawing.Point(347, 50);
            this.labTop4.Size = new System.Drawing.Size(71, 12);
            this.labTop4.Text = "结算账户*：";
            // 
            // labTop3
            // 
            this.labTop3.Location = new System.Drawing.Point(34, 49);
            this.labTop3.Text = "本次核销：";
            // 
            // labTop2
            // 
            this.labTop2.Location = new System.Drawing.Point(347, 18);
            this.labTop2.Size = new System.Drawing.Size(71, 12);
            this.labTop2.Text = "供 应 商*：";
            // 
            // pictureBoxClose
            // 
            this.pictureBoxClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(177)))), ((int)(((byte)(238)))));
            // 
            // panel5
            // 
            this.panel5.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
            // 
            // pictureBoxEmployee
            // 
            this.pictureBoxEmployee.Location = new System.Drawing.Point(227, 14);
            this.pictureBoxEmployee.Click += new System.EventHandler(this.pictureBoxEmployee_Click);
            // 
            // ltxtbShengHeMan
            // 
            // 
            // 
            // 
            this.ltxtbShengHeMan.Border.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.ltxtbShengHeMan.Border.BorderBottomColor = System.Drawing.Color.Black;
            this.ltxtbShengHeMan.Border.BorderBottomWidth = 1;
            this.ltxtbShengHeMan.Border.BorderGradientAngle = 0;
            this.ltxtbShengHeMan.Border.Class = "SideNavStrip";
            this.ltxtbShengHeMan.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.ltxtbShengHeMan.FocusHighlightColor = System.Drawing.Color.AliceBlue;
            this.ltxtbShengHeMan.FocusHighlightEnabled = true;
            this.ltxtbShengHeMan.Location = new System.Drawing.Point(726, 21);
            this.ltxtbShengHeMan.Size = new System.Drawing.Size(150, 16);
            // 
            // ltxtbMakeMan
            // 
            // 
            // 
            // 
            this.ltxtbMakeMan.Border.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.ltxtbMakeMan.Border.BorderBottomColor = System.Drawing.Color.Black;
            this.ltxtbMakeMan.Border.BorderBottomWidth = 1;
            this.ltxtbMakeMan.Border.BorderGradientAngle = 0;
            this.ltxtbMakeMan.Border.Class = "SideNavStrip";
            this.ltxtbMakeMan.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.ltxtbMakeMan.FocusHighlightColor = System.Drawing.Color.AliceBlue;
            this.ltxtbMakeMan.FocusHighlightEnabled = true;
            this.ltxtbMakeMan.Location = new System.Drawing.Point(411, 21);
            this.ltxtbMakeMan.Size = new System.Drawing.Size(150, 16);
            // 
            // labtextboxBotton2
            // 
            // 
            // 
            // 
            this.labtextboxBotton2.Border.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.labtextboxBotton2.Border.BorderBottomColor = System.Drawing.Color.Black;
            this.labtextboxBotton2.Border.BorderBottomWidth = 1;
            this.labtextboxBotton2.Border.BorderGradientAngle = 0;
            this.labtextboxBotton2.Border.Class = "SideNavStrip";
            this.labtextboxBotton2.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labtextboxBotton2.FocusHighlightColor = System.Drawing.Color.AliceBlue;
            this.labtextboxBotton2.FocusHighlightEnabled = true;
            this.labtextboxBotton2.Location = new System.Drawing.Point(726, 76);
            this.labtextboxBotton2.Size = new System.Drawing.Size(150, 16);
            // 
            // ltxtbSalsMan
            // 
            // 
            // 
            // 
            this.ltxtbSalsMan.Border.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.ltxtbSalsMan.Border.BorderBottomColor = System.Drawing.Color.Black;
            this.ltxtbSalsMan.Border.BorderBottomWidth = 1;
            this.ltxtbSalsMan.Border.BorderGradientAngle = 0;
            this.ltxtbSalsMan.Border.Class = "SideNavStrip";
            this.ltxtbSalsMan.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.ltxtbSalsMan.FocusHighlightColor = System.Drawing.Color.AliceBlue;
            this.ltxtbSalsMan.FocusHighlightEnabled = true;
            this.ltxtbSalsMan.Location = new System.Drawing.Point(97, 19);
            this.ltxtbSalsMan.TextChanged += new System.EventHandler(this.ltxtbSalsMan_TextChanged);
            // 
            // labBotton4
            // 
            this.labBotton4.Location = new System.Drawing.Point(669, 23);
            // 
            // labBotton2
            // 
            this.labBotton2.Location = new System.Drawing.Point(669, 79);
            // 
            // labBotton3
            // 
            this.labBotton3.Location = new System.Drawing.Point(347, 23);
            // 
            // labBotton1
            // 
            this.labBotton1.Size = new System.Drawing.Size(59, 12);
            this.labBotton1.Text = "付款员*：";
            // 
            // resizablePanelData
            // 
            this.resizablePanelData.Location = new System.Drawing.Point(517, 274);
            // 
            // labeldata
            // 
            this.labeldata.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labeldata.Location = new System.Drawing.Point(1008, 84);
            // 
            // bar1
            // 
            this.bar1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(177)))), ((int)(((byte)(238)))));
            // 
            // superGridControlShangPing
            // 
            this.superGridControlShangPing.FilterExprColors.SysFunction = System.Drawing.Color.DarkRed;
            // 
            // 
            // 
            this.superGridControlShangPing.PrimaryGrid.Columns.Add(this.BillCode);
            this.superGridControlShangPing.PrimaryGrid.Columns.Add(this.BillDate);
            this.superGridControlShangPing.PrimaryGrid.Columns.Add(this.BillType);
            this.superGridControlShangPing.PrimaryGrid.Columns.Add(this.BillMoney);
            this.superGridControlShangPing.PrimaryGrid.Columns.Add(this.yiHeXiao);
            this.superGridControlShangPing.PrimaryGrid.Columns.Add(this.weiHeXiao);
            this.superGridControlShangPing.PrimaryGrid.Columns.Add(this.benciHeXiao);
            this.superGridControlShangPing.PrimaryGrid.Columns.Add(this.shengyuMoney);
            this.superGridControlShangPing.PrimaryGrid.Columns.Add(this.remark);
            this.superGridControlShangPing.PrimaryGrid.FrozenColumnCount = 2;
            this.superGridControlShangPing.PrimaryGrid.RowHeaderIndexOffset = 1;
            this.superGridControlShangPing.PrimaryGrid.ShowInsertRow = true;
            this.superGridControlShangPing.CellValidated += new System.EventHandler<DevComponents.DotNetBar.SuperGrid.GridCellValidatedEventArgs>(this.superGridControlShangPing_CellValidated);
            this.superGridControlShangPing.KeyDown += new System.Windows.Forms.KeyEventHandler(this.superGridControlShangPing_KeyDown);
            // 
            // resizablePanel1
            // 
            this.resizablePanel1.Location = new System.Drawing.Point(95, 279);
            // 
            // pictureBoxMax
            // 
            this.pictureBoxMax.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(177)))), ((int)(((byte)(238)))));
            // 
            // pictureBoxMin
            // 
            this.pictureBoxMin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(177)))), ((int)(((byte)(238)))));
            // 
            // picBarCode
            // 
            this.picBarCode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.picBarCode.Location = new System.Drawing.Point(1052, 9);
            this.picBarCode.Name = "picBarCode";
            this.picBarCode.Size = new System.Drawing.Size(137, 70);
            this.picBarCode.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picBarCode.TabIndex = 53;
            this.picBarCode.TabStop = false;
            // 
            // cboType
            // 
            this.cboType.DisplayMember = "Text";
            this.cboType.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboType.FocusHighlightColor = System.Drawing.Color.AliceBlue;
            this.cboType.FocusHighlightEnabled = true;
            this.cboType.FormattingEnabled = true;
            this.cboType.ItemHeight = 15;
            this.cboType.Items.AddRange(new object[] {
            this.comboItem1,
            this.comboItem2,
            this.comboItem3});
            this.cboType.Location = new System.Drawing.Point(91, 12);
            this.cboType.Name = "cboType";
            this.cboType.Size = new System.Drawing.Size(150, 21);
            this.cboType.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cboType.TabIndex = 54;
            this.cboType.SelectedIndexChanged += new System.EventHandler(this.cboType_SelectedIndexChanged);
            // 
            // comboItem1
            // 
            this.comboItem1.Text = "采购付款";
            // 
            // comboItem2
            // 
            this.comboItem2.Text = "预付款";
            // 
            // comboItem3
            // 
            this.comboItem3.Text = "预付退款";
            // 
            // cboMethod
            // 
            this.cboMethod.DisplayMember = "Text";
            this.cboMethod.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboMethod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMethod.FocusHighlightColor = System.Drawing.Color.AliceBlue;
            this.cboMethod.FocusHighlightEnabled = true;
            this.cboMethod.FormattingEnabled = true;
            this.cboMethod.ItemHeight = 15;
            this.cboMethod.Items.AddRange(new object[] {
            this.comboItem4,
            this.comboItem5,
            this.comboItem6,
            this.comboItem7,
            this.comboItem8});
            this.cboMethod.Location = new System.Drawing.Point(726, 46);
            this.cboMethod.Name = "cboMethod";
            this.cboMethod.Size = new System.Drawing.Size(150, 21);
            this.cboMethod.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cboMethod.TabIndex = 55;
            // 
            // comboItem4
            // 
            this.comboItem4.Text = "现金";
            // 
            // comboItem5
            // 
            this.comboItem5.Text = "电汇";
            // 
            // comboItem6
            // 
            this.comboItem6.Text = "信汇";
            // 
            // comboItem7
            // 
            this.comboItem7.Text = "商业汇票";
            // 
            // comboItem8
            // 
            this.comboItem8.Text = "银行汇票";
            // 
            // BillCode
            // 
            this.BillCode.AllowSelection = false;
            this.BillCode.AutoSizeMode = DevComponents.DotNetBar.SuperGrid.ColumnAutoSizeMode.Fill;
            background1.Color1 = System.Drawing.Color.Azure;
            this.BillCode.CellStyles.Default.Background = background1;
            this.BillCode.ColumnSortMode = DevComponents.DotNetBar.SuperGrid.ColumnSortMode.None;
            this.BillCode.HeaderText = "源单编号";
            this.BillCode.Name = "BillCode";
            this.BillCode.ReadOnly = true;
            // 
            // BillDate
            // 
            this.BillDate.AllowSelection = false;
            this.BillDate.AutoSizeMode = DevComponents.DotNetBar.SuperGrid.ColumnAutoSizeMode.Fill;
            background2.Color1 = System.Drawing.Color.Azure;
            this.BillDate.CellStyles.Default.Background = background2;
            this.BillDate.ColumnSortMode = DevComponents.DotNetBar.SuperGrid.ColumnSortMode.None;
            this.BillDate.EnableFiltering = DevComponents.DotNetBar.SuperGrid.Style.Tbool.False;
            this.BillDate.HeaderText = "源单日期";
            this.BillDate.Name = "BillDate";
            this.BillDate.ReadOnly = true;
            this.BillDate.ToolTip = "";
            // 
            // BillType
            // 
            this.BillType.AllowSelection = false;
            this.BillType.AutoSizeMode = DevComponents.DotNetBar.SuperGrid.ColumnAutoSizeMode.Fill;
            background3.Color1 = System.Drawing.Color.Azure;
            this.BillType.CellStyles.Default.Background = background3;
            this.BillType.ColumnSortMode = DevComponents.DotNetBar.SuperGrid.ColumnSortMode.None;
            this.BillType.HeaderText = "源单类型";
            this.BillType.Name = "BillType";
            this.BillType.ReadOnly = true;
            // 
            // BillMoney
            // 
            this.BillMoney.AllowSelection = false;
            this.BillMoney.AutoSizeMode = DevComponents.DotNetBar.SuperGrid.ColumnAutoSizeMode.Fill;
            background4.Color1 = System.Drawing.Color.Azure;
            this.BillMoney.CellStyles.Default.Background = background4;
            this.BillMoney.ColumnSortMode = DevComponents.DotNetBar.SuperGrid.ColumnSortMode.None;
            this.BillMoney.EditorType = typeof(DevComponents.DotNetBar.SuperGrid.GridDoubleInputEditControl);
            this.BillMoney.HeaderText = "单据金额";
            this.BillMoney.Name = "BillMoney";
            this.BillMoney.ReadOnly = true;
            // 
            // yiHeXiao
            // 
            this.yiHeXiao.AllowSelection = false;
            this.yiHeXiao.AutoSizeMode = DevComponents.DotNetBar.SuperGrid.ColumnAutoSizeMode.Fill;
            background5.Color1 = System.Drawing.Color.Azure;
            this.yiHeXiao.CellStyles.Default.Background = background5;
            this.yiHeXiao.ColumnSortMode = DevComponents.DotNetBar.SuperGrid.ColumnSortMode.None;
            this.yiHeXiao.EditorType = typeof(DevComponents.DotNetBar.SuperGrid.GridDoubleInputEditControl);
            this.yiHeXiao.HeaderText = "已核销金额";
            this.yiHeXiao.Name = "yiHeXiao";
            this.yiHeXiao.ReadOnly = true;
            // 
            // weiHeXiao
            // 
            this.weiHeXiao.AllowSelection = false;
            this.weiHeXiao.AutoSizeMode = DevComponents.DotNetBar.SuperGrid.ColumnAutoSizeMode.Fill;
            background6.Color1 = System.Drawing.Color.Azure;
            this.weiHeXiao.CellStyles.Default.Background = background6;
            this.weiHeXiao.ColumnSortMode = DevComponents.DotNetBar.SuperGrid.ColumnSortMode.None;
            this.weiHeXiao.EditorType = typeof(DevComponents.DotNetBar.SuperGrid.GridDoubleInputEditControl);
            this.weiHeXiao.HeaderText = "未核销金额";
            this.weiHeXiao.Name = "weiHeXiao";
            this.weiHeXiao.ReadOnly = true;
            // 
            // benciHeXiao
            // 
            this.benciHeXiao.AutoSizeMode = DevComponents.DotNetBar.SuperGrid.ColumnAutoSizeMode.Fill;
            this.benciHeXiao.ColumnSortMode = DevComponents.DotNetBar.SuperGrid.ColumnSortMode.None;
            this.benciHeXiao.EditorType = typeof(DevComponents.DotNetBar.SuperGrid.GridDoubleInputEditControl);
            this.benciHeXiao.HeaderText = "本次核销";
            this.benciHeXiao.Name = "benciHeXiao";
            // 
            // remark
            // 
            this.remark.AllowSelection = false;
            this.remark.AutoSizeMode = DevComponents.DotNetBar.SuperGrid.ColumnAutoSizeMode.Fill;
            background8.Color1 = System.Drawing.Color.Azure;
            this.remark.CellStyles.Default.Background = background8;
            this.remark.ColumnSortMode = DevComponents.DotNetBar.SuperGrid.ColumnSortMode.None;
            this.remark.HeaderText = "备注";
            this.remark.Name = "remark";
            this.remark.ReadOnly = true;
            // 
            // shengyuMoney
            // 
            this.shengyuMoney.AllowSelection = false;
            this.shengyuMoney.AutoSizeMode = DevComponents.DotNetBar.SuperGrid.ColumnAutoSizeMode.Fill;
            background7.Color1 = System.Drawing.Color.Azure;
            this.shengyuMoney.CellStyles.Default.Background = background7;
            this.shengyuMoney.ColumnSortMode = DevComponents.DotNetBar.SuperGrid.ColumnSortMode.None;
            this.shengyuMoney.EditorType = typeof(DevComponents.DotNetBar.SuperGrid.GridDoubleInputEditControl);
            this.shengyuMoney.HeaderText = "剩余尾款";
            this.shengyuMoney.Name = "shengyuMoney";
            this.shengyuMoney.ReadOnly = true;
            // 
            // pictureBoxShengHe
            // 
            this.pictureBoxShengHe.BackColor = System.Drawing.Color.Transparent;
            this.pictureBoxShengHe.Image = global::WSCATProject.Properties.Resources.审核;
            this.pictureBoxShengHe.Location = new System.Drawing.Point(692, 3);
            this.pictureBoxShengHe.Name = "pictureBoxShengHe";
            this.pictureBoxShengHe.Size = new System.Drawing.Size(64, 64);
            this.pictureBoxShengHe.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBoxShengHe.TabIndex = 46;
            this.pictureBoxShengHe.TabStop = false;
            this.pictureBoxShengHe.Visible = false;
            // 
            // PurchasePaymentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1202, 690);
            this.Name = "PurchasePaymentForm";
            this.Text = "付款单";
            this.Activated += new System.EventHandler(this.PurchasePaymentForm_Activated);
            this.Load += new System.EventHandler(this.PurchasePaymentForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.PurchasePaymentForm_KeyDown);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.PurchasePaymentForm_KeyPress);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxDanJuType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxClose)).EndInit();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxEmployee)).EndInit();
            this.resizablePanelData.ResumeLayout(false);
            this.resizablePanelData.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxtitle)).EndInit();
            this.panel3.ResumeLayout(false);
            this.resizablePanel1.ResumeLayout(false);
            this.resizablePanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxMax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxMin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBarCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxShengHe)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picBarCode;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cboType;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cboMethod;
        private DevComponents.Editors.ComboItem comboItem4;
        private DevComponents.Editors.ComboItem comboItem5;
        private DevComponents.Editors.ComboItem comboItem6;
        private DevComponents.Editors.ComboItem comboItem7;
        private DevComponents.Editors.ComboItem comboItem8;
        private DevComponents.Editors.ComboItem comboItem1;
        private DevComponents.Editors.ComboItem comboItem2;
        private DevComponents.Editors.ComboItem comboItem3;
        private DevComponents.DotNetBar.SuperGrid.GridColumn BillCode;
        private DevComponents.DotNetBar.SuperGrid.GridColumn BillDate;
        private DevComponents.DotNetBar.SuperGrid.GridColumn BillType;
        private DevComponents.DotNetBar.SuperGrid.GridColumn BillMoney;
        private DevComponents.DotNetBar.SuperGrid.GridColumn yiHeXiao;
        private DevComponents.DotNetBar.SuperGrid.GridColumn weiHeXiao;
        private DevComponents.DotNetBar.SuperGrid.GridColumn benciHeXiao;
        private DevComponents.DotNetBar.SuperGrid.GridColumn remark;
        private DevComponents.DotNetBar.SuperGrid.GridColumn shengyuMoney;
        private System.Windows.Forms.PictureBox pictureBoxShengHe;
    }
}