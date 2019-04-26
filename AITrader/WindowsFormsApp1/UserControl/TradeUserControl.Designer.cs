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
            this.tabPage_Money = new System.Windows.Forms.TabPage();
            this.tabPage_log = new System.Windows.Forms.TabPage();
            this.tabPage_notify = new System.Windows.Forms.TabPage();
            this.tabPage_wechat = new System.Windows.Forms.TabPage();
            this.tabPage_auto = new System.Windows.Forms.TabPage();
            this.tabPage_ins = new System.Windows.Forms.TabPage();
            this.tabPage_Trade = new System.Windows.Forms.TabPage();
            this.quickOrderUserControl1 = new WindowsFormsApp1.QuickOrderUserControl();
            this.visualTradingUserControl1 = new WindowsFormsApp1.VisualTradingUserControl();
            this.visualLogUserControl1 = new WindowsFormsApp1.VisualLogUserControl();
            this.instrumentsInfoUserControl1 = new WindowsFormsApp1.InstrumentsInfoUserControl();
            this.tabControl1.SuspendLayout();
            this.tabPage_Money.SuspendLayout();
            this.tabPage_log.SuspendLayout();
            this.tabPage_ins.SuspendLayout();
            this.tabPage_Trade.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Alignment = System.Windows.Forms.TabAlignment.Bottom;
            this.tabControl1.Controls.Add(this.tabPage_Trade);
            this.tabControl1.Controls.Add(this.tabPage_Money);
            this.tabControl1.Controls.Add(this.tabPage_log);
            this.tabControl1.Controls.Add(this.tabPage_notify);
            this.tabControl1.Controls.Add(this.tabPage_wechat);
            this.tabControl1.Controls.Add(this.tabPage_auto);
            this.tabControl1.Controls.Add(this.tabPage_ins);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1054, 460);
            this.tabControl1.TabIndex = 0;
            this.tabControl1.Selecting += new System.Windows.Forms.TabControlCancelEventHandler(this.Tabpage_SelectingClick);
            // 
            // tabPage_Money
            // 
            this.tabPage_Money.Controls.Add(this.visualTradingUserControl1);
            this.tabPage_Money.Location = new System.Drawing.Point(4, 4);
            this.tabPage_Money.Name = "tabPage_Money";
            this.tabPage_Money.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_Money.Size = new System.Drawing.Size(1046, 434);
            this.tabPage_Money.TabIndex = 1;
            this.tabPage_Money.Text = "数字货币钱包";
            this.tabPage_Money.UseVisualStyleBackColor = true;
            // 
            // tabPage_log
            // 
            this.tabPage_log.Controls.Add(this.visualLogUserControl1);
            this.tabPage_log.Location = new System.Drawing.Point(4, 4);
            this.tabPage_log.Name = "tabPage_log";
            this.tabPage_log.Size = new System.Drawing.Size(1046, 434);
            this.tabPage_log.TabIndex = 4;
            this.tabPage_log.Text = "日志";
            this.tabPage_log.UseVisualStyleBackColor = true;
            // 
            // tabPage_notify
            // 
            this.tabPage_notify.Location = new System.Drawing.Point(4, 4);
            this.tabPage_notify.Name = "tabPage_notify";
            this.tabPage_notify.Size = new System.Drawing.Size(1046, 434);
            this.tabPage_notify.TabIndex = 5;
            this.tabPage_notify.Text = "警报";
            this.tabPage_notify.UseVisualStyleBackColor = true;
            // 
            // tabPage_wechat
            // 
            this.tabPage_wechat.Location = new System.Drawing.Point(4, 4);
            this.tabPage_wechat.Name = "tabPage_wechat";
            this.tabPage_wechat.Size = new System.Drawing.Size(1046, 434);
            this.tabPage_wechat.TabIndex = 6;
            this.tabPage_wechat.Text = "交易微信实时提示功能";
            this.tabPage_wechat.UseVisualStyleBackColor = true;
            // 
            // tabPage_auto
            // 
            this.tabPage_auto.Location = new System.Drawing.Point(4, 4);
            this.tabPage_auto.Name = "tabPage_auto";
            this.tabPage_auto.Size = new System.Drawing.Size(1046, 434);
            this.tabPage_auto.TabIndex = 7;
            this.tabPage_auto.Text = "自动交易设置";
            this.tabPage_auto.UseVisualStyleBackColor = true;
            // 
            // tabPage_ins
            // 
            this.tabPage_ins.Controls.Add(this.instrumentsInfoUserControl1);
            this.tabPage_ins.Location = new System.Drawing.Point(4, 4);
            this.tabPage_ins.Name = "tabPage_ins";
            this.tabPage_ins.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_ins.Size = new System.Drawing.Size(1046, 434);
            this.tabPage_ins.TabIndex = 8;
            this.tabPage_ins.Text = "永续合约基础信息";
            this.tabPage_ins.UseVisualStyleBackColor = true;
            // 
            // tabPage_Trade
            // 
            this.tabPage_Trade.Controls.Add(this.quickOrderUserControl1);
            this.tabPage_Trade.Location = new System.Drawing.Point(4, 4);
            this.tabPage_Trade.Name = "tabPage_Trade";
            this.tabPage_Trade.Size = new System.Drawing.Size(1046, 434);
            this.tabPage_Trade.TabIndex = 9;
            this.tabPage_Trade.Text = "下单板";
            this.tabPage_Trade.UseVisualStyleBackColor = true;
            // 
            // quickOrderUserControl1
            // 
            this.quickOrderUserControl1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.quickOrderUserControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.quickOrderUserControl1.Location = new System.Drawing.Point(0, 0);
            this.quickOrderUserControl1.Name = "quickOrderUserControl1";
            this.quickOrderUserControl1.Size = new System.Drawing.Size(1046, 434);
            this.quickOrderUserControl1.TabIndex = 0;
            this.quickOrderUserControl1.Load += new System.EventHandler(this.TradeUserControl_Load);
            // 
            // visualTradingUserControl1
            // 
            this.visualTradingUserControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.visualTradingUserControl1.Location = new System.Drawing.Point(3, 3);
            this.visualTradingUserControl1.Name = "visualTradingUserControl1";
            this.visualTradingUserControl1.Size = new System.Drawing.Size(1040, 428);
            this.visualTradingUserControl1.TabIndex = 0;
            // 
            // visualLogUserControl1
            // 
            this.visualLogUserControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.visualLogUserControl1.Location = new System.Drawing.Point(0, 0);
            this.visualLogUserControl1.Name = "visualLogUserControl1";
            this.visualLogUserControl1.Size = new System.Drawing.Size(1046, 434);
            this.visualLogUserControl1.TabIndex = 0;
            // 
            // instrumentsInfoUserControl1
            // 
            this.instrumentsInfoUserControl1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.instrumentsInfoUserControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.instrumentsInfoUserControl1.Location = new System.Drawing.Point(3, 3);
            this.instrumentsInfoUserControl1.Name = "instrumentsInfoUserControl1";
            this.instrumentsInfoUserControl1.Size = new System.Drawing.Size(1040, 428);
            this.instrumentsInfoUserControl1.TabIndex = 0;
            // 
            // TradeUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabControl1);
            this.Name = "TradeUserControl";
            this.Size = new System.Drawing.Size(1054, 460);
            this.tabControl1.ResumeLayout(false);
            this.tabPage_Money.ResumeLayout(false);
            this.tabPage_log.ResumeLayout(false);
            this.tabPage_ins.ResumeLayout(false);
            this.tabPage_Trade.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage_Money;
        private System.Windows.Forms.TabPage tabPage_log;
        private System.Windows.Forms.TabPage tabPage_notify;
        private System.Windows.Forms.TabPage tabPage_wechat;
        private System.Windows.Forms.TabPage tabPage_auto;
        private System.Windows.Forms.TabPage tabPage_ins;
        private InstrumentsInfoUserControl instrumentsInfoUserControl1;
        private VisualLogUserControl visualLogUserControl1;
        private VisualTradingUserControl visualTradingUserControl1;
        private System.Windows.Forms.TabPage tabPage_Trade;
        private QuickOrderUserControl quickOrderUserControl1;
    }
}
