namespace WindowsFormsApp1
{
    partial class RenkoSettingsForm
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
            this.textBox_RenkoBoxSize = new System.Windows.Forms.TextBox();
            this.textBox_RenkoFrame = new System.Windows.Forms.TextBox();
            this.comboBox_StyleCombine = new System.Windows.Forms.ComboBox();
            this.comboBox_POintRate = new System.Windows.Forms.ComboBox();
            this.comboBox_FrameStyle = new System.Windows.Forms.ComboBox();
            this.checkBox_CloseBreak = new System.Windows.Forms.CheckBox();
            this.checkBox_VisualNoBar = new System.Windows.Forms.CheckBox();
            this.checkBox_VisualCnadle = new System.Windows.Forms.CheckBox();
            this.checkBox_VisualRealOpen = new System.Windows.Forms.CheckBox();
            this.button_OK = new System.Windows.Forms.Button();
            this.button_Cancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "单位大小:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "周期:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(20, 77);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "组合方式:";
            // 
            // textBox_RenkoBoxSize
            // 
            this.textBox_RenkoBoxSize.Location = new System.Drawing.Point(85, 20);
            this.textBox_RenkoBoxSize.Name = "textBox_RenkoBoxSize";
            this.textBox_RenkoBoxSize.Size = new System.Drawing.Size(100, 21);
            this.textBox_RenkoBoxSize.TabIndex = 3;
            this.textBox_RenkoBoxSize.Text = "2";
            // 
            // textBox_RenkoFrame
            // 
            this.textBox_RenkoFrame.Location = new System.Drawing.Point(85, 47);
            this.textBox_RenkoFrame.Name = "textBox_RenkoFrame";
            this.textBox_RenkoFrame.Size = new System.Drawing.Size(100, 21);
            this.textBox_RenkoFrame.TabIndex = 4;
            this.textBox_RenkoFrame.Text = "1";
            // 
            // comboBox_StyleCombine
            // 
            this.comboBox_StyleCombine.FormattingEnabled = true;
            this.comboBox_StyleCombine.Items.AddRange(new object[] {
            "开高低收",
            "收盘价"});
            this.comboBox_StyleCombine.Location = new System.Drawing.Point(85, 74);
            this.comboBox_StyleCombine.Name = "comboBox_StyleCombine";
            this.comboBox_StyleCombine.Size = new System.Drawing.Size(100, 20);
            this.comboBox_StyleCombine.TabIndex = 5;
            // 
            // comboBox_POintRate
            // 
            this.comboBox_POintRate.FormattingEnabled = true;
            this.comboBox_POintRate.Items.AddRange(new object[] {
            "点(固定)",
            "%(比率)"});
            this.comboBox_POintRate.Location = new System.Drawing.Point(191, 20);
            this.comboBox_POintRate.Name = "comboBox_POintRate";
            this.comboBox_POintRate.Size = new System.Drawing.Size(94, 20);
            this.comboBox_POintRate.TabIndex = 6;
            // 
            // comboBox_FrameStyle
            // 
            this.comboBox_FrameStyle.FormattingEnabled = true;
            this.comboBox_FrameStyle.Items.AddRange(new object[] {
            "Tick",
            "1分钟",
            "5分钟"});
            this.comboBox_FrameStyle.Location = new System.Drawing.Point(191, 48);
            this.comboBox_FrameStyle.Name = "comboBox_FrameStyle";
            this.comboBox_FrameStyle.Size = new System.Drawing.Size(94, 20);
            this.comboBox_FrameStyle.TabIndex = 7;
            // 
            // checkBox_CloseBreak
            // 
            this.checkBox_CloseBreak.AutoSize = true;
            this.checkBox_CloseBreak.Location = new System.Drawing.Point(85, 101);
            this.checkBox_CloseBreak.Name = "checkBox_CloseBreak";
            this.checkBox_CloseBreak.Size = new System.Drawing.Size(84, 16);
            this.checkBox_CloseBreak.TabIndex = 8;
            this.checkBox_CloseBreak.Text = "收盘时中断";
            this.checkBox_CloseBreak.UseVisualStyleBackColor = true;
            // 
            // checkBox_VisualNoBar
            // 
            this.checkBox_VisualNoBar.AutoSize = true;
            this.checkBox_VisualNoBar.Location = new System.Drawing.Point(169, 100);
            this.checkBox_VisualNoBar.Name = "checkBox_VisualNoBar";
            this.checkBox_VisualNoBar.Size = new System.Drawing.Size(90, 16);
            this.checkBox_VisualNoBar.TabIndex = 9;
            this.checkBox_VisualNoBar.Text = "显示幽灵Bar";
            this.checkBox_VisualNoBar.UseVisualStyleBackColor = true;
            // 
            // checkBox_VisualCnadle
            // 
            this.checkBox_VisualCnadle.AutoSize = true;
            this.checkBox_VisualCnadle.Location = new System.Drawing.Point(85, 123);
            this.checkBox_VisualCnadle.Name = "checkBox_VisualCnadle";
            this.checkBox_VisualCnadle.Size = new System.Drawing.Size(72, 16);
            this.checkBox_VisualCnadle.TabIndex = 10;
            this.checkBox_VisualCnadle.Text = "显示烛芯";
            this.checkBox_VisualCnadle.UseVisualStyleBackColor = true;
            // 
            // checkBox_VisualRealOpen
            // 
            this.checkBox_VisualRealOpen.AutoSize = true;
            this.checkBox_VisualRealOpen.Location = new System.Drawing.Point(169, 122);
            this.checkBox_VisualRealOpen.Name = "checkBox_VisualRealOpen";
            this.checkBox_VisualRealOpen.Size = new System.Drawing.Size(108, 16);
            this.checkBox_VisualRealOpen.TabIndex = 11;
            this.checkBox_VisualRealOpen.Text = "显示真实开盘价";
            this.checkBox_VisualRealOpen.UseVisualStyleBackColor = true;
            // 
            // button_OK
            // 
            this.button_OK.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.button_OK.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button_OK.Location = new System.Drawing.Point(302, 87);
            this.button_OK.Name = "button_OK";
            this.button_OK.Size = new System.Drawing.Size(75, 23);
            this.button_OK.TabIndex = 12;
            this.button_OK.Text = "确定";
            this.button_OK.UseVisualStyleBackColor = false;
            this.button_OK.Click += new System.EventHandler(this.Button_OK_Click);
            // 
            // button_Cancel
            // 
            this.button_Cancel.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.button_Cancel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button_Cancel.Location = new System.Drawing.Point(302, 116);
            this.button_Cancel.Name = "button_Cancel";
            this.button_Cancel.Size = new System.Drawing.Size(75, 23);
            this.button_Cancel.TabIndex = 13;
            this.button_Cancel.Text = "取消";
            this.button_Cancel.UseVisualStyleBackColor = false;
            this.button_Cancel.Click += new System.EventHandler(this.Button_Cancel_Click);
            // 
            // RenkoSettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(389, 153);
            this.Controls.Add(this.button_Cancel);
            this.Controls.Add(this.button_OK);
            this.Controls.Add(this.checkBox_VisualRealOpen);
            this.Controls.Add(this.checkBox_VisualCnadle);
            this.Controls.Add(this.checkBox_VisualNoBar);
            this.Controls.Add(this.checkBox_CloseBreak);
            this.Controls.Add(this.comboBox_FrameStyle);
            this.Controls.Add(this.comboBox_POintRate);
            this.Controls.Add(this.comboBox_StyleCombine);
            this.Controls.Add(this.textBox_RenkoFrame);
            this.Controls.Add(this.textBox_RenkoBoxSize);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "RenkoSettingsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "砖型图图表参数设置";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox_RenkoBoxSize;
        private System.Windows.Forms.TextBox textBox_RenkoFrame;
        private System.Windows.Forms.ComboBox comboBox_StyleCombine;
        private System.Windows.Forms.ComboBox comboBox_POintRate;
        private System.Windows.Forms.ComboBox comboBox_FrameStyle;
        private System.Windows.Forms.CheckBox checkBox_CloseBreak;
        private System.Windows.Forms.CheckBox checkBox_VisualNoBar;
        private System.Windows.Forms.CheckBox checkBox_VisualCnadle;
        private System.Windows.Forms.CheckBox checkBox_VisualRealOpen;
        private System.Windows.Forms.Button button_OK;
        private System.Windows.Forms.Button button_Cancel;
    }
}