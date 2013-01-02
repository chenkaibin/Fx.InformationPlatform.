using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Fx.Entity.FxAggregate;

namespace Fx.Domain.FxAggregate.IService
{
    /// <summary>
    /// 私信接口
    /// </summary>
    public interface IPrivateMessage
    {
        /// <summary>
        /// 添加私信
        /// </summary>
        /// <param name="message"></param>
        void AddPrivateMessage(PrivateMessage message);

        /// <summary>
        /// 删除私信
        /// </summary>
        /// <param name="message"></param>
        void RemovePrivateMessage(PrivateMessage message);

        /// <summary>
        /// 获取私信
        /// </summary>
        /// <param name="id">私信id</param>
        /// <returns>私信</returns>
        PrivateMessage GetById(int id);

        /// <summary>
        /// 获取用户私信
        /// </summary>
        /// <param name="email">用户帐号</param>
        /// <returns>私信列表</returns>
        List<PrivateMessage> GetByUser(string email);

        /// <summary>
        /// 用户私信数量
        /// </summary>
        /// <param name="email">帐号</param>
        /// <returns>私信数量</returns>
        int PrivateMessageCount(string email);
    }
}
