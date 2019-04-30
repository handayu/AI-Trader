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

namespace WindowsFormsApp1
{
    public partial class MarketDataUserControl : UserControl
    {
        public delegate void RealMarketDataClikHandle(swap.Ticker t);
        public RealMarketDataClikHandle RealMarketDataClikEvent;


        private BindingList<swap.Ticker> m_marketDataList = new BindingList<swap.Ticker>();

        //每隔1000s请求一次

        public MarketDataUserControl()
        {
            InitializeComponent();
        }

        public void SubScribe()
        {
            this.dataGridView1.DataSource = m_marketDataList;

            ConnectManager.CreateInstance().CONNECTION.AnsyRealDataEvent += AnsyTickerSubEvent;
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

        private void DataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || this.dataGridView1.Rows[e.RowIndex].DataBoundItem == null) return;

            swap.Ticker tic = this.dataGridView1.Rows[e.RowIndex].DataBoundItem as swap.Ticker;

            if(RealMarketDataClikEvent != null && tic != null)
            {
                RealMarketDataClikEvent(tic);
            }

        }
    }
}
