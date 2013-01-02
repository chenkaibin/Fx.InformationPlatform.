using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Linq;
using System.Text;
using Fx.Domain.Base;
using Fx.Domain.Base.IService;
using Fx.Entity.FxHouse;
using Fx.Infrastructure.Data;

namespace Fx.Domain.FxHouse.Search
{
    /// <summary>
    /// 房屋转让查询服务
    /// </summary>
    public class HouseTransferSearchService : CommonSearch, ISiteSearch<HouseTransferInfo>, IHomeSearch<HouseTransferInfo>, IHouseSearch<HouseTransferInfo>
    {
        /// <summary>
        /// 按关键字查询 （标题） 缓存会
        /// </summary>
        /// <param name="key">关键字</param>
        /// <param name="page">页码</param>
        /// <param name="take">获取数据的数量</param>
        /// <param name="area">地区</param>
        /// <param name="city">城市</param>
        /// <param name="clc">帖子对应的二级或者三级频道Id</param>
        /// <returns>房屋转让信息列表</returns>
        public List<HouseTransferInfo> SearchByKey(string key, int area = 0,
            int city = 0, int page = 0,
            int take = 10, int clc = 0)
        {
            int start = 1 + page * 10;
            int end = page * 10 + take;
            var where = CreateWhereExpress(key, area, city, clc);
            string sql = " SELECT [HouseTransferInfoId] FROM " +
                "  ( SELECT ROW_NUMBER() OVER ( ORDER BY [HouseTransferInfoId] ) " +
                "    AS RowNumber,[HouseTransferInfoId],CreatedTime " +
                "      FROM [FxHouse].[House].[HouseTransferInfo] " + where.ToString() + " ) " +
                "  AS A1 WHERE RowNumber BETWEEN " + start + " AND " + end;

            SqlHelper db = new SqlHelper(ConfigurationManager.ConnectionStrings["fx.house-sqlserver"].ToString());
            var dt = db.GetDt(sql);
            var ids = new List<int>();
            if (dt != null)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    ids.Add(Convert.ToInt32(dt.Rows[i][0]));
                }
            }
            if (ids.Count > 0)
            {
                using (var context = new FxHouseContext())
                {
                    return context.HouseTransferInfos
                        .Include(r=>r.Pictures)
                        .Where(r => ids.Contains(r.HouseTransferInfoId)).ToList();
                }
            }
            else
            {
                return new List<HouseTransferInfo>();
            }
        }

        /// <summary>
        /// 获取首页最新房屋信息
        /// </summary>
        /// <param name="count">获取数量</param>
        /// <returns>房屋转让信息列表</returns>
        public List<HouseTransferInfo> SearchLatestForHome(int count)
        {
            using (var content = new FxHouseContext())
            {
                return content.HouseTransferInfos
                                    .Include(r => r.Pictures)
                                    .Where(r => r.IsPublish == true)
                                    .OrderByDescending(r => r.CreatedTime)
                                    .Take(count).ToList();
            }
        }

        /// <summary>
        /// 获取首页最热门房屋信息(未实现)
        /// </summary>
        /// <param name="count">获取数量</param>
        /// <returns>房屋转让信息列表</returns>
        public List<HouseTransferInfo> SearchHottestForHome(int count)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 仅仅根据三级类别查询，用于大频道和后续仅仅点击页码的查询
        /// </summary>
        /// <param name="catagroy">三级分类目录列表id</param>
        /// <param name="page">页码</param>
        /// <param name="take">每页获取多少数据</param>
        /// <returns>房屋转让信息列表</returns>
        public List<HouseTransferInfo> SearchByCatagroy(Entity.Catagroy.ChannelListDetailCatagroy catagroy, int page = 0, int take = 20)
        {
            using (var content = new FxHouseContext())
            {
                return content.HouseTransferInfos
                                    .Include(r => r.Pictures)
                                    .Where(r => r.IsPublish == true && r.CatagroyId == (int)catagroy)
                                    .OrderByDescending(r => r.CreatedTime)
                                    .Skip(page * take)
                                    .Take(take).ToList();
            }
        }

        /// <summary>
        /// 创建sql where表达式 用于多条件的查询
        /// </summary>
        /// <param name="key">关键字</param>
        /// <param name="area">地区</param>
        /// <param name="city">城市</param>
        /// <param name="clc">三级分类</param>
        /// <returns>sql where表达式</returns>
        private StringBuilder CreateWhereExpress(string key, int area,
            int city, int clc)
        {
            var sb = CreateCommonSearch(key, area, city);
            if (clc != 0)
            {
                sb.Append(" and CatagroyId=" + clc);
            }
            return sb;
        }
    }
}
