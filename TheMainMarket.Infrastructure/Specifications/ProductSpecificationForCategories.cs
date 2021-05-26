using System;
using System.Collections.Generic;
using System.Text;
using TheMainMarket.Models;

namespace TheMainMarket.Infrastructure.Specifications
{
    public class ProductSpecificationForCategories: BaseSpecification<Product>
    {
        public ProductSpecificationForCategories(string Id): base(Product=> Product.CategoryId == Id)
        {
            AddInclude(product => product.Store);
            AddInclude(product => product.Category);
        }
    }
}
