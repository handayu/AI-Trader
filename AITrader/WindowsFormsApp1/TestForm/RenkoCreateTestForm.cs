using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class RenkoCreateTestForm : Form
    {
        public RenkoCreateTestForm()
        {
            InitializeComponent();
        }


        private double m_StartPrice = 0;
        private List<double> m_renkoPriceList = new List<double>();
        private double m_RealPrice = 0;

        private void button_MarketClick(object sender, EventArgs e)
        {
            //if (m_StartPrice == 0)
            //{
            //    m_StartPrice = startPrice;
            //    m_RealPrice = startPrice;

            //    return;
            //}

            ////BOXSize
            //int BoxSize = 0;
            //int.TryParse(this.textBox_RenkoBoxSize.Text, out BoxSize);

            //double startPrice = 0.00;
            //double.TryParse(this.textBox_StartPrice.Text, out startPrice);

            //double addprice = 0.00;
            //double.TryParse(this.textBox_AddPrice.Text, out addprice);

            //double m_RealPrice = startPrice + 

            //if (m_StartPrice == 0)
            //{
            //    m_StartPrice = startPrice;
            //    m_RealPrice = startPrice;
            //}
            //else
            //{

            //    if()

            //}

        }


    }
}
