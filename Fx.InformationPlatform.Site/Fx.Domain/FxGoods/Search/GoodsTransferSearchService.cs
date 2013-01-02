using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using Fx.Domain.Base;
using Fx.Domain.Base.IService;
using Fx.Entity.FxGoods;
using Fx.Infrastructure.Data;
using System.Configuration;

namespace Fx.Domain.FxGoods.Search
{
    /// <summary>
    /// 物品转让查询服务
    /// </summary>
    public class GoodsTransferSearchService : CommonSearch, ISiteSearch<GoodsTransferInfo>, IGoodsSearch<GoodsTransferInfo>, IHomeSearch<GoodsTransferInfo>
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
        public List<GoodsTransferInfo> SearchByKey(string key, int area, int city, int page, int take, int clc)
        {
            return SearchByKey(key, area, city, page, take, true, true, clc);
        }

        /// <summary>
        /// 仅仅根据三级类别查询，用于大频道和后续仅仅点击页码的查询
        /// </summary>
        /// <param name="catagroy">三级分类目录列表id</param>
        /// <param name="page">页码</param>
        /// <param name="take">每页获取多少数据</param>
        /// <returns>物品查询的结果集合</returns>
        public List<GoodsTransferInfo> SearchByKey(string key, int area = 0, 
            int city = 0, int page = 0, 
            int take = 10, bool changegoods = true, 
            bool changeprice = true, int clc = 0)
        {
            


            int start = 1 + page * 10;
            int end = page * 10 + take;
            var where = CreateWhereExpress(key, area, city, changegoods, changeprice, clc);
            string sql = " SELECT [GoodsTransferInfoId] FROM " +
                "  ( SELECT ROW_NUMBER() OVER ( ORDER BY [GoodsTransferInfoId] ) " +
                "    AS RowNumber,[GoodsTransferInfoId],CreatedTime " +
                "      FROM [FxGoods].[Goods].[GoodsTransferInfo] " + where.ToString() + " ) " +
                "  AS A1 WHERE RowNumber BETWEEN " + start + " AND " + end;

            SqlHelper db = new SqlHelper(ConfigurationManager.ConnectionStrings["fx.goods-sqlserver"].ToString());
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
                using (var context = new FxGoodsContext())
                {
                    return context.GoodsTransferInfos
                        .Include(r => r.Pictures)
                        .Where(r => ids.Contains(r.GoodsTransferInfoId)).ToList();
                }
            }
            else
            {
                return new List<GoodsTransferInfo>();
            }
        }

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
        public List<GoodsTransferInfo> SearchByCatagroy(Entity.Catagroy.ChannelListDetailCatagroy catagroy, int page, int take)
        {
            using (var content = new FxGoodsContext())
            {
                return content.GoodsTransferInfos
                                    .Include(r => r.Pictures)
                                    .Where(r => r.IsPublish == true && r.CatagroyId == (int)catagroy)
                                    .OrderByDescending(r => r.CreatedTime)
                                    .Skip(page * take)
                                    .Take(take).ToList();
            }
        }

        /// <summary>
        /// 获取首页最新物品信息
        /// </summary>
        /// <param name="count"></param>
        /// <returns></returns>
        public List<GoodsTransferInfo> SearchLatestForHome(int count)
        {
            using (var content = new FxGoodsContext())
            {
                return content.GoodsTransferInfos
                                    .Include(r => r.Pictures)
                                    .Where(r => r.IsPublish == true)
                                    .Include(r => r.Pictures)
                                    .OrderByDescending(r => r.CreatedTime)
                                    .Take(count).ToList();
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="count"></param>
        /// <returns></returns>
        public List<GoodsTransferInfo> SearchHottestForHome(int count)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 创建sql where表达式 用于多条件的查询
        /// </summary>
        /// <param name="key">关键字</param>
        /// <param name="area">地区</param>
        /// <param name="city">城市</param>
        /// <param name="changegoods">是否按换物</param>
        /// <param name="changeprice">是否按价格</param>
        /// <param name="clc">二级分类（但是检索按此目录下的三级分类检索）</param>
        private StringBuilder CreateWhereExpress(string key, int area,
            int city, bool changegoods,
            bool changeprice, int clc)
        {
            var sb = CreateCommonSearch(key, area, city);
            if (!(changegoods && changeprice))
            {
                if (changegoods)
                {
                    sb.Append(" and IsChange=1");
                }
                else
                {
                    sb.Append(" and IsChange=0");
                }
            }
            if (clc != 0)
            {
                //不在去读取数据库 性能第一 后期考虑基础表不在使用创建来得到ID
                if (clc == 1)//数码产品
                {
                    sb.Append(" and CatagroyId >= 1 and CatagroyId<=8");
                }
                else if (clc == 2)//居家用品
                {
                    sb.Append(" and CatagroyId >= 9 and CatagroyId<=17");
                }
                else if (clc == 3)//衣服鞋包
                {
                    sb.Append(" and CatagroyId >= 18 and CatagroyId<=22");
                }
                else if (clc == 4)//文化生活
                {
                    sb.Append(" and CatagroyId >= 23 and CatagroyId<=27");
                }
                else if (clc == 5)//其他
                {
                    sb.Append(" and CatagroyId=28");
                }
            }
            return sb;
        }

    }
}
