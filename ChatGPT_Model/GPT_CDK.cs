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
        [SugarColumn(IsNullable = true)]
        public DateTime? Stamp { get; set; } = DateTime.Now;
        [SugarColumn(IsNullable = true)]
        public string CDK { get; set; }
        [SugarColumn(IsNullable = true)]
        public int? State { get; set; }
        [SugarColumn(IsNullable = true)]
        public string NikeName { get; set; }
        [SugarColumn(IsNullable = true)]
        public int? UserID { get; set; }
        [SugarColumn(IsNullable = true)]
        public DateTime? BigoTime { get; set; }
        [SugarColumn(IsNullable = true)]
        public int? Type { get; set; }
        [SugarColumn(IsNullable = true)]
        public int? Duration { get; set; }
        [SugarColumn(IsNullable = true)]
        public int? Free_Second { get; set; }
    }
}
