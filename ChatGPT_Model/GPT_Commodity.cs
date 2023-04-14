﻿using System;
using System.Linq;
using System.Text;
using SqlSugar;

namespace ChatGPT_Model
{
    ///<summary>
    ///
    ///</summary>
    [SugarTable("GPT_Commodity")]
    public partial class GPT_Commodity
    {
        public GPT_Commodity()
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
        public int? Type { get; set; }

        [SugarColumn(IsNullable = true)]
        public int? Enable { get; set; }

        [SugarColumn(IsNullable = true)]
        public int? Discount { get; set; }

        /// <summary>
        /// Desc:
        /// Default:
        /// Nullable:True
        /// </summary>           
        [SugarColumn(IsNullable = true)]
        public string CommodityName { get; set; }

        [SugarColumn(IsNullable = true)]
        public int? CommodityOriginalPrice { get; set; }

        [SugarColumn(IsNullable = true)]
        public int? CommodityPresentPrice { get; set; }

        [SugarColumn(IsNullable = true)]
        public int? CommodityType { get; set; }

        [SugarColumn(IsNullable = true)]
        public int? Duration { get; set; }

        [SugarColumn(IsNullable = true)]
        public string Explain { get; set; }
        [SugarColumn(ColumnDataType = "decimal(18,2)",IsNullable = true)]
        public decimal? ShareCommission { get; set; }
        [SugarColumn(IsNullable = true)]
        public int? Sort { get; set; }

    }
}
