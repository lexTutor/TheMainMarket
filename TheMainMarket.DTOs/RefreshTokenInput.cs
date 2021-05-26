using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TheMainMarket.DTOs
{
    public class RefreshTokenInput
    {
        [Required]
        public string Token { get; set; }
        [Required]
        public string ReftreshToken { get; set; }
    }
}
