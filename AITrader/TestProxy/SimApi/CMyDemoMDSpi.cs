using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProxy
{

    public enum SPIEVNETEENUM
    {
        OnConnected,
        OnDisConnected,
        OnRspLogin,
        OnRspLogout,
        OnRspSubscribe,
        OnRtnData
    }

    public struct SpiStruct
    {
        public SPIEVNETEENUM spiEventEnum;

        public Object spiObject;
    }


    public class CMyDemoMDSpi : CBaseDemoMDSpi
    {
        /// <summary>
        /// 线程安全的回调队列
        /// </summary>
        private ConcurrentQueue<SpiStruct> m_spiQueue = new ConcurrentQueue<SpiStruct>();

        /// <summary>
        /// 对外属性
        /// </summary>
        public ConcurrentQueue<SpiStruct> SpiQueue
        {
            get
            {
                return m_spiQueue;
            }
        }

        //虚拟队列回推行情
        private System.Threading.Thread m_OnMarketDataEvent;

        public CMyDemoMDSpi()
        {
            m_OnMarketDataEvent = new System.Threading.Thread(BroadCastMarketdataEvent);
        }

        public override void OnFrontConnected()
        {
            SpiStruct s;
            s.spiEventEnum = SPIEVNETEENUM.OnConnected;
            s.spiObject = null;
            m_spiQueue.Enqueue(s);

        }

        public override void OnFrontDisconnected(int nReason)
        {
            SpiStruct s;
            s.spiEventEnum = SPIEVNETEENUM.OnDisConnected;
            s.spiObject = nReason;
            m_spiQueue.Enqueue(s);
        }

        public override void OnHeartBeatWarning(int nTimeLapse)
        {
        }

        public override void OnRspUserLogin()
        {
            SpiStruct s;
            s.spiEventEnum = SPIEVNETEENUM.OnDisConnected;
            s.spiObject = "";
            m_spiQueue.Enqueue(s);
        }

        public override void OnRspUserLogout()
        {
            SpiStruct s;
            s.spiEventEnum = SPIEVNETEENUM.OnDisConnected;
            s.spiObject = "";
            m_spiQueue.Enqueue(s);
        }

        public override void OnRspError()
        {
        }

        public override void OnRspSubMarketData()
        {
            SpiStruct s;
            s.spiEventEnum = SPIEVNETEENUM.OnDisConnected;
            s.spiObject = "";
            m_spiQueue.Enqueue(s);
        }

        public override void OnRspUnSubMarketData()
        {
        }

        public override void OnRtnDepthMarketData()
        {
            m_OnMarketDataEvent.Start();
        }

        private void BroadCastMarketdataEvent()
        {
            while(true)
            {
                SpiStruct s;
                s.spiEventEnum = SPIEVNETEENUM.OnRtnData;
                s.spiObject = "20210324 600001 12.34 13.35 18.89 11.00 2300000";
                m_spiQueue.Enqueue(s);

                System.Threading.Thread.Sleep(1000);
            }
        }
    }
}
