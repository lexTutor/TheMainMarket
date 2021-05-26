using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TheMainMarket.Infrastructure.Mutations;
using TheMainMarket.Infrastructure.Services;

namespace TheMainMarket.API.Extensions
{
    public static class GraphQlExtensions
    {
        public static void AddGraphQLExtensions(this IServiceCollection services)
        {
            services.AddGraphQLServer()
                     .AddQueryType<Query>()
                     .AddMutationType<Mutations>()
                     .AddType<ProductType>()
                     .AddType<ProductCategoryType>()
                     .AddType<StoreType>()
                     .AddType<UserType>()
                     .AddSorting()
                     .AddFiltering()
                     .AddAuthorization();
        }
    }
}
