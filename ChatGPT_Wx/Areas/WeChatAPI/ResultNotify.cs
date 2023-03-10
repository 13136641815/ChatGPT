using ChatGPT_Service.PayBack;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using SYSTEM_Extend.log4net;
using WeChat.com.WeChatAPI;
using WeChat.Com.Log4net;
namespace WeChat.com.WeChatAPI
{
    public class ResultNotify : Notify
    {
        public ResultNotify(HttpRequest page)
            : base(page)
        {

        }
        public async Task<string> ProcessNotify()
        {
            Dictionary<string, string> logDi = new Dictionary<string, string>();
            PayData notifyData = GetNotifyData();
            //检查支付结果中transaction_id是否存在
            if (!notifyData.IsSet("transaction_id"))
            {
                //若transaction_id不存在，则立即返回结果给微信支付后台
                PayData res = new PayData();
                res.SetValue("return_code", "FAIL");
                res.SetValue("return_msg", "支付结果中微信订单号不存在");
                logDi.Add("回收参数异常：", JsonConvert.SerializeObject(notifyData.GetValues()));
                logDi.Add("返回给腾讯：", res.ToXml());
                await PayLog(logDi);
                return res.ToXml();
            }
            logDi.Add("回收参数初步正常：", JsonConvert.SerializeObject(notifyData.GetValues()));
            string transaction_id = notifyData.GetValue("transaction_id").ToString();//解析接收到订单号
            //查询订单，判断订单真实性
            if (!QueryOrder(transaction_id))
            {
                //若订单查询失败，则立即返回结果给微信支付后台
                PayData res = new PayData();
                res.SetValue("return_code", "FAIL");
                res.SetValue("return_msg", "订单查询失败");
                logDi.Add("订单查询：", "失败！");
                logDi.Add("返回给腾讯：", res.ToXml());
                await PayLog(logDi);
                return res.ToXml();
            }
            else
            {
                //查询订单成功
                string strout_trade_no = notifyData.GetValue("out_trade_no").ToString();//订单号
                                                                                        //处理业务 修改支付状态为成功
                                                                                        //处理业务
                string stropenid = notifyData.GetValue("openid").ToString();//openid
                WeChatPayBack app = new WeChatPayBack();
                PayData res = new PayData();
                bool isok = await app.WriteBack(strout_trade_no, stropenid);
                if (isok)
                {
                    //↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓可以做支付成功业务了
                    res.SetValue("return_code", "SUCCESS");
                    res.SetValue("return_msg", "OK");
                }
                return res.ToXml();
            }
        }
        async Task PayLog(Dictionary<string, string> di)
        {
            SYSTEM_Models.sys_Log4net modelLog4 = new SYSTEM_Models.sys_Log4net()
            {
                userlogin = "微信支付回调",
                userName = "微信支付回调",
                LogTime = DateTime.Now,
                SystemName = "ChatGPT",
                SystemCode = "ChatGPT",
                Path = "Fuction:" + this.GetType().ToString(),
                Method = "LOG",
                LogBody = JsonConvert.SerializeObject(di),
                ResponseParams = "",
                LogLevelCode = LogType.WARN.Code,
                LogLevelName = LogType.WARN.Name,
                Error = "",
                ip_Address = this.page.HttpContext.Connection.RemoteIpAddress.ToString() + ":" + this.page.HttpContext.Connection.RemotePort,
                CookiesAll = ""
            };
            Log4netHelper.WirteLog4net(modelLog4, LogType.INFO.Code);
            //插入数据库日志
            ChatGPT_Mapper.Mapper_sys_Log4net LOG = new ChatGPT_Mapper.Mapper_sys_Log4net();
            await LOG.Insert(modelLog4);
        }
        //查询订单
        private bool QueryOrder(string transaction_id)
        {
            PayData req = new PayData();
            req.SetValue("transaction_id", transaction_id);
            PayData res = OrderQuery(req);
            if (res.GetValue("return_code").ToString() == "SUCCESS" &&
                res.GetValue("result_code").ToString() == "SUCCESS")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public PayData OrderQuery(PayData inputObj, int timeOut = 6)
        {
            string url = "https://api.mch.weixin.qq.com/pay/orderquery";
            //检测必填参数
            if (!inputObj.IsSet("out_trade_no") && !inputObj.IsSet("transaction_id"))
            {
                throw new WxPayException("订单查询接口中，out_trade_no、transaction_id至少填一个！");
            }
            PayConfigParameter config = new PayConfigParameter();
            inputObj.SetValue("appid", config.appid);//公众账号ID
            inputObj.SetValue("mch_id", config.mch_id);//商户号
            inputObj.SetValue("nonce_str", Guid.NewGuid().ToString().Replace("-", ""));//随机字符串
            inputObj.SetValue("sign", inputObj.MakeSign());//签名
            string xml = inputObj.ToXml();
            var start = DateTime.Now;
            //Log.Debug("WxPayAPI45", "OrderQuery request : " + xml);
            HttpClient httpClient = new HttpClient();
            byte[] data = System.Text.Encoding.UTF8.GetBytes(xml);
            var byteContent = new ByteArrayContent(data);
            string response = httpClient.PostAsync(url, byteContent).Result.Content.ReadAsStringAsync().Result;//异步调用post请求
            //Log.Debug("WxPayAPI45", "OrderQuery response : " + response);
            var end = DateTime.Now;
            int timeCost = (int)((end - start).TotalMilliseconds);//获得接口耗时
            //将xml格式的数据转化为对象以返回
            PayData result = new PayData();
            result.FromXml(response);
            //ReportCostTime(url, timeCost, result);//测速上报
            return result;
        }
    }
}
