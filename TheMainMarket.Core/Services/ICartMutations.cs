using HotChocolate;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using TheMainMarket.DataAccess;
using TheMainMarket.DTOs.CartDtos;
using TheMainMarket.DTOs.General;

namespace TheMainMarketCore.Services
{
    public interface ICartMutations
    {
        Task<CartPayload> AddCart(AddCartInput input, [Service] AppDbContext context, string Id);
        Task<CartPayload> DeleteCart(DeleteInput input, [Service] AppDbContext context, string Id);
        Task<CartPayload> UpdateCart(UpdateCartInput input, [Service] AppDbContext context, string Id);
    }
}