using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Fx.Domain.FxHouse.IService
{
    /// <summary>
    /// 房屋转让Job接口
    /// </summary>
    public interface IHouseTransferJob
    {
        /// <summary>
        /// 认证中...
        /// </summary>
        /// <param name="houseId">房屋转让帖子Id</param>
        /// <returns>操作是否成功</returns>
        bool Authorizing(int houseId);

        /// <summary>
        /// 认证成功
        /// </summary>
        /// <param name="houseId">房屋转让帖子Id</param>
        /// <returns>操作是否成功</returns>
        bool AuthorizeSuccess(int houseId);

        /// <summary>
        /// 认证失败
        /// </summary>
        /// <param name="houseId">房屋转让帖子Id</param>
        /// <param name="msg">认证失败错误信息</param>
        /// <returns>操作是否成功</returns>
        bool AuthorizeFaild(int houseId, string msg);

        /// <summary>
        /// 图片CDN中...
        /// </summary>
        /// <param name="houseId">房屋转让帖子Id</param>
        /// <returns>操作是否成功</returns>
        bool PictrueCdning(int houseId);

        /// <summary>
        /// 图片CDN成功
        /// </summary>
        /// <param name="houseId">房屋转让帖子Id</param>
        /// <returns>操作是否成功</returns>
        bool PictrueCdnSuccessd(int houseId);

        /// <summary>
        /// 图片CDN失败
        /// </summary>
        /// <param name="houseId">房屋转让帖子Id</param>
        /// <param name="errorMsg">图片CDN失败错误信息</param>
        /// <returns>操作是否成功</returns>
        bool PictrueCdnFailed(int houseId, string errorMsg);

        /// <summary>
        /// Job调度完成
        /// </summary>
        /// <param name="houseId">房屋转让帖子Id</param>
        /// <returns>操作是否成功</returns>
        bool JobSuccess(int houseId);

        /// <summary>
        /// 发布
        /// </summary>
        /// <param name="houseId">房屋转让帖子Id</param>
        /// <returns>操作是否成功</returns>
        bool Publish(int houseId);

        /// <summary>
        /// 帖子延期
        /// </summary>
        /// <param name="houseId">房屋转让帖子Id</param>
        /// <returns>操作是否成功</returns>
        bool Delay(int houseId);

        /// <summary>
        /// 以成交
        /// </summary>
        /// <param name="houseId">房屋转让帖子Id</param>
        /// <returns>操作是否成功</returns>
        bool End(int houseId);

        /// <summary>
        /// 不删除状态 （置顶中）
        /// </summary>
        /// <param name="houseId">房屋转让帖子Id</param>
        /// <returns>操作是否成功</returns>
        bool NoDelete(int houseId);

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="houseId">房屋转让帖子Id</param>
        /// <returns>操作是否成功</returns>
        bool Delete(int houseId);
    }
}
