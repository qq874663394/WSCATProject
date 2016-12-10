namespace WSCATProject.Base
{
    partial class MateCreateTypeForm
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
            this.form_exit = new System.Windows.Forms.Button();
            this.form_save = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // form_exit
            // 
            this.form_exit.Location = new System.Drawing.Point(161, 64);
            this.form_exit.Name = "form_exit";
            this.form_exit.Size = new System.Drawing.Size(75, 25);
            this.form_exit.TabIndex = 5;
            this.form_exit.Text = "取消(&Q)";
            this.form_exit.UseVisualStyleBackColor = true;
            this.form_exit.Click += new System.EventHandler(this.form_exit_Click);
            // 
            // form_save
            // 
            this.form_save.Location = new System.Drawing.Point(80, 64);
            this.form_save.Name = "form_save";
            this.form_save.Size = new System.Drawing.Size(75, 25);
            this.form_save.TabIndex = 6;
            this.form_save.Text = "保存(&A)";
            this.form_save.UseVisualStyleBackColor = true;
            this.form_save.Click += new System.EventHandler(this.form_save_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 12);
            this.label1.TabIndex = 4;
            this.label1.Text = "请输入下级名称：";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(18, 32);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(218, 21);
            this.textBox1.TabIndex = 3;
            // 
            // MateCreateTypeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(255, 107);
            this.ControlBox = false;
            this.Controls.Add(this.form_exit);
            this.Controls.Add(this.form_save);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox1);
            this.Name = "MateCreateTypeForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "新增产品类别";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button form_exit;
        private System.Windows.Forms.Button form_save;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
    }
}