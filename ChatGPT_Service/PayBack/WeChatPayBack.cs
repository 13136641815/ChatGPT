using ChatGPT_Mapper;
using ChatGPT_Model;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatGPT_Service.PayBack
{
    public class WeChatPayBack
    {
        /// <summary>
        /// 回写核心函数
        /// </summary>
        /// <param name="OrderNo"></param>
        /// <param name="Openid"></param>
        /// <returns></returns>
        public async Task<bool> WriteBack(string OrderNo, string Openid)
        {
            Mapper_GPT_User UserApp = new Mapper_GPT_User();
            Mapper_GPT_Order OrderApp = new Mapper_GPT_Order();
            Mapper_GPT_OrderCommodity OrderCommodityApp = new Mapper_GPT_OrderCommodity();
            Mapper_GPT_Bill BillApp = new Mapper_GPT_Bill();
            Mapper_GPT_Commission CommissionApp = new Mapper_GPT_Commission();
            //查询出订单
            //查询出人
            //查询出商品
            GPT_Order OrderModel = await OrderApp.GetModelFirstAsync(OrderNo);
            if (OrderModel.State == 0)//判断未支付，防止重复调用重复充值
            {
                GPT_User UserModel = await UserApp.GetModelFirstAsync(Openid);
                GPT_OrderCommodity CommodityModel = await OrderCommodityApp.GetFirstAsync(OrderNo);
                var db = SugarConfig.CretClient();
                await db.BeginTranAsync();
                var OrderBool = await OrderApp.UpdateStateToSussAsync(OrderModel, db);//修改订单状态
                var BillBool = await BillApp.AddAsync(OrderModel, db);//插入账单表
                var UserBool = await UpdateUserInfoAsync(UserModel, CommodityModel, db);//修改人的VIP状态和时间
                var CommissionBool = await CommissionApp.UpdateAsync(OrderNo, db);//修改分佣状态
                if (OrderBool && BillBool && UserBool)
                {
                    await db.CommitTranAsync();
                    return true;
                }
                await db.RollbackTranAsync();
            }
            return false;
        }
        public async Task<bool> UpdateUserInfoAsync(GPT_User UserModel, GPT_OrderCommodity CommodityModel, SqlSugarScope db)
        {
            Mapper_GPT_User UserApp = new Mapper_GPT_User();
            DateTime dt = DateTime.Now;
            if (UserModel.YN_VIP == 0)
            {
                //非会员，从今天开始充值
                UserModel.BeOverdue_VIP = dt.AddDays(double.Parse((31 * CommodityModel.Duration).ToString()));
            }
            else
            {
                //是会员
                if (DateTime.Now > UserModel.BeOverdue_VIP)
                {
                    //已过期，从今天开始充值
                    UserModel.BeOverdue_VIP = dt.AddDays(double.Parse((31 * CommodityModel.Duration).ToString()));
                }
                else
                {
                    //未过期，续费
                    DateTime dn = DateTime.Parse(UserModel.BeOverdue_VIP.ToString());
                    UserModel.BeOverdue_VIP = dn.AddDays(double.Parse((31 * CommodityModel.Duration).ToString()));
                }
            }
            UserModel.YN_VIP = 1;
            return await UserApp.RechargeAsync(UserModel, db);
        }
    }
}
