using swap = OKExSDK.Models.Swap;
using OKExSDK.Models.Swap;
namespace Common
{
    public class ItemList
    {
        /// <summary>
        /// Item列表
        /// </summary>
        public static System.Collections.Generic.List<swap.Instrument> Item { get; set; }
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
