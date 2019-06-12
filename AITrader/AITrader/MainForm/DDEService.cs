using DDE;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using APIConnect;
using Common;

namespace AITrader
{
    public partial class DDEService : Form
    {
        private DDEServer m_service = null;

        private MCDataLooper m_looper = null;

        public DDEService()
        {
            InitializeComponent();

            //逆向
            this.pictureBox_TradeDown.Image.RotateFlip(RotateFlipType.Rotate180FlipY);
            this.pictureBox_TradeUp.Image.RotateFlip(RotateFlipType.Rotate180FlipY);

            //handle
            //加载账户配置文件
            string path = System.Windows.Forms.Application.StartupPath + "\\config.ini";
            IniOperationClass c = new IniOperationClass(path);
            this.textBox_Handle.Text = c.IniReadValue("handle", "mchandle");
        }

        private void Button_Start_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.textBox_Service.Text == "" || this.textBox_Topic.Text == "")
                {
                    MessageBox.Show("Service or Topic can not be null");
                    return;
                }
                string service = this.textBox_Service.Text;
                string topic = this.textBox_Topic.Text;

                m_service = new DDEServer(service, topic, ConnectManager.CreateInstance().InstrumentList);
                m_service.MarketDataRealCallEvent += M_service_MarketDataRealCallEvent;

                this.textBox_Service.Enabled = false;
                this.textBox_Topic.Enabled = false;
                this.button_Start.Enabled = false;

            }
            catch (Exception ex)
            {
                MessageBox.Show("启动失败:" + ex.Message);

                this.textBox_Service.Enabled = true;
                this.textBox_Topic.Enabled = true;
                this.button_Start.Enabled = true;

                this.pictureBoxDown.Visible = true;
                this.pictureBoxUp.Visible = true;
            }
        }

        /// <summary>
        /// 检查行情是否还在正常推送中
        /// </summary>
        private void M_service_MarketDataRealCallEvent()
        {
            MarketData_BLing();
        }

        private void MarketData_BLing()
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke(new Action(MarketData_BLing));
                return;
            }

            if (this.pictureBoxDown.Visible)
            {
                this.pictureBoxDown.Visible = false;
                this.pictureBoxUp.Visible = false;
            }
            else
            {
                this.pictureBoxDown.Visible = true;
                this.pictureBoxUp.Visible = true;
            }
        }

        private void Trade_BLing()
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke(new Action(Trade_BLing));
                return;
            }

            if (this.pictureBox_TradeDown.Visible)
            {
                this.pictureBox_TradeDown.Visible = false;
                this.pictureBox_TradeUp.Visible = false;
            }
            else
            {
                this.pictureBox_TradeDown.Visible = true;
                this.pictureBox_TradeUp.Visible = true;
            }
        }

        /// <summary>
        /// 交易管道设定-开启灯定时器和获取txt定时器
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_TradePiple_Click(object sender, EventArgs e)
        {
            if(textBox_Handle.Text == "" || this.m_looper == null)
            {
                MessageBox.Show("请先完成MC_PLEDIT测试");
                return;
            }

            this.timer_PLMCEdit.Enabled = true;
            this.timer_PLMCEdit.Start();

        }

        /// <summary>
        /// PL发送清空和获取测试
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_coverPL_Click(object sender, EventArgs e)
        {
            if(this.textBox_Handle.Text == "")
            {
                MessageBox.Show("请先填写Handle");
                return;
            }

            IntPtr handle = (IntPtr)Convert.ToInt32(this.textBox_Handle.Text, 16);
            McOutPutWndHooker hooker = new McOutPutWndHooker(handle);
            hooker.SendMessageToOutPutWnd("");

            if (m_looper == null)
            {
                m_looper = new MCDataLooper(handle);
            }
        }

        private void Button_GetPL_Click(object sender, EventArgs e)
        {
            if (this.textBox_Handle.Text == "")
            {
                MessageBox.Show("请先填写Handle");
                return;
            }

            try
            {
                IntPtr handle = (IntPtr)Convert.ToInt32(this.textBox_Handle.Text, 16);
                McOutPutWndHooker hooker = new McOutPutWndHooker(handle);
                string result = hooker.SendMessageToHoldOutPutMessage();

                if (m_looper == null)
                {
                    m_looper = new MCDataLooper(handle);
                }

                //转换成List然后对于收到的Print进行分类
                List<string> strInfoList = result.Split(new char[] { '\r', '\n' }).ToList();

                List<string> newStrinfoList = new List<string>();

                foreach (string str in strInfoList)
                {
                    if (str != "")
                    {
                        newStrinfoList.Add(str);
                    }
                }

                foreach (string strInfo in newStrinfoList)
                {
                    NotifyAppendTextRich(strInfo);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("获取内容分类或者超出获取的索引范围，检查...");
                return;
            }
        }

        private void NotifyAppendTextRich(string data)
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke(new Action<string>(NotifyAppendTextRich), data);
            }

            this.richTextBox_PL.AppendText("\n" + data);
        }

        /// <summary>
        /// 定时器获取内容-发单
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TimerEvent_MCData(object sender, EventArgs e)
        {
            this.timer_PLMCEdit.Stop();

            try
            {
                if (m_looper == null) return;
                string strMc = m_looper.GetMCData();
                if (strMc == "") return;

                Trade_BLing();

                //转换成List然后对于收到的Print进行分类
                List<string> strInfoList = strMc.Split(new char[] { '\r', '\n' }).ToList();

                List<string> newStrinfoList = new List<string>();

                foreach (string str in strInfoList)
                {
                    if (str != "")
                    {
                        newStrinfoList.Add(str);
                    }
                }

                foreach (string strInfo in newStrinfoList)
                {
                    //筛选出来下单
                    if (!strInfo.Contains("AITrader")) continue;
                    string[] array = strInfo.Split('_');

                    //
                    string ins = array[3];
                    decimal orderP = 0;
                    string price = array[6];
                    decimal.TryParse(price, out orderP);
                    string num = array[5];
                    string direc = array[4];
                    //
                    if(direc == "BUY")
                    {
                        OderAction.BuyToCover(ins, orderP, num);

                        System.Threading.Thread.Sleep(1000);

                        OderAction.Buy(ins, orderP, num);
                    }

                    if (direc == "SELLSHORT")
                    {
                        OderAction.Sell(ins, orderP, num);

                        System.Threading.Thread.Sleep(1000);

                        OderAction.SellShort(ins, orderP, num);
                    }
                }
            }
            catch (Exception ex)
            {

            }

            this.timer_PLMCEdit.Start();

        }

        /// <summary>
        /// 交易测试
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Buy_Click(object sender, EventArgs e)
        {
            decimal orderP = 0;
            string price = this.textBox_BuyPrice.Text;
            decimal.TryParse(price, out orderP);

            OderAction.Buy("BTC-USD-SWAP", orderP, "1");
        }

        private void Button_Sellshort_Click(object sender, EventArgs e)
        {
            decimal orderP = 0;
            string price = this.textBox_CoverPrice.Text;
            decimal.TryParse(price, out orderP);

            OderAction.Sell("BTC-USD-SWAP", orderP, "1");
        }

        private void Button_stop_Click(object sender, EventArgs e)
        {
            this.timer_PLMCEdit.Enabled = false;
            this.timer_PLMCEdit.Stop();
        }
    }
}
