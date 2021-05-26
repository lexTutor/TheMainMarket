using HotChocolate;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;
using TheMainMarket.Commons.CustomException;
using TheMainMarket.Core.Repositories;
using TheMainMarket.DataAccess;
using TheMainMarket.DTOs.General;
using TheMainMarket.DTOs.ProductDtos;
using TheMainMarket.Infrastructure.Specifications;
using TheMainMarket.Models;
using TheMainMarketCore.Services;

namespace TheMainMarket.Infrastructure.Mutations
{
    public class ProductMutations : IProductMutations
    {
        private readonly IGenericRepository<Product> _productRepo;
        private readonly IGenericRepository<Store> _storeRepo;
        private readonly IGenericRepository<ProductCategory> _categoryRepo;

        public ProductMutations(IServiceProvider serviceProvider)
        {
            _productRepo = serviceProvider.GetRequiredService<IGenericRepository<Product>>();
            _storeRepo = serviceProvider.GetRequiredService<IGenericRepository<Store>>();
            _categoryRepo = serviceProvider.GetRequiredService<IGenericRepository<ProductCategory>>();

        }

        public async Task<ProductPayload> AddProduct(AddProductInput input, [Service] AppDbContext context)
        {
            var isValidCategory = await _categoryRepo.GetEntityBySpec(new ProductCategorySpecification(input.CategoryId)) is null;

            if (isValidCategory)
            {
                throw new ModelExceptions() { DefaultError = $"The category is invalid" };
            }
            var isValidStore = await _storeRepo.GetEntityBySpec(new StoreSpecification(input.StoreId)) is null;

            if (isValidStore)
            {
                throw new ModelExceptions() { DefaultError = $"Store does not exist" };
            }

            Product product = new Product
            {
                Name = input.Name,
                Price = input.Price,
                CategoryId = input.CategoryId,
                StoreId = input.StoreId
            };

            var result = await _productRepo.AddEntity(product);

            if (!result)
            {
                throw new ModelExceptions() { DefaultError = $"The product could not be added" };
            }

            return new ProductPayload
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price
            };
        }

        public async Task<ProductPayload> UpdateProduct(UpdateProductInput input, [Service] AppDbContext context)
        {
            Product product = await _productRepo.GetEntityBySpec(new ProductCheckSpecification(input.Id));

            if (product is null)
            {
                throw new ModelExceptions() { DefaultError = $"The product id {input.Id} is not available" };
            }

            product.Name = input.Name is null ? product.Name : input.Name;
            product.Price = input.Price is 0 ? product.Price : input.Price;
            product.CategoryId = input.CategoryId is null ? product.CategoryId : input.CategoryId;

            var result = await _productRepo.UpdateEntity(product);

            if (!result)
            {
                throw new ModelExceptions() { DefaultError = $"The product could not be updated" };
            }

            return new ProductPayload
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price
            };
        }

        public async Task<ProductPayload> DeleteProduct(DeleteInput input, [Service] AppDbContext context)
        {
            Product product = await _productRepo.GetEntityBySpec(new ProductCheckSpecification(input.Id));

            if (product is null)
            {
                throw new ModelExceptions() { DefaultError = $"The product id {input.Id} is not available" };
            }

            var result = await _productRepo.DeleteEntity(product);

            if (!result)
            {
                throw new ModelExceptions() { DefaultError = $"The product could not be deleted" };
            }

            return new ProductPayload
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price
            };
        }
    }
}
