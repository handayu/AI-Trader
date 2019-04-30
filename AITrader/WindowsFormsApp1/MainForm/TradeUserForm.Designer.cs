namespace WindowsFormsApp1
{
    partial class TradeUserForm
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
            this.tradeUserControl1 = new WindowsFormsApp1.TradeUserControl();
            this.SuspendLayout();
            // 
            // tradeUserControl1
            // 
            this.tradeUserControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tradeUserControl1.Location = new System.Drawing.Point(0, 0);
            this.tradeUserControl1.Name = "tradeUserControl1";
            this.tradeUserControl1.Size = new System.Drawing.Size(1099, 389);
            this.tradeUserControl1.TabIndex = 0;
            // 
            // TradeUserForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1099, 389);
            this.Controls.Add(this.tradeUserControl1);
            this.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Name = "TradeUserForm";
            this.Text = "交易";
            this.ResumeLayout(false);

        }

        #endregion

        private TradeUserControl tradeUserControl1;
    }
}