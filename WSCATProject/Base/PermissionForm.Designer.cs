namespace WSCATProject.Base
{
    partial class PermissionForm
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
            this.treeViewUser = new System.Windows.Forms.TreeView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.新增角色ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.修改角色ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.删除角色ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.comboBoxEx1 = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.label1 = new System.Windows.Forms.Label();
            this.line1 = new DevComponents.DotNetBar.Controls.Line();
            this.panelPermission = new System.Windows.Forms.Panel();
            this.superGridControlPer = new DevComponents.DotNetBar.SuperGrid.SuperGridControl();
            this.gridColumn7 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            this.gridColumn6 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            this.gridColumn1 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            this.gridColumn2 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            this.gridColumn3 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            this.gridColumn4 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            this.gridColumn5 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            this.gridColumn8 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            this.gridColumn9 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            this.panel2 = new System.Windows.Forms.Panel();
            this.buttonInverse = new System.Windows.Forms.Button();
            this.buttonSelectAll = new System.Windows.Forms.Button();
            this.buttonSave = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.gridCell1 = new DevComponents.DotNetBar.SuperGrid.GridCell();
            this.gridCell2 = new DevComponents.DotNetBar.SuperGrid.GridCell();
            this.gridCell3 = new DevComponents.DotNetBar.SuperGrid.GridCell();
            this.gridCell4 = new DevComponents.DotNetBar.SuperGrid.GridCell();
            this.contextMenuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panelPermission.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // treeViewUser
            // 
            this.treeViewUser.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.treeViewUser.ContextMenuStrip = this.contextMenuStrip1;
            this.treeViewUser.Dock = System.Windows.Forms.DockStyle.Left;
            this.treeViewUser.Location = new System.Drawing.Point(0, 0);
            this.treeViewUser.Name = "treeViewUser";
            this.treeViewUser.Size = new System.Drawing.Size(158, 547);
            this.treeViewUser.TabIndex = 0;
            this.treeViewUser.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeViewUser_AfterSelect);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.新增角色ToolStripMenuItem,
            this.修改角色ToolStripMenuItem,
            this.删除角色ToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(125, 70);
            // 
            // 新增角色ToolStripMenuItem
            // 
            this.新增角色ToolStripMenuItem.Name = "新增角色ToolStripMenuItem";
            this.新增角色ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.新增角色ToolStripMenuItem.Text = "新增角色";
            this.新增角色ToolStripMenuItem.Click += new System.EventHandler(this.新增角色ToolStripMenuItem_Click);
            // 
            // 修改角色ToolStripMenuItem
            // 
            this.修改角色ToolStripMenuItem.Name = "修改角色ToolStripMenuItem";
            this.修改角色ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.修改角色ToolStripMenuItem.Text = "修改角色";
            this.修改角色ToolStripMenuItem.Click += new System.EventHandler(this.修改角色ToolStripMenuItem_Click);
            // 
            // 删除角色ToolStripMenuItem
            // 
            this.删除角色ToolStripMenuItem.Name = "删除角色ToolStripMenuItem";
            this.删除角色ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.删除角色ToolStripMenuItem.Text = "删除角色";
            this.删除角色ToolStripMenuItem.Click += new System.EventHandler(this.删除角色ToolStripMenuItem_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.comboBoxEx1);
            this.panel1.Controls.Add(this.labelX1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.line1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(158, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(604, 48);
            this.panel1.TabIndex = 1;
            // 
            // comboBoxEx1
            // 
            this.comboBoxEx1.DisplayMember = "Text";
            this.comboBoxEx1.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.comboBoxEx1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxEx1.FormattingEnabled = true;
            this.comboBoxEx1.ItemHeight = 15;
            this.comboBoxEx1.Location = new System.Drawing.Point(463, 12);
            this.comboBoxEx1.Name = "comboBoxEx1";
            this.comboBoxEx1.Size = new System.Drawing.Size(129, 21);
            this.comboBoxEx1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.comboBoxEx1.TabIndex = 2;
            this.comboBoxEx1.Visible = false;
            this.comboBoxEx1.SelectedIndexChanged += new System.EventHandler(this.comboBoxEx1_SelectedIndexChanged);
            // 
            // labelX1
            // 
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.Location = new System.Drawing.Point(421, 12);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(50, 23);
            this.labelX1.TabIndex = 3;
            this.labelX1.Text = "筛选：";
            this.labelX1.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 14F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.label1.Location = new System.Drawing.Point(8, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 19);
            this.label1.TabIndex = 1;
            this.label1.Text = "权限设置";
            // 
            // line1
            // 
            this.line1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.line1.ForeColor = System.Drawing.SystemColors.ButtonShadow;
            this.line1.Location = new System.Drawing.Point(0, 38);
            this.line1.Name = "line1";
            this.line1.Size = new System.Drawing.Size(604, 10);
            this.line1.TabIndex = 0;
            this.line1.Text = "line1";
            // 
            // panelPermission
            // 
            this.panelPermission.AutoScroll = true;
            this.panelPermission.BackColor = System.Drawing.Color.White;
            this.panelPermission.Controls.Add(this.superGridControlPer);
            this.panelPermission.Controls.Add(this.panel2);
            this.panelPermission.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelPermission.Location = new System.Drawing.Point(158, 48);
            this.panelPermission.Name = "panelPermission";
            this.panelPermission.Size = new System.Drawing.Size(604, 499);
            this.panelPermission.TabIndex = 2;
            // 
            // superGridControlPer
            // 
            this.superGridControlPer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.superGridControlPer.FilterExprColors.SysFunction = System.Drawing.Color.DarkRed;
            this.superGridControlPer.Location = new System.Drawing.Point(0, 0);
            this.superGridControlPer.Name = "superGridControlPer";
            // 
            // 
            // 
            this.superGridControlPer.PrimaryGrid.Columns.Add(this.gridColumn7);
            this.superGridControlPer.PrimaryGrid.Columns.Add(this.gridColumn6);
            this.superGridControlPer.PrimaryGrid.Columns.Add(this.gridColumn1);
            this.superGridControlPer.PrimaryGrid.Columns.Add(this.gridColumn2);
            this.superGridControlPer.PrimaryGrid.Columns.Add(this.gridColumn3);
            this.superGridControlPer.PrimaryGrid.Columns.Add(this.gridColumn4);
            this.superGridControlPer.PrimaryGrid.Columns.Add(this.gridColumn5);
            this.superGridControlPer.PrimaryGrid.Columns.Add(this.gridColumn8);
            this.superGridControlPer.PrimaryGrid.Columns.Add(this.gridColumn9);
            this.superGridControlPer.PrimaryGrid.RowHeaderWidth = 10;
            this.superGridControlPer.Size = new System.Drawing.Size(604, 455);
            this.superGridControlPer.TabIndex = 29;
            this.superGridControlPer.Text = "superGridControl1";
            // 
            // gridColumn7
            // 
            this.gridColumn7.DataPropertyName = "Per_ID";
            this.gridColumn7.HeaderText = "ID";
            this.gridColumn7.Name = "Per_ID";
            this.gridColumn7.Visible = false;
            // 
            // gridColumn6
            // 
            this.gridColumn6.DataPropertyName = "Per_Code";
            this.gridColumn6.HeaderText = "code";
            this.gridColumn6.Name = "Per_Code";
            this.gridColumn6.Visible = false;
            // 
            // gridColumn1
            // 
            this.gridColumn1.AllowEdit = false;
            this.gridColumn1.AutoSizeMode = DevComponents.DotNetBar.SuperGrid.ColumnAutoSizeMode.Fill;
            this.gridColumn1.DataPropertyName = "Per_ModuleName";
            this.gridColumn1.HeaderText = "模块名称";
            this.gridColumn1.Name = "Per_ModuleName";
            // 
            // gridColumn2
            // 
            this.gridColumn2.CellStyles.Default.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleCenter;
            this.gridColumn2.DataPropertyName = "Per_ReadState";
            this.gridColumn2.EditorType = typeof(DevComponents.DotNetBar.SuperGrid.GridCheckBoxXEditControl);
            this.gridColumn2.HeaderText = "读取";
            this.gridColumn2.Name = "Per_ReadState";
            // 
            // gridColumn3
            // 
            this.gridColumn3.CellStyles.Default.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleCenter;
            this.gridColumn3.DataPropertyName = "Per_WriteState";
            this.gridColumn3.EditorType = typeof(DevComponents.DotNetBar.SuperGrid.GridCheckBoxXEditControl);
            this.gridColumn3.HeaderText = "写入";
            this.gridColumn3.Name = "Per_WriteState";
            // 
            // gridColumn4
            // 
            this.gridColumn4.CellStyles.Default.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleCenter;
            this.gridColumn4.DataPropertyName = "Per_AuditState";
            this.gridColumn4.EditorType = typeof(DevComponents.DotNetBar.SuperGrid.GridCheckBoxXEditControl);
            this.gridColumn4.HeaderText = "审核";
            this.gridColumn4.Name = "Per_AuditState";
            // 
            // gridColumn5
            // 
            this.gridColumn5.DataPropertyName = "Per_Clear";
            this.gridColumn5.HeaderText = "clear";
            this.gridColumn5.Name = "Per_Clear";
            this.gridColumn5.Visible = false;
            // 
            // gridColumn8
            // 
            this.gridColumn8.DataPropertyName = "Per_Type";
            this.gridColumn8.HeaderText = "隶属于";
            this.gridColumn8.Name = "Per_Type";
            this.gridColumn8.Visible = false;
            // 
            // gridColumn9
            // 
            this.gridColumn9.DataPropertyName = "Per_RoleCode";
            this.gridColumn9.HeaderText = "角色名";
            this.gridColumn9.Name = "Per_RoleCode";
            this.gridColumn9.Visible = false;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.buttonInverse);
            this.panel2.Controls.Add(this.buttonSelectAll);
            this.panel2.Controls.Add(this.buttonSave);
            this.panel2.Controls.Add(this.buttonCancel);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 455);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(604, 44);
            this.panel2.TabIndex = 28;
            // 
            // buttonInverse
            // 
            this.buttonInverse.BackColor = System.Drawing.SystemColors.Control;
            this.buttonInverse.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonInverse.Location = new System.Drawing.Point(124, 11);
            this.buttonInverse.Name = "buttonInverse";
            this.buttonInverse.Size = new System.Drawing.Size(75, 23);
            this.buttonInverse.TabIndex = 3;
            this.buttonInverse.Text = "反选";
            this.buttonInverse.UseVisualStyleBackColor = false;
            this.buttonInverse.Click += new System.EventHandler(this.buttonInverse_Click);
            // 
            // buttonSelectAll
            // 
            this.buttonSelectAll.BackColor = System.Drawing.SystemColors.Control;
            this.buttonSelectAll.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonSelectAll.Location = new System.Drawing.Point(22, 11);
            this.buttonSelectAll.Name = "buttonSelectAll";
            this.buttonSelectAll.Size = new System.Drawing.Size(75, 23);
            this.buttonSelectAll.TabIndex = 2;
            this.buttonSelectAll.Text = "全选";
            this.buttonSelectAll.UseVisualStyleBackColor = false;
            this.buttonSelectAll.Click += new System.EventHandler(this.buttonSelectAll_Click);
            // 
            // buttonSave
            // 
            this.buttonSave.BackColor = System.Drawing.SystemColors.Control;
            this.buttonSave.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonSave.Location = new System.Drawing.Point(418, 11);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(75, 23);
            this.buttonSave.TabIndex = 1;
            this.buttonSave.Text = "保存";
            this.buttonSave.UseVisualStyleBackColor = false;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.BackColor = System.Drawing.SystemColors.Control;
            this.buttonCancel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonCancel.Location = new System.Drawing.Point(517, 11);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 0;
            this.buttonCancel.Text = "取消";
            this.buttonCancel.UseVisualStyleBackColor = false;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // gridCell1
            // 
            this.gridCell1.EditorType = typeof(DevComponents.DotNetBar.SuperGrid.GridTextBoxXEditControl);
            this.gridCell1.InfoText = "";
            this.gridCell1.Value = "dsferf";
            // 
            // gridCell2
            // 
            this.gridCell2.EditorType = typeof(DevComponents.DotNetBar.SuperGrid.GridCheckBoxXEditControl);
            this.gridCell2.InfoText = "";
            this.gridCell2.Value = true;
            // 
            // gridCell3
            // 
            this.gridCell3.EditorType = typeof(DevComponents.DotNetBar.SuperGrid.GridCheckBoxXEditControl);
            this.gridCell3.InfoText = "";
            this.gridCell3.Value = true;
            // 
            // gridCell4
            // 
            this.gridCell4.EditorType = typeof(DevComponents.DotNetBar.SuperGrid.GridCheckBoxXEditControl);
            this.gridCell4.Value = true;
            // 
            // PermissionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(762, 547);
            this.Controls.Add(this.panelPermission);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.treeViewUser);
            this.Name = "PermissionForm";
            this.Load += new System.EventHandler(this.PermissionForm_Load);
            this.contextMenuStrip1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panelPermission.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView treeViewUser;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panelPermission;
        private System.Windows.Forms.Label label1;
        private DevComponents.DotNetBar.Controls.Line line1;
        private DevComponents.DotNetBar.Controls.ComboBoxEx comboBoxEx1;
        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.DotNetBar.SuperGrid.SuperGridControl superGridControlPer;
        private DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn1;
        private DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn2;
        private DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn3;
        private DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn4;
        private DevComponents.DotNetBar.SuperGrid.GridCell gridCell1;
        private DevComponents.DotNetBar.SuperGrid.GridCell gridCell2;
        private DevComponents.DotNetBar.SuperGrid.GridCell gridCell3;
        private DevComponents.DotNetBar.SuperGrid.GridCell gridCell4;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button buttonInverse;
        private System.Windows.Forms.Button buttonSelectAll;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Button buttonCancel;
        private DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn7;
        private DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn6;
        private DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn5;
        private DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn8;
        private DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn9;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 新增角色ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 修改角色ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 删除角色ToolStripMenuItem;
    }
}