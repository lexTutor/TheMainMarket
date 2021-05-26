using System;
using System.Collections.Generic;

namespace TheMainMarket.Models
{
    public class ProductCategory: BaseEntity
    {
        public string Name { get; set; }

        //Navigational Properties
        public ICollection<Product> Products { get; set; }
    }
}