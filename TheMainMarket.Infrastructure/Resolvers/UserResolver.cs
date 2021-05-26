using HotChocolate;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using TheMainMarket.Core.Repositories;
using TheMainMarket.DataAccess;
using TheMainMarket.Infrastructure.Specifications;
using TheMainMarket.Models;

namespace TheMainMarket.Infrastructure.Resolvers
{
    public class UserResolver
    {
        private readonly IGenericRepository<Order> _orderRepo;
        private readonly IGenericRepository<Cart> _cartRepo;
        public UserResolver([Service] IServiceProvider serviceProvider)
        {
            _orderRepo = serviceProvider.GetRequiredService<IGenericRepository<Order>>();
            _cartRepo = serviceProvider.GetRequiredService<IGenericRepository<Cart>>();
        }
        public IReadOnlyList<Order> GetOrders(User user, [Service] AppDbContext context)
        {
            return _orderRepo.ListAllEntityBySpec(new OrderSpecification(user.Id)).Result;
        }
        public IReadOnlyList<Cart> GetCarts(User user, [Service] AppDbContext context)
        {
            return _cartRepo.ListAllEntityBySpec(new CartSpecification(user.Id)).Result;
        }
    }
}
