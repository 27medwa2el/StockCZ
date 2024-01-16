using StockCZ.Shared.Models.Domain;

namespace StockCZ.Models.Domain
{
    public class Item : BaseObject
    {

        public string Name { get; set; }
        public decimal Price { get; set; }
        public virtual ICollection<StockMovement> StockMovements { get; set; }
    }
}
