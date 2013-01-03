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
    /// ����LocalCache�ӿ�
    /// </summary>
	public interface ICacheManager
	{
        /// <summary>
        /// ���뻺��
        /// </summary>
        /// <param name="Key">����Key</param>
        /// <param name="Obj">����Value</param>
        /// <param name="TimeOut">������Чʱ��</param>
        /// <param name="Priority">�������ȼ�</param>
        void Insert(string Key, object Obj, double TimeOut, CacheItemPriority Priority);

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
        void Insert(string Key, object Obj, CacheDependency Dependency, double TimeOut, TimeSpan SlidingExpiration, CacheItemPriority Priority, CacheItemRemovedCallback RemovedCallback);
        
        /// <summary>
        /// ����Key��ȡ����
        /// </summary>
        /// <param name="Key">����Key</param>
        /// <returns>����Value</returns>
        object Get(string Key);

        /// <summary>
        /// ����Keyɾ������
        /// </summary>
        /// <param name="Key">����Key</param>
        void Remove(string Key);

        /// <summary>
        /// ����������ʽɾ������
        /// </summary>
        /// <param name="pattern">�Ƴ���������ʽ</param>
        void RemoveByPattern(string pattern);

        /// <summary>
        /// �������
        /// </summary>
        void Clear();

        /// <summary>
        /// ��ȡ����Ļ������ȼ���Ϣ
        /// </summary>
        /// <returns>���ȼ���Ϣ</returns>
        Dictionary<byte, string> CacheItemPriorities();
	}

}