using System;
using System.Globalization;
using System.Text.RegularExpressions;

namespace SYSTEM_Extend.AES
{
    public class AES
    {
        #region 生成随机字符
        /// <summary>
        /// 生成随机字符
        /// </summary>
        /// <param name="length">字符长度</param>
        /// <param name="isSleep">是否要在生成前将当前线程阻止以避免重复</param>
        /// <param name="type">字符类型"num":数字类型；"str":纯字母；为空或者其他时，是数字和字母混合随机数</param>
        /// <returns>随机字符组成的字符串</returns>
        public static string Chars(int length = 32, bool isSleep = true, string type = "")
        {
            if (isSleep) System.Threading.Thread.Sleep(3);

            char[] chars = new char[] { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' };
            string result = "";
            //  给一个时间种子，防止重复
            Random random = new Random(~unchecked((int)DateTime.Now.Ticks));
            if (type == "num")
            {
                //  生成纯数字随机数
                for (int i = 0; i < length; i++)
                {
                    int rnd = random.Next(10);
                    result += chars[rnd];
                }
            }
            else if (type == "str")
            {
                //   纯字母随机数
                int rnd = random.Next(11, 36);
                result += chars[rnd];
            }
            else
            {
                //  数字字符混合随机数
                for (int i = 0; i < length; i++)
                {
                    int rnd = random.Next(36);
                    result += chars[rnd];
                }
            }
            return result;
        }
        #endregion
    }
}
