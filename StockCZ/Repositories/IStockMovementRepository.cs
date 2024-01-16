using StockCZ.Models.Domain;

namespace StockCZ.Repositories
{
    public interface IStockMovementRepository: IRepository<StockMovement>
    {
        Task<StockMovement>? GetStockMovementByItemAndStockId(int storeId, int itemId);
    }
}
