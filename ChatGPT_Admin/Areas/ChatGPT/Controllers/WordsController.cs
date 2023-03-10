using ChatGPT_Mapper;
using ChatGPT_Model.AppModel;
using ChatGPT_Model;
using Microsoft.AspNetCore.Mvc;
using SqlSugar;
using ChatGPT_Admin.Helper;
using System.IO;
using Newtonsoft.Json;
using NPOI.SS.Formula.Functions;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace ChatGPT_Admin.Areas.ChatGPT.Controllers
{
    [Area("ChatGPT")]
    public class WordsController : Controller
    {
        public IActionResult List()
        {
            return View();
        }
        [HttpGet]
        public async Task<JsonResult> GetListPage(PageParams Page, GPT_SensitiveWords model)
        {
            Mapper_GPT_SensitiveWords app = new Mapper_GPT_SensitiveWords();
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
        public async Task<JsonResult> Add([FromBody] GPT_SensitiveWords model)
        {
            Mapper_GPT_SensitiveWords app = new Mapper_GPT_SensitiveWords();
            int i = await app.AddAsync(model);
            model.ID = i;
            return Json(new Result()
            {
                CODE = i > 0 ? ResultCode.Success : ResultCode.Empty,
                DATA = model
            });
        }
        [HttpPut]
        public async Task<JsonResult> Update([FromBody] GPT_SensitiveWords model)
        {
            Mapper_GPT_SensitiveWords app = new Mapper_GPT_SensitiveWords();
            bool isok = await app.UpdateAsync(model);
            return Json(new Result()
            {
                CODE = isok ? ResultCode.Success : ResultCode.Empty
            });
        }
        [HttpDelete]
        public async Task<JsonResult> Delete(int ID)
        {
            Mapper_GPT_SensitiveWords app = new Mapper_GPT_SensitiveWords();
            int i = await app.DeleteAsync(ID);
            return Json(new Result()
            {
                CODE = i > 0 ? ResultCode.Success : ResultCode.Empty,
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
            var list = JsonConvert.DeserializeObject<List<GPT_SensitiveWords>>(JsonStr);
            Mapper_GPT_SensitiveWords app = new Mapper_GPT_SensitiveWords();
            var i = await app.AddList(list);
            return Json(new Result()
            {
                CODE = i > 0 ? ResultCode.Success : ResultCode.Empty,
                DATA = i
            });
        }
    }
}
