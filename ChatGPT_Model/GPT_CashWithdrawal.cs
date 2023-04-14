using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatGPT_Model
{
    [SugarTable("GPT_CashWithdrawal")]
    public partial class GPT_CashWithdrawal
    {
        public GPT_CashWithdrawal()
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
        [SugarColumn(IsNullable = true)]
        public string NikeName { get; set; }
        [SugarColumn(IsNullable = true)]
        public string Opneid { get; set; }
        [SugarColumn(IsNullable = true)]
        public string AccountType { get; set; }
        [SugarColumn(IsNullable = true)]
        public string AccountNum { get; set; }
        public int? ZBS { get; set; }
        [SugarColumn(ColumnDataType = "decimal(18,2)",IsNullable = true)]
        public decimal? ZJE { get; set; }
    }
}
