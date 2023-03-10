using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatGPT_Model.GPT3_5
{
    public class StreamRespose
    {
        /// <summary>
        /// 
        /// </summary>
        public string id { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string object1 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int created { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string model { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<Choices> choices { get; set; }
    }
    public class Delta
    {
        /// <summary>
        /// 
        /// </summary>
        public string role { get; set; }
        public string content { get; set; }
    }

    public class Choices
    {
        /// <summary>
        /// 
        /// </summary>
        public Delta delta { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int index { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string finish_reason { get; set; }
    }
    public class ErrorBody
    {
        public Error error { get; set; }
    }
    public class Error
    {
        public string message { get; set; }
        public string type { get; set; }
        public string param { get; set; }
        public string code { get; set; }
    }
}
