using System.Text.RegularExpressions;

namespace System.ComponentModel.DataAnnotations
{
    /// <summary>
    /// 邮箱帐号验证特性
    /// </summary>
    public class EmailCheckAttribute : ValidationAttribute
    {
        /// <summary>
        /// 是否验证通过
        /// </summary>
        /// <param name="value">验证的内容</param>
        /// <returns>是否是邮箱帐号</returns>
        public override bool IsValid(object value)
        {
            string match = @"^\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$";
            if (value == null || !Regex.IsMatch(value.ToString(), match))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
