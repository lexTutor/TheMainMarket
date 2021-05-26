using HotChocolate;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheMainMarket.Commons.CustomException;
using TheMainMarket.Core.Repositories;
using TheMainMarket.DataAccess;
using TheMainMarket.DTOs.CartDtos;
using TheMainMarket.DTOs.General;
using TheMainMarket.Infrastructure.Specifications;
using TheMainMarket.Models;
using TheMainMarketCore.Services;

namespace TheMainMarket.Infrastructure.Mutations
{
    public class CartMutation : ICartMutations
    {
        private readonly IGenericRepository<Cart> _cartRepo;
        private readonly IGenericRepository<User> _userRepo;
        private readonly IGenericRepository<CartProduct> _cartProductRepo;
        private readonly IGenericRepository<Product> _productRepo;
        private readonly IGenericRepository<Store> _storeRepo;
        public CartMutation(IServiceProvider serviceProvider)
        {
            _cartRepo = serviceProvider.GetRequiredService<IGenericRepository<Cart>>();
            _userRepo = serviceProvider.GetRequiredService<IGenericRepository<User>>();
            _cartProductRepo = serviceProvider.GetRequiredService<IGenericRepository<CartProduct>>();
            _productRepo = serviceProvider.GetRequiredService<IGenericRepository<Product>>();
            _storeRepo = serviceProvider.GetRequiredService<IGenericRepository<Store>>();
        }


        public async Task<CartPayload> AddCart(AddCartInput input, AppDbContext context, string Id)
        {
            User user = await _userRepo.GetEntityBySpec(new UserSpecification(Id));

            if (user is null)
                throw new AccessViolationException("Forbidden");

            if(await _storeRepo.GetEntityBySpec(new StoreSpecification(input.StoreId)) is null)
                throw new ModelExceptions() { DefaultError = "The store does not exist" };

            if(input.CartProducts is null || input.CartProducts.Count < 0)
                throw new ModelExceptions() { DefaultError = "An empty cart cannot be created" };

            Cart cart = new Cart
            {
                UserId = user.Id,
                StoreId = input.StoreId
            };

            var result = await _cartRepo.AddEntity(cart);

            if (!result)
                throw new ModelExceptions() { DefaultError = "The cart could not be created" };

            List<CartProduct> cartProducts = new List<CartProduct>();
            foreach (var product in input.CartProducts)
            {
                var actualProd = await _productRepo.GetEntityBySpec(new ProductCheckSpecification(product.ProductId));
                if (actualProd is null) { }

                else if(actualProd.StoreId == input.StoreId)
                {
                    CartProduct cartProduct = new CartProduct
                    {
                        CartId = cart.Id,
                        ProductId = product.ProductId
                    };

                    cartProducts.Add(cartProduct);
                }
            }

            if(cartProducts.Count <= 0)
            {
                await _cartRepo.DeleteAll(c=>c.Id == cart.Id);
                throw new ModelExceptions() { DefaultError = "The cart could not be created due to a problem with the products" };
            }

            await _cartProductRepo.AddRangeAsync(cartProducts);

            return new CartPayload
            {
                Id = cart.Id,
                StoreId = cart.StoreId,
                UserId = cart.UserId,
            };
        }
        public async Task<CartPayload> UpdateCart(UpdateCartInput input, [Service] AppDbContext context, string Id)
        {

            Cart cart = await _cartRepo.GetEntityBySpec(new CartCheckSpecification(input.Id));

            if (cart is null)
                throw new ModelExceptions() { DefaultError = $"The cart id {input.Id} is not available" };

            if (cart.UserId != Id)
                throw new AccessViolationException("Forbidden");

            var result = await _cartProductRepo.DeleteAll(cartProducts => cartProducts.CartId == input.Id);

            if (!result)
            {
                throw new ModelExceptions() { DefaultError = "The cart could not be updated" };
            }

            foreach (var product in input.CartProducts)
            {
                CartProduct cartProduct = new CartProduct
                {
                    CartId = cart.Id,
                    ProductId = product.ProductId
                };
                await _cartProductRepo.AddEntity(cartProduct);
            }

            return new CartPayload
            {
                Id = cart.Id,
                StoreId = cart.StoreId,
                UserId = cart.UserId,
            };
        }
        public async Task<CartPayload> DeleteCart(DeleteInput input, [Service] AppDbContext context, string Id)
        {
            Cart cart = await _cartRepo.GetEntityBySpec(new CartCheckSpecification(input.Id));

            if (cart is null)
                throw new ModelExceptions() { DefaultError = $"The cart id {input.Id} is not available" };

            if (cart.UserId != Id)
                throw new AccessViolationException("Forbidden");

            var result = await _cartRepo.DeleteEntity(cart);

            if (!result)
            {
                throw new ModelExceptions() { DefaultError = "The cart could not be deleted" };
            }

            return new CartPayload
            {
                Id = cart.Id,
                StoreId = cart.StoreId,
                UserId = cart.UserId,
            };
        }
    }
}
