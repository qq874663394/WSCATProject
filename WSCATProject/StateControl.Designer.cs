namespace DataGridViewProcessEditTest
{
    partial class StateControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StateControl));
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.SuspendLayout();
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "Gray");
            this.imageList1.Images.SetKeyName(1, "Blue");
            this.imageList1.Images.SetKeyName(2, "Green");
            this.imageList1.Images.SetKeyName(3, "Yellow");
            this.imageList1.Images.SetKeyName(4, "Red");
            this.imageList1.Images.SetKeyName(5, "red.PNG");
            this.imageList1.Images.SetKeyName(6, "green.PNG");
            this.imageList1.Images.SetKeyName(7, "yellow.PNG");
            // 
            // StateControl
            // 
            this.Size = new System.Drawing.Size(90, 20);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ImageList imageList1;
    }
}
