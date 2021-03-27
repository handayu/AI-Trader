using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace TestProxy
{
    public class CMyDemoProxy : BaseProxy
    {

        private CMyMDApi m_MyMDApi;



        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="proxyName"></param>
        public CMyDemoProxy(EXCHANGETHROUGH proxyThrough)
        {
            m_MyMDApi = new CMyMDApi();

            this.m_proxyThroughEnum = proxyThrough;
            this.m_OnSpiEventThread = new System.Threading.Thread(BroadCastSpiEvent);
            //..req
        }

        /// <summary>
        /// 广播父类事件/取队列上层广播
        /// </summary>
        private void BroadCastSpiEvent()
        {
            if (m_MyMDApi.SpiQueue == null || m_MyMDApi.SpiQueue.Count <= 0) return;
            while (true)
            {
                SpiStruct s;
                if (false == m_MyMDApi.SpiQueue.TryDequeue(out s)) continue;

                switch (s.spiEventEnum)
                {
                    case SPIEVNETEENUM.OnLogin:
                        OnLogin();
                        break;
                    case SPIEVNETEENUM.OnTick:
                        OnTick(s.spiObject as RspHistoryData);
                        break;
                        //........
                }
            }
        }

        public override void Init(ReqLoginData loginData)
        {
            if (!m_MyMDApi.ISMdInit)
            {
                m_MyMDApi = new CMyMDApi();
                m_MyMDApi.CreateMdApi();
                m_MyMDApi.RegisterSpi(m_MyMDApi);
                m_OnSpiEventThread.Start();

                m_MyMDApi.Init();

                //仿真调用
                m_MyMDApi.OnFrontConnected();

                m_MyMDApi.ISMdInit = true;
            }
        }

        public override void Login()
        {
            if (!m_MyMDApi.ISMdLogin)
            {
                //在这里仿真直接调用回调
                this.m_MyMDApi.ReqUserLogin();
                this.m_MyMDApi.OnRspUserLogin();
                m_MyMDApi.ISMdLogin = true;
            }
        }

        public override void Close()
        {
            if (m_MyMDApi.ISMdLogin)
            {
                //在这里仿真直接调用回调
                this.m_MyMDApi.ReqUserLogout();
                this.m_MyMDApi.OnRspUserLogout();
                m_MyMDApi.ISMdLogin = false;
            }
        }

        public override void SubScribe()
        {
            if(m_MyMDApi.ISMdInit && m_MyMDApi.ISMdLogin)
            {
                this.m_MyMDApi.OnRtnDepthMarketData();
            }
        }
    }
}
