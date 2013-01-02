using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Fx.Domain.FxCar.IService;
using Fx.Entity;

namespace Fx.Domain.FxCar
{
    /// <summary>
    /// 车辆转让Job服务
    /// </summary>
    public class CarTransferJobService : ICarTransferJob
    {
        /// <summary>
        /// 认证中...
        /// </summary>
        /// <param name="carId">车辆帖子id</param>
        /// <returns>是否成功</returns>
        public bool Authorizing(int carId)
        {
            using (var context = new FxCarContext())
            {
                var car = context.CarTransferInfos.Where(r => r.CarTransferInfoId == carId).FirstOrDefault();
                if (car != null)
                {
                    car.InfoProcessState = (int)ProcessState.Authorizing;
                    car.Logs.Add(new Entity.FxCar.CarTransferLog()
                    {
                        OperteName = Enum.GetName(typeof(ProcessState), ProcessState.Authorizing)
                    });
                    return context.SaveChanges() > 0;
                }
            }
            return false;
        }

        /// <summary>
        /// 认证成功
        /// </summary>
        /// <param name="carId">车辆帖子id</param>
        /// <returns>是否成功</returns>
        public bool AuthorizeSuccess(int carId)
        {
            using (var context = new FxCarContext())
            {
                var car = context.CarTransferInfos.Where(r => r.CarTransferInfoId == carId).FirstOrDefault();
                if (car != null)
                {
                    car.InfoProcessState = (int)ProcessState.AuthorizeSuccess;
                    car.Logs.Add(new Entity.FxCar.CarTransferLog()
                    {
                        OperteName = Enum.GetName(typeof(ProcessState), ProcessState.AuthorizeSuccess)
                    });
                    return context.SaveChanges() > 0;
                }
            }
            return false;
        }

        /// <summary>
        /// 认证失败
        /// </summary>
        /// <param name="carId">车辆帖子id</param>
        /// <param name="msg"></param>
        /// <returns>是否成功</returns>
        public bool AuthorizeFaild(int carId,string msg)
        {
            using (var context = new FxCarContext())
            {
                var car = context.CarTransferInfos.Where(r => r.CarTransferInfoId == carId).FirstOrDefault();
                if (car != null)
                {
                    car.InfoProcessState = (int)ProcessState.AuthorizeFaild;
                    car.ErrorMsg = msg;
                    car.Logs.Add(new Entity.FxCar.CarTransferLog()
                    {
                        OperteName = Enum.GetName(typeof(ProcessState), ProcessState.AuthorizeFaild)
                    });
                    return context.SaveChanges() > 0;
                }
            }
            return false;
        }

        /// <summary>
        /// 图片CDN中...
        /// </summary>
        /// <param name="carId">车辆帖子id</param>
        /// <returns>是否成功</returns>
        public bool PictrueCdning(int carId)
        {
            using (var context = new FxCarContext())
            {
                var car = context.CarTransferInfos.Where(r => r.CarTransferInfoId == carId).FirstOrDefault();
                if (car != null)
                {
                    car.InfoProcessState = (int)ProcessState.PictrueCdning;
                    car.Logs.Add(new Entity.FxCar.CarTransferLog()
                    {
                        OperteName = Enum.GetName(typeof(ProcessState), ProcessState.PictrueCdning)
                    });
                    return context.SaveChanges() > 0;
                }
            }
            return false;
        }

        /// <summary>
        /// 图片CDN成功
        /// </summary>
        /// <param name="carId">车辆帖子id</param>
        /// <returns></returns>
        public bool PictrueCdnSuccessd(int carId)
        {
            using (var context = new FxCarContext())
            {
                var car = context.CarTransferInfos.Where(r => r.CarTransferInfoId == carId).FirstOrDefault();
                if (car != null)
                {
                    car.InfoProcessState = (int)ProcessState.PictrueCdnSuccessd;
                    car.Logs.Add(new Entity.FxCar.CarTransferLog()
                    {
                        OperteName = Enum.GetName(typeof(ProcessState), ProcessState.PictrueCdnSuccessd)
                    });
                    return context.SaveChanges() > 0;
                }
            }
            return false;
        }

        /// <summary>
        /// 图片CDN失败
        /// </summary>
        /// <param name="carId">车辆帖子id</param>
        /// <param name="errorMsg">错误信息</param>
        /// <returns>是否成功</returns>
        public bool PictrueCdnFailed(int carId, string errorMsg)
        {
            using (var context = new FxCarContext())
            {
                var car = context.CarTransferInfos.Where(r => r.CarTransferInfoId == carId).FirstOrDefault();
                if (car != null)
                {
                    car.InfoProcessState = (int)ProcessState.PictrueCdnFailed;
                    car.Logs.Add(new Entity.FxCar.CarTransferLog()
                    {
                        OperteName = Enum.GetName(typeof(ProcessState), ProcessState.PictrueCdnFailed)
                    });
                    context.PictureCdnErrors.Add(new PictureCdnError()
                    {
                        ErorMsg = errorMsg,
                        ObjectId = carId,
                        SourceType = (int)ChannelCatagroy.FxCarTransfer
                    });
                    return context.SaveChanges() > 0;
                }
            }
            return false;
        }

        /// <summary>
        /// Job调度完成
        /// </summary>
        /// <param name="carId">车辆帖子id</param>
        /// <returns>是否成功</returns>
        public bool JobSuccess(int carId)
        {
            using (var context = new FxCarContext())
            {
                var car = context.CarTransferInfos.Where(r => r.CarTransferInfoId == carId).FirstOrDefault();
                if (car != null)
                {
                    car.InfoProcessState = (int)ProcessState.JobSuccess;
                    car.Logs.Add(new Entity.FxCar.CarTransferLog()
                    {
                        OperteName = Enum.GetName(typeof(ProcessState), ProcessState.JobSuccess)
                    });
                    return context.SaveChanges() > 0;
                }
            }
            return false;
        }

        /// <summary>
        /// 发布
        /// </summary>
        /// <param name="carId">车辆帖子id</param>
        /// <returns>是否成功</returns>
        public bool Publish(int carId)
        {
            using (var context = new FxCarContext())
            {
                var car = context.CarTransferInfos.Where(r => r.CarTransferInfoId == carId).FirstOrDefault();
                if (car != null)
                {
                    car.InfoProcessState = (int)ProcessState.Publish;
                    car.IsPublish = true;
                    car.Logs.Add(new Entity.FxCar.CarTransferLog()
                    {
                        OperteName = Enum.GetName(typeof(ProcessState), ProcessState.Publish)
                    });
                    return context.SaveChanges() > 0;
                }
            }
            return false;
        }

        /// <summary>
        /// 帖子延期
        /// </summary>
        /// <param name="carId">车辆帖子id</param>
        /// <returns>是否成功</returns>
        public bool Delay(int carId)
        {
            using (var context = new FxCarContext())
            {
                var car = context.CarTransferInfos.Where(r => r.CarTransferInfoId == carId).FirstOrDefault();
                if (car != null)
                {
                    car.InfoProcessState = (int)ProcessState.Delay;
                    car.Logs.Add(new Entity.FxCar.CarTransferLog()
                    {
                        OperteName = Enum.GetName(typeof(ProcessState), ProcessState.Delay)
                    });
                    return context.SaveChanges() > 0;
                }
            }
            return false;
        }

        /// <summary>
        /// 以成交
        /// </summary>
        /// <param name="carId">车辆帖子id</param>
        /// <returns>是否成功</returns>
        public bool End(int carId)
        {
            using (var context = new FxCarContext())
            {
                var car = context.CarTransferInfos.Where(r => r.CarTransferInfoId == carId).FirstOrDefault();
                if (car != null)
                {
                    car.InfoProcessState = (int)ProcessState.End;
                    car.Logs.Add(new Entity.FxCar.CarTransferLog()
                    {
                        OperteName = Enum.GetName(typeof(ProcessState), ProcessState.End)
                    });
                    return context.SaveChanges() > 0;
                }
            }
            return false;
        }
        
        /// <summary>
        /// 不删除状态 （置顶中）
        /// </summary>
        /// <param name="carId">车辆帖子id</param>
        /// <returns>是否成功</returns>
        public bool NoDelete(int carId)
        {
            using (var context = new FxCarContext())
            {
                var car = context.CarTransferInfos.Where(r => r.CarTransferInfoId == carId).FirstOrDefault();
                if (car != null)
                {
                    car.InfoProcessState = (int)ProcessState.NoDelete;
                    car.Logs.Add(new Entity.FxCar.CarTransferLog()
                    {
                        OperteName = Enum.GetName(typeof(ProcessState), ProcessState.NoDelete)
                    });
                    return context.SaveChanges() > 0;
                }
            }
            return false;
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="carId">车辆帖子id</param>
        /// <returns>是否成功</returns>
        public bool Delete(int carId)
        {
            using (var context = new FxCarContext())
            {
                var car = context.CarTransferInfos.Where(r => r.CarTransferInfoId == carId).FirstOrDefault();
                if (car != null)
                {
                    car.InfoProcessState = (int)ProcessState.Delete;
                    car.IsPublish = false;
                    car.IsDelete = true;
                    car.Logs.Add(new Entity.FxCar.CarTransferLog()
                    {
                        OperteName = Enum.GetName(typeof(ProcessState), ProcessState.Delete)
                    });
                    return context.SaveChanges() > 0;
                }
            }
            return false;
        }
    }
}
