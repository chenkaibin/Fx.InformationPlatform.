using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Fx.Domain.FxGoods.IService
{
    public interface IGoodsTransferJob
    {
        /// <summary>
        /// 认证中...
        /// </summary>
        /// <param name="goodsId"></param>
        /// <returns></returns>
        bool Authorizing(int goodsId);

        /// <summary>
        /// 认证成功
        /// </summary>
        /// <param name="goodsId"></param>
        /// <returns></returns>
        bool AuthorizeSuccess(int goodsId);

        /// <summary>
        /// 认证失败
        /// </summary>
        /// <param name="goodsId"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        bool AuthorizeFaild(int goodsId, string msg);

        /// <summary>
        /// 图片CDN中...
        /// </summary>
        /// <param name="goodsId"></param>
        /// <returns></returns>
        bool PictrueCdning(int goodsId);

        /// <summary>
        /// 图片CDN成功
        /// </summary>
        /// <param name="goodsId"></param>
        /// <returns></returns>
        bool PictrueCdnSuccessd(int goodsId);

        /// <summary>
        /// 图片CDN失败
        /// </summary>
        /// <param name="goodsId"></param>
        /// <param name="erroMsg"></param>
        /// <returns></returns>
        bool PictrueCdnFailed(int goodsId, string erroMsg);

        /// <summary>
        /// Job调度完成
        /// </summary>
        /// <param name="goodsId"></param>
        /// <returns></returns>
        bool JobSuccess(int goodsId);

        /// <summary>
        /// 发布
        /// </summary>
        /// <param name="goodsId"></param>
        /// <returns></returns>
        bool Publish(int goodsId);

        /// <summary>
        /// 帖子延期
        /// </summary>
        /// <param name="goodsId"></param>
        /// <returns></returns>
        bool Delay(int goodsId);

        /// <summary>
        /// 以成交
        /// </summary>
        /// <param name="goodsId"></param>
        /// <returns></returns>
        bool End(int goodsId);

        /// <summary>
        /// 不删除状态 （置顶中）
        /// </summary>
        /// <param name="goodsId"></param>
        /// <returns></returns>
        bool NoDelete(int goodsId);

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="goodsId"></param>
        /// <returns></returns>
        bool Delete(int goodsId);
    }
}
