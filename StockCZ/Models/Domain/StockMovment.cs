using StockCZ.Shared.Models.Domain;

namespace StockCZ.Models.Domain
{
    public class StockMovement : BaseObject
    {
        public int StoreId { get; set; }
        public int ItemId { get; set; }
        public int Quantity { get; set; }
        public DateTime Date { get; set; }

        public virtual Store Store { get; set; }
        public virtual Item Item { get; set; }
    }
}
