using System.ComponentModel.DataAnnotations;

namespace Fx.Entity.Account
{
    /// <summary>
    /// 用户注册模型
    /// </summary>
    public class RegisterUser
    {
        /// <summary>
        /// 昵称
        /// </summary>
        [Required(ErrorMessage = "昵称不能为空")]
        [StringLength(128, MinimumLength = 1, ErrorMessage = "用户名最大长度为128个字符")]        
        public string NickName { get; set; }

        /// <summary>
        /// 邮箱（帐号）
        /// </summary>
        [EmailCheck(ErrorMessage = "请填写正确的邮箱地址")]
        [StringLength(256, MinimumLength = 1, ErrorMessage = "Email最大长度为256个字符")]
        [Required(ErrorMessage = "Email不能为空")]
        public string Email { get; set; }

        /// <summary>
        /// 手机号码
        /// </summary>
        [StringLength(11, ErrorMessage = "手机号码长度为11字符")]
        public string Mobile { get; set; }

        /// <summary>
        /// 密码
        /// </summary>
        [Required(ErrorMessage = "密码不能为空")]
        [StringLength(256, MinimumLength = 1, ErrorMessage = "密码最大长度为256个字符")]
        public string Password { get; set; }

        /// <summary>
        /// QQ
        /// </summary>
        [StringLength(20, MinimumLength = 0, ErrorMessage = "QQ最大长度为20个字符")]
        public string QQ { get; set; }

        /// <summary>
        /// 头像（未使用 考虑使用gravatar来使用头像）
        /// </summary>
        [StringLength(128, MinimumLength = 0, ErrorMessage = "密码最大长度为256个字符")]
        public string HeadPicture { get; set; }

        /// <summary>
        /// 密保问题
        /// </summary>
        [Required(ErrorMessage = "请选择密保问题",AllowEmptyStrings=false)]
        [StringLength(20, MinimumLength = 1, ErrorMessage = "密保问题最大长度为20个字符")]
        public string PasswordQuestion { get; set; }

        /// <summary>
        /// 密保问题答案
        /// </summary>
        [Required(ErrorMessage = "密保问题答案不能为空")]
        [StringLength(20, MinimumLength = 1, ErrorMessage = "密保问题答案最大长度为20个字符")]
        public string PasswordAnswer { get; set; }

        /// <summary>
        /// 验证码
        /// </summary>
        [Required(ErrorMessage = "注册码不能为空")]
        public string VerificationCode { get; set; }
    }
}
