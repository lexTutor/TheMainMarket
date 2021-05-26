using HotChocolate;
using HotChocolate.Data;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using TheMainMarket.Core.Repositories;
using TheMainMarket.DataAccess;
using TheMainMarket.Infrastructure.Specifications;
using TheMainMarket.Models;

namespace TheMainMarket.Infrastructure.Resolvers
{
    public class ProductCategoryResolver
    {
        private readonly IGenericRepository<Product> _productRepo;
        public ProductCategoryResolver(IServiceProvider serviceProvider)
        {
            _productRepo = serviceProvider.GetRequiredService<IGenericRepository<Product>>();
        }
        public IReadOnlyList<Product> GetProductsForACategory(ProductCategory category, [Service] AppDbContext context)
        {
            return _productRepo.ListAllEntityBySpec(new ProductSpecificationForCategories(category.Id)).Result;
        }
    }
}