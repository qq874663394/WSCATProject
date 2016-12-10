namespace WSCATProject.Finance
{
    partial class FinanceSubjectAddDialogForm
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
            this.label2 = new System.Windows.Forms.Label();
            this.txtCode = new System.Windows.Forms.TextBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.btnYes = new System.Windows.Forms.Button();
            this.btnNo = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.rdbSubject = new System.Windows.Forms.RadioButton();
            this.rdbClass = new System.Windows.Forms.RadioButton();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(34, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "代码：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(34, 86);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "名称：";
            // 
            // txtCode
            // 
            this.txtCode.Location = new System.Drawing.Point(81, 44);
            this.txtCode.Name = "txtCode";
            this.txtCode.Size = new System.Drawing.Size(162, 21);
            this.txtCode.TabIndex = 2;
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(81, 83);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(162, 21);
            this.txtName.TabIndex = 3;
            // 
            // btnYes
            // 
            this.btnYes.Location = new System.Drawing.Point(81, 129);
            this.btnYes.Name = "btnYes";
            this.btnYes.Size = new System.Drawing.Size(75, 23);
            this.btnYes.TabIndex = 4;
            this.btnYes.Text = "确认";
            this.btnYes.UseVisualStyleBackColor = true;
            this.btnYes.Click += new System.EventHandler(this.btnYes_Click);
            // 
            // btnNo
            // 
            this.btnNo.Location = new System.Drawing.Point(168, 129);
            this.btnNo.Name = "btnNo";
            this.btnNo.Size = new System.Drawing.Size(75, 23);
            this.btnNo.TabIndex = 5;
            this.btnNo.Text = "取消";
            this.btnNo.UseVisualStyleBackColor = true;
            this.btnNo.Click += new System.EventHandler(this.btnNo_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.rdbSubject);
            this.panel1.Controls.Add(this.rdbClass);
            this.panel1.Location = new System.Drawing.Point(81, 5);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(120, 33);
            this.panel1.TabIndex = 7;
            // 
            // rdbSubject
            // 
            this.rdbSubject.AutoSize = true;
            this.rdbSubject.Location = new System.Drawing.Point(56, 7);
            this.rdbSubject.Name = "rdbSubject";
            this.rdbSubject.Size = new System.Drawing.Size(47, 16);
            this.rdbSubject.TabIndex = 1;
            this.rdbSubject.TabStop = true;
            this.rdbSubject.Text = "科目";
            this.rdbSubject.UseVisualStyleBackColor = true;
            this.rdbSubject.CheckedChanged += new System.EventHandler(this.rdbSubject_CheckedChanged);
            // 
            // rdbClass
            // 
            this.rdbClass.AutoSize = true;
            this.rdbClass.Location = new System.Drawing.Point(3, 7);
            this.rdbClass.Name = "rdbClass";
            this.rdbClass.Size = new System.Drawing.Size(47, 16);
            this.rdbClass.TabIndex = 0;
            this.rdbClass.TabStop = true;
            this.rdbClass.Text = "类别";
            this.rdbClass.UseVisualStyleBackColor = true;
            this.rdbClass.CheckedChanged += new System.EventHandler(this.rdbClass_CheckedChanged);
            // 
            // FinanceSubjectAddDialogForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 174);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnNo);
            this.Controls.Add(this.btnYes);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.txtCode);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FinanceSubjectAddDialogForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "科目-添加";
            this.Load += new System.EventHandler(this.FinanceSubjectAddDialog_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtCode;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Button btnYes;
        private System.Windows.Forms.Button btnNo;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton rdbSubject;
        private System.Windows.Forms.RadioButton rdbClass;
    }
}