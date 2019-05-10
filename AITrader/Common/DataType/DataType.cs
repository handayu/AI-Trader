using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using swap = OKExSDK.Models.Swap;
using OKExSDK;
using OKExSDK.Models;
using OKExSDK.Models.Account;
using OKExSDK.Models.Ett;
using OKExSDK.Models.Futures;
using OKExSDK.Models.Margin;
using OKExSDK.Models.Spot;
using OKExSDK.Models.General;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Common
{
    public class ItemList
    {
        /// <summary>
        /// Item列表
        /// </summary>
        public static List<swap.Instrument> Item { get; set; }
    }

    /// <summary>
    /// 数据周期类型
    /// </summary>
    public enum DATAFRAME
    {
        TICK = 0,
        MIN5,
        MIN1,
        MIN15,
        MIN30,
        HOUR1,
        HOUR4,
        DAY1,
        WEEK1,
        MONTH1,
        UNKNOW
    };

    /// <summary>
    /// K线类型
    /// </summary>
    public enum CANDLETYPE
    {
        KLINEBAR = 0,
        RENKOBAR,
        UNKNOW
    };

    public class ChartInfo
    {
        public string Instrument
        {
            get;
            set;
        }

        public DATAFRAME DataFrame
        {
            get;
            set;
        }

        public CANDLETYPE CandleType
        {
            get;
            set;
        }

        public decimal RenkoBarBoxSize
        {
            get;
            set;
        }

    }

}
