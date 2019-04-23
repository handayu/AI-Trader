using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class VisualLogUserControl : UserControl
    {
        public VisualLogUserControl()
        {
            InitializeComponent();

            ConnectManagerSinlethon.CreateInstance().AnsyLoginEvent += AnsyLoginSubHandle;
            ConnectManagerSinlethon.CreateInstance().AnsyServerTimeEvent += AnsyServerSubHandle;
            ConnectManagerSinlethon.CreateInstance().AnsyGetInsEvent += AnsyGetInsSubHandle;

        }

        private void AnsyGetInsSubHandle(AIEventArgs args)
        {
            AppendLog(args.info + args.EventData);
        }

        private void AnsyServerSubHandle(AIEventArgs args)
        {
            AppendLog(args.info);
        }

        private void AnsyLoginSubHandle(AIEventArgs args)
        {
            AppendLog(args.info);
        }

        private void AppendLog(string text)
        {
            if(this.InvokeRequired)
            {
                this.BeginInvoke(new Action<string>(AppendLog),text);
            }

            this.richTextBox1.AppendText("\n" + DateTime.Now.ToString() + ":" + "\n" + text);
        }
    }
}
