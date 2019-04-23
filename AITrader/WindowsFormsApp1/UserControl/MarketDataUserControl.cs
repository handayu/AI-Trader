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
    public partial class MarketDataUserControl : UserControl
    {
        public MarketDataUserControl()
        {
            InitializeComponent();

            ConnectManagerSinlethon.CreateInstance().AnsyGetInsEvent += AnsyGetInsSubEvent;
            ConnectManagerSinlethon.CreateInstance().AnsyTickerEvent += AnsyTickerSubEvent;

        }

        private void AnsyTickerSubEvent(AIEventArgs args)
        {
            
        }

        private void AnsyGetInsSubEvent(AIEventArgs args)
        {
            
        }
    }
}
