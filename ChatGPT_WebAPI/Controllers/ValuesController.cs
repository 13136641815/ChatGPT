using ChatGPT_Model.AppModel;
using ChatGPT_Model.GPT3_5;
using ChatGPT_WebAPI.ChatHub;
using Chinese;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace ChatGPT_WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        [HttpPost]
        public async Task<Result> Values([FromForm] IFormFileCollection formFiles)
        {
            try
            {
                string APIKEY = await ApiKeyCacheTime.GetApiKeyTime();//缓存中获取APIKEY
                if (string.IsNullOrEmpty(APIKEY))
                {
                    return new Result()
                    {
                        CODE = ResultCode.Empty,
                        MSG = "当前人数较多，请稍后再试。"
                    };
                }
                var client = new HttpClient();
                byte[] buffer = new byte[formFiles.FirstOrDefault().Length];
                Stream fs = formFiles.FirstOrDefault().OpenReadStream();
                fs.Read(buffer, 0, buffer.Length);
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + APIKEY);
                var multiFormData = new MultipartFormDataContent();
                multiFormData.Add(new ByteArrayContent(buffer), "file", formFiles.FirstOrDefault().FileName);
                //multiFormData.Add(new StreamContent(fs, (int)fs.Length), "file", formFiles.FirstOrDefault().FileName);
                multiFormData.Add(new StringContent("whisper-1"), "model");
                multiFormData.Add(new StringContent("ZH"), "language");
                string response = client.PostAsync("https://api.openai.com/v1/audio/transcriptions", multiFormData).Result.Content.ReadAsStringAsync().Result;
                var STR = JsonConvert.DeserializeObject<STR>(response);
                fs.Close();
                if (!string.IsNullOrEmpty(STR.text))
                {
                    var msg = ChineseConverter.ToSimplified(STR.text);
                    return new Result()
                    {
                        DATA = msg
                    };
                }
                return new Result()
                {
                    CODE = ResultCode.Empty,
                    DATA = "OpenAI：" + STR.error.message
                };
            }
            catch (Exception ex)
            {
                return new Result()
                {
                    CODE = ResultCode.Empty,
                    DATA = "异常：" + ex.ToString()
                };
            }

        }
    }
    class STR
    {
        public string text { get; set; }
        public Error error { get; set; }
    }
}
