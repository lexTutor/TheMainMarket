using System;
using System.Collections.Generic;
using System.Text;

namespace TheMainMarket.DTOs.UsersDtos
{
    public class UpdateUserInput
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
    }
}
