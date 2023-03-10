using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeChat.com.WeChatAPI
{
    public class Notify
    {
        public HttpRequest page { get; set; }
        public Notify(HttpRequest page)
        {
            this.page = page;
        }
        /// <summary>
        /// 接收回调数据流
        /// </summary>
        /// <returns></returns>
        public PayData GetNotifyData()
        {
            PayData PayData = new PayData();
            System.IO.Stream message = this.page.Body;
            try
            {
                using (StreamReader sr = new StreamReader(this.page.Body, Encoding.UTF8))
                {
                    string WeChatResultStr = sr.ReadToEndAsync().Result;//回收原字符串
                    PayData.FromXml(WeChatResultStr);//字符串转为 对象
                }
            }
            catch (Exception ex)
            {
                PayData.SetValue("接收数据流报错：", ex.ToString());
            }
            return PayData;
        }
        //派生类需要重写这个方法，进行不同的回调处理
        public virtual async Task<string> ProcessNotify()
        {
            return "";
        }
    }
}
