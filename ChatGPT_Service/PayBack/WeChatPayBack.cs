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
        Mapper_GPT_User UserApp = new Mapper_GPT_User();
        Mapper_GPT_Order OrderApp = new Mapper_GPT_Order();
        Mapper_GPT_OrderCommodity OrderCommodityApp = new Mapper_GPT_OrderCommodity();
        Mapper_GPT_Bill BillApp = new Mapper_GPT_Bill();
        Mapper_GPT_Commission CommissionApp = new Mapper_GPT_Commission();
        DateTime dt = DateTime.Now;
        public WeChatPayBack()
        {

        }
        /// <summary>
        /// 回写核心函数
        /// </summary>
        /// <param name="OrderNo"></param>
        /// <param name="Openid"></param>
        /// <returns></returns>
        public async Task<bool> WriteBack(string OrderNo, string Openid)
        {

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

            bool isok = false;
            int Type = (int)CommodityModel.Type;//0普通VIP|1超级VIP
            //SVIP
            if (Type == 1)
            {
                if (UserModel.YN_PVIP == null || UserModel.YN_PVIP == 0 || UserModel.BeOverdue_PVIP == null || UserModel.BeOverdue_PVIP < dt)
                {
                    //未充值普通VIP
                }
                else
                {
                    //已经充值了普通VIP，要将普通VIP的时间延后SVIP的时间
                    int Days = GetDays(CommodityModel, db);
                    if (Days != 0)
                    {
                        //延后普通VIP的时间
                        DateTime dn = DateTime.Parse(UserModel.BeOverdue_PVIP.ToString());
                        UserModel.BeOverdue_PVIP = dn.AddDays(Days);
                        await UserApp.longPvip(UserModel, db);
                    }
                }
                isok = await SVIP(UserModel, CommodityModel, db);//充值SVIP
            }
            else
            {
                //普通会员
                if (UserModel.YN_VIP == null || UserModel.YN_VIP == 0 || UserModel.BeOverdue_VIP == null || UserModel.BeOverdue_VIP < dt)
                {
                    //未充值超级SVIP
                    isok = await PVIP(UserModel, CommodityModel, db);//充值PVIP
                }
                else
                {
                    //已经充值了SVIP，比较超级会员和普通会员时间哪个长，哪个长就延迟到哪个时间后.
                    int Days = GetDays(CommodityModel, db);
                    DateTime dn = (DateTime)(UserModel.BeOverdue_VIP > UserModel.BeOverdue_PVIP ? UserModel.BeOverdue_VIP : UserModel.BeOverdue_PVIP);
                    dn = dn.AddDays(Days);
                    UserModel.YN_PVIP = 1;
                    UserModel.BeOverdue_PVIP = dn;
                    isok = await UserApp.longPvip(UserModel, db);
                }

            }
            return isok;
        }
        /// <summary>
        /// 获取延迟的天数
        /// </summary>
        /// <param name="CommodityModel"></param>
        /// <param name="db"></param>
        /// <returns></returns>
        int GetDays(GPT_OrderCommodity CommodityModel, SqlSugarScope db)
        {
            if (CommodityModel.CommodityType == 1)
            {
                return 0;
            }
            else
            {
                int TimeUnit = CommodityModel.CommodityType == 0 ? 31 : 1;//月就是31，天就是1
                int Days = (int)(TimeUnit * CommodityModel.Duration);//时长
                return Days;
            }
        }
        async Task<bool> SVIP(GPT_User UserModel, GPT_OrderCommodity CommodityModel, SqlSugarScope db)
        {
            bool isok;
            //次数还是天数
            if (CommodityModel.CommodityType == 1)
            {
                //次数
                UserModel.Free_Second = CommodityModel.Duration;
                isok = await UserApp.Free_SecondAsync(UserModel, db);
            }
            else
            {
                int TimeUnit = CommodityModel.CommodityType == 0 ? 31 : 1;//月就是31，天就是1
                int Days = (int)(TimeUnit * CommodityModel.Duration);//时长
                if (UserModel.YN_VIP == 0)
                {
                    //非会员，从今天开始充值
                    UserModel.BeOverdue_VIP = dt.AddDays(Days);
                }
                else
                {
                    //是会员
                    if (DateTime.Now > UserModel.BeOverdue_VIP)
                    {
                        //已过期，从今天开始充值
                        UserModel.BeOverdue_VIP = dt.AddDays(Days);
                    }
                    else
                    {
                        //未过期，续费
                        DateTime dn = DateTime.Parse(UserModel.BeOverdue_VIP.ToString());
                        UserModel.BeOverdue_VIP = dn.AddDays(Days);
                    }
                }
                UserModel.YN_VIP = 1;
                isok = await UserApp.RechargeAsync(UserModel, db);
            }
            return isok;
        }
        async Task<bool> PVIP(GPT_User UserModel, GPT_OrderCommodity CommodityModel, SqlSugarScope db)
        {
            bool isok;
            //次数还是天数
            if (CommodityModel.CommodityType == 1)
            {
                //次数
                UserModel.Free_Second = CommodityModel.Duration;
                isok = await UserApp.Free_SecondAsync(UserModel, db);
            }
            else
            {
                int TimeUnit = CommodityModel.CommodityType == 0 ? 31 : 1;//月就是31，天就是1
                int Days = (int)(TimeUnit * CommodityModel.Duration);//时长
                if (UserModel.YN_PVIP == 0)
                {
                    //非会员，从今天开始充值
                    UserModel.BeOverdue_PVIP = dt.AddDays(Days);
                }
                else
                {
                    //是会员
                    if (DateTime.Now > UserModel.BeOverdue_PVIP)
                    {
                        //已过期，从今天开始充值
                        UserModel.BeOverdue_PVIP = dt.AddDays(Days);
                    }
                    else
                    {
                        //未过期，续费
                        DateTime dn = DateTime.Parse(UserModel.BeOverdue_PVIP.ToString());
                        UserModel.BeOverdue_PVIP = dn.AddDays(Days);
                    }
                }
                UserModel.YN_PVIP = 1;
                isok = await UserApp.RechargePVIPAsync(UserModel, db);
            }
            return isok;
        }
    }
}
