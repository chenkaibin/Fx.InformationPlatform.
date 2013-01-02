using Fx.Entity.FxGoods;

namespace Fx.Domain.FxGoods.IService
{
    /// <summary>
    /// 物品转让保存读取接口
    /// </summary>
    public interface ITransferGoods
    {
        /// <summary>
        /// 获取物品转让信息
        /// </summary>
        /// <param name="Id">物品转让Id</param>
        /// <returns>物品转让信息</returns>
        GoodsTransferInfo Get(int Id);

        /// <summary>
        /// 保存物品转让信息
        /// </summary>
        /// <param name="goods">物品转让信息</param>
        /// <returns>是否保存成功</returns>
        bool SaveTransferGoods(GoodsTransferInfo goods);
    }
}
