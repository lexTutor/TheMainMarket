using GraphQL.Server.Ui.Voyager;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using TheMainMarket.API.Extensions;
using TheMainMarket.Commons.ErrorFilters;
using TheMainMarket.Core.Repositories;
using TheMainMarket.Core.Specifications;
using TheMainMarket.DataAccess;
using TheMainMarket.DataAccess.Seed;
using TheMainMarket.Infrastructure.Mutations;
using TheMainMarket.Infrastructure.Repositories;
using TheMainMarket.Infrastructure.Services;
using TheMainMarket.Infrastructure.Specifications;
using TheMainMarket.Models;
using TheMainMarketCore.Services;

namespace TheMainMarket.API
{
    public class Startup
    {
        private readonly IConfiguration _configuration;
        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContextPool<AppDbContext>(optionsAction => optionsAction
            .UseNpgsql(_configuration
            .GetConnectionString("DefaultConnectionString")));

            services.AddIdentityExtensions();
            services.AddCustomErrorFilters();

            var tokenParams = services.AddTokenValidationParameters(_configuration);
            services.AddCors();
            services.AddJWTAuthentication(tokenParams);
            services.AddAuthorization();
            services.AddServiceRegisterations(_configuration);
            services.AddGraphQLExtensions();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, AppDbContext context)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseDataSeeding(context);

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGraphQL();
            });

            app.UseGraphQLVoyager(new VoyagerOptions()
            {
                GraphQLEndPoint = "/graphql"
            }, path: "/graphql-voyager");
        }
    }
}
