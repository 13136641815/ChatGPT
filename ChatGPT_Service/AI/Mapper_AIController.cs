using ChatGPT_Mapper;
using ChatGPT_Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatGPT_Service.AI
{
    public class Mapper_AIController
    {
        public async Task<GPT_User> GetModelFirstAsync(string Openid)
        {
            Mapper_GPT_User app = new Mapper_GPT_User();
            var FirstModel = await app.GetModelFirstAsync(Openid);
            return FirstModel;
        }
    }
}
