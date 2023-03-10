using ChatGPT_Mapper;
using ChatGPT_Model.AppModel;
using Microsoft.AspNetCore.DataProtection.KeyManagement;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
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
                var isok =await app.CheckedInfo(model.UserInfo);
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
                var isok =await app.CheckedInfo(model.UserInfo);
            }
            return Json(new Result());
        }
    }
}
