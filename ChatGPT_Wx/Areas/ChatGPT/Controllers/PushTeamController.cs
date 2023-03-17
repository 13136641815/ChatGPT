using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChatGPT_Wx.Areas.ChatGPT.Controllers
{
    [Area("ChatGPT")]
    public class PushTeamController : Controller
    {
        public IActionResult TeamList()
        {
            return View();
        }
    }
}
