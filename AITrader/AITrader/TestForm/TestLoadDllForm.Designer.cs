namespace WindowsFormsApp1
{
    partial class TestLoadDllForm
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
            this.textBox_dll = new System.Windows.Forms.TextBox();
            this.button_OK = new System.Windows.Forms.Button();
            this.richTextBox_Info = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(36, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "dll:";
            // 
            // textBox_dll
            // 
            this.textBox_dll.Location = new System.Drawing.Point(71, 23);
            this.textBox_dll.Name = "textBox_dll";
            this.textBox_dll.Size = new System.Drawing.Size(351, 21);
            this.textBox_dll.TabIndex = 1;
            this.textBox_dll.Text = "C:\\Users\\Administrator\\Desktop\\AI-Trader\\AITrader\\Commonlib\\Strategy.dll";
            // 
            // button_OK
            // 
            this.button_OK.Location = new System.Drawing.Point(442, 21);
            this.button_OK.Name = "button_OK";
            this.button_OK.Size = new System.Drawing.Size(132, 23);
            this.button_OK.TabIndex = 2;
            this.button_OK.Text = "加载dll信息";
            this.button_OK.UseVisualStyleBackColor = true;
            this.button_OK.Click += new System.EventHandler(this.Button_OK_Click);
            // 
            // richTextBox_Info
            // 
            this.richTextBox_Info.Location = new System.Drawing.Point(38, 68);
            this.richTextBox_Info.Name = "richTextBox_Info";
            this.richTextBox_Info.Size = new System.Drawing.Size(536, 345);
            this.richTextBox_Info.TabIndex = 3;
            this.richTextBox_Info.Text = "";
            // 
            // TestLoadDllForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.richTextBox_Info);
            this.Controls.Add(this.button_OK);
            this.Controls.Add(this.textBox_dll);
            this.Controls.Add(this.label1);
            this.Name = "TestLoadDllForm";
            this.Text = "TestLoadDllForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox_dll;
        private System.Windows.Forms.Button button_OK;
        private System.Windows.Forms.RichTextBox richTextBox_Info;
    }
}