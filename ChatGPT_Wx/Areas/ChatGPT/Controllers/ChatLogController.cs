using ChatGPT_Mapper;
using ChatGPT_Model;
using ChatGPT_Model.AppModel;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace ChatGPT_Wx.Areas.ChatGPT.Controllers
{
    [Area("ChatGPT")]
    public class ChatLogController : Controller
    {
        private IWebHostEnvironment _env;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public ChatLogController(IHttpContextAccessor httpContextAccessor, IWebHostEnvironment env)
        {
            _httpContextAccessor = httpContextAccessor;
            _env = env;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public async Task<JsonResult> GetListPage(PageParams Page, GPT_ChatLog model, DateTimeParams Time)
        {
            _httpContextAccessor.HttpContext.Request.Cookies.TryGetValue("H5COOKIES", out string value);
            var CookiesModel = JsonConvert.DeserializeObject<H5Cookie>(Tools.AES.staticKeyTo_DecryptAES(value));//获取COOKIE身份
            model.Openid = CookiesModel.UserInfo.openid;
            Mapper_GPT_ChatLog app = new Mapper_GPT_ChatLog();
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
        [HttpPost]
        public async Task<JsonResult> Add([FromBody] GPT_ChatLog model)
        {
            _httpContextAccessor.HttpContext.Request.Cookies.TryGetValue("H5COOKIES", out string value);
            var CookiesModel = JsonConvert.DeserializeObject<H5Cookie>(Tools.AES.staticKeyTo_DecryptAES(value));//获取COOKIE身份
            model.Openid = CookiesModel.UserInfo.openid;
            Mapper_GPT_ChatLog app = new Mapper_GPT_ChatLog();
            int i = await app.AddAsync(model);
            return Json(new Result()
            {
                CODE = i > 0 ? ResultCode.Success : ResultCode.Empty
            });
        }
        [HttpGet]
        public async Task<JsonResult> GetQList()
        {
            Mapper_GPT_ChatLog app = new Mapper_GPT_ChatLog();
            return Json(new Result()
            {
                DATA = await app.GetQList()
            });
        }
        [HttpPost]
        public async Task<JsonResult> AddDraw([FromBody] GPT_ChatLog model)
        {
            List<ImgList> ImgList = JsonConvert.DeserializeObject<List<ImgList>>(model.AIMessage);
            //文件存入本地
            string filePath = _env.WebRootPath + "\\ChatGPT\\UploadImages\\";
            if (!Directory.Exists(filePath))//判断文件夹是否存在 
            {
                Directory.CreateDirectory(filePath);//不存在则创建文件夹 
            }
            List<ImgList> DataImgList = new List<ImgList>();
            foreach (var item in ImgList)
            {
                FormFile file = DownloadImage(item.url);
                string Name = DateTime.Now.ToString("yyyyMMddHHmmssfff") + Guid.NewGuid().ToString();
                string fullName = Name;
                fullName = filePath + fullName + ".jpeg";
                using (FileStream stream = new FileStream(fullName, FileMode.Create, FileAccess.Write))
                {
                    file.CopyTo(stream);
                    stream.Flush();
                }
                DataImgList.Add(new ImgList
                {
                    url = "/ChatGPT/UploadImages/" + Name + ".jpeg"
                });
            }
            model.AIMessage = JsonConvert.SerializeObject(DataImgList);
            _httpContextAccessor.HttpContext.Request.Cookies.TryGetValue("H5COOKIES", out string value);
            var CookiesModel = JsonConvert.DeserializeObject<H5Cookie>(Tools.AES.staticKeyTo_DecryptAES(value));//获取COOKIE身份
            model.Openid = CookiesModel.UserInfo.openid;
            Mapper_GPT_ChatLog app = new Mapper_GPT_ChatLog();
            int n = await app.AddAsync(model);
            if (n > 0)
            {
                //扣减绘画次数
                ChatGPT_Service.AIDraw.App AI = new ChatGPT_Service.AIDraw.App();
                Mapper_GPT_User UserApp = new Mapper_GPT_User();
                var UserModel = await UserApp.GetModelFirst(model.Openid);
                int i = -1;
                if (UserModel.YN_VIP == 1 && DateTime.Now < UserModel.BeOverdue_VIP)
                {
                    //是超级会员且未过期，查看免费次数
                    i = (await AI.GetThisMonthsCount(model.Openid));
                }
                if (i < 0)
                {
                    //体验次数没有了，扣减付费次数

                    UserModel.AIDraw_Second--;
                    bool isok = await UserApp.UpdateAIDraw_SecondAsync(UserModel);
                }
            }
            return Json(new Result()
            {
                CODE = n > 0 ? ResultCode.Success : ResultCode.Empty
            });
        }
        FormFile DownloadImage(string url)
        {
            byte[] imageData = null;
            using (WebClient client = new WebClient())
            {
                imageData = client.DownloadData(url);
            }

            MemoryStream stream = new MemoryStream(imageData);
            return new FormFile(stream, 0, imageData.Length, "image", "image.jpeg");
        }
        class ImgList
        {
            public string url { get; set; }
        }
    }
}
