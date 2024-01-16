using StockCZ.Shared.Models.Domain;

namespace StockCZ.Models.Domain
{
    public class Store : BaseObject
    {
        public string Name { get; set; }
        public virtual ICollection<StockMovement> StockMovements { get; set; }
    }
}
