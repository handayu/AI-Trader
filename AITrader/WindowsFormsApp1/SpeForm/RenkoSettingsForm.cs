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
    public partial class RenkoSettingsForm : Form
    {
        private double m_boxSize = 0.00;
        private bool m_dialogresult = false;

        public RenkoSettingsForm()
        {
            InitializeComponent();
        }

        public double BoxSize
        {
            get
            {
                return m_boxSize;
            }
        }

        public bool RenkoDialogResult
        {
            get
            {
                return m_dialogresult;
            }
        }

        private void Button_OK_Click(object sender, EventArgs e)
        {
            double boxSizeDouble = 0.00;
            string boxsizeStr = this.textBox_RenkoBoxSize.Text;
            double.TryParse(boxsizeStr, out boxSizeDouble);
            m_boxSize = boxSizeDouble;
            m_dialogresult = true;

            this.Close();
        }

        private void Button_Cancel_Click(object sender, EventArgs e)
        {
            m_dialogresult = false;
            this.Close();
        }
    }
}
