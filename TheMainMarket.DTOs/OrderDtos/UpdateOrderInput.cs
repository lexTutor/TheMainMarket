using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TheMainMarket.DTOs.OrderDtos
{
    public class UpdateOrderInput
    {
        [Required]
        public string Id { get; set; }
        public string CartId { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
    }
}
