namespace WSCATProject.Base
{
    partial class CityNode
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
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(18, 38);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(18, 21);
            this.label1.TabIndex = 3;
            // 
            // form_save
            // 
            this.form_save.Location = new System.Drawing.Point(80, 68);
            this.form_save.TabIndex = 1;
            this.form_save.Click += new System.EventHandler(this.form_save_Click_1);
            // 
            // form_exit
            // 
            this.form_exit.Location = new System.Drawing.Point(161, 68);
            // 
            // CityNode
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(254, 112);
            this.Name = "CityNode";
            this.Text = "CityNode";
            this.Load += new System.EventHandler(this.CityNode_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
    }
}