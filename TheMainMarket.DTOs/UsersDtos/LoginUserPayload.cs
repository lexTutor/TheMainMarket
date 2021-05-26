using System;
using System.Collections.Generic;
using System.Text;

namespace TheMainMarket.DTOs.UsersDtos
{
    public class LoginUserPayload
    {
        public string Email { get; set; }
        public AuthenticationResult TokenData { get; set; }
        public string Message { get; set; }
    }
}
