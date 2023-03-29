using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChatGPT_Wx.Areas.ChatGPT.Controllers
{
    [Area("ChatGPT")]
    public class ChatLogController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
