using ChatGPT_Model.AppModel;
using ChatGPT_WebAPI.ChatHub;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using System.Threading.Tasks;

namespace ChatGPT_WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ApiKeyCacheController : ControllerBase
    {
        [HttpGet]
        public async Task<Result> Get()
        {
            await ApiKeyCacheTime.UpdateApiKey();
            return new Result()
            {
                DATA = true,
            };
        }
        [HttpPost]
        public Result GetCacheList()
        {
            //存在缓存
            var obj = MemoryCacheUtility.Get("APIKEY");
            var list = ApiKeyCacheTime.ConvertToDesiredType(obj);
            return new Result()
            {
                DATA = list,
            };
        }
    }
}
