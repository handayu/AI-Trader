using Common;
using Reg;
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
        private string m_dialogResultBack = string.Empty;

        public RegForm(Point p, int width, int height)
        {
            InitializeComponent();

            try
            {
                //加载账户配置文件
                string path = System.Windows.Forms.Application.StartupPath + "\\config.ini";
                IniOperationClass c = new IniOperationClass(path);
                this.textBox_name.Text = c.IniReadValue("license", "name");
                this.textBox_Code.Text = c.IniReadValue("license", "code");
            }
            catch (Exception ex)
            {
                MessageBox.Show("加载默认注册配置失败:" + ex.Message);
            }



            //显示在主窗口的右下角的位置
            this.Location = new Point(p.X + width - this.Width, p.Y + height - this.Height);
        }

        public string DialogResultBack
        {
            get
            {
                return "true:" + this.textBox_name.Text + ":" + this.textBox_Code.Text;
            }

            set
            {
                m_dialogResultBack = "false:0:0";
            }
        }

        private void Button_OK_Click(object sender, EventArgs e)
        {
            //MessageBox.Show(RegUser.GetMacByNetworkInterface());

            if (this.textBox_Code.Text == "" || this.textBox_name.Text == "")
            {
                this.label_Info.Text = "请输入正确的登陆名和注册码才能完成授权,若还未注册,请填写注册名进行注册...";
            }

            if (this.textBox_Code.Text.CompareTo(RegUser.GetRNum()) == 0)
            {
                m_dialogResultBack = "true:" + this.textBox_name.Text + ":" + this.textBox_Code.Text;
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

            m_dialogResultBack = "false:0:0";
            this.Close();
        }

        private void Button_Register_Click(object sender, EventArgs e)
        {
            try
            {
                //在这里链接服务器进行验证--或者发送邮件到软件开发者邮箱进行授权，软件开发者把授权码交付客户
                //MessageBox.Show(CalBody());
                string title = this.textBox_name.Text + "正在申请数字货币交易平台登陆授权...";
                string body = CalBody();

                //hanyu:"lhfdcuftsjjwbbhd"
                //yinsijin:"zgwxdarbgbxebbaf"

                QQMail.SendQQMailsHANYU(title, body);
                QQMail.SendQQMailsYINSI(title, body);

                this.label_Info.Text = "注册成功,请联系技术支持获取唯一登陆注册码完成授权...";

                this.button_Register.Enabled = false;

            }
            catch (Exception ex)
            {
                this.label_Info.Text = "注册失败,请及时联系平台技术支持:" + ex.Message;
            }
        }

        private string CalBody()
        {
            string body = DateTime.Now.ToString() + ":" + "\n" +
                "发给客户的授权码:" + RegUser.GetRNum() + "\n" +
                "客户的全球MAC地址:" + RegUser.GetMacByNetworkInterface();
            //"客户的外网IP地址:" + RegUser.GetClientInternetIPAddress();

            return body;
        }
    }
}
