using APIConnect;
using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using swap = OKExSDK.Models.Swap;

namespace WindowsFormsApp1
{
    public class BarMarker
    {
        private List<TestData.KlineOkex> m_1MinBar = new List<TestData.KlineOkex>();
        private List<TestData.KlineOkex> m_5MinBar = new List<TestData.KlineOkex>();
        private List<TestData.KlineOkex> m_15MinBar = new List<TestData.KlineOkex>();
        private List<TestData.KlineOkex> m_30MinBar = new List<TestData.KlineOkex>();
        private List<TestData.KlineOkex> m_60MinBar = new List<TestData.KlineOkex>();

        /// <summary>
        /// 完整的图表信息元素
        /// </summary>
        private ChartInfo m_ChartInfo = null;

        /// <summary>
        /// 砖图和起始第一个tick有关，记录下来
        /// </summary>
        private TestData.KlineOkex m_firstTickMark = null;

        /// <summary>
        /// 记录前一根的renkobar，用于计算下一根renkoBar
        /// </summary>
        private TestData.KlineOkex m_preRenkoBar = null;

        /// <summary>
        /// Bar发布器
        /// </summary>
        /// <param name="renkoBar"></param>
        public delegate void BarComingHandle(TestData.KlineOkex Bar, DATAFRAME dataFrame);
        public event BarComingHandle BarComingEvent;

        /// <summary>
        /// 外部属性，可以实时修改图表信息用于发布
        /// </summary>
        public ChartInfo CHARTINFO
        {
            get
            {
                return m_ChartInfo;
            }

            set
            {
                m_ChartInfo = value;
            }
        }

        /// <summary>
        /// 外部改变renkobar计算的boxsize的时候，要实时把起始值修改为
        /// 当前最新的起始点，开始计算
        /// </summary>
        public void ResetRenkoStartPrice()
        {
            m_firstTickMark = null;
            m_preRenkoBar = null;
        }

        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="ins"></param>
        /// <param name="boxSize"></param>
        public BarMarker(ChartInfo info)
        {
            if (info == null)
            {
                throw new Exception("the info is null");
            }

            if (info.Instrument.CompareTo(string.Empty) == 0)
            {
                throw new Exception("the Instrument is is null");
            }

            if (info.DataFrame == DATAFRAME.UNKNOW || info.CandleType == CANDLETYPE.UNKNOW)
            {
                throw new Exception("the DataFrame or CandleType is is null");
            }

            if (info.CandleType == CANDLETYPE.RENKOBAR && info.RenkoBarBoxSize <= 0)
            {
                throw new Exception("the CandleType is RENKOBAR but  RenkoBarBoxSize is low zero");
            }

            if (ConnectManager.CreateInstance().CONNECTION == null)
            {
                throw new Exception("the connection is unconnect");
            }

            m_ChartInfo = info;

            //订阅实时数据
            ConnectManager.CreateInstance().CONNECTION.AnsyRealDataEvent += AnsyTickerSubEvent;

        }

        /// <summary>
        /// 通过tick数据合成相关Bar和renkoBar对外发布
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
                if (t.instrument_id != m_ChartInfo.Instrument) continue;//如果不是该合约，下一条

                switch (m_ChartInfo.CandleType)
                {
                    //合成K线-按照周期分类发布
                    case CANDLETYPE.KLINEBAR:

                        //重置一下renkobar的初始状态
                        m_firstTickMark = null;
                        m_preRenkoBar = null;

                        if (m_ChartInfo.DataFrame == DATAFRAME.MIN1)
                        {
                            PublishKline1Bar(t, m_ChartInfo.DataFrame);
                        }

                        if (m_ChartInfo.DataFrame == DATAFRAME.MIN5)
                        {
                            PublishKline5Bar(t, m_ChartInfo.DataFrame);
                        }

                        if (m_ChartInfo.DataFrame == DATAFRAME.MIN15)
                        {
                            PublishKline15Bar(t, m_ChartInfo.DataFrame);
                        }


                        if (m_ChartInfo.DataFrame == DATAFRAME.MIN30)
                        {
                            PublishKline30Bar(t, m_ChartInfo.DataFrame);
                        }


                        if (m_ChartInfo.DataFrame == DATAFRAME.HOUR1)
                        {
                            PublishKline60Bar(t, m_ChartInfo.DataFrame);
                        }

                        break;

                    //合成renko
                    case CANDLETYPE.RENKOBAR:

                        PublishRenkoBar(t);

                        break;

                    case CANDLETYPE.UNKNOW:

                        break;
                }
            }
        }

        #region 在这里合成K线发布
        /// <summary>
        /// 发布30分K线--分钟数是否==30计算
        /// </summary>
        /// <param name="ticLiet"></param>
        private void PublishKline30Bar(swap.Ticker t, DATAFRAME frame)
        {
            //记录第一笔进来的tick的时间戳，
            if (m_30MinBar.Count <= 0)
            {
                TestData.KlineOkex Bar30 = new TestData.KlineOkex()
                {
                    insment = t.instrument_id,
                    d = t.timestamp,
                    o = t.last,
                    h = t.last,
                    l = t.last,
                    c = t.last,
                    unkonwn1 = t.high_24h,
                    unkonwn2 = t.high_24h,
                };

                m_30MinBar.Add(Bar30);
            }
            else
            {
                //如果分钟不能被5整除，比较开高低收合成--如果不相等了，直接发布，并把这个不相等的第一笔作为最新的一个起始点
                if (t.timestamp.Minute != 0 || t.timestamp.Minute != 30)
                {
                    if (t.last >= m_30MinBar[0].h)
                    {
                        m_30MinBar[0].h = t.last;
                    }

                    if (t.last <= m_30MinBar[0].l)
                    {
                        m_30MinBar[0].l = t.last;
                    }
                }
                else
                {
                    m_30MinBar[0].c = t.last;

                    //克隆一个--因为发布出去之后，List里的引用值会改变
                    TestData.KlineOkex BarClone30Min = new TestData.KlineOkex()
                    {
                        insment = m_30MinBar[0].insment,
                        d = m_30MinBar[0].d,
                        o = m_30MinBar[0].o,
                        h = m_30MinBar[0].h,
                        l = m_30MinBar[0].l,
                        c = m_30MinBar[0].c,
                        unkonwn1 = m_30MinBar[0].unkonwn1,
                        unkonwn2 = m_30MinBar[0].unkonwn2,
                    };

                    SafeRiseBarComingEvent(BarClone30Min, frame);

                    m_30MinBar[0].insment = t.instrument_id;
                    m_30MinBar[0].d = t.timestamp;
                    m_30MinBar[0].o = t.last;
                    m_30MinBar[0].h = t.last;
                    m_30MinBar[0].l = t.last;
                    m_30MinBar[0].c = t.last;
                    m_30MinBar[0].unkonwn1 = t.high_24h;
                    m_30MinBar[0].unkonwn2 = t.high_24h;

                }
            }
        }

        /// <summary>
        /// 发布60分K线
        /// </summary>
        /// <param name="ticLiet"></param>
        private void PublishKline60Bar(swap.Ticker t, DATAFRAME frame)
        {
            //记录第一笔进来的tick的时间戳，
            if (m_60MinBar.Count <= 0)
            {
                TestData.KlineOkex Bar60 = new TestData.KlineOkex()
                {
                    insment = t.instrument_id,
                    d = t.timestamp,
                    o = t.last,
                    h = t.last,
                    l = t.last,
                    c = t.last,
                    unkonwn1 = t.high_24h,
                    unkonwn2 = t.high_24h,
                };

                m_60MinBar.Add(Bar60);
            }
            else
            {
                //如果分钟不能被5整除，比较开高低收合成--如果不相等了，直接发布，并把这个不相等的第一笔作为最新的一个起始点
                if (t.timestamp.Hour == m_60MinBar[0].d.Hour)
                {
                    if (t.last >= m_60MinBar[0].h)
                    {
                        m_60MinBar[0].h = t.last;
                    }

                    if (t.last <= m_60MinBar[0].l)
                    {
                        m_60MinBar[0].l = t.last;
                    }
                }
                else
                {
                    m_60MinBar[0].c = t.last;

                    //克隆一个--因为发布出去之后，List里的引用值会改变
                    TestData.KlineOkex BarClone60Min = new TestData.KlineOkex()
                    {
                        insment = m_60MinBar[0].insment,
                        d = m_60MinBar[0].d,
                        o = m_60MinBar[0].o,
                        h = m_60MinBar[0].h,
                        l = m_60MinBar[0].l,
                        c = m_60MinBar[0].c,
                        unkonwn1 = m_60MinBar[0].unkonwn1,
                        unkonwn2 = m_60MinBar[0].unkonwn2,
                    };

                    SafeRiseBarComingEvent(BarClone60Min, frame);

                    m_60MinBar[0].insment = t.instrument_id;
                    m_60MinBar[0].d = t.timestamp;
                    m_60MinBar[0].o = t.last;
                    m_60MinBar[0].h = t.last;
                    m_60MinBar[0].l = t.last;
                    m_60MinBar[0].c = t.last;
                    m_60MinBar[0].unkonwn1 = t.high_24h;
                    m_60MinBar[0].unkonwn2 = t.high_24h;

                }
            }
        }

        /// <summary>
        /// 发布15分K线--分钟线能被15整除
        /// </summary>
        /// <param name="ticLiet"></param>
        private void PublishKline15Bar(swap.Ticker t, DATAFRAME frame)
        {
            //记录第一笔进来的tick的时间戳，更新分钟相同情况下的开高低收，直到分钟能被5整除发布，然后重新开始
            if (m_15MinBar.Count <= 0)
            {
                TestData.KlineOkex Bar15 = new TestData.KlineOkex()
                {
                    insment = t.instrument_id,
                    d = t.timestamp,
                    o = t.last,
                    h = t.last,
                    l = t.last,
                    c = t.last,
                    unkonwn1 = t.high_24h,
                    unkonwn2 = t.high_24h,
                };

                m_15MinBar.Add(Bar15);
            }
            else
            {
                //如果分钟不能被5整除，比较开高低收合成--如果不相等了，直接发布，并把这个不相等的第一笔作为最新的一个起始点
                if (t.timestamp.Minute % 15 != 0)
                {
                    if (t.last >= m_15MinBar[0].h)
                    {
                        m_15MinBar[0].h = t.last;
                    }

                    if (t.last <= m_15MinBar[0].l)
                    {
                        m_15MinBar[0].l = t.last;
                    }
                }
                else
                {
                    m_15MinBar[0].c = t.last;

                    //克隆一个--因为发布出去之后，List里的引用值会改变
                    TestData.KlineOkex BarClone15Min = new TestData.KlineOkex()
                    {
                        insment = m_15MinBar[0].insment,
                        d = m_15MinBar[0].d,
                        o = m_15MinBar[0].o,
                        h = m_15MinBar[0].h,
                        l = m_15MinBar[0].l,
                        c = m_15MinBar[0].c,
                        unkonwn1 = m_15MinBar[0].unkonwn1,
                        unkonwn2 = m_15MinBar[0].unkonwn2,
                    };

                    SafeRiseBarComingEvent(BarClone15Min, frame);

                    m_15MinBar[0].insment = t.instrument_id;
                    m_15MinBar[0].d = t.timestamp;
                    m_15MinBar[0].o = t.last;
                    m_15MinBar[0].h = t.last;
                    m_15MinBar[0].l = t.last;
                    m_15MinBar[0].c = t.last;
                    m_15MinBar[0].unkonwn1 = t.high_24h;
                    m_15MinBar[0].unkonwn2 = t.high_24h;

                }
            }
        }

        /// <summary>
        /// 发布5MinK--分钟能否被5整除的原理
        /// </summary>
        /// <param name="ticLiet"></param>
        private void PublishKline5Bar(swap.Ticker t, DATAFRAME frame)
        {
            //记录第一笔进来的tick的时间戳，更新分钟相同情况下的开高低收，直到分钟能被5整除发布，然后重新开始
            if (m_5MinBar.Count <= 0)
            {
                TestData.KlineOkex Bar5 = new TestData.KlineOkex()
                {
                    insment = t.instrument_id,
                    d = t.timestamp,
                    o = t.last,
                    h = t.last,
                    l = t.last,
                    c = t.last,
                    unkonwn1 = t.high_24h,
                    unkonwn2 = t.high_24h,
                };

                m_5MinBar.Add(Bar5);
            }
            else
            {
                //如果分钟不能被5整除，比较开高低收合成--如果不相等了，直接发布，并把这个不相等的第一笔作为最新的一个起始点
                if (t.timestamp.Minute % 5 != 0)
                {
                    if (t.last >= m_5MinBar[0].h)
                    {
                        m_5MinBar[0].h = t.last;
                    }

                    if (t.last <= m_5MinBar[0].l)
                    {
                        m_5MinBar[0].l = t.last;
                    }
                }
                else
                {
                    m_5MinBar[0].c = t.last;

                    //克隆一个--因为发布出去之后，List里的引用值会改变
                    TestData.KlineOkex BarClone5Min = new TestData.KlineOkex()
                    {
                        insment = m_5MinBar[0].insment,
                        d = m_5MinBar[0].d,
                        o = m_5MinBar[0].o,
                        h = m_5MinBar[0].h,
                        l = m_5MinBar[0].l,
                        c = m_5MinBar[0].c,
                        unkonwn1 = m_5MinBar[0].unkonwn1,
                        unkonwn2 = m_5MinBar[0].unkonwn2,
                    };

                    SafeRiseBarComingEvent(BarClone5Min, frame);

                    m_5MinBar[0].insment = t.instrument_id;
                    m_5MinBar[0].d = t.timestamp;
                    m_5MinBar[0].o = t.last;
                    m_5MinBar[0].h = t.last;
                    m_5MinBar[0].l = t.last;
                    m_5MinBar[0].c = t.last;
                    m_5MinBar[0].unkonwn1 = t.high_24h;
                    m_5MinBar[0].unkonwn2 = t.high_24h;

                }
            }
        }

        /// <summary>
        /// 发布1MinK--分钟进行比较的原理
        /// </summary>
        /// <param name="ticLiet"></param>
        private void PublishKline1Bar(swap.Ticker t, DATAFRAME frame)
        {
            //记录第一笔进来的tick的时间戳，更新分钟相同情况下的开高低收，直到分钟不再一样，14:00:59  14:01:00驱动推送上一分钟的K线
            if (m_1MinBar.Count <= 0)
            {
                TestData.KlineOkex Bar1 = new TestData.KlineOkex()
                {
                    insment = t.instrument_id,
                    d = t.timestamp,
                    o = t.last,
                    h = t.last,
                    l = t.last,
                    c = t.last,
                    unkonwn1 = t.high_24h,
                    unkonwn2 = t.high_24h,
                };

                m_1MinBar.Add(Bar1);
            }
            else
            {
                //如果分钟数相等的话，比较开高低收合成--如果不相等了，直接发布，并把这个不相等的第一笔作为最新的一个起始点
                if (t.timestamp.Minute == m_1MinBar[0].d.Minute)
                {
                    if (t.last >= m_1MinBar[0].h)
                    {
                        m_1MinBar[0].h = t.last;
                    }

                    if (t.last <= m_1MinBar[0].l)
                    {
                        m_1MinBar[0].l = t.last;
                    }
                }
                else
                {
                    m_1MinBar[0].c = t.last;

                    //克隆一个--因为发布出去之后，List里的引用值会改变
                    TestData.KlineOkex BarClone1Min = new TestData.KlineOkex()
                    {
                        insment = m_1MinBar[0].insment,
                        d = m_1MinBar[0].d,
                        o = m_1MinBar[0].o,
                        h = m_1MinBar[0].h,
                        l = m_1MinBar[0].l,
                        c = m_1MinBar[0].c,
                        unkonwn1 = m_1MinBar[0].unkonwn1,
                        unkonwn2 = m_1MinBar[0].unkonwn2,
                    };

                    SafeRiseBarComingEvent(BarClone1Min, frame);

                    m_1MinBar[0].insment = t.instrument_id;
                    m_1MinBar[0].d = t.timestamp;
                    m_1MinBar[0].o = t.last;
                    m_1MinBar[0].h = t.last;
                    m_1MinBar[0].l = t.last;
                    m_1MinBar[0].c = t.last;
                    m_1MinBar[0].unkonwn1 = t.high_24h;
                    m_1MinBar[0].unkonwn2 = t.high_24h;

                }
            }

        }


        /// <summary>
        /// 发布RenkoBar
        /// </summary>
        /// <param name="ticLiet"></param>
        private void PublishRenkoBar(swap.Ticker t)
        {
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
                    if (t.last >= m_firstTickMark.c + m_ChartInfo.RenkoBarBoxSize)
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
                        SafeRiseBarComingEvent(firstRenkoBar, m_ChartInfo.DataFrame);
                    }

                    if (t.last <= m_firstTickMark.c - m_ChartInfo.RenkoBarBoxSize)
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
                        SafeRiseBarComingEvent(firstRenkoBar, m_ChartInfo.DataFrame);
                    }
                }
                else//已经有了第一根，从第二根开始，发布的renko和前一根的状态有关
                {   //无论前一根是阴线阳线，后一块发布都是在前一块的最高上加，最低上减
                    if (t.last >= m_preRenkoBar.h + m_ChartInfo.RenkoBarBoxSize)
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
                        SafeRiseBarComingEvent(nowRenkoBar, m_ChartInfo.DataFrame);
                    }
                    if (t.last <= m_preRenkoBar.l - m_ChartInfo.RenkoBarBoxSize)
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
                        SafeRiseBarComingEvent(nowRenkoBar, m_ChartInfo.DataFrame);
                    }
                }
            }
        }

        #endregion

        /// <summary>
        /// 安全的发布Bar
        /// </summary>
        /// <param name="Bar"></param>
        private void SafeRiseBarComingEvent(TestData.KlineOkex Bar, DATAFRAME dataFrame)
        {
            if (BarComingEvent != null)
            {
                BarComingEvent(Bar, dataFrame);
            }
        }
    }
}
