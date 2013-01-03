namespace Fx.Entity
{
    /// <summary>
    /// 确定相关频道在MVC中运行信息
    /// </summary>
    public interface IAction
    {
        /// <summary>
        /// MVC控制器名称 如一个Car频道 那么设置其控制器是Car
        /// </summary>
        string ControllerName { get; set; }

        /// <summary>
        /// MVC Action
        /// </summary>
        string ActionName { get; set; }

        /// <summary>
        /// MVC Route参数
        /// </summary>
        string RoutePars { get; set; }
    }
}
