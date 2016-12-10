namespace WSCATProject.Sales
{
    partial class SalesTicketReportForm
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
            DevComponents.DotNetBar.SuperGrid.Style.Background background1 = new DevComponents.DotNetBar.SuperGrid.Style.Background();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SalesTicketReportForm));
            this.lbldanju = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.pictureBoxClose = new System.Windows.Forms.PictureBox();
            this.pictureBoxMax = new System.Windows.Forms.PictureBox();
            this.pictureBoxMin = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.superGridControlShangPing = new DevComponents.DotNetBar.SuperGrid.SuperGridControl();
            this.BillType = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            this.BillCode = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            this.KeHuName = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            this.BillDate = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            this.ZongMoney = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            this.YiHeXiaoMoney = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            this.WeiHeXiaoMoney = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            this.remark = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            this.labelTitle = new DevComponents.DotNetBar.LabelX();
            this.pictureBoxtitle = new System.Windows.Forms.PictureBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButtonProfit = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonshuaixin = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtondayin = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtondaochu = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonClose = new System.Windows.Forms.ToolStripButton();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxClose)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxMax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxMin)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxtitle)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbldanju
            // 
            this.lbldanju.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbldanju.AutoSize = true;
            this.lbldanju.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.lbldanju.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbldanju.ForeColor = System.Drawing.Color.Red;
            this.lbldanju.Location = new System.Drawing.Point(1047, 93);
            this.lbldanju.Name = "lbldanju";
            this.lbldanju.Size = new System.Drawing.Size(47, 12);
            this.lbldanju.TabIndex = 61;
            this.lbldanju.Text = "label2";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.label1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(999, 93);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 12);
            this.label1.TabIndex = 60;
            this.label1.Text = "共计：";
            // 
            // pictureBoxClose
            // 
            this.pictureBoxClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBoxClose.BackColor = System.Drawing.Color.White;
            this.pictureBoxClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pictureBoxClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBoxClose.Image = global::WSCATProject.Properties.Resources.clo;
            this.pictureBoxClose.Location = new System.Drawing.Point(1144, 28);
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
            this.pictureBoxMax.Location = new System.Drawing.Point(1115, 28);
            this.pictureBoxMax.Name = "pictureBoxMax";
            this.pictureBoxMax.Size = new System.Drawing.Size(20, 20);
            this.pictureBoxMax.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxMax.TabIndex = 49;
            this.pictureBoxMax.TabStop = false;
            this.toolTip1.SetToolTip(this.pictureBoxMax, "最大化");
            this.pictureBoxMax.Click += new System.EventHandler(this.pictureBoxMax_Click);
            this.pictureBoxMax.MouseEnter += new System.EventHandler(this.pictureBoxMax_MouseEnter);
            // 
            // pictureBoxMin
            // 
            this.pictureBoxMin.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBoxMin.BackColor = System.Drawing.Color.White;
            this.pictureBoxMin.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBoxMin.Image = global::WSCATProject.Properties.Resources.small;
            this.pictureBoxMin.Location = new System.Drawing.Point(1088, 28);
            this.pictureBoxMin.Name = "pictureBoxMin";
            this.pictureBoxMin.Size = new System.Drawing.Size(20, 20);
            this.pictureBoxMin.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxMin.TabIndex = 50;
            this.pictureBoxMin.TabStop = false;
            this.toolTip1.SetToolTip(this.pictureBoxMin, "最小化");
            this.pictureBoxMin.Click += new System.EventHandler(this.pictureBoxMin_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.superGridControlShangPing);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 131);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1202, 435);
            this.panel2.TabIndex = 59;
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
            this.superGridControlShangPing.PrimaryGrid.Columns.Add(this.BillType);
            this.superGridControlShangPing.PrimaryGrid.Columns.Add(this.BillCode);
            this.superGridControlShangPing.PrimaryGrid.Columns.Add(this.KeHuName);
            this.superGridControlShangPing.PrimaryGrid.Columns.Add(this.BillDate);
            this.superGridControlShangPing.PrimaryGrid.Columns.Add(this.ZongMoney);
            this.superGridControlShangPing.PrimaryGrid.Columns.Add(this.YiHeXiaoMoney);
            this.superGridControlShangPing.PrimaryGrid.Columns.Add(this.WeiHeXiaoMoney);
            this.superGridControlShangPing.PrimaryGrid.Columns.Add(this.remark);
            background1.Color1 = System.Drawing.Color.Azure;
            this.superGridControlShangPing.PrimaryGrid.DefaultVisualStyles.CellStyles.Default.Background = background1;
            this.superGridControlShangPing.PrimaryGrid.FrozenColumnCount = 3;
            this.superGridControlShangPing.PrimaryGrid.RowHeaderIndexOffset = 1;
            this.superGridControlShangPing.PrimaryGrid.ShowInsertRow = true;
            this.superGridControlShangPing.Size = new System.Drawing.Size(1202, 435);
            this.superGridControlShangPing.TabIndex = 1;
            this.superGridControlShangPing.Text = "superGridControl1";
            this.superGridControlShangPing.CellDoubleClick += new System.EventHandler<DevComponents.DotNetBar.SuperGrid.GridCellDoubleClickEventArgs>(this.superGridControlShangPing_CellDoubleClick);
            // 
            // BillType
            // 
            this.BillType.ColumnSortMode = DevComponents.DotNetBar.SuperGrid.ColumnSortMode.None;
            this.BillType.DataPropertyName = "type";
            this.BillType.HeaderText = "单据类型";
            this.BillType.Name = "BillType";
            this.BillType.ReadOnly = true;
            this.BillType.Width = 120;
            // 
            // BillCode
            // 
            this.BillCode.ColumnSortMode = DevComponents.DotNetBar.SuperGrid.ColumnSortMode.None;
            this.BillCode.DataPropertyName = "code";
            this.BillCode.HeaderText = "单据编号";
            this.BillCode.Name = "BillCode";
            this.BillCode.ReadOnly = true;
            this.BillCode.Width = 120;
            // 
            // KeHuName
            // 
            this.KeHuName.ColumnSortMode = DevComponents.DotNetBar.SuperGrid.ColumnSortMode.None;
            this.KeHuName.DataPropertyName = "clientName";
            this.KeHuName.HeaderText = "客户名称";
            this.KeHuName.Name = "KeHuName";
            this.KeHuName.ReadOnly = true;
            this.KeHuName.Width = 120;
            // 
            // BillDate
            // 
            this.BillDate.ColumnSortMode = DevComponents.DotNetBar.SuperGrid.ColumnSortMode.None;
            this.BillDate.DataPropertyName = "date";
            this.BillDate.HeaderText = "单据日期";
            this.BillDate.Name = "BillDate";
            this.BillDate.ReadOnly = true;
            this.BillDate.Width = 150;
            // 
            // ZongMoney
            // 
            this.ZongMoney.ColumnSortMode = DevComponents.DotNetBar.SuperGrid.ColumnSortMode.None;
            this.ZongMoney.DataPropertyName = "oddAllMoney";
            this.ZongMoney.EditorType = typeof(DevComponents.DotNetBar.SuperGrid.GridDoubleInputEditControl);
            this.ZongMoney.HeaderText = "总金额";
            this.ZongMoney.Name = "ZongMoney";
            this.ZongMoney.ReadOnly = true;
            this.ZongMoney.Width = 150;
            // 
            // YiHeXiaoMoney
            // 
            this.YiHeXiaoMoney.ColumnSortMode = DevComponents.DotNetBar.SuperGrid.ColumnSortMode.None;
            this.YiHeXiaoMoney.DataPropertyName = "firstMoney";
            this.YiHeXiaoMoney.EditorType = typeof(DevComponents.DotNetBar.SuperGrid.GridDoubleInputEditControl);
            this.YiHeXiaoMoney.HeaderText = "已核销金额";
            this.YiHeXiaoMoney.Name = "YiHeXiaoMoney";
            this.YiHeXiaoMoney.ReadOnly = true;
            this.YiHeXiaoMoney.Width = 150;
            // 
            // WeiHeXiaoMoney
            // 
            this.WeiHeXiaoMoney.ColumnSortMode = DevComponents.DotNetBar.SuperGrid.ColumnSortMode.None;
            this.WeiHeXiaoMoney.DataPropertyName = "lastMoney";
            this.WeiHeXiaoMoney.EditorType = typeof(DevComponents.DotNetBar.SuperGrid.GridDoubleInputEditControl);
            this.WeiHeXiaoMoney.HeaderText = "未核销金额";
            this.WeiHeXiaoMoney.Name = "WeiHeXiaoMoney";
            this.WeiHeXiaoMoney.ReadOnly = true;
            this.WeiHeXiaoMoney.Width = 150;
            // 
            // remark
            // 
            this.remark.AutoSizeMode = DevComponents.DotNetBar.SuperGrid.ColumnAutoSizeMode.Fill;
            this.remark.ColumnSortMode = DevComponents.DotNetBar.SuperGrid.ColumnSortMode.None;
            this.remark.DataPropertyName = "remark";
            this.remark.HeaderText = "摘要";
            this.remark.Name = "remark";
            this.remark.ReadOnly = true;
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
            this.labelTitle.Size = new System.Drawing.Size(287, 30);
            this.labelTitle.TabIndex = 4;
            this.labelTitle.Text = "销  售  单  序  时  薄";
            this.labelTitle.TextAlignment = System.Drawing.StringAlignment.Center;
            this.labelTitle.MouseDown += new System.Windows.Forms.MouseEventHandler(this.SalesTicketReportForm_MouseDown);
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
            this.pictureBoxtitle.Size = new System.Drawing.Size(1205, 61);
            this.pictureBoxtitle.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxtitle.TabIndex = 1;
            this.pictureBoxtitle.TabStop = false;
            this.pictureBoxtitle.MouseDown += new System.Windows.Forms.MouseEventHandler(this.SalesTicketReportForm_MouseDown);
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
            this.toolStrip1.Size = new System.Drawing.Size(1202, 70);
            this.toolStrip1.TabIndex = 58;
            this.toolStrip1.Text = "toolStrip1";
            this.toolStrip1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.SalesTicketReportForm_MouseDown);
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
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.label3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.ForeColor = System.Drawing.Color.Red;
            this.label3.Location = new System.Drawing.Point(1118, 93);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 12);
            this.label3.TabIndex = 62;
            this.label3.Text = "label3";
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
            this.panel1.Size = new System.Drawing.Size(1202, 61);
            this.panel1.TabIndex = 57;
            // 
            // SalesTicketReportForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1202, 566);
            this.Controls.Add(this.lbldanju);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "SalesTicketReportForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "销售单序时薄";
            this.Load += new System.EventHandler(this.SalesTicketReportForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SalesTicketReportForm_KeyDown);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.SalesTicketReportForm_MouseDown);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxClose)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxMax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxMin)).EndInit();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxtitle)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lbldanju;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolTip toolTip1;
        protected System.Windows.Forms.PictureBox pictureBoxClose;
        public System.Windows.Forms.PictureBox pictureBoxMax;
        public System.Windows.Forms.PictureBox pictureBoxMin;
        private System.Windows.Forms.Panel panel2;
        private DevComponents.DotNetBar.SuperGrid.SuperGridControl superGridControlShangPing;
        protected DevComponents.DotNetBar.LabelX labelTitle;
        public System.Windows.Forms.PictureBox pictureBoxtitle;
        private System.Windows.Forms.ToolStrip toolStrip1;
        protected System.Windows.Forms.ToolStripButton toolStripButtonProfit;
        protected System.Windows.Forms.ToolStripButton toolStripButtonshuaixin;
        protected System.Windows.Forms.ToolStripButton toolStripButtondayin;
        protected System.Windows.Forms.ToolStripButton toolStripButtondaochu;
        private System.Windows.Forms.ToolStripButton toolStripButtonClose;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel1;
        private DevComponents.DotNetBar.SuperGrid.GridColumn BillType;
        private DevComponents.DotNetBar.SuperGrid.GridColumn BillCode;
        private DevComponents.DotNetBar.SuperGrid.GridColumn KeHuName;
        private DevComponents.DotNetBar.SuperGrid.GridColumn BillDate;
        private DevComponents.DotNetBar.SuperGrid.GridColumn ZongMoney;
        private DevComponents.DotNetBar.SuperGrid.GridColumn YiHeXiaoMoney;
        private DevComponents.DotNetBar.SuperGrid.GridColumn WeiHeXiaoMoney;
        private DevComponents.DotNetBar.SuperGrid.GridColumn remark;
    }
}