using ChatGPT_Model;
using ChatGPT_Model.AppModel;
using ChatGPT_Model.AppModel.User;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ChatGPT_Mapper
{
    public class Mapper_GPT_User
    {
        /// <summary>
        /// 获取推广对象列表
        /// </summary>
        /// <param name="Openid"></param>
        /// <returns></returns>
        public async Task<List<GPT_User>> GetComListAsync(string Openid)
        {
            return await SugarConfig.CretClient().Queryable<GPT_User>()
                .Where(it => it.PushOpenID == Openid)
                .ToListAsync();
        }
        /// <summary>
        /// 查询分页
        /// </summary>
        /// <returns></returns>
        public async Task<List<GPT_User>> GetListPageAsync(PageParams Page, GPT_User model, DateTimeParams Time, UserBusParams UserParams, RefAsync<int> DataCount)
        {
            return await SugarConfig.CretClient().Queryable<GPT_User>()
                .WhereIF(model.NikeName != null && model.NikeName != "", it => it.NikeName.Contains(model.NikeName))
                .WhereIF(model.YN_VIP != null, it => it.YN_VIP == model.YN_VIP)
                .WhereIF(Time.TimeStart != null && Time.TimeStart != "", it => it.Stamp > DateTime.Parse(Time.TimeStart + " 00:00:00"))
                .WhereIF(Time.TimeEnd != null && Time.TimeEnd != "", it => it.Stamp <= DateTime.Parse(Time.TimeEnd + " 23:59:59"))
                .WhereIF(UserParams.BeOverdue, it => it.BeOverdue_VIP < DateTime.Now)
                .ToPageListAsync(Page.PageNum, Page.PageSize, DataCount);
        }
        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<int> AddAsync(GPT_User model)
        {
            return await SugarConfig.CretClient().Insertable(model).ExecuteReturnIdentityAsync();
        }
        /// <summary>
        /// 修改（按主键）
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<bool> UpdateAsync(GPT_User model)
        {
            return await SugarConfig.CretClient().Updateable(model).IgnoreColumns(ignoreAllNullColumns: true).ExecuteCommandHasChangeAsync();
        }
        /// <summary>
        /// 修改（按主键）
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Update(GPT_User model, SqlSugarScope db)
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
            return await SugarConfig.CretClient().Deleteable<GPT_User>().Where(it => it.ID == ID).ExecuteCommandHasChangeAsync();
        }
        /// <summary>
        /// 进入主页判断是否存在该用户
        /// </summary>
        /// <param name="OpenID"></param>
        /// <returns></returns>
        public async Task<GPT_User> GetModelFirstAsync(string OpenID)
        {
            var list = await SugarConfig.CretClient().Queryable<GPT_User>().Where(it => it.WxOpenID == OpenID).FirstAsync();
            return list;
        }
        /// <summary>
        /// 进入主页判断是否存在该用户
        /// </summary>
        /// <param name="OpenID"></param>
        /// <returns></returns>
        public async Task<GPT_User> GetModelFirst(string OpenID)
        {
            var list = await SugarConfig.CretClient().Queryable<GPT_User>().Where(it => it.WxOpenID == OpenID).FirstAsync();
            return list;
        }
        public GPT_User GetFirst(string OpenID)
        {
            var list = SugarConfig.CretClient().Queryable<GPT_User>().Where(it => it.WxOpenID == OpenID).First();
            return list;
        }
        /// <summary>
        /// 新增一个用户到表中
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<int> UserAddAsync(GPT_User model)
        {
            var i = await SugarConfig.CretClient().Insertable(model).ExecuteReturnIdentityAsync();
            return i;
        }
        /// <summary>
        /// 新增一个用户到表中
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int UserAdd(GPT_User model)
        {
            var i = SugarConfig.CretClient().Insertable(model).ExecuteReturnIdentity();
            return i;
        }
        /// <summary>
        /// 游客-免费次数
        /// </summary>
        /// <param name="Openid"></param>
        /// <returns></returns>
        public async Task<bool> Free_SecondAsync(GPT_User model)
        {
            return await SugarConfig.CretClient().Updateable(model).UpdateColumns(it => new
            {
                it.Free_Second,
            }).Where(it => it.ID == model.ID)
           .ExecuteCommandHasChangeAsync();
        }
        /// <summary>
        /// 游客-免费次数
        /// </summary>
        /// <param name="Openid"></param>
        /// <returns></returns>
        public async Task<bool> Free_SecondAsync(GPT_User model, SqlSugarScope db)
        {
            return await db.Updateable(model).UpdateColumns(it => new
            {
                it.Free_Second,
            }).Where(it => it.ID == model.ID)
           .ExecuteCommandHasChangeAsync();
        }
        /// <summary>
        /// 充值会员SVIP
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<bool> RechargeAsync(GPT_User model, SqlSugarScope db)
        {
            return await db.Updateable(model).UpdateColumns(it => new
            {
                it.YN_VIP,
                it.BeOverdue_VIP
            }).Where(it => it.ID == model.ID)
              .ExecuteCommandHasChangeAsync();
        }
        /// <summary>
        /// 延后超级VIP的时间
        /// </summary>
        /// <param name="model"></param>
        /// <param name="db"></param>
        /// <returns></returns>
        public async Task<bool> longSvip(GPT_User model, SqlSugarScope db) 
        {
            return await db.Updateable(model).UpdateColumns(it => new
            {
                it.BeOverdue_VIP
            }).Where(it => it.ID == model.ID)
                  .ExecuteCommandHasChangeAsync();
        }
        /// <summary>
        /// 延后普通VIP的时间
        /// </summary>
        /// <param name="model"></param>
        /// <param name="db"></param>
        /// <returns></returns>
        public async Task<bool> longPvip(GPT_User model, SqlSugarScope db)
        {
            return await db.Updateable(model).UpdateColumns(it => new
            {
                it.YN_PVIP,
                it.BeOverdue_PVIP
            }).Where(it => it.ID == model.ID)
                  .ExecuteCommandHasChangeAsync();
        }
        /// <summary>
        /// 充值会员VIP
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<bool> RechargePVIPAsync(GPT_User model, SqlSugarScope db)
        {
            return await db.Updateable(model).UpdateColumns(it => new
            {
                it.YN_PVIP,
                it.BeOverdue_PVIP
            }).Where(it => it.ID == model.ID)
              .ExecuteCommandHasChangeAsync();
        }
        /// <summary>
        /// 充值会员
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Recharge(GPT_User model, SqlSugarScope db)
        {
            return db.Updateable(model).UpdateColumns(it => new
            {
                it.YN_VIP,
                it.BeOverdue_VIP
            }).Where(it => it.ID == model.ID)
              .ExecuteCommandHasChange();
        }
        public async Task<bool> UpdateTestAsync(GPT_User model)
        {
            return await SugarConfig.CretClient().Updateable(model).UpdateColumns(it => new
            {
                it.YN_VIP,
                it.BeOverdue_VIP,
                it.Free_Second
            }).Where(it => it.ID == model.ID)
                  .ExecuteCommandHasChangeAsync();
        }
        public async Task<bool> UpdateAccount(GPT_User model)
        {
            return await SugarConfig.CretClient().Updateable(model).UpdateColumns(it => new
            {
                it.AccountType,
                it.AccountNum
            })
            .Where(it => it.ID == model.ID)
            .ExecuteCommandHasChangeAsync();
        }
    }
}
