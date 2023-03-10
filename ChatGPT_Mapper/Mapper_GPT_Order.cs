using ChatGPT_Model;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatGPT_Mapper
{
    public class Mapper_GPT_Order
    {
        /// <summary>
        /// 下单
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<int> AddAsync(GPT_Order model, SqlSugarScope db)
        {
            return await db.Insertable(model).ExecuteReturnIdentityAsync();
        }
        /// <summary>
        /// 查找订单
        /// </summary>
        /// <param name="OrderNo"></param>
        /// <returns></returns>
        public async Task<GPT_Order> GetModelFirstAsync(string OrderNo)
        {
            return await SugarConfig.CretClient().Queryable<GPT_Order>().Where(it => it.OrderNumber == OrderNo).FirstAsync();
        }
        public async Task<bool> UpdateStateToSussAsync(GPT_Order model, SqlSugarScope db)
        {
            model.State = 1;
            model.BackStamp = DateTime.Now;
            return await db.Updateable(model).UpdateColumns(it => new
            {
                it.State,
                it.BackStamp,
            }).Where(it => it.OrderNumber == model.OrderNumber).ExecuteCommandHasChangeAsync();
        }
    }
}
