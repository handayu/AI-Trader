using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

namespace Telerik.Examples.WinControls.ChartView.ChartTypes.StockSeries
{
    public class CandleDataInfo : INotifyPropertyChanged
    {
        private DateTime date;
        private double open;
        private double high;
        private double low;
        private double close;

        public DateTime Date
        {
            get
            {
                return this.date;
            }
            set
            {
                this.date = value;
                this.OnPropertyChanged("Date");
            }
        }

        public double Open
        {
            get
            {
                return this.open;
            }
            set
            {
                this.open = value;
                this.OnPropertyChanged("Open");
            }
        }

        public double High
        {
            get
            {
                return this.high;
            }
            set
            {
                this.high = value;
                this.OnPropertyChanged("High");
            }
        }

        public double Low
        {
            get
            {
                return this.low;
            }
            set
            {
                this.low = value;
                this.OnPropertyChanged("Low");
            }
        }

        public double Close
        {
            get
            {
                return this.close;
            }
            set
            {
                this.close = value;
                this.OnPropertyChanged("Close");
            }
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
