using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Fx.Domain.FxHouse.IService
{
    /// <summary>
    /// 房屋求购Job接口
    /// </summary>
    public interface IHouseBuyJob
    {
        /// <summary>
        /// 认证中...
        /// </summary>
        /// <param name="houseId"></param>
        /// <returns></returns>
        bool Authorizing(int houseId);

        /// <summary>
        /// 认证成功
        /// </summary>
        /// <param name="houseId"></param>
        /// <returns></returns>
        bool AuthorizeSuccess(int houseId);

        /// <summary>
        /// 认证失败
        /// </summary>
        /// <param name="houseId"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        bool AuthorizeFaild(int houseId, string msg);

        /// <summary>
        /// 发布
        /// </summary>
        /// <param name="houseId"></param>
        /// <returns></returns>
        bool Publish(int houseId);

        /// <summary>
        /// 帖子延期
        /// </summary>
        /// <param name="houseId"></param>
        /// <returns></returns>
        bool Delay(int houseId);

        /// <summary>
        /// 以成交
        /// </summary>
        /// <param name="houseId"></param>
        /// <returns></returns>
        bool End(int houseId);

        /// <summary>
        /// 不删除状态 （置顶中）
        /// </summary>
        /// <param name="houseId"></param>
        /// <returns></returns>
        bool NoDelete(int houseId);

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="houseId"></param>
        /// <returns></returns>
        bool Delete(int houseId);
    }
}
