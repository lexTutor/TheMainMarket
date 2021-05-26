using System;
using System.Collections.Generic;
using System.Text;
using TheMainMarket.Models;

namespace TheMainMarket.Infrastructure.Specifications
{
    public class StoreCheckSpecification: BaseSpecification<Store>
    {
        public StoreCheckSpecification(string name): base(s=>s.Name.ToLower() == name.ToLower())
        {

        }
    }
}
