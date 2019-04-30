namespace WindowsFormsApp1
{
    partial class StrategySettingsForm
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
            this.comboBox_StrategyChoose = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.checkBox_IsVisualSingle = new System.Windows.Forms.CheckBox();
            this.checkBox_IsNotify = new System.Windows.Forms.CheckBox();
            this.checkBox_ISSound = new System.Windows.Forms.CheckBox();
            this.checkBox_ISWeChart = new System.Windows.Forms.CheckBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button_Cancel = new System.Windows.Forms.Button();
            this.button_OK = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox_ins = new System.Windows.Forms.TextBox();
            this.textBox_Frame = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 68);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "选择策略:";
            // 
            // comboBox_StrategyChoose
            // 
            this.comboBox_StrategyChoose.FormattingEnabled = true;
            this.comboBox_StrategyChoose.Items.AddRange(new object[] {
            "测试策略"});
            this.comboBox_StrategyChoose.Location = new System.Drawing.Point(88, 65);
            this.comboBox_StrategyChoose.Name = "comboBox_StrategyChoose";
            this.comboBox_StrategyChoose.Size = new System.Drawing.Size(257, 20);
            this.comboBox_StrategyChoose.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(23, 115);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(131, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "是否显示信号点在图表:";
            // 
            // checkBox_IsVisualSingle
            // 
            this.checkBox_IsVisualSingle.AutoSize = true;
            this.checkBox_IsVisualSingle.Location = new System.Drawing.Point(160, 114);
            this.checkBox_IsVisualSingle.Name = "checkBox_IsVisualSingle";
            this.checkBox_IsVisualSingle.Size = new System.Drawing.Size(90, 16);
            this.checkBox_IsVisualSingle.TabIndex = 5;
            this.checkBox_IsVisualSingle.Text = "显示/不显示";
            this.checkBox_IsVisualSingle.UseVisualStyleBackColor = true;
            // 
            // checkBox_IsNotify
            // 
            this.checkBox_IsNotify.AutoSize = true;
            this.checkBox_IsNotify.Location = new System.Drawing.Point(25, 161);
            this.checkBox_IsNotify.Name = "checkBox_IsNotify";
            this.checkBox_IsNotify.Size = new System.Drawing.Size(78, 16);
            this.checkBox_IsNotify.TabIndex = 6;
            this.checkBox_IsNotify.Text = "启用警报:";
            this.checkBox_IsNotify.UseVisualStyleBackColor = true;
            // 
            // checkBox_ISSound
            // 
            this.checkBox_ISSound.AutoSize = true;
            this.checkBox_ISSound.Location = new System.Drawing.Point(54, 216);
            this.checkBox_ISSound.Name = "checkBox_ISSound";
            this.checkBox_ISSound.Size = new System.Drawing.Size(90, 16);
            this.checkBox_ISSound.TabIndex = 7;
            this.checkBox_ISSound.Text = "客户端声音:";
            this.checkBox_ISSound.UseVisualStyleBackColor = true;
            // 
            // checkBox_ISWeChart
            // 
            this.checkBox_ISWeChart.AutoSize = true;
            this.checkBox_ISWeChart.Location = new System.Drawing.Point(54, 279);
            this.checkBox_ISWeChart.Name = "checkBox_ISWeChart";
            this.checkBox_ISWeChart.Size = new System.Drawing.Size(78, 16);
            this.checkBox_ISWeChart.TabIndex = 8;
            this.checkBox_ISWeChart.Text = "微信推送:";
            this.checkBox_ISWeChart.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.panel1.Controls.Add(this.button_Cancel);
            this.panel1.Controls.Add(this.button_OK);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 318);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(370, 49);
            this.panel1.TabIndex = 9;
            // 
            // button_Cancel
            // 
            this.button_Cancel.Location = new System.Drawing.Point(270, 7);
            this.button_Cancel.Name = "button_Cancel";
            this.button_Cancel.Size = new System.Drawing.Size(75, 34);
            this.button_Cancel.TabIndex = 1;
            this.button_Cancel.Text = "取消";
            this.button_Cancel.UseVisualStyleBackColor = true;
            this.button_Cancel.Click += new System.EventHandler(this.Button_Cancel_Click);
            // 
            // button_OK
            // 
            this.button_OK.Location = new System.Drawing.Point(184, 6);
            this.button_OK.Name = "button_OK";
            this.button_OK.Size = new System.Drawing.Size(75, 34);
            this.button_OK.TabIndex = 0;
            this.button_OK.Text = "应用";
            this.button_OK.UseVisualStyleBackColor = true;
            this.button_OK.Click += new System.EventHandler(this.Button_OK_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(47, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 12);
            this.label3.TabIndex = 10;
            this.label3.Text = "合约:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(23, 41);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 12);
            this.label4.TabIndex = 12;
            this.label4.Text = "图表周期:";
            // 
            // textBox_ins
            // 
            this.textBox_ins.Location = new System.Drawing.Point(89, 15);
            this.textBox_ins.Name = "textBox_ins";
            this.textBox_ins.ReadOnly = true;
            this.textBox_ins.Size = new System.Drawing.Size(256, 21);
            this.textBox_ins.TabIndex = 13;
            // 
            // textBox_Frame
            // 
            this.textBox_Frame.Location = new System.Drawing.Point(89, 38);
            this.textBox_Frame.Name = "textBox_Frame";
            this.textBox_Frame.ReadOnly = true;
            this.textBox_Frame.Size = new System.Drawing.Size(256, 21);
            this.textBox_Frame.TabIndex = 14;
            // 
            // StrategySettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(370, 367);
            this.Controls.Add(this.textBox_Frame);
            this.Controls.Add(this.textBox_ins);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.checkBox_ISWeChart);
            this.Controls.Add(this.checkBox_ISSound);
            this.Controls.Add(this.checkBox_IsNotify);
            this.Controls.Add(this.checkBox_IsVisualSingle);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comboBox_StrategyChoose);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "StrategySettingsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "策略属性设置";
            this.Load += new System.EventHandler(this.Form_Load);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox_StrategyChoose;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox checkBox_IsVisualSingle;
        private System.Windows.Forms.CheckBox checkBox_IsNotify;
        private System.Windows.Forms.CheckBox checkBox_ISSound;
        private System.Windows.Forms.CheckBox checkBox_ISWeChart;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button_Cancel;
        private System.Windows.Forms.Button button_OK;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox_ins;
        private System.Windows.Forms.TextBox textBox_Frame;
    }
}