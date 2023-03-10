using ChatGPT_Model.AppModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace ChatGPT_Service.ChatGPT
{
    public class ChatPost
    {
        string url = "https://api.openai.com/v1/completions";
        public string Post()
        {
            body Body = new body();
            string APIKEY = "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";
            //byte[] data = System.Text.Encoding.UTF8.GetBytes(Xml);
            //var byteContent = new ByteArrayContent(data);


            HttpClient httpClient = new HttpClient();
            HttpContent httpContent = JsonContent.Create<body>(Body);
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + APIKEY);
            string PostRes = httpClient.PostAsync(url, httpContent).Result.Content.ReadAsStringAsync().Result;//异步调用post请求
            return PostRes;
        }
    }
}
