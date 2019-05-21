using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TALibraryInCSharp;

namespace Indicators
{
    public class MaIndicator:IIndicators
    {
        /// <summary>
        /// 外部K线等其他K线触发器--MA目前只是个范例，因为涉及到指标周期，MA类型，长度等参数调入
        /// </summary>
        /// <param name="bar"></param>
        public override double[] OnBarRising(List<decimal> m_o, List<decimal> m_h, List<decimal> m_l, List<decimal> m_c)
        {
            if (m_o == null || m_h == null || m_l == null || m_c == null) return new double[] { };
            if (m_o.Count <= 6 || m_h.Count <= 6 || m_l.Count <= 6 || m_c.Count <= 6) return new double[] { };

            double[] closeArray = new double[m_c.Count];
            for (int i = 0; i < m_c.Count; i++)
            {
                closeArray[i] = Convert.ToDouble(m_c[i]);
            }
            double[] intReal = closeArray;
            double[] outRealMA = new double[closeArray.Length];

            //输出数列的起始计算的Index
            int outBegIndexSAR = 0;

            //输出数列的目前计算的index
            int outNBElementSAR = 0;
            Core.RetCode resultCode = Core.MovingAverage(0, closeArray.Length - 1, closeArray, 2,Core.MAType.Sma, ref outBegIndexSAR, ref outNBElementSAR, outRealMA);

            if(resultCode == Core.RetCode.Success)
            {
                return outRealMA;
            }
            else
            {
                return new double[] { };
            }
        }
    }
}
