using System;
using System.Collections.Generic;
using System.Text;
using TheMainMarket.Models;

namespace TheMainMarket.Infrastructure.Specifications
{
    public class CategoryCheckSpecification: BaseSpecification<ProductCategory>
    {
        public CategoryCheckSpecification(string name): base(c=>c.Name.ToLower() == name.ToLower())
        {

        }
    }
}
