using Identity.Api.Constants;
using Identity.Application.Common.Constants;
using Identity.Persistence;
using IdentityServer4.AccessTokenValidation;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddIdentityPersistence(builder.Configuration);
var authority = builder.Configuration[IdentityConsts.IdentityAuthority];

builder.Services.AddAuthentication(
      IdentityServerAuthenticationDefaults.AuthenticationScheme)
      .AddIdentityServerAuthentication(options =>
      {
          options.Authority = authority;
          //options.ApiName = "OnlineShop.Api";
          options.RequireHttpsMetadata = false;
      });

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy(IdentityConsts.ApiScopePolicy, policy =>
    {
        policy.RequireAuthenticatedUser();
        policy.RequireClaim(IdentityConsts.ClaimTypeScope, IdentityConsts.ApiScope);
    });
});

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

//using (var scope = app.Services.CreateScope())
//{

//    var serviceProvider = scope.ServiceProvider;
//    try
//    {
//        var context = serviceProvider.GetRequiredService<ApplicationDbContext>();
//        SeedData.EnsureSeedData(context, builder.Services);
//    }
//    catch (Exception m)
//    {
//        Console.WriteLine(m);
//    }
//}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(config =>
    {
        config.RoutePrefix = string.Empty;
        config.SwaggerEndpoint(SwaggerConstants.Url, SwaggerConstants.Name);
    });
}

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers().RequireAuthorization(IdentityConsts.ApiScopePolicy);
});

app.Run();
