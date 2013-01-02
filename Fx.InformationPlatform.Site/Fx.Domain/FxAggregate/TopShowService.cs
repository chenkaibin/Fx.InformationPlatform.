using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Fx.Domain.FxAggregate.IService;
using Fx.Domain.FxCar.IService;
using Fx.Domain.FxGoods.IService;
using Fx.Domain.FxHouse.IService;
using Fx.Entity;
using Fx.Entity.FxAggregate;
using Fx.Entity.FxCar;
using Fx.Entity.FxGoods;
using Fx.Entity.FxHouse;

namespace Fx.Domain.FxAggregate
{
    /// <summary>
    /// 聚合信息之置顶服务
    /// </summary>
    public class TopShowService : ITopShow, IHomeTopShow
    {
        /// <summary>
        /// 车辆求购保存读取接口
        /// </summary>
        protected IBuyCar buyCarService;
        /// <summary>
        /// 车辆转让保存读取接口
        /// </summary>
        protected ITransferCar transferCarService;
        /// <summary>
        /// 房屋求购保存读取接口
        /// </summary>
        protected IBuyHouse buyHouseService;
        /// <summary>
        /// 房屋转让保存读取接口
        /// </summary>
        protected ITransferHouse transferHouseService;
        /// <summary>
        /// 物品求购保存读取接口
        /// </summary>
        protected IBuyGoods buyGoodsService;
        /// <summary>
        /// 物品转让保存读取接口
        /// </summary>
        protected ITransferGoods transferGoodsService;

        /// <summary>
        /// 默认构造函数
        /// </summary>
        /// <param name="buyCarService">车辆求购保存读取接口</param>
        /// <param name="transferCarService">车辆转让保存读取接口</param>
        /// <param name="buyHouseService">房屋求购保存读取接口</param>
        /// <param name="transferHouseService">房屋转让保存读取接口</param>
        /// <param name="buyGoodsService">物品求购保存读取接口</param>
        /// <param name="transferGoodsService">物品转让保存读取接口</param>
        public TopShowService(IBuyCar buyCarService,
            ITransferCar transferCarService,
            IBuyHouse buyHouseService,
            ITransferHouse transferHouseService,
            IBuyGoods buyGoodsService,
            ITransferGoods transferGoodsService)
        {
            this.buyCarService = buyCarService;
            this.buyGoodsService = buyGoodsService;
            this.buyHouseService = buyHouseService;
            this.transferCarService = transferCarService;
            this.transferGoodsService = transferGoodsService;
            this.transferHouseService = transferHouseService;
        }

        /// <summary>
        /// 置顶相关帖子
        /// </summary>
        /// <param name="entity">置顶信息</param>
        public void TopShow(TopShow entity)
        {
            if (!IsExist(entity))
            {
                using (var content = new FxAggregateContext())
                {
                    content.TopShows.Add(entity);
                    content.SaveChanges();
                }
            }
        }

        /// <summary>
        /// 查询指定信息是否已存在
        /// </summary>
        /// <param name="entity">置顶信息</param>
        /// <returns></returns>
        public bool IsExist(TopShow entity)
        {
            return GetById(entity.TopShowId) != null;
        }


        /// <summary>
        /// 取消置顶信息
        /// </summary>
        /// <param name="entity">置顶信息</param>
        public void TopShowCancel(TopShow entity)
        {
            if (IsExist(entity))
            {
                using (var content = new FxAggregateContext())
                {
                    entity = content.TopShows
                    .Where(r => r.TopShowId == entity.TopShowId)
                    .FirstOrDefault();
                    if (entity != null)
                    {
                        content.TopShows.Remove(entity);
                        content.SaveChanges();
                    }
                }
            }
        }

        /// <summary>
        /// 获取所有置顶信息
        /// </summary>
        /// <returns></returns>
        public List<TopShow> GetAllTopShow()
        {
            using (var content = new FxAggregateContext())
            {
                return content.TopShows.ToList();
            }
        }

        /// <summary>
        /// 获取置顶信息
        /// </summary>
        /// <param name="id">置顶id</param>
        /// <returns>置顶信息</returns>
        public TopShow GetById(int id)
        {
            using (var content = new FxAggregateContext())
            {
                return content.TopShows.Where(r => r.TopShowId == id).FirstOrDefault();
            }
        }

        /// <summary>
        /// 获取车辆转让置顶信息 用于具体频道的展示
        /// </summary>
        /// <returns>车辆信息列表</returns>
        public List<CarTransferInfo> GetCarTransferTopShow()
        {
            var topShows = new List<TopShow>();
            var cars = new List<CarTransferInfo>();
            using (var content = new FxAggregateContext())
            {
                topShows = content.TopShows.Where(r => r.ChannelCatagroy == (int)ChannelCatagroy.FxCarTransfer).ToList();
            }
            foreach (var item in topShows)
            {
                cars.Add(this.transferCarService.Get(item.InfoId));
            }
            return cars;
        }

        /// <summary>
        /// 获取物品转让置顶信息 用于具体频道的展示
        /// </summary>
        /// <returns>物品信息列表</returns>
        public List<GoodsTransferInfo> GetGoodsTransferTopShow()
        {
            var topShows = new List<TopShow>();
            var goods = new List<GoodsTransferInfo>();
            using (var content = new FxAggregateContext())
            {
                topShows = content.TopShows.Where(r => r.ChannelCatagroy == (int)ChannelCatagroy.FxGoodsTransfer).ToList();
            }
            foreach (var item in topShows)
            {
                goods.Add(this.transferGoodsService.Get(item.InfoId));
            }
            return goods;
        }

        /// <summary>
        /// 获取房屋转让置顶信息 用于具体频道的展示
        /// </summary>
        /// <returns>房屋信息列表</returns>
        public List<HouseTransferInfo> GetHouseTransferTopShow()
        {
            var topShows = new List<TopShow>();
            var houses = new List<HouseTransferInfo>();
            using (var content = new FxAggregateContext())
            {
                topShows = content.TopShows.Where(r => r.ChannelCatagroy == (int)ChannelCatagroy.FxHouseTrasnfer).ToList();
            }
            foreach (var item in topShows)
            {
                houses.Add(this.transferHouseService.Get(item.InfoId));
            }
            return houses;
        }

        /// <summary>
        /// 获取车辆求购置顶信息 用于具体频道的展示
        /// </summary>
        /// <returns>车辆信息列表</returns>
        public List<CarBuyInfo> GetCarBuyTopShow()
        {
            var topShows = new List<TopShow>();
            var cars = new List<CarBuyInfo>();
            using (var content = new FxAggregateContext())
            {
                topShows = content.TopShows.Where(r => r.ChannelCatagroy == (int)ChannelCatagroy.FxCarBuy).ToList();
            }
            foreach (var item in topShows)
            {
                cars.Add(buyCarService.Get(item.InfoId));
            }
            return cars;
        }

        /// <summary>
        /// 获取物品求购置顶信息 用于具体频道的展示
        /// </summary>
        /// <returns>物品信息列表</returns>
        public List<GoodsBuyInfo> GetGoodsBuyTopShow()
        {
            var topShows = new List<TopShow>();
            var goods = new List<GoodsBuyInfo>();
            using (var content = new FxAggregateContext())
            {
                topShows = content.TopShows.Where(r => r.ChannelCatagroy == (int)ChannelCatagroy.FxGoodsBuy).ToList();
            }
            foreach (var item in topShows)
            {
                goods.Add(this.buyGoodsService.Get(item.InfoId));
            }
            return goods;
        }

        /// <summary>
        /// 获取房屋求购置顶信息 用于具体频道的展示
        /// </summary>
        /// <returns>房屋信息列表</returns>
        public List<HouseBuyInfo> GetHouseBuyTopShow()
        {
            var topShows = new List<TopShow>();
            var houses = new List<HouseBuyInfo>();
            using (var content = new FxAggregateContext())
            {
                topShows = content.TopShows.Where(r => r.ChannelCatagroy == (int)ChannelCatagroy.FxHouseBuy).ToList();
            }
            foreach (var item in topShows)
            {
                houses.Add(this.buyHouseService.Get(item.InfoId));
            }
            return houses;
        }

        /// <summary>
        /// 获取首页车辆的置顶展示
        /// </summary>
        /// <returns></returns>
        public List<CarTransferInfo> GetHomeCarTopShow()
        {
            var topShows = new List<TopShow>();
            var cars = new List<CarTransferInfo>();
            using (var content = new FxAggregateContext())
            {
                topShows = content.TopShows.Where(r => r.ChannelCatagroy == (int)ChannelCatagroy.FxCarTransfer).ToList();
            }
            foreach (var item in topShows)
            {
                cars.Add(new CarTransferInfo()
                {
                    CarTransferInfoId = item.InfoId,
                    Price = item.Price,
                    PublishTitle = item.Title,
                    Pictures = new List<TransferPicture>() { 
                        new  TransferPicture(){
                             TransferPictureCatagroy= (int)PictureCatagroy.Head,
                             ImageUrl=item.HeadPicture,
                        }
                    }
                });
            }
            return cars;
        }

        /// <summary>
        /// 获取首页物品的置顶展示
        /// </summary>
        /// <returns></returns>
        public List<GoodsTransferInfo> GetHomeGoodsTopShow()
        {
            var topShows = new List<TopShow>();
            var goods = new List<GoodsTransferInfo>();
            using (var content = new FxAggregateContext())
            {
                topShows = content.TopShows.Where(r => r.ChannelCatagroy == (int)ChannelCatagroy.FxGoodsTransfer).ToList();
            }
            foreach (var item in topShows)
            {
                goods.Add(new GoodsTransferInfo()
                {
                    GoodsTransferInfoId = item.InfoId,
                    Price = item.Price,
                    PublishTitle = item.Title,
                    Pictures = new List<TransferPicture>() { 
                        new  TransferPicture(){
                             TransferPictureCatagroy= (int)PictureCatagroy.Head,
                             ImageUrl=item.HeadPicture,
                        }
                    }
                });
            }
            return goods;
        }

        /// <summary>
        /// 获取首页房屋的置顶展示
        /// </summary>
        /// <returns></returns>
        public List<HouseTransferInfo> GetHomeHouseTopShow()
        {
            var topShows = new List<TopShow>();
            var houses = new List<HouseTransferInfo>();
            using (var content = new FxAggregateContext())
            {
                topShows = content.TopShows.Where(r => r.ChannelCatagroy == (int)ChannelCatagroy.FxHouseTrasnfer).ToList();
            }
            foreach (var item in topShows)
            {
                houses.Add(new HouseTransferInfo()
                {
                    HouseTransferInfoId = item.InfoId,
                    Price = item.Price,
                    PublishTitle = item.Title,
                    Pictures = new List<TransferPicture>() { 
                        new  TransferPicture(){
                             TransferPictureCatagroy= (int)PictureCatagroy.Head,
                             ImageUrl=item.HeadPicture,
                        }
                    }
                });
            }
            return houses;
        }
    }
}
