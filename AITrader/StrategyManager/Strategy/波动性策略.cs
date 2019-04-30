using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using swap = OKExSDK.Models.Swap;

namespace Strategy
{
    public class 波动性策略 : IStrategy
    {

        public 波动性策略(string tradeIns, int frame)
        {
            this.m_tradeInstrument = tradeIns;
            this.m_frame = frame;
        }

        public override void OnTick(swap.Ticker t, string strategyName)
        {
            //调用一下基类，对外广播出去
            base.OnTick(t, this.GetType().FullName);
        }

        /// <summary>
        /// 订单触发
        /// </summary>
        /// <param name="t"></param>
        public override void OnOrder(Common.SwapOrderReturn orderReturn, string strategyName)
        {

        }
    }
}
