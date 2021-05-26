using HotChocolate;
using HotChocolate.AspNetCore.Authorization;
using Microsoft.Extensions.DependencyInjection;
using System;
using TheMainMarket.Core.Repositories;
using TheMainMarket.DataAccess;
using TheMainMarket.Infrastructure.Specifications;
using TheMainMarket.Models;

namespace TheMainMarket.Infrastructure.Resolvers
{
    public class ProductResolver
    {
        private readonly IGenericRepository<Store> _storeRepo;
        private readonly IGenericRepository<ProductCategory> _categoryRepo;

        public ProductResolver([Service] IServiceProvider serviceProvider)
        {
            _storeRepo = serviceProvider.GetRequiredService<IGenericRepository<Store>>(); ;
            _categoryRepo = serviceProvider.GetRequiredService<IGenericRepository<ProductCategory>>(); ;
        }

        public Store GetStore(Product product, [Service] AppDbContext context)
        {
            return  _storeRepo.GetEntityBySpec(new StoreSpecification(product.StoreId)).Result;
        }

        public ProductCategory GetCategory(Product product, [Service] AppDbContext context)
        {
           return _categoryRepo.GetEntityBySpec(new ProductCategorySpecification(product.CategoryId)).Result;
        }
    }
}
