using ChatGPT_Model.AppModel;
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
        /// <summary>
        /// 微信端分享描述
        /// </summary>
        public string Desc_ { get; set; }
        public string ApiUrl { get; set; }
        public string CommissionRemark { get; set; }
        public int Free_Second { get; set; }
        public decimal? DoorJe { get; set; }
        public string Notice { get; set; }
        public int VIP_NumberWords { get; set; }
        public int Draw_Second { get; set; }
        public int Free_DrawSecond { get; set; }
        [SqlSugar.SugarColumn(ColumnDataType = "varchar(4000)" /*可以设置类型*/, IsJson = true)]
        public List<VIPReamrk> VIPReamrk { get; set; }
        public string PushImg { get; set; }
    }
}
