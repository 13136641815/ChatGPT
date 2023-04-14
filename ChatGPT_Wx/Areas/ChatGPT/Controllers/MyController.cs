using ChatGPT_Mapper;
using ChatGPT_Model;
using ChatGPT_Model.AppModel;
using ChatGPT_Service.AES;
using ChatGPT_Service.AI;
using ChatGPT_Service.Home;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Linq;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using System.Web;

namespace ChatGPT_Wx.Areas.ChatGPT.Controllers
{
    [Area("ChatGPT")]
    public class MyController : Controller
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        public MyController(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }
        public async Task<IActionResult> Index()
        {
            Mapper_GPT_Setup setApp = new Mapper_GPT_Setup();
            var setmodel = await setApp.GetFirstAsync();
            ViewBag.CommissionRemark = setmodel.CommissionRemark;
            _httpContextAccessor.HttpContext.Request.Cookies.TryGetValue("H5COOKIES", out string value);
            if (value != null && value != "")
            {
                var model = JsonConvert.DeserializeObject<H5Cookie>(Tools.AES.staticKeyTo_DecryptAES(value));//获取COOKIE身份
                ChatGPT_Service.Home.Mapper_HomeController app = new ChatGPT_Service.Home.Mapper_HomeController();
                var isok = await app.CheckedInfo(model.UserInfo);
            }
            return View();
        }
        public async Task<IActionResult> PersonalCnter()
        {
            Mapper_GPT_Setup setApp = new Mapper_GPT_Setup();
            var setmodel = await setApp.GetFirstAsync();
            ViewBag.CommissionRemark = setmodel.CommissionRemark;
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
        public async Task<JsonResult> GetInfoModel()
        {
            _httpContextAccessor.HttpContext.Request.Cookies.TryGetValue("H5COOKIES", out string value);
            var CookiesModel = JsonConvert.DeserializeObject<H5Cookie>(Tools.AES.staticKeyTo_DecryptAES(value));//获取COOKIE身份
            Mapper_AIController app = new Mapper_AIController();
            var model = await app.GetModelFirstAsync(CookiesModel.UserInfo.openid);
            BusUserModel Model = new BusUserModel()
            {
                ID = model.ID,
                Tel = model.Tel,
                NikeName = model.NikeName,
                WxOpenID = model.WxOpenID,
                WxHeadUrl = model.WxHeadUrl,
                YN_VIP = model.YN_VIP,
                Type_VIP = model.Type_VIP,
                BeOverdue_VIP = model.BeOverdue_VIP,
                Free_Second = model.Free_Second,
                VIP_Type = model.YN_VIP == 1 && model.BeOverdue_VIP > DateTime.Now ? 1 : model.YN_PVIP == 1 && model.BeOverdue_PVIP > DateTime.Now ? 0 : -1,
                AccountType = model.AccountType,
                AccountNum = model.AccountNum,
                Block = model.Block,
                AIDraw_Second = model.AIDraw_Second

            };
            return Json(new Result()
            {
                DATA = Model
            });
        }
        [HttpGet]
        public async Task<JsonResult> GetMyQrCode()
        {
            _httpContextAccessor.HttpContext.Request.Cookies.TryGetValue("H5COOKIES", out string value);
            var CookiesModel = JsonConvert.DeserializeObject<H5Cookie>(Tools.AES.staticKeyTo_DecryptAES(value));//获取COOKIE身份
            TencentQrCode app = new TencentQrCode();
            string ticket = await app.GetQRCodeTicket(CookiesModel.UserInfo.openid);
            var CODE = ResultCode.Success;
            var Base64QR = await app.UrlToImage("https://mp.weixin.qq.com/cgi-bin/showqrcode?ticket=" + HttpUtility.UrlEncode(ticket));
            var Base64Heard = await app.UrlToImage(CookiesModel.UserInfo.headimgurl);
            Mapper_GPT_Setup setApp = new Mapper_GPT_Setup();
            var setmodel = await setApp.GetFirstAsync();
            var bg = await app.UrlToImage(setmodel.PushImg);
            if (string.IsNullOrEmpty(ticket))
            {
                CODE = ResultCode.Empty;
            }
            return Json(new Result()
            {
                CODE = CODE,
                DATA = new Base64Img()
                {
                    Base64QR = Base64QR,
                    Base64Heard = Base64Heard,
                    Base64Bg = bg
                }
            });
        }
        [HttpPut]
        public JsonResult ExchangeCDK([FromBody] GPT_CDK model)
        {
            _httpContextAccessor.HttpContext.Request.Cookies.TryGetValue("H5COOKIES", out string value);
            var CookiesModel = JsonConvert.DeserializeObject<H5Cookie>(Tools.AES.staticKeyTo_DecryptAES(value));//获取COOKIE身份
            (bool isok, string msg) = CDK.ExchangeCDK(model.CDK, CookiesModel.UserInfo.openid);
            return Json(new Result()
            {
                CODE = isok ? ResultCode.Success : ResultCode.Empty,
                DATA = msg,
                MSG = msg
            });
        }
        [HttpPut]
        public async Task<JsonResult> UpdateAccountNum([FromBody] GPT_User model)
        {
            Mapper_GPT_User app = new Mapper_GPT_User();
            bool isok = await app.UpdateAccount(model);
            return Json(new Result()
            {
                CODE = isok ? ResultCode.Success : ResultCode.Empty,
                MSG = isok ? "成功" : "提交失败",
            });
        }
        [HttpGet]
        public async Task<JsonResult> GetMoneyType()
        {
            _httpContextAccessor.HttpContext.Request.Cookies.TryGetValue("H5COOKIES", out string value);
            var CookiesModel = JsonConvert.DeserializeObject<H5Cookie>(Tools.AES.staticKeyTo_DecryptAES(value));//获取COOKIE身份
            Mapper_GPT_Commission app = new Mapper_GPT_Commission();
            var list = await app.GetListAll_byOpenID(CookiesModel.UserInfo.openid);
            decimal? JeA = list.Where(it => it.CheckState == 0).Sum(it => it.Commission);
            decimal? JeB = list.Where(it => it.CheckState == 2).Sum(it => it.Commission);
            decimal? JeC = list.Where(it => it.CheckState == 1).Sum(it => it.Commission);
            return Json(new Result()
            {
                DATA = new CommissionMoneyType()
                {
                    JeA = JeA,
                    JeB = JeB,
                    JeC = JeC,
                }
            });
        }
    }
}
