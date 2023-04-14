using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatGPT_Model
{
    [SugarTable("GPT_KeyPool")]
    public partial class GPT_KeyPool
    {
        public GPT_KeyPool()
        {

        }
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true)]
        public int ID { get; set; }
        [SugarColumn(IsNullable = true)]
        public DateTime? Stamp { get; set; } = DateTime.Now;
        [SugarColumn(IsNullable = true)]
        public int? Enable { get; set; }
        [SugarColumn(IsNullable = true)]
        public int? State { get; set; }
        [SugarColumn(IsNullable = true)]
        public string ApiKey { get; set; }
        [SugarColumn(IsNullable = true)]
        public string Explain { get; set; }

    }
}
