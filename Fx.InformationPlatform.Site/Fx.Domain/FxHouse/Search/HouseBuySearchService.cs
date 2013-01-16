using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using Fx.Domain.Base;
using Fx.Domain.Base.IService;
using Fx.Entity.FxHouse;
using Fx.Infrastructure.Data;

namespace Fx.Domain.FxHouse.Search
{
    /// <summary>
    /// 房屋求购查询服务
    /// </summary>
    public class HouseBuySearchService : CommonSearch, ISiteSearch<HouseBuyInfo>, IHouseSearch<HouseBuyInfo>
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
        /// <returns></returns>
        public List<HouseBuyInfo> SearchByKey(string key, int area = 0, 
            int city = 0, int page = 0, 
            int take = 10,int clc=0)
        {
            int start = 1 + page * 10;
            int end = page * 10 + take;
            var where = CreateWhereExpress(key, area, city, clc);
            string sql = " SELECT [HouseBuyInfoId] FROM " +
                "  ( SELECT ROW_NUMBER() OVER ( ORDER BY [HouseBuyInfoId] ) " +
                "    AS RowNumber,[HouseBuyInfoId],CreatedTime " +
                "      FROM [FxHouse].[House].[HouseBuyInfo] " + where.ToString() + " ) " +
                "  AS A1 WHERE RowNumber BETWEEN " + start + " AND " + end;


            var dt = GetDataTable(sql, key);
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
                    return context.HouseBuyInfos
                        .Where(r => ids.Contains(r.HouseBuyInfoId)).ToList();
                }
            }
            else
            {
                return new List<HouseBuyInfo>();
            }
        }


        private System.Data.DataTable GetDataTable(string sql, string key)
        {
            SqlHelper db = new SqlHelper(ConfigurationManager.ConnectionStrings["fx.house-sqlserver"].ToString());
            if (string.IsNullOrWhiteSpace(key))
            {
                return db.GetDt(sql);
            }
            else
            {
                return db.GetDt(sql, new System.Data.SqlClient.SqlParameter("key", "%" + key + "%"));
            }
        }



        /// <summary>
        /// 仅仅根据三级类别查询，用于大频道和后续仅仅点击页码的查询
        /// </summary>
        /// <param name="catagroy">三级分类目录列表id</param>
        /// <param name="page">页码</param>
        /// <param name="take">每页获取多少数据</param>
        /// <returns>房屋查询的结果集合</returns>
        public List<HouseBuyInfo> SearchByCatagroy(Entity.Catagroy.ChannelListDetailCatagroy catagroy, int page, int take)
        {
            using (var content = new FxHouseContext())
            {
                return content.HouseBuyInfos
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
        /// <returns></returns>
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
