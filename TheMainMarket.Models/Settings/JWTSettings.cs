using System;
using System.Collections.Generic;
using System.Text;

namespace TheMainMarket.Models.Settings
{
    public class JWTSettings
    {
        public string SecretKey { get; set; }
        public TimeSpan TokenLifeTime { get; set; }
        public string Issuer { get; set; }
        public string Audience { get; set; }
    }
}
