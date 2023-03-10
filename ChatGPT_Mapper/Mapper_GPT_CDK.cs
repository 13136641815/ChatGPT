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
    public class Mapper_GPT_CDK
    {
        /// <summary>
        /// 查询分页
        /// </summary>
        /// <returns></returns>
        public async Task<List<GPT_CDK>> GetListPageAsync(PageParams Page, GPT_CDK model, DateTimeParams Time, RefAsync<int> DataCount)
        {
            return await SugarConfig.CretClient().Queryable<GPT_CDK>()
                .WhereIF(model.NikeName != null && model.NikeName != "", it => it.NikeName.Contains(model.NikeName))
                .WhereIF(model.CDK != null && model.CDK != "", it => it.NikeName.Contains(model.CDK))
                .WhereIF(model.State != null && model.State != -2, it => it.State == model.State)
                .WhereIF(Time.TimeStart != null && Time.TimeStart != "", it => it.Stamp > DateTime.Parse(Time.TimeStart + " 00:00:00"))
                .WhereIF(Time.TimeEnd != null && Time.TimeEnd != "", it => it.Stamp <= DateTime.Parse(Time.TimeEnd + " 23:59:59"))
                .ToPageListAsync(Page.PageNum, Page.PageSize, DataCount);
        }
        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<int> AddAsync(GPT_CDK model)
        {
            return await SugarConfig.CretClient().Insertable(model).ExecuteReturnIdentityAsync();
        }
        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<int> AddAsync(List<GPT_CDK> model)
        {
            return await SugarConfig.CretClient().Insertable(model).ExecuteCommandAsync();
        }
        /// <summary>
        /// 删除（按主键ID）
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public async Task<bool> DeleteAsync(int ID)
        {
            return await SugarConfig.CretClient().Deleteable<GPT_CDK>().Where(it => it.ID == ID).ExecuteCommandHasChangeAsync();
        }
        /// <summary>
        /// 获取一条CDK
        /// </summary>
        /// <param name="CDK"></param>
        /// <returns></returns>
        public GPT_CDK First(string CDK)
        {
            return SugarConfig.CretClient().Queryable<GPT_CDK>().Where(it => it.CDK == CDK && it.State == 0).First();
        }
        /// <summary>
        /// 更新占用状态
        /// </summary>
        /// <param name="CDK"></param>
        /// <returns></returns>
        public bool UpdateState(GPT_CDK model, SqlSugarScope db)
        {
            return db.Updateable(model).ExecuteCommandHasChange();
        }
    }
}
