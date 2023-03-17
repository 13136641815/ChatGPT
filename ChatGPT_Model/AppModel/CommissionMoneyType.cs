using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatGPT_Model.AppModel
{
    public class CommissionMoneyType
    {
        /// <summary>
        /// 可提现
        /// </summary>
        public decimal? JeA { get; set; }
        /// <summary>
        /// 申请中
        /// </summary>
        public decimal? JeB { get; set; }
        /// <summary>
        /// 未提现
        /// </summary>
        public decimal? JeC { get; set; }
    }
}
