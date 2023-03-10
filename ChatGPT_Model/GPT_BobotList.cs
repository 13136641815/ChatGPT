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
        public DateTime? Stamp { get; set; } = DateTime.Now;
        public int Type { get; set; }
        public int State { get; set; }
        public string Openid { get; set; }
        public string Name { get; set; }
        public string Img { get; set; }
        public string Greetings { get; set; }
        [SqlSugar.SugarColumn(ColumnDataType = "varchar(4000)" /*可以设置类型*/, IsJson = true)]
        public ChatGPT_Model.GPT3_5.Body APIJson { get; set; }
        public string Ccene { get; set; }
    }
}
