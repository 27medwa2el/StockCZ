namespace StockCZ.Models.Dto
{
    public class StockMovementViewModel
    {
        public int StoreId { get; set; }
        public int ItemId { get; set; }
        public int Quantity { get; set; }
        public DateTime Date { get; set; }
    }
}
