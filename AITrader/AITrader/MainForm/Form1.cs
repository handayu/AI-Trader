﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AITrader;
using OKExSDK.Models.Swap;
using WeifenLuo.WinFormsUI.Docking;
using swap = OKExSDK.Models.Swap;
using TestProxy;
using System.Diagnostics;

namespace WindowsFormsApp1
{
    public partial class Form1 : DockContent
    {

        private MarketDataUserForm m_marketDataForm = null;
        private AccountStrategyUserForm m_accountStrategyForm = null;
        private TradeUserForm m_tradeUserForm = null;
        private BrokerProfileForm m_brokersForm = null;

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

        /// <summary>
        /// 通道管理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OrderWayManagerToolStripMenuItem_Click(object sender, EventArgs e)
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

        private int m_formNum = 0;
        private List<Form> m_OpenKLineFormList = new List<Form>();
        private void RealMarketDataClikSubEvent(swap.Ticker t)
        {
            if (t == null || t.instrument_id == "") return;

            //foreach (Form f in m_OpenKLineFormList)
            //{
            //    KLineFormTest fT = f as KLineFormTest;
            //    if (fT != null && fT.FORMNAME == t.instrument_id)
            //    {
            //        MessageBox.Show("不能重复添加相同的品种图表...");
            //        return;
            //    }
            //}

            KLineFormTest form = new KLineFormTest(t, m_formNum++);
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
        private void DeleteKLineFormSubEvent(string formName)
        {
            if (formName == null || formName == "") return;

            Form reForm = null;
            foreach (Form f in m_OpenKLineFormList)
            {
                if ((f as KLineFormTest) != null && (f as KLineFormTest).FORMNAME.CompareTo(formName) == 0)
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

        }

        private void Edit_Click(object sender, EventArgs e)
        {
            try
            {
                string exeInfo = System.Windows.Forms.Application.StartupPath + "\\edi\\Edi.exe";

                //打开Edit进程--独立的进程
                System.Diagnostics.Process.Start(exeInfo);
            }
            catch (Exception ex)
            {
                MessageBox.Show("无法找到Edi:" + ex.Message);
            }

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

        private void Form_Closed(object sender, FormClosedEventArgs e)
        {
            if (m_marketDataForm != null && m_marketDataForm.MarketDataUserControlSelf != null)
            {
                m_marketDataForm.MarketDataUserControlSelf.RealMarketDataClikEvent -= RealMarketDataClikSubEvent;
            }

            m_marketDataForm = null;
            m_accountStrategyForm = null;
            m_tradeUserForm = null;
            m_marketDataForm = null;
            m_accountStrategyForm = null;
            m_tradeUserForm = null;

            APIConnect.ConnectManager.CreateInstance().CONNECTION.StopThreadTicker();

            //this.Close();
        }

        private void ToolStripMenuItem_BarMakerClick(object sender, EventArgs e)
        {
            //TestSarForm f = new TestSarForm();
            //f.Show();
            List<MemberInfo> typesList = IndicatorsLoader.LoadeIndicatorsFuncAisa();

        }

        private void teamViwerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                string tVPath = System.Windows.Forms.Application.StartupPath + "\\TeamViewerQS.exe";

                //打开
                System.Diagnostics.Process.Start(tVPath);
            }
            catch (Exception ex)
            {
                MessageBox.Show("无法找到TeamViwer请确认安装了teamviwer:" + ex.Message);
            }

        }

        private void ToolStripMenuItem_DDEClick(object sender, EventArgs e)
        {
            DDEService serF = new DDEService();
            serF.Show();
        }

        private void ToolTrip_ManagerAccountClick(object sender, EventArgs e)
        {
            ManagerListConnect conn = new ManagerListConnect();
            conn.Show();
        }

        private void ToolTrip_dataCenterClick(object sender, EventArgs e)
        {
            QuoteManager ma = new QuoteManager();
            ma.Show();
        }

        private void ToolStrip_AccountChoose(object sender, EventArgs e)
        {

        }

        private void Timer_NowTimeEvent(object sender, EventArgs e)
        {
          this.label_Timer.Text =  DateTime.Now.ToLongTimeString();
        }

        private void ToolStrip_StratgyPerfomaceClick(object sender, EventArgs e)
        {
            StrategyPerfomace fM = new StrategyPerfomace();
            fM.Show();
        }

        private ProxyTestForm m_proxyTestForm = new ProxyTestForm();

        #region 测试后台代理类
        /// <summary>
        /// 测试后台代理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButton_testProxy_Click(object sender, EventArgs e)
        {
            if (!m_proxyTestForm.Visible)
            {
                m_proxyTestForm.Show();
            }
            else
            {
                m_proxyTestForm.Hide();
            }
        }
        #endregion

        private TuShareLoginForm m_toShareForm = new TuShareLoginForm();

        /// <summary>
        /// Toshare登陆
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButton_toShare_Click(object sender, EventArgs e)
        {
            if(!m_toShareForm.Visible)
            {
                m_toShareForm.Show();
            }
            else
            {
                m_toShareForm.Hide();
            }
        }

        /// <summary>
        /// menuStrip-新建图表
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripMenuItem_AddChart_Click(object sender, EventArgs e)
        {
            AddInstruments addInsForm = new AddInstruments();
            addInsForm.ShowDialog();
        }

        private void toolStripMenuItem_DataCenter_Click(object sender, EventArgs e)
        {
            QuoteManager Qm = new QuoteManager();
            Qm.Show();
        }

        private void toolStripMenuItem_Perfomance_Click(object sender, EventArgs e)
        {
            StrategyPerfomace pFoem = new StrategyPerfomace();
            pFoem.Show();
        }

        private void toolStripMenuItem_OrderManager_Click(object sender, EventArgs e)
        {
            OrderAccountListForm aL = new OrderAccountListForm();
            aL.Show();
        }

        private void toolStripMenuItem_Coder_Click(object sender, EventArgs e)
        {

        }

        private void toolStripButton_TestKLineClick(object sender, EventArgs e)
        {
            ZedKLineForm f = new ZedKLineForm();
            f.Show();
        }
    }
}
