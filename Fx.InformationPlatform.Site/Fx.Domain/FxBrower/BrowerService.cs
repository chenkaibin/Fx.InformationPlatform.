using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Fx.Entity.FxBrower;

namespace Fx.Domain.FxBrower
{
    /// <summary>
    /// 浏览器服务
    /// </summary>
    public class BrowerService
    {
        /// <summary>
        /// 添加用户浏览器信息
        /// </summary>
        /// <param name="brower"></param>
        public void AddBrower(Brower brower)
        {
            using (var context = new Fx.Domain.FxBrower.FxBrowerContext())
            {
                context.Browers.Add(brower);
                context.SaveChanges();
            }
        }

        /// <summary>
        /// 是否存在当前SessionId的浏览器信息
        /// </summary>
        /// <param name="SessionID"></param>
        /// <returns></returns>
        public bool IsExist(string SessionID)
        {
            using (var context = new Fx.Domain.FxBrower.FxBrowerContext())
            {
                return context.Browers.Where(r => r.SessionID == SessionID).FirstOrDefault() != null;
            }
        }

    }
}
