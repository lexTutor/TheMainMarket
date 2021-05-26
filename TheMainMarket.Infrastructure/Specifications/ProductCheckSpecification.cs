using System;
using System.Collections.Generic;
using System.Text;
using TheMainMarket.Models;

namespace TheMainMarket.Infrastructure.Specifications
{
    public class ProductCheckSpecification: BaseSpecification<Product>
    {
        public ProductCheckSpecification(string Id): base(p=>p.Id== Id)
        {

        }
    }
}
