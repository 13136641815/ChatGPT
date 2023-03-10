using ChatGPT_Mapper;
using ChatGPT_Model.AppModel.User;
using ChatGPT_Model.AppModel;
using ChatGPT_Model;
using Microsoft.AspNetCore.Mvc;
using SqlSugar;
using System.Threading.Tasks;

namespace ChatGPT_Admin.Areas.ChatGPT.Controllers
{
    [Area("ChatGPT")]
    public class BillController : Controller
    {
        public IActionResult BillList()
        {
            return View();
        }
        [HttpGet]
        public async Task<JsonResult> GetListPage(PageParams Page, GPT_Bill model, DateTimeParams Time)
        {
            Mapper_GPT_Bill app = new Mapper_GPT_Bill();
            RefAsync<int> DataCount = 0;
            var list = await app.GetListPageAsync(Page, model, Time, DataCount);
            var SUM = await app.GetListSumAsync(model, Time);
            return Json(new Result()
            {
                DATA = new ResultPage()
                {
                    DATACOUNT = DataCount,
                    DATASUM = SUM,
                    DATA = list
                }
            });
        }
    }
}
