using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SYSTEM_Models
{
    [SplitTable(SplitType.Month)]//按年分表 （自带分表支持 年、季、月、周、日）
    [SugarTable("sys_Log4net_{year}_{month}_{day}")]//生成表名格式 3个变量必须要有
    public class sys_Log4net
    {
        /// <summary>
        /// ID自增
        /// </summary>
        [SugarColumn(IsPrimaryKey = true)]//数据库是自增才配自增 
        public long id { get; set; }
        /// <summary>
        /// 数据库默认时间
        /// </summary>
        public DateTime? Stamp { get; set; } = DateTime.Now;
        /// <summary>
        /// 日志系统输出时间
        /// </summary>
        [SplitField]
        public DateTime LogTime { get; set; }
        /// <summary>
        /// 系统名称
        /// </summary>
        public string SystemName { get; set; } = "";
        /// <summary>
        /// 系统代码
        /// </summary>
        public string SystemCode { get; set; } = "";
        /// <summary>
        /// 日志等级
        /// </summary>
        public int LogLevelCode { get; set; }
        /// <summary>
        /// 日志等级
        /// </summary>
        public string LogLevelName { get; set; }
        /// <summary>
        /// 请求路径
        /// </summary>
        public string Path { get; set; }
        /// <summary>
        /// 请求类型
        /// </summary>
        public string Method { get; set; }
        /// <summary>
        /// 请求参数
        /// </summary>
        [SugarColumn(ColumnDataType = "ntext,TEXT")]
        public string RequestParams { get; set; } = "";
        /// <summary>
        /// 响应参数
        /// </summary>
        [SugarColumn(ColumnDataType = "ntext,TEXT")]
        public string ResponseParams { get; set; } = "";
        /// <summary>
        /// 日志内容
        /// </summary>
        [SugarColumn(ColumnDataType = "ntext,TEXT")]
        public string LogBody { get; set; } = "";
        /// <summary>
        /// 错误信息
        /// </summary>
        [SugarColumn(ColumnDataType = "ntext,TEXT")]
        public string Error { get; set; } = "";
        /// <summary>
        /// 当前登录名
        /// </summary>
        public string userlogin { get; set; } = "";
        /// <summary>
        /// 当前用户姓名
        /// </summary>
        public string userName { get; set; } = "";
        /// <summary>
        /// 客户端IP地址
        /// </summary>
        public string ip_Address { get; set; } = "";
        /// <summary>
        /// Cookies全部参数
        /// </summary>
        [SugarColumn(ColumnDataType = "ntext,TEXT")]
        public string CookiesAll { get; set; } = "";
    }
}
