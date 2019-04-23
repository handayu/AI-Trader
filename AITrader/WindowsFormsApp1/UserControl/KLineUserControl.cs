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
    public partial class KLineUserControl : UserControl
    {
        public KLineUserControl()
        {
            InitializeComponent();

            //在这里订阅实时行情和K线行情画图--在另外的地方会启动线程不断的请求行情
            ConnectManagerSinlethon.CreateInstance().AnsyKLineEvent += AnsyKLineSubEvent;
            ConnectManagerSinlethon.CreateInstance().AnsyTickerEvent += AnsyTickerSubEvent;
        }

        private void AnsyTickerSubEvent(AIEventArgs args)
        {
            if (this.InvokeRequired)
            {

            }
        }

        private void AnsyKLineSubEvent(AIEventArgs args)
        {
            if (this.InvokeRequired)
            {

            }
        }
    }
}
