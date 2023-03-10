using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatGPT_Service.ChatGPT
{
    public class body
    {
        public string model { get; set; } = "text-davinci-003";
        public string prompt { get; set; } = "{\"prompt\":\"我们玩个游戏吧\",\"history\":[{\"question\":\"你好\",\"answer\":\"你好！很高兴认识你！\"}]}}";
        public double temperature { get; set; } = 0;
        public int max_tokens { get; set; } = 100;
    }
}
