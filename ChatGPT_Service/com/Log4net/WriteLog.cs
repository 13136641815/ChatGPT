using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SYSTEM_Extend.log4net;

namespace HitAir_PayService.com.Log4net
{
    public class WriteLog
    {
        /// <summary>
        /// 记录日志
        /// </summary>
        /// <param name="ActionName">执行事件</param>
        /// <param name="Content">内容</param>
        public static void WriteINFO(string ActionName, string Content)
        {
            SYSTEM_Models.sys_Log4net modelLog4 = new SYSTEM_Models.sys_Log4net()
            {
                LogTime = DateTime.Now,
                SystemName = "空调充值回写服务",
                SystemCode = "HitAir_PayService",
                Path = "",
                Method = ActionName,
                RequestParams = Content,
                ResponseParams = "",
                LogLevelCode = LogType.INFO.Code,
                LogLevelName = LogType.INFO.Name,
                ip_Address = "",
                Error = "",
                CookiesAll = ""
            };

            WeChat.Com.Log4net.Log4netHelper.WirteLog4net(modelLog4, LogType.INFO.Code);
        }
        /// <summary>
        /// 日志记录异常
        /// </summary>
        /// <param name="ActionName">异常事件名</param>
        /// <param name="ErrorMsg">错误信息</param>
        public static void WriteERROR(string ActionName,string ErrorMsg)
        {
            SYSTEM_Models.sys_Log4net modelLog4 = new SYSTEM_Models.sys_Log4net()
            {
                LogTime = DateTime.Now,
                SystemName = "空调充值回写服务",
                SystemCode = "HitAir_PayService",
                Path = "",
                Method = ActionName,
                RequestParams = "",
                ResponseParams = "",
                LogLevelCode = LogType.ERROR.Code,
                LogLevelName = LogType.ERROR.Name,
                ip_Address = "",
                Error = ErrorMsg,
                CookiesAll = ""
            };
            WeChat.Com.Log4net.Log4netHelper.WirteLog4net(modelLog4, LogType.ERROR.Code);
        }
    }
}
