using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProxy
{
    public class BaseProxy
    {
        /// <summary>
        /// 代理名称
        /// </summary>
        protected EXCHANGETHROUGH m_proxyThroughEnum;
        public EXCHANGETHROUGH PROXYTHROUGH
        {
            get
            {
                return m_proxyThroughEnum;
            }

            set
            {
                m_proxyThroughEnum = value;
            }
        
        }

    }
}
