using System;

namespace OnlineStoreManager.Domain.Clients
{
    public class SaleReport
    {
        public int Id { get; set; }
        public decimal SubTotal { get; set; }
        public decimal Tax { get; set; }
        public decimal Total { get; set; }
        public DateTime SaleDate { get; set; }
        public int CashierId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
    }
}
