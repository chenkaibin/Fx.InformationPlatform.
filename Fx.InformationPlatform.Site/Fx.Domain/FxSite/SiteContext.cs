using System.Data.Entity;
using Fx.Domain.Account.Mapping;
using Fx.Domain.Account.Mapping.Other;
using Fx.Domain.FxSite.Mapping;
using Fx.Entity.FxSite;
using Fx.Entity.MemberShip;

namespace Fx.Domain
{
    /// <summary>
    /// 站点上下文
    /// </summary>
    public class SiteContext : DbContext
    {
        static SiteContext()
        {
            System.Data.Entity.Database.SetInitializer(new SiteInitializer());
        }

        /// <summary>
        /// 默认构造函数,,读取数据库字符串fx.site-sqlserver
        /// </summary>
        public SiteContext()
            : base("fx.site-sqlserver")
        {
           
        }

        /// <summary>
        /// 站点上下文数据库如何创建
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //User
            modelBuilder.Configurations.Add(new Applications_Mapping());
            modelBuilder.Configurations.Add(new Membership_Mapping());
            modelBuilder.Configurations.Add(new Paths_Mapping());
            modelBuilder.Configurations.Add(new PersonalizationAllUsers_Mapping());
            modelBuilder.Configurations.Add(new PersonalizationPerUser_Mapping());
            modelBuilder.Configurations.Add(new Profile_Mapping());
            modelBuilder.Configurations.Add(new Roles_Mapping());
            modelBuilder.Configurations.Add(new SchemaVersions_Mapping());
            modelBuilder.Configurations.Add(new Users_Mapping());
            modelBuilder.Configurations.Add(new WebEvent_Events_Mapping());
            //User Extend
            modelBuilder.Configurations.Add(new OtherInformation_Mapping());

            //ELMAH
            modelBuilder.Configurations.Add(new ELMAH_Error_Mapping());

            //Site
            modelBuilder.Configurations.Add(new Area_Mapping());
            modelBuilder.Configurations.Add(new City_Mapping());
            modelBuilder.Configurations.Add(new GoodsConditions_Mapping());
            modelBuilder.Configurations.Add(new Channel_Mapping());
            modelBuilder.Configurations.Add(new ChannelList_Mapping());
            modelBuilder.Configurations.Add(new ChannelListDetail_Mapping());
        }

        //public DbSet<Applications> Applications { get; set; }
        /// <summary>
        /// Membership聚合根
        /// </summary>
        public DbSet<Membership> Memberships { get; set; }
        //public DbSet<Paths> Paths { get; set; }
        //public DbSet<PersonalizationAllUsers> PersonalizationAllUsers { get; set; }
        //public DbSet<PersonalizationPerUser> PersonalizationPerUsers { get; set; }
        //public DbSet<Profile> Profiles { get; set; }
        //public DbSet<Roles> Roles { get; set; }
        //public DbSet<SchemaVersions> SchemaVersions { get; set; }
        /// <summary>
        /// 用户聚合根 暂时用于查询UserId和ApplicationId
        /// </summary>
        public DbSet<Users> Users { get; set; }
        //public DbSet<WebEvent_Events> WebEvent_Events { get; set; }
       
        /// <summary>
        /// 用户扩展信息聚合根
        /// </summary>
        public DbSet<OtherInformation> OtherInformations { get; set; }
        
        /// <summary>
        /// ELMAH聚合根
        /// </summary>
        public DbSet<ELMAH_Error> ELMAHErrors { get; set; }


        //Site
        /// <summary>
        /// 区域聚合根
        /// </summary>
        public DbSet<Area> Areas { get; set; }
        /// <summary>
        /// 城市聚合根
        /// </summary>
        public DbSet<City> Cities { get; set; }
        /// <summary>
        /// 一级频道聚合根
        /// </summary>
        public DbSet<Channel> Channels { get; set; }
        /// <summary>
        /// 二级频道聚合根
        /// </summary>
        public DbSet<ChannelList> ChannelLists { get; set; }

        /// <summary>
        /// 物品新旧程度聚合根 后期整顿!!TODO
        /// </summary>
        public DbSet<GoodsCondition> GoodsConditions { get; set; }
    }
}
