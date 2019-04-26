namespace WindowsFormsApp1
{
    partial class MarketDataUserForm
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
            this.marketDataUserControl1 = new WindowsFormsApp1.MarketDataUserControl();
            this.SuspendLayout();
            // 
            // marketDataUserControl1
            // 
            this.marketDataUserControl1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.marketDataUserControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.marketDataUserControl1.Location = new System.Drawing.Point(0, 0);
            this.marketDataUserControl1.Name = "marketDataUserControl1";
            this.marketDataUserControl1.Size = new System.Drawing.Size(258, 295);
            this.marketDataUserControl1.TabIndex = 0;
            // 
            // MarketDataUserForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(258, 295);
            this.Controls.Add(this.marketDataUserControl1);
            this.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "MarketDataUserForm";
            this.Text = "报价";
            this.Load += new System.EventHandler(this.Form_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private MarketDataUserControl marketDataUserControl1;
    }
}