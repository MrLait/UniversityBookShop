using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using UniversityBookShop.Application.Common.Interfaces;
using UniversityBookShop.Persistence.Clients.IdentityServerClient;
using UniversityBookShop.Persistence.Options;

namespace UniversityBookShop.Persistence;

public static class DependencyInjection
{
    public static IServiceCollection AddPersistence(this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddHttpClient<IdentityServerClient>();
        services.AddTransient<IIdentityServerClient, IdentityServerClient>();
        
        var connectionString = configuration["DbConnection"];
        services.AddDbContext<ApplicationDbContext>(option =>
        {
            option.UseMySql(connectionString,
                new MySqlServerVersion(new Version(8, 0, 32)),
                p =>
                p.EnableRetryOnFailure(10, TimeSpan.FromSeconds(30), null));

        });

        var serviceCollection = services.AddScoped<IApplicationDbContext>
        (
            provider => provider.GetService<ApplicationDbContext>()!
        );
        //configuration.GetSection(ServiceAdressOptions.SectionName);
        services.Configure<ServiceAdressOptions>(configuration.GetSection(ServiceAdressOptions.SectionName));
        return services;
    }
}
