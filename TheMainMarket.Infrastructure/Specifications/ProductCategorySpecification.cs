using System;
using System.Collections.Generic;
using System.Text;
using TheMainMarket.Models;

namespace TheMainMarket.Infrastructure.Specifications
{
    public class ProductCategorySpecification : BaseSpecification<ProductCategory>
    {
        public ProductCategorySpecification()
        {
        }
        public ProductCategorySpecification(string Id):base(ProductCategory=> ProductCategory.Id == Id)
        {

        }
    }
}
