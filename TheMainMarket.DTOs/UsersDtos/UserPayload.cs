﻿using System;
using System.Collections.Generic;
using System.Text;

namespace TheMainMarket.DTOs.UsersDtos
{
    public class UserPayload
    {
        public string Id { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
