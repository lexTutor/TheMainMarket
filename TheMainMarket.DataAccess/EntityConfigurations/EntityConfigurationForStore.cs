using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using TheMainMarket.Models;

namespace TheMainMarket.DataAccess.EntityConfigurations
{
    public class EntityConfigurationForStore : IEntityTypeConfiguration<Store>
    {
        public void Configure(EntityTypeBuilder<Store> builder)
        {
            builder.HasMany(stores => stores.Carts)
                    .WithOne(cart => cart.Store)
                    .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(stores => stores.Products)
                   .WithOne(product => product.Store)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
