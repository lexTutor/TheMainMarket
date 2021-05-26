using HotChocolate;
using HotChocolate.Types;
using System.Linq;
using System.Threading.Tasks;
using TheMainMarket.DataAccess;
using TheMainMarket.Infrastructure.Resolvers;
using TheMainMarket.Models;

namespace TheMainMarket.Infrastructure.Services
{
    public class ProductType: ObjectType<Product>
    {
        protected override void Configure(IObjectTypeDescriptor<Product> descriptor)
        {
            descriptor.Description("Base entity for all type of products");

            descriptor
                .Field(product => product.CartProducts)
                .Ignore();

            descriptor
                .Field(product => product.Store)
                .ResolveWith<ProductResolver>(product => product.GetStore(default, default))
                .Description("This is the store which this product belongs to");

           
            descriptor
                .Field(product => product.Category)
                .ResolveWith<ProductResolver>(resolver=> resolver.GetCategory(default, default))
                .Description("The category which this product belongs to");
        }
    }
}
