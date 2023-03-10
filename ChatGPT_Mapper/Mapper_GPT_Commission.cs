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
    public class Mapper_GPT_Commission
    {
        /// <summary>
        /// 查询当前金额合计
        /// </summary>
        /// <returns></returns>
        public async Task<decimal?> GetListSumAsync(PageParams Page, GPT_Commission model, DateTimeParams Time, RefAsync<int> DataCount)
        {
            decimal? SUM = await SugarConfig.CretClient().Queryable<GPT_Commission>()
               .WhereIF(Time.TimeStart != null && Time.TimeStart != "", it => it.Stamp > DateTime.Parse(Time.TimeStart + " 00:00:00"))
               .WhereIF(Time.TimeEnd != null && Time.TimeEnd != "", it => it.Stamp <= DateTime.Parse(Time.TimeEnd + " 23:59:59"))
               .Where(it => it.CheckState == model.CheckState)
               .Where(it => it.Push_WxOpenID == model.Push_WxOpenID)
               .Where(it => it.State == 1)
               .SumAsync(it => it.Commission);
            return SUM;
        }
        /// <summary>
        /// 分页
        /// </summary>
        /// <param name="Page"></param>
        /// <param name="model"></param>
        /// <param name="Time"></param>
        /// <param name="DataCount"></param>
        /// <returns></returns>
        public async Task<List<GPT_Commission>> GetListPageAsync(PageParams Page, GPT_Commission model, DateTimeParams Time, RefAsync<int> DataCount)
        {
            return await SugarConfig.CretClient().Queryable<GPT_Commission>()
                .WhereIF(Time.TimeStart != null && Time.TimeStart != "", it => it.Stamp > DateTime.Parse(Time.TimeStart + " 00:00:00"))
                .WhereIF(Time.TimeEnd != null && Time.TimeEnd != "", it => it.Stamp <= DateTime.Parse(Time.TimeEnd + " 23:59:59"))
                .Where(it => it.CheckState == model.CheckState)
                .Where(it => it.Push_WxOpenID == model.Push_WxOpenID)
                .Where(it => it.State == 1)
                .ToPageListAsync(Page.PageNum, Page.PageSize, DataCount);
        }
        /// <summary>
        /// 分佣下单
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<int> AddAsync(GPT_Commission model, SqlSugarScope db)
        {
            return await db.Insertable(model).ExecuteReturnIdentityAsync();
        }
        /// <summary>
        /// 支付成功回调
        /// </summary>
        /// <param name="OrderNumber"></param>
        /// <returns></returns>
        public async Task<bool> UpdateAsync(string OrderNumber, SqlSugarScope db)
        {
            GPT_Commission model = new GPT_Commission();
            model.State = 1;
            model.BackStamp = DateTime.Now;
            return await db.Updateable(model).UpdateColumns(it => new
            {
                it.State,
                it.BackStamp
            }).Where(it => it.OrderNumber == OrderNumber).ExecuteCommandHasChangeAsync();
        }
        /// <summary>
        /// 结算:批量修改结算状态
        /// </summary>
        /// <param name="OrderNumberlist"></param>
        /// <returns></returns>
        public async Task<int> UpdateCheckState(List<GPT_Commission> modellist)
        {
            modellist.ForEach(it => it.CheckState = 1);
            return await SugarConfig.CretClient().Updateable(modellist).UpdateColumns(it => new
            {
                it.CheckState
            }).ExecuteCommandAsync();
        }
        /// <summary>
        /// 结算:批量修改结算状态
        /// </summary>
        /// <param name="OrderNumberlist"></param>
        /// <returns></returns>
        public async Task<int> UpdateCheck2State(List<GPT_Commission> modellist, SqlSugarScope db)
        {
            return await db.Updateable(modellist).UpdateColumns(it => new
            {
                it.CheckState
            }).ExecuteCommandAsync();
        }
        /// <summary>
        /// 查询当前金额合计
        /// </summary>
        /// <returns></returns>
        public async Task<decimal?> GetListSumAdminAsync(PageParams Page, GPT_Commission model, DateTimeParams Time, RefAsync<int> DataCount)
        {
            decimal? SUM = await SugarConfig.CretClient().Queryable<GPT_Commission>()
                .Where(it => it.State == 1)//支付成功
                .WhereIF(model.Push_WxOpenID != null && model.Push_WxOpenID != "", it => it.Push_WxOpenID.Contains(model.Push_WxOpenID))
                .WhereIF(model.Push_NikeName != null && model.Push_NikeName != "", it => it.Push_NikeName.Contains(model.Push_NikeName))//昵称搜索
                .WhereIF(model.CheckState != -1, it => it.CheckState == model.CheckState)//结算状态
                .WhereIF(Time.TimeStart != null && Time.TimeStart != "", it => it.BackStamp > DateTime.Parse(Time.TimeStart + " 00:00:00"))
                .WhereIF(Time.TimeEnd != null && Time.TimeEnd != "", it => it.BackStamp <= DateTime.Parse(Time.TimeEnd + " 23:59:59"))
               .SumAsync(it => it.Commission);
            return SUM;
        }
        /// <summary>
        /// 查询分页
        /// </summary>
        /// <returns></returns>
        public async Task<List<GPT_Commission>> GetListPageAdminAsync(PageParams Page, GPT_Commission model, DateTimeParams Time, RefAsync<int> DataCount)
        {
            return await SugarConfig.CretClient().Queryable<GPT_Commission>()
                .Where(it => it.State == 1)//支付成功
                .WhereIF(model.Push_WxOpenID != null && model.Push_WxOpenID != "", it => it.Push_WxOpenID.Contains(model.Push_WxOpenID))
                .WhereIF(model.Push_NikeName != null && model.Push_NikeName != "", it => it.Push_NikeName.Contains(model.Push_NikeName))//昵称搜索
                .WhereIF(model.CheckState != -1, it => it.CheckState == model.CheckState)//结算状态
                .WhereIF(Time.TimeStart != null && Time.TimeStart != "", it => it.BackStamp > DateTime.Parse(Time.TimeStart + " 00:00:00"))
                .WhereIF(Time.TimeEnd != null && Time.TimeEnd != "", it => it.BackStamp <= DateTime.Parse(Time.TimeEnd + " 23:59:59"))
                .ToPageListAsync(Page.PageNum, Page.PageSize, DataCount);
        }
    }
}
