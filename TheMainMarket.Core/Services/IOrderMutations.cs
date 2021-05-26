using HotChocolate;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using TheMainMarket.DataAccess;
using TheMainMarket.DTOs.General;
using TheMainMarket.DTOs.OrderDtos;
using TheMainMarket.Models;

namespace TheMainMarketCore.Services
{
    public interface IOrderMutations
    {
        Task<OrderPayload> DeleteOrder(DeleteInput input, [Service] AppDbContext context, string Id);
        Task<OrderPayload> MakeOrder(MakeOrderInput input, [Service] AppDbContext context, string Id);
        Task<OrderPayload> UpdateOrder(UpdateOrderInput input, [Service] AppDbContext context, string Id);
    }
}