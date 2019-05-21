using APIConnect;
using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TALibraryInCSharp;
using swap = OKExSDK.Models.Swap;

namespace Strategy
{
    public class Par策略 : IStrategy
    {
        public Par策略(string tradeIns, int frame,int openShares)
        {
            this.m_tradeInstrument = tradeIns;
            this.m_frame = frame;
            m_openShares = openShares;
        }

        /// <summary>
        /// Ontick触发
        /// </summary>
        /// <param name="t"></param>
        /// <param name="strategyName"></param>
        public override void OnTick(swap.Ticker t, string strategyName)
        {
            //策略Tick逻辑判断在这里继续-下单
            swap.OrderSingle o = new swap.OrderSingle()
            {
                instrument_id = t.instrument_id,
                client_oid = "1",
                price = t.last,
                size = 1,
                type = "12",
                match_price = "1"
            };

            //APIConnect.ConnectManager.CreateInstance().CONNECTION.AnsyOrderSwap(o);

            SafeRiseLogEvent("在这里收到Par策略的OnTick");
        }

        /// <summary>
        /// 订单触发
        /// </summary>
        /// <param name="t"></param>
        public override void OnOrder(Common.SwapOrderReturn orderReturn, string strategyName)
        {
            //策略订单如何处理在这里继续处理
            SafeRiseLogEvent("在这里收到订单回报OnOrder");
        }

        /// <summary>
        /// 外部K线等其他K线触发器
        /// </summary>
        /// <param name="bar"></param>
        public override void OnBarRising(List<decimal> m_o, List<decimal> m_h, List<decimal> m_l, List<decimal> m_c)
        {
            SafeRiseLogEvent("Par策略的Bar正在参与计算");

            if (m_o == null || m_h == null || m_l == null || m_c == null) return;
            if (m_o.Count <= 2 || m_h.Count <= 2 || m_l.Count <= 2 || m_c.Count <= 2) return;

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

            if (outRealSAR.Length <= 2 || m_o == null || outRealSAR == null || m_l.Count <= 2
                || outRealSAR.Length <= 2)
            {
                //指标最小计算根数不够
                return;
            }

            double prePrice = Convert.ToDouble((m_c[m_c.Count - 2]));
            double nowPrice = Convert.ToDouble((m_c[m_c.Count - 1]));


            double preSar = Convert.ToDouble((outRealSAR[outRealSAR.Length - 3]));
            double nowSar = Convert.ToDouble((outRealSAR[outRealSAR.Length - 2]));

            //上一个renko价格小于上一个sar值，当前最新的renko大于当前的Sar
            if (prePrice < preSar && nowPrice >= nowSar)
            {
                //平空单，买入多单
                SafeRiseLogEvent("平空单，买入多单");

                swap.OrderSingle orderSP = new swap.OrderSingle()
                {
                    instrument_id = m_tradeInstrument,
                    type = "4",//平空
                    price = Convert.ToDecimal(nowPrice) + 5,
                    size = m_openShares,
                    client_oid = "hanyu1",
                    match_price = "0"
                };

                ConnectManager.CreateInstance().CONNECTION.AnsyOrderSwap(orderSP);

                swap.OrderSingle orderBK = new swap.OrderSingle()
                {
                    instrument_id = m_tradeInstrument,
                    type = "1",//开多
                    price = Convert.ToDecimal(nowPrice) + 5,
                    size = m_openShares,
                    client_oid = "hanyu1",
                    match_price = "0"
                };

                ConnectManager.CreateInstance().CONNECTION.AnsyOrderSwap(orderBK);
            }

            if (prePrice > preSar && nowPrice <= nowSar)
            {
                //平多单，进入空单
                SafeRiseLogEvent("平多单，进入空单");

                swap.OrderSingle orderBP = new swap.OrderSingle()
                {
                    instrument_id = m_tradeInstrument,
                    type = "3",//平多
                    price = Convert.ToDecimal(nowPrice) - 5,
                    size = m_openShares,
                    client_oid = "hanyu1",
                    match_price = "0"
                };

                ConnectManager.CreateInstance().CONNECTION.AnsyOrderSwap(orderBP);

                swap.OrderSingle orderSK = new swap.OrderSingle()
                {
                    instrument_id = m_tradeInstrument,
                    type = "2",//开空
                    price = Convert.ToDecimal(nowPrice) - 5,
                    size = m_openShares,
                    client_oid = "hanyu1",
                    match_price = "0"
                };

                ConnectManager.CreateInstance().CONNECTION.AnsyOrderSwap(orderSK);
            }

        }
    }
}
