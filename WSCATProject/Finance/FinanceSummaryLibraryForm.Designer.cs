namespace WSCATProject.Finance
{
    partial class FinanceSummaryLibraryForm
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
            this.tvSummary = new System.Windows.Forms.TreeView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnCDel = new System.Windows.Forms.Button();
            this.btnCRevise = new System.Windows.Forms.Button();
            this.btnCAdd = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnSAdd = new System.Windows.Forms.Button();
            this.btnSDel = new System.Windows.Forms.Button();
            this.btnSRevise = new System.Windows.Forms.Button();
            this.btnYes = new System.Windows.Forms.Button();
            this.btnNo = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tvSummary
            // 
            this.tvSummary.Location = new System.Drawing.Point(12, 12);
            this.tvSummary.Name = "tvSummary";
            this.tvSummary.Size = new System.Drawing.Size(319, 287);
            this.tvSummary.TabIndex = 0;
            this.tvSummary.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvSummary_AfterSelect);
            this.tvSummary.DoubleClick += new System.EventHandler(this.tvSummary_DoubleClick);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnCDel);
            this.groupBox1.Controls.Add(this.btnCRevise);
            this.groupBox1.Controls.Add(this.btnCAdd);
            this.groupBox1.Location = new System.Drawing.Point(337, 77);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(104, 108);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "类别";
            // 
            // btnCDel
            // 
            this.btnCDel.Location = new System.Drawing.Point(15, 78);
            this.btnCDel.Name = "btnCDel";
            this.btnCDel.Size = new System.Drawing.Size(75, 23);
            this.btnCDel.TabIndex = 7;
            this.btnCDel.Text = "删除";
            this.btnCDel.UseVisualStyleBackColor = true;
            this.btnCDel.Click += new System.EventHandler(this.btnCDel_Click);
            // 
            // btnCRevise
            // 
            this.btnCRevise.Location = new System.Drawing.Point(15, 49);
            this.btnCRevise.Name = "btnCRevise";
            this.btnCRevise.Size = new System.Drawing.Size(75, 23);
            this.btnCRevise.TabIndex = 6;
            this.btnCRevise.Text = "修改...";
            this.btnCRevise.UseVisualStyleBackColor = true;
            this.btnCRevise.Click += new System.EventHandler(this.btnCRevise_Click);
            // 
            // btnCAdd
            // 
            this.btnCAdd.Location = new System.Drawing.Point(15, 20);
            this.btnCAdd.Name = "btnCAdd";
            this.btnCAdd.Size = new System.Drawing.Size(75, 23);
            this.btnCAdd.TabIndex = 5;
            this.btnCAdd.Text = "增加...";
            this.btnCAdd.UseVisualStyleBackColor = true;
            this.btnCAdd.Click += new System.EventHandler(this.btnCAdd_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnSAdd);
            this.groupBox2.Controls.Add(this.btnSDel);
            this.groupBox2.Controls.Add(this.btnSRevise);
            this.groupBox2.Location = new System.Drawing.Point(337, 191);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(104, 108);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "摘要";
            // 
            // btnSAdd
            // 
            this.btnSAdd.Location = new System.Drawing.Point(15, 20);
            this.btnSAdd.Name = "btnSAdd";
            this.btnSAdd.Size = new System.Drawing.Size(75, 23);
            this.btnSAdd.TabIndex = 8;
            this.btnSAdd.Text = "增加...";
            this.btnSAdd.UseVisualStyleBackColor = true;
            this.btnSAdd.Click += new System.EventHandler(this.btnSAdd_Click);
            // 
            // btnSDel
            // 
            this.btnSDel.Location = new System.Drawing.Point(15, 79);
            this.btnSDel.Name = "btnSDel";
            this.btnSDel.Size = new System.Drawing.Size(75, 23);
            this.btnSDel.TabIndex = 7;
            this.btnSDel.Text = "删除";
            this.btnSDel.UseVisualStyleBackColor = true;
            this.btnSDel.Click += new System.EventHandler(this.btnSDel_Click);
            // 
            // btnSRevise
            // 
            this.btnSRevise.Location = new System.Drawing.Point(15, 50);
            this.btnSRevise.Name = "btnSRevise";
            this.btnSRevise.Size = new System.Drawing.Size(75, 23);
            this.btnSRevise.TabIndex = 6;
            this.btnSRevise.Text = "修改...";
            this.btnSRevise.UseVisualStyleBackColor = true;
            this.btnSRevise.Click += new System.EventHandler(this.btnSRevise_Click);
            // 
            // btnYes
            // 
            this.btnYes.Location = new System.Drawing.Point(352, 19);
            this.btnYes.Name = "btnYes";
            this.btnYes.Size = new System.Drawing.Size(75, 23);
            this.btnYes.TabIndex = 3;
            this.btnYes.Text = "确定";
            this.btnYes.UseVisualStyleBackColor = true;
            this.btnYes.Click += new System.EventHandler(this.btnYes_Click);
            // 
            // btnNo
            // 
            this.btnNo.Location = new System.Drawing.Point(352, 48);
            this.btnNo.Name = "btnNo";
            this.btnNo.Size = new System.Drawing.Size(75, 23);
            this.btnNo.TabIndex = 4;
            this.btnNo.Text = "取消";
            this.btnNo.UseVisualStyleBackColor = true;
            this.btnNo.Click += new System.EventHandler(this.btnNo_Click);
            // 
            // FinanceSummaryLibraryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(445, 311);
            this.Controls.Add(this.btnNo);
            this.Controls.Add(this.btnYes);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.tvSummary);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FinanceSummaryLibraryForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "摘要库";
            this.Load += new System.EventHandler(this.FinanceSummaryLibraryForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView tvSummary;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnCDel;
        private System.Windows.Forms.Button btnCRevise;
        private System.Windows.Forms.Button btnCAdd;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnSAdd;
        private System.Windows.Forms.Button btnSDel;
        private System.Windows.Forms.Button btnSRevise;
        private System.Windows.Forms.Button btnYes;
        private System.Windows.Forms.Button btnNo;
    }
}