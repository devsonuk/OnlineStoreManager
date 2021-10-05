using System;

namespace OnlineStoreManager.Domain.Entities
{
    public class Inventory : BaseEntity
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal PurchasePrice { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
