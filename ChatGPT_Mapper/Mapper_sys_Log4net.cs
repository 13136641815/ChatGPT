using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatGPT_Mapper
{
    public class Mapper_sys_Log4net
    {
        public async Task<long> Insert(SYSTEM_Models.sys_Log4net model) 
        {
            return await SugarConfig.CretClient().Insertable(model).SplitTable().ExecuteReturnSnowflakeIdAsync();
        }
    }
}
