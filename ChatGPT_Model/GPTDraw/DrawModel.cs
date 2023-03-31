using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatGPT_Model.GPTDraw
{
    public class DrawModel
    {
        public string prompt { get; set; }
        public int n { get; set; }
        public string size { get; set; } = "1024x1024";
    }
}
