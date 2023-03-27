using ChatGPT_Mapper;
using ChatGPT_Model;
using ChatGPT_Model.AppModel;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatGPT_Service.Home
{
    public class Mapper_HomeController
    {
        /// <summary>
        /// 校验用户（含创建）
        /// </summary>
        /// <param name="UserInfo"></param>
        /// <returns></returns>
        public async Task<bool> CheckedInfo(Authorization_code UserInfo)
        {
            //查看用户表中是否存在该用户，不存在则插入
            Mapper_GPT_User app = new Mapper_GPT_User();
            var FirstModel = await app.GetModelFirst(UserInfo.openid);
            if (FirstModel != null)
            {
                return true;
            }
            else
            {
                TencentQrCode Qrapp = new TencentQrCode();
                string pushopenid = await Qrapp.GetQr_scene_str(UserInfo.openid);
                Mapper_GPT_Setup setApp = new Mapper_GPT_Setup();
                var setmodel = await setApp.GetFirstAsync();
                var model = new GPT_User()
                {
                    Stamp = DateTime.Now,
                    NikeName = UserInfo.nickname,
                    WxOpenID = UserInfo.openid,
                    WxHeadUrl = UserInfo.headimgurl,
                    YN_VIP = 0,
                    YN_PVIP=0,
                    Type_VIP = -1,
                    BeOverdue_VIP = DateTime.Parse("2000/01/01"),
                    BeOverdue_PVIP = DateTime.Parse("2000/01/01"),
                    Free_Second = setmodel.Free_Second,
                    PushOpenID = pushopenid == UserInfo.openid ? "0" : pushopenid
                };
                var i = app.UserAdd(model);
                if (i > 0)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
