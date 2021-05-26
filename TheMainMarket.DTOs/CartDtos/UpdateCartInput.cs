using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TheMainMarket.DTOs.CartDtos
{
    public class UpdateCartInput
    {
        [Required]
        public string Id { get; set; }
        [Required]
        public IEnumerable<CartAndProduct> CartProducts { get; set; }
    }
}
