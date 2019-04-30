using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strategy
{
    /// <summary>
    /// 策略管理器
    /// </summary>
    public class StrategyManager
    {

        private List<IStrategy> m_StrategyList = new List<IStrategy>();

        #region 单例模式
        private static StrategyManager m_SingletonManager = null;

        private StrategyManager()
        {
            m_SingletonManager = new StrategyManager();
        }



        public static StrategyManager CreateInstance()
        {
            if (m_SingletonManager == null)
            {
                m_SingletonManager = new StrategyManager();
                return m_SingletonManager;
            }
            else
            {
                return m_SingletonManager;
            }
        }
        #endregion

        public void AddStrategy(IStrategy stra)
        {
            if (stra == null) return;
            m_StrategyList.Add(stra);
        }
    }
}
