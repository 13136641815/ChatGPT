using ChatGPT_Model;
using ChatGPT_Model.AppModel;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatGPT_Mapper
{
    public class Mapper_GPT_ChatLog
    {
        /// <summary>
        /// 查询分页
        /// </summary>
        /// <returns></returns>
        public async Task<List<GPT_ChatLog>> GetListPageAsync(PageParams Page, GPT_ChatLog model, DateTimeParams Time, RefAsync<int> DataCount)
        {
            var exp = Expressionable.Create<GPT_ChatLog>();
            exp.OrIF(!string.IsNullOrEmpty(model.UserMessage), it => it.UserMessage.Contains(model.UserMessage));
            exp.OrIF(!string.IsNullOrEmpty(model.UserMessage), it => it.AIMessage.Contains(model.UserMessage));
            return await SugarConfig.CretClient().Queryable<GPT_ChatLog>()
                .Where(exp.ToExpression())
                .Where(it => it.Openid == model.Openid)
                .OrderBy(it => it.Time, OrderByType.Desc)
                .ToPageListAsync(Page.PageNum, Page.PageSize, DataCount);
        }
        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<int> AddAsync(GPT_ChatLog model)
        {
            return await SugarConfig.CretClient().Insertable(model).ExecuteReturnIdentityAsync();
        }
    }
}
