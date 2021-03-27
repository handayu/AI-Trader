using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TestProxy
{
    class CToShareProxy: BaseProxy
    {
        private CToShareAPI m_api;

        private System.Threading.Thread m_OnHisDataThread;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="proxyName"></param>
        public CToShareProxy(EXCHANGETHROUGH proxyThrough)
        {
            this.m_proxyThroughEnum = proxyThrough;
            m_api = new CToShareAPI();
            m_OnHisDataThread = new System.Threading.Thread(new ParameterizedThreadStart(BrocastHisData));
        }

        /// <summary>
        /// 线程广播历史数据
        /// </summary>
        private void BrocastHisData(object hDParam)
        {
            StockData dT = m_api.QueryHistory(hDParam as ReqHistoryData);
            List<List<String>> dList = dT.Items;

            for (int i = 0; i < dList.Count; i++)
            {
                RspHistoryData hD = new RspHistoryData();
                hD.ExchangeThrough = EXCHANGETHROUGH.TuShare;
                hD.MarketType = MARKETTYPE.Stock;
                hD.Frame = FRAME.Day;
                hD.TradingDate = dList[i][1];
                hD.Code = dT.StockName;
                hD.Open = dList[i][2];
                hD.High = dList[i][3];
                hD.Low = dList[i][4];
                hD.Close = dList[i][5];

                OnTick(hD);
            }
        }

        /// <summary>
        /// 查询历史重载-可以直接调基类回调返回
        /// </summary>
        public override void QueryHistory(ReqHistoryData hisData)
        {
            m_OnHisDataThread.Start(hisData);
        }

        public override void Init(ReqLoginData loginData)
        {
            m_api.Init(loginData);
        }

    }
}
