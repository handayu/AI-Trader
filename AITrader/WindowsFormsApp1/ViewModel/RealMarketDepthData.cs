using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    public class RealMarketDepthData
    {
        public Image UpDown
        {
            get;
            set;
        }

        public string Ins
        {
            get;
            set;
        }

        public double Ask
        {
            set;
            get;
        }

        public double Bid
        {
            set;
            get;
        }
    }
}
