using System;

namespace OnlineStoreManager.Domain.Entities
{
    public class Sale : BaseEntity
    {
        public int CashierId { get; set; }
        public decimal SubTotal { get; set; }
        public decimal Tax { get; set; }
        public decimal Total { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
