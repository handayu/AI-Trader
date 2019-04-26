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
    public partial class QuickOrderUserControl : UserControl
    {
        private BindingList<swap.Position> m_positionList = new BindingList<swap.Position>();
        private BindingList<swap.Trade> m_tradeList = new BindingList<swap.Trade>();
        private BindingList<swap.Order> m_orderList = new BindingList<swap.Order>();


        public QuickOrderUserControl()
        {
            InitializeComponent();

            this.AppendText("启动快捷下单面板成功...");

            //绑定数据
            this.dataGridView_Hold.DataSource = m_positionList;
            this.dataGridView_hasTraded.DataSource = m_tradeList;
            this.dataGridView_NoTradedOrder.DataSource = m_orderList;
        }

        /// <summary>
        /// 订阅-实时行情-成交-委托-持仓回报
        /// </summary>
        public void SubScribe()
        {
            //先去拿一遍--然后订阅
            //position
            swap.PositionResult<swap.Position> position = ConnectManager.CreateInstance().PositionList;

            if (position != null && position.holding != null)
            {
                foreach (swap.Position p in position.holding)
                {
                    m_positionList.Add(p);
                }
            }


            //trade
            List<swap.Trade> trade = ConnectManager.CreateInstance().TradeList;

            if (trade != null)
            {
                foreach (swap.Trade t in trade)
                {
                    m_tradeList.Add(t);
                }
            }

            //order
            swap.OrderListResult order = ConnectManager.CreateInstance().OrderList;

            if (order != null && order.order_info != null)
            {
                foreach (swap.Order o in order.order_info)
                {
                    m_orderList.Add(o);
                }
            }


            //SubEvent
            //查成交-委托-持仓
            ConnectManager.CreateInstance().CONNECTION.AnsyOrderEvent += AnsyOrderSubEvent;
            ConnectManager.CreateInstance().CONNECTION.AnsyPositionEvent += AnsyPositionSubEvent;
            ConnectManager.CreateInstance().CONNECTION.AnsyTradeEvent += AnsyTradeSubEvent;

        }

        /// <summary>
        /// 成交回报
        /// </summary>
        /// <param name="args"></param>
        private void AnsyTradeSubEvent(AIEventArgs args)
        {
        }

        /// <summary>
        /// 持仓回报
        /// </summary>
        /// <param name="args"></param>
        private void AnsyPositionSubEvent(AIEventArgs args)
        {
        }

        /// <summary>
        /// 委托回报
        /// </summary>
        /// <param name="args"></param>
        private void AnsyOrderSubEvent(AIEventArgs args)
        {
        }

        private void AppendText(string str)
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke(new Action<string>(AppendText), str);
            }

            this.label4.Text = DateTime.Now.ToString() + ":" + str;
        }

        private void button_Buy_Click(object sender, EventArgs e)
        {

        }

        private void button_SellShort_Click(object sender, EventArgs e)
        {

        }

        private void button_OppositePrice_Click(object sender, EventArgs e)
        {

        }

        private void button_Buy_Click_1(object sender, EventArgs e)
        {

        }
    }
}
