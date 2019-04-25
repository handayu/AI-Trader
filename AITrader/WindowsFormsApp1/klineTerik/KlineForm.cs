using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.QuickStart.WinControls;
using Telerik.WinControls.UI;
using Telerik.Charting;
using Telerik.Examples.WinControls.ChartView.ChartTypes.StockSeries;

namespace WindowsFormsApp1
{
    public partial class KlineForm : ExamplesForm
    {
        private CandlestickViewModel viewModel;
        private List<string> movingAverageIndicators, financialIndicators;
        private List<string> chartTypes;

        public KlineForm()
        {
            InitializeComponent();
            InitializeData();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            this.radDropDownList1.DataSource = chartTypes;
            this.radDropDownList2.DataSource = movingAverageIndicators;
            this.radDropDownList3.DataSource = financialIndicators;

            SetCartesianGrid(this.radChartView1);
            SetCartesianGrid(this.radChartView2);
            SetTrackBall();

        }
        
        private void InitializeData()
        {
            viewModel = new CandlestickViewModel();

            chartTypes = new List<string>() { "OHLC", "HLC", "Candlestick" };

            movingAverageIndicators = new List<string>() 
            {
                "MA (5)",
                "Exponential MA (5)",
                "Modified MA (5)",
                "Modified Exponential MA (5)",
                "Weighted MA (5)",
                "Adaptive MA Kaufman (10,4,2)",
                "Bollinger Bands (5,2)" 
            };

            financialIndicators = new List<string>()
            {
                "Average True Range (5)",
                "Commodity Channel Index (5)",
                "MACD (12, 9, 6)",
                "Momentum (5)",
                "Oscillator (8, 4)",
                "RAVI (8, 4)",
                "Rate Of Change (8)",
                "Relative Momentum Index (8)",
                "Relative Strength Index (8)",
                "Stochastic Fast (14, 3)",
                "Stochastic Slow (14, 3, 3)",
                "TRIX (8)",
                "True Range",
                "Ultimate Oscillator (6, 9, 12)"
            };
        }

        void radDropDownList1_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            UpdateStockSeries();
        }

        void radDropDownList2_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            UpdateStockSeries();
        }

        private void UpdateStockSeries()
        {
            DateTimeCategoricalAxis horizontalAxis = this.radChartView2.Axes[0] as DateTimeCategoricalAxis;
            LinearAxis verticalAxis = this.radChartView2.Axes[1] as LinearAxis;

            this.radChartView2.Series.Clear();

            if (this.radDropDownList1.SelectedItem != null)
            {
                string seriesType = this.radDropDownList1.SelectedItem.Text;

                if (seriesType == "Candlestick" || seriesType == "OHLC")
                {
                    OhlcSeries series = (seriesType == "Candlestick") ? new CandlestickSeries() : new OhlcSeries();

                    series.BorderColor = Color.FromArgb(102, 102, 102);
                    series.BackColor = Color.FromArgb(102, 102, 102);
                    series.HorizontalAxis = horizontalAxis;
                    series.VerticalAxis = verticalAxis;
                    series.OpenValueMember = "Open";
                    series.HighValueMember = "High";
                    series.LowValueMember = "Low";
                    series.CloseValueMember = "Close";
                    series.CategoryMember = "Date";
                    series.DataSource = viewModel.Data;

                    this.radChartView2.Series.Add(series);

                    if (!(series is CandlestickSeries))
                    {
                        foreach (OhlcPointElement point in series.Children)
                        {
                            if (point.IsFalling)
                            {
                                point.BorderColor = Color.FromArgb(175, 175, 175);
                            }
                        }
                    }
                }
                else
                {
                    HlcSeries series = new HlcSeries();

                    series.BorderColor = Color.FromArgb(102, 102, 102);
                    series.BackColor = Color.FromArgb(102, 102, 102);
                    series.HorizontalAxis = horizontalAxis;
                    series.VerticalAxis = verticalAxis;
                    series.HighValueMember = "High";
                    series.LowValueMember = "Low";
                    series.CloseValueMember = "Close";
                    series.CategoryMember = "Date";
                    series.DataSource = viewModel.Data;

                    this.radChartView2.Series.Add(series);
                }
            }

            if (this.radDropDownList2.SelectedItem != null)
            {
                IndicatorBase indicator = CreateMAIndicator(this.radDropDownList2.SelectedItem.Text);
                indicator.BorderColor = Color.Red;
                indicator.PointSize = SizeF.Empty;

                IParentIndicator parentIndicator = indicator as IParentIndicator;
                if (parentIndicator != null)
                {
                    parentIndicator.ChildIndicator.BorderColor = Color.Black;
                }

                this.radChartView2.Series.Add(indicator);
            }
        }

        void radDropDownList3_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            this.radChartView1.View.Margin = new System.Windows.Forms.Padding(15, 10, 10, 10);
            UpdateFinancialIndicator(this.radDropDownList3.SelectedItem.Text);
        }

        private void UpdateFinancialIndicator(string indicatorType)
        {
            DateTimeCategoricalAxis horizontalAxis = this.radChartView1.Axes[0] as DateTimeCategoricalAxis;
            LinearAxis verticalAxis = this.radChartView1.Axes[1] as LinearAxis;

            this.radChartView1.Series.Clear();

            IndicatorBase indicator = CreateFinancialIndicator(indicatorType);
            indicator.HorizontalAxis = horizontalAxis;
            indicator.VerticalAxis = verticalAxis;
            indicator.PointSize = SizeF.Empty;
            indicator.BorderColor = Color.Black;

            IParentIndicator parentIndicator = indicator as IParentIndicator;
            if (parentIndicator != null)
            {
                parentIndicator.ChildIndicator.BorderColor = Color.Red;
            }

            this.radChartView1.Series.Add(indicator);
        }

        private void SetCartesianGrid(RadChartView chart)
        {
            CartesianArea area = chart.GetArea<CartesianArea>();
            area.ShowGrid = true;

            CartesianGrid grid = area.GetGrid<CartesianGrid>();
            grid.DrawHorizontalFills = false;
            grid.DrawVerticalFills = false;
            grid.DrawHorizontalStripes = true;
            grid.DrawVerticalStripes = true;
            grid.ForeColor = Color.LightGray;
            grid.BorderDashStyle = System.Drawing.Drawing2D.DashStyle.Solid;
        }

        private void SetTrackBall()
        {
            ChartTrackballController trackBallElement = new ChartTrackballController();

            trackBallElement.Element.TextAlignment = ContentAlignment.MiddleLeft;
            trackBallElement.Element.BorderColor = Color.Black;
            trackBallElement.Element.BackColor = Color.White;
            trackBallElement.Element.BorderGradientStyle = Telerik.WinControls.GradientStyles.Solid;
            trackBallElement.Element.GradientStyle = Telerik.WinControls.GradientStyles.Solid;
            trackBallElement.Element.Padding = new Padding(3, 0, 3, 3);

            this.radChartView2.Controllers.Add(trackBallElement);
        }


        private void ConfigureAxis(double min, double max, double majorStep)
        {
            LinearAxis axis = this.radChartView1.Axes[1] as LinearAxis;
            if (axis == null)
                return;

            axis.Minimum = min;
            axis.Maximum = max;
            axis.MajorStep = majorStep;
        }

        private IndicatorBase CreateMAIndicator(string indicatorType)
        {
            IndicatorBase indicator;

            if (indicatorType.StartsWith("MA ("))
            {
                indicator = new MovingAverageIndicator();
                indicator.Name = "MA";
            }
            else if (indicatorType.StartsWith("Exponential MA"))
            {
                indicator = new ExponentialMovingAverageIndicator();
                indicator.Name = "EMA";
            }
            else if (indicatorType.StartsWith("Modified MA"))
            {
                indicator = new ModifiedMovingAverageIndicator();
                indicator.Name = "MMA";
            }
            else if (indicatorType.StartsWith("Modified Exponential MA"))
            {
                indicator = new ModifiedExponentialMovingAverageIndicator();
                indicator.Name = "MEMA";
            }
            else if (indicatorType.StartsWith("Weighted MA"))
            {
                indicator = new WeightedMovingAverageIndicator();
                indicator.Name = "WMA";
            }
            else if (indicatorType.StartsWith("Adaptive MA"))
            {
                indicator = new AdaptiveMovingAverageKaufmanIndicator();
                indicator.Name = "KAMA";
                ((AdaptiveMovingAverageKaufmanIndicator)indicator).SlowPeriod = 10;
                ((AdaptiveMovingAverageKaufmanIndicator)indicator).FastPeriod = 4;
            }
            else
            {
                indicator = new BollingerBandsIndicator();
                indicator.Name = "BOLL";
                ((BollingerBandsIndicator)indicator).StandardDeviations = 2;
            }

            ((ValuePeriodIndicatorBase)indicator).Period = 5;
            indicator.CategoryMember = "Date";
            indicator.ValueMember = "Close";
            indicator.DataSource = viewModel.Data;

            return indicator;
        }

        private IndicatorBase CreateFinancialIndicator(string indicatorType)
        {
            if (indicatorType.StartsWith("Average True Range"))
            {
                return CreateAverageTrueRangeIndicator();
            }
            else if (indicatorType.StartsWith("Commodity Channel Index"))
            {
                return CreateCommodityChannelIndexIndicator(); 
            }
            else if (indicatorType.StartsWith("MACD"))
            {
                return CreateMACDIndicator();
            }
            else if (indicatorType.StartsWith("Momentum"))
            {
                return CreateMomentumIndicator();
            }
            else if (indicatorType.StartsWith("Oscillator"))
            {
                return CreateOscillatorIndicator();
            }
            else if (indicatorType.StartsWith("RAVI"))
            {
                return CreateRaviIndicator();
            }
            else if (indicatorType.StartsWith("Rate Of Change"))
            {
                return CreateRateOfChangeIndicator();
            }
            else if (indicatorType.StartsWith("Relative Momentum Index"))
            {
                return CreateRelativeMomentumIndexIndicator();
            }
            else if (indicatorType.StartsWith("Relative Strength Index"))
            {
                return CreateRelativeStrengthIndexIndicator();
            }
            else if (indicatorType.StartsWith("Stochastic Fast"))
            {
                return CreateStochasticFastIndicator();
            }
            else if (indicatorType.StartsWith("Stochastic Slow"))
            {
                return CreateStochasticSlowIndicator();
            }
            else if (indicatorType.StartsWith("True Range"))
            {
                return CreateTrueRangeIndicator();
            }
            else if (indicatorType.StartsWith("TRIX"))
            {
                return CreateTrixIndicator();
            }
            return CreateUltimateOscillatorIndicator();
        }

        private AverageTrueRangeIndicator CreateAverageTrueRangeIndicator()
        {
            AverageTrueRangeIndicator indicator = new AverageTrueRangeIndicator();
            indicator.Period = 5;
            indicator.CategoryMember = "Date";
            indicator.HighValueMember = "High";
            indicator.LowValueMember = "Low";
            indicator.CloseValueMember = "Close";
            indicator.DataSource = viewModel.Data;
       
            ConfigureAxis(0, 5, 1);

            return indicator;
        }

        private CommodityChannelIndexIndicator CreateCommodityChannelIndexIndicator()
        {
            CommodityChannelIndexIndicator indicator = new CommodityChannelIndexIndicator();
            indicator.Period = 5;
            indicator.CategoryMember = "Date";
            indicator.HighValueMember = "High";
            indicator.LowValueMember = "Low";
            indicator.CloseValueMember = "Close";
            indicator.DataSource = viewModel.Data;
       
            ConfigureAxis(-200, 200, 100);

            return indicator;
        }


        private IndicatorBase CreateMACDIndicator()
        {
            MacdIndicator indicator = new MacdIndicator();
            indicator.ShortPeriod = 9;
            indicator.LongPeriod = 12;
            indicator.SignalPeriod = 6;
            indicator.CategoryMember = "Date";
            indicator.ValueMember = "Close";
            indicator.DataSource = viewModel.Data;

            ConfigureAxis(-2, 2, 1);

            return indicator;
        }

        private MomentumIndicator CreateMomentumIndicator()
        {
            MomentumIndicator indicator = new MomentumIndicator();
            indicator.Period = 8;
            indicator.CategoryMember = "Date";
            indicator.ValueMember = "Close";
            indicator.DataSource = viewModel.Data;

            ConfigureAxis(80, 120, 10);

            return indicator;
        }

        private OscillatorIndicator CreateOscillatorIndicator()
        {
            OscillatorIndicator indicator = new OscillatorIndicator();
            indicator.ShortPeriod = 4;
            indicator.LongPeriod = 8;
            indicator.CategoryMember = "Date";
            indicator.ValueMember = "Close";
            indicator.DataSource = viewModel.Data;

            ConfigureAxis(-5, 5, 5);

            return indicator;
        }

        private RaviIndicator CreateRaviIndicator()
        {
            RaviIndicator indicator = new RaviIndicator();
            indicator.ShortPeriod = 4;
            indicator.LongPeriod = 8;
            indicator.CategoryMember = "Date";
            indicator.ValueMember = "Close";
            indicator.DataSource = viewModel.Data;

            ConfigureAxis(-5, 5, 5);

            return indicator;
        }

        private RateOfChangeIndicator CreateRateOfChangeIndicator()
        {
            RateOfChangeIndicator indicator = new RateOfChangeIndicator();
            indicator.Period = 8;
            indicator.CategoryMember = "Date";
            indicator.ValueMember = "Close";
            indicator.DataSource = viewModel.Data;
         
            ConfigureAxis(-20, 20, 10);

            return indicator;
        }

        private RelativeMomentumIndexIndicator CreateRelativeMomentumIndexIndicator()
        {
            RelativeMomentumIndexIndicator indicator = new RelativeMomentumIndexIndicator();
            indicator.Period = 8;
            indicator.CategoryMember = "Date";
            indicator.ValueMember = "Close";
            indicator.DataSource = viewModel.Data;
           
            ConfigureAxis(0, 100, 20);

            return indicator;
        }

        private RelativeStrengthIndexIndicator CreateRelativeStrengthIndexIndicator()
        {
            RelativeStrengthIndexIndicator indicator = new RelativeStrengthIndexIndicator();
            indicator.Period = 8;
            indicator.CategoryMember = "Date";
            indicator.ValueMember = "Close";
            indicator.DataSource = viewModel.Data;
        
            ConfigureAxis(0, 100, 20);

            return indicator;
        }

        private StochasticFastIndicator CreateStochasticFastIndicator()
        {
            StochasticFastIndicator indicator = new StochasticFastIndicator();
            indicator.MainPeriod = 14;
            indicator.SignalPeriod = 3;
            indicator.CategoryMember = "Date";
            indicator.HighValueMember = "High";
            indicator.LowValueMember = "Low";
            indicator.CloseValueMember = "Close";
            indicator.DataSource = viewModel.Data;
           
            ConfigureAxis(0, 100, 20);

            return indicator;
        }

        private StochasticSlowIndicator CreateStochasticSlowIndicator()
        {
            StochasticSlowIndicator indicator = new StochasticSlowIndicator();
            indicator.MainPeriod = 14;
            indicator.SignalPeriod = 3;
            indicator.SlowingPeriod = 3;
            indicator.CategoryMember = "Date";
            indicator.HighValueMember = "High";
            indicator.LowValueMember = "Low";
            indicator.CloseValueMember = "Close";
            indicator.DataSource = viewModel.Data;
          
            ConfigureAxis(0, 100, 20);

            return indicator;
        }

        private TrixIndicator CreateTrixIndicator()
        {
            TrixIndicator indicator = new TrixIndicator();
            indicator.Period = 8;
            indicator.CategoryMember = "Date";
            indicator.ValueMember = "Close";
            indicator.DataSource = viewModel.Data;
        
            ConfigureAxis(-1, 1, 0.5);

            return indicator;
        }

        private TrueRangeIndicator CreateTrueRangeIndicator()
        {
            TrueRangeIndicator indicator = new TrueRangeIndicator();
            indicator.CategoryMember = "Date";
            indicator.HighValueMember = "High";
            indicator.LowValueMember = "Low";
            indicator.CloseValueMember = "Close";
            indicator.DataSource = viewModel.Data;
          
            ConfigureAxis(0, 6, 1);

            return indicator;
        }

        private UltimateOscillatorIndicator CreateUltimateOscillatorIndicator()
        {
            UltimateOscillatorIndicator indicator = new UltimateOscillatorIndicator();
            indicator.Period = 6;
            indicator.Period2 = 9;
            indicator.Period3 = 12;
            indicator.CategoryMember = "Date";
            indicator.CloseValueMember = "Close";
            indicator.HighValueMember = "High";
            indicator.LowValueMember = "Low";
            indicator.DataSource = viewModel.Data;
           
            ConfigureAxis(0, 100, 20);

            return indicator;
        }

        protected override void WireEvents()
        {
            this.radDropDownList1.SelectedIndexChanged += new Telerik.WinControls.UI.Data.PositionChangedEventHandler(radDropDownList1_SelectedIndexChanged);
            this.radDropDownList2.SelectedIndexChanged += new Telerik.WinControls.UI.Data.PositionChangedEventHandler(radDropDownList2_SelectedIndexChanged);
            this.radDropDownList3.SelectedIndexChanged += new Telerik.WinControls.UI.Data.PositionChangedEventHandler(radDropDownList3_SelectedIndexChanged);
        }
    }
}
