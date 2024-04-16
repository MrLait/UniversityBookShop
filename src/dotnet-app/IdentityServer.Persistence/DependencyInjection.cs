﻿using Identity.Domain.Constants;
using Identity.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace IdentityServer.Persistence
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddIdentityServerPersistence(this IServiceCollection services,
            IConfiguration configuration)
        {
            var connectionString = configuration[ConnectionConstants.IdentityServerConnection];
            var IDENTITY_ISSUER = configuration["IDENTITY_ISSUER"];
            var migrationsAssembly = typeof(DependencyInjection).GetTypeInfo().Assembly.GetName().Name;

            services.AddIdentityServer(options =>
                {
                    options.Events.RaiseErrorEvents = true;
                    options.Events.RaiseInformationEvents = true;
                    options.Events.RaiseFailureEvents = true;
                    options.Events.RaiseSuccessEvents = true;

                    // see https://identityserver4.readthedocs.io/en/latest/topics/resources.html
                    options.EmitStaticAudienceClaim = true;
                    options.IssuerUri = IDENTITY_ISSUER;
                })
                 .AddConfigurationStore(options =>
                 {
                     options.ConfigureDbContext = b => b.UseSqlServer(connectionString,
                         sql => sql.MigrationsAssembly(migrationsAssembly));
                 })
                 .AddOperationalStore(options =>
                 {
                     options.ConfigureDbContext = b => b.UseSqlServer(connectionString,
                         sql => sql.MigrationsAssembly(migrationsAssembly));
                 })
                 .AddAspNetIdentity<ApplicationUser>()
                 .AddDeveloperSigningCredential();

            return services;
        }
    }
}
