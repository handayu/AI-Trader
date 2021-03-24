using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace TestProxy
{
    public class CMyDemoProxy : BaseProxy
    {

        public delegate void OnFrontConnectedHandle();
        public event OnFrontConnectedHandle OnFrontConnectedEvent;

        public delegate void OnRspUserLoginHandle();
        public event OnRspUserLoginHandle OnRspUserLoginEvent;

        public delegate void OnRtnDataHandle(string data);
        public event OnRtnDataHandle OnRtnDataEvent;

        //开启一个线程，转发API上层的请求，做流控等限制，比如req(Enum,Object),在这个线程里转发到底层API请求里进行请求;
        //在这里开启一个新的线程，该线程主要用于捕获底层抛出的回调信息队列，用于上层转发；
        private System.Threading.Thread m_OnSpiEventThread;
        private System.Threading.Thread m_ReqEventThread;


        private CDemoMDApi m_demoMDApi;
        private CMyDemoMDSpi m_demoMDSpi;

        private bool m_isMDInit = false;
        public bool ISMdInit
        {
            get
            {
                return m_isMDInit;
            }
            set
            {
                m_isMDInit = value;
            }
        }

        private bool m_isMDLogin = false;
        public bool ISMdLogin
        {
            get
            {
                return m_isMDLogin;
            }
            set
            {
                m_isMDLogin = value;
            }
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="proxyName"></param>
        public CMyDemoProxy(EXCHANGETHROUGH proxyThrough)
        {
            this.m_proxyThroughEnum = proxyThrough;
            m_OnSpiEventThread = new System.Threading.Thread(BroadCastSpiEvent);
        }

        /// <summary>
        /// 广播父类事件/取队列上层广播
        /// </summary>
        private void BroadCastSpiEvent()
        {
            if (m_demoMDSpi.SpiQueue == null || m_demoMDSpi.SpiQueue.Count <= 0) return;
            while (true)
            {
                SpiStruct s;
                if (false == m_demoMDSpi.SpiQueue.TryDequeue(out s)) continue;

                switch (s.spiEventEnum)
                {
                    case SPIEVNETEENUM.OnConnected:
                        if (OnFrontConnectedEvent != null) OnFrontConnectedEvent();
                        break;
                    case SPIEVNETEENUM.OnRspLogin:
                        if (OnRspUserLoginEvent != null) OnRspUserLoginEvent();
                        break;
                    case SPIEVNETEENUM.OnRtnData:
                        if (OnRtnDataEvent != null) OnRtnDataEvent((string)s.spiObject);
                        break;
                        //........
                }
            }
        }

        public virtual void InitMDApi()
        {
            if (!m_isMDInit)
            {
                m_demoMDSpi = new CMyDemoMDSpi();
                m_demoMDApi = CDemoMDApi.CreateMdApi();
                m_demoMDApi.RegisterSpi(m_demoMDSpi);
                m_OnSpiEventThread.Start();

                m_demoMDApi.Init();

                //仿真调用
                m_demoMDSpi.OnFrontConnected();

                m_isMDInit = true;
            }
        }

        public void InitTradeApi()
        {
        }

        public void ReqMDLogin()
        {
            if (!m_isMDLogin)
            {
                //在这里仿真直接调用回调
                this.m_demoMDApi.ReqUserLogin();
                this.m_demoMDSpi.OnRspUserLogin();
                m_isMDLogin = true;
            }
        }

        public void ReqMDLogOut()
        {
            if (m_isMDLogin)
            {
                //在这里仿真直接调用回调
                this.m_demoMDApi.ReqUserLogout();
                this.m_demoMDSpi.OnRspUserLogout();
                m_isMDLogin = false;
            }
        }

        public void SubscribeMarketData(string[] pInstrumentsStr, int count)
        {
            if(m_isMDInit && m_isMDLogin)
            {
                m_demoMDSpi.OnRtnDepthMarketData();
            }
        }
    }
}
