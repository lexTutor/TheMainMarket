using HotChocolate.Types;
using TheMainMarket.DataAccess;
using TheMainMarket.Infrastructure.Resolvers;
using TheMainMarket.Models;

namespace TheMainMarket.Infrastructure.Services
{
    public class StoreType : ObjectType<Store>
    { 
        protected override void Configure(IObjectTypeDescriptor<Store> descriptor)
        {
            descriptor.Description("The store contains products");

            descriptor
                .Field(store => store.Carts)
                .Ignore();

            descriptor
                .Field(store => store.Products)
                .ResolveWith<StoreResolvers>(store => store.GetProducts(default, default!))
                .Description("This is the store which this product belongs to");
        }
    }
}
