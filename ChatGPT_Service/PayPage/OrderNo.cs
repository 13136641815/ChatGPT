using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatGPT_Service.PayPage
{
    public class OrderNo
    {
        private static readonly object _lock = new object();
        private static Dictionary<string, List<int>> _dic = new Dictionary<string, List<int>>();
        private static long _num;
        /// <summary>
        /// 生成唯一平台订单号
        /// </summary>
        /// <returns></returns>
        public static string GeneratOrderNo()
        {
            lock (_lock)
            {
                TimeSpan timespan = DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, 0);
                string timeStamp = Convert.ToInt64(timespan.TotalSeconds).ToString();

                //若时间戳 + 随机数重复, 重新生成随机数
                string nonce = GenerateNonce(timeStamp);
                return "WXH5" + DateTime.Now.ToString("yyyy") + timeStamp + nonce;
            }
        }

        /// <summary>
        /// 生成不重复的四位随机数（同一时间戳下不允许重复）
        /// </summary>
        /// <param name="timeStamp">10位时间戳</param>
        /// <returns></returns>
        private static string GenerateNonce(string timeStamp)
        {
            Random random = new Random();
            int nonce = random.Next(1000, 9999);

            if (_dic.TryGetValue(timeStamp, out List<int> value))
            {
                //重新获取随机数
                if (value.Contains(nonce))
                {
                    return GenerateNonce(timeStamp);
                }
                else
                {
                    value.Add(nonce);
                    _dic.Remove(timeStamp);
                    _dic.Add(timeStamp, value);
                }
            }
            else
            {
                _dic.Clear();
                _dic.Add(timeStamp, new List<int> { nonce });
            }
            return nonce.ToString();
        }
    }
}
