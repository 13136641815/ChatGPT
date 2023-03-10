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
    public class CommodityController : Controller
    {
        public IActionResult List()
        {
            return View();
        }
        [HttpGet]
        public async Task<JsonResult> GetListPage(PageParams Page, GPT_Commodity model)
        {
            Mapper_GPT_Commodity app = new Mapper_GPT_Commodity();
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
        [HttpPost]
        public async Task<JsonResult> Add([FromBody] GPT_Commodity model)
        {
            Mapper_GPT_Commodity app = new Mapper_GPT_Commodity();
            int i = await app.AddAsync(model);
            model.ID = i;
            return Json(new Result()
            {
                CODE = i > 0 ? ResultCode.Success : ResultCode.Empty,
                DATA = model
            });
        }
        [HttpPut]
        public async Task<JsonResult> Update([FromBody] GPT_Commodity model)
        {
            Mapper_GPT_Commodity app = new Mapper_GPT_Commodity();
            bool isok = await app.UpdateAsync(model);
            return Json(new Result()
            {
                CODE = isok ? ResultCode.Success : ResultCode.Empty
            });
        }
        [HttpDelete]
        public async Task<JsonResult> Delete(int ID)
        {
            Mapper_GPT_Commodity app = new Mapper_GPT_Commodity();
            bool isok = await app.DeleteAsync(ID);
            return Json(new Result()
            {
                CODE = isok ? ResultCode.Success : ResultCode.Empty
            });
        }
    }
}
