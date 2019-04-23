namespace WindowsFormsApp1
{
    partial class TradeUserControl
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.tabPage6 = new System.Windows.Forms.TabPage();
            this.tabPage7 = new System.Windows.Forms.TabPage();
            this.tabPage8 = new System.Windows.Forms.TabPage();
            this.visualTradingUserControl1 = new WindowsFormsApp1.VisualTradingUserControl();
            this.autoTradeUserControl1 = new WindowsFormsApp1.AutoTradeUserControl();
            this.visualLogUserControl1 = new WindowsFormsApp1.VisualLogUserControl();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage5.SuspendLayout();
            this.tabPage8.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Alignment = System.Windows.Forms.TabAlignment.Bottom;
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Controls.Add(this.tabPage5);
            this.tabControl1.Controls.Add(this.tabPage6);
            this.tabControl1.Controls.Add(this.tabPage7);
            this.tabControl1.Controls.Add(this.tabPage8);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(669, 199);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.visualTradingUserControl1);
            this.tabPage1.Location = new System.Drawing.Point(4, 4);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(661, 173);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "交易";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 4);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(661, 173);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "账户";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            this.tabPage3.Location = new System.Drawing.Point(4, 4);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(661, 173);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "委托";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // tabPage4
            // 
            this.tabPage4.Location = new System.Drawing.Point(4, 4);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(661, 173);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "成交";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.visualLogUserControl1);
            this.tabPage5.Location = new System.Drawing.Point(4, 4);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Size = new System.Drawing.Size(661, 173);
            this.tabPage5.TabIndex = 4;
            this.tabPage5.Text = "日志";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // tabPage6
            // 
            this.tabPage6.Location = new System.Drawing.Point(4, 4);
            this.tabPage6.Name = "tabPage6";
            this.tabPage6.Size = new System.Drawing.Size(661, 173);
            this.tabPage6.TabIndex = 5;
            this.tabPage6.Text = "警报";
            this.tabPage6.UseVisualStyleBackColor = true;
            // 
            // tabPage7
            // 
            this.tabPage7.Location = new System.Drawing.Point(4, 4);
            this.tabPage7.Name = "tabPage7";
            this.tabPage7.Size = new System.Drawing.Size(661, 173);
            this.tabPage7.TabIndex = 6;
            this.tabPage7.Text = "交易微信实时提示功能";
            this.tabPage7.UseVisualStyleBackColor = true;
            // 
            // tabPage8
            // 
            this.tabPage8.Controls.Add(this.autoTradeUserControl1);
            this.tabPage8.Location = new System.Drawing.Point(4, 4);
            this.tabPage8.Name = "tabPage8";
            this.tabPage8.Size = new System.Drawing.Size(661, 173);
            this.tabPage8.TabIndex = 7;
            this.tabPage8.Text = "自动交易设置";
            this.tabPage8.UseVisualStyleBackColor = true;
            // 
            // visualTradingUserControl1
            // 
            this.visualTradingUserControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.visualTradingUserControl1.Location = new System.Drawing.Point(3, 3);
            this.visualTradingUserControl1.Name = "visualTradingUserControl1";
            this.visualTradingUserControl1.Size = new System.Drawing.Size(655, 167);
            this.visualTradingUserControl1.TabIndex = 0;
            // 
            // autoTradeUserControl1
            // 
            this.autoTradeUserControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.autoTradeUserControl1.Location = new System.Drawing.Point(0, 0);
            this.autoTradeUserControl1.Name = "autoTradeUserControl1";
            this.autoTradeUserControl1.Size = new System.Drawing.Size(661, 173);
            this.autoTradeUserControl1.TabIndex = 0;
            // 
            // visualLogUserControl1
            // 
            this.visualLogUserControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.visualLogUserControl1.Location = new System.Drawing.Point(0, 0);
            this.visualLogUserControl1.Name = "visualLogUserControl1";
            this.visualLogUserControl1.Size = new System.Drawing.Size(661, 173);
            this.visualLogUserControl1.TabIndex = 0;
            // 
            // TradeUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabControl1);
            this.Name = "TradeUserControl";
            this.Size = new System.Drawing.Size(669, 199);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage5.ResumeLayout(false);
            this.tabPage8.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.TabPage tabPage6;
        private System.Windows.Forms.TabPage tabPage7;
        private System.Windows.Forms.TabPage tabPage8;
        private VisualTradingUserControl visualTradingUserControl1;
        private AutoTradeUserControl autoTradeUserControl1;
        private VisualLogUserControl visualLogUserControl1;
    }
}
