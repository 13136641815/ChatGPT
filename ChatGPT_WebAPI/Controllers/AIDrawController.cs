﻿using ChatGPT_Model.AppModel;
using ChatGPT_Model.GPTDraw;
using ChatGPT_WebAPI.ChatHub;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace ChatGPT_WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class AIDrawController : Controller
    {
        [HttpPost]
        public async Task<Result> DrawImg([FromBody] DrawModel Send)
        {
            string err = "";
            try
            {
                string APIKEY = await ApiKeyCacheTime.GetApiKeyTime();//缓存中获取APIKEY
                var client = new HttpClient();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + APIKEY);
                HttpContent httpContent = JsonContent.Create<DrawModel>(Send);
                string PostRes = client.PostAsync("https://api.openai.com/v1/images/generations", httpContent).Result.Content.ReadAsStringAsync().Result;
                err = "OpenAI反馈："+PostRes;
                var res = JsonConvert.DeserializeObject<DrawResModel>(PostRes);
                if (res.data.Count > 0)
                {
                    return new Result()
                    {
                        DATA = res.data
                    };
                }
            }
            catch (Exception ex)
            {
                err += "系统内异常：" + ex.ToString();
            }
            return new Result()
            {
                CODE = ResultCode.Empty,
                MSG = "图片未生成，可能OpenAI未识别，请换一种说法再试试：" + err
            };
        }
    }
}
