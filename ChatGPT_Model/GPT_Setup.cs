using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatGPT_Model
{
    [SugarTable("GPT_Setup")]
    public class GPT_Setup
    {
        public GPT_Setup()
        {

        }
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true)]
        public int ID { get; set; }
        public DateTime? Stamp { get; set; } = DateTime.Now;
        public string Title { get; set; }
        public string ApiUrl { get; set; }
        public string CommissionRemark { get; set; }
        public int Free_Second { get; set; }
        public decimal? DoorJe { get; set; }
    }
}
