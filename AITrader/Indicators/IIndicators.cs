using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Indicators
{
    public class IIndicators
    {
        /// <summary>
        /// 外部调用-OHLC
        /// </summary>
        /// <param name="closeList"></param>
        public virtual double[] OnBarRising(List<decimal> openList, List<decimal> highList, List<decimal> lowList, List<decimal> closeList)
        {
            return new double[] { };
        }
    }
}
