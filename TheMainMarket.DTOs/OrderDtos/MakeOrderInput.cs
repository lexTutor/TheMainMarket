using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TheMainMarket.DTOs.OrderDtos
{
    public class MakeOrderInput
    {
        [Required]
        public string CartId { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
    }
}
