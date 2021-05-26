using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using TheMainMarket.Models;

namespace TheMainMarket.DataAccess.EntityConfigurations
{
    public class EntityConfigurationsForProduct : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasOne(product => product.Store)
                    .WithMany(Store => Store.Products);
            builder.HasOne(product => product.Category)
                    .WithMany(category => category.Products);
            builder.HasMany(product => product.CartProducts)
                    .WithOne(CartProduct => CartProduct.Product)
                    .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
