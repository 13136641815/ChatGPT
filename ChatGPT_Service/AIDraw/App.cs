using ChatGPT_Mapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatGPT_Service.AIDraw
{
    public class App
    {
        /// <summary>
        /// 获取本月剩余免费次数
        /// </summary>
        /// <param name="OpenID"></param>
        /// <returns></returns>
        public async Task<int> GetThisMonthsCount(string OpenID)
        {
            DateTime today = DateTime.Today;
            DateTime firstDayOfMonth = new DateTime(today.Year, today.Month, 1);
            DateTime lastDayOfMonth = firstDayOfMonth.AddMonths(1).AddDays(-1).AddHours(23).AddMinutes(59);
            Mapper_GPT_ChatLog app = new Mapper_GPT_ChatLog();
            var list = await app.GetListFromMonth(firstDayOfMonth, lastDayOfMonth, OpenID);
            Mapper_GPT_Setup setApp = new Mapper_GPT_Setup();
            var setModel = await setApp.GetFirstAsync();
            int Draw_Second = int.Parse(setModel.Draw_Second.ToString());
            return Draw_Second - list.Count;
        }
    }
}
