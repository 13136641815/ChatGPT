using System;
using System.Linq;
using System.Text;
using SqlSugar;

namespace ChatGPT_Model
{
    ///<summary>
    ///
    ///</summary>
    [SugarTable("GPT_Bill")]
    public partial class GPT_Bill
    {
        public GPT_Bill()
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
        public int? UID { get; set; }

        /// <summary>
        /// Desc:
        /// Default:
        /// Nullable:True
        /// </summary>           
        [SugarColumn(IsNullable = true)]
        public string Channel { get; set; }

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
