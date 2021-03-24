using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProxy
{

    public class CDemoMDApi
    {
        ///创建MdApi
        ///@param pszFlowPath 存贮订阅信息文件的目录，默认为当前目录
        ///@return 创建出的UserApi
        ///modify for udp marketdata
        public static CDemoMDApi CreateMdApi()
        {
            return new CDemoMDApi();
        }

        ///获取API的版本信息
        ///@retrun 获取到的版本号
        public string GetApiVersion()
        {
            return "DemoApiV1.0.0";
        }

        ///删除接口对象本身
        ///@remark 不再使用本接口对象时,调用该函数删除接口对象
        public void Release()
        {

        }

        ///初始化
        ///@remark 初始化运行环境,只有调用后,接口才开始工作
        public void Init()
        {

        }

        ///等待接口线程结束运行
        ///@return 线程退出代码
        public void Join()
        {

        }

        ///获取当前交易日
        ///@retrun 获取到的交易日
        ///@remark 只有登录成功后,才能得到正确的交易日
        public DateTime GetTradingDay()
        {
            return DateTime.Now;
        }

        ///注册前置机网络地址
        ///@param pszFrontAddress：前置机网络地址。
        ///@remark 网络地址的格式为：“protocol://ipaddress:port”，如：”tcp://127.0.0.1:17001”。 
        ///@remark “tcp”代表传输协议，“127.0.0.1”代表服务器地址。”17001”代表服务器端口号。
        public void RegisterFront(string frontAddress)
        {

        }


        ///注册回调接口
        ///@param pSpi 派生自回调接口类的实例
        public void RegisterSpi(CBaseDemoMDSpi userSpi)
        {

        }

        ///订阅行情。
        ///@param ppInstrumentID 合约ID  
        ///@param nCount 要订阅/退订行情的合约个数
        ///@remark 
        public int SubscribeMarketData(string[] pInstrumentStr, int nCount)
        {
            return 1;
        }

        ///退订行情。
        ///@param ppInstrumentID 合约ID  
        ///@param nCount 要订阅/退订行情的合约个数
        ///@remark 
        public int UnSubscribeMarketData(string[] pInstrumentStr, int nCount)
        {
            return 1;
        }


        ///用户登录请求
        public int ReqUserLogin()
        {
            return 1;
        }


        ///登出请求
        public int ReqUserLogout()
        {
            return 1;
        }
    }
}
