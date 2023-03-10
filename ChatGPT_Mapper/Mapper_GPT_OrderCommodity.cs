using ChatGPT_Model;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatGPT_Mapper
{
    public class Mapper_GPT_OrderCommodity
    {

        /// <summary>
        /// 下单
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<int> AddAsync(GPT_OrderCommodity model, SqlSugarScope db)
        {
            return await db.Insertable(model).ExecuteReturnIdentityAsync();
        }
        /// <summary>
        /// 获取订单下的一个商品
        /// </summary>
        /// <param name="OrderNo"></param>
        /// <returns></returns>
        public async Task<GPT_OrderCommodity> GetFirstAsync(string OrderNo) 
        {
            return await SugarConfig.CretClient().Queryable<GPT_OrderCommodity>().Where(it => it.OrderNumber == OrderNo).FirstAsync();
        }
    }
}
