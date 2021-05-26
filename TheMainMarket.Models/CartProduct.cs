using System;

namespace TheMainMarket.Models
{
    public class CartProduct: BaseEntity
    {
        public string CartId { get; set; }
        public string ProductId { get; set; }

        //Navigational Properties
        public Cart Cart { get; set; }
        public Product Product { get; set; }
    }
}