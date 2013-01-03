using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Fx.InformationPlatform.Site
{
    /// <summary>
    /// T4帮助 用户判断当前环境是否是开发环境
    /// </summary>
    public class T4Helper
    {
        /// <summary>
        /// 是否是开发环境
        /// </summary>
        public static bool IsDebug
        {
            get
            {
#if (DEBUG)
                return true;
#else
                return false;
#endif
            }
        }

    }
}