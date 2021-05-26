using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using TheMainMarket.DataAccess.EntityConfigurations;
using TheMainMarket.Models;

namespace TheMainMarket.DataAccess
{
    public class AppDbContext: IdentityDbContext<User>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options): base(options)
        {

        }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<CartProduct> CartProducts { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }
        public DbSet<Store> Stores { get; set; }
        public DbSet<Token> Tokens { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfiguration(new EntityConfigurationForCart());
            builder.ApplyConfiguration(new EntityConfigurationForStore());
            builder.ApplyConfiguration(new EntityConfigurationForCartProduct());
            builder.ApplyConfiguration(new EntityConfigurationForOrder());
            builder.ApplyConfiguration(new EntityConfigurationForTokens());
            builder.ApplyConfiguration(new EntityConfigurationForUser());
            builder.ApplyConfiguration(new EntityConfigurationsForProduct());

        }
    }
}
