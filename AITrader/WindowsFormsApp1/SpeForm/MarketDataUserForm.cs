using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;

namespace WindowsFormsApp1
{
    public partial class MarketDataUserForm : DockContent
    {
        public MarketDataUserForm()
        {
            InitializeComponent();

            this.FormBorderStyle = FormBorderStyle.None;
        }

        public MarketDataUserControl MarketDataUserControlSelf
        {
            get
            {
                return this.marketDataUserControl1;
            }
        }

        private void Form_Load(object sender, EventArgs e)
        {
            this.marketDataUserControl1.SubScribe();

        }
    }
}
