namespace WSCATProject.Warehouse
{
    partial class TestVoidForm
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
            this.button1 = new System.Windows.Forms.Button();
            this.sgCustomers = new DevComponents.DotNetBar.SuperGrid.SuperGridControl();
            this.gridColumn3 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            this.gridColumn4 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            this.gridColumn5 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            this.gridCell1 = new DevComponents.DotNetBar.SuperGrid.GridCell();
            this.gridCell2 = new DevComponents.DotNetBar.SuperGrid.GridCell();
            this.gridCell3 = new DevComponents.DotNetBar.SuperGrid.GridCell();
            this.gridCell4 = new DevComponents.DotNetBar.SuperGrid.GridCell();
            this.gridCell5 = new DevComponents.DotNetBar.SuperGrid.GridCell();
            this.gridCell6 = new DevComponents.DotNetBar.SuperGrid.GridCell();
            this.gridCell7 = new DevComponents.DotNetBar.SuperGrid.GridCell();
            this.gridCell8 = new DevComponents.DotNetBar.SuperGrid.GridCell();
            this.gridCell9 = new DevComponents.DotNetBar.SuperGrid.GridCell();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "查询";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // sgCustomers
            // 
            this.sgCustomers.FilterExprColors.SysFunction = System.Drawing.Color.DarkRed;
            this.sgCustomers.Location = new System.Drawing.Point(-2, 50);
            this.sgCustomers.Name = "sgCustomers";
            // 
            // 
            // 
            this.sgCustomers.PrimaryGrid.AllowRowDelete = true;
            this.sgCustomers.PrimaryGrid.AllowRowInsert = true;
            this.sgCustomers.PrimaryGrid.Columns.Add(this.gridColumn3);
            this.sgCustomers.PrimaryGrid.Columns.Add(this.gridColumn4);
            this.sgCustomers.PrimaryGrid.Columns.Add(this.gridColumn5);
            this.sgCustomers.PrimaryGrid.Name = "sgCustomers";
            this.sgCustomers.PrimaryGrid.ShowInsertRow = true;
            this.sgCustomers.Size = new System.Drawing.Size(1118, 576);
            this.sgCustomers.TabIndex = 2;
            // 
            // gridColumn3
            // 
            this.gridColumn3.DataPropertyName = "id";
            this.gridColumn3.HeaderText = "id";
            this.gridColumn3.Name = "id";
            // 
            // gridColumn4
            // 
            this.gridColumn4.DataPropertyName = "code";
            this.gridColumn4.HeaderText = "code";
            this.gridColumn4.Name = "code";
            // 
            // gridColumn5
            // 
            this.gridColumn5.DataPropertyName = "mainCode";
            this.gridColumn5.HeaderText = "mainCode";
            this.gridColumn5.Name = "mainCode";
            // 
            // gridCell1
            // 
            this.gridCell1.Value = "123";
            // 
            // gridCell2
            // 
            this.gridCell2.Value = "123";
            // 
            // gridCell3
            // 
            this.gridCell3.Value = "123";
            // 
            // gridCell4
            // 
            this.gridCell4.Value = "456";
            // 
            // gridCell5
            // 
            this.gridCell5.Value = "456";
            // 
            // gridCell6
            // 
            this.gridCell6.Value = "456";
            // 
            // gridCell7
            // 
            this.gridCell7.Value = "789";
            // 
            // gridCell8
            // 
            this.gridCell8.Value = "789";
            // 
            // gridCell9
            // 
            this.gridCell9.Value = "789";
            // 
            // TestVoidForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1114, 624);
            this.Controls.Add(this.sgCustomers);
            this.Controls.Add(this.button1);
            this.Name = "TestVoidForm";
            this.Text = "TestVoidForm";
            this.Load += new System.EventHandler(this.TestVoidForm_Load);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button button1;
        private DevComponents.DotNetBar.SuperGrid.SuperGridControl sgCustomers;
        private DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn3;
        private DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn4;
        private DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn5;
        private DevComponents.DotNetBar.SuperGrid.GridCell gridCell7;
        private DevComponents.DotNetBar.SuperGrid.GridCell gridCell8;
        private DevComponents.DotNetBar.SuperGrid.GridCell gridCell9;
        private DevComponents.DotNetBar.SuperGrid.GridCell gridCell4;
        private DevComponents.DotNetBar.SuperGrid.GridCell gridCell5;
        private DevComponents.DotNetBar.SuperGrid.GridCell gridCell6;
        private DevComponents.DotNetBar.SuperGrid.GridCell gridCell1;
        private DevComponents.DotNetBar.SuperGrid.GridCell gridCell2;
        private DevComponents.DotNetBar.SuperGrid.GridCell gridCell3;
    }
}