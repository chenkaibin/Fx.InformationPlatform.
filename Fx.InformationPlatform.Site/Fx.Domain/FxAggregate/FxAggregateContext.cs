using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using Fx.Domain.FxAggregate.Mapping;
using Fx.Entity.FxAggregate;

namespace Fx.Domain.FxAggregate
{
    /// <summary>
    /// 聚合信息上下文
    /// </summary>
    public class FxAggregateContext : DbContext
    {
        static FxAggregateContext()
        {
            //System.Data.Entity.Database.SetInitializer(new FxCarInitializer());
        }

        public FxAggregateContext()
            : base("fx.aggregate-sqlserver")
        {

        }

        public FxAggregateContext(string nameOrConnectionString)
            : base(nameOrConnectionString)
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Configurations.Add(new Favorites_Mapping());
            modelBuilder.Configurations.Add(new PrivateMessage_Mapping());
            modelBuilder.Configurations.Add(new TopShows_Mapping());
            
        }
        /// <summary>
        /// 收藏信息
        /// </summary>
        public DbSet<Favorite> Favorites { get; set; }
        /// <summary>
        /// 私信
        /// </summary>
        public DbSet<PrivateMessage> PrivateMessages { get; set; }
        /// <summary>
        /// 置顶信息
        /// </summary>
        public DbSet<TopShow> TopShows { get; set; }
    }
}
