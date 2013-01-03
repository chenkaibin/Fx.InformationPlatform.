using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Fx.InformationPlatform.Site.ViewModel
{
    /// <summary>
    /// 房屋求购视图模型
    /// </summary>
    public class BuyViewHouse
    {
        /// <summary>
        /// 标题
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// 三级分类Id
        /// </summary>
        public int CatagroyId { get; set; }

        /// <summary>
        /// 价格
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// 区域Id
        /// </summary>
        public int AreaId { get; set; }

        /// <summary>
        /// 城市Id
        /// </summary>
        public int CityId { get; set; }

        /// <summary>
        /// 房间数量
        /// </summary>
        public int RoomNumber { get; set; }

        /// <summary>
        /// 是否包Bill
        /// </summary>
        public bool Bill { get; set; }

        /// <summary>
        /// 是否有基本家具
        /// </summary>
        public bool HasFurniture { get; set; }

        /// <summary>
        /// 发布者接收信息邮箱
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string Mark { get; set; }
    }
}