using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatGPT_Model.AppModel
{
    public class PayConfigParameter
    {
        #region 有默认值 或 跟不跟业务关联可独立填充的项

        public string body { get; set; } = ".netCore微信支付";//商品简单描述
        public string attach { get; set; } = "";//附加数据，在查询API和支付通知中原样返回，可作为自定义参数使用。

        public string time_start { get; } = DateTime.Now.ToString("yyyyMMddHHmmss");
        public string time_expire { get; } = DateTime.Now.AddMinutes(10).ToString("yyyyMMddHHmmss");
        public string goods_tag { get; } = "";//默认空，订单优惠标记，使用代金券或立减优惠功能时需要的参数，说明详见
        public string trade_type { get; } = "JSAPI";
        /// <summary>
        /// 微信支付回调路径
        /// </summary>
        public string notify_url { get; set; } = AppSettingsHelper.Configuration.GetSection("WeChatSetup").GetSection("CallbackUrl").Value;//回调地址，默认走配置文件，其他支付途径可覆盖配置
        /// <summary>
        /// appid
        /// </summary>
        public string appid { get; } = AppSettingsHelper.Configuration.GetSection("WeChatSetup").GetSection("AppID").Value;
        /// <summary>
        /// 商户号
        /// </summary>
        public string mch_id { get; } = AppSettingsHelper.Configuration.GetSection("WeChatSetup").GetSection("MerchantID").Value;
        /// <summary>
        /// 主机地址，默认 8.8.8.8
        /// </summary>
        public string spbill_create_ip { get; set; } = "8.8.8.8";
        /// <summary>
        /// 随机数
        /// </summary>
        public string nonce_str { get; } = Guid.NewGuid().ToString().Replace("-", "");
        #endregion
    }
}
