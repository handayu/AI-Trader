using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft;
using Newtonsoft.Json;

namespace TestProxy
{

    public class StockData
    {
        //证券名称
        public string StockName { get; set; }

        //证券数据
        public List<List<string>> Items { get; set; }

    }

    public class RequestData
    {
        public string api_name;

        public string token;

        public DataParams paramsQ;

        public string fields;
    }

    public class DataParams
    {
        public string ts_code;

        public string start_date;

        public string end_date;
    }

    public class Data
    {
        /// <summary>
        /// 
        /// </summary>
        public List<string> fields { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<List<string>> items { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string has_more { get; set; }
    }

    public class Root
    {
        /// <summary>
        /// 
        /// </summary>
        public string request_id { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int code { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string msg { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Data data { get; set; }
    }


    public class CToShareAPI
    {
        /// <summary>
        /// Json帮助类
        /// </summary>
        public static class JsonDataContractJsonSerializer
        {
            /// <summary>
            /// 将对象序列化为JSON格式
            /// </summary>
            /// <param name="o">对象</param>
            /// <returns>json字符串</returns>
            public static string SerializeObject(object o)
            {
                string json = JsonConvert.SerializeObject(o);
                return json;
            }

            /// <summary>
            /// 解析JSON字符串生成对象实体
            /// </summary>
            /// <typeparam name="T">对象类型</typeparam>
            /// <param name="json">json字符串(eg.{"ID":"112","Name":"石子儿"})</param>
            /// <returns>对象实体</returns>
            public static T DeserializeJsonToObject<T>(string json) where T : class
            {
                JsonSerializer serializer = new JsonSerializer();
                StringReader sr = new StringReader(json);
                object o = serializer.Deserialize(new JsonTextReader(sr), typeof(T));
                T t = o as T;
                return t;
            }

            /// <summary>
            /// 解析JSON数组生成对象实体集合
            /// </summary>
            /// <typeparam name="T">对象类型</typeparam>
            /// <param name="json">json数组字符串(eg.[{"ID":"112","Name":"石子儿"}])</param>
            /// <returns>对象实体集合</returns>
            public static List<T> DeserializeJsonToList<T>(string json) where T : class
            {
                JsonSerializer serializer = new JsonSerializer();
                StringReader sr = new StringReader(json);
                object o = serializer.Deserialize(new JsonTextReader(sr), typeof(List<T>));
                List<T> list = o as List<T>;
                return list;
            }

            /// <summary>
            /// 反序列化JSON到给定的匿名对象.
            /// </summary>
            /// <typeparam name="T">匿名对象类型</typeparam>
            /// <param name="json">json字符串</param>
            /// <param name="anonymousTypeObject">匿名对象</param>
            /// <returns>匿名对象</returns>
            public static T DeserializeAnonymousType<T>(string json, T anonymousTypeObject)
            {
                T t = JsonConvert.DeserializeAnonymousType(json, anonymousTypeObject);
                return t;
            }
        }

        //{
        //    "api_name": "daily",
        //    "token":"eea049d7d60973c01823ea6593ced55386e676abcda5b7b44bb19995",
        //    "params":{"ts_code":"000001.SZ","start_date":"20180701", "end_date":"20190718"},
        //    "fields":""
        //}

        //result
        //ts_code trade_date  open high   low close  pre_close change    pct_chg vol        amount

        //ts_code str N 股票代码（支持多个股票同时提取，逗号分隔)
        //trade_date str N 交易日期（YYYYMMDD）
        //start_date str N 开始日期(YYYYMMDD)
        //end_date str N 结束日期(YYYYMMDD)

        private string m_token;
        public string TOCKEN
        {
            get
            {
                return m_token;
            }
            set
            {
                m_token = value;
            }
        }

        private string m_apiName;
        public string APINAME
        {
            get
            {
                return m_apiName;
            }
            set
            {
                m_apiName = value;
            }
        }

        public void Init(ReqLoginData loginData)
        {
            string exData = loginData.Exdata;
            string[] strArray = exData.Split('|');
            m_apiName = strArray[0];
            m_token = strArray[1];

        }

        public StockData QueryHistory(ReqHistoryData hisData)
        {
            // url:POST请求地址
            // postData:json格式的请求报文,例如：{"key1":"value1","key2":"value2"}
            // 发送的链接包含在代码里，因为不变
            // stockCode = "000001.SZ"
            string year = DateTime.Now.ToString("yyyy");
            string month = DateTime.Now.ToString("MM");
            string day = DateTime.Now.ToString("dd");

            string dateToday = year + month + day;

            //在这里把日期默认到当天end_day
            DataParams DP = new DataParams()
            {
                ts_code = hisData.Code,
                start_date = "20190101",
                end_date = dateToday
            };

            RequestData dataReq = new RequestData()
            {
                api_name = m_apiName,
                token = m_token,
                paramsQ = DP,
                fields = ""
            };

            string json1 = JsonDataContractJsonSerializer.SerializeObject(dataReq);
            json1 = json1.Replace("Q", "");

            //
            string result = "";
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(@"http://api.waditu.com");
            req.Method = "POST";
            req.Timeout = 6000;//设置请求超时时间，单位为毫秒
            req.ContentType = "text/plain";
            byte[] data = Encoding.UTF8.GetBytes(json1);
            req.ContentLength = data.Length;
            using (Stream reqStream = req.GetRequestStream())
            {
                reqStream.Write(data, 0, data.Length);
                reqStream.Close();
            }
            HttpWebResponse resp = (HttpWebResponse)req.GetResponse();
            Stream stream = resp.GetResponseStream();
            //获取响应内容
            using (StreamReader reader = new StreamReader(stream, Encoding.UTF8))
            {
                result = reader.ReadToEnd();
            }

            //反序列化之后返回
            Root rootData = JsonDataContractJsonSerializer.DeserializeJsonToObject<Root>(result);

            StockData sD = new StockData();
            sD.StockName = hisData.Code;
            sD.Items = rootData.data.items;

            return sD;
        }


    }
}
