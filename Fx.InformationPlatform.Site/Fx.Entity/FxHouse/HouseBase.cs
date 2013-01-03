using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Fx.Entity.FxHouse
{
    /// <summary>
    /// 房屋帖子基类
    /// </summary>
    public class HouseBase : IInfo
    {
        /// <summary>
        /// 默认构造函数
        /// </summary>
        public HouseBase()
        {
            this.CreatedTime = DateTime.Now;
            this.IsDelete = false;
            this.IsPublish = false;
            this.InfoProcessState = (int)ProcessState.Commit;
        }

        /// <summary>
        /// 发布标题 
        /// </summary>
        public string PublishTitle { get; set; }

        /// <summary>
        /// 三级分类Id
        /// </summary>
        public int CatagroyId { get; set; }

        /// <summary>
        /// 价格
        /// </summary>
        public int Price { get; set; }

        /// <summary>
        /// 区域Id
        /// </summary>
        public int AreaId { get; set; }

        /// <summary>
        /// 城市Id
        /// </summary>
        public int CityId { get; set; }

        /// <summary>
        /// 是否包Bill
        /// </summary>
        public bool Bill { get; set; }

        /// <summary>
        /// 是否有基本家具
        /// </summary>
        public bool HasFurniture { get; set; }

        /// <summary>
        /// 房间数量
        /// </summary>
        public int RoomNumber { get; set; }

        /// <summary>
        /// 发布者接收信息邮箱
        /// </summary>
        public virtual string PublishUserEmail { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string Mark { get; set; }

        /// <summary>
        /// 房屋帖子所在控制器
        /// </summary>
        public string Controller { get; set; }

        /// <summary>
        /// 房屋帖子所执行的方法 
        /// </summary>
        public string Action { get; set; }


        /// <summary>
        /// 发布此信息用户的帐号 这里是发布者的Email 因为使用邮箱作为帐号
        /// </summary>
        public virtual string UserAccount { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreatedTime { get; set; }

        /// <summary>
        /// 是否逻辑删除
        /// </summary>
        public bool IsDelete { get; set; }

        /// <summary>
        /// 是否发布
        /// </summary>
        public bool IsPublish { get; set; }

        /// <summary>
        /// 帖子所在状态
        /// </summary>
        public int InfoProcessState { get; set; }

        /// <summary>
        /// 错误信息
        /// </summary>
        public string ErrorMsg { get; set; }
    }
}
