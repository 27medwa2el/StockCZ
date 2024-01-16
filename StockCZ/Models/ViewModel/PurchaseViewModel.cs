using StockCZ.Models.Domain;
using System.ComponentModel.DataAnnotations;

namespace StockCZ.Models.Dto
{
        public class PurchaseViewModel
        {
            public IEnumerable<Store>? Stores { get; set; }
            public IEnumerable<Item>? Items { get; set; }
            public int SelectedStoreId { get; set; }
            public int SelectedItemId { get; set; }
            public string ItemName { get; set; }

            public int Quantity { get; set; }
        }
}
