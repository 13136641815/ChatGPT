using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ChatGPT_Model.AppModel;
using ChatGPT_Service.AI;
using ChatGPT_Mapper;
using ChatGPT_Service.ChatGPT;
using Microsoft.AspNetCore.DataProtection.KeyManagement;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using System;

namespace ChatGPT_Wx.Areas.ChatGPT.Controllers
{
    [Area("ChatGPT")]
    public class AIController : Controller
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        public AIController(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }
        public async Task<IActionResult> Index()
        {
            _httpContextAccessor.HttpContext.Request.Cookies.TryGetValue("H5COOKIES", out string value);
            if (value != null && value != "")
            {
                var model = JsonConvert.DeserializeObject<H5Cookie>(Tools.AES.staticKeyTo_DecryptAES(value));//获取COOKIE身份
                ChatGPT_Service.Home.Mapper_HomeController app = new ChatGPT_Service.Home.Mapper_HomeController();
                var isok = await app.CheckedInfo(model.UserInfo);
            }
            return View();
        }
        public async Task<IActionResult> StreamAI()
        {
            _httpContextAccessor.HttpContext.Request.Cookies.TryGetValue("H5COOKIES", out string value);
            if (value != null && value != "")
            {
                var model = JsonConvert.DeserializeObject<H5Cookie>(Tools.AES.staticKeyTo_DecryptAES(value));//获取COOKIE身份
                ChatGPT_Service.Home.Mapper_HomeController app = new ChatGPT_Service.Home.Mapper_HomeController();
                var isok = await app.CheckedInfo(model.UserInfo);
            }
            return View();
        }
        public async Task<IActionResult> GPT3_5()
        {
            _httpContextAccessor.HttpContext.Request.Cookies.TryGetValue("H5COOKIES", out string value);
            if (value != null && value != "")
            {
                var model = JsonConvert.DeserializeObject<H5Cookie>(Tools.AES.staticKeyTo_DecryptAES(value));//获取COOKIE身份
                ChatGPT_Service.Home.Mapper_HomeController app = new ChatGPT_Service.Home.Mapper_HomeController();
                var isok = await app.CheckedInfo(model.UserInfo);
            }
            return View();
        }
        public async Task<IActionResult> GPT3_5Voice()
        {
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
        public async Task<IActionResult> GetBot(int ID)
        {
            Mapper_GPT_BobotList app = new Mapper_GPT_BobotList();
            var model = await app.GetFirstAsync(ID);
            return Json(new Result()
            {
                DATA = model
            });
        }
        /// <summary>
        /// 获取api接口，流式返回
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<JsonResult> GetAPI_Url()
        {
            Result RES = new Result();
            Mapper_GPT_Setup setApp = new Mapper_GPT_Setup();
            var setmodel = await setApp.GetFirstAsync();
            RES.DATA = setmodel;
            return Json(RES);
        }
        /// <summary>
        /// 获取校验权限，流式返回
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<JsonResult> Check([FromForm] string Text)
        {
            Result RES = new Result();
            Mapper_GPT_Setup setup = new Mapper_GPT_Setup();
            var setupModel = await setup.GetFirstAsync();
            Tools.WordSearch appc = new Tools.WordSearch();
            bool isok = appc.Filter(Text);//校验关键字
            if (isok)
            {
                GetCookiesController Capp = new GetCookiesController(_httpContextAccessor);
                Mapper_GPT_User app = new Mapper_GPT_User();
                var model = await Capp.GetInfoModelFromCookies();
                //1.判断是不是会员
                if (model.YN_VIP == 1)
                {
                    //超级会员
                    //是会员，会员是否到期
                    if (DateTime.Now < model.BeOverdue_VIP)
                    {
                        //未到期，直接发送
                        RES.CODE = ResultCode.Success;
                    }
                    else
                    {
                        //已到期，提示充值
                        RES.CODE = ResultCode.Empty;
                        RES.MSG = "您的会员已到期，请续费后再使用";
                        return Json(RES);
                    }
                }
                else if (model.YN_PVIP == 1)
                {
                    //普通会员
                    //是会员，会员是否到期
                    if (DateTime.Now < model.BeOverdue_PVIP)
                    {
                        //未到期验证字数
                        if (Text.Length > setupModel.VIP_NumberWords)
                        {
                            RES.CODE = ResultCode.Empty;
                            RES.MSG = $"普通会员对话输入字长度不得超过{setupModel.VIP_NumberWords}个字";
                            return Json(RES);
                        }
                        RES.CODE = ResultCode.Success;
                    }
                    else
                    {
                        //已到期，提示充值
                        RES.CODE = ResultCode.Empty;
                        RES.MSG = "您的会员已到期，请续费后再使用";
                        return Json(RES);
                    }
                }
                else
                {
                    //非会员，查看免费次数
                    if (model.Free_Second > 0)
                    {
                        //有次数，发送成功后次数--
                        //次数--
                        RES.CODE = ResultCode.Success;
                        RES.DATA = "";
                        model.Free_Second--;
                        await app.Free_SecondAsync(model);
                    }
                    else
                    {
                        //没次数了，提示非会员
                        RES.CODE = ResultCode.Empty;
                        RES.MSG = "免费次数已用尽，请开通会员后再使用";
                        return Json(RES);
                    }
                }
            }
            else
            {
                //非法文字
                RES.CODE = ResultCode.Empty;
                RES.MSG = "您的询问内容包含敏感词汇，请修改后再尝试。";
            }
            return Json(RES);
        }
    }
}
