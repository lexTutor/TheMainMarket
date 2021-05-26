using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using TheMainMarket.Models;

namespace TheMainMarket.DataAccess.EntityConfigurations
{
    public class EntityConfigurationForUser : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasMany(user => user.Carts)
                   .WithOne(Cart => Cart.User)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(user => user.Orders)
                    .WithOne(Order => Order.User)
                    .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
