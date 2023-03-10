using ChatGPT_Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatGPT_Mapper
{
    public class Mapper_GPT_Setup
    {
        /// <summary>
        /// 获取一条配置
        /// </summary>
        /// <returns></returns>
        public async Task<GPT_Setup> GetFirstAsync()
        {
            return await SugarConfig.CretClient().Queryable<GPT_Setup>().FirstAsync();
        }
        /// <summary>
        /// 更新一条配置
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<bool> UpdateAsync(GPT_Setup model)
        {
            return await SugarConfig.CretClient().Updateable(model).ExecuteCommandHasChangeAsync();
        }
    }
}
