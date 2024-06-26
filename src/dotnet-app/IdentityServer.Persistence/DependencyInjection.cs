﻿using Identity.Domain.Models;
using IdentityServer.Application.Common.Constants;
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
            var connectionString = configuration[ApiConstants.Connection.IdentityServer];
            var IdentityIssuer = configuration[ApiConstants.IdentityServer.IdentityIssuer];
            var migrationsAssembly = typeof(DependencyInjection).GetTypeInfo().Assembly.GetName().Name;

            //services.Configure<ForwardedHeadersOptions>(options =>
            //{
            //    options.ForwardedHeaders =
            //        ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto | ForwardedHeaders.XForwardedHost;
            //    options.KnownNetworks.Clear();
            //    options.KnownProxies.Clear();
            //});

            services.AddIdentityServer(options =>
                {
                    options.Events.RaiseErrorEvents = true;
                    options.Events.RaiseInformationEvents = true;
                    options.Events.RaiseFailureEvents = true;
                    options.Events.RaiseSuccessEvents = true;

                    // see https://identityserver4.readthedocs.io/en/latest/topics/resources.html
                    options.EmitStaticAudienceClaim = true;
                    options.IssuerUri = IdentityIssuer;
                    //options.PublicOrigin = IDENTITY_ISSUER;
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
