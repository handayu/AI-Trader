namespace WindowsFormsApp1
{
    partial class RenkoCreateTestForm
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
            this.button_MarketMarket = new System.Windows.Forms.Button();
            this.textBox_AddPrice = new System.Windows.Forms.TextBox();
            this.richTextBox_RenkoBar = new System.Windows.Forms.RichTextBox();
            this.textBox_RenkoBoxSize = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox_StartPrice = new System.Windows.Forms.TextBox();
            this.richTextBox_RealBar = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // button_MarketMarket
            // 
            this.button_MarketMarket.Location = new System.Drawing.Point(187, 56);
            this.button_MarketMarket.Name = "button_MarketMarket";
            this.button_MarketMarket.Size = new System.Drawing.Size(100, 25);
            this.button_MarketMarket.TabIndex = 0;
            this.button_MarketMarket.Text = "加入行情";
            this.button_MarketMarket.UseVisualStyleBackColor = true;
            // 
            // textBox_AddPrice
            // 
            this.textBox_AddPrice.Location = new System.Drawing.Point(146, 60);
            this.textBox_AddPrice.Name = "textBox_AddPrice";
            this.textBox_AddPrice.Size = new System.Drawing.Size(35, 21);
            this.textBox_AddPrice.TabIndex = 1;
            this.textBox_AddPrice.Text = "-1";
            // 
            // richTextBox_RenkoBar
            // 
            this.richTextBox_RenkoBar.Location = new System.Drawing.Point(25, 122);
            this.richTextBox_RenkoBar.Name = "richTextBox_RenkoBar";
            this.richTextBox_RenkoBar.Size = new System.Drawing.Size(140, 316);
            this.richTextBox_RenkoBar.TabIndex = 2;
            this.richTextBox_RenkoBar.Text = "";
            // 
            // textBox_RenkoBoxSize
            // 
            this.textBox_RenkoBoxSize.Location = new System.Drawing.Point(81, 16);
            this.textBox_RenkoBoxSize.Name = "textBox_RenkoBoxSize";
            this.textBox_RenkoBoxSize.Size = new System.Drawing.Size(100, 21);
            this.textBox_RenkoBoxSize.TabIndex = 3;
            this.textBox_RenkoBoxSize.Text = "5";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 4;
            this.label1.Text = "BOXSIZE:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 6;
            this.label2.Text = "起始价格";
            // 
            // textBox_StartPrice
            // 
            this.textBox_StartPrice.Location = new System.Drawing.Point(71, 60);
            this.textBox_StartPrice.Name = "textBox_StartPrice";
            this.textBox_StartPrice.Size = new System.Drawing.Size(49, 21);
            this.textBox_StartPrice.TabIndex = 5;
            this.textBox_StartPrice.Text = "5000";
            // 
            // richTextBox_RealBar
            // 
            this.richTextBox_RealBar.Location = new System.Drawing.Point(187, 122);
            this.richTextBox_RealBar.Name = "richTextBox_RealBar";
            this.richTextBox_RealBar.Size = new System.Drawing.Size(140, 316);
            this.richTextBox_RealBar.TabIndex = 7;
            this.richTextBox_RealBar.Text = "";
            // 
            // RenkoCreateTestForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(379, 455);
            this.Controls.Add(this.richTextBox_RealBar);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox_StartPrice);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox_RenkoBoxSize);
            this.Controls.Add(this.richTextBox_RenkoBar);
            this.Controls.Add(this.textBox_AddPrice);
            this.Controls.Add(this.button_MarketMarket);
            this.Name = "RenkoCreateTestForm";
            this.Text = "砖型图生成器";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_MarketMarket;
        private System.Windows.Forms.TextBox textBox_AddPrice;
        private System.Windows.Forms.RichTextBox richTextBox_RenkoBar;
        private System.Windows.Forms.TextBox textBox_RenkoBoxSize;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox_StartPrice;
        private System.Windows.Forms.RichTextBox richTextBox_RealBar;
    }
}