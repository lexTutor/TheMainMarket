using System;
using System.Collections.Generic;
using System.Text;

namespace TheMainMarket.Models
{
    public interface IBase
    {
        public DateTime Created_at { get; set; }
        public DateTime Updated_at { get; set; }
    }
}
