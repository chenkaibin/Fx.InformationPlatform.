﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Fx.Domain.FxCar.IService
{
    /// <summary>
    /// 车辆Job任务接口
    /// </summary>
    public interface ICarBuyJob
    {
        /// <summary>
        /// 认证中...
        /// </summary>
        /// <param name="carId">车辆帖子id</param>
        /// <returns>是否成功</returns>
        bool Authorizing(int carId);

        /// <summary>
        /// 认证成功
        /// </summary>
        /// <param name="carId">车辆帖子id</param>
        /// <returns>是否成功</returns>
        bool AuthorizeSuccess(int carId);

        /// <summary>
        /// 认证失败
        /// </summary>
        /// <param name="carId">车辆帖子id</param>
        /// <param name="msg">错误信息</param>
        /// <returns>是否成功</returns>
        bool AuthorizeFaild(int carId, string msg);

        /// <summary>
        /// 发布
        /// </summary>
        /// <param name="carId">车辆帖子id</param>
        /// <returns>是否成功</returns>
        bool Publish(int carId);

        /// <summary>
        /// 帖子延期
        /// </summary>
        /// <param name="carId">车辆帖子id</param>
        /// <returns>是否成功</returns>
        bool Delay(int carId);

        /// <summary>
        /// 以成交
        /// </summary>
        /// <param name="carId">车辆帖子id</param>
        /// <returns>是否成功</returns>
        bool End(int carId);

        /// <summary>
        /// 不删除状态 （置顶中）
        /// </summary>
        /// <param name="carId">车辆帖子id</param>
        /// <returns>是否成功</returns>
        bool NoDelete(int carId);

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="carId">车辆帖子id</param>
        /// <returns>是否成功</returns>
        bool Delete(int carId);
    }
}
