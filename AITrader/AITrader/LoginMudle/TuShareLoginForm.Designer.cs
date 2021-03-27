
namespace WindowsFormsApp1
{
    partial class TuShareLoginForm
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
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox_socketUrl = new System.Windows.Forms.TextBox();
            this.textBox_apiName = new System.Windows.Forms.TextBox();
            this.textBox_tocken = new System.Windows.Forms.TextBox();
            this.textBox_testStockCode = new System.Windows.Forms.TextBox();
            this.dateTimePicker_start = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.dateTimePicker_end = new System.Windows.Forms.DateTimePicker();
            this.richTextBox_Log = new System.Windows.Forms.RichTextBox();
            this.button_Test = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "api_name：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 77);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "tocken：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 107);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(107, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "test_stock_code：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 137);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 12);
            this.label4.TabIndex = 3;
            this.label4.Text = "date_start：";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(16, 18);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(101, 12);
            this.label5.TabIndex = 4;
            this.label5.Text = "web_socket_url：";
            // 
            // textBox_socketUrl
            // 
            this.textBox_socketUrl.Location = new System.Drawing.Point(127, 12);
            this.textBox_socketUrl.Name = "textBox_socketUrl";
            this.textBox_socketUrl.ReadOnly = true;
            this.textBox_socketUrl.Size = new System.Drawing.Size(172, 21);
            this.textBox_socketUrl.TabIndex = 5;
            this.textBox_socketUrl.Text = "http://api.waditu.com";
            // 
            // textBox_apiName
            // 
            this.textBox_apiName.Location = new System.Drawing.Point(127, 42);
            this.textBox_apiName.Name = "textBox_apiName";
            this.textBox_apiName.Size = new System.Drawing.Size(172, 21);
            this.textBox_apiName.TabIndex = 6;
            this.textBox_apiName.Text = "daily";
            // 
            // textBox_tocken
            // 
            this.textBox_tocken.Location = new System.Drawing.Point(127, 69);
            this.textBox_tocken.Name = "textBox_tocken";
            this.textBox_tocken.PasswordChar = '*';
            this.textBox_tocken.Size = new System.Drawing.Size(172, 21);
            this.textBox_tocken.TabIndex = 7;
            this.textBox_tocken.Text = "eea049d7d60973c01823ea6593ced55386e676abcda5b7b44bb19995";
            // 
            // textBox_testStockCode
            // 
            this.textBox_testStockCode.Location = new System.Drawing.Point(127, 102);
            this.textBox_testStockCode.Name = "textBox_testStockCode";
            this.textBox_testStockCode.Size = new System.Drawing.Size(172, 21);
            this.textBox_testStockCode.TabIndex = 8;
            this.textBox_testStockCode.Text = "600000.SH";
            // 
            // dateTimePicker_start
            // 
            this.dateTimePicker_start.Location = new System.Drawing.Point(127, 132);
            this.dateTimePicker_start.Name = "dateTimePicker_start";
            this.dateTimePicker_start.Size = new System.Drawing.Size(172, 21);
            this.dateTimePicker_start.TabIndex = 9;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(16, 164);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 12);
            this.label6.TabIndex = 10;
            this.label6.Text = "date_end：";
            // 
            // dateTimePicker_end
            // 
            this.dateTimePicker_end.Location = new System.Drawing.Point(127, 160);
            this.dateTimePicker_end.Name = "dateTimePicker_end";
            this.dateTimePicker_end.Size = new System.Drawing.Size(172, 21);
            this.dateTimePicker_end.TabIndex = 11;
            // 
            // richTextBox_Log
            // 
            this.richTextBox_Log.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.richTextBox_Log.Location = new System.Drawing.Point(18, 218);
            this.richTextBox_Log.Name = "richTextBox_Log";
            this.richTextBox_Log.Size = new System.Drawing.Size(516, 78);
            this.richTextBox_Log.TabIndex = 12;
            this.richTextBox_Log.Text = "";
            // 
            // button_Test
            // 
            this.button_Test.Location = new System.Drawing.Point(18, 189);
            this.button_Test.Name = "button_Test";
            this.button_Test.Size = new System.Drawing.Size(75, 23);
            this.button_Test.TabIndex = 13;
            this.button_Test.Text = "Test";
            this.button_Test.UseVisualStyleBackColor = true;
            this.button_Test.Click += new System.EventHandler(this.button_Test_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.Color.Red;
            this.label7.Location = new System.Drawing.Point(305, 15);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(197, 12);
            this.label7.TabIndex = 14;
            this.label7.Text = "PS:此链接固定为tushare数据源地址";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.ForeColor = System.Drawing.Color.Red;
            this.label8.Location = new System.Drawing.Point(305, 47);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(113, 12);
            this.label8.TabIndex = 15;
            this.label8.Text = "PS:别名,可自由设置";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.ForeColor = System.Drawing.Color.Red;
            this.label9.Location = new System.Drawing.Point(305, 75);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(173, 12);
            this.label9.TabIndex = 16;
            this.label9.Text = "PS:此tocken为tusahre官网申请";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.ForeColor = System.Drawing.Color.Red;
            this.label10.Location = new System.Drawing.Point(305, 107);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(233, 12);
            this.label10.TabIndex = 17;
            this.label10.Text = "PS:测试下载股票代码,注意带.SZ和.SH后缀";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.ForeColor = System.Drawing.Color.Red;
            this.label11.Location = new System.Drawing.Point(305, 135);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(71, 12);
            this.label11.TabIndex = 18;
            this.label11.Text = "PS:开始日期";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.ForeColor = System.Drawing.Color.Red;
            this.label12.Location = new System.Drawing.Point(306, 164);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(71, 12);
            this.label12.TabIndex = 19;
            this.label12.Text = "PS:截至日期";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.ForeColor = System.Drawing.Color.Red;
            this.label13.Location = new System.Drawing.Point(106, 194);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(287, 12);
            this.label13.TabIndex = 20;
            this.label13.Text = "PS:由于是Http无状态获取数据，非长连接，状态即时";
            // 
            // TuShareLoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(547, 306);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.button_Test);
            this.Controls.Add(this.richTextBox_Log);
            this.Controls.Add(this.dateTimePicker_end);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.dateTimePicker_start);
            this.Controls.Add(this.textBox_testStockCode);
            this.Controls.Add(this.textBox_tocken);
            this.Controls.Add(this.textBox_apiName);
            this.Controls.Add(this.textBox_socketUrl);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "TuShareLoginForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TuShare数据源登陆";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form_Closing);
            this.Load += new System.EventHandler(this.Form_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBox_socketUrl;
        private System.Windows.Forms.TextBox textBox_apiName;
        private System.Windows.Forms.TextBox textBox_tocken;
        private System.Windows.Forms.TextBox textBox_testStockCode;
        private System.Windows.Forms.DateTimePicker dateTimePicker_start;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker dateTimePicker_end;
        private System.Windows.Forms.RichTextBox richTextBox_Log;
        private System.Windows.Forms.Button button_Test;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
    }
}