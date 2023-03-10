using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace ChatGPT_Model.GPT3_5
{
    public class Body
    {
        public string model { get; } = "gpt-3.5-turbo";
        public List<Messages> messages { get; set; }
        public double temperature { get; set; } = 0;
        public int max_tokens { get; set; } = 2048;
        public bool stream { get; set; } = true;
        public int top_p { get; set; } = 1;
        public double presence_penalty { get; set; } = 0.0;
    }
}
