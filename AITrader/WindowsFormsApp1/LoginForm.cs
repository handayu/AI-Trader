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
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void button_Login_Click(object sender, EventArgs e)
        {
            string api = this.textBox_apikey.Text;
            string ser = this.textBox_serkets.Text;
            string pas = this.textBox_passphear.Text;

            //主FormLiad的时候已经初始化生成了对象现在给值---登陆
            ConnectManagerSinlethon.CreateInstance().InitApiLogin(api, ser, pas);

            //登陆完成--获取所有合约信息
            ConnectManagerSinlethon.CreateInstance().AnsyGetInstrumentsSwap();

        }

        private void button_Cancel_Click(object sender, EventArgs e)
        {

        }

        private void button_ansyTime_ClickAsync(object sender, EventArgs e)
        {
            button_ansyTime_ClickAsync();
        }

        private async Task button_ansyTime_ClickAsync()
        {
            await ConnectManagerSinlethon.CreateInstance().AnsyServerTimeAsync();
        }
    }
}
