using ChatGPT_Mapper;
using ChatGPT_Model.AppModel;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace ChatGPT_Wx.Areas.ChatGPT.Controllers
{
    [Area("ChatGPT")]
    public class TestController : Controller
    {
        Result RES = new Result();
        Mapper_GPT_User APP = new Mapper_GPT_User();
        [NoCheck]
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public async Task<JsonResult> ResetTimes(string OpenID) 
        {
            var model = await APP.GetModelFirstAsync(OpenID);
            model.Free_Second = 5;
            var isok = await APP.UpdateTestAsync(model);
            if (!isok) 
            {
                RES.CODE = ResultCode.Empty;
            }
            return Json(RES);
        }
        [HttpGet]
        public async Task<JsonResult> NoVip(string OpenID)
        {
            var model = await APP.GetModelFirstAsync(OpenID);
            model.YN_VIP = 0;
            var isok = await APP.UpdateTestAsync(model);
            if (!isok)
            {
                RES.CODE = ResultCode.Empty;
            }
            return Json(RES);
        }
        [HttpGet]
        public async Task<JsonResult> VipTimeOut(string OpenID)
        {
            var model = await APP.GetModelFirstAsync(OpenID);
            model.BeOverdue_VIP = DateTime.Parse("2022-10-19 15:19:03.000");
            var isok = await APP.UpdateTestAsync(model);
            if (!isok)
            {
                RES.CODE = ResultCode.Empty;
            }
            return Json(RES);
        }
    }
}
