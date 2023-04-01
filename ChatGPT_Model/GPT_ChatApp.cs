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
        public DateTime Stamp { get; set; } = DateTime.Now;
        public int State { get; set; }
        public string Type { get; set; }
        public string Name { get; set; }
        public string HeardImg { get; set; }
        public string Explain { get; set; }
        public string Guide { get; set; }
        [SqlSugar.SugarColumn(ColumnDataType = "varchar(4000)" /*可以设置类型*/, IsJson = true)]
        public List<ChatAppExamples> Examples { get; set; }
        public int Sort { get; set; }

    }
}
