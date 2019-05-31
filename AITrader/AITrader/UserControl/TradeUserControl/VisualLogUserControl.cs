using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Common;
using APIConnect;

namespace WindowsFormsApp1
{
    public partial class VisualLogUserControl : UserControl
    {
        public VisualLogUserControl()
        {
            InitializeComponent();
        }

        public void SubScribe()
        {
            if(ConnectManager.CreateInstance().CONNECTION != null)
            {
                ConnectManager.CreateInstance().CONNECTION.AnsyLoginEvent += AnsyLoginSubHandle;
                ConnectManager.CreateInstance().CONNECTION.AnsyServerTimeEvent += AnsyServerSubHandle;
                ConnectManager.CreateInstance().CONNECTION.AnsyGetInsEvent += AnsyGetInsSubHandle;
                ConnectManager.CreateInstance().CONNECTION.AnsyRealDataEvent += AnsyTickerSubEvent;
                ConnectManager.CreateInstance().CONNECTION.AnsyAccountDataEvent += AnsyAccountDataSubEvent;
                ConnectManager.CreateInstance().CONNECTION.AnsyMakeOrderEvent += AnsyMakeOrderSubEvent;
            }

        }

        private void AnsyAccountDataSubEvent(AIEventArgs args)
        {
            AppendLog(args.EventData.ToString());
        }

        private void AnsyMakeOrderSubEvent(AIEventArgs args)
        {
            AppendLog(args.EventData.ToString());
        }

        private void AnsyGetInsSubHandle(AIEventArgs args)
        {
            AppendLog(args.EventData.ToString());
        }

        private void AnsyServerSubHandle(AIEventArgs args)
        {
            AppendLog(args.EventData.ToString());
        }

        private void AnsyLoginSubHandle(AIEventArgs args)
        {
            AppendLog(args.EventData.ToString());
        }

        private void AppendLog(string text)
        {
            if(this.InvokeRequired)
            {
                this.BeginInvoke(new Action<string>(AppendLog),text);
                return;
            }

            this.richTextBox1.AppendText("\n" + DateTime.Now.ToString() + ":" + "\n" + text);
        }

        private void UserControl_Load(object sender, EventArgs e)
        {


        }

        private void AnsyTickerSubEvent(AIEventArgs args)
        {
            AppendLog(args.EventData.ToString());
        }
    }
}
