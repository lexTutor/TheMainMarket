using HotChocolate;
using System.Threading.Tasks;
using TheMainMarket.DataAccess;
using TheMainMarket.DTOs.General;
using TheMainMarket.DTOs.StoreDtos;

namespace TheMainMarketCore.Services
{
    public interface IStoreMutations
    {
        Task<StorePayload> AddStore(AddStoreInput input, [Service] AppDbContext context);
        Task<StorePayload> DeleteStore(DeleteInput input, [Service] AppDbContext context);
        Task<StorePayload> UpdateStore(UpdateStoreInput input, [Service] AppDbContext context);
    }
}