using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using swap = OKExSDK.Models.Swap;

namespace Strategy
{
    public class Par策略 : IStrategy
    {
        public Par策略(string tradeIns, int frame)
        {
            this.m_tradeInstrument = tradeIns;
            this.m_frame = frame;
        }

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

            SafeRiseLogEvent("在这里收到策略的OnTick");

            //调用一下基类，对外广播出去
            //base.OnTick(t, this.GetType().FullName);
        }

        /// <summary>
        /// 订单触发
        /// </summary>
        /// <param name="t"></param>
        public override void OnOrder(Common.SwapOrderReturn orderReturn, string strategyName)
        {
            //调用一下基类，对外广播出去
            base.OnOrder(orderReturn, this.GetType().FullName);

            //策略订单如何处理在这里继续处理
            SafeRiseLogEvent("在这里收到订单回报OnOrder");
        }
    }
}
