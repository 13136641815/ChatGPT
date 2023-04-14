using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatGPT_Model
{
    public class GPT_ChatLog
    {
        public GPT_ChatLog()
        {

        }
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true)]
        public int ID { get; set; }
        [SugarColumn(IsNullable = true)]
        public DateTime? Time { get; set; } = DateTime.Now;
        public int? Type { get; set; }
        [SugarColumn(IsNullable = true)]
        public string UserMessage { get; set; }
        [SugarColumn(IsNullable = true)]
        public string AIMessage { get; set; }
        [SugarColumn(IsNullable = true)]
        public string Openid { get; set; }
    }
}
