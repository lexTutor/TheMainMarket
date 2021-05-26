using System;
using System.Collections.Generic;
using System.Text;

namespace TheMainMarket.Models
{
    public class Product: BaseEntity
    {
        public string Name { get; set; }
        public string CategoryId { get; set; }
        public decimal Price { get; set; }
        public string StoreId { get; set; }

        //Navigational Properties
        public ProductCategory Category { get; set; }
        public Store Store { get; set; }
        public ICollection<CartProduct> CartProducts { get; set; }
    }
}
