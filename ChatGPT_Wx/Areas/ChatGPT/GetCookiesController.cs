using ChatGPT_Model;
using ChatGPT_Model.AppModel;
using ChatGPT_Service.AI;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace ChatGPT_Wx.Areas.ChatGPT
{
    public class GetCookiesController
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        public GetCookiesController(IHttpContextAccessor httpContextAccessor) 
        {
            _httpContextAccessor = httpContextAccessor;
        }
        public async Task<GPT_User> GetInfoModelFromCookies()
        {
            _httpContextAccessor.HttpContext.Request.Cookies.TryGetValue("H5COOKIES", out string value);
            var CookiesModel = JsonConvert.DeserializeObject<H5Cookie>(Tools.AES.staticKeyTo_DecryptAES(value));//获取COOKIE身份

            Mapper_AIController app = new Mapper_AIController();
            var model = await app.GetModelFirstAsync(CookiesModel.UserInfo.openid);
            return model;
        }
    }
}
