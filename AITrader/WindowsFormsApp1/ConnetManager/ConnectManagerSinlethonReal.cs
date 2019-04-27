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

namespace WindowsFormsApp1
{
    public class ConnectManagerSinlethonReal : IConnectManagerSinlethon
    {
        private static ConnectManagerSinlethonReal m_SingletonSecond = null;

        static ConnectManagerSinlethonReal()
        {

            m_SingletonSecond = new ConnectManagerSinlethonReal();
        }

        public static ConnectManagerSinlethonReal CreateInstance()
        {
            return m_SingletonSecond;
        }


        /// <summary>
        /// Init-Login
        /// </summary>
        /// <param name="apikey"></param>
        /// <param name="secret"></param>
        /// <param name="passPhrea"></param>
        public override void InitApiLogin(string apikey, string secret, string passPhrea)
        {
            m_apiKey = apikey;
            m_secret = secret;
            m_passPhrase = passPhrea;

            m_generalApi = new GeneralApi(m_apiKey, m_secret, m_passPhrase);
            m_futureApi = new FuturesApi(m_apiKey, m_secret, m_passPhrase);
            m_accountApi = new AccountApi(m_apiKey, m_secret, m_passPhrase);
            m_spotApi = new SpotApi(m_apiKey, m_secret, m_passPhrase);
            m_marginApi = new MarginApi(m_apiKey, m_secret, m_passPhrase);
            m_ettApi = new EttApi(m_apiKey, m_secret, m_passPhrase);
            m_swapApi = new SwapApi(m_apiKey, m_secret, m_passPhrase);

            AIEventArgs args = new AIEventArgs()
            {
                EventData = m_apiKey,
                ReponseMessage = RESONSEMESSAGE.LOGIN_SUCCESS
            };

            SafeRiseAnsyLoginEvent(args);
        }

        /// <summary>
        /// 获取同步时间
        /// </summary>
        /// <returns></returns>
        public override async Task AnsyServerTime()
        {
            try
            {
                var result = await m_generalApi.syncTimeAsync();
                string sTime = JsonConvert.SerializeObject(result);

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
        /// 获取永续合约信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public override async Task AnsyGetInstrumentsSwap()
        {
            try
            {
                var resResult = await m_swapApi.getInstrumentsAsync();
                if (resResult.Type == JTokenType.Object)
                {
                    JToken codeJToken;
                    if (((JObject)resResult).TryGetValue("code", out codeJToken))
                    {
                        var errorInfo = resResult.ToObject<ErrorResult>();

                        AIEventArgs args = new AIEventArgs()
                        {
                            EventData = errorInfo,
                            ReponseMessage = RESONSEMESSAGE.HOLDINSTRUMENTS_FAILED
                        };

                        SafeRiseAnsyGetInsEvent(args);
                    }
                }
                else
                {
                    var instruments = resResult.ToObject<List<swap.Instrument>>();

                    AIEventArgs args = new AIEventArgs()
                    {
                        EventData = instruments,
                        ReponseMessage = RESONSEMESSAGE.HOLDINSTRUMENTS_SUCCESS
                    };

                    SafeRiseAnsyGetInsEvent(args);
                }
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
        /// 获取永续合约深度报价-所有合约
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public override async Task AnsyGetMarketDepthDataSwap()
        {
            try
            {
                var resResult = await m_swapApi.getTickersAsync();
                if (resResult.Type == JTokenType.Object)
                {
                    JToken codeJToken;
                    if (((JObject)resResult).TryGetValue("code", out codeJToken))
                    {
                        var errorInfo = resResult.ToObject<ErrorResult>();

                        AIEventArgs args = new AIEventArgs()
                        {
                            EventData = errorInfo,
                            ReponseMessage = RESONSEMESSAGE.HOLDMARKETDATA_FAILED
                        };

                        SafeRiseAnsyRealDataEvent(args);
                    }
                }
                else
                {
                    var ticker = resResult.ToObject<List<swap.Ticker>>();
                    AIEventArgs args = new AIEventArgs()
                    {
                        EventData = ticker,
                        ReponseMessage = RESONSEMESSAGE.HOLDMARKETDATA_SUCCESS
                    };

                    SafeRiseAnsyRealDataEvent(args);
                }
            }
            catch (Exception ex)
            {
                AIEventArgs args = new AIEventArgs()
                {
                    EventData = ex,
                    ReponseMessage = RESONSEMESSAGE.HOLDMARKETDATA_FAILED
                };

                SafeRiseAnsyRealDataEvent(args);
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
            //之前的这里的K线解析有问题，所以改用下面的根据字符串暴力解析
            //try
            //{
            //    var resResult = await m_swapApi.getCandlesDataAsync(ins, startTime, endTime, frame);
            //    if (resResult.Type == JTokenType.Object)
            //    {
            //        JToken codeJToken;
            //        if (((JObject)resResult).TryGetValue("code", out codeJToken))
            //        {
            //            var errorInfo = resResult.ToObject<ErrorResult>();
            //            AIEventArgs args = new AIEventArgs()
            //            {
            //                EventData = errorInfo,
            //                ReponseMessage = RESONSEMESSAGE.HOLDKLINE_FAILED
            //            };

            //            SafeRiseAnsyKLineEvent(args);
            //        }
            //    }
            //    else
            //    {
            //        var candles = resResult.ToObject<TestData.klineRoot>();
            //        AIEventArgs args = new AIEventArgs()
            //        {
            //            EventData = candles,
            //            ReponseMessage = RESONSEMESSAGE.HOLDKLINE_SUCCESS
            //        };

            //        SafeRiseAnsyKLineEvent(args);
            //    }
            //}
            //catch (Exception ex)
            //{
            //    AIEventArgs args = new AIEventArgs()
            //    {
            //        EventData = ex,
            //        ReponseMessage = RESONSEMESSAGE.HOLDKLINE_FAILED
            //    };

            //    SafeRiseAnsyKLineEvent(args);
            //}

            //之前的这里的K线解析有问题，所以改用下面的暴力解析
            //  {[
            //  [
            //    "2019-04-27T10:27:00Z",
            //    "5152.4",
            //    "5152.4",
            //    "5152.4",
            //    "5152.4",
            //    "0",
            //    "0"
            //  ],
            //  [
            //    "2019-04-27T10:26:00Z",
            //    "5154.4",
            //    "5154.4",
            //    "5152.4",
            //    "5152.4",
            //    "197",
            //    "3.8225"
            //  ]
            //  ]}

            try
            {
                var resResult = await m_swapApi.getCandlesDataAsync(ins, startTime, endTime, frame);
                if (resResult.Type == JTokenType.Object)
                {
                    JToken codeJToken;
                    if (((JObject)resResult).TryGetValue("code", out codeJToken))
                    {
                        var errorInfo = resResult.ToObject<ErrorResult>();
                        AIEventArgs args = new AIEventArgs()
                        {
                            EventData = errorInfo,
                            ReponseMessage = RESONSEMESSAGE.HOLDKLINE_FAILED
                        };

                        SafeRiseAnsyKLineEvent(args);
                    }
                }
                else
                {
                    List<JToken> jList = resResult.Root.ToList();
                    if (jList == null || jList.Count <= 0) return;

                    List<TestData.KlineOkex> klineList = new List<TestData.KlineOkex>();

                    foreach (JToken j in jList)
                    {
                        TestData.KlineOkex okLine = new TestData.KlineOkex()
                        {
                            insment = ins,
                            d = (DateTime)j[0],
                            o = (decimal)j[1],
                            h = (decimal)j[2],
                            l = (decimal)j[3],
                            c = (decimal)j[4],
                            unkonwn1 = (decimal)j[5],
                            unkonwn2 = (decimal)j[6],

                        };

                        klineList.Add(okLine);
                    }

                    AIEventArgs args = new AIEventArgs()
                    {
                        EventData = klineList,
                        ReponseMessage = RESONSEMESSAGE.HOLDKLINE_SUCCESS
                    };

                    SafeRiseAnsyKLineEvent(args);
                }
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
                var resResult = await this.m_swapApi.getAccountsAsync();
                JToken codeJToken;
                if (resResult.TryGetValue("code", out codeJToken))
                {
                    var errorInfo = resResult.ToObject<ErrorResult>();

                    AIEventArgs args = new AIEventArgs()
                    {
                        EventData = errorInfo,
                        ReponseMessage = RESONSEMESSAGE.HOLDKLINE_FAILED
                    };

                    SafeRiseAnsyAccountDataEvent(args);
                }
                else
                {
                    var accountsInfo = resResult.ToObject<swap.AccountsResult>();

                    AIEventArgs args = new AIEventArgs()
                    {
                        EventData = accountsInfo,
                        ReponseMessage = RESONSEMESSAGE.HOLDACCOUNTS_SUCCESS
                    };

                    SafeRiseAnsyAccountDataEvent(args);
                }
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
                var resResult = await this.m_swapApi.getPositionByInstrumentAsync(insID);
                JToken codeJToken;
                if (resResult.TryGetValue("code", out codeJToken))
                {
                    var errorInfo = resResult.ToObject<ErrorResult>();

                    AIEventArgs args = new AIEventArgs()
                    {
                        EventData = errorInfo,
                        ReponseMessage = RESONSEMESSAGE.HOLDPOSITION_FAILED
                    };

                    SafeRiseAnsyPositionEvent(args);
                }
                else
                {
                    var obj = resResult.ToObject<swap.PositionResult<Position>>();

                    AIEventArgs args = new AIEventArgs()
                    {
                        EventData = obj,
                        ReponseMessage = RESONSEMESSAGE.HOLDPOSITION_SUCCESS
                    };

                    SafeRiseAnsyPositionEvent(args);
                }
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
                var resResult = await this.m_swapApi.getOrdersAsync(instrument_id, status, from, to, limit);

                JToken codeJToken;
                if (((JObject)resResult).TryGetValue("code", out codeJToken))
                {
                    var errorInfo = resResult.ToObject<ErrorResult>();
                    AIEventArgs args = new AIEventArgs()
                    {
                        EventData = errorInfo,
                        ReponseMessage = RESONSEMESSAGE.HOLDORDER_FAILED
                    };

                    SafeRiseAnsyPositionEvent(args);
                }
                else
                {
                    var ledgers = resResult.ToObject<swap.OrderListResult>();
                    AIEventArgs args = new AIEventArgs()
                    {
                        EventData = ledgers,
                        ReponseMessage = RESONSEMESSAGE.HOLDORDER_SUCCESS
                    };

                    SafeRiseAnsyPositionEvent(args);
                }
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
                var resResult = await this.m_swapApi.getTradesAsync(instrument_id, from, to, limit);
                if (resResult.Type == JTokenType.Object)
                {
                    JToken codeJToken;
                    if (((JObject)resResult).TryGetValue("code", out codeJToken))
                    {
                        var errorInfo = resResult.ToObject<ErrorResult>();
                        AIEventArgs args = new AIEventArgs()
                        {
                            EventData = errorInfo,
                            ReponseMessage = RESONSEMESSAGE.HOLDTRADE_FAILED
                        };

                        SafeRiseAnsyTradeEvent(args);
                    }
                }
                else
                {
                    var trades = resResult.ToObject<List<swap.Trade>>();
                    AIEventArgs args = new AIEventArgs()
                    {
                        EventData = trades,
                        ReponseMessage = RESONSEMESSAGE.HOLDTRADE_SUCCESS
                    };

                    SafeRiseAnsyTradeEvent(args);
                }
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


    }
}
