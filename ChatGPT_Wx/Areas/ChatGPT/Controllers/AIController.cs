using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ChatGPT_Model.AppModel;
using ChatGPT_Service.AI;
using ChatGPT_Mapper;
using ChatGPT_Service.ChatGPT;
using Microsoft.AspNetCore.DataProtection.KeyManagement;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

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
            string API_URL = setmodel.ApiUrl;
            if (API_URL != null && API_URL != "")
            {
                RES.DATA = API_URL;
                return Json(RES);
            }
            RES.CODE = ResultCode.Empty;
            RES.DATA = "本地API接口异常";
            RES.MSG = "本地API接口异常";
            return Json(RES);
        }
    }
}
