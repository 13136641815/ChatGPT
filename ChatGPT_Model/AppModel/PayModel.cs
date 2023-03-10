using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatGPT_Model.AppModel
{
    public class PayModel
    {
        #region 操作业务时必填项
        /// <summary>
        /// 当前支付者openid
        /// </summary>
        public string openid { get; set; }
        /// <summary>
        /// 订单号
        /// </summary>
        public string out_trade_no { get; set; }
        /// <summary>
        /// 订单金额
        /// </summary>
        public string total_fee { get; set; }
        #endregion
    }
}
