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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void ToolStripMenuItem_LoginClick(object sender, EventArgs e)
        {
            LoginForm f = new LoginForm();
            f.ShowDialog();
        }

        private void ToolStripMenuItem_LogOutClick(object sender, EventArgs e)
        {

        }

        private void Form_load(object sender, EventArgs e)
        {
            ConnectManagerSinlethon s = new ConnectManagerSinlethon();
        }

        private void AutoTrading_Click(object sender, EventArgs e)
        {

        }

        private void ToolStripMenuItem_testClick(object sender, EventArgs e)
        {
            TestForm f = new WindowsFormsApp1.TestForm();
            f.ShowDialog();
        }

        private void Edit_Click(object sender, EventArgs e)
        {
            //打开Edit进程--独立的进程
            System.Diagnostics.Process.Start(@"C:\Users\Administrator\Desktop\AI-Trader\Edi-master\Debug\Edi.exe");
        }
    }
}
