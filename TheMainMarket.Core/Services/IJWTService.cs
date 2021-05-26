using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TheMainMarket.DataAccess;
using TheMainMarket.DTOs;
using TheMainMarket.Models;

namespace TheMainMarket.Core.Services
{
    public interface IJWTService<TEntity> where TEntity : IdentityUser
    {
        Task<AuthenticationResult> GetToken(TEntity entity, UserManager<TEntity> _userManager);
        Task<AuthenticationResult> GetRefreshToken(RefreshTokenInput refreshToken, UserManager<TEntity> _userManager);
    }
}
