namespace WSCATProject.Purchase
{
    partial class PurchaseOrderReportForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PurchaseOrderReportForm));
            DevComponents.DotNetBar.SuperGrid.Style.Background background1 = new DevComponents.DotNetBar.SuperGrid.Style.Background();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBoxClose = new System.Windows.Forms.PictureBox();
            this.pictureBoxMax = new System.Windows.Forms.PictureBox();
            this.pictureBoxMin = new System.Windows.Forms.PictureBox();
            this.labelTitle = new DevComponents.DotNetBar.LabelX();
            this.pictureBoxtitle = new System.Windows.Forms.PictureBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButtonProfit = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonshuaixin = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtondayin = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtondaochu = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonClose = new System.Windows.Forms.ToolStripButton();
            this.panel2 = new System.Windows.Forms.Panel();
            this.superGridControlShangPing = new DevComponents.DotNetBar.SuperGrid.SuperGridControl();
            this.DanJuCode = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            this.DanJuDate = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            this.SupplyName = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            this.MobilPhone = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            this.fax = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            this.JiaoHuoMethod = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            this.JiaoHuoDate = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            this.shengheMan = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            this.ZhaiYao = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            this.shengheState = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            this.purchaseDetilecode = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            this.materialDaiMa = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            this.materialName = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            this.materialModel = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            this.materialBarCode = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            this.materialUnit = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            this.materialNumber = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            this.materialPrice = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            this.materialMoney = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            this.discountRate = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            this.discountMoney = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            this.ZongKuCun = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            this.gridColumnmaterialcode = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            this.labelPurchaseDetile = new System.Windows.Forms.Label();
            this.labelPurchaseMain = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxClose)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxMax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxMin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxtitle)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.pictureBoxClose);
            this.panel1.Controls.Add(this.pictureBoxMax);
            this.panel1.Controls.Add(this.pictureBoxMin);
            this.panel1.Controls.Add(this.labelTitle);
            this.panel1.Controls.Add(this.pictureBoxtitle);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1170, 61);
            this.panel1.TabIndex = 5;
            this.panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PurchaseOrderReportForm_MouseDown);
            // 
            // pictureBoxClose
            // 
            this.pictureBoxClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBoxClose.BackColor = System.Drawing.Color.White;
            this.pictureBoxClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pictureBoxClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBoxClose.Image = global::WSCATProject.Properties.Resources.clo;
            this.pictureBoxClose.Location = new System.Drawing.Point(1112, 28);
            this.pictureBoxClose.Name = "pictureBoxClose";
            this.pictureBoxClose.Size = new System.Drawing.Size(20, 20);
            this.pictureBoxClose.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxClose.TabIndex = 51;
            this.pictureBoxClose.TabStop = false;
            this.toolTip1.SetToolTip(this.pictureBoxClose, "关闭");
            this.pictureBoxClose.Click += new System.EventHandler(this.pictureBoxClose_Click);
            // 
            // pictureBoxMax
            // 
            this.pictureBoxMax.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBoxMax.BackColor = System.Drawing.Color.White;
            this.pictureBoxMax.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pictureBoxMax.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBoxMax.Image = global::WSCATProject.Properties.Resources.zuidahua1;
            this.pictureBoxMax.Location = new System.Drawing.Point(1083, 28);
            this.pictureBoxMax.Name = "pictureBoxMax";
            this.pictureBoxMax.Size = new System.Drawing.Size(20, 20);
            this.pictureBoxMax.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxMax.TabIndex = 49;
            this.pictureBoxMax.TabStop = false;
            this.toolTip1.SetToolTip(this.pictureBoxMax, "最大化");
            this.pictureBoxMax.Click += new System.EventHandler(this.pictureBoxMax_MouseEnter);
            this.pictureBoxMax.MouseEnter += new System.EventHandler(this.pictureBoxMax_MouseEnter);
            // 
            // pictureBoxMin
            // 
            this.pictureBoxMin.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBoxMin.BackColor = System.Drawing.Color.White;
            this.pictureBoxMin.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBoxMin.Image = global::WSCATProject.Properties.Resources.small;
            this.pictureBoxMin.Location = new System.Drawing.Point(1056, 28);
            this.pictureBoxMin.Name = "pictureBoxMin";
            this.pictureBoxMin.Size = new System.Drawing.Size(20, 20);
            this.pictureBoxMin.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxMin.TabIndex = 50;
            this.pictureBoxMin.TabStop = false;
            this.toolTip1.SetToolTip(this.pictureBoxMin, "最小化");
            this.pictureBoxMin.Click += new System.EventHandler(this.pictureBoxMin_Click);
            // 
            // labelTitle
            // 
            this.labelTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelTitle.BackColor = System.Drawing.Color.DeepSkyBlue;
            // 
            // 
            // 
            this.labelTitle.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelTitle.Font = new System.Drawing.Font("微软雅黑", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelTitle.ForeColor = System.Drawing.Color.White;
            this.labelTitle.Location = new System.Drawing.Point(452, 8);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(277, 30);
            this.labelTitle.TabIndex = 4;
            this.labelTitle.Text = "采  购  订  单  序  时  薄";
            this.labelTitle.TextAlignment = System.Drawing.StringAlignment.Center;
            this.labelTitle.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PurchaseOrderReportForm_MouseDown);
            // 
            // pictureBoxtitle
            // 
            this.pictureBoxtitle.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBoxtitle.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.pictureBoxtitle.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxtitle.Image")));
            this.pictureBoxtitle.Location = new System.Drawing.Point(0, 0);
            this.pictureBoxtitle.Name = "pictureBoxtitle";
            this.pictureBoxtitle.Size = new System.Drawing.Size(1173, 61);
            this.pictureBoxtitle.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxtitle.TabIndex = 1;
            this.pictureBoxtitle.TabStop = false;
            this.pictureBoxtitle.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PurchaseOrderReportForm_MouseDown);
            // 
            // toolStrip1
            // 
            this.toolStrip1.AutoSize = false;
            this.toolStrip1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.toolStrip1.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButtonProfit,
            this.toolStripButtonshuaixin,
            this.toolStripButtondayin,
            this.toolStripButtondaochu,
            this.toolStripButtonClose});
            this.toolStrip1.Location = new System.Drawing.Point(0, 61);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1170, 70);
            this.toolStrip1.TabIndex = 53;
            this.toolStrip1.Text = "toolStrip1";
            this.toolStrip1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PurchaseOrderReportForm_MouseDown);
            // 
            // toolStripButtonProfit
            // 
            this.toolStripButtonProfit.Image = global::WSCATProject.Properties.Resources.business;
            this.toolStripButtonProfit.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButtonProfit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonProfit.Margin = new System.Windows.Forms.Padding(0, 2, 0, 2);
            this.toolStripButtonProfit.Name = "toolStripButtonProfit";
            this.toolStripButtonProfit.Size = new System.Drawing.Size(41, 66);
            this.toolStripButtonProfit.Text = "查看";
            this.toolStripButtonProfit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolStripButtonProfit.ToolTipText = "查看销售订单";
            // 
            // toolStripButtonshuaixin
            // 
            this.toolStripButtonshuaixin.AutoSize = false;
            this.toolStripButtonshuaixin.Image = global::WSCATProject.Properties.Resources.刷新;
            this.toolStripButtonshuaixin.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButtonshuaixin.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonshuaixin.Margin = new System.Windows.Forms.Padding(0, 5, 0, -2);
            this.toolStripButtonshuaixin.Name = "toolStripButtonshuaixin";
            this.toolStripButtonshuaixin.Size = new System.Drawing.Size(60, 67);
            this.toolStripButtonshuaixin.Text = "刷新(&F5)";
            this.toolStripButtonshuaixin.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolStripButtonshuaixin.ToolTipText = "刷新（F5）";
            // 
            // toolStripButtondayin
            // 
            this.toolStripButtondayin.Image = global::WSCATProject.Properties.Resources.daying1;
            this.toolStripButtondayin.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButtondayin.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtondayin.Margin = new System.Windows.Forms.Padding(0, 2, 0, 2);
            this.toolStripButtondayin.Name = "toolStripButtondayin";
            this.toolStripButtondayin.Size = new System.Drawing.Size(60, 66);
            this.toolStripButtondayin.Text = "打印(&P)";
            this.toolStripButtondayin.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolStripButtondayin.ToolTipText = "打印(Ctrl+P)";
            // 
            // toolStripButtondaochu
            // 
            this.toolStripButtondaochu.Image = global::WSCATProject.Properties.Resources.countExc;
            this.toolStripButtondaochu.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButtondaochu.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtondaochu.Margin = new System.Windows.Forms.Padding(0, 2, 0, 2);
            this.toolStripButtondaochu.Name = "toolStripButtondaochu";
            this.toolStripButtondaochu.Size = new System.Drawing.Size(93, 66);
            this.toolStripButtondaochu.Text = "导出Excel(&T)";
            this.toolStripButtondaochu.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolStripButtondaochu.ToolTipText = "导出Excel(Ctrl+T)";
            // 
            // toolStripButtonClose
            // 
            this.toolStripButtonClose.Image = global::WSCATProject.Properties.Resources.guanbi;
            this.toolStripButtonClose.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButtonClose.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonClose.Name = "toolStripButtonClose";
            this.toolStripButtonClose.Size = new System.Drawing.Size(60, 67);
            this.toolStripButtonClose.Text = "关闭(&X)";
            this.toolStripButtonClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolStripButtonClose.ToolTipText = "关闭(Ctrl+X)";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.superGridControlShangPing);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 131);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1170, 435);
            this.panel2.TabIndex = 54;
            // 
            // superGridControlShangPing
            // 
            this.superGridControlShangPing.Dock = System.Windows.Forms.DockStyle.Fill;
            this.superGridControlShangPing.FilterExprColors.SysFunction = System.Drawing.Color.DarkRed;
            this.superGridControlShangPing.Location = new System.Drawing.Point(0, 0);
            this.superGridControlShangPing.Name = "superGridControlShangPing";
            // 
            // 
            // 
            this.superGridControlShangPing.PrimaryGrid.AllowSelection = false;
            this.superGridControlShangPing.PrimaryGrid.Columns.Add(this.DanJuCode);
            this.superGridControlShangPing.PrimaryGrid.Columns.Add(this.DanJuDate);
            this.superGridControlShangPing.PrimaryGrid.Columns.Add(this.SupplyName);
            this.superGridControlShangPing.PrimaryGrid.Columns.Add(this.MobilPhone);
            this.superGridControlShangPing.PrimaryGrid.Columns.Add(this.fax);
            this.superGridControlShangPing.PrimaryGrid.Columns.Add(this.JiaoHuoMethod);
            this.superGridControlShangPing.PrimaryGrid.Columns.Add(this.JiaoHuoDate);
            this.superGridControlShangPing.PrimaryGrid.Columns.Add(this.shengheMan);
            this.superGridControlShangPing.PrimaryGrid.Columns.Add(this.ZhaiYao);
            this.superGridControlShangPing.PrimaryGrid.Columns.Add(this.shengheState);
            this.superGridControlShangPing.PrimaryGrid.Columns.Add(this.purchaseDetilecode);
            this.superGridControlShangPing.PrimaryGrid.Columns.Add(this.materialDaiMa);
            this.superGridControlShangPing.PrimaryGrid.Columns.Add(this.materialName);
            this.superGridControlShangPing.PrimaryGrid.Columns.Add(this.materialModel);
            this.superGridControlShangPing.PrimaryGrid.Columns.Add(this.materialBarCode);
            this.superGridControlShangPing.PrimaryGrid.Columns.Add(this.materialUnit);
            this.superGridControlShangPing.PrimaryGrid.Columns.Add(this.materialNumber);
            this.superGridControlShangPing.PrimaryGrid.Columns.Add(this.materialPrice);
            this.superGridControlShangPing.PrimaryGrid.Columns.Add(this.materialMoney);
            this.superGridControlShangPing.PrimaryGrid.Columns.Add(this.discountRate);
            this.superGridControlShangPing.PrimaryGrid.Columns.Add(this.discountMoney);
            this.superGridControlShangPing.PrimaryGrid.Columns.Add(this.ZongKuCun);
            this.superGridControlShangPing.PrimaryGrid.Columns.Add(this.gridColumnmaterialcode);
            background1.Color1 = System.Drawing.Color.Azure;
            this.superGridControlShangPing.PrimaryGrid.DefaultVisualStyles.CellStyles.Default.Background = background1;
            this.superGridControlShangPing.PrimaryGrid.FrozenColumnCount = 3;
            this.superGridControlShangPing.PrimaryGrid.RowHeaderIndexOffset = 1;
            this.superGridControlShangPing.Size = new System.Drawing.Size(1170, 435);
            this.superGridControlShangPing.TabIndex = 1;
            this.superGridControlShangPing.Text = "superGridControl1";
            this.superGridControlShangPing.CellDoubleClick += new System.EventHandler<DevComponents.DotNetBar.SuperGrid.GridCellDoubleClickEventArgs>(this.superGridControlShangPing_CellDoubleClick);
            // 
            // DanJuCode
            // 
            this.DanJuCode.ColumnSortMode = DevComponents.DotNetBar.SuperGrid.ColumnSortMode.None;
            this.DanJuCode.DataPropertyName = "code";
            this.DanJuCode.HeaderText = "单据编号";
            this.DanJuCode.Name = "DanJuCode";
            // 
            // DanJuDate
            // 
            this.DanJuDate.ColumnSortMode = DevComponents.DotNetBar.SuperGrid.ColumnSortMode.None;
            this.DanJuDate.DataPropertyName = "date";
            this.DanJuDate.HeaderText = "单据日期";
            this.DanJuDate.Name = "DanJuDate";
            // 
            // SupplyName
            // 
            this.SupplyName.ColumnSortMode = DevComponents.DotNetBar.SuperGrid.ColumnSortMode.None;
            this.SupplyName.DataPropertyName = "name";
            this.SupplyName.HeaderText = "供应商名称";
            this.SupplyName.Name = "SupplyName";
            this.SupplyName.Width = 80;
            // 
            // MobilPhone
            // 
            this.MobilPhone.ColumnSortMode = DevComponents.DotNetBar.SuperGrid.ColumnSortMode.None;
            this.MobilPhone.DataPropertyName = "phone";
            this.MobilPhone.HeaderText = "电话";
            this.MobilPhone.Name = "MobilPhone";
            this.MobilPhone.Width = 80;
            // 
            // fax
            // 
            this.fax.ColumnSortMode = DevComponents.DotNetBar.SuperGrid.ColumnSortMode.None;
            this.fax.DataPropertyName = "fax";
            this.fax.DefaultNewRowCellValue = "";
            this.fax.HeaderText = "传真";
            this.fax.Name = "fax";
            this.fax.Width = 80;
            // 
            // JiaoHuoMethod
            // 
            this.JiaoHuoMethod.ColumnSortMode = DevComponents.DotNetBar.SuperGrid.ColumnSortMode.None;
            this.JiaoHuoMethod.DataPropertyName = "deliversMethod";
            this.JiaoHuoMethod.HeaderStyles.Default.AllowWrap = DevComponents.DotNetBar.SuperGrid.Style.Tbool.True;
            this.JiaoHuoMethod.HeaderText = "交货方式";
            this.JiaoHuoMethod.Name = "JiaoHuoMethod";
            this.JiaoHuoMethod.Width = 50;
            // 
            // JiaoHuoDate
            // 
            this.JiaoHuoDate.ColumnSortMode = DevComponents.DotNetBar.SuperGrid.ColumnSortMode.None;
            this.JiaoHuoDate.DataPropertyName = "deliversDate";
            this.JiaoHuoDate.HeaderText = "交货日期";
            this.JiaoHuoDate.Name = "JiaoHuoDate";
            this.JiaoHuoDate.Width = 80;
            // 
            // shengheMan
            // 
            this.shengheMan.ColumnSortMode = DevComponents.DotNetBar.SuperGrid.ColumnSortMode.None;
            this.shengheMan.DataPropertyName = "examine";
            this.shengheMan.HeaderText = "审核人";
            this.shengheMan.Name = "shengheMan";
            this.shengheMan.Width = 60;
            // 
            // ZhaiYao
            // 
            this.ZhaiYao.ColumnSortMode = DevComponents.DotNetBar.SuperGrid.ColumnSortMode.None;
            this.ZhaiYao.DataPropertyName = "remark";
            this.ZhaiYao.HeaderText = "摘要";
            this.ZhaiYao.Name = "ZhaiYao";
            this.ZhaiYao.Width = 60;
            // 
            // shengheState
            // 
            this.shengheState.ColumnSortMode = DevComponents.DotNetBar.SuperGrid.ColumnSortMode.None;
            this.shengheState.DataPropertyName = "checkState";
            this.shengheState.HeaderStyles.Default.AllowWrap = DevComponents.DotNetBar.SuperGrid.Style.Tbool.True;
            this.shengheState.HeaderText = "审核状态";
            this.shengheState.Name = "shengheState";
            this.shengheState.Width = 60;
            // 
            // purchaseDetilecode
            // 
            this.purchaseDetilecode.ColumnSortMode = DevComponents.DotNetBar.SuperGrid.ColumnSortMode.None;
            this.purchaseDetilecode.HeaderStyles.Default.AllowWrap = DevComponents.DotNetBar.SuperGrid.Style.Tbool.True;
            this.purchaseDetilecode.HeaderText = "销售订单详细号";
            this.purchaseDetilecode.Name = "purchaseDetilecode";
            // 
            // materialDaiMa
            // 
            this.materialDaiMa.ColumnSortMode = DevComponents.DotNetBar.SuperGrid.ColumnSortMode.None;
            this.materialDaiMa.DataPropertyName = "materialDaima";
            this.materialDaiMa.HeaderText = "商品代码";
            this.materialDaiMa.Name = "materialDaiMa";
            // 
            // materialName
            // 
            this.materialName.ColumnSortMode = DevComponents.DotNetBar.SuperGrid.ColumnSortMode.None;
            this.materialName.DataPropertyName = "name";
            this.materialName.HeaderText = "商品名称";
            this.materialName.Name = "materialName";
            // 
            // materialModel
            // 
            this.materialModel.ColumnSortMode = DevComponents.DotNetBar.SuperGrid.ColumnSortMode.None;
            this.materialModel.DataPropertyName = "model";
            this.materialModel.HeaderStyles.Default.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleCenter;
            this.materialModel.HeaderStyles.Default.AllowWrap = DevComponents.DotNetBar.SuperGrid.Style.Tbool.True;
            this.materialModel.HeaderText = "规格型号";
            this.materialModel.Name = "materialModel";
            this.materialModel.Width = 50;
            // 
            // materialBarCode
            // 
            this.materialBarCode.ColumnSortMode = DevComponents.DotNetBar.SuperGrid.ColumnSortMode.None;
            this.materialBarCode.DataPropertyName = "barCode";
            this.materialBarCode.HeaderText = "条形码";
            this.materialBarCode.Name = "materialBarCode";
            this.materialBarCode.Width = 150;
            // 
            // materialUnit
            // 
            this.materialUnit.ColumnSortMode = DevComponents.DotNetBar.SuperGrid.ColumnSortMode.None;
            this.materialUnit.DataPropertyName = "unit";
            this.materialUnit.HeaderText = "单位";
            this.materialUnit.Name = "materialUnit";
            this.materialUnit.Width = 50;
            // 
            // materialNumber
            // 
            this.materialNumber.ColumnSortMode = DevComponents.DotNetBar.SuperGrid.ColumnSortMode.None;
            this.materialNumber.DataPropertyName = "number";
            this.materialNumber.HeaderText = "数量";
            this.materialNumber.Name = "materialNumber";
            this.materialNumber.Width = 80;
            // 
            // materialPrice
            // 
            this.materialPrice.ColumnSortMode = DevComponents.DotNetBar.SuperGrid.ColumnSortMode.None;
            this.materialPrice.DataPropertyName = "materialPrice";
            this.materialPrice.HeaderText = "单价";
            this.materialPrice.Name = "materialPrice";
            this.materialPrice.Width = 80;
            // 
            // materialMoney
            // 
            this.materialMoney.ColumnSortMode = DevComponents.DotNetBar.SuperGrid.ColumnSortMode.None;
            this.materialMoney.DataPropertyName = "";
            this.materialMoney.HeaderText = "金额";
            this.materialMoney.Name = "materialMoney";
            // 
            // discountRate
            // 
            this.discountRate.ColumnSortMode = DevComponents.DotNetBar.SuperGrid.ColumnSortMode.None;
            this.discountRate.DataPropertyName = "discountRate";
            this.discountRate.HeaderStyles.Default.AllowWrap = DevComponents.DotNetBar.SuperGrid.Style.Tbool.True;
            this.discountRate.HeaderText = "折扣率%";
            this.discountRate.Name = "discountRate";
            this.discountRate.Width = 50;
            // 
            // discountMoney
            // 
            this.discountMoney.ColumnSortMode = DevComponents.DotNetBar.SuperGrid.ColumnSortMode.None;
            this.discountMoney.DataPropertyName = "discountMoney";
            this.discountMoney.HeaderText = "折扣额";
            this.discountMoney.Name = "discountMoney";
            this.discountMoney.Width = 80;
            // 
            // ZongKuCun
            // 
            this.ZongKuCun.ColumnSortMode = DevComponents.DotNetBar.SuperGrid.ColumnSortMode.None;
            this.ZongKuCun.DataPropertyName = "allNumber";
            this.ZongKuCun.HeaderStyles.Default.AllowWrap = DevComponents.DotNetBar.SuperGrid.Style.Tbool.False;
            this.ZongKuCun.HeaderText = "总库存";
            this.ZongKuCun.Name = "ZongKuCun";
            this.ZongKuCun.Width = 60;
            // 
            // gridColumnmaterialcode
            // 
            this.gridColumnmaterialcode.ColumnSortMode = DevComponents.DotNetBar.SuperGrid.ColumnSortMode.None;
            this.gridColumnmaterialcode.HeaderText = "物流code";
            this.gridColumnmaterialcode.Name = "gridColumnmaterialcode";
            this.gridColumnmaterialcode.Visible = false;
            // 
            // labelPurchaseDetile
            // 
            this.labelPurchaseDetile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelPurchaseDetile.AutoSize = true;
            this.labelPurchaseDetile.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.labelPurchaseDetile.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelPurchaseDetile.ForeColor = System.Drawing.Color.Red;
            this.labelPurchaseDetile.Location = new System.Drawing.Point(1085, 88);
            this.labelPurchaseDetile.Name = "labelPurchaseDetile";
            this.labelPurchaseDetile.Size = new System.Drawing.Size(47, 12);
            this.labelPurchaseDetile.TabIndex = 59;
            this.labelPurchaseDetile.Text = "label3";
            // 
            // labelPurchaseMain
            // 
            this.labelPurchaseMain.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelPurchaseMain.AutoSize = true;
            this.labelPurchaseMain.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.labelPurchaseMain.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelPurchaseMain.ForeColor = System.Drawing.Color.Red;
            this.labelPurchaseMain.Location = new System.Drawing.Point(1014, 88);
            this.labelPurchaseMain.Name = "labelPurchaseMain";
            this.labelPurchaseMain.Size = new System.Drawing.Size(47, 12);
            this.labelPurchaseMain.TabIndex = 58;
            this.labelPurchaseMain.Text = "label2";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.label1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(966, 88);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 12);
            this.label1.TabIndex = 57;
            this.label1.Text = "共计：";
            // 
            // PurchaseOrderReportForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1170, 566);
            this.Controls.Add(this.labelPurchaseDetile);
            this.Controls.Add(this.labelPurchaseMain);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "PurchaseOrderReportForm";
            this.Text = "销售订单序时薄";
            this.Load += new System.EventHandler(this.PurchaseOrderReportForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.PurchaseOrderReportForm_KeyDown);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxClose)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxMax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxMin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxtitle)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        protected System.Windows.Forms.PictureBox pictureBoxClose;
        public System.Windows.Forms.PictureBox pictureBoxMax;
        public System.Windows.Forms.PictureBox pictureBoxMin;
        protected DevComponents.DotNetBar.LabelX labelTitle;
        public System.Windows.Forms.PictureBox pictureBoxtitle;
        private System.Windows.Forms.ToolStrip toolStrip1;
        protected System.Windows.Forms.ToolStripButton toolStripButtonProfit;
        protected System.Windows.Forms.ToolStripButton toolStripButtonshuaixin;
        protected System.Windows.Forms.ToolStripButton toolStripButtondayin;
        protected System.Windows.Forms.ToolStripButton toolStripButtondaochu;
        private System.Windows.Forms.ToolStripButton toolStripButtonClose;
        private System.Windows.Forms.Panel panel2;
        private DevComponents.DotNetBar.SuperGrid.SuperGridControl superGridControlShangPing;
        private DevComponents.DotNetBar.SuperGrid.GridColumn DanJuCode;
        private DevComponents.DotNetBar.SuperGrid.GridColumn DanJuDate;
        private DevComponents.DotNetBar.SuperGrid.GridColumn SupplyName;
        private DevComponents.DotNetBar.SuperGrid.GridColumn MobilPhone;
        private DevComponents.DotNetBar.SuperGrid.GridColumn fax;
        private DevComponents.DotNetBar.SuperGrid.GridColumn JiaoHuoMethod;
        private DevComponents.DotNetBar.SuperGrid.GridColumn JiaoHuoDate;
        private DevComponents.DotNetBar.SuperGrid.GridColumn shengheMan;
        private DevComponents.DotNetBar.SuperGrid.GridColumn ZhaiYao;
        private DevComponents.DotNetBar.SuperGrid.GridColumn shengheState;
        private DevComponents.DotNetBar.SuperGrid.GridColumn purchaseDetilecode;
        private DevComponents.DotNetBar.SuperGrid.GridColumn materialDaiMa;
        private DevComponents.DotNetBar.SuperGrid.GridColumn materialName;
        private DevComponents.DotNetBar.SuperGrid.GridColumn materialModel;
        private DevComponents.DotNetBar.SuperGrid.GridColumn materialBarCode;
        private DevComponents.DotNetBar.SuperGrid.GridColumn materialUnit;
        private DevComponents.DotNetBar.SuperGrid.GridColumn materialNumber;
        private DevComponents.DotNetBar.SuperGrid.GridColumn materialPrice;
        private DevComponents.DotNetBar.SuperGrid.GridColumn materialMoney;
        private DevComponents.DotNetBar.SuperGrid.GridColumn discountRate;
        private DevComponents.DotNetBar.SuperGrid.GridColumn discountMoney;
        private DevComponents.DotNetBar.SuperGrid.GridColumn ZongKuCun;
        private System.Windows.Forms.Label labelPurchaseDetile;
        private System.Windows.Forms.Label labelPurchaseMain;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolTip toolTip1;
        private DevComponents.DotNetBar.SuperGrid.GridColumn gridColumnmaterialcode;
    }
}