using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using swap = OKExSDK.Models.Swap;
using spot = OKExSDK.Models.Spot;

using Common;
using APIConnect;
using System.IO;

namespace WindowsFormsApp1
{
    public partial class MarketDataUserControl : UserControl
    {
        public delegate void RealMarketDataClikHandle(swap.Ticker t);
        public RealMarketDataClikHandle RealMarketDataClikEvent;

        /// <summary>
        /// 永续合约实时行情
        /// </summary>
        private BindingList<swap.Ticker> m_marketDataList = new BindingList<swap.Ticker>();

        /// <summary>
        /// 币币实时行情
        /// </summary>
        private BindingList<spot.SpotTicker> m_SpotMarketDataList = new BindingList<spot.SpotTicker>();


        //每隔1000s请求一次

        public MarketDataUserControl()
        {
            InitializeComponent();
        }

        public void SubScribe()
        {
            this.dataGridView1.DataSource = m_marketDataList;
            ConnectManager.CreateInstance().CONNECTION.AnsyRealDataEvent += AnsyTickerSubEvent;

            this.dataGridView_spot.DataSource = m_SpotMarketDataList;
            ConnectManager.CreateInstance().CONNECTION.AnsySPOTRealDataEvent += AnsyGetMarketDepthDataBitCoinUSDEvent;
        }

        private void AnsyTickerSubEvent(AIEventArgs args)
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke(new Action<AIEventArgs>(AnsyTickerSubEvent), args);
                return;
            }

            if (args.ReponseMessage == RESONSEMESSAGE.HOLDMARKETDATA_SUCCESS)
            {
                List<swap.Ticker> tikList = (List<swap.Ticker>)args.EventData;

                foreach(swap.Ticker t in tikList)
                {
                    swap.Ticker removeTic = null;
                    foreach (swap.Ticker nowTick in m_marketDataList)
                    {
                        if(t.instrument_id == nowTick.instrument_id)
                        {
                            removeTic = nowTick;
                            break;
                        }
                    }

                    if (removeTic == null)
                    {
                        m_marketDataList.Add(t);
                    }
                    else
                    {
                        m_marketDataList.Remove(removeTic);
                        m_marketDataList.Add(t);
                    }

                    //比较两个新来最新价的大小，如果现在比之前小，显示绿色/大显示红色
                    foreach (DataGridViewRow r in this.dataGridView1.Rows)
                    {
                        swap.Ticker tickRow = r.DataBoundItem as swap.Ticker;
                        if (tickRow == null) continue;
                        if (tickRow.instrument_id == t.instrument_id && t.last >= tickRow.last)
                        {
                            r.DataGridView.ForeColor = Color.Red;
                        }

                        if (tickRow.instrument_id == t.instrument_id && t.last < t.last)
                        {
                            r.DataGridView.ForeColor = Color.Green;
                        }
                    }
                }

            }
        }

        private void AnsyGetMarketDepthDataBitCoinUSDEvent(AIEventArgs args)
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke(new Action<AIEventArgs>(AnsyGetMarketDepthDataBitCoinUSDEvent), args);
                return;
            }

            if (args.ReponseMessage == RESONSEMESSAGE.SPOTMARKETDATA_SUCCESS)
            {
                List<spot.SpotTicker> tikList = (List<spot.SpotTicker>)args.EventData;


                foreach (spot.SpotTicker t in tikList)
                {
                    //在这里把比特币-USDT的行情写入Txt映射到multicharts中进行测试
                    if(t.instrument_id == "BTC-USDT")
                    {
                        WriteToTxt(t);
                    }
                    
                    spot.SpotTicker removeTic = null;
                    foreach (spot.SpotTicker nowTick in m_SpotMarketDataList)
                    {
                        if (t.instrument_id == nowTick.instrument_id)
                        {
                            removeTic = nowTick;
                            break;
                        }
                    }

                    if (removeTic == null)
                    {
                        m_SpotMarketDataList.Add(t);
                    }
                    else
                    {
                        m_SpotMarketDataList.Remove(removeTic);
                        m_SpotMarketDataList.Add(t);
                    }

                    //比较两个新来最新价的大小，如果现在比之前小，显示绿色/大显示红色
                    foreach (DataGridViewRow r in this.dataGridView_spot.Rows)
                    {
                        spot.SpotTicker tickRow = r.DataBoundItem as spot.SpotTicker;
                        if (tickRow == null) continue;
                        if (tickRow.instrument_id == t.instrument_id && Convert.ToDouble(t.last) >= Convert.ToDouble(tickRow.last))
                        {
                            r.DataGridView.ForeColor = Color.Red;
                        }

                        if (tickRow.instrument_id == t.instrument_id && Convert.ToDouble(t.last) < Convert.ToDouble(tickRow.last))
                        {
                            r.DataGridView.ForeColor = Color.Green;
                        }
                    }
                }

            }
        }

        /// <summary>
        /// 写入txt
        /// </summary>
        /// <param name=""></param>
        public void WriteToTxt(spot.SpotTicker ticker)
        {
            string path = Application.StartupPath + "\\" + "BTC-USDT.txt";

            string str = DateTime.Now.Year.ToString() + "/" + DateTime.Now.Month.ToString() + "/" + DateTime.Now.Day.ToString()  + "," + DateTime.Now.Hour.ToString() + ":" + DateTime.Now.Minute.ToString() + ":" + DateTime.Now.Second.ToString() + "," +
                Convert.ToDouble(ticker.last).ToString("#0.00000000") + "," + "0" + "\r\n";

            File.AppendAllText(path,str);
        }

        private void DataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || this.dataGridView1.Rows[e.RowIndex].DataBoundItem == null) return;

            swap.Ticker tic = this.dataGridView1.Rows[e.RowIndex].DataBoundItem as swap.Ticker;

            if(RealMarketDataClikEvent != null && tic != null)
            {
                RealMarketDataClikEvent(tic);
            }

        }

        private void SpotDataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //if (e.RowIndex < 0 || this.dataGridView_spot.Rows[e.RowIndex].DataBoundItem == null) return;

            //spot.SpotTicker tic = this.dataGridView_spot.Rows[e.RowIndex].DataBoundItem as spot.SpotTicker;

            //if (RealMarketDataClikEvent != null && tic != null)
            //{
            //    RealMarketDataClikEvent(tic);
            //}
        }
    }
}
