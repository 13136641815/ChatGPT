using ChatGPT_Mapper;
using ChatGPT_Model;
using ChatGPT_Model.AppModel;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace ChatGPT_Admin.Areas.ChatGPT.Controllers
{
    [Area("ChatGPT")]
    public class BotController : Controller
    {
        private IWebHostEnvironment _env;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public BotController(IWebHostEnvironment env, IHttpContextAccessor httpContextAccessor)
        {
            _env = env;
            _httpContextAccessor = httpContextAccessor;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public async Task<JsonResult> GetListPage(PageParams Page, GPT_BobotList model)
        {
            Mapper_GPT_BobotList app = new Mapper_GPT_BobotList();
            RefAsync<int> DataCount = 0;
            var list = await app.GetListPageAsync(Page, model, DataCount);
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
        public async Task<JsonResult> Add([FromBody] GPT_BobotList model)
        {
            Mapper_GPT_BobotList app = new Mapper_GPT_BobotList();
            int i = await app.AddAsync(model);
            model.ID = i;
            return Json(new Result()
            {
                CODE = i > 0 ? ResultCode.Success : ResultCode.Empty,
                DATA = model
            });
        }
        [HttpPut]
        public async Task<JsonResult> Update([FromBody] GPT_BobotList model)
        {
            Mapper_GPT_BobotList app = new Mapper_GPT_BobotList();
            bool isok = await app.UpdateAsync(model);
            return Json(new Result()
            {
                CODE = isok ? ResultCode.Success : ResultCode.Empty
            });
        }
        [HttpDelete]
        public async Task<JsonResult> Delete(int ID)
        {
            Mapper_GPT_BobotList app = new Mapper_GPT_BobotList();
            bool isok = await app.DeleteAsync(ID);
            return Json(new Result()
            {
                CODE = isok ? ResultCode.Success : ResultCode.Empty
            });
        }
        [HttpPost]
        public JsonResult UploedImg(List<IFormFile> upfile)
        {
            string IMGURL = "";
            //图片保存路径
            string filePath = _env.WebRootPath + "\\ChatGPT\\UploadImages\\";
            if (!Directory.Exists(filePath))//判断文件夹是否存在 
            {
                Directory.CreateDirectory(filePath);//不存在则创建文件夹 
            }
            string fullName = string.Empty;

            //Request.Form.Files获取客户端POST过来的所有文件
            IFormFileCollection files = Request.Form.Files;
            foreach (FormFile file in files) //遍历处理每一个文件
            {
                //Path.GetExtension()获取文件扩展名
                string exten = Path.GetExtension(file.FileName).ToLower();

                //扩展名不符合要求就不处理
                if (exten != ".jpg" && exten != ".png") continue;

                //Guid.NewGuid().ToString()生成一个GUID风格的文件名避免重名
                string fileName = Guid.NewGuid().ToString();

                fullName = filePath + fileName + exten;

                //用using语句释放文件资源
                using (FileStream stream = new FileStream(fullName, FileMode.Create, FileAccess.Write))
                {
                    file.CopyTo(stream);
                    stream.Flush();
                }
                IMGURL = Request.Scheme+"://" + Request.Host.Value + "/ChatGPT/UploadImages/" + fileName + exten;
            }
            return Json(new Result()
            {
                DATA = IMGURL
            });
        }
    }
}
