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
    /// <summary>
    /// 登陆信息
    /// </summary>
    public class SwapLoginAccountInfo
    {
        public string SwapApiKey
        {
            set;
            get;
        }

        public string SwapSecret
        {
            set;
            get;
        }
        public string SwapPassPhrase
        {
            set;
            get;
        }
    }


    public class IConnectManagerSinlethon
    {
        protected GeneralApi m_generalApi = null;
        protected AccountApi m_accountApi = null;
        protected FuturesApi m_futureApi = null;
        protected SpotApi m_spotApi = null;
        protected MarginApi m_marginApi = null;
        protected EttApi m_ettApi = null;
        protected SwapApi m_swapApi = null;
        protected SwapLoginAccountInfo m_swapLoginAccountInfo = new SwapLoginAccountInfo();

        public SwapLoginAccountInfo SwapLoginAccountInfo
        {
            get
            {
                return m_swapLoginAccountInfo;
            }
        }

        /// <summary>
        /// Event-Make Order
        /// </summary>
        /// <param name="args"></param>
        public delegate void AnsyMakeOrderHandle(AIEventArgs args);
        public AnsyMakeOrderHandle AnsyMakeOrderEvent;
        public void SafeRiseAnsyMakeOrderEvent(AIEventArgs args)
        {
            if (AnsyMakeOrderEvent == null)
            {
                return;
            }
            else
            {
                AnsyMakeOrderEvent(args);
            }
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

        #region 持仓-成交-委托
        /// <summary>
        /// Event-position
        /// </summary>
        /// <param name="args"></param>
        public delegate void AnsyPositionHandle(AIEventArgs args);
        public AnsyPositionHandle AnsyPositionEvent;
        public void SafeRiseAnsyPositionEvent(AIEventArgs args)
        {
            if (AnsyPositionEvent == null)
            {
                return;
            }
            else
            {
                AnsyPositionEvent(args);
            }
        }

        /// <summary>
        /// Event-trade
        /// </summary>
        /// <param name="args"></param>
        public delegate void AnsyTradeHandle(AIEventArgs args);
        public AnsyTradeHandle AnsyTradeEvent;
        public void SafeRiseAnsyTradeEvent(AIEventArgs args)
        {
            if (AnsyTradeEvent == null)
            {
                return;
            }
            else
            {
                AnsyTradeEvent(args);
            }
        }

        /// <summary>
        /// Event-order
        /// </summary>
        /// <param name="args"></param>
        public delegate void AnsyOrderHandle(AIEventArgs args);
        public AnsyOrderHandle AnsyOrderEvent;
        public void SafeRiseAnsyOrderEvent(AIEventArgs args)
        {
            if (AnsyOrderEvent == null)
            {
                return;
            }
            else
            {
                AnsyOrderEvent(args);
            }
        }

        #endregion

        /// <summary>
        /// Event-AccountData
        /// </summary>
        /// <param name="args"></param>
        public delegate void AnsyAccountDataHandle(AIEventArgs args);
        public AnsyAccountDataHandle AnsyAccountDataEvent;
        public void SafeRiseAnsyAccountDataEvent(AIEventArgs args)
        {
            if (AnsyAccountDataEvent == null)
            {
                return;
            }
            else
            {
                AnsyAccountDataEvent(args);
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
        public virtual async Task AnsyGetMarketDepthDataSwap()
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

        /// <summary>
        /// 获取所有永续合约账户信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public virtual async Task AnsyAccountsSwap()
        {

        }

        /// <summary>
        /// 获取永续合约持仓信息
        /// </summary>
        /// <param name="insID"></param>
        public virtual async void AnsyPositionByInstrumentSwap(string insID)
        {

        }

        /// <summary>
        /// 获取永续合约Order信息
        /// </summary>
        /// <param name="insID"></param>
        public virtual async void AnsyOrdersByInstrumentSwap(string instrument_id, string status, int? from, int? to, int? limit)
        {

        }

        /// <summary>
        /// 获取永续合约Trade信息
        /// </summary>
        /// <param name="insID"></param>
        public virtual async void AnsyTradeByInstrumentSwap(string instrument_id, int? from, int? to, int? limit)
        {

        }

        /// <summary>
        /// 下单动作
        /// </summary>
        /// <param name="order"></param>
        public virtual async void AnsyOrderSwap(OKExSDK.Models.Swap.OrderSingle order)
        {

        }

    }
}
