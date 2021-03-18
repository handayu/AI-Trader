using APIConnect;
using Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using swap = OKExSDK.Models.Swap;

namespace WindowsFormsApp1
{
    public partial class LoginForm2 : Form
    {
        private Form1 m_MainForm = null;
        private BackgroundWorker m_BackgroundWorker = new BackgroundWorker();
        public LoginForm2()
        {
            InitializeComponent();

            this.comb_Server.SelectedIndex = 0;
            this.comboBox_SimReal.SelectedIndex = 0;

        }

        private void btn_Login_Click(object sender, EventArgs e)
        {
            string api = this.textBox_apikey.Text;
            string ser = this.textBox_serkets.Text;
            string pas = this.textBox_passphear.Text;


            ConnectManager.CreateInstance().CONNECTION.AnsyLoginEvent += AnsyLoginSubEvent;

            //查合约
            ConnectManager.CreateInstance().CONNECTION.AnsyGetInsEvent += AnsyGetInsSubEvent;

            //查成交-委托-持仓
            ConnectManager.CreateInstance().CONNECTION.AnsyOrderEvent += AnsyOrderSubEvent;
            ConnectManager.CreateInstance().CONNECTION.AnsyPositionEvent += AnsyPositionSubEvent;
            ConnectManager.CreateInstance().CONNECTION.AnsyTradeEvent += AnsyTradeSubEvent;


            //主FormLiad的时候已经初始化生成了对象现在给值---登陆
            ConnectManager.CreateInstance().CONNECTION.InitApiLogin(api, ser, pas);

            //开始开启永续和币币交易线程推送实时行情
            ConnectManager.CreateInstance().CONNECTION.StartThreadTicker();
            ConnectManager.CreateInstance().CONNECTION.StartSpotThreadTicker();


            m_BackgroundWorker.DoWork += BGWorker_DoWork;
            m_BackgroundWorker.RunWorkerAsync();
        }

        private void BGWorker_DoWork(object sender, DoWorkEventArgs e)
        {

        }

        #region 持仓-成交-委托
        private void AnsyTradeSubEvent(AIEventArgs args)
        {
            if (args.ReponseMessage == RESONSEMESSAGE.HOLDTRADE_SUCCESS)
            {
                ConnectManager.CreateInstance().TradeList = (List<swap.Trade>)args.EventData;
            }
        }

        private void AnsyPositionSubEvent(AIEventArgs args)
        {

        }

        private void AnsyOrderSubEvent(AIEventArgs args)
        {
            if (args.ReponseMessage == RESONSEMESSAGE.HOLDORDER_SUCCESS)
            {
                ConnectManager.CreateInstance().OrderList = (swap.OrderListResult)args.EventData;
            }
        }
        #endregion
        /// <summary>
        /// 登陆成功完成-查到所有的合约-查持仓-查成家-查委托
        /// </summary>
        /// <param name="args"></param>
        private void AnsyGetInsSubEvent(AIEventArgs args)
        {
            if (args.ReponseMessage == RESONSEMESSAGE.HOLDINSTRUMENTS_SUCCESS)
            {
                List<swap.Instrument> insList = (List<swap.Instrument>)args.EventData;
                foreach (swap.Instrument ins in insList)
                {
                    ConnectManager.CreateInstance().AddInstrument(ins);
                }


                if (insList != null && insList.Count > 0)
                {
                    foreach (swap.Instrument ins in insList)
                    {
                        ConnectManager.CreateInstance().CONNECTION.AnsyOrdersByInstrumentSwap(ins.instrument_id, "2", 1, null, 10);
                        ConnectManager.CreateInstance().CONNECTION.AnsyPositionByInstrumentSwap(ins.instrument_id);
                        ConnectManager.CreateInstance().CONNECTION.AnsyTradeByInstrumentSwap(ins.instrument_id, 1, null, 10);
                    }
                }
            }
        }

        private void AnsyLoginSubEvent(AIEventArgs args)
        {
            if (args.ReponseMessage == RESONSEMESSAGE.LOGIN_SUCCESS)
            {
                //登陆完成--获取所有合约信息-成交-委托-持仓信息
                ConnectManager.CreateInstance().CONNECTION.AnsyGetInstrumentsSwap();

                this.Hide();
                m_MainForm = new Form1();
                m_MainForm.Show();
            }

            if (args.ReponseMessage == RESONSEMESSAGE.LOGIN_FAILED)
            {
                MessageBox.Show("登陆失败,请重新确认后登陆...");
                return;
            }
        }
        private void button_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void DetroyClick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form_Load(object sender, EventArgs e)
        {
            //加载账户配置文件
            string path = System.Windows.Forms.Application.StartupPath + "\\config.ini";
            IniOperationClass c = new IniOperationClass(path);
            this.textBox_apikey.Text = c.IniReadValue("account", "apikey");
            this.textBox_serkets.Text = c.IniReadValue("account", "secrets");
            this.textBox_passphear.Text = c.IniReadValue("account", "passphera");
        }

        private void Form_Closed(object sender, FormClosedEventArgs e)
        {
            string path = System.Windows.Forms.Application.StartupPath + "\\config.ini";
            IniOperationClass c = new IniOperationClass(path);
            c.IniWriteValue("account", "apikey", this.textBox_apikey.Text);
            c.IniWriteValue("account", "secrets", this.textBox_serkets.Text);
            c.IniWriteValue("account", "passphera", this.textBox_passphear.Text);
        }

        private void SiimRealTradeing_SelectChaned(object sender, EventArgs e)
        {
            string nowSel = this.comboBox_SimReal.SelectedItem.ToString();
            if (nowSel.CompareTo("实盘") == 0)
            {

                this.textBox_apikey.Enabled = true;
                this.textBox_serkets.Enabled = true;
                this.textBox_passphear.Enabled = true;

                //加载账户配置文件
                string path = System.Windows.Forms.Application.StartupPath + "\\config.ini";
                IniOperationClass c = new IniOperationClass(path);
                this.textBox_apikey.Text = c.IniReadValue("account", "apikey");
                this.textBox_serkets.Text = c.IniReadValue("account", "secrets");
                this.textBox_passphear.Text = c.IniReadValue("account", "passphera");

                //在这里
                //在这里可以切换实盘和模拟盘
                ConnectManager.Start();
                IConnectManagerSinlethon manager = new ConnectManagerSinlethonReal();

                ConnectManager.CreateInstance().ClearIConnection();
                ConnectManager.CreateInstance().AddIConnect(manager);

            }
            else
            {
                this.textBox_apikey.Text = "";
                this.textBox_serkets.Text = "";
                this.textBox_passphear.Text = "";

                this.textBox_apikey.Enabled = false;
                this.textBox_serkets.Enabled = false;
                this.textBox_passphear.Enabled = false;

                ConnectManager.Start();
                IConnectManagerSinlethon manager = new ConnectManagerSinlethonTest();

                ConnectManager.CreateInstance().ClearIConnection();
                ConnectManager.CreateInstance().AddIConnect(manager);
            }
        }
    }
}
