using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Fx.Domain.FxCar.IService
{
    /// <summary>
    /// 车辆转让Job接口
    /// </summary>
    public interface ICarTransferJob
    {
        /// <summary>
        /// 认证中...
        /// </summary>
        /// <param name="carId"></param>
        /// <returns></returns>
        bool Authorizing(int carId);

        /// <summary>
        /// 认证成功
        /// </summary>
        /// <param name="carId"></param>
        /// <returns></returns>
        bool AuthorizeSuccess(int carId);

        /// <summary>
        /// 认证失败
        /// </summary>
        /// <param name="carId"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        bool AuthorizeFaild(int carId, string msg);

        /// <summary>
        /// 图片CDN中...
        /// </summary>
        /// <param name="carId"></param>
        /// <returns></returns>
        bool PictrueCdning(int carId);

        /// <summary>
        /// 图片CDN成功
        /// </summary>
        /// <param name="carId"></param>
        /// <returns></returns>
        bool PictrueCdnSuccessd(int carId);

        /// <summary>
        /// 图片CDN失败
        /// </summary>
        /// <param name="carId"></param>
        /// <param name="erroMsg"></param>
        /// <returns></returns>
        bool PictrueCdnFailed(int carId, string erroMsg);

        /// <summary>
        /// Job调度完成
        /// </summary>
        /// <param name="carId"></param>
        /// <returns></returns>
        bool JobSuccess(int carId);

        /// <summary>
        /// 发布
        /// </summary>
        /// <param name="carId"></param>
        /// <returns></returns>
        bool Publish(int carId);

        /// <summary>
        /// 帖子延期
        /// </summary>
        /// <param name="carId"></param>
        /// <returns></returns>
        bool Delay(int carId);

        /// <summary>
        /// 以成交
        /// </summary>
        /// <param name="carId"></param>
        /// <returns></returns>
        bool End(int carId);

        /// <summary>
        /// 不删除状态 （置顶中）
        /// </summary>
        /// <param name="carId"></param>
        /// <returns></returns>
        bool NoDelete(int carId);

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="carId"></param>
        /// <returns></returns>
        bool Delete(int carId);
    }
}
