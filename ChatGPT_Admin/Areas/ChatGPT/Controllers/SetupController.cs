using ChatGPT_Mapper;
using ChatGPT_Model;
using ChatGPT_Model.AppModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Reflection;
using System.Threading.Tasks;

namespace ChatGPT_Admin.Areas.ChatGPT.Controllers
{
    [Area("ChatGPT")]
    public class SetupController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public async Task<JsonResult> GetFirst() 
        {
            Mapper_GPT_Setup app = new Mapper_GPT_Setup();
            return Json(new Result()
            {
                DATA = await app.GetFirstAsync()
            });
        }
        [HttpPut]
        public async Task<JsonResult> Update([FromBody]GPT_Setup model) 
        {
            Mapper_GPT_Setup app = new Mapper_GPT_Setup();
            bool isok = await app.UpdateAsync(model);
            return Json(new Result()
            {
                CODE = isok ? ResultCode.Success : ResultCode.Empty
            });
        }
    }
}
