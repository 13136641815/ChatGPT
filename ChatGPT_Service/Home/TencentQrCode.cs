﻿using ChatGPT_Model.AppModel;
using ChatGPT_Model.Tencent;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace ChatGPT_Service.Home
{
    public class TencentQrCode
    {
        string APPID = AppSettingsHelper.Configuration["WeChatSetup:AppID"].ToString();
        string APPSECRET = AppSettingsHelper.Configuration["WeChatSetup:AppSecret"].ToString();
        private async Task<string> GetAccess_token()
        {
            HttpClient httpClient = new HttpClient();
            string access_tokenUrl = "https://api.weixin.qq.com/cgi-bin/token?grant_type=client_credential&appid=" + APPID + "&secret=" + APPSECRET;
            var access_tokenRes = httpClient.GetAsync(access_tokenUrl).Result.Content.ReadAsStringAsync().Result;
            var Modelaccess_token = JsonConvert.DeserializeObject<Access_token>(access_tokenRes);
            if (Modelaccess_token.access_token != null && Modelaccess_token.access_token != "")
            {
                return Modelaccess_token.access_token;
            }
            return "";
        }
        public async Task<string> UrlToImage(string url)
        {
            using var client = new HttpClient();
            var response = await client.GetAsync(url);
            var bytes = await response.Content.ReadAsByteArrayAsync();
            var base64 = Convert.ToBase64String(bytes);
            return base64;
        }
        /// <summary>
        /// 根据Opneid获取本人的推广二维码
        /// </summary>
        /// <param name="Openid">本人的openid</param>
        /// <returns></returns>
        public async Task<string> GetQRCodeTicket(string Openid)
        {
            string access_token = await GetAccess_token();
            if (!string.IsNullOrEmpty(access_token))
            {
                var url = "https://api.weixin.qq.com/cgi-bin/qrcode/create?access_token=" + access_token;
                HttpClient httpClient = new HttpClient();
                QRCodeCreate model = new QRCodeCreate();
                model.action_info = new action_info() { scene = new scene() { scene_str = Openid } };
                string str = JsonConvert.SerializeObject(model);
                HttpContent httpContent = new StringContent("{\"action_name\":\"QR_LIMIT_STR_SCENE\",\"action_info\":{\"scene\":{\"scene_str\":\"" + Openid + "\"}}}");
                //HttpContent httpContent = JsonContent.Create<QRCodeCreate>(model);
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var ResStr = httpClient.PostAsync(url, httpContent).Result.Content.ReadAsStringAsync().Result;
                var ResTicketModel = JsonConvert.DeserializeObject<ResTicket>(ResStr);
                if (!string.IsNullOrEmpty(ResTicketModel.ticket))
                {
                    return ResTicketModel.ticket;
                }
            }
            return "";
        }
        public async Task<string> GetTicket()
        {
            string access_token = await GetAccess_token();
            if (!string.IsNullOrEmpty(access_token))
            {
                var url = "https://api.weixin.qq.com/cgi-bin/ticket/getticket?access_token=" + access_token + "&type=jsapi";
                HttpClient httpClient = new HttpClient();
                QRCodeCreate model = new QRCodeCreate();
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var ResStr = httpClient.GetAsync(url).Result.Content.ReadAsStringAsync().Result;
                var ResTicketModel = JsonConvert.DeserializeObject<ResTicket>(ResStr);
                if (!string.IsNullOrEmpty(ResTicketModel.ticket))
                {
                    return ResTicketModel.ticket;
                }
            }
            return "";
        }
        /// <summary>
        /// 首次进入系统，通过本人的openid看看是否是被别人邀请进入的
        /// </summary>
        /// <param name="ThisOpenid"></param>
        /// <returns>邀请人的openid</returns>
        public async Task<string> GetQr_scene_str(string ThisOpenid)
        {
            string access_token = await GetAccess_token();
            string url = "https://api.weixin.qq.com/cgi-bin/user/info?access_token=" + access_token + "&openid=" + ThisOpenid + "&lang=zh_CN";
            HttpClient httpClient = new HttpClient();
            var ResStr = httpClient.GetAsync(url).Result.Content.ReadAsStringAsync().Result;
            var ResModel = JsonConvert.DeserializeObject<FollowInfo>(ResStr);
            if (!string.IsNullOrEmpty(ResModel.qr_scene_str))
            {
                return ResModel.qr_scene_str;
            }
            else
            {
                return "0";
            }
        }

        /// <summary>
        /// Sha1签名
        /// </summary>
        /// <param name="str">内容</param>
        /// <param name="encoding">编码</param>
        /// <returns></returns>
        public static string Sha1Signature(string str, Encoding encoding = null)
        {
            if (encoding == null) encoding = Encoding.UTF8;
            var buffer = encoding.GetBytes(str);
            var data = SHA1.Create().ComputeHash(buffer);
            StringBuilder sub = new StringBuilder();
            foreach (var t in data)
            {
                sub.Append(t.ToString("x2"));
            }
            return sub.ToString();
        }
    }
}
