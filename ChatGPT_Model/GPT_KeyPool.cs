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
        public DateTime? Stamp { get; set; } = DateTime.Now;
        public int? Enable { get; set; }
        public int? State { get; set; }
        public string ApiKey { get; set; }
        public string Explain { get; set; }

    }
}
