using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SYSTEM_Extend.log4net
{
    public static class LogType
    {
        //DEBUG Level指出细粒度信息事件对调试应用程序是非常有帮助的。
        public static class DEBUG
        {
            public static int Code { get; } = 0;
            public static string Name { get; } = "调试";

        };
        //INFO level表明 消息在粗粒度级别上突出强调应用程序的运行过程。
        public static class INFO
        {
            public static int Code { get; } = 1;
            public static string Name { get; } = "监控请求";

        };
        //WARN level表明会出现潜在错误的情形。
        public static class WARN
        {
            public static int Code { get; } = 2;
            public static string Name { get; } = "主动记录";

        };
        //ERROR level指出虽然发生错误事件，但仍然不影响系统的继续运行。
        public static class ERROR
        {
            public static int Code { get; } = 3;
            public static string Name { get; } = "捕获异常";

        };
        //FATAL level指出每个严重的错误事件将会导致应用程序的退出。
        public static class FATAL
        {
            public static int Code { get; } = 4;
            public static string Name { get; } = "崩溃";

        };
        public static class UltraVires 
        {
            public static int Code { get; } = 5;
            public static string Name { get; } = "越权拦截";
        };


    }
}
