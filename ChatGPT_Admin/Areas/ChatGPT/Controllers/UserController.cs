using ChatGPT_Mapper;
using ChatGPT_Model.AppModel;
using ChatGPT_Model;
using Microsoft.AspNetCore.Mvc;
using SqlSugar;
using ChatGPT_Model.AppModel.User;
using System.Threading.Tasks;

namespace ChatGPT_Admin.Areas.ChatGPT.Controllers
{
    [Area("ChatGPT")]
    public class UserController : Controller
    {
        public IActionResult List()
        {
            return View();
        }
        [HttpGet]
        public async Task<JsonResult> GetListPage(PageParams Page, GPT_User model, DateTimeParams Time, UserBusParams UserParams)
        {
            Mapper_GPT_User app = new Mapper_GPT_User();
            RefAsync<int> DataCount = 0;
            var list = await app.GetListPageAsync(Page, model, Time, UserParams, DataCount);
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
        public async Task<JsonResult> Add([FromBody] GPT_User model)
        {
            Mapper_GPT_User app = new Mapper_GPT_User();
            int i = await app.AddAsync(model);
            return Json(new Result()
            {
                CODE = i > 0 ? ResultCode.Success : ResultCode.Empty
            });
        }
        [HttpPut]
        public async Task<JsonResult> Update([FromBody] GPT_User model)
        {
            Mapper_GPT_User app = new Mapper_GPT_User();
            bool isok = await app.UpdateAsync(model);
            return Json(new Result()
            {
                CODE = isok ? ResultCode.Success : ResultCode.Empty
            });
        }
        [HttpDelete]
        public async Task<JsonResult> Delete(int ID)
        {
            Mapper_GPT_User app = new Mapper_GPT_User();
            bool isok = await app.DeleteAsync(ID);
            return Json(new Result()
            {
                CODE = isok ? ResultCode.Success : ResultCode.Empty
            });
        }
    }
}
