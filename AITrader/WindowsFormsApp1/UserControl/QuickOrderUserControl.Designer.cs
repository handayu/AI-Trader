namespace WindowsFormsApp1
{ 
    partial class QuickOrderUserControl
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
            this.label14 = new System.Windows.Forms.Label();
            this.button_SellShort = new System.Windows.Forms.Button();
            this.button_Buy = new System.Windows.Forms.Button();
            this.label13 = new System.Windows.Forms.Label();
            this.label_CanUseMargion = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.textBox_OrderNum = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.button_OppositePrice = new System.Windows.Forms.Button();
            this.textBox_Price = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.comboBox_OrderStyle = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.radioButton_Cover = new System.Windows.Forms.RadioButton();
            this.radioButton_Open = new System.Windows.Forms.RadioButton();
            this.label_UpDown = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label_newMarketData = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBox_Ins = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label_CanOrderOpenShres = new System.Windows.Forms.Label();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.dataGridView_Hold = new System.Windows.Forms.DataGridView();
            this.tabControl_HasTradedOrder = new System.Windows.Forms.TabControl();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.dataGridView_NoTradedOrder = new System.Windows.Forms.DataGridView();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.dataGridView_hasTraded = new System.Windows.Forms.DataGridView();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Hold)).BeginInit();
            this.tabControl_HasTradedOrder.SuspendLayout();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_NoTradedOrder)).BeginInit();
            this.tabPage4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_hasTraded)).BeginInit();
            this.SuspendLayout();
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(18, 57);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(59, 12);
            this.label14.TabIndex = 47;
            this.label14.Text = "开仓方向:";
            // 
            // button_SellShort
            // 
            this.button_SellShort.BackColor = System.Drawing.Color.LightGreen;
            this.button_SellShort.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button_SellShort.Location = new System.Drawing.Point(145, 195);
            this.button_SellShort.Name = "button_SellShort";
            this.button_SellShort.Size = new System.Drawing.Size(109, 23);
            this.button_SellShort.TabIndex = 46;
            this.button_SellShort.Text = "卖空";
            this.button_SellShort.UseVisualStyleBackColor = false;
            // 
            // button_Buy
            // 
            this.button_Buy.BackColor = System.Drawing.Color.LightCoral;
            this.button_Buy.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button_Buy.Location = new System.Drawing.Point(21, 195);
            this.button_Buy.Name = "button_Buy";
            this.button_Buy.Size = new System.Drawing.Size(109, 23);
            this.button_Buy.TabIndex = 45;
            this.button_Buy.Text = "买入";
            this.button_Buy.UseVisualStyleBackColor = false;
            this.button_Buy.Click += new System.EventHandler(this.button_Buy_Click_1);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(179, 180);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(35, 12);
            this.label13.TabIndex = 43;
            this.label13.Text = "可开:";
            // 
            // label_CanUseMargion
            // 
            this.label_CanUseMargion.AutoSize = true;
            this.label_CanUseMargion.Location = new System.Drawing.Point(96, 180);
            this.label_CanUseMargion.Name = "label_CanUseMargion";
            this.label_CanUseMargion.Size = new System.Drawing.Size(59, 12);
            this.label_CanUseMargion.TabIndex = 42;
            this.label_CanUseMargion.Text = "0.0001BTC";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(19, 180);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(71, 12);
            this.label10.TabIndex = 41;
            this.label10.Text = "可用保证金:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(219, 150);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(17, 12);
            this.label9.TabIndex = 40;
            this.label9.Text = "张";
            // 
            // textBox_OrderNum
            // 
            this.textBox_OrderNum.Location = new System.Drawing.Point(85, 146);
            this.textBox_OrderNum.Name = "textBox_OrderNum";
            this.textBox_OrderNum.Size = new System.Drawing.Size(130, 21);
            this.textBox_OrderNum.TabIndex = 39;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(30, 155);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(47, 12);
            this.label8.TabIndex = 38;
            this.label8.Text = "  数量:";
            // 
            // button_OppositePrice
            // 
            this.button_OppositePrice.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_OppositePrice.Location = new System.Drawing.Point(181, 115);
            this.button_OppositePrice.Name = "button_OppositePrice";
            this.button_OppositePrice.Size = new System.Drawing.Size(55, 23);
            this.button_OppositePrice.TabIndex = 37;
            this.button_OppositePrice.Text = "对手价";
            this.button_OppositePrice.UseVisualStyleBackColor = true;
            // 
            // textBox_Price
            // 
            this.textBox_Price.Location = new System.Drawing.Point(85, 117);
            this.textBox_Price.Name = "textBox_Price";
            this.textBox_Price.Size = new System.Drawing.Size(89, 21);
            this.textBox_Price.TabIndex = 36;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(30, 121);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(47, 12);
            this.label7.TabIndex = 35;
            this.label7.Text = "  价格:";
            // 
            // comboBox_OrderStyle
            // 
            this.comboBox_OrderStyle.FormattingEnabled = true;
            this.comboBox_OrderStyle.Location = new System.Drawing.Point(85, 85);
            this.comboBox_OrderStyle.Name = "comboBox_OrderStyle";
            this.comboBox_OrderStyle.Size = new System.Drawing.Size(89, 20);
            this.comboBox_OrderStyle.TabIndex = 34;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(19, 93);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(59, 12);
            this.label6.TabIndex = 33;
            this.label6.Text = "委托类型:";
            // 
            // radioButton_Cover
            // 
            this.radioButton_Cover.AutoSize = true;
            this.radioButton_Cover.Location = new System.Drawing.Point(131, 57);
            this.radioButton_Cover.Name = "radioButton_Cover";
            this.radioButton_Cover.Size = new System.Drawing.Size(47, 16);
            this.radioButton_Cover.TabIndex = 32;
            this.radioButton_Cover.TabStop = true;
            this.radioButton_Cover.Text = "平仓";
            this.radioButton_Cover.UseVisualStyleBackColor = true;
            // 
            // radioButton_Open
            // 
            this.radioButton_Open.AutoSize = true;
            this.radioButton_Open.Location = new System.Drawing.Point(83, 57);
            this.radioButton_Open.Name = "radioButton_Open";
            this.radioButton_Open.Size = new System.Drawing.Size(47, 16);
            this.radioButton_Open.TabIndex = 31;
            this.radioButton_Open.TabStop = true;
            this.radioButton_Open.Text = "开仓";
            this.radioButton_Open.UseVisualStyleBackColor = true;
            // 
            // label_UpDown
            // 
            this.label_UpDown.AutoSize = true;
            this.label_UpDown.ForeColor = System.Drawing.Color.Red;
            this.label_UpDown.Location = new System.Drawing.Point(237, 45);
            this.label_UpDown.Name = "label_UpDown";
            this.label_UpDown.Size = new System.Drawing.Size(41, 12);
            this.label_UpDown.TabIndex = 30;
            this.label_UpDown.Text = "+20.30";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(184, 45);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 12);
            this.label5.TabIndex = 29;
            this.label5.Text = "涨跌:";
            // 
            // label_newMarketData
            // 
            this.label_newMarketData.AutoSize = true;
            this.label_newMarketData.Location = new System.Drawing.Point(237, 22);
            this.label_newMarketData.Name = "label_newMarketData";
            this.label_newMarketData.Size = new System.Drawing.Size(47, 12);
            this.label_newMarketData.TabIndex = 28;
            this.label_newMarketData.Text = "5683.30";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(184, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 12);
            this.label2.TabIndex = 27;
            this.label2.Text = "最新价:";
            // 
            // comboBox_Ins
            // 
            this.comboBox_Ins.FormattingEnabled = true;
            this.comboBox_Ins.Location = new System.Drawing.Point(85, 19);
            this.comboBox_Ins.Name = "comboBox_Ins";
            this.comboBox_Ins.Size = new System.Drawing.Size(89, 20);
            this.comboBox_Ins.TabIndex = 26;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(42, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 12);
            this.label1.TabIndex = 25;
            this.label1.Text = "品种:";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.groupBox1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer3);
            this.splitContainer1.Size = new System.Drawing.Size(788, 241);
            this.splitContainer1.SplitterDistance = 296;
            this.splitContainer1.TabIndex = 51;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label15);
            this.groupBox1.Controls.Add(this.button_SellShort);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.comboBox_Ins);
            this.groupBox1.Controls.Add(this.button_Buy);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label_CanOrderOpenShres);
            this.groupBox1.Controls.Add(this.label_newMarketData);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label_CanUseMargion);
            this.groupBox1.Controls.Add(this.label_UpDown);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.radioButton_Open);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.radioButton_Cover);
            this.groupBox1.Controls.Add(this.textBox_OrderNum);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.comboBox_OrderStyle);
            this.groupBox1.Controls.Add(this.button_OppositePrice);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.textBox_Price);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(296, 241);
            this.groupBox1.TabIndex = 49;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "下单板";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(237, 180);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(17, 12);
            this.label15.TabIndex = 48;
            this.label15.Text = "张";
            // 
            // label_CanOrderOpenShres
            // 
            this.label_CanOrderOpenShres.AutoSize = true;
            this.label_CanOrderOpenShres.Location = new System.Drawing.Point(220, 180);
            this.label_CanOrderOpenShres.Name = "label_CanOrderOpenShres";
            this.label_CanOrderOpenShres.Size = new System.Drawing.Size(11, 12);
            this.label_CanOrderOpenShres.TabIndex = 44;
            this.label_CanOrderOpenShres.Text = "0";
            // 
            // splitContainer3
            // 
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.Location = new System.Drawing.Point(0, 0);
            this.splitContainer3.Name = "splitContainer3";
            this.splitContainer3.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.Controls.Add(this.tabControl1);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this.tabControl_HasTradedOrder);
            this.splitContainer3.Size = new System.Drawing.Size(488, 241);
            this.splitContainer3.SplitterDistance = 71;
            this.splitContainer3.TabIndex = 0;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(488, 71);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.dataGridView_Hold);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(480, 45);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "当前持仓";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // dataGridView_Hold
            // 
            this.dataGridView_Hold.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dataGridView_Hold.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_Hold.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView_Hold.Location = new System.Drawing.Point(3, 3);
            this.dataGridView_Hold.Name = "dataGridView_Hold";
            this.dataGridView_Hold.RowTemplate.Height = 23;
            this.dataGridView_Hold.Size = new System.Drawing.Size(474, 39);
            this.dataGridView_Hold.TabIndex = 0;
            // 
            // tabControl_HasTradedOrder
            // 
            this.tabControl_HasTradedOrder.Controls.Add(this.tabPage3);
            this.tabControl_HasTradedOrder.Controls.Add(this.tabPage4);
            this.tabControl_HasTradedOrder.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl_HasTradedOrder.Location = new System.Drawing.Point(0, 0);
            this.tabControl_HasTradedOrder.Name = "tabControl_HasTradedOrder";
            this.tabControl_HasTradedOrder.SelectedIndex = 0;
            this.tabControl_HasTradedOrder.Size = new System.Drawing.Size(488, 166);
            this.tabControl_HasTradedOrder.TabIndex = 0;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.dataGridView_NoTradedOrder);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(445, 285);
            this.tabPage3.TabIndex = 0;
            this.tabPage3.Text = "未成交委托";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // dataGridView_NoTradedOrder
            // 
            this.dataGridView_NoTradedOrder.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dataGridView_NoTradedOrder.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_NoTradedOrder.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView_NoTradedOrder.Location = new System.Drawing.Point(3, 3);
            this.dataGridView_NoTradedOrder.Name = "dataGridView_NoTradedOrder";
            this.dataGridView_NoTradedOrder.RowTemplate.Height = 23;
            this.dataGridView_NoTradedOrder.Size = new System.Drawing.Size(439, 279);
            this.dataGridView_NoTradedOrder.TabIndex = 1;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.dataGridView_hasTraded);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(480, 140);
            this.tabPage4.TabIndex = 1;
            this.tabPage4.Text = "已成交历史";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // dataGridView_hasTraded
            // 
            this.dataGridView_hasTraded.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dataGridView_hasTraded.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_hasTraded.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView_hasTraded.Location = new System.Drawing.Point(3, 3);
            this.dataGridView_hasTraded.Name = "dataGridView_hasTraded";
            this.dataGridView_hasTraded.RowTemplate.Height = 23;
            this.dataGridView_hasTraded.Size = new System.Drawing.Size(474, 134);
            this.dataGridView_hasTraded.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(19, 222);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 12);
            this.label3.TabIndex = 49;
            this.label3.Text = "下单消息:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(81, 222);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(83, 12);
            this.label4.TabIndex = 50;
            this.label4.Text = "-------------";
            // 
            // QuickOrderUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Controls.Add(this.splitContainer1);
            this.MinimumSize = new System.Drawing.Size(788, 241);
            this.Name = "QuickOrderUserControl";
            this.Size = new System.Drawing.Size(788, 241);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
            this.splitContainer3.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Hold)).EndInit();
            this.tabControl_HasTradedOrder.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_NoTradedOrder)).EndInit();
            this.tabPage4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_hasTraded)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Button button_SellShort;
        private System.Windows.Forms.Button button_Buy;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label_CanUseMargion;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox textBox_OrderNum;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button button_OppositePrice;
        private System.Windows.Forms.TextBox textBox_Price;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox comboBox_OrderStyle;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.RadioButton radioButton_Cover;
        private System.Windows.Forms.RadioButton radioButton_Open;
        private System.Windows.Forms.Label label_UpDown;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label_newMarketData;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBox_Ins;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabControl tabControl_HasTradedOrder;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label_CanOrderOpenShres;
        private System.Windows.Forms.DataGridView dataGridView_Hold;
        private System.Windows.Forms.DataGridView dataGridView_NoTradedOrder;
        private System.Windows.Forms.DataGridView dataGridView_hasTraded;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
    }
}
