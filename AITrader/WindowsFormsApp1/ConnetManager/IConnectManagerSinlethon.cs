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
    public class IConnectManagerSinlethon
    {
        protected GeneralApi m_generalApi = null;
        protected AccountApi m_accountApi = null;
        protected FuturesApi m_futureApi = null;
        protected SpotApi m_spotApi = null;
        protected MarginApi m_marginApi = null;
        protected EttApi m_ettApi = null;
        protected SwapApi m_swapApi = null;
        protected string m_apiKey = "";
        protected string m_secret = "";
        protected string m_passPhrase = "";


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
            if (AnsyServerTimeEvent == null)
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
        /// Init-Login
        /// </summary>
        /// <param name="apikey"></param>
        /// <param name="secret"></param>
        /// <param name="passPhrea"></param>
        public virtual void InitApiLogin(string apikey, string secret, string passPhrea)
        {
            
        }

        /// <summary>
        /// 获取同步时间
        /// </summary>
        /// <returns></returns>
        public virtual async Task AnsyServerTime()
        {

        }

        /// <summary>
        /// 获取永续合约信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public virtual async Task AnsyGetInstrumentsSwap()
        {
        }

        /// <summary>
        /// 获取永续合约深度报价-所有合约
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public  virtual async Task AnsyGetMarketDepthDataSwap()
        {
        }

        /// <summary>
        /// 获取K线数据
        /// </summary>
        /// "BTC-USD-SWAP", DateTime.UtcNow.AddMinutes(-1), DateTime.UtcNow, 60
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public virtual async Task AnsyGetKLineSwap(string ins, DateTime startTime, DateTime endTime, int frame)
        {
        }
    }
}
