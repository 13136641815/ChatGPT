using System.Collections.Generic;

namespace ChatGPT_Model.AppModel
{
    public class TalkModel
    {
        public string prompt { get; set; }
        public List<Question> history { get; set; }
    }
}
