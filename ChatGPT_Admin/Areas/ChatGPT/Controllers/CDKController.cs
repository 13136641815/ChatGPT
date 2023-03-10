using ChatGPT_Admin.Helper;
using ChatGPT_Mapper;
using ChatGPT_Model;
using ChatGPT_Model.AppModel;
using Microsoft.AspNetCore.Mvc;
using NPOI.HSSF.UserModel;
using SqlSugar;
using SYSTEM_Extend.AES;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using System.Collections.Generic;

namespace ChatGPT_Admin.Areas.ChatGPT.Controllers
{
    [Area("ChatGPT")]
    public class CDKController : Controller
    {
        string WebRootPath = "";
        public CDKController(IWebHostEnvironment env) 
        {
            WebRootPath = env.WebRootPath;
        }
        public IActionResult CDKList()
        {
            return View();
        }
        [HttpGet]
        public async Task<JsonResult> GetListPage(PageParams Page, GPT_CDK model, DateTimeParams Time)
        {
            Mapper_GPT_CDK app = new Mapper_GPT_CDK();
            RefAsync<int> DataCount = 0;
            var list = await app.GetListPageAsync(Page, model, Time, DataCount);
            return Json(new Result()
            {
                DATA = new ResultPage()
                {
                    DATACOUNT = DataCount,
                    DATA = list
                }
            });
        }
        [HttpGet]
        public async Task<JsonResult> LeadingOut(PageParams Page, GPT_CDK model, DateTimeParams Time)
        {
            Mapper_GPT_CDK app = new Mapper_GPT_CDK();
            RefAsync<int> DataCount = 0;
            var list = await app.GetListPageAsync(Page, model, Time, DataCount);
            string ExcelPath = await ExcelOut.ListExcelOut(list, WebRootPath);

            return Json(new Result()
            {
                DATA = ExcelPath
            });
        }
        [HttpPost]
        public async Task<JsonResult> Add([FromBody] GPT_CDK model, int COUNT)
        {
            List<GPT_CDK> listmodel = new List<GPT_CDK>();
            for (int c = 0; c < COUNT; c++)
            {
                model.CDK = AES.Chars();
                GPT_CDK thismodel = new GPT_CDK();
                thismodel.State = model.State;
                thismodel.Duration = model.Duration;
                thismodel.Free_Second = model.Free_Second;
                thismodel.Type = model.Type;
                thismodel.CDK = model.CDK;
                listmodel.Add(thismodel);
            }

            Mapper_GPT_CDK app = new Mapper_GPT_CDK();
            int i = await app.AddAsync(listmodel);
            return Json(new Result()
            {
                CODE = i > 0 ? ResultCode.Success : ResultCode.Empty,
                DATA = i
            });
        }
        [HttpDelete]
        public async Task<JsonResult> Delete(int ID)
        {
            Mapper_GPT_CDK app = new Mapper_GPT_CDK();
            bool isok = await app.DeleteAsync(ID);
            return Json(new Result()
            {
                CODE = isok ? ResultCode.Success : ResultCode.Empty
            });
        }
    }
}
