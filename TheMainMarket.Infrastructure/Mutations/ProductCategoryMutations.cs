using HotChocolate;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;
using TheMainMarket.Commons.CustomException;
using TheMainMarket.Core.Repositories;
using TheMainMarket.DataAccess;
using TheMainMarket.DTOs.CategoryDtos;
using TheMainMarket.DTOs.General;
using TheMainMarket.Infrastructure.Specifications;
using TheMainMarket.Models;
using TheMainMarketCore.Services;

namespace TheMainMarket.Infrastructure.Mutations
{
    public class ProductCategoryMutations : IProductCategoryMutations
    {
        private readonly IGenericRepository<ProductCategory> _categoryRepo;
        public ProductCategoryMutations(IServiceProvider serviceProvider)
        {
            _categoryRepo = serviceProvider.GetRequiredService<IGenericRepository<ProductCategory>>();
        }

        public async Task<CategoryPayload> AddCategory(AddCategoryInput input, [Service] AppDbContext context)
        {
            if (await _categoryRepo.GetEntityBySpec(new CategoryCheckSpecification(input.Name)) != null)
            {
                throw new ModelExceptions() { DefaultError = $"The name {input.Name} is not available" };
            }

            ProductCategory category = new ProductCategory
            {
                Name = input.Name
            };

            var result = await _categoryRepo.AddEntity(category);

            if (!result)
            {
                throw new ModelExceptions() { DefaultError = $"The store could not be created" };
            }

            return new CategoryPayload
            {
                Id = category.Id,
                Name = category.Name
            };
        }
        public async Task<CategoryPayload> UpdateCategory(UpdateCategoryInput input, [Service] AppDbContext context)
        {
            ProductCategory category = await _categoryRepo.GetEntityBySpec(new ProductCategorySpecification(input.Id));

            if (category is null)
            {
                throw new ModelExceptions() { DefaultError = $"The store id {input.Id} is not available" };
            }

            category.Name = input.Name is null ? category.Name : input.Name;

            var result = await _categoryRepo.UpdateEntity(category);

            if (!result)
            {
                throw new ModelExceptions() { DefaultError = $"The store could not be updated" };
            }

            return new CategoryPayload
            {
                Id = category.Id,
                Name = category.Name
            };
        }
        public async Task<CategoryPayload> DeleteCategory(DeleteInput input, [Service] AppDbContext context)
        {
            ProductCategory category = await _categoryRepo.GetEntityBySpec(new ProductCategorySpecification(input.Id));

            if (category is null)
            {
                throw new ModelExceptions() { DefaultError = $"The store id {input.Id} is not available" };
            }

            var result = await _categoryRepo.DeleteEntity(category);

            if (!result)
            {
                throw new ModelExceptions() { DefaultError = $"The store could not be deleted" };
            }

            return new CategoryPayload
            {
                Id = category.Id,
                Name = category.Name
            };
        }
    }
}
