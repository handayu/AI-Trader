namespace WindowsFormsApp1
{
    partial class AccountStrategyUserControl
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Stoch-Strategy");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("Rsi-Strategy");
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("震荡策略实例", new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2});
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("均线跟踪");
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("MACD跟踪");
            System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode("趋势策略实例", new System.Windows.Forms.TreeNode[] {
            treeNode4,
            treeNode5});
            System.Windows.Forms.TreeNode treeNode7 = new System.Windows.Forms.TreeNode("搬砖");
            System.Windows.Forms.TreeNode treeNode8 = new System.Windows.Forms.TreeNode("强弱-Strategy ");
            System.Windows.Forms.TreeNode treeNode9 = new System.Windows.Forms.TreeNode("套利策略实例", new System.Windows.Forms.TreeNode[] {
            treeNode7,
            treeNode8});
            System.Windows.Forms.TreeNode treeNode10 = new System.Windows.Forms.TreeNode("Volatity");
            System.Windows.Forms.TreeNode treeNode11 = new System.Windows.Forms.TreeNode("Volatity-Break");
            System.Windows.Forms.TreeNode treeNode12 = new System.Windows.Forms.TreeNode("波动性策略", new System.Windows.Forms.TreeNode[] {
            treeNode10,
            treeNode11});
            System.Windows.Forms.TreeNode treeNode13 = new System.Windows.Forms.TreeNode("搬砖");
            System.Windows.Forms.TreeNode treeNode14 = new System.Windows.Forms.TreeNode("抢单");
            System.Windows.Forms.TreeNode treeNode15 = new System.Windows.Forms.TreeNode("高频策略", new System.Windows.Forms.TreeNode[] {
            treeNode13,
            treeNode14});
            System.Windows.Forms.TreeNode treeNode16 = new System.Windows.Forms.TreeNode("跟踪止盈止损");
            System.Windows.Forms.TreeNode treeNode17 = new System.Windows.Forms.TreeNode("设置自动止盈止损", new System.Windows.Forms.TreeNode[] {
            treeNode16});
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.treeView_Strategy = new System.Windows.Forms.TreeView();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(269, 222);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.treeView_Strategy);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(261, 196);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "指标/自动策略";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // treeView_Strategy
            // 
            this.treeView_Strategy.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView_Strategy.Location = new System.Drawing.Point(3, 3);
            this.treeView_Strategy.Name = "treeView_Strategy";
            treeNode1.Name = "节点5";
            treeNode1.Text = "Stoch-Strategy";
            treeNode2.Name = "节点6";
            treeNode2.Text = "Rsi-Strategy";
            treeNode3.Name = "节点0";
            treeNode3.Text = "震荡策略实例";
            treeNode4.Name = "节点8";
            treeNode4.Text = "均线跟踪";
            treeNode5.Name = "节点9";
            treeNode5.Text = "MACD跟踪";
            treeNode6.Name = "节点1";
            treeNode6.Text = "趋势策略实例";
            treeNode7.Name = "节点10";
            treeNode7.Text = "搬砖";
            treeNode8.Name = "节点11";
            treeNode8.Text = "强弱-Strategy ";
            treeNode9.Name = "节点2";
            treeNode9.Text = "套利策略实例";
            treeNode10.Name = "节点12";
            treeNode10.Text = "Volatity";
            treeNode11.Name = "节点13";
            treeNode11.Text = "Volatity-Break";
            treeNode12.Name = "节点3";
            treeNode12.Text = "波动性策略";
            treeNode13.Name = "节点14";
            treeNode13.Text = "搬砖";
            treeNode14.Name = "节点15";
            treeNode14.Text = "抢单";
            treeNode15.Name = "节点4";
            treeNode15.Text = "高频策略";
            treeNode16.Name = "节点18";
            treeNode16.Text = "跟踪止盈止损";
            treeNode17.Name = "节点17";
            treeNode17.Text = "设置自动止盈止损";
            this.treeView_Strategy.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode3,
            treeNode6,
            treeNode9,
            treeNode12,
            treeNode15,
            treeNode17});
            this.treeView_Strategy.Size = new System.Drawing.Size(255, 190);
            this.treeView_Strategy.TabIndex = 0;
            // 
            // AccountStrategyUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Controls.Add(this.tabControl1);
            this.Name = "AccountStrategyUserControl";
            this.Size = new System.Drawing.Size(269, 222);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TreeView treeView_Strategy;
    }
}
