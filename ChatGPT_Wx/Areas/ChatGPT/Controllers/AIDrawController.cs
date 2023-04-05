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
            Mapper_GPT_User userApp = new Mapper_GPT_User();
            var UserModel = await userApp.GetModelFirst(model.WxOpenID);
            ChatGPT_Service.AIDraw.App AI = new ChatGPT_Service.AIDraw.App();
            int i = 0;
            if (UserModel.YN_VIP == 1 && DateTime.Now < UserModel.BeOverdue_VIP)
            {
                //是超级会员且未过期，查看免费次数
                i = (await AI.GetThisMonthsCount(model.WxOpenID));
            }
            int? AIDraw_Second = 0;
            if (UserModel.AIDraw_Second != null && UserModel.AIDraw_Second > 0)
            {
                AIDraw_Second = UserModel.AIDraw_Second;
            }
            if (i > 0 || AIDraw_Second > 0)
            {
                int[] intlist = new int[2] { i < 0 ? 0 : i, (int)AIDraw_Second };
                return Json(new Result()
                {
                    DATA = intlist
                });
            }
            else
            {
                return Json(new Result()
                {
                    CODE = ResultCode.Empty,
                    MSG = "本月剩余绘画体验次数不足！"
                });
            }
        }

    }
}
