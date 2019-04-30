namespace WindowsFormsApp1
{
    partial class QuickOrderForm
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
            this.quickOrderUserControl1 = new WindowsFormsApp1.QuickOrderUserControl();
            this.SuspendLayout();
            // 
            // quickOrderUserControl1
            // 
            this.quickOrderUserControl1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.quickOrderUserControl1.Location = new System.Drawing.Point(0, 0);
            this.quickOrderUserControl1.Margin = new System.Windows.Forms.Padding(6);
            this.quickOrderUserControl1.MinimumSize = new System.Drawing.Size(1773, 543);
            this.quickOrderUserControl1.Name = "quickOrderUserControl1";
            this.quickOrderUserControl1.Size = new System.Drawing.Size(1773, 543);
            this.quickOrderUserControl1.TabIndex = 0;
            // 
            // QuickOrderForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1190, 411);
            this.Controls.Add(this.quickOrderUserControl1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(1202, 440);
            this.Name = "QuickOrderForm";
            this.Text = "快捷下单面板";
            this.Load += new System.EventHandler(this.Form_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private QuickOrderUserControl quickOrderUserControl1;
    }
}