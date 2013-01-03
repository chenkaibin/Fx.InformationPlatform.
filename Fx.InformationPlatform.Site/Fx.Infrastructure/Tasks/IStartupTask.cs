namespace Fx.Infrastructure.Tasks
{
    /// <summary>
    /// 任务启动
    /// </summary>
    public interface IStartupTask
    {
        /// <summary>
        /// 任务运行
        /// </summary>
        void Execute();
    }
}