using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Objects;
using Fx.Domain.FxGoods.Mapping;
using Fx.Entity;
using Fx.Entity.FxGoods;

namespace Fx.Domain.FxGoods
{
    /// <summary>
    /// 物品上下文
    /// </summary>
    public class FxGoodsContext : DbContext
    {
        static FxGoodsContext()
        {
            //System.Data.Entity.Database.SetInitializer(new FxGoodsInitializer());
        }

        public FxGoodsContext()
            : base("fx.goods-sqlserver")
        {

        }

        public FxGoodsContext(string nameOrConnectionString)
            : base(nameOrConnectionString)
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //modelBuilder.Configurations.Add(new GoodsBuyInfo_Mapping());
            //modelBuilder.Configurations.Add(new GoodsTransferInfo_Mapping());
            //modelBuilder.Configurations.Add(new TransferPicture_Mapping());
            //modelBuilder.Configurations.Add(new BuyPicture_Mapping());


            modelBuilder.Configurations.Add(new BuyPicture_Mapping());
            modelBuilder.Configurations.Add(new GoodsBuyInfo_Mapping());
            modelBuilder.Configurations.Add(new GoodsBuyLogs_Mapping());
            modelBuilder.Configurations.Add(new GoodsTransferInfo_Mapping());
            modelBuilder.Configurations.Add(new GoodsTransferLogs_Mapping());
            modelBuilder.Configurations.Add(new PictureCdnErrors_Mapping());
            modelBuilder.Configurations.Add(new TransferPicture_Mapping());

        }
        /// <summary>
        /// 物品转让
        /// </summary>
        public DbSet<GoodsTransferInfo> GoodsTransferInfos { get; set; }
        /// <summary>
        /// 物品求购
        /// </summary>
        public DbSet<GoodsBuyInfo> GoodsBuyInfos { get; set; }
        /// <summary>
        /// 图片CND错误  暂时用于监测图片错误信息 不正确的图片格式等导致意外的错误
        /// </summary>
        public DbSet<PictureCdnError> PictureCdnErrors { get; set; }


    }
}
