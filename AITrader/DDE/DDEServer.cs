using APIConnect;
using Common;
using NDde.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using swap = OKExSDK.Models.Swap;

namespace DDE
{
    /// <summary>
    /// DDEServer服务
    /// </summary>
    public class DDEServer : DdeServer
    {
        public delegate void MarketDataRealCallHandle();
        public event MarketDataRealCallHandle MarketDataRealCallEvent;

        private System.Threading.Thread m_adviseThread = null;

        //private string m_service = "";//服务名
        private string m_topic = "";//主题
        private List<swap.Instrument> m_insList = null;//推送的合约

        /// <summary>
        /// 每个合约对象都有一个自己的行情队列
        /// </summary>
        private Dictionary<swap.Instrument, Queue<swap.Ticker>> m_insTickerQueue = new Dictionary<swap.Instrument, Queue<swap.Ticker>>();

        /// <summary>
        /// 父类构造--MT4|BID*
        /// MT4为Service,Topic为BID
        /// </summary>
        /// <param name="service"></param>
        public DDEServer(string service, string topic, List<swap.Instrument> insList) : base(service)
        {
            if (topic == "")
            {
                throw new Exception("推送的Topic不能为null,请重新设置");
            }
            else
            {
                m_topic = topic;
            }

            if (service == "")
            {
                throw new Exception("推送的Service不能为null,请重新设置");
            }

            if (insList == null || insList.Count <= 0)
            {
                throw new Exception("推送的insList不能为null,请重新设置");
            }
            else
            {
                m_insList = insList;
            }

            //直接生成所有永续合约的队列
            foreach (swap.Instrument ins in m_insList)
            {
                Queue<swap.Ticker> tic = new Queue<swap.Ticker>();
                m_insTickerQueue.Add(ins, tic);
            }

            m_adviseThread = new System.Threading.Thread(ThreadAdvise);
            m_adviseThread.Start();

            //订阅实时行情,进入队列,客户端订阅之后按照item回推
            ConnectManager.CreateInstance().CONNECTION.AnsyRealDataEvent += AnsyRealDataSubEvent;

        }

        /// <summary>
        /// 实时行情回调
        /// </summary>
        /// <param name="args"></param>
        private void AnsyRealDataSubEvent(AIEventArgs args)
        {
            if (args.ReponseMessage == RESONSEMESSAGE.HOLDMARKETDATA_SUCCESS)
            {
                List<swap.Ticker> tikList = (List<swap.Ticker>)args.EventData;

                foreach (swap.Ticker t in tikList)
                {
                    //去Dic里面查找，如果没找到对象Ins的Que生成一个，并加入第一条--如果找到了，直接加入到队列
                    foreach (KeyValuePair<swap.Instrument, Queue<swap.Ticker>> kv in m_insTickerQueue)
                    {
                        swap.Instrument ins = kv.Key;
                        Queue<swap.Ticker> que = kv.Value;

                        if (ins.instrument_id == t.instrument_id)
                        {
                            m_insTickerQueue[ins].Enqueue(t);

                            //说明行情正在正常推送，没有中断
                            RaiseCallRealDataEvent();
                        }
                    }
                }
            }
        }

        public void RaiseCallRealDataEvent()
        {
            if(this.MarketDataRealCallEvent !=null)
            {
                MarketDataRealCallEvent();
            }
        }

        /// <summary>
        /// 客户端订阅，CallBack
        /// </summary>
        /// <param name="topic"></param>//BID
        /// <param name="item"></param>//USDJPY
        /// <param name="format"></param>
        /// <returns></returns>
        protected override byte[] OnAdvise(string topic, string item, int format)
        {
            //在这里根据客户订阅的topic分类回推回去
            string str = "";
            if (topic.CompareTo(m_topic) != 0) return Encoding.Default.GetBytes(str);//BID

            foreach (KeyValuePair<swap.Instrument, Queue<swap.Ticker>> kv in m_insTickerQueue)
            {
                if (item.CompareTo(kv.Key.instrument_id) != 0) continue;

                Queue<swap.Ticker> tickerBack = kv.Value;
                if (tickerBack != null && tickerBack.Count > 0)
                {
                    swap.Ticker lastTic = tickerBack.Dequeue();
                    string lastPrice = lastTic.last.ToString();
                    byte[] b = Encoding.Default.GetBytes(lastPrice);
                    return b;
                }

            }

            return Encoding.Default.GetBytes(str);//BID
        }

        /// <summary>
        /// 服务端线程推送线程
        /// </summary>
        public void ThreadAdvise()
        {
            this.Register();
            while (true)
            {
                try
                {
                    AdviseTopic(m_insList);
                    System.Threading.Thread.Sleep(50);
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
        }

        public void AdviseTopic(List<swap.Instrument> insList)
        {
            if (insList == null || insList.Count <= 0)
            {
                return;
            }

            foreach (swap.Instrument ins in insList)
            {
                this.Advise(m_topic, ins.instrument_id);
            }
        }
    }
}
