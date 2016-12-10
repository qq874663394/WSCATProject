namespace WSCATProject.Base
{
    partial class BorrowType
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
            this.gridColumn1 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            this.gridColumn2 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.SuspendLayout();
            // 
            // superGridControl1
            // 
            this.superGridControl1.FilterExprColors.SysFunction = System.Drawing.Color.DarkRed;
            // 
            // 
            // 
            this.superGridControl1.PrimaryGrid.ActiveRowIndicatorStyle = DevComponents.DotNetBar.SuperGrid.ActiveRowIndicatorStyle.None;
            this.superGridControl1.PrimaryGrid.AutoGenerateColumns = false;
            this.superGridControl1.PrimaryGrid.Columns.Add(this.gridColumn1);
            this.superGridControl1.PrimaryGrid.Columns.Add(this.gridColumn2);
            this.superGridControl1.PrimaryGrid.FocusCuesEnabled = false;
            this.superGridControl1.PrimaryGrid.InitialSelection = DevComponents.DotNetBar.SuperGrid.RelativeSelection.None;
            this.superGridControl1.PrimaryGrid.SelectionGranularity = DevComponents.DotNetBar.SuperGrid.SelectionGranularity.Row;
            this.superGridControl1.Size = new System.Drawing.Size(338, 388);
            // 
            // gridColumn1
            // 
            this.gridColumn1.DataPropertyName = "Bo_TypeID";
            this.gridColumn1.HeaderText = "ID";
            this.gridColumn1.Name = "gridColumn1";
            // 
            // gridColumn2
            // 
            this.gridColumn2.DataPropertyName = "Bo_TypeName";
            this.gridColumn2.HeaderText = "类型名称";
            this.gridColumn2.Name = "gridColumn2";
            // 
            // BorrowType
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(338, 423);
            this.Name = "BorrowType";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "BorrowType";
            this.Load += new System.EventHandler(this.BorrowType_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn1;
        private DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn2;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
    }
}