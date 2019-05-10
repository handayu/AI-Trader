using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Common;
using TALibraryInCSharp;
using swap = OKExSDK.Models.Swap;

namespace WindowsFormsApp1
{
    public partial class TestSarForm : Form
    {
        private BarMarker m_barMarker = null;

        public TestSarForm()
        {
            InitializeComponent();

            //ta-lib验证通过，指标验证通过

            #region 实例计算SMA

            //外部去封装按照OHLC计算，这里IntReal是一组数列,等待计算的
            double[] intRealSMA = new double[] { 1, 2, 3, 45, 1, 1, 3 };

            //outReal是即将输出的一组计算结果数列
            double[] outRealSMA = { 0, 0, 0, 0, 0, 0 };

            //输出数列的起始计算的Index
            int outBegIndexSMA = 0;

            //输出数列的目前计算的index
            int outNBElementSMA = 0;

            Core.MovingAverage(0, 6, intRealSMA, 2, Core.MAType.Sma, ref outBegIndexSMA, ref outNBElementSMA, outRealSMA);
            #endregion

            #region 计算SAR实例
            //外部去封装按照OHLC计算，这里IntReal是一组数列,等待计算的
            double[] intHigh = new double[] { 2130, 2130, 2135, 2140, 2145, 2150, 2145, 2140, 2145, 2150, 2155, 2160, 2155, 2150, 2145, 2140, 2135 };
            double[] intLow = new double[] { 2130-5, 2130 - 5, 2135 - 5, 2140 - 5, 2145 - 5, 2150 - 5, 2145 - 5, 2140 - 5,
                2145 - 5, 2150 - 5, 2155-5, 2160-5, 2155-5, 2150-5, 2145-5 ,2140-5,2135-5};

            //outReal是即将输出的一组计算结果数列
            double[] outRealSAR = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };

            //输出数列的起始计算的Index
            int outBegIndexSAR = 0;

            //输出数列的目前计算的index
            int outNBElementSAR = 0;

            Core.Sar(0, intHigh.Length - 1, intHigh, intLow, 0.02, 0.2, ref outBegIndexSAR, ref outNBElementSAR, outRealSAR);

            #endregion

            #region C++使用方法和.net一致
            //TA-Lib是一个用于金融技术分析的C++库，可以用来计算MACD，动量，移动均线等常用指标等
            //本文对TA-Lib做了一个简单的使用初体验
            //int main()
            //{
            //    std::cout << "ta-lib test" << std::endl;

            //    // init ta-lib context
            //    TA_RetCode retcode;
            //    retcode = TA_Initialize();
            //    assert(retcode == TA_SUCCESS);

            //    // comput moving average price
            //    TA_Real close_price_array[400] = { 0 };
            //    // construct random price
            //    srand((unsigned)time(0));
            //    for (int i = 0; i < 400; i++)
            //    close_price_array[i] = rand() % 50 + 100;

            //    TA_Real    out[400] = { 0 };
            //    TA_Integer out_begin = 0;
            //        TA_Integer out_nb_element = 0;

            //        retcode = TA_MA(0, 399,
            //            &close_price_array[0],
            //            30, TA_MAType_SMA,
            //            &out_begin, &out_nb_element, &out[0]);

            //        assert(retcode == TA_SUCCESS);

            //        std::cout << "---- compute output ----" << std::endl;
            //    std::cout << "out_begin_index: " << out_begin << std::endl;
            //    std::cout << "out_nb_element: " << out_nb_element << std::endl;
            //    std::cout << "out price array: " << std::endl;
            //    for (auto &price : out)
            //        std::cout << price << " ";

            //    retcode = TA_Shutdown();
            //        assert(retcode == TA_SUCCESS);

            //    return 0;
            //}
            #endregion

            ChartInfo chartinfo = new ChartInfo()
            {
                Instrument = "BTC-USD-SWAP",
                RenkoBarBoxSize = 2,
                DataFrame = DATAFRAME.MIN1,
                CandleType = CANDLETYPE.RENKOBAR
            };

            m_barMarker = new BarMarker(chartinfo);

            m_barMarker.BarComingEvent += M_barMarker_NewRenkoBarComingEvent;
            APIConnect.ConnectManager.CreateInstance().CONNECTION.AnsyRealDataEvent += AnsyRealDataSubEvent;
        }

        private void AnsyRealDataSubEvent(AIEventArgs args)
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke(new Action<AIEventArgs>(AnsyRealDataSubEvent), args);
                return;
            }
            if (args.ReponseMessage == RESONSEMESSAGE.HOLDMARKETDATA_FAILED) return;
            List<swap.Ticker> ticLiet = (List<swap.Ticker>)args.EventData;
            if (ticLiet == null) return;
            if (ticLiet.Count <= 0 || ticLiet[0].instrument_id != "BTC-USD-SWAP") return;

            foreach (swap.Ticker t in ticLiet)
            {
                if (t.instrument_id != "BTC-USD-SWAP") continue;

                this.richTextBox_nowTick.AppendText("\n" + t.last.ToString());
            }
        }

        private void M_barMarker_NewRenkoBarComingEvent(Common.TestData.KlineOkex renkoBar,DATAFRAME frame)
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke(new Action<Common.TestData.KlineOkex, DATAFRAME>(M_barMarker_NewRenkoBarComingEvent), renkoBar, frame);
                return;
            }

            this.richTextBox_renko.AppendText("\n" + renkoBar.o.ToString() + ":" + renkoBar.h.ToString() + ":" +
                renkoBar.l.ToString() + ":" + renkoBar.c.ToString());

        }

        private void Form_Closed(object sender, FormClosedEventArgs e)
        {
            if (m_barMarker != null)
                m_barMarker.BarComingEvent -= M_barMarker_NewRenkoBarComingEvent;

            if (APIConnect.ConnectManager.CreateInstance().CONNECTION != null)
                APIConnect.ConnectManager.CreateInstance().CONNECTION.AnsyRealDataEvent -= AnsyRealDataSubEvent;
        }
    }
}
