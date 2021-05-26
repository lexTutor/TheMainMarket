using HotChocolate.Types;
using TheMainMarket.Infrastructure.Resolvers;
using TheMainMarket.Models;

namespace TheMainMarket.Infrastructure.Services
{
    public class ProductCategoryType: ObjectType<ProductCategory>
    {
        protected override void Configure(IObjectTypeDescriptor<ProductCategory> descriptor)
        {
            descriptor.Description("These are the product categories available in the application");

            descriptor
                .Field(category=> category.Products)
                .ResolveWith<ProductCategoryResolver>(resolver=> resolver.GetProductsForACategory(default, default!))
                .Description("These are the products in this category");
        }
    }
}
