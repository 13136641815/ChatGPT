using ChatGPT_Model.GPT3_5;
using ChatGPT_Service.ChatGPT;
using Microsoft.AspNetCore.SignalR;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using SYSTEM_Extend.log4net;
using WeChat.Com.Log4net;

namespace ChatGPT_WebAPI.ChatHub
{
    public class ChatHubGPT3_5 : Hub
    {
        public async Task SendMessage(int botID, string message, int VIPTYPE)
        {
            Dictionary<string, string> DiLog = new Dictionary<string, string>();
            try
            {
                ChatGPT_Mapper.Mapper_GPT_BobotList botapp = new ChatGPT_Mapper.Mapper_GPT_BobotList(); //查询情景机器人
                var botModel = await botapp.GetFirstAsync(botID);
                string APIKEY = await ApiKeyCacheTime.GetApiKeyTime();//缓存中获取APIKEY
                if (string.IsNullOrEmpty(APIKEY))
                {
                    await Clients.Caller.SendAsync("ErrMessage", "", "当前人数较多，请稍后再试。");//异常回复
                    return;
                }
                var messages = JsonConvert.DeserializeObject<List<ChatGPT_Model.GPT3_5.Messages>>(message);
                int botCount = 0;//情景模式的字符串长度
                if (botModel != null)
                {
                    botCount = botModel.Ccene.Length;
                }
                #region 计算tokens算法
                int TokenCount = botCount;
                int overstepIndex = -1;
                for (int i = 1; i < messages.Count; i++)
                {
                    int Index = messages.Count - i;//倒叙索引
                    TokenCount += messages[Index].content.Length;
                    if (TokenCount > 1024)
                    {
                        overstepIndex = Index;
                        break;
                    }
                }
                for (int i = 0; i < overstepIndex + 1; i++)
                {
                    messages.RemoveAt(0);
                }
                ChatGPT_Model.GPT3_5.Body Body = null;
                if (botModel != null)
                {
                    Body = botModel.APIJson;
                    messages.Insert(0, new Messages()
                    {
                        role = "system",
                        content = botModel.Ccene
                    });//附加情景模式
                }
                else
                {
                    Body = new Body();
                }
                Body.messages = messages;
                #endregion
                if (VIPTYPE == 0)
                {
                    //普通会员限制最大字数为200字 200*4=800 tokens
                    Body.max_tokens = 800;
                }
                await SendHttpPost(DiLog, APIKEY, Body, messages);
            }
            catch (Exception ex)
            {
                DiLog.Add("5.", DateTime.Now.ToString() + "|报错了：" + ex.ToString());
                await Clients.Caller.SendAsync("ErrMessage", "", "哟报错了，叫程序员，错误提示：" + ex.ToString());//异常回复
            }
        }
        public async Task SendAppMessage(int ID, string message)
        {
            Dictionary<string, string> DiLog = new Dictionary<string, string>();
            try
            {
                string APIKEY = await ApiKeyCacheTime.GetApiKeyTime();//缓存中获取APIKEY
                ChatGPT_Mapper.Mapper_GPT_ChatApp app = new ChatGPT_Mapper.Mapper_GPT_ChatApp();
                var AiApp = await app.GetFirstAsync(ID);
                ChatGPT_Model.GPT3_5.Body Body = new Body();
                List<Messages> messages = new List<Messages>();
                messages.Add(new Messages()
                {
                    role = "system",
                    content = AiApp.Guide
                });
                messages.Add(new Messages()
                {
                    role = "user",
                    content = message
                });
                Body.messages = messages;
                await SendHttpPost(DiLog, APIKEY, Body, messages);
            }
            catch (Exception ex)
            {
                DiLog.Add("5.", DateTime.Now.ToString() + "|报错了：" + ex.ToString());
                await Clients.Caller.SendAsync("ErrMessage", "", "哟报错了，叫程序员，错误提示：" + ex.ToString());//异常回复
            }

        }
        async Task SendHttpPost(Dictionary<string, string> DiLog, string APIKEY, Body Body, List<Messages> messages)
        {
            //请求开始
            var client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Add("Authorization", "Bearer " + APIKEY);
            HttpContent httpContent = JsonContent.Create<ChatGPT_Model.GPT3_5.Body>(Body);
            DiLog.Add("1.", DateTime.Now.ToString() + "|APIKEY:" + APIKEY);
            DiLog.Add("2.", DateTime.Now.ToString() + "|消息发送:" + messages[messages.Count - 1].content);
            var response = await client.PostAsync("https://api.openai.com/v1/chat/completions", httpContent);
            // 读取响应内容
            using (var stream = await response.Content.ReadAsStreamAsync())
            {
                using (var reader = new StreamReader(stream, Encoding.UTF8))
                {
                    string Error = "";
                    string Text = "";
                    // 逐行读取文本内容
                    while (!reader.EndOfStream)
                    {
                        Thread.Sleep(15);
                        string line = await reader.ReadLineAsync();
                        // 在这里对每一行文本进行处理
                        if (line.Contains("[DONE]"))
                        {
                            //回复流结束
                            DiLog.Add("4.", DateTime.Now.ToString() + "|消息接收完结,回复完整内容：" + Text);
                            await Clients.Caller.SendAsync("EndMessage", "", line);//回复
                            await Log(DiLog);
                            return;
                        }
                        if (line.Contains("assistant"))
                        {
                            //首次接收消息
                            DiLog.Add("3.", DateTime.Now.ToString() + "|首次接收到回应消息");
                        }
                        if (line.Contains("data:"))
                        {
                            line = line.Replace("data:", "");
                            var ItemResponse = JsonConvert.DeserializeObject<ChatGPT_Model.GPT3_5.StreamRespose>(line);
                            if (ItemResponse.choices[0].delta.content != null && ItemResponse.choices[0].delta.content != "")
                            {
                                string ReturnHtmlStr = ItemResponse.choices[0].delta.content;
                                Text += ReturnHtmlStr;
                                await Clients.Caller.SendAsync("ReceiveMessage", "", ReturnHtmlStr);//回复
                            }
                        }
                        else
                        {
                            Error += line;
                        }
                    }
                    if (Error.Contains("error"))
                    {
                        var ErrModel = JsonConvert.DeserializeObject<ChatGPT_Model.GPT3_5.ErrorBody>(Error.Trim(' '));
                        if (ErrModel.error.type == "access_terminated" || ErrModel.error.type == "insufficient_quota")
                        {
                            await ApiKeyCacheTime.RemvoCache(APIKEY);
                        }
                        DiLog.Add("5.", DateTime.Now.ToString() + "|接收异常:[代码:" + ErrModel.error.type + "][内容:" + ErrModel.error.message + "]");
                        await Clients.Caller.SendAsync("ErrMessage", "", ErrModel.error.message);//异常回复
                        await Log(DiLog);
                    }
                }
            }
        }
        async Task Log(Dictionary<string, string> di)
        {
            SYSTEM_Models.sys_Log4net modelLog4 = new SYSTEM_Models.sys_Log4net()
            {
                userlogin = "对话记录",
                userName = "对话记录",
                LogTime = DateTime.Now,
                SystemName = "ChatGPT",
                SystemCode = "ChatGPT",
                Path = "Fuction:" + this.GetType().ToString(),
                Method = "LOG",
                LogBody = JsonConvert.SerializeObject(di),
                ResponseParams = "",
                LogLevelCode = LogType.WARN.Code,
                LogLevelName = LogType.WARN.Name,
                Error = "",
                ip_Address = "",
                CookiesAll = ""
            };
            //插入数据库日志
            Log4netHelper.WirteLog4net(modelLog4, LogType.INFO.Code);
            ChatGPT_Mapper.Mapper_sys_Log4net LOG = new ChatGPT_Mapper.Mapper_sys_Log4net();
            await LOG.Insert(modelLog4);
        }
    }
}
