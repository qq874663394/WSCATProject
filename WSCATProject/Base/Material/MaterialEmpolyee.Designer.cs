namespace WSCATProject.Base
{
    partial class MaterialEmpolyee
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MaterialEmpolyee));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripDropDownButton1 = new System.Windows.Forms.ToolStripDropDownButton();
            this.InsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.UpdToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AllDelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.ExportExcelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.RefreshToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripButton4 = new System.Windows.Forms.ToolStripButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.superGridControl1 = new DevComponents.DotNetBar.SuperGrid.SuperGridControl();
            this.contextMenuStrip2 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.新增NToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.编辑EToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.删除DToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.全部删除ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.导出到ExcelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.刷新ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.contextMenuStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripDropDownButton1,
            this.toolStripButton4});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.MinimumSize = new System.Drawing.Size(0, 35);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(938, 35);
            this.toolStrip1.TabIndex = 2;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripDropDownButton1
            // 
            this.toolStripDropDownButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.InsToolStripMenuItem,
            this.UpdToolStripMenuItem,
            this.DelToolStripMenuItem,
            this.AllDelToolStripMenuItem,
            this.toolStripSeparator1,
            this.ExportExcelToolStripMenuItem,
            this.RefreshToolStripMenuItem});
            this.toolStripDropDownButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButton1.Image")));
            this.toolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton1.Name = "toolStripDropDownButton1";
            this.toolStripDropDownButton1.ShowDropDownArrow = false;
            this.toolStripDropDownButton1.Size = new System.Drawing.Size(66, 32);
            this.toolStripDropDownButton1.Text = "操作(&F)";
            // 
            // InsToolStripMenuItem
            // 
            this.InsToolStripMenuItem.Image = global::WSCATProject.Properties.Resources.arrowsDown;
            this.InsToolStripMenuItem.Name = "InsToolStripMenuItem";
            this.InsToolStripMenuItem.ShortcutKeyDisplayString = "Ctrl+N";
            this.InsToolStripMenuItem.Size = new System.Drawing.Size(200, 22);
            this.InsToolStripMenuItem.Text = "新增(&N)";
            this.InsToolStripMenuItem.Click += new System.EventHandler(this.InsToolStripMenuItem_Click);
            // 
            // UpdToolStripMenuItem
            // 
            this.UpdToolStripMenuItem.Name = "UpdToolStripMenuItem";
            this.UpdToolStripMenuItem.ShortcutKeyDisplayString = "Ctrl+E";
            this.UpdToolStripMenuItem.Size = new System.Drawing.Size(200, 22);
            this.UpdToolStripMenuItem.Text = "编辑(&E)";
            this.UpdToolStripMenuItem.Click += new System.EventHandler(this.UpdToolStripMenuItem_Click);
            // 
            // DelToolStripMenuItem
            // 
            this.DelToolStripMenuItem.Name = "DelToolStripMenuItem";
            this.DelToolStripMenuItem.ShortcutKeyDisplayString = "Ctrl+D";
            this.DelToolStripMenuItem.Size = new System.Drawing.Size(200, 22);
            this.DelToolStripMenuItem.Text = "删除(&D)";
            this.DelToolStripMenuItem.Click += new System.EventHandler(this.DelToolStripMenuItem_Click);
            // 
            // AllDelToolStripMenuItem
            // 
            this.AllDelToolStripMenuItem.Name = "AllDelToolStripMenuItem";
            this.AllDelToolStripMenuItem.ShortcutKeyDisplayString = "Shift+Del";
            this.AllDelToolStripMenuItem.Size = new System.Drawing.Size(200, 22);
            this.AllDelToolStripMenuItem.Text = "全部删除";
            this.AllDelToolStripMenuItem.Click += new System.EventHandler(this.AllDelToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(197, 6);
            // 
            // ExportExcelToolStripMenuItem
            // 
            this.ExportExcelToolStripMenuItem.Name = "ExportExcelToolStripMenuItem";
            this.ExportExcelToolStripMenuItem.ShortcutKeyDisplayString = "Ctrl+T";
            this.ExportExcelToolStripMenuItem.Size = new System.Drawing.Size(200, 22);
            this.ExportExcelToolStripMenuItem.Text = "导出到(T)Excel";
            this.ExportExcelToolStripMenuItem.Click += new System.EventHandler(this.ExportExcelToolStripMenuItem_Click);
            // 
            // RefreshToolStripMenuItem
            // 
            this.RefreshToolStripMenuItem.Name = "RefreshToolStripMenuItem";
            this.RefreshToolStripMenuItem.ShortcutKeyDisplayString = "F5";
            this.RefreshToolStripMenuItem.Size = new System.Drawing.Size(200, 22);
            this.RefreshToolStripMenuItem.Text = "刷新";
            this.RefreshToolStripMenuItem.Click += new System.EventHandler(this.RefreshToolStripMenuItem_Click);
            // 
            // toolStripButton4
            // 
            this.toolStripButton4.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripButton4.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton4.Image")));
            this.toolStripButton4.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton4.Name = "toolStripButton4";
            this.toolStripButton4.Size = new System.Drawing.Size(120, 32);
            this.toolStripButton4.Text = "全部显示[含停用]";
            this.toolStripButton4.Click += new System.EventHandler(this.toolStripButton4_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.superGridControl1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 35);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(938, 363);
            this.panel1.TabIndex = 3;
            // 
            // superGridControl1
            // 
            this.superGridControl1.BackColor = System.Drawing.Color.White;
            this.superGridControl1.ContextMenuStrip = this.contextMenuStrip2;
            this.superGridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.superGridControl1.FilterExprColors.SysFunction = System.Drawing.Color.DarkRed;
            this.superGridControl1.ForeColor = System.Drawing.Color.White;
            this.superGridControl1.Location = new System.Drawing.Point(0, 0);
            this.superGridControl1.Name = "superGridControl1";
            this.superGridControl1.Size = new System.Drawing.Size(938, 363);
            this.superGridControl1.TabIndex = 4;
            this.superGridControl1.Text = "superGridControl1";
            // 
            // contextMenuStrip2
            // 
            this.contextMenuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.新增NToolStripMenuItem,
            this.编辑EToolStripMenuItem,
            this.删除DToolStripMenuItem,
            this.全部删除ToolStripMenuItem,
            this.toolStripSeparator3,
            this.导出到ExcelToolStripMenuItem,
            this.刷新ToolStripMenuItem});
            this.contextMenuStrip2.Name = "contextMenuStrip2";
            this.contextMenuStrip2.Size = new System.Drawing.Size(157, 142);
            // 
            // 新增NToolStripMenuItem
            // 
            this.新增NToolStripMenuItem.Name = "新增NToolStripMenuItem";
            this.新增NToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
            this.新增NToolStripMenuItem.Text = "新增(&N)";
            this.新增NToolStripMenuItem.Click += new System.EventHandler(this.新增NToolStripMenuItem_Click);
            // 
            // 编辑EToolStripMenuItem
            // 
            this.编辑EToolStripMenuItem.Name = "编辑EToolStripMenuItem";
            this.编辑EToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
            this.编辑EToolStripMenuItem.Text = "编辑(&E)";
            this.编辑EToolStripMenuItem.Click += new System.EventHandler(this.编辑EToolStripMenuItem_Click);
            // 
            // 删除DToolStripMenuItem
            // 
            this.删除DToolStripMenuItem.Name = "删除DToolStripMenuItem";
            this.删除DToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
            this.删除DToolStripMenuItem.Text = "删除(&D)";
            this.删除DToolStripMenuItem.Click += new System.EventHandler(this.删除DToolStripMenuItem_Click);
            // 
            // 全部删除ToolStripMenuItem
            // 
            this.全部删除ToolStripMenuItem.Name = "全部删除ToolStripMenuItem";
            this.全部删除ToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
            this.全部删除ToolStripMenuItem.Text = "全部删除";
            this.全部删除ToolStripMenuItem.Click += new System.EventHandler(this.全部删除ToolStripMenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(153, 6);
            // 
            // 导出到ExcelToolStripMenuItem
            // 
            this.导出到ExcelToolStripMenuItem.Name = "导出到ExcelToolStripMenuItem";
            this.导出到ExcelToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
            this.导出到ExcelToolStripMenuItem.Text = "导出到(&T)Excel";
            this.导出到ExcelToolStripMenuItem.Click += new System.EventHandler(this.导出到ExcelToolStripMenuItem_Click);
            // 
            // 刷新ToolStripMenuItem
            // 
            this.刷新ToolStripMenuItem.Name = "刷新ToolStripMenuItem";
            this.刷新ToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
            this.刷新ToolStripMenuItem.Text = "刷新";
            this.刷新ToolStripMenuItem.Click += new System.EventHandler(this.刷新ToolStripMenuItem_Click);
            // 
            // MaterialEmpolyee
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(938, 398);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "MaterialEmpolyee";
            this.Text = "EmplyeeMaster";
            this.Load += new System.EventHandler(this.EmplyeeMaster_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.contextMenuStrip2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.Panel panel1;
        protected System.Windows.Forms.ToolStripMenuItem InsToolStripMenuItem;
        protected System.Windows.Forms.ToolStripMenuItem UpdToolStripMenuItem;
        protected System.Windows.Forms.ToolStripMenuItem DelToolStripMenuItem;
        protected System.Windows.Forms.ToolStripMenuItem AllDelToolStripMenuItem;
        protected System.Windows.Forms.ToolStripMenuItem ExportExcelToolStripMenuItem;
        protected System.Windows.Forms.ToolStripMenuItem RefreshToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip2;
        private System.Windows.Forms.ToolStripMenuItem 新增NToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 编辑EToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 删除DToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 全部删除ToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem 导出到ExcelToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 刷新ToolStripMenuItem;
        protected DevComponents.DotNetBar.SuperGrid.SuperGridControl superGridControl1;
        protected System.Windows.Forms.ToolStripButton toolStripButton4;
    }
}