using Microsoft.EntityFrameworkCore;
using StockCZ.Models;
using StockCZ.Models.Domain;

namespace StockCZ.Repositories
{
    public class StockMovementRepository : Repository<StockMovement>, IStockMovementRepository
    {
        public StockMovementRepository(AppDbContext dbContext) : base(dbContext)
        {

        }
        public async Task<StockMovement>? GetStockMovementByItemAndStockId(int storeId, int itemId)
        {
            return await _dbContext.Set<StockMovement>()
                .Where(sm => sm.StoreId == storeId && sm.ItemId == itemId)
                .FirstOrDefaultAsync();
        }

    }
}
