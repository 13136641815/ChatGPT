using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatGPT_Model.Tencent
{
    public class QRCodeCreate
    {
        public string action_name { get; set; } = "QR_LIMIT_STR_SCENE";
        public action_info action_info { get; set; }
    }
    public class action_info
    {
        public scene scene { get; set; }
    }
    public class scene
    {
        public string scene_str { get; set; }//openid
    }
}
