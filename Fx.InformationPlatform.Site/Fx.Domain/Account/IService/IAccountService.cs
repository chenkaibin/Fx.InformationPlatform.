using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fx.Entity;
using Fx.Entity.MemberShip;

namespace Fx.Domain.Account.IService
{
    /// <summary>
    /// 帐号服务接口
    /// </summary>
    public interface IAccountService
    {
        /// <summary>
        /// 新增一个用户
        /// </summary>
        /// <param name="entity">memberiship用户</param>
        /// <param name="other">用户扩展信息</param>
        /// <returns>领域处理结果</returns>
        DomainResult AddUser(Membership entity,OtherInformation other);

        /// <summary>
        /// 删除一个用户
        /// </summary>
        /// <param name="entity">memberiship用户</param>
        /// <returns>领域处理结果</returns>
        DomainResult DeleteUser(Membership entity);

        /// <summary>
        /// 更新用户信息
        /// </summary>
        /// <param name="entity">memberiship用户</param>
        /// <returns>领域处理结果</returns>
        DomainResult UpdateUser(Membership entity);

        /// <summary>
        /// 修改用户密码
        /// </summary>
        /// <param name="entity">memberiship用户</param>
        /// <param name="oldPassword">用户扩展信息</param>
        /// <returns>领域处理结果</returns>
        DomainResult ChangePassword(Membership entity,string oldPassword);

        /// <summary>
        /// 用户帐号是否存在
        /// </summary>
        /// <param name="userName">帐号</param>
        /// <returns>领域处理结果</returns>
        DomainResult IsExistUser(string userName);

        /// <summary>
        /// 验证用户
        /// </summary>
        /// <param name="userName">帐号</param>
        /// <param name="password">密码</param>
        /// <returns>领域处理结果</returns>
        DomainResult VaildUser(string userName, string password);

        /// <summary>
        /// 获取用户的数量
        /// </summary>
        /// <returns>用户数量</returns>
        int GetUserCount();

        /// <summary>
        /// 获取当前的用户Guid
        /// </summary>
        /// <param name="Email">邮箱帐号</param>
        /// <returns>领域处理结果</returns>
        Guid GetCurrentUser(string Email);

        /// <summary>
        /// 获取用户扩展信息
        /// </summary>
        /// <param name="Email">邮箱帐号</param>
        /// <returns>用户扩展信息</returns>
        OtherInformation GetUserExtendInfo(string Email);

        /// <summary>
        /// 重置用户密码
        /// </summary>
        /// <param name="Email">邮箱帐号</param>
        /// <returns>领域处理结果</returns>
        DomainResult ResetPassword(string Email);
    }
}
