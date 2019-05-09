using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class AccountStrategyUserControl : UserControl
    {
        public AccountStrategyUserControl()
        {
            InitializeComponent();
        }

        public void LoadStrategy()
        {
            try
            {
                List<Type> tList = StrategyLoader.LoadeStartegy();

                foreach (Type t in tList)
                {
                    System.Windows.Forms.TreeNode treeNodeSelf = new System.Windows.Forms.TreeNode(t.Name);
                    TreeNodeCollection tC = this.treeView_Strategy.Nodes;
                    foreach(TreeNode node in tC)
                    {
                        if(node.Name == "Root_Self")
                        {
                            node.Nodes.Add(treeNodeSelf);
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("加载策略异常:" + ex.Message);
                return;
            }
        }

        /// <summary>
        /// 新建策略
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToolStripMenuItem_newClick(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 编辑策略
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToolStripMenuItem_EidtClick(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 删除策略
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToolStripMenuItem_DeleteClick(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 双击节点
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Mouse_DoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            //条件单控制面板
            if(true)//MenuStrategyForm Menu = new MenuStrategyForm();          
            {
                MenuStrategyForm Menu = new MenuStrategyForm();
                Menu.Show();
            }

        }
    }
}
