﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using Fx.Domain.Base.IService;
using Fx.Entity.FxHouse;

namespace Fx.Domain.FxHouse.Search
{
   public class HouseTransferSearchService:ISiteSearch<HouseTransferInfo>,IHomeSearch<HouseTransferInfo>
    {
        public List<HouseTransferInfo> SearchByKey(string key, int page)
        {
            using (var context = new FxHouseContext())
            {
                if (!string.IsNullOrWhiteSpace(key))
                {
                    return context.HouseTransferInfos
                                    .Where(r => r.PublishTitle.Contains(key) && r.IsPublish == true)
                                    .OrderByDescending(r => r.CreatedTime)
                                    .Skip(page * 20)
                                    .Take(20).ToList();
                }
                else
                {
                    return context.HouseTransferInfos.Where(r => r.IsPublish == true)
                                    .OrderByDescending(r => r.CreatedTime)
                                    .Skip(page * 20)
                                    .Take(20).ToList();
                }
            }
        }

        /// <summary>
        /// 按价格查询 默认价格从低到高
        /// </summary>
        /// <param name="page"></param>
        /// <param name="asc"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public List<HouseTransferInfo> SearchByPrice(int page, bool asc = true, string key = "")
        {
            using (var context = new FxHouseContext())
            {
                if (!string.IsNullOrWhiteSpace(key))
                {
                    if (asc)
                    {
                        return context.HouseTransferInfos.Where(r => r.IsPublish == true)
                                    .OrderBy(r => r.Price)
                                    .Skip(page * 20)
                                    .Take(20).ToList();
                    }
                    else
                    {
                        return context.HouseTransferInfos.Where(r => r.IsPublish == true)
                                    .OrderByDescending(r => r.Price)
                                    .Skip(page * 20)
                                    .Take(20).ToList();
                    }
                }
                else
                {
                    if (asc)
                    {
                        return context.HouseTransferInfos
                                    .Where(r => r.PublishTitle.Contains(key) && r.IsPublish == true)
                                    .OrderBy(r => r.Price)
                                    .Skip(page * 20)
                                    .Take(20).ToList();
                    }
                    else
                    {
                        return context.HouseTransferInfos
                                    .Where(r => r.PublishTitle.Contains(key) && r.IsPublish == true)
                                    .OrderByDescending(r => r.Price)
                                    .Skip(page * 20)
                                    .Take(20).ToList();
                    }
                }
            }
        }

        /// <summary>
        /// 根据时间排序
        /// </summary>
        /// <param name="key"></param>
        /// <param name="asc"></param>
        /// <param name="page"></param>
        /// <returns></returns>
        public List<HouseTransferInfo> SearchByDate(int page, bool asc, string key)
        {
            using (var context = new FxHouseContext())
            {
                if (!string.IsNullOrWhiteSpace(key))
                {
                    if (asc)
                    {
                        return context.HouseTransferInfos
                                        .Where(r => r.PublishTitle.Contains(key) && r.IsPublish == true)
                                        .OrderBy(r => r.CreatedTime)
                                        .Skip(page * 20)
                                        .Take(20).ToList();
                    }
                    else
                    {
                        return context.HouseTransferInfos
                                        .Where(r => r.PublishTitle.Contains(key) && r.IsPublish == true)
                                        .OrderByDescending(r => r.CreatedTime)
                                        .Skip(page * 20)
                                        .Take(20).ToList();
                    }
                }
                else
                {
                    if (asc)
                    {
                        return context.HouseTransferInfos.Where(r => r.IsPublish == true)
                                        .OrderBy(r => r.CreatedTime)
                                        .Skip(page * 20)
                                        .Take(20).ToList();
                    }
                    else
                    {
                        return context.HouseTransferInfos.Where(r => r.IsPublish == true)
                                        .OrderByDescending(r => r.CreatedTime)
                                        .Skip(page * 20)
                                        .Take(20).ToList();
                    }
                }
            }
        }

        public List<HouseTransferInfo> SearchLatestForHome(int count)
        {
            using (var content = new FxHouseContext())
            {
                return content.HouseTransferInfos.Where(r => r.IsPublish == true)
                    .Include(r => r.Pictures).OrderByDescending(r => r.CreatedTime).Take(count).ToList();
            }
        }

        public List<HouseTransferInfo> SearchHottestForHome(int count)
        {
            throw new NotImplementedException();
        }

        public List<HouseTransferInfo> SearchTopshowForHome(int count)
        {
            throw new NotImplementedException();
        }
    }
}
