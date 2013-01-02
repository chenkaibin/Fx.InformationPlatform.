using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Fx.Domain.FxGoods.IService
{
    /// <summary>
    /// 物品求购Job接口
    /// </summary>
    public interface IGoodsBuyJob
    {
        /// <summary>
        /// 认证中...
        /// </summary>
        /// <param name="goodsId">物品求购帖子Id</param>
        /// <returns>是否成功</returns>
        bool Authorizing(int goodsId);

        /// <summary>
        /// 认证成功
        /// </summary>
        /// <param name="goodsId">物品求购帖子Id</param>
        /// <returns>是否成功</returns>
        bool AuthorizeSuccess(int goodsId);

        /// <summary>
        /// 认证失败
        /// </summary>
        /// <param name="goodsId">物品求购帖子Id</param>
        /// <param name="msg">认证失败错误信息</param>
        /// <returns>是否成功</returns>
        bool AuthorizeFaild(int goodsId, string msg);

        /// <summary>
        /// 图片CDN中...
        /// </summary>
        /// <param name="goodsId">物品求购帖子Id</param>
        /// <returns>是否成功</returns>
        bool PictrueCdning(int goodsId);

        /// <summary>
        /// 图片CDN成功
        /// </summary>
        /// <param name="goodsId">物品求购帖子Id</param>
        /// <returns>是否成功</returns>
        bool PictrueCdnSuccessd(int goodsId);

        /// <summary>
        /// 图片CDN失败
        /// </summary>
        /// <param name="goodsId">物品求购帖子Id</param>
        /// <param name="errorMsg">CDN失败错误信息</param>
        /// <returns>是否成功</returns>
        bool PictrueCdnFailed(int goodsId, string errorMsg);

        /// <summary>
        /// Job调度完成
        /// </summary>
        /// <param name="goodsId">物品求购帖子Id</param>
        /// <returns>是否成功</returns>
        bool JobSuccess(int goodsId);

        /// <summary>
        /// 发布
        /// </summary>
        /// <param name="goodsId">物品求购帖子Id</param>
        /// <returns>是否成功</returns>
        bool Publish(int goodsId);

        /// <summary>
        /// 帖子延期
        /// </summary>
        /// <param name="goodsId">物品求购帖子Id</param>
        /// <returns>是否成功</returns>
        bool Delay(int goodsId);

        /// <summary>
        /// 以成交
        /// </summary>
        /// <param name="goodsId">物品求购帖子Id</param>
        /// <returns>是否成功</returns>
        bool End(int goodsId);

        /// <summary>
        /// 不删除状态 （置顶中）
        /// </summary>
        /// <param name="goodsId">物品求购帖子Id</param>
        /// <returns>是否成功</returns>
        bool NoDelete(int goodsId);

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="goodsId">物品求购帖子Id</param>
        /// <returns>是否成功</returns>
        bool Delete(int goodsId);
    }
}
