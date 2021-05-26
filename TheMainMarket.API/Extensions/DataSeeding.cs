using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TheMainMarket.DataAccess;
using TheMainMarket.DataAccess.Seed;

namespace TheMainMarket.API.Extensions
{
    public static class DataSeeding
    {
        public static void UseDataSeeding(this IApplicationBuilder app, AppDbContext context)
        {
            PreSeedData.SeedCategoryData(context).Wait();
            PreSeedData.SeedStoreData(context).Wait();
            PreSeedData.SeedUsers(context).Wait();
            PreSeedData.SeedCartProducts(context).Wait();
        }
    }
}
