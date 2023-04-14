using System;
using System.Linq;
using System.Text;
using SqlSugar;

namespace ChatGPT_Model
{
    ///<summary>
    ///
    ///</summary>
    [SugarTable("GPT_User")]
    public partial class GPT_User
    {
        public GPT_User()
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

        /// <summary>
        /// Desc:
        /// Default:
        /// Nullable:True
        /// </summary>           
        [SugarColumn(IsNullable = true)]
        public string Tel { get; set; }

        /// <summary>
        /// Desc:
        /// Default:
        /// Nullable:True
        /// </summary>           
        [SugarColumn(IsNullable = true)]
        public string NikeName { get; set; }

        /// <summary>
        /// Desc:
        /// Default:
        /// Nullable:True
        /// </summary>           
        [SugarColumn(IsNullable = true)]
        public string WxOpenID { get; set; }

        /// <summary>
        /// Desc:
        /// Default:
        /// Nullable:True
        /// </summary>           
        [SugarColumn(IsNullable = true)]
        public string WxHeadUrl { get; set; }

        [SugarColumn(IsNullable = true)]
        public int? YN_VIP { get; set; }

        [SugarColumn(IsNullable = true)]
        public int? Type_VIP { get; set; }
        [SugarColumn(IsNullable = true)]
        public DateTime? BeOverdue_VIP { get; set; }
        public int? YN_PVIP { get; set; }
        [SugarColumn(IsNullable = true)]
        public DateTime? BeOverdue_PVIP { get; set; }

        [SugarColumn(IsNullable = true)]
        /// </summary>           
        public int? Free_Second { get; set; }
        [SugarColumn(IsNullable = true)]
        public string PushOpenID { get; set; }
        [SugarColumn(IsNullable = true)]
        public string AccountType { get; set; }
        [SugarColumn(IsNullable = true)]
        public string AccountNum { get; set; }
        [SugarColumn(ColumnDataType = "decimal(18,2)",IsNullable = true)]
        public decimal? ShareCommission { get; set; } = null;
        [SugarColumn(IsNullable = true)]
        public int? Block { get; set; } = 0;
        [SugarColumn(IsNullable = true)]
        public int? AIDraw_Second { get; set; } = 0;
    }
}
