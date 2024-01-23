using BackOffice.Application.Common.Interfaces;
using BackOffice.Application.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace BackOffice.Persistence
{
    public static class ServiceCollectionExtension
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddTransient<IBookRepository, BookRepository>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();
        }
    }
}
