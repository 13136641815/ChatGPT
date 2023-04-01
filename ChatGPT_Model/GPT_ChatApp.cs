using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatGPT_Model
{
    public class GPT_ChatApp
    {
        public GPT_ChatApp() 
        {
        
        }
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true)]
        public int ID { get; set; }
        public DateTime Stamp { get; set; } = DateTime.Now;
        public string Type { get; set; }
        public string HeardImg { get; set; }
        public string Explain { get; set; }
        public string Guide { get; set; }
        public string Examples { get; set; }

    }
}
