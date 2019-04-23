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
    public class ConnectManagerSinlethon
    {

        private GeneralApi m_generalApi = null;
        private AccountApi m_accountApi = null;
        private FuturesApi m_futureApi = null;
        private SpotApi m_spotApi = null;
        private MarginApi m_marginApi = null;
        private EttApi m_ettApi = null;
        private SwapApi m_swapApi = null;

        private string m_apiKey = "";
        private string m_secret = "";
        private string m_passPhrase = "";

        private static ConnectManagerSinlethon m_SingletonSecond = null;

        static ConnectManagerSinlethon()
        {

            m_SingletonSecond = new ConnectManagerSinlethon();
        }

        public static ConnectManagerSinlethon CreateInstance()
        {
            return m_SingletonSecond;
        }

        /// <summary>
        /// Event-GetKLine
        /// </summary>
        /// <param name="args"></param>
        public delegate void AnsyKLineHandle(AIEventArgs args);
        public AnsyKLineHandle AnsyKLineEvent;
        public void SafeRiseAnsyKLineEvent(AIEventArgs args)
        {
            if (AnsyKLineEvent == null)
            {
                return;
            }
            else
            {
                AnsyKLineEvent(args);
            }
        }

        /// <summary>
        /// Event-Time
        /// </summary>
        /// <param name="args"></param>
        public delegate void AnsyServerTimeHandle(AIEventArgs args);
        public AnsyServerTimeHandle AnsyServerTimeEvent;
        public void SafeRiseAnsyServerTimeEvent(AIEventArgs args)
        {
            if(AnsyServerTimeEvent == null)
            {
                return;
            }
            else
            {
                AnsyServerTimeEvent(args);
            }
        }

        /// <summary>
        /// Event-Login
        /// </summary>
        /// <param name="args"></param>
        public delegate void AnsyLoginHandle(AIEventArgs args);
        public AnsyLoginHandle AnsyLoginEvent;
        public void SafeRiseAnsyLoginEvent(AIEventArgs args)
        {
            if (AnsyLoginEvent == null)
            {
                return;
            }
            else
            {
                AnsyLoginEvent(args);
            }
        }

        /// <summary>
        /// Event-GetIns
        /// </summary>
        /// <param name="args"></param>
        public delegate void AnsyGetInsHandle(AIEventArgs args);
        public AnsyGetInsHandle AnsyGetInsEvent;
        public void SafeRiseAnsyGetInsEvent(AIEventArgs args)
        {
            if (AnsyGetInsEvent == null)
            {
                return;
            }
            else
            {
                AnsyGetInsEvent(args);
            }
        }

        /// <summary>
        /// Event-RealData
        /// </summary>
        /// <param name="args"></param>
        public delegate void AnsyRealDataHandle(AIEventArgs args);
        public AnsyGetInsHandle AnsyRealDataEvent;
        public void SafeRiseAnsyRealDataEvent(AIEventArgs args)
        {
            if (AnsyRealDataEvent == null)
            {
                return;
            }
            else
            {
                AnsyRealDataEvent(args);
            }
        }


        /// <summary>
        /// Event-GetTiker
        /// </summary>
        /// <param name="args"></param>
        public delegate void AnsyTickerHandle(AIEventArgs args);
        public AnsyTickerHandle AnsyTickerEvent;
        public void SafeRiseAnsyTickerEvent(AIEventArgs args)
        {
            if (AnsyTickerEvent == null)
            {
                return;
            }
            else
            {
                AnsyTickerEvent(args);
            }
        }


        /// <summary>
        /// Init-Login
        /// </summary>
        /// <param name="apikey"></param>
        /// <param name="secret"></param>
        /// <param name="passPhrea"></param>
        public void InitApiLogin(string apikey, string secret, string passPhrea)
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
                info = "InitApiLogin-OK"
            };

            SafeRiseAnsyLoginEvent(args);
        }

        /// <summary>
        /// 获取同步时间
        /// </summary>
        /// <returns></returns>
        public async Task AnsyServerTimeAsync()
        {
            try
            {
                var result = await m_generalApi.syncTimeAsync();
                string sTime = JsonConvert.SerializeObject(result);

                AIEventArgs args = new AIEventArgs()
                {
                    EventData = sTime,
                    info = "AnsyServerTimeAsync-OK"
                };

                 SafeRiseAnsyServerTimeEvent(args);

            }
            catch (Exception ex)
            {
                AIEventArgs args = new AIEventArgs()
                {
                    EventData = ex,
                    info = ex.Message
                };

                SafeRiseAnsyServerTimeEvent(args);
            }
        }

        /// <summary>
        /// 获取永续合约信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public async void AnsyGetInstrumentsSwap()
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
                            info = "错误代码：" + errorInfo.code + ",错误消息：" + errorInfo.message
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
                        info = "获取合约信息成功"
                    };

                    SafeRiseAnsyGetInsEvent(args);
                }
            }
            catch (Exception ex)
            {
                AIEventArgs args = new AIEventArgs()
                {
                    EventData = ex,
                    info = "错误消息:" + ex.Message
                };

                SafeRiseAnsyGetInsEvent(args);
            }
        }

        /// <summary>
        /// 获取永续合约深度报价-所有合约
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void AnsyGetMarketDepthDataSwap()
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
                            info = "获取行情错误代码：" + errorInfo.code + ",错误消息：" + errorInfo.message
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
                        info = "获取行情成功"
                    };

                    SafeRiseAnsyRealDataEvent(args);
                }
            }
            catch (Exception ex)
            {
                AIEventArgs args = new AIEventArgs()
                {
                    EventData = ex,
                    info = "获取行情异常:" + ex.Message
                };

                SafeRiseAnsyRealDataEvent(args);
            }
        }

        /// <summary>
        /// 获取K线数据
        /// </summary>
        /// "BTC-USD-SWAP", DateTime.UtcNow.AddMinutes(-1), DateTime.UtcNow, 60
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void AnsyGetKLineSwap(string ins,DateTime startTime,DateTime endTime,int frame)
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
                            info = "获取K线错误代码：" + errorInfo.code + ",错误消息：" + errorInfo.message
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
                        info = "获取K线成功"
                    };

                    SafeRiseAnsyKLineEvent(args);
                }
            }
            catch (Exception ex)
            {
                AIEventArgs args = new AIEventArgs()
                {
                    EventData = ex,
                    info = "获取K线异常" + ex.Message
                };

                SafeRiseAnsyKLineEvent(args);
            }
        }

    }
}
