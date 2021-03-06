﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Fx.Infrastructure.Data
{
    /// <summary>
    /// 字符串切割帮助类 可以区分中英文 1个中文2个英文长度
    /// </summary>
    public class Cut
    {
        /// <summary>
        /// 获取指定长度的字符串
        /// </summary>
        /// <param name="str">字符串</param>
        /// <param name="len">字符串的英文长度</param>
        /// <returns>结果字符串</returns>
        public static string CutStr(string str, int len)
        {
            if (str == null || str.Length == 0 || len <= 0)
            {
                return string.Empty;
            }

            int l = str.Length;

            #region 计算长度
            int clen = 0;
            while (clen < len && clen < l)
            {
                //每遇到一个中文，则将目标长度减一。
                if ((int)str[clen] > 128) { len--; }
                clen++;
            }
            #endregion

            if (clen < l)
            {
                return str.Substring(0, clen) + "...";
            }
            else
            {
                return str;
            }
        }

        /// <summary>
        /// 获取字符串长度。与string.Length不同的是，该方法将中文作 2 个字符计算。
        /// </summary>
        /// <param name="str">目标字符串</param>
        /// <returns>结果字符串</returns>
        public static int GetLength(string str)
        {
            if (str == null || str.Length == 0) { return 0; }

            int l = str.Length;
            int realLen = l;

            #region 计算长度
            int clen = 0;//当前长度
            while (clen < l)
            {
                //每遇到一个中文，则将实际长度加一。
                if ((int)str[clen] > 128) { realLen++; }
                clen++;
            }
            #endregion

            return realLen;
        }
    }
}
