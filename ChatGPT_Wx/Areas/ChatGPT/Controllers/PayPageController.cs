using ChatGPT_Mapper;
using ChatGPT_Model.AppModel;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ChatGPT_Wx.Areas.ChatGPT.Controllers
{
    [Area("ChatGPT")]
    public class PayPageController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> GetCommodityList()
        {
            Mapper_GPT_Commodity app = new Mapper_GPT_Commodity();
            var list = await app.GetCommodityListAsync();
            return Json(new Result()
            {
                DATA = list
            });
        }
    }
}
