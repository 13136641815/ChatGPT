using ChatGPT_Mapper;
using ChatGPT_Model;
using Microsoft.AspNetCore.DataProtection.KeyManagement;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace ChatGPT_WebAPI.ChatHub
{
    public class APIKEY_Cache
    {
        public APIKEY_Cache()
        {

        }
        /// <summary>
        /// 从缓存中获取APIKEY，按调用次数，从小到大
        /// </summary>
        /// <returns></returns>
        public static async Task<string> GetAPIKEY_First()
        {
            if (!MemoryCacheUtility.Exists("APIKEY"))
            {
                await CacheUpdate();
            }
            //存在缓存
            var obj = MemoryCacheUtility.Get("APIKEY");
            List<ApiKeyCache> CacheList = ConvertToDesiredType(obj);
            CacheList = CacheList.OrderBy(x => x.i).ToList();//排序
            CacheList[0].i = CacheList[0].i + 1;//缓存数据++以便按规则拿去最小的
            MemoryCacheUtility.Set("APIKEY", CacheList);//更新/重新设置缓存
            return CacheList[0].APIKEY;
        }
        /// <summary>
        /// 更新APIKEY缓存
        /// </summary>
        /// <returns></returns>
        public static async Task CacheUpdate()
        {
            Mapper_GPT_KeyPool app = new Mapper_GPT_KeyPool();
            var list = await app.GetEnableListAsync();
            List<ApiKeyCache> CacheList = new List<ApiKeyCache>();
            MemoryCacheUtility.Remove("APIKEY");
            foreach (var item in list)
            {
                //缓存中不存在，直接添加进去
                CacheList.Add(new ApiKeyCache()
                {
                    APIKEY = item.ApiKey,
                });
            }
            MemoryCacheUtility.Set("APIKEY", CacheList);//更新/重新设置缓存
        }
        /// <summary>
        /// 
        /// </summary>
        public static async Task RemvoCache(string APIKEY)
        {
            if (MemoryCacheUtility.Exists("APIKEY"))
            {
                //存在缓存
                var obj = MemoryCacheUtility.Get("APIKEY");
                List<ApiKeyCache> CacheList = ConvertToDesiredType(obj);
                CacheList.RemoveAll(i => i.APIKEY == APIKEY);//移除某个失效的APIKEY
                Mapper_GPT_KeyPool app = new Mapper_GPT_KeyPool();
                await app.UpdateToInvalid(new GPT_KeyPool()
                {
                    ApiKey = APIKEY
                });//修改数据库该APIKEY为不可用
                MemoryCacheUtility.Set("APIKEY", CacheList);//更新/重新设置缓存
            }
        }
        public class ApiKeyCache
        {
            public string APIKEY { get; set; }
            public int i { get; set; } = 0;
        }
        public static List<ApiKeyCache> ConvertToDesiredType(object list)
        {
            List<ApiKeyCache> returnList = new List<ApiKeyCache>();

            foreach (var item in (IEnumerable<dynamic>)list)
            {
                ApiKeyCache extract = new ApiKeyCache();
                extract.APIKEY = item.APIKEY;
                extract.i = item.i;
                returnList.Add(extract);
            }

            return returnList;
        }
    }
}
