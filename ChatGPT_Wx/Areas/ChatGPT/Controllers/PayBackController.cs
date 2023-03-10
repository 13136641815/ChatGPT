using ChatGPT_Mapper;
using ChatGPT_Model.AppModel;
using ChatGPT_Service.PayBack;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using WeChat.Com.Log4net;

namespace ChatGPT_Wx.Areas.ChatGPT.Controllers
{
    [Area("ChatGPT")]
    public class PayBackController : Controller
    {
        [NoCheck]
        [HttpPost]
        public async Task<ActionResult> WeChatBack()
        {
            SYSTEM_Models.sys_Log4net model = new SYSTEM_Models.sys_Log4net()
            {
                userlogin = "微信支付回调",
                userName = "微信支付回调",
                LogTime = DateTime.Now,
                SystemName = "会员充值",
                SystemCode = "ChatGPT",
                Path = "Fuction:" + this.GetType().ToString(),
                Method = "LOG",
                LogBody = "进入PayBack",
                ResponseParams = "",
                LogLevelCode = SYSTEM_Extend.log4net.LogType.WARN.Code,
                LogLevelName = SYSTEM_Extend.log4net.LogType.WARN.Name,
                Error = "",
                ip_Address = "",
                CookiesAll = ""
            };
            Log4netHelper.WirteLog4net(model, SYSTEM_Extend.log4net.LogType.INFO.Code);
            Mapper_sys_Log4net LOG = new Mapper_sys_Log4net();
            LOG.Insert(model);
            WeChat.com.WeChatAPI.ResultNotify notify = new WeChat.com.WeChatAPI.ResultNotify(Request);
            string Str = await notify.ProcessNotify();
            return Content(Str, "text/xml");
        }

        [HttpGet]
        public async Task<JsonResult> TestBack(string No, string Openid)
        {
            WeChatPayBack app = new WeChatPayBack();
            bool isok = await app.WriteBack(No, Openid);

            return Json(new Result()
            {
                CODE = isok ? ResultCode.Success : ResultCode.Empty
            });
        }
    }
}
