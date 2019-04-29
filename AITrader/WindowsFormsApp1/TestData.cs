using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using swap = OKExSDK.Models.Swap;
using OKExSDK.Models.Swap;
using System.IO;
using System.Globalization;

namespace WindowsFormsApp1
{
    public static class TestData
    {

        public class klineRoot
        {
            public List<KlineOkex> okexKlineList;
        }

        public class KlineOkex
        {
            public string insment { get; set; }
            public DateTime d { get; set; }
            public decimal o { get; set; }
            public decimal h { get; set; }
            public decimal l { get; set; }
            public decimal c { get; set; }

            public decimal unkonwn1 { get; set; }
            public decimal unkonwn2 { get; set; }
        }

        public class Kline
        {
            public string insment { get; set; }

            public DateTime d { get; set; }
            public decimal o { get; set; }
            public decimal h { get; set; }
            public decimal l { get; set; }
            public decimal c { get; set; }

            public decimal unkonwn1 { get; set; }
            public decimal unkonwn2 { get; set; }
        }

        public static List<RealMarketDepthData> GetBtc()
        {
            List<RealMarketDepthData> l = new List<RealMarketDepthData>();

            RealMarketDepthData d1 = new RealMarketDepthData()
            {
                Ins = "BTC",
                Ask = 5783.22,
                Bid = 5782.20
            };

            RealMarketDepthData d2 = new RealMarketDepthData()
            {
                Ins = "COS",
                Ask = 57.2,
                Bid = 52.4
            };

            RealMarketDepthData d3 = new RealMarketDepthData()
            {
                Ins = "LTC",
                Ask = 578.23,
                Bid = 579.46
            };

            RealMarketDepthData d4 = new RealMarketDepthData()
            {
                Ins = "HTC",
                Ask = 0.21222,
                Bid = 0.21343
            };

            RealMarketDepthData d5 = new RealMarketDepthData()
            {
                Ins = "EOS",
                Ask = 22.22,
                Bid = 21.20
            };

            l.Add(d1);
            l.Add(d2);
            l.Add(d3);
            l.Add(d4);
            l.Add(d5);

            return l;
        }


        public static List<swap.Instrument> GetIns()
        {
            //[{'instrument_id/:'BTC-USD-SWAP','underlying_index':'BTC','quote_currency':"USD','coin':"BTC','contract_val':100.0,listing':'2018-08-28T02:43:23Z','delivery':'2019-04-24T14:00:00Z','tick_size':0.1, 'size_increment':1.0},{'instrument_id/:'LTC-USD-SWAP','underlying_index':'LTC','quote_currency':"USD','coin':"LTC','contract_val':10.0, listing':'2018-12-21T07:53:47Z','delivery':'2019-04-24T14:00:00Z','tick_size':0.01,'size_increment':1.0},{'instrument_id/:'ETH-USD-SWAP','underlying_index':'ETH','quote_currency':"USD','coin':"ETH','contract_val':10.0, listing':'2018-12-21T07:53:47Z','delivery':'2019-04-24T14:00:00Z','tick_size':0.01,'size_increment':1.0},
            // {'instrument_id/:'TRX-USD-SWAP','underlying_index':'TRX','quote_currency':"USD','coin':"TRX','contract_val':10.0, listing':'2019-01-16T04:09:23Z','delivery':'2019-04-24T14:00:00Z','tick_size':0.000010,'size_increment':1.0},
            // {'instrument_id/:'BCH-USD-SWAP','underlying_index':'BCH','quote_currency':"USD','coin':"BCH','contract_val':10.0, listing':'2018-12-21T07:53:47Z','delivery':'2019-04-24T14:00:00Z','tick_size':0.01,'size_increment':1.0},
            // {'instrument_id/:'BSV-USD-SWAP','underlying_index':'BSV','quote_currency':"USD','coin':"BSV','contract_val':10.0, listing':'2018-12-21T07:53:47Z','delivery':'2019-04-24T14:00:00Z','tick_size':0.01,'size_increment':1.0},
            // {'instrument_id/:'EOS-USD-SWAP','underlying_index':'EOS','quote_currency':"USD','coin':"EOS','contract_val':10.0, listing':'2018-12-10T11:55:31Z','delivery':'2019-04-24T14:00:00Z','tick_size':0.001,'size_increment':1.0},
            // {'instrument_id/:'XRP-USD-SWAP','underlying_index':'XRP','quote_currency':"USD','coin':"XRP','contract_val':10.0, listing':'2018-12-21T07:53:47Z','delivery':'2019-04-24T14:00:00Z','tick_size':0.00010,'size_increment':1.0},
            // {'instrument_id/:'ETC-USD-SWAP','underlying_index':'ETC','quote_currency':"USD','coin':"ETC','contract_val':10.0, listing':'2018-12-21T07:53:47Z','delivery':'2019-04-24T14:00:00Z','tick_size':0.001,'size_increment':1.0}]";

            List<swap.Instrument> insLIst = new List<swap.Instrument>();
            swap.Instrument ins1 = new swap.Instrument()
            {
                instrument_id = "BTC-USD-SWAP",
                underlying_index = "BTC",
                quote_currency = "USD",
                coin = "BTC",
                contract_val = 100.00m,
                listing = DateTime.Now,
                delivery = DateTime.Now,
                tick_size = 0.10m,
                size_increment = 1.00m
            };

            swap.Instrument ins2 = new swap.Instrument()
            {
                instrument_id = "TRX-USD-SWAP",
                underlying_index = "TRX",
                quote_currency = "USD",
                coin = "TRX",
                contract_val = 100.00m,
                listing = DateTime.Now,
                delivery = DateTime.Now,
                tick_size = 0.10m,
                size_increment = 1.00m
            };

            swap.Instrument ins3 = new swap.Instrument()
            {
                instrument_id = "BCH-USD-SWAP",
                underlying_index = "BCH",
                quote_currency = "USD",
                coin = "BCH",
                contract_val = 100.00m,
                listing = DateTime.Now,
                delivery = DateTime.Now,
                tick_size = 0.10m,
                size_increment = 1.00m
            };

            swap.Instrument ins4 = new swap.Instrument()
            {
                instrument_id = "EOS-USD-SWAP",
                underlying_index = "EOS",
                quote_currency = "USD",
                coin = "EOS",
                contract_val = 100.00m,
                listing = DateTime.Now,
                delivery = DateTime.Now,
                tick_size = 0.10m,
                size_increment = 1.00m
            };

            insLIst.Add(ins1);
            insLIst.Add(ins2);
            insLIst.Add(ins3);
            insLIst.Add(ins4);
            return insLIst;
        }

        public static List<swap.Ticker> GetTicker()
        {
            Random rd = new Random();
            int radom1 = rd.Next(-20, 20);
            int radom2 = rd.Next(1, 10);
            int radom3 = rd.Next(-1, 90);
            int radom4 = rd.Next(-8, 9);

            List<Ticker> tic1ist = new List<Ticker>();

            Ticker ticker1 = new Ticker()
            {
                instrument_id = "BTC-USD-SWAP",
                last = 5308.340m - radom1,
                high_24h = 5401.350m + radom1,
                low_24h = 4209.020m + radom1,
                volume_24h = 4233390 + radom1,
                timestamp = DateTime.Now
            };

            Ticker ticker2 = new Ticker()
            {
                instrument_id = "TRX-USD-SWAP",
                last = 8.340m + radom2,
                high_24h = 0.350m + radom2,
                low_24h = 5.020m + radom2,
                volume_24h = 4420 + radom2,
                timestamp = DateTime.Now
            };

            Ticker ticker3 = new Ticker()
            {
                instrument_id = "BCH-USD-SWAP",
                last = 308.340m - radom3,
                high_24h = 401.350m + radom3,
                low_24h = 209.020m + radom3,
                volume_24h = 45210 + radom3,
                timestamp = DateTime.Now
            };

            Ticker ticker4 = new Ticker()
            {
                instrument_id = "EOS-USD-SWAP",
                last = 50.000340m + radom4,
                high_24h = 54.000350m + radom4,
                low_24h = 42.000020m + radom4,
                volume_24h = 421 + radom4,
                timestamp = DateTime.Now
            };

            tic1ist.Add(ticker1);
            tic1ist.Add(ticker2);
            tic1ist.Add(ticker3);
            tic1ist.Add(ticker4);
            return tic1ist;
        }

        public static swap.AccountsResult GetAccountResult()
        {
            swap.AccountsResult reList = new AccountsResult();
            List<swap.Account> aList = new List<swap.Account>();

            swap.Account a1 = new Account()
            {
                equity = "111",
                total_avail_balance = "1",
                margin = 112,
                realized_pnl = 112,
                unrealized_pnl = 112,
                margin_ratio = 112,
                instrument_id = "BTC",
                margin_frozen = "123123",
                margin_mode = "CSS",
                timestamp = DateTime.Now
            };

            swap.Account a2 = new Account()
            {
                equity = "111",
                total_avail_balance = "1",
                margin = 112,
                realized_pnl = 112,
                unrealized_pnl = 112,
                margin_ratio = 112,
                instrument_id = "LTC",
                margin_frozen = "123123",
                margin_mode = "CSS",
                timestamp = DateTime.Now
            };

            swap.Account a3 = new Account()
            {
                equity = "111",
                total_avail_balance = "1",
                margin = 112,
                realized_pnl = 112,
                unrealized_pnl = 112,
                margin_ratio = 112,
                instrument_id = "EOS",
                margin_frozen = "123123",
                margin_mode = "CSS",
                timestamp = DateTime.Now
            };

            swap.Account a4 = new Account()
            {
                equity = "111",
                total_avail_balance = "1",
                margin = 112,
                realized_pnl = 112,
                unrealized_pnl = 112,
                margin_ratio = 112,
                instrument_id = "CCE",
                margin_frozen = "123123",
                margin_mode = "CSS",
                timestamp = DateTime.Now
            };

            aList.Add(a1);
            aList.Add(a2);
            aList.Add(a3);
            aList.Add(a4);

            reList.info = aList;
            return reList;
        }


        public static swap.PositionResult<Position> GetPositionResult()
        {
            swap.PositionResult<Position> reList = new swap.PositionResult<Position>();
            List<swap.Position> aList = new List<swap.Position>();

            swap.Position a1 = new swap.Position()
            {
                liquidation_price = 2111.980m,
                position = "",
                avail_position = "",
                margin = "0.5",
                avg_cost = "",
                settlement_price = "5432",
                instrument_id = "CCS",
                leverage = 50,
                realized_pnl = 123210m,
                side = "",
                timestamp = DateTime.Now,
            };

            swap.Position a2 = new swap.Position()
            {
                liquidation_price = 2111.980m,
                position = "",
                avail_position = "",
                margin = "0.5",
                avg_cost = "",
                settlement_price = "5432",
                instrument_id = "EOS",
                leverage = 50,
                realized_pnl = 123210m,
                side = "",
                timestamp = DateTime.Now,
            };

            swap.Position a3 = new swap.Position()
            {
                liquidation_price = 2111.980m,
                position = "",
                avail_position = "",
                margin = "0.5",
                avg_cost = "",
                settlement_price = "5432",
                instrument_id = "BTC",
                leverage = 50,
                realized_pnl = 123210m,
                side = "",
                timestamp = DateTime.Now,
            };

            swap.Position a4 = new swap.Position()
            {
                liquidation_price = 2111.980m,
                position = "",
                avail_position = "",
                margin = "0.5",
                avg_cost = "",
                settlement_price = "5432",
                instrument_id = "LTC",
                leverage = 50,
                realized_pnl = 123210m,
                side = "",
                timestamp = DateTime.Now,
            };

            aList.Add(a1);
            aList.Add(a2);
            aList.Add(a3);
            aList.Add(a4);

            reList.holding = aList;
            reList.margin_mode = "全仓模式";
            return reList;
        }
        public static swap.OrderListResult GetOrderResult()
        {
            swap.OrderListResult reList = new swap.OrderListResult();
            List<swap.Order> aList = new List<swap.Order>();

            swap.Order a1 = new swap.Order()
            {
                instrument_id = "LTC",
                size = "1",
                timestamp = DateTime.Now,
                filled_qty = "BTC",
                fee = 0.992210m,
                order_id = "192837",
                price = 5182.320m,
                price_avg = 5182.320m,
                status = "部分成交",
                type = "买入",
                contract_val = "1",
            };

            swap.Order a2 = new swap.Order()
            {
                instrument_id = "BTC",
                size = "1",
                timestamp = DateTime.Now,
                filled_qty = "BTC",
                fee = 0.992210m,
                order_id = "192837",
                price = 5182.320m,
                price_avg = 5182.320m,
                status = "已撤单",
                type = "买入",
                contract_val = "1",
            };

            swap.Order a3 = new swap.Order()
            {
                instrument_id = "BTC",
                size = "1",
                timestamp = DateTime.Now,
                filled_qty = "BTC",
                fee = 0.992210m,
                order_id = "192837",
                price = 5182.320m,
                price_avg = 5182.320m,
                status = "部分成交",
                type = "买入",
                contract_val = "1",
            };

            swap.Order a4 = new swap.Order()
            {
                instrument_id = "EOS",
                size = "1",
                timestamp = DateTime.Now,
                filled_qty = "BTC",
                fee = 0.992210m,
                order_id = "192837",
                price = 5182.320m,
                price_avg = 5182.320m,
                status = "全部成交",
                type = "买入",
                contract_val = "1",
            };

            aList.Add(a1);
            aList.Add(a2);
            aList.Add(a3);
            aList.Add(a4);

            reList.result = true;
            reList.order_info = aList;
            return reList;
        }
        public static List<swap.Trade> GetTradeResult()
        {
            List<swap.Trade> reList = new List<swap.Trade>();

            swap.Trade a1 = new swap.Trade()
            {
                trade_id = "221311",
                price = 12120m,
                size = 5,
                timestamp = DateTime.Now,
                side = "买入"
            };
            swap.Trade a2 = new swap.Trade()
            {
                trade_id = "112121",
                price = 12120m,
                size = 5,
                timestamp = DateTime.Now,
                side = "买入"
            };
            swap.Trade a3 = new swap.Trade()
            {
                trade_id = "1213434",
                price = 12120m,
                size = 5,
                timestamp = DateTime.Now,
                side = "卖空"
            };
            swap.Trade a4 = new swap.Trade()
            {
                trade_id = "222456",
                price = 12120m,
                size = 2,
                timestamp = DateTime.Now,
                side = "买入"
            };

            reList.Add(a1);
            reList.Add(a2);
            reList.Add(a3);
            reList.Add(a4);

            return reList;
        }

        public static swap.OrderResultSingle GetResultMarkeOrderSingle()
        {
            swap.OrderResultSingle s = new OrderResultSingle()
            {
                order_id = "1121212",
                client_oid = "23552342",
                error_code = "4432",
                error_message = "测试成功返回",
                result = "TRUE"
            };

            return s;

        }

        public static List<TestData.KlineOkex> GetKLine(string ins)
        {
            List<TestData.KlineOkex> klineList = new List<TestData.KlineOkex>();


            char[] separator = { '\r', '\n' };

            FileStream fs = new FileStream(@"C:\Users\Administrator\Desktop\AI-Trader\AITrader\WindowsFormsApp1\Resource\OhlcData.csv", FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
            StreamReader sr = new StreamReader(fs, System.Text.Encoding.Default);
            String line;
            while ((line = sr.ReadLine()) != null)
            {
                string[] lines = line.Split(separator, StringSplitOptions.RemoveEmptyEntries);
                foreach (string l in lines)
                {
                    if (string.IsNullOrEmpty(l))
                        continue;

                    string[] data = l.Split(',');
                    TestData.KlineOkex dataItem = new TestData.KlineOkex()
                    {
                        insment = ins,
                        d = DateTime.Parse(data[0], CultureInfo.InvariantCulture),
                        o = decimal.Parse(data[1], CultureInfo.InvariantCulture),
                        h = decimal.Parse(data[2], CultureInfo.InvariantCulture),
                        l = decimal.Parse(data[3], CultureInfo.InvariantCulture),
                        c = decimal.Parse(data[4], CultureInfo.InvariantCulture)
                    };

                    klineList.Add(dataItem);
                }
            }
            return klineList;


            //List<Kline> klineList = new List<Kline>();
            //for(int i = 0;i<500;i++)
            //{
            //    Random rd = new Random();
            //    int radom1 = rd.Next(-10,20);

            //    Kline Kline = new Kline()
            //    {
            //        d = DateTime.Now.AddDays(i+1),
            //        o = 10 - radom1 + i,
            //        h = 11 + radom1 + i,
            //        l = 15 - radom1 + i,
            //        c = 1 + radom1 + i,
            //    };

            //    klineList.Add(Kline);
            //}
            //return klineList;
        }
    }
}
