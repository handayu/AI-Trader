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
    public partial class QuickOrderUserControl : UserControl
    {
        public QuickOrderUserControl()
        {
            InitializeComponent();

            this.AppendText("启动快捷下单面板成功...");
        }

        /// <summary>
        /// 订阅-实时行情-成交-委托-持仓回报
        /// </summary>
        public void SubScribe()
        {

        }


        private void AppendText(string str)
        {
            if(this.InvokeRequired)
            {
                this.BeginInvoke(new Action<string>(AppendText), str);
            }

            this.richTextBox_Log.AppendText("\n" + DateTime.Now.ToString() + ":" + "\n" + str);
        }

        private void button_Buy_Click(object sender, EventArgs e)
        {

        }

        private void button_SellShort_Click(object sender, EventArgs e)
        {

        }

        private void button_OppositePrice_Click(object sender, EventArgs e)
        {

        }

        private void button_Buy_Click_1(object sender, EventArgs e)
        {

        }
    }
}
