using System;
using System.Collections.Generic;
using System.Text;
using TheMainMarket.Models;

namespace TheMainMarket.Infrastructure.Specifications
{
    public class CartCheckSpecification: BaseSpecification<Cart>
    {
        public CartCheckSpecification(string Id): base(c=>c.Id == Id)
        {

        }
    }
}
