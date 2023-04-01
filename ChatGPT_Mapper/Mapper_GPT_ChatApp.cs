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
    public class Mapper_GPT_ChatApp
    {
        /// <summary>
        /// 查询分页
        /// </summary>
        /// <returns></returns>
        public async Task<List<GPT_ChatApp>> GetListPageAsync(PageParams Page, GPT_ChatApp model, RefAsync<int> DataCount)
        {
            return await SugarConfig.CretClient().Queryable<GPT_ChatApp>()
                .WhereIF(!string.IsNullOrEmpty(model.Type),it=>it.Type==model.Type)
                .WhereIF(!string.IsNullOrEmpty(model.Name), it => it.Name == model.Name)
                .ToPageListAsync(Page.PageNum, Page.PageSize, DataCount);
        }
        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<int> AddAsync(GPT_ChatApp model)
        {
            return await SugarConfig.CretClient().Insertable(model).ExecuteReturnIdentityAsync();
        }
        /// <summary>
        /// 修改（按主键）
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<bool> UpdateAsync(GPT_ChatApp model)
        {
            return await SugarConfig.CretClient().Updateable(model).IgnoreColumns(ignoreAllNullColumns: true).ExecuteCommandHasChangeAsync();
        }
        /// <summary>
        /// 删除（按主键ID）
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public async Task<bool> DeleteAsync(int ID)
        {
            return await SugarConfig.CretClient().Deleteable<GPT_ChatApp>().Where(it => it.ID == ID).ExecuteCommandHasChangeAsync();
        }
    }
}
