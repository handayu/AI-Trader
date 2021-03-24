
namespace AITrader
{
    partial class ProxyTestForm
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
            this.button_login = new System.Windows.Forms.Button();
            this.richTextBox_log = new System.Windows.Forms.RichTextBox();
            this.button_dingyue = new System.Windows.Forms.Button();
            this.button_logout = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button_login
            // 
            this.button_login.Location = new System.Drawing.Point(28, 24);
            this.button_login.Name = "button_login";
            this.button_login.Size = new System.Drawing.Size(75, 23);
            this.button_login.TabIndex = 0;
            this.button_login.Text = "登陆";
            this.button_login.UseVisualStyleBackColor = true;
            this.button_login.Click += new System.EventHandler(this.button_login_Click);
            // 
            // richTextBox_log
            // 
            this.richTextBox_log.Location = new System.Drawing.Point(12, 66);
            this.richTextBox_log.Name = "richTextBox_log";
            this.richTextBox_log.Size = new System.Drawing.Size(409, 355);
            this.richTextBox_log.TabIndex = 1;
            this.richTextBox_log.Text = "";
            // 
            // button_dingyue
            // 
            this.button_dingyue.Location = new System.Drawing.Point(248, 24);
            this.button_dingyue.Name = "button_dingyue";
            this.button_dingyue.Size = new System.Drawing.Size(75, 23);
            this.button_dingyue.TabIndex = 2;
            this.button_dingyue.Text = "订阅";
            this.button_dingyue.UseVisualStyleBackColor = true;
            this.button_dingyue.Click += new System.EventHandler(this.button_dingyue_Click);
            // 
            // button_logout
            // 
            this.button_logout.Location = new System.Drawing.Point(134, 24);
            this.button_logout.Name = "button_logout";
            this.button_logout.Size = new System.Drawing.Size(75, 23);
            this.button_logout.TabIndex = 3;
            this.button_logout.Text = "登出";
            this.button_logout.UseVisualStyleBackColor = true;
            this.button_logout.Click += new System.EventHandler(this.button_logout_Click);
            // 
            // ProxyTestForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(431, 423);
            this.Controls.Add(this.button_logout);
            this.Controls.Add(this.button_dingyue);
            this.Controls.Add(this.richTextBox_log);
            this.Controls.Add(this.button_login);
            this.Name = "ProxyTestForm";
            this.Text = "测试数据源登陆";
            this.Load += new System.EventHandler(this.Form_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button_login;
        private System.Windows.Forms.RichTextBox richTextBox_log;
        private System.Windows.Forms.Button button_dingyue;
        private System.Windows.Forms.Button button_logout;
    }
}