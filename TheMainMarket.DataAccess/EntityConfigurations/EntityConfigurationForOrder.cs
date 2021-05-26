using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using TheMainMarket.Models;

namespace TheMainMarket.DataAccess.EntityConfigurations
{
    public class EntityConfigurationForOrder : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasOne(order => order.Cart)
                    .WithMany(Cart => Cart.Orders)
                    .OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(order => order.User)
                    .WithMany(users => users.Orders);
        }
    }
}
