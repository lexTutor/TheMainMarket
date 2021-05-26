using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TheMainMarket.DTOs.CartDtos
{
    public class CartAndProduct
    {
        [Required]
        public string ProductId { get; set; }
    }
}
