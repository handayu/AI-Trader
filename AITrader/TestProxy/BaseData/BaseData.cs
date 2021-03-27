using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProxy
{
    public enum EXCHANGETHROUGH
    {
        CTP,
        IB,
        Tiger,
        HTZQ,
        Okex,
        MT4,
        Demo,
        TuShare,
        TianQin,
        IQFeed
    }

    public enum MARKETTYPE
    {
        Stock,
        Bond,
        Fund,
        Future,
        Option,
        CFD,
        Currency,
        Coin
    }

    public enum FRAME
    {
        Tick,
        Minute,
        Minute_5,
        Minute_10,
        Minute_15,
        Day,
        Week,
        Month
    }

    public class ReqHistoryData
    {
        public MARKETTYPE MarketType
        {
            get;
            set;
        }

        public string Code
        {
            get;
            set;
        }

        public FRAME Frame
        {
            get;
            set;
        }

        public DateTime StartDate
        {
            get;
            set;
        }

        public DateTime EndDate
        {
            get;
            set;
        }
    }

    public class RspHistoryData
    {
        public EXCHANGETHROUGH ExchangeThrough
        {
            get;
            set;
        }

        public MARKETTYPE MarketType
        {
            get;
            set;
        }

        public string Code
        {
            get;
            set;
        }

        public FRAME Frame
        {
            get;
            set;
        }

        public string TradingDate
        {
            get;
            set;
        }

        public string Open
        {
            get;
            set;
        }

        public string High
        {
            get;
            set;
        }

        public string Low
        {
            get;
            set;
        }

        public string Close
        {
            get;
            set;
        }
    }

    public class ReqLoginData
    {
        public string IP
        {
            get;
            set;
        }

        public string Port
        {
            get;
            set;

        }

        /// <summary>
        /// 扩展字段
        /// </summary>
        public string Exdata
        {
            get;
            set;
        }


    }
}
