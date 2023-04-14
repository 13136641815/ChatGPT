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
        [SugarColumn(IsNullable = true)]
        public string Title { get; set; }
        /// <summary>
        /// 微信端分享描述
        /// </summary>
        [SugarColumn(ColumnDataType = "Nvarchar(2000)", IsNullable = true)]
        public string Desc_ { get; set; }
        [SugarColumn(IsNullable = true)]
        public string ApiUrl { get; set; }
        [SugarColumn(ColumnDataType = "Nvarchar(2000)", IsNullable = true)]
        public string CommissionRemark { get; set; }
        [SugarColumn(IsNullable = true)]
        public int? Free_Second { get; set; }
        [SugarColumn(ColumnDataType = "decimal(18,2)",IsNullable = true)]
        public decimal? DoorJe { get; set; }
        [SugarColumn(ColumnDataType = "Nvarchar(2000)", IsNullable = true)]
        public string Notice { get; set; }
        public int? VIP_NumberWords { get; set; }
        public int? Draw_Second { get; set; }
        public int? Free_DrawSecond { get; set; }
        [SqlSugar.SugarColumn(ColumnDataType = "Nvarchar(4000)" /*可以设置类型*/, IsJson = true, IsNullable = true)]
        public List<VIPReamrk> VIPReamrk { get; set; }
        [SugarColumn(IsNullable = true)]
        public string PushImg { get; set; }
    }
}
