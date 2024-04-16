using Identity.Application.Common.Constants;
using Identity.Domain.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Identity.Persistence
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddIdentityPersistence(this IServiceCollection services,
            IConfiguration configuration)
        {
            var connectionString = configuration[IdentityConsts.Connections.Identity];

            services.AddDbContext<ApplicationDbContext>(opt =>
                opt.UseSqlServer(connectionString));

            services.AddIdentity<ApplicationUser, IdentityRole>()
                //.AddApiEndpoints()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            return services;
        }
    }
}
