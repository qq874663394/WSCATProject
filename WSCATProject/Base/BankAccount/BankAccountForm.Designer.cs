namespace WSCATProject.Base
{
    partial class BankAccountForm
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
            this.superGridControl1.PrimaryGrid.FocusCuesEnabled = false;
            this.superGridControl1.PrimaryGrid.InitialSelection = DevComponents.DotNetBar.SuperGrid.RelativeSelection.None;
            this.superGridControl1.PrimaryGrid.SelectionGranularity = DevComponents.DotNetBar.SuperGrid.SelectionGranularity.Row;
            // 
            // BankAccountForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(938, 398);
            this.Name = "BankAccountForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "资金账户";
            this.Load += new System.EventHandler(this.BankAccountMaterial_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
    }
}