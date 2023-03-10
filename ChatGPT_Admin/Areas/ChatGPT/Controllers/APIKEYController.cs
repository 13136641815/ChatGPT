using ChatGPT_Admin.Helper;
using ChatGPT_Admin.Models;
using ChatGPT_Mapper;
using ChatGPT_Model;
using ChatGPT_Model.AppModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using SqlSugar;
using System.Collections.Generic;
using System.Reflection;
using System.Threading.Tasks;
using System.Xml;

namespace ChatGPT_Admin.Areas.ChatGPT.Controllers
{
    [Area("ChatGPT")]
    public class APIKEYController : Controller
    {
        public IActionResult KeyPool()
        {
            return View();
        }
        [HttpGet]
        public async Task<JsonResult> GetListPage(PageParams Page, GPT_KeyPool model)
        {
            Mapper_GPT_KeyPool app = new Mapper_GPT_KeyPool();
            RefAsync<int> DataCount = 0;
            var list = await app.GetListPageAsync(Page, model, DataCount);
            return Json(new Result()
            {
                DATA = new ResultPage()
                {
                    DATACOUNT = DataCount,
                    DATA = list
                }
            }); ;
        }
        [HttpPost]
        public async Task<JsonResult> Add([FromBody] GPT_KeyPool model)
        {
            Mapper_GPT_KeyPool app = new Mapper_GPT_KeyPool();
            int i = await app.AddAsync(model);
            model.ID = i;
            return Json(new Result()
            {
                CODE = i > 0 ? ResultCode.Success : ResultCode.Empty,
                DATA = model
            });
        }
        [HttpPut]
        public async Task<JsonResult> Update([FromBody] GPT_KeyPool model)
        {
            Mapper_GPT_KeyPool app = new Mapper_GPT_KeyPool();
            bool isok = await app.UpdateAsync(model);
            return Json(new Result()
            {
                CODE = isok ? ResultCode.Success : ResultCode.Empty
            });
        }
        [HttpDelete]
        public async Task<JsonResult> Delete(int ID)
        {
            Mapper_GPT_KeyPool app = new Mapper_GPT_KeyPool();
            bool isok = await app.DeleteAsync(ID);
            return Json(new Result()
            {
                CODE = isok ? ResultCode.Success : ResultCode.Empty
            });
        }
        [HttpPost]
        public async Task<JsonResult> Import()
        {
            IFormFileCollection files = Request.Form.Files;
            var JsonStr = "";
            //获取上传的Excel文件
            foreach (FormFile file in files) //遍历处理每一个文件
            {
                var Stream = file.OpenReadStream();
                JsonStr = NpoiExcelExportHelper.StreamRead(Stream);
            }
            var list = JsonConvert.DeserializeObject<List<GPT_KeyPool>>(JsonStr);
            foreach (var item in list)
            {
                item.State = 1;
                item.Enable = 1;
            }
            Mapper_GPT_KeyPool app = new Mapper_GPT_KeyPool();
            var i = await app.AddList(list);
            return Json(new Result()
            {
                CODE = i > 0 ? ResultCode.Success : ResultCode.Empty,
                DATA = i
            });
        }
    }
}
