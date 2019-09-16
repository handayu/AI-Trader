namespace WindowsFormsApp1
{
    partial class KLineFormWholeTest
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint1 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(41032.430555555555D, "80,70,60,65");
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint2 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(41032.416666666664D, "80,70,60,65");
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint3 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(41032.409722222219D, "80,70,60,65");
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint4 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(41032.402777777781D, "80,70,60,65");
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint5 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(41032.395833333336D, "80,70,60,65");
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint6 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(41032.388888888891D, "80,70,60,65");
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint7 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(41032.381944444445D, "80,50,70,65");
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint8 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(41032.375D, "80,80,80,80");
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
            this.toolStripButton_Day = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton_ZoomLarge = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton_ZoomSmall = new System.Windows.Forms.ToolStripButton();
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
            this.dateTimePicker_Begin = new System.Windows.Forms.DateTimePicker();
            this.panel1 = new System.Windows.Forms.Panel();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ToolStripMenuItem_VisualIndocator = new System.Windows.Forms.ToolStripMenuItem();
            this.panel2 = new System.Windows.Forms.Panel();
            this.richTextBox_StrategyLog = new System.Windows.Forms.RichTextBox();
            this.richTextBox_ChartAndIndicatorsLog = new System.Windows.Forms.RichTextBox();
            this.timer_NotifyPosition = new System.Windows.Forms.Timer(this.components);
            this.panel4 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.toolStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel4.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
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
            this.toolStripButton_Day,
            this.toolStripSeparator2,
            this.toolStripButton_ZoomLarge,
            this.toolStripButton_ZoomSmall,
            this.toolStripDropDownButton2,
            this.toolStripDropDownButton3,
            this.toolStripSeparator3,
            this.ToolStripMenuItem_Log,
            this.toolStripSeparator5});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(800, 31);
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
            this.ToolStripMenuItem_IndicatorsCommonIn.Click += new System.EventHandler(this.ToolStripMenuItem_IndicatorsCommonIn_Click);
            // 
            // mAToolStripMenuItem
            // 
            this.mAToolStripMenuItem.Name = "mAToolStripMenuItem";
            this.mAToolStripMenuItem.Size = new System.Drawing.Size(99, 22);
            this.mAToolStripMenuItem.Text = "MA";
            this.mAToolStripMenuItem.Click += new System.EventHandler(this.ToolStripMenuItem_IndicatorsCommonIn_Click);
            // 
            // ToolStripMenuItem_Custems
            // 
            this.ToolStripMenuItem_Custems.Name = "ToolStripMenuItem_Custems";
            this.ToolStripMenuItem_Custems.Size = new System.Drawing.Size(148, 22);
            this.ToolStripMenuItem_Custems.Text = "交易常用指标";
            this.ToolStripMenuItem_Custems.Click += new System.EventHandler(this.ToolStripMenuItem_CustemsClick);
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
            // toolStripButton_Day
            // 
            this.toolStripButton_Day.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton_Day.Image = global::AITrader.Properties.Resources.icons8_plus_1_day_482;
            this.toolStripButton_Day.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_Day.Name = "toolStripButton_Day";
            this.toolStripButton_Day.Size = new System.Drawing.Size(28, 28);
            this.toolStripButton_Day.Text = "toolStripButton6";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 31);
            // 
            // toolStripButton_ZoomLarge
            // 
            this.toolStripButton_ZoomLarge.Image = global::AITrader.Properties.Resources.icons8_expand_481;
            this.toolStripButton_ZoomLarge.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_ZoomLarge.Name = "toolStripButton_ZoomLarge";
            this.toolStripButton_ZoomLarge.Size = new System.Drawing.Size(60, 28);
            this.toolStripButton_ZoomLarge.Text = "放大";
            this.toolStripButton_ZoomLarge.Click += new System.EventHandler(this.toolStripButton_ZoomLargeClick);
            // 
            // toolStripButton_ZoomSmall
            // 
            this.toolStripButton_ZoomSmall.Image = global::AITrader.Properties.Resources.icons8_collapse_481;
            this.toolStripButton_ZoomSmall.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_ZoomSmall.Name = "toolStripButton_ZoomSmall";
            this.toolStripButton_ZoomSmall.Size = new System.Drawing.Size(60, 28);
            this.toolStripButton_ZoomSmall.Text = "缩小";
            this.toolStripButton_ZoomSmall.Click += new System.EventHandler(this.toolStripButton_ZoomSmallClick);
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
            this.ToolStripMenuItem_CandleKLine.Click += new System.EventHandler(this.ToolStripMenuItem_CandleKLineClick);
            // 
            // ToolStripMenuItem_Renko
            // 
            this.ToolStripMenuItem_Renko.Name = "ToolStripMenuItem_Renko";
            this.ToolStripMenuItem_Renko.Size = new System.Drawing.Size(112, 22);
            this.ToolStripMenuItem_Renko.Text = "转型图";
            this.ToolStripMenuItem_Renko.Click += new System.EventHandler(this.ToolStripMenuItem_RenkoClick);
            // 
            // ToolStripMenuItem_StockKline
            // 
            this.ToolStripMenuItem_StockKline.Name = "ToolStripMenuItem_StockKline";
            this.ToolStripMenuItem_StockKline.Size = new System.Drawing.Size(112, 22);
            this.ToolStripMenuItem_StockKline.Text = "宝塔线";
            this.ToolStripMenuItem_StockKline.Click += new System.EventHandler(this.ToolStripMenuItem_StockKlineClick);
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
            this.ToolStripMenuItem_BlackGround.Click += new System.EventHandler(this.ToolStripMenuItem_BlackGroundClick);
            // 
            // ToolStripMenuItem_WhiteGround
            // 
            this.ToolStripMenuItem_WhiteGround.Name = "ToolStripMenuItem_WhiteGround";
            this.ToolStripMenuItem_WhiteGround.Size = new System.Drawing.Size(124, 22);
            this.ToolStripMenuItem_WhiteGround.Text = "白色背景";
            this.ToolStripMenuItem_WhiteGround.Click += new System.EventHandler(this.ToolStripMenuItem_WhiteGroundClick);
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
            this.ToolStripMenuItem_Log.Click += new System.EventHandler(this.ToolStripMenuItem_LogClick);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 31);
            // 
            // dateTimePicker_Begin
            // 
            this.dateTimePicker_Begin.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dateTimePicker_Begin.Location = new System.Drawing.Point(3, 3);
            this.dateTimePicker_Begin.Name = "dateTimePicker_Begin";
            this.dateTimePicker_Begin.Size = new System.Drawing.Size(794, 21);
            this.dateTimePicker_Begin.TabIndex = 5;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.chart1);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(794, 387);
            this.panel1.TabIndex = 6;
            // 
            // chart1
            // 
            chartArea1.AlignmentOrientation = ((System.Windows.Forms.DataVisualization.Charting.AreaAlignmentOrientations)((System.Windows.Forms.DataVisualization.Charting.AreaAlignmentOrientations.Vertical | System.Windows.Forms.DataVisualization.Charting.AreaAlignmentOrientations.Horizontal)));
            chartArea1.AxisX.IntervalAutoMode = System.Windows.Forms.DataVisualization.Charting.IntervalAutoMode.VariableCount;
            chartArea1.AxisX.IsStartedFromZero = false;
            chartArea1.AxisX.LabelStyle.Format = "HH:mm";
            chartArea1.AxisX.LabelStyle.Interval = 0D;
            chartArea1.AxisX.LabelStyle.IntervalType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Number;
            chartArea1.AxisX.MajorGrid.LineColor = System.Drawing.Color.DimGray;
            chartArea1.AxisX.MajorGrid.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dot;
            chartArea1.AxisX.MajorTickMark.Enabled = false;
            chartArea1.AxisX.MajorTickMark.Interval = 0D;
            chartArea1.AxisX.MajorTickMark.IntervalType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Number;
            chartArea1.AxisX.ScrollBar.ButtonStyle = System.Windows.Forms.DataVisualization.Charting.ScrollBarButtonStyles.SmallScroll;
            chartArea1.AxisY.IntervalAutoMode = System.Windows.Forms.DataVisualization.Charting.IntervalAutoMode.VariableCount;
            chartArea1.AxisY.IntervalType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Number;
            chartArea1.AxisY.IsInterlaced = true;
            chartArea1.AxisY.IsStartedFromZero = false;
            chartArea1.AxisY.MajorGrid.LineColor = System.Drawing.Color.DimGray;
            chartArea1.AxisY.MajorGrid.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dash;
            chartArea1.AxisY.MajorTickMark.Enabled = false;
            chartArea1.AxisY.ScrollBar.Enabled = false;
            chartArea1.BackColor = System.Drawing.Color.White;
            chartArea1.BorderColor = System.Drawing.Color.Maroon;
            chartArea1.BorderDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid;
            chartArea1.IsSameFontSizeForAllAxes = true;
            chartArea1.Name = "ChartArea1";
            chartArea1.Position.Auto = false;
            chartArea1.Position.Height = 99F;
            chartArea1.Position.Width = 99F;
            chartArea1.Position.X = 1F;
            chartArea1.Position.Y = 1F;
            chartArea1.ShadowColor = System.Drawing.Color.White;
            this.chart1.ChartAreas.Add(chartArea1);
            this.chart1.ContextMenuStrip = this.contextMenuStrip1;
            this.chart1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chart1.Location = new System.Drawing.Point(176, 0);
            this.chart1.Margin = new System.Windows.Forms.Padding(0);
            this.chart1.Name = "chart1";
            this.chart1.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.None;
            series1.BorderColor = System.Drawing.Color.DimGray;
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Candlestick;
            series1.Color = System.Drawing.Color.SeaGreen;
            series1.CustomProperties = "PriceDownColor=SeaGreen, PriceUpColor=Maroon";
            series1.IsXValueIndexed = true;
            series1.Name = "Series1";
            series1.Points.Add(dataPoint1);
            series1.Points.Add(dataPoint2);
            series1.Points.Add(dataPoint3);
            series1.Points.Add(dataPoint4);
            series1.Points.Add(dataPoint5);
            series1.Points.Add(dataPoint6);
            series1.Points.Add(dataPoint7);
            series1.Points.Add(dataPoint8);
            series1.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.DateTime;
            series1.YValuesPerPoint = 4;
            series1.YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Double;
            this.chart1.Series.Add(series1);
            this.chart1.Size = new System.Drawing.Size(618, 387);
            this.chart1.TabIndex = 4;
            this.chart1.Text = "chart1";
            this.chart1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Chart_MouseMove);
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
            this.ToolStripMenuItem_VisualIndocator.Click += new System.EventHandler(this.ToolStripMenuItem_VisualIndocatorClick);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.richTextBox_StrategyLog);
            this.panel2.Controls.Add(this.richTextBox_ChartAndIndicatorsLog);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(176, 387);
            this.panel2.TabIndex = 5;
            this.panel2.Visible = false;
            // 
            // richTextBox_StrategyLog
            // 
            this.richTextBox_StrategyLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBox_StrategyLog.Location = new System.Drawing.Point(0, 199);
            this.richTextBox_StrategyLog.Name = "richTextBox_StrategyLog";
            this.richTextBox_StrategyLog.Size = new System.Drawing.Size(176, 188);
            this.richTextBox_StrategyLog.TabIndex = 1;
            this.richTextBox_StrategyLog.Text = ">>策略日志开启:";
            this.richTextBox_StrategyLog.TextChanged += new System.EventHandler(this.RichBoxStrategy_TextChanged);
            // 
            // richTextBox_ChartAndIndicatorsLog
            // 
            this.richTextBox_ChartAndIndicatorsLog.Dock = System.Windows.Forms.DockStyle.Top;
            this.richTextBox_ChartAndIndicatorsLog.Location = new System.Drawing.Point(0, 0);
            this.richTextBox_ChartAndIndicatorsLog.Name = "richTextBox_ChartAndIndicatorsLog";
            this.richTextBox_ChartAndIndicatorsLog.Size = new System.Drawing.Size(176, 199);
            this.richTextBox_ChartAndIndicatorsLog.TabIndex = 0;
            this.richTextBox_ChartAndIndicatorsLog.Text = "";
            this.richTextBox_ChartAndIndicatorsLog.TextChanged += new System.EventHandler(this.RichBox_TextChanged);
            // 
            // timer_NotifyPosition
            // 
            this.timer_NotifyPosition.Enabled = true;
            this.timer_NotifyPosition.Interval = 3000;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.panel1);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(3, 29);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(794, 387);
            this.panel4.TabIndex = 8;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 800F));
            this.tableLayoutPanel1.Controls.Add(this.panel4, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.dateTimePicker_Begin, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 31);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(800, 419);
            this.tableLayoutPanel1.TabIndex = 9;
            // 
            // KLineFormWholeTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.toolStrip1);
            this.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Name = "KLineFormWholeTest";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "BTC永续合约 -K线图1.0 1Min Bar -AutoTrader";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form_Closing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form_Closed);
            this.Load += new System.EventHandler(this.Form_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
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
        private System.Windows.Forms.ToolStripButton toolStripButton_Day;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton toolStripButton_ZoomLarge;
        private System.Windows.Forms.ToolStripButton toolStripButton_ZoomSmall;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton2;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem_CandleKLine;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem_Renko;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem_StockKline;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton3;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem_BlackGround;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem_WhiteGround;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.DateTimePicker dateTimePicker_Begin;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.RichTextBox richTextBox_ChartAndIndicatorsLog;
        private System.Windows.Forms.ToolStripButton ToolStripMenuItem_Log;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.Timer timer_NotifyPosition;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem_IndicatorsCommonIn;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.RichTextBox richTextBox_StrategyLog;
        private System.Windows.Forms.ToolStripMenuItem mAToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem_VisualIndocator;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem_Custems;
    }
}