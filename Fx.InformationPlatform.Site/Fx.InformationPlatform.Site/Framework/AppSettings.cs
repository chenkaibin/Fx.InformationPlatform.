using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Fx.Infrastructure.Caching;
using SimpleInjector;

namespace Fx.InformationPlatform.Site
{
    /// <summary>
    /// 配置文件
    /// </summary>
    public class AppSettings
    {
        static ICacheManager cacheService;

        static AppSettings()
        {
            cacheService = DependencyResolver.Current.GetService<ICacheManager>();
        }
        #region Private Methods

        private static string GetValue(string Key)
        {
            string Value = ConfigurationManager.AppSettings[Key];
            if (!string.IsNullOrEmpty(Value))
            {
                return Value;
            }
            return string.Empty;
        }

        private static string GetString(string Key, string DefaultValue)
        {
            string Setting = GetValue(Key);
            if (!string.IsNullOrEmpty(Setting))
            {
                return Setting;
            }
            return DefaultValue;
        }

        private static bool GetBool(string Key, bool DefaultValue)
        {
            string Setting = GetValue(Key);
            if (!string.IsNullOrEmpty(Setting))
            {
                switch (Setting.ToLower())
                {
                    case "false":
                    case "0":
                    case "n":
                        return false;
                    case "true":
                    case "1":
                    case "y":
                        return true;
                }
            }
            return DefaultValue;
        }

        private static int GetInt(string Key, int DefaultValue)
        {
            string Setting = GetValue(Key);
            if (!string.IsNullOrEmpty(Setting))
            {
                int i;
                if (int.TryParse(Setting, out i))
                {
                    return i;
                }
            }
            return DefaultValue;
        }

        private static double GetDouble(string Key, double DefaultValue)
        {
            string Setting = GetValue(Key);
            if (!string.IsNullOrEmpty(Setting))
            {
                double d;
                if (double.TryParse(Setting, out d))
                {
                    return d;
                }
            }
            return DefaultValue;
        }

        private static byte GetByte(string Key, byte DefaultValue)
        {
            string Setting = GetValue(Key);
            if (!string.IsNullOrEmpty(Setting))
            {
                byte b;
                if (byte.TryParse(Setting, out b))
                {
                    return b;
                }
            }
            return DefaultValue;
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// 站点名称
        /// </summary>
        public static string SiteName
        {
            get { return GetString("SiteName", "英淘网"); }
        }

        /// <summary>
        /// 默认语言
        /// </summary>
        public static string DefaultLanguage
        {
            get { return GetString("DefaultLanguage", "zh-CN"); }  //en-US
        }

        /// <summary>
        /// 脚本域名地址
        /// </summary>
        /// <param name="jsFileorPath">文件名称或者局部地址</param>
        /// <returns>脚本域名地址</returns>
        public static string JavaScriptDomain(string jsFileorPath)
        {
            return GetString("JavaScriptDomain", "http://localhost:9999/Content/js/") + jsFileorPath;
        }

        /// <summary>
        /// CSS域名地址
        /// </summary>
        /// <param name="cssFileorPath">文件名称或者局部地址</param>
        /// <returns>CSS</returns>
        public static string CssDomain(string cssFileorPath)
        {
            return GetString("CssDomain", "http://localhost:9999/Content/css/") + cssFileorPath;
        }

        /// <summary>
        /// 图片域名地址
        /// </summary>
        /// <param name="imageFileorPath">文件名称或者局部地址</param>
        /// <returns>图片域名地址</returns>
        public static string ImageDomain(string imageFileorPath)
        {
            return GetString("ImageDomain", "http://localhost:9999/Content/images/") + imageFileorPath;
        }

        /// <summary>
        /// 上传图片域名地址
        /// </summary>
        /// <param name="imageFileorPath">文件名称或者局部地址</param>
        /// <returns>上传图片域名地址</returns>
        public static string ImageUploadCdnDomain(string imageFileorPath)
        {
            return GetString("ImageUploadCdnDomain", "http://uploadcdn.yingtao.co.uk/") + imageFileorPath;
        }

        /// <summary>
        /// 英淘网Url
        /// </summary>
        /// <returns>英淘网Url</returns>
        public static string YingTaoUrl()
        {
            if (cacheService.Get("YingTaoUrl") == null)
            {
                cacheService.Insert("YingTaoUrl", GetString("YingTaoUrl", "http://yingtao.co.uk/"), 3600, System.Web.Caching.CacheItemPriority.Default);
            }
            object o = cacheService.Get("YingTaoUrl");
            if (o != null)
            {
                return o.ToString();
            }
            return "";
        }

        /// <summary>
        /// 物品转让链接
        /// </summary>
        /// <param name="id">帖子Id</param>
        /// <returns>物品转让链接</returns>
        public static string GoodsTransferLink(int id)
        {
            return string.Format("{0}{1}/{2}/{3}", YingTaoUrl(), "GoodsTransferDetail", "Index", id);
        }

        /// <summary>
        /// 物品求购链接
        /// </summary>
        /// <param name="id">帖子Id</param>
        /// <returns>物品求购链接</returns>
        public static string GoodsBuyLink(int id)
        {
            return string.Format("{0}{1}/{2}/{3}", YingTaoUrl(), "GoodsBuyDetail", "Index", id);
        }

        /// <summary>
        /// 房屋转让链接
        /// </summary>
        /// <param name="id">帖子Id</param>
        /// <returns>房屋转让链接</returns>
        public static string HouseTransferLink(int id)
        {
            return string.Format("{0}{1}/{2}/{3}", YingTaoUrl(), "HouseTransferDetail", "Index", id);
        }

        /// <summary>
        /// 房屋求购链接
        /// </summary>
        /// <param name="id">帖子Id</param>
        /// <returns>房屋求购链接</returns>
        public static string HouseBuyLink(int id)
        {
            return string.Format("{0}{1}/{2}/{3}", YingTaoUrl(), "HouseBuyDetail", "Index", id);
        }

        /// <summary>
        /// 车辆转让链接
        /// </summary>
        /// <param name="id">帖子Id</param>
        /// <returns>车辆转让链接</returns>
        public static string CarTransferLink(int id)
        {
            return string.Format("{0}{1}/{2}/{3}", YingTaoUrl(), "CarTransferDetail", "Index", id);
        }

        /// <summary>
        /// 车辆求购链接
        /// </summary>
        /// <param name="id">帖子Id</param>
        /// <returns>车辆求购链接</returns>
        public static string CarBuyLink(int id)
        {
            return string.Format("{0}{1}/{2}/{3}", YingTaoUrl(), "CarBuyDetail", "Index", id);
        }





        /// <summary>
        /// 允许上传的图片MINE格式
        /// </summary>
        /// <returns>格式数组</returns>
        public static string[] PictureMINE()
        {
            if (cacheService.Get("FxSitePictureMINE") == null)
            {
                cacheService.Insert("FxSitePictureMINE", GetString("PictureMIME", "jpg|jpeg|png|gif|bmp"), 3600, System.Web.Caching.CacheItemPriority.Normal);
            }
            var mines = (cacheService.Get("FxSitePictureMINE") as string).Split('|').ToArray();
            return mines;
        }

        /// <summary>
        /// Cookie表单认证Form的域名信息 yingtao.co.uk
        /// </summary>
        public static string FormDomain
        {
            get { return GetString("FormDomain", "yingtao.co.uk"); }
        }
        #endregion

    }
}