using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using swap = OKExSDK.Models.Swap;
using Common;
using APIConnect;

namespace WindowsFormsApp1
{
    public partial class VisualTradingUserControl : UserControl
    {
        private BindingList<swap.Account> m_accountBindList = new BindingList<swap.Account>();


        public VisualTradingUserControl()
        {
            InitializeComponent();

            this.dataGridView1.DataSource = m_accountBindList;

        }

        public void SubScribe()
        {
            if(ConnectManager.CreateInstance().CONNECTION != null) 
            ConnectManager.CreateInstance().CONNECTION.AnsyAccountDataEvent += AnsyAccountDataSubEvent;
        }

        private void AnsyAccountDataSubEvent(AIEventArgs args)
        {
            if(args.ReponseMessage == RESONSEMESSAGE.HOLDACCOUNTS_SUCCESS)
            {
                m_accountBindList.Clear();

                swap.AccountsResult accsRes = (swap.AccountsResult)args.EventData;
                List<swap.Account> aList = accsRes.info;

                foreach(swap.Account a in aList)
                {
                    m_accountBindList.Add(a);
                }
            }
        }

        private void Button_Freash_Click(object sender, EventArgs e)
        {
            ConnectManager.CreateInstance().CONNECTION.AnsyAccountsSwap();
        }
    }
}
