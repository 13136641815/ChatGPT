using ChatGPT_Mapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatGPT_Service.AES
{
    public class CDK
    {
        private static object obj = new object();
        public static (bool, string) ExchangeCDK(string CDK, string Openid)
        {
            string msg = "";
            bool isok = false;
            lock (obj)
            {
                ChatGPT_Mapper.Mapper_GPT_CDK app = new ChatGPT_Mapper.Mapper_GPT_CDK();
                var model = app.First(CDK);
                if (model == null)
                {
                    return (isok, "兑换码错误，请查证");
                }
                Mapper_GPT_User UserApp = new Mapper_GPT_User();
                var UserModel = UserApp.GetFirst(Openid);
                var db = SugarConfig.CretClient();
                model.UserID = UserModel.ID;
                model.NikeName=UserModel.NikeName;
                model.BigoTime=DateTime.Now;
                model.State = 1;
                isok = app.UpdateState(model, db);
                if (isok)
                {

                    //修改充值者的信息
                    if (model.Type == 0)
                    {
                        //会员

                        DateTime dt = DateTime.Now;
                        if (UserModel.YN_VIP == 0)
                        {
                            //非会员，从今天开始充值
                            UserModel.BeOverdue_VIP = dt.AddDays(double.Parse((31 * model.Duration).ToString()));
                        }
                        else
                        {
                            //是会员
                            if (DateTime.Now > UserModel.BeOverdue_VIP)
                            {
                                //已过期，从今天开始充值
                                UserModel.BeOverdue_VIP = dt.AddDays(double.Parse((31 * model.Duration).ToString()));
                            }
                            else
                            {
                                //未过期，续费
                                DateTime dn = DateTime.Parse(UserModel.BeOverdue_VIP.ToString());
                                UserModel.BeOverdue_VIP = dn.AddDays(double.Parse((31 * model.Duration).ToString()));
                            }
                        }
                        UserModel.YN_VIP = 1;
                        isok = UserApp.Recharge(UserModel, db);//修改会员状态
                        if (isok)
                        {
                            msg = $"兑换成功：{model.Duration}月会员";
                            db.CommitTran();//提交事务
                            return (isok, msg);
                        }
                    }
                    else
                    {
                        //次数
                        UserModel.Free_Second = model.Free_Second + UserModel.Free_Second;
                        //修改免费次数
                        isok = UserApp.Update(UserModel, db);
                        if (isok)
                        {
                            msg = $"兑换成功：{model.Free_Second}次免费对话";
                            db.CommitTran();//提交事务
                            return (isok, msg);
                        }
                    }
                }
                isok = false;
                msg = "兑换异常，请联系客服";
                db.RollbackTran();//回滚
            }
            return (isok, msg);
        }
    }
}
