using HotChocolate;
using HotChocolate.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TheMainMarket.Core.Repositories;
using TheMainMarket.DataAccess;
using TheMainMarket.Infrastructure.Specifications;
using TheMainMarket.Models;

namespace TheMainMarket.Infrastructure.Services
{
    public class Query
    {
        private readonly IGenericRepository<Product> _productRepo;
        private readonly IGenericRepository<Store> _storeRepo;
        private readonly IGenericRepository<ProductCategory> _categoryRepo;
        private readonly IGenericRepository<User> _userRepo;

        public Query(IServiceProvider serviceProvider)
        {
            _productRepo = serviceProvider.GetRequiredService<IGenericRepository<Product>>();
            _storeRepo = serviceProvider.GetRequiredService<IGenericRepository<Store>>(); ;
            _categoryRepo = serviceProvider.GetRequiredService<IGenericRepository<ProductCategory>>(); ;
            _userRepo = serviceProvider.GetRequiredService<IGenericRepository<User>>();
        }

        [UseSorting]
        [UseFiltering]
        public async Task<IReadOnlyList<Product>> GetProductsAsync([Service] AppDbContext context)
        {
            return await _productRepo.ListAllEntityBySpec(new ProductSpecification());
        }

        [UseSorting]
        [UseFiltering]
        public async Task<IReadOnlyList<Store>> GetStores([Service] AppDbContext context)
        {
            return await _storeRepo.ListAllEntityBySpec(new StoreSpecification());
        }

        [UseSorting]
        [UseFiltering]
        public Task<IReadOnlyList<ProductCategory>> GetCategories([Service] AppDbContext context)
        {
            return _categoryRepo.ListAllEntityBySpec(new ProductCategorySpecification());
        }

        //[Authorized for admin]
        [UseSorting]
        [UseFiltering]
        public Task<IReadOnlyList<User>> GetUsers([Service] AppDbContext context)
        {
            return _userRepo.ListAllEntityBySpec(new UserSpecification());
        }

        //[Authorized]
        [UseSorting]
        [UseFiltering]
        public Task<User> GetUser([Service] AppDbContext context, [Service] IHttpContextAccessor contextAccessor)
        {
            var user = contextAccessor.HttpContext.User; // <-> There is your user
            return _userRepo.GetEntityBySpec(new UserSpecification(user.FindFirst(c=> c.Type == "Id").Value));
        }
    }
}
