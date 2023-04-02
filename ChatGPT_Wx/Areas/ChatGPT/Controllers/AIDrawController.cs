using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ChatGPT_Mapper;
using ChatGPT_Model.AppModel;

namespace ChatGPT_Wx.Areas.ChatGPT.Controllers
{
    [Area("ChatGPT")]
    public class AIDrawController : Controller
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        public AIDrawController(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public async Task<JsonResult> GetUserDrawTop10()
        {
            Mapper_GPT_ChatLog app = new Mapper_GPT_ChatLog();
            return Json(new Result()
            {
                DATA = await app.GetTop10()
            });
        }
        [HttpGet]
        public async Task<JsonResult> Check()
        {
            GetCookiesController CookiesApp = new GetCookiesController(_httpContextAccessor);
            var model = await CookiesApp.GetInfoModelFromCookies();
            int i = (await GetThisMonthsCount(model.WxOpenID));
            if (i > 0)
            {
                return Json(new Result()
                {
                    DATA = i
                });
            }
            else
            {
                return Json(new Result()
                {
                    CODE = ResultCode.Empty,
                    MSG = "本月剩余体验次数不足，若有特殊需求，请联系客服"
                });
            }
        }
        async Task<int> GetThisMonthsCount(string OpenID)
        {
            DateTime today = DateTime.Today;
            DateTime firstDayOfMonth = new DateTime(today.Year, today.Month, 1);
            DateTime lastDayOfMonth = firstDayOfMonth.AddMonths(1).AddDays(-1).AddHours(23).AddMinutes(59);
            Mapper_GPT_ChatLog app = new Mapper_GPT_ChatLog();
            var list = await app.GetListFromMonth(firstDayOfMonth, lastDayOfMonth, OpenID);
            Mapper_GPT_Setup setApp = new Mapper_GPT_Setup();
            var setModel = await setApp.GetFirstAsync();
            int Draw_Second = setModel.Draw_Second;
            return Draw_Second - list.Count;
        }
    }
}
