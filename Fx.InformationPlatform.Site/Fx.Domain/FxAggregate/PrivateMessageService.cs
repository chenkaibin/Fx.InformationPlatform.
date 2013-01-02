using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Fx.Domain.FxAggregate.IService;
using Fx.Entity.FxAggregate;

namespace Fx.Domain.FxAggregate
{
    /// <summary>
    /// 私信服务
    /// </summary>
    public class PrivateMessageService : IPrivateMessage
    {
        /// <summary>
        /// 添加私信
        /// </summary>
        /// <param name="message"></param>
        public void AddPrivateMessage(PrivateMessage message)
        {
            using (var content = new FxAggregateContext())
            {
                content.PrivateMessages.Add(message);
                content.SaveChanges();
            }
        }

        /// <summary>
        /// 删除私信
        /// </summary>
        /// <param name="message"></param>
        public void RemovePrivateMessage(PrivateMessage message)
        {
            using (var content = new FxAggregateContext())
            {
                var entity = content.PrivateMessages
                    .Where(r => r.PrivateMessageId == message.PrivateMessageId).FirstOrDefault();
                if (entity != null)
                {
                    content.PrivateMessages.Remove(entity);
                    content.SaveChanges();
                }
            }
        }

        /// <summary>
        /// 获取私信
        /// </summary>
        /// <param name="email">用户帐号</param>
        /// <returns>私信</returns>
        public List<PrivateMessage> GetByUser(string email)
        {
            using (var content = new FxAggregateContext())
            {
                var entitys = content.PrivateMessages
                    .Where(r => r.UserAccount == email).ToList();
                return entitys;
            }
        }

        /// <summary>
        /// 获取用户私信
        /// </summary>
        /// <param name="id">私信Id</param>
        /// <returns>私信列表</returns>
        public PrivateMessage GetById(int id)
        {
            using (var content = new FxAggregateContext())
            {
                var entity = content.PrivateMessages
                    .Where(r => r.PrivateMessageId == id).FirstOrDefault();
                return entity;
            }
        }

        /// <summary>
        /// 用户私信数量
        /// </summary>
        /// <param name="email">帐号</param>
        /// <returns>私信数量</returns>
        public int PrivateMessageCount(string email)
        {
            using (var content = new FxAggregateContext())
            {
                return content.PrivateMessages
                    .Where(r => r.UserAccount == email).Count();
            }
        }
    }
}
