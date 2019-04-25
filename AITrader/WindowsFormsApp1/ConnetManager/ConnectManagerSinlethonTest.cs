using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using swap = OKExSDK.Models.Swap;
using OKExSDK;
using OKExSDK.Models;
using OKExSDK.Models.Account;
using OKExSDK.Models.Ett;
using OKExSDK.Models.Futures;
using OKExSDK.Models.Margin;
using OKExSDK.Models.Spot;
using OKExSDK.Models.General;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Converters;

namespace WindowsFormsApp1
{
    public class ConnectManagerSinlethonTest : IConnectManagerSinlethon
    {
        private static ConnectManagerSinlethonTest m_SingletonSecond = null;

        static ConnectManagerSinlethonTest()
        {

            m_SingletonSecond = new ConnectManagerSinlethonTest();
        }

        public static ConnectManagerSinlethonTest CreateInstance()
        {
            return m_SingletonSecond;
        }


        /// <summary>
        /// Init-Login-模拟直接返回
        /// </summary>
        /// <param name="apikey"></param>
        /// <param name="secret"></param>
        /// <param name="passPhrea"></param>
        public override void InitApiLogin(string apikey, string secret, string passPhrea)
        {
            AIEventArgs args = new AIEventArgs()
            {
                EventData = m_apiKey,
                ReponseMessage = RESONSEMESSAGE.LOGIN_SUCCESS
            };

            SafeRiseAnsyLoginEvent(args);
        }

        /// <summary>
        /// 获取同步时间-模拟直接返回时间
        /// </summary>
        /// <returns></returns>
        public override async Task AnsyServerTime()
        {
            try
            {
                string sTime = DateTime.Now.ToString();

                AIEventArgs args = new AIEventArgs()
                {
                    EventData = sTime,
                    ReponseMessage = RESONSEMESSAGE.SERVERTIME_SUCCESS
                };

                SafeRiseAnsyServerTimeEvent(args);

            }
            catch (Exception ex)
            {
                AIEventArgs args = new AIEventArgs()
                {
                    EventData = ex,
                    ReponseMessage = RESONSEMESSAGE.SERVERTIME_FAILED
                };

                SafeRiseAnsyServerTimeEvent(args);
            }
        }


        /// <summary>
        /// 获取永续合约信息-模拟直接返回结果
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public override async Task AnsyGetInstrumentsSwap()
        {
            try
            {
                List<swap.Instrument> insLIst = TestData.GetIns();

                AIEventArgs args = new AIEventArgs()
                {
                    EventData = insLIst,
                    ReponseMessage = RESONSEMESSAGE.HOLDINSTRUMENTS_SUCCESS
                };

                SafeRiseAnsyGetInsEvent(args);

            }
            catch (Exception ex)
            {
                AIEventArgs args = new AIEventArgs()
                {
                    EventData = ex,
                    ReponseMessage = RESONSEMESSAGE.HOLDINSTRUMENTS_FAILED
                };

                SafeRiseAnsyGetInsEvent(args);
            }

        }


        /// <summary>
        /// 获取永续合约深度报价-模拟返回行情
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public override async Task AnsyGetMarketDepthDataSwap()
        {
            try
            {

                List<swap.Ticker> tickerList = TestData.GetTicker();
                AIEventArgs args = new AIEventArgs()
                {
                    EventData = tickerList,
                    ReponseMessage = RESONSEMESSAGE.HOLDMARKETDATA_SUCCESS
                };

                SafeRiseAnsyTickerEvent(args);

            }
            catch (Exception ex)
            {
                AIEventArgs args = new AIEventArgs()
                {
                    EventData = ex,
                    ReponseMessage = RESONSEMESSAGE.HOLDMARKETDATA_FAILED
                };

                SafeRiseAnsyTickerEvent(args);
            }
        }

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
        public override async Task AnsyGetKLineSwap(string ins, DateTime startTime, DateTime endTime, int frame)
        {
            try
            {
                var candles = TestData.GetKLine();
                AIEventArgs args = new AIEventArgs()
                {
                    EventData = candles,
                    ReponseMessage = RESONSEMESSAGE.HOLDKLINE_SUCCESS
                };

                SafeRiseAnsyKLineEvent(args);

            }
            catch (Exception ex)
            {
                AIEventArgs args = new AIEventArgs()
                {
                    EventData = ex,
                    ReponseMessage = RESONSEMESSAGE.HOLDKLINE_FAILED
                };

                SafeRiseAnsyKLineEvent(args);
            }
        }

    }
}
