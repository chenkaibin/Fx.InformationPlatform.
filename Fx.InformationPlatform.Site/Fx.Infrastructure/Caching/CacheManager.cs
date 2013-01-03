using System;
using System.Collections.Generic;
using System.Web;
using System.Runtime.CompilerServices;
using System.Web.Caching;
using System.Collections;
using System.Text.RegularExpressions;

namespace Fx.Infrastructure.Caching
{
    /// <summary>
    /// 缓存实现类
    /// </summary>
	public class CacheManager : ICacheManager
	{
        /// <summary>
        /// 插入缓存
        /// </summary>
        /// <param name="Key">缓存Key</param>
        /// <param name="Obj">缓存Value</param>
        /// <param name="TimeOut">缓存有效时间</param>
        /// <param name="Priority">缓存优先级</param>
        public void Insert(string Key, object Obj, double TimeOut, CacheItemPriority Priority)
		{
            Insert(Key, Obj, null, TimeOut, TimeSpan.Zero, Priority, null);
		}

        /// <summary>
        /// 插入缓存
        /// </summary>
        /// <param name="Key">缓存Key</param>
        /// <param name="Obj">缓存Value</param>
        /// <param name="Dependency">缓存依赖</param>
        /// <param name="TimeOut">缓存有效时间</param>
        /// <param name="SlidingExpiration">间隔时间</param>
        /// <param name="Priority">缓存优先级</param>
        /// <param name="RemovedCallback">删除回调函数</param>
		public void Insert(string Key, object Obj, CacheDependency Dependency, double TimeOut, TimeSpan SlidingExpiration, CacheItemPriority Priority, CacheItemRemovedCallback RemovedCallback)
		{
			if ((Obj != null)) {
				Cache Cache = HttpRuntime.Cache;
				if (Cache [Key] == null) {
					Cache.Insert(Key, RuntimeHelpers.GetObjectValue(Obj), Dependency, DateTime.Now.AddSeconds(TimeOut), SlidingExpiration, Priority, RemovedCallback);
				}
			}
		}

        /// <summary>
        /// 根据Key获取缓存
        /// </summary>
        /// <param name="Key">缓存Key</param>
        /// <returns>缓存Value</returns>
		public object Get(string Key)
		{
			Cache Cache = HttpRuntime.Cache;
			return Cache[Key];
		}

        /// <summary>
        /// 根据Key删除缓存
        /// </summary>
        /// <param name="Key">缓存Key</param>
        public void Remove(string Key)
		{
			Cache Cache = HttpRuntime.Cache;
			if (Cache[Key] != null) {
				Cache.Remove(Key);
			}
		}

        /// <summary>
        /// 根据正则表达式删除缓存
        /// </summary>
        /// <param name="pattern">移除的正则表达式</param>
		public void RemoveByPattern(string pattern)
		{
			Cache Cache = HttpRuntime.Cache;
			IDictionaryEnumerator enumerator = Cache.GetEnumerator();
			Regex rgx = new Regex(pattern, (RegexOptions.Singleline | (RegexOptions.Compiled | RegexOptions.IgnoreCase)));
			while (enumerator.MoveNext()) {
				if (rgx.IsMatch(enumerator.Key.ToString())) {
					Cache.Remove(enumerator.Key.ToString());
				}
			}
		}

        /// <summary>
        /// 清除缓存
        /// </summary>
        public void Clear()
        {
            Cache Cache = HttpRuntime.Cache;
            IDictionaryEnumerator enumerator = Cache.GetEnumerator();
            while (enumerator.MoveNext())
            {
                Cache.Remove(enumerator.Key.ToString());
            }
        }

        /// <summary>
        /// 获取缓存的缓存优先级信息
        /// </summary>
        /// <returns>优先级信息</returns>
        public Dictionary<byte, string> CacheItemPriorities()
        {
            Dictionary<byte, string> dic = new Dictionary<byte, string>();
            dic.Add((byte)CacheItemPriority.Low, CacheItemPriority.Low.ToString());
            dic.Add((byte)CacheItemPriority.BelowNormal, CacheItemPriority.BelowNormal.ToString());
            dic.Add((byte)CacheItemPriority.Normal, CacheItemPriority.Normal.ToString());
            dic.Add((byte)CacheItemPriority.AboveNormal, CacheItemPriority.AboveNormal.ToString());
            dic.Add((byte)CacheItemPriority.High, CacheItemPriority.High.ToString());
            dic.Add((byte)CacheItemPriority.NotRemovable, CacheItemPriority.NotRemovable.ToString());
            return dic;
        }
	}

}