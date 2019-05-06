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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.TreeNode treeNode37 = new System.Windows.Forms.TreeNode("Stoch-Strategy");
            System.Windows.Forms.TreeNode treeNode38 = new System.Windows.Forms.TreeNode("Rsi-Strategy");
            System.Windows.Forms.TreeNode treeNode39 = new System.Windows.Forms.TreeNode("震荡策略实例", new System.Windows.Forms.TreeNode[] {
            treeNode37,
            treeNode38});
            System.Windows.Forms.TreeNode treeNode40 = new System.Windows.Forms.TreeNode("均线跟踪");
            System.Windows.Forms.TreeNode treeNode41 = new System.Windows.Forms.TreeNode("MACD跟踪");
            System.Windows.Forms.TreeNode treeNode42 = new System.Windows.Forms.TreeNode("趋势策略实例", new System.Windows.Forms.TreeNode[] {
            treeNode40,
            treeNode41});
            System.Windows.Forms.TreeNode treeNode43 = new System.Windows.Forms.TreeNode("搬砖");
            System.Windows.Forms.TreeNode treeNode44 = new System.Windows.Forms.TreeNode("强弱-Strategy ");
            System.Windows.Forms.TreeNode treeNode45 = new System.Windows.Forms.TreeNode("套利策略实例", new System.Windows.Forms.TreeNode[] {
            treeNode43,
            treeNode44});
            System.Windows.Forms.TreeNode treeNode46 = new System.Windows.Forms.TreeNode("Volatity");
            System.Windows.Forms.TreeNode treeNode47 = new System.Windows.Forms.TreeNode("Volatity-Break");
            System.Windows.Forms.TreeNode treeNode48 = new System.Windows.Forms.TreeNode("波动性策略", new System.Windows.Forms.TreeNode[] {
            treeNode46,
            treeNode47});
            System.Windows.Forms.TreeNode treeNode49 = new System.Windows.Forms.TreeNode("搬砖");
            System.Windows.Forms.TreeNode treeNode50 = new System.Windows.Forms.TreeNode("抢单");
            System.Windows.Forms.TreeNode treeNode51 = new System.Windows.Forms.TreeNode("高频策略", new System.Windows.Forms.TreeNode[] {
            treeNode49,
            treeNode50});
            System.Windows.Forms.TreeNode treeNode52 = new System.Windows.Forms.TreeNode("跟踪止盈止损");
            System.Windows.Forms.TreeNode treeNode53 = new System.Windows.Forms.TreeNode("设置自动止盈止损", new System.Windows.Forms.TreeNode[] {
            treeNode52});
            System.Windows.Forms.TreeNode treeNode54 = new System.Windows.Forms.TreeNode("自定义策略");
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.treeView_Strategy = new System.Windows.Forms.TreeView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ToolStripMenuItem_new = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.ToolStripMenuItem_Eidt = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.ToolStripMenuItem_Delete = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.ContextMenuStrip = this.contextMenuStrip1;
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
            treeNode37.Name = "节点5";
            treeNode37.Text = "Stoch-Strategy";
            treeNode38.Name = "节点6";
            treeNode38.Text = "Rsi-Strategy";
            treeNode39.Name = "节点0";
            treeNode39.Text = "震荡策略实例";
            treeNode40.Name = "节点8";
            treeNode40.Text = "均线跟踪";
            treeNode41.Name = "节点9";
            treeNode41.Text = "MACD跟踪";
            treeNode42.Name = "节点1";
            treeNode42.Text = "趋势策略实例";
            treeNode43.Name = "节点10";
            treeNode43.Text = "搬砖";
            treeNode44.Name = "节点11";
            treeNode44.Text = "强弱-Strategy ";
            treeNode45.Name = "节点2";
            treeNode45.Text = "套利策略实例";
            treeNode46.Name = "节点12";
            treeNode46.Text = "Volatity";
            treeNode47.Name = "节点13";
            treeNode47.Text = "Volatity-Break";
            treeNode48.Name = "节点3";
            treeNode48.Text = "波动性策略";
            treeNode49.Name = "节点14";
            treeNode49.Text = "搬砖";
            treeNode50.Name = "节点15";
            treeNode50.Text = "抢单";
            treeNode51.Name = "节点4";
            treeNode51.Text = "高频策略";
            treeNode52.Name = "节点18";
            treeNode52.Text = "跟踪止盈止损";
            treeNode53.Name = "节点17";
            treeNode53.Text = "设置自动止盈止损";
            treeNode54.Name = "Root_Self";
            treeNode54.Text = "自定义策略";
            this.treeView_Strategy.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode39,
            treeNode42,
            treeNode45,
            treeNode48,
            treeNode51,
            treeNode53,
            treeNode54});
            this.treeView_Strategy.Size = new System.Drawing.Size(255, 190);
            this.treeView_Strategy.TabIndex = 0;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItem_new,
            this.toolStripSeparator1,
            this.ToolStripMenuItem_Eidt,
            this.toolStripSeparator2,
            this.ToolStripMenuItem_Delete});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(125, 82);
            // 
            // ToolStripMenuItem_new
            // 
            this.ToolStripMenuItem_new.Name = "ToolStripMenuItem_new";
            this.ToolStripMenuItem_new.Size = new System.Drawing.Size(180, 22);
            this.ToolStripMenuItem_new.Text = "新建策略";
            this.ToolStripMenuItem_new.Click += new System.EventHandler(this.ToolStripMenuItem_newClick);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(177, 6);
            // 
            // ToolStripMenuItem_Eidt
            // 
            this.ToolStripMenuItem_Eidt.Name = "ToolStripMenuItem_Eidt";
            this.ToolStripMenuItem_Eidt.Size = new System.Drawing.Size(180, 22);
            this.ToolStripMenuItem_Eidt.Text = "编辑策略";
            this.ToolStripMenuItem_Eidt.Click += new System.EventHandler(this.ToolStripMenuItem_EidtClick);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(177, 6);
            // 
            // ToolStripMenuItem_Delete
            // 
            this.ToolStripMenuItem_Delete.Name = "ToolStripMenuItem_Delete";
            this.ToolStripMenuItem_Delete.Size = new System.Drawing.Size(180, 22);
            this.ToolStripMenuItem_Delete.Text = "删除策略";
            this.ToolStripMenuItem_Delete.Click += new System.EventHandler(this.ToolStripMenuItem_DeleteClick);
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
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TreeView treeView_Strategy;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem_new;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem_Eidt;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem_Delete;
    }
}
