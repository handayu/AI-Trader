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
    public partial class LawNotifyForm : Form
    {
        public LawNotifyForm()
        {
            InitializeComponent();
        }

        private void Button_ok_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Button_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
