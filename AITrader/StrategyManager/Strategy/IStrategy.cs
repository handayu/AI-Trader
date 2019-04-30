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
        public delegate void OnTickHandle(swap.Ticker t);
        public event OnTickHandle OnTickEvent;

        public bool ISSTRATEGYGOING
        {
            get
            {
                return m_isStart;
            }
        }


        public void Start()
        {
            m_isStart = true;
        }

        public void Stop()
        {
            m_isStart = false;
        }

        public IStrategy()
        {
            //订阅行情-成家委托-bar等

            ConnectManager.CreateInstance().CONNECTION.AnsyRealDataEvent += AnsyTickerSubEvent;

        }

        private void AnsyTickerSubEvent(AIEventArgs args)
        {
            if (m_isStart == false) return;

            if(args.ReponseMessage == RESONSEMESSAGE.HOLDMARKETDATA_SUCCESS)
            {
                List<swap.Ticker> ticList = (List<swap.Ticker>)args.EventData;
                foreach(swap.Ticker t in ticList)
                {
                    if(t.instrument_id.CompareTo(m_tradeInstrument) == 0)
                    {
                        OnTick(t);
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
        public virtual void OnTick(swap.Ticker t)
        {
            if(OnTickEvent != null)
            {
                OnTickEvent(t);
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
        public virtual void OnOrder(swap.Ticker t)
        {

        }

        /// <summary>
        /// 时间触发
        /// </summary>
        /// <param name="t"></param>
        public virtual void OnTimer(swap.Ticker t)
        {

        }
    }
}
