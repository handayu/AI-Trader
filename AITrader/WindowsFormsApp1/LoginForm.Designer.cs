namespace WindowsFormsApp1
{
    partial class LoginForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox_apikey = new System.Windows.Forms.TextBox();
            this.textBox_serkets = new System.Windows.Forms.TextBox();
            this.textBox_passphear = new System.Windows.Forms.TextBox();
            this.button_Login = new System.Windows.Forms.Button();
            this.button_Cancel = new System.Windows.Forms.Button();
            this.button_ansyTime = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "API-KEY:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "Sercrets:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 85);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "PassPhera:";
            // 
            // textBox_apikey
            // 
            this.textBox_apikey.Location = new System.Drawing.Point(84, 13);
            this.textBox_apikey.Name = "textBox_apikey";
            this.textBox_apikey.Size = new System.Drawing.Size(276, 21);
            this.textBox_apikey.TabIndex = 3;
            // 
            // textBox_serkets
            // 
            this.textBox_serkets.Location = new System.Drawing.Point(84, 46);
            this.textBox_serkets.Name = "textBox_serkets";
            this.textBox_serkets.Size = new System.Drawing.Size(276, 21);
            this.textBox_serkets.TabIndex = 4;
            // 
            // textBox_passphear
            // 
            this.textBox_passphear.Location = new System.Drawing.Point(84, 82);
            this.textBox_passphear.Name = "textBox_passphear";
            this.textBox_passphear.Size = new System.Drawing.Size(276, 21);
            this.textBox_passphear.TabIndex = 5;
            // 
            // button_Login
            // 
            this.button_Login.Location = new System.Drawing.Point(130, 133);
            this.button_Login.Name = "button_Login";
            this.button_Login.Size = new System.Drawing.Size(112, 27);
            this.button_Login.TabIndex = 6;
            this.button_Login.Text = "登陆";
            this.button_Login.UseVisualStyleBackColor = true;
            this.button_Login.Click += new System.EventHandler(this.button_Login_Click);
            // 
            // button_Cancel
            // 
            this.button_Cancel.Location = new System.Drawing.Point(248, 133);
            this.button_Cancel.Name = "button_Cancel";
            this.button_Cancel.Size = new System.Drawing.Size(112, 27);
            this.button_Cancel.TabIndex = 7;
            this.button_Cancel.Text = "取消";
            this.button_Cancel.UseVisualStyleBackColor = true;
            this.button_Cancel.Click += new System.EventHandler(this.button_Cancel_Click);
            // 
            // button_ansyTime
            // 
            this.button_ansyTime.Location = new System.Drawing.Point(15, 133);
            this.button_ansyTime.Name = "button_ansyTime";
            this.button_ansyTime.Size = new System.Drawing.Size(109, 27);
            this.button_ansyTime.TabIndex = 8;
            this.button_ansyTime.Text = "同步服务器时间";
            this.button_ansyTime.UseVisualStyleBackColor = true;
            this.button_ansyTime.Click += new System.EventHandler(this.button_ansyTime_ClickAsync);
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(379, 176);
            this.Controls.Add(this.button_ansyTime);
            this.Controls.Add(this.button_Cancel);
            this.Controls.Add(this.button_Login);
            this.Controls.Add(this.textBox_passphear);
            this.Controls.Add(this.textBox_serkets);
            this.Controls.Add(this.textBox_apikey);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "LoginForm";
            this.Text = "Okex登陆";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox_apikey;
        private System.Windows.Forms.TextBox textBox_serkets;
        private System.Windows.Forms.TextBox textBox_passphear;
        private System.Windows.Forms.Button button_Login;
        private System.Windows.Forms.Button button_Cancel;
        private System.Windows.Forms.Button button_ansyTime;
    }
}