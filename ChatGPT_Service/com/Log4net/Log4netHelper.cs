using log4net;
using log4net.Config;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using SYSTEM_Extend.log4net;
using SYSTEM_Models;

namespace WeChat.Com.Log4net
{
    public class Log4netHelper
    {
        public static readonly Log4netHelper Instance = new Log4netHelper();
        public Log4netHelper()
        {
            string text = "";
            //《Log4Net.config》所在位置
            text = System.AppDomain.CurrentDomain.BaseDirectory + "Config/Log4Net.config";
            XmlConfigurator.ConfigureAndWatch(new FileInfo(text));
        }
        //《Log4Net.config》中《logger》属性的Name值
        private static readonly log4net.ILog loginfo = log4net.LogManager.GetLogger("loginfo");
        private static readonly log4net.ILog logerror = log4net.LogManager.GetLogger("logerror");
        private static sys_Log4net _message = null;
        private static log4net.ILog _log;
        public static log4net.ILog Log
        {
            get
            {
                if (_log == null)
                {
                    _log = LogManager.GetLogger("OperateLogger");
                }
                return _log;
            }
        }
        /// <summary>
        /// 调用log4写日志
        /// </summary>
        /// <param name="model">日志实体</param>
        /// <param name="Number">级别索引</param>
        public static void WirteLog4net(sys_Log4net model, int Number) 
        {
            //参数根据自定义类中字段值决定
            _message = model;
            switch (Number)
            {
                case 1: Info(); break;
                case 2: Warn(); break;
                case 3: Error(); break;
                case 4: Fatal(); break;
                default: break;
            }
        }
        #region 方法组
        private static void Debug()
        {
            if (Log.IsDebugEnabled)
            {
                Log.Debug(_message);
            }
        }
        private static void Error()
        {
            if (logerror.IsErrorEnabled)
            {
                logerror.Error(_message);
            }
        }
        private static void Fatal()
        {
            if (Log.IsFatalEnabled)
            {
                Log.Fatal(_message);
            }
        }
        private static void Info()
        {
            if (loginfo.IsInfoEnabled)
            {
                loginfo.Info(_message);
            }
        }
        private static void Warn()
        {
            try
            {
                if (Log.IsWarnEnabled)
                {
                    Log.Warn(_message);
                }
            }
            catch (Exception e)
            {
                var t = e;
            }
        }
        #endregion
    }
}
