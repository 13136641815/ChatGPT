using ChatGPT_Model;
using ChatGPT_Model.AppModel.User;
using ChatGPT_Model.AppModel;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;
using System.Collections;

namespace ChatGPT_Mapper
{
    public class Mapper_GPT_Bill
    {
        /// <summary>
        /// 查询当前金额合计
        /// </summary>
        /// <returns></returns>
        public async Task<decimal?> GetListSumAsync(GPT_Bill model, DateTimeParams Time)
        {
            decimal? SUM = await SugarConfig.CretClient().Queryable<GPT_Bill>()
                .WhereIF(model.Channel != null && model.Channel != "", it => it.Channel == model.Channel)
                .WhereIF(model.OrderNumber != null && model.OrderNumber != "", it => it.OrderNumber.Contains(model.OrderNumber))
                .WhereIF(Time.TimeStart != null && Time.TimeStart != "", it => it.Stamp > DateTime.Parse(Time.TimeStart + " 00:00:00"))
                .WhereIF(Time.TimeEnd != null && Time.TimeEnd != "", it => it.Stamp <= DateTime.Parse(Time.TimeEnd + " 23:59:59"))
                .SumAsync(it => it.OrderAmountYuan);
            return SUM;
        }
        /// <summary>
        /// 查询分页
        /// </summary>
        /// <returns></returns>
        public async Task<List<BillViewModel>> GetListPageAsync(PageParams Page, GPT_Bill model, DateTimeParams Time, RefAsync<int> DataCount)
        {
            return await SugarConfig.CretClient().Queryable<GPT_Bill>()
                .LeftJoin<GPT_User>((it, v) => it.UserID == v.ID)//联表为了查询支付人的信息
                .LeftJoin<GPT_OrderCommodity>((it, v, o) => it.OrderNumber == o.OrderNumber)//联表为了查询购买的商品信息
                .WhereIF(model.Channel != null && model.Channel != "", it => it.Channel == model.Channel)
                .WhereIF(model.OrderNumber != null && model.OrderNumber != "", it => it.OrderNumber.Contains(model.OrderNumber))
                .WhereIF(Time.TimeStart != null && Time.TimeStart != "", it => it.Stamp > DateTime.Parse(Time.TimeStart + " 00:00:00"))
                .WhereIF(Time.TimeEnd != null && Time.TimeEnd != "", it => it.Stamp <= DateTime.Parse(Time.TimeEnd + " 23:59:59"))
                .Select((it, v, o) => new BillViewModel
                {
                    ID = it.ID,
                    Stamp = it.Stamp,
                    Channel = it.Channel,
                    OrderNumber = it.OrderNumber,
                    NikeName = v.NikeName,
                    OrderAmountYuan = it.OrderAmountYuan,
                    OrderAmountFen = it.OrderAmountFen,
                    CommodityName = o.CommodityName,
                    Duration = o.Duration
                })
                .OrderBy(it => it.Stamp, OrderByType.Desc)
                .ToPageListAsync(Page.PageNum, Page.PageSize, DataCount);
        }
        /// <summary>
        /// 支付成功
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<bool> AddAsync(GPT_Order model, SqlSugarScope db)
        {
            var i = await db.Insertable(new GPT_Bill()
            {
                Stamp = DateTime.Now,
                UID = model.ID,
                Channel = model.Channel,
                OrderNumber = model.OrderNumber,
                UserID = model.UserID,
                OrderAmountYuan = model.OrderAmountYuan,
                OrderAmountFen = model.OrderAmountFen
            }).ExecuteReturnIdentityAsync();
            return i > 0 ? true : false;
        }
    }
}
