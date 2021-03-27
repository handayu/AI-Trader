using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProxy
{

    /// <summary>
    /// 单例模式的实现
    /// </summary>
    public class ProxyManager
    {
        private static ProxyManager Instance;

        CMyDemoProxy demoProxy;
        CToShareProxy toShareProxy;

        private ProxyManager()
        {
            demoProxy = new CMyDemoProxy(EXCHANGETHROUGH.Demo);
            toShareProxy = new CToShareProxy(EXCHANGETHROUGH.TuShare);
        }

        public static ProxyManager GetInstance()
        {
            if (Instance == null)
            {
                Instance = new ProxyManager();
            }
            return Instance;
        }



        public BaseProxy GetProxy(EXCHANGETHROUGH proxyThrough)
        {
            switch (proxyThrough)
            {
                case EXCHANGETHROUGH.Demo:
                    return demoProxy;
                    break;
                case EXCHANGETHROUGH.TuShare:
                    return toShareProxy;
                    break;
                default:
                    break;
            }
            return null;
        }

    }
}


