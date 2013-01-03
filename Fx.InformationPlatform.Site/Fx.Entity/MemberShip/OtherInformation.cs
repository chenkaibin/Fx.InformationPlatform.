using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Entity.MemberShip
{
    /// <summary>
    /// 扩展信息
    /// </summary>
    public class OtherInformation
    {
        /// <summary>
        /// 扩展信息主键Id
        /// </summary>
        public int OtherInformationId { get; set; }

        /// <summary>
        /// Email帐号
        /// </summary>
        public string Email { get; set; }
        
        /// <summary>
        /// QQ
        /// </summary>
        public string QQ { get; set; }

        /// <summary>
        /// 性别枚举
        /// </summary>
        public SexCatalog Sex { get; set; }

        /// <summary>
        /// 手机
        /// </summary>
        public string Mobile { get; set; }

        /// <summary>
        /// 昵称
        /// </summary>
        public string NickName { get; set; }

        /// <summary>
        /// 地址
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// 头像
        /// </summary>
        public string HeadPicture { get; set; }

        /// <summary>
        /// 密保问题
        /// </summary>
        public string PasswordQuestion { get; set; }

        /// <summary>
        /// 密保问题答案
        /// </summary>
        public string PasswordAnswer { get; set; }

        /// <summary>
        /// 扩展信息对应的应用程序Id
        /// </summary>
        public Guid ApplicationId { get; set; }

        /// <summary>
        /// 扩展信息对应的用户Id
        /// </summary>
        public Guid UserId { get; set; }
    }

    /// <summary>
    /// 性别枚举
    /// </summary>
    public enum SexCatalog
    {
        /// <summary>
        /// 男性
        /// </summary>
        Male = 0,

        /// <summary>
        /// 女性
        /// </summary>
        Fmale = 1
    }
}
