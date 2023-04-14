using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatGPT_Model
{
    [SugarTable("GPT_BobotList")]
    public class GPT_BobotList
    {
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true)]
        public int ID { get; set; }
        [SugarColumn(IsNullable = true)]
        public DateTime? Stamp { get; set; } = DateTime.Now;
        public int? Type { get; set; }
        [SugarColumn(IsNullable = true)]
        public int? State { get; set; }
        [SugarColumn(IsNullable = true)]
        public string Openid { get; set; }
        [SugarColumn(IsNullable = true)]
        public string Name { get; set; }
        [SugarColumn(IsNullable = true)]
        public string Img { get; set; }
        [SqlSugar.SugarColumn(ColumnDataType = "Nvarchar(500)", IsNullable = true)]
        public string Greetings { get; set; }
        [SqlSugar.SugarColumn(ColumnDataType = "Nvarchar(4000)", IsNullable = true /*可以设置类型*/, IsJson = true)]
        public ChatGPT_Model.GPT3_5.Body APIJson { get; set; }
        [SqlSugar.SugarColumn(ColumnDataType = "Nvarchar(500)",IsNullable = true)]
        public string Ccene { get; set; }
        [SugarColumn(IsNullable = true)]
        public int? Sort { get; set; }
    }
}
