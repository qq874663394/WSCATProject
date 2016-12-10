namespace WSCATProject.Base
{
    partial class CreateClientTypeForm
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
            this.buttonXOK = new DevComponents.DotNetBar.ButtonX();
            this.textBoxXName = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelXName = new DevComponents.DotNetBar.LabelX();
            this.richTextBoxExRe = new DevComponents.DotNetBar.Controls.RichTextBoxEx();
            this.labelXRemark = new DevComponents.DotNetBar.LabelX();
            this.buttonXCancel = new DevComponents.DotNetBar.ButtonX();
            this.SuspendLayout();
            // 
            // buttonXOK
            // 
            this.buttonXOK.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonXOK.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonXOK.Location = new System.Drawing.Point(206, 90);
            this.buttonXOK.Name = "buttonXOK";
            this.buttonXOK.Size = new System.Drawing.Size(58, 23);
            this.buttonXOK.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonXOK.TabIndex = 3;
            this.buttonXOK.Text = "确定";
            this.buttonXOK.Click += new System.EventHandler(this.buttonXOK_Click);
            // 
            // textBoxXName
            // 
            // 
            // 
            // 
            this.textBoxXName.Border.Class = "TextBoxBorder";
            this.textBoxXName.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.textBoxXName.Location = new System.Drawing.Point(83, 11);
            this.textBoxXName.MaxLength = 10;
            this.textBoxXName.Name = "textBoxXName";
            this.textBoxXName.PreventEnterBeep = true;
            this.textBoxXName.Size = new System.Drawing.Size(181, 21);
            this.textBoxXName.TabIndex = 1;
            // 
            // labelXName
            // 
            // 
            // 
            // 
            this.labelXName.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelXName.Location = new System.Drawing.Point(15, 12);
            this.labelXName.Name = "labelXName";
            this.labelXName.Size = new System.Drawing.Size(75, 23);
            this.labelXName.TabIndex = 2;
            this.labelXName.Text = "类别名称：";
            // 
            // richTextBoxExRe
            // 
            // 
            // 
            // 
            this.richTextBoxExRe.BackgroundStyle.Class = "RichTextBoxBorder";
            this.richTextBoxExRe.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.richTextBoxExRe.Location = new System.Drawing.Point(83, 41);
            this.richTextBoxExRe.MaxLength = 200;
            this.richTextBoxExRe.Name = "richTextBoxExRe";
            this.richTextBoxExRe.Rtf = "{\\rtf1\\ansi\\ansicpg936\\deff0\\deflang1033\\deflangfe2052{\\fonttbl{\\f0\\fnil\\fcharset" +
    "134 \\\'cb\\\'ce\\\'cc\\\'e5;}}\r\n\\viewkind4\\uc1\\pard\\lang2052\\f0\\fs18\\par\r\n}\r\n";
            this.richTextBoxExRe.Size = new System.Drawing.Size(181, 39);
            this.richTextBoxExRe.TabIndex = 2;
            // 
            // labelXRemark
            // 
            // 
            // 
            // 
            this.labelXRemark.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelXRemark.Location = new System.Drawing.Point(39, 41);
            this.labelXRemark.Name = "labelXRemark";
            this.labelXRemark.Size = new System.Drawing.Size(75, 23);
            this.labelXRemark.TabIndex = 4;
            this.labelXRemark.Text = "备注：";
            // 
            // buttonXCancel
            // 
            this.buttonXCancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonXCancel.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonXCancel.Location = new System.Drawing.Point(138, 90);
            this.buttonXCancel.Name = "buttonXCancel";
            this.buttonXCancel.Size = new System.Drawing.Size(58, 23);
            this.buttonXCancel.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonXCancel.TabIndex = 4;
            this.buttonXCancel.Text = "关闭";
            this.buttonXCancel.Click += new System.EventHandler(this.buttonXCancel_Click);
            // 
            // CreateClientTypeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(281, 121);
            this.Controls.Add(this.buttonXCancel);
            this.Controls.Add(this.richTextBoxExRe);
            this.Controls.Add(this.labelXRemark);
            this.Controls.Add(this.textBoxXName);
            this.Controls.Add(this.labelXName);
            this.Controls.Add(this.buttonXOK);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CreateClientTypeForm";
            this.Text = "新增客户";
            this.Load += new System.EventHandler(this.CreateClientTypeForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.ButtonX buttonXOK;
        private DevComponents.DotNetBar.Controls.TextBoxX textBoxXName;
        private DevComponents.DotNetBar.LabelX labelXName;
        private DevComponents.DotNetBar.Controls.RichTextBoxEx richTextBoxExRe;
        private DevComponents.DotNetBar.LabelX labelXRemark;
        private DevComponents.DotNetBar.ButtonX buttonXCancel;
    }
}