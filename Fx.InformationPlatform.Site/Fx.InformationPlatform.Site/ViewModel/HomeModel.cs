using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Fx.InformationPlatform.Site.ViewModel
{
    /// <summary>
    /// 首页视图模型
    /// </summary>
    public class HomeModel
    {
        /// <summary>
        /// 首页物品视图模型
        /// </summary>
        public HomeGoodsModel HomeGoodsModel { get; set; }

        /// <summary>
        /// 首页车辆视图模型
        /// </summary>
        public HomeCarModel HomeCarModel { get; set; }

        /// <summary>
        /// 首页房屋视图模型
        /// </summary>
        public HomeHouseModel HomeHouseModel { get; set; }

        /// <summary>
        /// 默认构造函数
        /// </summary>
        public HomeModel()
        {
            this.HomeCarModel = new HomeCarModel();
            this.HomeGoodsModel = new HomeGoodsModel();
            this.HomeHouseModel = new HomeHouseModel();
        }
    }

    /// <summary>
    /// 首页物品视图模型
    /// </summary>
    public class HomeGoodsModel
    {
        /// <summary>
        /// 物品第一栏
        /// </summary>
        public List<Fx.Entity.FxGoods.GoodsTransferInfo> GoodsTransferInfo1s { get; set; }

        /// <summary>
        /// 物品第二栏
        /// </summary>
        public List<Fx.Entity.FxGoods.GoodsTransferInfo> GoodsTransferInfo2s { get; set; }

        /// <summary>
        /// 物品第三栏
        /// </summary>
        public List<Fx.Entity.FxGoods.GoodsTransferInfo> GoodsTransferInfo3s { get; set; }

        /// <summary>
        /// 默认构造函数
        /// </summary>
        public HomeGoodsModel()
        {
            this.GoodsTransferInfo1s = new List<Entity.FxGoods.GoodsTransferInfo>();
            this.GoodsTransferInfo2s = new List<Entity.FxGoods.GoodsTransferInfo>();
            this.GoodsTransferInfo3s = new List<Entity.FxGoods.GoodsTransferInfo>();
        }
    }

    /// <summary>
    /// 首页车辆视图模型
    /// </summary>
    public class HomeCarModel
    {
        /// <summary>
        /// 车辆第一栏
        /// </summary>
        public List<Fx.Entity.FxCar.CarTransferInfo> CarTransferInfo1s { get; set; }

        /// <summary>
        /// 车辆第二栏
        /// </summary>
        public List<Fx.Entity.FxCar.CarTransferInfo> CarTransferInfo2s { get; set; }

        /// <summary>
        /// 车辆第三栏
        /// </summary>
        public List<Fx.Entity.FxCar.CarTransferInfo> CarTransferInfo3s { get; set; }

        /// <summary>
        /// 默认构造函数
        /// </summary>
        public HomeCarModel()
        {
            this.CarTransferInfo1s = new List<Entity.FxCar.CarTransferInfo>();
            this.CarTransferInfo2s = new List<Entity.FxCar.CarTransferInfo>();
            this.CarTransferInfo3s = new List<Entity.FxCar.CarTransferInfo>();
        }
    }

    /// <summary>
    /// 首页房屋视图模型
    /// </summary>
    public class HomeHouseModel
    {
        /// <summary>
        /// 房屋第一栏
        /// </summary>
        public List<Fx.Entity.FxHouse.HouseTransferInfo> HouseTransferInfo1s { get; set; }

        /// <summary>
        /// 房屋第二栏
        /// </summary>
        public List<Fx.Entity.FxHouse.HouseTransferInfo> HouseTransferInfo2s { get; set; }

        /// <summary>
        /// 房屋第三栏
        /// </summary>
        public List<Fx.Entity.FxHouse.HouseTransferInfo> HouseTransferInfo3s { get; set; }

        /// <summary>
        /// 默认构造函数
        /// </summary>
        public HomeHouseModel()
        {
            this.HouseTransferInfo1s = new List<Entity.FxHouse.HouseTransferInfo>();
            this.HouseTransferInfo2s = new List<Entity.FxHouse.HouseTransferInfo>();
            this.HouseTransferInfo3s = new List<Entity.FxHouse.HouseTransferInfo>();
        }
    }

}