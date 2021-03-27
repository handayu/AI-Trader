/********************************************************************
	created:	2021/03/25
	author:		Hanyu	
	purpose:	Abstract Class
*********************************************************************/

//"""
//    Abstract Proxy class for creating gateways connection
//    to different trading systems.

//    # How to implement a gateway:

//    -- -
//## Basics
//    A Proxy should satisfies:
//    *this class should be thread-safe:
//        *all methods should be thread-safe
//        * no mutable shared properties between objects.
//    * all methods should be non-blocked
//    * satisfies all requirements written in Proxy for every method and callbacks.
//    * automatically reconnect if connection lost.

//    ---
//    ## methods must implements:
//    all @abstractmethod

//    ---
//    ## callbacks must response manually:
//    * on_tick
//    * on_trade
//    * on_order
//    * on_position
//    * on_account
//    * on_contract

//    All the XxxData passed to callback should be constant, which means that
//        the object should not be modified after passing to on_xxxx.
//    So if you use a cache to store reference of data, use copy.copy to create a new object
//    before passing that data into on_xxxx
//    抽象层业务适配器Abs
//
//    交易的抽象业务接口：
//    1.初始化 2.连接 3.登陆 4.查询(资金/委托/成交/持仓/基础信息/.) 5.交易(委托/撤单) 6.退出 7.日志打印

//    行情的抽象业务接口:
//    1.初始化 2.连接 3.登陆 4.查询(基础信息/.) 5.订阅行情 6.查历史行情 7.退出 8.日志打印

//    合并交易与行情的抽象层业务表示
//    1.初始化 2.连接 3.登陆 4.查询(资金/委托/成交/持仓/基础信息/.) 5.订阅行情 6.交易(委托/撤单/) 7.查询历史行情 8.退出 9.日志打印
//
//    回调业务上层抽象
//    1.初始化回调 2.连接回调 ............

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProxy
{
    public abstract class BaseProxy
    {

        //开启一个线程，转发API上层的请求，做流控等限制，比如req(Enum,Object),在这个线程里转发到底层API请求里进行请求;
        //开启一个新的线程，该线程主要用于捕获底层抛出的回调信息队列，用于上层转发；
        protected System.Threading.Thread m_OnSpiEventThread;
        protected System.Threading.Thread m_ReqEventThread;

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

        /// <summary>
        /// 对外全部以事件形式广播，由于.net子类无法直接调用基类事件，
        /// 因此使用抽象函数指针强制重写，间接调用，供外部订阅
        /// </summary>
        public delegate void OnLoginHandle();
        public event OnLoginHandle OnLoginEvent;

        public delegate void OnTickHandle(RspHistoryData hD);
        public event OnTickHandle OnTickEvent;

        public delegate void OnTradeHandle();
        public event OnTradeHandle OnTradeEvent;

        public delegate void OnOrderHandle();
        public event OnOrderHandle OnOrderEvent;

        public delegate void OnPositinHandle();
        public event OnPositinHandle OnPositinEvent;

        public delegate void OnAccountHandle();
        public event OnAccountHandle OnAccountEvent;

        public delegate void OnContractHandle();
        public event OnContractHandle OnContractEvent;

        public delegate void OnLogaHandle();
        public event OnLogaHandle OnLogEvent;

        #region 抽象接口
        /// <summary>
        /// 行情交易公用
        /// </summary>
        public virtual void Init(ReqLoginData loginData) { }
        public virtual void Connect() { }
        public virtual void Login() { }

        /// <summary>
        /// 交易
        /// </summary>
        public virtual void QueryAccount() { }
        public virtual void QueryPosition() { }
        public virtual void QueryTrade() { }
        public virtual void QueryOrder() { }
        public virtual void QueryContract() { }
        public virtual void SendOrder() { }
        public virtual void CancelOrder() { }
        public virtual void SendOrders() { }
        public virtual void CancelOrders() { }

        /// <summary>
        /// 行情
        /// </summary>
        public virtual void SubScribe() { }
        public virtual void QueryHistory(ReqHistoryData hisData) { }

        /// <summary>
        /// 交易与行情公用
        /// </summary>
        public virtual void Close() { }
        #endregion

        #region 抽象回调
        protected virtual void OnLogin()
        {
            if (this.OnLoginEvent != null) OnLoginEvent();
        }

        protected virtual void OnTick(RspHistoryData hD)
        {
            if (this.OnTickEvent != null) OnTickEvent(hD);
        }

        protected virtual void OnTrade() 
        {
            if (this.OnTradeEvent != null) OnTradeEvent();

        }

        protected virtual void OnOrder() 
        {
            if (this.OnOrderEvent != null) OnOrderEvent();

        }

        protected virtual void OnPosition() 
        {
            if (this.OnPositinEvent != null) OnPositinEvent();

        }

        protected virtual void OnAccount()
        {
            if (this.OnAccountEvent != null) OnAccountEvent();

        }

        protected virtual void OnLog() 
        {
            if (this.OnLogEvent != null) OnLogEvent();

        }

        protected virtual void OnContract() 
        {
            if (this.OnContractEvent != null) OnContractEvent();

        }
        #endregion

    }
}
