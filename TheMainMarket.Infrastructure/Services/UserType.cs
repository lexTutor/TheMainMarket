using HotChocolate.Types;
using System;
using System.Collections.Generic;
using System.Text;
using TheMainMarket.Infrastructure.Resolvers;
using TheMainMarket.Models;

namespace TheMainMarket.Infrastructure.Services
{
    public class UserType: ObjectType<User>
    {
        protected override void Configure(IObjectTypeDescriptor<User> descriptor)
        {
            descriptor.Description("Stores an instance of the application user");

            descriptor
                .Field(user => user.Orders)
                .ResolveWith<UserResolver>(resolver => resolver.GetOrders(default, default))
                .Description("These are the orders made by this user");

            descriptor
                .Field(user => user.Carts)
                .ResolveWith<UserResolver>(resolver => resolver.GetCarts(default, default))
                .Description("These are the carts created by this user");
        }
    }
}
