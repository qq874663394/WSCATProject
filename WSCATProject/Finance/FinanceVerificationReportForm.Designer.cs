namespace WSCATProject.Finance
{
    partial class FinanceVerificationReportForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FinanceVerificationReportForm));
            DevComponents.DotNetBar.SuperGrid.Style.Background background1 = new DevComponents.DotNetBar.SuperGrid.Style.Background();
            this.pictureBoxtitle = new System.Windows.Forms.PictureBox();
            this.labelTitle = new DevComponents.DotNetBar.LabelX();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButtonProfit = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonshuaixin = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtondayin = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtondaochu = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonClose = new System.Windows.Forms.ToolStripButton();
            this.superGridControlShangPing = new DevComponents.DotNetBar.SuperGrid.SuperGridControl();
            this.pictureBoxClose = new System.Windows.Forms.PictureBox();
            this.pictureBoxMax = new System.Windows.Forms.PictureBox();
            this.pictureBoxMin = new System.Windows.Forms.PictureBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxtitle)).BeginInit();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxClose)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxMax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxMin)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBoxtitle
            // 
            this.pictureBoxtitle.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.pictureBoxtitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.pictureBoxtitle.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxtitle.Image")));
            this.pictureBoxtitle.Location = new System.Drawing.Point(0, 0);
            this.pictureBoxtitle.Name = "pictureBoxtitle";
            this.pictureBoxtitle.Size = new System.Drawing.Size(1170, 61);
            this.pictureBoxtitle.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxtitle.TabIndex = 2;
            this.pictureBoxtitle.TabStop = false;
            this.pictureBoxtitle.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PurchaseOrderReportForm_MouseDown);
            // 
            // labelTitle
            // 
            this.labelTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(177)))), ((int)(((byte)(238)))));
            // 
            // 
            // 
            this.labelTitle.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelTitle.Font = new System.Drawing.Font("微软雅黑", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelTitle.ForeColor = System.Drawing.Color.White;
            this.labelTitle.Location = new System.Drawing.Point(446, 5);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(277, 30);
            this.labelTitle.TabIndex = 5;
            this.labelTitle.Text = "预  收  源  单";
            this.labelTitle.TextAlignment = System.Drawing.StringAlignment.Center;
            this.labelTitle.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PurchaseOrderReportForm_MouseDown);
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
            this.toolStrip1.TabIndex = 54;
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
            this.toolStripButtonshuaixin.Click += new System.EventHandler(this.toolStripButtonshuaixin_Click);
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
            // superGridControlShangPing
            // 
            this.superGridControlShangPing.Dock = System.Windows.Forms.DockStyle.Fill;
            this.superGridControlShangPing.FilterExprColors.SysFunction = System.Drawing.Color.DarkRed;
            this.superGridControlShangPing.Location = new System.Drawing.Point(0, 131);
            this.superGridControlShangPing.Name = "superGridControlShangPing";
            // 
            // 
            // 
            this.superGridControlShangPing.PrimaryGrid.AllowSelection = false;
            background1.Color1 = System.Drawing.Color.Azure;
            this.superGridControlShangPing.PrimaryGrid.DefaultVisualStyles.CellStyles.Default.Background = background1;
            this.superGridControlShangPing.PrimaryGrid.FrozenColumnCount = 3;
            this.superGridControlShangPing.PrimaryGrid.RowHeaderIndexOffset = 1;
            this.superGridControlShangPing.Size = new System.Drawing.Size(1170, 397);
            this.superGridControlShangPing.TabIndex = 55;
            this.superGridControlShangPing.Text = "superGridControl1";
            this.superGridControlShangPing.CellDoubleClick += new System.EventHandler<DevComponents.DotNetBar.SuperGrid.GridCellDoubleClickEventArgs>(this.superGridControlShangPing_CellDoubleClick);
            // 
            // pictureBoxClose
            // 
            this.pictureBoxClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBoxClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(177)))), ((int)(((byte)(238)))));
            this.pictureBoxClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pictureBoxClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBoxClose.Image = global::WSCATProject.Properties.Resources.clo;
            this.pictureBoxClose.Location = new System.Drawing.Point(1105, 27);
            this.pictureBoxClose.Name = "pictureBoxClose";
            this.pictureBoxClose.Size = new System.Drawing.Size(20, 20);
            this.pictureBoxClose.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxClose.TabIndex = 58;
            this.pictureBoxClose.TabStop = false;
            this.pictureBoxClose.Click += new System.EventHandler(this.pictureBoxClose_Click);
            // 
            // pictureBoxMax
            // 
            this.pictureBoxMax.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBoxMax.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(177)))), ((int)(((byte)(238)))));
            this.pictureBoxMax.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pictureBoxMax.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBoxMax.Image = global::WSCATProject.Properties.Resources.zuidahua1;
            this.pictureBoxMax.Location = new System.Drawing.Point(1076, 27);
            this.pictureBoxMax.Name = "pictureBoxMax";
            this.pictureBoxMax.Size = new System.Drawing.Size(20, 20);
            this.pictureBoxMax.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxMax.TabIndex = 56;
            this.pictureBoxMax.TabStop = false;
            this.pictureBoxMax.Click += new System.EventHandler(this.pictureBoxMax_Click);
            // 
            // pictureBoxMin
            // 
            this.pictureBoxMin.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBoxMin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(177)))), ((int)(((byte)(238)))));
            this.pictureBoxMin.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBoxMin.Image = global::WSCATProject.Properties.Resources.small;
            this.pictureBoxMin.Location = new System.Drawing.Point(1049, 27);
            this.pictureBoxMin.Name = "pictureBoxMin";
            this.pictureBoxMin.Size = new System.Drawing.Size(20, 20);
            this.pictureBoxMin.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxMin.TabIndex = 57;
            this.pictureBoxMin.TabStop = false;
            this.pictureBoxMin.Click += new System.EventHandler(this.pictureBoxMin_Click);
            // 
            // FinanceVerificationReportForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1170, 528);
            this.Controls.Add(this.pictureBoxClose);
            this.Controls.Add(this.pictureBoxMax);
            this.Controls.Add(this.pictureBoxMin);
            this.Controls.Add(this.superGridControlShangPing);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.labelTitle);
            this.Controls.Add(this.pictureBoxtitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FinanceVerificationReportForm";
            this.Text = "FinanceVerificationReportForm";
            this.Load += new System.EventHandler(this.FinanceVerificationReportForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxtitle)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxClose)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxMax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxMin)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.PictureBox pictureBoxtitle;
        protected DevComponents.DotNetBar.LabelX labelTitle;
        private System.Windows.Forms.ToolStrip toolStrip1;
        protected System.Windows.Forms.ToolStripButton toolStripButtonProfit;
        protected System.Windows.Forms.ToolStripButton toolStripButtonshuaixin;
        protected System.Windows.Forms.ToolStripButton toolStripButtondayin;
        protected System.Windows.Forms.ToolStripButton toolStripButtondaochu;
        private System.Windows.Forms.ToolStripButton toolStripButtonClose;
        private DevComponents.DotNetBar.SuperGrid.SuperGridControl superGridControlShangPing;
        protected System.Windows.Forms.PictureBox pictureBoxClose;
        public System.Windows.Forms.PictureBox pictureBoxMax;
        public System.Windows.Forms.PictureBox pictureBoxMin;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}