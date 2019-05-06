namespace WindowsFormsApp1
{
    partial class AccountStrategyUserForm
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
            this.accountStrategyUserControl1 = new WindowsFormsApp1.AccountStrategyUserControl();
            this.SuspendLayout();
            // 
            // accountStrategyUserControl1
            // 
            this.accountStrategyUserControl1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.accountStrategyUserControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.accountStrategyUserControl1.Location = new System.Drawing.Point(0, 0);
            this.accountStrategyUserControl1.Name = "accountStrategyUserControl1";
            this.accountStrategyUserControl1.Size = new System.Drawing.Size(800, 450);
            this.accountStrategyUserControl1.TabIndex = 0;
            this.accountStrategyUserControl1.Load += new System.EventHandler(this.Form_Load);
            // 
            // AccountStrategyUserForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.accountStrategyUserControl1);
            this.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Name = "AccountStrategyUserForm";
            this.Text = "指标策略管理";
            this.ResumeLayout(false);

        }

        #endregion

        private AccountStrategyUserControl accountStrategyUserControl1;
    }
}