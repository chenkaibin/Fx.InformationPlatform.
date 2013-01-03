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
    /// ����ʵ����
    /// </summary>
	public class CacheManager : ICacheManager
	{
        /// <summary>
        /// ���뻺��
        /// </summary>
        /// <param name="Key">����Key</param>
        /// <param name="Obj">����Value</param>
        /// <param name="TimeOut">������Чʱ��</param>
        /// <param name="Priority">�������ȼ�</param>
        public void Insert(string Key, object Obj, double TimeOut, CacheItemPriority Priority)
		{
            Insert(Key, Obj, null, TimeOut, TimeSpan.Zero, Priority, null);
		}

        /// <summary>
        /// ���뻺��
        /// </summary>
        /// <param name="Key">����Key</param>
        /// <param name="Obj">����Value</param>
        /// <param name="Dependency">��������</param>
        /// <param name="TimeOut">������Чʱ��</param>
        /// <param name="SlidingExpiration">���ʱ��</param>
        /// <param name="Priority">�������ȼ�</param>
        /// <param name="RemovedCallback">ɾ���ص�����</param>
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
        /// ����Key��ȡ����
        /// </summary>
        /// <param name="Key">����Key</param>
        /// <returns>����Value</returns>
		public object Get(string Key)
		{
			Cache Cache = HttpRuntime.Cache;
			return Cache[Key];
		}

        /// <summary>
        /// ����Keyɾ������
        /// </summary>
        /// <param name="Key">����Key</param>
        public void Remove(string Key)
		{
			Cache Cache = HttpRuntime.Cache;
			if (Cache[Key] != null) {
				Cache.Remove(Key);
			}
		}

        /// <summary>
        /// ����������ʽɾ������
        /// </summary>
        /// <param name="pattern">�Ƴ���������ʽ</param>
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
        /// �������
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
        /// ��ȡ����Ļ������ȼ���Ϣ
        /// </summary>
        /// <returns>���ȼ���Ϣ</returns>
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