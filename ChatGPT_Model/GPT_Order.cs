using System;
using System.Linq;
using System.Text;
using SqlSugar;

namespace ChatGPT_Model
{
    ///<summary>
    ///
    ///</summary>
    [SugarTable("GPT_Order")]
    public partial class GPT_Order
    {
        public GPT_Order()
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
        public int? State { get; set; }

        /// <summary>
        /// Desc:
        /// Default:
        /// Nullable:True
        /// </summary>           
        [SugarColumn(IsNullable = true)]
        public string Channel { get; set; }

        [SugarColumn(IsNullable = true)]
        public DateTime? BackStamp { get; set; }

        /// <summary>
        /// Desc:
        /// Default:
        /// Nullable:True
        /// </summary>           
        [SugarColumn(IsNullable = true)]
        public string OrderNumber { get; set; }

        [SugarColumn(IsNullable = true)]
        public int? UserID { get; set; }

        /// <summary>
        /// Desc:
        /// Default:
        /// Nullable:True
        /// </summary>           
        [SugarColumn(ColumnDataType = "decimal(18,2)",IsNullable = true)]
        public decimal? OrderAmountYuan { get; set; }

        [SugarColumn(IsNullable = true)]
        public int? OrderAmountFen { get; set; }

    }
}
