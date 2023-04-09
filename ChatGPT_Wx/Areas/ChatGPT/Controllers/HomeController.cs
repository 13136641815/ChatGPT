using ChatGPT_Mapper;
using ChatGPT_Model.AppModel;
using ChatGPT_Model.Tencent;
using ChatGPT_Service.Home;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ChatGPT_Wx.Areas.ChatGPT.Controllers
{
    [Area("ChatGPT")]
    public class HomeController : Controller
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        public HomeController(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }
        [Route("")]
        [Route("Home")]
        [Route("Home/Index")]
        public async Task<IActionResult> Index()
        {
            Mapper_GPT_Setup setApp = new Mapper_GPT_Setup();
            var setmodel = await setApp.GetFirstAsync();
            ViewBag.Title = setmodel.Title;
            _httpContextAccessor.HttpContext.Request.Cookies.TryGetValue("H5COOKIES", out string value);
            if (value != null && value != "")
            {
                var model = JsonConvert.DeserializeObject<H5Cookie>(Tools.AES.staticKeyTo_DecryptAES(value));//获取COOKIE身份
                ChatGPT_Service.Home.Mapper_HomeController app = new ChatGPT_Service.Home.Mapper_HomeController();
                var isok = await app.CheckedInfo(model.UserInfo);
            }
            return View();
        }
        [HttpGet]
        public async Task<JsonResult> CheckedInfo()
        {
            _httpContextAccessor.HttpContext.Request.Cookies.TryGetValue("H5COOKIES", out string value);
            if (value != null && value != "")
            {
                var model = JsonConvert.DeserializeObject<H5Cookie>(Tools.AES.staticKeyTo_DecryptAES(value));//获取COOKIE身份
                ChatGPT_Service.Home.Mapper_HomeController app = new ChatGPT_Service.Home.Mapper_HomeController();
                var isok = await app.CheckedInfo(model.UserInfo);
            }
            return Json(new Result());
        }
        [HttpGet]
        public async Task<JsonResult> GetWxShare(string HtmlURL)
        {
            Mapper_GPT_Setup setApp = new Mapper_GPT_Setup();
            var setModel = await setApp.GetFirstAsync();
            WxShare ResModel = new WxShare();
            ResModel.appId = AppSettingsHelper.Configuration["WeChatSetup:AppID"].ToString();
            ResModel.timeStamp = Convert.ToInt64((DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, 0)).TotalSeconds).ToString();
            ResModel.nonceStr = Guid.NewGuid().ToString().Replace("-", "");
            ResModel.nTitle = setModel.Title;
            ResModel.Desc = setModel.Desc_;
            ResModel.Link = HtmlURL;
            ResModel.ImgUrl = "https://" + _httpContextAccessor.HttpContext.Request.Host.Host + "/ChatGPT_Wx/Img/ChatGPT.png";
            //获取token
            //获取ticket https://api.weixin.qq.com/cgi-bin/ticket/getticket?access_token=ACCESS_TOKEN&type=jsapi
            //签名
            TencentQrCode app = new TencentQrCode();
            string ticket = await app.GetTicket();
            string buff = $"jsapi_ticket={ticket}&noncestr={ResModel.nonceStr}&timestamp={ResModel.timeStamp}&url={HtmlURL}";
            ResModel.QM = TencentQrCode.Sha1Signature(buff);
            return Json(new Result()
            {
                DATA = ResModel,
                MSG = ""
            });
        }

    }
}
