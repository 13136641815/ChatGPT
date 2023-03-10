using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatGPT_Model
{
    [SugarTable("GPT_CDK")]
    public class GPT_CDK
    {
        public GPT_CDK()
        {

        }
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true)]
        public int ID { get; set; }
        public DateTime? Stamp { get; set; } = DateTime.Now;
        public string CDK { get; set; }
        public int State { get; set; }
        public string NikeName { get; set; }
        public int UserID { get; set; }
        public DateTime BigoTime { get; set; }
        public int Type { get; set; }
        public int Duration { get; set; }
        public int Free_Second { get; set; }
    }
}
