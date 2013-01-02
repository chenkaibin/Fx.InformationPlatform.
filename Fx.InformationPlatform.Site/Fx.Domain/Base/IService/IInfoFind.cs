using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Fx.Domain.Base.IService
{
    /// <summary>
    /// 帖子状态查询接口 未使用
    /// </summary>
    public interface IInfoFind<T> where T : class
    {
       /// <summary>
        /// 查询审核中的信息
       /// </summary>
       /// <param name="user"></param>
       /// <returns></returns>
        List<T> FindCommitInfo(string user);

        /// <summary>
        /// 查询已发布的信息
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        List<T> FindPublishInfo(string user);

        /// <summary>
        /// 查询已成交的信息
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        List<T> FindEndInfo(string user);

        /// <summary>
        /// 查询置顶的信息
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        List<T> FindTopInfo(string user);
    }
}
