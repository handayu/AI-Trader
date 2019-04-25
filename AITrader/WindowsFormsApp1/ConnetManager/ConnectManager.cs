using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using swap = OKExSDK.Models.Swap;

namespace WindowsFormsApp1
{
    public class ConnectManager
    {
        private static ConnectManager m_SingletonManager = null;
        private IConnectManagerSinlethon m_singlethon = null;
        private List<swap.Instrument> m_insList = new List<swap.Instrument>();

        static ConnectManager()
        {

            m_SingletonManager = new ConnectManager();
        }



        public static ConnectManager CreateInstance()
        {
            return m_SingletonManager;
        }

        public static void Start()
        {
            m_SingletonManager = new ConnectManager();
        }

        public void AddIConnect(IConnectManagerSinlethon s)
        {
            m_singlethon = s;
        }

        public IConnectManagerSinlethon CONNECTION
        {
            get
            {
                return m_singlethon;
            }
        }

        public List<swap.Instrument> InstrumentList
        {
            get
            {
                return m_insList;
            }
        }

        public void AddInstrument(swap.Instrument ins)
        {
            m_insList.Add(ins);
        }
    }
}
