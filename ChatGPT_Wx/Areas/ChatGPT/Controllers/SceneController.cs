using ChatGPT_Model.AppModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace ChatGPT_Wx.Areas.ChatGPT.Controllers
{
    [Area("ChatGPT")]
    public class SceneController : Controller
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        public SceneController(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public async Task<JsonResult> GetBot()
        {
            _httpContextAccessor.HttpContext.Request.Cookies.TryGetValue("H5COOKIES", out string value);
            var model = JsonConvert.DeserializeObject<H5Cookie>(Tools.AES.staticKeyTo_DecryptAES(value));//获取COOKIE身份
            ChatGPT_Mapper.Mapper_GPT_BobotList app = new ChatGPT_Mapper.Mapper_GPT_BobotList();
            ChatGPT_Service.Home.Mapper_HomeController app1 = new ChatGPT_Service.Home.Mapper_HomeController();
            var list = await app.GetBotAllAsync(model.UserInfo.openid);
            var isok = await app1.CheckedInfo(model.UserInfo);
            return Json(new Result()
            {
                DATA = list
            });
        }
    }
}
