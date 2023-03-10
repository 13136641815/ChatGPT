using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace ChatGPT_Model.AppModel.User
{
    public class BillViewModel
    {         
        public int ID { get; set; }
      
        public DateTime? Stamp { get; set; } = DateTime.Now;
    
        public int? UID { get; set; }
        public string NikeName { get; set; }

        public string Channel { get; set; }
       
        public string OrderNumber { get; set; }
        
        public int? UserID { get; set; }
         
        public decimal? OrderAmountYuan { get; set; }
       
        public int? OrderAmountFen { get; set; }
        public string CommodityName { get; set; }
        public int? Duration { get; set; }
    }
}
