using ChatGPT_Mapper;
using ChatGPT_Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChatGPT_WebAPI.ChatHub
{
    public class ApiKeyCacheTime
    {
        public static async Task<string> GetApiKeyTime()
        {
            if (!MemoryCacheUtility.Exists("APIKEY"))
            {
                await UpdateApiKey();
            }
            //存在缓存
            var obj = MemoryCacheUtility.Get("APIKEY");
            List<CacheApiKeyTime> CacheList = ConvertToDesiredType(obj);
            CacheList = CacheList.OrderBy(x => x.i).ThenBy(x => x.DateTime).ToList();//排序
            string APIKEY = "";
            foreach (var item in CacheList)
            {
                if (item.i >= 3)
                {
                    //对时间的判断
                    DateTime dt = DateTime.Now;
                    if (item.DateTime.AddMinutes(1) > dt)
                    {
                        //不足一分
                        continue;
                    }
                    else
                    {
                        //足一分钟
                        APIKEY = item.APIKEY;
                        item.i = 1;
                        item.DateTime = dt;
                        break;
                    }
                }
                else
                {
                    //直接+1然后时间不动存储
                    APIKEY = item.APIKEY;
                    item.i = item.i + 1;
                    if (item.i == 1) 
                    {
                        item.DateTime = DateTime.Now;
                    }
                    break;
                }
            }
            MemoryCacheUtility.Set("APIKEY", CacheList);//更新/重新设置缓存
            return APIKEY;
        }
        public static async Task UpdateApiKey()
        {
            Mapper_GPT_KeyPool app = new Mapper_GPT_KeyPool();
            var list = await app.GetEnableListAsync();
            List<CacheApiKeyTime> CacheList = new List<CacheApiKeyTime>();
            MemoryCacheUtility.Remove("APIKEY");
            foreach (var item in list)
            {
                //缓存中不存在，直接添加进去
                CacheList.Add(new CacheApiKeyTime()
                {
                    APIKEY = item.ApiKey,
                });
            }
            MemoryCacheUtility.Set("APIKEY", CacheList);//更新/重新设置缓存
        }
        public static async Task RemvoCache(string APIKEY)
        {
            if (MemoryCacheUtility.Exists("APIKEY"))
            {
                //存在缓存
                var obj = MemoryCacheUtility.Get("APIKEY");
                List<CacheApiKeyTime> CacheList = ConvertToDesiredType(obj);
                CacheList.RemoveAll(i => i.APIKEY == APIKEY);//移除某个失效的APIKEY
                Mapper_GPT_KeyPool app = new Mapper_GPT_KeyPool();
                await app.UpdateToInvalid(new GPT_KeyPool()
                {
                    ApiKey = APIKEY
                });//修改数据库该APIKEY为不可用
                MemoryCacheUtility.Set("APIKEY", CacheList);//更新/重新设置缓存
            }
        }
        public class CacheApiKeyTime
        {
            public string APIKEY { get; set; }
            public int i { get; set; } = 0;
            public DateTime DateTime { get; set; } = DateTime.Parse("2000-01-01");
        }
        public static List<CacheApiKeyTime> ConvertToDesiredType(object list)
        {
            List<CacheApiKeyTime> returnList = new List<CacheApiKeyTime>();

            foreach (var item in (IEnumerable<dynamic>)list)
            {
                CacheApiKeyTime extract = new CacheApiKeyTime();
                extract.APIKEY = item.APIKEY;
                extract.i = item.i;
                extract.DateTime = item.DateTime;
                returnList.Add(extract);
            }

            return returnList;
        }
    }
}
