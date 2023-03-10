using ChatGPT_Mapper;
using ChatGPT_Model;
using ChatGPT_Model.AppModel;
using Microsoft.AspNetCore.Mvc;
using SqlSugar;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ChatGPT_Admin.Areas.ChatGPT.Controllers
{
    [Area("ChatGPT")]
    public class CommissionController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public async Task<JsonResult> GetListPage(PageParams Page, GPT_Commission model, DateTimeParams Time)
        {
            Mapper_GPT_Commission app = new Mapper_GPT_Commission();
            RefAsync<int> DataCount = 0;
            var list = await app.GetListPageAdminAsync(Page, model, Time, DataCount);
            var SUM = await app.GetListSumAdminAsync(Page, model, Time, DataCount);
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
        [HttpPut]
        public async Task<JsonResult> CheckList([FromBody] List<GPT_Commission> modellist)
        {
            Mapper_GPT_Commission app = new Mapper_GPT_Commission();
            var I = await app.UpdateCheckState(modellist);
            return Json(new Result()
            {
                CODE = I > 0 ? ResultCode.Success : ResultCode.Empty
            });

        }
    }
}
