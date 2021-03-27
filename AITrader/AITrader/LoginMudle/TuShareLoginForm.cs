using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TestProxy;

namespace WindowsFormsApp1
{
    public partial class TuShareLoginForm : Form
    {
        public TuShareLoginForm()
        {
            InitializeComponent();
        }

        private void button_Test_Click(object sender, EventArgs e)
        {
            ReqLoginData data = new ReqLoginData();
            data.Exdata = this.textBox_apiName.Text + "|" + this.textBox_tocken.Text;

            ReqHistoryData hisData = new ReqHistoryData();
            hisData.Code = this.textBox_testStockCode.Text;
            hisData.Frame = FRAME.Day;
            hisData.MarketType = MARKETTYPE.Stock;
            hisData.StartDate = this.dateTimePicker_start.Value;
            hisData.EndDate = this.dateTimePicker_end.Value;

            //初始化信息
            ProxyManager.GetInstance().GetProxy(EXCHANGETHROUGH.TuShare).Init(data);

            ///查询历史数据信息
            ProxyManager.GetInstance().GetProxy(EXCHANGETHROUGH.TuShare).QueryHistory(hisData);

            ///订阅数据
            ProxyManager.GetInstance().GetProxy(EXCHANGETHROUGH.TuShare).OnTickEvent += TuShareLoginForm_OnTickEvent;

        }

        private void TuShareLoginForm_OnTickEvent(RspHistoryData hD)
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke(new Action<RspHistoryData>(TuShareLoginForm_OnTickEvent), hD);
                return;
            }
            this.richTextBox_Log.AppendText("\n" + hD.Code + " | " + hD.TradingDate + " | " + hD.Close );
        }

        private void Form_Load(object sender, EventArgs e)
        {
            this.dateTimePicker_start.Format = DateTimePickerFormat.Custom;
            this.dateTimePicker_start.CustomFormat = "yyyyMMdd";

            this.dateTimePicker_end.Format = DateTimePickerFormat.Custom;
            this.dateTimePicker_end.CustomFormat = "yyyyMMdd";
        }

        private void Form_Closing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            e.Cancel = true;
        }
    }
}
