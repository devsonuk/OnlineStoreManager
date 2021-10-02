using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStoreManager.DesktopUI.Library.Models
{
    public class ProductModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public double RetailPrice { get; set; }
        public int QuantityInStock { get; set; }
        public bool IsTaxable { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public string Display => $"{Name} : {RetailPrice} : {QuantityInStock}";
    }
}
