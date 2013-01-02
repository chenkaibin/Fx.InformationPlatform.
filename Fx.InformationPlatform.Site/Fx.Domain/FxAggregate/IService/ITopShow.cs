using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Fx.Entity.FxAggregate;
using Fx.Entity.FxCar;
using Fx.Entity.FxGoods;
using Fx.Entity.FxHouse;

namespace Fx.Domain.FxAggregate.IService
{
    /// <summary>
    /// 置顶操作接口 用于一般性的操作
    /// </summary>
    public interface ITopShow
    {
        /// <summary>
        /// 置顶相关帖子
        /// </summary>
        /// <param name="entity">置顶信息</param>
        void TopShow(TopShow entity);

        /// <summary>
        /// 查询指定信息是否已存在
        /// </summary>
        /// <param name="entity">置顶信息</param>
        /// <returns></returns>
        bool IsExist(TopShow entity);

        /// <summary>
        /// 取消置顶信息
        /// </summary>
        /// <param name="entity">置顶信息</param>
        void TopShowCancel(TopShow entity);

        /// <summary>
        /// 获取所有置顶信息
        /// </summary>
        /// <returns></returns>
        List<TopShow> GetAllTopShow();

        /// <summary>
        /// 获取置顶信息
        /// </summary>
        /// <param name="id">置顶id</param>
        /// <returns>置顶信息</returns>
        TopShow GetById(int id);

        
        /// <summary>
        /// 获取车辆转让置顶信息 用于具体频道的展示
        /// </summary>
        /// <returns>车辆信息列表</returns>
        List<CarTransferInfo> GetCarTransferTopShow();

        /// <summary>
        /// 获取物品转让置顶信息 用于具体频道的展示
        /// </summary>
        /// <returns>物品信息列表</returns>
        List<GoodsTransferInfo> GetGoodsTransferTopShow();

        /// <summary>
        /// 获取房屋转让置顶信息 用于具体频道的展示
        /// </summary>
        /// <returns>房屋信息列表</returns>
        List<HouseTransferInfo> GetHouseTransferTopShow();

        /// <summary>
        /// 获取车辆求购置顶信息 用于具体频道的展示
        /// </summary>
        /// <returns>车辆信息列表</returns>
        List<CarBuyInfo> GetCarBuyTopShow();

        /// <summary>
        /// 获取物品求购置顶信息 用于具体频道的展示
        /// </summary>
        /// <returns>物品信息列表</returns>
        List<GoodsBuyInfo> GetGoodsBuyTopShow();

        /// <summary>
        /// 获取房屋求购置顶信息 用于具体频道的展示
        /// </summary>
        /// <returns>房屋信息列表</returns>
        List<HouseBuyInfo> GetHouseBuyTopShow();
    }
}
