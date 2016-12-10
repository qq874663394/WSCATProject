namespace WSCATProject.Base.Shelves
{
    partial class ShelvesListForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ShelvesListForm));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripDropDownButton();
            this.新增同级分类BToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.新增下级分类NToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.编辑EToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.删除DToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.全部删除ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.展开第一节TToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.全部展开AToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.刷新ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.comboBoxck = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.toolStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(274, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.新增同级分类BToolStripMenuItem,
            this.新增下级分类NToolStripMenuItem,
            this.编辑EToolStripMenuItem,
            this.删除DToolStripMenuItem,
            this.全部删除ToolStripMenuItem,
            this.展开第一节TToolStripMenuItem,
            this.全部展开AToolStripMenuItem,
            this.刷新ToolStripMenuItem});
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(61, 22);
            this.toolStripButton1.Text = "操作";
            // 
            // 新增同级分类BToolStripMenuItem
            // 
            this.新增同级分类BToolStripMenuItem.Name = "新增同级分类BToolStripMenuItem";
            this.新增同级分类BToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.新增同级分类BToolStripMenuItem.Text = "新增同级分类(&B)";
            // 
            // 新增下级分类NToolStripMenuItem
            // 
            this.新增下级分类NToolStripMenuItem.Name = "新增下级分类NToolStripMenuItem";
            this.新增下级分类NToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.新增下级分类NToolStripMenuItem.Text = "新增下级分类(&N)";
            // 
            // 编辑EToolStripMenuItem
            // 
            this.编辑EToolStripMenuItem.Name = "编辑EToolStripMenuItem";
            this.编辑EToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.编辑EToolStripMenuItem.Text = "编辑（&E）";
            // 
            // 删除DToolStripMenuItem
            // 
            this.删除DToolStripMenuItem.Name = "删除DToolStripMenuItem";
            this.删除DToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.删除DToolStripMenuItem.Text = "删除(&D)";
            // 
            // 全部删除ToolStripMenuItem
            // 
            this.全部删除ToolStripMenuItem.Name = "全部删除ToolStripMenuItem";
            this.全部删除ToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.全部删除ToolStripMenuItem.Text = "全部删除";
            // 
            // 展开第一节TToolStripMenuItem
            // 
            this.展开第一节TToolStripMenuItem.Name = "展开第一节TToolStripMenuItem";
            this.展开第一节TToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.展开第一节TToolStripMenuItem.Text = "展开第一节(&T)";
            // 
            // 全部展开AToolStripMenuItem
            // 
            this.全部展开AToolStripMenuItem.Name = "全部展开AToolStripMenuItem";
            this.全部展开AToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.全部展开AToolStripMenuItem.Text = "全部展开(&A)";
            // 
            // 刷新ToolStripMenuItem
            // 
            this.刷新ToolStripMenuItem.Name = "刷新ToolStripMenuItem";
            this.刷新ToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.刷新ToolStripMenuItem.Text = "刷新";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.comboBoxck);
            this.panel1.Controls.Add(this.labelX1);
            this.panel1.Controls.Add(this.treeView1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 25);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(274, 414);
            this.panel1.TabIndex = 1;
            // 
            // comboBoxck
            // 
            this.comboBoxck.DisplayMember = "Text";
            this.comboBoxck.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.comboBoxck.FormattingEnabled = true;
            this.comboBoxck.ItemHeight = 15;
            this.comboBoxck.Location = new System.Drawing.Point(107, 6);
            this.comboBoxck.Name = "comboBoxck";
            this.comboBoxck.Size = new System.Drawing.Size(121, 21);
            this.comboBoxck.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.comboBoxck.TabIndex = 2;
            this.comboBoxck.SelectedIndexChanged += new System.EventHandler(this.comboBoxck_SelectedIndexChanged);
            // 
            // labelX1
            // 
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.Location = new System.Drawing.Point(24, 6);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(79, 23);
            this.labelX1.TabIndex = 1;
            this.labelX1.Text = "请选择仓库：";
            // 
            // treeView1
            // 
            this.treeView1.Location = new System.Drawing.Point(0, 34);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(274, 380);
            this.treeView1.TabIndex = 0;
            // 
            // ShelvesListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(274, 439);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "ShelvesListForm";
            this.Text = "货架信息";
            this.Load += new System.EventHandler(this.ShelvesListForm_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.ToolStripDropDownButton toolStripButton1;
        private System.Windows.Forms.ToolStripMenuItem 新增同级分类BToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 新增下级分类NToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 编辑EToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 删除DToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 全部删除ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 展开第一节TToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 全部展开AToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 刷新ToolStripMenuItem;
        private DevComponents.DotNetBar.Controls.ComboBoxEx comboBoxck;
        private DevComponents.DotNetBar.LabelX labelX1;
    }
}