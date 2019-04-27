using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OKExSDK.Models.Swap;
using WeifenLuo.WinFormsUI.Docking;
using swap = OKExSDK.Models.Swap;

namespace WindowsFormsApp1
{
    public partial class Form1 : DockContent
    {

        private MarketDataUserForm m_marketDataForm = null;
        private AccountStrategyUserForm m_accountStrategyForm = null;
        private TradeUserForm m_tradeUserForm = null;


        public Form1()
        {
            InitializeComponent();
        }

        private void ToolStripMenuItem_LoginClick(object sender, EventArgs e)
        {

        }

        private void ToolStripMenuItem_LogOutClick(object sender, EventArgs e)
        {

        }

        private void Form_load(object sender, EventArgs e)
        {

            foreach (Control c in this.Controls)
            {
                if (c is MdiClient)
                {
                    c.BackColor = Color.White; //颜色 
                }
            }


            //生成所有的有业务对象-然后再在这里管理所有的事件通知
            m_marketDataForm = new MarketDataUserForm();
            m_accountStrategyForm = new AccountStrategyUserForm();
            m_tradeUserForm = new TradeUserForm();
            m_marketDataForm.Show(dockPanel1, DockState.DockLeft);
            m_accountStrategyForm.Show(dockPanel1, DockState.DockRightAutoHide);
            m_tradeUserForm.Show(dockPanel1, DockState.DockBottomAutoHide);

            //行情点击事件订阅-生成窗口展示
            m_marketDataForm.MarketDataUserControlSelf.RealMarketDataClikEvent += RealMarketDataClikSubEvent;
        }


        private List<Form> m_OpenKLineFormList = new List<Form>();
        private void RealMarketDataClikSubEvent(swap.Ticker t)
        {
            if (t == null || t.instrument_id == "") return;

            foreach (Form f in m_OpenKLineFormList)
            {
                KLineFormTest fT = f as KLineFormTest;
                if (fT != null && fT.FORMNAME == t.instrument_id)
                {
                    MessageBox.Show("不能重复添加相同的品种图表...");
                    return;
                }
            }

            KLineFormTest form = new KLineFormTest(t);
            form.TopLevel = false;//设置为非顶级控件
            form.MdiParent = this;
            form.DeleteKLineFormEvent += DeleteKLineFormSubEvent;
            form.Show();

            m_OpenKLineFormList.Add(form);

            this.LayoutMdi(MdiLayout.TileHorizontal);
        }

        /// <summary>
        /// K线窗口关闭删除事件--清除List的存在的KLine
        /// </summary>
        /// <param name="t"></param>
        private void DeleteKLineFormSubEvent(Ticker t)
        {
            if (t == null || t.instrument_id == "") return;

            Form reForm = null;
            foreach (Form f in m_OpenKLineFormList)
            {
                if ((f as KLineFormTest) != null && (f as KLineFormTest).FORMNAME.CompareTo(t.instrument_id) == 0)
                {
                    reForm = f;
                    break;
                }
            }

            if (reForm == null) return;
            m_OpenKLineFormList.Remove(reForm);
        }

        private void AutoTrading_Click(object sender, EventArgs e)
        {

        }

        private void ToolStripMenuItem_testClick(object sender, EventArgs e)
        {
            TestForm f = new WindowsFormsApp1.TestForm();
            f.ShowDialog();
        }

        private void Edit_Click(object sender, EventArgs e)
        {
            //打开Edit进程--独立的进程
            System.Diagnostics.Process.Start(@"C:\Users\Administrator\Desktop\AI-Trader\Edi-master\Debug\Edi.exe");
        }

        private void toolStripButton_QuaickOrderClick(object sender, EventArgs e)
        {
            QuickOrderForm f = new QuickOrderForm();
            f.Show();
        }

        #region VH布局管理
        private void toolStripButton_VLayout_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.TileHorizontal);

        }

        private void toolStripButton_SLayOut_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.Cascade);
        }

        private void toolStripButton_HLayout_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.TileVertical);
        }
        #endregion

        private void 组合LogK线测试ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //KLineLogForm f = new KLineLogForm(new Ticker());
            //f.Show();
        }
    }
}
