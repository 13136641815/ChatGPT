using log4net.Core;
using log4net.Layout.Pattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeChat.Com.Log4net
{
    public class ActionConverter : PatternLayoutConverter
    {
        protected override void Convert(System.IO.TextWriter writer, LoggingEvent loggingEvent)
        {
            var LogModel = loggingEvent.MessageObject as SYSTEM_Models.sys_Log4net;

            if (LogModel == null)
            {
                writer.Write("");
            }
            else
            {
                // 1.以下值数量根据《LogClass.cs》参数设定
                // 2.参数名自定义；与《Log4Net.config》中相呼应
                switch (this.Option)
                {
                    case "LogTime":
                        writer.Write(LogModel.LogTime);
                        break;
                    case "LogLevelName":
                        writer.Write(LogModel.LogLevelName);
                        break;
                    case "SystemName":
                        writer.Write(LogModel.SystemName);
                        break;
                    case "Path":
                        writer.Write(LogModel.Path);
                        break;
                    case "Method":
                        writer.Write(LogModel.Method);
                        break;
                    case "RequestParams":
                        writer.Write(LogModel.RequestParams);
                        break;
                    case "ResponseParams":
                        writer.Write(LogModel.ResponseParams);
                        break;
                    case "LogBody":
                        writer.Write(LogModel.LogBody);
                        break;
                    case "Error":
                        writer.Write(LogModel.Error);
                        break;
                    case "CookiesAll":
                        writer.Write(LogModel.CookiesAll);
                        break;
                    default:
                        writer.Write("");
                        break;
                }
            }
        }
    }
}
