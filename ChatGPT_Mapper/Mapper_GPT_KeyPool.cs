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
    public class Mapper_GPT_KeyPool
    {
        /// <summary>
        /// 查询分页
        /// </summary>
        /// <returns></returns>
        public async Task<List<GPT_KeyPool>> GetListPageAsync(PageParams Page, GPT_KeyPool model, RefAsync<int> DataCount)
        {
            return await SugarConfig.CretClient().Queryable<GPT_KeyPool>()
                .WhereIF(model.ApiKey != null && model.ApiKey != "", it => it.ApiKey.Contains(model.ApiKey))
                .WhereIF(model.Enable != null, it => it.Enable == model.Enable)
                .WhereIF(model.State != null, it => it.State == model.State)
                .ToPageListAsync(Page.PageNum, Page.PageSize, DataCount);
        }
        /// <summary>
        /// 查询一条
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<GPT_KeyPool> GetFirst(int ID)
        {
            return await SugarConfig.CretClient().Queryable<GPT_KeyPool>().Where(it => it.ID == ID).FirstAsync();
        }
        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<int> AddAsync(GPT_KeyPool model)
        {
            return await SugarConfig.CretClient().Insertable(model).ExecuteReturnIdentityAsync();
        }
        /// <summary>
        /// 修改（按主键）
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<bool> UpdateAsync(GPT_KeyPool model)
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
            return await SugarConfig.CretClient().Deleteable<GPT_KeyPool>().Where(it => it.ID == ID).ExecuteCommandHasChangeAsync();
        }
        /// <summary>
        /// 获取当前所有有效的APIKEY
        /// </summary>
        /// <returns></returns>
        public async Task<List<GPT_KeyPool>> GetEnableListAsync()
        {
            return await SugarConfig.CretClient().Queryable<GPT_KeyPool>().Where(it => it.Enable == 1 && it.State == 1).ToListAsync();
        }
        /// <summary>
        /// 修改一条APIKEY为用尽
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<bool> UpdateToInvalid(GPT_KeyPool model)
        {
            model.State = -1;
            return await SugarConfig.CretClient().Updateable(model).UpdateColumns(it => new
            {
                it.State
            }).Where(it => it.ApiKey == model.ApiKey).ExecuteCommandHasChangeAsync();
        }
        public async Task<int> AddList(List<GPT_KeyPool> model)
        {
            return await SugarConfig.CretClient().Insertable(model).ExecuteCommandAsync();
        }
    }
}
