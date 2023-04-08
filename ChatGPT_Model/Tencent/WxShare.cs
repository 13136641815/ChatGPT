using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatGPT_Model.Tencent
{
    public class WxShare
    {
        public string appId { get; set; }//APPID
        public string timeStamp { get; set; }//时间辍
        public string nonceStr { get; set; }//随机数
        public string QM { get; set; }//签名
        public string nTitle { get; set; }//标题
        public string Desc { get; set; }//描述
        public string Link { get; set; }//链接
        public string ImgUrl { get; set; }//图片
    }
}
