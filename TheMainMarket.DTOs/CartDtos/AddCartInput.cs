using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TheMainMarket.DTOs.CartDtos
{
    public class AddCartInput
    {
        [Required]
        public string StoreId { get; set; }
        [Required]
        public ICollection<CartAndProduct> CartProducts { get; set; }
    }
}
