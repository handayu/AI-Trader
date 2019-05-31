using Strategy;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using swap = OKExSDK.Models.Swap;

namespace WindowsFormsApp1
{
    public partial class StrategySettingsForm : Form
    {
        private object m_strategy = null;

        private swap.Ticker m_InitInsTicker = null;
        private string m_Frame = string.Empty;

        public StrategySettingsForm(swap.Ticker t,string frame)
        {
            InitializeComponent();
            m_InitInsTicker = t;
            m_Frame = frame;
        }

        public object STRATEGY
        {
            get
            {
                return m_strategy;
            }
        }

        private void Button_OK_Click(object sender, EventArgs e)
        {
            Type strategyType = (Type)this.comboBox_StrategyChoose.SelectedItem;

            if (strategyType == null || strategyType.Name == "")
            {
                MessageBox.Show("请选取一个交易策略用于自动化交易...");
                return;
            }

            try
            {
                string openshares = this.textBox_Shares.Text;
                int openSharesItr = 0;
                int.TryParse(openshares, out openSharesItr);

                m_strategy = StrategyLoader.CreateInstanceStrategy(strategyType, m_InitInsTicker.instrument_id, 0, openSharesItr);//创建类实例
            }
            catch(Exception ex)
            {
                MessageBox.Show("创建strategy对象发生异常请重试:" + ex.Message);
                return;
            }

            this.Close();
        }

        private void Button_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        /// <summary>
        /// 装载strategy.dll中所有的策略
        /// </summary>
        private void Form_Load(object sender, EventArgs e)
        {
            try
            {
                this.textBox_ins.Text = m_InitInsTicker.instrument_id;
                this.textBox_Frame.Text = m_Frame;

                this.comboBox_StrategyChoose.Items.Clear();
                List<Type> tList = StrategyLoader.LoadeStartegy();

                foreach(Type t in tList)
                {
                    this.comboBox_StrategyChoose.Items.Add(t);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }

        }
    }
}
