using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProxy
{
    public enum EXCHANGETHROUGH
    {
        Demo
    }

    /// <summary>
    /// 单例模式的实现
    /// </summary>
    public class ProxyManager
    {
        private static ProxyManager Instance;

        CMyDemoProxy demoProxy;

        private ProxyManager()
        {
            demoProxy = new CMyDemoProxy(EXCHANGETHROUGH.Demo);

        }

        public static ProxyManager GetInstance()
        {
            if (Instance == null)
            {
                Instance = new ProxyManager();
            }
            return Instance;
        }



        public CMyDemoProxy GetProxy(EXCHANGETHROUGH proxyThrough)
        {
            switch (proxyThrough)
            {
                case EXCHANGETHROUGH.Demo:
                    return demoProxy;
                    break;
                default:
                    break;
            }
            return null;
        }

    }
}


