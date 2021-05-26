using System;
using System.Collections.Generic;
using System.Text;

namespace TheMainMarket.DTOs.ProductDtos
{
    public class UpdateProductInput
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string CategoryId { get; set; }
        public decimal Price { get; set; }
    }
}
