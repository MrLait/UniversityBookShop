using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using UniversityBookShop.Application.Common.Interfaces;

namespace UniversityBookShop.Persistence;

public static class DependencyInjection
{
    public static IServiceCollection AddPersistence(this IServiceCollection services,
        IConfiguration configuration)
    {
        var connectionString = configuration["DbConnection"];
        services.AddDbContext<ApplicationDbContext>(option =>
        {
            option.UseMySql(connectionString,
                new MySqlServerVersion(new Version(8, 0, 32)),
                p =>
                p.EnableRetryOnFailure(5, TimeSpan.FromSeconds(30), null));

        });

        var serviceCollection = services.AddScoped<IApplicationDbContext>
        (
            provider => provider.GetService<ApplicationDbContext>()!
        );
        return services;
    }
}
