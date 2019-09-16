using APIConnect;
using Common;
using Indicators;
using Strategy;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using TALibraryInCSharp;
using WeifenLuo.WinFormsUI.Docking;
using swap = OKExSDK.Models.Swap;


namespace WindowsFormsApp1
{
    public partial class KLineFormWholeTest : DockContent
    {
        /// <summary>
        /// 包含一个或者一组指标
        /// </summary>
        private object m_indicator = null;

        /// <summary>
        /// 当前图表上包含的所有K线数据缓存
        /// </summary>
        private List<decimal> m_o = new List<decimal>();
        private List<decimal> m_h = new List<decimal>();
        private List<decimal> m_l = new List<decimal>();
        private List<decimal> m_c = new List<decimal>();
        private List<DateTime> m_d = new List<DateTime>();

        public KLineFormWholeTest()
        {
            InitializeComponent();

            //chart的滚动条始终在最右边
            this.chart1.ChartAreas[0].AxisX.ScaleView.Scroll(ScrollType.Last);

            AppendText("图表启动成功...");
        }

        /// <summary>
        /// 返回历史查询的K线
        /// </summary>
        /// <param name="args"></param>
        private void AnsyKLineSubEvent(AIEventArgs args)
        {
            List<TestData.KlineOkex> klineLiet = new List<TestData.KlineOkex>();

            List<TestData.KlineOkex> klinetemp = (List<TestData.KlineOkex>)(args.Clone()).EventData;

            foreach (TestData.KlineOkex data in klinetemp)
            {
                TestData.KlineOkex d = new TestData.KlineOkex()
                {
                    insment = data.insment,
                    d = data.d,
                    o = data.o,
                    h = data.h,
                    l = data.l,
                    c = data.c,
                    unkonwn1 = data.unkonwn1,
                    unkonwn2 = data.unkonwn2
                };

                klineLiet.Add(data);
            }

            if (klineLiet.Count <= 0) return;

            try
            {
                //清空
                this.chart1.Series[0].Points.Clear();
                this.chart1.Annotations.Clear();

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

                AddHistoryBar(klineLiet);

            }
            catch (Exception ex)
            {
                MessageBox.Show("查询K线返回异常:" + ex.Message);
                return;
            }
        }

        /// <summary>
        /// 添加历史K线
        /// </summary>
        /// <param name="klineLiet"></param>
        private void AddHistoryBar(List<TestData.KlineOkex> klineLiet)
        {
            for (int i = 0; i < klineLiet.Count; i++)
            {
                this.chart1.Series[0].Points.AddXY(m_d[i], m_h[i], m_l[i], m_o[i], m_c[i]);
            }
        }

        /// <summary>
        /// 返回实时的行情数据--只更新最后一笔tick最新的-闪烁
        /// </summary>
        /// <param name="args"></param>
        private void AnsyTickerSubEvent(AIEventArgs args)
        {
            try
            {
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

                Debug.WriteLine(string.Format("我是实时Tick:{0}:{0}", ticLiet[0].instrument_id, ticLiet[0].last));


                foreach (swap.Ticker t in ticLiet)
                {
                    TestData.Kline k = new TestData.Kline()
                    {
                        d = t.timestamp,
                        o = t.last,
                        h = t.last,
                        l = t.last,
                        c = t.last
                    };

                    //永远是更新最后一笔，只更新最后一笔闪烁的，其余的分钟K和其他图形，通过专有的BarMaker接口推送过来添加；
                    if (this.chart1.Series[0].Points.Count >= 1)
                    {
                        //[Hanyu]这里多删除了一个Bar----需要修正---如果前一笔是tick线(在这里怎么判断？目前暂时用ohlc都一样)
                        if ((this.chart1.Series[0].Points[this.chart1.Series[0].Points.Count - 1].YValues[0] ==
                            this.chart1.Series[0].Points[this.chart1.Series[0].Points.Count - 1].YValues[1] &&
                            this.chart1.Series[0].Points[this.chart1.Series[0].Points.Count - 1].YValues[1] ==
                            this.chart1.Series[0].Points[this.chart1.Series[0].Points.Count - 1].YValues[2] &&
                            this.chart1.Series[0].Points[this.chart1.Series[0].Points.Count - 1].YValues[2] ==
                            this.chart1.Series[0].Points[this.chart1.Series[0].Points.Count - 1].YValues[3]))
                        {
                            this.chart1.Series[0].Points.RemoveAt(this.chart1.Series[0].Points.Count - 1);
                            this.chart1.Series[0].Points.AddXY(k.d, k.o, k.h, k.l, k.c);

                        }

                        if (this.chart1.Series[0].Points[this.chart1.Series[0].Points.Count - 2].YValues[0] ==
                          this.chart1.Series[0].Points[this.chart1.Series[0].Points.Count - 2].YValues[1] &&
                          this.chart1.Series[0].Points[this.chart1.Series[0].Points.Count - 2].YValues[1] ==
                          this.chart1.Series[0].Points[this.chart1.Series[0].Points.Count - 2].YValues[2] &&
                          this.chart1.Series[0].Points[this.chart1.Series[0].Points.Count - 2].YValues[2] ==
                          this.chart1.Series[0].Points[this.chart1.Series[0].Points.Count - 2].YValues[3])
                        {
                            this.chart1.Series[0].Points.RemoveAt(this.chart1.Series[0].Points.Count - 2);
                            this.chart1.Series[0].Points.AddXY(k.d, k.o, k.h, k.l, k.c);

                        }

                    }
                    //AppendText(k.ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("RealMarket:", ex.Message);
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

        /// <summary>
        /// 调整纵坐标
        /// </summary>
        /// <param name="chart"></param>
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

        private void Chart_MouseMove(object sender, MouseEventArgs e)
        {
            //MsChart.Refresh();没啥效果
            this.chart1.ChartAreas[0].CursorX.LineColor = Color.White;
            this.chart1.ChartAreas[0].CursorY.LineColor = Color.White;

            this.chart1.ChartAreas[0].CursorX.SetCursorPixelPosition(new PointF(e.X, e.Y), true);
            this.chart1.ChartAreas[0].CursorY.SetCursorPixelPosition(new PointF(e.X, e.Y), true);
            //Application.DoEvents(); 使用此方法当有线程操作时会引发异常
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
            //拉取所有的ta.lib的指标信息，并填充到Menu_Items
            try
            {
                LoadIndicators();
            }
            catch(Exception ex)
            {
                MessageBox.Show("指标信息菜单信息加载失败:" + ex.Message);
            }
        }

        /// <summary>
        /// 加载所有ta_lib的指标到菜单
        /// </summary>
        private void LoadIndicators()
        {
            //List<MemberInfo> typesList = IndicatorsLoader.LoadeIndicatorsFuncAisa();
            //for(int i = 0;i<10;i++)
            //foreach (MemberInfo info in typesList)
            //{
            //    //string IndicatorName = info.Name;

            //    //ToolStripMenuItem ToolStripMenuItem_Indicators = new System.Windows.Forms.ToolStripMenuItem();
            //    //ToolStripMenuItem_Indicators.Name = "ToolStripMenuItem_Indicators_" + IndicatorName;
            //    //ToolStripMenuItem_Indicators.Size = new System.Drawing.Size(180, 22);
            //    //ToolStripMenuItem_Indicators.Text = IndicatorName;
            //    //this.ToolStripMenuItem_Custems.DropDownItems.Add(ToolStripMenuItem_Indicators);
            //}
        }

        private void Form_Closed(object sender, FormClosedEventArgs e)
        {
          
        }

        private void Form_Closing(object sender, FormClosingEventArgs e)
        {
          
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
        /// 图表和指标日常日志
        /// </summary>
        /// <param name="str"></param>
        private void AppendText(string str)
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke(new Action<string>(AppendText), str);
                return;
            }

            this.richTextBox_ChartAndIndicatorsLog.AppendText("\n" + DateTime.Now.ToString() + ":" + "\n" + str);
        }

        /// <summary>
        /// 策略订阅的策略日志
        /// </summary>
        /// <param name="str"></param>
        private void AppendStrategyText(string str)
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke(new Action<string>(AppendStrategyText), str);
                return;
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
            if (renkoForm.RenkoDialogResult == false)
            {
                return;
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
        /// 日志自动滚动到末尾
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RichBox_TextChanged(object sender, EventArgs e)
        {
            this.richTextBox_ChartAndIndicatorsLog.SelectionStart = this.richTextBox_ChartAndIndicatorsLog.Text.Length;
            this.richTextBox_ChartAndIndicatorsLog.SelectionLength = 0;
            this.richTextBox_ChartAndIndicatorsLog.Focus();
        }

        private void RichBoxStrategy_TextChanged(object sender, EventArgs e)
        {
            this.richTextBox_StrategyLog.SelectionStart = this.richTextBox_StrategyLog.Text.Length;
            this.richTextBox_StrategyLog.SelectionLength = 0;
            this.richTextBox_StrategyLog.Focus();
        }

        /// <summary>
        /// 所有指标点击入口
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToolStripMenuItem_IndicatorsCommonIn_Click(object sender, EventArgs e)
        {
            //和策略一样可以在这里用工厂模式搜索indicator里的所有指标抽象加载
            if (((ToolStripMenuItem)sender).Text == "SAR")
            {
                IIndicators sar = new SarIndicator();

                if (m_indicator != null)
                {
                    m_indicator = null;
                }
                m_indicator = sar;
            }

            if (((ToolStripMenuItem)sender).Text == "MA")
            {
                IIndicators ma = new MaIndicator();

                if (m_indicator != null)
                {
                    m_indicator = null;
                }
                m_indicator = ma;
            }
        }

        /// <summary>
        /// 隐藏显示指标面板
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private bool m_isIndocatorChartVisual = false;
        private void ToolStripMenuItem_VisualIndocatorClick(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 延迟Form_Load加载到点击常用指标菜单的时候加载指标
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToolStripMenuItem_CustemsClick(object sender, EventArgs e)
        {
           
        }
    }
}
