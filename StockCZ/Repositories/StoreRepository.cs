using StockCZ.Models;
using StockCZ.Models.Domain;

namespace StockCZ.Repositories
{
    public class StoreRepository : Repository<Store>, IStoreRepository
    {
        public StoreRepository(AppDbContext dbContext) : base(dbContext)
        {
        }
    }
}
