using System;
using System.Linq;
using Fx.Domain.FxGoods.IService;
using Fx.Entity;

namespace Fx.Domain.FxGoods
{
    /// <summary>
    /// 物品求购Job服务
    /// </summary>
    public class GoodsBuyJobService : IGoodsBuyJob
    {
        /// <summary>
        /// 认证中...
        /// </summary>
        /// <param name="goodsId">物品求购帖子Id</param>
        /// <returns>是否成功</returns>
        public bool Authorizing(int goodsId)
        {
            using (var context = new FxGoodsContext())
            {
                var goods = context.GoodsBuyInfos.Where(r => r.GoodsBuyInfoId == goodsId).FirstOrDefault();
                if (goods != null)
                {
                    goods.InfoProcessState = (int)ProcessState.Authorizing;
                    goods.Logs.Add(new Entity.FxGoods.GoodsBuyLog()
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
        /// <param name="goodsId">物品求购帖子Id</param>
        /// <returns>是否成功</returns>
        public bool AuthorizeSuccess(int goodsId)
        {
            using (var context = new FxGoodsContext())
            {
                var goods = context.GoodsBuyInfos.Where(r => r.GoodsBuyInfoId == goodsId).FirstOrDefault();
                if (goods != null)
                {
                    goods.InfoProcessState = (int)ProcessState.AuthorizeSuccess;
                    goods.Logs.Add(new Entity.FxGoods.GoodsBuyLog()
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
        /// <param name="goodsId">物品求购帖子Id</param>
        /// <param name="msg">认证失败错误信息</param>
        /// <returns>是否成功</returns>
        public bool AuthorizeFaild(int goodsId,string msg)
        {
            using (var context = new FxGoodsContext())
            {
                var goods = context.GoodsBuyInfos.Where(r => r.GoodsBuyInfoId == goodsId).FirstOrDefault();
                if (goods != null)
                {
                    goods.InfoProcessState = (int)ProcessState.AuthorizeFaild;
                    goods.ErrorMsg = msg;
                    goods.Logs.Add(new Entity.FxGoods.GoodsBuyLog()
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
        /// <param name="goodsId">物品求购帖子Id</param>
        /// <returns>是否成功</returns>
        public bool Publish(int goodsId)
        {
            using (var context = new FxGoodsContext())
            {
                var goods = context.GoodsBuyInfos.Where(r => r.GoodsBuyInfoId == goodsId).FirstOrDefault();
                if (goods != null)
                {
                    goods.InfoProcessState = (int)ProcessState.Publish;
                    goods.IsPublish = true;
                    goods.Logs.Add(new Entity.FxGoods.GoodsBuyLog()
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
        /// <param name="goodsId">物品求购帖子Id</param>
        /// <returns>是否成功</returns>
        public bool Delay(int goodsId)
        {
            using (var context = new FxGoodsContext())
            {
                var goods = context.GoodsBuyInfos.Where(r => r.GoodsBuyInfoId == goodsId).FirstOrDefault();
                if (goods != null)
                {
                    goods.InfoProcessState = (int)ProcessState.Delay;
                    goods.Logs.Add(new Entity.FxGoods.GoodsBuyLog()
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
        /// <param name="goodsId">物品求购帖子Id</param>
        /// <returns>是否成功</returns>
        public bool End(int goodsId)
        {
            using (var context = new FxGoodsContext())
            {
                var goods = context.GoodsBuyInfos.Where(r => r.GoodsBuyInfoId == goodsId).FirstOrDefault();
                if (goods != null)
                {
                    goods.InfoProcessState = (int)ProcessState.End;
                    goods.Logs.Add(new Entity.FxGoods.GoodsBuyLog()
                    {
                        OperteName = Enum.GetName(typeof(ProcessState), ProcessState.End)
                    });
                    return context.SaveChanges() > 0;
                }
            }
            return false;
        }



        /// <summary>
        /// 图片CDN中...
        /// </summary>
        /// <param name="goodsId">物品求购帖子Id</param>
        /// <returns>是否成功</returns>
        public bool PictrueCdning(int goodsId)
        {
            using (var context = new FxGoodsContext())
            {
                var goods = context.GoodsBuyInfos.Where(r => r.GoodsBuyInfoId == goodsId).FirstOrDefault();
                if (goods != null)
                {
                    goods.InfoProcessState = (int)ProcessState.PictrueCdning;
                    goods.Logs.Add(new Entity.FxGoods.GoodsBuyLog()
                    {
                        OperteName = Enum.GetName(typeof(ProcessState), ProcessState.PictrueCdning)
                    });
                    return context.SaveChanges() > 0;
                }
            }
            return false;
        }

        /// <summary>
        /// 图片CDN成功
        /// </summary>
        /// <param name="goodsId">物品求购帖子Id</param>
        /// <returns>是否成功</returns>
        public bool PictrueCdnSuccessd(int goodsId)
        {
            using (var context = new FxGoodsContext())
            {
                var goods = context.GoodsBuyInfos.Where(r => r.GoodsBuyInfoId == goodsId).FirstOrDefault();
                if (goods != null)
                {
                    goods.InfoProcessState = (int)ProcessState.PictrueCdnSuccessd;
                    goods.Logs.Add(new Entity.FxGoods.GoodsBuyLog()
                    {
                        OperteName = Enum.GetName(typeof(ProcessState), ProcessState.PictrueCdnSuccessd)
                    });
                    return context.SaveChanges() > 0;
                }
            }
            return false;
        }

        /// <summary>
        /// 图片CDN失败
        /// </summary>
        /// <param name="goodsId">物品求购帖子Id</param>
        /// <param name="errorMsg">CDN失败错误信息</param>
        /// <returns>是否成功</returns>
        public bool PictrueCdnFailed(int goodsId, string errorMsg)
        {
            using (var context = new FxGoodsContext())
            {
                var goods = context.GoodsBuyInfos.Where(r => r.GoodsBuyInfoId == goodsId).FirstOrDefault();
                if (goods != null)
                {
                    goods.InfoProcessState = (int)ProcessState.PictrueCdnFailed;
                    goods.Logs.Add(new Entity.FxGoods.GoodsBuyLog()
                    {
                        OperteName = Enum.GetName(typeof(ProcessState), ProcessState.PictrueCdnFailed)
                    });
                    context.PictureCdnErrors.Add(new PictureCdnError()
                    {
                        ErorMsg = errorMsg,
                        ObjectId = goodsId,
                        SourceType = (int)ChannelCatagroy.FxGoodsBuy
                    });
                    return context.SaveChanges() > 0;
                }
            }
            return false;
        }

        /// <summary>
        /// Job调度完成
        /// </summary>
        /// <param name="goodsId">物品求购帖子Id</param>
        /// <returns>是否成功</returns>
        public bool JobSuccess(int goodsId)
        {
            using (var context = new FxGoodsContext())
            {
                var goods = context.GoodsBuyInfos.Where(r => r.GoodsBuyInfoId == goodsId).FirstOrDefault();
                if (goods != null)
                {
                    goods.InfoProcessState = (int)ProcessState.JobSuccess;
                    goods.Logs.Add(new Entity.FxGoods.GoodsBuyLog()
                    {
                        OperteName = Enum.GetName(typeof(ProcessState), ProcessState.JobSuccess)
                    });
                    return context.SaveChanges() > 0;
                }
            }
            return false;
        }

        /// <summary>
        /// 不删除状态 （置顶中）
        /// </summary>
        /// <param name="goodsId">物品求购帖子Id</param>
        /// <returns>是否成功</returns>
        public bool NoDelete(int goodsId)
        {
            using (var context = new FxGoodsContext())
            {
                var goods = context.GoodsBuyInfos.Where(r => r.GoodsBuyInfoId == goodsId).FirstOrDefault();
                if (goods != null)
                {
                    goods.InfoProcessState = (int)ProcessState.NoDelete;
                    goods.Logs.Add(new Entity.FxGoods.GoodsBuyLog()
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
        /// <param name="goodsId">物品求购帖子Id</param>
        /// <returns>是否成功</returns>
        public bool Delete(int goodsId)
        {
            using (var context = new FxGoodsContext())
            {
                var goods = context.GoodsBuyInfos.Where(r => r.GoodsBuyInfoId == goodsId).FirstOrDefault();
                if (goods != null)
                {
                    goods.InfoProcessState = (int)ProcessState.Delete;
                    goods.IsPublish = false;
                    goods.IsDelete = true;
                    goods.Logs.Add(new Entity.FxGoods.GoodsBuyLog()
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
