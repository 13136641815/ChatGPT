using ChatGPT_Model.AppModel;
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
        [SugarColumn(IsNullable = true)]
        public DateTime? Stamp { get; set; } = DateTime.Now;
        [SugarColumn(IsNullable = true)]
        public int? State { get; set; }
        [SugarColumn(IsNullable = true)]
        public string Type { get; set; }
        [SugarColumn(IsNullable = true)]
        public string Name { get; set; }
        [SugarColumn(IsNullable = true)]
        public string HeardImg { get; set; }
        [SqlSugar.SugarColumn(ColumnDataType = "Nvarchar(2000)", IsNullable = true)]
        public string Explain { get; set; }
        [SqlSugar.SugarColumn(ColumnDataType = "Nvarchar(4000)", IsNullable = true)]
        public string Guide { get; set; }
        [SqlSugar.SugarColumn(ColumnDataType = "Nvarchar(4000)", IsNullable = true /*可以设置类型*/, IsJson = true)]
        public List<ChatAppExamples> Examples { get; set; }
        [SugarColumn(IsNullable = true)]
        public int? Sort { get; set; }

    }
}
