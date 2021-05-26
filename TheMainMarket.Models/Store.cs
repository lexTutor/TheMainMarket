using System;
using System.Collections.Generic;

namespace TheMainMarket.Models
{
    public class Store: BaseEntity
    {
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string Description { get; set; }

        //Navigational Properties
        public ICollection<Cart> Carts { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}