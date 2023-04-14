using ChatGPT_Mapper;
using ChatGPT_Model.AppModel;
using ChatGPT_Service.Home;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChatGPT_Wx.Areas.ChatGPT.Controllers
{
    [Area("ChatGPT")]
    public class QRController : Controller
    {
        public IActionResult QRCode()
        {
            return View();
        }

    }
}
