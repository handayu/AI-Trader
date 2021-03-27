namespace WindowsFormsApp1
{
    partial class ZedKLineForm
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
            this.components = new System.ComponentModel.Container();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton_StartStrategy = new System.Windows.Forms.ToolStripDropDownButton();
            this.ToolStripMenuItem_StrategyAutoAction = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem_StrategySettings = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripDropDownButton1 = new System.Windows.Forms.ToolStripDropDownButton();
            this.ToolStripMenuItem_Self = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem_IndicatorsCommonIn = new System.Windows.Forms.ToolStripMenuItem();
            this.mAToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem_Custems = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel_1Min = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton_5Min = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton_15Min = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton_30Min = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton_60Min = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripDropDownButton2 = new System.Windows.Forms.ToolStripDropDownButton();
            this.ToolStripMenuItem_CandleKLine = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem_Renko = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem_StockKline = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripDropDownButton3 = new System.Windows.Forms.ToolStripDropDownButton();
            this.ToolStripMenuItem_BlackGround = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem_WhiteGround = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.ToolStripMenuItem_Log = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton_ViusalTrade = new System.Windows.Forms.ToolStripButton();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ToolStripMenuItem_VisualIndocator = new System.Windows.Forms.ToolStripMenuItem();
            this.timer_NotifyPosition = new System.Windows.Forms.Timer(this.components);
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.zedGraphControl1 = new ZedGraph.ZedGraphControl();
            this.panel_Trade = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.richTextBox_StrategyLog = new System.Windows.Forms.RichTextBox();
            this.richTextBox_ChartAndIndicatorsLog = new System.Windows.Forms.RichTextBox();
            this.toolStrip1.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton_StartStrategy,
            this.toolStripDropDownButton1,
            this.toolStripSeparator1,
            this.toolStripLabel_1Min,
            this.toolStripButton_5Min,
            this.toolStripButton_15Min,
            this.toolStripButton_30Min,
            this.toolStripButton_60Min,
            this.toolStripSeparator2,
            this.toolStripDropDownButton2,
            this.toolStripDropDownButton3,
            this.toolStripSeparator3,
            this.ToolStripMenuItem_Log,
            this.toolStripSeparator5,
            this.toolStripButton_ViusalTrade});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(923, 31);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButton_StartStrategy
            // 
            this.toolStripButton_StartStrategy.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItem_StrategyAutoAction,
            this.ToolStripMenuItem_StrategySettings});
            this.toolStripButton_StartStrategy.Image = global::AITrader.Properties.Resources.stop;
            this.toolStripButton_StartStrategy.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_StartStrategy.Name = "toolStripButton_StartStrategy";
            this.toolStripButton_StartStrategy.Size = new System.Drawing.Size(93, 28);
            this.toolStripButton_StartStrategy.Text = "策略交易";
            // 
            // ToolStripMenuItem_StrategyAutoAction
            // 
            this.ToolStripMenuItem_StrategyAutoAction.Image = global::AITrader.Properties.Resources._6b41346d30a6d19b7fdfc283add2871;
            this.ToolStripMenuItem_StrategyAutoAction.Name = "ToolStripMenuItem_StrategyAutoAction";
            this.ToolStripMenuItem_StrategyAutoAction.Size = new System.Drawing.Size(148, 22);
            this.ToolStripMenuItem_StrategyAutoAction.Text = "自动交易执行";
            // 
            // ToolStripMenuItem_StrategySettings
            // 
            this.ToolStripMenuItem_StrategySettings.Image = global::AITrader.Properties.Resources.a2102536be0be8e0e7fa63dee8061a6e_t01bcc617f0d4a93e3a;
            this.ToolStripMenuItem_StrategySettings.Name = "ToolStripMenuItem_StrategySettings";
            this.ToolStripMenuItem_StrategySettings.Size = new System.Drawing.Size(148, 22);
            this.ToolStripMenuItem_StrategySettings.Text = "策略属性设置";
            // 
            // toolStripDropDownButton1
            // 
            this.toolStripDropDownButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItem_Self,
            this.ToolStripMenuItem_Custems});
            this.toolStripDropDownButton1.Image = global::AITrader.Properties.Resources.icons8_heart_monitor_481;
            this.toolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton1.Name = "toolStripDropDownButton1";
            this.toolStripDropDownButton1.Size = new System.Drawing.Size(69, 28);
            this.toolStripDropDownButton1.Text = "指标";
            // 
            // ToolStripMenuItem_Self
            // 
            this.ToolStripMenuItem_Self.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItem_IndicatorsCommonIn,
            this.mAToolStripMenuItem});
            this.ToolStripMenuItem_Self.Name = "ToolStripMenuItem_Self";
            this.ToolStripMenuItem_Self.Size = new System.Drawing.Size(148, 22);
            this.ToolStripMenuItem_Self.Text = "自定义指标";
            // 
            // ToolStripMenuItem_IndicatorsCommonIn
            // 
            this.ToolStripMenuItem_IndicatorsCommonIn.Name = "ToolStripMenuItem_IndicatorsCommonIn";
            this.ToolStripMenuItem_IndicatorsCommonIn.Size = new System.Drawing.Size(99, 22);
            this.ToolStripMenuItem_IndicatorsCommonIn.Text = "SAR";
            // 
            // mAToolStripMenuItem
            // 
            this.mAToolStripMenuItem.Name = "mAToolStripMenuItem";
            this.mAToolStripMenuItem.Size = new System.Drawing.Size(99, 22);
            this.mAToolStripMenuItem.Text = "MA";
            // 
            // ToolStripMenuItem_Custems
            // 
            this.ToolStripMenuItem_Custems.Name = "ToolStripMenuItem_Custems";
            this.ToolStripMenuItem_Custems.Size = new System.Drawing.Size(148, 22);
            this.ToolStripMenuItem_Custems.Text = "交易常用指标";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 31);
            // 
            // toolStripLabel_1Min
            // 
            this.toolStripLabel_1Min.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripLabel_1Min.Image = global::AITrader.Properties.Resources.icons8_1_482;
            this.toolStripLabel_1Min.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripLabel_1Min.Name = "toolStripLabel_1Min";
            this.toolStripLabel_1Min.Size = new System.Drawing.Size(28, 28);
            this.toolStripLabel_1Min.Text = "toolStripLabel1";
            // 
            // toolStripButton_5Min
            // 
            this.toolStripButton_5Min.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton_5Min.Image = global::AITrader.Properties.Resources.icons8_5_482;
            this.toolStripButton_5Min.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_5Min.Name = "toolStripButton_5Min";
            this.toolStripButton_5Min.Size = new System.Drawing.Size(28, 28);
            this.toolStripButton_5Min.Text = "toolStripButton2";
            // 
            // toolStripButton_15Min
            // 
            this.toolStripButton_15Min.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton_15Min.Image = global::AITrader.Properties.Resources.icons8_15_483;
            this.toolStripButton_15Min.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_15Min.Name = "toolStripButton_15Min";
            this.toolStripButton_15Min.Size = new System.Drawing.Size(28, 28);
            this.toolStripButton_15Min.Text = "toolStripButton3";
            // 
            // toolStripButton_30Min
            // 
            this.toolStripButton_30Min.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton_30Min.Image = global::AITrader.Properties.Resources.icons8_30_482;
            this.toolStripButton_30Min.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_30Min.Name = "toolStripButton_30Min";
            this.toolStripButton_30Min.Size = new System.Drawing.Size(28, 28);
            this.toolStripButton_30Min.Text = "toolStripButton4";
            // 
            // toolStripButton_60Min
            // 
            this.toolStripButton_60Min.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton_60Min.Image = global::AITrader.Properties.Resources.icons8_60_481;
            this.toolStripButton_60Min.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_60Min.Name = "toolStripButton_60Min";
            this.toolStripButton_60Min.Size = new System.Drawing.Size(28, 28);
            this.toolStripButton_60Min.Text = "toolStripButton5";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 31);
            // 
            // toolStripDropDownButton2
            // 
            this.toolStripDropDownButton2.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItem_CandleKLine,
            this.ToolStripMenuItem_Renko,
            this.ToolStripMenuItem_StockKline});
            this.toolStripDropDownButton2.Image = global::AITrader.Properties.Resources.icons8_google_forms_481;
            this.toolStripDropDownButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton2.Name = "toolStripDropDownButton2";
            this.toolStripDropDownButton2.Size = new System.Drawing.Size(93, 28);
            this.toolStripDropDownButton2.Text = "图表类型";
            // 
            // ToolStripMenuItem_CandleKLine
            // 
            this.ToolStripMenuItem_CandleKLine.Name = "ToolStripMenuItem_CandleKLine";
            this.ToolStripMenuItem_CandleKLine.Size = new System.Drawing.Size(112, 22);
            this.ToolStripMenuItem_CandleKLine.Text = "蜡烛线";
            // 
            // ToolStripMenuItem_Renko
            // 
            this.ToolStripMenuItem_Renko.Name = "ToolStripMenuItem_Renko";
            this.ToolStripMenuItem_Renko.Size = new System.Drawing.Size(112, 22);
            this.ToolStripMenuItem_Renko.Text = "转型图";
            // 
            // ToolStripMenuItem_StockKline
            // 
            this.ToolStripMenuItem_StockKline.Name = "ToolStripMenuItem_StockKline";
            this.ToolStripMenuItem_StockKline.Size = new System.Drawing.Size(112, 22);
            this.ToolStripMenuItem_StockKline.Text = "宝塔线";
            // 
            // toolStripDropDownButton3
            // 
            this.toolStripDropDownButton3.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItem_BlackGround,
            this.ToolStripMenuItem_WhiteGround,
            this.toolStripSeparator4});
            this.toolStripDropDownButton3.Image = global::AITrader.Properties.Resources.icons8_automatic_481;
            this.toolStripDropDownButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton3.Name = "toolStripDropDownButton3";
            this.toolStripDropDownButton3.Size = new System.Drawing.Size(93, 28);
            this.toolStripDropDownButton3.Text = "窗口设置";
            // 
            // ToolStripMenuItem_BlackGround
            // 
            this.ToolStripMenuItem_BlackGround.Name = "ToolStripMenuItem_BlackGround";
            this.ToolStripMenuItem_BlackGround.Size = new System.Drawing.Size(124, 22);
            this.ToolStripMenuItem_BlackGround.Text = "黑色背景";
            // 
            // ToolStripMenuItem_WhiteGround
            // 
            this.ToolStripMenuItem_WhiteGround.Name = "ToolStripMenuItem_WhiteGround";
            this.ToolStripMenuItem_WhiteGround.Size = new System.Drawing.Size(124, 22);
            this.ToolStripMenuItem_WhiteGround.Text = "白色背景";
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(121, 6);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 31);
            // 
            // ToolStripMenuItem_Log
            // 
            this.ToolStripMenuItem_Log.Image = global::AITrader.Properties.Resources.icons8_purchase_order_481;
            this.ToolStripMenuItem_Log.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ToolStripMenuItem_Log.Name = "ToolStripMenuItem_Log";
            this.ToolStripMenuItem_Log.Size = new System.Drawing.Size(108, 28);
            this.ToolStripMenuItem_Log.Text = "策略实时日志";
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 31);
            // 
            // toolStripButton_ViusalTrade
            // 
            this.toolStripButton_ViusalTrade.Image = global::AITrader.Properties.Resources.icons8_customer_48;
            this.toolStripButton_ViusalTrade.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_ViusalTrade.Name = "toolStripButton_ViusalTrade";
            this.toolStripButton_ViusalTrade.Size = new System.Drawing.Size(84, 28);
            this.toolStripButton_ViusalTrade.Text = "图表交易";
            this.toolStripButton_ViusalTrade.Click += new System.EventHandler(this.ToolStripMenuItem_VisualTradeClick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItem_VisualIndocator});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(154, 26);
            // 
            // ToolStripMenuItem_VisualIndocator
            // 
            this.ToolStripMenuItem_VisualIndocator.Name = "ToolStripMenuItem_VisualIndocator";
            this.ToolStripMenuItem_VisualIndocator.Size = new System.Drawing.Size(153, 22);
            this.ToolStripMenuItem_VisualIndocator.Text = "隐藏/显示指标";
            // 
            // timer_NotifyPosition
            // 
            this.timer_NotifyPosition.Enabled = true;
            this.timer_NotifyPosition.Interval = 3000;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 800F));
            this.tableLayoutPanel1.Controls.Add(this.panel4, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 31);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(923, 417);
            this.tableLayoutPanel1.TabIndex = 9;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.panel1);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(3, 3);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(917, 411);
            this.panel4.TabIndex = 8;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.splitContainer1);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(917, 411);
            this.panel1.TabIndex = 6;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(176, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.zedGraphControl1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.panel_Trade);
            this.splitContainer1.Size = new System.Drawing.Size(741, 411);
            this.splitContainer1.SplitterDistance = 485;
            this.splitContainer1.TabIndex = 6;
            // 
            // zedGraphControl1
            // 
            this.zedGraphControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.zedGraphControl1.Location = new System.Drawing.Point(0, 0);
            this.zedGraphControl1.Name = "zedGraphControl1";
            this.zedGraphControl1.ScrollGrace = 0D;
            this.zedGraphControl1.ScrollMaxX = 0D;
            this.zedGraphControl1.ScrollMaxY = 0D;
            this.zedGraphControl1.ScrollMaxY2 = 0D;
            this.zedGraphControl1.ScrollMinX = 0D;
            this.zedGraphControl1.ScrollMinY = 0D;
            this.zedGraphControl1.ScrollMinY2 = 0D;
            this.zedGraphControl1.Size = new System.Drawing.Size(485, 411);
            this.zedGraphControl1.TabIndex = 0;
            this.zedGraphControl1.UseExtendedPrintDialog = true;
            // 
            // panel_Trade
            // 
            this.panel_Trade.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_Trade.Location = new System.Drawing.Point(0, 0);
            this.panel_Trade.Name = "panel_Trade";
            this.panel_Trade.Size = new System.Drawing.Size(252, 411);
            this.panel_Trade.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.richTextBox_StrategyLog);
            this.panel2.Controls.Add(this.richTextBox_ChartAndIndicatorsLog);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(176, 411);
            this.panel2.TabIndex = 5;
            this.panel2.Visible = false;
            // 
            // richTextBox_StrategyLog
            // 
            this.richTextBox_StrategyLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBox_StrategyLog.Location = new System.Drawing.Point(0, 199);
            this.richTextBox_StrategyLog.Name = "richTextBox_StrategyLog";
            this.richTextBox_StrategyLog.Size = new System.Drawing.Size(176, 212);
            this.richTextBox_StrategyLog.TabIndex = 1;
            this.richTextBox_StrategyLog.Text = ">>策略日志开启:";
            // 
            // richTextBox_ChartAndIndicatorsLog
            // 
            this.richTextBox_ChartAndIndicatorsLog.Dock = System.Windows.Forms.DockStyle.Top;
            this.richTextBox_ChartAndIndicatorsLog.Location = new System.Drawing.Point(0, 0);
            this.richTextBox_ChartAndIndicatorsLog.Name = "richTextBox_ChartAndIndicatorsLog";
            this.richTextBox_ChartAndIndicatorsLog.Size = new System.Drawing.Size(176, 199);
            this.richTextBox_ChartAndIndicatorsLog.TabIndex = 0;
            this.richTextBox_ChartAndIndicatorsLog.Text = "";
            // 
            // ZedKLineForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(923, 448);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.toolStrip1);
            this.Font = new System.Drawing.Font("SimSun", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Name = "ZedKLineForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "BTC永续合约 -K线图1.0 1Min Bar -AutoTrader";
            this.Load += new System.EventHandler(this.Form_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripDropDownButton toolStripButton_StartStrategy;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem_StrategyAutoAction;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem_StrategySettings;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton1;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem_Self;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton toolStripLabel_1Min;
        private System.Windows.Forms.ToolStripButton toolStripButton_5Min;
        private System.Windows.Forms.ToolStripButton toolStripButton_15Min;
        private System.Windows.Forms.ToolStripButton toolStripButton_30Min;
        private System.Windows.Forms.ToolStripButton toolStripButton_60Min;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton2;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem_CandleKLine;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem_Renko;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem_StockKline;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton3;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem_BlackGround;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem_WhiteGround;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripButton ToolStripMenuItem_Log;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.Timer timer_NotifyPosition;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem_IndicatorsCommonIn;
        private System.Windows.Forms.ToolStripMenuItem mAToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem_VisualIndocator;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem_Custems;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private ZedGraph.ZedGraphControl zedGraphControl1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.RichTextBox richTextBox_StrategyLog;
        private System.Windows.Forms.RichTextBox richTextBox_ChartAndIndicatorsLog;
        private System.Windows.Forms.ToolStripButton toolStripButton_ViusalTrade;
        private System.Windows.Forms.Panel panel_Trade;
    }
}