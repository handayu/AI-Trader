using APIConnect;
using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using swap = OKExSDK.Models.Swap;

namespace Strategy
{
    public class IStrategy
    {
        /// <summary>
        /// 策略基础信息
        /// </summary>
        protected string m_tradeInstrument = string.Empty;
        protected int m_frame = int.MinValue;

        protected bool m_isStart = false;

        /// <summary>
        /// 对外广播Ontick触发
        /// </summary>
        public delegate void OnTickHandle(swap.Ticker t, string StrategyName);
        public event OnTickHandle OnTickEvent;

        /// <summary>
        /// 对外广播日志-交易日志
        /// </summary>
        public delegate void OnLogHandle(string strategyLogText);
        public event OnLogHandle OnLogEvent;

        /// <summary>
        /// 对外广播OnOrder触发
        /// </summary>
        public delegate void OnOrderHandle(Common.SwapOrderReturn orderReturn, string StrategyName);
        public event OnOrderHandle OnOrderEvent;

        public bool ISSTRATEGYGOING
        {
            get
            {
                return m_isStart;
            }
        }


        public void Start()
        {
            SafeRiseLogEvent("策略开始...");
            m_isStart = true;
        }

        public void Stop()
        {
            SafeRiseLogEvent("停止策略...");
            m_isStart = false;
        }

        public IStrategy()
        {
            //订阅行情-成家委托-bar等

            if (ConnectManager.CreateInstance().CONNECTION != null)
            {
                ConnectManager.CreateInstance().CONNECTION.AnsyRealDataEvent += AnsyTickerSubEvent;
                ConnectManager.CreateInstance().CONNECTION.AnsyMakeOrderEvent += AnsyMakeOrderSubEvent;
                ConnectManager.CreateInstance().CONNECTION.AnsyOrderEvent += AnsyOrderSubEvent;
                ConnectManager.CreateInstance().CONNECTION.AnsyTradeEvent += AnsyTradeSubEvent;
                ConnectManager.CreateInstance().CONNECTION.AnsyPositionEvent += AnsyPositionSubEvent;
            }
        }

        #region 部位-成交-委托-下单回报回调
        /// <summary>
        /// 部位查询？不知道是否有CTP一样的回调订阅
        /// </summary>
        /// <param name="args"></param>
        private void AnsyPositionSubEvent(AIEventArgs args)
        {

        }

        /// <summary>
        /// 交易查询?不知道是否有CTP一样的回调订阅
        /// </summary>
        /// <param name="args"></param>
        private void AnsyTradeSubEvent(AIEventArgs args)
        {

        }

        /// <summary>
        /// 委托查询?不知道是否有CTP一样的回调订阅
        /// </summary>
        /// <param name="args"></param>
        private void AnsyOrderSubEvent(AIEventArgs args)
        {

        }

        /// <summary>
        /// 下单回调，任何地方下单这里会有返回
        /// </summary>
        /// <param name="args"></param>
        private void AnsyMakeOrderSubEvent(AIEventArgs args)
        {
            if (args == null) return;

            if (args.ReponseMessage == RESONSEMESSAGE.HOLDMAKEORDERACTION_SUCCESS)
            {
                Common.SwapOrderReturn orderReturn = (Common.SwapOrderReturn)args.EventData;

                if (orderReturn.instrument.CompareTo(m_tradeInstrument) == 0)
                {
                    OnOrder(orderReturn,"");
                }
            }
        }

        #endregion

        private void AnsyTickerSubEvent(AIEventArgs args)
        {
            if (m_isStart == false) return;

            if (args.ReponseMessage == RESONSEMESSAGE.HOLDMARKETDATA_SUCCESS)
            {
                List<swap.Ticker> ticList = (List<swap.Ticker>)args.EventData;
                foreach (swap.Ticker t in ticList)
                {
                    if (t.instrument_id.CompareTo(m_tradeInstrument) == 0)
                    {
                        OnTick(t, "");
                    }
                    else
                    {
                        continue;
                    }
                }
            }
        }


        /// <summary>
        /// tic触发
        /// </summary>
        /// <param name="t"></param>
        public virtual void OnTick(swap.Ticker t, string strategyName)
        {
            if (OnTickEvent != null)
            {
                OnTickEvent(t, strategyName);
            }
        }

        /// <summary>
        /// Bar触发
        /// </summary>
        /// <param name="t"></param>
        public virtual void OnBar(swap.Ticker t)
        {

        }

        /// <summary>
        /// 交易触发
        /// </summary>
        /// <param name="t"></param>
        public virtual void OnTrade(swap.Ticker t)
        {

        }

        /// <summary>
        /// 订单触发
        /// </summary>
        /// <param name="t"></param>
        public virtual void OnOrder(Common.SwapOrderReturn orderReturn,string strategyName)
        {
            if (OnOrderEvent != null)
            {
                OnOrderEvent(orderReturn, strategyName);
            }
        }


        public void SafeRiseLogEvent(string strategyLogText)
        {
            if(OnLogEvent != null)
            {
                OnLogEvent(strategyLogText);
            }
        }
    }
}
