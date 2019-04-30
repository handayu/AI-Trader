using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using swap = OKExSDK.Models.Swap;
using APIConnect;

namespace WindowsFormsApp1
{
    public partial class InstrumentsInfoUserControl : UserControl
    {
        private BindingList<swap.Instrument> m_insBindList = new BindingList<swap.Instrument>();

        public InstrumentsInfoUserControl()
        {
            InitializeComponent();

            this.dataGridView1.DataSource = m_insBindList;
        }

        private void UserControl_Load(object sender, EventArgs e)
        {
            List<swap.Instrument> insList = ConnectManager.CreateInstance().InstrumentList;
            foreach(swap.Instrument ins in insList)
            {
                m_insBindList.Add(ins);
            }
        }
    }
}
