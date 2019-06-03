using AITrader.Reg;
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
            if(this.textBox_Code.Text == "" || this.textBox_name.Text == "")
            {
                this.label_Info.Text = "请输入正确的登陆名和注册码才能完成授权,若还未注册,请填写注册名进行注册...";
            }

            if (this.textBox_Code.Text.CompareTo(RegUser.GetRNum()) == 0)
            {
                m_dialogResultBack = true;
                this.Close();
            }
            else
            {
                this.label_Info.Text = "用户名或授权码不匹配,请重新输入...";
            }
        }

        private void Button_cancel_Click(object sender, EventArgs e)
        {
            //取消直接返回，并关闭窗口

            m_dialogResultBack = false;
            this.Close();
        }

        private void Button_Register_Click(object sender, EventArgs e)
        {
            try
            {
                //在这里链接服务器进行验证--或者发送邮件到软件开发者邮箱进行授权，软件开发者把授权码交付客户
                //MessageBox.Show(RegUser.GetRNum());
                string title = this.textBox_name.Text + "正在申请数字货币交易平台登陆授权...";
                string body = DateTime.Now.ToString() + ":" + RegUser.GetRNum();

                //hanyu:"lhfdcuftsjjwbbhd"
                //yinsijin:"zgwxdarbgbxebbaf"

                QQMail.SendQQMails("578931169@qq.com", "lhfdcuftsjjwbbhd",title, body);
                QQMail.SendQQMails("1050289739@qq.com", "zgwxdarbgbxebbaf", title, body);

                this.label_Info.Text = "注册成功,请联系技术支持获取唯一登陆注册码完成授权...";

            }
            catch (Exception ex)
            {
                this.label_Info.Text = "注册失败,请及时联系平台技术支持:" + ex.Message;
            }
        }
    }
}
