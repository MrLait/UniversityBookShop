using System.Security.Claims;
using Identity.Domain.Models;
using IdentityModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Serilog;

namespace Identity.Persistence
{
    public class SeedData
    {
        public static void EnsureSeedData(ApplicationDbContext context, IServiceCollection services)
        {
            using (var serviceProvider = services.BuildServiceProvider())
            {
                using (var scope = serviceProvider.GetRequiredService<IServiceScopeFactory>().CreateScope())
                {
                    context.Database.Migrate();

                    var userMgr = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
                    var vladimir = userMgr.FindByNameAsync("vladimir").Result;
                    if (vladimir == null)
                    {
                        vladimir = new ApplicationUser
                        {
                            UserName = "vladimir",
                            FirstName = "Vladimir",
                            LastName = "Vlad",
                            Email = "MrLait@email.com",
                            EmailConfirmed = true,
                        };
                        var result = userMgr.CreateAsync(vladimir, "Pass123$").Result;
                        if (!result.Succeeded)
                        {
                            throw new Exception(result.Errors.First().Description);
                        }

                        result = userMgr.AddClaimsAsync(vladimir, new Claim[]{
                            new Claim(JwtClaimTypes.Name, "Vladimir Vlad"),
                            new Claim(JwtClaimTypes.GivenName, "Vladimir"),
                            new Claim(JwtClaimTypes.FamilyName, "Vlad"),
                            new Claim(JwtClaimTypes.WebSite, "https://github.com/MrLait"),
                        }).Result;
                        if (!result.Succeeded)
                        {
                            throw new Exception(result.Errors.First().Description);
                        }
                        Log.Debug("vladimir created");
                    }
                    else
                    {
                        Log.Debug("vladimir already exists");
                    }

                    //var bob = userMgr.FindByNameAsync("bob").Result;
                    //if (bob == null)
                    //{
                    //    bob = new ApplicationUser
                    //    {
                    //        UserName = "bob",
                    //        Email = "BobSmith@email.com",
                    //        EmailConfirmed = true
                    //    };
                    //    var result = userMgr.CreateAsync(bob, "Pass123$").Result;
                    //    if (!result.Succeeded)
                    //    {
                    //        throw new Exception(result.Errors.First().Description);
                    //    }

                    //    result = userMgr.AddClaimsAsync(bob, new Claim[]{
                    //        new Claim(JwtClaimTypes.Name, "Bob Smith"),
                    //        new Claim(JwtClaimTypes.GivenName, "Bob"),
                    //        new Claim(JwtClaimTypes.FamilyName, "Smith"),
                    //        new Claim(JwtClaimTypes.WebSite, "http://bob.com"),
                    //        new Claim("location", "somewhere")
                    //    }).Result;
                    //    if (!result.Succeeded)
                    //    {
                    //        throw new Exception(result.Errors.First().Description);
                    //    }
                    //    Log.Debug("bob created");
                    //}
                    //else
                    //{
                    //    Log.Debug("bob already exists");
                    //}
                }
            }
        }
    }
}