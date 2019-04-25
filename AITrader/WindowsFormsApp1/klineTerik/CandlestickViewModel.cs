using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Globalization;
using WindowsFormsApp1.Properties;
using System.IO;

namespace Telerik.Examples.WinControls.ChartView.ChartTypes.StockSeries
{
    public class CandlestickViewModel : INotifyPropertyChanged
    {
        BindingList<CandleDataInfo> data;

        public CandlestickViewModel()
        {
            data = ParseData();
        }

        public BindingList<CandleDataInfo> Data
        {
            get
            {
                return data;
            }
            set
            {
                if (this.data != value)
                {
                    this.data = value;
                    this.OnPropertyChanged("Data");
                }
            }
        }

        internal static BindingList<CandleDataInfo> ParseData()
        {
            BindingList<CandleDataInfo> chartData = new BindingList<CandleDataInfo>();
            char[] separator = { '\r', '\n' };

            FileStream fs = new FileStream(@"C:\Users\Administrator\Desktop\AI-Trader\AITrader\WindowsFormsApp1\Resource\OhlcData.csv", FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
            StreamReader sr = new StreamReader(fs, System.Text.Encoding.Default);
            String line;
            while ((line = sr.ReadLine()) != null)
            {
                string[] lines = line.Split(separator, StringSplitOptions.RemoveEmptyEntries);
                foreach (string l in lines)
                {
                    if (string.IsNullOrEmpty(l))
                        continue;

                    string[] data = l.Split(',');
                    CandleDataInfo dataItem = new CandleDataInfo()
                    {
                        Date = DateTime.Parse(data[0], CultureInfo.InvariantCulture),
                        Open = double.Parse(data[1], CultureInfo.InvariantCulture),
                        High = double.Parse(data[2], CultureInfo.InvariantCulture),
                        Low = double.Parse(data[3], CultureInfo.InvariantCulture),
                        Close = double.Parse(data[4], CultureInfo.InvariantCulture)
                    };

                    chartData.Add(dataItem);
                }
            }
            return chartData;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
