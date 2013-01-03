using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace Fx.Entity
{
    /// <summary>
    /// 帖子处理状态
    /// </summary>
    public enum ProcessState
    {
        /// <summary>
        /// 待审核 = 0
        /// </summary>
        [Description("待审核")]
        Commit = 0,

        /// <summary>
        /// 认证中 = 1
        /// </summary>
        [Description("认证中")]
        Authorizing = 1,

        /// <summary>
        /// 关键词过滤认证成功 = 2
        /// </summary>
        [Description("关键词过滤认证成功")]
        AuthorizeSuccess = 2,
        /// <summary>
        /// 关键词过滤认证失败 = 3
        /// </summary>
        [Description("关键词过滤认证失败")]
        AuthorizeFaild = 3,



        /// <summary>
        /// 图片CDN处理中 = 7
        /// </summary>
        [Description("图片CDN处理中")]
        PictrueCdning = 7,

        /// <summary>
        /// 图片CDN成功 = 8
        /// </summary>
        [Description("图片CDN成功")]
        PictrueCdnSuccessd = 8,

        /// <summary>
        /// 图片CDN失败 = 9
        /// </summary>
        [Description("图片CDN失败")]
        PictrueCdnFailed = 9,

        /// <summary>
        /// Job完成 = 10
        /// </summary>
        [Description("Job完成")]
        JobSuccess = 10,

        /// <summary>
        /// 已发布 = 11
        /// </summary>
        [Description("已发布")]
        Publish = 11,

        /// <summary>
        /// 延长展示时间 = 12
        /// </summary>
        [Description("延长展示时间")]
        Delay = 12,

        /// <summary>
        /// 流程结束 交易完成 不再进行任何处理 = 99
        /// </summary>
        [Description("交易完成")]
        End = 99,

        /// <summary>
        /// 不删除状态【置顶中...】 = -1
        /// </summary>
        [Description("不删除状态【置顶中...】")]
        NoDelete = -1,

        /// <summary>
        /// 已删除 -100
        /// </summary>
        [Description("已删除")]
        Delete = -100
    }
}
