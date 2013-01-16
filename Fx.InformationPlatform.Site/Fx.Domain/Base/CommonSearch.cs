using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Fx.Domain.Base
{
    /// <summary>
    ///通用子频道查询服务，根据关键字、地区、城市查询 
    /// </summary>
    public class CommonSearch
    {
        /// <summary>
        /// 创建通用查询服务的sql条件
        /// </summary>
        /// <param name="key">关键字</param>
        /// <param name="area">地区</param>
        /// <param name="city">城市</param>
        /// <returns>sql查询条件 带where,未采用参数化查询</returns>
        protected StringBuilder CreateCommonSearch(string key, int area, int city)
        {
            var sb = new StringBuilder();
            sb.Append(" where IsPublish='True' ");
            if (!string.IsNullOrWhiteSpace(key))
            {
                sb.Append(string.Format(" and PublishTitle like @key ", key));
            }
            if (area > 0)
            {
                sb.Append(string.Format(" and AreaId={0}", area));
            }
            if (city > 0)
            {
                sb.Append(string.Format(" and CityId={0}", city));

            }
            return sb;
        }

    }
}
