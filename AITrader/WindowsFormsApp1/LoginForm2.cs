using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using swap = OKExSDK.Models.Swap;

namespace WindowsFormsApp1
{
    public partial class LoginForm2 : Form
    {
        private Form1 m_MainForm = null;

        public LoginForm2()
        {
            InitializeComponent();
        }

        private void btn_Login_Click(object sender, EventArgs e)
        {
            string api = this.textBox_apikey.Text;
            string ser = this.textBox_serkets.Text;
            string pas = this.textBox_passphear.Text;

            //在这里可以切换实盘和模拟盘
            ConnectManager.Start();
            IConnectManagerSinlethon manager = new ConnectManagerSinlethonReal();
            ConnectManager.CreateInstance().AddIConnect(manager);

            ConnectManager.CreateInstance().CONNECTION.AnsyLoginEvent += AnsyLoginSubEvent;
            ConnectManager.CreateInstance().CONNECTION.AnsyGetInsEvent += AnsyGetInsSubEvent;


            //主FormLiad的时候已经初始化生成了对象现在给值---登陆
            ConnectManager.CreateInstance().CONNECTION.InitApiLogin(api, ser, pas);


        }

        private void AnsyGetInsSubEvent(AIEventArgs args)
        {
            if(args.ReponseMessage == RESONSEMESSAGE.HOLDINSTRUMENTS_SUCCESS)
            {
                List<swap.Instrument> insList = (List<swap.Instrument>)args.EventData;
                foreach (swap.Instrument ins in insList)
                {
                    ConnectManager.CreateInstance().AddInstrument(ins);
                }
            }
        }

        private void AnsyLoginSubEvent(AIEventArgs args)
        {
            if (args.ReponseMessage == RESONSEMESSAGE.LOGIN_SUCCESS)
            {
                //登陆完成--获取所有合约信息
                ConnectManager.CreateInstance().CONNECTION.AnsyGetInstrumentsSwap();

                this.Hide();
                m_MainForm = new Form1();
                m_MainForm.Show();
            }

            if (args.ReponseMessage == RESONSEMESSAGE.LOGIN_FAILED)
            {
                MessageBox.Show("登陆失败,请重新确认后登陆...");
                return;
            }
        }
        private void button_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void DetroyClick(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
