using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Fx.Entity
{
    /// <summary>
    /// 求购图片信息
    /// </summary>
    public class BuyPicture
    {
        /// <summary>
        /// 求购图片信息主键Id
        /// </summary>
        public int BuyPictureId { get; set; }

        /// <summary>
        /// 求购图片种类
        /// </summary>
        public int BuyPictureCatagroy { get; set; }

        /// <summary>
        /// 图片物理路径
        /// </summary>
        public string PhysicalPath { get; set; }

        /// <summary>
        /// 图片Url相对地址
        /// </summary>
        public string ImageUrl { get; set; }

        /// <summary>
        /// 是否Cdn
        /// </summary>
        public bool IsCdn { get; set; }

        /// <summary>
        /// CdnUrl
        /// </summary>
        public string CdnUrl { get; set; }

        /// <summary>
        /// 小图片相对路径
        /// </summary>
        public string MinImageUrl { get; set; }

        /// <summary>
        /// 默认构造函数 Cdn默认True
        /// </summary>
        public BuyPicture()
        {
            this.IsCdn = false;
        }
    }
}
