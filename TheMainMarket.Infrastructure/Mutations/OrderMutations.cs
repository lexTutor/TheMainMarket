using HotChocolate;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;
using TheMainMarket.Commons.CustomException;
using TheMainMarket.Core.Repositories;
using TheMainMarket.DataAccess;
using TheMainMarket.DTOs.General;
using TheMainMarket.DTOs.OrderDtos;
using TheMainMarket.Infrastructure.Specifications;
using TheMainMarket.Models;
using TheMainMarketCore.Services;

namespace TheMainMarket.Infrastructure.Mutations
{
    public class OrderMutations : IOrderMutations
    {
        private readonly IGenericRepository<Order> _orderRepo; 
        private readonly IGenericRepository<User> _userRepo;
        private readonly IGenericRepository<Cart> _cartRepo;


        public OrderMutations(IServiceProvider serviceProvider)
        {
            _orderRepo = serviceProvider.GetRequiredService<IGenericRepository<Order>>();
            _userRepo = serviceProvider.GetRequiredService<IGenericRepository<User>>();
            _cartRepo = serviceProvider.GetRequiredService<IGenericRepository<Cart>>();
        }

        public async Task<OrderPayload> MakeOrder(MakeOrderInput input, [Service] AppDbContext context, string Id)
        {
            User user = await _userRepo.GetEntityBySpec(new UserSpecification(Id));
            if (user is null)
            throw new AccessViolationException("Forbidden");

            if (await _cartRepo.GetEntityBySpec(new CartCheckSpecification(input.CartId)) is null)
            throw new ModelExceptions() { DefaultError = $"Cart does not exist" };

            Order order = new Order
            {
                Address = input.Address,
                CartId = input.CartId,
                UserId = user.Id,
                PhoneNumber = input.PhoneNumber
            };

            var result = await _orderRepo.AddEntity(order);

            if (!result)
            throw new ModelExceptions() { DefaultError = $"The order could not be created" };

            return new OrderPayload
            {
                Address = order.Address,
                CartId = order.CartId,
                UserId = order.UserId,
                Id = order.Id,
                PhoneNumber = order.PhoneNumber
            };
        }
        public async Task<OrderPayload> UpdateOrder(UpdateOrderInput input, [Service] AppDbContext context, string Id)
        {
            Order order = await _orderRepo.GetEntityBySpec(new OrderCheckSpecification(input.Id));

            if (order is null)
            throw new ModelExceptions() { DefaultError = $"The order id {input.Id} is not available" };

            if (order.UserId != Id)
                throw new AccessViolationException("Forbidden");
            if (order.IsDelivered)
                throw new ModelExceptions() { DefaultError = "The order has been delivered and cannot be updated. Please make a new order" };

            order.PhoneNumber = input.PhoneNumber is null ? order.PhoneNumber : input.PhoneNumber;
            order.Address = input.Address is null ? order.Address : input.Address;
            order.CartId = input.CartId is null ? order.CartId : input.CartId;

            var result = await _orderRepo.UpdateEntity(order);

            if (!result)
                throw new ModelExceptions() { DefaultError = $"The order could not be updated" };

            return new OrderPayload
            {
                Address = order.Address,
                CartId = order.CartId,
                UserId = order.UserId,
                Id = order.Id,
                PhoneNumber = order.PhoneNumber
            };
        }
        public async Task<OrderPayload> DeleteOrder(DeleteInput input, [Service] AppDbContext context, string Id)
        {
            Order order = await _orderRepo.GetEntityBySpec(new OrderCheckSpecification(input.Id));

            if (order is null)
            throw new ModelExceptions() { DefaultError = $"The order id {input.Id} is not available" };

            if (order.UserId != Id)
                throw new AccessViolationException($"Forbidden");

            var result = await _orderRepo.DeleteEntity(order);

            if (!result)
            throw new ModelExceptions() { DefaultError = $"The order could not be deleted" };

            return new OrderPayload
            {
                Address = order.Address,
                CartId = order.CartId,
                UserId = order.UserId,
                Id = order.Id,
                PhoneNumber = order.PhoneNumber
            };
        }
    }
}
