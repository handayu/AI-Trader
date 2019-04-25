﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using WeifenLuo.WinFormsUI.Docking;
using swap = OKExSDK.Models.Swap;


namespace WindowsFormsApp1
{
    public partial class KLineFormTest : DockContent
    {
        private string m_formName = string.Empty;
        private swap.Ticker m_InitInsTicker = null;

        private List<decimal> m_o = new List<decimal>();
        private List<decimal> m_h = new List<decimal>();
        private List<decimal> m_l = new List<decimal>();
        private List<decimal> m_c = new List<decimal>();
        private List<DateTime> m_d = new List<DateTime>();

        public delegate void  DeleteKLineFormHandle(swap.Ticker t);
        public event DeleteKLineFormHandle DeleteKLineFormEvent;

        public KLineFormTest(swap.Ticker t)
        {
            InitializeComponent();

            //订阅实时行情RealMarketData
            ConnectManager.CreateInstance().CONNECTION.AnsyKLineEvent += AnsyKLineSubEvent;
            ConnectManager.CreateInstance().CONNECTION.AnsyTickerEvent += AnsyTickerSubEvent;

            //按照指定的时间订阅拉取历史K线数据，展示

            //加载策略到ComBox

            m_InitInsTicker = t;
            m_formName = t.instrument_id;

            this.Text = string.Format("{0}永续合约 -K线图1.0 Bar -AutoTrader", t.instrument_id);
        }

        public String FORMNAME
        {
            get
            {
                return this.m_formName;
            }
        }

        /// <summary>
        /// 返回历史查询的K线
        /// </summary>
        /// <param name="args"></param>
        private void AnsyKLineSubEvent(AIEventArgs args)
        {
            try
            {
                List<TestData.Kline> klineLiet = (List<TestData.Kline>)args.EventData;
                if (klineLiet == null) return;
                if (klineLiet.Count <= 0) return;

                if (args.ReponseMessage == RESONSEMESSAGE.HOLDKLINE_SUCCESS)
                {
                    int kCout = klineLiet.Count;

                    for (int j = 0; j < kCout; ++j)
                    {
                        m_d.Add(klineLiet[j].d);
                        m_o.Add(klineLiet[j].o);
                        m_h.Add(klineLiet[j].h);
                        m_l.Add(klineLiet[j].l);
                        m_c.Add(klineLiet[j].c);
                    }

                    //for (int j = 0; j < kCout; j++)
                    //{
                    //    if (j == 0 || (j < kCout - 1 && klineLiet[j].d != klineLiet[j + 1].d))
                    //        this.chart1.Series[0].Points[j].AxisLabel = d[j].ToString("MM/dd");
                    //    else
                    //        this.chart1.Series[0].Points[j].AxisLabel = d[j].ToString("HH:mm");
                    //}

                    //Y轴显示的小数位数
                    //var fmt = "F" + (_stra.InstrumentInfo.PriceTick >= 1 ? 0 : _stra.InstrumentInfo.PriceTick.ToString().Split('.')[1].Length - 1);
                    //var interval = 10 * _stra.InstrumentInfo.PriceTick; //最小跳动
                    //SetLoadParams(this.chart1, this.chart1.ChartAreas[0], fmt, interval, cnt + 1);
                    //foreach (ChartArea area in this.chart1.ChartAreas)
                    //area.AxisY.LabelStyle.Format = "F" + (_stra.InstrumentInfo.PriceTick >= 1 ? 0 : _stra.InstrumentInfo.PriceTick.ToString().Split('.')[1].Length - 1);
                    //this.chart1.ChartAreas[0].AxisY.Interval = 100 * _stra.InstrumentInfo.PriceTick; //最小跳动

                    //调整显示K线
                    this.chart1.ChartAreas[0].AxisX.ScaleView.ZoomReset();
                    Zoom(this.chart1);

                    //图表K线和Anotion-Clear()--数据回来的根据接口猜测，应该是d,o,h,l,c四个量足以
                    this.chart1.Series[0].Points.Clear();
                    this.chart1.Annotations.Clear();

                    for(int i = 0;i<kCout;i++)
                    {
                        this.chart1.Series[0].Points.AddXY(m_d[i], m_h[i], m_l[i], m_o[i], m_c[i]);
                    }

                    //装载查询回来的历史K线
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("查询K线返回异常:" + ex.Message);
                return;
            }
        }

        /// <summary>
        /// 返回实时的行情数据
        /// </summary>
        /// <param name="args"></param>
        private void AnsyTickerSubEvent(AIEventArgs args)
        {
            if (args.ReponseMessage == RESONSEMESSAGE.HOLDMARKETDATA_SUCCESS)
            {
                //合成目前图表上的周期K线，或者每隔一段时间查一次直接装载K线
                List<swap.Ticker> ticLiet = (List<swap.Ticker>)args.EventData;
                if (ticLiet == null) return;
                if (ticLiet.Count <= 0 || ticLiet[0].instrument_id == "") return;
                foreach(swap.Ticker t in ticLiet)
                {
                    if (t.instrument_id != m_InitInsTicker.instrument_id) continue;

                    TestData.Kline k = new TestData.Kline()
                    {
                        d= t.timestamp,
                        o = t.last,
                        h = t.last,
                        l = t.last,
                        c = t.last
                    };

                    double kLast = this.chart1.Series[0].Points[this.chart1.Series[0].Points.Count - 1].XValue;
                    this.chart1.Series[0].Points.AddXY(kLast + 1, k.o,k.h,k.l,k.c);
                }
            }
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
            //填写合约，时间区间获取行情
            ConnectManager.CreateInstance().CONNECTION.AnsyGetKLineSwap(m_InitInsTicker.instrument_id,
                this.dateTimePicker_Begin.Value, DateTime.Today, 60 * 60 * 24);
        }

        private void toolStripButton_60MinClick(object sender, EventArgs e)
        {
            //填写合约，时间区间获取行情
            ConnectManager.CreateInstance().CONNECTION.AnsyGetKLineSwap(m_InitInsTicker.instrument_id,
                this.dateTimePicker_Begin.Value, DateTime.Today, 60 * 60);
        }

        private void toolStripButton_30MinClick(object sender, EventArgs e)
        {
            //填写合约，时间区间获取行情
            ConnectManager.CreateInstance().CONNECTION.AnsyGetKLineSwap(m_InitInsTicker.instrument_id,
                this.dateTimePicker_Begin.Value, DateTime.Today, 60 * 30);
        }

        private void toolStripButton_15MinClick(object sender, EventArgs e)
        {
            //填写合约，时间区间获取行情
            ConnectManager.CreateInstance().CONNECTION.AnsyGetKLineSwap(m_InitInsTicker.instrument_id,
                this.dateTimePicker_Begin.Value, DateTime.Today, 60 * 15);
        }

        private void toolStripButton_5MinClick(object sender, EventArgs e)
        {
            //填写合约，时间区间获取行情
            ConnectManager.CreateInstance().CONNECTION.AnsyGetKLineSwap(m_InitInsTicker.instrument_id,
                this.dateTimePicker_Begin.Value, DateTime.Today, 60 * 5);
        }

        private void toolStripLabel_1Min_Click(object sender, EventArgs e)
        {
            //填写合约，时间区间获取行情
            ConnectManager.CreateInstance().CONNECTION.AnsyGetKLineSwap(m_InitInsTicker.instrument_id,
                this.dateTimePicker_Begin.Value, DateTime.Today, 60);
        }
        #endregion

        private void Form_Closing(object sender, FormClosingEventArgs e)
        {
            if (DeleteKLineFormEvent != null && DeleteKLineFormEvent.Method != null)
            {
                DeleteKLineFormEvent(m_InitInsTicker);
            }
        }
    }
}
