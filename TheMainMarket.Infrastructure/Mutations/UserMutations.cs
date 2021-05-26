using HotChocolate;
using HotChocolate.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading;
using System.Threading.Tasks;
using TheMainMarket.Commons.CustomException;
using TheMainMarket.Core.Repositories;
using TheMainMarket.Core.Services;
using TheMainMarket.DataAccess;
using TheMainMarket.DTOs;
using TheMainMarket.DTOs.General;
using TheMainMarket.DTOs.UsersDtos;
using TheMainMarket.Models;
using TheMainMarketCore.Services;

namespace TheMainMarket.Infrastructure.Mutations
{
    public class UserMutations : IUserMutations
    {
        private readonly IGenericRepository<Token> _tokenRepository;
        private readonly IJWTService<User> _jwtService;

        public UserMutations([Service] IServiceProvider serviceProvider)
        {
            _jwtService = serviceProvider.GetRequiredService<IJWTService<User>>();
            _tokenRepository = serviceProvider.GetRequiredService<IGenericRepository<Token>>();

        }

        public async Task<UserPayload> AddUserAsync(AddUserInput input, [Service] AppDbContext context, [Service] UserManager<User> userManager, CancellationToken cancellationtoken)
        {
            var User = new User
            {
                Email = input.Email,
                FirstName = input.FirstName,
                LastName = input.LastName,
                UserName = input.UserName
            };

            var result = await userManager.CreateAsync(User, input.Password);

            if (!result.Succeeded)
            {
                throw new IdentityException { Errors = result.Errors };
            }
            await context.SaveChangesAsync(cancellationtoken);
            return new UserPayload { Email = User.Email, FirstName = User.FirstName, Id = User.Id, LastName = User.LastName };
        }

        [Authorize]
        public async Task<UserPayload> UpdateUserAsync(UpdateUserInput input, [Service] AppDbContext context, [Service] UserManager<User> userManager, CancellationToken cancellationtoken)
        {
            User user = await userManager.FindByIdAsync(input.Id);

            user.FirstName = string.IsNullOrWhiteSpace(input.FirstName) ? user.FirstName : input.FirstName;
            user.LastName = string.IsNullOrWhiteSpace(input.LastName) ? user.LastName : input.LastName;
            user.Gender = string.IsNullOrWhiteSpace(input.Gender) ? user.Gender : input.Gender;

            var result = await userManager.UpdateAsync(user);

            if (!result.Succeeded)
            {
                throw new IdentityException { Errors = result.Errors };
            }
            await context.SaveChangesAsync(cancellationtoken);
            return new UserPayload { Email = user.Email, FirstName = user.FirstName, Id = user.Id, LastName = user.LastName };
        }

        [Authorize]
        public async Task<UserPayload> DeleteUserAsync(DeleteInput input, [Service] AppDbContext context, [Service] UserManager<User> userManager, CancellationToken cancellationtoken)
        {
            User user = await userManager.FindByIdAsync(input.Id);
            var result = await userManager.DeleteAsync(user);

            if (!result.Succeeded)
            {
                throw new IdentityException { Errors = result.Errors };
            }
            await context.SaveChangesAsync(cancellationtoken);
            return new UserPayload { Email = user.Email, FirstName = user.FirstName, Id = user.Id, LastName = user.LastName };
        }


        public async Task<LoginUserPayload> LoginUserAsync(LoginUserInput input, [Service] AppDbContext context, [Service] UserManager<User> userManager)
        {
            var user = await userManager.FindByEmailAsync(input.Email);
            LoginUserPayload response = new LoginUserPayload();

            if (user != null)
            {
                var check = await userManager.CheckPasswordAsync(user, input.Password);
                if (!check)
                {
                    response.Message = "Invalid credentials";
                    return response;
                }

                await _tokenRepository.DeleteAll(tokens => tokens.UserId == user.Id);
                AuthenticationResult token = await _jwtService.GetToken(user, userManager);

                response.TokenData = token;
                response.Message = "Successful";
                response.Email = user.Email;
                return response;
            }

            response.Message = "Invalid credentials";
            return response;
        }
    }
}