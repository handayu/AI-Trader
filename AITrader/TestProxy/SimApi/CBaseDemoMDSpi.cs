using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProxy
{
    public class CBaseDemoMDSpi
    {
        ///当客户端与交易后台建立起通信连接时（还未登录前），该方法被调用。
        public virtual void OnFrontConnected() { }

        ///当客户端与交易后台通信连接断开时，该方法被调用。当发生这个情况后，API会自动重新连接，客户端可不做处理。
        ///@param nReason 错误原因
        ///        0x1001 网络读失败
        ///        0x1002 网络写失败
        ///        0x2001 接收心跳超时
        ///        0x2002 发送心跳失败
        ///        0x2003 收到错误报文
        public virtual void OnFrontDisconnected(int nReason) { }

        ///心跳超时警告。当长时间未收到报文时，该方法被调用。
        ///@param nTimeLapse 距离上次接收报文的时间
        public virtual void OnHeartBeatWarning(int nTimeLapse) { }

        ///登录请求响应
        public  virtual void OnRspUserLogin( ) { }

        ///登出请求响应
        public virtual void OnRspUserLogout() { }

        ///错误应答
        public virtual void OnRspError() { }

        ///订阅行情应答
        public virtual void OnRspSubMarketData() { }

        ///取消订阅行情应答
        public virtual void OnRspUnSubMarketData() { }

        ///深度行情通知
        public virtual void OnRtnDepthMarketData() { }

    };
}
