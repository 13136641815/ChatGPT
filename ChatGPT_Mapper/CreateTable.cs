using ChatGPT_Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatGPT_Mapper
{
    public class CreateTable
    {
        public static void Create()
        {
            SugarConfig.CretClient().CodeFirst.SetStringDefaultLength(255).InitTables(typeof(GPT_Setup));
            SugarConfig.CretClient().CodeFirst.SetStringDefaultLength(255).InitTables(typeof(GPT_User));
            SugarConfig.CretClient().CodeFirst.SetStringDefaultLength(255).InitTables(typeof(GPT_Order));
            SugarConfig.CretClient().CodeFirst.SetStringDefaultLength(255).InitTables(typeof(GPT_Bill));
            SugarConfig.CretClient().CodeFirst.SetStringDefaultLength(255).InitTables(typeof(GPT_Commodity));
            SugarConfig.CretClient().CodeFirst.SetStringDefaultLength(255).InitTables(typeof(GPT_OrderCommodity));
            SugarConfig.CretClient().CodeFirst.SetStringDefaultLength(255).InitTables(typeof(GPT_BobotList));
            SugarConfig.CretClient().CodeFirst.SetStringDefaultLength(255).InitTables(typeof(GPT_KeyPool));
            SugarConfig.CretClient().CodeFirst.SetStringDefaultLength(255).InitTables(typeof(GPT_CDK));
            SugarConfig.CretClient().CodeFirst.SetStringDefaultLength(255).InitTables(typeof(GPT_Commission));
            SugarConfig.CretClient().CodeFirst.SetStringDefaultLength(255).InitTables(typeof(GPT_CashWithdrawal));
            SugarConfig.CretClient().CodeFirst.SetStringDefaultLength(255).InitTables(typeof(GPT_ChatLog));
            SugarConfig.CretClient().CodeFirst.SetStringDefaultLength(255).InitTables(typeof(GPT_ChatApp));
        }
    }
}
