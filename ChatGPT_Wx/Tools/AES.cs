using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace ChatGPT_Wx.Tools
{
    public class AES
    {
        static string staticKey { get; } = "o2wqbf57ozcvpjlqotl85hhl5065ugm0";
        /// <summary>
        /// 获取动态AES密钥
        /// </summary>
        /// <returns></returns>
        public static string GetAesKey()
        {
            //return StrRandom(32).ToLower();
            return staticKey;
        }
        public static string staticKeyTo_EncryptAES(string input)
        {

            return EncryptAES(input, staticKey);
        }
        public static string staticKeyTo_DecryptAES(string input)
        {
            return DecryptAES(input, staticKey);
        }
        /// <summary>
        /// 生成随机字母与数字
        /// </summary>
        /// <param name="Length">生成长度</param>
        /// <param name="Sleep">是否要在生成前将当前线程阻止以避免重复</param>
        /// <returns></returns>
        private static string StrRandom(int Length)
        {
            if (true) System.Threading.Thread.Sleep(3);
            char[] Pattern = new char[] { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' };
            string result = "";
            int n = Pattern.Length;
            System.Random random = new Random(~unchecked((int)DateTime.Now.Ticks));
            for (int i = 0; i < Length; i++)
            {
                int rnd = random.Next(0, n);
                result += Pattern[rnd];
            }
            return result;
        }
        /// <summary>  
        /// AES加密字符串  
        /// </summary>  
        /// <param name="encryptString">待加密的字符串</param>  
        /// <param name="encryptKey">加密密钥,要求为16位</param>  
        /// <returns>加密成功返回加密后的字符串，失败返回源串</returns>  
        public static string EncryptAES(string encryptString, string key)
        {
            byte[] rgbKey = Encoding.UTF8.GetBytes(key);
            //用于对称算法的初始化向量（默认值）。  
            byte[] rgbIV = { 0x00, 0x01, 0x02, 0x03, 0x04, 0x05, 0x06, 0x07, 0x08, 0x09, 0x0A, 0x0B, 0x0C, 0x0D, 0x0E, 0x0F };
            byte[] inputByteArray = Encoding.UTF8.GetBytes(encryptString);
            Aes dCSP = Aes.Create();

            MemoryStream mStream = new MemoryStream();
            CryptoStream cStream = new CryptoStream(mStream, dCSP.CreateEncryptor(rgbKey, rgbIV), CryptoStreamMode.Write);
            cStream.Write(inputByteArray, 0, inputByteArray.Length);
            cStream.FlushFinalBlock();
            return Convert.ToBase64String(mStream.ToArray());
        }

        /// <summary>  
        /// AES解密字符串  
        /// </summary>  
        /// <param name="decryptString">待解密的字符串</param>  
        /// <param name="key">解密密钥，要求16位</param>  
        /// <returns></returns>  
        public static string DecryptAES(string decryptString, string key)
        {
            //用于对称算法的初始化向量（默认值）  
            byte[] Keys = { 0x00, 0x01, 0x02, 0x03, 0x04, 0x05, 0x06, 0x07, 0x08, 0x09, 0x0A, 0x0B, 0x0C, 0x0D, 0x0E, 0x0F };
            byte[] rgbKey = Encoding.UTF8.GetBytes(key);
            byte[] rgbIV = Keys;
            byte[] inputByteArray = Convert.FromBase64String(decryptString);
            Aes DCSP = Aes.Create();

            MemoryStream mStream = new MemoryStream();
            CryptoStream cStream = new CryptoStream(mStream, DCSP.CreateDecryptor(rgbKey, rgbIV), CryptoStreamMode.Write);
            cStream.Write(inputByteArray, 0, inputByteArray.Length);
            cStream.FlushFinalBlock();
            return Encoding.UTF8.GetString(mStream.ToArray());
        }
    }
}
