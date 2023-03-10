using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatGPT_Model.AppModel
{
    public class PageParams
    {
        /// <summary>
        /// 当前第几页
        /// </summary>
        public int PageNum { get; set; }
        /// <summary>
        /// 页面尺寸
        /// </summary>
        public int PageSize { get; set; }
    }
    public class ResultPage
    {
        public int DATACOUNT { get; set; }
        public object DATASUM { get; set; }
        public object DATA { get; set; }
    }
}
