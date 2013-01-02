using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Fx.Domain.Base.IService
{
    /// <summary>
    ///  物品交易检索接口
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IGoodsSearch<T> where T : class
    {
        /// <summary>
        /// 根据关键字的查询，适用于子频道具体查询
        /// </summary>
        /// <param name="key">关键字</param>
        /// <param name="area">地区</param>
        /// <param name="city">城市</param>
        /// <param name="page">页码</param>
        /// <param name="take">页面数量</param>
        /// <param name="changegoods">是否换物</param>
        /// <param name="changeprice">是否根据价格</param>
        /// <param name="clc">二级频道id，可以以此找到相应三级区间</param>
        /// <returns>物品查询的结果集合</returns>
        List<T> SearchByKey(string key, int area, int city, int page, int take, bool changegoods, bool changeprice,int clc);

        /// <summary>
        /// 仅仅根据三级类别查询，用于大频道和后续仅仅点击页码的查询
        /// </summary>
        /// <param name="catagroy">三级分类目录列表id</param>
        /// <param name="page">页码</param>
        /// <param name="take">每页获取多少数据</param>
        /// <returns>物品查询的结果集合</returns>
        List<T> SearchByCatagroy(Fx.Entity.Catagroy.ChannelListDetailCatagroy catagroy, int page, int take);
    }
}
