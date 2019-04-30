using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using swap = OKExSDK.Models.Swap;

namespace WindowsFormsApp1
{
    public class VolatityStrategy: IStrategy
    {

        public VolatityStrategy(string tradeIns,int frame)
        {
            this.m_tradeInstrument = tradeIns;
            this.m_frame = frame;
        }

        public override void OnTick(swap.Ticker t)
        {
            //调用一下基类，对外广播出去
            base.OnTick(t);
        }


    }
}
