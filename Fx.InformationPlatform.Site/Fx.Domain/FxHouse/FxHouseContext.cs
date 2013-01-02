using System;
using System.Data.Entity;
using Fx.Domain.FxHouse.Mapping;
using Fx.Entity;
using Fx.Entity.FxHouse;

namespace Fx.Domain.FxHouse
{
    /// <summary>
    /// 房屋上下文
    /// </summary>
    public class FxHouseContext : DbContext
    {
        static FxHouseContext()
        {
            //System.Data.Entity.Database.SetInitializer(new FxHouseInitializer());
        }

        public FxHouseContext()
            : base("fx.house-sqlserver")
        {

        }

        public FxHouseContext(string nameOrConnectionString)
            :base(nameOrConnectionString)
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Configurations.Add(new HouseBuyInfo_Mapping());
            modelBuilder.Configurations.Add(new HouseBuyLogs_Mapping());
            modelBuilder.Configurations.Add(new HouseTransferInfo_Mapping());
            modelBuilder.Configurations.Add(new HouseTransferLogs_Mapping());
            modelBuilder.Configurations.Add(new PictureCdnErrors_Mapping());
            modelBuilder.Configurations.Add(new TransferPicture_Mapping());
        }

        /// <summary>
        /// 房屋转让
        /// </summary>
        public DbSet<HouseTransferInfo> HouseTransferInfos { get; set; }
        /// <summary>
        /// 房屋求购
        /// </summary>
        public DbSet<HouseBuyInfo> HouseBuyInfos { get; set; }
        /// <summary>
        /// 图片CND错误  暂时用于监测图片错误信息 不正确的图片格式等导致意外的错误
        /// </summary>
        public DbSet<PictureCdnError> PictureCdnErrors { get; set; }
    }
}
