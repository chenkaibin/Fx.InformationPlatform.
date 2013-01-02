using System;
using System.Linq;
using Fx.Domain.FxHouse.IService;
using Fx.Entity;

namespace Fx.Domain.FxHouse
{
    /// <summary>
    /// 房屋转让Job服务
    /// </summary>
    public class HouseBuyJobService : IHouseBuyJob
    {
        /// <summary>
        /// 认证中...
        /// </summary>
        /// <param name="houseId">房屋求购帖子Id</param>
        /// <returns>操作是否成功</returns>
        public bool Authorizing(int houseId)
        {
            using (var context = new FxHouseContext())
            {
                var house = context.HouseBuyInfos.Where(r => r.HouseBuyInfoId == houseId).FirstOrDefault();
                if (house != null)
                {
                    house.InfoProcessState = (int)ProcessState.Authorizing;
                    house.Logs.Add(new Entity.FxHouse.HouseBuyLog()
                    {
                        OperteName = Enum.GetName(typeof(ProcessState), ProcessState.Authorizing)
                    });
                    return context.SaveChanges() > 0;
                }
            }
            return false;
        }

        /// <summary>
        /// 认证成功
        /// </summary>
        /// <param name="houseId">房屋求购帖子Id</param>
        /// <returns>操作是否成功</returns>
        public bool AuthorizeSuccess(int houseId)
        {
            using (var context = new FxHouseContext())
            {
                var house = context.HouseBuyInfos.Where(r => r.HouseBuyInfoId == houseId).FirstOrDefault();
                if (house != null)
                {
                    house.InfoProcessState = (int)ProcessState.AuthorizeSuccess;
                    house.Logs.Add(new Entity.FxHouse.HouseBuyLog()
                    {
                        OperteName = Enum.GetName(typeof(ProcessState), ProcessState.AuthorizeSuccess)
                    });
                    return context.SaveChanges() > 0;
                }
            }
            return false;
        }

        /// <summary>
        /// 认证失败
        /// </summary>
        /// <param name="houseId">房屋求购帖子Id</param>
        /// <param name="msg">认证失败错误信息</param>
        /// <returns>操作是否成功</returns>
        public bool AuthorizeFaild(int houseId,string msg)
        {
            using (var context = new FxHouseContext())
            {
                var house = context.HouseBuyInfos.Where(r => r.HouseBuyInfoId == houseId).FirstOrDefault();
                if (house != null)
                {
                    house.InfoProcessState = (int)ProcessState.AuthorizeFaild;
                    house.ErrorMsg = msg;
                    house.Logs.Add(new Entity.FxHouse.HouseBuyLog()
                    {
                        OperteName = Enum.GetName(typeof(ProcessState), ProcessState.AuthorizeFaild)
                    });
                    return context.SaveChanges() > 0;
                }
            }
            return false;
        }
        
        /// <summary>
        /// 发布
        /// </summary>
        /// <param name="houseId">房屋求购帖子Id</param>
        /// <returns>操作是否成功</returns>
        public bool Publish(int houseId)
        {
            using (var context = new FxHouseContext())
            {
                var house = context.HouseBuyInfos.Where(r => r.HouseBuyInfoId == houseId).FirstOrDefault();
                if (house != null)
                {
                    house.InfoProcessState = (int)ProcessState.Publish;
                    house.IsPublish = true;
                    house.Logs.Add(new Entity.FxHouse.HouseBuyLog()
                    {
                        OperteName = Enum.GetName(typeof(ProcessState), ProcessState.Publish)
                    });
                    return context.SaveChanges() > 0;
                }
            }
            return false;
        }

        /// <summary>
        /// 帖子延期
        /// </summary>
        /// <param name="houseId">房屋求购帖子Id</param>
        /// <returns>操作是否成功</returns>
        public bool Delay(int houseId)
        {
            using (var context = new FxHouseContext())
            {
                var house = context.HouseBuyInfos.Where(r => r.HouseBuyInfoId == houseId).FirstOrDefault();
                if (house != null)
                {
                    house.InfoProcessState = (int)ProcessState.Delay;
                    house.Logs.Add(new Entity.FxHouse.HouseBuyLog()
                    {
                        OperteName = Enum.GetName(typeof(ProcessState), ProcessState.Delay)
                    });
                    return context.SaveChanges() > 0;
                }
            }
            return false;
        }

        /// <summary>
        /// 以成交
        /// </summary>
        /// <param name="houseId">房屋求购帖子Id</param>
        /// <returns>操作是否成功</returns>
        public bool End(int houseId)
        {
            using (var context = new FxHouseContext())
            {
                var house = context.HouseBuyInfos.Where(r => r.HouseBuyInfoId == houseId).FirstOrDefault();
                if (house != null)
                {
                    house.InfoProcessState = (int)ProcessState.End;
                    house.Logs.Add(new Entity.FxHouse.HouseBuyLog()
                    {
                        OperteName = Enum.GetName(typeof(ProcessState), ProcessState.End)
                    });
                    return context.SaveChanges() > 0;
                }
            }
            return false;
        }

        /// <summary>
        /// 不删除状态 （置顶中）
        /// </summary>
        /// <param name="houseId">房屋求购帖子Id</param>
        /// <returns>操作是否成功</returns>
        public bool NoDelete(int houseId)
        {
            using (var context = new FxHouseContext())
            {
                var house = context.HouseBuyInfos.Where(r => r.HouseBuyInfoId == houseId).FirstOrDefault();
                if (house != null)
                {
                    house.InfoProcessState = (int)ProcessState.NoDelete;
                    house.Logs.Add(new Entity.FxHouse.HouseBuyLog()
                    {
                        OperteName = Enum.GetName(typeof(ProcessState), ProcessState.NoDelete)
                    });
                    return context.SaveChanges() > 0;
                }
            }
            return false;
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="houseId">房屋求购帖子Id</param>
        /// <returns>操作是否成功</returns>
        public bool Delete(int houseId)
        {
            using (var context = new FxHouseContext())
            {
                var house = context.HouseBuyInfos.Where(r => r.HouseBuyInfoId == houseId).FirstOrDefault();
                if (house != null)
                {
                    house.InfoProcessState = (int)ProcessState.Delete;
                    house.IsPublish = false;
                    house.IsDelete = true;
                    house.Logs.Add(new Entity.FxHouse.HouseBuyLog()
                    {
                        OperteName = Enum.GetName(typeof(ProcessState), ProcessState.Delete)
                    });
                    return context.SaveChanges() > 0;
                }
            }
            return false;
        }
    }
}
