using HotChocolate;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using TheMainMarket.Core.Repositories;
using TheMainMarket.DataAccess;
using TheMainMarket.Infrastructure.Specifications;
using TheMainMarket.Models;

namespace TheMainMarket.Infrastructure.Resolvers
{
    public class StoreResolvers
    {
        private readonly IGenericRepository<Product> _productRepo;
        public StoreResolvers( IServiceProvider serviceProvider)
        {
            _productRepo = serviceProvider.GetRequiredService<IGenericRepository<Product>>();
        }
        public IReadOnlyList<Product> GetProducts(Store store, [Service] AppDbContext context)
        {
            return _productRepo.ListAllEntityBySpec(new ProductSpecification(store.Id)).Result;
        }
    }
}
