namespace WSCATProject.Base
{
    partial class AccountingSubjectsForm
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
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButtonProfit = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonshuaixin = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtondayin = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtondaochu = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonClose = new System.Windows.Forms.ToolStripButton();
            this.tabControl1 = new DevComponents.DotNetBar.TabControl();
            this.tabControlPanel5 = new DevComponents.DotNetBar.TabControlPanel();
            this.tabItemSunYi = new DevComponents.DotNetBar.TabItem(this.components);
            this.tabControlPanel1 = new DevComponents.DotNetBar.TabControlPanel();
            this.tabItemZiChan = new DevComponents.DotNetBar.TabItem(this.components);
            this.tabControlPanel2 = new DevComponents.DotNetBar.TabControlPanel();
            this.tabItemFuZhai = new DevComponents.DotNetBar.TabItem(this.components);
            this.tabControlPanel3 = new DevComponents.DotNetBar.TabControlPanel();
            this.tabItemQuanYi = new DevComponents.DotNetBar.TabItem(this.components);
            this.tabControlPanel4 = new DevComponents.DotNetBar.TabControlPanel();
            this.tabItemChengBen = new DevComponents.DotNetBar.TabItem(this.components);
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tabControl1)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabControlPanel1.SuspendLayout();
            this.SuspendLayout();
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
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(653, 60);
            this.toolStrip1.TabIndex = 55;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButtonProfit
            // 
            this.toolStripButtonProfit.Image = global::WSCATProject.Properties.Resources.business;
            this.toolStripButtonProfit.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButtonProfit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonProfit.Margin = new System.Windows.Forms.Padding(0, 2, 0, 2);
            this.toolStripButtonProfit.Name = "toolStripButtonProfit";
            this.toolStripButtonProfit.Size = new System.Drawing.Size(41, 56);
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
            this.toolStripButtondayin.Size = new System.Drawing.Size(41, 56);
            this.toolStripButtondayin.Text = "新增";
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
            this.toolStripButtondaochu.Size = new System.Drawing.Size(41, 56);
            this.toolStripButtondaochu.Text = "修改";
            this.toolStripButtondaochu.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolStripButtondaochu.ToolTipText = "导出Excel(Ctrl+T)";
            // 
            // toolStripButtonClose
            // 
            this.toolStripButtonClose.Image = global::WSCATProject.Properties.Resources.guanbi;
            this.toolStripButtonClose.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButtonClose.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonClose.Name = "toolStripButtonClose";
            this.toolStripButtonClose.Size = new System.Drawing.Size(41, 57);
            this.toolStripButtonClose.Text = "删除";
            this.toolStripButtonClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolStripButtonClose.ToolTipText = "关闭(Ctrl+X)";
            // 
            // tabControl1
            // 
            this.tabControl1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.tabControl1.CanReorderTabs = true;
            this.tabControl1.Controls.Add(this.tabControlPanel1);
            this.tabControl1.Controls.Add(this.tabControlPanel3);
            this.tabControl1.Controls.Add(this.tabControlPanel2);
            this.tabControl1.Controls.Add(this.tabControlPanel5);
            this.tabControl1.Controls.Add(this.tabControlPanel4);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 60);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedTabFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold);
            this.tabControl1.SelectedTabIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(653, 436);
            this.tabControl1.TabIndex = 56;
            this.tabControl1.TabLayoutType = DevComponents.DotNetBar.eTabLayoutType.FixedWithNavigationBox;
            this.tabControl1.Tabs.Add(this.tabItemZiChan);
            this.tabControl1.Tabs.Add(this.tabItemFuZhai);
            this.tabControl1.Tabs.Add(this.tabItemQuanYi);
            this.tabControl1.Tabs.Add(this.tabItemChengBen);
            this.tabControl1.Tabs.Add(this.tabItemSunYi);
            this.tabControl1.Text = "tabControl1";
            // 
            // tabControlPanel5
            // 
            this.tabControlPanel5.DisabledBackColor = System.Drawing.Color.Empty;
            this.tabControlPanel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlPanel5.Location = new System.Drawing.Point(0, 40);
            this.tabControlPanel5.Name = "tabControlPanel5";
            this.tabControlPanel5.Padding = new System.Windows.Forms.Padding(1);
            this.tabControlPanel5.Size = new System.Drawing.Size(653, 396);
            this.tabControlPanel5.Style.BackColor1.Color = System.Drawing.Color.White;
            this.tabControlPanel5.Style.BackColor2.Color = System.Drawing.Color.White;
            this.tabControlPanel5.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.tabControlPanel5.Style.BorderColor.Color = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(97)))), ((int)(((byte)(156)))));
            this.tabControlPanel5.Style.BorderSide = ((DevComponents.DotNetBar.eBorderSide)(((DevComponents.DotNetBar.eBorderSide.Left | DevComponents.DotNetBar.eBorderSide.Right) 
            | DevComponents.DotNetBar.eBorderSide.Bottom)));
            this.tabControlPanel5.Style.GradientAngle = -90;
            this.tabControlPanel5.TabIndex = 17;
            this.tabControlPanel5.TabItem = this.tabItemSunYi;
            // 
            // tabItemSunYi
            // 
            this.tabItemSunYi.AttachedControl = this.tabControlPanel5;
            this.tabItemSunYi.BackColor = System.Drawing.Color.White;
            this.tabItemSunYi.BackColor2 = System.Drawing.Color.White;
            this.tabItemSunYi.Image = global::WSCATProject.Properties.Resources.shouyi;
            this.tabItemSunYi.Name = "tabItemSunYi";
            this.tabItemSunYi.Text = "5、损益";
            this.tabItemSunYi.Click += new System.EventHandler(this.tabItemSunYi_Click);
            // 
            // tabControlPanel1
            // 
            this.tabControlPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.OfficeMobile2014;
            this.tabControlPanel1.Controls.Add(this.treeView1);
            this.tabControlPanel1.DisabledBackColor = System.Drawing.Color.Empty;
            this.tabControlPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlPanel1.Location = new System.Drawing.Point(0, 40);
            this.tabControlPanel1.Name = "tabControlPanel1";
            this.tabControlPanel1.Padding = new System.Windows.Forms.Padding(1);
            this.tabControlPanel1.Size = new System.Drawing.Size(653, 396);
            this.tabControlPanel1.Style.BackColor1.Color = System.Drawing.Color.White;
            this.tabControlPanel1.Style.BackColor2.Color = System.Drawing.Color.White;
            this.tabControlPanel1.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.tabControlPanel1.Style.BorderColor.Color = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(97)))), ((int)(((byte)(156)))));
            this.tabControlPanel1.Style.BorderSide = ((DevComponents.DotNetBar.eBorderSide)(((DevComponents.DotNetBar.eBorderSide.Left | DevComponents.DotNetBar.eBorderSide.Right) 
            | DevComponents.DotNetBar.eBorderSide.Bottom)));
            this.tabControlPanel1.Style.GradientAngle = -90;
            this.tabControlPanel1.TabIndex = 1;
            this.tabControlPanel1.TabItem = this.tabItemZiChan;
            // 
            // tabItemZiChan
            // 
            this.tabItemZiChan.AttachedControl = this.tabControlPanel1;
            this.tabItemZiChan.BackColor = System.Drawing.Color.White;
            this.tabItemZiChan.BackColor2 = System.Drawing.Color.White;
            this.tabItemZiChan.Image = global::WSCATProject.Properties.Resources.car;
            this.tabItemZiChan.Name = "tabItemZiChan";
            this.tabItemZiChan.Text = "1、资产";
            this.tabItemZiChan.Click += new System.EventHandler(this.tabItemZiChan_Click);
            // 
            // tabControlPanel2
            // 
            this.tabControlPanel2.DisabledBackColor = System.Drawing.Color.Empty;
            this.tabControlPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlPanel2.Location = new System.Drawing.Point(0, 40);
            this.tabControlPanel2.Name = "tabControlPanel2";
            this.tabControlPanel2.Padding = new System.Windows.Forms.Padding(1);
            this.tabControlPanel2.Size = new System.Drawing.Size(653, 396);
            this.tabControlPanel2.Style.BackColor1.Color = System.Drawing.Color.White;
            this.tabControlPanel2.Style.BackColor2.Color = System.Drawing.Color.White;
            this.tabControlPanel2.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.tabControlPanel2.Style.BorderColor.Color = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(97)))), ((int)(((byte)(156)))));
            this.tabControlPanel2.Style.BorderSide = ((DevComponents.DotNetBar.eBorderSide)(((DevComponents.DotNetBar.eBorderSide.Left | DevComponents.DotNetBar.eBorderSide.Right) 
            | DevComponents.DotNetBar.eBorderSide.Bottom)));
            this.tabControlPanel2.Style.GradientAngle = -90;
            this.tabControlPanel2.TabIndex = 5;
            this.tabControlPanel2.TabItem = this.tabItemFuZhai;
            // 
            // tabItemFuZhai
            // 
            this.tabItemFuZhai.AttachedControl = this.tabControlPanel2;
            this.tabItemFuZhai.BackColor = System.Drawing.Color.White;
            this.tabItemFuZhai.BackColor2 = System.Drawing.Color.White;
            this.tabItemFuZhai.Image = global::WSCATProject.Properties.Resources.fuzhai;
            this.tabItemFuZhai.Name = "tabItemFuZhai";
            this.tabItemFuZhai.Text = "2、负债";
            this.tabItemFuZhai.Click += new System.EventHandler(this.tabItemFuZhai_Click);
            // 
            // tabControlPanel3
            // 
            this.tabControlPanel3.DisabledBackColor = System.Drawing.Color.Empty;
            this.tabControlPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlPanel3.Location = new System.Drawing.Point(0, 40);
            this.tabControlPanel3.Name = "tabControlPanel3";
            this.tabControlPanel3.Padding = new System.Windows.Forms.Padding(1);
            this.tabControlPanel3.Size = new System.Drawing.Size(653, 396);
            this.tabControlPanel3.Style.BackColor1.Color = System.Drawing.Color.White;
            this.tabControlPanel3.Style.BackColor2.Color = System.Drawing.Color.White;
            this.tabControlPanel3.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.tabControlPanel3.Style.BorderColor.Color = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(97)))), ((int)(((byte)(156)))));
            this.tabControlPanel3.Style.BorderSide = ((DevComponents.DotNetBar.eBorderSide)(((DevComponents.DotNetBar.eBorderSide.Left | DevComponents.DotNetBar.eBorderSide.Right) 
            | DevComponents.DotNetBar.eBorderSide.Bottom)));
            this.tabControlPanel3.Style.GradientAngle = -90;
            this.tabControlPanel3.TabIndex = 9;
            this.tabControlPanel3.TabItem = this.tabItemQuanYi;
            // 
            // tabItemQuanYi
            // 
            this.tabItemQuanYi.AttachedControl = this.tabControlPanel3;
            this.tabItemQuanYi.BackColor = System.Drawing.Color.White;
            this.tabItemQuanYi.BackColor2 = System.Drawing.Color.White;
            this.tabItemQuanYi.Image = global::WSCATProject.Properties.Resources.quanyi;
            this.tabItemQuanYi.Name = "tabItemQuanYi";
            this.tabItemQuanYi.Text = "3、权益";
            this.tabItemQuanYi.Click += new System.EventHandler(this.tabItemQuanYi_Click);
            // 
            // tabControlPanel4
            // 
            this.tabControlPanel4.DisabledBackColor = System.Drawing.Color.Empty;
            this.tabControlPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlPanel4.Location = new System.Drawing.Point(0, 40);
            this.tabControlPanel4.Name = "tabControlPanel4";
            this.tabControlPanel4.Padding = new System.Windows.Forms.Padding(1);
            this.tabControlPanel4.Size = new System.Drawing.Size(653, 396);
            this.tabControlPanel4.Style.BackColor1.Color = System.Drawing.Color.White;
            this.tabControlPanel4.Style.BackColor2.Color = System.Drawing.Color.White;
            this.tabControlPanel4.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.tabControlPanel4.Style.BorderColor.Color = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(97)))), ((int)(((byte)(156)))));
            this.tabControlPanel4.Style.BorderSide = ((DevComponents.DotNetBar.eBorderSide)(((DevComponents.DotNetBar.eBorderSide.Left | DevComponents.DotNetBar.eBorderSide.Right) 
            | DevComponents.DotNetBar.eBorderSide.Bottom)));
            this.tabControlPanel4.Style.GradientAngle = -90;
            this.tabControlPanel4.TabIndex = 13;
            this.tabControlPanel4.TabItem = this.tabItemChengBen;
            // 
            // tabItemChengBen
            // 
            this.tabItemChengBen.AttachedControl = this.tabControlPanel4;
            this.tabItemChengBen.BackColor = System.Drawing.Color.White;
            this.tabItemChengBen.BackColor2 = System.Drawing.Color.White;
            this.tabItemChengBen.Image = global::WSCATProject.Properties.Resources.chengben;
            this.tabItemChengBen.Name = "tabItemChengBen";
            this.tabItemChengBen.Text = "4、成本";
            this.tabItemChengBen.Click += new System.EventHandler(this.tabItemChengBen_Click);
            // 
            // treeView1
            // 
            this.treeView1.Location = new System.Drawing.Point(83, 53);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(121, 97);
            this.treeView1.TabIndex = 0;
            // 
            // AccountingSubjectsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(653, 496);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "AccountingSubjectsForm";
            this.Text = "会计科目";
            this.Load += new System.EventHandler(this.AccountingSubjectsForm_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tabControl1)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabControlPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        protected System.Windows.Forms.ToolStripButton toolStripButtonProfit;
        protected System.Windows.Forms.ToolStripButton toolStripButtonshuaixin;
        protected System.Windows.Forms.ToolStripButton toolStripButtondayin;
        protected System.Windows.Forms.ToolStripButton toolStripButtondaochu;
        private System.Windows.Forms.ToolStripButton toolStripButtonClose;
        private DevComponents.DotNetBar.TabControl tabControl1;
        private DevComponents.DotNetBar.TabControlPanel tabControlPanel5;
        private DevComponents.DotNetBar.TabItem tabItemSunYi;
        private DevComponents.DotNetBar.TabControlPanel tabControlPanel4;
        private DevComponents.DotNetBar.TabItem tabItemChengBen;
        private DevComponents.DotNetBar.TabControlPanel tabControlPanel3;
        private DevComponents.DotNetBar.TabItem tabItemQuanYi;
        private DevComponents.DotNetBar.TabControlPanel tabControlPanel2;
        private DevComponents.DotNetBar.TabItem tabItemFuZhai;
        private DevComponents.DotNetBar.TabControlPanel tabControlPanel1;
        private DevComponents.DotNetBar.TabItem tabItemZiChan;
        private System.Windows.Forms.TreeView treeView1;
    }
}