using Microsoft.AspNetCore.Mvc;

namespace ChatGPT_Admin.Areas.ChatGPT.Controllers
{
    [Area("ChatGPT")]
    public class HomeController : Controller
    {
        public IActionResult List()
        {
            return View();
        }
    }
}
