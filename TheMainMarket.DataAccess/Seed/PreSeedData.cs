using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheMainMarket.Models;

namespace TheMainMarket.DataAccess.Seed
{
    public class PreSeedData
    {
        public async static Task SeedCategoryData(AppDbContext context)
        {
            context.Database.EnsureCreated();
            if (!context.ProductCategories.Any())
            {
                var categoryData = await File.ReadAllTextAsync("SeedData/ProductCategories.json");

                List<ProductCategory> categories = JsonConvert.DeserializeObject<List<ProductCategory>>(categoryData);

                await context.ProductCategories.AddRangeAsync(categories);

                await context.SaveChangesAsync();
            }
        }

        public async static Task SeedStoreData(AppDbContext context)
        {
            context.Database.EnsureCreated();

            if (!context.Stores.Any())
            {
                var storeData = await File.ReadAllTextAsync("SeedData/Store.json");

                List<Store> stores = JsonConvert.DeserializeObject<List<Store>>(storeData);

                var categories = context.ProductCategories.Select(c => c.Id).ToList();

                int count = 0;
                foreach (var store in stores)
                {
                    foreach (var product in store.Products)
                    {
                        product.CategoryId = categories[count];
                        count= categories.Count == count -1? 0: count+=1;
                    }
                    context.Stores.Add(store);

                    count = 0;
                }
                await context.SaveChangesAsync();
            }
        }

        public async static Task SeedUsers(AppDbContext context)
        {
            context.Database.EnsureCreated();

            if (!context.Users.Any())
            {
                var userData = await File.ReadAllTextAsync("SeedData/User.json");

                List<User> users = JsonConvert.DeserializeObject<List<User>>(userData);

                var stores = context.Stores.Select(store => store.Id).ToList();

                int count = 0;

                foreach (var user in users)
                {
                    foreach (var cart in user.Carts)
                    {
                        cart.StoreId = stores[count];
                        count = stores.Count == count - 1 ? 0 : count+=1;

                        foreach (var order in cart.Orders)
                        {
                            order.UserId = user.Id;
                        }
                    }
                    context.Users.Add(user);
                    count = 0;
                }
                await context.SaveChangesAsync();
            }
        }

        public async static Task SeedCartProducts(AppDbContext context)
        {
            context.Database.EnsureCreated();

            if (!context.CartProducts.Any() && context.Carts.Any() && context.Products.Any())
            {
                var carts = context.Carts.ToList();

                var stores = context.Stores.Include(store=> store.Products).ToList();

                var cartCount = 0;

                var storeCount = 0;

                while (cartCount <= carts.Count-1)
                {
                    foreach (var product in stores[storeCount].Products)
                    {
                        var cartProduct = new CartProduct { Cart = carts[cartCount], Product = product };

                        context.CartProducts.Add(cartProduct);
                        cartCount++;
                        storeCount = storeCount == stores.Count - 1 ? 0 : storeCount += 1;
                        if (cartCount >= carts.Count - 1)
                        {
                            break;
                        }
                    }
                }

                await context.SaveChangesAsync();
            }
        }
    }
}
