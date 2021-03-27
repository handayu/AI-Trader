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
using ZedGraph;

namespace WindowsFormsApp1
{
    public partial class ZedKLineForm : DockContent
    {
        public ZedKLineForm()
        {
            InitializeComponent();

            InitControls();
        }

        public ZedKLineForm(swap.Ticker t, int formName)
        {
            InitializeComponent();

            InitControls();

        }

        private void InitControls()
        {
            this.zedGraphControl1.GraphPane.XAxis.MajorGrid.IsVisible = true;
            this.zedGraphControl1.GraphPane.YAxis.MajorGrid.IsVisible = true;
            this.zedGraphControl1.GraphPane.XAxis.MajorGrid.Color = Color.FromArgb(65, 65, 65);
            this.zedGraphControl1.GraphPane.YAxis.MajorGrid.Color = Color.FromArgb(65, 65, 65);

            this.zedGraphControl1.IsZoomOnMouseCenter = false;//使用滚轮时以鼠标所在点进行缩放还是以图形中心进行缩放  true为以鼠标所在点进行缩放

            this.zedGraphControl1.GraphPane.XAxis.Color = Color.Red;
            this.zedGraphControl1.GraphPane.YAxis.Color = Color.Red;

            this.zedGraphControl1.GraphPane.XAxis.Scale.FontSpec.FontColor = Color.White;
            this.zedGraphControl1.GraphPane.YAxis.Scale.FontSpec.FontColor = Color.White;

            //this.zedGraphControl1.GraphPane.XAxis.MajorGrid.Color = Color.Red;
            //this.zedGraphControl1.GraphPane.XAxis.MinorGrid.Color = Color.Red;

            this.zedGraphControl1.GraphPane.YAxis.MajorGrid.IsZeroLine = false;


            this.zedGraphControl1.GraphPane.XAxis.MajorTic.Color = Color.Red;
            this.zedGraphControl1.GraphPane.XAxis.MinorTic.Color = Color.Red;

            this.zedGraphControl1.GraphPane.YAxis.MajorTic.Color = Color.Red;
            this.zedGraphControl1.GraphPane.YAxis.MinorTic.Color = Color.Red;

            this.zedGraphControl1.GraphPane.Chart.Border.IsVisible = false;//首先设置边框为无
            this.zedGraphControl1.GraphPane.XAxis.MajorTic.IsOpposite = false;//然后设置X轴对面轴大间隔为无
            this.zedGraphControl1.GraphPane.XAxis.MinorTic.IsOpposite = false;//设置Y轴对面轴小间隔为无
            this.zedGraphControl1.GraphPane.YAxis.MajorTic.IsOpposite = false;//设置Y轴对面轴大间隔为无
            this.zedGraphControl1.GraphPane.YAxis.MinorTic.IsOpposite = false;//设置Y轴对面轴小间隔为无
        }

        private void Form_Load(object sender, EventArgs e)
        {
            GraphPane myPane = this.zedGraphControl1.GraphPane;
            myPane.Title.Text = "";
            myPane.XAxis.Title.Text = "";
            myPane.YAxis.Title.Text = "";
            StockPointList spl = new StockPointList();
            Random rand = new Random();
            int dP = 0;
            double open = 50.0;
            for (int i = 0; i < 200; i++)
            {
                dP++;
                double close = open + rand.NextDouble() * 10.0 - 5.0;
                double hi = Math.Max(open, close) + rand.NextDouble() * 5.0;
                double low = Math.Min(open, close) - rand.NextDouble() * 3.0;
                StockPt pt = new StockPt(dP, hi, low, open, close, 100);
                spl.Add(pt);
                open = close;

            }

            JapaneseCandleStickItem myCurve = myPane.AddJapaneseCandleStick("", spl);
            //中间那条细线的颜色
            myCurve.Stick.Color = Color.Orange;
            //当收盘价高于开盘价body的颜色
            myCurve.Stick.RisingFill = new Fill(Color.FromArgb(255, 0, 0));
            //当收盘价低于开盘价body的颜色
            myCurve.Stick.FallingFill = new Fill(Color.FromArgb(0, 254, 4));
            //当收盘价高于开盘价border的颜色
            myCurve.Stick.RisingBorder = new Border(Color.FromArgb(255, 0, 0), 1.0f);
            //当收盘价低于开盘价border的颜色
            myCurve.Stick.FallingBorder = new Border(Color.FromArgb(0, 254, 4), 1.0f);

            //myPane.XAxis.Type=AxisType.DateAsOrdinal;
            //myPane.XAxis.Scale.Min=new XDate(2006,1,1);
            myPane.Chart.Fill = new Fill(Color.Black, Color.Black, 45.0f);
            myPane.Fill = new Fill(Color.Black, Color.Black, 45.0f);
            this.zedGraphControl1.AxisChange();

        }

        /// <summary>
        /// 隐藏显示交易面板
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private bool m_isTradePanelVisual = true;
        private void ToolStripMenuItem_VisualTradeClick(object sender, EventArgs e)
        {
            if (m_isTradePanelVisual)
            {
                this.splitContainer1.SplitterDistance =
    this.splitContainer1.Panel1.Width + this.splitContainer1.Panel2.Width;
                this.panel_Trade.Visible = false;
                m_isTradePanelVisual = false;
                return;
            }
            else
            {
                this.splitContainer1.SplitterDistance =
  this.splitContainer1.Width / 2;
                this.panel_Trade.Visible = true;
                m_isTradePanelVisual = true;
                return;

            }

        }
    }
}
