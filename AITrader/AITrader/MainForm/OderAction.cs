using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using swap = OKExSDK.Models.Swap;
using OKExSDK.Models;
using Common;
using APIConnect;

namespace AITrader
{
    public static class OderAction
    {
        public static void Buy(string m_ins,decimal price, string numT)
        {
            decimal orderP = price + 15;
            //以自定义价格买入
            Order(m_ins, "1", orderP.ToString(), numT);
        }

        public static void Sell(string m_ins, decimal price, string numT)
        {
            decimal orderP = price - 15;

            //以自定义价格平多
            Order(m_ins, "3", orderP.ToString(), numT);
        }

        public static void SellShort(string m_ins, decimal price, string numT)
        {
            decimal orderP = price - 15;

            //以自定义价格空
            Order(m_ins, "2", orderP.ToString(), numT);
        }

        public static void BuyToCover(string m_ins, decimal price, string numT)
        {
            decimal orderP = price + 15;

            //以自定义价格平空
            Order(m_ins, "4", orderP.ToString(), numT);
        }


        public static void Order(string insT,string order_typeT,string priceT,string numT)
        {
            string order_strIns = insT;
            string order_type = order_typeT;

            string price = priceT;
            decimal order_Price = 0.0m;
            decimal.TryParse(price, out order_Price);

            string num = numT;
            int order_Num = 0;
            int.TryParse(num, out order_Num);

            string order_clientId = "hanyu1";

            string order_Mathprice = "0";

            swap.OrderSingle order = new swap.OrderSingle()
            {
                instrument_id = order_strIns,
                type = order_type,
                price = order_Price,
                size = order_Num,
                client_oid = order_clientId,
                match_price = order_Mathprice
            };

            ConnectManager.CreateInstance().CONNECTION.AnsyOrderSwap(order);
        }


    }
}
