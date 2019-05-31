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
    public partial class QuickOrderForm : Form
    {
        public QuickOrderForm()
        {
            InitializeComponent();
        }

        private void Form_Load(object sender, EventArgs e)
        {
            this.quickOrderUserControl1.SubScribe();
        }

        private void Form_Closed(object sender, FormClosedEventArgs e)
        {
            this.quickOrderUserControl1.Destroy();
        }
    }
}
