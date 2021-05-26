using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TheMainMarket.DTOs.ProductDtos
{
    public class AddProductInput
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string CategoryId { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        public string StoreId { get; set; }
    }
}
