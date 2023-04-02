using ChatGPT_Mapper;
using ChatGPT_Model.AppModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChatGPT_Wx.Areas.ChatGPT.Controllers
{
    [Area("ChatGPT")]
    public class AIAppController : Controller
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        public AIAppController(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public async Task<JsonResult> GetItme(string Dcode)
        {
            Mapper_sys_dictionary_item app = new Mapper_sys_dictionary_item();
            return Json(new Result()
            {
                DATA = await app.GetDiyItem(Dcode)
            });
        }
        [HttpGet]
        public async Task<JsonResult> GetAIAppAll()
        {
            Mapper_GPT_ChatApp app = new Mapper_GPT_ChatApp();
            return Json(new Result()
            {
                DATA = await app.GetAllAsync()
            });
        }
        [HttpGet]
        public async Task<JsonResult> GetApp(int ID) 
        {
            Mapper_GPT_ChatApp app = new Mapper_GPT_ChatApp();
            return Json(new Result()
            {
                DATA = await app.GetFirstAsync(ID)
            });
        }
    }
}
