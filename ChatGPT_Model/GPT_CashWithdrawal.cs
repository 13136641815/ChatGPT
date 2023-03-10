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

        /// <summary>
        /// Desc:
        /// Default:
        /// Nullable:True
        /// </summary>           
        public DateTime? Stamp { get; set; } = DateTime.Now;

        /// <summary>
        /// Desc:
        /// Default:
        /// Nullable:True
        /// </summary>           
        public int? State { get; set; }
        public string NikeName { get; set; }
        public string Opneid { get; set; }
        public string AccountType { get; set; }
        public string AccountNum { get; set; }
        public int ZBS { get; set; }
        public decimal ZJE { get; set; }
    }
}
