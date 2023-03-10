using System.Collections.Generic;

namespace ChatGPT_Model.AppModel
{
    public class Authorization_code
    {
        public string openid { get; set; }//openid 微信、知校（支付宝） 开放平台ID
        public string nickname { get; set; }//昵称 微信、知校（支付宝）
        public string sex { get; set; }//性别
        public string language { get; set; }//语言 微信
        public string city { get; set; }//城市 微信
        public string province { get; set; }//省份 微信
        public string country { get; set; }//国家 微信
        public string headimgurl { get; set; }//头像 微信、知校（支付宝）
        public List<string> privilege { get; set; }//权限 微信

        public string school_id { get; set; }//知校 学校ID
        public string school_name { get; set; }//知校 学校名称
        public string user_no { get; set; }//知校 学号、工号
        public string user_name { get; set; }//知校 姓名
        public string user_id { get; set; }//知校 用户ID
        public string user_identity { get; set; }//知校 用户身份
        public string id_card { get; set; }//知校 身份证号码
        public string phone { get; set; }//知校 手机号码
    }
}
