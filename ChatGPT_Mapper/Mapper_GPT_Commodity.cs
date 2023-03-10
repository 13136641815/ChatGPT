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
    public class Mapper_GPT_Commodity
    {
        /// <summary>
        /// 查询一条
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<GPT_Commodity> GetFirstAsync(int ID)
        {
            return await SugarConfig.CretClient().Queryable<GPT_Commodity>().Where(it => it.ID == ID).FirstAsync();
        }
        /// <summary>
        /// 查询分页
        /// </summary>
        /// <returns></returns>
        public async Task<List<GPT_Commodity>> GetListPageAsync(PageParams Page, GPT_Commodity model, RefAsync<int> DataCount)
        {
            return await SugarConfig.CretClient().Queryable<GPT_Commodity>()
                .WhereIF(model.CommodityName != null && model.CommodityName != "", it => it.CommodityName.Contains(model.CommodityName))
                .ToPageListAsync(Page.PageNum, Page.PageSize, DataCount);
        }
        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<int> AddAsync(GPT_Commodity model)
        {
            return await SugarConfig.CretClient().Insertable(model).ExecuteReturnIdentityAsync();
        }
        /// <summary>
        /// 修改（按主键）
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<bool> UpdateAsync(GPT_Commodity model)
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
            return await SugarConfig.CretClient().Deleteable<GPT_Commodity>().Where(it => it.ID == ID).ExecuteCommandHasChangeAsync();
        }
        /// <summary>
        /// 获取所有启用商品
        /// </summary>
        /// <returns></returns>
        public async Task<List<GPT_Commodity>> GetCommodityListAsync()
        {
            return await SugarConfig.CretClient().Queryable<GPT_Commodity>().Where(it => it.Enable == 1).ToListAsync();
        }
        /// <summary>
        /// 查询某一个商品
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public async Task<GPT_Commodity> GetCommodityFirstAsync(int ID)
        {
            return await SugarConfig.CretClient().Queryable<GPT_Commodity>().Where(it => it.ID == ID).FirstAsync();
        }
    }
}
