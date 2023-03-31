using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatGPT_Model.GPTDraw
{
    public class DrawResModel
    {
        public string DrawModel { get; set; }
        public List<Url> data { get; set; }

    }
    public class Url
    {
        public string url { get; set; }
    }
}
