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
    public partial class TradeUserControl : UserControl
    {
        public TradeUserControl()
        {
            InitializeComponent();

        }

        private void Tabpage_SelectingClick(object sender, TabControlCancelEventArgs e)
        {
        }

        private void TradeUserControl_Load(object sender, EventArgs e)
        {

            this.visualLogUserControl1.SubScribe();
            this.visualTradingUserControl1.SubScribe();
            this.quickOrderUserControl1.SubScribe();
        }

        private void VisualTradingUserControl1_Load(object sender, EventArgs e)
        {

        }
    }
}
