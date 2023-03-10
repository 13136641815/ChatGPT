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
    public class Mapper_GPT_CashWithdrawal
    {

        /// <summary>
        /// 查询分页
        /// </summary>
        /// <returns></returns>
        public async Task<List<GPT_CashWithdrawal>> GetListPageAsync(PageParams Page, GPT_CashWithdrawal model, RefAsync<int> DataCount)
        {
            return await SugarConfig.CretClient().Queryable<GPT_CashWithdrawal>()
                .WhereIF(model.Opneid != null && model.Opneid != "", it => it.Opneid.Contains(model.Opneid))
                .WhereIF(model.NikeName != null && model.NikeName != "", it => it.NikeName.Contains(model.NikeName))//昵称搜索
                .WhereIF(model.State != -1, it => it.State == model.State)//结算状态
                .ToPageListAsync(Page.PageNum, Page.PageSize, DataCount);
        }
        /// <summary>
        /// 结算:批量修改结算状态
        /// </summary>
        /// <param name="OrderNumberlist"></param>
        /// <returns></returns>
        public async Task<int> UpdateCheckState(List<GPT_CashWithdrawal> modellist)
        {
            modellist.ForEach(it => it.State = 1);
            return await SugarConfig.CretClient().Updateable(modellist).UpdateColumns(it => new
            {
                it.State
            }).ExecuteCommandAsync();
        }
        /// <summary>
        /// 获取此人申请中的数据（满足业务申请中不可再次申请）
        /// </summary>
        /// <param name="Openid"></param>
        /// <returns></returns>
        public async Task<GPT_CashWithdrawal> GetModel(string Openid)
        {
            return await SugarConfig.CretClient().Queryable<GPT_CashWithdrawal>().Where(it => it.Opneid == Openid && it.State == 0).FirstAsync();
        }
        /// <summary>
        /// 新增一条
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<int> Add(GPT_CashWithdrawal model, SqlSugarScope db)
        {
            return await db.Insertable(model).ExecuteReturnIdentityAsync();
        }
    }
}
