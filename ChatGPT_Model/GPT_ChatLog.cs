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
        public DateTime? Time { get; set; } = DateTime.Now;
        public string UserMessage { get; set; }
        public string AIMessage { get; set; }
        public string Openid { get; set; }
    }
}
