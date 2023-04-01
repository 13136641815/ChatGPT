using ChatGPT_Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatGPT_Mapper
{
    public class Mapper_sys_dictionary_item
    {
        public async Task<List<sys_dictionary_item>> GetDiyItem(string Dcode)
        {
            return await SugarConfig.CretClient().Queryable<sys_dictionary_item>().Where(it => it.dcode == Dcode)
                .OrderBy(it => it.sort, SqlSugar.OrderByType.Asc)
                .ToListAsync();
        }
    }
}
