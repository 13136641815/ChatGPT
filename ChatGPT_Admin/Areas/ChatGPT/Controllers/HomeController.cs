using ChatGPT_Model.AppModel;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ChatGPT_Admin.Areas.ChatGPT.Controllers
{
    [Area("ChatGPT")]
    public class HomeController : Controller
    {
        public IActionResult List()
        {
            return View();
        }
        [HttpGet]
        public async Task<JsonResult> UpdateTable()
        {
            return Json(new Result() { });
        }
    }
}
