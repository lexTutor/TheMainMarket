using HotChocolate;
using HotChocolate.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using TheMainMarket.DataAccess;
using TheMainMarket.DTOs.CartDtos;
using TheMainMarket.DTOs.CategoryDtos;
using TheMainMarket.DTOs.General;
using TheMainMarket.DTOs.OrderDtos;
using TheMainMarket.DTOs.ProductDtos;
using TheMainMarket.DTOs.StoreDtos;
using TheMainMarket.DTOs.UsersDtos;
using TheMainMarket.Models;
using TheMainMarketCore.Services;

namespace TheMainMarket.Infrastructure.Mutations
{
    public class Mutations
    {
        private readonly IUserMutations _userMutations;
        private readonly IStoreMutations _storeMutations;
        private readonly IProductMutations _productMutations;
        private readonly IProductCategoryMutations _productCategoryMutations;
        private readonly IOrderMutations _orderMutations;
        private readonly ICartMutations _cartMutation;
        public Mutations(IServiceProvider serviceProvider)
        {
            _userMutations = serviceProvider.GetRequiredService<IUserMutations>();
            _storeMutations = serviceProvider.GetRequiredService<IStoreMutations>();
            _productMutations = serviceProvider.GetRequiredService<IProductMutations>();
            _productCategoryMutations = serviceProvider.GetRequiredService<IProductCategoryMutations>();
            _orderMutations = serviceProvider.GetRequiredService<IOrderMutations>();
            _cartMutation = serviceProvider.GetRequiredService<ICartMutations>();
        }

        [Authorize]
        public async Task<CartPayload> AddCart(AddCartInput input, [Service] AppDbContext context, [Service] IHttpContextAccessor contextAccessor)
        {
            var userClaims = contextAccessor.HttpContext.User;
            return await _cartMutation.AddCart(input, context, userClaims.FindFirst(ClaimTypes.NameIdentifier).Value);
        }

        public async Task<CategoryPayload> AddCategory(AddCategoryInput input, [Service] AppDbContext context)
        {
          return await _productCategoryMutations.AddCategory(input, context);
        }
        public async Task<ProductPayload> AddProduct(AddProductInput input, [Service] AppDbContext context)
        {
            return await _productMutations.AddProduct(input, context);
        }
        public async Task<StorePayload> AddStore(AddStoreInput input, [Service] AppDbContext context)
        {
            return await _storeMutations.AddStore(input, context);
        }
        public async Task<UserPayload> AddUserAsync(AddUserInput input, [Service] AppDbContext context, [Service] UserManager<User> userManager, CancellationToken cancellationtoken)
        {
            return await _userMutations.AddUserAsync(input, context, userManager, cancellationtoken);
        }
        [Authorize]
        public async Task<OrderPayload> MakeOrder(MakeOrderInput input, [Service] AppDbContext context, [Service] IHttpContextAccessor contextAccessor)
        {
            var userClaims = contextAccessor.HttpContext.User;
            return await _orderMutations.MakeOrder(input, context, userClaims.FindFirst(ClaimTypes.NameIdentifier).Value);
        }
        public async Task<CategoryPayload> DeleteCategory(DeleteInput input, [Service] AppDbContext context)
        {
            return await _productCategoryMutations.DeleteCategory(input, context);
        }
        [Authorize]
        public async Task<CartPayload> DeleteCart(DeleteInput input, [Service] AppDbContext context, [Service] IHttpContextAccessor contextAccessor)
        {
            var userClaims = contextAccessor.HttpContext.User;
            return await _cartMutation.DeleteCart(input, context, userClaims.FindFirst(ClaimTypes.NameIdentifier).Value);
        }
        public async Task<StorePayload> DeleteStore(DeleteInput input, [Service] AppDbContext context)
        {
            return await _storeMutations.DeleteStore(input, context);
        }
        public async Task<UserPayload> DeleteUserAsync(DeleteInput input, [Service] AppDbContext context, [Service] UserManager<User> userManager, CancellationToken cancellationtoken)
        {
            return await _userMutations.DeleteUserAsync(input, context, userManager, cancellationtoken);
        }
        public async Task<ProductPayload> DeleteProduct(DeleteInput input, [Service]AppDbContext context)
        {
            return await _productMutations.DeleteProduct(input, context);
        }
        public async Task<LoginUserPayload> LoginUserAsync(LoginUserInput input, [Service] AppDbContext context, [Service] UserManager<User> userManager)
        {
            return await _userMutations.LoginUserAsync(input, context, userManager);
        }
        public async Task<CategoryPayload> UpdateCategory(UpdateCategoryInput input, [Service] AppDbContext context)
        {
            return await _productCategoryMutations.UpdateCategory(input, context);
        }
        [Authorize]
        public async Task<OrderPayload> DeleteOrder(DeleteInput input, [Service] AppDbContext context, [Service] IHttpContextAccessor contextAccessor)
        {
            var userClaims = contextAccessor.HttpContext.User;

            return await _orderMutations.DeleteOrder(input, context, userClaims.FindFirst(ClaimTypes.NameIdentifier).Value);
        }
        public async Task<ProductPayload> UpdateProduct(UpdateProductInput input, [Service] AppDbContext context)
        {
            return await _productMutations.UpdateProduct(input, context);
        }
        public async Task<StorePayload> UpdateStore(UpdateStoreInput input, [Service] AppDbContext context)
        {
            return await _storeMutations.UpdateStore(input, context);
        }

        public async Task<UserPayload> UpdateUserAsync(UpdateUserInput input, [Service] AppDbContext context, [Service] UserManager<User> userManager, CancellationToken cancellationtoken)
        {
            return await _userMutations.UpdateUserAsync(input, context, userManager, cancellationtoken);
        }

        [Authorize]
        public async Task<OrderPayload> UpdateOrder(UpdateOrderInput input, [Service] AppDbContext context, [Service] IHttpContextAccessor contextAccessor)
        {
            var userClaims = contextAccessor.HttpContext.User;
            return await _orderMutations.UpdateOrder(input, context, userClaims.FindFirst(ClaimTypes.NameIdentifier).Value);
        }
        [Authorize]
        public async Task<CartPayload> UpdateCart(UpdateCartInput input, [Service] AppDbContext context, [Service] IHttpContextAccessor contextAccessor)
        {
            var userClaims = contextAccessor.HttpContext.User;
            return await _cartMutation.UpdateCart(input, context, userClaims.FindFirst(ClaimTypes.NameIdentifier).Value);
        }
    }
}
