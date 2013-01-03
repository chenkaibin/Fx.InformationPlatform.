using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Fx.InformationPlatform.Site
{
    /// <summary>
    /// 站点Job运行接口
    /// </summary>
    public interface ISiteJob
    {
        /// <summary>
        /// Job运行
        /// </summary>
        void RunJob();
    }
}