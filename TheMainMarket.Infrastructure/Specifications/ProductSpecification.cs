using System;
using System.Collections.Generic;
using System.Text;
using TheMainMarket.Models;

namespace TheMainMarket.Infrastructure.Specifications
{
    public class ProductSpecification: BaseSpecification<Product>
    {
        public ProductSpecification(string Id): base(Product=> Product.StoreId ==Id)
        {
            AddInclude(product => product.Store);
        }
        public ProductSpecification()
        {

        }
    }
}
