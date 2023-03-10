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
    public class ApplyController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public async Task<JsonResult> GetListPage(PageParams Page, GPT_CashWithdrawal model)
        {
            Mapper_GPT_CashWithdrawal app = new Mapper_GPT_CashWithdrawal();
            RefAsync<int> DataCount = 0;
            var list = await app.GetListPageAsync(Page, model, DataCount);
            return Json(new Result()
            {
                DATA = new ResultPage()
                {
                    DATACOUNT = DataCount,
                    DATA = list
                }
            });
        }
        [HttpPut]
        public async Task<JsonResult> CheckList([FromBody] List<GPT_CashWithdrawal> modellist)
        {
            Mapper_GPT_CashWithdrawal app = new Mapper_GPT_CashWithdrawal();
            var I = await app.UpdateCheckState(modellist);
            return Json(new Result()
            {
                CODE = I > 0 ? ResultCode.Success : ResultCode.Empty
            });

        }
    }
}
