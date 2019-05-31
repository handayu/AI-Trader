using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1.MainForm
{
    public partial class RegForm : Form
    {
        private bool m_dialogResultBack = false;

        public RegForm(Point p,int width,int height)
        {
            InitializeComponent();

            //显示在主窗口的右下角的位置
            this.Location = new Point(p.X + width - this.Width, p.Y + height - this.Height);
        }

        public bool DialogResultBack
        {
            get
            {
                return m_dialogResultBack;
            }

            set
            {
                m_dialogResultBack = value;
            }
        }

        private void Button_OK_Click(object sender, EventArgs e)
        {
            //在这里链接服务器进行验证返回成功并关闭窗口

            m_dialogResultBack = true;
            this.Close();
        }

        private void Button_cancel_Click(object sender, EventArgs e)
        {
            //取消直接返回，并关闭窗口

            m_dialogResultBack = false;
            this.Close();
        }
    }
}
