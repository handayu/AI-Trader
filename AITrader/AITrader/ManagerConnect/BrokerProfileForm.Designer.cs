
namespace WindowsFormsApp1
{
    partial class BrokerProfileForm
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
            this.brokerProfileItems1 = new WindowsFormsApp1.BrokerProfileItems();
            this.SuspendLayout();
            // 
            // brokerProfileItems1
            // 
            this.brokerProfileItems1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.brokerProfileItems1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.brokerProfileItems1.Location = new System.Drawing.Point(0, 0);
            this.brokerProfileItems1.Name = "brokerProfileItems1";
            this.brokerProfileItems1.Size = new System.Drawing.Size(851, 27);
            this.brokerProfileItems1.TabIndex = 0;
            // 
            // BrokerProfileForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(851, 27);
            this.Controls.Add(this.brokerProfileItems1);
            this.Font = new System.Drawing.Font("SimSun", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "BrokerProfileForm";
            this.Text = "通道管理";
            this.ResumeLayout(false);

        }

        #endregion

        private WindowsFormsApp1.BrokerProfileItems brokerProfileItems1;
    }
}