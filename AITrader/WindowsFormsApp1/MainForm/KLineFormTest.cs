using APIConnect;
using Common;
using Strategy;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using WeifenLuo.WinFormsUI.Docking;
using swap = OKExSDK.Models.Swap;


namespace WindowsFormsApp1
{
    public partial class KLineFormTest : DockContent
    {
        private object m_Strategy = null;

        private string m_Frame = string.Empty;
        private string m_formName = string.Empty;
        private swap.Ticker m_InitInsTicker = null;

        //在这里Load-strategy.dll然后遍历里面所有策略
        //private IStrategy m_Strategy = null;

        private List<decimal> m_o = new List<decimal>();
        private List<decimal> m_h = new List<decimal>();
        private List<decimal> m_l = new List<decimal>();
        private List<decimal> m_c = new List<decimal>();
        private List<DateTime> m_d = new List<DateTime>();
        private static Mutex m_mut = new Mutex();

        public delegate void DeleteKLineFormHandle(swap.Ticker t);
        public event DeleteKLineFormHandle DeleteKLineFormEvent;
        public KLineFormTest(swap.Ticker t)
        {
            InitializeComponent();

            //订阅实时行情RealMarketData
            ConnectManager.CreateInstance().CONNECTION.AnsyKLineEvent += AnsyKLineSubEvent;
            ConnectManager.CreateInstance().CONNECTION.AnsyRealDataEvent += AnsyTickerSubEvent;

            //按照指定的时间订阅拉取历史K线数据，展示
            //默认设置为前一个月
            this.dateTimePicker_Begin.Value = DateTime.Now.AddDays(-30);

            m_InitInsTicker = t;
            m_formName = t.instrument_id;

            this.Text = string.Format("{0}永续合约 -K线图1.0 Bar -AutoTrader", t.instrument_id);

            AppendText("图表启动成功...");
            AppendText("交易合约为:" + m_InitInsTicker);
        }

        public String FORMNAME
        {
            get
            {
                return this.m_formName;
            }
        }

        //public IStrategy FORMSTRATEGY
        //{
        //    get
        //    {
        //        return m_Strategy;
        //    }
        //}

        //private void SetStrategy(IStrategy s)
        //{
        //    m_Strategy = s;
        //}

        /// <summary>
        /// 返回历史查询的K线
        /// </summary>
        /// <param name="args"></param>
        private void AnsyKLineSubEvent(AIEventArgs args)
        {
            m_mut.WaitOne();

            if (args.ReponseMessage == RESONSEMESSAGE.HOLDKLINE_FAILED) return;
            List<TestData.KlineOkex> klineLiet = (List<TestData.KlineOkex>)args.EventData;
            if (klineLiet == null) return;
            if (klineLiet.Count <= 0) return;
            if (klineLiet[0].insment != m_InitInsTicker.instrument_id) return;

            try
            {
                //清空
                this.chart1.Series[0].Points.Clear();
                m_d.Clear();
                m_o.Clear();
                m_h.Clear();
                m_l.Clear();
                m_c.Clear();

                //在这里list倒序处理，因为最新的价格在最前面在图表的最右边
                klineLiet.Reverse(); //关键是这句

                int kCout = klineLiet.Count;

                for (int j = 0; j < kCout; ++j)
                {
                    m_d.Add(klineLiet[j].d);
                    m_o.Add(klineLiet[j].o);
                    m_h.Add(klineLiet[j].h);
                    m_l.Add(klineLiet[j].l);
                    m_c.Add(klineLiet[j].c);
                }

                //调整显示K线
                this.chart1.ChartAreas[0].AxisX.ScaleView.ZoomReset();
                Zoom(this.chart1);

                //图表K线和Anotion-Clear()--数据回来的根据接口猜测，应该是d,o,h,l,c四个量足以
                this.chart1.Series[0].Points.Clear();
                this.chart1.Annotations.Clear();

                for (int i = 0; i < kCout; i++)
                {
                    this.chart1.Series[0].Points.AddXY(m_d[i], m_h[i], m_l[i], m_o[i], m_c[i]);
                }

                m_mut.ReleaseMutex();

            }
            catch (Exception ex)
            {
                MessageBox.Show("查询K线返回异常:" + ex.Message);
                return;
            }

        }

        /// <summary>
        /// 返回实时的行情数据--Kxian是合成，砖图自动，但在这里处理方式是一致的
        /// </summary>
        /// <param name="args"></param>
        private void AnsyTickerSubEvent(AIEventArgs args)
        {
            m_mut.WaitOne();

            if (this.InvokeRequired)
            {
                this.BeginInvoke(new Action<AIEventArgs>(AnsyTickerSubEvent), args);
                return;
            }

            if (args.ReponseMessage == RESONSEMESSAGE.HOLDMARKETDATA_FAILED) return;
            //合成目前图表上的周期K线，或者每隔一段时间查一次直接装载K线
            List<swap.Ticker> ticLiet = (List<swap.Ticker>)args.EventData;
            if (ticLiet == null) return;
            if (ticLiet.Count <= 0 || ticLiet[0].instrument_id == "") return;

            foreach (swap.Ticker t in ticLiet)
            {
                if (t.instrument_id != m_InitInsTicker.instrument_id) continue;

                TestData.Kline k = new TestData.Kline()
                {
                    d = t.timestamp,
                    o = t.last,
                    h = t.last,
                    l = t.last,
                    c = t.last
                };

                this.chart1.Series[0].Points.AddXY(k.d, k.o, k.h, k.l, k.c);

                AppendText(k.ToString());
            }
            m_mut.ReleaseMutex();

        }

        #region
        /// <summary>
        /// 缩放
        /// </summary>
        public void Zoom(Chart chart)
        {
            if (chart.Series[0].Points.Count > 200)
            {
                chart.ChartAreas[0].AxisX.ScaleView.Zoom(chart.Series[0].Points.Count - 150, chart.Series[0].Points.Count);
                ResetAxisY(chart);
            }
            else
            {
                chart.ChartAreas[0].AxisX.ScaleView.ZoomReset();
                chart.ChartAreas[0].AxisY.ScaleView.ZoomReset();
            }
        }

        /// <summary>
        /// 放大
        /// </summary>
        public void ZoomOut(Chart chart)
        {
            if (!chart.ChartAreas[0].AxisX.ScaleView.IsZoomed)
                Zoom(chart);

            Series sCur = chart.Series[0];
            int left = (int)chart.ChartAreas[0].AxisX.ScaleView.ViewMinimum;
            int right = (int)chart.ChartAreas[0].AxisX.ScaleView.ViewMaximum;
            if (right - left > 20)
            {
                chart.ChartAreas[0].AxisX.ScaleView.Zoom(left + (right - left) / 3, right);
                ResetAxisY(chart);
            }
        }

        /// <summary>
        /// 缩小
        /// </summary>
        public void ZoomIn(Chart chart)
        {
            if (chart.ChartAreas[0].AxisX.ScaleView.IsZoomed)
            {
                Series sCur = chart.Series[0];
                int left = (int)chart.ChartAreas[0].AxisX.ScaleView.ViewMinimum;
                int right = (int)chart.ChartAreas[0].AxisX.ScaleView.ViewMaximum;
                if (left <= 1 && right >= sCur.Points.Count)
                {
                    chart.ChartAreas[0].AxisX.ScaleView.ZoomReset();
                    chart.ChartAreas[0].AxisY.ScaleView.ZoomReset();
                }
                else
                {
                    if (left == 0)
                        chart.ChartAreas[0].AxisX.ScaleView.Zoom(left, right + (right - left) / 3);
                    else
                        chart.ChartAreas[0].AxisX.ScaleView.Zoom(left - (right - left) / 3, right);
                    ResetAxisY(chart);
                }
            }
        }

        /// <summary>
        /// 设置显示区大小
        /// </summary>
        public void ResetChartArea(Chart chart)
        {
            for (int i = 1; i < chart.ChartAreas.Count; i++)
            {
                bool needShow = chart.Series.Count(n => n.ChartArea == chart.ChartAreas[i].Name) > 0;
                if (needShow && !chart.ChartAreas[i].Visible)
                {
                    chart.ChartAreas[0].Position.Height -= 23;
                    for (int j = 1; j < i; j++)
                    {
                        if (chart.ChartAreas[j].Visible)
                            chart.ChartAreas[j].Position.Y -= 25;
                    }
                    chart.ChartAreas[i].Position.Y = 75;
                    chart.ChartAreas[i].AxisX.Interval = chart.ChartAreas[0].AxisX.Interval;
                    chart.ChartAreas[i].AxisX.IntervalType = chart.ChartAreas[0].AxisX.IntervalType;
                    chart.ChartAreas[i].Visible = true;
                    chart.ChartAreas[i].AxisX.ScaleView.Zoom(chart.ChartAreas[0].AxisX.ScaleView.ViewMinimum, chart.ChartAreas[0].AxisX.ScaleView.ViewMaximum);
                }
                else if (!needShow && chart.ChartAreas[i].Visible)
                {
                    chart.ChartAreas[i].Visible = false;
                    chart.ChartAreas[0].Position.Height += 23;
                    for (int j = 1; j < i; j++)
                    {
                        if (chart.ChartAreas[j].Visible)
                            chart.ChartAreas[j].Position.Y += 25;
                    }
                }
            }
            //重新调整副图高度适应
            ResetAxisY(chart);
        }

        public void ResetAxisY(Chart chart)
        {
            if (chart.ChartAreas[0].AxisX.ScaleView.IsZoomed)
            {
                Series sCur = chart.Series[0];
                int left = Math.Max(0, (int)chart.ChartAreas[0].AxisX.ScaleView.ViewMinimum);
                int right = Math.Min(sCur.Points.Count - 1, (int)chart.ChartAreas[0].AxisX.ScaleView.ViewMaximum);

                double viewTop = double.MinValue, viewButtom = double.MaxValue;

                ////调整纵坐标
                //for (int i = left; i <= right; i++)
                //{
                //    viewTop = Math.Max(viewTop, chart.Series[0].Points[i].YValues[0]);
                //    viewButtom = Math.Min(viewButtom, chart.Series[0].Points[i].YValues[chart.Series[0].YValuesPerPoint > 1 ? 1 : 0]);
                //}
                ////viewTop += 10 * YValueTick;
                ////viewButtom -= 10 * YValueTick;
                //viewTop *= 1.01;
                //viewButtom *= 0.99;
                //chart.ChartAreas[0].AxisY.ScaleView.Zoom(viewButtom, viewTop);

                for (int i = 0; i < chart.ChartAreas.Count; i++)
                {
                    viewTop = double.MinValue;
                    viewButtom = double.MaxValue;
                    if (chart.ChartAreas[i].Visible)
                    {
                        foreach (Series s in chart.Series.Where(n => n.ChartArea == chart.ChartAreas[i].Name))
                        {
                            for (int j = left; j <= right; j++)
                            {
                                viewTop = Math.Max(viewTop, s.Points[j].YValues[0]);
                                viewButtom = Math.Min(viewButtom, s.Points[j].YValues[s.YValuesPerPoint > 1 ? 1 : 0]);
                            }
                        }
                        //viewTop += 10 * YValueTick;
                        //viewButtom -= 10 * YValueTick;
                        //viewTop = (Math.Ceiling(viewTop / 100) + 1) * 100;// *= 1.01;
                        //viewButtom = viewButtom / 100 * 100;// *= 0.99;
                        //viewTop = viewTop / chart.YValueTick * chart.YValueTick;
                        //viewButtom = viewButtom / chart.YValueTick * chart.YValueTick;
                        double baseY = Math.Pow(10, Math.Max(0, Math.Ceiling(viewTop).ToString().Length - 3));
                        if (baseY == 1)
                        {
                            viewTop = Math.Ceiling(viewTop);
                            viewButtom = Math.Floor(viewButtom);
                        }
                        else
                        {
                            viewTop = Math.Ceiling(viewTop / baseY) * baseY + baseY;
                            viewButtom = Math.Floor(viewButtom / baseY) * baseY - baseY;
                        }
                        chart.ChartAreas[i].AxisY.ScaleView.Zoom(viewButtom, viewTop);
                    }
                }
            }
        }

        #endregion

        private void toolStripButton_ZoomLargeClick(object sender, EventArgs e)
        {
            ZoomOut(this.chart1);
        }

        private void toolStripButton_ZoomSmallClick(object sender, EventArgs e)
        {
            ZoomIn(this.chart1);
        }

        private void Form_Load(object sender, EventArgs e)
        {
            //拉取历史行情，订阅实时行情
        }

        private void Form_Closed(object sender, FormClosedEventArgs e)
        {

        }


        #region 分钟周期发送请求拉取历史数据Param(合约，时间区间)
        /// <summary>
        /// 获取K线数据
        /// </summary>
        /// "BTC-USD-SWAP", DateTime.UtcNow.AddMinutes(-1), DateTime.UtcNow, 60
        /// </summary>
        /// <param name="instrument_id">合约名称，如BTC-USD-SWAP</param>
        /// <param name="start">开始时间</param>
        /// <param name="end">结束时间</param>
        /// <param name="granularity">时间粒度，以秒为单位，必须为60的倍数</param>
        /// <returns></returns>
        /// <param name="e"></param>
        private void toolStripButton_DayClick(object sender, EventArgs e)
        {
            m_Frame = "日";
            this.Text = string.Format("{0}永续合约 -K线图1.0 日线Bar -AutoTrader", m_InitInsTicker.instrument_id);

            //120根
            DateTime startTime = DateTime.UtcNow.AddDays(-120);
            DateTime endTime = DateTime.UtcNow;

            //填写合约，时间区间获取行情
            ConnectManager.CreateInstance().CONNECTION.AnsyGetKLineSwap(m_InitInsTicker.instrument_id,
                startTime, endTime, 60 * 60 * 24);
        }

        private void toolStripButton_60MinClick(object sender, EventArgs e)
        {
            m_Frame = "60";
            this.Text = string.Format("{0}永续合约 -K线图1.0 60MinBar -AutoTrader", m_InitInsTicker.instrument_id);

            //120根
            DateTime startTime = DateTime.UtcNow.AddHours(-120);
            DateTime endTime = DateTime.UtcNow;

            //填写合约，时间区间获取行情
            ConnectManager.CreateInstance().CONNECTION.AnsyGetKLineSwap(m_InitInsTicker.instrument_id,
                startTime, endTime, 60 * 60);
        }

        private void toolStripButton_30MinClick(object sender, EventArgs e)
        {
            m_Frame = "30";
            this.Text = string.Format("{0}永续合约 -K线图1.0 30MinBar -AutoTrader", m_InitInsTicker.instrument_id);

            //120根
            DateTime startTime = DateTime.UtcNow.AddHours(-60);
            DateTime endTime = DateTime.UtcNow;

            //填写合约，时间区间获取行情
            ConnectManager.CreateInstance().CONNECTION.AnsyGetKLineSwap(m_InitInsTicker.instrument_id,
                startTime, endTime, 60 * 30);
        }

        private void toolStripButton_15MinClick(object sender, EventArgs e)
        {
            m_Frame = "15";
            this.Text = string.Format("{0}永续合约 -K线图1.0 15MinBar -AutoTrader", m_InitInsTicker.instrument_id);

            //120根
            DateTime startTime = DateTime.UtcNow.AddHours(-30);
            DateTime endTime = DateTime.UtcNow;


            //填写合约，时间区间获取行情
            ConnectManager.CreateInstance().CONNECTION.AnsyGetKLineSwap(m_InitInsTicker.instrument_id,
                startTime, endTime, 60 * 15);
        }

        private void toolStripButton_5MinClick(object sender, EventArgs e)
        {
            m_Frame = "5";
            this.Text = string.Format("{0}永续合约 -K线图1.0 5MinBar -AutoTrader", m_InitInsTicker.instrument_id);

            //120根
            DateTime startTime = DateTime.UtcNow.AddHours(-10);
            DateTime endTime = DateTime.UtcNow;


            //填写合约，时间区间获取行情
            ConnectManager.CreateInstance().CONNECTION.AnsyGetKLineSwap(m_InitInsTicker.instrument_id,
                startTime, endTime, 60 * 5);
        }

        private void toolStripLabel_1Min_Click(object sender, EventArgs e)
        {
            m_Frame = "1";
            this.Text = string.Format("{0}永续合约 -K线图1.0 1MinBar -AutoTrader", m_InitInsTicker.instrument_id);

            //120根
            DateTime startTime = DateTime.UtcNow.AddHours(-2);
            DateTime endTime = DateTime.UtcNow;


            //填写合约，时间区间获取行情
            ConnectManager.CreateInstance().CONNECTION.AnsyGetKLineSwap(m_InitInsTicker.instrument_id,
                startTime, endTime, 60);
        }
        #endregion

        private void Form_Closing(object sender, FormClosingEventArgs e)
        {
            if (DeleteKLineFormEvent != null && DeleteKLineFormEvent.Method != null)
            {
                DeleteKLineFormEvent(m_InitInsTicker);
            }
        }

        private bool m_isLog = true;
        private void ToolStripMenuItem_LogClick(object sender, EventArgs e)
        {
            if (m_isLog)
            {
                this.panel2.Visible = true;
                m_isLog = false;
            }
            else
            {
                this.panel2.Visible = false;
                m_isLog = true;
            }
        }

        /// <summary>
        /// 策略日志
        /// </summary>
        /// <param name="str"></param>
        private void AppendText(string str)
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke(new Action<string>(AppendText), str);
            }

            this.richTextBox_StrategyLog.AppendText("\n" + DateTime.Now.ToString() + ":" + "\n" + str);
        }

        /// <summary>
        /// 切换Renko转型图
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToolStripMenuItem_RenkoClick(object sender, EventArgs e)
        {
            RenkoSettingsForm renkoForm = new RenkoSettingsForm();
            renkoForm.ShowDialog();
            if(renkoForm.RenkoDialogResult == false)
            {
                return;
            }
            {
                //清空
                this.chart1.Series[0].Points.Clear();
                m_d.Clear();
                m_o.Clear();
                m_h.Clear();
                m_l.Clear();
                m_c.Clear();

                double boxsize = renkoForm.BoxSize;
                this.chart1.Series[0].ChartType = SeriesChartType.Renko;
                this.chart1.Series[0]["BoxSize"] = boxsize.ToString();

                m_Frame = "Tick";
                this.Text = string.Format("{0}永续合约 -K线图1.0 砖型图Bar -AutoTrader", m_InitInsTicker.instrument_id);

            }
        }

        private void ToolStripMenuItem_CandleKLineClick(object sender, EventArgs e)
        {
            this.chart1.Series[0].ChartType = SeriesChartType.Candlestick;
        }

        private void ToolStripMenuItem_StockKlineClick(object sender, EventArgs e)
        {
            this.chart1.Series[0].ChartType = SeriesChartType.Stock;
        }

        private void ToolStripMenuItem_BlackGroundClick(object sender, EventArgs e)
        {
            this.chart1.ChartAreas[0].BackColor = Color.Black;
        }

        private void ToolStripMenuItem_WhiteGroundClick(object sender, EventArgs e)
        {
            this.chart1.ChartAreas[0].BackColor = Color.White;
        }

        /// <summary>
        /// 策略属性设置
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToolStripMenuItem_StrategySettingsClick(object sender, EventArgs e)
        {
            StrategySettingsForm s = new StrategySettingsForm(m_InitInsTicker,m_Frame);
            s.ShowDialog();

            if(s.STRATEGY != null)
            {
                object strategy = s.STRATEGY;
                m_Strategy = strategy;
            }
        }

        #region 策略事件通知
        private void OnStrategyTickSubEvent(swap.Ticker t,string strategyName)
        {
            AppendText(string.Format("我是策略:{0},正在执行/策略当前最新价:{1}/策略当前合约:{2}",strategyName,t.last,t.instrument_id));
        }

        private void OnStrategyOrderSubEvent(SwapOrderReturn orderReturn, string StrategyName)
        {
            AppendText(string.Format("我是策略:{0},策略正在下单并收到订单返回/策略当前合约:{1}", StrategyName, orderReturn.instrument));
        }
        #endregion

        /// <summary>
        /// 自动交易执行
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToolStripMenuItem_StrategyAutoActionClick(object sender, EventArgs e)
        {
            //if(m_Strategy == null)
            //{
            //    MessageBox.Show("请通过策略属性先指定策略再开启...");
            //    return;
            //}

            LawNotifyForm n = new LawNotifyForm();
            n.ShowDialog();

            PositionCompareForm f = new PositionCompareForm();
            f.ShowDialog();

            //订阅策略事件-在这里Form类完成触发和订阅-启动
            if(m_Strategy != null)
            {
                ((IStrategy)m_Strategy).OnTickEvent += OnStrategyTickSubEvent;
                ((IStrategy)m_Strategy).OnOrderEvent += OnStrategyOrderSubEvent;

                ((IStrategy)m_Strategy).Start();

                this.toolStripButton_StartStrategy.Image = global::WindowsFormsApp1.Properties.Resources._6b41346d30a6d19b7fdfc283add2871;
            }
            else
            {
                MessageBox.Show("请先设置策略属性..");
            }
  
        }

    }
}
