using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Domain
{
    /// <summary>
    /// 领域处理结果
    /// </summary>
    public class DomainResult
    {
        public DomainResult(bool isSuccess)
        {
            this.isSuccess = isSuccess;
        }

        /// <summary>
        /// 是否成功
        /// </summary>
        public bool isSuccess { get; set; }

        /// <summary>
        /// 结果返回信息
        /// </summary>
        public string ResultMsg { get; set; }

        /// <summary>
        /// 异常信息
        /// </summary>
        public Exception error { get; set; }

        /// <summary>
        /// 标签
        /// </summary>
        public object Tag { get; set; }

        /// <summary>
        /// 默认返回成功
        /// </summary>
        private static DomainResult result = new DomainResult(true);

        /// <summary>
        ///  默认成功
        /// </summary>
        /// <returns></returns>
        public static DomainResult GetDefault()
        {
            return result;
        }

        /// <summary>
        /// 设置返回结果
        /// </summary>
        /// <param name="retultMsg">结果返回信息</param>
        /// <param name="ex">异常信息</param>
        /// <param name="Tag">标签</param>
        /// <param name="isSuccess">是否成功</param>
        /// <returns>领域处理结果</returns>
        public DomainResult SetResult(string retultMsg="", Exception ex = null, string Tag = "",bool isSuccess = false)
        {
            //解决公用一个DomainResult而导致的冲突问题
            var copyone = result.MemberwiseClone() as DomainResult;
            copyone.isSuccess = isSuccess;
            copyone.ResultMsg = retultMsg;
            copyone.error = ex;
            copyone.Tag = Tag;
            return copyone;
        }
    }
}
