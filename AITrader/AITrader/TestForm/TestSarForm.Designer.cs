namespace WindowsFormsApp1
{
    partial class TestSarForm
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
            this.richTextBox_nowTick = new System.Windows.Forms.RichTextBox();
            this.richTextBox_renko = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // richTextBox_nowTick
            // 
            this.richTextBox_nowTick.Location = new System.Drawing.Point(28, 12);
            this.richTextBox_nowTick.Name = "richTextBox_nowTick";
            this.richTextBox_nowTick.Size = new System.Drawing.Size(309, 405);
            this.richTextBox_nowTick.TabIndex = 0;
            this.richTextBox_nowTick.Text = "";
            // 
            // richTextBox_renko
            // 
            this.richTextBox_renko.Location = new System.Drawing.Point(353, 12);
            this.richTextBox_renko.Name = "richTextBox_renko";
            this.richTextBox_renko.Size = new System.Drawing.Size(312, 405);
            this.richTextBox_renko.TabIndex = 1;
            this.richTextBox_renko.Text = "";
            // 
            // TestSarForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.richTextBox_renko);
            this.Controls.Add(this.richTextBox_nowTick);
            this.Name = "TestSarForm";
            this.Text = "TestSarForm";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form_Closed);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox richTextBox_nowTick;
        private System.Windows.Forms.RichTextBox richTextBox_renko;
    }
}