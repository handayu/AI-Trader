using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TALibraryInCSharp;

namespace Indicators
{
    public class SarIndicator : IIndicators
    {
        /// <summary>
        /// 外部K线等其他K线触发器
        /// </summary>
        /// <param name="bar"></param>
        public override double[] OnBarRising(List<decimal> m_o, List<decimal> m_h, List<decimal> m_l, List<decimal> m_c)
        {
            if (m_o == null || m_h == null || m_l == null || m_c == null) return new double[] { };
            if (m_o.Count <= 2 || m_h.Count <= 2 || m_l.Count <= 2 || m_c.Count <= 2) return new double[] { };

            //添加计算Sar指标的值到日志用于监控(统一计算renko)
            double[] highAyyay = new double[m_h.Count];
            double[] lowArray = new double[m_l.Count];
            for (int i = 0; i < m_h.Count; i++)
            {
                highAyyay[i] = Convert.ToDouble(m_h[i]);
                lowArray[i] = Convert.ToDouble(m_l[i]);
            }
            double[] intHigh = highAyyay;
            double[] intLow = lowArray;
            //outReal是即将输出的一组计算结果数列
            double[] outRealSAR = new double[highAyyay.Length];
            //输出数列的起始计算的Index
            int outBegIndexSAR = 0;
            //输出数列的目前计算的index
            int outNBElementSAR = 0;
            Core.RetCode resultCode = Core.Sar(0, intHigh.Length - 1, intHigh, intLow, 0.02, 0.2, ref outBegIndexSAR, ref outNBElementSAR, outRealSAR);

            if (resultCode == Core.RetCode.Success)
            {
                return outRealSAR;
            }
            else
            {
                return new double[] { };
            }

        }
    }
}
