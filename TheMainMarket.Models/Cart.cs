using System;
using System.Collections.Generic;

namespace TheMainMarket.Models
{
    public class Cart: BaseEntity
    {
        public string UserId { get; set; }
        public string StoreId { get; set; }

        //Navigational Properties
        public User User { get; set; }
        public Store Store { get; set; }
        public ICollection<CartProduct> CartProducts { get; set; }
        public ICollection<Order> Orders { get; set; }
    }
}