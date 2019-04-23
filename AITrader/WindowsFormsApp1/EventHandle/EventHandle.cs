using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    public class AIEventArgs : EventArgs
    {
        public object EventData
        {
            get;
            set;
        }

        public string info
        {
            get;
            set;
        }
    }

}
