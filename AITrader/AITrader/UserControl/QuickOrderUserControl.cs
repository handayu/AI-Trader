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

            //
            this.label_newMarketData.Text = "----";
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
                    double holdNum = 0.00;
                    double.TryParse(p.position, out holdNum);
                    if (holdNum >= 1) m_positionList.Add(p);
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

            foreach (swap.Instrument ins in ConnectManager.CreateInstance().InstrumentList)
            {
                if (ins != null)
                {
                    this.comboBox_Ins.Items.Add(ins.instrument_id);
                }
            }


            //SubEvent
            //查成交-委托-持仓
            if (ConnectManager.CreateInstance().CONNECTION != null)
            {
                ConnectManager.CreateInstance().CONNECTION.AnsyOrderEvent += AnsyOrderSubEvent;
                ConnectManager.CreateInstance().CONNECTION.AnsyPositionEvent += AnsyPositionSubEvent;
                ConnectManager.CreateInstance().CONNECTION.AnsyTradeEvent += AnsyTradeSubEvent;
                ConnectManager.CreateInstance().CONNECTION.AnsyMakeOrderEvent += AnsyMakeOrderSubEvent;

                ConnectManager.CreateInstance().CONNECTION.AnsyRealDataEvent += AnsyRealDataSubEvent;

            }

        }

        /// <summary>
        /// 下单回报
        /// </summary>
        /// <param name="args"></param>
        private void AnsyMakeOrderSubEvent(AIEventArgs args)
        {
            if (args.ReponseMessage == RESONSEMESSAGE.HOLDMAKEORDERACTION_FAILED)
            {
                OKExSDK.Models.ErrorResult result = (OKExSDK.Models.ErrorResult)args.EventData;
                this.label_log.Text = result.code + ":" + result.message;
            }

            if (args.ReponseMessage == RESONSEMESSAGE.HOLDMAKEORDERACTION_SUCCESS)
            {
                Common.SwapOrderReturn result = (Common.SwapOrderReturn)args.EventData;
                this.label_log.Text = result.order_id + ":" + result.error_message;
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
            if (args.ReponseMessage == RESONSEMESSAGE.HOLDTRADE_SUCCESS)
            {
                List<swap.Trade> result = (List<swap.Trade>)args.EventData;
                foreach (swap.Trade t in result)
                {
                    m_tradeList.Add(t);
                }
            }
        }

        /// <summary>
        /// 持仓回报
        /// </summary>
        /// <param name="args"></param>
        private void AnsyPositionSubEvent(AIEventArgs args)
        {
            m_positionList.Clear();

            //只显示持仓数量>0的有持仓的数字货币
            if (args.ReponseMessage == RESONSEMESSAGE.HOLDPOSITION_SUCCESS)
            {
                swap.PositionResult<swap.Position> result = ConnectManager.CreateInstance().PositionList;
                List<swap.Position> pList = result.holding;
                foreach (swap.Position p in pList)
                {
                    double holdNum = 0.00;
                    double.TryParse(p.position, out holdNum);
                    if (holdNum >= 1) m_positionList.Add(p);
                }
            }
        }

        /// <summary>
        /// 委托回报
        /// </summary>
        /// <param name="args"></param>
        private void AnsyOrderSubEvent(AIEventArgs args)
        {
            if (args.ReponseMessage == RESONSEMESSAGE.HOLDORDER_SUCCESS)
            {
                swap.OrderListResult result = (swap.OrderListResult)args.EventData;
                List<swap.Order> oList = result.order_info;
                foreach (swap.Order o in oList)
                {
                    m_orderList.Add(o);
                }
            }
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


            //在这里新开一个线程用于延时查询，不要阻塞主界面线程
            Task task = new Task(new Action(QueryPositionAndOrder));
            task.Start();

        }

        private void QueryPositionAndOrder()
        {
            System.Threading.Thread.Sleep(1000);
            Button_queryPosition_Click(null, null);
            System.Threading.Thread.Sleep(1000);
            Button_QueryOrder_Click(null, null);
        }

        private void MakeOrderAction()
        {
            string order_strIns = this.comboBox_Ins.SelectedItem.ToString().Trim();
            string order_type = string.Empty;

            if (radioButton_Buy.Checked && radioButton_Open.Checked)
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

            string order_clientId = "hanyu1";

            string order_Mathprice = string.Empty;
            if (radioButton_oppPrice.Checked)
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

        private void Button_TestQuery_Click(object sender, EventArgs e)
        {
            m_positionList.Clear();
            m_orderList.Clear();
            m_positionList.Clear();

            foreach (swap.Instrument ins in ConnectManager.CreateInstance().InstrumentList)
            {
                if (ins != null)
                {
                    ConnectManager.CreateInstance().CONNECTION.AnsyOrdersByInstrumentSwap(ins.instrument_id, "2", 1, null, 10);
                    ConnectManager.CreateInstance().CONNECTION.AnsyPositionByInstrumentSwap(ins.instrument_id);
                    ConnectManager.CreateInstance().CONNECTION.AnsyTradeByInstrumentSwap(ins.instrument_id, 1, null, 10);
                }

            }
        }

        /// <summary>
        /// 每隔一分钟查询一次持仓-委托-成交
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer_queryPOTEvent(object sender, EventArgs e)
        {
            //Button_TestQuery_Click(null, null);
        }

        private void Button_queryPosition_Click(object sender, EventArgs e)
        {
            if(this.InvokeRequired)
            {
                this.BeginInvoke(new Action<object, EventArgs>(Button_queryPosition_Click),sender,e);
                return;
            }

            ConnectManager.CreateInstance().PositionList.holding.Clear();
            ConnectManager.CreateInstance().PositionList.margin_mode = "";

            foreach (swap.Instrument ins in ConnectManager.CreateInstance().InstrumentList)
            {
                if (ins != null)
                {
                    ConnectManager.CreateInstance().CONNECTION.AnsyPositionByInstrumentSwap(ins.instrument_id);
                }

            }
        }

        private void Button_CoverPosition_Click(object sender, EventArgs e)
        {

        }

        private void Button_QueryOrder_Click(object sender, EventArgs e)
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke(new Action<object, EventArgs>(Button_queryPosition_Click), sender, e);
                return;
            }

            m_orderList.Clear();

            foreach (swap.Instrument ins in ConnectManager.CreateInstance().InstrumentList)
            {
                if (ins != null)
                {
                    ConnectManager.CreateInstance().CONNECTION.AnsyOrdersByInstrumentSwap(ins.instrument_id, "2", 1, null, 10);
                }
            }
        }

        private void Button_CancelOrder_Click(object sender, EventArgs e)
        {

        }

        #region 控制radiobutton
        private void RadioButton_Buy_CheckedChanged(object sender, EventArgs e)
        {
            if (this.radioButton_Buy.Checked)
            {
                this.radioButton_Sellshort.Checked = false;
            }
        }

        private void RadioButton_Sellshort_CheckedChanged(object sender, EventArgs e)
        {
            if (this.radioButton_Sellshort.Checked)
            {
                this.radioButton_Buy.Checked = false;
            }
        }

        private void RadioButton_Open_CheckedChanged(object sender, EventArgs e)
        {
            if (this.radioButton_Open.Checked)
            {
                this.radioButton_Cover.Checked = false;
            }
        }

        private void RadioButton_Cover_CheckedChanged(object sender, EventArgs e)
        {
            if (this.radioButton_Cover.Checked)
            {
                this.radioButton_Open.Checked = false;
            }
        }
        #endregion

        /// <summary>
        /// 实时行情回调
        /// </summary>
        /// <param name="args"></param>
        private void AnsyRealDataSubEvent(AIEventArgs args)
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke(new Action<AIEventArgs>(AnsyRealDataSubEvent), args);
                return;
            }

            if (args.ReponseMessage == RESONSEMESSAGE.HOLDMARKETDATA_SUCCESS)
            {
                List<swap.Ticker> tikList = (List<swap.Ticker>)args.EventData;

                foreach (swap.Ticker t in tikList)
                {
                    if(t.instrument_id.CompareTo(this.comboBox_Ins.Text) != 0)
                    {
                        continue;
                    }
                    else
                    {
                        decimal AddDiffPrice = 0m;
                        decimal.TryParse(this.textBox_OppositePriceOrder.Text, out AddDiffPrice);

                        //如果是买入开仓和买入平仓[特殊]，价格要+ ；卖出开仓和卖出平仓[特殊]，价格要-
                        if ( (radioButton_Buy.Checked && radioButton_Open.Checked )||
                            (radioButton_Sellshort.Checked && radioButton_Cover.Checked))
                        {


                            this.label_newMarketData.Text = t.last.ToString();
                            this.textBox_Price.Text = (t.last + AddDiffPrice).ToString();
                        }

                        if ((radioButton_Sellshort.Checked && radioButton_Open.Checked) ||
                             (radioButton_Buy.Checked && radioButton_Cover.Checked))
                        {


                            this.label_newMarketData.Text = t.last.ToString();
                            this.textBox_Price.Text = (t.last - AddDiffPrice).ToString();
                        }

                    }
                }
            }
        }

        /// <summary>
        /// 释放回收
        /// </summary>
        public void Destroy()
        {
            //SubEvent
            //查成交-委托-持仓
            if (ConnectManager.CreateInstance().CONNECTION != null)
            {
                ConnectManager.CreateInstance().CONNECTION.AnsyRealDataEvent -= AnsyRealDataSubEvent;

                ConnectManager.CreateInstance().CONNECTION.AnsyOrderEvent -= AnsyOrderSubEvent;
                ConnectManager.CreateInstance().CONNECTION.AnsyPositionEvent -= AnsyPositionSubEvent;
                ConnectManager.CreateInstance().CONNECTION.AnsyTradeEvent -= AnsyTradeSubEvent;
                ConnectManager.CreateInstance().CONNECTION.AnsyMakeOrderEvent -= AnsyMakeOrderSubEvent;
            }
        }
    }
}
