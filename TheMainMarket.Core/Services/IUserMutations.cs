using HotChocolate;
using Microsoft.AspNetCore.Identity;
using System.Threading;
using System.Threading.Tasks;
using TheMainMarket.DataAccess;
using TheMainMarket.DTOs.General;
using TheMainMarket.DTOs.UsersDtos;
using TheMainMarket.Models;

namespace TheMainMarketCore.Services
{
    public interface IUserMutations
    {
        Task<UserPayload> AddUserAsync(AddUserInput input, [Service] AppDbContext context, [Service] UserManager<User> userManager, CancellationToken cancellationtoken);
        Task<UserPayload> DeleteUserAsync(DeleteInput input, [Service] AppDbContext context, [Service] UserManager<User> userManager, CancellationToken cancellationtoken);
        Task<LoginUserPayload> LoginUserAsync(LoginUserInput input, [Service] AppDbContext context, [Service] UserManager<User> userManager);
        Task<UserPayload> UpdateUserAsync(UpdateUserInput input, [Service] AppDbContext context, [Service] UserManager<User> userManager, CancellationToken cancellationtoken);
    }
}