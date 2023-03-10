using log4net.Layout;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeChat.Com.Log4net
{
    public class ActionLayoutPattern : PatternLayout
    {
        public ActionLayoutPattern()
        {
            // 1.《actionInfo》为《Log4Net.config》中自定义取值的参数前置
            // 2.《ActionConverter》为《actionInfo》里的内置参数。
            this.AddConverter("LogModel", typeof(ActionConverter));
        }
    }
}
