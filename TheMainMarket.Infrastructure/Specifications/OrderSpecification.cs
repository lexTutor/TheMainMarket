using System;
using System.Collections.Generic;
using System.Text;
using TheMainMarket.Models;

namespace TheMainMarket.Infrastructure.Specifications
{
    public class OrderSpecification: BaseSpecification<Order>
    {
        public OrderSpecification(string Id): base(Order=> Order.UserId == Id)
        {

        }
    }
}
