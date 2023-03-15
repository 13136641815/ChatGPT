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
    public class Mapper_GPT_BobotList
    {
        /// <summary>
        /// 查询分页
        /// </summary>
        /// <returns></returns>
        public async Task<List<GPT_BobotList>> GetListPageAsync(PageParams Page, GPT_BobotList model, RefAsync<int> DataCount)
        {
            return await SugarConfig.CretClient().Queryable<GPT_BobotList>()
                .WhereIF(model.Openid != null && model.Openid != "", it => it.Openid.Contains(model.Openid))
                .OrderBy(it => it.Sort)
                .ToPageListAsync(Page.PageNum, Page.PageSize, DataCount);
        }
        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<int> AddAsync(GPT_BobotList model)
        {
            return await SugarConfig.CretClient().Insertable(model).ExecuteReturnIdentityAsync();
        }
        /// <summary>
        /// 修改（按主键）
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<bool> UpdateAsync(GPT_BobotList model)
        {
            return await SugarConfig.CretClient().Updateable(model).IgnoreColumns(ignoreAllNullColumns: true).ExecuteCommandHasChangeAsync();
        }
        /// <summary>
        /// 修改（按主键）
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Update(GPT_BobotList model, SqlSugarScope db)
        {
            return db.Updateable(model).IgnoreColumns(ignoreAllNullColumns: true).ExecuteCommandHasChange();
        }
        /// <summary>
        /// 删除（按主键ID）
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public async Task<bool> DeleteAsync(int ID)
        {
            return await SugarConfig.CretClient().Deleteable<GPT_BobotList>().Where(it => it.ID == ID).ExecuteCommandHasChangeAsync();
        }
        /// <summary>
        /// 获取一个机器人
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public async Task<GPT_BobotList> GetFirstAsync(int ID)
        {
            return await SugarConfig.CretClient().Queryable<GPT_BobotList>().Where(it => it.ID == ID).FirstAsync();
        }
        /// <summary>
        /// 移动端获取机器人列表
        /// </summary>
        /// <param name="openid"></param>
        /// <returns></returns>
        public async Task<List<GPT_BobotList>> GetBotAllAsync(string openid)
        {
            var list1 = await SugarConfig.CretClient().Queryable<GPT_BobotList>()
                .Where(it => it.Type == 1 && it.State == 1)
                .OrderBy(it=>it.Sort)
                .ToListAsync();
            var list2 = await SugarConfig.CretClient().Queryable<GPT_BobotList>()
                .Where(it => it.Openid == openid && it.State == 1 && it.Type == 0)
                .OrderBy(it => it.Sort)
                .ToListAsync();
            foreach (var item in list2)
            {
                list1.Add(item);
            }
            return list1;
        }
    }
}
