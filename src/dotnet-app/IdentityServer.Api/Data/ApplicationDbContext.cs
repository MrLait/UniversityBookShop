using IdentityServer.Api.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace IdentityServer.Api.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }



        //public ApplicationDbContext(DbContextOptions options,
        //    IOptions<OperationalStoreOptions> operationalStoreOptions) : base(options, operationalStoreOptions)
        //{
        //}
    }
}
