using HotChocolate;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;
using TheMainMarket.Commons.CustomException;
using TheMainMarket.Core.Repositories;
using TheMainMarket.DataAccess;
using TheMainMarket.DTOs.General;
using TheMainMarket.DTOs.StoreDtos;
using TheMainMarket.Infrastructure.Specifications;
using TheMainMarket.Models;
using TheMainMarketCore.Services;

namespace TheMainMarket.Infrastructure.Mutations
{
    public class StoreMutations : IStoreMutations
    {
        private readonly IGenericRepository<Store> _storeRepo;
        public StoreMutations(IServiceProvider serviceProvider)
        {
            _storeRepo = serviceProvider.GetRequiredService<IGenericRepository<Store>>();
        }

        public async Task<StorePayload> AddStore(AddStoreInput input, [Service] AppDbContext context)
        {
            if (await _storeRepo.GetEntityBySpec(new StoreCheckSpecification(input.Name)) != null)
            {
                throw new ModelExceptions() { DefaultError = $"The name {input.Name} is not available" };
            }

            Store store = new Store
            {
                Name = input.Name,
                Description = input.Description,
                PhoneNumber = input.PhoneNumber
            };

            var result = await _storeRepo.AddEntity(store);

            if (!result)
            {
                throw new ModelExceptions() { DefaultError = $"The store could not be created" };
            }

            return new StorePayload
            {
                Description = store.Description,
                Id = store.Id,
                Name = store.Name,
                PhoneNumber = store.PhoneNumber
            };
        }
        public async Task<StorePayload> UpdateStore(UpdateStoreInput input, [Service] AppDbContext context)
        {
            Store store = await _storeRepo.GetEntityBySpec(new StoreSpecification(input.Id));

            if (store is null)
            {
                throw new ModelExceptions() { DefaultError = $"The store id {input.Id} is not available" };
            }

            store.PhoneNumber = input.PhoneNumber is null ? store.PhoneNumber : input.PhoneNumber;
            store.Description = input.Description is null ? store.Description : input.Description;

            var result = await _storeRepo.UpdateEntity(store);

            if (!result)
            {
                throw new ModelExceptions() { DefaultError = $"The store could not be updated" };
            }

            return new StorePayload
            {
                Description = store.Description,
                Id = store.Id,
                Name = store.Name,
                PhoneNumber = store.PhoneNumber
            };
        }
        public async Task<StorePayload> DeleteStore(DeleteInput input, [Service] AppDbContext context)
        {
            Store store = await _storeRepo.GetEntityBySpec(new StoreSpecification(input.Id));

            if (store is null)
            {
                throw new ModelExceptions() { DefaultError = $"The store id {input.Id} is not available" };
            }

            var result = await _storeRepo.DeleteEntity(store);

            if (!result)
            {
                throw new ModelExceptions() { DefaultError = $"The store could not be deleted" };
            }

            return new StorePayload
            {
                Description = store.Description,
                Id = store.Id,
                Name = store.Name,
                PhoneNumber = store.PhoneNumber
            };
        }
    }
}
