using OKExSDK.Models.Swap;
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

        private List<swap.Instrument> m_insList = new List<swap.Instrument>();
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


        private swap.PositionResult<Position> m_positionList = new swap.PositionResult<Position>();
        public swap.PositionResult<Position> PositionList
        {
            set
            {
                m_positionList = value;
            }
            get
            {
                return m_positionList;
            }
        }

        private List<swap.Trade> m_tradeList = new List<swap.Trade>();
        public List<swap.Trade> TradeList
        {
            set
            {
                m_tradeList = value;
            }
            get
            {
                return m_tradeList;
            }
        }


        private swap.OrderListResult m_orderList = new swap.OrderListResult();
        public swap.OrderListResult OrderList
        {
            set
            {
                m_orderList = value;
            }
            get
            {
                return m_orderList;
            }
        }

    }
}
