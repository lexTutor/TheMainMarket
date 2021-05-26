using System;
using System.Collections.Generic;
using System.Text;

namespace TheMainMarket.DTOs
{
    public class AuthenticationResult
    {
        public string Token { get; set; }

        public string RefreshToken { get; set; }

        public ICollection<string> Errors { get; set; }
    }
}
