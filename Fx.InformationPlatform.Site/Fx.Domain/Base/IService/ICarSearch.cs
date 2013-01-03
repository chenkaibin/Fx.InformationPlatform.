using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Fx.Domain.Base.IService
{
    /// <summary>
    /// 车辆交易检索接口
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface ICarSearch<T> where T : class
    {
        /// <summary>
        /// 仅仅根据三级类别查询，用于大频道和后续仅仅点击页码的查询
        /// </summary>
        /// <param name="catagroy">三级分类目录列表id</param>
        /// <param name="page">页码</param>
        /// <param name="take">每页获取多少数据</param>
        /// <returns>车辆查询的结果集合</returns>
        List<T> SearchByCatagroy(Fx.Entity.Catagroy.ChannelListDetailCatagroy catagroy, int page, int take);
    }
}
