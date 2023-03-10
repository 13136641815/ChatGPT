using ChatGPT_Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChatGPT_Wx.Tools
{
    /// <summary>
    /// 关键字过滤
    /// </summary>
    public class WordSearch
    {
        private Dictionary<char, IList<string>> keyDict;
        public WordSearch()
        {
            if (keyDict == null || keyDict.Count == 0)
            {
                //从缓存中获取，赋值
                if (MemoryCacheUtility.Exists("WordSearch"))
                {
                    var obj = MemoryCacheUtility.Get("WordSearch");
                    List<GPT_SensitiveWords> keyList = ConvertToDesiredType(obj);
                    HandleKeyWords(keyList);
                }
                else
                {
                    //缓存中不存在，从数据库读取赋值，存入缓存
                    ChatGPT_Mapper.Mapper_GPT_SensitiveWords app = new ChatGPT_Mapper.Mapper_GPT_SensitiveWords();
                    var list = app.GetListAll();
                    TimeSpan ts0 = new TimeSpan(0, 10, 00);//10分钟滑动过期
                    TimeSpan ts1 = new TimeSpan(1, 00, 00);//1小时绝对过期
                    MemoryCacheUtility.Set("WordSearch", list, ts0, ts1);
                    HandleKeyWords(list);
                }
            }
        }

        private void HandleKeyWords(List<GPT_SensitiveWords> text)
        {
            if (text.Count == 0)
            {
                keyDict = new Dictionary<char, IList<string>>();
            }
            else
            {
                keyDict = new Dictionary<char, IList<string>>(text.Count / 4);
                foreach (var item in text)
                {
                    if (item.Text == "")
                    {
                        continue;
                    }
                    if (keyDict.ContainsKey(item.Text[0]))
                    {
                        keyDict[item.Text[0]].Add(item.Text);
                    }
                    else
                    {
                        keyDict.Add(item.Text[0], new List<string> { item.Text });
                    }
                }
            }
        }

        public bool Filter(string str)
        {
            if (string.IsNullOrEmpty(str))
            {
                return true;
            }
            int len = str.Length;
            StringBuilder sb = new StringBuilder(len);
            bool isOK = true;
            for (int i = 0; i < len; i++)
            {
                if (keyDict.ContainsKey(str[i]))
                {
                    foreach (string s in keyDict[str[i]])
                    {
                        isOK = true;
                        int j = i;
                        foreach (char c in s)
                        {
                            if (j >= len || c != str[j++])
                            {
                                isOK = false;
                                break;
                            }
                        }
                        if (isOK)
                        {
                            //i += s.Length - 1;
                            //sb.Append('*', s.Length);
                            //break;
                            return false;
                        }

                    }
                    if (!isOK)
                    {
                        sb.Append(str[i]);
                    }
                }
                else
                {
                    sb.Append(str[i]);
                }
            }
            return true;
        }
        public List<GPT_SensitiveWords> ConvertToDesiredType(object list)
        {
            List<GPT_SensitiveWords> returnList = new List<GPT_SensitiveWords>();

            foreach (var item in (IEnumerable<dynamic>)list)
            {
                GPT_SensitiveWords extract = new GPT_SensitiveWords();
                extract.Text = item.Text;
                returnList.Add(extract);
            }

            return returnList;
        }

    }
}
