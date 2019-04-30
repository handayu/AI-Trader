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
using OKExSDK.Models;
using Common;
using APIConnect;

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
            if(ConnectManager.CreateInstance().CONNECTION != null)
            {
                ConnectManager.CreateInstance().CONNECTION.AnsyOrderEvent += AnsyOrderSubEvent;
                ConnectManager.CreateInstance().CONNECTION.AnsyPositionEvent += AnsyPositionSubEvent;
                ConnectManager.CreateInstance().CONNECTION.AnsyTradeEvent += AnsyTradeSubEvent;
                ConnectManager.CreateInstance().CONNECTION.AnsyMakeOrderEvent += AnsyMakeOrderSubEvent;
            }

        }

        /// <summary>
        /// 下单回报
        /// </summary>
        /// <param name="args"></param>
        private void AnsyMakeOrderSubEvent(AIEventArgs args)
        {
            if(args.ReponseMessage == RESONSEMESSAGE.HOLDMAKEORDERACTION_FAILED)
            {
                OKExSDK.Models.ErrorResult result = (OKExSDK.Models.ErrorResult)args.EventData;
                this.label_log.Text = result.code + ":" + result.message;
            }

            if (args.ReponseMessage == RESONSEMESSAGE.HOLDMAKEORDERACTION_SUCCESS)
            {
                swap.OrderResultSingle result = (swap.OrderResultSingle)args.EventData;
                this.label_log.Text = result.order_id + ":" + result.result;
            }
            if (args.ReponseMessage == RESONSEMESSAGE.HOLDMAKEORDERACTION_EXCEPTION)
            {
                System.Exception result = (System.Exception)args.EventData;
                this.label_log.Text = result.Message;
            }
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

            this.label_log.Text = DateTime.Now.ToString() + ":" + str;
        }

        /// <summary>
        /// 下单
        /// </summary>
        /// <param name="instrument_id">合约名称，如BTC-USD-SWAP</param>
        /// <param name="type">1:开多2:开空3:平多4:平空</param>
        /// <param name="price">委托价格</param>
        /// <param name="size">下单数量</param>
        /// <param name="client_oid">由您设置的订单ID来识别您的订单</param>
        /// <param name="match_price">是否以对手价下单(0:不是 1:是)</param>
        /// <returns></returns>
        private void button_Buy_Click_1(object sender, EventArgs e)
        {
            //OrderSingle-下单
            MakeOrderAction();
        }

        private void MakeOrderAction()
        {
            string order_strIns = this.comboBox_Ins.SelectedText;
            string order_type = string.Empty;

            if(radioButton_Buy.Checked && radioButton_Open.Checked)
            {
                order_type = "1";
            }
            if (radioButton_Sellshort.Checked && radioButton_Open.Checked)
            {
                order_type = "2";
            }
            if (radioButton_Buy.Checked && radioButton_Cover.Checked)
            {
                order_type = "3";
            }
            if (radioButton_Sellshort.Checked && radioButton_Cover.Checked)
            {
                order_type = "4";
            }

            string price = this.textBox_Price.Text;
            decimal order_Price = 0.0m;
            decimal.TryParse(price, out order_Price);

            string num = this.textBox_OrderNum.Text;
            int order_Num = 0;
            int.TryParse(num, out order_Num);

            string order_clientId = "1111";

            string order_Mathprice = string.Empty;
            if(radioButton_oppPrice.Checked)
            {
                order_Mathprice = "1";
            }
            else
            {
                order_Mathprice = "0";
            }

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
