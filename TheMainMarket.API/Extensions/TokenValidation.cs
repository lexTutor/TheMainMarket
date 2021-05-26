﻿using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Text;

namespace TheMainMarket.API.Extensions
{
    public static class TokenValidation
    {
        public static TokenValidationParameters AddTokenValidationParameters(this IServiceCollection services, IConfiguration config)
        {
            TokenValidationParameters tokenValidationParams = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateLifetime = true,
                ValidateAudience = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = config["JWTConfigurations:Issuer"],
                ValidAudience = config["JWTConfigurations:Audience"],
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["JWTConfigurations:SecretKey"])),
                ClockSkew = TimeSpan.Zero
            };
            services.AddSingleton(tokenValidationParams);
            return tokenValidationParams;
        }
    }
}
