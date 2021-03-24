using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZedGraph;
using System.Diagnostics;

namespace WindowsFormsApp1
{
    public partial class TestZedGraphForm : Form
    {
        private List<OHLCBarItem> m_LineItemList = new List<OHLCBarItem>();


        public TestZedGraphForm()
        {
            InitializeComponent();

            Form_Load(null, null);
        }

        private void Form_Load(object sender, EventArgs e)
        {
            GraphPane mPane = zedGraphControl1.GraphPane;//获取索引到GraphPane面板上


            PointPairList dataList = new PointPairList();

            int x = 0;

            for (int j = 0; j < 100; j++)
            {
                PointPair pairData = new PointPair();

                Random d = new Random();
                int sysInt = d.Next(0, 50);

                int y = sysInt;


                pairData.X = x;
                pairData.Y = y;

                dataList.Add(pairData);

                x++;
            }

            //OHLCBarItem mCure = mPane.AddBar("KLine", dataList, Color.Red);
            //m_LineItemList.Add(mCure);
            zedGraphControl1.AxisChange();//画到zedGraphControl1控件中，此句必加        
        }
    }
}
