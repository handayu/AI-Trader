using APIConnect;
using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using swap = OKExSDK.Models.Swap;

namespace BarMarker
{
    public class RenkoBarMarker
    {
        /// <summary>
        /// 砖块高度-合约
        /// </summary>
        private decimal m_boxSize = 0m;
        private string m_ins = string.Empty;

        /// <summary>
        /// 砖图和起始第一个tick有关，记录下来
        /// </summary>
        private TestData.KlineOkex m_firstTickMark = null;

        /// <summary>
        /// 记录前一根的renkobar，用于计算下一根renkoBar
        /// </summary>
        private TestData.KlineOkex m_preRenkoBar = null;

        /// <summary>
        /// RenkoBar发布器
        /// </summary>
        /// <param name="renkoBar"></param>
        public delegate void NewRenkoBarComingHandle(TestData.KlineOkex renkoBar);
        public event NewRenkoBarComingHandle NewRenkoBarComingEvent;

        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="ins"></param>
        /// <param name="boxSize"></param>
        public RenkoBarMarker(string ins, decimal boxSize)
        {
            if (boxSize <= 0 || ins == null || ins == string.Empty)
            {
                throw new Exception("the boxsize is low zero or ins is null");
            }

            if (ConnectManager.CreateInstance().CONNECTION == null)
            {
                throw new Exception("the connection is unconnect");
            }

            m_boxSize = boxSize;
            m_ins = ins;

            //订阅实时数据
            ConnectManager.CreateInstance().CONNECTION.AnsyRealDataEvent += AnsyTickerSubEvent;

        }

        /// <summary>
        /// 通过tick数据和Boxsize计算并对外发布renko数据
        /// </summary>
        /// <param name="args"></param>
        private void AnsyTickerSubEvent(AIEventArgs args)
        {
            if (args.ReponseMessage == RESONSEMESSAGE.HOLDMARKETDATA_FAILED) return;//如果返回错误，直接返回
            List<swap.Ticker> ticLiet = (List<swap.Ticker>)args.EventData;
            if (ticLiet == null) return;//如果返回为null。直接返回
            if (ticLiet.Count <= 0 || ticLiet[0].instrument_id == "") return;//如果行情为0.或无合约，返回

            foreach (swap.Ticker t in ticLiet)
            {
                if (t.instrument_id != m_ins) continue;//如果不是该合约，下一条

                if (m_firstTickMark == null)//记录第一笔tick最开始的一条数据
                {
                    TestData.KlineOkex k = new TestData.KlineOkex()
                    {
                        d = t.timestamp,
                        o = t.last,
                        h = t.last,
                        l = t.last,
                        c = t.last
                    };

                    m_firstTickMark = k;
                }
                else//已经记录开始计算
                {
                    if (m_preRenkoBar == null)//如果还没有发布第一根renkobar,在这里发布并记录作为前一根的renkoBar
                    {
                        //如果最新价<>第一笔+-boxsize ，发布第一根上涨下跌renko--，并记录，迭代
                        if (t.last >= m_firstTickMark.c + m_boxSize)
                        {
                            TestData.KlineOkex firstRenkoBar = new TestData.KlineOkex()
                            {
                                d = t.timestamp,
                                o = m_firstTickMark.o,
                                h = t.last,
                                l = m_firstTickMark.l,
                                c = t.last
                            };

                            m_preRenkoBar = firstRenkoBar;

                            //发布
                            SafeRiseNewRenkoBarComingEvent(firstRenkoBar);
                        }

                        if (t.last <= m_firstTickMark.c - m_boxSize)
                        {
                            TestData.KlineOkex firstRenkoBar = new TestData.KlineOkex()
                            {
                                d = t.timestamp,
                                o = m_firstTickMark.o,
                                h = m_firstTickMark.h,
                                l = t.last,
                                c = t.last
                            };

                            m_preRenkoBar = firstRenkoBar;

                            //发布
                            SafeRiseNewRenkoBarComingEvent(firstRenkoBar);
                        }
                    }
                    else//已经有了第一根，从第二根开始，发布的renko和前一根的状态有关
                    {   //无论前一根是阴线阳线，后一块发布都是在前一块的最高上加，最低上减
                        if (t.last >= m_preRenkoBar.h + m_boxSize)
                        {
                            TestData.KlineOkex nowRenkoBar = new TestData.KlineOkex()
                            {
                                d = t.timestamp,
                                o = m_preRenkoBar.h,
                                h = t.last,
                                l = m_preRenkoBar.h,
                                c = t.last
                            };

                            m_preRenkoBar = nowRenkoBar;

                            //发布
                            SafeRiseNewRenkoBarComingEvent(nowRenkoBar);
                        }
                        if (t.last <= m_preRenkoBar.l - m_boxSize)
                        {
                            TestData.KlineOkex nowRenkoBar = new TestData.KlineOkex()
                            {
                                d = t.timestamp,
                                o = m_preRenkoBar.l,
                                h = m_preRenkoBar.l,
                                l = t.last,
                                c = t.last
                            };

                            m_preRenkoBar = nowRenkoBar;

                            //发布
                            SafeRiseNewRenkoBarComingEvent(nowRenkoBar);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// 安全的发布renkoBar
        /// </summary>
        /// <param name="renkoBar"></param>
        private void SafeRiseNewRenkoBarComingEvent(TestData.KlineOkex renkoBar)
        {
            if (NewRenkoBarComingEvent != null)
            {
                NewRenkoBarComingEvent(renkoBar);
            }
        }

    }
}
