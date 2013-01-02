using System;
using System.Data.Entity;
using Fx.Domain.FxCar.Mapping;
using Fx.Entity;
using Fx.Entity.FxCar;

namespace Fx.Domain.FxCar
{
    /// <summary>
    /// 车辆上下文
    /// </summary>
    public class FxCarContext : DbContext
    {
        static FxCarContext()
        {
            //System.Data.Entity.Database.SetInitializer(new FxCarInitializer());
        }

        public FxCarContext()
            : base("fx.car-sqlserver")
        {

        }

        public FxCarContext(string nameOrConnectionString)
            : base(nameOrConnectionString)
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder); 
            modelBuilder.Configurations.Add(new CarBuyInfo_Mapping());
            modelBuilder.Configurations.Add(new CarBuyLogs_Mapping());
            modelBuilder.Configurations.Add(new CarTransferInfo_Mapping());
            modelBuilder.Configurations.Add(new CarTransferLogs_Mapping());
            modelBuilder.Configurations.Add(new PictureCdnErrors_Mapping());
            modelBuilder.Configurations.Add(new TransferPicture_Mapping());
        }

        /// <summary>
        /// 车辆转让
        /// </summary>
        public DbSet<CarTransferInfo> CarTransferInfos { get; set; }
        /// <summary>
        /// 车辆求购 
        /// </summary>
        public DbSet<CarBuyInfo> CarBuyInfos { get; set; }
        /// <summary>
        /// 图片CND错误  暂时用于监测图片错误信息 不正确的图片格式等导致意外的错误
        /// </summary>
        public DbSet<PictureCdnError> PictureCdnErrors { get; set; }
    }
}
