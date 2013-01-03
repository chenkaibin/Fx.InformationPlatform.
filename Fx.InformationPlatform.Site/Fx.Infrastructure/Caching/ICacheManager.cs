#region Copyright

//  Weapsy - http://www.weapsy.org
//  Copyright (c) 2011-2012 Luca Cammarata Briguglia
//  Licensed under the Weapsy Public License Version 1.0 (WPL-1.0)
//  A copy of this license may be found at http://www.weapsy.org/Documentation/License.txt

#endregion

using System;
using System.Collections.Generic;
using System.Web.Caching;

namespace Fx.Infrastructure.Caching
{
    /// <summary>
    /// 本地LocalCache接口
    /// </summary>
	public interface ICacheManager
	{
        /// <summary>
        /// 插入缓存
        /// </summary>
        /// <param name="Key">缓存Key</param>
        /// <param name="Obj">缓存Value</param>
        /// <param name="TimeOut">缓存有效时间</param>
        /// <param name="Priority">缓存优先级</param>
        void Insert(string Key, object Obj, double TimeOut, CacheItemPriority Priority);

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
        void Insert(string Key, object Obj, CacheDependency Dependency, double TimeOut, TimeSpan SlidingExpiration, CacheItemPriority Priority, CacheItemRemovedCallback RemovedCallback);
        
        /// <summary>
        /// 根据Key获取缓存
        /// </summary>
        /// <param name="Key">缓存Key</param>
        /// <returns>缓存Value</returns>
        object Get(string Key);

        /// <summary>
        /// 根据Key删除缓存
        /// </summary>
        /// <param name="Key">缓存Key</param>
        void Remove(string Key);

        /// <summary>
        /// 根据正则表达式删除缓存
        /// </summary>
        /// <param name="pattern">移除的正则表达式</param>
        void RemoveByPattern(string pattern);

        /// <summary>
        /// 清除缓存
        /// </summary>
        void Clear();

        /// <summary>
        /// 获取缓存的缓存优先级信息
        /// </summary>
        /// <returns>优先级信息</returns>
        Dictionary<byte, string> CacheItemPriorities();
	}

}