using System;
using System.Collections.Generic;
using System.Text;

namespace TheMainMarket.DTOs.CartDtos
{
    public class CartPayload
    {
        public string  Id { get; set; }
        public string UserId { get; set; }
        public string StoreId { get; set; }
        public ICollection<CartAndProduct> CartProducts { get; set; }
    }
}
