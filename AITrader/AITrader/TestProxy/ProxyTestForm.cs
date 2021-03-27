using IronPython.Hosting;
using Microsoft.Scripting.Hosting;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TestProxy;

namespace AITrader
{
    public partial class ProxyTestForm : Form
    {


        public ProxyTestForm()
        {
            InitializeComponent();
        }

        private void Form_Load(object sender, EventArgs e)
        {

            ProxyManager.GetInstance().GetProxy(EXCHANGETHROUGH.Demo).OnLoginEvent += M_dP_OnFrontConnectedEvent;
            ProxyManager.GetInstance().GetProxy(EXCHANGETHROUGH.Demo).OnTickEvent += M_dP_OnRtnDataEvent;

        }

        private void M_dP_OnRtnDataEvent(RspHistoryData hD)
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke(new Action<RspHistoryData>(M_dP_OnRtnDataEvent),hD);
                return;
            }

            this.richTextBox_log.AppendText("\n" + hD.Close);
        }

        private void M_dP_OnRspUserLoginEvent()
        {
        }

        private void M_dP_OnFrontConnectedEvent()
        {
            if(this.InvokeRequired)
            {
                this.BeginInvoke(new Action(M_dP_OnFrontConnectedEvent));
                return;
            }
            this.richTextBox_log.AppendText("M_dP_OnFrontConnectedEvent: " + DateTime.Now.ToShortTimeString());
        }

        private void button_login_Click(object sender, EventArgs e)
        {
            ProxyManager.GetInstance().GetProxy(EXCHANGETHROUGH.Demo).Init(null);

            ProxyManager.GetInstance().GetProxy(EXCHANGETHROUGH.Demo).Login();
        }

        private void button_logout_Click(object sender, EventArgs e)
        {
            ProxyManager.GetInstance().GetProxy(EXCHANGETHROUGH.Demo).Close();

        }

        private void button_dingyue_Click(object sender, EventArgs e)
        {
            string[] strList = { "" };
            ProxyManager.GetInstance().GetProxy(EXCHANGETHROUGH.Demo).SubScribe();
        }

        /// <summary>
        /// 测试py调用
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_testPy_Click(object sender, EventArgs e)
        {
            ScriptRuntime pyRuntime = Python.CreateRuntime();
            dynamic py = pyRuntime.UseFile(@"C:\Users\Administrator\Desktop\test.py");
            //string a = py;

            //this.richTextBox_log.AppendText("\n" + a);
        }

        private void Form_Closing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            e.Cancel = true;
        }
    }
}
