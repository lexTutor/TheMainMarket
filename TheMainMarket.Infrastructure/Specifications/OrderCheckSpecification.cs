using System;
using System.Collections.Generic;
using System.Text;
using TheMainMarket.Models;

namespace TheMainMarket.Infrastructure.Specifications
{
    public class OrderCheckSpecification: BaseSpecification<Order>
    {
        public OrderCheckSpecification(string Id): base(o=> o.Id == Id)
        {
        }
    }
}
