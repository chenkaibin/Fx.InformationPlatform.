using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Fx.Domain.Base.IService
{
    /// <summary>
    /// 首页的信息接口
    /// </summary>
    /// <typeparam name="T">查询返回类型</typeparam>
    public interface IHomeSearch<T> where T : class
    {
        /// <summary>
        /// 获取首页最新信息
        /// </summary>
        /// <param name="count"></param>
        /// <returns></returns>
        List<T> SearchLatestForHome(int count);

        /// <summary>
        ///  获取最热门的信息 没有实现 取消此功能 later imp
        /// </summary>
        /// <param name="count"></param>
        /// <returns></returns>
        List<T> SearchHottestForHome(int count);
    }
}
