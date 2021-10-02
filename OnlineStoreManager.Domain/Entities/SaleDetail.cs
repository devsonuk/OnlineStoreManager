using System;

namespace OnlineStoreManager.Domain.Entities
{
    public class SaleDetail : BaseEntity
    {
        public int SaleId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal CumulativePrice { get; set; }
        public decimal Tax { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
