using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TheMainMarket.Core.Repositories;
using TheMainMarket.Core.Services;
using TheMainMarket.Core.Specifications;
using TheMainMarket.Infrastructure.Mutations;
using TheMainMarket.Infrastructure.Repositories;
using TheMainMarket.Infrastructure.Services;
using TheMainMarket.Infrastructure.Specifications;
using TheMainMarket.Models.Settings;
using TheMainMarketCore.Services;

namespace TheMainMarket.API.Extensions
{
    public static class DIcontainer
    {
        public static void AddServiceRegisterations(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped(typeof(IJWTService<>), typeof(JWTService<>));
            services.Configure<JWTSettings>(configuration.GetSection("JWTConfigurations"));
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped(typeof(ISpecification<>), typeof(BaseSpecification<>));
            services.AddScoped<IUserMutations, UserMutations>();
            services.AddScoped<IStoreMutations, StoreMutations>();
            services.AddScoped<IProductMutations, ProductMutations>();
            services.AddScoped<IProductCategoryMutations, ProductCategoryMutations>();
            services.AddScoped<IOrderMutations, OrderMutations>();
            services.AddScoped<ICartMutations, CartMutation>();


        }
    }
}
