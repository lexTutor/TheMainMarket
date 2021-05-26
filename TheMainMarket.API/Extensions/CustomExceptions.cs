using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TheMainMarket.Commons.ErrorFilters;

namespace TheMainMarket.API.Extensions
{
    public static class CustomExceptions
    {
        public static void AddCustomErrorFilters(this IServiceCollection services)
        {
            services.AddErrorFilter<IdentityErrorFilter>();
            services.AddErrorFilter<ModelErrorFilter>();
        }
    }
}
