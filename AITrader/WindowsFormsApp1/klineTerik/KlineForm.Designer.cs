namespace WindowsFormsApp1
{
    partial class KlineForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Telerik.WinControls.UI.CartesianArea cartesianArea1 = new Telerik.WinControls.UI.CartesianArea();
            Telerik.WinControls.UI.DateTimeCategoricalAxis dateTimeCategoricalAxis1 = new Telerik.WinControls.UI.DateTimeCategoricalAxis();
            Telerik.WinControls.UI.LinearAxis linearAxis1 = new Telerik.WinControls.UI.LinearAxis();
            Telerik.WinControls.UI.CartesianArea cartesianArea2 = new Telerik.WinControls.UI.CartesianArea();
            Telerik.WinControls.UI.DateTimeCategoricalAxis dateTimeCategoricalAxis2 = new Telerik.WinControls.UI.DateTimeCategoricalAxis();
            Telerik.WinControls.UI.LinearAxis linearAxis2 = new Telerik.WinControls.UI.LinearAxis();
            this.radChartView1 = new Telerik.WinControls.UI.RadChartView();
            this.radChartView2 = new Telerik.WinControls.UI.RadChartView();
            this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel2 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel3 = new Telerik.WinControls.UI.RadLabel();
            this.radDropDownList1 = new Telerik.WinControls.UI.RadDropDownList();
            this.radDropDownList2 = new Telerik.WinControls.UI.RadDropDownList();
            this.radDropDownList3 = new Telerik.WinControls.UI.RadDropDownList();
            //((System.ComponentModel.ISupportInitialize)(this.settingsPanel)).BeginInit();
            //this.settingsPanel.SuspendLayout();
            //((System.ComponentModel.ISupportInitialize)(this.themePanel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radChartView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radChartView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radDropDownList1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radDropDownList2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radDropDownList3)).BeginInit();
            this.SuspendLayout();
            // 
            // settingsPanel
            // 
            //this.settingsPanel.Controls.Add(this.radLabel3);
            //this.settingsPanel.Controls.Add(this.radLabel2);
            //this.settingsPanel.Controls.Add(this.radLabel1);
            //this.settingsPanel.Controls.Add(this.radDropDownList3);
            //this.settingsPanel.Controls.Add(this.radDropDownList2);
            //this.settingsPanel.Controls.Add(this.radDropDownList1);
            //this.settingsPanel.Location = new System.Drawing.Point(962, 19);
            //this.settingsPanel.Size = new System.Drawing.Size(336, 832);
            //this.settingsPanel.Controls.SetChildIndex(this.radDropDownList1, 0);
            //this.settingsPanel.Controls.SetChildIndex(this.radDropDownList2, 0);
            //this.settingsPanel.Controls.SetChildIndex(this.radDropDownList3, 0);
            //this.settingsPanel.Controls.SetChildIndex(this.radLabel1, 0);
            //this.settingsPanel.Controls.SetChildIndex(this.radLabel2, 0);
            //this.settingsPanel.Controls.SetChildIndex(this.radLabel3, 0);
            // 
            // radChartView1
            // 
            this.radChartView1.AreaDesign = cartesianArea1;
            dateTimeCategoricalAxis1.DateTimeComponent = Telerik.Charting.DateTimeComponent.Ticks;
            dateTimeCategoricalAxis1.IsPrimary = true;
            dateTimeCategoricalAxis1.LabelFitMode = Telerik.Charting.AxisLabelFitMode.MultiLine;
            dateTimeCategoricalAxis1.LabelFormat = "{0:dd.MM}";
            dateTimeCategoricalAxis1.MajorTickInterval = 5;
            linearAxis1.AxisType = Telerik.Charting.AxisType.Second;
            linearAxis1.HorizontalLocation = Telerik.Charting.AxisHorizontalLocation.Right;
            linearAxis1.IsPrimary = true;
            linearAxis1.MajorStep = 10D;
            linearAxis1.Maximum = 100D;
            linearAxis1.Minimum = 0D;
            this.radChartView1.Axes.AddRange(new Telerik.WinControls.UI.Axis[] {
            dateTimeCategoricalAxis1,
            linearAxis1});
            this.radChartView1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.radChartView1.Location = new System.Drawing.Point(0, 538);
            this.radChartView1.Name = "radChartView1";
            this.radChartView1.ShowGrid = false;
            this.radChartView1.Size = new System.Drawing.Size(1158, 160);
            this.radChartView1.TabIndex = 1;
            this.radChartView1.Text = "radChartView1";
            this.radChartView1.Title = "Chart title";
            // 
            // radChartView2
            // 
            this.radChartView2.AreaDesign = cartesianArea2;
            dateTimeCategoricalAxis2.DateTimeComponent = Telerik.Charting.DateTimeComponent.Ticks;
            dateTimeCategoricalAxis2.IsPrimary = true;
            dateTimeCategoricalAxis2.LabelFitMode = Telerik.Charting.AxisLabelFitMode.MultiLine;
            dateTimeCategoricalAxis2.LabelFormat = "{0:dd.MM}";
            dateTimeCategoricalAxis2.MajorTickInterval = 5;
            linearAxis2.AxisType = Telerik.Charting.AxisType.Second;
            linearAxis2.HorizontalLocation = Telerik.Charting.AxisHorizontalLocation.Right;
            linearAxis2.IsPrimary = true;
            linearAxis2.MajorStep = 5D;
            linearAxis2.Maximum = 80D;
            linearAxis2.Minimum = 50D;
            this.radChartView2.Axes.AddRange(new Telerik.WinControls.UI.Axis[] {
            dateTimeCategoricalAxis2,
            linearAxis2});
            this.radChartView2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radChartView2.Location = new System.Drawing.Point(0, 0);
            this.radChartView2.MinimumSize = new System.Drawing.Size(500, 150);
            this.radChartView2.Name = "radChartView2";
            // 
            // 
            // 
            this.radChartView2.RootElement.MinSize = new System.Drawing.Size(500, 150);
            this.radChartView2.ShowGrid = false;
            this.radChartView2.ShowTitle = true;
            this.radChartView2.Size = new System.Drawing.Size(1158, 538);
            this.radChartView2.TabIndex = 2;
            this.radChartView2.Text = "radChartView2";
            this.radChartView2.Title = "Investor Adviser: International Software Company (ISC)";
            ((Telerik.WinControls.UI.ChartTitleElement)(this.radChartView2.GetChildAt(0).GetChildAt(0).GetChildAt(0))).Text = "Investor Adviser: International Software Company (ISC)";
            ((Telerik.WinControls.UI.ChartTitleElement)(this.radChartView2.GetChildAt(0).GetChildAt(0).GetChildAt(0))).Margin = new System.Windows.Forms.Padding(10, 10, 0, 0);
            // 
            // radLabel1
            // 
            this.radLabel1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.radLabel1.Location = new System.Drawing.Point(10, 11);
            this.radLabel1.Name = "radLabel1";
            this.radLabel1.Size = new System.Drawing.Size(64, 18);
            this.radLabel1.TabIndex = 0;
            this.radLabel1.Text = "Series Type:";
            // 
            // radLabel2
            // 
            this.radLabel2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.radLabel2.Location = new System.Drawing.Point(10, 61);
            this.radLabel2.Name = "radLabel2";
            this.radLabel2.Size = new System.Drawing.Size(137, 18);
            this.radLabel2.TabIndex = 0;
            this.radLabel2.Text = "Moving Average indicator:";
            // 
            // radLabel3
            // 
            this.radLabel3.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.radLabel3.Location = new System.Drawing.Point(10, 111);
            this.radLabel3.Name = "radLabel3";
            this.radLabel3.Size = new System.Drawing.Size(98, 18);
            this.radLabel3.TabIndex = 0;
            this.radLabel3.Text = "Financial indicator:";
            // 
            // radDropDownList1
            // 
            this.radDropDownList1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.radDropDownList1.DropDownStyle = Telerik.WinControls.RadDropDownStyle.DropDownList;
            this.radDropDownList1.Location = new System.Drawing.Point(10, 32);
            this.radDropDownList1.Name = "radDropDownList1";
            this.radDropDownList1.Size = new System.Drawing.Size(316, 20);
            this.radDropDownList1.TabIndex = 1;
            this.radDropDownList1.Text = "radDropDownList1";
            // 
            // radDropDownList2
            // 
            this.radDropDownList2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.radDropDownList2.DropDownStyle = Telerik.WinControls.RadDropDownStyle.DropDownList;
            this.radDropDownList2.Location = new System.Drawing.Point(10, 82);
            this.radDropDownList2.Name = "radDropDownList2";
            this.radDropDownList2.Size = new System.Drawing.Size(316, 20);
            this.radDropDownList2.TabIndex = 2;
            this.radDropDownList2.Text = "radDropDownList2";
            // 
            // radDropDownList3
            // 
            this.radDropDownList3.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.radDropDownList3.DropDownStyle = Telerik.WinControls.RadDropDownStyle.DropDownList;
            this.radDropDownList3.Location = new System.Drawing.Point(10, 132);
            this.radDropDownList3.Name = "radDropDownList3";
            this.radDropDownList3.Size = new System.Drawing.Size(316, 20);
            this.radDropDownList3.TabIndex = 3;
            this.radDropDownList3.Text = "radDropDownList3";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScrollMinSize = new System.Drawing.Size(500, 320);
            this.Controls.Add(this.radChartView2);
            this.Controls.Add(this.radChartView1);
            this.Name = "Form1";
            this.Size = new System.Drawing.Size(1168, 708);
            //this.Controls.SetChildIndex(this.themePanel, 0);
            this.Controls.SetChildIndex(this.radChartView1, 0);
            this.Controls.SetChildIndex(this.radChartView2, 0);
            //this.Controls.SetChildIndex(this.settingsPanel, 0);
            //((System.ComponentModel.ISupportInitialize)(this.settingsPanel)).EndInit();
            //this.settingsPanel.ResumeLayout(false);
            //this.settingsPanel.PerformLayout();
            //((System.ComponentModel.ISupportInitialize)(this.themePanel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radChartView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radChartView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radDropDownList1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radDropDownList2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radDropDownList3)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.UI.RadDropDownList radDropDownList3;
        private Telerik.WinControls.UI.RadDropDownList radDropDownList2;
        private Telerik.WinControls.UI.RadDropDownList radDropDownList1;
        private Telerik.WinControls.UI.RadChartView radChartView1;
        private Telerik.WinControls.UI.RadChartView radChartView2;
        private Telerik.WinControls.UI.RadLabel radLabel1;
        private Telerik.WinControls.UI.RadLabel radLabel2;
        private Telerik.WinControls.UI.RadLabel radLabel3;
    }
}