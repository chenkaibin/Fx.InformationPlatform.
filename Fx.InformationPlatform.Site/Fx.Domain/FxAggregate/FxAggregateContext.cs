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
        /// <summary>
        /// 默认构造 ,读取数据库字符串fx.aggregate-sqlserver
        /// </summary>
        public FxAggregateContext()
            : base("fx.aggregate-sqlserver")
        {

        }

        /// <summary>
        /// 模型创建方式
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Configurations.Add(new Favorites_Mapping());
            modelBuilder.Configurations.Add(new PrivateMessage_Mapping());
            modelBuilder.Configurations.Add(new TopShows_Mapping());
            
        }
        /// <summary>
        /// 收藏信息聚合根
        /// </summary>
        public DbSet<Favorite> Favorites { get; set; }
        /// <summary>
        /// 私信聚合根
        /// </summary>
        public DbSet<PrivateMessage> PrivateMessages { get; set; }
        /// <summary>
        /// 置顶信息聚合根
        /// </summary>
        public DbSet<TopShow> TopShows { get; set; }
    }
}
