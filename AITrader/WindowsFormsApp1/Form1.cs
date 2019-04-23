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
    }
}
