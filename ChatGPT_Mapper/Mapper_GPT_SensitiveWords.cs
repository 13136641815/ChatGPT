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
    public class Mapper_GPT_SensitiveWords
    {
        /// <summary>
        /// 获取所有关键字
        /// </summary>
        /// <returns></returns>
        public List<GPT_SensitiveWords> GetListAll()
        {
            return SugarConfig.CretClient().Queryable<GPT_SensitiveWords>().ToList();
        }
        public async Task<List<GPT_SensitiveWords>> GetListPageAsync(PageParams Page, GPT_SensitiveWords model, RefAsync<int> DataCount)
        {
            return await SugarConfig.CretClient().Queryable<GPT_SensitiveWords>()
                .WhereIF(!string.IsNullOrEmpty(model.Text), it => it.Text.Contains(model.Text))
                .ToPageListAsync(Page.PageNum, Page.PageSize, DataCount);
        }
        public async Task<GPT_SensitiveWords> GetFirstAsync(int ID)
        {
            return await SugarConfig.CretClient().Queryable<GPT_SensitiveWords>()
                .Where(it => it.ID == ID)
                .FirstAsync();
        }
        public async Task<bool> UpdateAsync(GPT_SensitiveWords model)
        {
            return await SugarConfig.CretClient().Updateable(model).UpdateColumns(it => new
            {
                it.Text
            }).Where(it => it.ID == model.ID).ExecuteCommandHasChangeAsync();
        }
        public async Task<int> AddAsync(GPT_SensitiveWords model)
        {
            return await SugarConfig.CretClient().Insertable(model).ExecuteReturnIdentityAsync();
        }
        public async Task<int> DeleteAsync(int ID)
        {
            return await SugarConfig.CretClient().Deleteable<GPT_SensitiveWords>().Where(it => it.ID == ID).ExecuteCommandAsync();
        }
        public async Task<int> AddList(List<GPT_SensitiveWords> model)
        {
            return await SugarConfig.CretClient().Insertable(model).ExecuteCommandAsync();
        }
    }
}
