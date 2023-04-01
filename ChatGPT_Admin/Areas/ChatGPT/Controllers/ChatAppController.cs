using ChatGPT_Mapper;
using ChatGPT_Model;
using ChatGPT_Model.AppModel;
using Microsoft.AspNetCore.Mvc;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChatGPT_Admin.Areas.ChatGPT.Controllers
{
    [Area("ChatGPT")]
    public class ChatAppController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public async Task<JsonResult> GetListPage(PageParams Page, GPT_ChatApp model)
        {
            Mapper_GPT_ChatApp app = new Mapper_GPT_ChatApp();
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
        public async Task<JsonResult> Add([FromBody] GPT_ChatApp model)
        {
            Mapper_GPT_ChatApp app = new Mapper_GPT_ChatApp();
            int i = await app.AddAsync(model);
            model.ID = i;
            return Json(new Result()
            {
                CODE = i > 0 ? ResultCode.Success : ResultCode.Empty,
                DATA = model
            });
        }
        [HttpPut]
        public async Task<JsonResult> Update([FromBody] GPT_ChatApp model)
        {
            Mapper_GPT_ChatApp app = new Mapper_GPT_ChatApp();
            bool isok = await app.UpdateAsync(model);
            return Json(new Result()
            {
                CODE = isok ? ResultCode.Success : ResultCode.Empty
            });
        }
        [HttpDelete]
        public async Task<JsonResult> Delete(int ID)
        {
            Mapper_GPT_ChatApp app = new Mapper_GPT_ChatApp();
            bool isok = await app.DeleteAsync(ID);
            return Json(new Result()
            {
                CODE = isok ? ResultCode.Success : ResultCode.Empty
            });
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
    }
}
