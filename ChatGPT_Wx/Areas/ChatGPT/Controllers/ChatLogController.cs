using ChatGPT_Mapper;
using ChatGPT_Model;
using ChatGPT_Model.AppModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChatGPT_Wx.Areas.ChatGPT.Controllers
{
    [Area("ChatGPT")]
    public class ChatLogController : Controller
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        public ChatLogController(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public async Task<JsonResult> GetListPage(PageParams Page, GPT_ChatLog model, DateTimeParams Time)
        {
            _httpContextAccessor.HttpContext.Request.Cookies.TryGetValue("H5COOKIES", out string value);
            var CookiesModel = JsonConvert.DeserializeObject<H5Cookie>(Tools.AES.staticKeyTo_DecryptAES(value));//获取COOKIE身份
            model.Openid = CookiesModel.UserInfo.openid;
            Mapper_GPT_ChatLog app = new Mapper_GPT_ChatLog();
            RefAsync<int> DataCount = 0;
            var list = await app.GetListPageAsync(Page, model, Time, DataCount);
            return Json(new Result()
            {
                DATA = new ResultPage()
                {
                    DATACOUNT = DataCount,
                    DATA = list
                }
            });
        }
        [HttpPost]
        public async Task<JsonResult> Add([FromBody] GPT_ChatLog model)
        {
            _httpContextAccessor.HttpContext.Request.Cookies.TryGetValue("H5COOKIES", out string value);
            var CookiesModel = JsonConvert.DeserializeObject<H5Cookie>(Tools.AES.staticKeyTo_DecryptAES(value));//获取COOKIE身份
            model.Openid = CookiesModel.UserInfo.openid;
            Mapper_GPT_ChatLog app = new Mapper_GPT_ChatLog();
            int i = await app.AddAsync(model);
            return Json(new Result()
            {
                CODE = i > 0 ? ResultCode.Success : ResultCode.Empty
            });
        }
    }
}
