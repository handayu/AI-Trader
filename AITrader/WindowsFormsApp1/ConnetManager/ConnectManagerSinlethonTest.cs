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
            SwapLoginAccountInfo a = new SwapLoginAccountInfo()
            {
                SwapApiKey = apikey,
                SwapSecret = secret,
                SwapPassPhrase = passPhrea
            };

            m_swapLoginAccountInfo = a;

            AIEventArgs args = new AIEventArgs()
            {
                EventData = a,
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

                AnsyRealDataEvent(args);

            }
            catch (Exception ex)
            {
                AIEventArgs args = new AIEventArgs()
                {
                    EventData = ex,
                    ReponseMessage = RESONSEMESSAGE.HOLDMARKETDATA_FAILED
                };

                AnsyRealDataEvent(args);
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
                var candles = TestData.GetKLine(ins);
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

        /// <summary>
        /// 获取所有永续合约账户信息
        /// </summary>
        /// <returns></returns>
        public override async Task AnsyAccountsSwap()
        {
            try
            {

                var accountsInfo = TestData.GetAccountResult();

                AIEventArgs args = new AIEventArgs()
                {
                    EventData = accountsInfo,
                    ReponseMessage = RESONSEMESSAGE.HOLDACCOUNTS_SUCCESS
                };

                SafeRiseAnsyAccountDataEvent(args);

            }
            catch (Exception ex)
            {
                AIEventArgs args = new AIEventArgs()
                {
                    EventData = ex,
                    ReponseMessage = RESONSEMESSAGE.HOLDKLINE_FAILED
                };

                SafeRiseAnsyAccountDataEvent(args);
            }
        }

        /// <summary>
        /// 获取各永续合约Position信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public override async void AnsyPositionByInstrumentSwap(string insID)
        {
            try
            {
                var obj = TestData.GetPositionResult();
                AIEventArgs args = new AIEventArgs()
                {
                    EventData = obj,
                    ReponseMessage = RESONSEMESSAGE.HOLDPOSITION_SUCCESS
                };

                SafeRiseAnsyPositionEvent(args);

            }
            catch (Exception ex)
            {
                AIEventArgs args = new AIEventArgs()
                {
                    EventData = ex,
                    ReponseMessage = RESONSEMESSAGE.HOLDPOSITION_FAILED
                };

                SafeRiseAnsyPositionEvent(args);
            }
        }

        /// <summary>
        /// 获取永续合约Order信息
        /// </summary>
        /// <param name="instrument_id">合约名称，如BTC-USD-SWAP</param>
        /// <param name="status">订单状态(-2:失败 -1:撤单成功 0:等待成交 1:部分成交 2:完全成交)</param>
        /// <param name="from">分页游标开始</param>
        /// <param name="to">分页游标截至</param>
        /// <param name="limit">分页数据数量，默认100</param>
        /// <returns></returns>
        public override async void AnsyOrdersByInstrumentSwap(string instrument_id, string status, int? from, int? to, int? limit)
        {
            try
            {

                var ledgers = TestData.GetOrderResult();
                AIEventArgs args = new AIEventArgs()
                {
                    EventData = ledgers,
                    ReponseMessage = RESONSEMESSAGE.HOLDORDER_SUCCESS
                };

                SafeRiseAnsyPositionEvent(args);

            }
            catch (Exception ex)
            {
                AIEventArgs args = new AIEventArgs()
                {
                    EventData = ex,
                    ReponseMessage = RESONSEMESSAGE.HOLDORDER_FAILED
                };

                SafeRiseAnsyPositionEvent(args);
            }
        }

        /// <summary>
        /// 获取永续合约Trade信息
        /// </summary>
        /// <summary>
        /// 获取成交数据
        /// </summary>
        /// <param name="instrument_id">合约ID，如BTC-USD-180213</param>
        /// <param name="from">分页游标开始</param>
        /// <param name="to">分页游标截至</param>
        /// <param name="limit">分页数据数量，默认100</param>
        /// <param name="insID"></param>
        public override async void AnsyTradeByInstrumentSwap(string instrument_id, int? from, int? to, int? limit)
        {
            try
            {
                var trades = TestData.GetTradeResult();
                AIEventArgs args = new AIEventArgs()
                {
                    EventData = trades,
                    ReponseMessage = RESONSEMESSAGE.HOLDTRADE_SUCCESS
                };

                SafeRiseAnsyTradeEvent(args);

            }
            catch (Exception ex)
            {
                AIEventArgs args = new AIEventArgs()
                {
                    EventData = ex,
                    ReponseMessage = RESONSEMESSAGE.HOLDTRADE_FAILED
                };

                SafeRiseAnsyTradeEvent(args);
            }
        }


        /// <summary>
        /// 下单动作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// 下单
        /// </summary>
        /// <param name="instrument_id">合约名称，如BTC-USD-SWAP</param>
        /// <param name="type">1:开多2:开空3:平多4:平空</param>
        /// <param name="price">委托价格</param>
        /// <param name="size">下单数量</param>
        /// <param name="client_oid">由您设置的订单ID来识别您的订单</param>
        /// <param name="match_price">是否以对手价下单(0:不是 1:是)</param>
        /// <returns></returns>
        public override async void AnsyOrderSwap(OKExSDK.Models.Swap.OrderSingle order)
        {
            try
            {
                var orderResult = TestData.GetResultMarkeOrderSingle();
                AIEventArgs args = new AIEventArgs()
                {
                    EventData = orderResult,
                    ReponseMessage = RESONSEMESSAGE.HOLDMAKEORDERACTION_SUCCESS
                };

                SafeRiseAnsyMakeOrderEvent(args);

            }
            catch (Exception ex)
            {
                AIEventArgs args = new AIEventArgs()
                {
                    EventData = ex,
                    ReponseMessage = RESONSEMESSAGE.HOLDMAKEORDERACTION_FAILED
                };

                SafeRiseAnsyMakeOrderEvent(args);
            }
        }
    }
}
