namespace WSCATProject.Base
{
    partial class InShelvesForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxX1 = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.buttonsave = new System.Windows.Forms.Button();
            this.buttonquxiao = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "请输入下级名称：";
            // 
            // textBoxX1
            // 
            // 
            // 
            // 
            this.textBoxX1.Border.Class = "TextBoxBorder";
            this.textBoxX1.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.textBoxX1.Location = new System.Drawing.Point(25, 47);
            this.textBoxX1.Name = "textBoxX1";
            this.textBoxX1.PreventEnterBeep = true;
            this.textBoxX1.Size = new System.Drawing.Size(202, 21);
            this.textBoxX1.TabIndex = 1;
            // 
            // buttonsave
            // 
            this.buttonsave.Location = new System.Drawing.Point(26, 84);
            this.buttonsave.Name = "buttonsave";
            this.buttonsave.Size = new System.Drawing.Size(75, 23);
            this.buttonsave.TabIndex = 2;
            this.buttonsave.Text = "保存";
            this.buttonsave.UseVisualStyleBackColor = true;
            // 
            // buttonquxiao
            // 
            this.buttonquxiao.Location = new System.Drawing.Point(153, 84);
            this.buttonquxiao.Name = "buttonquxiao";
            this.buttonquxiao.Size = new System.Drawing.Size(75, 23);
            this.buttonquxiao.TabIndex = 3;
            this.buttonquxiao.Text = "取消";
            this.buttonquxiao.UseVisualStyleBackColor = true;
            // 
            // InShelvesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(259, 125);
            this.Controls.Add(this.buttonquxiao);
            this.Controls.Add(this.buttonsave);
            this.Controls.Add(this.textBoxX1);
            this.Controls.Add(this.label1);
            this.Name = "InShelvesForm";
            this.Text = "添加货架";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private DevComponents.DotNetBar.Controls.TextBoxX textBoxX1;
        private System.Windows.Forms.Button buttonsave;
        private System.Windows.Forms.Button buttonquxiao;
    }
}