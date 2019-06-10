using Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.MainForm;

namespace WindowsFormsApp1
{
    public partial class ListenceForm : Form
    {
        private LoginForm2 m_loginForm2 = null;


        private bool m_listceDialogBack = false;

        public ListenceForm()
        {
            InitializeComponent();
        }

        public bool DialoglistceBack
        {
            get
            {
                return m_listceDialogBack;
            }

            set
            {
                m_listceDialogBack = value;
            }
        }

        private void Button_Reg_Click(object sender, EventArgs e)
        {
            RegForm f = new RegForm(this.Location,this.Width,this.Height);
            f.ShowDialog();
            string[] ar = f.DialogResultBack.Split(':');
            if (ar == null || ar.Length <= 0) return;

            //如果注册码和名称验证成功
            if (ar[0] == "true")
            {
                m_listceDialogBack = true;

                //隐藏所有的说明控件以及按钮控件，显示出链接服务器进度条，缓冲2秒登陆
                this.button_Buy.Visible = false;
                this.button_Reg.Visible = false;
                this.panel_Group.Visible = false;
                this.pictureBox1.Location = new Point(this.Location.X + this.Width / 2, this.Location.Y + this.Height / 2);

                //停止相当于进程缓冲2秒
                //System.Threading.Thread.Sleep(2000);
                this.Hide();
                //写入ini配置
                string path = System.Windows.Forms.Application.StartupPath + "\\config.ini";
                IniOperationClass c = new IniOperationClass(path);
                c.IniWriteValue("license", "name", ar[1]);
                c.IniWriteValue("license", "code", ar[2]);

                m_loginForm2 = new LoginForm2();
                m_loginForm2.ShowDialog();
            }
            else//失败---(取消或者验证失败直接退出最外层的)
            {
                m_listceDialogBack = false;
                this.Close();
            }
        }

        private void ButtonBUY_Click(object sender, EventArgs e)
        {
            //打开链接进行联系和注册码申请
            try
            {
                //Process.Start("https://github.com/handayu/AI-Trader-DownLoad");
                GithubApi.GithubApiManager m = new GithubApi.GithubApiManager();
                m.GetCountAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
