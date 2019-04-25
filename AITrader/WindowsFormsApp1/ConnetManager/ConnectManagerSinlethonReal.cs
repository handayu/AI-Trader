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
                    var candles = resResult.ToObject<List<List<decimal>>>();
                    AIEventArgs args = new AIEventArgs()
                    {
                        EventData = candles,
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

    }
}
