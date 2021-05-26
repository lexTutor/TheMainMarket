using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using TheMainMarket.Models;

namespace TheMainMarket.DataAccess.EntityConfigurations
{
    class EntityConfigurationForCartProduct : IEntityTypeConfiguration<CartProduct>
    {
        public void Configure(EntityTypeBuilder<CartProduct> builder)
        {
            builder
                .HasKey(cartProduct => 
                new { cartProduct.ProductId, cartProduct.CartId });

            builder.HasOne(cartProduct => cartProduct.Product)
                 .WithMany(products => products.CartProducts)
                 .HasForeignKey(cartProduct=> cartProduct.ProductId);

            builder.HasOne(cartProduct => cartProduct.Cart)
                .WithMany(cart => cart.CartProducts)
                .HasForeignKey(cartproduct=> cartproduct.CartId);

        }
    }
}
