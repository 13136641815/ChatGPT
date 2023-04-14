using System;
using System.Linq;
using System.Text;
using SqlSugar;

namespace ChatGPT_Model
{
    ///<summary>
    ///
    ///</summary>
    [SugarTable("GPT_Commission")]
    public partial class GPT_Commission
    {
        public GPT_Commission()
        {


        }
        /// <summary>
        /// Desc:
        /// Default:
        /// Nullable:False
        /// </summary>           
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true)]
        public int ID { get; set; }

        [SugarColumn(IsNullable = true)]
        public DateTime? Stamp { get; set; } = DateTime.Now;

        [SugarColumn(IsNullable = true)]
        public DateTime? BackStamp { get; set; }

        [SugarColumn(IsNullable = true)]
        public int? State { get; set; }
        [SugarColumn(IsNullable = true)]
        public int? CheckState { get; set; }

        [SugarColumn(IsNullable = true)]
        public int? Push_ID { get; set; }

        /// <summary>
        /// Desc:
        /// Default:
        /// Nullable:True
        /// </summary>           
        [SugarColumn(IsNullable = true)]
        public string Push_WxOpenID { get; set; }

        /// <summary>
        /// Desc:
        /// Default:
        /// Nullable:True
        /// </summary>           
        [SugarColumn(IsNullable = true)]
        public string Push_NikeName { get; set; }

        [SugarColumn(IsNullable = true)]
        public int? Buy_ID { get; set; }

        /// <summary>
        /// Desc:
        /// Default:
        /// Nullable:True
        /// </summary>           
        [SugarColumn(IsNullable = true)]
        public string Buy_WxOpenID { get; set; }

        /// <summary>
        /// Desc:
        /// Default:
        /// Nullable:True
        /// </summary>           
        [SugarColumn(IsNullable = true)]
        public string Buy_NikeName { get; set; }

        /// <summary>
        /// Desc:
        /// Default:
        /// Nullable:True
        /// </summary>           
        [SugarColumn(IsNullable = true)]
        public string OrderNumber { get; set; }

        /// <summary>
        /// Desc:
        /// Default:
        /// Nullable:True
        /// </summary>           
        [SugarColumn(IsNullable = true)]
        public string CommodityName { get; set; }

        /// <summary>
        /// Desc:
        /// Default:
        /// Nullable:True
        /// </summary>           
        [SugarColumn(ColumnDataType = "decimal(18,2)",IsNullable = true)]
        public decimal? ShareCommission { get; set; }

        /// <summary>
        /// Desc:
        /// Default:
        /// Nullable:True
        /// </summary>           
        [SugarColumn(ColumnDataType = "decimal(18,2)",IsNullable = true)]
        public decimal? OrderAmountYuan { get; set; }

        /// <summary>
        /// Desc:
        /// Default:
        /// Nullable:True
        /// </summary>           
        [SugarColumn(ColumnDataType = "decimal(18,2)",IsNullable = true)]
        public decimal? Commission { get; set; }

    }
}
