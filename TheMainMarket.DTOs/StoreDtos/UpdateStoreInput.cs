using System;
using System.Collections.Generic;
using System.Text;

namespace TheMainMarket.DTOs.StoreDtos
{
    public class UpdateStoreInput
    {
        public string Id { get; set; }
        public string PhoneNumber { get; set; }
        public string Description { get; set; }
    }
}
